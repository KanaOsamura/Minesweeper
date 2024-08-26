using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Block:PictureBox
    {

        public int[] address = new int[2];//0 =x ,1=y

        public BlockType type;
        public BlockType insideBlock;//中身
        public bool canClick_R {get
            {
                bool canClick = false;

                if (Program.step == Step.PLAY && (int)type <= 2) canClick = true;

                return canClick;
            }
        }
        public bool canClick_L
        {
            get
            {
                bool canClick = false;

                if (Program.step == Step.PLAY && type == BlockType.btn_blank) canClick = true;

                return canClick;
            }
        }

        public Block(int x, int y, Size size, Panel pnBlock)
        {
            address[0] = x;
            address[1] = y;

            Parent = pnBlock;
            Size = size;
            Location = new Point(size.Width * address[0], size.Height * address[1]);
            SizeMode = PictureBoxSizeMode.StretchImage; 
            Name = $"block{x}_{y}";


            Start();

            Program.startDel += new StepDel(Start);
            Program.endDel += new StepDel(End);
        }


        /// <summary>
        /// スタート時、ブロックの情報を初期化
        /// </summary>
        private void Start()
        {
            type = BlockType.btn_blank;
            insideBlock = BlockType.ans_blank;
            Image = BlockImages.SetImage(type);
        }

        /// <summary>
        /// 終了時、ブロックの正体を見せる
        /// </summary>
        public void End()
        {
            BlockType imageType=BlockType.btn_blank;
            BlockType mine = BlockType.ans_mine;

            if (insideBlock == mine) imageType = mine;

            switch (type)
            {
                case BlockType.btn_flag:
                    if (insideBlock == mine) imageType = BlockType.btn_flagX;
                    break;
                case BlockType.btn_hold:
                    if (insideBlock == mine) imageType = BlockType.btn_holdX;
                    break;
                case BlockType.ans_mine:
                    imageType = BlockType.ans_mineX;
                    break;
            }

            if (imageType != BlockType.btn_blank && (int)type <= 3) Image = BlockImages.SetImage(imageType);
        }



        /// <summary>
        /// 右クリックのとき、マークを変える
        /// </summary>
        public void SetMark()
        {
            switch (type)
            {
                case BlockType.btn_blank:
                    type = BlockType.btn_flag;
                    if (insideBlock == BlockType.ans_mine) Program.collectFlagNum++;
                    Program.flagNum++;

                    break;
                case BlockType.btn_flag:
                    type = BlockType.btn_hold;

                    if (insideBlock == BlockType.ans_mine) Program.collectFlagNum--;
                    Program.flagNum--;
                    break;
                case BlockType.btn_hold:
                    type = BlockType.btn_blank;
                    break;
            }

            Image = BlockImages.SetImage(type);

            Program.ClearCheck();
        }


    }
}
