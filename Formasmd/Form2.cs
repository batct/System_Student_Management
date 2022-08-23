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
    public partial class FrmAllManage : Form
    {
        public FrmAllManage()
        {
            InitializeComponent();
        }
        string sqlconnect = "server = LAPTOP-ROQKGN48\\SQLEXPRESS;database=StudentManagement;uid=sa;pwd=1234567890";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {

            Frmstudent Frmstudent = new Frmstudent();
            Frmstudent.Show();
            this.Hide();
        }

        private void FrmAllManage_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(sqlconnect);
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            FrmTeacher FrmTeacher = new FrmTeacher();
            FrmTeacher.Show();
            this.Hide();
        }
    }
}
