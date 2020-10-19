using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Speech.Recognition;
using System.Speech.Synthesis;

using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.IO;

namespace myEVA
{
    /*
    Link speichern -> markierten Link in DB speichern mit schlagwörter und so 
                        Link speichern
                        Linkliste in einer Form zeigen
    
    Wecker / Counter


    */    
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine h = new SpeechRecognitionEngine();
        SpeechSynthesizer s = new SpeechSynthesizer();

        SQLiteConnection connection = new SQLiteConnection("Data Source=commands.dat");     // ("Data Source=database.sqlite;Version=3;New=True;Compress=True;")
        string db_command;
        string db_answer;
        string db_info;
        string db_argument;

        bool aktiv = true;
        bool command_kill = false;


        // Hauptkommandos
        string[] main_commands =
        {
            "tab start",
            "tab befehle",
            "pause", "bereitschaft",
            "maximieren",
            "minimieren",
            "ausschalten", "beenden",
            "datum",
            "zeit",           
            "vorlesen",
            "schalte dich aus"
            
        };
 
        //string cmd_command;
        //string cmd_answer;
        //string cmd_info;
        //string cmd_argument;

        //Commands cmd_computer;
        //Commands cmd_tab_start;


        //string user = "Maik";
        /// Unter Assistant -> Eigenschaften -> Einstellungen
        /// Programm speicher Settings selbst, es werden keine Dateien mehr gebraucht
        string user = Properties.Settings.Default.username;
        string computer = Properties.Settings.Default.computername;
        


        /*
        command_argument    none = nix
                            app = windows programm
                            cmd = ipconfig (Konsole)
                            564984 = irgendeine ProcessID
                            
                            exit = myEVA schließen

        sollten vielleicht noch  text hinzufügen

        */


        public Form1()
        {
            InitializeComponent();
            db_create();
            timer1.Start();
            notifyIcon1.Visible = true;
            if (user == "none")
            {
                set_user();
                set_computer();
                set_main_commands();
            }

            // abfrage ob die Basisbefehle schon in der Datenbank existieren
            // wenn nicht speichern mit set_basis_commands
            // abrufen mit get_basis_commands ???  Wird eigentlich schon geladen beim Start aus der DB

            //if (!File.Exists("settings.xml"))
            //{
            //    set_settings();
            //}
            //get_settings(computer);
            //MessageBox.Show(cmd_command+"\n" + cmd_answer + cmd_info);
            //get_settings("tab start");
            //MessageBox.Show(cmd_command + "\n" + cmd_answer + cmd_info);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Voice_in_out();
            
            string befehlszeile = "Befehlszeile: \n" + Environment.CommandLine + "\n\n";
            string arbeitsverzeichniss = "Arbeitsverzeichnis: \n" + Environment.CurrentDirectory + "\n\n";

            string computername = "Computer-Name: \n" + Environment.MachineName + "\n\n";
            string benutzername = "Benutzername: \n" + Environment.UserName + "\n\n";

            string betriebssystem_version = "Betriebssystem-Version: \n" + Environment.OSVersion + "\n\n";      // OS-Version ist eine Klasse, über welche weitere 
                                                                                        // Informationen einzeln abgerufen werden können
            string systemverzeichniss = "Systemverzeichnis: \n" + Environment.SystemDirectory + "\n\n";

            string prozessoren_kern_anzahl = "Prozessoren-Kern-Anzahl: \n" + Environment.ProcessorCount + "\n\n";

            string buildnummer = "Buildnummer: \n" + Environment.Version.Build.ToString() + "\n\n";

            //lbl_systeminfo.Text = befehlszeile
            //                    + arbeitsverzeichniss
            //                    + computername
            //                    + benutzername
            //                    + betriebssystem_version
            //                    + buildnummer
            //                    + systemverzeichniss
            //                    + prozessoren_kern_anzahl;




            




        }
        private void Voice_in_out()
        {
            Choices commands = new Choices();

            // Computernamen in die Commandoliste hinzufügen damit er angesprochen werden kann
            commands.Add(computer);
            // Hauptcommandos hinzufügen
            //commands.Add(main_commands);


            // Computernamen in die Befehlliste hinzufügen 
            comboBox_my_commands.Items.Add(computer);
            
            // Hauptcommandos in die Befehlliste hinzufügen 
 /*           foreach (string value in main_commands)
            {
                comboBox_commands.Items.Add(value);
                
            }
 */

            // Commandos aus der Datenbank holen und zu den Command / Befehlsliste hinzufügen
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand("select command from tb_commands;", connection);
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
                while (reader.Read())
                {
                    commands.Add(reader.GetString(reader.GetOrdinal("command")));
                    comboBox_my_commands.Items.Add(reader.GetString(reader.GetOrdinal("command")));
                    //MessageBox.Show(reader.GetString(reader.GetOrdinal("command")));
                }
            connection.Close();




            GrammarBuilder gbuilder = new GrammarBuilder();

            gbuilder.Append(commands);

            Grammar grammar = new Grammar(gbuilder);

            h.LoadGrammar(grammar);

            // Fehler abfangen, falls kein Micro angeschlossen ist
            h.SetInputToDefaultAudioDevice();
            h.SpeechRecognized += recEngine_SpeechRecognized;

            h.RecognizeAsync(RecognizeMode.Multiple);
            s.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);

            s.SpeakAsync("Hallo " + user + " wie kann ich dir helfen?");
        }


        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            

            string speak_command = e.Result.Text;

            db_command_select(speak_command);


            //MessageBox.Show(speak_command);
            //s.SpeakAsync("Du sagtest " + speak_command + "1");
            //s.SpeakAsync("Du sagtest " + speak_command + "2");
            //s.Speak("Du sagtest " + speak_command + "3");

            if (aktiv)
            {
                // ausführen sprich zuhören
                //MessageBox.Show("hört zu");
            }
            else
            {
                if (speak_command == computer)
                {
                    aktiv = true;

                }
                else
                {
                    //MessageBox.Show("Ruhemodus");
                    return;
                }

                
            }



            if (speak_command == "tab start" || speak_command == "tab befehle")
            {
                s.SpeakAsync(db_answer);
                if (speak_command == "tab start")
                {
                    tabControl1.SelectedTab = tabPage1;
                    
                }
                if (speak_command == "tab befehle")
                {
                    tabControl1.SelectedTab = tabPage2;
                    
                }
            }
            else
            {
                //db_command_select(speak_command);
                // in der Datenbank gespeicherte Antwort ansagen lassen bevor das Ergebniss angesagt wird

                // mit command_kill muss ich mir noch was besseres einfallen lassen
                if (command_kill == false)
                {
                    s.SpeakAsync(db_answer);
                }
                

                Command_processing command_Processing = new Command_processing(db_command, db_answer, db_info, db_argument, command_kill);

                command_kill = command_Processing.command_kill;

                if (db_answer != command_Processing.command_answer)
                {
                    s.SpeakAsync(command_Processing.command_answer);
                }

                // Textfelder für Infos füllen und s.speak abrufen
                tb_command_name.Text = command_Processing.command_name;
                tb_command_answer.Text = command_Processing.command_answer;
                tb_command_info.Text = command_Processing.command_info;
                tb_command_argument.Text = command_Processing.command_argument;

                

                switch (command_Processing.command_argument)
                {
                    case "none":
                        break;
                    case "app":
                        //s.Speak("Ich habe das laufende Programm " + command_Processing.command_name + " gefunden und geschlossen");
                        db_command_update(this.tb_command_name.Text, db_answer, this.tb_command_info.Text, this.tb_command_argument.Text);
                        break;
                    case "cmd":                       
                        
                        break;
                    case "normal":
                        Normalisiere_Form1();
                        break;
                    case "minimieren":
                        Minimiere_Form1();
                        break;
                    case "exit":
                        Thread.Sleep(4500);
                        Application.Exit();
                        break;
                    default:
                        // command_Processing.command_argument muss in der Datenbank gespeichert werden wenn nicht none, cmd oder app ist (nochmal prüfen)
                        // Process ID
                        foreach (Process p_all in Process.GetProcesses())
                        {
                            if (p_all.Id == Convert.ToInt32(command_Processing.command_argument))
                            {
                                // ab in die datenbank
                                db_command_update(this.tb_command_name.Text, db_answer, this.tb_command_info.Text, this.tb_command_argument.Text);
                                //s.Speak("Deine Änderungen wurden gespeichert");
                                break;
                            }
                        }
                        break;
                }
            }
            
            
            
            
            
            
        }


        


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {                
                ShowInTaskbar = false;
                
                notifyIcon1.BalloonTipTitle = "myEVA";
                notifyIcon1.BalloonTipText = computer + " wartet im Hintergrund";
                notifyIcon1.ShowBalloonTip(1000);
            }
            else
            {
                ShowInTaskbar = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Normalisiere_Form1();            
        }

        private void Normalisiere_Form1()
        {            
            WindowState = FormWindowState.Normal;
            aktiv = true;
        }

        private void Minimiere_Form1()
        {
            WindowState = FormWindowState.Minimized;
            aktiv = false;
        }






        /// <summary>
        /// erstellt die Datenbanktabellen falls sie noch nicht existieren
        /// </summary>
        private void db_create()
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("create table if not exists {0} (" +
                                                "  ID integer not null primary key autoincrement," +
                                                "  command varchar(100) not null," +
                                                "  answer varchar(100) not null," +
                                                "  info varchar(250) not null," +
                                                "  argument varchar(100) not null)",
                                                "tb_commands");
            command.ExecuteNonQuery();
                        
            connection.Close();
        }

        /// <summary>
        /// Speichert die Kommandos in die Datenbank
        /// </summary>
        /// <param name="table">tb_commands oder tb_memory</param>
        /// <param name="_command"></param>
        /// <param name="_answer"></param>
        /// <param name="_info"></param>
        /// <param name="_argument"></param>
        private void db_command_insert(string _command, string _answer, string _info, string _argument)
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("insert into tb_commands (command, answer, info, argument) values ('{0}','{1}','{2}','{3}')",
                                                _command,
                                                _answer,
                                                _info,
                                                _argument);
            command.ExecuteNonQuery();



            connection.Close();
        }

        private void db_command_update(string _command, string _answer, string _info, string _argument)
        {
            connection.Open();

            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = String.Format("update tb_commands set answer = '{0}', info = '{1}', argument = '{2}'  where command = '{3}';",
                                                _answer,
                                                _info,
                                                _argument,
                                                _command);
            command.ExecuteNonQuery();



            connection.Close();
        }

        private void db_command_select(string search)
        {
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand("select * from tb_commands where command ='" + search + "';", connection);
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    db_command = reader.GetString(reader.GetOrdinal("command"));
                    db_answer = reader.GetString(reader.GetOrdinal("answer"));
                    db_info = reader.GetString(reader.GetOrdinal("info"));
                    db_argument = reader.GetString(reader.GetOrdinal("argument"));
                    //MessageBox.Show(string.Format("{0}, {1}, {2}, {3}", db_command, db_answer, db_info, db_argument));
                }
            }
            else
            {
                db_command = search;    
                db_answer = "";
                db_info = "";
                db_argument = "none";
            }
                      

            connection.Close();
        }




        private void set_user()
        {
            user = Prompt.ShowDialog("Wie soll ich dich nennen?", "Dein Name?");
            Properties.Settings.Default.username = user;
            Properties.Settings.Default.Save();
        }

        private void set_computer()
        {
            computer = Prompt.ShowDialog("Wie willst du mich nennen?", "Siri, Contana, Computer oder sonst ein Name ...");
            Properties.Settings.Default.computername = computer;
            Properties.Settings.Default.Save();
        }


        private void set_main_commands()
        {
            
            ///*
            db_command_insert(  computer, 
                                user + " was kann ich für dich tun", 
                                "Systembefehl, holt die App wieder in den Vordergrund! (Ktivierungsaufruf)",
                                "normal");

            db_command_insert(  "tab start",
                                "ich wechsel auf Start",
                                "Systembefehl, wechsel auf den Tab Start!",
                                "none");
            db_command_insert(  "tab befehle",
                                "ich wechsle auf Befehle",
                                "Systembefehl, wechsel auf den Tab Befehle!",
                                "none");
            db_command_insert(  "bereitschaft",
                                "Bis gleich!",
                                "Systembefehl, schickt die App in den Hintergrund und führt keine Befehle mehr aus (außer dem Aktivierungsaufruf)!",
                                "minimieren");
            db_command_insert(  "Programm beenden",
                                "Welches Programm soll ich beenden?",
                                "Systembefehl, zum beenden von Programmen!",
                                "none");
            db_command_insert(  "Datum",
                                "",
                                "Systembefehl, sagt das aktuelle Datum.",
                                "none");
            db_command_insert(  "Zeit",
                                "",
                                "Systembefehl, sagt die aktuelle Uhrzeit an.",
                                "none");
            db_command_insert(  "Vorlesen",
                                "",
                                "Systembefehl, liest den Text aus der Zwischenablage vor.",
                                "none");
            db_command_insert(  "schalte dich aus",
                                "ok " + user + ", dann bis zu nächsten mal",
                                "Systembefehl, schließt die App MyEVA.",
                                "exit");
            //*/

            
        }

        private void get_settings(string read)
        {
            
            

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToLongTimeString();
            lbl_date.Text = DateTime.Now.ToLongDateString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_my_commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_my_commands.SelectedIndex != -1)
            {
                string curItem = comboBox_my_commands.SelectedItem.ToString();
                db_command_select(curItem);

                this.btn_command_save.Visible = true;
                this.btn_delete.Visible = true;
                
                tb_command_name.Text = db_command;
                tb_command_answer.Text = db_answer;
                tb_command_info.Text = db_info;
                tb_command_argument.Text = db_argument;

            }
        }

        //private void comboBox_commands_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox_my_commands.SelectedIndex != -1)
        //    {
        //        string curItem = comboBox_my_commands.SelectedItem.ToString();                
        //        db_command_select(curItem);                               

        //        foreach (string value in main_commands)
        //        {
        //            if (value == curItem)
        //            {
        //                this.btn_command_save.Visible = false;
        //                this.btn_delete.Visible = false;                        
        //            }
        //        }

        //        tb_command_name.Text = db_command;
        //        tb_command_answer.Text = db_answer;
        //        tb_command_info.Text = db_info;
        //        tb_command_argument.Text = db_argument;

        //    }
        //}

        private void btn_command_save_Click(object sender, EventArgs e)
        {
            if (tb_command_argument.Text == "")
            {
                this.tb_command_argument.Text = "none";
            }
            for (int i = 0; i <= comboBox_my_commands.Items.Count - 1; i++)
            {


                if (comboBox_my_commands.Items[i].ToString() == tb_command_name.Text)
                {
                    
                    s.SpeakAsync(comboBox_my_commands.Items[i].ToString() + " habe ich schon als Befehl in meiner Datenbank. Wenn ich die Änderungen speichern soll, dann klicke bitte auf ja.");
                    //MessageBox.Show(comboBox_commands.Items[i].ToString() + " habe ich schon als Befehl in meiner Datenbank");

                    string message = '"' + comboBox_my_commands.Items[i].ToString() + '"' + " habe ich schon als Befehl in meiner Datenbank! /nUpdate ausführen?";
                    string caption = "Befehl updaten?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(this, message, caption, buttons);

                    if (result == DialogResult.Yes)
                    {
                        db_command_update(this.tb_command_name.Text, this.tb_command_answer.Text, this.tb_command_info.Text, this.tb_command_argument.Text);
                        s.Speak("Deine Änderungen wurden gespeichert");


                    }
                    else
                    {
                        s.SpeakAsync("OK, es wurde nichts verändert.");
                    }


                }
            }

            db_command_insert(this.tb_command_name.Text, this.tb_command_answer.Text, this.tb_command_info.Text, this.tb_command_argument.Text);

            s.Speak("gespeichert, ich muss mich jetzt neustarten, damit der neue Befehl verfügbar ist");
            //Thread.Sleep(55000);
            Application.Restart();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (comboBox_my_commands.SelectedIndex != -1)
            {
                string curItem = comboBox_my_commands.SelectedItem.ToString();

                this.btn_delete.Visible = true;

                foreach (string value in main_commands)
                {
                    if (value == curItem)
                    {
                        // Systembefehl, kann nicht gelöscht werden
                    }
                    else
                    {
                        if (curItem == tb_command_name.Text)
                        {


                            s.SpeakAsync(curItem + " aus meiner Datenbank löschen? ");


                            string message = '"' + curItem + '"' + " aus meiner Datenbank löschen? Wenn ich das wirklich machen soll, dann klicke bitte auf ja.";
                            string caption = "Befehl updaten?";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            result = MessageBox.Show(this, message, caption, buttons);

                            if (result == DialogResult.Yes)
                            {
                                connection.Open();

                                SQLiteCommand command = new SQLiteCommand("delete from tb_commands where command ='" + curItem + "';", connection);
                                command.ExecuteNonQuery();

                                //Command_info();

                                connection.Close();
                                //s.SpeakAsync("Der Befehl "+ curItem+" wurde aus der Datenbank gelöscht.");
                                s.Speak("Der Befehl " + curItem + " wurde aus der Datenbank gelöscht.");
                                //Thread.Sleep(4500);
                                s.Speak("ich muss mich jetzt neustarten, damit der alte Befehl aus dem System raus ist");
                                //Thread.Sleep(5000);
                                Application.Restart();


                            }
                            else
                            {
                                s.SpeakAsync("OK, es wurde nichts gelöscht.");
                            }

                            return;
                        }
                        else
                        {
                            s.SpeakAsync("Dieser Befehl stimmt nicht mit der Befehlsliste überein. Bitte neu auswählen.");
                        }
                    }
                }




            }
        }

        private void btn_clear_textboxen_Click(object sender, EventArgs e)
        {
            tb_command_name.Text = "";
            tb_command_answer.Text = "";
            tb_command_info.Text = "";
            tb_command_argument.Text = "";
            this.btn_command_save.Visible = true;
            this.btn_delete.Visible = true;
        }
    }
}
