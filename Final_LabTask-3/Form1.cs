using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Final_LabTask_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Tag = this;
            f2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zamal\source\repos\Final_LabTask-3\DB\loginInfo.mdf;Integrated Security=True;Connect Timeout=30");

            string query = "select* from USERINFO where PHONE_NO ='" + textPhoneNo.Text.Trim() + "' and PASS='" + textPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            textPhoneNo.Text = "";
            textPassword.Text = "";

            if (dtbl.Rows.Count == 1)
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }

            else
            {
                MessageBox.Show("Invalid username or password!");
            }

        }

        private void textPhoneNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textPhoneNo.Text) == true)
            {
                textPhoneNo.Focus();
                errorProvider1.SetError(this.textPhoneNo, "Phone number can not be null.");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (new Regex(@"^([01]|\+88)?\d{11}").IsMatch(textPhoneNo.Text)== false)
            {
                textPhoneNo.Focus();
                errorProvider2.SetError(this.textPhoneNo, "Phone number is not valide.");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textPassword.PasswordChar == '*')
            {
                button3.BringToFront();
                textPassword.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textPassword.PasswordChar == '\0')
            {
                button4.BringToFront();
                textPassword.PasswordChar = '*';
            }
        }
    }
}
