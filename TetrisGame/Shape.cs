using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public class ShapeForm
    {
        public int iColor;
        public int[,] Shape1 = new int[3, 3] {
            { 0, 1, 1 },
            { 0, 1, 0 },
            { 0, 1, 0 } };
        public int[,] Shape2 = new int[3, 3] {
            { 0, 0, 0 },
            { 1, 1, 0 },
            { 1, 1, 0 } };
        public int[,] Shape3 = new int[3, 3] {
            { 0, 1, 0 },
            { 0, 1, 1 },
            { 0, 1, 0 } };
        public int[,] Shape4 = new int[3, 3] {
            { 0, 0, 0 },
            { 0, 1, 1 },
            { 1, 1, 0 } };
        public int[,] Shape5 = new int[3, 3] {
            { 0, 1, 0 },
            { 0, 1, 0 },
            { 0, 1, 0 } };
        public int[,] RandomShape()
        {
            Random num = new Random();
            int Escolhido = num.Next(1, 6);
            int[,] ShapeEscolhido = new int[3, 3];
            switch (Escolhido)
            {
                case 1:
                    {
                        ShapeEscolhido = Shape1;
                        iColor = 1;
                    }
                    break;
                case 2:
                    {
                        ShapeEscolhido = Shape2;
                        iColor = 2;
                    }
                    break;
                case 3:
                    {
                        ShapeEscolhido = Shape3;
                        iColor = 3;
                    }
                    break;
                case 4:
                    {
                        ShapeEscolhido = Shape4;
                        iColor = 4;
                    }
                    break;
                case 5:
                    {
                        ShapeEscolhido = Shape5;
                        iColor = 5;
                    }
                    break;


            }
            return ShapeEscolhido;

        }
    }
}
