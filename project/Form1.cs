using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Conf.GetOne(String.Format("SELECT chair.name, faculty.department_name FROM chair INNER JOIN faculty on faculty.name = chair.faculty_name WHERE faculty.name = '{0}'", textBox1.Text));
            while (Conf.reader.Read())
            {
                dataGridView1.Rows.Add(Conf.reader[0], Conf.reader[1]);
            }
            Conf.Close();
            Conf.ResizeGrid(dataGridView1);
            dataGridView1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            Conf.GetOne(String.Format("SELECT student.surname, student.name, student.patronymic, student.phone_number, student.email FROM student WHERE student.group_name = '{0}'", textBox2.Text));
            while (Conf.reader.Read())
            {
                dataGridView2.Rows.Add(Conf.reader[0], Conf.reader[1], Conf.reader[2], Conf.reader[3], Conf.reader[4]);
            }
            Conf.Close();
            Conf.ResizeGrid(dataGridView1);
            dataGridView2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel4.Visible = false;
        }
    }
}
