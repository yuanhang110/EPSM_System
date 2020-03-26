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
using EPSM_System.Model;
using EPSM_System.BLL;

namespace EPSM_System.pages.attendance
{
    /// <summary>
    /// EditAttendancePage.xaml 的交互逻辑
    /// </summary>
    public partial class EditAttendancePage : Window
    {
        private AttendanceBLL bll = new AttendanceBLL();
        //编辑或者增加
        public bool isAdd { get; set; }
        public EditAttendancePage()
        {
            InitializeComponent();
            this.cbType.ItemsSource = Common.AttendanceTypes;
            this.cbType.Text = "选择缺勤类型";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (isAdd)
            {
                this.Title = "添加员工";
                this.btnOk.Content = "添加";
                AttendanceData user = new AttendanceData();
                user.AttendanceDate = DateTime.Now;
                gridUser.DataContext = user;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            AttendanceData user = (AttendanceData)gridUser.DataContext;
            if (isAdd)
            {
                if (bll.AddAttendance(user))
                    MessageBox.Show("添加成功！");
            }
            else
            {
                if (bll.UpdateAttendance(user))
                    MessageBox.Show("修改成功！");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
