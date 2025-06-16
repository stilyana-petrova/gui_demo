using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    public class NewTrapezeShape:Shape
    {
        private PointF[] points;
        public PointF[] Points
        {
            get { return points; }
            set { points = value; }
        }

        #region Constructor
        public NewTrapezeShape(RectangleF rect) : base(rect)
        {
           
        }
        #endregion

        public override bool Contains(PointF point)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(points);
                return path.IsVisible(point);
            }
        }
        public override void DrawSelf(Graphics grfx)
        {
            float topWidth = Rectangle.Width;
            float bottomWidth = Rectangle.Width * 0.6f;
            float height = Rectangle.Height;

            float offsetX = (Rectangle.Width - bottomWidth) / 2;

            PointF p1 = new PointF(Rectangle.X, Rectangle.Y);                       // top-left
            PointF p2 = new PointF(Rectangle.X + topWidth, Rectangle.Y);           // top-right
            PointF p3 = new PointF(Rectangle.X + topWidth - offsetX, Rectangle.Y + height);          // bottom-right
            PointF p4 = new PointF(Rectangle.X + offsetX, Rectangle.Y + height);                       // bottom-left

            points = new PointF[] { p1, p2, p3, p4 };
            this.FillColor = Color.White;
            this.BorderColor = Color.Black;
            this.BorderWidth = 2f;
            using (Matrix matrix = new Matrix())
            {
                float centerX = Rectangle.X + Rectangle.Width / 2;
                float centerY = Rectangle.Y + Rectangle.Height / 2;

                matrix.Translate(centerX, centerY);
                matrix.Scale(ScaleFactor, ScaleFactor);
                matrix.Translate(-centerX, -centerY);

                matrix.RotateAt(RotationAngle, new PointF(centerX, centerY));
                grfx.Transform = matrix;

                PointF left = new PointF((p4.X + p1.X) / 2, (p4.Y + p1.Y) / 2);
                PointF top = new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y);


                using (SolidBrush brush = new SolidBrush(FillColor))
                using (Pen pen = new Pen(BorderColor, BorderWidth))
                {
                    grfx.FillPolygon(brush, points);
                    grfx.DrawPolygon(pen, points);
                    grfx.DrawLine(pen, new PointF(centerX, centerY), p3);
                    grfx.DrawLine(pen, new PointF(centerX, centerY), top);
                    grfx.DrawLine(pen, new PointF(centerX, centerY), left);
                }

                grfx.ResetTransform();
            }
        }
        public override Shape Clone()
        {
            NewTrapezeShape copy = new NewTrapezeShape(this.Rectangle)
            {
                FillColor = this.FillColor,
                BorderColor = this.BorderColor,
                BorderWidth = this.BorderWidth,
                Transparency = this.Transparency,
                RotationAngle = this.RotationAngle,
                ScaleFactor = this.ScaleFactor,
                Points = (PointF[])this.Points.Clone()
            };

            return copy;
        }
    }
}
