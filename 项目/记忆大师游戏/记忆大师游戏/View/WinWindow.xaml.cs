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
using 记忆大师游戏.ViewModel;

namespace 记忆大师游戏.View
{
    /// <summary>
    /// WinWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WinWindow : Window
    {
        private MainWindowmModel mainViewModel = new MainWindowmModel();
        private bool isLastLevel = false;
        private int gameId;
        private int level;

        public WinWindow(int gameId, int level)
        {
            InitializeComponent();
            this.gameId = gameId;
            this.level = level;
            if (gameId<=2)
            {
                if (level==6)
                {
                    isLastLevel = true;
                }
            }
            else
            {
                if (level==3)
                {
                    isLastLevel = true;
                }
            }
        }

        /// <summary>
        /// Go back to the game level page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLevel_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.PageLabel = Config.GameLevelPageName;
            this.Close();
        }

        /// <summary>
        /// Go to challenge the next level,if it is the last level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (isLastLevel)
            {
                MessageBox.Show("太棒啦！你已经战胜所有一关！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                this.Close();
                mainViewModel.PageLabel = string.Format(Config.GamePlayPageName, gameId, level + 1);
            }
        }
    }
}
