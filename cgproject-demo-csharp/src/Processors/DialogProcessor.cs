using Draw.src.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : DisplayProcessor
    {

        private float startAngle;

        public event Action RequestRedraw;


        #region Constructor

        public DialogProcessor()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Избран елемент.
        /// </summary>
        private Shape selection;
        public Shape Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
        public bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF lastLocation;
        public PointF LastLocation
        {
            get { return lastLocation; }
            set { lastLocation = value; }
        }


        #endregion

        /// <summary>
        /// Добавя примитив - правоъгълник на произволно място върху клиентската област.
        /// </summary>
        public void AddRandomRectangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
            rect.FillColor = Color.White;
            rect.BorderColor = Color.Black;

            ShapeList.Add(rect);


        }
        /// <summary>
        /// 
        /// </summary>
        public void AddRandomElipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            ElipseShape ellipse = new ElipseShape(new RectangleF(x, y, 100, 200));
            ellipse.FillColor = Color.White;
            ellipse.BorderColor = Color.Black;
            ShapeList.Add(ellipse);
        }
        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            // Create three points for the triangle
            PointF p1 = new PointF(x, y);
            PointF p2 = new PointF(x + 50, y + 100);
            PointF p3 = new PointF(x - 50, y + 100);

            TriangleShape triangle = new TriangleShape(p1, p2, p3);
            ShapeList.Add(triangle);
        }

        public void AddRandomCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            CircleShape circle = new CircleShape(new RectangleF(x, y, 100, 100));
            circle.FillColor = Color.White;
            ShapeList.Add(circle);
        }

        public void AddRandomHexagon()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            // Създаваме правоъгълник, който определя обхващащата област на шестоъгълника
            RectangleF rect = new RectangleF(x, y, 100, 100);
            HexagonShape hexagon = new HexagonShape(rect);

            hexagon.FillColor = Color.White;
            hexagon.BorderColor = Color.Black;
            hexagon.BorderWidth = 2f;

            ShapeList.Add(hexagon);
        }
        public void AddRandomSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            // Определяме фиксиран размер за квадрата, например 100x100
            RectangleF rect = new RectangleF(x, y, 100, 100);
            SquareShape square = new SquareShape(rect);

            square.FillColor = Color.White;
            square.BorderColor = Color.Black;
            square.BorderWidth = 2f;

            ShapeList.Add(square);
        }

        public void AddRandomStar()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            int size = rnd.Next(50, 150); // Размер на звездата

            // Създава звездата като правоъгълник, който я огражда
            StarShape star = new StarShape(new RectangleF(x, y, size, size));
            star.FillColor = Color.White;
            star.BorderColor = Color.Black;
            star.BorderWidth = 2f;

            ShapeList.Add(star);
        }
        public void AddRandomComplexStar()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            int size = rnd.Next(50, 150); // Размер на звездата

            // Създаваме сложната звезда като правоъгълник, който я огражда
            ComplexStarShape star = new ComplexStarShape(new RectangleF(x, y, size, size))
            {
                FillColor = Color.White, // полупрозрачен жълт
                BorderColor = Color.Black,
                BorderWidth = 2f
            };

            ShapeList.Add(star);
        }

        public void AddRandomTrapeze()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RectangleF rect = new RectangleF(x, y, 120, 80);
            TrapezeShape trapeze = new TrapezeShape(rect);
            trapeze.FillColor = Color.White;
            trapeze.BorderColor = Color.Black;

            ShapeList.Add(trapeze);
        }
        public void AddRandomTrapeze2()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RectangleF rect = new RectangleF(x, y, 120, 80);
            NewTrapezeShape trapeze = new NewTrapezeShape(rect);
            trapeze.FillColor = Color.White;
            trapeze.BorderColor = Color.Black;

            ShapeList.Add(trapeze);
        }

        public void AddRandomRhombus()
        {
            Random rand = new Random();

            // Random location and size
            float x = rand.Next(50, 300);
            float y = rand.Next(50, 300);
            float width = rand.Next(50, 150);
            float height = rand.Next(50, 150);

            RectangleF rect = new RectangleF(x, y, width, height);

            // Create the rhombus
            RhombusShape rhombus = new RhombusShape(rect)
            {
                FillColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 2f
            };

            ShapeList.Add(rhombus);
            Selection = rhombus;
            Redraw();
        }



        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
        {
            //for (int i = ShapeList.Count - 1; i >= 0; i--)
            //{
            //    if (ShapeList[i].Contains(point))
            //    {
            //        //ShapeList[i].FillColor = Color.Red;

            //        return ShapeList[i];
            //    }
            //}
            //return null;

            for (int i = ShapeList.Count - 1; i >= 0; i--)
            {
                if (ShapeList[i] is GroupShape group)
                {
                    // Проверяваме дали точката принадлежи на някой от елементите в групата
                    foreach (var shape in group.Shapes)
                    {
                        if (shape.Contains(point))
                        {
                            return group; // Връщаме цялата група
                        }
                    }
                }
                else if (ShapeList[i].Contains(point))
                {
                    return ShapeList[i];
                }
            }
            return null;
        }




        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p">p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (selection != null)
            {
                if (selection is GroupShape group)
                {
                    // Преместваме цялата група
                    group.TranslateTo(p);
                }
                else
                {

                    float deltaX = p.X - lastLocation.X;
                    float deltaY = p.Y - lastLocation.Y;

                    selection.Location = new PointF(selection.Location.X + p.X - lastLocation.X, selection.Location.Y + p.Y - lastLocation.Y);
                    lastLocation = p;

                    // Ако избраният елемент е шестоъгълник, актуализира RectangleF
                    if (selection is HexagonShape hexagon)
                    {
                        hexagon.Rectangle = new RectangleF(
                            hexagon.Rectangle.X + p.X - lastLocation.X,
                            hexagon.Rectangle.Y + p.Y - lastLocation.Y,
                            hexagon.Rectangle.Width,
                            hexagon.Rectangle.Height
                        );

                        hexagon.CalculateHexPoints();
                    }

                    //Ако избраният елемент е сложната звезда
                    if (selection is ComplexStarShape star)
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

                    // Ако избраният елемент е звезда
                    if (selection is StarShape star2)
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

                    //Ако избраният елемент е триъгълник
                    if (selection is TriangleShape triangle)
                    {
                        PointF[] currentPoints = triangle.Points;

                        for (int i = 0; i < currentPoints.Length; i++)
                        {
                            PointF point = currentPoints[i];
                            currentPoints[i] = new PointF(point.X + deltaX, point.Y + deltaY);
                        }

                        triangle.Points = currentPoints;

                        float minX = currentPoints.Min(point => p.X);
                        float minY = currentPoints.Min(point => p.Y);
                        float maxX = currentPoints.Max(ppoint => p.X);
                        float maxY = currentPoints.Max(ppoint => p.Y);

                        triangle.Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
                    }
                    //Ако избраният елемент е трапец

                    if (selection is TrapezeShape trapeze)
                    {
                        PointF[] currentPoints = trapeze.Points;

                        for (int i = 0; i < currentPoints.Length; i++)
                        {
                            currentPoints[i] = new PointF(currentPoints[i].X + deltaX, currentPoints[i].Y + deltaY);
                        }

                        trapeze.Points = currentPoints;

                        float minX = currentPoints.Min(ppoint => p.X);
                        float minY = currentPoints.Min(ppoin => p.Y);
                        float maxX = currentPoints.Max(ppoint => p.X);
                        float maxY = currentPoints.Max(ppoint => p.Y);

                        trapeze.Rectangle = new RectangleF(minX, minY, maxX - minX, maxY - minY);
                    }


                }
            }
        }



        public void SetShapeProperties(Color fillColor, Color borderColor, float borderWidth, int transparency)
        {
            if (Selection != null)
            {
                if (selection is GroupShape group)
                {
                    group.SetShapeProperties(fillColor, borderColor, borderWidth, transparency);
                }
                else
                {
                    Selection.FillColor = fillColor;
                    Selection.BorderColor = borderColor;
                    Selection.BorderWidth = borderWidth;
                    Selection.Transparency = transparency;
                }
            }
        }


        public void Redraw()
        {
            RequestRedraw?.Invoke();
        }

        //изтриване на примитив
        public void DeleteSelectedShape()
        {
            if (Selection != null)
            {
                ShapeList.Remove(Selection);
                Selection = null;
                Redraw();
            }
        }

        //копиране на примитив
        public void CopySelectedShape()
        {
            if (Selection != null)
            {
                if (Selection is GroupShape group)
                {
                    // Създаваме нова група
                    GroupShape copiedGroup = new GroupShape();

                    // Копираме всички фигури от оригиналната група
                    foreach (var shape in group.Shapes)
                    {
                        Shape copiedShape = shape.Clone();
                        copiedShape.Location = new PointF(
                            copiedShape.Location.X + 10, // Преместване с 10 пиксела надясно
                            copiedShape.Location.Y + 10  // Преместване с 10 пиксела надолу
                        );
                        copiedGroup.AddShape(copiedShape);
                    }

                    // Добавяме новата група към списъка с фигури
                    ShapeList.Add(copiedGroup);
                    Selection = copiedGroup; // Селектираме новата група
                }

                else
                {
                    Shape copiedShape = Selection.Clone();
                    copiedShape.Location = new PointF(
                        copiedShape.Location.X + 10,
                        copiedShape.Location.Y + 10
                    );
                    ShapeList.Add(copiedShape);
                    Selection = copiedShape;
                    Redraw();
                }
            }
        }

        //за групиране на примитиви
        public void GroupShapes()
        {
            if (ShapeList.Count > 1)
            {
                GroupShape group = new GroupShape();
                foreach (var shape in ShapeList.ToList())
                {
                    group.AddShape(shape);
                    ShapeList.Remove(shape);
                }
                ShapeList.Add(group);
                Selection = group;
                Redraw();
            }
        }

        //за дегрупиране на примитиви
        public void UngroupShapes()
        {
            if (selection is GroupShape group)
            {
                foreach (var shape in group.Shapes)
                {
                    ShapeList.Add(shape);
                }
                ShapeList.Remove(group);
                selection = null;
                Redraw();
            }
        }


        public void RotateSelection(float angle)
        {
            if (Selection != null)
            {
                if (Selection is GroupShape group)
                {
                    group.Rotate(angle);
                }
                else
                {
                    Selection.Rotate(angle);
                }
                Redraw();
            }
        }
        public void ScaleSelection(float factor)
        {
            if (selection != null)
            {
                if (selection is GroupShape group)
                {
                    group.Scale(factor);
                }
                else
                {
                    selection.Scale(factor);
                }

                Redraw();
            }
        }

        // Запазване на фигурите във файл
        public void SaveModel(string filePath)
        {
            string json = JsonConvert.SerializeObject(ShapeList, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All 
            });

            File.WriteAllText(filePath, json);
        }

        // Зареждане на фигурите от файл
        public void LoadModel(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                ShapeList = JsonConvert.DeserializeObject<List<Shape>>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            }
        }

    }
}
