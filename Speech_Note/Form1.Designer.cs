namespace Speech_Note
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_SearchFiles = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbx_content = new System.Windows.Forms.TextBox();
            this.btn_KeysDataBase = new System.Windows.Forms.Button();
            this.btn_Recognition = new System.Windows.Forms.Button();
            this.btn_init = new System.Windows.Forms.Button();
            this.btn_speak = new System.Windows.Forms.Button();
            this.btn_video = new System.Windows.Forms.Button();
            this.btn_record = new System.Windows.Forms.Button();
            this.btn_re = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SearchFiles
            // 
            this.btn_SearchFiles.Location = new System.Drawing.Point(30, 105);
            this.btn_SearchFiles.Name = "btn_SearchFiles";
            this.btn_SearchFiles.Size = new System.Drawing.Size(195, 41);
            this.btn_SearchFiles.TabIndex = 1;
            this.btn_SearchFiles.Text = "Search";
            this.btn_SearchFiles.UseVisualStyleBackColor = true;
            this.btn_SearchFiles.Click += new System.EventHandler(this.btn_SearchFiles_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(809, 345);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // tbx_content
            // 
            this.tbx_content.Location = new System.Drawing.Point(30, 171);
            this.tbx_content.Name = "tbx_content";
            this.tbx_content.Size = new System.Drawing.Size(809, 25);
            this.tbx_content.TabIndex = 3;
            // 
            // btn_KeysDataBase
            // 
            this.btn_KeysDataBase.Location = new System.Drawing.Point(243, 45);
            this.btn_KeysDataBase.Name = "btn_KeysDataBase";
            this.btn_KeysDataBase.Size = new System.Drawing.Size(181, 41);
            this.btn_KeysDataBase.TabIndex = 4;
            this.btn_KeysDataBase.Text = "Vocabulary Bank";
            this.btn_KeysDataBase.UseVisualStyleBackColor = true;
            this.btn_KeysDataBase.Click += new System.EventHandler(this.btn_KeysDataBase_Click);
            // 
            // btn_Recognition
            // 
            this.btn_Recognition.Location = new System.Drawing.Point(30, 45);
            this.btn_Recognition.Name = "btn_Recognition";
            this.btn_Recognition.Size = new System.Drawing.Size(195, 41);
            this.btn_Recognition.TabIndex = 5;
            this.btn_Recognition.Text = "Voice Recognition";
            this.btn_Recognition.UseVisualStyleBackColor = true;
            this.btn_Recognition.Click += new System.EventHandler(this.btn_Recognition_Click);
            // 
            // btn_init
            // 
            this.btn_init.Location = new System.Drawing.Point(658, 45);
            this.btn_init.Name = "btn_init";
            this.btn_init.Size = new System.Drawing.Size(181, 41);
            this.btn_init.TabIndex = 6;
            this.btn_init.Text = "Message Board";
            this.btn_init.UseVisualStyleBackColor = true;
            this.btn_init.Click += new System.EventHandler(this.btn_init_Click);
            // 
            // btn_speak
            // 
            this.btn_speak.Location = new System.Drawing.Point(447, 46);
            this.btn_speak.Name = "btn_speak";
            this.btn_speak.Size = new System.Drawing.Size(190, 40);
            this.btn_speak.TabIndex = 7;
            this.btn_speak.Text = "Text Speaker";
            this.btn_speak.UseVisualStyleBackColor = true;
            this.btn_speak.Click += new System.EventHandler(this.btn_speak_Click);
            // 
            // btn_video
            // 
            this.btn_video.Location = new System.Drawing.Point(447, 104);
            this.btn_video.Name = "btn_video";
            this.btn_video.Size = new System.Drawing.Size(190, 39);
            this.btn_video.TabIndex = 8;
            this.btn_video.Text = "Video Speak";
            this.btn_video.UseVisualStyleBackColor = true;
            this.btn_video.Click += new System.EventHandler(this.btn_video_Click);
            // 
            // btn_record
            // 
            this.btn_record.Location = new System.Drawing.Point(658, 105);
            this.btn_record.Name = "btn_record";
            this.btn_record.Size = new System.Drawing.Size(181, 38);
            this.btn_record.TabIndex = 9;
            this.btn_record.Text = "Record";
            this.btn_record.UseVisualStyleBackColor = true;
            this.btn_record.Click += new System.EventHandler(this.btn_record_Click);
            // 
            // btn_re
            // 
            this.btn_re.Location = new System.Drawing.Point(243, 103);
            this.btn_re.Name = "btn_re";
            this.btn_re.Size = new System.Drawing.Size(181, 41);
            this.btn_re.TabIndex = 10;
            this.btn_re.Text = "Recognition";
            this.btn_re.UseVisualStyleBackColor = true;
            this.btn_re.Click += new System.EventHandler(this.btn_re_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 562);
            this.Controls.Add(this.btn_re);
            this.Controls.Add(this.btn_record);
            this.Controls.Add(this.btn_video);
            this.Controls.Add(this.btn_speak);
            this.Controls.Add(this.btn_init);
            this.Controls.Add(this.btn_Recognition);
            this.Controls.Add(this.btn_KeysDataBase);
            this.Controls.Add(this.tbx_content);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_SearchFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Speech Note shizheng CID 2013213234";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_SearchFiles;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbx_content;
        private System.Windows.Forms.Button btn_KeysDataBase;
        private System.Windows.Forms.Button btn_Recognition;
        private System.Windows.Forms.Button btn_init;
        private System.Windows.Forms.Button btn_speak;
        private System.Windows.Forms.Button btn_video;
        private System.Windows.Forms.Button btn_record;
        private System.Windows.Forms.Button btn_re;
    }
}

