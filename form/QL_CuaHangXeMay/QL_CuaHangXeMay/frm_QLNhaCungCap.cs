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
using System.Text.RegularExpressions;
namespace QL_CuaHangXeMay
{
    public partial class frm_QLNhaCungCap : Form
    {
        public frm_QLNhaCungCap()
        {
            InitializeComponent();
            load_data();
        }
        void load_data()
        {
            string query = "select * from NhaCungCap";
            dgv_NhaCungCap.DataSource = DataProvider.Instance.ExecuteQury(query);
            txt_manhacungcap.Enabled = false;
            dgv_NhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm_hoadonNCC fhdncc = new frm_hoadonNCC();
            this.Hide();
            fhdncc.ShowDialog();
            this.Show();
        }

        private void dgv_NhaCungCap_Click(object sender, EventArgs e)
        {
            int so = dgv_NhaCungCap.CurrentCell.RowIndex;
            txt_manhacungcap.Text = dgv_NhaCungCap.Rows[so].Cells[0].Value.ToString();
            txt_TenNhaCungCap.Text = dgv_NhaCungCap.Rows[so].Cells[1].Value.ToString();
            txt_DiaChiNhaCungCap.Text = dgv_NhaCungCap.Rows[so].Cells[2].Value.ToString();
            txt_SoDienThoaiNhaCungCap.Text = dgv_NhaCungCap.Rows[so].Cells[3].Value.ToString();
            txt_EmailNhaCungCap.Text = dgv_NhaCungCap.Rows[so].Cells[4].Value.ToString();
            txt_DiaChiNhaCungCap.Enabled = false;
            txt_EmailNhaCungCap.Enabled = false;
            txt_SoDienThoaiNhaCungCap.Enabled = false;
            txt_TenNhaCungCap.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_DiaChiNhaCungCap.Enabled = true;
            txt_EmailNhaCungCap.Enabled = true;
            txt_SoDienThoaiNhaCungCap.Enabled = true;
            txt_TenNhaCungCap.Enabled = true;
            txt_DiaChiNhaCungCap.Clear();
            txt_EmailNhaCungCap.Clear();
            txt_manhacungcap.Clear();
            txt_SoDienThoaiNhaCungCap.Clear();
            txt_TenNhaCungCap.Clear();
            txt_TenNhaCungCap.Focus();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            txt_DiaChiNhaCungCap.Enabled = true;
            txt_EmailNhaCungCap.Enabled = true;
            txt_SoDienThoaiNhaCungCap.Enabled = true;
            txt_TenNhaCungCap.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string query = "delete from NhaCungCap where MaNCC = "+txt_manhacungcap.Text+"";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            load_data();
            txt_DiaChiNhaCungCap.Clear();
            txt_EmailNhaCungCap.Clear();
            txt_manhacungcap.Clear();
            txt_SoDienThoaiNhaCungCap.Clear();
            txt_TenNhaCungCap.Clear();
        }

        string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reg = new Regex(match);
                if (reg.IsMatch(txt_EmailNhaCungCap.Text))
                {
                    if (txt_manhacungcap.Text == "")
                    {
                        string query = "insert into NhaCungCap values(N'" + txt_TenNhaCungCap.Text + "',N'" + txt_DiaChiNhaCungCap.Text + "'," + txt_SoDienThoaiNhaCungCap.Text + ",'" + txt_EmailNhaCungCap.Text + "')";
                        int so = DataProvider.Instance.ExecuteNonQuery(query);
                        if (so > 0)
                            MessageBox.Show("Thêm thành công!");
                        else
                            MessageBox.Show("Thêm thành công!");
                        load_data();

                    }
                    else
                    {
                        string query = "update NhaCungCap set TenNCC=N'" + txt_TenNhaCungCap.Text + "',DiaChiNCC=N'" + txt_DiaChiNhaCungCap.Text + "',SoDTNCC=" + txt_SoDienThoaiNhaCungCap.Text + ",EmailNCC='" + txt_EmailNhaCungCap.Text + "' where MaNCC=" + txt_manhacungcap.Text + "";
                        int so = DataProvider.Instance.ExecuteNonQuery(query);
                        if (so > 0)
                            MessageBox.Show("Sửa thành công!");
                        else
                            MessageBox.Show("Sửa thành công!");
                        load_data();
                    }
                }
                else
                    MessageBox.Show("Email không hợp lệ!");
            }
            catch
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
            }

       

        private void txt_SoDienThoaiNhaCungCap_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_SoDienThoaiNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        
       
    }
}
