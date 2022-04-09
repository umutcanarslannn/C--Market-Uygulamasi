using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            anaekran.Controls.Clear();
            sepet f2 = new sepet();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            anaekran.Controls.Add(f2);
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            anaekran.Controls.Clear();
            urunler f2 = new urunler();
            f2.Dock = DockStyle.Fill; 
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            anaekran.Controls.Add(f2);
            f2.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            anaekran.Controls.Clear();
            sepet f2 = new sepet();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            anaekran.Controls.Add(f2);
            f2.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            anaekran.Controls.Clear();
            urunler f2 = new urunler();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            anaekran.Controls.Add(f2);
            f2.Show();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Umuta");
        }
    }
}
