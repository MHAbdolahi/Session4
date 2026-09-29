using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int a = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            a++;
            label1.Text = a.ToString();
            
        }
    }
}
