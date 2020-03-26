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
    public class RecordDataDAL
    {
        /// <summary>
        /// 添加档案
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddRecord(RecordData record)
        {
            //sql语句
            String sql = "INSERT INTO Table_RecordData(ID,Name,Position,Age,Sex) VALUES(@ID,@Name,@Position,@Age,@Sex)";
            //参数列表
            SqlParameter[] param = {
                                       new SqlParameter("@ID",SqlDbType.Int),
                                       new SqlParameter("@Name",SqlDbType.VarChar),
                                       new SqlParameter("@Position",SqlDbType.VarChar),
                                       new SqlParameter("@Age",SqlDbType.VarChar),
                                       new SqlParameter("@Sex",SqlDbType.VarChar)
                                   };
            //参数赋值
            param[0].Value = record.ID;
            param[1].Value = record.Name;
            param[2].Value = record.Position;
            param[3].Value = record.Age;
            param[4].Value = record.Sex;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }

        //TODO:



        public int UpdateRecord(RecordData record)
        {
            //1.sql语句
            string sql = "UPDATE Table_RecordData SET Name=@Name,Position=@Position,Age=@Age,Sex=@Sex WHERE ID=@ID";

            SqlParameter[] param = { new SqlParameter("@Name",SqlDbType.VarChar),
                                   new SqlParameter("@Position",SqlDbType.VarChar),
                                   new SqlParameter("@Age",SqlDbType.VarChar),
                                   new SqlParameter("@Sex",SqlDbType.VarChar),
                                   new SqlParameter("@ID", SqlDbType.Int)};

            param[0].Value = record.Name;
            param[1].Value = record.Position;
            param[2].Value = record.Age;
            param[3].Value = record.Sex;
            param[4].Value = record.ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }

        public List<RecordData> GetAllRecordData(int isDel)
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_RecordData";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<RecordData> records = new List<RecordData>();

            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                RecordData record = DataRowToRecord(dr);
                records.Add(record);
            }
            return records;
        }

        public DataTable GetAllRecordData()
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_RecordData";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            return dt;
        }



        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public int SoftDelete(int ID)
        {
            string sql = "DELETE FROM Table_RecordData WHERE ID =" + ID;
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
            string sql = "DELETE FROM Table_RecordData WHERE ID =" + ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql);
        }

        private RecordData DataRowToRecord(DataRow dr)
        {
            RecordData record = new RecordData();
            if (!(DBNull.Value.Equals(record.ID) && DBNull.Value.Equals(record.Name)
               && DBNull.Value.Equals(record.Position) && DBNull.Value.Equals(record.Age) 
               && DBNull.Value.Equals(record.Sex)))
            {
                record.ID = Convert.ToInt32(dr["ID"]);
                record.Name = Convert.ToString(dr["Name"]);
                record.Position = Convert.ToString(dr["Position"]);
                record.Age = Convert.ToString(dr["Age"]);
                record.Sex = Convert.ToString(dr["Sex"]);
            }
            return record;
        }
    }
}
