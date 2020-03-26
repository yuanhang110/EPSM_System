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

namespace EPSM_System.pages.pay
{
    /// <summary>
    /// EditPayPage.xaml 的交互逻辑
    /// </summary>
    public partial class EditPayPage : Window
    {
        int RealPay;
        private PayDataBLL bll = new PayDataBLL();
        //编辑或者增加
        public bool isAdd { get; set; }
        public EditPayPage()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (isAdd)
            {
                this.Title = "添加员工";
                this.btnOk.Content = "添加";
                PayData user = new PayData();
                gridUser.DataContext = user;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            PayData user = (PayData)gridUser.DataContext;
            if (isAdd)
            {
                if (bll.AddPay(user))
                    MessageBox.Show("添加成功！");
            }
            else
            {
                if (bll.UpdatePay(user))
                    MessageBox.Show("修改成功！");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void txtRealPay_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtRealPay.Text = Convert.ToString(Convert.ToInt32(txtRealPay.Text) + (Convert.ToInt32(txtBonusInTotal.Text)));
            RealPay = Convert.ToInt32(txtRealPay.Text);
        }
        public int getBonusInTotalvalue(int RealPay)
        {
            return RealPay;
        }
    }
}

