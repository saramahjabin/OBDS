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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zamal\source\repos\Final_LabTask-3\DB\loginInfo.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textName.Text) == true || string.IsNullOrEmpty(textBloodGroup.Text) == true || string.IsNullOrEmpty(textPhoneNo.Text) == true || string.IsNullOrEmpty(textPassword.Text) == true)
            {
                MessageBox.Show("Please fill up the informations.");
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO USERINFO VALUES ('" + textName.Text + "','" + textBloodGroup.Text + "','" + textPhoneNo.Text + "','" + textPassword.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Created");
                Form1 f1 = new Form1();
                f1.Tag = this;
                f1.Show();
                this.Close();
            }
        }

        private void textName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textName.Text) == true)
            {
                textName.Focus();
                errorProvider1.SetError(this.textName, "Name can not be null.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBloodGroup_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBloodGroup.Text) == true)
            {
                textBloodGroup.Focus();
                errorProvider1.SetError(this.textBloodGroup, "Blood Group can not be null.");
            }
            else
            {
                errorProvider1.Clear();
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
            if (new Regex(@"^([01]|\+88)?\d{11}").IsMatch(textPhoneNo.Text) == false)
            {
                textPhoneNo.Focus();
                errorProvider2.SetError(this.textPhoneNo, "Phone number is not valide.");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textPasword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textPassword.Text) == true)
            {
                textPassword.Focus();
                errorProvider1.SetError(this.textPassword, "Password can not be null.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
    }

