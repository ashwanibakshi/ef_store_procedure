using dept;
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

namespace proc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'demouserDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.demouserDataSet.department);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (deptContext dpt = new deptContext())
            {
                SqlParameter para1 = new SqlParameter("@name",textBox1.Text);
                department dp = new department();
                dp.name = textBox1.Text;
                dpt.departments.Add(dp);
                dpt.SaveChanges();
            }
        }
    }
}
