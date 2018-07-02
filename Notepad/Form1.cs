using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                

                    saveFileDialog1.ShowDialog();
                    String path = saveFileDialog1.FileName;
                    FileStream sav = new FileStream(path, FileMode.Create, FileAccess.Write);
                    StreamWriter write = new StreamWriter(sav);
                    string text = richTextBox1.Text;
                    write.Write(text);
                    write.Flush();
                    write.Close();
                    sav.Close();
                    MessageBox.Show("Successfully Saved");


               
            }
            catch(NoNullAllowedException ex)
            {
                string epath = @"Z:\error.txt";
                FileStream esav = new FileStream(epath, FileMode.Append, FileAccess.Write);
                StreamWriter write = new StreamWriter(esav);
                write.Write(ex.ToString() + "\n \n");
                write.Flush();
                write.Close();
                esav.Close();
                MessageBox.Show("Empty Path");
            }

        }

        private void open_Click(object sender, EventArgs e)
        {

            try
            {
                openFileDialog1.ShowDialog();
                String path = openFileDialog1.FileName;
                StreamReader read = new StreamReader(path);
                string data = read.ReadToEnd();
                richTextBox1.Text = data;
                read.Close();
            }
            catch(Exception ex)
            {
                string epath = @"Z:\error.txt";
                FileStream esav = new FileStream(epath, FileMode.Append, FileAccess.Write);
                StreamWriter write = new StreamWriter(esav);
                write.Write(ex.ToString() + "\n");
                write.Flush();
                write.Close();
                esav.Close();
                MessageBox.Show("Empty Path");
            }
}

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
