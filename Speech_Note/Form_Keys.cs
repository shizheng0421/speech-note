using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace Speech_Note
{
    public partial class Form_Keys : Skin_Mac
    {
        public Form_Keys()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (tbx_Keys.Text != "")
            {
                string cmd = "SELECT * FROM `"+Common.keysTBName+"` WHERE `Keys` LIKE '%" + tbx_Keys.Text + "%'";
                dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, cmd, null).Tables[0].DefaultView;
                int ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
            }
            else
            {
                MessageBox.Show("载入所有关键词/Load all the keywords");
                dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from " + Common.keysTBName, null).Tables[0].DefaultView;
            }
          
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (tbx_Keys.Text != "")
            {
                string cmd = "SELECT * FROM `"+Common.keysTBName+"` WHERE `Keys`='" + tbx_Keys.Text + "'";
                int ex = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from "+Common.keysTBName, null).Tables.Count;
                try {
                    cmd = "INSERT INTO "+Common.keysTBName+" VALUES ('" + tbx_Keys.Text + "')";
                    ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
                    if (ex < 1)
                    {
                        MessageBox.Show("关键词添加失败/Keywords add failure");
                        tbx_Keys.Focus();
                    }
                    else
                    {
                        MessageBox.Show("成功添加关键词/Add keywords successfully：" + tbx_Keys.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("该关键词已存在/The keyword already exists");
                    tbx_Keys.Focus();
                    tbx_Keys.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("不能添加空关键字/Cannot add empty keywords");
            }
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from "+Common.keysTBName, null).Tables[0].DefaultView;

        }

        private void Form_Keys_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from " + Common.keysTBName, null).Tables[0].DefaultView;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbx_Keys.Text = dataGridView1.SelectedCells[0].Value.ToString();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (tbx_Keys.Text != "")
            {
                string cmd = "DELETE FROM `"+Common.keysTBName+"` WHERE `Keys`='" + tbx_Keys.Text + "'";
                int ex = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, cmd, null);
                if (ex == -1)
                {
                    MessageBox.Show("删除失败/Delete failure");
                    tbx_Keys.Focus();
                    tbx_Keys.SelectAll();
                }
                else
                {
                    
                        MessageBox.Show("成功删除关键词/Keyword deletion successfully：" + tbx_Keys.Text);

                }
            }
            else
            {
                MessageBox.Show("不能删除空关键字/Cannot delete empty keywords");
            }
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from " + Common.keysTBName, null).Tables[0].DefaultView;

        }

        private void btn_Multi_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ParameterizedThreadStart(delegate { Application.Run(new Form_Vocabulary_Bank()); }));
            t.ApartmentState = ApartmentState.STA;
            t.Start();
            this.Close();
        }
    }
}
