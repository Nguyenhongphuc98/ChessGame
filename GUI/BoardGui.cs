using ObjectGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class BoardGui: TableLayoutPanel
    {
        public List<CellGui> listCellGui { get; set; }
        public Cell CellSelectedFirst { get; set; }
        public Cell CellSelectedSecond { get; set; }
        public Board boardLogic { get; set; }

        public ChessPieces workingPiece { get; set; }

        public BoardGui(ChessPieceSide sidePlayFirst) : base()
        {
            boardLogic = new Board(sidePlayFirst);
            this.CellSelectedFirst = this.CellSelectedSecond = null;

            this.ColumnCount = 8;
            
            this.RowCount = 8;


            this.Size = new Size(538, 538);
            this.Location = new Point(90, 20);
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            listCellGui = new List<CellGui>();
            for(int i=0;i<64;i++)
            {
                CellGui cell = new CellGui(this, i);
                this.Controls.Add(cell,i%8,i/8);
                listCellGui.Add(cell);
            }
        }

        public CellGui GetCellGui(int id)
        {
            return listCellGui[id];
        }
    }
}
