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
    public partial class Form2 : Form1
    {
        public Form2()
        {
            InitializeComponent();
            Level2();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Level2();
        }
    }
}
