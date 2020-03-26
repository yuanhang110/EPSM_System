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

namespace EPSM_System.pages.record
{
    /// <summary>
    /// EditPage.xaml 的交互逻辑
    /// </summary>
    /// <summary>
    /// EditUserPage.xaml 的交互逻辑
    /// </summary>
    public partial class EditRecordPage : Window
    {

        private RecordBLL bll = new RecordBLL();
        //编辑或者增加
        public bool isAdd { get; set; }

        public EditRecordPage()
        {
            InitializeComponent();
            this.cbType.ItemsSource = Common.SexTypes;
            this.cbType.Text = "选择性别";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (isAdd)
            {
                this.Title = "添加员工";
                this.btnOk.Content = "添加";
                RecordData user = new RecordData();                         
                gridUser.DataContext = user;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            RecordData user = (RecordData)gridUser.DataContext;
            if (isAdd)
            {
                if (bll.AddRecord(user))
                    MessageBox.Show("添加成功！");
            }
            else
            {
                if (bll.UpdateRecord(user))
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
