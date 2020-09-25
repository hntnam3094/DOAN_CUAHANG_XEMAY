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
    public partial class frm_hoadonbanxe : Form
    {
        public frm_hoadonbanxe()
        {
            InitializeComponent();
            load_data();
        }
        void load_data()
        {
            string query = "select MaHD, KhachHang.HoTenKH, MaNX, NhanVien.HotenNV, SoKhung, SoMay, SoLuong, MauSac, NgayLapHD, TongTienHD from HoaDonBanXe, KhachHang, NhanVien where HoaDonBanXe.MaKH = KhachHang.MaKH and NhanVien.MaNV= HoaDonBanXe.MaNV";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQury(query);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            string mahd = dataGridView1.Rows[i].Cells[0].Value.ToString();

            string query ="delete from HoaDonBanXe where MaHD="+mahd+"";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            load_data();



        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;

        }
    }
}
