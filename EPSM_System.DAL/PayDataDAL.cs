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
    public class PayDataDAL
    {


        public DataTable GetTheBonusData()
        {
            //1 sql语句
            string sql = "SELECT BonusInTotal FROM Table_BonusData WHERE ID=@ID";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);

            return dt;
        }
        /// <summary>
        /// 添加工资信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddPay(PayData pay)
        {
            //sql语句
            String sql = "INSERT INTO Table_PayData(ID,Name,BasePay,RealPay,BonusInTotal) VALUES(@ID,@Name,@BasePay,@RealPay,@BonusInTotal)";
            //参数列表
            SqlParameter[] param = {
                                       new SqlParameter("@ID",SqlDbType.Int),
                                       new SqlParameter("@Name",SqlDbType.VarChar),
                                       new SqlParameter("@BasePay",SqlDbType.Int),
                                       new SqlParameter("@RealPay",SqlDbType.Int),
                                       new SqlParameter("@BonusInTotal",SqlDbType.Int)
                                   };

            //参数赋值
            param[0].Value = pay.ID;
            param[1].Value = pay.Name;
            param[2].Value = pay.BasePay;
            param[3].Value = pay.BasePay + pay.BonusInTotal;
            param[4].Value = pay.BonusInTotal;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }

        //TODO:


        public int UpdatePay(PayData pay)
        {
            //1.sql语句
            string sql = "UPDATE Table_PayData SET Name=@Name,BasePay=@BasePay,RealPay=@RealPay,BonusInTotal=@BonusInTotal WHERE ID=@ID";

            SqlParameter[] param = { new SqlParameter("@Name",SqlDbType.VarChar),
                                   new SqlParameter("@BasePay",SqlDbType.Int),
                                   new SqlParameter("@RealPay",SqlDbType.Int),
                                   new SqlParameter("@BonusInTotal",SqlDbType.Int),
                                   new SqlParameter("@ID", SqlDbType.Int)

                                   };

            param[0].Value = pay.Name;
            param[1].Value = pay.BasePay;
            param[2].Value = pay.BasePay + pay.BonusInTotal;
            param[3].Value = pay.BonusInTotal;
            param[4].Value = pay.ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }


        public List<PayData> GetAllPayData(int isDel)
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_PayData ";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<PayData> pays = new List<PayData>();

            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                PayData pay = DataRowToPay(dr);
                pays.Add(pay);
            }
            return pays;
        }

        public DataTable GetAllPayData()
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_PayData";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);

            return dt;
        }

        private PayData DataRowToPay(DataRow dr)
        {
            PayData pay = new PayData();
            
                pay.ID = Convert.ToInt32(dr["ID"]);
                pay.Name = Convert.ToString(dr["Name"]);
            if (!DBNull.Value.Equals(pay.BasePay))          
                pay.BasePay = Convert.ToInt32(dr["BasePay"]);
                pay.RealPay = Convert.ToInt32(dr["RealPay"]);
            
                
            return pay;
        }

        /// <summary>
        /// 更新工资
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int UpdatePwd(int ID, string newPay)
        {
            //1 sql语句
            string sql = "UPDATE Table_PayData SET RealPay=@RealPay WHERE ID=@ID";
            SqlParameter[] param = {
                                    new SqlParameter("@ID",SqlDbType.VarChar),
                                     new SqlParameter("@RealPay",SqlDbType.VarChar)
                                   };
            param[0].Value = ID;
            param[1].Value = newPay;
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);

        }


        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public int SoftDelete(int ID)
        {
            string sql = "DELETE FROM Table_PayData WHERE ID =" + ID;
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
            string sql = "DELETE FROM Table_PayData WHERE ID =" + ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql);
        }
    }
}