using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inertia__new_
{
    public partial class Form1 : Form
    {
        public string direction;
        public int playerXlocation;
        public int playerYlocation;
        public bool currentDirection = true;


        public Form1()
        {
            InitializeComponent();
            GenerateMap();
       
            this.KeyDown += new KeyEventHandler(keyisup);
          
        }

        Level_1 level = new Level_1();
        Player playerOnThemap = new Player();
        public void GenerateMap()
        {

            for (int i = 0; i < level.height; i++)
            {
                for (int j = 0; j < level.width; j++)
                {
                    PictureBox line = new PictureBox();
                    line.Location = new Point(60 * j, i * 60);
                    line.Size = new Size(54, 36);

                    if (level.mapLevel[i, j] == '%')
                    {
                        Trap trap = new Trap();
                        line.Tag = "trap";
                        line.Image = Image.FromFile(trap.pathOfImageTrap);
                        line.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.mapLevel[i, j] == '#')
                    {
                        Barrier barrier = new Barrier();
                        line.Tag = "barrier";
                        line.Image = Image.FromFile(barrier.pathOfImageBarrier);
                        line.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.mapLevel[i, j] == '.')
                    {
                        Station station = new Station();
                        line.Tag = "station";
                        line.Image = Image.FromFile(station.pathOfImageStation);
                        line.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.mapLevel[i, j] == '@')
                    {
                        Coins coins = new Coins();
                        line.Tag = "coins";
                        line.Image = Image.FromFile(coins.pathOfImageCoins);
                        line.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    if (level.mapLevel[i, j] == 'I')
                    {
                        Player player = new Player();
                        line.Name = "player";
                        line.Image = Image.FromFile(player.pathOgImagePlayer);
                        line.SizeMode = PictureBoxSizeMode.Zoom;
                        player.directionX = line.Location.X;
                        player.directionY = line.Location.Y;
                    }

                    this.Controls.Add(line);
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
                playerOnThemap.direction = "Up";
                playerOnThemap.ChangeCoordinates();
            }
            if (e.KeyCode == Keys.Down)
            {
                playerOnThemap.direction = "Down";
                playerOnThemap.ChangeCoordinates();
            }
            if (e.KeyCode == Keys.Left)
            {
                playerOnThemap.direction = "Left";
                playerOnThemap.ChangeCoordinates();

            }
            if (e.KeyCode == Keys.Right)
            {
                playerOnThemap.direction = "Right";
                playerOnThemap.ChangeCoordinates();

            }
            if (e.KeyCode == Keys.D)
            {
                playerOnThemap.direction = "DiagonalUpRight";

            }
            if (e.KeyCode == Keys.F)
            {
                playerOnThemap.direction = "DiagonalDownRight";
            }
            if (e.KeyCode == Keys.G)
            {
                playerOnThemap.direction = "DiagonalUpLeft";
            }
            if (e.KeyCode == Keys.H)
            {
                playerOnThemap.direction = "DiagonalDownLeft";
            }

            foreach (Control x in Controls)
            {
                if (x is PictureBox)
                {
                    //if ((string)x.Tag != "barrier" && (string)x.Tag != "coins" &&
                    //(string)x.Tag != "trap" && (string)x.Tag != "station")
                    //{
                    //    player.ChangeCoordinates();
                    //}
                    if (x.Name == "player")
                    {
                       
                        x.Location = new Point(playerOnThemap.directionX, playerOnThemap.directionY); ;
                        x.Visible = true;
                        //foreach (Control f in Controls)
                        //{
                        //    if (f is PictureBox)
                        //    {
                        //        if (x.Bounds.IntersectsWith(f.Bounds))
                        //        {
                        //            player.ChangeCoordinates();
                        //            f.Visible = false;
                        //            //player.direction = "Stop";
                        //        }
                        //    }
                        //}
                    }
                    

                   


                }

            }



        }

    }
}
