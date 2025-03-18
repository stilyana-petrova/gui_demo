using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    public class GroupShape:Shape
    {
        private List<Shape> shapes;

        public GroupShape()
        {
            shapes = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
            UpdateBounds();
        }

        public void RemoveShape(Shape shape)
        {
            shapes.Remove(shape);
            UpdateBounds();
        }

        public List<Shape> Shapes
        {
            get { return shapes; }
        }

        private void UpdateBounds()
        {
            if (shapes.Count == 0)
            {
                Rectangle = new RectangleF(0, 0, 0, 0);
                return;
            }

            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            foreach (var shape in shapes)
            {
                minX = Math.Min(minX, shape.Rectangle.Left);
                minY = Math.Min(minY, shape.Rectangle.Top);
                maxX = Math.Max(maxX, shape.Rectangle.Right);
                maxY = Math.Max(maxY, shape.Rectangle.Bottom);
            }

            Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }

        public override bool Contains(PointF point)
        {
            foreach (var shape in shapes)
            {
                if (shape.Contains(point))
                    return true;
            }
            return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            foreach (var shape in shapes)
            {
                shape.DrawSelf(grfx);
            }
        }

        public override void TranslateTo(PointF p)
        {
            // Изчисляваме разликата между новата позиция и текущата позиция на групата
            float deltaX = p.X - Location.X;
            float deltaY = p.Y - Location.Y;

            // Преместваме всички елементи в групата
            foreach (var shape in shapes)
            {
                if (shape is HexagonShape hexagon)
                {
                    hexagon.Rectangle = new RectangleF(
                        hexagon.Rectangle.X + deltaX,
                        hexagon.Rectangle.Y + deltaY,
                        hexagon.Rectangle.Width,
                        hexagon.Rectangle.Height
                    );

                    hexagon.CalculateHexPoints();
                }
                else if (shape is ComplexStarShape star)
                {
                    for (int i = 0; i < star.StarPoints.Length; i++)
                    {
                        star.StarPoints[i] = new PointF(star.StarPoints[i].X + deltaX, star.StarPoints[i].Y + deltaY);
                    }

                    star.Center = new PointF(star.Center.X + deltaX, star.Center.Y + deltaY);

                    float minX = star.StarPoints.Min(point => point.X);
                    float minY = star.StarPoints.Min(point => point.Y);
                    float maxX = star.StarPoints.Max(point => point.X);
                    float maxY = star.StarPoints.Max(point => point.Y);

                    star.Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
                }
                else if (shape is StarShape star2)
                {
                    for (int i = 0; i < star2.StarPoints.Length; i++)
                    {
                        star2.StarPoints[i] = new PointF(star2.StarPoints[i].X + deltaX, star2.StarPoints[i].Y + deltaY);
                    }

                    float minX = star2.StarPoints.Min(point => point.X);
                    float minY = star2.StarPoints.Min(point => point.Y);
                    float maxX = star2.StarPoints.Max(point => point.X);
                    float maxY = star2.StarPoints.Max(point => point.Y);

                    star2.Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
                }
                else if (shape is TriangleShape triangle)
                {
                    PointF[] currentPoints = triangle.Points;

                    for (int i = 0; i < currentPoints.Length; i++)
                    {
                        PointF point = currentPoints[i];
                        currentPoints[i] = new PointF(point.X + deltaX, point.Y + deltaY);
                    }

                    triangle.Points = currentPoints;

                    float minX = currentPoints.Min(point => point.X);
                    float minY = currentPoints.Min(point => point.Y);
                    float maxX = currentPoints.Max(point => point.X);
                    float maxY = currentPoints.Max(point => point.Y);

                    triangle.Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
                }
                else
                {
                    // Стандартно преместване за другите фигури
                    shape.Location = new PointF(shape.Location.X + deltaX, shape.Location.Y + deltaY);
                }
            }

            // Актуализираме позицията на групата
            base.TranslateTo(p);
        }

        public override void Rotate(float angle)
        {
            // Намираме центъра на групата
            PointF center = new PointF(
                Rectangle.X + Rectangle.Width / 2,
                Rectangle.Y + Rectangle.Height / 2
            );

            foreach (var shape in shapes)
            {
                float dx = shape.Location.X - center.X;
                float dy = shape.Location.Y - center.Y;

                float newX = center.X + (float)(dx * Math.Cos(angle) - dy * Math.Sin(angle));
                float newY = center.Y + (float)(dx * Math.Sin(angle) + dy * Math.Cos(angle));

                shape.Location = new PointF(newX, newY);

                shape.Rotate(angle);
            }
            base.Rotate(angle);
        }

        public override void Scale(float factor)
        {
            PointF center = new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);

            foreach (var shape in shapes)
            {
                // Премести формата спрямо центъра на групата
                float dx = shape.Location.X - center.X;
                float dy = shape.Location.Y - center.Y;

                // Приложи мащабиране
                shape.Location = new PointF(center.X + dx * factor, center.Y + dy * factor);
                shape.Scale(factor); // Мащабирай и самата форма
            }

            base.Scale(factor); // Актуализирай границите на групата
        }
        public void SetShapeProperties(Color fillColor, Color borderColor, float borderWidth, int transparency)
        {
            foreach (var shape in shapes)
            {
                shape.FillColor = fillColor;
                shape.BorderColor = borderColor;
                shape.BorderWidth = borderWidth;
                shape.Transparency = transparency;
            }
        }

        public override Shape Clone()
        {
            GroupShape copy = new GroupShape();

            // Копираме всички фигури в групата
            foreach (var shape in this.Shapes)
            {
                copy.AddShape(shape.Clone());
            }

            // Копираме свойствата на групата
            copy.FillColor = this.FillColor;
            copy.BorderColor = this.BorderColor;
            copy.BorderWidth = this.BorderWidth;
            copy.Transparency = this.Transparency;
            copy.RotationAngle = this.RotationAngle;
            copy.ScaleFactor = this.ScaleFactor;

            return copy;
        }
    }

}

