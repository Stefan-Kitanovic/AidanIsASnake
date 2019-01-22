namespace AidanIsASnake
{
    partial class Form1
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
            this.gameBackground = new System.Windows.Forms.PictureBox();
            this.gameScoreLabel = new System.Windows.Forms.Label();
            this.gameScoreNumLabel = new System.Windows.Forms.Label();
            this.gameEndMsgLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.difficultySlider = new System.Windows.Forms.TrackBar();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.gameSpawningText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gamePausedLabel = new System.Windows.Forms.Label();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.volumeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // gameBackground
            // 
            this.gameBackground.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gameBackground.Location = new System.Drawing.Point(0, 0);
            this.gameBackground.Name = "gameBackground";
            this.gameBackground.Size = new System.Drawing.Size(541, 560);
            this.gameBackground.TabIndex = 0;
            this.gameBackground.TabStop = false;
            this.gameBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.graphicsUpdate);
            // 
            // gameScoreLabel
            // 
            this.gameScoreLabel.AutoSize = true;
            this.gameScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameScoreLabel.Location = new System.Drawing.Point(605, 70);
            this.gameScoreLabel.Name = "gameScoreLabel";
            this.gameScoreLabel.Size = new System.Drawing.Size(71, 24);
            this.gameScoreLabel.TabIndex = 1;
            this.gameScoreLabel.Text = "Score:";
            // 
            // gameScoreNumLabel
            // 
            this.gameScoreNumLabel.AutoSize = true;
            this.gameScoreNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameScoreNumLabel.Location = new System.Drawing.Point(675, 72);
            this.gameScoreNumLabel.Name = "gameScoreNumLabel";
            this.gameScoreNumLabel.Size = new System.Drawing.Size(32, 24);
            this.gameScoreNumLabel.TabIndex = 2;
            this.gameScoreNumLabel.Text = "00";
            // 
            // gameEndMsgLabel
            // 
            this.gameEndMsgLabel.AutoSize = true;
            this.gameEndMsgLabel.BackColor = System.Drawing.Color.Black;
            this.gameEndMsgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameEndMsgLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.gameEndMsgLabel.Location = new System.Drawing.Point(22, 23);
            this.gameEndMsgLabel.Name = "gameEndMsgLabel";
            this.gameEndMsgLabel.Size = new System.Drawing.Size(227, 44);
            this.gameEndMsgLabel.TabIndex = 3;
            this.gameEndMsgLabel.Text = "Game Over";
            // 
            // difficultySlider
            // 
            this.difficultySlider.LargeChange = 0;
            this.difficultySlider.Location = new System.Drawing.Point(591, 149);
            this.difficultySlider.Maximum = 4;
            this.difficultySlider.Name = "difficultySlider";
            this.difficultySlider.Size = new System.Drawing.Size(262, 45);
            this.difficultySlider.TabIndex = 1;
            this.difficultySlider.TabStop = false;
            this.difficultySlider.Scroll += new System.EventHandler(this.difficultySlider_Scroll);
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyLabel.Location = new System.Drawing.Point(586, 197);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(119, 26);
            this.difficultyLabel.TabIndex = 4;
            this.difficultyLabel.Text = "Difficulty: ";
            // 
            // gameSpawningText
            // 
            this.gameSpawningText.AutoSize = true;
            this.gameSpawningText.BackColor = System.Drawing.Color.Black;
            this.gameSpawningText.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameSpawningText.ForeColor = System.Drawing.Color.LawnGreen;
            this.gameSpawningText.Location = new System.Drawing.Point(25, 23);
            this.gameSpawningText.Name = "gameSpawningText";
            this.gameSpawningText.Size = new System.Drawing.Size(194, 44);
            this.gameSpawningText.TabIndex = 5;
            this.gameSpawningText.Text = "Spawning";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Press SPACE to pause at any moment";
            // 
            // gamePausedLabel
            // 
            this.gamePausedLabel.AutoSize = true;
            this.gamePausedLabel.BackColor = System.Drawing.Color.Black;
            this.gamePausedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamePausedLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.gamePausedLabel.Location = new System.Drawing.Point(30, 23);
            this.gamePausedLabel.Name = "gamePausedLabel";
            this.gamePausedLabel.Size = new System.Drawing.Size(92, 26);
            this.gamePausedLabel.TabIndex = 7;
            this.gamePausedLabel.Text = "Paused";
            // 
            // volumeSlider
            // 
            this.volumeSlider.Location = new System.Drawing.Point(591, 315);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(262, 45);
            this.volumeSlider.TabIndex = 8;
            this.volumeSlider.TabStop = false;
            this.volumeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeSlider.Scroll += new System.EventHandler(this.volumeSlider_Scroll);
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLabel.Location = new System.Drawing.Point(588, 363);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(107, 26);
            this.volumeLabel.TabIndex = 9;
            this.volumeLabel.Text = "Volume: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 631);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.volumeSlider);
            this.Controls.Add(this.gamePausedLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameSpawningText);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.difficultySlider);
            this.Controls.Add(this.gameEndMsgLabel);
            this.Controls.Add(this.gameScoreNumLabel);
            this.Controls.Add(this.gameScoreLabel);
            this.Controls.Add(this.gameBackground);
            this.Name = "Form1";
            this.Text = "Snek";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficultySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameBackground;
        private System.Windows.Forms.Label gameScoreLabel;
        private System.Windows.Forms.Label gameScoreNumLabel;
        private System.Windows.Forms.Label gameEndMsgLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TrackBar difficultySlider;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.Label gameSpawningText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label gamePausedLabel;
        private System.Windows.Forms.TrackBar volumeSlider;
        private System.Windows.Forms.Label volumeLabel;
    }
}

