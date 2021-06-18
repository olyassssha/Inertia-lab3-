using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Inertia__new_
{
    class Space : Element
    {
        public override bool Logic(int x, int y)
        {
            Inertia.pictureBoxes[playerX, playerY].Location = new Point(Y * 60, X * 60);
            steps++;
            return true;
        }

        public override void MakeMapPicturesBoxes(int i, int j)
        {
           
        }
    }
}
