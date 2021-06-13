using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Inertia__new_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
       
       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           Application.OpenForms[0].Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }


    
}
