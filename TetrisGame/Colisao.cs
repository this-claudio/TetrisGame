using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    partial class Form1
    {
        public bool ColisionDown() // verifica colisão com a parte de baixo da peça
        {
            bool bresult = false;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (MapCurrentShape[i, j] == 1)
                    {
                        if (j + 1 > (boardHeight-1))
                            bresult = true;
                        else if (MappingGame[i, j + 1] == 1)
                        {
                            if (MapCurrentShape[i, j + 1] == 0)
                            {
                                bresult = true;
                            }
                        }

                    }
                }
            }
            return bresult;
        }

        public bool ColisionRight() // verifica colisão com a direita da peça
        {
            bool bresult = false;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (MapCurrentShape[i, j] == 1)
                    {

                        if (i + 1 > (boardWidth-1))
                            bresult = true;
                        else if (MappingGame[i + 1, j] == 1)
                        {
                            if (MapCurrentShape[i + 1, j] == 0)
                            {
                                bresult = true;
                            }

                        }
                    }
                }
            }

            if (PositionShapeX > boardWidth)
                bresult = true;
            return bresult;
        }
        public bool ColisionLeft()
        {
            bool bresult = false;
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (MapCurrentShape[i, j] == 1)
                    {
                        if (i - 1 < 0)
                            bresult = true;
                        else if (MappingGame[i - 1, j] == 1)
                        {
                            if (MapCurrentShape[i - 1, j] == 0)
                            {
                                bresult = true;
                            }
                        }

                    }
                }
            }

            return bresult;
        }

        public bool ColisionRotate()
        {
            bool bresult = false;

            bresult = ColisionDown(); // testa colisão inferior no Shape antes de rodar

            for (int i = 0; i < 3; i++) // testa se a rotação não vai fazer a peça sair para fora do mapa
            {
                for (int j = 0; j < 3; j++)
                {
                    if (RotatedCurrentShape[i, j] == 1)
                    {
                        if (i + PositionShapeX > (boardWidth-1) || i + PositionShapeX < 0)
                        {
                            bresult = true;
                        }
                    }
                }
            }


            for (int i = 0; i < boardWidth; i++) // testa colisão de superposição do shape rotacionado com as peças no tabuleiro
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (MapCurrentShapToTestColision[i, j] == 1 && MappingGame[i, j] == 1)
                    {

                        bresult = true;
                    }

                }

            }

            return bresult;
        }
    }
}
