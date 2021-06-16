using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Inertia__new_
{
    public partial class Inertia : Form
    {
        public string direction;
      
        int uselessX;
        int uselessY;

        int X;
        int Y;

        protected PictureBox[,] pictureBoxes;

        int score;
        int steps;
        int lives = 10;

        public Inertia()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer1.Interval = 1000;
            timer2.Interval = 1000;

            GenerateMap();
            //Play();
            this.KeyDown += new KeyEventHandler(KeyIsUp);


        }
        Level_1 level = new Level_1();

        public Player playerOnThemap = new Player();

        static void Play()
        {
            SoundPlayer music = new SoundPlayer(@"../../../../Fear.wav");
            music.PlayLooping();
        }
        public void GenerateMap()
        {
            playerOnThemap.MakeMap(level);
            pictureBoxes = new PictureBox[level.height, level.width];

            for (int i = 0; i < level.height; i++)
            {
                for (int j = 0; j < level.width; j++)
                {
                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Location = new Point(60 * j, i * 60);
                    pictureBoxes[i, j].Size = new Size(54, 36);

                    if (level.arrayOfObjects[i, j].GetType() == typeof(Trap))
                    {
                        pictureBoxes[i, j].Tag = "trap";
                        pictureBoxes[i, j].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Barrier))
                    {
                        pictureBoxes[i, j].Tag = "barrier";
                        pictureBoxes[i, j].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Station))
                    {
                        pictureBoxes[i, j].Tag = "station";
                        pictureBoxes[i, j].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Coins))
                    {
                        pictureBoxes[i, j].Tag = "coins";
                        pictureBoxes[i, j].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Space))
                    {
                        pictureBoxes[i, j].Tag = "space";

                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Player))
                    {
                        pictureBoxes[i, j].Name = "player";
                        pictureBoxes[i, j].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                        uselessX = i;
                        uselessY = j;
                        X = i;
                        Y = j;
                    }

                    this.Controls.Add(pictureBoxes[i, j]);

                }
            }

        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                direction = "Up";
                ChangeCoordinates();
            }
            if (e.KeyCode == Keys.Down)
            {
                direction = "Down";
                ChangeCoordinates();
            }
            if (e.KeyCode == Keys.Left)
            {
                direction = "Left";
                ChangeCoordinates();
            }
            if (e.KeyCode == Keys.Right)
            {
                direction = "Right";
                ChangeCoordinates();
            }
            if (e.KeyCode == Keys.D)
            {
                direction = "DiagonalUpRight";
                ChangeCoordinates();
            }
            if (e.KeyCode == Keys.F)
            {
                direction = "DiagonalDownRight";
                ChangeCoordinates();
            }
            if (e.KeyCode == Keys.G)
            {
                direction = "DiagonalUpLeft";
                ChangeCoordinates();
            }
            if (e.KeyCode == Keys.H)
            {
                direction = "DiagonalDownLeft";
                ChangeCoordinates();
            }

        }
        public void ChangeCoordinates()
        {

            if (direction == "Right")
            {
                RighT();

            }
            if (direction == "Left")
            {
                LefT();
            }
            if (direction == "Up")
            {
                Up();

            }
            if (direction == "Down")
            {
                Down();

            }
            if (direction == "DiagonalUpRight")
            {
                DiagonalUpRight();
            }
            if (direction == "DiagonalDownRight")
            {
                DiagonalDownRight();

            }
            if (direction == "DiagonalUpLeft")
            {
                DiagonalUpLeft();
            }
            if (direction == "DiagonalDownLeft")
            {
                DiagonalDownLeft();
            }
           

        }
        private void Down()
        {
            while (X< pictureBoxes.GetLength(0))
            {
                X += 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(X*60, Y*60);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    X -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                    steps++;
                    score++;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    lives--;
                    X -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                {
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    steps++;
                }
            }
        }
        private void Up()
        {
            for (int i = 0; i < pictureBoxes.GetLength(0); i++)
            {
                X -= 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    X += 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                    score++;
                    steps++;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    lives--;
                    X += 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);

                }
            }
        }
        private void LefT()
        {
            for (int i = 0; i < pictureBoxes.GetLength(1); i++)
            {
                Y -= 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {steps++; ;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    Y += 1;
                    
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                    score++;
                    steps++;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    Y += 1;
                    lives--;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                {steps++; 
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);

                }

            }
        }
        private void RighT()
        {
            for (int i = 0; i < pictureBoxes.GetLength(1); i++)
            {
                Y += 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    Y -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {
                    score++;
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    lives--;
                    Y -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);

                }

            }
        }
        private void DiagonalDownRight()
        {
            for (int i = 0; i < pictureBoxes.GetLength(1) + pictureBoxes.GetLength(0); i++)
            {
                Y -= 1;
                X += 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    Y += 1;
                    X -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {
                    score++;
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    lives--;
                    Y += 1;
                    X -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);

                }

            }
        }
        private void DiagonalUpRight()
        {
            for (int i = 0; i < pictureBoxes.GetLength(1) + pictureBoxes.GetLength(0); i++)
            {
                Y += 1;
                X -= 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    Y -= 1;
                    X += 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {steps++;
                    score++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    lives--;
                    Y -= 1;
                    X += 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);

                }

            }
        }
        private void DiagonalUpLeft()
        {
            for (int i = 0; i < pictureBoxes.GetLength(1) + pictureBoxes.GetLength(0); i++)
            {
                Y -= 1;
                X -= 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    Y += 1;
                    X += 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {
                    score++;
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    lives--;
                    Y += 1;
                    X += 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);

                }

            }
        }
        private void DiagonalDownLeft()
        {
            for (int i = 0; i < pictureBoxes.GetLength(1) + pictureBoxes.GetLength(0); i++)
            {
                Y += 1;
                X += 1;
                if ((string)pictureBoxes[X, Y].Tag == "station")
                {
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    break;
                }

                if ((string)pictureBoxes[X, Y].Tag == "barrier")
                {
                    Y -= 1;
                    X -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "coins")
                {
                    score++;
                    steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);
                    pictureBoxes[X, Y].Visible = false;
                }
                if ((string)pictureBoxes[X, Y].Tag == "trap")
                {
                    lives--;
                    Y -= 1;
                    X -= 1;
                    break;
                }
                if ((string)pictureBoxes[X, Y].Tag == "space")
                { steps++;
                    pictureBoxes[uselessX, uselessY].Location = new Point(pictureBoxes[X, Y].Location.X, pictureBoxes[X, Y].Location.Y);

                }

            }
        }
        public bool CheckLives()
        {
            if (lives <= 0)
            {
                Controls.Clear();
                Label label = new Label();
                label.Text = "YOU LOSE(   " + $"YOUR SCORE:  {score}";
                label.AutoSize = true;
                label.Location = new Point(222, 90);
                label.Font = new Font("Calibri", 18);
                label.Padding = new Padding(20);
                label.Visible = true;
                label.BackColor = Color.AliceBlue;
                Controls.Add(label);
                return true;
            }
            return false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckLives()) timer1.Enabled = false;
            label2.AutoSize = true;
            label2.Text = $"{score}";

            label4.AutoSize = true;
            label4.Text = $"{steps}";

            label6.AutoSize = true;
            label6.Text = $"{lives}";

            label7.AutoSize = true;
            label7.Text = $"{X}";

            label9.AutoSize = true;
            label9 .Text = $"{Y}";

            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label6);
        }
        bool CheckScore()
        {
            if(score >= 15)
            {
                Controls.Clear();
                Label label = new Label();
                label.Text = "YOU WIN!   " + $"YOUR SCORE:  {score}";
                label.AutoSize = true;
                label.Location = new Point(222, 90);
                label.Font = new Font("Calibri", 18);
                label.Padding = new Padding(20);
                label.Visible = true;
                label.BackColor = Color.AliceBlue;
                Controls.Add(label);
                return true;
            }
            return false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CheckScore()) { timer1.Enabled = false; }
        }

       
    }

    
}
