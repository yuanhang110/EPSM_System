using EPSM_System.DAL;
using System;
using EPSM_System.Model;
using System.Collections.Generic;

namespace EPSM_System.BLL
{
    public class ReportBLL
    {

        private AttendanceDataDAL dal = new AttendanceDataDAL();

        public bool UpdateAttendance(AttendanceData record)
        {
            return dal.UpdateAttendance(record) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddAttendance(AttendanceData record)
        {
            return dal.AddAttendanceData(record) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid">id</param>
        /// <param name="flag">1 真删除  0 软删除</param>
        /// <returns></returns>
        public bool Delete(int id, int flag)
        {
            bool result = false;
            if (flag == 1)
            {
                result = dal.RealDelete(id) > 0;
            }
            else if (flag == 0)
            {
                result = dal.SoftDelete(id) > 0;
            }
            return result;
        }

        /// <summary>
        /// 查询所有员工
        /// </summary>
        /// <param name="isDel">0 未删除的员工  1 删除的员工</param>
        /// <returns></returns>
        public List<AttendanceData> GetPartialAttendanceData(DateTime StartDate, DateTime EndDate)
        {

            return dal.GetPartialAttendanceData(StartDate, EndDate);
        }

    }
}
