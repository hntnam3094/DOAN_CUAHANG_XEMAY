using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CuaHangXeMay.Modul
{
    public class Taikhoan
    {
        public string tendangnhap { get; set; }
        public string matkhau { get; set; }
        public int phanquyen { get; set; }

        public Taikhoan(string tendn, string mk, int phanquyen)
        {
            this.tendangnhap = tendn;
            this.matkhau = mk;
            this.phanquyen = phanquyen;
        }

        public Taikhoan(DataRow row)
        {
            this.tendangnhap = row["UserName"].ToString();
            this.matkhau = row["Password"].ToString();
            this.phanquyen = (int)row["PhanQuyen"];
        }

    }
}
