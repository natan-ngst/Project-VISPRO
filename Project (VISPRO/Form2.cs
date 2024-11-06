using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace Project__VISPRO
{
    
    public partial class Form2 : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;

        private DataSet ds = new DataSet();
        private string alamat, query;
        public Form2()
        {
            alamat = "server=localhost; database=db_asrama; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from tbl_penghuni");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[0].HeaderText = "ID Penghuni";
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[1].HeaderText = "ID Kamar";
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[2].HeaderText = "ID Mahasiswa";
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[3].HeaderText = "Tingkat";
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[4].HeaderText = "Nama Penghuni";

                txtIDPenghuni.Clear();
                txtIDKamar.Clear();
                txtIDMahasiswa.Clear();
                txtTingkat.Clear();
                txtTingkat.Clear();
                txtNamapenghuni.Clear();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnClear.Enabled = true;
                btnSave.Enabled = true;
                btnClear.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Hide();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show ();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form2_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDorm_Click(object sender, EventArgs e)
        {
            FrmKamar frmKamar = new FrmKamar();
            frmKamar.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDPenghuni.Text != "" && txtIDKamar.Text != "" && txtIDMahasiswa.Text != "" && txtTingkat.Text != "" && txtNamapenghuni.Text != "")
                {

                    query = string.Format("insert into tbl_penghuni  values ('{0}','{1}','{2}','{3}','{4}');", txtIDPenghuni.Text, txtIDKamar.Text, txtIDMahasiswa.Text, txtTingkat.Text, txtNamapenghuni.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        Form2_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal insert Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Form2_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDPenghuni.Text != "" && txtIDKamar.Text != "" && txtIDMahasiswa.Text != "" && txtTingkat.Text != "" && txtNamapenghuni.Text != "")
                {

                    query = string.Format("update tbl_penghuni set id_kamar = '{0}', id_mahasiswa = '{1}', tingkat = '{2}', nama_penghuni = '{3}' where id_penghuni = '{4}'", txtIDKamar.Text, txtIDMahasiswa.Text, txtTingkat.Text, txtNamapenghuni.Text, txtIDPenghuni.Text);


                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Suksess ...");
                        Form2_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Update Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDPenghuni.Text != "")
                {
                    query = string.Format("select * from tbl_penghuni where id_penghuni = '{0}'", txtIDPenghuni.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtIDPenghuni.Text = kolom["id_penghuni"].ToString();
                            txtIDKamar.Text = kolom["id_kamar"].ToString();
                            txtIDMahasiswa.Text = kolom["id_mahasiswa"].ToString();
                            txtTingkat.Text = kolom["tingkat"].ToString();
                            txtNamapenghuni.Text = kolom["nama_penghuni"].ToString();

                        }
                        
                        dataGridView1.DataSource = ds.Tables[0];
                        btnSave.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnClear.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        Form2_Load(null, null);
                    }

                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDPenghuni.Text != "")
                {
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        query = string.Format("Delete from tbl_penghuni where id_penghuni = '{0}'", txtIDPenghuni.Text);
                        ds.Clear();
                        koneksi.Open();
                        perintah = new MySqlCommand(query, koneksi);
                        adapter = new MySqlDataAdapter(perintah);
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();
                        if (res == 1)
                        {
                            MessageBox.Show("Delete Data Suksess ...");
                        }
                        else
                        {
                            MessageBox.Show("Gagal Delete data");
                        }
                    }
                    Form2_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCarikamar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDKamar.Text != "")
                {
                    query = string.Format("select * from tbl_penghuni where id_kamar = '{0}'", txtIDKamar.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtIDPenghuni.Text = kolom["id_penghuni"].ToString();
                            txtIDKamar.Text = kolom["id_kamar"].ToString();
                            txtIDMahasiswa.Text = kolom["id_mahasiswa"].ToString();
                            txtTingkat.Text = kolom["tingkat"].ToString();
                            txtNamapenghuni.Text = kolom["nama_penghuni"].ToString();

                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnSave.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnClear.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        Form2_Load(null, null);
                    }

                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCarinama_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNamapenghuni.Text != "")
                {
                    query = string.Format("select * from tbl_penghuni where nama_penghuni = '{0}'", txtNamapenghuni.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txtIDPenghuni.Text = kolom["id_penghuni"].ToString();
                            txtIDKamar.Text = kolom["id_kamar"].ToString();
                            txtIDMahasiswa.Text = kolom["id_mahasiswa"].ToString();
                            txtTingkat.Text = kolom["tingkat"].ToString();
                            txtNamapenghuni.Text = kolom["nama_penghuni"].ToString();

                        }

                        dataGridView1.DataSource = ds.Tables[0];
                        btnSave.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnClear.Enabled = true;
                        btnClear.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                        Form2_Load(null, null);
                    }

                }
                else
                {
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
