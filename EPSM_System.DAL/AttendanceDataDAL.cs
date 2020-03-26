using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPSM_System.Model;
using System.Data.SqlClient;
using System.Data;

namespace EPSM_System.DAL
{
    public class AttendanceDataDAL
    {
        /// <summary>
        /// 添加考勤信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddAttendanceData(AttendanceData attendance)
        {
            //sql语句
            String sql = "INSERT INTO Table_AttendanceData(ID,Name,AttendanceDate,Type,Remark) VALUES(@ID,@Name,@AttendanceDate,@Type,@Remark)";
            //参数列表
            SqlParameter[] param = {
                                       new SqlParameter("@ID",SqlDbType.Int),
                                       new SqlParameter("@Name",SqlDbType.VarChar),
                                       new SqlParameter("@AttendanceDate",SqlDbType.DateTime),
                                       new SqlParameter("@Type",SqlDbType.VarChar),
                                       new SqlParameter("@Remark",SqlDbType.VarChar)
                                   };
            //参数赋值
            param[0].Value = attendance.ID;
            param[1].Value = attendance.Name;
            param[2].Value = attendance.AttendanceDate;
            param[3].Value = attendance.Type;
            param[4].Value = attendance.Remark;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }
        public int UpdateAttendance(AttendanceData record)
        {
            //1 sql语句
            string sql = "UPDATE Table_AttendanceData SET AttendanceDate=@AttendanceDate,Name=@Name," +
                "Type=@Type,Remark=@Remark WHERE ID=@ID";
            SqlParameter[] param = {
                                       new SqlParameter("@ID",SqlDbType.Int),
                                       new SqlParameter("@Name",SqlDbType.VarChar),
                                       new SqlParameter("@AttendanceDate",SqlDbType.DateTime),
                                       new SqlParameter("@Type",SqlDbType.VarChar),
                                       new SqlParameter("@Remark",SqlDbType.VarChar)
                                   };
            //参数赋值
            param[0].Value = record.ID;
            param[1].Value = record.Name;
            param[2].Value = record.AttendanceDate;
            param[3].Value = record.Type;
            param[4].Value = record.Remark;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 显示考勤
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
       
        public List<AttendanceData> GetPartialAttendanceData(DateTime? StartDate, DateTime? EndDate)//,DateTime startTime,DateTime endTime)
        {         
            //1 sql语句
            string sql = "SELECT * FROM Table_AttendanceData WHERE AttendanceDate BETWEEN @startTime AND  @endTime ";
            SqlParameter[] param = {
                                       new SqlParameter("@startTime",SqlDbType.Date),
                                       new SqlParameter("@endTime",SqlDbType.Date)
                                       };
            param[0].Value = StartDate;
            param[1].Value = EndDate;
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<AttendanceData> attendances = new List<AttendanceData>();

            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                AttendanceData attendance = DataRowToAttendance(dr);
                attendances.Add(attendance);
            }
            return attendances;
        }


        public List<AttendanceData> GetAllAttendanceData(int isDel)
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_AttendanceData ";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<AttendanceData> attendances = new List<AttendanceData>();

            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                AttendanceData attendance = DataRowToAttendance(dr);
                attendances.Add(attendance);
            }
            return attendances;
        }

        public DataTable GetAllAttendanceData()
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_AttendanceData";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);

            return dt;
        }
        public int SoftDelete(int ID)
        {
            string sql = "DELETE FROM Table_AttendanceData WHERE ID =" + ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 硬删除
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public int RealDelete(int ID)
        {
            string sql = "DELETE FROM Table_AttendanceData  WHERE ID =" + ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql);
        }
        private AttendanceData DataRowToAttendance(DataRow dr)
        {
            AttendanceData attendance = new AttendanceData();
            attendance.ID = Convert.ToInt32(dr["ID"]);
            attendance.Name = Convert.ToString(dr["Name"]);
            attendance.AttendanceDate = Convert.ToDateTime(dr["AttendanceDate"]);
            attendance.Type = Convert.ToString(dr["Type"]);
            attendance.Remark = Convert.ToString(dr["Remark"]);           
            return attendance;
        }
        /// <summary>
        /// 更新考勤
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newattendance"></param>
        /// <returns></returns>
        
    }
}
