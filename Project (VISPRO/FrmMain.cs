using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project__VISPRO
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin(); 
            frmLogin.Show();
            this.Hide();
        }

        private void btnDorm_Click(object sender, EventArgs e)
        {
            FrmKamar frmKamar = new FrmKamar();
            frmKamar.Show();
            this.Hide();
        }

        private void btnDorm_Click_1(object sender, EventArgs e)
        {
            FrmKamar frmKamar = new FrmKamar();
            frmKamar.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Form3 form3= new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
