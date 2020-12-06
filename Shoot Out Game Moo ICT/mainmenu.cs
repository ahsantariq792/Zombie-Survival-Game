using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Shoot_Out_Game_Moo_ICT
{
    public partial class mainmenu : Form
    {
       
        public mainmenu()
        {
            InitializeComponent();
            SoundPlayer sp = new SoundPlayer();

        }
        private void Mainmenu_Load(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\mainmenu.wav";
            sp.PlayLooping();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The player is stuck in place full of monsters.You have to keep fighting to remain alive " +
                "and keep refilling the ammo" + Environment.NewLine +"Controls :" 
                + Environment.NewLine + "Use arrow Keys to move the player" 
                + Environment.NewLine + "Space Key to Fire"
                + Environment.NewLine + "Enter Keys to restart" );
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
