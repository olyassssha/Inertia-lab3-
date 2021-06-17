using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Inertia__new_
{
   public class Player :Field
    {

        public Player()
        {
            pathOfImage = @"../../../pictures/player.png";
        }
        public void MakeMap(Field field)
        {
            field.Made();
        }

    }
}
