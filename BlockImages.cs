using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//ブロックの名前
public enum BlockType
{
    btn_blank = 0,
    btn_hold=1,
    btn_flag,//ここまで右 2
    ans_mine,
    btn_holdX,
    btn_flagX,
    ans_mineX,
    ans_blank
};

namespace Minesweeper
{
    //画像オブジェクトの配置
    public class BlockImages
    {
        private const int ANS_BLANCK_NUM = 9;

        private static Image?[]? blockImages;

        /// <summary>
        /// 画像の初期化
        /// </summary>
        private static void SetImages()
        {
            blockImages = new Image[Enum.GetValues(typeof(BlockType)).Length + ANS_BLANCK_NUM - 1];
            for (var i = 0; i < (int)BlockType.ans_blank; i++)
            {
                blockImages[i] = CallResource(((BlockType)i).ToString());
            }

            for (var i = 0; i < ANS_BLANCK_NUM; i++)
            {
                blockImages[(int)BlockType.ans_blank+i] = CallResource(BlockType.ans_blank.ToString() + i);
            }

        }

        /// <summary>
        /// resourceから画像を呼び出す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Image? CallResource(string name)
        {
            Image? im = Properties.Resources.ResourceManager.GetObject(name, Properties.Resources.Culture) as Image;
            if (im == null)
            {
                MessageBox.Show(name + "という名前の画像は存在しません");
            }
            return im;
        }

        /// <summary>
        /// ブロックの画像をかえす
        /// </summary>
        public static Image? SetImage(BlockType type,int num =0)
        {
            if (blockImages==null||blockImages.Length == 0 )
            {
                SetImages();
            }

            if (blockImages?[(int)type + num] == null) MessageBox.Show(blockImages?.Length.ToString());

            if (num >= ANS_BLANCK_NUM)
            {
                num = 0;
            }

            return blockImages?[(int)type + num];

        }

    }

 
}
