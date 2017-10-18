using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using 记忆大师游戏.Tools;
using 记忆大师游戏.ViewModel;

namespace 记忆大师游戏.View
{
    /// <summary>
    /// GamePlayPage.xaml 的交互逻辑
    /// </summary>
    public partial class GamePlayPage : Page
    {

        //view model
        private GamePlayPageModel playModel;
        //cell button
        List<Button> listButton = new List<Button>();
        //Timer
        private DispatcherTimer timerOne = new DispatcherTimer();
        private DispatcherTimer timerTwo = new DispatcherTimer();
        //Used to play music
        BackgroundMusic musicPlayer = BackgroundMusic.GetInstance();
        //Used to page switching
        MainWindowmModel mainWindowModel = new MainWindowmModel();
        //whether game is beginning
        private bool isGameBegin = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameid">Game id</param>
        /// <param name="level">Game level</param>
        public GamePlayPage(int gameid,int level)
        {
            InitializeComponent();
            playModel = new GamePlayPageModel(gameid,level);
            //listButton = new List<Button>();
            List<int> randomList = playModel.GetList();
            //create square of button in the center of UI
            for (int i=0;i<playModel.row;i++)
            {
                StackPanel rowStack = new StackPanel();
                rowStack.Orientation = Orientation.Horizontal;
                for (int j=0;j<playModel.row;j++)
                {
                    Button btnItem = new Button();
                    GamePlayPageModel.SetButtonProperty(btnItem, randomList[i+playModel.row*j]);
                    btnItem.MouseEnter += CellMouseEnter;
                    btnItem.MouseLeave += CellMouseLeave;
                    btnItem.Click += CellClick;
                    listButton.Add(btnItem);
                    rowStack.Children.Add(btnItem);
                }
                splRectContainer.Children.Add(rowStack);
            }
            this.lblRestTime.Content = playModel.RestMemoryTime.ToString() + " s";
            this.lblUseTime.Content = playModel.UseTime.ToString() + " s";
            //set the timerOne,record the rest time
            timerOne.Interval = new TimeSpan(0, 0, 1);
            timerOne.Tick += TimerOne_Tick;
            //set the timerTwo,record the use time
            timerTwo.Interval = new TimeSpan(0, 0, 1);
            timerTwo.Tick += TimerTwo_Tick;
            
        }

        private void TimerTwo_Tick(object sender, EventArgs e)
        {
            playModel.UseTime++;
            this.lblUseTime.Content = playModel.UseTime.ToString() + " s";
        }

        private void TimerOne_Tick(object sender, EventArgs e)
        {
            playModel.RestMemoryTime = playModel.RestMemoryTime-1;
            this.lblRestTime.Content = playModel.RestMemoryTime.ToString() + " s";
            if (playModel.RestMemoryTime<=0)
            {
                timerOne.Stop();
                ShowInvisibleView();
            }
        }

        /// <summary>
        /// The function will be executed when clicking cell button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int isWin = playModel.IsWin(button);
            if (isWin == 1)
            {
                timerTwo.Stop();
                ShowMemoryView();
                WinWindow winWindow = new WinWindow(playModel.GameId, playModel.Level);
                musicPlayer.PlayWin();
                winWindow.ShowDialog();               
                return;
            }
            else if (isWin==-1)
            {
                timerTwo.Stop();
                ShowMemoryView();
                musicPlayer.PlayButtonError();
                LoseWindow loseWindow = new LoseWindow(playModel.GameId,playModel.Level);
                loseWindow.ShowDialog();
                return;
            }
            musicPlayer.PlayButtonCorrect();
            //begin to record the time used
            if (isGameBegin==false)
            {
                isGameBegin = true;
                timerTwo.Start();
            }
        }

        /// <summary>
        /// The function will be executed when mouse leaves cell button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellMouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button.IsEnabled)
            {
                button.BorderThickness = new Thickness(0);
            }           
        }

        /// <summary>
        /// The function will be executed when mouse enters cell button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellMouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.BorderThickness = new Thickness(1);
        }

        /// <summary>
        /// Go back to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.PlayButtonPress();
            mainWindowModel.PageLabel = Config.MainPageName;            
        }

        /// <summary>
        /// Go back to the previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            musicPlayer.PlayButtonPress();
            mainWindowModel.PageLabel = Config.GameLevelPageName;
        }

        /// <summary>
        /// Begin to memory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameBegin_Click(object sender, RoutedEventArgs e)
        {
            ShowMemoryView();
            timerOne.Start();
            this.btnGameBegin.IsEnabled = false;
        }

        /// <summary>
        /// Show invisible view when memoey time ends
        /// </summary>
        private void ShowInvisibleView()
        {
            foreach (Button button in listButton)
            {
                GamePlayPageModel.SetInvisibleView(button);
            }
        }

        /// <summary>
        /// Show Game one memory view when memories or game is over.
        /// </summary>
        private void ShowGameOneMemoryView()
        {
            foreach (Button button in listButton)
            {
                GamePlayPageModel.SetGameOneMemoryView(button);
            }
        }

        /// <summary>
        /// Show Game two memory view when memories or game is over.
        /// </summary>
        private void ShowGameTwoMemoryView()
        {
            foreach (Button button in listButton)
            {
                GamePlayPageModel.SetGameTwoMemoryView(button);
            }
        }

        /// <summary>
        /// Show Game three memory view when memories or game is over.
        /// </summary>
        private void ShowGameThreeMemoryView()
        {
            foreach (Button button in listButton)
            {
                GamePlayPageModel.SetGameThreeMemoryView(button);
            }
        }

        /// <summary>
        /// According to game id,show the memory view.
        /// </summary>
        private void ShowMemoryView()
        {
            if (playModel.GameId==1)
            {
                ShowGameOneMemoryView();
            }
            else if (playModel.GameId==2)
            {
                ShowGameTwoMemoryView();
            }
            else
            {
                ShowGameThreeMemoryView();
            }
        }
    }
}
