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
                this.lvChat.Enabled = btnSendMessage.Enabled = tbmess.Enabled = false;
            else
                //nguoc lai la danh qua LAN
                timerCheckMove.Start();


            socket = new SocketManager();
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

        #region Update listView when chating
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

        
        void Listen()
        {
            SocketData data = (SocketData)socket.Receive();
            MessageBox.Show("da nhan  "+data.flag);
            switch (data.flag)
            {
                case (int)TypeData.GUI_TIN:
                    ListViewItem lvi = new ListViewItem(data.message);
                    //lvChat.Items.Add(lvi);
                    UpdateListView(lvi);                 
                    break;

                case (int)TypeData.MOVE:
                    ListViewItem lvii = new ListViewItem(data.move.X + "->" + data.move.Y);
                    lvChat.Items.Add(lvii);
                    break;

                case (int)TypeData.START:
                   // MessageBox.Show("ok");
                    StartGame(ChessPieceSide.BLACK);
                    
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
            tbmess.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(tbmess.Text))
            {
                tbmess.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
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
            SocketData data = new SocketData((int)TypeData.START, "start", Mode1AndMode2.moveLAN);
            socket.Send(data);

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
