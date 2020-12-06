using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoot_Out_Game_Moo_ICT
{
    public partial class Form1 : Form
    {
        bool goleft, goright, godown, gameover; 
        bool goUp;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int character_on = 1;
        int ammo = 10;
        int zombieSpeed = 3;
        Random randNum = new Random();
        List<PictureBox> zombiesList = new List<PictureBox>();
        int score;


        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameover = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();
              
            }

            txtAmmo.Text = "Ammo : " + ammo;
            txtScore.Text = "Kills : " + score;

            //player movement 
            if (goleft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goright == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 45)
            {
                player.Top -= speed;
            }
            if (godown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }




                //Health ka kam hona
                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }


                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealth -= 1; 
                    }

                    //moving of enemy :
                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= zombieSpeed; 
                        ((PictureBox)x).Image = Properties.Resources.zleft; 
                    }

                    if (((PictureBox)x).Top > player.Top)
                    {
                        ((PictureBox)x).Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup; 
                    }
                    if (((PictureBox)x).Left < player.Left)
                    {
                        ((PictureBox)x).Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright; 
                    }
                    if (((PictureBox)x).Top < player.Top)
                    {
                        ((PictureBox)x).Top += zombieSpeed; 
                        ((PictureBox)x).Image = Properties.Resources.zdown; 
                    }
                }

                foreach (Control j in this.Controls)
                {

                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            
                            if (score == 10)
                            {

                                
                                GameTimer.Stop();
                                //this.Hide();
                                Message1 form = new Message1();
                                form.ShowDialog();

                                
                            }
                            if (score == 15)
                            {
                                GameTimer.Stop();
                                this.Hide();
                                Message2 form = new Message2();
                                form.ShowDialog();

                            
                            }

                            this.Controls.Remove(j); 
                            ((PictureBox)j).Dispose(); 
                            this.Controls.Remove(x); 
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies(); 
                        }
                    }
                }
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameover == true)
            {
                return;
            }

            if (character_on == 1)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goleft = true;
                    facing = "left";
                    player.Image = Properties.Resources.left;
                }

                if (e.KeyCode == Keys.Right)
                {
                    goright = true;
                    facing = "right";
                    player.Image = Properties.Resources.right;
                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Properties.Resources.up;
                }

                if (e.KeyCode == Keys.Down)
                {
                    facing = "down";
                    godown = true;
                    player.Image = Properties.Resources.down;
                }
            }
            else if (character_on == 2)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goleft = true;
                    facing = "left";
                    player.Image = Properties.Resources.leftA;
                }

                if (e.KeyCode == Keys.Right)
                {
                    goright = true;
                    facing = "right";
                    player.Image = Properties.Resources.rightA;
                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Properties.Resources.upA;
                }

                if (e.KeyCode == Keys.Down)
                {
                    facing = "down";
                    godown = true;
                    player.Image = Properties.Resources.downA;
                }
            }
            else if (character_on == 3)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goleft = true;
                    facing = "left";
                    player.Image = Properties.Resources.leftB;
                }

                if (e.KeyCode == Keys.Right)
                {
                    goright = true;
                    facing = "right";
                    player.Image = Properties.Resources.rightB;
                }

                if (e.KeyCode == Keys.Up)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = Properties.Resources.upB;
                }

                if (e.KeyCode == Keys.Down)
                {
                    facing = "down";
                    godown = true;
                    player.Image = Properties.Resources.downB;
                }
            }

        }

        public void KeyIsUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

            if (e.KeyCode == Keys.Space && ammo > 0 && gameover == false)
            {
                ammo--;
                ShootBullet(facing);

                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
            if (e.KeyCode == Keys.Enter && gameover == true)
            {
                MessageBox.Show("Game Over");
                RestartGame();

                
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {

        }

        
        //Bullet fire
        private void ShootBullet(string direction)
        {
                Bullet shoot = new Bullet(); 
                shoot.direction = direction; 
                shoot.bulletLeft = player.Left + (player.Width / 2); 
                shoot.bulletTop = player.Top + (player.Height / 2);
                shoot.MakeBullet(this); 
        }

        //enemy restart 
        private void MakeZombies()
        {
            PictureBox zombie = new PictureBox(); 
            zombie.Tag = "zombie"; 
            zombie.Image = Properties.Resources.zdown; 
            zombie.Left = randNum.Next(0, 900); 
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize; 
            this.Controls.Add(zombie); 
            player.BringToFront(); 
        }


        //Ammo refill
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox(); 
            ammo.Image = Properties.Resources.ammo_Image; 
            ammo.SizeMode = PictureBoxSizeMode.AutoSize; 
            ammo.Left = randNum.Next(10, 890); 
            ammo.Top = randNum.Next(60, 600);
            ammo.Tag = "ammo"; 
            this.Controls.Add(ammo); 
            ammo.BringToFront(); 
            player.BringToFront(); 
        }

        private void RestartGame()
        {
            player.Image = Properties.Resources.up;
            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }
            zombiesList.Clear();
            for (int i = 0; i < 3; i++);
            {
                MakeZombies();
            }

            goUp = false;
            godown = false;
            goleft = false;
            goright = false;
            gameover = false;
            playerHealth = 100;
            score = 0;
            ammo = 10;

            GameTimer.Start();

        }
        public void Level2()
        {
            character_on = 2;
            player.Image = Properties.Resources.upA;
            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }
            zombiesList.Clear();
            for (int i = 0; i < 5; i++) ;
            {
                MakeZombies();
            }

            goUp = false;
            godown = false;
            goleft = false;
            goright = false;
            gameover = false;
            playerHealth = 100;
            score = 11;
            ammo = 10;
            zombieSpeed = 4;

            GameTimer.Start();

        }
        public void Level3()
        {
            character_on = 3;
            player.Image = Properties.Resources.upB;
            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }
            zombiesList.Clear();
            for (int i = 0; i < 6; i++) ;
            {
                MakeZombies();
            }

            goUp = false;
            godown = false;
            goleft = false;
            goright = false;
            gameover = false;
            playerHealth = 100;
            score = 21;
            ammo = 10;
            zombieSpeed = 5;

            GameTimer.Start();

        }
    }
}
