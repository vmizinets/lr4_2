using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Owner = this;
            fr1.Show();
            Form2 fr2 = new Form2();
            fr2.Owner = this;
            this.Hide();
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Owner = this;
            fr3.Show();
            Form2 fr2 = new Form2();
            fr2.Owner = this;
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.Owner = this;
            fr4.Show();
            Form2 fr2 = new Form2();
            fr2.Owner = this;
            this.Hide();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.Owner = this;
            fr5.Show();
            Form2 fr2 = new Form2();
            fr2.Owner = this;
            this.Hide();
        }

    }
}
