using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public class MoveHistory
    {
        public List<Move> ListMoveHistory;

        public MoveHistory()
        {
            ListMoveHistory = new List<Move>();
        }

        public Move GetNearestMove()
        {
            if (ListMoveHistory.Count > 0)
            {
                return ListMoveHistory[ListMoveHistory.Count - 1];
            }

            return null;
        }

        public Board Undo(Board board)
        {
            Move MoveUndo = this.GetNearestMove();

            int pos = MoveUndo.actionPiece.chessPiecePosition;
            board.listCell[pos] = new OccupiedCell(pos, MoveUndo.actionPiece);
            board.SetPiece(MoveUndo.actionPiece);
            board.RemovePiece(board.ListChessPiece[MoveUndo.destination]);

            if (MoveUndo.isAttack())
            {
                board.listCell[MoveUndo.destination] = new OccupiedCell(MoveUndo.destination, MoveUndo.getAttackedPiece());
                board.SetPiece(MoveUndo.getAttackedPiece());
            }
            else
            {
                board.listCell[MoveUndo.destination] = new EmptyCell(pos);
            }

          //  RemoveHistoryForThisMove();

            return board;
        }

        public void RemoveHistoryForThisMove()
        {
            Move m = ListMoveHistory[ListMoveHistory.Count - 1];
            ListMoveHistory.Remove(m);
        }
    }
}
