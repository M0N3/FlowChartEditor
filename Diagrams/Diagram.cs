using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Diagrams
{
    //класс "блок-схема"
    [Serializable]
    public class Diagram
    {
        //список фигур диаграммы
        public readonly List<Figure> figures = new List<Figure>();//список всех блоков

        //сохранение диаграммы в файл
        public void Save(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
                new BinaryFormatter().Serialize(fs, this);
        }

        //чтение диаграммы из файла
        public static Diagram Load(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
                return (Diagram)new BinaryFormatter().Deserialize(fs);
        }
    }

    //фигура (абстрактый класс -блок, стрелка или маркер)
    [Serializable]
    public abstract class Figure
    {
        //линии фигуры
        readonly SerializableGraphicsPath serializablePath = new SerializableGraphicsPath();//путь отрисовки
        protected GraphicsPath Path { get { return serializablePath.path; } }
        
        //карандаш отрисовки линий
        protected Color _penColor = Color.Teal;
        protected float _penWidth = 1;
        [NonSerialized]
        protected Pen _pen;

        public virtual Pen pen
        {
            get
            {
                if (_pen == null)
                    _pen = new Pen(_penColor, _penWidth);
                return _pen;
            }
        }
        
        public Color penColor
        {
            get { return _penColor; }
            set { _penColor = value; _pen = null; }
        }

        public float penWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; _pen = null; }
        }

        //точка находится внутри фигуры?
        public abstract bool IsInsidePoint(PointF p);

        //отрисовка фигуры
        public abstract void Draw(Graphics gr);

        //получение маркеров
        public abstract IEnumerable<Marker> GetMarkers(Diagram diagram);

        public virtual Figure Clone()
        {
            return (Figure)MemberwiseClone();
        }
    }

    //многоугольник с текстом внутри
    //абстрактный класс "блок"
    [Serializable]
    public abstract class SolidFigure : Figure
    {
        //размер новой фигуры, по умолчанию
        protected static int defaultSize = 40;
        //заливка фигуры
        Color _color = Color.DarkSeaGreen;
        protected int _FontSize = 10;
        //местоположение центра фигуры
        public PointF location;
        //прямоугольник, в котором расположен текст
        protected RectangleF textRect;
        //размер текста
        public int FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }
        public string text = null;
        
        [NonSerialized]
        public Brush _brush;

        public Color color
        {
            get { return _color; }
            set { _color = value; _brush = null; }
        }

        public virtual Brush brush
        {
            get
            {
                if (_brush == null)
                    _brush = new SolidBrush(_color);
                return _brush;
            }
        }

        //возвращает формат текста
        protected virtual StringFormat StringFormat
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }

        //находится ли точка внутри контура?
        public override bool IsInsidePoint(PointF p)
        {
            return Path.IsVisible(p.X - location.X, p.Y - location.Y);
        }

        //прямоугольник вокруг фигуры (в абсолютных координатах)
        public virtual RectangleF Bounds
        {
            get
            {
                RectangleF bounds = Path.GetBounds();
                return new RectangleF(bounds.Left + location.X, bounds.Top + location.Y, bounds.Width, bounds.Height);
            }
        }

        //прямоугольник текста (в абсолютных координатах)
        public Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int)(textRect.Left + location.X), (int)(textRect.Top + location.Y), (int)textRect.Width, (int)textRect.Height);
            }
        }

        //размер прямоугольника вокруг фигуры
        public SizeF Size
        {
            get { return Path.GetBounds().Size; }
            set
            {
                SizeF oldSize = Path.GetBounds().Size;
                SizeF newSize = new SizeF(Math.Max(80, value.Width), Math.Max(40, value.Height));
                //коэффициент шкалировани по x
                float kx = newSize.Width / oldSize.Width;
                //коэффициент шкалировани по y
                float ky = newSize.Height / oldSize.Height;
                Scale(kx, ky);
            }
        }

        //изменение масштаба фигуры
        public virtual void Scale(float scaleX, float scaleY)
        {
            //масштабируем линии
            Matrix m = new Matrix();//матрица геометрического преобразования

            m.Scale(scaleX, scaleY);//передаем матрице масштабы
            Path.Transform(m);//преобразуем отрисовку фигуры, передав ей матрицу
            //масштабируем прямоугльник текста
            textRect = new RectangleF(textRect.Left * scaleX, textRect.Top * scaleY, textRect.Width * scaleX, textRect.Height * scaleY);//изменяем область текста
           //FontSize = Convert.ToInt32(textRect.Height - (textRect.Height * 0.7) + 1);//изменяем размер шрифта
        }

        //сдвиг местоположения фигуры
        public virtual void Offset(float dx, float dy)
        {
            location = location = new PointF(location.X + dx, location.Y + dy);
            if (location.X < 0)
                location.X = 0;
            if (location.Y < 0)
                location.Y = 0;
        }

        //отрисовка фигуры
        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();//сохраняем значение объекта графика (где будет отрисовываться элемент)
            gr.TranslateTransform(location.X, location.Y);//меняет точку отсчета координат в объекте графики - чтобы она была в центре блока
            gr.FillPath(brush, Path);//заполняем блок цветом
            gr.DrawPath(pen, Path);//рисуем контур

            Font font = new System.Drawing.Font("Arial", FontSize, FontStyle.Regular);//выбираем шрифт
            if (!string.IsNullOrEmpty(text))//есть ли текст
                gr.DrawString(text, font, Brushes.Black, textRect, StringFormat);//если да - отрисовываем его
            gr.Restore(transState);//возвращаем прежнее состояние (точка отсчета координат возвращается на прежнее место)
        }

        //создание маркера для изменения размера
        public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            Marker m = new SizeMarker();
            m.targetFigure = this;
            yield return m;
        }
    }

    //прямоугольник
    [Serializable]
    public class RectFigure : SolidFigure
    {
        public RectFigure()
        {
            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2, 2 * defaultSize, defaultSize));
            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);
        }
    }
    //процесс
    [Serializable]
    public class ProcessFigure : SolidFigure
    {
        public ProcessFigure()
        {

            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2, defaultSize / 5, defaultSize));
            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2, defaultSize + 48, defaultSize));
            Path.AddRectangle(new RectangleF(defaultSize, -defaultSize / 2, 8, defaultSize));
            textRect = new RectangleF(-defaultSize +3, -defaultSize / 2 + 2, 2 * defaultSize, defaultSize - 4);
        }
    }
    //Comment
    [Serializable]
    public class CommentFigure : SolidFigure
    {
        public CommentFigure()
        {

           Path.AddRectangle(new RectangleF(-2, -defaultSize / 2, defaultSize*2 -5, defaultSize));
            Path.AddRectangle(new RectangleF(3, -defaultSize / 2, defaultSize*2-10, defaultSize));
            textRect = new RectangleF(-defaultSize +defaultSize, -defaultSize / 2 + 2, 2 * defaultSize, defaultSize - 4);
        }
    }
    //скругленный прямоугольник
    [Serializable]
    public class RoundRectFigure : SolidFigure
    {
        public RoundRectFigure()
        {
            float diameter = 16f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(-defaultSize, -defaultSize / 2, sizeF.Width, sizeF.Height);
            Path.AddArc(arc, 180, 90);
            arc.X = defaultSize - diameter;
            Path.AddArc(arc, 270, 90);
            arc.Y = defaultSize / 2 - diameter;
            Path.AddArc(arc, 0, 90);
            arc.X = -defaultSize;
            Path.AddArc(arc, 90, 90);
            Path.CloseFigure();

            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);
        }
    }

    //ромб
    [Serializable]
    public class RhombFigure : SolidFigure
    {
        public RhombFigure()
        {
            Path.AddPolygon(new PointF[]{
                new PointF(-defaultSize, 0),
                new PointF(0, -defaultSize/2),
                new PointF(defaultSize, 0),
                new PointF(0, defaultSize/2)
            });
            textRect = new RectangleF(-defaultSize / 2, -defaultSize / 4, defaultSize, defaultSize / 2);
        }
    }

    //паралелограмм
    [Serializable]
    public class ParalelogrammFigure : SolidFigure
    {
        public ParalelogrammFigure()
        {
            float shift = 8f;
            Path.AddPolygon(new PointF[]{
                new PointF(-defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize - shift/2, defaultSize/2),
                new PointF(-defaultSize - shift/2, defaultSize/2),
            });
            textRect = new RectangleF(-defaultSize + shift / 2, -defaultSize / 2 + 2, 2 * defaultSize - shift, defaultSize - 4);
        }
    }
    //кружочек
    [Serializable]
    public class CircleFigure : SolidFigure
    {
        public CircleFigure()
        {
            Path.AddEllipse(new RectangleF(-defaultSize + 20, -defaultSize / 2, defaultSize, defaultSize));
            textRect = new RectangleF(-defaultSize, -defaultSize / 2 / 1.4f, defaultSize, defaultSize / 1.4f);
        }
    }

    //Цикл фор
    [Serializable]
    public class CycleFigure : SolidFigure
    {
        public CycleFigure()
        {
            Path.AddPolygon(new PointF[]{
               new PointF(-defaultSize, defaultSize/2), 
                  new PointF(-defaultSize*2, 0), 
                     new PointF(-defaultSize, -defaultSize/2), 
                        new PointF(defaultSize, -defaultSize/2),
                           new PointF(2*defaultSize, 0), 
                              new PointF(defaultSize, defaultSize/2), 
               
            });
            textRect = new RectangleF(-defaultSize, -defaultSize / 4, defaultSize * 4 / 2, defaultSize / 2);
        }
    }
 
    //линия 
    [Serializable]
    public class LedgeLineFigure : Figure
    {
        readonly SerializableGraphicsPath serializableEndPath = new SerializableGraphicsPath();
        protected GraphicsPath EndPath { get { return serializableEndPath.path; } }

        public SolidFigure From;
        public SolidFigure To;
        static Pen clickPen = new Pen(Color.Transparent, 3);//толщина линии для выделения

        public virtual Pen penl
        {
            get
            {
                if (_pen == null)
                {
                    GraphicsPath hPath = new GraphicsPath();
                    CustomLineCap cust = new CustomLineCap(null, hPath);
                    _pen = new Pen(_penColor, 3.5f);
                    _pen.CustomStartCap = cust;
                    _pen.EndCap = LineCap.ArrowAnchor;
                }
                return _pen;
            }
        }

        public override void Draw(Graphics gr)
        {
            if (From == null || To == null)
                return;

            RecalcPath();
            gr.DrawPath(penl, Path);
            gr.DrawPath(penl, EndPath);
        }

        public override bool IsInsidePoint(PointF p)
        {
            if (From == null || To == null)
                return false;
            
            return EndPath.IsOutlineVisible(p, clickPen) || Path.IsOutlineVisible(p, clickPen);
        }

        //координата X точки "перелома"
        internal float ledgePositionX = -1;
        PointF point = new PointF(10, 10);
        protected void RecalcPath()
        {
            PointF[] points = null;

            if (ledgePositionX < 0)
                ledgePositionX = (From.location.X + To.location.X) / 2;

            if (Path.PointCount > 0)
                points = Path.PathPoints;
            PointF middle = new PointF(ledgePositionX, (From.location.Y + To.location.Y) / 2);//точка перегиба

            //мы разделили линию на четыре:
                Path.Reset();
                Path.AddLines(new PointF[]{
                    From.location,
                   new PointF(ledgePositionX, From.location.Y),
                   middle});//первые две идут до срединной стрелочки
                EndPath.Reset();
                EndPath.AddLines(new PointF[]{
                    middle,
                   new PointF(ledgePositionX, To.location.Y),
                    To.location
                    });//а вторые после нее
        }

        public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            RecalcPath();
            EndLineMarker m1 = new EndLineMarker(diagram, 0);//маркер в начале линии
            m1.targetFigure = this;
            yield return m1;

            EndLineMarker m2 = new EndLineMarker(diagram, 1);//маркер в конце линии
            m2.targetFigure = this;
            yield return m2;

            LedgeMarker m3 = new LedgeMarker();//маркер в точке перегиба
            m3.targetFigure = this;
            m3.UpdateLocation();
            yield return m3;
        }
    }

    //сериализуемая обертка над GraphicsPath
    [Serializable]
    public class SerializableGraphicsPath : ISerializable
    {
        public GraphicsPath path = new GraphicsPath();//GraphicsPath - несериализуемый path

        public SerializableGraphicsPath()
        {
        }
        private SerializableGraphicsPath(SerializationInfo info, StreamingContext context)//конструктор. Нужен для открытия существующих схем
        {
            if (info.MemberCount > 0)
            {
                PointF[] points = (PointF[])info.GetValue("p", typeof(PointF[]));
                byte[] types = (byte[])info.GetValue("t", typeof(byte[]));
                path = new GraphicsPath(points, types);
            }
            else
                path = new GraphicsPath();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)//поэтому при помощи интерфейса ISerializable сериализуем его обходным путем 
        {
            if (path.PointCount > 0)
            {
                info.AddValue("p", path.PathPoints);//сериализуем поля Path'а
                info.AddValue("t", path.PathTypes);
            }
        }
    }

    //абстрактный класс маркера
    [Serializable]
    public abstract class Marker : SolidFigure
    {
        protected static new int defaultSize = 2;
        public Figure targetFigure;

        public Marker()
        {
            color = Color.Red;
        }

        public virtual System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return System.Windows.Forms.Cursors.SizeAll;//курсор при наведении на маркер
            }
        }

        public override bool IsInsidePoint(PointF p)
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
            gr.FillRectangle(brush, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
        }

        public abstract void UpdateLocation();
    }


    public class SizeMarker : Marker
    {
        //маркер смещается вместе с фигурой
        public override void UpdateLocation()
        {
            RectangleF bounds = (targetFigure as SolidFigure).Bounds;
            location = new PointF(bounds.Right + defaultSize / 2, bounds.Bottom + defaultSize / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            (targetFigure as SolidFigure).Size =
                SizeF.Add((targetFigure as SolidFigure).Size, new SizeF(dx * 2, dy * 2));
        }
    }

    [Serializable]
    public class EndLineMarker : Marker
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
            LedgeLineFigure line = (targetFigure as LedgeLineFigure);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            SolidFigure figure = pointIndex == 0 ? line.From : line.To;
            location = figure.location;
        }

        public override void Offset(float dx, float dy)
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

            LedgeLineFigure line = (targetFigure as LedgeLineFigure);
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

    [Serializable]
    public class LedgeMarker : Marker
    {
        public override void UpdateLocation()
        {
            LedgeLineFigure line = (targetFigure as LedgeLineFigure);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            location = new PointF(line.ledgePositionX, (line.From.location.Y + line.To.location.Y) / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, 0);
            (targetFigure as LedgeLineFigure).ledgePositionX += dx;
        }
    }
}
