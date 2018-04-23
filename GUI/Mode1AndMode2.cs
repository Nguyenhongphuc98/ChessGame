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

namespace GUI
{
    public partial class Mode1AndMode2 : Form
    {
        BoardGui boardGui;

        public Mode1AndMode2()
        {
            InitializeComponent();
            boardGui = new BoardGui(ChessPieceSide.WHITE);
            this.Controls.Add(boardGui);
        }
    }

    
}
