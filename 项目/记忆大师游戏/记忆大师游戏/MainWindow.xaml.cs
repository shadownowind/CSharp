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
using 记忆大师游戏.View;
using 记忆大师游戏.ViewModel;

namespace 记忆大师游戏
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //Background music
        private BackgroundMusic backgroundMusic = BackgroundMusic.GetInstance();
        //ViewModel
        private MainWindowmModel mainViewModel = new MainWindowmModel();
        public MainWindow()
        {
            InitializeComponent();
            MainWindowmModel.PropertyChanged += ChangePage;
            this.Content = new MainPage();
        }

        /// <summary>
        /// Change the page in the Main Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePage(object sender, EventArgs e)
        {
            switch (mainViewModel.PageLabel)
            {
                case Config.MainPageName:
                    this.Content = new MainPage();
                    break;
                case Config.GameLevelPageName:
                    this.Content = new GameLevelPage();
                    break;
                case Config.SettingPageName:
                    this.Content = new SettingPage();
                    break;
                case Config.IntroductionPageName:
                    this.Content = new IntroductionPage();
                    break;
                default:
                    string[] arrayStr = mainViewModel.PageLabel.Split(new char[] { '_' });
                    this.Content = new GamePlayPage(int.Parse(arrayStr[1]), int.Parse(arrayStr[2]));
                    break;
            }
        }
    }
}
