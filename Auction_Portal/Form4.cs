using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Auction_Portal
{
    public partial class Form4 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank You!");
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

        }

        public void connect1()
        {
            string oradb = "Data Source=XE;User ID=system;Password=pratyush";
            conn = new OracleConnection(oradb);

            conn.Open();
        }

        void load()
        {
            connect1();
            comm = new OracleCommand(" select Item_ID,name,Base_Price,Inc_Price from bid;", conn);
            try
            {

                da = new OracleDataAdapter();
                da.SelectCommand = comm;
                dt = new DataTable();
                da.Fill(dt);
                BindingSource bSourse = new BindingSource();

                bSourse.DataSource = dt;
                dataGridView1.DataSource = bSourse;
                da.Update(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            load();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
        }
    }
}
