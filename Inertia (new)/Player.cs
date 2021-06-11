using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Inertia__new_
{
   public class Player :Field
    {
       public int directionX = 120;
       public int directionY = 60;
        public int playerPreviousXlocation;
        public int playerPreviousYlocation;
        public string direction;
        public Player()
        {
            pathOfImage = @"../../../../player.png";
        }
        public void ChangeCoordinates()
        {
           
                if (direction == "Right")
                {
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionX += 60;
                
                }
                if (direction == "Left")
                {
              
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionX -= 60;
                
              
                }
                if (direction == "Up")
                {
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionY -= 60;
                }
                if (direction == "Down")
                {
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionY += 60;
                }
                if (direction == "DiagonalUpRight")
                {
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionX -= 60;
                    directionY += 60;
                }
                if (direction == "DiagonalDownRight")
                {
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionY -= 60;
                    directionX += 60;
                }
                if (direction == "DiagonalUpLeft")
                {
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionX -= 60;
                    directionY -= 60;
                }
                if (direction == "DiagonalDownLeft")
                {
                while (direction != "Stop")
                {
                    playerPreviousXlocation = directionX;
                    playerPreviousYlocation = directionY;
                    directionX += 60;
                    directionY += 60;
                }
                }
                if (direction == "Stop")
                {
                    directionX = playerPreviousXlocation;
                    directionY = playerPreviousYlocation;

                }
            
        }
        public void MakeMap(Field field)
        {
            field.Made();
        }

    }
}
