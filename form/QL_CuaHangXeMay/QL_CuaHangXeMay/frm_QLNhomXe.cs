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
    public partial class frm_QLNhomXe : Form
    {
        public frm_QLNhomXe()
        {
            InitializeComponent();
            load_data();
            load_cbo_nhomxe();
            
        }

        void load_cbo_nhomxe()
        {
            string query = "select HangSX from NhomXe group by HangSX";
            cbo_TimKiemNhomXe.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_TimKiemNhomXe.DisplayMember = "HangSX";
            cbo_TimKiemNhomXe.ValueMember = "HangSX";
        }

        void load_data()
        {
            string query = "select * from NhomXe";
            dgv_NhomXe.DataSource = DataProvider.Instance.ExecuteQury(query);
            dgv_NhomXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgv_NhomXe_Click(object sender, EventArgs e)
        {
            int i = dgv_NhomXe.CurrentCell.RowIndex;
            txt_MaNhomXe.Text = dgv_NhomXe.Rows[i].Cells[0].Value.ToString();
            txt_HangSanXuat.Text = dgv_NhomXe.Rows[i].Cells[1].Value.ToString();
            txt_Dongia.Text = dgv_NhomXe.Rows[i].Cells[2].Value.ToString();
            txt_SoLuong.Text = dgv_NhomXe.Rows[i].Cells[3].Value.ToString();
            txt_Dongia.Enabled = false;
            txt_HangSanXuat.Enabled = false;
            txt_MaNhomXe.Enabled = false;
            txt_SoLuong.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
           
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

            txt_HangSanXuat.Enabled = true;
            txt_Dongia.Enabled = true;
            txt_SoLuong.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_Dongia.Clear();
            txt_HangSanXuat.Clear();
            txt_MaNhomXe.Clear();
            txt_SoLuong.Clear();
            txt_HangSanXuat.Focus();
            txt_HangSanXuat.Enabled = true;
            txt_Dongia.Enabled = true;
            txt_SoLuong.Enabled = true;
            txt_MaNhomXe.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string query = "delete from NhomXe where MaNX='"+txt_MaNhomXe.Text+"'";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            load_data();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_MaNhomXe.Enabled == true)
            {
                string query = "insert into NhomXe values('"+txt_MaNhomXe.Text+"','"+txt_HangSanXuat.Text+"',"+txt_Dongia.Text+","+txt_SoLuong.Text+")";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Thêm thành công!");
                else
                    MessageBox.Show("Thêm thành công!");
                load_data();

            }
            else
            {
                string query = "update NhomXe set HangSX='" + txt_HangSanXuat.Text + "',DonGia=" + txt_Dongia.Text + ",SoLuong=" + txt_SoLuong.Text + " where MaNX='" + txt_MaNhomXe.Text + "'";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Sửa thành công!");
                else
                    MessageBox.Show("Sửa thành công!");
                load_data();
            }
        }

        private void cbo_TimKiemNhomXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from NhomXe where HangSX='" + cbo_TimKiemNhomXe.SelectedValue.ToString() + "'";
            dgv_NhomXe.DataSource = DataProvider.Instance.ExecuteQury(query);
            dgv_NhomXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
