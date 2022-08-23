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
    public partial class Frmstudent : Form
    {
        string connectionString = "server = LAPTOP-ROQKGN48\\SQLEXPRESS;database=StudentManagement;uid=sa;pwd=1234567890";
        SqlConnection con = null;
        SqlCommand cmd;
        public Frmstudent()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            
        }

        private void Frmstudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
        public void Display()
        {
            string sqlSELECT = "select * from Student";
            SqlCommand cmd = new SqlCommand(sqlSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Liststudent.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Student(StudentId, StudentName, Email, Age) VALUES(@StudentId,@StudentName,@Email,@Age)";
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = Int32.Parse(txtID.Text);
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = txtName.Text;
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
                cmd.CommandText = "UPDATE Student SET StudentName = @StudentName, Email = @Email, Age = @Age WHERE StudentID = @StudentID";
                cmd.Parameters.AddWithValue("@StudentID",txtID.Text);
                cmd.Parameters.AddWithValue("@StudentName", txtName.Text);
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

                string StudentID = btnDelete.Text;
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Student WHERE StudentID = @StudentID";
                cmd.Parameters.AddWithValue("@StudentID", txtID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Delete successfully !", "Added");
                con.Close();
            }
            catch(Exception ex)
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
                cmd.CommandText = "SELECT * FROM Student where StudentID like @StudentID";
                cmd.Parameters.AddWithValue("StudentID", string.Format("%{0}%", txtsearchsv.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Liststudent.DataSource = dt;
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
            cmd.CommandText = "Select * from Student";
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            Liststudent.DataSource = dtbl;
            // Query execution.
            cmd.ExecuteNonQuery();
            // Close connection
            con.Close();
        }
    }
}
