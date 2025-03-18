using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Draw
{
    /// <summary>
    /// Върху главната форма е поставен потребителски контрол,
    /// в който се осъществява визуализацията
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
        /// </summary>
        private DialogProcessor dialogProcessor = new DialogProcessor();

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            dialogProcessor.RequestRedraw += () => viewPort.Invalidate();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        /// <summary>
        /// Изход от програмата. Затваря главната форма, а с това и програмата.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
        /// </summary>
        void ViewPortPaint(object sender, PaintEventArgs e)
        {
            dialogProcessor.ReDraw(sender, e);
        }

        /// <summary>
        /// Бутон, който поставя на произволно място правоъгълник със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRectangle();

            statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>
        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
                if (dialogProcessor.Selection != null)
                {
                    statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                    dialogProcessor.IsDragging = true;
                    dialogProcessor.LastLocation = e.Location;
                    viewPort.Invalidate();
                }
            }

        }

        /// <summary>
        /// Прихващане на преместването на мишката.
        /// Ако сме в режм на "влачене", то избрания елемент се транслира.
        /// </summary>
        void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging)
            {
                if (dialogProcessor.Selection != null)
                {
                    statusBar.Items[0].Text = "Последно действие: Влачене";
                    dialogProcessor.TranslateTo(e.Location);
                    viewPort.Invalidate();
                }
            }

        }

        /// <summary>
        /// Прихващане на отпускането на бутона на мишката.
        /// Излизаме от режим "влачене".
        /// </summary>
        void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dialogProcessor.IsDragging = false;
        }


        private void drawElipseSpeedButton_Click_1(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomElipse();
            statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";
            viewPort.Invalidate();
        }


        private void selectColor_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null) // Check if a shape is selected
            {
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        dialogProcessor.Selection.FillColor = colorDialog.Color;
                        Invalidate();
                    }
                }
            }
            else
            {
                MessageBox.Show("Изберете фигура.");
            }
        }

        private void selectBorderColor_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        dialogProcessor.Selection.BorderColor = colorDialog.Color;
                        Invalidate();
                    }
                }
            }
            else
            {
                MessageBox.Show("Изберете фигура.");
            }
        }

        private void borderWidthControl_ValueChanged(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                dialogProcessor.Selection.BorderWidth = (float)borderWidthControl.Value;
                Invalidate();
            }
            else
            {
                MessageBox.Show("Изберете фигура.");
            }
        }

        private void transparentcyChanger_Scroll(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                dialogProcessor.Selection.Transparency = transparencyChanger.Value;
                Invalidate();
            }
            else
            {
                MessageBox.Show("Изберете фигура.");
            }
        }

        private void viewPort_Load(object sender, EventArgs e)
        {

        }

        private void DrawCircleButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomCircle();
            statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";
            viewPort.Invalidate();
        }

        private void DrawHexagonShape_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomHexagon();
            statusBar.Items[0].Text = "Последно действие: Рисуване на шестоъгълник";
            viewPort.Invalidate();
        }

        private void DrawSquareShape_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomSquare();
            statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";
            viewPort.Invalidate();
        }

        private void DrawComplexStarShape_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomComplexStar();
            statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
            viewPort.Invalidate();
        }

        private void DrawTriangleShape_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomTriangle();
            statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";
            viewPort.Invalidate();
        }

        private void DrawStarShape_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomStar();
            statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
            viewPort.Invalidate();
        }

        private void RotationBar_Scroll(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                dialogProcessor.Selection.RotationAngle = RotationBar.Value;
                dialogProcessor.RotateSelection(RotationBar.Value);
                dialogProcessor.Redraw();
                statusBar.Items[0].Text = "Последно действие: Завъртане";

            }
        }

        private void ScalingTrackBar_Scroll(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection != null)
            {
                float scaleFactor = ScalingTrackBar.Value / 100.0f;
                dialogProcessor.Selection.ScaleFactor = scaleFactor;

                statusBar.Items[0].Text = "Последно действие: Мащабиране";

                viewPort.Invalidate();
            }
        }

        //за групиране
        private void GroupButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.GroupShapes();
            //viewPort.Invalidate();
        }

        private void UngroupButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.UngroupShapes();
           // viewPort.Invalidate();
        }

        private void DeleteShapeButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.DeleteSelectedShape();
        }

        private void CopyShapeButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.CopySelectedShape();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Запази модела"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SaveModel(saveFileDialog.FileName);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Отвори модела"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.LoadModel(openFileDialog.FileName);
                viewPort.Invalidate(); 
            }
        }

        private void drawCircleXButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomCircleX();
            viewPort.Invalidate();
        }
    }
}
