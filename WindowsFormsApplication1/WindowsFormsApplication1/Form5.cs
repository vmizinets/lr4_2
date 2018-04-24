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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Owner = this;
            fr2.Show();
            Form5 fr5 = new Form5();
            fr5.Owner = this;
            this.Hide();
        }
    }
}
