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
    public partial class Form5 : Form
    {
         OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public Form5()
        {
            InitializeComponent();
            
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
            comm = new OracleCommand(" select * from bid;", conn);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CleanForm()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else if (control is RichTextBox)
                        (control as RichTextBox).Clear();
                    else if (control is RadioButton)
                        (control as RadioButton).Checked = false;

                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            String query = " insert into bid (bid_ID,Item_ID,Inc_Price,Base_Price,Start_Time,Stop_Time,name) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
            comm = new OracleCommand(query, conn);
            OracleDataReader odr;
            try
            {
                odr = comm.ExecuteReader();
                CleanForm();
                load();
                MessageBox.Show("Added!");
                while (odr.Read()) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
 
    }
}
