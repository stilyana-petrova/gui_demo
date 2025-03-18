using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    /// <summary>
    /// Клас за чертаене на триъгълник
    /// </summary>
    public class TriangleShape:Shape
    {
        private PointF[] points;
        public PointF[] Points 
        {
            get { return points; }
            set { points = value; }
        }
        #region Constructor
        public TriangleShape(PointF p1, PointF p2, PointF p3)
        {
            points = new PointF[] { p1, p2, p3 };

            float minX = Math.Min(p1.X, Math.Min(p2.X, p3.X));
            float minY = Math.Min(p1.Y, Math.Min(p2.Y, p3.Y));
            float maxX = Math.Max(p1.X, Math.Max(p2.X, p3.X));
            float maxY = Math.Max(p1.Y, Math.Max(p2.Y, p3.Y));

            this.Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
            this.FillColor = Color.White;
            this.BorderColor = Color.Black;
            this.BorderWidth = 2f;
        }
        #endregion
        /// <summary>
        /// Проверява дали точката е в триъгълника
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(PointF point)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(points);
                return path.IsVisible(point);
            }
        }
        /// <summary>
        /// Частта, визуализираща конкретния примитив + приложено завъртане и мащабиране.
        /// </summary>
        /// <param name="grfx"></param>
        public override void DrawSelf(Graphics grfx)
        {
            using (Matrix matrix = new Matrix())
            {
                // център на триъгълника
                float centerX = Rectangle.X + Rectangle.Width / 2;
                float centerY = Rectangle.Y + Rectangle.Height / 2;

                PointF[] trianglePoints = new PointF[]
                {
            new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y),  // Горна точка
            new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height),      // Лява долна точка
            new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height) // Дясна долна точка
                };

                matrix.Translate(centerX, centerY);
                matrix.Scale(ScaleFactor, ScaleFactor);
                matrix.Translate(-centerX, -centerY);

                // завъртане около центъра
                matrix.RotateAt(RotationAngle, new PointF(centerX, centerY));
                grfx.Transform = matrix;
                using (SolidBrush brush = new SolidBrush(FillColor))
                using (Pen pen = new Pen(BorderColor, BorderWidth))
                {
                    grfx.FillPolygon(brush, points);
                    grfx.DrawPolygon(pen, points);
                }
                grfx.ResetTransform();
            }
        }
        public override Shape Clone()
        {
            TriangleShape copy = new TriangleShape(this.Points[0], this.Points[1], this.Points[2])
            {
                FillColor = this.FillColor,
                BorderColor = this.BorderColor,
                BorderWidth = this.BorderWidth,
                Transparency = this.Transparency,
                RotationAngle = this.RotationAngle,
                ScaleFactor = this.ScaleFactor
            };
            return copy;
        }
    }
}
