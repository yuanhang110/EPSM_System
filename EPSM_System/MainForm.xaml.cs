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
using System.Windows.Shapes;

namespace EPSM_System
{
    /// <summary>
    /// MainForm.xaml 的交互逻辑
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            if (Common.LoginUser.UserRight == 1)
            {
                this.mainMenu.Items.Remove(this.MenuRecord);
                this.mainMenu.Items.Remove(this.MenuBonus);
            }
            if (Common.LoginUser.UserRight == 2)
            {
                this.mainMenu.Items.Remove(this.MenuRecord);
            }
        }
        private void MenuRecord_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Source = new Uri("pages/record/RecordPage.xaml", UriKind.Relative);
        }
        private void MenuBonus_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Source = new Uri("pages/bonus/BonusPage.xaml", UriKind.Relative);
        }
        private void MenuAttendance_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Source = new Uri("pages/attendance/AttendancePage.xaml", UriKind.Relative);
        }
        private void MenuPay_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Source = new Uri("pages/pay/PayPage.xaml", UriKind.Relative);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {          
           tbLoginName.Text = "欢迎您，" + Common.LoginUser.Name;          
        }

        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            this.frame1.Source = new Uri("pages/welcome/WelcomePage.xaml", UriKind.Relative);

        }

        private void MenuReport_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Source = new Uri("pages/report/ReportPage.xaml", UriKind.Relative);
        }
    }
}
