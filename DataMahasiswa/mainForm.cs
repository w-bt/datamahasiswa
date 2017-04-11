using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMahasiswa
{
    public partial class mainForm : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=MELKA-PC;Initial Catalog=DataMHS;Integrated Security=True");

        public void displayData()
        {
            SqlCommand qry = new SqlCommand("select * from Mahasiswa", sqlCon);

            sqlCon.Open();
            SqlDataReader rdData = qry.ExecuteReader();
            DataTable myData = new DataTable();
            myData.Load(rdData);
            myDataGridView.DataSource = myData;
            sqlCon.Close();
        }

        public mainForm()
        {
            InitializeComponent();
            displayData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            // query insert untuk kolom nim dan nama
            SqlCommand qry = new SqlCommand("insert into Mahasiswa (nim, nama) values ('"+textNIM.Text+"','"+textNama.Text+"')", sqlCon);
            sqlCon.Open();
            qry.ExecuteNonQuery();
            sqlCon.Close();
            // tampilkan pada myDataGridView setelah insert
            displayData();
            // tampilkan pesan bahwa data berhasil ditambahkan
            MessageBox.Show("Data sukses ditambahkan!");
            // bersihkan semua textbox
            textID.Clear();
            textNIM.Clear();
            textNama.Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // query update untuk kolom nim dan nama berdasarkan ID
            SqlCommand qry = new SqlCommand("update Mahasiswa set nim='"+textNIM.Text+"', nama='"+textNama.Text+"' where mhsTableID='"+textID.Text+"'", sqlCon);
            sqlCon.Open();
            qry.ExecuteNonQuery();
            sqlCon.Close();
            // tampilkan pada myDataGridView setelah update
            displayData();
            // tampilkan pesan bahwa data berhasil diubah
            MessageBox.Show("Data " + textID.Text + " sukses diubah!");
            // bersihkan semua textbox
            textID.Clear();
            textNIM.Clear();
            textNama.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // query delete berdasarkan ID
            SqlCommand qry = new SqlCommand("delete from Mahasiswa where mhsTableID='" + textID.Text + "'", sqlCon);
            sqlCon.Open();
            qry.ExecuteNonQuery();
            sqlCon.Close();
            // tampilkan pada myDataGridView setelah delete
            displayData();
            // tampilkan pesan bahwa data berhasil dihapus
            MessageBox.Show("Data " + textID.Text + " sukses dihapus!");
            // bersihkan semua textbox
            textID.Clear();
            textNIM.Clear();
            textNama.Clear();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // query select berdasarkan nama
            SqlCommand qry = new SqlCommand("select * from Mahasiswa where nama LIKE '%" + textNama.Text + "%'", sqlCon);

            sqlCon.Open();
            SqlDataReader rdData = qry.ExecuteReader();
            DataTable myData = new DataTable();
            myData.Load(rdData);
            myDataGridView.DataSource = myData;
            sqlCon.Close();
            // tampilkan pesan bahwa pencarian selesai
            MessageBox.Show("Pencarian selesai!");
            // bersihkan semua textbox
            textID.Clear();
            textNIM.Clear();
            textNama.Clear();
        }
    }
}
