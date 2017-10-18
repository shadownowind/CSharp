using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 记忆大师游戏
{
    /// <summary>
    /// Memory some constant variable
    /// </summary>
    public abstract class Config
    {
        //sound of selecting button
        public static readonly string SelectSoundPath = "./Resources/Music/ButtonSelectMusic.wav";
        //sound of pressing correct button
        public static readonly string CorrectSoundPath = "./Resources/Music/ButtonCorrectMusic.wav";
        //sound of pressing wrong button
        public static readonly string ErrorSoundPath = "./Resources/Music/ButtonErrorMusic.wav";
        //sound of pressing button
        public static readonly string PressSoundPath = "./Resources/Music/ButtonPressMusic.wav";
        //sound of winning
        public static readonly string WinSoundPath = "./Resources/Music/WinMusic.wav";

        //Main page
        public const string MainPageName = "MainPage";
        //Game level page
        public const string GameLevelPageName = "GameLevelPage";
        //Game playing page.{0} is game type,{1}is game level
        public const string GamePlayPageName = "GamePlayPage_{0}_{1}";
        //Setting page
        public const string SettingPageName = "SettingPage";
        //Introduction page
        public const string IntroductionPageName = "IntroductionPage";

        //Image path
        public const string CellImage = "\\Resources\\Image\\Cell.png";

        //the configure document name
        public const string ConfigDocName = "setting.xml";

        //Game rule introduction
        public const string Introduction = "黑白两清：记忆颜色为蓝色的方块，将所有颜色为蓝色的方块点击出来。\n\n\n" +
            "数字连连：记忆每个数字方块的位置，按从小到大的顺序将数字方块点击出来。\n\n\n" +
            "成双成对：记忆颜色方块的位置，将一双双的颜色对点击出来。";
    }
}
