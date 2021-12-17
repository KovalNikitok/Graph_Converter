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
        private string levelsOfQuantization;

        private void ShowButton_Click(object sender, EventArgs e)
        {
            Graphics graphicsPaint = DrawBox.CreateGraphics(); // графический контекст для рисования
            graphicsPaint.Clear(Color.White);
            Pen black = new Pen(Color.Black),
                functionPen = new Pen(Color.BlueViolet, 2f); // Pen'ы для рисования (чёрный - оси, синий - графики
            startPoint.Y = DrawBox.Height - 40; // высота окна для рисования
            // Рисуем оси координат
            graphicsPaint.DrawLine(black, new Point(startPoint.X, 0), new Point(startPoint.X, startPoint.Y));
            graphicsPaint.DrawLine(black, new Point(startPoint.X, startPoint.Y), new Point(DrawBox.Width, startPoint.Y));

            int coeff; // коэффициент для функций
            if (startPoint.X <= DrawBox.Width)
            {
                /*
                if (samplingLevel < 0.01f || samplingLevel > 0.99f)
                    samplingLevel = 0.1f;
                */
                if ((!int.TryParse(
                    CoefficientTextBox.Text.Replace('.', ','),
                    out coeff) || coeff < 1 || coeff > 5)
                )
                    MessageBox.Show(
                            this,
                            "Неправильно задан коэффициент",
                            "Уведомление",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                // Получаем точки графика функции
                Point[] funcPoints = func.GetGraphPoints(DrawBox.Width, startPoint, coeff > 5 ? 3 : coeff < 1 ? 1 : coeff);
                // Рисуем уровни квантования
                Quantization funcQuantization = new Quantization(startPoint, quantizationLevels);
                List<int> quantizationOfFunction = funcQuantization.GetQuantizationOfFunction();
                funcQuantization.DrawQuantizationLevels(graphicsPaint, DrawBox.Width);

                // Получаем разбивку по уровням дискретизации
                Sampling funcSampling = new Sampling(DrawBox.Width, samplingLevel, quantizationLevels);
                try
                {
                    // TODO:
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
                    // получаем тип квантования по селектору и отрисовываем квантование функций
                    QuantizationByLevels quantizationByLevels =
                      Selectors.SelectionQuantization(levelsOfQuantization, funcPoints, funcQuantization, funcSampling);
                    quantizationByLevels.DrawQuantizationOfFunction(graphicsPaint);
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

        private void QuantingLevelButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(
                        QuantingLevelTextBox.Text,
                        out this.quantizationLevels)
                )
            {
                MessageBox.Show(
                         this,
                         "Неправильный формат уровней квантования",
                         "Уведомление",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information
                     );
            }
            if (quantizationLevels > 15)
                quantizationLevels = 15;
            if (quantizationLevels < 3)
                quantizationLevels = 3;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton functionRadioButton = (RadioButton)sender;
            if (functionRadioButton.Checked)
            {
                func = Selectors.GraphOfFunctionRadioSelector(functionRadioButton.Text);
            }
        }

        private void QuantizationLevelRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton quantizationLevelRadioButton = (RadioButton)sender;
            levelsOfQuantization = Selectors.QuantizationLevelRadioSelector(quantizationLevelRadioButton.Text);
        }
    }
}
