using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ban
    {
        int idBan;
        string tenBan;
        int tinhTrang;

        public int IdBan
        {
            get
            {
                return idBan;
            }

            set
            {
                idBan = value;
            }
        }

        public string TenBan
        {
            get
            {
                return tenBan;
            }

            set
            {
                tenBan = value;
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
        public DTO_Ban(string tenBan, int tinhTrang)
        {
            this.tenBan = tenBan;
            this.tinhTrang = tinhTrang;
        }
        public DTO_Ban() { }
        public DTO_Ban(DataRow row)
        {
            this.idBan = (int)row["idBan"];
            this.tenBan = row["tenBan"].ToString();
            this.tinhTrang = (int)row["tinhTrang"];
        }
    }
}
