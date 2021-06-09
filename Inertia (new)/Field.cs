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
        public int width;
        public int height;
        protected string path;
        public char[,] arr;
        
        public string pathOfImage { get; set; }
        protected char[,] Made()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                arr = new char[height, width];
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
                      
                    }
                }
                return arr;
            }

        }
    

    }
    public class Level_1 : Field
    {
    
        public string pathOfLevelImages;
        public char[,] mapLevel;
        public Level_1()
        {
            width = 21;
            height = 9;
            path = @"../../../../map.txt";
            mapLevel = Made();

        }


    }

}

