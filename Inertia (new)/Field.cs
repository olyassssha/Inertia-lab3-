using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Inertia__new_
{
    public abstract class Field
    {
        public static int width;
        public static int height;
        protected string path;


        public char[,] arr;
        static public Element[,] Elements;
        
        public char[,] Made()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                arr = new char[height, width];
                Elements = new Element[height, width];
                string[] arr2 = new string[height];
                for (int i = 0; i < height; i++)
                {
                    arr2[i] = sr.ReadLine();
                }
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        arr[i, j] = arr2[i][j];
                        if(arr[i,j] == '%')
                        {
                            Elements[i, j] = new Trap();
                        }
                        if (arr[i, j] == '@')
                        {
                            Elements[i, j] = new Coins();
                        }
                        if (arr[i, j] == '#')
                        {
                            Elements[i, j] = new Barrier();
                        }
                        if (arr[i, j] == '.')
                        {
                            Elements[i, j] = new Station();
                        }
                        if (arr[i, j] == 'I')
                        {
                            Elements[i, j] = new Player();
                            Element.playerX = i;
                            Element.playerY = j;
                            Element.X = i;
                            Element.Y = j;
                        }
                        if (arr[i, j] == ' ')
                        {
                            Elements[i, j] = new Space();
                        }

                    }
                }
                return arr;
            }

        }
   

    }
    public class Level_1 : Field
    {
        public string pathOfLevelImages;
        public Level_1()
        {
            width = 21;
            height = 9;
            path = @"maps/map.txt";
 
        }
    }
    public class Level_2 : Field
    {

        public string pathOfLevelImages;

        public Level_2()
        {
            width = 27;
            height = 11;
            path = @"maps/map2.txt";

        }


    }
    public class Level_3 : Field
    {

        public string pathOfLevelImages;

        public Level_3()
        {
            width = 29;
            height = 16;
            path = @"maps/map3.txt";
          
        }


    }

}

