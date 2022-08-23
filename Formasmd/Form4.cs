using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Formasmd
{
    public partial class FrmTeacher : Form
    {
        string connectionString = "server = LAPTOP-ROQKGN48\\SQLEXPRESS;database=StudentManagement;uid=sa;pwd=1234567890";
        SqlConnection con = null;
        SqlCommand cmd;
        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
        }
        public void Display()
        {
            string sqlSELECT = "select * from Teacher";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            ListTeacher.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Teacher(TeacherID, TeacherName, Email, Age) VALUES(@TeacherID,@TeacherName,@Email,@Age)";
            cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = Int32.Parse(txtID.Text);
            cmd.Parameters.Add("@TeacherName", SqlDbType.VarChar).Value = txtName.Text;
            cmd.Parameters.Add("@Email", SqlDbType.Int).Value = Int32.Parse(txtEmail.Text);
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Int32.Parse(txtAge.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" successfully Added");
            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Teacher SET TeacherName = @TeacherName, Email = @Email, Age = @Age WHERE TeacherID = @TeacherID";
                cmd.Parameters.AddWithValue("@TeacherID", txtID.Text);
                cmd.Parameters.AddWithValue("@TeacherName", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" successfully edited!", "Added");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string TeacherID = btnDelete.Text;
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Teacher WHERE TeacherID = @TeacherID";
                cmd.Parameters.AddWithValue("@TeacherID", txtID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Delete successfully !", "Added");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Open connection
                con = new SqlConnection(connectionString);
                con.Open();
                // Create command object.
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Teacher where TeacherID like @TeacherID";
                cmd.Parameters.AddWithValue("TeacherID", string.Format("%{0}%", txtsearchgv.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ListTeacher.DataSource = dt;
                // Query execution.
                cmd.ExecuteNonQuery();
                // Close connection
                con.Close();
            }
            // Notice errors to avoid interrupting the running system.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            // Open connection
            con.Open();
            // Create command object.
            SqlCommand cmd = con.CreateCommand();
            // Create command
            cmd.CommandText = "Select * from Teacher";
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            ListTeacher.DataSource = dtbl;
            // Query execution.
            cmd.ExecuteNonQuery();
            // Close connection
            con.Close();
        }
    }
}
