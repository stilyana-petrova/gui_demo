using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    /// <summary>
	/// Клас за чертаене на елипса
	/// </summary>
    public class ElipseShape : Shape
    {
        #region Constructor

        public ElipseShape(RectangleF rect) : base(rect)
        {
        }

        public ElipseShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към елипса, която е вмъкната в правоъгълник.
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {
                float x = point.X;
                float y = point.Y;
                float h = this.Rectangle.X + this.Width / 2;
                float k = this.Rectangle.Y + this.Height / 2;

                float rx = this.Width;
                float ry = this.Height;

                //проверява дили точката е в елипсата
                return Math.Pow((x - h), 2) / Math.Pow(rx, 2) + Math.Pow((y - k), 2) / Math.Pow(ry, 2) <= 1;

}

            else
                return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            using (SolidBrush brush = new SolidBrush(FillColor))
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                var originalTransform = grfx.Transform;

                grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
                grfx.RotateTransform(RotationAngle);
                grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));

                float scaledWidth = Rectangle.Width * ScaleFactor;
                float scaledHeight = Rectangle.Height * ScaleFactor;
                float scaledX = Rectangle.X + (Rectangle.Width - scaledWidth) / 2;
                float scaledY = Rectangle.Y + (Rectangle.Height - scaledHeight) / 2;

                RectangleF scaledRect = new RectangleF(scaledX, scaledY, scaledWidth, scaledHeight);

                grfx.FillEllipse(brush, scaledRect);
                grfx.DrawEllipse(pen, scaledRect);

                grfx.Transform = originalTransform;

            }

        }
        public override Shape Clone()
        {
            ElipseShape copy = new ElipseShape(this.Rectangle)
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
