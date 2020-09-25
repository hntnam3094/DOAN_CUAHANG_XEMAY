using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_CuaHangXeMay.Modul;
namespace QL_CuaHangXeMay
{
    public partial class FormKetNoi : Form
    {
        public FormKetNoi()
        {
            InitializeComponent();
            load();
        }


        void load()
        {
            txtsever.Text = Connection.sever;
            txtusername.Text = Connection.sa;
            txtpassword.Text = Connection.pass;
            txtdatabase.Text = Connection.databasename;
        }
        private void btnConc_Click(object sender, EventArgs e)
        {
            if (txtdatabase.Text == "" || txtpassword.Text == "" || txtsever.Text == "" || txtusername.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                Connection.sever = "";
                Connection.sa = "";
                Connection.pass = "";
                Connection.databasename = "";
                Connection.sever = txtsever.Text;
                Connection.sa = txtusername.Text;
                Connection.pass = txtpassword.Text;
                Connection.databasename = txtdatabase.Text;
                MessageBox.Show("Gửi dữ liệu thành công!");

            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.sever = "";
            Connection.sa = "";
            Connection.pass = "";
            Connection.databasename = "";
            txtsever.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtdatabase.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select count(*) from NhanVien";
                int so = (int)DataProvider.Instance.ExecuteScalar(query);
                if (so > 0)
                    MessageBox.Show("Kết nối thành công!");
                else
                    MessageBox.Show("Kết nối thất bại!");
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại!");
            }
        }
    }
}
