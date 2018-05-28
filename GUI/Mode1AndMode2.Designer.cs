namespace GUI
{
    partial class Mode1AndMode2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mode1AndMode2));
            this.tbmess = new System.Windows.Forms.TextBox();
            this.pnChat = new System.Windows.Forms.Panel();
            this.lvChat = new System.Windows.Forms.ListView();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reSetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCheckEndGame = new System.Windows.Forms.Timer(this.components);
            this.timerProcessbarPlayer = new System.Windows.Forms.Timer(this.components);
            this.timerCheckMove = new System.Windows.Forms.Timer(this.components);
            this.proBlack = new System.Windows.Forms.ProgressBar();
            this.proWhite = new System.Windows.Forms.ProgressBar();
            this.pbPlayer2 = new System.Windows.Forms.PictureBox();
            this.pbPlayer1 = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pbSound = new System.Windows.Forms.PictureBox();
            this.pnChat.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSound)).BeginInit();
            this.SuspendLayout();
            // 
            // tbmess
            // 
            this.tbmess.Location = new System.Drawing.Point(0, 217);
            this.tbmess.Multiline = true;
            this.tbmess.Name = "tbmess";
            this.tbmess.Size = new System.Drawing.Size(204, 59);
            this.tbmess.TabIndex = 2;
            // 
            // pnChat
            // 
            this.pnChat.Controls.Add(this.lvChat);
            this.pnChat.Controls.Add(this.btnSendMessage);
            this.pnChat.Controls.Add(this.tbmess);
            this.pnChat.Location = new System.Drawing.Point(836, 302);
            this.pnChat.Name = "pnChat";
            this.pnChat.Size = new System.Drawing.Size(306, 276);
            this.pnChat.TabIndex = 3;
            // 
            // lvChat
            // 
            this.lvChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvChat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lvChat.Location = new System.Drawing.Point(0, 0);
            this.lvChat.Name = "lvChat";
            this.lvChat.Size = new System.Drawing.Size(306, 211);
            this.lvChat.TabIndex = 4;
            this.lvChat.UseCompatibleStateImageBehavior = false;
            this.lvChat.View = System.Windows.Forms.View.List;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Location = new System.Drawing.Point(204, 217);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(102, 59);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Kết nối";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1160, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.reSetGameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // reSetGameToolStripMenuItem
            // 
            this.reSetGameToolStripMenuItem.Name = "reSetGameToolStripMenuItem";
            this.reSetGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reSetGameToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.reSetGameToolStripMenuItem.Text = "ResetGame";
            this.reSetGameToolStripMenuItem.Click += new System.EventHandler(this.reSetGameToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // timerCheckEndGame
            // 
            this.timerCheckEndGame.Tick += new System.EventHandler(this.timerCheckEndGame_Tick);
            // 
            // timerProcessbarPlayer
            // 
            this.timerProcessbarPlayer.Interval = 1000;
            this.timerProcessbarPlayer.Tick += new System.EventHandler(this.timerProcessbarPlayer_Tick);
            // 
            // timerCheckMove
            // 
            this.timerCheckMove.Tick += new System.EventHandler(this.timerCheckMove_Tick);
            // 
            // proBlack
            // 
            this.proBlack.Location = new System.Drawing.Point(836, 261);
            this.proBlack.Name = "proBlack";
            this.proBlack.Size = new System.Drawing.Size(306, 16);
            this.proBlack.TabIndex = 9;
            this.proBlack.Value = 100;
            // 
            // proWhite
            // 
            this.proWhite.Location = new System.Drawing.Point(836, 140);
            this.proWhite.Name = "proWhite";
            this.proWhite.Size = new System.Drawing.Size(306, 16);
            this.proWhite.TabIndex = 8;
            this.proWhite.Value = 100;
            // 
            // pbPlayer2
            // 
            this.pbPlayer2.BackColor = System.Drawing.Color.Tomato;
            this.pbPlayer2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlayer2.BackgroundImage")));
            this.pbPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayer2.Location = new System.Drawing.Point(836, 169);
            this.pbPlayer2.Name = "pbPlayer2";
            this.pbPlayer2.Size = new System.Drawing.Size(89, 91);
            this.pbPlayer2.TabIndex = 7;
            this.pbPlayer2.TabStop = false;
            // 
            // pbPlayer1
            // 
            this.pbPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlayer1.BackgroundImage")));
            this.pbPlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlayer1.Location = new System.Drawing.Point(836, 45);
            this.pbPlayer1.Name = "pbPlayer1";
            this.pbPlayer1.Size = new System.Drawing.Size(89, 93);
            this.pbPlayer1.TabIndex = 6;
            this.pbPlayer1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DarkGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnReset.Location = new System.Drawing.Point(490, 582);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 37);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "New game";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnExit.Location = new System.Drawing.Point(611, 582);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 37);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.DarkGray;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnPlay.Location = new System.Drawing.Point(475, 302);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(117, 48);
            this.btnPlay.TabIndex = 10;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.DarkGray;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.ForeColor = System.Drawing.Color.DarkViolet;
            this.btnUndo.Location = new System.Drawing.Point(365, 582);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(102, 37);
            this.btnUndo.TabIndex = 10;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // pbSound
            // 
            this.pbSound.BackColor = System.Drawing.Color.Transparent;
            this.pbSound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbSound.BackgroundImage")));
            this.pbSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSound.Location = new System.Drawing.Point(19, 42);
            this.pbSound.Name = "pbSound";
            this.pbSound.Size = new System.Drawing.Size(38, 38);
            this.pbSound.TabIndex = 11;
            this.pbSound.TabStop = false;
            this.pbSound.Click += new System.EventHandler(this.pbSound_Click);
            // 
            // Mode1AndMode2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1160, 631);
            this.Controls.Add(this.pbSound);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.proBlack);
            this.Controls.Add(this.proWhite);
            this.Controls.Add(this.pbPlayer2);
            this.Controls.Add(this.pbPlayer1);
            this.Controls.Add(this.pnChat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mode1AndMode2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bàn cờ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mode1AndMode2_FormClosed);
            this.Load += new System.EventHandler(this.Mode1AndMode2_Load);
            this.pnChat.ResumeLayout(false);
            this.pnChat.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbmess;
        private System.Windows.Forms.Panel pnChat;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reSetGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timerCheckEndGame;
        private System.Windows.Forms.Timer timerProcessbarPlayer;
        private System.Windows.Forms.ListView lvChat;
        private System.Windows.Forms.Timer timerCheckMove;
        private System.Windows.Forms.ProgressBar proBlack;
        private System.Windows.Forms.ProgressBar proWhite;
        private System.Windows.Forms.PictureBox pbPlayer2;
        private System.Windows.Forms.PictureBox pbPlayer1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.PictureBox pbSound;
    }
}