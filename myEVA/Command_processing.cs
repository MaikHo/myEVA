using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using myEVA;

namespace myEVA
{
    /// <summary>
    /// Befehlsverarbeitung der Sprachbefehle
    /// </summary>
    class Command_processing
    {
        public string command_name;
        public string command_answer;
        public string command_info;
        public string command_argument;
        public bool command_kill;

        

        public Command_processing(string _command_name, string _command_answer, string _command_info, string _command_argument, bool _command_kill)
        {
            command_name = _command_name;
            command_answer = _command_answer;
            command_info = _command_info;
            command_argument = _command_argument;
            command_kill = _command_kill;

            if (command_argument == "none")
            {
                Main_commands(command_name);
            }
            else
            {
                Command_start_tool();
            }
        }
        
        

        private void Main_commands(string _command_name)
        {
            //MessageBox.Show(_speack_command);

            // Falls doch kein programm geschlossen werden soll
            command_kill = false;

            string computer = myEVA.Properties.Settings.Default.computername;
            string user = myEVA.Properties.Settings.Default.username;

            if (_command_name == computer)
            {
                // Antwortvielfalt
                Random r = new Random();
                string[] hallo_computer = new string[4] { user + " was kann ich für dich tun", "ja " + user, "ja", "jup" };

                command_name = _command_name;
                command_answer = hallo_computer[r.Next(4)];
                command_info = "Systembefehl, holt die App wieder in den Vordergrund!";
                command_argument = "normal";

            }
            else
            {
                switch (_command_name)
                {
                    case "pause": case "bereitschaft": case "minimieren":
                        // Antwortvielfalt
                        Random r = new Random();
                        string[] minimieren_computer = new string[4] { "bis gleich " + user, "zu Befehl " + user, "bin dann mal weg", "jup" };
                        command_name = _command_name;
                        command_answer = minimieren_computer[r.Next(4)];
                        command_info = "Systembefehl, minimiert die App";
                        command_argument = "minimieren";
                        
                        break;
                    
                    case "maximieren":
                        Random r1 = new Random();
                        string[] maximieren_computer = new string[4] { user + " was kann ich für dich tun", "ja " + user, "ja", "jup" };
                        command_name = _command_name;
                        command_answer = maximieren_computer[r1.Next(4)];
                        command_info = "Systembefehl, holt die App wieder in den Vordergrund!";
                        command_argument = "normal";
                        
                        break;
                    
                    case "ausschalten": case "beenden":
                        command_name = _command_name;
                        command_answer = "welches Programm?";
                        command_info = "Systembefehl zum beenden von Programmen!";
                        command_argument = "none";
                        command_kill = true;
                        break;
                    
                        
                    case "datum":
                        command_name = _command_name;
                        command_answer = DateTime.Now.ToString("d");
                        command_info = "Systembefehl, sagt das aktuelle Datum.";
                        break;
                    case "zeit":
                        command_name = _command_name;
                        command_answer = DateTime.Now.ToString("HH:mm");
                        command_info = "Systembefehl, sagt die aktuelle Uhrzeit an.";
                        break;
                    case "vorlesen":
                        string zwischenablage = null;                        
                        if (Clipboard.ContainsText())
                        {                            
                            zwischenablage = Clipboard.GetText();
                        }
                        else
                        {
                            zwischenablage = "Bitte markiere erst etwas.";
                        }
                        command_name = _command_name;
                        command_answer = zwischenablage;
                        command_info = "Systembefehl, liest den Text aus der Zwischenablage vor.";
                        break;
                    case "schalte dich aus":
                        command_name = _command_name;
                        command_answer = "ok " + user + ", dann bis demnächst";
                        command_info = "Systembefehl, schließt die App.";
                        command_argument = "exit";
                        break;
                    default:
                        break;
                }
            }

            


        }

        private void Command_start_tool()
        {
            

            if (command_argument == "cmd")
            {
                // commando_name ist z.B ping localhost
                Process.Start("cmd.exe", "/K " + command_name);

                //Process oProcess = new Process();

                //oProcess.StartInfo.FileName = "cmd.exe";
                //oProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                //oProcess.StartInfo.Arguments = command_name + " > cmd_ausgabe.txt";

                //oProcess.Start();

                //if (oProcess.HasExited)
                //{

                //}
                //else
                //{
                //    oProcess.Kill();
                //}


                //StreamReader myFile = new StreamReader("cmd_ausgabe.txt", System.Text.Encoding.Default);
                //command_answer = myFile.ReadToEnd();
                //myFile.Close();

                command_kill = false;
            }
            else if (command_kill)
            {
                // Programm schließen
                Process P = Process.GetProcessById(Convert.ToInt32(command_argument));
                                
                foreach (Process p_all in Process.GetProcesses())
                {
                    if (p_all.Id == P.Id)
                    {
                        P.CloseMainWindow();
                        // Programm geschlossen dann
                        command_kill = false;
                        command_argument = "app";
                        command_answer = "Ich habe das laufende Programm " + command_name + " gefunden und geschlossen";
                        break;
                    }
                }

                if (P.HasExited)
                {
                    command_answer = "Ich habe das laufende Programm " + command_name + " nicht gefunden. Vielleicht hast du es selber gestartet";
                }
                
                

                
                

                
            }
            else
            {
                //Programm läuft nicht
                if (command_argument == "app")
                {
                    // command_argument bekommt die ProcessID
                    Process P = new Process();
                    P.StartInfo.FileName = command_name +".exe";
                    P.Start();
                    command_argument = Convert.ToString(P.Id);
                }                
                else  // Programm läuft
                {
                    // Hier kommt die ID an
                    int _P_ID = Convert.ToInt32(command_argument);
                    Process P = Process.GetProcessById(_P_ID);
                    //P.Refresh(); //.Start();
                    BringMainWindowToFront(P.ProcessName);
                    command_answer = "Ich habe ein laufendes Programm Namens " + command_name + " gefunden";
                }
                

            }
        }




        /// <summary>
        /// BringMainWindowToFront(P.ProcessName);
        /// </summary>

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };
        public void BringMainWindowToFront(string processName)
        {
            //get the process
            Process bProcess = Process.GetProcessesByName(processName).FirstOrDefault();
            //check if the process is running
            if (bProcess != null)
            {
                //check if the window is hidden /minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    //the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.Show); // Hier stand vorher .Restore  vielleicht funzt Show besser
                    MessageBox.Show("bin da");
                }
                //set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }

        }



    }
}
