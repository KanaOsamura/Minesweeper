namespace Minesweeper
{
    enum Step
    {
        START,
        PLAY,
        STOP,
        CLEAR,
        GAMEOVER
    };

    public delegate void StepDel();
    /*
        ���[���F
        ��  Num
        �������@Set

        �֐��@�p�X�J��
        �ϐ��@�L������
        �萔�@�啶���{�X�l�[�N
�@�@  �C�x���g�n���h���@�X�l�[�N
    */
    internal static class Program
    {

        public const int SCORE_TIMEBUUNUS = 5400;
        public const int SCORE_DECREASE = 3;
        public const int SCORE_FLOGBUUNUS = 100;

        public const int BLOCKNUM_H = 5;
        public const int BLOCKNUM_W = 5;

        private const int PANNNEL_SPACE = 50;
        private const int PANNEL_SPACE_TOP = 120;

        public static int panelSpace
        {
            get
            {
                return (int)(PANNNEL_SPACE * screenRate);
            }
        }
        public static int panelSpaceTop
        {
            get
            {
                return (int)(PANNEL_SPACE_TOP * screenRate);
            }
        }

        private const int MINENUM = 3;
        public static int mineNum
        {
            get
            {
                int num = MINENUM;
                if (BLOCKNUM_H * BLOCKNUM_W < num) num = BLOCKNUM_H * BLOCKNUM_W / 2;
                return num;

            }
        }

        private const double FHD_WIDTH = 1920;

#pragma warning disable CS8602 // null �Q�Ƃ̉\����������̂̋t�Q�Ƃł��B
        public static Double screenRate { get { return Screen.PrimaryScreen.Bounds.Width / FHD_WIDTH; } }
        private const int BLOCK_SIZE_MIN = 30;
        public static int blockSizeMin { get { return (int)(BLOCK_SIZE_MIN * screenRate); } }


        public static int blocksNum { get { return BLOCKNUM_H * BLOCKNUM_W; } }
        public static int[] clickAddress = new int[2];
        public static Step step = Step.START;

        public static int openBlockNum = 0;
        public static int collectFlagNum = 0;
        public static int flagNum = 0;


        public static StepDel? startDel;
        public static StepDel? endDel;

        /// <summary>
        /// �I�������𖞂����Ă��邩�ǂ���
        /// </summary>
        public static void ClearCheck()
        {
            if (flagNum == collectFlagNum && collectFlagNum == mineNum)
            {
                step = Step.CLEAR;
                if (endDel != null) endDel();
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}