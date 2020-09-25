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
    public partial class frm_QLNhanVien : Form
    {
        public frm_QLNhanVien()
        {
            InitializeComponent();
            load_data();
            txt_maNhanvien.Enabled = false;
            txt_DiaChiNhanVien.Enabled = false;
            txt_HoTenNhanVien.Enabled = false;
            txt_LuongNhanVien.Enabled = false;
            txt_SoChungMinhNhanVien.Enabled = false;
            txt_SoDienThoaiNhanVien.Enabled = false;
        }


        void load_data()
        {
            string query = "select * from NhanVien";
            dgv_NhanVien.DataSource = DataProvider.Instance.ExecuteQury(query);
            dgv_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgv_NhanVien_Click(object sender, EventArgs e)
        {
            int i = dgv_NhanVien.CurrentCell.RowIndex;
            txt_maNhanvien.Text = dgv_NhanVien.Rows[i].Cells[0].Value.ToString();
            txt_HoTenNhanVien.Text = dgv_NhanVien.Rows[i].Cells[1].Value.ToString();
            txt_SoChungMinhNhanVien.Text = dgv_NhanVien.Rows[i].Cells[2].Value.ToString();
            txt_DiaChiNhanVien.Text = dgv_NhanVien.Rows[i].Cells[3].Value.ToString();
            txt_SoDienThoaiNhanVien.Text = dgv_NhanVien.Rows[i].Cells[4].Value.ToString();
            txt_LuongNhanVien.Text = dgv_NhanVien.Rows[i].Cells[5].Value.ToString();
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            txt_DiaChiNhanVien.Enabled = false;
            txt_HoTenNhanVien.Enabled = false;
            txt_LuongNhanVien.Enabled = false;
            txt_SoChungMinhNhanVien.Enabled = false;
            txt_SoDienThoaiNhanVien.Enabled = false;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_DiaChiNhanVien.Clear();
            txt_HoTenNhanVien.Clear();
            txt_LuongNhanVien.Clear();
            txt_maNhanvien.Clear();
            txt_SoChungMinhNhanVien.Clear();
            txt_SoDienThoaiNhanVien.Clear();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            txt_DiaChiNhanVien.Enabled = true;
            txt_HoTenNhanVien.Enabled = true;
            txt_LuongNhanVien.Enabled = true;
            txt_SoChungMinhNhanVien.Enabled = true;
            txt_SoDienThoaiNhanVien.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            txt_DiaChiNhanVien.Enabled = true;
            txt_HoTenNhanVien.Enabled = true;
            txt_LuongNhanVien.Enabled = true;
            txt_SoChungMinhNhanVien.Enabled = true;
            txt_SoDienThoaiNhanVien.Enabled = true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_maNhanvien.Text == "")
            {
                string query = "insert into NhanVien values(N'"+txt_HoTenNhanVien.Text+"',"+txt_SoChungMinhNhanVien.Text+",N'"+txt_DiaChiNhanVien.Text+"',"+txt_SoDienThoaiNhanVien.Text+","+txt_LuongNhanVien.Text+")";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Thêm thành công!");
                else
                    MessageBox.Show("Thêm thành công!");
                load_data();

            }
            else
            {
                string query = "update NhanVien set HotenNV=N'"+txt_HoTenNhanVien.Text+"', SoCMTNV="+txt_SoChungMinhNhanVien.Text+",DiaChiNV=N'"+txt_DiaChiNhanVien.Text+"',SoDTNV="+txt_SoDienThoaiNhanVien.Text+",Luong="+txt_LuongNhanVien.Text+" where MaNV="+txt_maNhanvien.Text+"";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Sửa thành công!");
                else
                    MessageBox.Show("Sửa Thất bại!");
                load_data();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from NhanVien where MaNV=" + txt_maNhanvien.Text + "";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Xóa thành công!");
                else
                    MessageBox.Show("Xóa Thất bại!");
                load_data();
            }
            catch
            {
                MessageBox.Show("Bạn không thể xóa nhân viên này!");
            }
        }


    }
}
