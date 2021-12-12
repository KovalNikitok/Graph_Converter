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
        private float samplingLevel = 0.2f;
        private int quantizationLevels = 4;
        private Functions func = new Sinusoid();

        private void ShowButton_Click(object sender, EventArgs e)
        {
            Graphics graphicsPaint = DrawBox.CreateGraphics();
            graphicsPaint.Clear(Color.White);
            Pen black = new Pen(Color.Black);
            startPoint.Y = DrawBox.Height - 40;
            // Рисуем оси координат
            graphicsPaint.DrawLine(black, new Point(startPoint.X, 0), new Point(startPoint.X, startPoint.Y));
            graphicsPaint.DrawLine(black, new Point(startPoint.X, startPoint.Y), new Point(DrawBox.Width, startPoint.Y));

            if (startPoint.X <= DrawBox.Width)
            {
                if (quantizationLevels <= 1)
                    quantizationLevels = 2;
                if (samplingLevel < 0.01f || samplingLevel > 0.99f)
                    samplingLevel = 0.1f;
                // Получаем точки графика функции
                Point[] funcPoints = func.GetGraphPoints(DrawBox.Width);
                // Рисуем уровни квантования
                Quantization funcQuantization = new Quantization(startPoint, quantizationLevels);

                List<int> quantizationOfFunction = funcQuantization.GetQuantizationOfFunction();
                funcQuantization.DrawQuantizationLevels(graphicsPaint, DrawBox.Width);

                // Получаем разбивку по уровням дискретизации
                int levels = Convert.ToInt32(Math.Ceiling(quantizationLevels / samplingLevel));
                int[] samplingDecompose = new int[levels];
                int samplingStage = (int)((DrawBox.Width - startPoint.X) * samplingLevel);
                try
                {
                    for (int i = samplingStage, n = 0; i < DrawBox.Width; i += samplingStage, n++)
                    {
                        // Уровень квантования для данной точки графика находится в рамках от firstIndex = IndexOf(elem) до secondIndex = firstIndex + 1
                        samplingDecompose[n] = quantizationOfFunction.IndexOf(quantizationOfFunction.Find(elem => elem <= funcPoints[i].Y));
                        graphicsPaint.DrawLine(new Pen(Color.BlueViolet, 2.0f),
                                new Point(i + 32, quantizationOfFunction[samplingDecompose[n]] + funcQuantization.QuantizationThresold),
                                new Point(i + 32, quantizationOfFunction[samplingDecompose[n]])
                            );
                    }

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
        }

        private void QuantingLevelButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(
                        QuantingLevelTextBox.Text,
                        out this.quantizationLevels)
                )
                MessageBox.Show(
                         this,
                         "Неправильный формат уровней квантования",
                         "Уведомление",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information
                     );
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton functionRadioButton = (RadioButton)sender;
            if (functionRadioButton.Checked)
            {
                switch (functionRadioButton.Text)
                {
                    case "Синусоида":
                    {
                            func = new Sinusoid();
                            break;
                    }
                    case "Косинусоида":
                    {
                            func = new Cosinusoid();
                            break;
                    }
                    case "Коренная":
                    {
                            func = new SquareRoot();
                            break;
                    }
                }
            }
        }
    }
}
