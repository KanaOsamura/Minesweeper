namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Size pnBlockSize;


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
            components = new System.ComponentModel.Container();
            btStart = new Button();
            lbTimer = new Label();
            btStop = new Button();
            pnBlock = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btStart
            // 
            btStart.BackColor = SystemColors.ButtonHighlight;
            btStart.Font = new Font("Yu Gothic UI", 14F);
            btStart.Location = new Point(70, 34);
            btStart.Name = "btStart";
            btStart.Size = new Size(270, 90);
            btStart.TabIndex = 0;
            btStart.Text = "START";
            btStart.UseVisualStyleBackColor = false;
            btStart.Click += BtStart_Click;
            // 
            // lbTimer
            // 
            lbTimer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTimer.BackColor = Color.Transparent;
            lbTimer.Font = new Font("Yu Gothic UI", 20F);
            lbTimer.ImageAlign = ContentAlignment.MiddleRight;
            lbTimer.Location = new Point(456, 34);
            lbTimer.Name = "lbTimer";
            lbTimer.Size = new Size(251, 90);
            lbTimer.TabIndex = 1;
            lbTimer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btStop
            // 
            btStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btStop.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            btStop.Location = new Point(729, 34);
            btStop.Name = "btStop";
            btStop.Size = new Size(90, 90);
            btStop.TabIndex = 2;
            btStop.Text = "| |";
            btStop.UseVisualStyleBackColor = true;
            btStop.Click += BtStop_Click;
            // 
            // pnBlock
            // 
            pnBlock.Anchor = AnchorStyles.Bottom;
            pnBlock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnBlock.BorderStyle = BorderStyle.Fixed3D;
            pnBlock.Location = new Point(70, 170);
            pnBlock.Name = "pnBlock";
            pnBlock.Size = new Size(758, 758);
            pnBlock.TabIndex = 3;
            // 
            // timer
            // 
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(874, 979);
            Controls.Add(pnBlock);
            Controls.Add(btStop);
            Controls.Add(lbTimer);
            Controls.Add(btStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }



        #endregion

        private Button btStart;
        private Label lbTimer;
        private Button btStop;
        private Panel pnBlock;
        private System.Windows.Forms.Timer timer;
    }
}
