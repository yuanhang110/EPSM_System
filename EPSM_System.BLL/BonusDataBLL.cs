using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPSM_System.Model;
using EPSM_System.DAL;

namespace EPSM_System.BLL
{
    public class BonusDataBLL
    {
        private BonusDataDAL dal = new BonusDataDAL();

        public bool UpdateBonus(BonusData bonus)
        {
            return dal.UpdateBonus(bonus) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool AddBonusData(BonusData bonus)
        {
            return dal.AddBonusData(bonus) > 0;
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
        public List<BonusData> GetAllUsers(int isDel)
        {

            return dal.GetAllBonusData(isDel);
        }
    }
}
