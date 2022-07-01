using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace Pass
{
    public partial class Form1 : Form
    {
        public int MaxLength = 67;
        private int MinLength = 1;
        private int LengthPassword;
        private static string DefPath = @"C:\Test\";
        private static string path = @"C:\Test\ahp.txt";
        public static string pathToSave = @"C:\Test\PasswordSeva.txt";
        private string[] Ble = { };
        private List<string> Pass = new List<string>();
        private int Rand;
        private Random Random = new Random();

        public Form1()
        {
            InitializeComponent();
            Refres();
            DeleteRows();
            //check dir is exists if not create 
            if (Directory.Exists(DefPath))
                return;
            else
                Directory.CreateDirectory(DefPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(LengthPassword == 0)
            {
                // check length 
                MessageBox.Show("Eneter Length");
            }
            else
            {
                NP();
                Refres();
            }
        }

        private void NP()
        {
            if (!File.Exists(path))
            {
                //create file 
                string[] TextInFile = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                    "a","b","c","d","e","f","g","h","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                "-","_","=","+",";",":","[","]","{","}","(",")","If","KJ","2137","420","!","@","#","$",">","<","PgDn","HomeEnd","ScrLk","PoLLoP"};
                File.WriteAllLines(path, TextInFile);
                File.WriteAllLines(pathToSave,Ble);
                NP();
            }
            else
            {
                //download text from file 
                string[] Text = File.ReadAllLines(path);
                List<string> InFile = new List<string>();
                
                for (int i = 0; i < LengthPassword; i++)
                {
                    Rand = Random.Next(MinLength, MaxLength);
                    InFile.Add(Text[Rand]);
                }
                string Password = string.Join("",InFile.ToArray());
                Pass.Add(Password);
                
                CfileToSavePass(Pass);
            }
        }
        private void CfileToSavePass(List<string> strings)
        {
            File.WriteAllLines(pathToSave, strings);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reset all file 
            File.Delete(path);
            File.Delete(pathToSave);
            string[] TextInFile = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                    "a","b","c","d","e","f","g","h","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
                "-","_","=","+",";",":","[","]","{","}","(",")","!","@","#","$",">","<","&"};
            File.WriteAllLines(path, TextInFile);
            File.WriteAllLines(pathToSave, Ble);
            Pass.Clear();
            Refres();
        }
        private void Refres()
        {
            if(File.Exists(path))
            foreach (var item in File.ReadAllLines(pathToSave))
            {
                    
                dataGridView1.Rows.Add(item);
            }
        }
        private void DeleteRows()
        {
            dataGridView1.Rows.Clear();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LengthPassword = int.Parse(textBox1.Text);
        }
    }
}