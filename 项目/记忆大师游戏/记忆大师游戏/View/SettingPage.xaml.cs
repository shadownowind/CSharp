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
    /// SettingPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingPage : Page
    {
        //ViewModel
        private MainWindowmModel mainViewModel = new MainWindowmModel();
        //Get setting singleton
        private GameInfoXml gameInfoXml = GameInfoXml.GetInstance();

        //setting data
        private string isTimeDefault = "";
        private string isMusic = "";
        private int gameOneTime = 0;
        private int gameTwoTime = 0;
        private int gameThreeTime = 0;

        public SettingPage()
        {
            InitializeComponent();
            isTimeDefault = gameInfoXml.GetSingleNodeValue("IsTimeDefault");
            isMusic = gameInfoXml.GetSingleNodeValue("IsMusic");
            gameOneTime = int.Parse(gameInfoXml.GetSingleNodeValue("GameTime/GameOneTime"));
            gameTwoTime = int.Parse(gameInfoXml.GetSingleNodeValue("GameTime/GameTwoTime"));
            gameThreeTime = int.Parse(gameInfoXml.GetSingleNodeValue("GameTime/GameThreeTime"));
            //set the ui view
            this.txbGameOne.Text = gameOneTime.ToString();
            this.txbGameTwo.Text = gameTwoTime.ToString();
            this.txbGameThree.Text = gameThreeTime.ToString();
            if (isTimeDefault == "true")
            {
                this.ckbTime.IsChecked = true;
            }
            if (isMusic == "true")
            {
                this.ckbMusic.IsChecked = true;
                SetTextBoxUnenable();
            }
        }

        /// <summary>
        /// cancel to save the setting changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.PageLabel = Config.MainPageName;
        }

        /// <summary>
        /// confirm to save the setting changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(IsAllDigit(this.txbGameOne.Text) && IsAllDigit(this.txbGameTwo.Text) && IsAllDigit(this.txbGameThree.Text))
            {
                SaveSetting();
                BackgroundMusic.IsMusic = (bool)this.ckbMusic.IsChecked;
                mainViewModel.PageLabel = Config.MainPageName;
            }
            else
            {
                MessageBox.Show("设置错误，输入框不能有非数字文本！", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// set textbox's IsEnable to false when checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbTime_Checked(object sender, RoutedEventArgs e)
        {
            SetTextBoxUnenable();
        }

        /// <summary>
        /// set textbox's IsEnable to true when uncheck.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbTime_Unchecked(object sender, RoutedEventArgs e)
        {
            SetTextBoxEnable();
        }

        /// <summary>
        /// set textbox's IsEnable to false.
        /// </summary>
        private void SetTextBoxUnenable()
        {
            this.txbGameOne.IsEnabled = false;
            this.txbGameTwo.IsEnabled = false;
            this.txbGameThree.IsEnabled = false;
        }

        /// <summary>
        /// set textbox's IsEnable to true.
        /// </summary>
        private void SetTextBoxEnable()
        {
            this.txbGameOne.IsEnabled = true;
            this.txbGameTwo.IsEnabled = true;
            this.txbGameThree.IsEnabled = true;
        }

        /// <summary>
        /// Save setting to xml document
        /// </summary>
        private void SaveSetting()
        {
            isTimeDefault = (bool)this.ckbTime.IsChecked ? "true" : "false";
            isMusic = (bool)this.ckbMusic.IsChecked ? "true" : "false";
            gameInfoXml.SetSingleNodeValue("IsTimeDefault", isTimeDefault);
            gameInfoXml.SetSingleNodeValue("IsMusic", isMusic);
            gameInfoXml.SetSingleNodeValue("GameTime/GameOneTime", this.txbGameOne.Text);
            gameInfoXml.SetSingleNodeValue("GameTime/GameTwoTime", this.txbGameTwo.Text);
            gameInfoXml.SetSingleNodeValue("GameTime/GameThreeTime", this.txbGameThree.Text);
        }

        /// <summary>
        /// If string is number,return true,else return false.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsAllDigit(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
