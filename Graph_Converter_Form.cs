using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Graph_Converter.Classes;

namespace Graph_Converter
{
    public partial class Graph_Converter_Form : Form
    {
        public Graph_Converter_Form()
        {
            InitializeComponent();
        }

        private Point startPoint = new Point(20, 40);
        private float samplingLevel;
        private int quantingLevel;
        private bool isCoordSystemDrawing;

        private void ShowButton_Click(object sender, EventArgs e)
        {
            Graphics graphicsPaint = DrawBox.CreateGraphics();
            graphicsPaint.Clear(Color.White);
            Pen black = new Pen(Color.Black);
            startPoint.Y = DrawBox.Height - 40;
            // Рисуем оси координат
            if (!isCoordSystemDrawing)
            {
                graphicsPaint.DrawLine(black, new Point(startPoint.X, 0), new Point(startPoint.X, startPoint.Y));
                graphicsPaint.DrawLine(black, new Point(startPoint.X, startPoint.Y), new Point(DrawBox.Width, startPoint.Y));
                isCoordSystemDrawing = true;
            }
            
            if(startPoint.X <= DrawBox.Width)
            {
                Functions func = new Functions();
                // Получаем точки графика функции
                Point[] funcPoints = func.SinusoidFunction(DrawBox.Width);
                // Создаём массив для получения уровней квантования
                List<int> functionQuanting = new List<int>(quantingLevel);
                // Рисуем уровни квантования
                int quantingStage = (startPoint.Y / quantingLevel) - 1;
                if (quantingLevel > 0)
                {
                    int currentQuantingStage = startPoint.Y - quantingStage;
                    for (int i = currentQuantingStage; i > 1; i -= quantingStage)
                    {
                        functionQuanting.Add(i);
                        graphicsPaint.DrawLine(black, new Point(startPoint.X, i), new Point(DrawBox.Width, i));
                    }
                }
                // Получаем разбивку по уровням дискретизации
                int[] samplingDecompose = new int[(int)Math.Ceiling(quantingLevel / samplingLevel)];
                int samplingStage = (int)((DrawBox.Width - startPoint.X) * (samplingLevel > 0.0f && samplingLevel < 1.0f ? samplingLevel : 0.1f)) - 1;
                for (int i = samplingStage, n = 0; i < DrawBox.Width; i += samplingStage, n++)
                {
                    // Уровень квантования для данной точки графика находится в рамках от firstIndex = IndexOf(elem) до secondIndex = firstIndex + 1
                    try
                    {
                        samplingDecompose[n] = functionQuanting.IndexOf(functionQuanting.Find(elem => elem <= funcPoints[i].Y));
                        //funcPoints.ElementAt(i).Y возможна на замену ^
                        graphicsPaint.DrawLine(new Pen(Color.BlueViolet, 2.0f),
                                new Point(i + 32, functionQuanting[samplingDecompose[n]] + quantingStage),
                                new Point(i + 32, functionQuanting[samplingDecompose[n]])
                            );
                    }
                    catch
                    {
                        MessageBox.Show(
                            this,
                            "Возникла ошибка при попытке раазбития по уровням дискретизации",
                            "Уведомление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }

                }
                //int functionStages = (int)Math.Floor(boxWidth / (samplingLevel * 4f)); // из частоты дискретизации

                // Рисуем график
                graphicsPaint.DrawLines(new Pen(Color.Red), funcPoints);
                graphicsPaint.DrawLine(new Pen(Color.Red), new Point(startPoint.X, startPoint.Y), funcPoints[0]);
            }    
        }

        private void SamplingButton_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(
                    SamplingTextBox.Text.Replace('.', ','),
                    out this.samplingLevel)
                )
                    MessageBox.Show(
                            this,
                            "Неправильный формат уровней дискретизации",
                            "Уведомление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
            else isCoordSystemDrawing = false;
        }

        private void QuantingLevelButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(
                        QuantingLevelTextBox.Text,
                        out this.quantingLevel)
                )
                    MessageBox.Show(
                             this,
                             "Неправильный формат уровней квантования",
                             "Уведомление",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information
                         );
            else isCoordSystemDrawing = false;
        }
    }
}
