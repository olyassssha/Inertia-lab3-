using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inertia__new_
{
    class Coins : Element
    {
        public Coins()
        {
            pathOfImage = @"../../../pictures/coins.png";
        }
        public override bool Logic (int x, int y)
        {
            Inertia.pictureBoxes[playerX, playerY].Location = new Point(Y*60,X*60);
            Inertia.pictureBoxes[X, Y].Visible = false;
            steps++;
            score++;
            return true;
        }

        public override void MakeMapPicturesBoxes(int i, int j)
        {
           Inertia.pictureBoxes[i, j].Image = Image.FromFile(Field.arrayOfObjects[i, j].pathOfImage);
           Inertia.pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
