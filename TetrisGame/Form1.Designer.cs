using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TetrisGame
{
    partial class Form1 : Form
    {
        int size;

        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlPause = new System.Windows.Forms.Panel();
            this.lblPause = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNewGame = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPontos = new System.Windows.Forms.Label();
            this.pnlPause.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPause
            // 
            this.pnlPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlPause.Controls.Add(this.lblPause);
            this.pnlPause.Location = new System.Drawing.Point(15, 15);
            this.pnlPause.Name = "pnlPause";
            this.pnlPause.Size = new System.Drawing.Size(75, 23);
            this.pnlPause.TabIndex = 0;
            this.pnlPause.Click += new System.EventHandler(this.pause_Click);
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.Location = new System.Drawing.Point(19, 5);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(37, 13);
            this.lblPause.TabIndex = 0;
            this.lblPause.Text = "Pause";
            this.lblPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPause.Click += new System.EventHandler(this.pause_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblNewGame);
            this.panel1.Location = new System.Drawing.Point(15, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 23);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // lblNewGame
            // 
            this.lblNewGame.AutoSize = true;
            this.lblNewGame.Location = new System.Drawing.Point(8, 5);
            this.lblNewGame.Name = "lblNewGame";
            this.lblNewGame.Size = new System.Drawing.Size(59, 13);
            this.lblNewGame.TabIndex = 0;
            this.lblNewGame.Text = "Novo Jogo";
            this.lblNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblPontos);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.pnlPause);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(285, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 280);
            this.panel2.TabIndex = 1;
            // 
            // lblPontos
            // 
            this.lblPontos.AutoSize = true;
            this.lblPontos.Location = new System.Drawing.Point(15, 75);
            this.lblPontos.Name = "lblPontos";
            this.lblPontos.Size = new System.Drawing.Size(43, 13);
            this.lblPontos.TabIndex = 2;
            this.lblPontos.Text = "Pontos:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(430, 493);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.pnlPause.ResumeLayout(false);
            this.pnlPause.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel pnlPause;
        private Label lblPause;
        private Panel panel1;
        private Label lblNewGame;
        private Panel panel2;
        private Label lblPontos;
    }
}

