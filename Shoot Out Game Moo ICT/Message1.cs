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
    public partial class Message1 : Form
    {
        public Message1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();            
            Form2 form = new Form2();
            form.ShowDialog();
            this.Close();
        }

        private void Message1_Load(object sender, EventArgs e)
        {

        }
    }
}
