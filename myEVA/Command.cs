using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace myEVA
{
    class Command
    {
        private string command;
        private string answer;
        private string info;
        private string pfad;
        private string argument;
        public bool command_kill;

        Command_processing cmd = new Command_processing();

        public Command(string _command_name, string _command_answer, string _command_info, string _pfad, string _command_argument, bool _command_kill)
        {
            this.command = _command_name;
            this.answer = _command_answer;
            this.info = _command_info;
            this.pfad = _pfad;
            this.argument = _command_argument;
            this.command_kill = _command_kill;

            command = command.ToLower();

            

            if (CheckPfad() && command_kill == false)
            {
                if (CheckArgument())
                {

                }
                //cmd.Cmd_ToolStart(pfad);                
            }

            if (CheckArgument() && command_kill)
            {
                cmd.Cmd_ToolClose(argument, command);
            }

            Main_commands();
        }

        private void Main_commands()
        {
            
            switch (command)
            {
                case "programm beenden":                     
                    command_kill = true;
                    break;
                case "datum":                    
                    answer = cmd.Get_Date();                    
                    break;
                case "zeit":
                    answer = cmd.Get_Time();
                    break;
                case "vorlesen":
                    answer = cmd.Get_ReadClipboard();                    
                    break;
                default:
                    break;
            }




        }

        public string GetCommand() { return command; }
        public string GetAnswer(){ return answer; }
        public string GetInfo() { return info; }
        public string GetPfad() { return pfad; }
        public string GetArgument() { return argument; }
        

        /// <summary>
        /// checkt ob in der Variable "none" oder eine ProcessID steckt
        /// </summary>
        /// 
        /// <returns></returns>
        private bool CheckArgument()
        {
            if (argument == "none")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// checkt ob in der Variable "none" oder ein String zun Aufruf eines Pogrammes steckt
        /// </summary>
        /// 
        /// <returns></returns>
        private bool CheckPfad()
        {
            if (pfad == "none")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        

    }
}
