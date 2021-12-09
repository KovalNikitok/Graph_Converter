namespace Graph_Converter
{
    partial class Graph_Converter_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph_Converter_Form));
            this.DrawBox = new System.Windows.Forms.PictureBox();
            this.ShowButton = new System.Windows.Forms.Button();
            this.SamplingTextBox = new System.Windows.Forms.TextBox();
            this.SamplingButton = new System.Windows.Forms.Button();
            this.QauntingLevelButton = new System.Windows.Forms.Button();
            this.QuantingLevelTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawBox
            // 
            this.DrawBox.Location = new System.Drawing.Point(12, 12);
            this.DrawBox.Name = "DrawBox";
            this.DrawBox.Size = new System.Drawing.Size(793, 280);
            this.DrawBox.TabIndex = 0;
            this.DrawBox.TabStop = false;
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(12, 298);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(98, 33);
            this.ShowButton.TabIndex = 1;
            this.ShowButton.Text = "Отобразить";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // SamplingTextBox
            // 
            this.SamplingTextBox.Location = new System.Drawing.Point(197, 302);
            this.SamplingTextBox.MaxLength = 5;
            this.SamplingTextBox.Multiline = true;
            this.SamplingTextBox.Name = "SamplingTextBox";
            this.SamplingTextBox.Size = new System.Drawing.Size(58, 29);
            this.SamplingTextBox.TabIndex = 2;
            this.SamplingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SamplingButton
            // 
            this.SamplingButton.Location = new System.Drawing.Point(261, 298);
            this.SamplingButton.Name = "SamplingButton";
            this.SamplingButton.Size = new System.Drawing.Size(103, 36);
            this.SamplingButton.TabIndex = 3;
            this.SamplingButton.Text = "Задать дискретизацию";
            this.SamplingButton.UseVisualStyleBackColor = true;
            this.SamplingButton.Click += new System.EventHandler(this.SamplingButton_Click);
            // 
            // QauntingLevelButton
            // 
            this.QauntingLevelButton.Location = new System.Drawing.Point(498, 298);
            this.QauntingLevelButton.Name = "QauntingLevelButton";
            this.QauntingLevelButton.Size = new System.Drawing.Size(104, 36);
            this.QauntingLevelButton.TabIndex = 4;
            this.QauntingLevelButton.Text = "Задать уровни квантования";
            this.QauntingLevelButton.UseVisualStyleBackColor = true;
            this.QauntingLevelButton.Click += new System.EventHandler(this.QuantingLevelButton_Click);
            // 
            // QuantingLevelTextBox
            // 
            this.QuantingLevelTextBox.Location = new System.Drawing.Point(434, 302);
            this.QuantingLevelTextBox.MaxLength = 2;
            this.QuantingLevelTextBox.Multiline = true;
            this.QuantingLevelTextBox.Name = "QuantingLevelTextBox";
            this.QuantingLevelTextBox.Size = new System.Drawing.Size(58, 29);
            this.QuantingLevelTextBox.TabIndex = 5;
            this.QuantingLevelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Test_Graphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 338);
            this.Controls.Add(this.QuantingLevelTextBox);
            this.Controls.Add(this.QauntingLevelButton);
            this.Controls.Add(this.SamplingButton);
            this.Controls.Add(this.SamplingTextBox);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.DrawBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(840, 420);
            this.MinimizeBox = false;
            this.Name = "Test_Graphics";
            this.Text = "Домашняя работа";
            ((System.ComponentModel.ISupportInitialize)(this.DrawBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawBox;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.TextBox SamplingTextBox;
        private System.Windows.Forms.Button SamplingButton;
        private System.Windows.Forms.Button QauntingLevelButton;
        private System.Windows.Forms.TextBox QuantingLevelTextBox;
    }
}

