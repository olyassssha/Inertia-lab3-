using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Inertia__new_
{
    public partial class Inertia : Form
    {
        public static PictureBox[,] pictureBoxes;
        public Inertia()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer1.Interval = 1000;
            timer2.Interval = 1000;
            GenerateMap();
           //Play();
            this.KeyDown += new KeyEventHandler(KeyIsUp);
        }

         Level_3 level = new Level_3();
         Player player = new Player();
        

        static void Play()
        {
            SoundPlayer music = new SoundPlayer(@"../../../../Fear.wav");
            music.PlayLooping();
        }
        public void GenerateMap()
        { 
            player.MakeMap(level);
            pictureBoxes = new PictureBox[Field.height, Field.width];
            for (int i = 0; i < Field.height; i++)
            {
                for (int j = 0; j < Field.width; j++)
                {
                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Location = new Point(60 * j, i * 60);
                    pictureBoxes[i, j].Size = new Size(54, 36);

                    Field.Elements[i, j].MakeMapPicturesBoxes(i, j);
                    this.Controls.Add(pictureBoxes[i, j]);
                }
              
            }
            label1.Location = new Point(label1.Location.X, label1.Location.Y + 300);
            label2.Location = new Point(label2.Location.X, label2.Location.Y + 300);
            label3.Location = new Point(label3.Location.X, label3.Location.Y + 300);
            label4.Location = new Point(label4.Location.X, label4.Location.Y + 300);
            label5.Location = new Point(label5.Location.X, label5.Location.Y + 300);
            label6.Location = new Point(label6.Location.X, label6.Location.Y + 300);
            label7.Location = new Point(label7.Location.X, label7.Location.Y + 300);
            label8.Location = new Point(label8.Location.X, label8.Location.Y + 300);
            label9.Location = new Point(label9.Location.X, label9.Location.Y + 300);
            label10.Location = new Point(label10.Location.X, label10.Location.Y + 300);
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                player.Logic(-1, 0);
            }
            if (e.KeyCode == Keys.Down)
            {
                player.Logic(1, 0);
            }
            if (e.KeyCode == Keys.Left)
            {
                player.Logic(0, -1);
            }
            if (e.KeyCode == Keys.Right)
            {
                player.Logic(0, 1);
            }
            if (e.KeyCode == Keys.D)
            {
                player.Logic(-1, 1);

            }
            if (e.KeyCode == Keys.F)
            {
                player.Logic(1, -1);
            }
            if (e.KeyCode == Keys.G)
            {
                player.Logic(-1, -1);
            }
            if (e.KeyCode == Keys.H)
            {
                player.Logic(1, 1);
            }

        }

        public bool CheckLives()
        {
            if (Element.lives <= 0)
            {
                Controls.Clear();
                Label label = new Label(); PictureBox lose = new PictureBox();
                lose.Image = Image.FromFile(@"../../../pictures/lose2.jpg");
                lose.Location = new Point(222, 200);
                lose.Size = new Size(500, 600);
                lose.SizeMode = PictureBoxSizeMode.Zoom;
                label.Text = "YOU LOSE(   " + $"YOUR SCORE:  {Element.score}";
                label.AutoSize = true;
                label.Location = new Point(222, 90);
                label.Font = new Font("Calibri", 18);
                label.Padding = new Padding(20);
                label.Visible = true;
                label.BackColor = Color.AliceBlue;
                Controls.Add(label);
                Controls.Add(label); Controls.Add(lose);
                timer1.Enabled = false; timer2.Enabled = false;
                return true;
            }
            return false;
        }
        private void BlockInformation_Tick(object sender, EventArgs e)
        {
            if (CheckLives()) { timer1.Enabled = false; timer2.Enabled = false; }
            label2.AutoSize = true;
            label2.Text = $"{Element.score}";

            label4.AutoSize = true;
            label4.Text = $"{Element.steps}";

            label6.AutoSize = true;
            label6.Text = $"{Element.lives}";

            label7.AutoSize = true;
            label7.Text = $"{ Element.X}";

            label9.AutoSize = true;
            label9 .Text = $"{ Element.Y}";

            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label6);
        }
        bool CheckScore()
        {
            if(Element.score >= 15)
            {
                Controls.Clear();
                PictureBox win = new PictureBox();
                win.Image = Image.FromFile(@"../../../pictures/win.jpg");
                win.Location = new Point(222,250);
                win.Size = new Size(500, 600);
                win.SizeMode = PictureBoxSizeMode.Zoom;
                Label label = new Label();
                label.Text = "YOU WIN!   " + $"YOUR SCORE:  {Element.score}";
                label.AutoSize = true;
                label.Location = new Point(222, 90);
                label.Font = new Font("Calibri", 18);
                label.Padding = new Padding(20);
                label.Visible = true;
                label.BackColor = Color.AliceBlue;
                Controls.Add(label); Controls.Add(win);
                return true;
            }
            return false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CheckScore()) { timer1.Enabled = false; }
        }

        private void Inertia_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (DialogResult.Yes == MessageBox.Show("Вы хотите закончить работу с программой?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) e.Cancel = false;
        }
    }

    
}
