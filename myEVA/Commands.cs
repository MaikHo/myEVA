using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace myEVA
{
    class Commands
    {
        private string command;
        private string answer;
        private string info;
        private string argument;




        public Commands(string _command_name, string _command_answer, string _command_info, string _command_argument)
        {
            command = _command_name;
            answer = _command_answer;
            info = _command_info;
            argument = _command_argument;
        }

        public string Command() { return command; }
        public string Answer(){ return answer; }
        public string Info() { return info; }
        public string Argument() { return argument; }

        public void Write_Commands_to_XML(XmlTextWriter xw)
        {
            xw.WriteStartElement("command");
            xw.WriteAttributeString("command_name", command);
            xw.WriteAttributeString("answer", answer);
            xw.WriteAttributeString("info", info);
            xw.WriteAttributeString("argument", argument);
            xw.WriteEndElement();
        }

    }
}
