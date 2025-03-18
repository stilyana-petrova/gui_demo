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
    /// Клас за чертаене на звезда
    /// </summary>
    public class StarShape : Shape
    {
        private PointF[] starPoints;

        public PointF[] StarPoints
        {
            get { return starPoints; }
            set { starPoints = value; }
        }
        #region Constructor
        public StarShape(RectangleF rect) : base(rect)
        {
            this.FillColor = Color.White;
            this.BorderColor = Color.Black;
            this.BorderWidth = 2f;
            CalculateStarPoints(5);
        }
        #endregion

        /// <summary>
        /// Изчислява точките на звездата
        /// </summary>
        /// <param name="numRays"></param>
        public void CalculateStarPoints(int numRays)
        {
            // Център и радиуси
            float cx = Rectangle.X + Rectangle.Width / 2;
            float cy = Rectangle.Y + Rectangle.Height / 2;
            float outerRadius = Math.Min(Rectangle.Width, Rectangle.Height) / 2;
            float innerRadius = outerRadius / 2.5f;

            // Общо 2 * numRays точки (външна точка, вътрешна точка, и т.н.)
            starPoints = new PointF[numRays * 2];

            double angleStep = Math.PI / numRays; // 180 / numRays
            double angle = -Math.PI / 2; // Започваме от -90 градуса, за да имаме горен връх

            for (int i = 0; i < numRays * 2; i++)
            {
                // Редуваме външен и вътрешен радиус
                float r = (i % 2 == 0) ? outerRadius : innerRadius;
                float x = cx + (float)(Math.Cos(angle) * r);
                float y = cy + (float)(Math.Sin(angle) * r);

                starPoints[i] = new PointF(x, y);
                angle += angleStep;
            }
        }
        /// <summary>
        /// Проверява дали точката е в звездата
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
        /// Частта, визуализираща конкретния примитив + приложено завъртане.
        /// </summary>
        /// <param name="grfx"></param>
        public override void DrawSelf(Graphics grfx)
        {
            using (Matrix matrix = new Matrix())
            {
                float centerX = Rectangle.X + Rectangle.Width / 2;
                float centerY = Rectangle.Y + Rectangle.Height / 2;

                matrix.RotateAt(RotationAngle, new PointF(centerX, centerY));

                PointF[] scaledStarPoints = new PointF[starPoints.Length];
                for (int i = 0; i < starPoints.Length; i++)
                {
                    scaledStarPoints[i] = new PointF(
                        centerX + (starPoints[i].X - centerX) * ScaleFactor,
                        centerY + (starPoints[i].Y - centerY) * ScaleFactor
                    );
                }

                grfx.Transform = matrix;

                using (SolidBrush brush = new SolidBrush(FillColor))
                using (Pen pen = new Pen(BorderColor, BorderWidth))
                {
                    grfx.FillPolygon(brush, scaledStarPoints);
                    grfx.DrawPolygon(pen, scaledStarPoints);
                }

                grfx.ResetTransform();
            }

        }
        public override Shape Clone()
        {
            StarShape copy = new StarShape(this.Rectangle)
            {
                FillColor = this.FillColor,
                BorderColor = this.BorderColor,
                BorderWidth = this.BorderWidth,
                Transparency = this.Transparency,
                RotationAngle = this.RotationAngle,
                ScaleFactor = this.ScaleFactor,
                StarPoints = (PointF[])this.StarPoints.Clone() // Клонираме точките на звездата
            };
            return copy;
        }

    }
}

