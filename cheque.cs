using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFDF3TailControlGUI
{
    public class Cheque
    {
        public DateTime cheque_date { get; set; }
        public decimal summ_cheque { get; set; }
        public string kassa { get; set; }
        public string fp { get; set; }
        public int cheque_number { get; set; }
        public string hash { get; set; }
    }

}
