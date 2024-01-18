namespace Estimate
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mathGrade_num = new System.Windows.Forms.NumericUpDown();
            this.bioGrade_num = new System.Windows.Forms.NumericUpDown();
            this.practiceGrade_num = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mathGrade_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioGrade_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.practiceGrade_num)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Математика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(37, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Биология";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(37, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Практика";
            // 
            // mathGrade_num
            // 
            this.mathGrade_num.Location = new System.Drawing.Point(188, 32);
            this.mathGrade_num.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.mathGrade_num.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mathGrade_num.Name = "mathGrade_num";
            this.mathGrade_num.ReadOnly = true;
            this.mathGrade_num.Size = new System.Drawing.Size(65, 20);
            this.mathGrade_num.TabIndex = 3;
            this.mathGrade_num.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mathGrade_num.ValueChanged += new System.EventHandler(this.mathGrade_num_ValueChanged);
            // 
            // bioGrade_num
            // 
            this.bioGrade_num.Location = new System.Drawing.Point(188, 79);
            this.bioGrade_num.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.bioGrade_num.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.bioGrade_num.Name = "bioGrade_num";
            this.bioGrade_num.ReadOnly = true;
            this.bioGrade_num.Size = new System.Drawing.Size(65, 20);
            this.bioGrade_num.TabIndex = 4;
            this.bioGrade_num.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // practiceGrade_num
            // 
            this.practiceGrade_num.Location = new System.Drawing.Point(188, 129);
            this.practiceGrade_num.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.practiceGrade_num.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.practiceGrade_num.Name = "practiceGrade_num";
            this.practiceGrade_num.ReadOnly = true;
            this.practiceGrade_num.Size = new System.Drawing.Size(65, 20);
            this.practiceGrade_num.TabIndex = 5;
            this.practiceGrade_num.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(83, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(315, 237);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.practiceGrade_num);
            this.Controls.Add(this.bioGrade_num);
            this.Controls.Add(this.mathGrade_num);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form2";
            this.Text = "Изменение оценки";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mathGrade_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioGrade_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.practiceGrade_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown mathGrade_num;
        public System.Windows.Forms.NumericUpDown bioGrade_num;
        public System.Windows.Forms.NumericUpDown practiceGrade_num;
        public System.Windows.Forms.Button button1;
    }
}