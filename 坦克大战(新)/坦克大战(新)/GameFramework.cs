using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 坦克大战_新_.Properties;

namespace 坦克大战_新_
{
    enum GameState
    {
        Running,
        GameOver
    }

    class GameFramework
    {
        public static Graphics g;
        private static GameState gameState = GameState.Running;

        public static void Start()
        {
            SoundManager.InitSound();
            SoundManager.PlayStart();
            GameObjectManager.Start();
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMyTank();
        }

        public static void Update()
        {//就相当于FPS，update被调用的次数就是我们的帧率
            //GameObjectManager.DrawMap();
            //GameObjectManager.DrawMyTank();

            if (gameState == GameState.Running)
            {
                GameObjectManager.Update();
            }
            else if (gameState == GameState.GameOver)
            {
                GameOverUpdate();
            }
        }
        
        private static void GameOverUpdate()
        {
            //Bitmap bmp = Resources.GameOver;
            //bmp.MakeTransparent(Color.Black);
            //int x = 450 / 2 - Resources.GameOver.Width / 2;
            //int y = 450 / 2 - Resources.GameOver.Height / 2;

            //g.DrawImage(bmp,x,y);

            Bitmap bmp = Resources.GameOver;
            bmp.MakeTransparent(Color.Black);
            g.DrawImage(bmp, -30, -10);
        }

        public static void ChangeToGameOver()
        {
            gameState = GameState.GameOver;
        }


    }
}
