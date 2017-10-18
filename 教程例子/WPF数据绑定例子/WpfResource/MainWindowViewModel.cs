using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfResource
{
    class MainWindowViewModel
    {
        public SimpleData simpleData;
        public ObservableCollection<FileMessage> fileList;

        public MainWindowViewModel()
        {
            simpleData = new SimpleData();
            fileList = new ObservableCollection<FileMessage>();
        }

        public void AddThreeFile()
        {
            fileList.Add(new FileMessage() { name = "作业.doc",size = 12,type = "doc文件" });
            fileList.Add(new FileMessage() { name = "照片.jpg", size = 100, type = "jpg文件" });
            fileList.Add(new FileMessage() { name = "音乐.mp3", size = 5000, type = "mp3文件" });
        }
    }

    class SimpleData
    {
        public int value { get; set; }
    }

    class FileMessage
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
    }
}
