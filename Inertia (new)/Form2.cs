﻿using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Inertia__new_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

        }

        Inertia inertia = new Inertia();
        Label label = new Label();
        Label label2 = new Label();
        private void Instruction_Click(object sender, EventArgs e)
        {
            this.Close();
           Application.OpenForms[0].Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            inertia.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
     
            button3.BackColor = Color.Red;
            label2.Name = "move";
            label2.Location = new Point(button3.Location.X + 80, button3.Location.Y + 60);
            label2.AutoSize = true;
            label2.Text = "Игрок двигается по инерции \n" + "До клетки остановки, ловушки или забора \n"+ "только после этого вы можете поменять направление \n"+
                "Используте курсорные клавиши для движения \n" + "Такжк игрок может двигаться по диагонали: D(вверх, право), F(вниз, вправо), \n G(вверх, налево), H(вниз, налево)";
            label2.Font = new Font("Calibri", 12);
            label2.Show();
            Controls.Add(label2);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
            label.Hide();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
            label2.Hide();
        }
    }


    
}