namespace Speech_Note
{
    partial class Form_Speech_To_Text
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Speech_To_Text));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_EnglishiRecognition = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Redite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Chinese Recognition";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(274, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Chinese Completed";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(350, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(441, 343);
            this.textBox1.TabIndex = 2;
            // 
            // btn_EnglishiRecognition
            // 
            this.btn_EnglishiRecognition.Location = new System.Drawing.Point(26, 187);
            this.btn_EnglishiRecognition.Name = "btn_EnglishiRecognition";
            this.btn_EnglishiRecognition.Size = new System.Drawing.Size(274, 42);
            this.btn_EnglishiRecognition.TabIndex = 3;
            this.btn_EnglishiRecognition.Text = "Englishi Recognition";
            this.btn_EnglishiRecognition.UseVisualStyleBackColor = true;
            this.btn_EnglishiRecognition.Click += new System.EventHandler(this.btn_EnglishiRecognition_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 247);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(274, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "English Completed";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(26, 307);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(274, 38);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save the Document";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Redite
            // 
            this.btn_Redite.Location = new System.Drawing.Point(26, 364);
            this.btn_Redite.Name = "btn_Redite";
            this.btn_Redite.Size = new System.Drawing.Size(274, 39);
            this.btn_Redite.TabIndex = 6;
            this.btn_Redite.Text = "Open the Document";
            this.btn_Redite.UseVisualStyleBackColor = true;
            this.btn_Redite.Click += new System.EventHandler(this.btn_Redite_Click);
            // 
            // Form_Speech_To_Text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 445);
            this.Controls.Add(this.btn_Redite);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_EnglishiRecognition);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Speech_To_Text";
            this.Text = "Form_Speech_To_Text";
            this.Load += new System.EventHandler(this.Form_Speech_To_Text_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_EnglishiRecognition;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Redite;
    }
}