using Microsoft.Data.SqlClient;
using System;
using System.Net;
using System.Timers;

namespace Minesweeper
{


    public partial class Form1 : Form
    {
        private Double playTime = 0;
        private Block[][] blocks;

        private int score = 0;

        public Form1()
        {
            InitializeComponent();

            ResizeUI();

            Size size = new Size(pnBlock.Size.Width / Program.BLOCKNUM_W, pnBlock.Size.Height / Program.BLOCKNUM_H);//ブロックのサイズ
            blocks = new Block[Program.BLOCKNUM_W][];

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = new Block[Program.BLOCKNUM_H];

                for (int j = 0; j < blocks[i].Length; j++)
                {
                    blocks[i][j] = new Block(i, j, size, pnBlock);
                    blocks[i][j].Click += Block_Click;
                }
            }

            Program.endDel += new StepDel(EndGame);

            EnabledUI(true);

        }

        private void BtStart_Click(object sender, EventArgs e)
        {

            if (Program.startDel == null) return;
            EnabledUI(false);
            playTime = 0;
            timer.Start();

            Program.startDel();

            SetMine();
            Program.step = Step.PLAY;

            Program.openBlockNum = 0;
            Program.flagNum = 0;
            Program.collectFlagNum = 0;

        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            if (Program.step == Step.PLAY)
            {
                btStop.Text = "▶";
                Program.step = Step.STOP;
            }
            else if (Program.step == Step.STOP)
            {
                btStop.Text = "| |";
                Program.step = Step.PLAY;
            }
        }


        public void Block_Click(object? sender, EventArgs e)
        {
            if (Program.step != Step.PLAY) return;

            MouseEventArgs click = (MouseEventArgs)e;
            if (sender == null) return;
            Block block = (Block)sender;

            Program.clickAddress = block.address;

            if (block.canClick_L && click.Button == MouseButtons.Left)//左クリック可能か
            {
                OpenBlock(block, true);
            }
            else if (block.canClick_R && click.Button == MouseButtons.Right)
            {
                block.SetMark();
            }
        }


        /// <summary>
        ///  ブロックが爆弾ではないとき周囲の、まだ空いていないかつブロック自身と周囲8つのブロックが爆弾ではないブロックを空ける
        /// </summary>
        /// <param name="block"></param>
        private void OpenBlock(Block block, bool click = false)
        {
            int[] address = block.address;
            int[] checkAddress = new int[2];


            Block? checkBlock;
            List<Block> checkBlocks = new List<Block>();

            int aroundMine = 0;


            if (Program.step != Step.PLAY && (int)block.type > 2) return;

            if (block.insideBlock == BlockType.ans_blank)
            {

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (i == 0 && j == 0) continue;
                        checkAddress[0] = address[0] + i;
                        checkAddress[1] = address[1] + j;

                        if (checkAddress[0] >= 0 && checkAddress[0] < blocks.Length &&
                            checkAddress[1] >= 0 && checkAddress[1] < blocks[0].Length)
                        {
                            checkBlock = blocks[checkAddress[0]][checkAddress[1]];
                            if (checkBlock.insideBlock == BlockType.ans_mine)
                            {
                                aroundMine++;
                            }
                            else
                            {
                                checkBlocks.Add(checkBlock);
                            }
                        }
                    }
                }

                if (block.type == BlockType.btn_flag) Program.flagNum--;
                block.type = block.insideBlock;

                block.Image = BlockImages.SetImage(block.type, aroundMine);
                Program.openBlockNum++;
                Program.ClearCheck();

                if (aroundMine == 0)
                {
                    foreach (var openBlock in checkBlocks)
                    {
                        if ((int)openBlock.type <= 2) OpenBlock(openBlock);
                    }
                }
            }
            else if (block.insideBlock == BlockType.ans_mine)
            {
                block.type = block.insideBlock;
                block.Image = BlockImages.SetImage(block.type);
                Program.step = Step.GAMEOVER;
                if (Program.endDel != null) Program.endDel();
            }

        }


        /// <summary>
        /// タイマーのUIを更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Program.step == Step.PLAY)
            {
                playTime += 0.01;
                lbTimer.Text = TimeText(playTime);
            }
        }

        /// <summary>
        /// 時間の表記を変更
        /// </summary>
        /// <param name="playTime"></param>
        /// <returns></returns>
        private string TimeText(Double playTime)
        {
            string timeText = "";
            int conversion = 0;

            int division = 360;
            AddText(false);

            division = 60;
            AddText(false);
            timeText += playTime.ToString("00.00");

            return timeText;


            void AddText(bool must)
            {
                conversion = (int)playTime / division;
                if (conversion > 0 || must)
                {
                    playTime %= division;

                    timeText += conversion.ToString("00") + ":";
                }
            };
        }
        /// <summary>
        /// ゲームの状態に応じてUIの更新
        /// </summary>
        /// <param name="start"></param>
        private void EnabledUI(bool start)
        {
            btStart.Enabled = start;

            lbTimer.Enabled = !start;
            btStop.Enabled = !start;
        }

        /// <summary>
        /// ブロックの個数に応じた比率変更
        /// </summary>
        private void ResizeUI()
        {
            pnBlockSize = new Size(pnBlock.Size.Width , pnBlock.Size.Height );

            int width;
            int height;
            Double blockNumW = Program.BLOCKNUM_W, blockNumH = Program.BLOCKNUM_H;

            if (pnBlockSize.Width / blockNumW < Program.BLOCK_SIZE_MIN ||
               pnBlockSize.Height / blockNumH < Program.BLOCK_SIZE_MIN)
            {
                width = Program.BLOCK_SIZE_MIN * (int)blockNumW;
                height = Program.BLOCK_SIZE_MIN * (int)blockNumH;
            }
            else
            {
                if (blockNumW > blockNumH)
                {
                    width = pnBlockSize.Width;
                    height = (int)(pnBlockSize.Height * blockNumH / blockNumW);
                }
                else
                {
                    width = (int)(pnBlockSize.Width * blockNumW / blockNumH);
                    height = pnBlockSize.Height;
                }
            }

            pnBlock.Size = new Size(width - width % Program.BLOCKNUM_W, height - height % Program.BLOCKNUM_H);

            width = pnBlock.Width + Program.PANNNEL_SPACE * 2;
            height = pnBlock.Height + Program.PANNNEL_SPACE + Program.PANNEL_SPACE_TOP;
            if (width < pnBlockSize.Width + Program.PANNNEL_SPACE * 2) width = pnBlockSize.Width + Program.PANNNEL_SPACE * 2;
            if (height < pnBlockSize.Height ) height = pnBlockSize.Height;
            this.Size = new Size(width, height);

            pnBlock.Location = new Point(width / 2 - pnBlock.Size.Width / 2, Program.PANNEL_SPACE_TOP);

            btStart.Location = new Point(Program.PANNNEL_SPACE, btStart.Location.Y);

        }


        /// <summary>
        /// 終了条件を満たしたとき
        /// </summary>
        /// <param name="clear"></param>
        private void EndGame()
        {
            timer.Stop();


            EnabledUI(true);
            //スコア

            score = Program.SCORE_FLOGBUUNUS * Program.collectFlagNum;

            string endText = "";

            if (Program.step == Step.CLEAR)
            {
                endText = "CLEAR";
                score += Program.SCORE_TIMEBUUNUS - Program.SCORE_DECREASE * (int)playTime;
            }
            else if (Program.step == Step.GAMEOVER) endText = "GAMEOVER";

            endText += $"\nSCORE : {score}";
            MessageBox.Show(endText, "終了");
        }



        /// <summary>
        /// Mineをランダムな位置に配置
        /// </summary>
        private void SetMine()
        {
            int mineNum = Program.mineNum;
            Random rand = new Random();
            Block mineBlock;

            while (mineNum > 0)
            {
                mineBlock = blocks[rand.Next(0, blocks.Length)][rand.Next(0, blocks[0].Length)];
                if (mineBlock.insideBlock != BlockType.ans_mine)
                {
                    mineBlock.insideBlock = BlockType.ans_mine;
                    mineNum--;
                }
            }

        }        

    }
}
