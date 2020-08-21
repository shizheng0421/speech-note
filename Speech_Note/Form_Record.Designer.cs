namespace Speech_Note
{
    partial class Form_Record
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Record));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_width = new System.Windows.Forms.TextBox();
            this.label_width = new System.Windows.Forms.Label();
            this.textBox_height = new System.Windows.Forms.TextBox();
            this.label_height = new System.Windows.Forms.Label();
            this.radioButton_camera = new System.Windows.Forms.RadioButton();
            this.radioButton_justAudio = new System.Windows.Forms.RadioButton();
            this.label_time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_parse = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_micro = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.radioButton_camera);
            this.groupBox1.Controls.Add(this.radioButton_justAudio);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_width);
            this.panel1.Controls.Add(this.label_width);
            this.panel1.Controls.Add(this.textBox_height);
            this.panel1.Controls.Add(this.label_height);
            this.panel1.Location = new System.Drawing.Point(195, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 58);
            this.panel1.TabIndex = 2;
            // 
            // textBox_width
            // 
            this.textBox_width.Location = new System.Drawing.Point(371, 14);
            this.textBox_width.Name = "textBox_width";
            this.textBox_width.Size = new System.Drawing.Size(133, 25);
            this.textBox_width.TabIndex = 6;
            this.textBox_width.Text = "640";
            // 
            // label_width
            // 
            this.label_width.AutoSize = true;
            this.label_width.Location = new System.Drawing.Point(310, 17);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(55, 15);
            this.label_width.TabIndex = 5;
            this.label_width.Text = "Width:";
            // 
            // textBox_height
            // 
            this.textBox_height.Location = new System.Drawing.Point(160, 14);
            this.textBox_height.Name = "textBox_height";
            this.textBox_height.Size = new System.Drawing.Size(128, 25);
            this.textBox_height.TabIndex = 4;
            this.textBox_height.Text = "480";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Location = new System.Drawing.Point(3, 17);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(151, 15);
            this.label_height.TabIndex = 3;
            this.label_height.Text = "Resolution Height:";
            // 
            // radioButton_camera
            // 
            this.radioButton_camera.AutoSize = true;
            this.radioButton_camera.Location = new System.Drawing.Point(46, 68);
            this.radioButton_camera.Name = "radioButton_camera";
            this.radioButton_camera.Size = new System.Drawing.Size(100, 19);
            this.radioButton_camera.TabIndex = 1;
            this.radioButton_camera.TabStop = true;
            this.radioButton_camera.Text = "PC Camera";
            this.radioButton_camera.UseVisualStyleBackColor = true;
            // 
            // radioButton_justAudio
            // 
            this.radioButton_justAudio.AutoSize = true;
            this.radioButton_justAudio.Location = new System.Drawing.Point(46, 24);
            this.radioButton_justAudio.Name = "radioButton_justAudio";
            this.radioButton_justAudio.Size = new System.Drawing.Size(108, 19);
            this.radioButton_justAudio.TabIndex = 0;
            this.radioButton_justAudio.TabStop = true;
            this.radioButton_justAudio.Text = "Only Voice";
            this.radioButton_justAudio.UseVisualStyleBackColor = true;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(95, 284);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(71, 15);
            this.label_time.TabIndex = 1;
            this.label_time.Text = "00:00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Time:";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(26, 328);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(163, 38);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_parse
            // 
            this.btn_parse.Location = new System.Drawing.Point(276, 328);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(175, 38);
            this.btn_parse.TabIndex = 4;
            this.btn_parse.Text = "Parse";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btn_parse_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(536, 328);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(175, 38);
            this.btn_stop.TabIndex = 5;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_micro);
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 94);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voice";
            // 
            // checkBox_micro
            // 
            this.checkBox_micro.AutoSize = true;
            this.checkBox_micro.Location = new System.Drawing.Point(46, 37);
            this.checkBox_micro.Name = "checkBox_micro";
            this.checkBox_micro.Size = new System.Drawing.Size(109, 19);
            this.checkBox_micro.TabIndex = 0;
            this.checkBox_micro.Text = "Microphone";
            this.checkBox_micro.UseVisualStyleBackColor = true;
            // 
            // Form_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 420);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_parse);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Record";
            this.Text = "Form_Record";
            this.Load += new System.EventHandler(this.Form_Record_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_width;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.TextBox textBox_height;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.RadioButton radioButton_camera;
        private System.Windows.Forms.RadioButton radioButton_justAudio;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_parse;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_micro;
    }
}