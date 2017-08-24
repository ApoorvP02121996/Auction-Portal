using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types; */


namespace Auction_Portal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        
        }

     /*   public void connect1()
        {
            string oradb = "Data Source=XE;User ID=system;Password=pratyush";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
       
     */

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
