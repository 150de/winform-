using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战_新_
{
    enum Direction
    { 
        Up,
        Down,
        Left,
        Right
    }

    class Movething:GameObject
    {
        private Object _lock = new Object();
        public Bitmap BitmapUp { set; get; }
        public Bitmap BitmapDown { set; get; }
        public Bitmap BitmapLeft { set; get; }
        public Bitmap BitmapRight { set; get; }

        public int Speed { set; get; }

        private Direction dir;
        public Direction Dir { get { return dir; }
            set
            {
                dir = value;
                Bitmap bmp = null;
                switch (dir)
                {
                    case Direction.Up:
                        bmp = BitmapUp; 
                        break;
                    case Direction.Down:
                        bmp = BitmapDown;
                        break;
                    case Direction.Left:
                        bmp = BitmapLeft;
                        break;
                    case Direction.Right:
                        bmp = BitmapRight;
                        break;
                }
                lock (_lock)
                {
                    Width = bmp.Width;
                    Height = bmp.Height;
                }                
            }
        }

        protected override Image GetImage()
        {
            Bitmap bitmap = null;
            
            switch (Dir)
            {
                case Direction.Up:
                    bitmap =  BitmapUp;
                    break;
                case Direction.Down:
                    bitmap = BitmapDown;
                    break;
                case Direction.Left:
                    bitmap = BitmapLeft;
                    break;
                case Direction.Right:
                    bitmap = BitmapRight;
                    break;
            }            
            bitmap.MakeTransparent(Color.Black);
            return bitmap;
        }

        public override void DrawSelf()
        {
            lock (_lock)
            {
                base.DrawSelf();
            }
            
        }

    }
}
