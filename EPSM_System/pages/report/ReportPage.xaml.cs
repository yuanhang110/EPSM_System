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
using EPSM_System.pages.attendance;

namespace EPSM_System.pages.report
{
    /// <summary>
    /// ReportPage.xaml 的交互逻辑
    /// </summary>
    public partial class ReportPage : Page
    {
        private AttendanceBLL bll = new AttendanceBLL();
        public ReportPage()
        {
            InitializeComponent();
            dpStartDate.SelectedDate = DateTime.Now;
            dpEndDate.SelectedDate = DateTime.Now;
            LoadData();
        }
        private void LoadData()
        {
            this.dgUsers.ItemsSource = bll.GetAllUsers(0);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditAttendancePage editUser = new EditAttendancePage();
            editUser.isAdd = true;
            editUser.ShowDialog();
            //加载数据
            LoadData();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
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
                AttendanceData user = (AttendanceData)dgUsers.SelectedValue;
                //打开编辑窗口
                EditAttendancePage editAttendance = new EditAttendancePage();
                editAttendance.isAdd = false;
                //设置编号不能编辑
                editAttendance.txtID.IsReadOnly = true;
                //绑定数据
                editAttendance.gridUser.DataContext = user;

                //显示窗口
                editAttendance.ShowDialog();

            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
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
                AttendanceData user = (AttendanceData)dgUsers.SelectedValue;
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

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            DateTime? StartDate = dpStartDate.DisplayDate;
            DateTime? EndDate = dpEndDate.DisplayDate;
            dgUsers.ItemsSource = (bll.GetPartialUsers(StartDate, EndDate));

        }
    }
}

