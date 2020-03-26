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

namespace EPSM_System.pages.bonus
{
    /// <summary>
    /// EditBonusPage.xaml 的交互逻辑
    /// </summary>

    /// <summary>
    /// EditBonusPage.xaml 的交互逻辑
    /// </summary>
    public partial class EditBonusPage : Window
    {       
        private BonusDataBLL bll = new BonusDataBLL();
        //编辑或者增加
        public bool isAdd { get; set; }

        public EditBonusPage()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (isAdd)
            {
                this.Title = "添加将奖罚信息";
                this.btnOk.Content = "添加";
                BonusData user = new BonusData();
                UserData u = new UserData();
                gridUser.DataContext = user;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            BonusData user = (BonusData)gridUser.DataContext;
            if (isAdd)
            {
                if (bll.AddBonusData(user))
                    MessageBox.Show("添加成功！");
            }
            else
            {
                if (bll.UpdateBonus(user))
                    MessageBox.Show("修改成功！");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        public int getBonusInTotalvalue(int BonusInTotal)
        {
            return BonusInTotal;
        }
       
        private void txtBonus_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBonus.Text != String.Empty && txtFine.Text != String.Empty)
            {
                int total = Convert.ToInt32(txtBonus.Text) - Convert.ToInt32(txtFine.Text);
                txtBonusInTotal.Text = total.ToString();

            }         
        }

        private void txtFine_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBonus.Text != String.Empty && txtFine.Text != String.Empty)
            {
                int total = Convert.ToInt32(txtBonus.Text) - Convert.ToInt32(txtFine.Text);
                txtBonusInTotal.Text = total.ToString();

            }
        }
    }
}
