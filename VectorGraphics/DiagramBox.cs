using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace VectorGraphics
{
    public partial class DiagramBox : UserControl
    {
        Diagram diagram;
        //выделенная фигура
        Figure selectedFigure = null;
        //фигура или маркер, который тащится мышью
        Figure draggedFigure = null;

        Marker[] markers = new Marker[0];
        Pen selectRectPen;

        public DiagramBox()
        {
            InitializeComponent();

            DoubleBuffered = true;
            ResizeRedraw = true;
            AutoScroll = true;

            selectRectPen = new Pen(Color.Red, 1);
            selectRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }


        //диаграмма, отображаемая компонентом
        public Diagram Diagram
        {
            get { return diagram; }
            set { 
                diagram = value;
                selectedFigure = null;
                draggedFigure = null;
                markers = new Marker[0];
                Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (diagram != null)
            {
                //сначала рисуем соеднительные линии
                foreach (Figure f in diagram.figures)
                    if(f is LineFigure)
                        f.Draw(e.Graphics);
                //затем рисуем плоские фигуры
                foreach (Figure f in diagram.figures)
                    if(f is SolidFigure)
                        f.Draw(e.Graphics);
            }

            //рисуем выделенный прямоугольник
            if (selectedFigure is SolidFigure)
            {
                SolidFigure figure = selectedFigure as SolidFigure;
                RectangleF bounds = figure.Bounds;
                e.Graphics.DrawRectangle(selectRectPen, bounds.Left-2, bounds.Top-2, bounds.Width+4, bounds.Height+4);
            }
            //рисуем маркеры
            foreach (Marker m in markers)
                m.Draw(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            draggedFigure = FindFigureByPoint(e.Location);
            if (!(draggedFigure is Marker))
            {
                selectedFigure = draggedFigure;
                CreateMarkers();
            }
            startDragPoint = e.Location;
            Invalidate();

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (selectedFigure == null)
                    cmMain.Show(PointToScreen(e.Location));
                else
                    cmSelectedFigure.Show(PointToScreen(e.Location));
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (selectedFigure != null)
                editTextToolStripMenuItem_Click(null, null);
        }

        private void CreateMarkers()
        {
            markers = new Marker[0];
            if(selectedFigure is SolidFigure)
            {
                markers = new Marker[1] { new SizeMarker() };
                markers[0].targetFigure = selectedFigure;
            }else
            if (selectedFigure is LineFigure)
            {
                markers = new Marker[2] { new EndLineMarker(diagram, 0), new EndLineMarker(diagram, 1) };
                markers[0].targetFigure = selectedFigure;
                markers[1].targetFigure = selectedFigure;
            }

            UpdateMarkers();
        }

        private void UpdateMarkers()
        {
            foreach (Marker m in markers)
                if(draggedFigure!=m)//маркер который тащится, обновляется сам
                    m.UpdateLocation();
        }

        Point startDragPoint;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (draggedFigure != null && (draggedFigure is SolidFigure))
                {
                    (draggedFigure as SolidFigure).Offset(e.Location.X - startDragPoint.X, e.Location.Y - startDragPoint.Y);
                    UpdateMarkers();
                    Invalidate();
                }
            }
            else
            {
                Figure figure = FindFigureByPoint(e.Location);
                if (figure is Marker)
                    Cursor = Cursors.SizeAll;
                else
                if (figure != null)
                    Cursor = Cursors.Hand;
                else
                    Cursor = Cursors.Default;
            }

            startDragPoint = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            draggedFigure = null;
            UpdateMarkers();
            Invalidate();
        }

        //поиск фигуры, по данной точке
        Figure FindFigureByPoint(Point p)
        {
            //ищем среди маркеров
            foreach (Marker m in markers)
                if (m.IsInsidePoint(p))
                    return m;
            //затем ищем среди плоских фигур
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is SolidFigure && diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            //затем ищем среди линий
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is LineFigure && diagram.figures[i].IsInsidePoint(p))
                if (diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            return null;
        }

        abstract class Marker : SolidFigure
        {
            protected static new int defaultSize = 2;
            public Figure targetFigure;

            public abstract void UpdateLocation();
        }

        class SizeMarker : Marker
        {
            public override void UpdateLocation()
            {
                RectangleF bounds = (targetFigure as SolidFigure).Bounds;
                location = new Point((int)Math.Round(bounds.Right), (int)Math.Round(bounds.Bottom));
            }

            public override bool IsInsidePoint(Point p)
            {
                if (p.X < location.X || p.X > location.X + defaultSize * 2)
                    return false;
                if (p.Y < location.Y || p.Y > location.Y + defaultSize * 2)
                    return false;

                return true;
            }

            public override void Draw(Graphics gr)
            {
                gr.DrawRectangle(Pens.Black, location.X, location.Y, defaultSize * 2, defaultSize * 2);
                gr.FillRectangle(Brushes.Red, location.X, location.Y, defaultSize * 2, defaultSize * 2);
            }

            public override void Offset(int dx, int dy)
            {
                base.Offset(dx, dy);
                (targetFigure as SolidFigure).Size = 
                    SizeF.Add((targetFigure as SolidFigure).Size, new SizeF(dx*2, dy*2));
            }
        }

        class EndLineMarker : Marker
        {
            int pointIndex;
            Diagram diagram;

            public EndLineMarker(Diagram diagram, int pointIndex)
            {
                this.diagram = diagram;
                this.pointIndex = pointIndex;
            }

            public override void UpdateLocation()
            {
                LineFigure line = (targetFigure as LineFigure);
                if (line.From == null || line.To == null)
                    return;//не обновляем маркеры оторванных концов
                //фигура, с которой связана линия
                SolidFigure figure = pointIndex == 0 ? line.From : line.To;
                location = figure.location;
            }

            public override bool IsInsidePoint(Point p)
            {
                if (p.X < location.X - defaultSize || p.X > location.X + defaultSize)
                    return false;
                if (p.Y < location.Y - defaultSize || p.Y > location.Y + defaultSize)
                    return false;

                return true;
            }

            public override void Draw(Graphics gr)
            {
                gr.DrawRectangle(Pens.Black, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
                gr.FillRectangle(Brushes.Red, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
            }

            public override void Offset(int dx, int dy)
            {
                base.Offset(dx, dy);

                //ищем фигуру под маркером
                SolidFigure figure = null;
                for (int i = diagram.figures.Count - 1; i >= 0; i--)
                    if (diagram.figures[i] is SolidFigure && diagram.figures[i].IsInsidePoint(location))
                    {
                        figure = (SolidFigure)diagram.figures[i];
                        break;
                    }

                LineFigure line = (targetFigure as LineFigure);
                if (figure == null)
                    figure = this;//если под маркером нет фигуры, то просто коннектим линию к самому маркеру

                //не позволяем конектится самому к себе
                if (line.From == figure || line.To == figure)
                    return;
                //обновляем конекторы линии
                if (pointIndex == 0)
                    line.From = figure;
                else
                    line.To = figure;

            }
        }

        private void miAddRect_Click(object sender, EventArgs e)
        {
            AddFigure<RectFigure>(startDragPoint);
        }

        private void AddFigure<FigureType>(Point location) where FigureType:SolidFigure
        {
            FigureType figure = Activator.CreateInstance<FigureType>();
            figure.location = location;
            if (diagram != null)
                diagram.figures.Add(figure);
            Invalidate();
        }

        private void addRoundRectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFigure<RoundRectFigure>(startDragPoint);
        }

        private void addRhombToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFigure<RhombFigure>(startDragPoint);
        }

        private void addParalelogrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFigure<ParalelogrammFigure>(startDragPoint);
        }

        private void addEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFigure<EllipseFigure>(startDragPoint);
        }

        private void addStackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFigure<StackFigure>(startDragPoint);
        }

        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Add(selectedFigure);
                Invalidate();
            }
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Insert(0,selectedFigure);
                Invalidate();
            }
        }

        private void addFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFigure<FrameFigure>(startDragPoint);
        }

        private void editTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                SolidFigure figure = (selectedFigure as SolidFigure);
                TextBox textBox = new TextBox();
                textBox.Parent = this;
                textBox.SetBounds(figure.TextBounds.Left, figure.TextBounds.Top, figure.TextBounds.Width, figure.TextBounds.Height);
                textBox.Text = figure.text;
                textBox.Multiline = true;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Focus();
                textBox.LostFocus += new EventHandler(textBox_LostFocus);
            }
        }

        void textBox_LostFocus(object sender, EventArgs e)
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                (selectedFigure as SolidFigure).text = (sender as TextBox).Text;
            }
            Controls.Remove((Control)sender);
        }

        private void miAddLine_Click(object sender, EventArgs e)
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                LineFigure line = new LineFigure();
                line.From = (selectedFigure as SolidFigure);
                EndLineMarker marker = new EndLineMarker(diagram, 1);
                marker.location = line.From.location;
                marker.location.Offset(0, (int)line.From.Size.Height/2+10);
                line.To = marker;
                diagram.figures.Add(line);
                selectedFigure = line;
                CreateMarkers();
                
                Invalidate();
            }
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            if (selectedFigure != null)
            {
                //удалем фигуру
                diagram.figures.Remove(selectedFigure);

                //удялаем также все линии, ведущие к данной фигуре
                for(int i = diagram.figures.Count-1;i>=0;i--)
                    if (diagram.figures[i] is LineFigure)
                    {
                        LineFigure line = (diagram.figures[i] as LineFigure);
                        if (line.To == selectedFigure || line.From == selectedFigure)
                            diagram.figures.RemoveAt(i);
                    }

                selectedFigure = null;
                draggedFigure = null;
                CreateMarkers();

                Invalidate();
            }
        }
    }
}
