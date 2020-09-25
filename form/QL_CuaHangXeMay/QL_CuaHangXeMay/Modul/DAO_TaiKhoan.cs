using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_CuaHangXeMay.Modul
{
    public class DAO_TaiKhoan
    {
        private static DAO_TaiKhoan instance;

        public static DAO_TaiKhoan Instance
        {
            get { if (instance == null) instance = new DAO_TaiKhoan(); return DAO_TaiKhoan.instance; }
            private set { DAO_TaiKhoan.instance = value; }
        }

        public Taikhoan getListTaiKhoan(string taikhoan, string matkhau)
        {
                DataTable dt = DataProvider.Instance.ExecuteQury("select * from DangNhap where UserName='" + taikhoan + "' and Password='" + matkhau + "' ");
                Taikhoan tk = new Taikhoan(dt.Rows[0]);
                return tk;
            
        }
    }
}
