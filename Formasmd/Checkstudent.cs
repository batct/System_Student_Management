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
    public partial class Checkstudent : Form
    {
        string sqlconnect = "server = LAPTOP-ROQKGN48\\SQLEXPRESS;database=StudentManagement;uid=sa;pwd=1234567890";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string searchInput;
        public Checkstudent()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchStudentName(txtSearch.Text);
        }

        void searchStudentName(string searchInput)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Student WHERE StudentName LIKE '%" + searchInput + "%'";
            dr = cmd.ExecuteReader();
            listStudent.Items.Clear();
            while (dr.Read())
            {
                string studentId = dr.GetInt32(0).ToString();
                string studentName = dr.GetString(1);
                string studentEmail = dr.GetString(2);
                string studentAge = dr.GetInt32(3).ToString();
                string[] arr = new string[4];
                arr[0] = studentId;
                arr[1] = studentName;
                arr[2] = studentEmail;
                arr[3] = studentAge;
                ListViewItem item = new ListViewItem(arr);
                listStudent.Items.Add(item);
            }
            dr.Close();
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Checkstudent_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlconnect);
            searchStudentName("");
        }
    }
}
