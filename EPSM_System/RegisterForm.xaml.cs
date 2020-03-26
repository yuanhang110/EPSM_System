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
using EPSM_System.BLL;
using EPSM_System.Model;

namespace EPSM_System
{
    /// <summary>
    /// RegisterForm.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterForm : Window
    {
        private UserBLL bll = new UserBLL();
        public bool IsAdd { get; set; }
        public RegisterForm()
        {
            InitializeComponent();
            txtID.Focus();
            this.cbType.ItemsSource = Common.UserTypes;
            //this.cbType.SelectedIndex = 0;
        }

        private void TxtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPassWord.Focus();
            }
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsAdd)
            {
                this.Title = "用户注册";
                this.btnOk.Content = "注册";
                UserData user = new UserData
                {
                    ////user.ID = Convert.ToInt32(this.txtID.Text);
                    //user.Name = this.txtName.Text;
                    IsDel = false
                };
                //user.PassWord = this.pwdUserPassword.Password;
                //user.UserRight = Convert.ToInt32(cbType.SelectedValuePath);
                gridUser.DataContext = user;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            UserData user = (UserData)gridUser.DataContext;
            if (IsAdd)
            {
                if (bll.AddUser(user))
                    MessageBox.Show("添加成功！");


            }
            this.Close();
        }


        private void PwdUserPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO:完成回车处理
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
