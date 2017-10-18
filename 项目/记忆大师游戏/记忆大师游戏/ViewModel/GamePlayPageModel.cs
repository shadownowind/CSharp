using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using 记忆大师游戏.Tools;

namespace 记忆大师游戏.ViewModel
{
    class GamePlayPageModel
    {
        //The limited time of memory
        private int useTime = 0;
        public int UseTime
        {
            get
            {
                return useTime;
            }
            set
            {
                if (value >= 0)
                {
                    useTime = value;
                }
            }
        }

        //The rest memory time
        private int restMemoryTime;
        public int RestMemoryTime
        {
            get
            {
                return restMemoryTime;
            }
            set
            {
                if (value >= 0)
                {
                    restMemoryTime = value;
                }
            }
        }

        //Game id
        private int gameId = 0;
        public int GameId
        {
            get
            {
                return gameId;
            }
        }
        //Game level
        private int level = 0;
        public int Level
        {
            get
            {
                return level;
            }
        }
        //Total number of clicking
        public int clickNumber = 0;
        //Correct number
        public int correctNumber = 0;
        //row
        public int row = 0;

        //game three aid variable
        private int gameThreeAidValue = 0;

        //get setting singleton
        private GameInfoXml gameInfo = GameInfoXml.GetInstance();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="level"></param>
        public GamePlayPageModel(int gameId, int level)
        {
            this.gameId = gameId;
            this.level = level;
            SetMemoryTime();
        }

        /// <summary>
        /// Set Button's property
        /// </summary>
        public static void SetButtonProperty(Button button, int id)
        {
            button.Width = 30;
            button.Height = 30;
            Uri uri = new Uri(Config.CellImage, UriKind.RelativeOrAbsolute);
            BitmapImage bitmap = new BitmapImage(uri);
            Image cellImage = new Image();
            cellImage.Source = bitmap;
            button.Content = cellImage;
            button.BorderThickness = new Thickness(0);
            button.Tag = id;
            button.IsEnabled = false;
        }

        /// <summary>
        /// When memory time ends,show the invisible view.
        /// </summary>
        public static void SetInvisibleView(Button button)
        {
            if (button.IsEnabled == false)
            {
                Uri uri = new Uri(Config.CellImage, UriKind.RelativeOrAbsolute);
                BitmapImage bitmap = new BitmapImage(uri);
                Image cellImage = new Image();
                cellImage.Source = bitmap;
                button.Content = cellImage;
                button.BorderThickness = new Thickness(0);
                button.IsEnabled = true;
            }
        }

        /// <summary>
        /// Show button's result when clicking it.
        /// </summary>
        /// <param name="button"></param>
        public static void SetGameOneMemoryView(Button button)
        {
            if ((int)button.Tag == 1)
            {
                Rectangle rect = new Rectangle();
                rect.Fill = Brushes.Blue;
                rect.Width = 30;
                rect.Height = 30;
                button.Content = rect;
                button.BorderThickness = new Thickness(1);
            }
            button.IsEnabled = false;
        }

        /// <summary>
        /// Show button's result when clicking it.
        /// </summary>
        /// <param name="button"></param>
        public static void SetGameTwoMemoryView(Button button)
        {
            button.Content = (int)button.Tag;            
            button.BorderThickness = new Thickness(1);
            button.FontFamily = new FontFamily("Segoe UI Black");
            button.FontSize = 16;
            button.IsEnabled = false;
        }

        /// <summary>
        /// Show button's result when clicking it.
        /// </summary>
        /// <param name="button"></param>
        public static void SetGameThreeMemoryView(Button button)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(GetColor((int)button.Tag));
            rect.Width = 30;
            rect.Height = 30;
            button.Content = rect;
            button.BorderThickness = new Thickness(1);
            button.IsEnabled = false;
        }

        /// <summary>
        /// Generate different color according to the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Color GetColor(int value)
        {
            Color color = new Color();
            color.R = Convert.ToByte((value * 31 + 1) % 256);
            color.G = Convert.ToByte((value * 52 + 1) % 256);
            color.B = Convert.ToByte((value * 73 + 1) % 256);
            color.A = 255;
            return color;
        }

        /// <summary>
        /// Randomize the list
        /// </summary>
        /// <param name="list"></param>
        static void RandomArray(List<int> list)
        {
            Random ran = new Random();
            int index = 0;
            int temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                index = ran.Next(0, list.Count - 1);
                if (index != i)
                {
                    temp = list[i];
                    list[i] = list[index];
                    list[index] = temp;
                }
            }
        }

        /// <summary>
        /// Judge whether game win,lose or continues
        /// </summary>
        /// <param name="button"></param>
        /// <returns>
        /// If wins,return 1,if loses,return -1,if game still continues,return 0.
        /// </returns>
        public int IsWin(Button button)
        {
            int idx = (int)button.Tag;
            if (gameId == 1)
            {
                if (idx == 0)
                {
                    return -1;
                }
                else
                {
                    SetGameOneMemoryView(button);
                    correctNumber++;
                    if (correctNumber >= clickNumber)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else if (gameId == 2)
            {
                if (idx != (correctNumber + 1))
                {
                    return -1;
                }
                else
                {
                    SetGameTwoMemoryView(button);
                    correctNumber++;
                    if (correctNumber >= clickNumber)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                if (gameThreeAidValue == 0)
                {
                    SetGameThreeMemoryView(button);
                    correctNumber++;
                    gameThreeAidValue = idx;
                    return 0;
                }
                else
                {
                    if (idx == gameThreeAidValue)
                    {
                        correctNumber++;
                        SetGameThreeMemoryView(button);
                        if (correctNumber >= clickNumber)
                        {
                            return 1;
                        }
                        else
                        {
                            gameThreeAidValue = 0;
                            return 0;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> GetList()
        {
            List<int> list = new List<int>();
            if (gameId == 1)
            {
                //Game One:if number is one,set blue color,if number is zero,set gray color.
                int total = (level + 1) * (level + 1);
                row = level + 1;
                Random rand = new Random();
                this.clickNumber = (int)rand.Next(total / 3, total * 2 / 3);
                for (int i = 0; i < total; i++)
                {
                    if (i < clickNumber)
                    {
                        list.Add(1);
                    }
                    else
                    {
                        list.Add(0);
                    }
                }
            }
            else if (gameId == 2)
            {
                //Game Two:Set the number's value.
                int total = (level + 1) * (level + 1);
                row = level + 1;
                clickNumber = total;
                for (int i = 1; i <= total; i++)
                {
                    list.Add(i);
                }
            }
            else
            {
                //Game Three:according to number's value,set the different color.
                int total = level * level * 2;
                row = level * 2;
                clickNumber = total * 2;
                for (int i = 1; i <= total; i++)
                {
                    list.Add(i);
                    list.Add(i);
                }
            }
            RandomArray(list);
            return list;
        }

        private void SetMemoryTime()
        {
            bool isDefaultTime = (gameInfo.GetSingleNodeValue("IsTimeDefault") == "true") ? true : false;
            if (isDefaultTime)
            {
                if (gameId == 1)
                {
                    restMemoryTime = level;
                }
                else if (gameId == 2)
                {
                    restMemoryTime = 1 + (int)Math.Pow(3, level - 1);
                }
                else
                {
                    restMemoryTime = 1 + 30 * (level - 1);
                }
            }
            else
            {
                if (gameId == 1)
                {
                    restMemoryTime = int.Parse(gameInfo.GetSingleNodeValue("GameTime/GameOneTime"));
                }
                else if (gameId == 2)
                {
                    restMemoryTime = int.Parse(gameInfo.GetSingleNodeValue("GameTime/GameTwoTime"));
                }
                else
                {
                    restMemoryTime = int.Parse(gameInfo.GetSingleNodeValue("GameTime/GameOneTime"));
                }
            }
        }
    }
}
