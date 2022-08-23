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

namespace Formasmd
{
    public partial class FrmteacherQl : Form
    {
        string sqlconnect = "server = LAPTOP-ROQKGN48\\SQLEXPRESS;database=StudentManagement;uid=sa;pwd=1234567890";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public FrmteacherQl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Score Pointstudent = new Score();
            Pointstudent.Show();
            this.Hide();
        }

        private void FrmteacherQl_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlconnect);
        }
    }
}
