using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Inertia__new_
{
    public partial class Inertia : Form
    {
        public string direction;
        public int playerXlocation;
        public int playerYlocation;
        public int playerPreviousXlocation;
        public int playerPreviousYlocation;
        public bool checkStation = false;
        int index;
        protected PictureBox[] pictureBoxes;
       
        int score;
        int steps;
        int lives=10;

        public Inertia()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer1.Interval =1000;
            timer2.Interval =1000;
          
            GenerateMap();
            Play();
            this.KeyDown += new KeyEventHandler(keyisup);


        }
        Level_2 level = new Level_2();

        public Player playerOnThemap = new Player();

        static void Play()
        {
            SoundPlayer music = new SoundPlayer(@"../../../../Fear.wav");
            music.PlayLooping();
        }
        public void GenerateMap()
        {
            playerOnThemap.MakeMap(level);
            pictureBoxes = new PictureBox[level.height * level.width];
            int k = 0;
            for (int i = 0; i < level.height; i++)
            {
                for (int j = 0; j < level.width; j++)
                {
                    pictureBoxes[k] = new PictureBox();
                    pictureBoxes[k].Location = new Point(60 * j, i * 60);
                    pictureBoxes[k].Size = new Size(54, 36);

                    if (level.arrayOfObjects[i, j].GetType() == typeof(Trap))
                    {
                        pictureBoxes[k].Tag = "trap";
                        pictureBoxes[k].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[k].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Barrier))
                    {
                        pictureBoxes[k].Tag = "barrier";
                        pictureBoxes[k].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[k].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Station))
                    {
                        pictureBoxes[k].Tag = "station";
                        pictureBoxes[k].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[k].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Coins))
                    {
                        pictureBoxes[k].Tag = "coins";
                        pictureBoxes[k].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[k].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.arrayOfObjects[i, j].GetType() == typeof(Player))
                    {
                        pictureBoxes[k].Name = "player";
                        pictureBoxes[k].Image = Image.FromFile(level.arrayOfObjects[i, j].pathOfImage);
                        pictureBoxes[k].SizeMode = PictureBoxSizeMode.Zoom;
                        index = k;
                        playerXlocation = pictureBoxes[k].Location.X;
                        playerYlocation = pictureBoxes[k].Location.Y;
                    }

                    this.Controls.Add(pictureBoxes[k]); k++;

                }
            }



            //for (int i = 0; i <= level.height; i++)
            //{
            //    PictureBox pic = new PictureBox();
            //    pic.BackColor = Color.Black;
            //    pic.Location = new Point(0, 60 * i);
            //    pic.Size = new Size(level.width * 60, 1);
            //    this.Controls.Add(pic);
            //}
            //for (int i = 0; i <= level.width; i++)
            //{
            //    PictureBox pic = new PictureBox();
            //    pic.BackColor = Color.Black;
            //    pic.Location = new Point(60 * i, 0);
            //    pic.Size = new Size(1, level.height * 60);
            //    this.Controls.Add(pic);
            //}

        }
        private void keyisup(object sender, KeyEventArgs e)
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

            LogicForElements();
            LogicForPlayer();



        }
        public void LogicForPlayer()
        {
            pictureBoxes[index].Location = new Point(playerXlocation, playerYlocation);
            pictureBoxes[index].Visible = true;
     
        }
        public bool LogicForElements()
        {
            LogicForPlayer();

            foreach (PictureBox x in pictureBoxes)
            {
                if ((string)x.Tag == "coins")
                {
                    if (pictureBoxes[index].Bounds.IntersectsWith(x.Bounds))
                    {
                        if (x.Visible != false)
                        {
                            score++;
                        }
                        checkStation = false;
                        x.Visible = false;
                       
                    }
                }
                if ((string)x.Tag == "station")
                {
                    //if (pictureBoxes[23].Bounds.IntersectsWith(x.Bounds))
                    //{
                        if (pictureBoxes[index].Location == x.Location)
                        {
                            direction = "Stop";
                        }
                      
                        //pictureBoxes[23].Location = new Point(x.Location.X, x.Location.Y);
                        //return true;

                    //}
                }
                if ((string)x.Tag == "barrier")
                {
                    if (pictureBoxes[index].Bounds.IntersectsWith(x.Bounds))
                    {
                        direction = "Stop";
                        return true;
                    }
                }
                if ((string)x.Tag == "trap")
                {
                    if (pictureBoxes[index].Bounds.IntersectsWith(x.Bounds))
                    {
                        lives--;
                        direction = "Stop";
                        return true;
                    }
                }



            }

            return false;
        }
        public void ChangeCoordinates()
        {

            if (direction == "Right")
            {
                while (LogicForElements() != true && checkStation == false)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerXlocation += 60;
                    steps++;
                }

            }
            if (direction == "Left")
            {
                while (LogicForElements() != true && checkStation == false)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerXlocation -= 60;
                    steps++;
                }
            }
            if (direction == "Up" && checkStation == false)
            {
                while (LogicForElements() != true)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerYlocation -= 60; steps++;
                }
            }
            if (direction == "Down" )
            {
                while (LogicForElements() != true && checkStation == false)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerYlocation += 60; steps++;
                }
            }
            if (direction == "DiagonalUpRight")
            {
                while (LogicForElements() != true)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerXlocation -= 60;
                    playerYlocation += 60; steps++;
                }
            }
            if (direction == "DiagonalDownRight")
            {
                while (LogicForElements() != true)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerYlocation -= 60;
                    playerXlocation += 60; steps++;
                }
            }
            if (direction == "DiagonalUpLeft")
            {
                while (LogicForElements() != true)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerXlocation -= 60;
                    playerYlocation -= 60; steps++;
                }
            }
            if (direction == "DiagonalDownLeft")
            {
                while (LogicForElements() != true)
                {
                    playerPreviousXlocation = playerXlocation;
                    playerPreviousYlocation = playerYlocation;
                    playerXlocation += 60;
                    playerYlocation += 60; steps++;
                }
            }
            if (direction == "Stop")
            {
                playerXlocation = playerPreviousXlocation;
                playerYlocation = playerPreviousYlocation;

            }
          
        }
        public void CheckLives()
        {
            if (lives <= 0)
            {
                this.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckLives();
            label2.AutoSize = true;
            label2.Text = $"{score}";

            label4.AutoSize = true;
            label4.Text = $"{steps}";

            label6.AutoSize = true;
            label6.Text = $"{lives}";

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
