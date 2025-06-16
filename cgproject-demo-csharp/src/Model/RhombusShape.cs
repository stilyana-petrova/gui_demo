using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    public class RhombusShape : Shape
    {
        private PointF[] points; // 4 rhombus points

        #region Constructor

        public RhombusShape(RectangleF rect) : base(rect)
        {
            CalculateRhombusPoints();
        }

        public RhombusShape(RhombusShape rhombus) : base(rhombus)
        {
            CalculateRhombusPoints();
            this.FillColor = rhombus.FillColor;
            this.BorderColor = rhombus.BorderColor;
            this.BorderWidth = rhombus.BorderWidth;
            this.Transparency = rhombus.Transparency;
            this.RotationAngle = rhombus.RotationAngle;
            this.ScaleFactor = rhombus.ScaleFactor;
        }

        #endregion

        private void CalculateRhombusPoints()
        {
            float cx = Rectangle.X + Rectangle.Width / 2f;
            float cy = Rectangle.Y + Rectangle.Height / 2f;

            points = new PointF[4];

            points[0] = new PointF(cx, Rectangle.Y); // top center
            points[1] = new PointF(Rectangle.Right, cy); // right center
            points[2] = new PointF(cx, Rectangle.Bottom); // bottom center
            points[3] = new PointF(Rectangle.Left, cy); // left center
        }

        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            float centerX = Rectangle.X + Rectangle.Width / 2f;
            float centerY = Rectangle.Y + Rectangle.Height / 2f;

            // Apply scaling
            float scaledWidth = Rectangle.Width * ScaleFactor;
            float scaledHeight = Rectangle.Height * ScaleFactor;

            // Recalculate points with scale
            PointF[] scaledPoints = new PointF[4];
            scaledPoints[0] = new PointF(centerX, centerY - scaledHeight / 2f);
            scaledPoints[1] = new PointF(centerX + scaledWidth / 2f, centerY);
            scaledPoints[2] = new PointF(centerX, centerY + scaledHeight / 2f);
            scaledPoints[3] = new PointF(centerX - scaledWidth / 2f, centerY);

            Matrix originalTransform = grfx.Transform;

            // Rotate around center
            grfx.TranslateTransform(centerX, centerY);
            grfx.RotateTransform(RotationAngle);
            grfx.TranslateTransform(-centerX, -centerY);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(Transparency, FillColor)))
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                grfx.FillPolygon(brush, scaledPoints);
                grfx.DrawPolygon(pen, scaledPoints);
            }

            grfx.Transform = originalTransform;
        }

        public override Shape Clone()
        {
            return new RhombusShape(this);
        }

        public override void TranslateTo(PointF delta)
        {
            Rectangle = new RectangleF(
       Rectangle.X + delta.X,
       Rectangle.Y + delta.Y,
       Rectangle.Width,
       Rectangle.Height
   );
            CalculateRhombusPoints();
        }

        public override void Rotate(float angle)
        {
            RotationAngle += angle;
        }

        public override void Scale(float factor)
        {
            ScaleFactor *= factor;
        }
    }
}
