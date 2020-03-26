using EPSM_System.DAL;
using System;
using EPSM_System.Model;
using System.Collections.Generic;

namespace EPSM_System.BLL
{
    public class RecordBLL
    {
        private RecordDataDAL dal = new RecordDataDAL();

        public bool UpdateRecord(RecordData record)
        {
            return dal.UpdateRecord(record) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddRecord(RecordData record)
        {
            return dal.AddRecord(record) > 0;
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
        public List<RecordData> GetAllUsers(int isDel)
        {

            return dal.GetAllRecordData(isDel);
        }
    }
}
