﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
    /// </summary>
    public abstract class Shape
    {
        #region Constructors

        public Shape()
        {
        }

        public Shape(RectangleF rect)
        {
            rectangle = rect;
        }

        public Shape(Shape shape)
        {
            this.Height = shape.Height;
            this.Width = shape.Width;
            this.Location = shape.Location;
            this.rectangle = shape.rectangle;

            this.FillColor = shape.FillColor;
            this.BorderColor= shape.BorderColor;
            this.Transparency = shape.Transparency;
            this.BorderWidth = shape.BorderWidth;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Обхващащ правоъгълник на елемента.
        /// </summary>
        private RectangleF rectangle;
        public virtual RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        /// <summary>
        /// Широчина на елемента.
        /// </summary>
        public virtual float Width
        {
            get { return Rectangle.Width; }
            set { rectangle.Width = value; }
        }

        /// <summary>
        /// Височина на елемента.
        /// </summary>
        public virtual float Height
        {
            get { return Rectangle.Height; }
            set { rectangle.Height = value; }
        }

        /// <summary>
        /// Горен ляв ъгъл на елемента.
        /// </summary>
        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { rectangle.Location = value; }
        }

        /// <summary>
        /// Цвят на елемента.
        /// </summary>
        private Color fillColor =Color.White;
        public virtual Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        /// <summary>
        /// Цвят на очертанията на елемента
        /// </summary>
        private Color borderColor = Color.Black;

        public virtual Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        /// <summary>
        /// Дебелина на контура
        /// </summary>
        private float borderWidth = 2f;

        public virtual float BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value > 0 ? value : 1f; }
        }

        /// <summary>
        /// Видимост на елемента
        /// </summary>
        private int transparency = 255;
        public virtual int Transparency
        {
            get { return transparency; }
            set
            {
                transparency = Math.Max(0, Math.Min(255, value));
                fillColor = Color.FromArgb(transparency, fillColor);
                borderColor = Color.FromArgb(transparency, borderColor);
            }
        }
        /// <summary>
        /// Ъгъл на завъртане
        /// </summary>
        private float rotationAngle;
        public virtual float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value % 360; } 
        }

        /// <summary>
        /// Коефициент на мащабиране
        /// </summary>
        private float scaleFactor = 1.0f;
        public virtual float ScaleFactor
        {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }



        #endregion

        public abstract Shape Clone();


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
        {
            return Rectangle.Contains(point.X, point.Y);
        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public virtual void DrawSelf(Graphics grfx)
        {
           
        }



        public virtual void TranslateTo(PointF p)
        {
            float deltaX = p.X - Location.X;
            float deltaY = p.Y - Location.Y;
            Location = p;
        }

        public virtual void Rotate(float angle)
        {
            RotationAngle += angle;
        }

        public virtual void Scale(float factor)
        {
            ScaleFactor *= factor;
            Width *= factor;
            Height *= factor;
        }
    }
}
