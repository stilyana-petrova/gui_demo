using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    public class CircleX:Shape
    {  
        public CircleX(RectangleF rect) : base(rect)
        {
            float diameter = Math.Min(rect.Width, rect.Height);
            this.Width = diameter;
            this.Height = diameter;
        }

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

                float centerX=scaledRect.X+scaledRect.Width/2;
                float centerY = scaledRect.Y + scaledRect.Height / 2;
                float radius= scaledRect.Width/2;
 
                PointF topLeft = new PointF(centerX-radius*(float)Math.Cos(Math.PI/4), centerY-radius*(float)Math.Sin(Math.PI/4));
                PointF topRight = new PointF(centerX+radius * (float)Math.Cos(Math.PI / 4), centerY-radius * (float)Math.Sin(Math.PI / 4));
                PointF bottomLeft = new PointF(centerX-radius * (float)Math.Cos(Math.PI / 4), centerY+radius * (float)Math.Sin(Math.PI / 4));
                PointF bottomRight = new PointF(centerX+radius * (float)Math.Cos(Math.PI / 4), centerY+radius * (float)Math.Sin(Math.PI / 4));

                PointF topCenter = new PointF(centerX, centerY - radius);
                PointF bottomCenter = new PointF(centerX, centerY + radius);

                PointF rightCenter = new PointF(centerX-radius, centerY);
                PointF leftCenter = new PointF(centerX+radius, centerY);

                PointF right1 =new PointF(centerX-radius, centerY-radius);
                PointF left1 =new PointF(centerX-radius, centerY+radius);

                PointF right2 = new PointF(centerX + radius, centerY + radius);
                PointF left2 = new PointF(centerX+ radius, centerY - radius);


                grfx.DrawLine(pen, topLeft, bottomRight);
                grfx.DrawLine (pen, topRight, bottomLeft);
                grfx.DrawLine(pen, topCenter, bottomCenter);
                grfx.DrawLine(pen, rightCenter, leftCenter);

                grfx.DrawLine(pen, right1, left1);
                grfx.DrawLine(pen, right2, left2);
            }
        }

        public override Shape Clone()
        {
            CircleX copy = new CircleX(this.Rectangle)
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
