namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            player = new Panel();
            player2 = new Panel();
            SuspendLayout();
            // 
            // player
            // 
            player.BackColor = SystemColors.HotTrack;
            player.Location = new Point(67, 67);
            player.Name = "player";
            player.Size = new Size(30, 30);
            player.TabIndex = 0;
            // 
            // player2
            // 
            player2.BackColor = Color.Red;
            player2.Location = new Point(582, 199);
            player2.Name = "player2";
            player2.Size = new Size(30, 30);
            player2.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(782, 553);
            Controls.Add(player2);
            Controls.Add(player);
            KeyPreview = true;
            Name = "Form1";
            Text = "Tags";
            ResumeLayout(false);
        }

        #endregion

        private Panel player;
        private Panel player2;
    }
}
