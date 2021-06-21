using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inertia__new_
{
    class Trap : Element
    {
        public Trap()
        {
            imagePath = @"../../../pictures/trap.png";
        }
        public override bool Logic(int x, int y)
        {
            lives--;
            X -= x;
            Y -= y;
            return false;
          
        }
        public override void MakeMapPicturesBoxes(int i, int j)
        {
            Inertia.pictureBoxes[i, j].Image = Image.FromFile(Field.Elements[i, j].imagePath);
            Inertia.pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
