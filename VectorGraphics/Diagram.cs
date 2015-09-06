using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace VectorGraphics
{
    //диаграмма
    [Serializable]
    public class Diagram
    {
        public readonly List<Figure> figures = new List<Figure>();
    }

    //фигура
    [Serializable]
    public abstract class Figure
    {
        protected readonly GraphicsPath path = new GraphicsPath();
        public Pen pen = Pens.Black;

        //точка находится внутри фигуры?
        public abstract bool IsInsidePoint(Point p);

        //отрисовка фигуры
        public abstract void Draw(Graphics gr);
    }

    //многоугольник с текстом внутри
    public abstract class SolidFigure: Figure
    {
        protected static int defaultSize = 40;

        public Brush brush = Brushes.White;
        public Point location;
        protected RectangleF textRect;
        public string text = null;
        protected StringFormat stringFormat;

        public SolidFigure()
        {
            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }

        public override bool IsInsidePoint(Point p)
        {
            return path.IsVisible(p.X - location.X, p.Y - location.Y);
        }
        
        public RectangleF Bounds
        {
            get
            {
                RectangleF bounds = path.GetBounds();
                return new RectangleF(bounds.Left + location.X, bounds.Top + location.Y, bounds.Width, bounds.Height);
            }
        }

        public Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int)textRect.Left + location.X, (int)textRect.Top + location.Y, (int)textRect.Width, (int)textRect.Height);
            }
        }

        public SizeF Size
        {
            get { return path.GetBounds().Size; }
            set
            {
                SizeF oldSize = path.GetBounds().Size;
                SizeF newSize = new SizeF(Math.Max(1, value.Width), Math.Max(1, value.Height));
                //коэффициент шкалировани по x
                float kx = newSize.Width / oldSize.Width;
                //коэффициент шкалировани по y
                float ky = newSize.Height / oldSize.Height;
                Scale(kx, ky);
            }
        }

        public void Scale(float scaleX, float scaleY)
        {
            //масштабируем линии
            Matrix m = new Matrix();
            m.Scale(scaleX, scaleY);
            path.Transform(m);
            //масштабируем прямоугльник текста
            textRect = new RectangleF(textRect.Left * scaleX, textRect.Top * scaleY, textRect.Width * scaleX, textRect.Height * scaleY);
        }

        public virtual void Offset(int dx, int dy)
        {
            location.Offset(dx, dy);
            if(location.X < 0)
                location.X = 0;
            if (location.Y < 0)
                location.Y = 0;
        }

        public override void Draw(Graphics gr)
        {
            gr.TranslateTransform(location.X, location.Y);
            gr.FillPath(brush, path);
            gr.DrawPath(pen, path);
            if (!string.IsNullOrEmpty(text))
            {
                gr.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, textRect, stringFormat);
            }
            gr.ResetTransform();
        }
    }

    //прямоугольник
    public class RectFigure : SolidFigure
    {
        public RectFigure()
        {
            path.AddRectangle(new RectangleF(-defaultSize, -defaultSize/2, 2*defaultSize, defaultSize));
            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);
        }
    }

    //скругленный прямоугольник
    public class RoundRectFigure : SolidFigure
    {
        public RoundRectFigure()
        {
            float diameter = 16f; 
            SizeF sizeF = new SizeF( diameter, diameter );
            RectangleF arc = new RectangleF( -defaultSize, -defaultSize/2, sizeF.Width, sizeF.Height );
            path.AddArc( arc, 180, 90 );
            arc.X = defaultSize-diameter;
            path.AddArc( arc, 270, 90 );
            arc.Y = defaultSize/2-diameter;
            path.AddArc( arc, 0, 90 );
            arc.X = -defaultSize;
            path.AddArc( arc, 90, 90 );
            path.CloseFigure(); 

            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);
        }
    }

    //ромб
    public class RhombFigure : SolidFigure
    {
        public RhombFigure()
        {
            path.AddPolygon(new PointF[]{
                new PointF(-defaultSize, 0),
                new PointF(0, -defaultSize/2),
                new PointF(defaultSize, 0),
                new PointF(0, defaultSize/2)
            });
            textRect = new RectangleF(-defaultSize/2, -defaultSize / 4, defaultSize, defaultSize/2);
        }
    }

    //паралелограмм
    public class ParalelogrammFigure : SolidFigure
    {
        public ParalelogrammFigure()
        {
            float shift = 8f;
            path.AddPolygon(new PointF[]{
                new PointF(-defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize - shift/2, defaultSize/2),
                new PointF(-defaultSize - shift/2, defaultSize/2),
            });
            textRect = new RectangleF(-defaultSize + shift / 2, -defaultSize / 2 + 2, 2 * defaultSize - shift, defaultSize - 4);
        }
    }

    //эллипс
    public class EllipseFigure : SolidFigure
    {
        public EllipseFigure()
        {
            path.AddEllipse(new RectangleF(-defaultSize, -defaultSize/2, defaultSize*2, defaultSize));
            textRect = new RectangleF(-defaultSize / 1.4f, -defaultSize / 2 / 1.4f , 2 * defaultSize / 1.4f, defaultSize / 1.4f);
        }
    }

    //стопка прямоугольников
    public class StackFigure : SolidFigure
    {
        public StackFigure()
        {
            float shift = 4f;
            path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2, defaultSize * 2, defaultSize));
            path.AddLines(new PointF[]{
                new PointF(-defaultSize + shift, defaultSize / 2),
                new PointF(-defaultSize + shift, defaultSize / 2 + shift),
                new PointF(defaultSize + shift, defaultSize / 2 + shift),
                new PointF(defaultSize + shift, -defaultSize / 2 + shift),
                new PointF(defaultSize, -defaultSize / 2 + shift),
                new PointF(defaultSize, defaultSize / 2)
            });

            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);
        }
    }

    //рамка
    public class FrameFigure : SolidFigure
    {
        static Pen clickPen = new Pen(Color.Transparent, 3);

        public FrameFigure()
        {
            path.AddRectangle(new RectangleF(0, -defaultSize, defaultSize * 4, defaultSize*2));
            textRect = new RectangleF(- defaultSize*2 + 3, -defaultSize*2, 4 * defaultSize - 6, defaultSize - 4);
        }

        public override bool IsInsidePoint(Point p)
        {
            return path.IsOutlineVisible(p.X - location.X, p.Y - location.Y, clickPen);
        }

        public override void Draw(Graphics gr)
        {
            gr.TranslateTransform(location.X, location.Y);
            gr.DrawPath(pen, path);
            if (!string.IsNullOrEmpty(text))
                gr.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, textRect, StringFormat.GenericDefault);
            gr.ResetTransform();
        }
    }

    //соединительная линия
    public class LineFigure : Figure
    {
        public SolidFigure From;
        public SolidFigure To;
        static Pen clickPen = new Pen(Color.Transparent, 3);

        public override void Draw(Graphics gr)
        {
            if (From == null || To == null)
                return;

            RecalcEndPoints();
            gr.DrawLine(pen, From.location, To.location);
        }

        public override bool IsInsidePoint(Point p)
        {
            if (From == null || To == null)
                return false;

            RecalcEndPoints();
            return path.IsOutlineVisible(p, clickPen);
        }

        void RecalcEndPoints()
        {
            PointF[] points = null;
            if(path.PointCount>0)
                points = path.PathPoints;
            if(path.PointCount!=2 || points[0]!=From.location || points[1]!=To.location)
            {
                path.Reset();
                path.AddLine(From.location, To.location);
            }
        }
    }
}
