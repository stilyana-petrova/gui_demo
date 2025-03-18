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
    /// Клас за чертаене на квадрат
    /// </summary>
    public class SquareShape : Shape
    {
        #region Constructor
        public SquareShape(RectangleF rect) : base(rect)
        {
            // Задаваме ширина = височина
            float side = Math.Min(rect.Width, rect.Height);
            this.Width = side;
            this.Height = side;
        }
        #endregion

        /// <summary>
        /// Проверява дали точката е в квадрата
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(PointF point)
        {
            return base.Contains(point);
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

                // центъра на квадрата
                float centerX = Rectangle.X + Rectangle.Width / 2;
                float centerY = Rectangle.Y + Rectangle.Height / 2;

                grfx.TranslateTransform(centerX, centerY); 
                grfx.RotateTransform(RotationAngle);      
                grfx.ScaleTransform(ScaleFactor, ScaleFactor); 
                grfx.TranslateTransform(-centerX, -centerY); 

                grfx.FillRectangle(brush, Rectangle.X, Rectangle.Y, Width, Height);
                grfx.DrawRectangle(pen, Rectangle.X, Rectangle.Y, Width, Height);

                grfx.Transform = originalTransform;
            }
        }
        public override Shape Clone()
        {
            SquareShape copy = new SquareShape(this.Rectangle)
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
