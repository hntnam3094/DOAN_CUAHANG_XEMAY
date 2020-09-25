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
    public partial class frm_QLPhieuNhapXe : Form
    {
        public frm_QLPhieuNhapXe()
        {
            InitializeComponent();
            load_data();
            load_nhomxe();
            load_ncc();
            load_tennhanvien();
            txt_maphieunhap.Enabled = false;
            txtTongtien.Enabled = false;

        }

        void load_data()
        {
            string query = "select  MaPN, HotenNV,NhomXe.MaNX,NgayNhapPN,ThanhTienPN,NhaCungCap.TenNCC ,DonGiaPN,SoLuongPN from PhieuNhapXe, NhanVien, NhomXe,NhaCungCap where PhieuNhapXe.MaNX=NhomXe.MaNX and PhieuNhapXe.MaNV= NhanVien.MaNV and NhaCungCap.MaNCC=PhieuNhapXe.MaNCC";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQury(query);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        void load_nhomxe()
        {
            string query = "select * from NhomXe";
            cbo_nhomxe.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_nhomxe.ValueMember = "MaNX";
        }
        void load_ncc()
        {
            string query = "select * from NhaCungCap";
            cboNhacungcapxe.DataSource = DataProvider.Instance.ExecuteQury(query);
            cboNhacungcapxe.DisplayMember = "TenNCC";
            cboNhacungcapxe.ValueMember = "MaNCC";
        }



        void load_tennhanvien()
        {
            string query = "select * from NhanVien";
            cbo_tennhanvien.DataSource = DataProvider.Instance.ExecuteQury(query);
            cbo_tennhanvien.DisplayMember = "HotenNV";
            cbo_tennhanvien.ValueMember = "MaNV";
        }



        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            txt_maphieunhap.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cbo_tennhanvien.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            cbo_nhomxe.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            datNgayLap.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtTongtien.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cboNhacungcapxe.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtDongia.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtSoluong.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            cbo_tennhanvien.Enabled = false;
            cbo_nhomxe.Enabled = false;
            datNgayLap.Enabled = false;
            txtTongtien.Enabled = false;
            cboNhacungcapxe.Enabled = false;
            txtDongia.Enabled = false;
            txtSoluong.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string query = "delete from PhieuNhapXe where MaPN=" + txt_maphieunhap.Text + "";
            int so = DataProvider.Instance.ExecuteNonQuery(query);
            if (so > 0)
                MessageBox.Show("Xóa thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            load_data();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            cbo_tennhanvien.Enabled = true;
            cbo_nhomxe.Enabled = true;
            datNgayLap.Enabled = true;

            cboNhacungcapxe.Enabled = true;
            txtDongia.Enabled = true;
            txtSoluong.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txt_maphieunhap.Clear();
            txtTongtien.Clear();
            txtDongia.Clear();
            txtSoluong.Clear();
            txtTongtien.Focus();
            cbo_tennhanvien.Enabled = true;
            cbo_nhomxe.Enabled = true;
            datNgayLap.Enabled = true;
            cboNhacungcapxe.Enabled = true;
            txtDongia.Enabled = true;
            txtSoluong.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        int tongtien(string txt1, string txt2)
        {
            return (int.Parse(txt1) * int.Parse(txt2));
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Parse(datNgayLap.Text);
                if (dt < DateTime.Now)
                    MessageBox.Show("Ngày tháng không hợp lệ!");
                else
                {
                    if (txt_maphieunhap.Text == "")
                    {
                        string query = "insert into PhieuNhapXe values(" + cbo_tennhanvien.SelectedValue.ToString() + "," + cboNhacungcapxe.SelectedValue.ToString() + ",'" + cbo_nhomxe.SelectedValue.ToString() + "'," + txtDongia.Text + "," + txtSoluong.Text + ",'" + DateTime.Parse(datNgayLap.Text) + "'," + tongtien(txtSoluong.Text, txtDongia.Text) + ")";

                        int so = DataProvider.Instance.ExecuteNonQuery(query);
                        if (so > 0)
                        {
                            MessageBox.Show("Thêm thành công!");

                        }
                        else
                            MessageBox.Show("Thêm thành công!");
                        load_data();

                    }
                    else
                    {
                        string query = "update PhieuNhapXe set MaNV=" + cbo_tennhanvien.SelectedValue.ToString() + ",MaNCC=" + cboNhacungcapxe.SelectedValue.ToString() + ",MaNX='" + cbo_nhomxe.SelectedValue.ToString() + "',DonGiaPN=" + txtDongia.Text + ",SoLuongPN=" + txtSoluong.Text + ",NgayNhapPN='" + DateTime.Parse(datNgayLap.Text) + "',ThanhTienPN=" + tongtien(txtSoluong.Text, txtDongia.Text) + " where MaPN =" + txt_maphieunhap.Text + " ";
                        int so = DataProvider.Instance.ExecuteNonQuery(query);
                        if (so > 0)
                        {
                            MessageBox.Show("Sửa thành công!");

                        }
                        else
                            MessageBox.Show("Sửa thành công!");
                        load_data();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
            }
        }
        
    }
}
