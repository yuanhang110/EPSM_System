using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSM_System.Model
{
    public class AttendanceData
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime AttendanceDate { get; set; }     
        public string Type { get; set; }
        public string Remark { get; set; }
    }
}
