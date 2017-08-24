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
    public partial class Form2 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        
        public Form2()
        {
            InitializeComponent();
        }


        public void connect1()
        {
            string oradb = "Data Source=XE;User ID=system;Password=pratyush";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            String userid = textBox5.Text;
            String password = textBox6.Text;
            cm = new OracleCommand(" select A_Username, Password from A_Credential where A_Username = '" + textBox5.Text + "' and password='" + textBox6.Text + "'", conn);
            da = new OracleDataAdapter(cm);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successful");
                Form3 frm = new Form3();
                frm.Show();
                this.Hide();
            }

            else
            {
                CleanForm();
                MessageBox.Show("Invalid Login Details");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                connect1();
                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                String userid = textBox7.Text;
                String password = textBox8.Text;
                cm = new OracleCommand("select B_Username, Password from B_Credential where B_Username = '" + textBox7.Text + "' and Password = '" + textBox8.Text + "'", conn);
                OracleDataAdapter da = new OracleDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful");
                    Form4 frm = new Form4();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    CleanForm();
                    MessageBox.Show("Invalid Login Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            OracleCommand cm1 = new OracleCommand();
            cm1.Connection = conn;

            try
            {
                if (radioButton1.Checked == true)
                {
                    cm.CommandText = "insert into auctioneer values('" + textBox2.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "')";
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();
                    cm.CommandText = "insert into A_Credential values('" + textBox2.Text + "','" + textBox3.Text + "')";
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();
                    conn.Close();
                }


                else if (radioButton2.Checked == true)
                {
                    cm1.CommandText = "insert into bidder values('" + textBox2.Text + "','" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "')";
                    cm1.CommandType = CommandType.Text;
                    cm1.ExecuteNonQuery();
                    cm1.CommandText = "insert into B_Credential values('" + textBox2.Text + "','" + textBox3.Text + "')";
                    cm1.CommandType = CommandType.Text;
                    cm1.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }


            CleanForm();
            MessageBox.Show("Successful! Login to Continue");
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
    
        
                       
            }
           
        }
    



