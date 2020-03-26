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
    public class BonusDataDAL
    {
        /// <summary>
        /// 添加奖励信息
        /// </summary>
        /// <param name="Bonus"></param>
        /// <returns></returns>
        public int AddBonusData(BonusData bonus)
        {
            //sql语句
            String sql = "INSERT INTO Table_BonusData(ID,Bonus,Fine,BonusInTotal,Name) VALUES(@ID,@Bonus,@Fine,@BonusInTotal,@Name)";
            //参数列表
            SqlParameter[] param = {
                                       new SqlParameter("@ID",SqlDbType.Int),
                                       new SqlParameter("@Bonus",SqlDbType.Int),
                                       new SqlParameter("@Fine",SqlDbType.Int),
                                       new SqlParameter("@BonusInTotal",SqlDbType.Int),
                                       new SqlParameter("@Name",SqlDbType.VarChar)
                                   };

            //参数赋值
            param[0].Value = bonus.ID;
            param[1].Value = bonus.Bonus;
            param[2].Value = bonus.Fine;
            param[3].Value = bonus.BonusInTotal;
            param[4].Value = bonus.Name;

            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }

        //TODO:


        public int UpdateBonus(BonusData bonus)
        {
            //1.sql语句
            string sql = "UPDATE Table_BonusData SET Bonus=@Bonus,Fine=@Fine,BonusInTotal=@BonusInTotal,Name=@Name WHERE ID=@ID";

            SqlParameter[] param = { new SqlParameter("@Bonus",SqlDbType.Int),
                                   new SqlParameter("@Fine",SqlDbType.Int),
                                   new SqlParameter("@BonusInTotal",SqlDbType.Int),
                                   new SqlParameter("@Name",SqlDbType.VarChar),
                                   new SqlParameter("@ID", SqlDbType.Int)};

            param[0].Value = bonus.Bonus;
            param[1].Value = bonus.Fine;
            param[2].Value = bonus.Bonus- bonus.Fine;//更新后自动加出来的总奖金不能传值
            param[3].Value = bonus.Name;
            param[4].Value = bonus.ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }


        public List<BonusData> GetAllBonusData(int isDel)                           //做到这里了
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_BonusData";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<BonusData> Bonus = new List<BonusData>();

            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                BonusData bonus = DataRowToBonus(dr);
                Bonus.Add(bonus);
            }
            return Bonus;
        }

        public DataTable GetAllBonusData()
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_BonusData";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);

            return dt;
        }

        private BonusData DataRowToBonus(DataRow dr)
        {        
            BonusData bonus = new BonusData();
            if (!(DBNull.Value.Equals(bonus.ID) && DBNull.Value.Equals(bonus.Bonus) 
                && DBNull.Value.Equals(bonus.Fine) && DBNull.Value.Equals(bonus.BonusInTotal)))
            {
                bonus.ID = Convert.ToInt32(dr["ID"]);
                bonus.Bonus = Convert.ToInt32(dr["Bonus"]);
                bonus.Fine = Convert.ToInt32(dr["Fine"]);
                bonus.BonusInTotal = Convert.ToInt32(dr["BonusInTotal"]);
                bonus.Name = Convert.ToString(dr["Name"]);
            }
            return bonus;
        }

        /// <summary>
        /// 更新工资
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        


        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public int SoftDelete(int ID)
        {
            string sql = "DELETE FROM Table_BonusData WHERE ID =" + ID;
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
            string sql = "DELETE FROM Table_BonusData WHERE ID =" + ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql);
        }
    }
}
