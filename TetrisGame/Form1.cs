using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{
    public partial class Form1 : Form
    {
        static int boardHeight = 17;
        static int boardWidth = 9;
        int[,] MappingGame = new int[boardWidth, boardHeight];
        int[,] MapCurrentShape = new int[boardWidth, boardHeight];
        int[,] MapColor = new int[boardWidth, boardHeight];
        int[,] CurrentShape = new int[3, 3];
        int[,] NextShape = new int[3, 3];
        int CurrentColor;
        int NextColor;
        public int PositionShapeY { get; set; }
        public int PositionShapeX { get; set; }
        int zero_y = 25;
        int zero_x = 50;
        int zero_y_preview = 375;
        int zero_x_preview = 300;
        ShapeForm Shape = new ShapeForm();

        bool InvertColor = new bool();

        bool bPause = new bool();

        int nPontuacao = new int();
        public Form1()
        {
            InitializeComponent();
            Init();
           
        }
        public void Init()
        {
            size = 25;

            PositionShapeY = -3;
            PositionShapeX = 2;

            CurrentShape = Shape.RandomShape();
            CurrentColor = Shape.iColor;
            NextShape = Shape.RandomShape();
            NextColor = Shape.iColor;

            while(NextShape == CurrentShape)
            {
                NextShape = Shape.RandomShape();
                NextColor = Shape.iColor;
            }

            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyFuntion); // observa os comandos
            timer1.Interval = 500;// intervalor de 500 milisegundos para a peça descer
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            
            

          
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics); //Desenha as linhas
            DrawTop(e.Graphics); // desenha linha amarela no topo
            DrawMap(e.Graphics, MappingGame,boardWidth,boardHeight,zero_x,zero_y,MapColor); // desenha o game 
            DrawMap(e.Graphics,MapCurrentShape, boardWidth, boardHeight,zero_x,zero_y,CurrentColor); // desenha a peça andando
            DrawMap(e.Graphics, NextShape, 3, 3, zero_x_preview, zero_y_preview, NextColor); // desenha a proxima peça
            this.lblPontos.Text = string.Format("Pontos: {0}", nPontuacao);
        }

        

        private void Update(object sender, EventArgs e)
        {
            
            if (ColisionDown() == true) // verifica se a peça chegou ao fim do tabuleiro ou se ouve colisão com peça abaixo
            {   
                Merge(MapCurrentShape, MappingGame, boardWidth ,boardHeight); // grava as mudanças
                PositionShapeY = -3;
                PositionShapeX = 2;
                CurrentShape = NextShape;
                CurrentColor = NextColor;

                while (NextShape == CurrentShape) // gera nova peça
                {
                    NextShape = Shape.RandomShape();
                    NextColor = Shape.iColor;
                }
                
                VerifyGameOver();// verifica se o jogador perdeu

                bool ThereIsLineFull = true;// verifica se tem alguma linha completa para apagar e realocar
                while (ThereIsLineFull == true)
                {
                    int FullLine = new int();
                    FullLine = VerifyLineFull();
                    if(FullLine < 1)
                    {
                        ThereIsLineFull = false;
                    }
                    else
                    {
                        EraseLineAndReplace(FullLine, MappingGame); 
                    }
                }
            }

            

            if (bPause == false)
            {
                MoveDown();
                nPontuacao += 50;
            }
            Invalidate();
        }

        private void DrawTop(Graphics e)
        {
            e.FillRectangle(Brushes.LightGoldenrodYellow, new Rectangle(zero_x, zero_y, size*boardWidth, size));
        }
        public void DrawGrid(Graphics e) // desanha as linhas do tabuleiro e da proxima peça
        {
            for (int i = 0; i < (boardHeight+1); i++)
            {
               e.DrawLine(Pens.Black, new Point(zero_x, zero_y + (i * size)), new Point(zero_x + boardWidth * size, zero_y + (i * size)));
            }
            for (int i = 0; i < (boardWidth+1); i++)
            {
                e.DrawLine(Pens.Black, new Point(zero_x + (i * size), zero_y), new Point(zero_x + (i * size), zero_y + boardHeight * size));

            }
            for (int i = 0; i < 4; i++)
            {
                e.DrawLine(Pens.Black, new Point(zero_x_preview + (i * size), zero_y_preview), new Point(zero_x_preview + (i * size), zero_y_preview + 3 * size));

            }
            for (int i = 0; i < 4; i++)
            {
                e.DrawLine(Pens.Black, new Point(zero_x_preview, zero_y_preview + (i * size)), new Point(zero_x_preview + 3 * size, zero_y_preview + i * size));

            }

        }
        

        public void DrawMap(Graphics e, int[,] Draw,int lengX, int lengY, int posX, int posY, int Color) // desenha a peça definitiva no tabuleiro
        {
            InvertColor = true;
            for (int i = 0; i < lengX; i++)
            {
                for (int j = 0; j < lengY; j++)
                {
                    if (Draw[i, j] == 1)
                    {
                        switch (Color)
                        {
                            case 1:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Red, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkRed, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Blue, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkBlue, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 3:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Orange, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkOrange, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 4:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Green, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkGreen, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 5:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Pink, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.LightPink, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            
                        }
                    }
                }
            }
        }

        public void DrawMap(Graphics e, int[,] Draw, int lengX, int lengY, int posX, int posY, int[,] Color)
        {
            InvertColor = true;
            for (int i = 0; i < lengX; i++)
            {
                for (int j = 0; j < lengY; j++)
                {
                    if (Draw[i, j] == 1)
                    {
                        switch (Color[i,j])
                        {
                            case 1:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Red, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkRed, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Blue, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkBlue, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 3:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Orange, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkOrange, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 4:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Green, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.DarkGreen, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            case 5:
                                {
                                    if (InvertColor == false)
                                    {
                                        e.FillRectangle(Brushes.Pink, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = true;
                                    }
                                    else
                                    {
                                        e.FillRectangle(Brushes.LightPink, new Rectangle(posX + i * size, posY + j * size, size, size));
                                        InvertColor = false;
                                    }
                                }
                                break;
                            
                        }

                    }
                }
            }
        }


        

        public void MappingShape(int[,] MapDraw, int[,] ShapeDraw, int position_x, int position_y) // define a posição da peça atual no tabuleiro e a cor em cada parte do mapa
        {
            for(int i=0; i<3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ShapeDraw[i, j] == 1)
                    {
                        int p_x = position_x + i;
                        int p_y = position_y + j;
                        if (p_x < boardWidth && p_x >= 0 && p_y < boardHeight && p_y >= 0)// se estiver dentro do mapa, não estiver fora
                        {
                                MapDraw[position_x + i, position_y + j] = 1;
                        }
                    }
                }
            }
        }

        public void MappingShapeColor(int[,] ShapeDraw, int position_x, int position_y) // define a posição da peça atual no tabuleiro e a cor em cada parte do mapa
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ShapeDraw[i, j] == 1)
                    {
                        int p_x = position_x + i;
                        int p_y = position_y + j;
                        if (p_x < boardWidth && p_x >= 0 && p_y < boardHeight && p_y >= 0)// se estiver dentro do mapa, não estiver fora
                        {
                            MapColor[position_x + i, position_y + j] = CurrentColor;
                        }
                    }
                }
            }
        }
        public void EraseMap(int[,] Map) // limpa todas as peças pintadas
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Map[i, j] = 0;
                }
            }
        }
        public void Merge(int[,] Map1, int[,] Map2, int LengX, int LengY) // copia o primeiro mapa para dentro do segundo
        {
            for (int i = 0; i < LengX; i++)
            {
                for (int j = 0; j < LengY; j++)
                {
                    if (Map1[i, j] == 1)
                    {
                        Map2[i, j] = 1;
                    }
                }
            }
        }

        public void VerifyGameOver() // verifica se houve gameover, ou seja se há algum bloco gravado na linha amarelada
        {
            for(int i=0; i<boardWidth; i++)
            {
                if (MappingGame[i, 0] == 1)
                {
                    EraseMap(MappingGame);
                    nPontuacao = 0;
                    bPause = true;
                    this.lblPause.Text = "Iniciar";
                    System.Windows.Forms.MessageBox.Show("Você perdeu");
                }
            }

        }

        public int VerifyLineFull() // verifica se alguma linha esta cheia e retorna qual
        {
            
            int WhatIsLineFull = -1;
            int SomaLine = 0;
            for (int j = 0; j < boardHeight; j++)
            {
                for (int i = 0; i < boardWidth; i++)
                {
                    if (MappingGame[i, j] == 1)
                    {
                        SomaLine++;                                    
                    }
                }
                if(SomaLine > (boardWidth-1))
                {
                    WhatIsLineFull = j;
                }
                SomaLine = 0;
            }
            return WhatIsLineFull;
        }

        public void EraseLineAndReplace(int Line, int[,] Map) // apaga a linha e copia tudo que esta em cima para baixo
        {
            
            for (int i = 0; i < boardWidth; i++)// erase
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    if (j == Line)
                    {
                        Map[i, j] = 0;
                        MapColor[i, j] = 0;
                    }
                }
            }

            for(int x=Line; x>1; x--)// replace
            {
                for (int i = 0; i < boardWidth; i++)
                {

                    Map[i, x] = Map[i, x - 1];
                    MapColor[i, x] = MapColor[i, x - 1];
                    
                }
                
            }
        }

        private void pause_Click(object sender, EventArgs e) // botao pause
        {
            bPause = !bPause;
            if (bPause == true) this.lblPause.Text = "Iniciar";
            else this.lblPause.Text = "Pause";
        }

        private void NewGame_Click(object sender, EventArgs e) // botao de novo jogo
        {
            EraseMap(MappingGame);
            EraseMap(MapCurrentShape);
            PositionShapeY = -3;
            PositionShapeX = 2;
            nPontuacao = 0;
            CurrentShape = NextShape;
            CurrentColor = NextColor;

            while (NextShape == CurrentShape)
            {
                NextShape = Shape.RandomShape();
                NextColor = Shape.iColor;
            }
            bPause = true;
            this.lblPause.Text = "Iniciar";
        }
    }
}
