﻿namespace ContainerSchip2 {
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
            this.coldValuable = new System.Windows.Forms.RadioButton();
            this.valuable = new System.Windows.Forms.RadioButton();
            this.cold = new System.Windows.Forms.RadioButton();
            this.normal = new System.Windows.Forms.RadioButton();
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
            // coldValuable
            // 
            this.coldValuable.AutoSize = true;
            this.coldValuable.Location = new System.Drawing.Point(58, 111);
            this.coldValuable.Name = "coldValuable";
            this.coldValuable.Size = new System.Drawing.Size(87, 17);
            this.coldValuable.TabIndex = 19;
            this.coldValuable.TabStop = true;
            this.coldValuable.Text = "ColdValuable";
            this.coldValuable.UseVisualStyleBackColor = true;
            // 
            // valuable
            // 
            this.valuable.AutoSize = true;
            this.valuable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.valuable.Location = new System.Drawing.Point(58, 65);
            this.valuable.Name = "valuable";
            this.valuable.Size = new System.Drawing.Size(66, 17);
            this.valuable.TabIndex = 18;
            this.valuable.TabStop = true;
            this.valuable.Text = "Valuable";
            this.valuable.UseVisualStyleBackColor = true;
            // 
            // cold
            // 
            this.cold.AutoSize = true;
            this.cold.Location = new System.Drawing.Point(58, 88);
            this.cold.Name = "cold";
            this.cold.Size = new System.Drawing.Size(46, 17);
            this.cold.TabIndex = 17;
            this.cold.TabStop = true;
            this.cold.Text = "Cold";
            this.cold.UseVisualStyleBackColor = true;
            // 
            // normal
            // 
            this.normal.AutoSize = true;
            this.normal.Location = new System.Drawing.Point(58, 42);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(58, 17);
            this.normal.TabIndex = 16;
            this.normal.TabStop = true;
            this.normal.Text = "Normal";
            this.normal.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "AddContainer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.Controls.Add(this.coldValuable);
            this.Controls.Add(this.valuable);
            this.Controls.Add(this.cold);
            this.Controls.Add(this.normal);
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
        private System.Windows.Forms.RadioButton coldValuable;
        private System.Windows.Forms.RadioButton valuable;
        private System.Windows.Forms.RadioButton cold;
        private System.Windows.Forms.RadioButton normal;
        private System.Windows.Forms.Button button1;
    }
}

