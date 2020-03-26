using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSM_System.Model
{
    public class PayData
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int BasePay { get; set; }
        public int RealPay { get; set; }
        public int BonusInTotal { get; set; }
    }
}
