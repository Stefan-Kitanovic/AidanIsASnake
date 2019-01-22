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
            ((System.ComponentModel.ISupportInitialize)(this.gameBackground)).BeginInit();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 631);
            this.Controls.Add(this.gameEndMsgLabel);
            this.Controls.Add(this.gameScoreNumLabel);
            this.Controls.Add(this.gameScoreLabel);
            this.Controls.Add(this.gameBackground);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameBackground;
        private System.Windows.Forms.Label gameScoreLabel;
        private System.Windows.Forms.Label gameScoreNumLabel;
        private System.Windows.Forms.Label gameEndMsgLabel;
        private System.Windows.Forms.Timer gameTimer;
    }
}

