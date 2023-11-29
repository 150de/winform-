using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战_新_
{
    abstract class GameObject
    {
        public int X { set; get; }
        public int Y { set; get; }

        public int Width { set; get; }
        public int Height { set; get; }

        protected abstract Image GetImage();

        public virtual void DrawSelf()
        {
            Graphics g = GameFramework.g;
            g.DrawImage(GetImage(),X,Y);
        }

        public virtual void Update()
        {
            DrawSelf();
        }

        public Rectangle GetRectangle()
        {
            Rectangle rectangle = new Rectangle(X,Y,Width,Height);
            return rectangle;
        }
    }
}
