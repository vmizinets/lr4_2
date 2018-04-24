using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        MySqlDataAdapter adapter;
        MySqlCommandBuilder bil;
        DataTable dt;

        MySqlConnectionStringBuilder mysqlCSB;
        public Form3()
        {
            InitializeComponent();
            System.Data.DataTable dt = new System.Data.DataTable();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "events";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            bindingNavigator1.BindingSource = customerBindingSource;
            dataGridView1.DataSource = customerBindingSource;

            dataGridView1.Columns[0].HeaderText = "Номер пользователя";
            dataGridView1.Columns[1].HeaderText = "Ф.И.О.";

            dataGridView1.Columns[0].ToolTipText = "Идентификационный Номер пользователя";
            dataGridView1.Columns[1].ToolTipText = "Фамилия/Имя/Отчество клиента";

            //grid1(@"SELECT * FROM customer", "customer");
        }
        private void grid2(string m, string k)//функція для відкриття таблиць в DataGrid
        {
            try
            {

                string queryString = m;
                using (MySqlConnection connection = new MySqlConnection())
                {
                    connection.ConnectionString = mysqlCSB.ConnectionString;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, k);
                    dataGridView2.DataSource = ds.Tables[k].DefaultView;

                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе");
            }


        }
        private void grid1(string m, string k)//функція для відкриття таблиць в DataGrid
        {
            try
            {

                string queryString = m;
                using (MySqlConnection connection = new MySqlConnection())
                {
                    connection.ConnectionString = mysqlCSB.ConnectionString;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, k);
                    dataGridView1.DataSource = ds.Tables[k].DefaultView;

                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе");
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Owner = this;
            fr2.Show();
            Form3 fr3 = new Form3();
            fr3.Owner = this;
            this.Hide();
        }

        public void data_output()
        {
            int rowindex = dataGridView1.CurrentRow.Index;

            grid2(@"SELECT *FROM reservat Where customer_id=" + dataGridView1.Rows[rowindex].Cells[0].Value.ToString(), "reservat");
            dataGridView2.Columns[0].HeaderText = "Номер резерва";
            dataGridView2.Columns[1].HeaderText = "Номер пользователя";
            dataGridView2.Columns[2].HeaderText = "Номер события";

            dataGridView2.Columns[0].ToolTipText = "Номер резерва события";
            dataGridView2.Columns[1].ToolTipText = "Номер пользователя события";
            dataGridView2.Columns[2].ToolTipText = "Номер события которое происходит";

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            data_output();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eventsDataSet.customer". При необходимости она может быть перемещена или удалена.
            this.customerTableAdapter.Fill(this.eventsDataSet.customer);

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            data_output();

        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            data_output();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            data_output();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            data_output();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bil = new MySqlCommandBuilder(adapter);
            adapter.Update(dt);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt;

        }
    }
}
