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

                // Query dengan JOIN antara tabel tbl_penghuni dan tbl_kamar
                query = @"SELECT p.id_penghuni, p.id_kamar, p.id_mahasiswa, p.tingkat, p.nama_penghuni, k.tipe_kamar 
                  FROM tbl_penghuni p
                  JOIN tbl_kamar k ON p.id_kamar = k.id_kamar";
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
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[5].HeaderText = "Tipe Kamar";

                // Populate ComboBox with unique 'tipe_kamar' values
                cmbType.Items.Clear(); // Assuming cmbType is the ComboBox
                query = "SELECT DISTINCT tipe_kamar FROM tbl_kamar";
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                MySqlDataReader reader = perintah.ExecuteReader();
                while (reader.Read())
                {
                    cmbType.Items.Add(reader["tipe_kamar"].ToString());
                }
                reader.Close();
                koneksi.Close();

                txtIDPenghuni.Clear();
                txtIDKamar.Clear();
                txtIDMahasiswa.Clear();
                txtTingkat.Clear();
                txtNamapenghuni.Clear();
                cmbType.SelectedIndex = -1; // Clear ComboBox selection

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
            FormInfo formInfo = new FormInfo();
            formInfo.Show ();
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
            FormDorm formDorm = new FormDorm();
            formDorm.Show();
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
                // Memastikan semua field telah diisi
                if (txtIDPenghuni.Text != "" && txtIDKamar.Text != "" && txtIDMahasiswa.Text != "" && txtTingkat.Text != "" && txtNamapenghuni.Text != "")
                {
                    // Query untuk menyimpan data ke tabel tbl_penghuni tanpa memasukkan tipe_kamar
                    string query = @"INSERT INTO tbl_penghuni (id_penghuni, id_kamar, id_mahasiswa, tingkat, nama_penghuni) 
                             VALUES (@id_penghuni, @id_kamar, @id_mahasiswa, @tingkat, @nama_penghuni);";

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);

                    // Menambahkan parameter untuk mencegah SQL Injection
                    perintah.Parameters.AddWithValue("@id_penghuni", txtIDPenghuni.Text);
                    perintah.Parameters.AddWithValue("@id_kamar", txtIDKamar.Text);
                    perintah.Parameters.AddWithValue("@id_mahasiswa", txtIDMahasiswa.Text);
                    perintah.Parameters.AddWithValue("@tingkat", txtTingkat.Text);
                    perintah.Parameters.AddWithValue("@nama_penghuni", txtNamapenghuni.Text);

                    // Eksekusi query insert
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    // Mengecek hasil eksekusi query
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Sukses ...");
                        Form2_Load(null, null);  // Memperbarui data setelah insert
                    }
                    else
                    {
                        MessageBox.Show("Gagal Insert Data ...");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak Lengkap !!");
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
                // Memastikan semua field diisi sebelum melakukan update
                if (txtIDPenghuni.Text != "" && txtIDKamar.Text != "" && txtIDMahasiswa.Text != "" && txtTingkat.Text != "" && txtNamapenghuni.Text != "")
                {
                    // Query untuk update data di tabel tbl_penghuni
                    string query = @"UPDATE tbl_penghuni SET 
                                id_kamar = @id_kamar, 
                                id_mahasiswa = @id_mahasiswa, 
                                tingkat = @tingkat, 
                                nama_penghuni = @nama_penghuni
                             WHERE id_penghuni = @id_penghuni";

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);

                    // Menambahkan parameter untuk mencegah SQL Injection
                    perintah.Parameters.AddWithValue("@id_kamar", txtIDKamar.Text);
                    perintah.Parameters.AddWithValue("@id_mahasiswa", txtIDMahasiswa.Text);
                    perintah.Parameters.AddWithValue("@tingkat", txtTingkat.Text);
                    perintah.Parameters.AddWithValue("@nama_penghuni", txtNamapenghuni.Text);
                    perintah.Parameters.AddWithValue("@id_penghuni", txtIDPenghuni.Text);

                    // Eksekusi query update
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    // Mengecek hasil eksekusi query
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Sukses ...");

                        // Perbarui data tipe kamar pada DataGridView setelah update
                        Form2_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal Update Data ...");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak Lengkap !!");
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
                string query = "";

                // Tentukan query berdasarkan parameter yang diisi
                if (!string.IsNullOrEmpty(txtIDPenghuni.Text))
                {
                    query = @"SELECT p.*, k.tipe_kamar 
                      FROM tbl_penghuni p
                      INNER JOIN tbl_kamar k ON p.id_kamar = k.id_kamar
                      WHERE p.id_penghuni = @id_penghuni";
                }
                else if (!string.IsNullOrEmpty(txtIDKamar.Text))
                {
                    query = @"SELECT p.*, k.tipe_kamar 
                      FROM tbl_penghuni p
                      INNER JOIN tbl_kamar k ON p.id_kamar = k.id_kamar
                      WHERE p.id_kamar = @id_kamar";
                }
                else if (!string.IsNullOrEmpty(txtIDMahasiswa.Text))
                {
                    query = @"SELECT p.*, k.tipe_kamar 
                      FROM tbl_penghuni p
                      INNER JOIN tbl_kamar k ON p.id_kamar = k.id_kamar
                      WHERE p.id_mahasiswa = @id_mahasiswa";
                }
                else if (!string.IsNullOrEmpty(txtTingkat.Text))
                {
                    query = @"SELECT p.*, k.tipe_kamar 
                      FROM tbl_penghuni p
                      INNER JOIN tbl_kamar k ON p.id_kamar = k.id_kamar
                      WHERE p.tingkat = @tingkat";
                }
                else if (!string.IsNullOrEmpty(txtNamapenghuni.Text))
                {
                    query = @"SELECT p.*, k.tipe_kamar 
                      FROM tbl_penghuni p
                      INNER JOIN tbl_kamar k ON p.id_kamar = k.id_kamar
                      WHERE p.nama_penghuni = @nama_penghuni";
                }
                else if (cmbType.SelectedIndex != -1) // Check if a value is selected in the ComboBox
                {
                    query = @"SELECT p.*, k.tipe_kamar 
                      FROM tbl_penghuni p
                      INNER JOIN tbl_kamar k ON p.id_kamar = k.id_kamar
                      WHERE k.tipe_kamar = @tipe_kamar";
                }
                else
                {
                    MessageBox.Show("Data yang Anda pilih tidak ada!!");
                    return;
                }

                // Menjalankan pencarian dengan query dinamis
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);

                // Menambahkan parameter ke query untuk mencegah SQL Injection
                if (!string.IsNullOrEmpty(txtIDPenghuni.Text)) perintah.Parameters.AddWithValue("@id_penghuni", txtIDPenghuni.Text);
                if (!string.IsNullOrEmpty(txtIDKamar.Text)) perintah.Parameters.AddWithValue("@id_kamar", txtIDKamar.Text);
                if (!string.IsNullOrEmpty(txtIDMahasiswa.Text)) perintah.Parameters.AddWithValue("@id_mahasiswa", txtIDMahasiswa.Text);
                if (!string.IsNullOrEmpty(txtTingkat.Text)) perintah.Parameters.AddWithValue("@tingkat", txtTingkat.Text);
                if (!string.IsNullOrEmpty(txtNamapenghuni.Text)) perintah.Parameters.AddWithValue("@nama_penghuni", txtNamapenghuni.Text);
                if (cmbType.SelectedIndex != -1) perintah.Parameters.AddWithValue("@tipe_kamar", cmbType.SelectedItem.ToString()); // Use selected item from ComboBox

                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();

                // Cek apakah data ditemukan dan update tampilan
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow kolom = ds.Tables[0].Rows[0]; // Ambil hanya baris pertama, karena id biasanya unik
                    txtIDPenghuni.Text = kolom["id_penghuni"].ToString();
                    txtIDKamar.Text = kolom["id_kamar"].ToString();
                    txtIDMahasiswa.Text = kolom["id_mahasiswa"].ToString();
                    txtTingkat.Text = kolom["tingkat"].ToString();
                    txtNamapenghuni.Text = kolom["nama_penghuni"].ToString();
                    cmbType.SelectedItem = kolom["tipe_kamar"].ToString(); // Set selected item in ComboBox

                    dataGridView1.DataSource = ds.Tables[0];
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnClear.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Data Tidak Ada !!");
                    Form2_Load(null, null); // Memuat ulang data jika tidak ada hasil
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
                // Pastikan ID Penghuni telah diisi
                if (!string.IsNullOrEmpty(txtIDPenghuni.Text))
                {
                    // Konfirmasi penghapusan data
                    if (MessageBox.Show("Anda Yakin Menghapus Data Ini ??", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // Membuat query untuk menghapus hanya data tingkat, nama mahasiswa, dan id mahasiswa
                        query = "UPDATE tbl_penghuni SET tingkat = NULL, nama_penghuni = NULL, id_mahasiswa = NULL WHERE id_penghuni = @id_penghuni";

                        // Menyiapkan koneksi dan perintah
                        koneksi.Open();
                        perintah = new MySqlCommand(query, koneksi);
                        perintah.Parameters.AddWithValue("@id_penghuni", txtIDPenghuni.Text);

                        // Eksekusi query
                        int res = perintah.ExecuteNonQuery();
                        koneksi.Close();

                        // Menampilkan hasil eksekusi
                        if (res == 1)
                        {
                            MessageBox.Show("Data Terhapus Suksess (Tingkat, Nama Mahasiswa, ID Mahasiswa) ...");
                            Form2_Load(null, null); // Memuat ulang data setelah penghapusan
                        }
                        else
                        {
                            MessageBox.Show("Gagal Menghapus Data");
                        }
                    }
                }
                else
                {
                    // Menampilkan pesan jika ID Penghuni tidak diisi
                    MessageBox.Show("Data Yang Anda Pilih Tidak Ada !!");
                }
            }
            catch (Exception ex)
            {
                // Menangkap dan menampilkan error jika terjadi exception
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Frmpenggguna frmpenggguna = new Frmpenggguna();
            frmpenggguna.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
