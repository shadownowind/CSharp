using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace 记忆大师游戏.Tools
{
    class GameInfoXml
    {
        //Create singleton
        private static GameInfoXml gameInfo ;
        private static object myLock = new object(); 

        /// <summary>
        /// Constructor
        /// </summary>
        protected GameInfoXml()
        {
            if (!File.Exists(Config.ConfigDocName))
            {
                CreateXmlDoc();
            }
        }

        /// <summary>
        /// Get instance of singleton
        /// </summary>
        /// <returns></returns>
        public static GameInfoXml GetInstance()
        {
            if (gameInfo == null)
            {
                lock(myLock)
                {
                    if (gameInfo==null)
                    {
                        gameInfo = new GameInfoXml();
                    }
                }
            }
            return gameInfo;
        }

        /// <summary>
        /// Create xml document to save the setting.
        /// </summary>
        private void CreateXmlDoc()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);
            XmlNode root = xmlDoc.CreateElement("GameInfo");
            xmlDoc.AppendChild(root);
            //Time Setting
            CreateNode(xmlDoc, root, "IsTimeDefault", "true");
            XmlNode gameTimeNode = xmlDoc.CreateElement("GameTime");
            root.AppendChild(gameTimeNode);
            CreateNode(xmlDoc, gameTimeNode, "GameOneTime", "5");
            CreateNode(xmlDoc, gameTimeNode, "GameTwoTime", "5");
            CreateNode(xmlDoc, gameTimeNode, "GameThreeTime", "5");
            //Music Setting
            CreateNode(xmlDoc, root, "IsMusic", "true");
            //Grade ranking
            XmlNode gradeRankRoot = xmlDoc.CreateElement("GradeRank");
            root.AppendChild(gradeRankRoot);
            //Memory time rank
            XmlNode memoryTimeRankNode = xmlDoc.CreateElement("MemoryTimeRank");
            gradeRankRoot.AppendChild(memoryTimeRankNode);
            CreateGameGradeNode(xmlDoc, memoryTimeRankNode, "GameOneGrade");
            CreateGameGradeNode(xmlDoc, memoryTimeRankNode, "GameTwoGrade");
            CreateGameGradeNode(xmlDoc, memoryTimeRankNode, "GameThreeGrade");
            //Use time rank
            XmlNode useTimeRankNode = xmlDoc.CreateElement("UseTimeRank");
            gradeRankRoot.AppendChild(useTimeRankNode);
            CreateGameGradeNode(xmlDoc, useTimeRankNode, "GameOneGrade");
            CreateGameGradeNode(xmlDoc, useTimeRankNode, "GameTwoGrade");
            CreateGameGradeNode(xmlDoc, useTimeRankNode, "GameThreeGrade");
            try
            {
                xmlDoc.Save(Config.ConfigDocName);
            }
            catch (Exception e)
            {
                //显示错误信息    
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Create game grade node
        /// </summary>
        /// <param name="xmlDoc">xml doc</param>
        /// <param name="parentNode">root node</param>
        /// <param name="name">child node</param>
        private void CreateGameGradeNode(XmlDocument xmlDoc, XmlNode parentNode, string name)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            parentNode.AppendChild(node);
            for (int i=0;i<5;i++)
            {
                CreateNode(xmlDoc, node, "Person", "0_0");
            }
        }

        /// <summary>      
        /// 创建节点      
        /// </summary>      
        /// <param name="xmldoc">xml文档</param>      
        /// <param name="parentnode">父节点</param>      
        /// <param name="name">节点名</param>      
        /// <param name="value">节点值</param>      
        ///     
        private void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }

        /// <summary>
        /// Set the single node value.
        /// </summary>
        /// <param name="path">node's path in xml document</param>
        /// <param name="value">node'value setted</param>
        public void SetSingleNodeValue(string path,string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Config.ConfigDocName);
            XmlElement xe = xmlDoc.DocumentElement;
            XmlNode selectXe = xe.SelectSingleNode(path);
            selectXe.InnerText = value;
            xmlDoc.Save(Config.ConfigDocName);
        }

        /// <summary>
        /// Set the single node value.
        /// </summary>
        /// <param name="path">node's path in xml document</param>
        public string GetSingleNodeValue(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Config.ConfigDocName);
            XmlElement xe = xmlDoc.DocumentElement;
            XmlNode selectXe = xe.SelectSingleNode(path);
            return selectXe.InnerText;            
        }
    }
}
