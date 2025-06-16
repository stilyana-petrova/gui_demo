using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    public class TrapezeShape:Shape
    {
        private PointF[] points;
        public PointF[] Points
        {
            get { return points; }
            set { points = value; }
        }

        #region Constructor
        public TrapezeShape(RectangleF rect) : base(rect)
        {
            float topWidth = rect.Width * 0.6f;   
            float bottomWidth = rect.Width;       
            float height = rect.Height;

            float offsetX = (rect.Width - topWidth) / 2;

            PointF p1 = new PointF(rect.X + offsetX, rect.Y);                       // top-left
            PointF p2 = new PointF(rect.X + offsetX + topWidth, rect.Y);           // top-right
            PointF p3 = new PointF(rect.X + rect.Width, rect.Y + height);          // bottom-right
            PointF p4 = new PointF(rect.X, rect.Y + height);                       // bottom-left

            points = new PointF[] { p1, p2, p3, p4 };
            this.Rectangle = rect;
            this.FillColor = Color.White;
            this.BorderColor = Color.Black;
            this.BorderWidth = 2f;
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
            using (Matrix matrix = new Matrix())
            {
                float centerX = Rectangle.X + Rectangle.Width / 2;
                float centerY = Rectangle.Y + Rectangle.Height / 2;

                matrix.Translate(centerX, centerY);
                matrix.Scale(ScaleFactor, ScaleFactor);
                matrix.Translate(-centerX, -centerY);

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
            TrapezeShape copy = new TrapezeShape(this.Rectangle)
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
