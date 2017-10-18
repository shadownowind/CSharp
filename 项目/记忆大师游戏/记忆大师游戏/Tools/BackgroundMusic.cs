using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace 记忆大师游戏.Tools
{
    /// <summary>
    /// The class can be used to choose music to play
    /// </summary>
    public class BackgroundMusic
    {
        //The instances of SoundPlayer
        private SoundPlayer buttonSelectPlayer;
        private SoundPlayer buttonPressPlayer;
        private SoundPlayer buttonCorrectPlayer;
        private SoundPlayer buttonErrorPlayer;
        private SoundPlayer winPlayer;

        //the singleton
        private static BackgroundMusic backgroundMusicPlayer;
        private static object createInstanceLock = new object();

        //get setting info
        private GameInfoXml gameInfoxml = GameInfoXml.GetInstance();
        public static bool IsMusic;

        /// <summary>
        /// Get the instance of singleton
        /// </summary>
        /// <returns></returns>
        public static BackgroundMusic GetInstance()
        {
            if (backgroundMusicPlayer == null)
            {
                lock (createInstanceLock)
                {
                    if (backgroundMusicPlayer == null)
                    {
                        backgroundMusicPlayer = new BackgroundMusic();
                    }
                }
            }
            return backgroundMusicPlayer;
        }

        /// <summary>
        ///  Constructor
        /// </summary>
        protected BackgroundMusic()
        {
            try
            {
                buttonSelectPlayer = new SoundPlayer(Config.SelectSoundPath);
                buttonPressPlayer = new SoundPlayer(Config.PressSoundPath);
                buttonCorrectPlayer = new SoundPlayer(Config.CorrectSoundPath);
                buttonErrorPlayer = new SoundPlayer(Config.ErrorSoundPath);
                winPlayer = new SoundPlayer(Config.WinSoundPath);
                IsMusic = (gameInfoxml.GetSingleNodeValue("IsMusic") == "true") ? true : false;
            }
            catch (Exception)
            {
                ReleasePlayer();
                MessageBox.Show("背景音乐创建失败！");
            }
        }

        ~BackgroundMusic()
        {
            ReleasePlayer();
        }

        /// <summary>
        /// Play the sound of entering button
        /// </summary>
        public void PlayButtonEnter()
        {
            if (IsMusic)
            {
                buttonSelectPlayer.Play();
            }
        }

        /// <summary>
        /// Play the sound of pressing button
        /// </summary>
        public void PlayButtonPress()
        {
            if (IsMusic)
            {
                buttonPressPlayer.Play();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Play the sound when selecting correctly
        /// </summary>
        public void PlayButtonCorrect()
        {
            if (IsMusic)
            {
                buttonCorrectPlayer.Play();
            }
        }

        /// <summary>
        /// Play the sound when selecting wrongly
        /// </summary>
        public void PlayButtonError()
        {
            if (IsMusic)
            {
                buttonErrorPlayer.Play();
            }
        }

        /// <summary>
        /// Play the sound when win the game
        /// </summary>
        public void PlayWin()
        {
            if (IsMusic)
            {
                winPlayer.Play();
            }
        }

        private void ReleasePlayer()
        {
            if (buttonSelectPlayer != null)
            {
                buttonSelectPlayer.Dispose();
            }
            if (buttonPressPlayer != null)
            {
                buttonPressPlayer.Dispose();
            }
            if (buttonCorrectPlayer != null)
            {
                buttonCorrectPlayer.Dispose();
            }
            if (buttonErrorPlayer != null)
            {
                buttonErrorPlayer.Dispose();
            }
            if (winPlayer != null)
            {
                winPlayer.Dispose();
            }
        }
    }
}

