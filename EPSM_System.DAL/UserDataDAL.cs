using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPSM_System.Model;

namespace EPSM_System.DAL
{
    public class UserDataDAL
    {
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public int AddUser(UserData user)
        {
            //sql语句
            String sql = "INSERT INTO Table_UserData(ID,Name,PassWord,UserRight,IsDel) VALUES(@ID,@Name,@PassWord,@UserRight,@IsDel)";
            //参数列表
            SqlParameter[] param = {
                                       new SqlParameter("@ID",SqlDbType.Int),
                                       new SqlParameter("@Name",SqlDbType.VarChar),
                                       new SqlParameter("@PassWord",SqlDbType.VarChar),
                                       new SqlParameter("@UserRight",SqlDbType.Int),
                                       new SqlParameter("@IsDel",SqlDbType.Bit)

                                   };

            //参数赋值
            param[0].Value = user.ID;
            param[1].Value = user.Name;
            param[2].Value = user.PassWord;
            param[3].Value = user.UserRight;
            param[4].Value = user.IsDel;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);
        }

        public int UpdateUser(UserData user)
        {
            //1.sql语句
            string sql = "UPDATE Table_UserData SET Name=@Name,PassWord=@PassWord,UserRight=@UserRight WHERE ID=@ID";

            SqlParameter[] param = { new SqlParameter("@Name",SqlDbType.VarChar),
                                   new SqlParameter("@PassWord",SqlDbType.VarChar),
                                   new SqlParameter("@UserRight",SqlDbType.Int),
                                   new SqlParameter("@ID",SqlDbType.VarChar),
                                   new SqlParameter("@IsDel", SqlDbType.Int)};
            new SqlParameter("@IsDel", SqlDbType.Int);
            param[0].Value = user.Name;
            param[1].Value = user.PassWord;
            param[2].Value = user.UserRight;
            param[3].Value = user.ID;
            param[4].Value = user.IsDel;
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
            string sql = "UPDATE Table_UserData SET IsDel=1 WHERE ID =" + ID;
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
            string sql = "DELETE FROM Table_UserData WHERE ID =" + ID;
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">2,3,4,5</param>
        /// <returns></returns>
        public int Deletes(string IDS)
        {
            //string sql = "DELETE FROM Table_UserData WHERE ID in (" + IDS + ")";
            string sql = "UPDATE Table_UserData SET isDel=1 WHERE ID in (" + IDS + ")";
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 查询所有员工
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>

        public List<UserData> GetAllUsers(int isDel)
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_UserData WHERE IsDel=" + isDel;
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<UserData> Table_UserData = new List<UserData>();

            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                UserData user = DataRowToUser(dr);
                Table_UserData.Add(user);
            }
            return Table_UserData;
        }

        public DataTable GetAllUsers()
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_UserData WHERE IsDel=0";
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);

            return dt;
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string Name, string newPwd)
        {
            //1 sql语句
            string sql = "UPDATE Table_UserData SET Password=@pwd WHERE Name=@name";
            SqlParameter[] param = {
                                    new SqlParameter("@Name",SqlDbType.VarChar),
                                     new SqlParameter("@PassWord",SqlDbType.VarChar)
                                   };
            param[0].Value = Name;
            param[1].Value = newPwd;
            //2 执行
            SqlDbHelper db = new SqlDbHelper();
            return db.ExecuteNonQuery(sql, param);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="UserRight"></param>
        /// <returns></returns>
        public UserData GetUserByLoginName(string Name, int UserRight)
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_UserData WHERE name=@name AND UserRight=@UserRight AND isdel=0";
            SqlParameter[] param = {
                                        new SqlParameter("@name",SqlDbType.VarChar),
                                        new SqlParameter("@UserRight",SqlDbType.Int)
                                   };
            param[0].Value = Name;
            param[1].Value = UserRight;
            //2 执行sql语句
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql, param);
            //3 关系--》对象     orm --》 ef  nhibernate
            UserData user = null;
            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                user = DataRowToUser(dr);
            }
            return user;
        }

        public UserData GetUserById(int id)
        {
            //1 sql语句
            string sql = "SELECT * FROM Table_UserData WHERE id=@Id";
            SqlParameter[] param = {
                                        new SqlParameter("@Id",SqlDbType.Int)
                                   };
            param[0].Value = id;
            //2 执行sql语句
            SqlDbHelper db = new SqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql, param);
            //3 关系--》对象     orm --》 ef  nhibernate
            UserData user = null;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                user = DataRowToUser(dr);
            }
            return user;
        }
        /// <summary>
        /// 把行转化成对象
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="type">table 表   view视图</param>
        /// <returns></returns>
        private UserData DataRowToUser(DataRow dr)
        {
            UserData user = new UserData();
            if (!(DBNull.Value.Equals(user.ID) && DBNull.Value.Equals(user.Name)
               && DBNull.Value.Equals(user.PassWord) && DBNull.Value.Equals(user.UserRight)))
            {
                user.ID = Convert.ToInt32(dr["ID"]);
                user.Name = Convert.ToString(dr["Name"]);
                user.PassWord = Convert.ToString(dr["PassWord"]);
                user.UserRight = Convert.ToInt32(dr["UserRight"]);
            }
            return user;
        }
    }
}
