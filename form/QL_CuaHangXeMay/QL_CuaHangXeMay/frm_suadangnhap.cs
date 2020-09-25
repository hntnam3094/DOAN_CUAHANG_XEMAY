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
    public partial class frm_suadangnhap : Form
    {
        public frm_suadangnhap()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Luu_HeThong_Click(object sender, EventArgs e)
        {
            if (txt_matkhaumoi.Text != txt_nhaplaimatkhaumoi.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
            }
            else
            {
                string query = "update DangNhap set Password="+txt_matkhaumoi.Text+" where UserName='"+txt_Tendangnhap.Text+"'";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Sửa thành công!");
                else
                    MessageBox.Show("Sửa thất bại!");
                txt_nhaplaimatkhaumoi.Clear();
                txt_Matkhaucu.Clear();
                txt_matkhaumoi.Clear();
               
            }
        }
    }
}
