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
    class MyTank:Movething
    {
        public bool IsMoving { get; set; }
        public int HP { get; set; }
        private int originalX;
        private int originalY;

        public MyTank(int x, int y, int speed)
        {
            IsMoving = false;
            this.X = x;
            this.Y = y;
            originalX = x;
            originalY = y;
            this.Speed = speed;
            BitmapDown = Resources.MyTankDown;
            BitmapUp = Resources.MyTankUp;
            BitmapRight = Resources.MyTankRight;
            BitmapLeft = Resources.MyTankLeft;
            this.Dir = Direction.Up;
            HP = 4;
        }

        public override void Update()
        {
            MoveCheck();
            Move();
            base.Update();
        }

        private void MoveCheck()
        {

            # region 检查有无超出边界
            if (Dir == Direction.Up)
            {
                if (Y - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed + Height > 450)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed + Width > 450)
                {
                    IsMoving = false;
                    return;
                }
            }
            #endregion 

            //检查有无与其他元素碰撞
            Rectangle rect = GetRectangle();//得到接下来将要碰撞的位置而不是直接让其碰撞上，这样就可以继续往其他地方走

            switch (Dir)
            {
                case Direction.Up:
                    rect.Y -= Speed;
                    break;
                case Direction.Down:
                    rect.Y += Speed;
                    break;
                case Direction.Left:
                    rect.X -= Speed;
                    break;
                case Direction.Right:
                    rect.X += Speed;
                    break;
            }


            if (GameObjectManager.IsCollidedWall(rect) != null)
            {
                IsMoving = false;
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                IsMoving = false;
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                IsMoving = false;
                return;
            }
        }

        private void Move()
        {
            if (IsMoving == false) return;

            switch (Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }
        }

        public void KeyDown(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:                                                                                        
                    IsMoving = true;
                    Dir = Direction.Up;
                    break;
                case Keys.S:
                    IsMoving = true;
                    Dir = Direction.Down;
                    break;
                case Keys.A:
                    IsMoving = true;
                    Dir = Direction.Left;
                    break;
                case Keys.D:
                    IsMoving = true;
                    Dir = Direction.Right;
                    break;
                case Keys.Space:
                    //bullet
                    Attack();
                    break;
            }
        }

        private void Attack()
        {
            int x = this.X;
            int y = this.Y;
            SoundManager.PlayFire();

            switch (Dir)
            {
                case Direction.Up:
                    x = x + Width / 2;
                    break;
                case Direction.Down:
                    x = x + Width / 2;
                    y += Height;
                    break;
                case Direction.Left:
                    y = y + Height / 2;
                    break;
                case Direction.Right:
                    x = x + Width;
                    y = y + Height / 2;
                    break;
            }

            GameObjectManager.CreateBullet(x,y,Tag.MyTank,Dir);
        }

        public void KeyUp(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                    IsMoving = false;
                    break;
                case Keys.S:
                    IsMoving = false;
                    break;
                case Keys.A:
                    IsMoving = false;
                    break;
                case Keys.D:
                    IsMoving = false;
                    break;
            }
        }

        public void TakeDamage()
        {
            HP--;

            if (HP < 1)
            {
                X = originalX;
                Y = originalY;
                HP = 4;
                SoundManager.PlayAdd(); 
            }
        }
    }
}
