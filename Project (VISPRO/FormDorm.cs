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
    public partial class FormDorm : Form
    {
        public FormDorm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCR3 formCR3 = new FormCR3();
            formCR3.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnCheck1_Click(object sender, EventArgs e)
        {
            FormCR1 formCR1 = new FormCR1();
            formCR1.Show();
            this.Hide();
        }

        private void btnCheck2_Click(object sender, EventArgs e)
        {
            FormCR2 formCR2 = new FormCR2();
            formCR2.Show();
            this.Hide();
        }
    }
}
