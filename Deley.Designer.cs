
namespace WindowsFormsApp2
{
    partial class Deley
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
            this.StartnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EndnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StartnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StartnumericUpDown
            // 
            this.StartnumericUpDown.DecimalPlaces = 3;
            this.StartnumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartnumericUpDown.Location = new System.Drawing.Point(84, 22);
            this.StartnumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.StartnumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.StartnumericUpDown.Name = "StartnumericUpDown";
            this.StartnumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.StartnumericUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "開始時間";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "終了時間";
            // 
            // EndnumericUpDown
            // 
            this.EndnumericUpDown.DecimalPlaces = 3;
            this.EndnumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EndnumericUpDown.Location = new System.Drawing.Point(84, 81);
            this.EndnumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.EndnumericUpDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.EndnumericUpDown.Name = "EndnumericUpDown";
            this.EndnumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.EndnumericUpDown.TabIndex = 4;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancelbutton.Location = new System.Drawing.Point(156, 133);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 5;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OKbutton.Location = new System.Drawing.Point(63, 133);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 6;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(210, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(210, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "秒";
            // 
            // fix
            // 
            this.AcceptButton = this.OKbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 168);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.EndnumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartnumericUpDown);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(265, 208);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(265, 208);
            this.Name = "fix";
            this.ShowIcon = false;
            this.Text = "Subtitle delay";
            this.Load += new System.EventHandler(this.fix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StartnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown StartnumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown EndnumericUpDown;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}