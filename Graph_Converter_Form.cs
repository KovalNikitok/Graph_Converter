using System;
using System.Windows.Forms;

namespace Graph_Converter
{
    public partial class Graph_Converter_Form : Form
    {
        public Graph_Converter_Form()
        {
            InitializeComponent();
        }

        private float samplingLevel;
        private int quantingLevel;
        private bool isCoordSystemDrawing;

        private void ShowButton_Click(object sender, EventArgs e)
        {
            
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
