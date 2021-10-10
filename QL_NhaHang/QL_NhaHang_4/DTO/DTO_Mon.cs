using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Mon
    {
        int idMon;
        int idDanhmuc;
        string tenMon;
        int donGia;
        int tinhTrang;

        public int IdMon
        {
            get
            {
                return idMon;
            }

            set
            {
                idMon = value;
            }
        }

        public int IdDanhmuc
        {
            get
            {
                return idDanhmuc;
            }

            set
            {
                idDanhmuc = value;
            }
        }

        public string TenMon
        {
            get
            {
                return tenMon;
            }

            set
            {
                tenMon = value;
            }
        }

        public int DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public int TinhTrang
        {
            get
            {
                return tinhTrang;
            }

            set
            {
                tinhTrang = value;
            }
        }
        public DTO_Mon(string tenMon)
        {

        }
        public DTO_Mon(DataRow row)
        {
            this.idMon = (int)(row["idMon"]);
            this.tenMon = row["tenMon"].ToString();
            this.donGia = (int)row["donGia"];
            this.tinhTrang = (int)(row["tinhTrangMon"]);
        }
    }
}
