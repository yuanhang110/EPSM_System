using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EPSM_System.BLL;
using EPSM_System.Model;

namespace EPSM_System.pages.pay
{
    /// <summary>
    /// PayPage.xaml 的交互逻辑
    /// </summary>
    public partial class PayPage : Page
    {
        private PayDataBLL bll = new PayDataBLL();
        public PayPage()
        {
            InitializeComponent();
            LoadData();
        }
        // 添加信息
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //  DispatcherTimer timer = new DispatcherTimer();
            EditPayPage editUser = new EditPayPage();
            editUser.isAdd = true;
            editUser.ShowDialog();
            //加载数据
            LoadData();


        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            this.dgUsers.ItemsSource = bll.GetAllUsers(0);
        }


        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //获取鼠标选择的索引
            int num = dgUsers.SelectedIndex;
            if (num < 0)
            {
                MessageBox.Show("请选择要修改的行!");
            }
            else
            {
                //获取选中行
                PayData user = (PayData)dgUsers.SelectedValue;
                //打开编辑窗口
                EditPayPage editRecord = new EditPayPage();
                editRecord.isAdd = false;
                //设置编号不能编辑
                editRecord.txtID.IsReadOnly = true;
                //绑定数据
                editRecord.gridUser.DataContext = user;

                //显示窗口
                editRecord.ShowDialog();
                LoadData();
            }
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //获取鼠标选择的索引
            int num = dgUsers.SelectedIndex;
            if (num < 0)
            {
                MessageBox.Show("请选择要删除的行!");
            }
            else
            {
                //获取选中行
                PayData user = (PayData)dgUsers.SelectedValue;
                if (MessageBox.Show("是否删除" + user.Name + "的信息", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //删除数据
                    if (bll.Delete(user.ID, 0))
                        MessageBox.Show("删除" + user.Name.Trim() + "成功");
                }
                //加载数据
                LoadData();
            }
        }      
    }
}