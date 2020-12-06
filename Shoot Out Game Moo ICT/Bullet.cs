using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Shoot_Out_Game_Moo_ICT
{
   class Bullet
   {
        public string direction; 
        public int speed = 20;  
        private PictureBox bullet = new PictureBox(); 
        private Timer bulletTimer = new Timer();  
        public int bulletLeft;
        public int bulletTop;

        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.OrangeRed;
            bullet.Size = new Size(8, 8);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();
            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
        }

        public void BulletTimerEvent(object sender, EventArgs e)
        {

            if (direction == "left")
            {
                bullet.Left -= speed;
            }
            if (direction == "right")
            {
                bullet.Left += speed;
            }

            if (direction == "up")
            {
                bullet.Top -= speed;
            }

            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bullet.Left < 16 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 616)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }

        }
}
