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

namespace Hangman
{
    public partial class Form1 : Form
    {
        
        int i = 0;
        string file;
        string target;
        char guess;
        int tries;
        bool hit = false;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
            WordList wl = new WordList();
            if (wl.ShowDialog() == DialogResult.OK)
                file = WordList.path;
            
            
            StreamReader sr = new StreamReader(file);
            while (sr.ReadLine() != null)
                i++;
            sr.Dispose();
            sr = new StreamReader(file);
            Random r = new Random();
            
            for (int k = 0; k < r.Next(1, i-1); k++)
                target = sr.ReadLine();
            sr.Dispose();
            MessageBox.Show(target);
            Setting();
            
        }

        private void Setting()
        {
            label5.Text = "";
            for (i = 0; i < target.Length; i++)
                label5.Text = label5.Text.Insert(i, "*");
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            guess = textBox2.Text[0];

            for (i=0;i<target.Length;i++)
            {
                if (Char.ToUpper(target[i]) == Char.ToUpper(guess))
                {
                    hit = true;
                    label5.Text = label5.Text.Remove(i, 1);
                    label5.Text = label5.Text.Insert(i, guess.ToString());
                }
            }
            if (label5.Text.ToUpper() == target.ToUpper())
                WonGame();
            if (!hit)
            {
                tries++;
                
                //textBox1.Text = textBox1.Text.Insert(0, " , " +  guess.ToString());
                guess = textBox2.Text[0];
            }
            hit = false;
           
                switch (tries)
                {
                    
                    case 1:
                        pictureBox1.Image = Hangman.Properties.Resources._1;
                    textBox1.Text = textBox1.Text.Insert(0, " , " +  guess.ToString());
                    guess = textBox2.Text[0];
                    break;
                    case 2:
                        pictureBox1.Image = Hangman.Properties.Resources._2;
                    textBox1.Text = textBox1.Text.Insert(0, " , " + guess.ToString());
                    guess = textBox2.Text[0];
                    break;
                    case 3:
                        pictureBox1.Image = Hangman.Properties.Resources._3;
                    textBox1.Text = textBox1.Text.Insert(0, " , " + guess.ToString());
                    guess = textBox2.Text[0];
                    break;
                    case 4:
                        pictureBox1.Image = Hangman.Properties.Resources._4;
                    textBox1.Text = textBox1.Text.Insert(0, " , " + guess.ToString());
                    guess = textBox2.Text[0];
                    break;
                    case 5:
                        pictureBox1.Image = Hangman.Properties.Resources._5;
                        textBox1.Text = textBox1.Text.Insert(0, " , " + guess.ToString());
                        guess = textBox2.Text[0];
                    break;
                    case 6:
                        pictureBox1.Image = Hangman.Properties.Resources._6;
                        textBox1.Text = textBox1.Text.Insert(0, " , " + guess.ToString());
                        guess = textBox2.Text[0];
                    break;
                    case 7:
                        pictureBox1.Image = Hangman.Properties.Resources._7;
                        textBox1.Text = textBox1.Text.Insert(0, " . " + guess.ToString());
                        guess = textBox2.Text[0];
                        LostGame();
                    break;
                        
            }
            
            textBox2.Focus();
            textBox2.SelectAll();
        }
        
        private void WordList_Reader()
        {
            WordList wl = new WordList();
            WordList.path = "WordList.txt";
            file = WordList.path;
            StreamReader sr = new StreamReader(file);
            while (sr.ReadLine() != null)
                i++;
            sr.Dispose();
            sr = new StreamReader(file);
            Random r = new Random();

            for (int k = 0; k < r.Next(1, i - 1); k++)
                target = sr.ReadLine();
            sr.Dispose();
            //MessageBox.Show(target);                          //Shows the word randomly selected (Just for a try!)
            Setting();
        }
        
        
        private void StartGame()
        {
            WordList_Reader();
            pictureBox1.Image = Hangman.Properties.Resources._0;
            
        }

        private void LostGame()
        {
            MessageBox.Show("You lost! Secret word was " + target);
            ResetGame();
        }
        private void WonGame()
        {
            MessageBox.Show("You won! Secret word was " + target);
            ResetGame();
        }

        private void ResetGame()
        {

           
            textBox2.Text = "";
            label5.Text = "Word to guess";
            target = "";
            tries = 0;
            pictureBox1.Image = Hangman.Properties.Resources._0;
            textBox1.Text = "";
            Setting();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

      
    }
}
