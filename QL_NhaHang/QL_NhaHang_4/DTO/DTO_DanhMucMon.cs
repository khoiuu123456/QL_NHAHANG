using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DanhMucMon
    {
        int idDanhmuc;
        string tenDanhmuc;

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

        public string TenDanhmuc
        {
            get
            {
                return tenDanhmuc;
            }

            set
            {
                tenDanhmuc = value;
            }
        }
        public DTO_DanhMucMon(int id, string tenDm)
        {
            this.tenDanhmuc = tenDm;
            this.idDanhmuc = id;
        }
    }
}
