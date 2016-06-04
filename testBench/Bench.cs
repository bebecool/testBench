using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Net.Mail;

namespace testBench
{
    public partial class Bench : Form
    {
        private static string Chemin = System.Windows.Forms.Application.StartupPath;
        string CodeSource = "";

        public Bench()
        {
            InitializeComponent();

            //Creation dossier Brouillon
            if (!File.Exists(Chemin + @"\CodeSource.txt"))
            {
                File.WriteAllText(Chemin + @"\CodeSource.txt", String.Empty);
            }

            CodeSource = File.ReadAllText(Chemin + @"\CodeSource.txt", Encoding.UTF8);
        }

        private TimeSpan TimeTestMin = TimeSpan.FromSeconds(10);
        private TimeSpan TimeTestMax;
        private Boolean first = false;

        public string Replacement(string WordS, string WordFind, string WordReplace)
        {
            return Regex.Replace(WordS, WordFind, WordReplace, RegexOptions.IgnoreCase);
        }

        private List<EmailCSV> MaListCreateEmailCSV = new List<EmailCSV>();
        private List<EmailCSV> MaListTargetEmailCSV = new List<EmailCSV>();
        public class EmailCSV
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string Quota { get; set; }
            public EmailCSV(
                string EmailS,
                string PasswordS,
                string QuotaS)
            {
                this.Email = EmailS;
                this.Password = PasswordS;
                this.Quota = QuotaS;
            }
        }

        private readonly Random Random = new Random();
        private const string Letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private char[] Separator = { '.', '-', '_' };
        private int NbrLetter = 9;
        private int Nbrchiffre = 0;
        private int NbrSeparator = 0;

        private void ButtonLancer_Click(object sender, EventArgs e)
        {
            //1318 = 1818

            int index = 0;
            Boolean booltest = false;
            Stopwatch sw = new Stopwatch();
            string Mot = "class=\"lst icon\"";

            sw.Start();

           
            //booltest = CodeSource.IndexOf(Mot, StringComparison.Ordinal) >= 0; 
            //booltest = CodeSource.IndexOf(Mot, StringComparison.OrdinalIgnoreCase) >= 0; 
            //booltest = Mot.Any(s => CodeSource.Contains(s));
            //booltest = CodeSource.Contains(Mot);
            //booltest = Regex.IsMatch(CodeSource, Mot);
            //index = CodeSource.IndexOf(Mot);
            //index = Regex.Matches(CodeSource, Mot).Count;
            //index = (CodeSource.Length - CodeSource.Replace(Mot, String.Empty).Length) / Mot.Length;

            string keytmp = "";
            do{
                keytmp += Char.ToUpper(Letter[Random.Next(Letter.Length)]);
            }while(keytmp.Length < 10);

            MessageBox.Show(keytmp);

            string CreateMail = @"C:\Users\EASYDEALS\Desktop\create[" + DateTime.Now.ToString("MM-dd-yyyy_h-mm-tt") + "].csv";
            string RedirectMail = @"C:\Users\EASYDEALS\Desktop\Redirect[" + DateTime.Now.ToString("MM-dd-yyyy_h-mm-tt") + "].csv";

                MaListCreateEmailCSV.Add(new EmailCSV("Email", "Password", "Quota"));
                MaListTargetEmailCSV.Add(new EmailCSV("Source", "Target", ""));

                NbrLetter = Random.Next(9, 15); // creates a number between 1 to 9
                NbrSeparator = Random.Next(1, 2); 
                Nbrchiffre = Random.Next(1, 2); 
               
                char[] EmailRandom;
                string EmailRandomfinal = "";
                List<int> ListEmpChange = new List<int>();
                int Emp = 0;
                
                //Debut Creation Tant qu'il existe
                do
                {
                    do
                    {

                        EmailRandom = new char[NbrLetter];
                        ListEmpChange = new List<int>();

                        //Creation Lettre
                        for (int i = 0; i < NbrLetter; i++)
                        {
                            EmailRandom[i] = (Convert.ToBoolean(Random.Next() % 2) ? Char.ToUpper(Letter[Random.Next(Letter.Length)]) : Char.ToLower(Letter[Random.Next(Letter.Length)]));
                        }

                        //Ajout Separator
                        for (int j = 0; j < NbrSeparator; j++)
                        {
                            do
                            {
                                Emp = Random.Next(2, NbrLetter - 1);
                            } while (ListEmpChange.Contains(Emp));
                            ListEmpChange.Add(Emp);

                            //Remplacement Lettre
                            EmailRandom[Emp] = Separator[Random.Next(Separator.Length)];
                        }

                        EmailRandomfinal = new string(EmailRandom);
                        for (int k = 0; k < Nbrchiffre; k++)
                        {
                            do
                            {
                                Emp = Random.Next(2, NbrLetter);
                            } while (ListEmpChange.Contains(Emp));
                            ListEmpChange.Add(Emp);

                            //Remplacement Lettre
                            EmailRandomfinal = EmailRandomfinal.Replace(EmailRandomfinal[Emp].ToString(), Random.Next(1, 9).ToString());
                        }

                    } while (EmailRandom.Length != NbrLetter);

                    MaListCreateEmailCSV.Add(new EmailCSV(EmailRandomfinal + "@customerbuyer.com", "buy76", "10"));
                    MaListTargetEmailCSV.Add(new EmailCSV(EmailRandomfinal + "@customerbuyer.com", "easybuy76@gmail.com", ""));

                } while (MaListCreateEmailCSV.Count < 100);

                StringBuilder CreateMailLigne = new StringBuilder();
                StringBuilder RedirectMailLigne = new StringBuilder();
                foreach (EmailCSV MyEmailCSV in MaListCreateEmailCSV)
                {
                    CreateMailLigne.AppendLine(MyEmailCSV.Email + "," + MyEmailCSV.Password + "," + MyEmailCSV.Quota);
                }


                foreach (EmailCSV MyEmailCSV in MaListTargetEmailCSV)
                {
                    RedirectMailLigne.AppendLine(MyEmailCSV.Email + "," + MyEmailCSV.Password);
                }

                File.WriteAllText(CreateMail, CreateMailLigne.ToString());
                File.WriteAllText(RedirectMail, RedirectMailLigne.ToString());
            

            sw.Stop();
            //labelBoolTest.Text = booltest.ToString();
            labelBoolTest.Text = index.ToString();
            if (first && sw.Elapsed < TimeTestMin) { TimeTestMin = sw.Elapsed; }
            if (first && sw.Elapsed > TimeTestMax) { TimeTestMax = sw.Elapsed; }

            TimeMin.Text = TimeTestMin.ToString();
            TimeMax.Text = TimeTestMax.ToString();
            LabelTime.Text = sw.Elapsed.ToString();

            first = true;
        }

        private void Bench_Load(object sender, EventArgs e)
        {

        }

        private string retrieveBetween(string input, string before, string after, int index)
        {
            try
            {
                string firstSplit = input.Split(new string[] { before }, StringSplitOptions.None)[index + 1];
                return firstSplit.Remove(firstSplit.IndexOf(after));
            }
            catch (Exception ex) { MessageBox.Show("Erreur Fournisseur Option retrieveBetween, ex : " + ex + "\n before : " + before + " \n after : " + after + "\n index : " + index + " \n Input : " + input); }
            return "";
        }

    }
}
