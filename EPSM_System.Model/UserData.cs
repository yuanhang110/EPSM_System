using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSM_System.Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserData
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public String PassWord { get; set; }

        public int UserRight { get; set; }
       
        public bool IsDel { get; set; }
    }
}
