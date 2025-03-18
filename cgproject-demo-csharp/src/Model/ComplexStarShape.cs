using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    /// <summary>
    /// Клас за чертаене на по-сложна звезда
    /// </summary>
    public class ComplexStarShape:Shape
    {
        #region Fields

        private PointF[] starPoints;
        private PointF center;

        #endregion

        public PointF[] StarPoints
        {
            get { return starPoints; }
            set { starPoints = value; }
        }

        public PointF Center
        {
            get { return center; }
            set { center = value; }
        }
        #region Constructor
        public ComplexStarShape(RectangleF rect) : base(rect)
        {
            this.FillColor = Color.White;
            this.BorderColor = Color.Black;
            this.BorderWidth = 2f;
            CalculateStarPoints(5); // 5-лъчева звезда
        }
        #endregion

        /// <summary>
        /// Изчислява точките на звездата
        /// </summary>
        /// <param name="numRays"></param>
        public void CalculateStarPoints(int numRays)
        {
            // център и радиуси
            float cx = Rectangle.X + Rectangle.Width / 2;
            float cy = Rectangle.Y + Rectangle.Height / 2;

            // Запазва центъра
            center = new PointF(cx, cy);

            float outerRadius = Math.Min(Rectangle.Width, Rectangle.Height) / 2;
            float innerRadius = outerRadius / 2.5f;

            // Общо 2 * numRays точки (външна точка, вътрешна точка, и т.н.)
            starPoints = new PointF[numRays * 2];

            double angleStep = Math.PI / numRays; // 180 / numRays
            double angle = -Math.PI / 2; // Започва от -90 градуса, за да има горен връх

            for (int i = 0; i < numRays * 2; i++)
            {
                // Редува външен и вътрешен радиус
                float r = (i % 2 == 0) ? outerRadius : innerRadius;
                float x = cx + (float)(Math.Cos(angle) * r);
                float y = cy + (float)(Math.Sin(angle) * r);

                starPoints[i] = new PointF(x, y);
                angle += angleStep;
            }
        }


        /// <summary>
        /// Проверява дали дадена точка е в звездата
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(PointF point)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(starPoints);
                return path.IsVisible(point);
            }
        }


        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        /// <param name="grfx"></param>
        public override void DrawSelf(Graphics grfx)
        {
            using (SolidBrush brush = new SolidBrush(FillColor))
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                var originalTransform = grfx.Transform;

                grfx.TranslateTransform(center.X, center.Y);
                grfx.ScaleTransform(ScaleFactor, ScaleFactor);
                grfx.RotateTransform(RotationAngle);
                grfx.TranslateTransform(-center.X, -center.Y);

                grfx.FillPolygon(brush, starPoints);
                grfx.DrawPolygon(pen, starPoints);

                // Линии от центъра до всеки връх
                for (int i = 0; i < starPoints.Length; i++)
                {
                    grfx.DrawLine(pen, center, starPoints[i]);
                }

                grfx.Transform = originalTransform;
            }
        }

        public override Shape Clone()
        {
            ComplexStarShape copy = new ComplexStarShape(this.Rectangle)
            {
                FillColor = this.FillColor,
                BorderColor = this.BorderColor,
                BorderWidth = this.BorderWidth,
                Transparency = this.Transparency,
                RotationAngle = this.RotationAngle,
                ScaleFactor = this.ScaleFactor,
                StarPoints = (PointF[])this.StarPoints.Clone(), // Клонираме точките на сложната звезда
                Center = this.Center // Клонираме центъра
            };
            return copy;
        }
    }
}
