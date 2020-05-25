namespace ContainerSchip2 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ContentWeight = new System.Windows.Forms.TextBox();
            this.RcoldValuable = new System.Windows.Forms.RadioButton();
            this.Rvaluable = new System.Windows.Forms.RadioButton();
            this.Rcold = new System.Windows.Forms.RadioButton();
            this.Rnormal = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Width";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(431, 354);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(85, 20);
            this.heightBox.TabIndex = 25;
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(329, 354);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(85, 20);
            this.widthBox.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Orden";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "ContentWeight";
            // 
            // ContentWeight
            // 
            this.ContentWeight.Location = new System.Drawing.Point(58, 172);
            this.ContentWeight.Name = "ContentWeight";
            this.ContentWeight.Size = new System.Drawing.Size(121, 20);
            this.ContentWeight.TabIndex = 20;
            // 
            // RcoldValuable
            // 
            this.RcoldValuable.AutoSize = true;
            this.RcoldValuable.Location = new System.Drawing.Point(58, 111);
            this.RcoldValuable.Name = "RcoldValuable";
            this.RcoldValuable.Size = new System.Drawing.Size(87, 17);
            this.RcoldValuable.TabIndex = 19;
            this.RcoldValuable.TabStop = true;
            this.RcoldValuable.Text = "ColdValuable";
            this.RcoldValuable.UseVisualStyleBackColor = true;
            // 
            // Rvaluable
            // 
            this.Rvaluable.AutoSize = true;
            this.Rvaluable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Rvaluable.Location = new System.Drawing.Point(58, 65);
            this.Rvaluable.Name = "Rvaluable";
            this.Rvaluable.Size = new System.Drawing.Size(66, 17);
            this.Rvaluable.TabIndex = 18;
            this.Rvaluable.TabStop = true;
            this.Rvaluable.Text = "Valuable";
            this.Rvaluable.UseVisualStyleBackColor = true;
            // 
            // Rcold
            // 
            this.Rcold.AutoSize = true;
            this.Rcold.Location = new System.Drawing.Point(58, 88);
            this.Rcold.Name = "Rcold";
            this.Rcold.Size = new System.Drawing.Size(46, 17);
            this.Rcold.TabIndex = 17;
            this.Rcold.TabStop = true;
            this.Rcold.Text = "Cold";
            this.Rcold.UseVisualStyleBackColor = true;
            // 
            // Rnormal
            // 
            this.Rnormal.AutoSize = true;
            this.Rnormal.Location = new System.Drawing.Point(58, 42);
            this.Rnormal.Name = "Rnormal";
            this.Rnormal.Size = new System.Drawing.Size(58, 17);
            this.Rnormal.TabIndex = 16;
            this.Rnormal.TabStop = true;
            this.Rnormal.Text = "Normal";
            this.Rnormal.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "AddContainer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContentWeight);
            this.Controls.Add(this.RcoldValuable);
            this.Controls.Add(this.Rvaluable);
            this.Controls.Add(this.Rcold);
            this.Controls.Add(this.Rnormal);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ContentWeight;
        private System.Windows.Forms.RadioButton RcoldValuable;
        private System.Windows.Forms.RadioButton Rvaluable;
        private System.Windows.Forms.RadioButton Rcold;
        private System.Windows.Forms.RadioButton Rnormal;
        private System.Windows.Forms.Button button1;
    }
}

