//It contains the Main() Functions .
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;


namespace ReadXMLFile
{
    class MainProgram
    {
        static void Main(string[] args)
        {

            StyleCop st = new StyleCop();
            List<ListCreation> dataStylecop = new List<ListCreation>(st.ParseXml("C:\\Users\\320067257\\source\\repos\\ReadXMLFile\\ReadXMLFile\\stylecopoutput.xml")); //Give path of Generated stylecop xml file
            WriteCSV(dataStylecop, "stylecopoutput.csv"); //Second parameter path of csv file in which output is needed.

            FxCop fx = new FxCop();
            List<ListCreation> dataFxcop = fx.ParseXml("C:\\Users\\320067257\\source\\repos\\ReadXMLFile\\ReadXMLFile\\FxcopOutput.xml"); ; //Give path of Generated Fxcop xml file
            WriteCSV(dataFxcop, "fxcopoutput.csv"); //Second parameter path of csv file in which output is needed.

            List<ListCreation> FinalList = new List<ListCreation>( MergeTable(dataStylecop, dataFxcop));
            WriteCSV(FinalList, "FinalOutput.csv"); //Second parameter path of csv file in which output is needed.
        }
        
        public static List<ListCreation>  MergeTable(List<ListCreation> L1,List<ListCreation> L2)
        {
            List<ListCreation> FinalList = new List<ListCreation>(L1);
            FinalList.AddRange(L2);

            return FinalList;

        }


        
        public static  void WriteCSV<ListCreation>(IEnumerable<ListCreation> items, string path)
        {
            Type itemType = typeof(ListCreation);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);
            Console.WriteLine(props);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));
                
                foreach (var item in items)
                {
     
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }
  
    }
}
