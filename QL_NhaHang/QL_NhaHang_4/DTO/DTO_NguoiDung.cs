using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NguoiDung
    {
        int idNguoidung;
        string tenDangNhap;
        string matKhau;
        string tenHienThi;
        int idKieuNguoiDung;

        public string TenDangNhap
        {
            get
            {
                return tenDangNhap;
            }

            set
            {
                tenDangNhap = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        public string TenHienThi
        {
            get
            {
                return tenHienThi;
            }

            set
            {
                tenHienThi = value;
            }
        }

        public int IdKieuNguoiDung
        {
            get
            {
                return idKieuNguoiDung;
            }

            set
            {
                idKieuNguoiDung = value;
            }
        }

        public int IdNguoidung
        {

            get { return idNguoidung; }
            set { idNguoidung = value; }

        }

        public DTO_NguoiDung()
        { }
        public DTO_NguoiDung(DataRow row)
        {
            this.idNguoidung = (int)row["idNguoidung"];
            this.idKieuNguoiDung = (int)row["idKieunguoidung"];
            this.tenHienThi = row["tenHienthi"].ToString();
            this.tenDangNhap = row["tenDangnhap"].ToString();
        }
    }
}
