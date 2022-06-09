using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{
    partial class Form1
    {



        int[,] RotatedCurrentShape = new int[3, 3];
        int[,] MapCurrentShapToTestColision = new int[boardWidth, boardHeight];
        public void KeyFuntion(object sender, KeyEventArgs e)
        {
            if (bPause == false)
            {
                
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        {
                            MoveRight();// move a peça para a direita
                            break;
                        }
                    case Keys.Left:
                        {
                            MoveLeft();
                            break;
                        }
                    case Keys.Up:
                        {
                            RotateComand();
                            break;
                        }
                    case Keys.Down:
                        {
                            MoveDown();
                            break;
                        }
                }
            }
        }
        public void MoveDown()
        {
            if (ColisionDown() == false)// verifica se há colisão para baixo
                PositionShapeY++; // avança para a baixo

            EraseMap(MapCurrentShape); // limpa o mapa do shape
            MappingShape(MapCurrentShape, CurrentShape, PositionShapeX, PositionShapeY);// desenha o shape na nova posição
            MappingShapeColor(CurrentShape, PositionShapeX, PositionShapeY);// desenha o as cores do novo shape, isto é mapeia as cores

        }
        public void MoveRight()
        {
            if (ColisionRight() == false)// verifica se há colisão na direita
                PositionShapeX++; // avança para a direita

            EraseMap(MapCurrentShape); // limpa o mapa do shape
            MappingShape(MapCurrentShape, CurrentShape, PositionShapeX, PositionShapeY);// desenha o shape na nova posição
            MappingShapeColor(CurrentShape, PositionShapeX, PositionShapeY);// desenha o as cores do novo shape, isto é mapeia as cores
        }
        public void MoveLeft()
        {
            if (ColisionLeft() == false) // verifica se há colisão na esquerda
                PositionShapeX--; // avança para esquerda

            EraseMap(MapCurrentShape); // limpa o mapa do shape
            MappingShape(MapCurrentShape, CurrentShape, PositionShapeX, PositionShapeY);// desenha o shape na nova posição
            MappingShapeColor(CurrentShape, PositionShapeX, PositionShapeY);// desenha o as cores do novo shape, isto é mapeia as cores
        }
        public void RotateComand()
        {
            int[,] CopyCurrentShape = new int[3, 3];

            Merge(CurrentShape, CopyCurrentShape, 3, 3);

            RotatedCurrentShape = Rotate(CopyCurrentShape); // faz a ação de virar e grava no RotateCurrentShape

            EraseMap(MapCurrentShapToTestColision);//limpa o mapa provisorio
            MappingShape(MapCurrentShapToTestColision, RotatedCurrentShape, PositionShapeX, PositionShapeY);//grava o shape rotasionado no mapa provisorio

            if (ColisionRotate() == false) // testa se o shape após ser girado não vai colidir com nada
            {
                CurrentShape = RotatedCurrentShape;
                EraseMap(MapCurrentShape);
                MappingShape(MapCurrentShape, CurrentShape, PositionShapeX, PositionShapeY);
                MappingShapeColor(CurrentShape, PositionShapeX, PositionShapeY);// desenha o as cores do novo shape, isto é mapeia as cores
            }

        }
        public int[,] Rotate(int[,] _ShapeToRotate)
        {
            int[,] ShapeToRotate = new int[3, 3];
            ShapeToRotate = _ShapeToRotate;


            for (int i=0; i<2; i++) // gira o shape
            {
                int Aux = ShapeToRotate[0, 0];
                ShapeToRotate[0, 0] = ShapeToRotate[0, 1];
                ShapeToRotate[0, 1] = ShapeToRotate[0, 2];
                ShapeToRotate[0, 2] = ShapeToRotate[1, 2];
                ShapeToRotate[1, 2] = ShapeToRotate[2, 2];
                ShapeToRotate[2, 2] = ShapeToRotate[2, 1];
                ShapeToRotate[2, 1] = ShapeToRotate[2, 0];
                ShapeToRotate[2, 0] = ShapeToRotate[1, 0];
                ShapeToRotate[1, 0] = Aux;
            }

            return ShapeToRotate;
        }
    }
}
