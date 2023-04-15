using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCompair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> inFile1 = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            List<string> rez = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            richTextBox1.AppendText("В файле №1(" + openFileDialog.FileName + ") - " + inFile1.Count.ToString() + " строк" + Environment.NewLine);
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> inFile2 = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            richTextBox1.AppendText("В файле №2(" + openFileDialog.FileName + ") - " + inFile2.Count.ToString() + " строк" + Environment.NewLine);
            foreach (var item1 in inFile1)
            {
                string s1 = item1.Split('|')[0];
                if (s1.Contains(":"))
                {
                    s1 = s1.Split(':')[0];
                }
                else
                {
                    s1 = s1.Split(';')[0];
                }
                foreach (var item2 in inFile2)
                {
                    string s2 = item2.Split('|')[0];
                    if (s2.Contains(":"))
                    {
                        s2 = s2.Split(':')[0];
                    }
                    else
                    {
                        s2 = s2.Split(';')[0];
                    }
                    if (s1 == s2)
                    {
                        rez.Remove(item1);
                    }
                }
            }
            File.WriteAllLines("F1-F2.txt", rez);
            richTextBox1.AppendText("В файле результате - " + rez.Count.ToString() + " строк" + Environment.NewLine);
            richTextBox1.AppendText("Готово" + Environment.NewLine);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> inFile1 = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            List<string> rez = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            richTextBox1.AppendText("В файле №1(" + openFileDialog.FileName + ") - " + inFile1.Count.ToString() + " строк" + Environment.NewLine);
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> inFile2 = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            richTextBox1.AppendText("В файле №2(" + openFileDialog.FileName + ") - " + inFile2.Count.ToString() + " строк" + Environment.NewLine);
            foreach (var item1 in inFile1)
            {
                foreach (var item2 in inFile2)
                {
                    if (item1.Contains(item2))
                    {
                        rez.Remove(item1);
                    }
                }
            }
            File.WriteAllLines("F1-F2.txt", rez);
            richTextBox1.AppendText("В файле результате - " + rez.Count.ToString() + " строк" + Environment.NewLine);
            richTextBox1.AppendText("Готово" + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> inFile1 = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            List<string> rez = new List<string>();
            foreach (var item in inFile1)
            {
                int count = item.Split('|').Length;
                if (!string.IsNullOrEmpty(item.Split('|')[count-1]))
                {
                    rez.Add(item);
                }
            }
            File.WriteAllLines("onlyFullFormat.txt", rez);
            richTextBox1.AppendText("Готово" + Environment.NewLine);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> inFile1 = new List<string>(File.ReadAllLines(openFileDialog.FileName));
            List<string> rez = new List<string>();
            foreach (var item in inFile1)
            {
                int count = item.Split('|').Length-1;
                rez.Add(item.Split('|')[0]+"|"+ item.Split('|')[1] + "|" + item.Split('|')[2] + "|" + item.Split('|')[4] + "|" + item.Split('|')[5] + "|" + item.Split('|')[count-1] + "|" + item.Split('|')[count] );
            }
            File.WriteAllLines("toShop.txt", rez);
            richTextBox1.AppendText("Готово" + Environment.NewLine);
        }
    }
}
