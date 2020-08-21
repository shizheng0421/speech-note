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
    public partial class Form_Visitors : Skin_Mac
    {
        public Form_Visitors()
        {
            InitializeComponent();
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            string cmd = "";
            cmd = "INSERT INTO `visitorstb` SET `UserName`='" +Common.user + "',`CreateTime`='" + DateTime.Now.ToString() + "',`Content`='" + textBox2.Text + "'";
            int ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
            Form_Visitors_Load(sender, e);
        }

        private void Form_Visitors_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from visitorstb", null).Tables[0].DefaultView;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            
        {
            int index= dataGridView1.CurrentRow.Index;
            string p = "用户名/Username：\r\n" + dataGridView1.Rows[index].Cells[0].Value+"\r\n时间/Time：\r\n"+ dataGridView1.Rows[index].Cells[1].Value + "\r\n内容/Content：\r\n"+ dataGridView1.Rows[index].Cells[2].Value;
            textBox2.Text = p;
            btn_Upload.Enabled = false;
        }
    }
}
