using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formasmd
{
    public partial class Frmlogin : Form
    {
        string sqlconnect = "server = LAPTOP-ROQKGN48\\SQLEXPRESS;database=StudentManagement;uid=sa;pwd=1234567890";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Frmlogin()
        {
            InitializeComponent();
        }
        private void Frmlogin_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlconnect);
        }
        void clearTxt()
        {
            txtpassword.Text = txtusername.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String username = txtusername.Text;
            String password = txtpassword.Text;
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from Users where username = '" + username + "' and Password = '" + password + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                string role = dr.GetString(3);
                if (role == "admin")
                {
                    MessageBox.Show("Login successful as admin!", "Success", MessageBoxButtons.OK);
                    clearTxt();
                    FrmAllManage AllManage = new FrmAllManage();
                    AllManage.Show();
                    this.Hide();
                }
                else if (role == "teacher")
                {
                    MessageBox.Show("Login successful as teacher!", "Success", MessageBoxButtons.OK);
                    clearTxt();
                    FrmteacherQl Teacher2 = new FrmteacherQl();
                    Teacher2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login successful as Student!", "Success", MessageBoxButtons.OK);
                    clearTxt();
                    Dstudent Student = new Dstudent();
                    Student.Show();
                    this.Hide();
                }

            }
            else
            {
                clearTxt();
                MessageBox.Show("Given username or password is incorrect!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();


        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Do you want exit?", "Notify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }
    }

}
