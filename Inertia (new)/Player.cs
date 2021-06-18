using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Inertia__new_
{
   public class Player : Element
   {

        public Player()
        {
            pathOfImage = @"../../../pictures/player.png";
        }
        public void MakeMap(Field field)
        {
            field.Made();
        }
        public override bool Logic(int x, int y)
        {

           while (X < Inertia.pictureBoxes.GetLength(0) && Y < Inertia.pictureBoxes.GetLength(1) &&
                X > 0 && Y > 0)
           {
                   X += x;
                   Y += y;

                if (!Field.arrayOfObjects[X, Y].Logic(x, y)) break;
         
           }
            return true;
        }

        public override void MakeMapPicturesBoxes(int i, int j)
        {
            Inertia.pictureBoxes[i, j].Image = Image.FromFile(Field.arrayOfObjects[i, j].pathOfImage);
            Inertia.pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;             
        }
    }
}
