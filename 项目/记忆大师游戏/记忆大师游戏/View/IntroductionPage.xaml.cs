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
using 记忆大师游戏.ViewModel;

namespace 记忆大师游戏.View
{
    /// <summary>
    /// IntroductionPage.xaml 的交互逻辑
    /// </summary>
    public partial class IntroductionPage : Page
    {
        private MainWindowmModel mainWindowModel = new MainWindowmModel();

        public IntroductionPage()
        {
            InitializeComponent();
            this.txbIntroduction.Text = Config.Introduction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            mainWindowModel.PageLabel = Config.MainPageName;
        }
    }
}
