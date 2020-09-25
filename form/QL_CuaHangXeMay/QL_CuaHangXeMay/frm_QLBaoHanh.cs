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
    public partial class frm_QLBaoHanh : Form
    {
        public frm_QLBaoHanh()
        {
            InitializeComponent();
            load_data();
            load_cobo_KH();
            txt_maBH.Enabled = false;
        }

        void load_data()
        {
            string query = "select MaBH, HoTenKH,SoKhung,SoMay,NgayBH from BaoHanh, KhachHang where BaoHanh.MaKH = KhachHang.MaKH";
            dgv_BaoHanh.DataSource = DataProvider.Instance.ExecuteQury(query);
            dgv_BaoHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void load_cobo_KH()
        {
            string query = "select * from KhachHang";
            cbo_tenkhachhang.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_tenkhachhang.DisplayMember = "HoTenKH";
            cbo_tenkhachhang.ValueMember = "MaKH";
        }

        private void dgv_BaoHanh_Click(object sender, EventArgs e)
        {
            int i = dgv_BaoHanh.CurrentCell.RowIndex;
            txt_maBH.Text = dgv_BaoHanh.Rows[i].Cells[0].Value.ToString();
            cbo_tenkhachhang.Text = dgv_BaoHanh.Rows[i].Cells[1].Value.ToString();
            txt_SoKhung.Text = dgv_BaoHanh.Rows[i].Cells[2].Value.ToString();
            txt_SoMay.Text = dgv_BaoHanh.Rows[i].Cells[3].Value.ToString();
            date_ngaybaohanh.Text = dgv_BaoHanh.Rows[i].Cells[4].Value.ToString();
            cbo_tenkhachhang.Enabled = false;
            txt_SoKhung.Enabled = false;
            txt_SoMay.Enabled = false;
            date_ngaybaohanh.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            cbo_tenkhachhang.Enabled = true;
            txt_SoKhung.Enabled = true;
            txt_SoMay.Enabled = true;
            date_ngaybaohanh.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            cbo_tenkhachhang.Enabled = true;
            txt_SoKhung.Enabled = true;
            txt_SoMay.Enabled = true;
            date_ngaybaohanh.Enabled = true;
            txt_maBH.Clear();
            txt_SoKhung.Focus();
            txt_SoKhung.Clear();
            txt_SoMay.Clear();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_maBH.Text == "")
                {
                    string query = "insert into BaoHanh values(" + cbo_tenkhachhang.SelectedValue.ToString() + ",'" + txt_SoKhung.Text + "','" + txt_SoMay.Text + "','" + DateTime.Parse(date_ngaybaohanh.Text) + "')";
                    int so = DataProvider.Instance.ExecuteNonQuery(query);
                    if (so > 0)
                        MessageBox.Show("Thêm thành công!");
                    else
                        MessageBox.Show("Thêm thành công!");
                    load_data();

                }
                else
                {
                    string query = "update BaoHanh set MaKH='" + cbo_tenkhachhang.SelectedValue.ToString() + "',SoKhung='" + txt_SoKhung.Text + "',SoMay='" + txt_SoMay.Text + "',NgayBH='" + DateTime.Parse(date_ngaybaohanh.Text) + "' where MaBH=" + txt_maBH.Text + "";
                    int so = DataProvider.Instance.ExecuteNonQuery(query);
                    if (so > 0)
                        MessageBox.Show("Sửa thành công!");
                    else
                        MessageBox.Show("Sửa Thất bại!");
                    load_data();
                }
            }
            catch
            {
                MessageBox.Show("Xe này không có trong hệ thống!");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string query = " delete from BaoHanh where MaBH=" + txt_maBH.Text + "";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            load_data();
        }
    }
}
