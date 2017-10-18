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
    /// LoseWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoseWindow : Window
    {
        private MainWindowmModel mainViewModel = new MainWindowmModel();
        private int gameId;
        private int level;
        private static int again = 0;

        public LoseWindow(int gameId, int level)
        {
            this.gameId = gameId;
            this.level = level;
            InitializeComponent();
        }

        /// <summary>
        /// Go back to the level page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLevel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainViewModel.PageLabel = Config.GameLevelPageName;
        }

        /// <summary>
        /// Challenge the game again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            again++;
            this.Close();
            mainViewModel.PageLabel = string.Format(Config.GamePlayPageName, gameId, level) + "_" + again.ToString();
        }
    }
}
