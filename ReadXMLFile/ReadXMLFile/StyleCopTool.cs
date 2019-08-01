using System;
using System.Data;
using System.Xml;
using System.Collections.Generic;

namespace ReadXMLFile
{
    //Class to handle Stylecop tool
    class StyleCop: IntegrateTool
    {
        public  List<ListCreation> ParseXml(String path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList elemList = doc.GetElementsByTagName("Violation");
           
            List<ListCreation> StylecopList = new List<ListCreation>();
            string RuleId="", Rule="", RuleNamespace="", Source="", LineNumber="", Section="", InnerText="";

            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].Attributes["RuleId"] != null)
                {
                    RuleId = elemList[i].Attributes["RuleId"].Value;
                }
                if (elemList[i].Attributes["Rule"] != null)
                {
                    Rule = elemList[i].Attributes["Rule"].Value;
                }
                if (elemList[i].Attributes["RuleNamespace"].Value != null)
                {
                    RuleNamespace = elemList[i].Attributes["RuleNamespace"].Value;
                }

                if (elemList[i].Attributes["Source"] != null)
                {
                    Source = elemList[i].Attributes["Source"].Value;
                }
                if (elemList[i].Attributes["LineNumber"] != null)
                {
                    LineNumber = elemList[i].Attributes["LineNumber"].Value;
                }
                if (elemList[i].Attributes["Section"] != null)
                {
                    Section = elemList[i].Attributes["Section"].Value;
                }
                if (elemList[i].InnerText != null)
                {
         
                    InnerText = elemList[i].InnerText;
                    if (InnerText.Contains(","))
                        InnerText = InnerText.Replace(",", " ");
                }
                StylecopList.Add(new ListCreation(RuleId,"StyleCop",Rule, RuleNamespace,Source,LineNumber,Section,"Warning", InnerText));
            }
            return StylecopList;
        }
        

    }

   
}
