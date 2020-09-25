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
    public partial class frm_QLXe : Form
    {
        public frm_QLXe()
        {
            InitializeComponent();
            load_data();
            load_cobo_nhomxe();
            cbo_nhomxe.Enabled = false;
            txt_Dongia.Enabled = false;
            txt_mausac.Enabled = false;
            txt_Sokhung.Enabled = false;
            txt_Somay.Enabled = false;
            load_cbo_timkiem();
            
        }

        void load_cbo_timkiem()
        {
            string query = "select Ma_NX from xe  group by Ma_NX";
            cbo_TimKiemXe.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_TimKiemXe.DisplayMember = "Ma_NX";
            cbo_TimKiemXe.ValueMember = "Ma_NX";
        }
        void load_data()
        {
            string query = "select Xe.Ma_NX,Xe.SoKhung,SoMay,Mau,DonGia from xe, mausac where xe.SoKhung = MauSac.sokhung";
            dgv_Xe.DataSource = DataProvider.Instance.ExecuteQury(query);
            dgv_Xe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void load_cobo_nhomxe()
        {
            string query = "select MaNX from NhomXe";
            cbo_nhomxe.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_nhomxe.ValueMember = "MaNX";
        }

       

        private void dgv_Xe_Click(object sender, EventArgs e)
        {
            int i = dgv_Xe.CurrentCell.RowIndex;
            cbo_nhomxe.Text = dgv_Xe.Rows[i].Cells[0].Value.ToString();
            txt_mausac.Text = dgv_Xe.Rows[i].Cells[3].Value.ToString();
            txt_Sokhung.Text = dgv_Xe.Rows[i].Cells[1].Value.ToString();
            txt_Somay.Text = dgv_Xe.Rows[i].Cells[2].Value.ToString();
            txt_Dongia.Text = dgv_Xe.Rows[i].Cells[4].Value.ToString();
            cbo_nhomxe.Enabled = false;
            txt_Dongia.Enabled = false;
            txt_mausac.Enabled = false;
            txt_Sokhung.Enabled = false;
            txt_Somay.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            
        }

        bool kiemtra(string txt)
        {
            string query = "select COUNT(*) from xe where SoKhung='"+txt+"'";
            int so = (int)DataProvider.Instance.ExecuteScalar(query);
            if (so > 0)
                return true;
            else
                return false;
        }
       

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_Dongia.Enabled = true;
            txt_mausac.Enabled = true;
            txt_Sokhung.Enabled = true;
            txt_Somay.Enabled = true;
            cbo_nhomxe.Enabled = true;
            txt_Dongia.Clear();
            txt_mausac.Clear();
            txt_Sokhung.Clear();
            txt_Somay.Clear();
            txt_Sokhung.Focus();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            txt_mausac.Enabled = true;
            txt_Dongia.Enabled = true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_Sokhung.Enabled == true)
            {
                if (kiemtra(txt_Sokhung.Text))
                {
                    MessageBox.Show("Xe này đã tồn tại!", "Thông báo!");
                }
                else
                {
                    string query = "insert into Xe values('" + cbo_nhomxe.SelectedValue.ToString() + "','" + txt_Sokhung.Text + "','" + txt_Somay.Text + "')";
                    int so = DataProvider.Instance.ExecuteNonQuery(query);
                    if (so > 0)
                    {
                        string query2 = "insert into MauSac values('" + txt_Sokhung.Text + "',N'" + txt_mausac.Text + "','" + cbo_nhomxe.SelectedValue.ToString() + "'," + txt_Dongia.Text + ")";
                        int so2 = DataProvider.Instance.ExecuteNonQuery(query2);
                        if (so2 > 0)
                            MessageBox.Show("Thêm thành công!");
                        txt_Dongia.Clear();
                        txt_mausac.Clear();
                        txt_Sokhung.Clear();
                        txt_Somay.Clear();
                        txt_Sokhung.Focus();
                    }
                    else
                        MessageBox.Show("Thêm thất bại!");
                    load_data();
                }
            }
            else
            {
                string query = "update Mausac set Mau = N'"+txt_mausac.Text+"' , DonGia = '"+txt_Dongia.Text+"' where SoKhung = '"+txt_Sokhung.Text+"'";
                int so = DataProvider.Instance.ExecuteNonQuery(query);
                if (so > 0)
                    MessageBox.Show("Sửa thành công!");
                else
                    MessageBox.Show("Sửa thất bại!");
                txt_mausac.Enabled = false;
                txt_Dongia.Enabled = false;
                load_data();
            }
        }

        private void cbo_nhomxe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Dongia.Clear();
            txt_mausac.Clear();
            txt_Sokhung.Clear();
            txt_Somay.Clear();
            txt_Sokhung.Focus();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string query = "delete from xe where SoKhung='" + txt_Sokhung.Text + "'";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
            {
                string query2 = "delete from mausac where sokhung = '" + txt_Sokhung.Text + "'";
                int so2 = DataProvider.Instance.ExecuteNonQuery(query2);
                if (so2 > 0)
                    MessageBox.Show("Xóa thành công!");
                load_data();
            }
            else
                MessageBox.Show("Xóa thất bại!");
        }

        private void cbo_TimKiemXe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select Xe.Ma_NX,Xe.SoKhung,SoMay,Mau,DonGia from xe, mausac where xe.SoKhung = MauSac.sokhung and Xe.Ma_NX = '" + cbo_TimKiemXe.SelectedValue.ToString() + "'";
            dgv_Xe.DataSource = DataProvider.Instance.ExecuteQury(query);
            dgv_Xe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
