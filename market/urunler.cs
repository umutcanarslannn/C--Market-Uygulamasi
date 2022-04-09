using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace market
{
    public partial class urunler : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=market.accdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        int id = 0;


        public urunler()
        {
            InitializeComponent();
            doldur();
        }

        public void textSifirla()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        void doldur()
        {
           
            da = new OleDbDataAdapter("Select * from urunler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "urunler");
            dataGridView1.DataSource = ds.Tables["urunler"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (button1.Text == "Ekle")
                {
                    ///Aynı ürün var mı
                    int ayni = 0;
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from urunler where barkod='" + textBox1.Text + "'", con);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ayni = 1;

                    }

                    con.Close();

                    ///Aynı ürün var mı
                    if (ayni == 0)
                    {
                        cmd = new OleDbCommand();
                        cmd.Connection = con;
                        con.Open();
                        cmd.CommandText = "insert into urunler (barkod,ad,fiyat) values (@barkod,@ad,@fiyat)";
                        cmd.Parameters.AddWithValue("@barkod", (textBox1.Text));
                        cmd.Parameters.AddWithValue("@ad", textBox2.Text);
                        cmd.Parameters.AddWithValue("@fiyat", Convert.ToDouble(textBox3.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                        label1.Visible = true;
                        label1.Text = "Başarıyla eklendi!";
                    }
                    else
                    {
                        MessageBox.Show("Bu barkoda sahip ürün eklenmiş!","Bilgi");
                        
                    }

                }
                else
                {
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "update urunler set barkod='" + textBox1.Text + "',ad='" + textBox2.Text + "',fiyat='" + textBox3.Text + "' where kimlik=" + id;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    button1.Text = "Ekle";
                    label1.Visible = true;
                    label1.Text = "Başarıyla düzenlendi!";
                    //Ürün arama
                }
                doldur();
               

                button1.BackColor = System.Drawing.Color.FromArgb(21, 114, 161);
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hatalı Giriş!","Dikkat");
               
            }
            finally
            {
                con.Close();
                textSifirla();
            }
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            }
            catch(Exception hata)
            {

            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[0].Index)
            {    
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            button1.Text = "Kaydet";
            }
            else if (e.ColumnIndex == dataGridView1.Columns[1].Index)
            {
              DialogResult sonuc =  MessageBox.Show("Seçili satır silinsin mi?","Dikkat", MessageBoxButtons.YesNo , MessageBoxIcon.Warning);
                if(sonuc==DialogResult.Yes)
                {
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from urunler where Kimlik=" + id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    label1.Visible = true;
                    label1.Text = "Başarıyla silindi!";
                    doldur();
                    textSifirla();
                    button1.Text = "Ekle";
                }
                else
                {
                    
                }
            }

        }

        private void urunler_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ClearSelection();
            radioButton1.Checked = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength > 1)
            {
                if (radioButton1.Checked == true)
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=market.accdb");
                    da = new OleDbDataAdapter("SElect * from urunler where ad like '%" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "urunler");
                    dataGridView1.DataSource = ds.Tables["urunler"];
                    con.Close();
                }
                else
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=market.accdb");
                    da = new OleDbDataAdapter("SElect * from urunler where barkod like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "urunler");
                    dataGridView1.DataSource = ds.Tables["urunler"];
                    con.Close();
                }
            }
            else
            {
                doldur();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
