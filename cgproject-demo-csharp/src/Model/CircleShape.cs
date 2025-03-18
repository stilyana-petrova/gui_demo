using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    /// <summary>
    /// Клас за рисуване на кръг
    /// </summary>
    public class CircleShape:Shape
    {
        #region Constructor
        public CircleShape(RectangleF rect) : base(rect)
        {
            float diameter = Math.Min(rect.Width, rect.Height);
            this.Width = diameter;
            this.Height = diameter;
        }
        #endregion

        /// <summary>
        /// Проверява дали дадена точка е в рамките на кръг, дефиниран чрез правоъгълник
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(PointF point)
        {
            //пресмята центъра на кръга
            float centerX = Rectangle.X + Width / 2;
            float centerY = Rectangle.Y + Height / 2;
            //изчислява разликата между точката и центъра на кръга
            float dx = point.X - centerX;
            float dy = point.Y - centerY;
            //проверява дали точката е в кръга
            return dx * dx + dy * dy <= (Width / 2) * (Width / 2);
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
                float scaledWidth = Rectangle.Width * ScaleFactor;
                float scaledHeight = Rectangle.Height * ScaleFactor;
                float scaledX = Rectangle.X + (Rectangle.Width - scaledWidth) / 2;
                float scaledY = Rectangle.Y + (Rectangle.Height - scaledHeight) / 2;

                RectangleF scaledRect = new RectangleF(scaledX, scaledY, scaledWidth, scaledHeight);

                grfx.FillEllipse(brush, scaledRect);
                grfx.DrawEllipse(pen, scaledRect);
            }
        }

        public override Shape Clone()
        {
            CircleShape copy = new CircleShape(this.Rectangle)
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
