using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInfoAppMay6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Employee aEmployee = new Employee();
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeInfoDB"].ConnectionString;
        private void saveButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();
           aEmployee.name = nameTextBox.Text;
            aEmployee.address = addressTextBox.Text;
            aEmployee.email = emailTextBox.Text;
            aEmployee.salary = Convert.ToDouble(salaryTextBox.Text);

            nameTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            salaryTextBox.Text = "";
           

            //email uiqe//
            if (IsEmailUniqe(aEmployee.email))
            {
                MessageBox.Show("already email exists!");
               
            }
            else
            {
                //connect database//
                
                SqlConnection connection = new SqlConnection(connectionString);

                //write query//

                string query = "INSERT INTO tb_employee VALUES('" + aEmployee.name + "','" + aEmployee.address + "','" + aEmployee.email + "','" + aEmployee.salary + "')";

                //execute query//

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                int rowAffected = command.ExecuteNonQuery();

                connection.Close();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Inserted successfully");
                }
                else
                {
                    MessageBox.Show("not Inserted");
                }
            }
           
        }

        public bool IsEmailUniqe(string email)
        {
           
            //connect database//
           
            SqlConnection connection = new SqlConnection(connectionString);

            //write query//

            string query = "SELECT * FROM tb_employee WHERE Email='" + email + "'";

            //execute query//

            SqlCommand command = new SqlCommand(query, connection);

           bool IsEmail = false;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                 IsEmail=true;
                 break;
            }

            //int rowAffected = command.ExecuteNonQuery();//

            reader.Close();
           connection.Close();
            return IsEmail;

        }

        private void showButton_Click(object sender, EventArgs e)
        {
         
            SqlConnection connection = new SqlConnection(connectionString);

            //write query//

            string query = "SELECT * FROM tb_employee";

            //execute query//

            SqlCommand command = new SqlCommand(query, connection);

            bool IsEmail = false;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();

            while (reader.Read())
            {
                Employee employees = new Employee();

                employees.id = int.Parse(reader["id"].ToString());
                employees.name = reader["name"].ToString();
                employees.address = reader["address"].ToString();
                employees.email= reader["email"].ToString();
                employees.salary = double.Parse(reader["salary"].ToString());
                employeeList.Add(employees);

            }

            

            reader.Close();
            connection.Close();
              
            LoadEmployeeListView(employeeList);


        }

        public void LoadEmployeeListView(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                ListViewItem item =new ListViewItem(employee.id.ToString());
                item.SubItems.Add(employee.name);
                item.SubItems.Add(employee.address);
                item.SubItems.Add(employee.email);
                item.SubItems.Add(employee.salary.ToString());
                employeeListView.Items.Add(item);

            }
        }
    }
}
