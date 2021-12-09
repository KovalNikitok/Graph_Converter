using System;
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
