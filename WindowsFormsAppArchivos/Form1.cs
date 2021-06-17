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

namespace WindowsFormsAppArchivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string path = fbd.SelectedPath;
            if (path != "")
                textBox1.Text = GetFiles(path);
            else
                MessageBox.Show("No seleccionó ningún directorio");
        }

        public static string GetFiles(string path)
        {
            string str = "";

            DirectoryInfo dir = new DirectoryInfo(path);
//            FileInfo[] archivos = dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileSystemInfo f in dir.GetFileSystemInfos())
            {
                if(f is FileInfo)
                    {
                        FileInfo j = f as FileInfo;
                        str += "" + f.Name + " - " + j.Length + "\r\n";
                }
                else
                {
                    str += "\\" + f.Name + "\r\n";
                }

            }
            return str;
        }
    }
}
