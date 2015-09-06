using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Printing;

namespace Diagrams
{
    public partial class DiagramBox : UserControl
    {
        //сама блок-схема
        Diagram diagram;
        //выделенная фигура
        Figure selectedFigure = null;
        //фигура или маркер, который тащится мышью
        Figure draggedFigure = null;

        List<Marker> markers = new List<Marker>();
        Pen selectRectPen;

        public DiagramBox()
        {
            InitializeComponent();

            AutoScroll = true;

            DoubleBuffered = true;
            ResizeRedraw = true;

            selectRectPen = new Pen(Color.Red, 1);
            selectRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public event EventHandler SelectedChanged;

        public Figure SelectedFigure
        {
            get { return selectedFigure; }
            set
            {
                selectedFigure = value;
                CreateMarkers();
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }


        //диаграмма, отображаемая компонентом
        public Diagram Diagram
        {
            get { return diagram; }
            set
            {
                diagram = value;
                selectedFigure = null;
                draggedFigure = null;
                markers.Clear();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics gr)
        {
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//выбираем качество отрисовки
            gr.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);//устанавливаем начало координат в начало проскролленной области

            if (diagram != null)
            {
                //сначала рисуем соединительные линии
                foreach (Figure f in diagram.figures)
                    if (f is LedgeLineFigure)
                        f.Draw(gr);
                //затем рисуем плоские фигуры
                foreach (Figure f in diagram.figures)
                    if (f is SolidFigure)
                        f.Draw(gr);
                //чтобы линии не отрисовывались поверх фигур 
            }

            //рисуем прямоугольник выделенной фигуры
            if (selectedFigure is SolidFigure)
            {
                SolidFigure figure = selectedFigure as SolidFigure;
                RectangleF bounds = figure.Bounds;
                gr.DrawRectangle(selectRectPen, bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
            }
            //рисуем маркеры
            foreach (Marker m in markers)
                m.Draw(gr);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point location = e.Location;//получаем координаты щелчка
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);//переносим в нашу систему координат, относительно скроллинга

            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                draggedFigure = FindFigureByPoint(location);
                if (!(draggedFigure is Marker))//если выбранная фигура - не маркер
                {
                    selectedFigure = draggedFigure;//то выделяем ее
                    CreateMarkers();//и рисуем маркеры
                }
                else
                {
                    Cursor.Hide();//убираем курсор
                }

                startDragPoint = location;//меняем точку начала перетаскивания
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }

        public void CreateMarkers()
        {
            markers = new List<Marker>();
            if (selectedFigure != null)
            {
                foreach (Marker m in selectedFigure.GetMarkers(diagram))
                    markers.Add(m);
                UpdateMarkers();
            }
        }

        private void UpdateMarkers()
        {
            foreach (Marker m in markers)
                if (draggedFigure != m)//маркер который тащится, обновляется сам
                    m.UpdateLocation();
        }

        Point startDragPoint;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point location = e.Location;//получаем координаты курсора
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);//переносим в нашу систему координат, относительно скроллинга
            if (e.Button == System.Windows.Forms.MouseButtons.Left)//если зажата левая клавиша мыши
            {
                if (draggedFigure != null && (draggedFigure is SolidFigure))//и перетаскивается какая-либо фигура
                {
                    (draggedFigure as SolidFigure).Offset(location.X - startDragPoint.X, location.Y - startDragPoint.Y);//смещаем ее
                    UpdateMarkers();
                    Invalidate();
                    CalcAutoScrollPosition();//рассчитываем положение полос прокрутки
                }
            }
            else
            {
                //если не зажата левая кнопка

                Figure figure = FindFigureByPoint(location);
                if (figure is Marker)
                {//если фигура - маркер
                    Cursor = (figure as Marker).Cursor;//меняем курсор на соответсвующий маркера
                }
                else
                {//если нет
                    if (figure != null)
                        Cursor = Cursors.Hand;//если курсор вообще не указывает на фигуру - меняем его на руку
                    else
                        Cursor = Cursors.Default;//если указывает - ставим по умолчанию
                }
            }

            startDragPoint = location;
        }
        private void CalcAutoScrollPosition()
        {
            RectangleF r = new RectangleF(0, 0, 0, 0);
            //перебираем все фигуры, ищем максимальные координаты
            foreach (Figure f in diagram.figures)//заключаем все 
                if (f != null && f is SolidFigure)//фигуры в один 
                    r = RectangleF.Union(r, (f as SolidFigure).Bounds);//большой прямоугольник (минимальный)

            Size size = new Size((int)r.Width, (int)r.Height);
            if (size != AutoScrollMinSize)
                AutoScrollMinSize = size;//меняем прокручиваемую область на размеры этого прямоугольника
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor.Show();
            draggedFigure = null;
            UpdateMarkers();
            Invalidate();
        }

        //поиск фигуры, по данной точке
        public Figure FindFigureByPoint(Point p)
        {
            //ищем среди маркеров
            for (int i = markers.Count - 1; i >= 0; i--)
                if (markers[i].IsInsidePoint(p))
                    return markers[i];
            //затем ищем среди плоских фигур
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is SolidFigure && diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            //затем ищем среди линий
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is LedgeLineFigure && diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            return null;
        }

        public void AddFigure<FigureType>(PointF location) where FigureType : SolidFigure, new()
        {
            FigureType figure = new FigureType();
            figure.location = location;
            if (diagram != null)
                diagram.figures.Add(figure);
            Invalidate();
        }

        public void SelectedBringToFront()
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Add(selectedFigure);
                Invalidate();
            }
        }
   

        public void SelectedSendToBack()
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Insert(0, selectedFigure);
                Invalidate();
            }
        }

        public void Inc()
        {
            if (selectedFigure != null)
                if ((selectedFigure as SolidFigure).FontSize < 52)
                    (selectedFigure as SolidFigure).FontSize = (selectedFigure as SolidFigure).FontSize + 2;
            Invalidate();
        }
        public void Dec()
        {
            if (selectedFigure != null)
                if ((selectedFigure as SolidFigure).FontSize > 8)
                    (selectedFigure as SolidFigure).FontSize = (selectedFigure as SolidFigure).FontSize - 2;
            Invalidate();
        }

        public void SelectedBeginEditText()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                SolidFigure figure = (selectedFigure as SolidFigure);
                TextBox textBox = new TextBox();//создаем текстбокс
                textBox.Parent = this;//устанавливаем его родителем ДиаграмБокс
                textBox.SetBounds(figure.TextBounds.Left, figure.TextBounds.Top, figure.TextBounds.Width, figure.TextBounds.Height);//устанавливаем его границы
                textBox.Text = figure.text;
                textBox.Multiline = true;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.AutoSize = true;
                textBox.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
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

        public void SelectedAddLedgeLine()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                LedgeLineFigure line = new LedgeLineFigure();
                line.From = (selectedFigure as SolidFigure);
                EndLineMarker marker = new EndLineMarker(diagram, 1);
                marker.location = line.From.location;
                marker.location = marker.location = new PointF(marker.location.X, marker.location.Y + line.From.Size.Height / 2 + 10);
                line.To = marker;
                diagram.figures.Add(line);
                selectedFigure = line;
                CreateMarkers();
                Invalidate();
            }
        }

        public void SelectedDelete()
        {
            if (selectedFigure != null)
            {
                //удалем фигуру
                diagram.figures.Remove(selectedFigure);

                //удялаем также все линии, ведущие к данной фигуре
                for (int i = diagram.figures.Count - 1; i >= 0; i--)
                    if (diagram.figures[i] is LedgeLineFigure)
                    {
                        LedgeLineFigure line = (diagram.figures[i] as LedgeLineFigure);
                        if (line.To == selectedFigure || line.From == selectedFigure)
                            diagram.figures.RemoveAt(i);
                    }

                selectedFigure = null;
                draggedFigure = null;
                CreateMarkers();

                Invalidate();
            }
        }

        //преобразуем в картинку
        public Bitmap GetImage()
        {
            selectedFigure = null;
            draggedFigure = null;
            CreateMarkers();
            Bitmap bmp = new Bitmap(Bounds.Width, Bounds.Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp;
        }
        int i = 0;
        string str2 = " ";
        public string Help()
        {

            while (i == 0)
            {
                string filename = "Log.txt";
                FileStream aFile = new FileStream(filename, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                string str = sr.ReadLine();
                while (str != null)
                {
                    str2 = str2.Insert(str2.Length, str);
                    str2 = str2.Insert(str2.Length, "\n");
                    str = sr.ReadLine();
                }
                ++i;
            }
            return str2;
        }

    }

}
