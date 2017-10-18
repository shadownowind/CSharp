using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 记忆大师游戏.ViewModel
{
    /// <summary>
    /// the MainWIndow's ViewModel
    /// </summary>
    public class MainWindowmModel
    {
        private static string pageLabel;
        public string PageLabel
        {
            get { return pageLabel; }
            set
            {
                pageLabel = value;
                OnPropertyChanged(new EventArgs());//每次改变Name值调用方法;  
            }
        }

        public static event EventHandler PropertyChanged;
        private void OnPropertyChanged(EventArgs eventArgs)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,eventArgs);
            }
        }
    }
}
