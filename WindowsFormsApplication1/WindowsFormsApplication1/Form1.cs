using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        MySqlDataAdapter adapter;
        MySqlCommandBuilder bil;
        DataTable dt;

        MySqlConnectionStringBuilder mysqlCSB;
        public Form1()
        {

            InitializeComponent();           
            System.Data.DataTable dt = new System.Data.DataTable();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.Database = "events";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "";
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].HeaderText = "Номер события";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Дата проведения";
            dataGridView1.Columns[3].HeaderText = "Фото";
            dataGridView1.Columns[4].HeaderText = "Номер места проведения";


            dataGridView1.Columns[0].ToolTipText = "Уникальный индентификационный номер события";
            dataGridView1.Columns[1].ToolTipText = "Название события которое происходит";
            dataGridView1.Columns[2].ToolTipText = "Число/месяц/день проведения";
            dataGridView1.Columns[3].ToolTipText = "Фото события";
            dataGridView1.Columns[4].ToolTipText = "Номер места проведения где будет проводится событие";


           

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
       


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem == "Спортивные сооружения")
            //{
            //    grid2(@"SELECT *FROM venues", "venues");

            //}
            //if (comboBox1.SelectedItem == "Спортивные события")
            //{
            //    grid2(@"SELECT *FROM events", "events");

            //}
            //if (comboBox1.SelectedItem == "Резервирование")
            //{
            //    grid2(@"SELECT *FROM reservat", "reservat");
            //}
            //if (comboBox1.SelectedItem == "Пользователи")
            //{
            //    grid2(@"SELECT *FROM Customer", "Customer");
            //}
          


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "eventsDataSet.events". При необходимости она может быть перемещена или удалена.
            //this.eventsTableAdapter.Fill(this.eventsDataSet.events);

        }

        //public byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    //MemoryStream ms = new MemoryStream();
        //    //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    //return ms.ToArray();
        //}

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}

        public void data_output()
        {
            //int rowindex = dataGridView1.CurrentRow.Index;

            //grid2(@"SELECT *FROM venues Where id_venues=" + dataGridView1.Rows[rowindex].Cells[4].Value.ToString(), "venues");
            //dataGridView2.Columns[0].HeaderText = "Номер места проведения";
            //dataGridView2.Columns[1].HeaderText = "Вместимость(тыс.)";
            //dataGridView2.Columns[2].HeaderText = "Площадь(м2)";
            //dataGridView2.Columns[3].HeaderText = "Место расположения";
            //dataGridView2.Columns[4].HeaderText = "Фото";

            //dataGridView2.Columns[0].ToolTipText = "Номер места проведения где будет проводится событие";
            //dataGridView2.Columns[1].ToolTipText = "Вместимость места где будет проводится в тысячах";
            //dataGridView2.Columns[2].ToolTipText = "Площадь места в которо будет проводится события в квадратных метрах";
            //dataGridView2.Columns[3].ToolTipText = "Место расположения где будет проходить событие";
            //dataGridView2.Columns[4].ToolTipText = "Фото места проведения";

            //pictureBox1.Image = byteArrayToImage(dataGridView1.Rows[rowindex].Cells[3].Value as Byte[]);

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            data_output();
            //pictureBox1.BackgroundImage=(Image)dataGridView2.Rows[0].Cells[4].Value;

            //pictureBox1.Image=byteArrayToImage(imageToByteArray((Image)dataGridView2.Rows[0].Cells[4].Value));
            //pictureBox1.Image = new System.Drawing.Bitmap(new MemoryStream(([byte])dr.GetValue(16)));

        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Owner = this;
            fr2.Show();
            Form1 fr1 = new Form1();
            fr1.Owner = this;
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            data_output();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            data_output();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            data_output();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            data_output();
        }

      
        private void button1_Click_1(object sender, EventArgs e)
        {
            bil = new MySqlCommandBuilder(adapter);
            adapter.Update(dt);
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = dt;
        }

        private void dataGridView1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (dataGridView1.Focused)
                Process.Start(@"E:\OneDrive\Учеба ХАИ\3 курс\тспп\lr3\help_grid1.html");

        }

        private void dataGridView2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
           // webBrowser1.Navigate(@"E:\OneDrive\Учеба ХАИ\3 курс\тспп\lr3\index.html");
           if(dataGridView2.Focused)
            Process.Start(@"E:\OneDrive\Учеба ХАИ\3 курс\тспп\lr3\help_grid2.html");

        }

        private void pictureBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            //if (pictureBox1.Focused)
            //    MessageBox.Show("подсказка по картинке");
        }

        private void groupBox1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            //if (groupBox1.Focused)
            //    MessageBox.Show("подсказка по групбоксу");
        }

        private void bindingNavigator1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            //if (bindingNavigator1.Focused)
            //    MessageBox.Show("подсказка по навигатору");
        }
    }
}
