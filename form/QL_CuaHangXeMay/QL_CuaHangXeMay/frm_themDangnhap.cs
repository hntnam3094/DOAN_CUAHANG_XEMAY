using QL_CuaHangXeMay.Modul;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_CuaHangXeMay
{
    public partial class frm_themDangnhap : Form
    {
        public frm_themDangnhap()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_HeThong_Click(object sender, EventArgs e)
        {
            if (txt_Matkhau.Text != txt_nhaplaimatkhau.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
            }
            else
            {
                string query = "insert into DangNhap values('" + txt_Tendangnhap.Text + "'," + txt_Matkhau.Text + ")";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Thêm thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
                txt_Tendangnhap.Clear();
                txt_Matkhau.Clear();
                txt_nhaplaimatkhau.Clear();
            }
        }
    }
}
