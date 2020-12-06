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
    public partial class Message2 : Form
    {
        public Message2()
        {
            InitializeComponent();
        }

        private void Message2_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
            this.Close();

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
