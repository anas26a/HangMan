using System;
using System.Windows.Forms;

namespace Hangman
{
    public partial class WordList : Form
    {
        public static string path;
        public WordList()
        {
            InitializeComponent();
        }

        private void WordList_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                path = opd.FileName;
                textBox1.Text = path;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
               
        }
    }
}
