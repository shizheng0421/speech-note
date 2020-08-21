using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Speech_Note
{
    public partial class Form_Init : Skin_Mac
    {
        public delegate void PrintInfoShow(object sender, EventArgs e);
        public event PrintInfoShow PrintEvent;


        public Form_Init()
        {
            InitializeComponent();
        }

        private void Form_Init_Load(object sender, EventArgs e)
        {
            tbx_DataSource.Text = Common.dataSource;
            tbx_UserID.Text = Common.uid;
            tbx_pwd.Text = Common.pwd;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认修改/Confirm change", "提示/SYSTEM WARNING", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Cancel)
            {

            }
            else
            {
                if (dr == DialogResult.Yes)
                {
                    //写db文件
                    Common.SetDataBaseInfo(tbx_DataSource.Text, tbx_UserID.Text, tbx_pwd.Text);
                }


                if (PrintEvent != null)
                {
                    PrintEvent(sender, e);
                }
                this.Close();
            }
        }
    }
}
