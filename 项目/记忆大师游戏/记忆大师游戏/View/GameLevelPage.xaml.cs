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
    /// GameLevelPage.xaml 的交互逻辑
    /// </summary>
    public partial class GameLevelPage : Page
    {
        //Used to page switching
        MainWindowmModel mainWindowModel = new MainWindowmModel();
        //Used to play music
        BackgroundMusic musicPlayer = BackgroundMusic.GetInstance();

        public GameLevelPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Go back to main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.PlayButtonPress();
            mainWindowModel.PageLabel = Config.MainPageName;
        }

        /// <summary>
        /// Change page to page of playing game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.PlayButtonPress();
            Button btnLevel = sender as Button;
            int index = this.tabGameType.SelectedIndex;
            mainWindowModel.PageLabel = string.Format(Config.GamePlayPageName, index+1, btnLevel.Tag.ToString());
        }

        /// <summary>
        /// The sound will play when mouse enter different TabItem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItem_MouseEnter(object sender, MouseEventArgs e)
        {
            musicPlayer.PlayButtonEnter();
        }

        /// <summary>
        /// The sound will play when mouse enter Home button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_MouseEnter(object sender, MouseEventArgs e)
        {
            musicPlayer.PlayButtonEnter();
        }
    }
}
