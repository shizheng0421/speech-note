namespace Speech_Note
{
    partial class Form_Vocabulary_Bank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Vocabulary_Bank));
            this.btn_TextProcessing = new System.Windows.Forms.Button();
            this.btn_InputDataBase = new System.Windows.Forms.Button();
            this.tbx_Article = new System.Windows.Forms.TextBox();
            this.btn_Recognition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_TextProcessing
            // 
            this.btn_TextProcessing.Location = new System.Drawing.Point(13, 59);
            this.btn_TextProcessing.Name = "btn_TextProcessing";
            this.btn_TextProcessing.Size = new System.Drawing.Size(175, 39);
            this.btn_TextProcessing.TabIndex = 0;
            this.btn_TextProcessing.Text = "Text Processing";
            this.btn_TextProcessing.UseVisualStyleBackColor = true;
            this.btn_TextProcessing.Click += new System.EventHandler(this.btn_TextProcessing_Click);
            // 
            // btn_InputDataBase
            // 
            this.btn_InputDataBase.Location = new System.Drawing.Point(234, 59);
            this.btn_InputDataBase.Name = "btn_InputDataBase";
            this.btn_InputDataBase.Size = new System.Drawing.Size(161, 39);
            this.btn_InputDataBase.TabIndex = 1;
            this.btn_InputDataBase.Text = "Text Repository";
            this.btn_InputDataBase.UseVisualStyleBackColor = true;
            this.btn_InputDataBase.Click += new System.EventHandler(this.btn_InputDataBase_Click);
            // 
            // tbx_Article
            // 
            this.tbx_Article.Location = new System.Drawing.Point(12, 117);
            this.tbx_Article.Multiline = true;
            this.tbx_Article.Name = "tbx_Article";
            this.tbx_Article.Size = new System.Drawing.Size(612, 356);
            this.tbx_Article.TabIndex = 2;
            // 
            // btn_Recognition
            // 
            this.btn_Recognition.Location = new System.Drawing.Point(444, 59);
            this.btn_Recognition.Name = "btn_Recognition";
            this.btn_Recognition.Size = new System.Drawing.Size(180, 39);
            this.btn_Recognition.TabIndex = 3;
            this.btn_Recognition.Text = "Recognition";
            this.btn_Recognition.UseVisualStyleBackColor = true;
            this.btn_Recognition.Click += new System.EventHandler(this.btn_Recognition_Click);
            // 
            // Form_Vocabulary_Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 485);
            this.Controls.Add(this.btn_Recognition);
            this.Controls.Add(this.tbx_Article);
            this.Controls.Add(this.btn_InputDataBase);
            this.Controls.Add(this.btn_TextProcessing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Vocabulary_Bank";
            this.Text = "Form_Vocabulary_Bank";
            this.Load += new System.EventHandler(this.Form_Vocabulary_Bank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_TextProcessing;
        private System.Windows.Forms.Button btn_InputDataBase;
        private System.Windows.Forms.TextBox tbx_Article;
        private System.Windows.Forms.Button btn_Recognition;
    }
}