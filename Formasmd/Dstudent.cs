using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formasmd
{
    public partial class Dstudent : Form
    {
        public Dstudent()
        {
            InitializeComponent();
        }

        private void Dstudent_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Checkstudent checkPage = new Checkstudent();
            this.Hide();
            checkPage.Show();
        }
    }
}
