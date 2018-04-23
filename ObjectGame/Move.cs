using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public abstract class Move
    {
        public ChessPieces actionPiece { get; set; }
        public int destination { get; set; }

        public Move(ChessPieces piece,int des)
        {
            this.actionPiece = piece;
            this.destination = des;
        }

        public int GetCurrentPosition()
        {
            return actionPiece.chessPiecePosition;
        }

        public virtual bool isAttack()
        {
            return false;
        }

        public virtual ChessPieces getAttackedPiece()
        {
            return null;
        }

        public bool IsPromote()
        {
            return ((destination / 8 == 0 || destination / 8 == 7) && this.actionPiece.IsPawn());
        }

        public virtual Board ExcuteMove(Board board)
        {
            //thay đổi loại cell trên bàn cờ cho 2 vị trí dang xet.
            // tao 1 quan co cung loai dua vao vi tri moi
            ChessPieces piece = actionPiece.movePiece(this);

            board.listCell[this.GetCurrentPosition()] = new EmptyCell(this.GetCurrentPosition());
            board.listCell[this.destination] = new OccupiedCell(this.destination,piece);

            board.SetPiece(piece);
            board.RemovePiece(this.actionPiece);

            //neu la vua di chuyen thi set vi tri thang vua cho player.
            /*-------------
             * 00000000000000000000000
             * */

            //neu la o vi tri chuyen toi co the phong tuong cho tot
            if(this.IsPromote())
            {
                //mo hop thoai cho chonj tuong muon phong va set lai gia tri cho vi tri moi phong
                /*_____________________________
                 * _______________________________
                 * ______________________
                 * */
            }

            return board;
        }
    }

    public class NormalMove : Move
    {
        public NormalMove(ChessPieces piece, int des) : base(piece, des)
        {
        }
    }

    public class AttackMove : Move
    {
        ChessPieces pieceWasAttacked;

        public AttackMove(ChessPieces piece, int des, ChessPieces pieceWasAttacked) : base(piece, des)
        {
            this.pieceWasAttacked = pieceWasAttacked;
        }

        public override bool isAttack()
        {
            return true;
        }

        public override ChessPieces getAttackedPiece()
        {
            return this.pieceWasAttacked;
        }
    }
}
