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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();

        }

    

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (Connection.databasename != null)
            {
                try
                {
                    Taikhoan tk = DAO_TaiKhoan.Instance.getListTaiKhoan(txt_TenDangNhap.Text, txt_MatKhau.Text);
                    Session.phanquyen = tk.phanquyen;
                    if (tk != null)
                    {
                        if (tk.phanquyen == 1)
                        {
                            frm_Home home = new frm_Home();
                            this.Hide();
                            home.ShowDialog();
                            this.Show();
                        }
                        if (tk.phanquyen == 0)
                        {
                            frm_Home home = new frm_Home();
                            this.Hide();
                            home.ShowDialog();
                            this.Show();
                        }

                    }
                    else
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo!");

                }
                catch
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo!");
                }
            }
            else
                MessageBox.Show("Vui lòng kết nối cơ sở dữ liệu!");
         
        }

        private void pic_KetNoiData_Click(object sender, EventArgs e)
        {
            FormKetNoi fkn = new FormKetNoi();
            this.Hide();
            fkn.ShowDialog();
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VUi lòng liên hệ Chủ quán");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
