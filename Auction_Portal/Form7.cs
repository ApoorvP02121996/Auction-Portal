﻿using System;
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
    
    public partial class Form7 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public Form7()
        {
            InitializeComponent();
            load1();
        }

        public void connect1()
        {
            string oradb = "Data Source=XE;User ID=system;Password=pratyush";
            conn = new OracleConnection(oradb);

            conn.Open();
        }

        public void load1()
        {
            connect1();
            comm = new OracleCommand("select * from current_bid;", conn);
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

        public void load2()
        {
            connect1();
            comm = new OracleCommand("select * from sold;",conn);
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
            catch(Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            OracleCommand cmd = new OracleCommand();
            try{
                cmd.Connection = conn;
                cmd.CommandText = "sellitem";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OracleParameter("b_id",OracleDbType.Int32)).Value = textBox1.Text;
                cmd.Parameters.Add(new OracleParameter("name",OracleDbType.Varchar2,20)).Value = textBox2.Text;
                cmd.Parameters.Add(new OracleParameter("price",OracleDbType.Int32)).Value = textBox3.Text;

                cmd.ExecuteNonQuery();
                load2();
                MessageBox.Show("Sold!");
                CleanForm();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }           

                
        }
    }

