using QL_CuaHangXeMay.Modul;
using QL_CuaHangXeMay.Report;
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
    public partial class frm_Home : Form
    {
        public frm_Home()
        {
            InitializeComponent();
            load_data();
            load_cbo_tennv();
            load_cbo_nhomxe();
            load_tenKH();
            if (Session.phanquyen == 0)
            {
                ((Control)this.tab_QuanLi).Enabled = false;
                ((Control)this.tab_HeThong).Enabled = false;
            }
                
        }

        void load_cbo_tennv()
        {
            string query = " select * from NhanVien";
            cbo_TenNhanVien.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_TenNhanVien.DisplayMember = "HoTenNV";
            cbo_TenNhanVien.ValueMember = "MaNV";
        }

        void load_cbo_nhomxe()
        {
            string query = "select * from NhomXe";
            cbo_TenNhomXe.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_TenNhomXe.DisplayMember = "MANX";
            cbo_TenNhomXe.ValueMember = "MANX";
        }

        void load_tenKH()
        {
            string query = " select * from KhachHang";
            cbo_TenKhachHang.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_TenKhachHang.DisplayMember = "HoTenKH";
            cbo_TenKhachHang.ValueMember = "MaKH";
        }

        private void cbo_TenNhomXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = " select * from xe where Ma_NX='" + cbo_TenNhomXe.SelectedValue.ToString() + "'";
            cbo_SoKhung.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_SoKhung.DisplayMember = "SoKhung";
            cbo_SoKhung.ValueMember = "SoKhung";
        }

        private void cbo_SoKhung_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = " select * from Xe where sokhung='"+cbo_SoKhung.SelectedValue.ToString()+"'";
            cbo_SoMay.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_SoMay.DisplayMember = "SoMay";
            cbo_SoMay.ValueMember = "SoMay";

            string query2 = " select * from MauSac where SoKhung = '" + cbo_SoKhung.SelectedValue.ToString() + "'";
            cbo_MauSacXe.DataSource = DataProvider.Instance.ExecuteQury(query2);
            cbo_MauSacXe.DisplayMember = "Mau";
            cbo_MauSacXe.ValueMember = "Mau";

            cbo_dongia.DataSource = DataProvider.Instance.ExecuteQury(query2);
            cbo_dongia.DisplayMember = "DonGia";
            cbo_dongia.ValueMember = "DonGia";

            txt_Tongtien.Text = cbo_dongia.SelectedValue.ToString();
        }

      

        //---------------------------------------------------------------- FROM NHAN VIEN ---------------------------------------------------------------------
        void load_data()
        {
            if (Session.phanquyen == 1)
            {
                string query = "select *  from DangNhap";
                dgv_HeThong.DataSource = DataProvider.Instance.ExecuteQury(query);
                dgv_HeThong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Them_HeThong_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_QLKhachHang fkhachhang = new frm_QLKhachHang();
            fkhachhang.TopLevel = false;
            this.pnl_Contain.Controls.Add(fkhachhang);
            fkhachhang.Show();
        }

        private void btn_NhaCungCap_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_QLNhaCungCap fnhacungcap = new frm_QLNhaCungCap();
            fnhacungcap.TopLevel = false;
            this.pnl_Contain.Controls.Add(fnhacungcap);
            fnhacungcap.Show();
        }

       

        private void btn_Them_HeThong_Click_1(object sender, EventArgs e)
        {
            frm_themDangnhap fthemdangnhap = new frm_themDangnhap();
            this.Hide();
            fthemdangnhap.ShowDialog();
            this.Show();
            load_data();
        }

        private void btn_Sua_HeThong_Click(object sender, EventArgs e)
        {
            frm_suadangnhap fsuadangnhap = new frm_suadangnhap();
            this.Hide();
            fsuadangnhap.ShowDialog();
            this.Show();
            load_data();
        }

        private void dgv_HeThong_Click_1(object sender, EventArgs e)
        {
            int i = dgv_HeThong.CurrentCell.RowIndex;
            txt_Tendangnhap.Text = dgv_HeThong.Rows[i].Cells[0].Value.ToString();
            txt_Matkhau.Text = dgv_HeThong.Rows[i].Cells[1].Value.ToString();
        }

        private void btn_Xoa_HeThong_Click(object sender, EventArgs e)
        {

            string query = "delete from DangNhap where UserName='"+txt_Tendangnhap.Text+"'";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            txt_Tendangnhap.Clear();
            txt_Matkhau.Clear();
            load_data();
        }

        private void btn_HoaDonThanhToan_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_hoadonbanxe fhdbx = new frm_hoadonbanxe();
            fhdbx.TopLevel = false;
            this.pnl_Contain.Controls.Add(fhdbx);
            fhdbx.Show();
        }

        private void btn_PhieuNhap_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_QLPhieuNhapXe fphieunhap = new frm_QLPhieuNhapXe();
            fphieunhap.TopLevel = false;
            this.pnl_Contain.Controls.Add(fphieunhap);
            fphieunhap.Show();
        }

        private void btn_NhomXe_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_QLNhomXe fnhomxe = new frm_QLNhomXe();
            fnhomxe.TopLevel = false;
            this.pnl_Contain.Controls.Add(fnhomxe);
            fnhomxe.Show();
        }

        private void btn_Xe_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_QLXe xe = new frm_QLXe();
            xe.TopLevel = false;
            this.pnl_Contain.Controls.Add(xe);
            xe.Show();
        }

        private void btn_BaoHanh_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_QLBaoHanh fbaohanh = new frm_QLBaoHanh();
            fbaohanh.TopLevel = false;
            this.pnl_Contain.Controls.Add(fbaohanh);
            fbaohanh.Show();
        }

        private void bunifuTileButton17_Click(object sender, EventArgs e)
        {
            this.pnl_Contain.Controls.Clear();
            frm_QLNhanVien fnv = new frm_QLNhanVien();
            fnv.TopLevel = false;
            this.pnl_Contain.Controls.Add(fnv);
            fnv.Show();
        }

        private void dgv_HeThong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Them_HoaDonBanXe_Click(object sender, EventArgs e)
        {
            string query = " insert into HoaDonBanXe values(N'"+cbo_TenKhachHang.SelectedValue.ToString()+"',N'"+cbo_TenNhomXe.SelectedValue.ToString()+"',N'"+cbo_TenNhanVien.SelectedValue.ToString()+"','"+cbo_SoKhung.SelectedValue.ToString()+"','"+cbo_SoMay.SelectedValue.ToString()+"',1,N'"+cbo_MauSacXe.SelectedValue.ToString()+"',"+txt_Tongtien.Text+",'"+DateTime.Parse(datNgayLap.Text)+"')";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Thanh toán thành công!");
            else
                MessageBox.Show("Thanh toán thất bại!");
            txt_Tongtien.Clear();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            HoaDon rpt = new HoaDon();
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa","123","Hntn\\sqlexpress","QL_CuaHangXe");
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.RefreshReport();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {

        }

       

        
       

        
    }
}
