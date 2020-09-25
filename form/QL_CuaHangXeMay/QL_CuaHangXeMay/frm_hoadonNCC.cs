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
    public partial class frm_hoadonNCC : Form
    {
        public frm_hoadonNCC()
        {
            InitializeComponent();
            load_data();
            load_ncc();
        }

        void load_data()
        {
            string query = "select MaTT,TenNCC,TongTienTT,NgayLapTT from ThanhToanChoNCC, NhaCungCap where ThanhToanChoNCC.MaNCC=NhaCungCap.MaNCC";
            dgv_ThanhToanNhaCungCap.DataSource = DataProvider.Instance.ExecuteQury(query);
            txt_manhacungcap.Enabled = false;
            txt_TongTienThanhToan.Enabled = false;
            dat_NgayLap.Enabled = false;
            cbo_TenNhaCungCap.Enabled = false;
        }
        private void dgv_ThanhToanNhaCungCap_Click(object sender, EventArgs e)
        {
            int i = dgv_ThanhToanNhaCungCap.CurrentCell.RowIndex;
            txt_manhacungcap.Text = dgv_ThanhToanNhaCungCap.Rows[i].Cells[0].Value.ToString();
            cbo_TenNhaCungCap.Text = dgv_ThanhToanNhaCungCap.Rows[i].Cells[1].Value.ToString();
            txt_TongTienThanhToan.Text = dgv_ThanhToanNhaCungCap.Rows[i].Cells[2].Value.ToString();
            dat_NgayLap.Text = dgv_ThanhToanNhaCungCap.Rows[i].Cells[3].Value.ToString();
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            txt_manhacungcap.Enabled = false;
            txt_TongTienThanhToan.Enabled = true;
            dat_NgayLap.Enabled = true;
            cbo_TenNhaCungCap.Enabled = true;
            txt_TongTienThanhToan.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_manhacungcap.Clear();
            txt_TongTienThanhToan.Enabled = true;
            cbo_TenNhaCungCap.Enabled = true;
            dat_NgayLap.Enabled = true;
            txt_TongTienThanhToan.Clear();
            txt_TongTienThanhToan.Focus();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        void load_ncc()
        {
            string query = "select * from NhaCungCap";
            cbo_TenNhaCungCap.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_TenNhaCungCap.DisplayMember = "TenNCC";
            cbo_TenNhaCungCap.ValueMember = "MaNCC";
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_manhacungcap.Text == "")
            {
                string query = "insert into ThanhToanChoNCC values("+cbo_TenNhaCungCap.SelectedValue.ToString()+","+txt_TongTienThanhToan.Text+",'"+DateTime.Parse(dat_NgayLap.Text)+"')";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Thêm thành công!");
                else
                    MessageBox.Show("Thêm thành công!");
                load_data();

            }
            else
            {

                string query = "update ThanhToanChoNCC set MaNCC=" + cbo_TenNhaCungCap.SelectedValue.ToString() + ",TongTienTT=" + txt_TongTienThanhToan.Text + ",NgayLapTT='" + DateTime.Parse(dat_NgayLap.Text) + "' where MaTT= "+txt_manhacungcap.Text+"";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Sửa thành công!");
                else
                    MessageBox.Show("Sửa thành công!");
                load_data();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string query = "delete from ThanhToanChoNCC where MaTT = "+txt_manhacungcap.Text+"";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            load_data();
        }
    }
}
