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
            this.QauntingLevelButton = new System.Windows.Forms.Button();
            this.QuantingLevelTextBox = new System.Windows.Forms.TextBox();
            this.panelOfRadioButtons = new System.Windows.Forms.Panel();
            this.squareRootRadioButton = new System.Windows.Forms.RadioButton();
            this.cosinusoidRadioButton = new System.Windows.Forms.RadioButton();
            this.sinusoidRadioButton = new System.Windows.Forms.RadioButton();
            this.PanelOfQuantizationLevels = new System.Windows.Forms.Panel();
            this.LesserQuantizationRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.CoefficientTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DrawBox)).BeginInit();
            this.panelOfRadioButtons.SuspendLayout();
            this.PanelOfQuantizationLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawBox
            // 
            this.DrawBox.BackColor = System.Drawing.Color.White;
            this.DrawBox.Location = new System.Drawing.Point(12, 50);
            this.DrawBox.Name = "DrawBox";
            this.DrawBox.Size = new System.Drawing.Size(793, 280);
            this.DrawBox.TabIndex = 0;
            this.DrawBox.TabStop = false;
            // 
            // ShowButton
            // 
            this.ShowButton.Location = new System.Drawing.Point(12, 336);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(98, 33);
            this.ShowButton.TabIndex = 1;
            this.ShowButton.Text = "Отобразить";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // QauntingLevelButton
            // 
            this.QauntingLevelButton.Location = new System.Drawing.Point(188, 336);
            this.QauntingLevelButton.Name = "QauntingLevelButton";
            this.QauntingLevelButton.Size = new System.Drawing.Size(104, 36);
            this.QauntingLevelButton.TabIndex = 4;
            this.QauntingLevelButton.Text = "Задать уровни квантования";
            this.QauntingLevelButton.UseVisualStyleBackColor = true;
            this.QauntingLevelButton.Click += new System.EventHandler(this.QuantingLevelButton_Click);
            // 
            // QuantingLevelTextBox
            // 
            this.QuantingLevelTextBox.Location = new System.Drawing.Point(122, 339);
            this.QuantingLevelTextBox.MaxLength = 1;
            this.QuantingLevelTextBox.Multiline = true;
            this.QuantingLevelTextBox.Name = "QuantingLevelTextBox";
            this.QuantingLevelTextBox.Size = new System.Drawing.Size(58, 29);
            this.QuantingLevelTextBox.TabIndex = 5;
            this.QuantingLevelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelOfRadioButtons
            // 
            this.panelOfRadioButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOfRadioButtons.Controls.Add(this.squareRootRadioButton);
            this.panelOfRadioButtons.Controls.Add(this.cosinusoidRadioButton);
            this.panelOfRadioButtons.Controls.Add(this.sinusoidRadioButton);
            this.panelOfRadioButtons.Location = new System.Drawing.Point(12, 12);
            this.panelOfRadioButtons.Name = "panelOfRadioButtons";
            this.panelOfRadioButtons.Size = new System.Drawing.Size(298, 32);
            this.panelOfRadioButtons.TabIndex = 6;
            // 
            // squareRootRadioButton
            // 
            this.squareRootRadioButton.AutoSize = true;
            this.squareRootRadioButton.Location = new System.Drawing.Point(219, 4);
            this.squareRootRadioButton.Name = "squareRootRadioButton";
            this.squareRootRadioButton.Size = new System.Drawing.Size(74, 17);
            this.squareRootRadioButton.TabIndex = 2;
            this.squareRootRadioButton.Text = "Коренная";
            this.squareRootRadioButton.UseVisualStyleBackColor = true;
            this.squareRootRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // cosinusoidRadioButton
            // 
            this.cosinusoidRadioButton.AutoSize = true;
            this.cosinusoidRadioButton.Location = new System.Drawing.Point(110, 3);
            this.cosinusoidRadioButton.Name = "cosinusoidRadioButton";
            this.cosinusoidRadioButton.Size = new System.Drawing.Size(91, 17);
            this.cosinusoidRadioButton.TabIndex = 1;
            this.cosinusoidRadioButton.Text = "Косинусоида";
            this.cosinusoidRadioButton.UseVisualStyleBackColor = true;
            this.cosinusoidRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // sinusoidRadioButton
            // 
            this.sinusoidRadioButton.AutoSize = true;
            this.sinusoidRadioButton.Checked = true;
            this.sinusoidRadioButton.Location = new System.Drawing.Point(4, 4);
            this.sinusoidRadioButton.Name = "sinusoidRadioButton";
            this.sinusoidRadioButton.Size = new System.Drawing.Size(79, 17);
            this.sinusoidRadioButton.TabIndex = 0;
            this.sinusoidRadioButton.TabStop = true;
            this.sinusoidRadioButton.Text = "Синусоида";
            this.sinusoidRadioButton.UseVisualStyleBackColor = true;
            this.sinusoidRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // PanelOfQuantizationLevels
            // 
            this.PanelOfQuantizationLevels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelOfQuantizationLevels.Controls.Add(this.radioButton2);
            this.PanelOfQuantizationLevels.Controls.Add(this.radioButton1);
            this.PanelOfQuantizationLevels.Controls.Add(this.LesserQuantizationRadioButton);
            this.PanelOfQuantizationLevels.Location = new System.Drawing.Point(513, 12);
            this.PanelOfQuantizationLevels.Name = "PanelOfQuantizationLevels";
            this.PanelOfQuantizationLevels.Size = new System.Drawing.Size(292, 32);
            this.PanelOfQuantizationLevels.TabIndex = 7;
            // 
            // LesserQuantizationRadioButton
            // 
            this.LesserQuantizationRadioButton.AutoSize = true;
            this.LesserQuantizationRadioButton.Checked = true;
            this.LesserQuantizationRadioButton.Location = new System.Drawing.Point(4, 6);
            this.LesserQuantizationRadioButton.Name = "LesserQuantizationRadioButton";
            this.LesserQuantizationRadioButton.Size = new System.Drawing.Size(87, 17);
            this.LesserQuantizationRadioButton.TabIndex = 0;
            this.LesserQuantizationRadioButton.TabStop = true;
            this.LesserQuantizationRadioButton.Text = "По нижнему";
            this.LesserQuantizationRadioButton.UseVisualStyleBackColor = true;
            this.LesserQuantizationRadioButton.CheckedChanged += new System.EventHandler(this.QuantizationLevelRadioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(98, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "По среднему";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.QuantizationLevelRadioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(196, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "По верхнему";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.QuantizationLevelRadioButton_CheckedChanged);
            // 
            // CoefficientTextBox
            // 
            this.CoefficientTextBox.Location = new System.Drawing.Point(316, 16);
            this.CoefficientTextBox.MaxLength = 1;
            this.CoefficientTextBox.Multiline = true;
            this.CoefficientTextBox.Name = "CoefficientTextBox";
            this.CoefficientTextBox.Size = new System.Drawing.Size(55, 26);
            this.CoefficientTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Коэффициент (1...5)";
            // 
            // Graph_Converter_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CoefficientTextBox);
            this.Controls.Add(this.PanelOfQuantizationLevels);
            this.Controls.Add(this.panelOfRadioButtons);
            this.Controls.Add(this.QuantingLevelTextBox);
            this.Controls.Add(this.QauntingLevelButton);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.DrawBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(840, 420);
            this.MinimizeBox = false;
            this.Name = "Graph_Converter_Form";
            this.Text = "Домашняя работа";
            ((System.ComponentModel.ISupportInitialize)(this.DrawBox)).EndInit();
            this.panelOfRadioButtons.ResumeLayout(false);
            this.panelOfRadioButtons.PerformLayout();
            this.PanelOfQuantizationLevels.ResumeLayout(false);
            this.PanelOfQuantizationLevels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DrawBox;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.Button QauntingLevelButton;
        private System.Windows.Forms.TextBox QuantingLevelTextBox;
        private System.Windows.Forms.Panel panelOfRadioButtons;
        private System.Windows.Forms.RadioButton squareRootRadioButton;
        private System.Windows.Forms.RadioButton cosinusoidRadioButton;
        private System.Windows.Forms.RadioButton sinusoidRadioButton;
        private System.Windows.Forms.Panel PanelOfQuantizationLevels;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton LesserQuantizationRadioButton;
        private System.Windows.Forms.TextBox CoefficientTextBox;
        private System.Windows.Forms.Label label1;
    }
}

