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
            Pen black = new Pen(Color.Black),
                functionPen = new Pen(Color.BlueViolet, 2f);
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
                Sampling funcSampling = new Sampling(DrawBox.Width, samplingLevel, quantizationLevels);
                try
                {
                    int[] samplingDecompose = funcSampling.SamplingDecompose(startPoint, funcPoints, quantizationOfFunction);
                }
                catch
                {
                    MessageBox.Show(
                        this,
                        "Возникла ошибка при попытке разбития по уровням дискретизации",
                        "Уведомление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                
                try
                {
                    QuantizationByLevels closestFromBelow = 
                        new QuantizationByClosestFromBelowLevel(funcPoints, funcQuantization, funcSampling);
                    closestFromBelow.DrawQuantizationOfFunction(graphicsPaint);
                }
                catch
                {
                    MessageBox.Show(
                        this,
                        "Возникла ошибка при попытке отрисовки делений по уровням квантования",
                        "Уведомление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                // Рисуем график
                graphicsPaint.DrawLines(functionPen, funcPoints);
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
