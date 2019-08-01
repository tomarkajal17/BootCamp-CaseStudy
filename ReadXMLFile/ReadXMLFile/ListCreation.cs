using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXMLFile
{
    //Class which enforce format of output generated via every tool
    class ListCreation
    {
        public string RuleId { get; set; }
        public string Tool { get; set; }
        public string Rule { get; set; }
        public string RuleNamespace { get; set; }
        public string Source { get; set; }
        public string Line_Number { get; set; }
        public string Section { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        
        private ListCreation()
        {

        }
       
        public ListCreation(string RuleId ,string Tool, string Rule, string RuleNamespace,string Source,string Line_Number,string Section,string Level,string Description)
        {
                
            this.RuleId = RuleId;
            this.Tool = Tool;
            this.Rule = Rule;
            this.RuleNamespace = RuleNamespace;
            this.Source = Source;
            this.Line_Number = Line_Number;
            this.Section = Section;
            this.Level = Level;
            this.Description = Description;

        }
  
    }
}
