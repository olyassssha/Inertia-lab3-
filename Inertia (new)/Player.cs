using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Inertia__new_
{
    class Player
    {
       public int directionX = 120;
       public int directionY = 60;
       public string direction;

        public string pathOgImagePlayer = @"../../../../player.png";
        public void ChangeCoordinates()
        {
            if (direction == "Right")
            {
                directionX += 60;
            }
            if (direction == "Left")
            {
                directionX -= 60;
            }
            if (direction == "Up")
            {
                directionY -= 60;
            }
            if (direction == "Down")
            {
                directionY += 60;
            }
            if (direction == "DiagonalUpRight")
            {
                directionX -=60;
                directionY +=60;
            }
            if (direction == "DiagonalDownRight")
            {
                directionY -= 60;
                directionX +=60;
            }
            if (direction == "DiagonalUpLeft")
            {
                directionX -= 60;
                directionY -= 60;
            }
            if (direction == "DiagonalDownLeft")
            {
                directionX += 60;
                directionY += 60;
            }
            if (direction == "Stop") 
            {

                directionX -= 0;
                directionY -= 0;
            }
        }
     
    }
}
