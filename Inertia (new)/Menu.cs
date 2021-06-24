using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Inertia__new_
{
    public partial class Menu : Form
    {
        public Menu()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

        }

       
        Label informationLabel = new Label();
        Label rulesLabel = new Label();
       
        private void Information_Hover(object sender, EventArgs e)
        {
            information.BackColor = Color.Red;
            informationLabel.Location = new Point(information.Location.X + 80, information.Location.Y + 60);
            informationLabel.AutoSize = true;
            informationLabel.Text = "Операционная система: Windows 7, 32 бит \n" +
                         "Оперативная память: 130 Кб \n" +
                         "Необходимое место на диске: 6 Мб";
            informationLabel.Font = new Font("Calibri", 12);
            informationLabel.Show();
            Controls.Add(informationLabel);
        }
        private void Information_MouseLeave(object sender, EventArgs e)
        {
            information.BackColor = Color.Transparent;
            informationLabel.Hide();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            level1.Visible = true;
            level2.Visible = true;
            level3.Visible = true;

        }
      
        private void Rules_Hover(object sender, EventArgs e)
        {
     
            rules.BackColor = Color.Red;
            rulesLabel.Name = "move";
            rulesLabel.Location = new Point(rules.Location.X + 80, rules.Location.Y + 60);
            rulesLabel.AutoSize = true;
            rulesLabel.Text = "Игрок двигается по инерции \n" + "До клетки остановки, ловушки или забора \n"+ "только после этого вы можете поменять направление \n"+
                "Используте курсорные клавиши для движения \n" + "Такжк игрок может двигаться по диагонали: D(вверх, право), F(вниз, вправо), \n G(вверх, налево), H(вниз, налево)";
            rulesLabel.Font = new Font("Calibri", 12);
            rulesLabel.Show();
            Controls.Add(rulesLabel);
        }
        private void Rules_MouseLeave(object sender, EventArgs e)
        {
            rules.BackColor = Color.Transparent;
            rulesLabel.Hide();
        }

        private void level1_Click(object sender, EventArgs e)
        {
            Inertia inertia = new Inertia(1);
            this.Hide();
            inertia.Show();
        }

        private void level2_Click(object sender, EventArgs e)
        {
            Inertia inertia = new Inertia(2);
            this.Hide();
            inertia.Show();
        }
        private void level3_Click(object sender, EventArgs e)
        {
            Inertia inertia = new Inertia(3);
            this.Hide();
            inertia.Show();
        }
    }


    
}
