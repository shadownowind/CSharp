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
using 记忆大师游戏.Tools;
using 记忆大师游戏.ViewModel;

namespace 记忆大师游戏.View
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        //Background music
        private BackgroundMusic backgroundMusic = BackgroundMusic.GetInstance();

        private MainWindowmModel mainWindowModel = new MainWindowmModel();

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Game begin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameBegin_Click(object sender, RoutedEventArgs e)
        {
            backgroundMusic.PlayButtonPress();
            //Show game level
            mainWindowModel.PageLabel = Config.GameLevelPageName;
        }

        /// <summary>
        /// The setting of game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameSetting_Click(object sender, RoutedEventArgs e)
        {
            backgroundMusic.PlayButtonPress();
            mainWindowModel.PageLabel = Config.SettingPageName;
        }

        /// <summary>
        /// The rank of score that the player get.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameRank_Click(object sender, RoutedEventArgs e)
        {
            backgroundMusic.PlayButtonPress();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameHelp_Click(object sender, RoutedEventArgs e)
        {
            backgroundMusic.PlayButtonPress();
            mainWindowModel.PageLabel = Config.IntroductionPageName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            backgroundMusic.PlayButtonEnter();
        }
    }
}
