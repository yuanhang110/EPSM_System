using EPSM_System.DAL;
using System;
using EPSM_System.Model;
using System.Collections.Generic;


namespace EPSM_System.BLL
{
    public class UserBLL
    {
        private UserDataDAL dal = new UserDataDAL();

        public bool UpdateUser(UserData user)
        {
            return dal.UpdateUser(user) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddUser(UserData user)
        {
            return dal.AddUser(user) > 0;
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
        public List<UserData> GetAllUsers(int isDel)
        {
            return dal.GetAllUsers(isDel);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="eName">登录名</param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdatePwd(string eName, string oldPwd, string newPwd, out string msg)
        {
            bool result = false;
            UserData e = dal.GetUserByLoginName(eName, 1);
            if (e != null)
            {
                if (e.PassWord == oldPwd)
                {
                    //更新密码
                    result = dal.UpdatePwd(eName, newPwd) > 0;
                    if (result)
                    {
                        msg = "更新成功";
                    }
                    else
                    {
                        msg = "更新失败";
                    }
                }
                else
                {
                    msg = "旧密码错误";
                }
            }
            else
            {
                msg = "账号不存在";
            }
            return result;
        }


        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Login(string name, string pwd, int type, out UserData user)
        {
            bool result = false; //假设登录失败

            user = dal.GetUserByLoginName(name, type);
            if (user != null)
            {
                if (user.PassWord == pwd)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}

