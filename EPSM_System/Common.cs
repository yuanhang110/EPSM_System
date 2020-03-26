using EPSM_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSM_System
{
    class Common
    {
        private static List<Type> userTypes = new List<Type>();
        private static List<Type> sexTypes = new List<Type>();
        private static List<Type> attendanceTypes = new List<Type>();
        static Common()
        {
            userTypes.Add(new Type() { No = 1, Name = "普通员工" });
            userTypes.Add(new Type() { No = 2, Name = "经理" });
            userTypes.Add(new Type() { No = 3, Name = "超级用户" });
            sexTypes.Add(new Type() { sex = "男", sexname = "男" });
            sexTypes.Add(new Type() { sex = "女", sexname = "女" });
            attendanceTypes.Add(new Type() { attendance = "迟到", attendancename = "迟到" });
            attendanceTypes.Add(new Type() { attendance = "早退", attendancename = "早退" });
            attendanceTypes.Add(new Type() { attendance = "缺勤", attendancename = "缺勤" });
            attendanceTypes.Add(new Type() { attendance = "请假", attendancename = "请假" });
            attendanceTypes.Add(new Type() { attendance = "外出", attendancename = "外出" });
        }
        public static List<Type> UserTypes
        {
            get
            {
                return userTypes;
            }
        }
        public static List<Type> SexTypes
        {
            get
            {
                return sexTypes;
            }
        }
        public static List<Type> AttendanceTypes
        {
            get
            {
                return attendanceTypes;
            }
        }
        public static UserData LoginUser { get; set; }
    }
    public class Type
    {
        public int No { get; set; }

        public string Name { get; set; }

        public string sex { get; set; }

        public string sexname { get; set; }

        public string attendance { get; set; }

        public string attendancename { get; set; }

    }
}
