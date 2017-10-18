using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfResource
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //切换语言
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            WpfResource.Properties.Resources.Culture = new System.Globalization.CultureInfo("zh-CN");
            //WpfResource.Properties.Resources.Culture = new System.Globalization.CultureInfo("EN");
        }
    }
}
