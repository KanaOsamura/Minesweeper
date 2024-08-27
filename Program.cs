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

        public const int BLOCKNUM_H = 10;
        public const int BLOCKNUM_W = 10;

        public const int PANNNEL_SPACE = 50;
        public const int PANNEL_SPACE_TOP = 250;

        private const int MINENUM = 10;
        public static int mineNum
        {
            get
            {
                int num = MINENUM;
                if (BLOCKNUM_H * BLOCKNUM_W < num) num = BLOCKNUM_H * BLOCKNUM_W / 2;
                return num;

            }
        }

        public const int BLOCK_SIZE_MIN = 30;


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
            _ = Rdb.Conn;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}