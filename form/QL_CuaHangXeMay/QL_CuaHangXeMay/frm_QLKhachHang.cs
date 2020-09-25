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
    public partial class frm_QLKhachHang : Form
    {
        public frm_QLKhachHang()
        {
            InitializeComponent();
            load_data();

        }

        void load_data()
        {
            string query = "select * from KHACHHANG";
            dgv_KhachHang.DataSource = DataProvider.Instance.ExecuteQury(query);
            txt_DiaChiKhachHang.Enabled = false;
            txt_HoTenKhachHang.Enabled = false;
            txt_makhachhang.Enabled = false;
            txt_SoChungMinhKhachHang.Enabled = false;
            txt_SoDienThoaiKhachHang.Enabled = false;
            dgv_KhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            
            string query = "delete from KhachHang where MaKH='" + txt_makhachhang.Text +"'";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            load_data();
        }

        private void dgv_KhachHang_Click(object sender, EventArgs e)
        {
            int i = dgv_KhachHang.CurrentCell.RowIndex;
            txt_makhachhang.Text = dgv_KhachHang.Rows[i].Cells[0].Value.ToString();
            txt_HoTenKhachHang.Text = dgv_KhachHang.Rows[i].Cells[1].Value.ToString();
            txt_SoChungMinhKhachHang.Text = dgv_KhachHang.Rows[i].Cells[2].Value.ToString();
            txt_DiaChiKhachHang.Text = dgv_KhachHang.Rows[i].Cells[3].Value.ToString();
            txt_SoDienThoaiKhachHang.Text = dgv_KhachHang.Rows[i].Cells[4].Value.ToString();
            txt_makhachhang.Enabled = false;
            txt_DiaChiKhachHang.Enabled = false;
            txt_HoTenKhachHang.Enabled = false;
            txt_SoChungMinhKhachHang.Enabled = false;
            txt_SoDienThoaiKhachHang.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_DiaChiKhachHang.Enabled = true;
            txt_HoTenKhachHang.Enabled = true;
            txt_SoChungMinhKhachHang.Enabled = true;
            txt_SoDienThoaiKhachHang.Enabled = true;
            txt_DiaChiKhachHang.Clear();
            txt_HoTenKhachHang.Clear();
            txt_makhachhang.Clear();
            txt_SoChungMinhKhachHang.Clear();
            txt_SoDienThoaiKhachHang.Clear();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            txt_makhachhang.Enabled = false;
            txt_HoTenKhachHang.Enabled = true;
            txt_DiaChiKhachHang.Enabled = true;
            txt_SoChungMinhKhachHang.Enabled = true;
            txt_SoDienThoaiKhachHang.Enabled = true;
        }

      

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                string qr = "select count(*) from khachhang where HoTenKH = '" + txt_HoTenKhachHang.Text + "'";
                int i = (int)DataProvider.Instance.ExecuteScalar(qr);
                if (i == 0)
                {
                    if (txt_makhachhang.Text == "")
                    {
                        string query = "insert into KhachHang values(N'" + txt_HoTenKhachHang.Text + "'," + txt_SoChungMinhKhachHang.Text + ",N'" + txt_DiaChiKhachHang.Text + "'," + txt_SoDienThoaiKhachHang.Text + ")";
                        int so = DataProvider.Instance.ExecuteNonQuery(query);
                        if (so > 0)
                            MessageBox.Show("Thêm thành công!");
                        else
                            MessageBox.Show("Thêm thành công!");
                        load_data();

                    }
                    else
                    {
                        string query = "update KhachHang set HoTenKH=N'" + txt_HoTenKhachHang.Text + "', SoCMTKH=" + txt_SoChungMinhKhachHang.Text + ",DiaChiKH=N'" + txt_DiaChiKhachHang.Text + "',SoDTKH=" + txt_SoDienThoaiKhachHang.Text + " where MAKH = " + txt_makhachhang.Text + "";
                        int so = DataProvider.Instance.ExecuteNonQuery(query);
                        if (so > 0)
                            MessageBox.Show("Sửa thành công!");
                        else
                            MessageBox.Show("Sửa Thất bại!");
                        load_data();
                    }
                }
                else
                {
                    MessageBox.Show("Khách hàng này đã tồn tại!", "Thông báo!");

                }
            }
            catch
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
          
        }

        private void txt_SoDienThoaiKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void dgv_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


       
    }
}
