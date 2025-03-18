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
    /// Клас за чертаене на шестоъгълник
    /// </summary>
    public class HexagonShape : Shape
    {
        #region Fields

        private PointF[] hexPoints;

        #endregion

        #region Constructor
        public HexagonShape(RectangleF rect) : base(rect)
        {
            this.FillColor = Color.White;
            this.BorderColor = Color.Black;
            this.BorderWidth = 2f;

            CalculateHexPoints();
        }
        #endregion
        /// <summary>
        /// Метод, който изчислява върховете на шестоъгълника
        /// </summary>
        public void CalculateHexPoints()
        {
            float centerX = Rectangle.X + Rectangle.Width / 2;
            float centerY = Rectangle.Y + Rectangle.Height / 2;

            float radius = (Math.Min(Rectangle.Width, Rectangle.Height) / 2) * ScaleFactor;

            hexPoints = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                float angle = (float)(Math.PI / 3 * i); // 60 градуса за всяка точка
                float x = centerX + (float)(Math.Cos(angle) * radius);
                float y = centerY + (float)(Math.Sin(angle) * radius);
                hexPoints[i] = new PointF(x, y);
            }
            //// център и радиус
            //float cx = Rectangle.X + Rectangle.Width / 2;
            //float cy = Rectangle.Y + Rectangle.Height / 2;
            //float radius = Math.Min(Rectangle.Width, Rectangle.Height) / 2;

            //// 6 страни, 6 ъгъла, всeкr 60 градуса
            //hexPoints = new PointF[6];
            //double angleStep = Math.PI / 3; // 60 градуса
            //double angle = -Math.PI / 2;    // Започва от -90 градуса

            //for (int i = 0; i < 6; i++)
            //{
            //    float x = cx + (float)(Math.Cos(angle) * radius);
            //    float y = cy + (float)(Math.Sin(angle) * radius);
            //    hexPoints[i] = new PointF(x, y);

            //    angle += angleStep;
            //}

            //hexPoints = new PointF[6];
            //float cx = Rectangle.X + Rectangle.Width / 2;
            //float cy = Rectangle.Y + Rectangle.Height / 2;
            //float radius = Math.Min(Rectangle.Width, Rectangle.Height) / 2 * ScaleFactor; // Прилагаме мащабиране

            //for (int i = 0; i < 6; i++)
            //{
            //    float angle = (float)(Math.PI / 3 * i);
            //    hexPoints[i] = new PointF(
            //        cx + radius * (float)Math.Cos(angle),
            //        cy + radius * (float)Math.Sin(angle)
            //    );
            //}

        }




        /// <summary>
        /// Проверява дали дадена точка е в шестоъгълника
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override bool Contains(PointF point)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(hexPoints);
                return path.IsVisible(point);
            }
        }
        /// <summary>
        /// Частта, визуализираща шестоъгълник + изчисляване на завъртане и мащабиране.
        /// </summary>
        /// <param name="grfx"></param>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            CalculateHexPoints();
            float centerX = Rectangle.X + Rectangle.Width / 2;
            float centerY = Rectangle.Y + Rectangle.Height / 2;

            Matrix originalTransform = grfx.Transform;

            grfx.TranslateTransform(centerX, centerY);
            grfx.RotateTransform(RotationAngle);
            grfx.TranslateTransform(-centerX, -centerY);

            using (SolidBrush brush = new SolidBrush(FillColor))
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                grfx.FillPolygon(brush, hexPoints);
                grfx.DrawPolygon(pen, hexPoints);
            }

            grfx.Transform = originalTransform;
        }
        public override Shape Clone()
        {
            HexagonShape copy = new HexagonShape(this.Rectangle)
            {
                FillColor = this.FillColor,
                BorderColor = this.BorderColor,
                BorderWidth = this.BorderWidth,
                Transparency = this.Transparency,
                RotationAngle = this.RotationAngle,
                ScaleFactor = this.ScaleFactor,
                hexPoints = (PointF[])this.hexPoints.Clone() // Клонираме точките на шестоъгълника
            };
            return copy;
        }
    }

}
