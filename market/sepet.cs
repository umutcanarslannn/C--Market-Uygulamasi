using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public partial class sepet : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=market.accdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        DataTable tablo = new DataTable();
        double toplam = 0;


        public sepet()
        {
            InitializeComponent();
           
            tablo.Columns.Add("Ad", typeof(string));
            tablo.Columns.Add("Fiyat", typeof(double));
            dataGridView1.DataSource = tablo;
        }

        private void sepet_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            if (textBox1.TextLength>=4)
            {
               
                 con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from urunler where barkod='"+textBox1.Text+"'", con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   // string ad = dr["ad"].ToString();
                    double fiyat = Convert.ToDouble(dr["fiyat"]);
                   // MessageBox.Show("." + ad.ToString() + " " + fiyat.ToString());
                    tablo.Rows.Add(dr["ad"].ToString(), fiyat.ToString());
                    dataGridView1.DataSource = tablo;
                    toplam = toplam + fiyat;
                    textBox1.Text = "";
                    label2.Text = "Toplam " + toplam.ToString() + " TL";
                    
                }
                
                con.Close();


            }
            textBox1.Select();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tablo.Clear();
            dataGridView1.DataSource = tablo;
            toplam = 0;
            textBox1.Text = "";
            label2.Text = "Toplam 0 TL";
            textBox1.Select();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            toplam = toplam - Convert.ToDouble(dataGridView1.CurrentRow.Cells[1].Value);
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            
           
            dataGridView1.ClearSelection();
            textBox1.Select();
            //if(toplam>=0)
            //{
                
            //}
            //else
            //{
            //    label2.Text = "Toplam 0 TL";
            //}
            if(dataGridView1.RowCount==0)
            {
                label2.Text = "Toplam 0 TL";
            }
            else
            {
                label2.Text = "Toplam " + toplam + " TL";
            }
        }

    
    }
}
