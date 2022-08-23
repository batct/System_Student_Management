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
    public partial class Score : Form
    {
        string connectionString = "server = LAPTOP-ROQKGN48\\SQLEXPRESS;database=StudentManagement;uid=sa;pwd=1234567890";
        SqlConnection con = null;
        SqlCommand cmd;
        public Score()
        {
            InitializeComponent();
        }

        private void Score_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
        }
        public void Display()
        {
            string sqlSELECT = "select * from Score";
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
            cmd.CommandText = "INSERT INTO Score(ScoreID, ScoreASM1, ScoreASM2, MediumScore, StudentID, TeacherID, SubjectsID) VALUES(@ScoreID,@ScoreASM1,@ScoreASM2,@MediumScore,@StudentID,@TeacherID,@SubjectsID)";
            cmd.Parameters.Add("@ScoreID", SqlDbType.Int).Value = Int32.Parse(txtScoreID.Text);
            cmd.Parameters.Add("@ScoreASM1", SqlDbType.VarChar).Value = Int32.Parse(txtScoreASM1.Text);
            cmd.Parameters.Add("@ScoreASM2", SqlDbType.Int).Value = Int32.Parse(txtScoreASM2.Text);
            cmd.Parameters.Add("@MediumScore", SqlDbType.Int).Value = Int32.Parse(txtMediumScore.Text);
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = Int32.Parse(txtStudentID.Text);
            cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = Int32.Parse(txtTeacherID.Text);
            cmd.Parameters.Add("@SubjectsID", SqlDbType.Int).Value = Int32.Parse(txtSubjectsID.Text);
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
                cmd.CommandText = "UPDATE Score SET ScoreASM1 = @ScoreASM1, ScoreASM2 = @ScoreASM2, MediumScore = @MediumScore, StudentID =@StudentID, TeacherID=@TeacherID, SubjectsID=@SubjectsID WHERE ScoreID = @ScoreID";
                cmd.Parameters.AddWithValue("@ScoreID", txtScoreID.Text);
                cmd.Parameters.AddWithValue("@ScoreASM1", txtScoreASM1.Text);
                cmd.Parameters.AddWithValue("@ScoreASM2", txtScoreASM2.Text);
                cmd.Parameters.AddWithValue("@MediumScore", txtMediumScore.Text);
                cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                cmd.Parameters.AddWithValue("@TeacherID", txtTeacherID.Text);
                cmd.Parameters.AddWithValue("@SubjectsID", txtSubjectsID.Text);
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

                string ScoreID = btnDelete.Text;
                cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Score WHERE ScoreID = @ScoreID";
                cmd.Parameters.AddWithValue("@ScoreID", txtScoreID.Text);
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
            cmd.CommandText = "Select * from Score";
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
