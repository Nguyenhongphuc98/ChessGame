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
using System.Threading;
using static System.Net.WebRequestMethods;

namespace GUI
{
    public partial class Mode1AndMode2 : Form
    {
        BoardGui boardGui;
        public static statusGame status_game = statusGame.ContinueGame;
        SocketManager socket;
        public static string namePlayer;
        public static int modeplay;

        public static int checkmove = 0; //de kiem tra coi da di nuoc co hay khong, pahi thi gui qua LAN
        public static Point moveLAN = new Point(0, 0);
        //chua diem dau va diem cuoi cua nuoc co vua di

        public Mode1AndMode2(int mode)
        {
           // System.Windows.Forms.Control.CheckForIllegalCrossT hreadCalls = File;
            InitializeComponent();
            modeplay = mode;

            //che do danh 2 nguoi 1 may hoac danh voi may thi !enable khung chat
            if (Mode1AndMode2.modeplay == 1 || Mode1AndMode2.modeplay == 2)
                //this.lvChat.Enabled = btnSendMessage.Enabled = tbmess.Enabled = false;
                pnChat.Visible = false;
            else
            {
                //nguoc lai la danh qua LAN
                timerCheckMove.Start();
                socket = new SocketManager();
            }

        }


        private void reSetGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.RESET, "", new Point(0, 0));
                socket.Send(data);
            }

            ResetGame();
        }

        private void timerCheckEndGame_Tick(object sender, EventArgs e)
        {
            if (Mode1AndMode2.status_game == statusGame.EndGame)
            {
                Mode1AndMode2.status_game = statusGame.ContinueGame;

                if (Mode1AndMode2.modeplay == 3)
                {
                    SocketData data = new SocketData((int)TypeData.RESET, "", new Point(0, 0));
                    socket.Send(data);
                }

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
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.UNDO, "", new Point(0, 0));
                socket.Send(data);
            }
            this.boardGui.Undo();
        }


        #region Update when resetgame
        delegate void updateResetGame(Form form);
        private void UpdateReset(Form form)
        {
            if (lvChat.InvokeRequired)
            {
                // this is worker thread
                updateResetGame del = new updateResetGame(UpdateReset);
                form.Invoke(del, new object[] { form });
            }
            else
            {
                // this is UI thread
                //chuc nang nay can fix bug haha. tu tu se xong thoi
                this.boardGui.boardLogic.CreateDefaultListPieceBoard();
                this.boardGui.boardLogic.CreateCellBoard(ChessPieceSide.WHITE);
                this.boardGui.AddCellGuiAndCell();

                //reset lai lich su. ahihi
                BoardGui.moveHistory.ListMoveHistory.Clear();
            }
        }
        #endregion
        public void ResetGame()
        {
            //chuc nang nay can fix bug haha. tu tu se xong thoi
            this.boardGui.boardLogic.CreateDefaultListPieceBoard();
            this.boardGui.boardLogic.CreateCellBoard(ChessPieceSide.WHITE);
            this.boardGui.AddCellGuiAndCell();

            //reset lai lich su. ahihi
            BoardGui.moveHistory.ListMoveHistory.Clear();
        }

        #region Update listView when chating LAN
        delegate void updateListViewTextDelegate(ListViewItem lvi);
        private void UpdateListView(ListViewItem lvi)
        {
            if (lvChat.InvokeRequired)
            {
                // this is worker thread
                updateListViewTextDelegate del = new updateListViewTextDelegate(UpdateListView);
                lvChat.Invoke(del, new object[] { lvi });
            }
            else
            {
                // this is UI thread
                lvChat.Items.Add(lvi);
            }
        }
        #endregion


        #region Update board when move to LAN
        delegate void updateExcuteLANDelegate(Form form);
        private void ExcuteMoveLAN(Form form)
        {
            if (form.InvokeRequired)
            {
                // this is worker thread
                updateExcuteLANDelegate del = new updateExcuteLANDelegate(ExcuteMoveLAN);
                form.Invoke(del, new object[] { form });
            }
            else
            {
                // this is UI thread
                Point position = Mode1AndMode2.moveLAN; // x la diem dau- y la diem den
                ChessPieces piece =(ChessPieces) this.boardGui.boardLogic.GetCell(position.X).GetChessPieces().Clone();
                //  MessageBox.Show(piece.chessPieceType.chessPieceName);

                Cell cell = this.boardGui.boardLogic.GetCell(position.Y);
                Move move;

                if (cell.Occupied())
                     move = new AttackMove(piece, position.Y, cell.GetChessPieces());
                else
                     move = new NormalMove(piece, position.Y);

                    
                

                CellGui cellG = this.boardGui.GetCellGui(position.X);

               // khong can thiet, cainay chi cap nhat game thoi ma, chi can hien ben nguoi choi duoc roi
                if (move.IsPromote())
                {
                    cellG.SetPromote(move);

                    //set lai icon cho ben nay-ban chat la phia ben nay board logic khong co con nay
                    //nhung chi co ben kia duoc di nen khong sao het- danh lua nguoi choi.

                }


                this.boardGui.boardLogic = move.ExcuteMove(this.boardGui.boardLogic);
                BoardGui.moveHistory.ListMoveHistory.Add(move);
                if (move.TheKingDie(this.boardGui.boardLogic))
                {
                    Mode1AndMode2.status_game = statusGame.EndGame;

                }

                //set lai icon tren ban co cho nguoi xem biet duoc  da di.-> thay doi board gui
                this.boardGui.GetCellGui(position.X).SetImageIcon();
                this.boardGui.GetCellGui(position.Y).SetImageIcon();

                //reset thanh chua chon nuoc co nao va set nguoi choi tiep theo vi da danh xong nuoc co nay.
                this.boardGui.CellSelectedFirst = this.boardGui.CellSelectedSecond = null;
                this.boardGui.boardLogic.SetNextPlayer();
            }
           
        }
        #endregion

        #region Update board when UNDO to LAN
        delegate void updateUndoLANDelegate(Form form);
        private void ExcuteUndoLAN(Form form)
        {
            if (form.InvokeRequired)
            {
                // this is worker thread
                updateUndoLANDelegate del = new updateUndoLANDelegate(ExcuteUndoLAN);
                form.Invoke(del, new object[] { form });
            }
            else
            {
                // this is UI thread

                if (BoardGui.moveHistory.GetNearestMove() != null)
                {
                    this.boardGui.boardLogic = BoardGui.moveHistory.Undo(this.boardGui.boardLogic);
                    this.boardGui.listCellGui[BoardGui.moveHistory.GetNearestMove().actionPiece.chessPiecePosition].SetImageIcon();
                    this.boardGui.listCellGui[BoardGui.moveHistory.GetNearestMove().destination].SetImageIcon();
                    BoardGui.moveHistory.RemoveHistoryForThisMove();
                    this.boardGui.boardLogic.SetNextPlayer();
                }     
            }

        }
        #endregion

        void Listen()
        {
            SocketData data = (SocketData)socket.Receive();

            switch (data.flag)
            {
                case (int)TypeData.GUI_TIN:
                    ListViewItem lvi = new ListViewItem(data.message);
                    UpdateListView(lvi);                 
                    break;

                case (int)TypeData.MOVE:
                    Mode1AndMode2.moveLAN = data.move;
                    ExcuteMoveLAN(this);
                    break;

                case (int)TypeData.START:
                    StartGame(ChessPieceSide.WHITE); 
                    break;

                case (int)TypeData.RESET:
                    // ResetGame();
                    UpdateReset(this);
                    break;

                case (int)TypeData.UNDO:
                    ExcuteUndoLAN(this);
                    break;
            }


        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (btnSendMessage.Text == "Kết nối")
            {
                btnSendMessage.Text = "Gửi tin";

                socket.IP = tbmess.Text;
                Mode1AndMode2.namePlayer = "Player black";
                if (!socket.ConnectServer())
                {
                    socket.CreateServer();
                    Mode1AndMode2.namePlayer = "Player white";
                }


                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                           // break;
                        }
                        catch
                        {

                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            {
                string mess = Mode1AndMode2.namePlayer + " : " + tbmess.Text;
                ListViewItem lvi = new ListViewItem(mess);
                lvChat.Items.Add(lvi);
                SocketData data = new SocketData((int)TypeData.GUI_TIN, mess, Mode1AndMode2.moveLAN);
                socket.Send(data);
                tbmess.Clear();
            }

        }

        private void Mode1AndMode2_Load(object sender, EventArgs e)
        {
            if (Mode1AndMode2.modeplay == 3)
            {
                tbmess.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
                if (string.IsNullOrEmpty(tbmess.Text))
                {
                    tbmess.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
                }
            }            
        }

        #region Update boardgame when start game
        delegate void updateBoardDelegate(Label lb,BoardGui boardGui,ChessPieceSide side);
        private void UpdateBoardeGui(Label lb, BoardGui boardGui, ChessPieceSide side)
        {
            if (lbPlay.InvokeRequired)
            {
                // this is worker thread
                updateBoardDelegate del = new updateBoardDelegate(UpdateBoardeGui);
                lvChat.Invoke(del, new object[] { lb,boardGui,side });
            }
            else
            {
                // this is UI thread
                lbPlay.Visible = false;
                boardGui = new BoardGui(side);
                this.Controls.Add(boardGui);
                this.boardGui = boardGui;

            }
        }
        #endregion
        void StartGame(ChessPieceSide side)
        {
            //lbPlay.Visible = false;
            UpdateBoardeGui(lbPlay,boardGui,side);
            timerCheckEndGame.Start();
            //timerProcessbarPlayer.Start();

        }
        private void lbPlay_Click(object sender, EventArgs e)
        {
            //neu dang o che do danh qua LAN thu truyen cho ben kia biet da bat dau
            if (Mode1AndMode2.modeplay == 3)
            {
                SocketData data = new SocketData((int)TypeData.START, "start", Mode1AndMode2.moveLAN);
                socket.Send(data);
            }
           

            StartGame(ChessPieceSide.WHITE);
            // MessageBox.Show("da send click");

        }

        private void timerCheckMove_Tick(object sender, EventArgs e)
        {
            //neu co su di chuyen
            if (CellGui.checkmove != Mode1AndMode2.checkmove)
            {
                Mode1AndMode2.checkmove = CellGui.checkmove;
                SocketData data = new SocketData((int)TypeData.MOVE, "di chuyen", Mode1AndMode2.moveLAN);
                socket.Send(data);
            }
        }
    }


}
