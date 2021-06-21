using System;
using System.Collections.Generic;
using System.Text;

namespace Inertia__new_
{
  public abstract class Element
  {
        public string imagePath { get; set; }
        abstract public bool Logic(int x, int y);
        abstract public void MakeMapPicturesBoxes(int i, int j);

        public static int playerX;
        public static int playerY;

        public static int X;
        public static int Y;


        public static int score;
        public static int steps;
        public static int lives = 10;

  }
}
