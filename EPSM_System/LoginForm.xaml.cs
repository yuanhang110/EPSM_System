using EPSM_System.BLL;
using EPSM_System.Model;
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
    /// LoginForm.xaml 的交互逻辑
    /// </summary>
    public partial class LoginForm : Window
    {    
        private UserBLL bll = new UserBLL();
        public LoginForm()
        {
            InitializeComponent();
            txtUserName.Focus();
            this.cbType.ItemsSource = Common.UserTypes;
            this.cbType.SelectedIndex = 0;
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                pwdUserPassword.Focus();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //接收用户输入数据
            string userName = txtUserName.Text.Trim();
            string userPassword = pwdUserPassword.Password;
            int type = (int)this.cbType.SelectedValue;

            UserData user = null;
            bool flag = false;

            if (userName == string.Empty || userPassword == string.Empty)
            {
                MessageBox.Show("用户名或密码不能为空！", "登录错误！", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                flag = bll.Login(userName, userPassword, type, out user);
                if (flag)
                {
                    //不把密码保存在内存中
                    user.PassWord = null;
                    //登录成功记录登录者的信息
                    Common.LoginUser = user;
                    //登录成功
                    //MessageBox.Show("登录成功!");
                    new MainForm().Show();
                    this.Close();
                }
                else //登录失败
                {
                    MessageBox.Show("用户名或密码错误！", "登录错误！", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.IsAdd = true;
            register.ShowDialog();
        }

        private void pwdUserPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO:完成回车处理
        }

        private void txtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
