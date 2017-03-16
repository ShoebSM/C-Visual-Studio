/*  Shoeb Mohammed - z1700231
*  Program to make a connection to a mySQL database
*  Allow user interactivity options (in a Visual Studio form) to create a new database, update the database,
    and ultimately output queried searches.
*
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign3
{
    public partial class Form1 : Form
    {
        string connstr = Assign3.Utility.GetConnectionString();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.clearText();
        }

        private void clearText()
        {
            textBox1.Clear();
            listBox1.ClearSelected();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstr);
                string sql = textBox1.Text;
                SqlCommand cd = new SqlCommand(sql, conn);

                conn.Open();
                cd.ExecuteNonQuery();
             }
            catch(Exception c)
            {
                listBox1.Text = (c.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                SqlCommand drop = new SqlCommand("DROP TABLE OFFICE", conn);
                drop.ExecuteNonQuery();
                SqlCommand dropRoom = new SqlCommand("DROP TABLE ROOM", conn);
                dropRoom.ExecuteNonQuery();
                SqlCommand create = new SqlCommand("CREATE TABLE OFFICE(Teacher varchar(20) PRIMARY KEY, Office int)", conn);
                create.ExecuteNonQuery();
                SqlCommand createRoom = new SqlCommand("CREATE TABLE ROOM(Room int PRIMARY KEY, Capacity int, Smart varchar(1)", conn);
                createRoom.ExecuteNonQuery();
                SqlCommand createClass = new SqlCommand("CREATE TABLE CLASS(Class int, Section int, Teacher varchar(20) FOREIGN KEY REFERENCES OFFICE('Teacher'),)
                using (StreamReader SR = new StreamReader("Office.txt"))
                {
                    string officeLine;
                    officeLine = SR.ReadLine();
                    //while !EOF
                    while (officeLine != null)
                    {
                        /// using (SqlConnection conn = new SqlConnection(connstr))
                        string[] officeRow = officeLine.Split(',');
                        string lastName = officeRow[0];
                        int officeNum = Convert.ToInt32(officeRow[1]);
                        //MessageBox.Show(lastName, officeNum);
                        string query= "INSERT INTO OFFICE (LastName, OfficeNum)";
                            query += "VALUES (@lastName,@officeNum)";
                        SqlCommand insert = new SqlCommand(query, conn);
                        insert.Parameters.AddWithValue("@lastName", lastName);
                        insert.Parameters.AddWithValue("@officeNum", officeNum);
                        insert.ExecuteNonQuery();
                        officeLine = SR.ReadLine();
                    }
                    SqlCommand select = new SqlCommand("SELECT LastName, officeNum FROM OFFICE", conn);
                    select.ExecuteNonQuery();

                    SqlDataReader reader = select.ExecuteReader();

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //MessageBox.Show(reader.GetString(0));
                            IDataRecord MyRecord = (IDataRecord)reader;
                            String S0 = MyRecord[0].ToString();
                            String S1 = MyRecord[1].ToString();
                            MessageBox.Show(S0, S1);
                        }
                    }
                }

            }
        }
    }
}
