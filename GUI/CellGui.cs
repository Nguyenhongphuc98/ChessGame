using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ObjectGame;

namespace GUI
{
    class CellGui : Panel
    {
        public int IDCellGui { get; }
        BoardGui board { get; set; }
               

        public Color backGroundColor { get; set; }
        public static Color activeColor { get; set; }
        public static int checkmove=0; //neu khac voi move tren giao dien tuc la da thay doi -> gui socket


       public CellGui(BoardGui board,int id)
        {
            this.IDCellGui = id;
            this.board = board;

            this.SetColor();

            
            CellGui.activeColor = Color.GreenYellow;
            this.Size = new Size(60, 60);

            this.SetImageIcon();

            this.MouseClick += CellGui_MouseClick;
        }

        private void SetColor()
        {
            //set color for cell in the board
            if ((this.IDCellGui / 8) % 2 == 0)
            {
                if (this.IDCellGui % 2 != 0)
                    this.backGroundColor = Color.White;
                else
                    this.backGroundColor = Color.Gray;
            }
            else
            {
                if (this.IDCellGui % 2 != 0)
                    this.backGroundColor = Color.Gray;
                else
                    this.backGroundColor = Color.White;
            }
            this.BackColor = backGroundColor;
        }


        public void SetPromote(Move move)
        {
            PromotionForm f = new PromotionForm();
            f.SetIconImage(move.actionPiece.side);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                //set lai con tot vua di la con duoc chon tu bang phong chuc.
                ChessPieces p = f.GetChessPiece(move.actionPiece.side);
                p.chessPiecePosition = move.actionPiece.chessPiecePosition;
                move.actionPiece = p;
            }
        }

        private void CellGui_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                //reset color
                foreach(CellGui cel in this.board.listCellGui)
                {
                    cel.SetColor();
                    //cel.BackColor = Color.Bisque;
                }

                this.BackColor = CellGui.activeColor;

                if (Mode1AndMode2.modeplay == 1)
                {
                    #region   che do mode 1-  2player

                    //neu day la chon o dau tien
                    if (this.board.CellSelectedFirst == null)
                    {
                        this.CheckToHilightMove();
                    }
                    //nguoc lai da chon 1 o co truoc do
                    else
                    {
                        this.board.CellSelectedSecond = this.board.boardLogic.GetCell(this.IDCellGui);

                        //neu lan chon thu 2 cung quan co voi lan thu nhat thi set lai day la lan thu nhat.
                        ChessPieces piece = this.board.CellSelectedSecond.GetChessPieces();
                        if (piece != null && this.board.CellSelectedFirst.GetChessPieces().side == piece.side)
                        {
                            this.board.CellSelectedFirst = this.board.CellSelectedSecond;
                            this.board.CellSelectedSecond = null;
                            this.CheckToHilightMove();
                        }
                        else
                        {
                            //nguoc lai lam chon thu 2 khong phai quan minh co nghia la di chuyen hoac tan cong.
                            //check xem co nam trong list di chuyen hop le khong?

                            //lay ra danh sach di chuyen cua quan co truoc di
                            //kiem tra vi tri chuyen toi co hop le hay khong?
                            List<Move> listMove = new List<ObjectGame.Move>();
                            listMove = this.board.CellSelectedFirst.GetChessPieces().getLegalMoves(this.board.boardLogic);

                            foreach (Move move in listMove)
                            {
                                if (move.destination == this.board.CellSelectedSecond.iPosition)
                                {

                                    //kiem tra xem thu co phai la phong chuc cho tot hay khong.
                                    if (move.IsPromote())
                                    {
                                        SetPromote(move);
                                    }


                                    //thay doi board logic
                                    this.board.boardLogic = move.ExcuteMove(this.board.boardLogic);

                                    //dua move vao lich su.
                                    BoardGui.moveHistory.ListMoveHistory.Add(move);
                                    // MessageBox.Show("da them 1 move vao stack");


                                    //kiem tra coi end game hay k
                                    if (move.TheKingDie(this.board.boardLogic))
                                    {
                                        Mode1AndMode2.status_game = statusGame.EndGame;

                                    }

                                    //set lai icon tren ban co cho nguoi xem biet duoc  da di.-> thay doi board gui
                                    this.board.GetCellGui(this.board.CellSelectedFirst.iPosition).SetImageIcon();
                                    this.board.GetCellGui(this.board.CellSelectedSecond.iPosition).SetImageIcon();

                                    //reset thanh chua chon nuoc co nao va set nguoi choi tiep theo vi da danh xong nuoc co nay.
                                    this.board.CellSelectedFirst = this.board.CellSelectedSecond = null;
                                    this.board.boardLogic.SetNextPlayer();

                                    break;
                                }

                            }
                        }
                        
                    }
                    #endregion
                }
                else
                    if (Mode1AndMode2.modeplay == 2)
                {
                    //chi cho phep danh quan mau trang- quan den do may danh
                    if(this.board.boardLogic.Curentlayer.sideplayer==ChessPieceSide.WHITE)
                    {
                        #region che do mode 2- danh voi may

                        //neu day la chon o dau tien
                        if (this.board.CellSelectedFirst == null)
                        {
                            this.CheckToHilightMove();
                        }
                        //nguoc lai da chon 1 o co truoc do
                        else
                        {
                            this.board.CellSelectedSecond = this.board.boardLogic.GetCell(this.IDCellGui);

                            //neu lan chon thu 2 cung quan co voi lan thu nhat thi set lai day la lan thu nhat.
                            ChessPieces piece = this.board.CellSelectedSecond.GetChessPieces();
                            if (piece != null && this.board.CellSelectedFirst.GetChessPieces().side == piece.side)
                            {
                                this.board.CellSelectedFirst = this.board.CellSelectedSecond;
                                this.board.CellSelectedSecond = null;
                                this.CheckToHilightMove();
                            }
                            else
                            {
                                //nguoc lai lam chon thu 2 khong phai quan minh co nghia la di chuyen hoac tan cong.
                                //check xem co nam trong list di chuyen hop le khong?

                                //lay ra danh sach di chuyen cua quan co truoc di
                                //kiem tra vi tri chuyen toi co hop le hay khong?
                                List<Move> listMove = new List<ObjectGame.Move>();
                                listMove = this.board.CellSelectedFirst.GetChessPieces().getLegalMoves(this.board.boardLogic);

                                foreach (Move move in listMove)
                                {
                                    if (move.destination == this.board.CellSelectedSecond.iPosition)
                                    {

                                        //kiem tra xem thu co phai la phong chuc cho tot hay khong.
                                        if (move.IsPromote())
                                        {
                                            SetPromote(move);
                                        }


                                        //thay doi board logic
                                        this.board.boardLogic = move.ExcuteMove(this.board.boardLogic);

                                        //dua move vao lich su.
                                        BoardGui.moveHistory.ListMoveHistory.Add(move);
                                        // MessageBox.Show("da them 1 move vao stack");


                                        //kiem tra coi end game hay k
                                        if (move.TheKingDie(this.board.boardLogic))
                                        {
                                            Mode1AndMode2.status_game = statusGame.EndGame;

                                        }

                                        //set lai icon tren ban co cho nguoi xem biet duoc  da di.-> thay doi board gui
                                        this.board.GetCellGui(this.board.CellSelectedFirst.iPosition).SetImageIcon();
                                        this.board.GetCellGui(this.board.CellSelectedSecond.iPosition).SetImageIcon();

                                        //reset thanh chua chon nuoc co nao va set nguoi choi tiep theo vi da danh xong nuoc co nay.
                                        this.board.CellSelectedFirst = this.board.CellSelectedSecond = null;
                                        this.board.boardLogic.SetNextPlayer();

                                        //*******************************************
                                        //Cho AI Danh o day *************************
                                        //*******************************************
                                        break;
                                    }

                                }
                            }

                        }
                        #endregion
                    }


                }
                else
                    if (Mode1AndMode2.modeplay == 3)
                {
                    //chi cho phep danh con co cua no( tren ban co no)
                    //if((Mode1AndMode2.namePlayer == "Player black"&&this.board.boardLogic.Curentlayer.sideplayer==ChessPieceSide.BLACK)
                    //    ||(Mode1AndMode2.namePlayer == "Player white" && this.board.boardLogic.Curentlayer.sideplayer == ChessPieceSide.WHITE))
                    //{
                        #region che do mode 3- danh LAN

                        //neu day la chon o dau tien
                        if (this.board.CellSelectedFirst == null)
                        {
                            this.CheckToHilightMove();
                        }
                        //nguoc lai da chon 1 o co truoc do
                        else
                        {
                            this.board.CellSelectedSecond = this.board.boardLogic.GetCell(this.IDCellGui);

                            //neu lan chon thu 2 cung quan co voi lan thu nhat thi set lai day la lan thu nhat.
                            ChessPieces piece = this.board.CellSelectedSecond.GetChessPieces();
                            if (piece != null && this.board.CellSelectedFirst.GetChessPieces().side == piece.side)
                            {
                                this.board.CellSelectedFirst = this.board.CellSelectedSecond;
                                this.board.CellSelectedSecond = null;
                                this.CheckToHilightMove();
                            }
                            else
                            {
                                //nguoc lai lam chon thu 2 khong phai quan minh co nghia la di chuyen hoac tan cong.
                                //check xem co nam trong list di chuyen hop le khong?

                                //lay ra danh sach di chuyen cua quan co truoc di
                                //kiem tra vi tri chuyen toi co hop le hay khong?
                                List<Move> listMove = new List<ObjectGame.Move>();
                                listMove = this.board.CellSelectedFirst.GetChessPieces().getLegalMoves(this.board.boardLogic);

                                foreach (Move move in listMove)
                                {
                                    if (move.destination == this.board.CellSelectedSecond.iPosition)
                                    {

                                        //kiem tra xem thu co phai la phong chuc cho tot hay khong.
                                        if (move.IsPromote())
                                        {
                                        SetPromote(move);
                                        }


                                        //thay doi board logic
                                        this.board.boardLogic = move.ExcuteMove(this.board.boardLogic);

                                        //dua move vao lich su.
                                        BoardGui.moveHistory.ListMoveHistory.Add(move);
                                        // MessageBox.Show("da them 1 move vao stack");


                                        //kiem tra coi end game hay k
                                        if (move.TheKingDie(this.board.boardLogic))
                                        {
                                            Mode1AndMode2.status_game = statusGame.EndGame;

                                        }

                                        //set lai icon tren ban co cho nguoi xem biet duoc  da di.-> thay doi board gui
                                        this.board.GetCellGui(this.board.CellSelectedFirst.iPosition).SetImageIcon();
                                        this.board.GetCellGui(this.board.CellSelectedSecond.iPosition).SetImageIcon();

                                        //reset thanh chua chon nuoc co nao va set nguoi choi tiep theo vi da danh xong nuoc co nay.
                                        this.board.CellSelectedFirst = this.board.CellSelectedSecond = null;
                                        this.board.boardLogic.SetNextPlayer();

                                        //thuc hien gui du lieu qua LAN
                                        //su dung timer kiem tra de xem da thuc hien move

                                        Mode1AndMode2.moveLAN = new Point(move.actionPiece.chessPiecePosition,move.destination);
                                        CellGui.checkmove++;
                                        break;
                                    }

                                }
                            }

                        }

                        #endregion
                    //}


                }


            }
        }

        /// <summary>
        /// kiểm tra thỏa mãn điều kiện thì sẽ gọi hàm hightlight
        /// </summary>
        private void CheckToHilightMove()
        {
            // lay cell vaf quan co nay ra de kiem tra
            this.board.CellSelectedFirst = this.board.boardLogic.GetCell(this.IDCellGui);
            this.board.workingPiece = this.board.CellSelectedFirst.GetChessPieces();

            //neu o nay khong co quan co hoac khong phai luot cua no thi khong co chon thi xem nhu chua chon
            if (this.board.workingPiece == null||this.board.workingPiece.side!=this.board.boardLogic.Curentlayer.sideplayer)
            {
                this.board.CellSelectedFirst = null;

            }
            else
            //nguoc lai da chon o co quan co la cua minh -> hien thi cac nuoc co co the di
            this.hightlightLegalMoves();
        }

        /// <summary>
        /// thựch hiện hightlight những ô có thể đi
        /// </summary>
        private void hightlightLegalMoves()
        {
            List<Move> listLegalMoves = new List<ObjectGame.Move>();

            listLegalMoves = this.board.workingPiece.getLegalMoves(this.board.boardLogic);

            foreach(Move move in listLegalMoves)
            {
                this.board.GetCellGui(move.destination).BackColor = CellGui.activeColor;
            }
        }

       // public List<CellGui> listRelationCellGui = new List<CellGui>();

        public void SetImageIcon()
        {
            //neu o dang co quan co chiem giu thi moi can set
            if(this.board.boardLogic.GetCell(this.IDCellGui).Occupied())
            {
                ChessPieces piece = (ChessPieces) board.boardLogic.GetCell(this.IDCellGui).GetChessPieces().Clone();
                string side = piece.side == ChessPieceSide.BLACK ? "black" : "white";
                string name = piece.chessPieceType.chessPieceName;
                string imagePath = Application.StartupPath + "\\ChessPieceIcon\\" + side + name + ".png";
                this.BackgroundImage = Image.FromFile(@imagePath);
                this.BackgroundImageLayout = ImageLayout.Center;
            }
            else
            {
                this.BackgroundImage = null;
            }
        }
    }
}
