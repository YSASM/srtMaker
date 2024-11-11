namespace srtMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            durationInput = new TextBox();
            label2 = new Label();
            subtitleLengthInput = new TextBox();
            label3 = new Label();
            subtitleWidthInput = new TextBox();
            label4 = new Label();
            linesInput = new TextBox();
            label5 = new Label();
            ellipsisInput = new TextBox();
            saveSrt = new Button();
            contentInput = new TextBox();
            fontSelect = new ComboBox();
            label6 = new Label();
            contentOutput = new RichTextBox();
            label7 = new Label();
            fontSizeInput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "持续秒数";
            // 
            // durationInput
            // 
            durationInput.Location = new Point(74, 6);
            durationInput.Name = "durationInput";
            durationInput.Size = new Size(25, 23);
            durationInput.TabIndex = 1;
            durationInput.Text = "5";
            durationInput.TextChanged += onConfigsInputChange;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 9);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 2;
            label2.Text = "字幕条数";
            // 
            // subtitleLengthInput
            // 
            subtitleLengthInput.Location = new Point(167, 6);
            subtitleLengthInput.Name = "subtitleLengthInput";
            subtitleLengthInput.Size = new Size(25, 23);
            subtitleLengthInput.TabIndex = 3;
            subtitleLengthInput.Text = "20";
            subtitleLengthInput.TextChanged += onConfigsInputChange;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 9);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 4;
            label3.Text = "换行宽度";
            // 
            // subtitleWidthInput
            // 
            subtitleWidthInput.Location = new Point(260, 6);
            subtitleWidthInput.Name = "subtitleWidthInput";
            subtitleWidthInput.Size = new Size(52, 23);
            subtitleWidthInput.TabIndex = 5;
            subtitleWidthInput.Text = "400";
            subtitleWidthInput.TextChanged += onConfigsInputChange;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 40);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 6;
            label4.Text = "限制行数";
            // 
            // linesInput
            // 
            linesInput.Location = new Point(74, 37);
            linesInput.Name = "linesInput";
            linesInput.Size = new Size(25, 23);
            linesInput.TabIndex = 7;
            linesInput.Text = "3";
            linesInput.TextChanged += onConfigsInputChange;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(105, 40);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 8;
            label5.Text = "超出文本";
            // 
            // ellipsisInput
            // 
            ellipsisInput.Location = new Point(167, 37);
            ellipsisInput.Name = "ellipsisInput";
            ellipsisInput.Size = new Size(145, 23);
            ellipsisInput.TabIndex = 9;
            ellipsisInput.Text = "...[行数超出]";
            ellipsisInput.TextChanged += onConfigsInputChange;
            // 
            // saveSrt
            // 
            saveSrt.Location = new Point(12, 97);
            saveSrt.Name = "saveSrt";
            saveSrt.Size = new Size(300, 23);
            saveSrt.TabIndex = 11;
            saveSrt.Text = "保存";
            saveSrt.UseVisualStyleBackColor = true;
            saveSrt.Click += saveSrtFile;
            // 
            // contentInput
            // 
            contentInput.Location = new Point(318, 6);
            contentInput.Multiline = true;
            contentInput.Name = "contentInput";
            contentInput.Size = new Size(291, 276);
            contentInput.TabIndex = 12;
            contentInput.TextChanged += onContentChanged;
            // 
            // fontSelect
            // 
            fontSelect.FormattingEnabled = true;
            fontSelect.Location = new Point(167, 66);
            fontSelect.Name = "fontSelect";
            fontSelect.Size = new Size(145, 25);
            fontSelect.TabIndex = 14;
            fontSelect.SelectedIndexChanged += onFontSelectChange;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(105, 69);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 15;
            label6.Text = "选择字体";
            // 
            // contentOutput
            // 
            contentOutput.BackColor = Color.White;
            contentOutput.BorderStyle = BorderStyle.None;
            contentOutput.CausesValidation = false;
            contentOutput.Location = new Point(615, 6);
            contentOutput.Name = "contentOutput";
            contentOutput.ReadOnly = true;
            contentOutput.Size = new Size(285, 273);
            contentOutput.TabIndex = 16;
            contentOutput.Text = "";
            contentOutput.WordWrap = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 69);
            label7.Name = "label7";
            label7.Size = new Size(56, 17);
            label7.TabIndex = 17;
            label7.Text = "字体大小";
            // 
            // fontSizeInput
            // 
            fontSizeInput.Location = new Point(74, 66);
            fontSizeInput.Name = "fontSizeInput";
            fontSizeInput.Size = new Size(25, 23);
            fontSizeInput.TabIndex = 18;
            fontSizeInput.Text = "10";
            fontSizeInput.TextChanged += onConfigsInputChange;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 288);
            Controls.Add(fontSizeInput);
            Controls.Add(label7);
            Controls.Add(contentOutput);
            Controls.Add(label6);
            Controls.Add(fontSelect);
            Controls.Add(contentInput);
            Controls.Add(saveSrt);
            Controls.Add(ellipsisInput);
            Controls.Add(label5);
            Controls.Add(linesInput);
            Controls.Add(label4);
            Controls.Add(subtitleWidthInput);
            Controls.Add(label3);
            Controls.Add(subtitleLengthInput);
            Controls.Add(label2);
            Controls.Add(durationInput);
            Controls.Add(label1);
            Name = "Form1";
            Text = "srtMaker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox durationInput;
        private Label label2;
        private TextBox subtitleLengthInput;
        private Label label3;
        private TextBox subtitleWidthInput;
        private Label label4;
        private TextBox linesInput;
        private Label label5;
        private TextBox ellipsisInput;
        private Button saveSrt;
        private TextBox contentInput;
        private ComboBox fontSelect;
        private Label label6;
        private RichTextBox contentOutput;
        private Label label7;
        private TextBox fontSizeInput;
    }
}
