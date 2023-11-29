using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 坦克大战_新_
{
    public partial class Form1 : Form
    {
        private Thread t;
        private static Graphics windowG;
        private static Bitmap tempBmp;

        public Form1()
        {
            //初始界面出现在屏幕中央
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            windowG = this.CreateGraphics();          

            tempBmp = new Bitmap(560,600);
            Graphics bmpG = Graphics.FromImage(tempBmp);
            GameFramework.g = bmpG;

            //避免阻塞，创建一个线程
            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
        }

        private static void GameMainThread()
        {
            //GameFramework类来进行管理总体逻辑运行的进程（框架）
            GameFramework.Start();
            int sleepTime = 1000 / 60;

            while (true)
            {
                GameFramework.g.Clear(Color.Black);
                GameFramework.Update();//控制在60FPS就够了其实，一秒运行60次
                windowG.DrawImage(tempBmp,0,0);
                Thread.Sleep(sleepTime);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode==Keys.W)检测按键按了哪一个
            GameObjectManager.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);
        }
    }
}
