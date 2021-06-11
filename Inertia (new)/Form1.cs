using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Inertia__new_
{
    public partial class Form1 : Form
    {
        public string direction;
        public int playerXlocation;
        public int playerYlocation;
        public int playerPreviousXlocation;
        public int playerPreviousYlocation;
        public bool currentDirection = true;
        protected PictureBox[] pictureBoxes;

        public Form1()
        {
            InitializeComponent();
            GenerateMap();
            Play();
            this.KeyDown += new KeyEventHandler(keyisup);

        }
        Level_1 level = new Level_1();

        public  Player playerOnThemap = new Player();

        static void Play()
        {
            SoundPlayer music = new SoundPlayer(@"../../../../Fear.wav");
            music.PlayLooping();
        }
        static void PlayBeep()
        {
            SoundPlayer music = new SoundPlayer(@"../../../../beep.wav");
            music.Play();
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
                playerOnThemap.direction = "DiagonalDownRight";
                playerOnThemap.ChangeCoordinates();
            }
            if (e.KeyCode == Keys.G)
            {
                playerOnThemap.direction = "DiagonalUpLeft";
                playerOnThemap.ChangeCoordinates();
            }
            if (e.KeyCode == Keys.H)
            {
                playerOnThemap.direction = "DiagonalDownLeft";
                playerOnThemap.ChangeCoordinates();
            }
            LogicForElements();
            LogicForPlayer();



        }
        public void LogicForPlayer()
        {
              pictureBoxes[23].Location = new Point(playerXlocation, playerYlocation);
              pictureBoxes[23].Visible = true;
        }
        public bool LogicForElements()
        {
            LogicForPlayer();

            foreach (PictureBox x in pictureBoxes)
            {
                if ((string)x.Tag == "coins")
                {
                    if (pictureBoxes[23].Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Visible = false;
                    }
                }
                if ((string)x.Tag == "station")
                {
                    if (pictureBoxes[23].Bounds.IntersectsWith(x.Bounds))
                    {
                        pictureBoxes[23].Location = new Point(x.Location.X, x.Location.Y);
                        //direction = "Stop";
                
                    }
                }
                if ((string)x.Tag == "barrier" || (string)x.Tag == "trap")
                {
                    if (pictureBoxes[23].Bounds.IntersectsWith(x.Bounds))
                    {
                        PlayBeep();
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
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerXlocation += 60;
                        }

                    }
                    if (direction == "Left")
                    {
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerXlocation -= 60;

                        }
                    }
                    if (direction == "Up")
                    {
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerYlocation -= 60;
                        }
                    }
                    if (direction == "Down")
                    {
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerYlocation += 60;
                        }
                    }
                    if (direction == "DiagonalUpRight")
                    {
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerXlocation -= 60;
                            playerYlocation += 60;
                        }
                    }
                    if (direction == "DiagonalDownRight")
                    {
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerYlocation -= 60;
                            playerXlocation += 60;
                        }
                    }
                    if (direction == "DiagonalUpLeft")
                    {
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerXlocation -= 60;
                            playerYlocation -= 60;
                        }
                    }
                    if (direction == "DiagonalDownLeft")
                    {
                        while (LogicForElements() != true)
                        {
                            playerPreviousXlocation = playerXlocation;
                            playerPreviousYlocation = playerYlocation;
                            playerXlocation += 60;
                            playerYlocation += 60;
                        }
                    }
                    if (direction == "Stop")
                    {
                        playerXlocation = playerPreviousXlocation;
                        playerYlocation = playerPreviousYlocation;

                    }
        }
    }
    





    
}
