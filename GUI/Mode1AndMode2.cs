using ObjectGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectGame;

namespace GUI
{
    public partial class Mode1AndMode2 : Form
    {
        BoardGui boardGui;
        public static statusGame status_game = statusGame.ContinueGame;

        public Mode1AndMode2()
        {
            InitializeComponent();
            boardGui = new BoardGui(ChessPieceSide.WHITE);
            this.Controls.Add(boardGui);
            timerCheckEndGame.Start();

        }

        public void ResetGame()
        {
            //chuc nang nay can fix bug haha. tu tu se xong thoi
            this.boardGui.boardLogic.CreateDefaultListPieceBoard();
            this.boardGui.boardLogic.CreateCellBoard(ChessPieceSide.WHITE);
            this.boardGui.AddCellGuiAndCell();

            //reset lai lich su. ahihi
            BoardGui.moveHistory.ListMoveHistory.Clear();
        }



        private void reSetGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void timerCheckEndGame_Tick(object sender, EventArgs e)
        {
            if (Mode1AndMode2.status_game == statusGame.EndGame)
            {
                Mode1AndMode2.status_game = statusGame.ContinueGame;
                ResetGame();
            }

        }

        private void timerProcessbarPlayer_Tick(object sender, EventArgs e)
        {
            if (boardGui.boardLogic.Curentlayer.sideplayer == ChessPieceSide.WHITE)
            {
                progressBar2.Value = 100;
                if (progressBar1.Value != 0) // player 1 la trang
                    progressBar1.Value -= 1;
                else
                {
                    timerProcessbarPlayer.Stop();
                    MessageBox.Show(" time up - Black Win!!!");
                    ResetGame();
                    timerProcessbarPlayer.Start();
                    
                }
                    
            }
            else
            {
                progressBar1.Value = 100;
                if (progressBar2.Value != 0) // player 1 la trang
                    progressBar2.Value -= 1;
                else
                {
                    timerProcessbarPlayer.Stop();
                    MessageBox.Show(" time up - White Win!!!");
                    ResetGame();
                    timerProcessbarPlayer.Start();

                }
                  
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.boardGui.Undo();
        }
    }


}
