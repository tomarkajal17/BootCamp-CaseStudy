using System.Xml;
using System.Data;
using System.Collections.Generic;

namespace ReadXMLFile
{
    //Class to handel the Fxcop tool
    class FxCop: IntegrateTool
    {
        public List<ListCreation> ParseXml(string path1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path1);
            List<ListCreation> FxcopList = new List<ListCreation>();

            foreach (XmlNode node in doc.GetElementsByTagName("Issue"))
            {
                string typename ="", CheckId="", Category="" ,Id="",InnerText="";

                if (node.ParentNode.Attributes["TypeName"] != null)
                {
                    typename = node.ParentNode.Attributes["TypeName"].Value;
                }
                if (node.ParentNode.Attributes["CheckId"] != null)
                {
                    CheckId = node.ParentNode.Attributes["CheckId"].Value;
                }
                if (node.ParentNode.Attributes["Category"] != null)
                {
                    Category = node.ParentNode.Attributes["Category"].Value;
                }
                if (node.ParentNode.Attributes["Id"] != null)
                {
                    Id = node.ParentNode.Attributes["Id"].Value;
                }

                string path = "", file = "", line = "", name="",level="";
               
                if (node.Attributes["Level"]!=null)
                {
                    level = node.Attributes["Level"].Value;

                }
                if (node.Attributes["Name"] != null)
                {
                    name = node.Attributes["Name"].Value;
                    name = name + ".";

                }

                if (node.Attributes["Path"] != null)
                {
                    path = node.Attributes["Path"].Value;
                    path = path + "\\";

                }
                if (node.Attributes["Line"] != null)
                {
                    line = node.Attributes["Line"].Value;

                }
                if (node.Attributes["File"] != null)
                {
                    file = node.Attributes["File"].Value;

                }
                if (node.InnerText != null)
                {

                    InnerText = node.InnerText;
                    if (InnerText.Contains(","))
                        InnerText = InnerText.Replace(",", " ");
                }

                FxcopList.Add(new ListCreation(CheckId, "FxCop", typename, Category, path + file, line, name + Id, level, InnerText));

            }
            return FxcopList;
        }
 
    }
}




