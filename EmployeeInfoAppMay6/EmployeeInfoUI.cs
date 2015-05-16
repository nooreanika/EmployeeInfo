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
    public partial class EmployeeInfoUI : Form
    {
        public EmployeeInfoUI()
        {
            InitializeComponent();
        }
        Employee aEmployee = new Employee();
        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeInfoDB"].ConnectionString;
        private bool isUpdateMode = false;
        private int employeeId;
        private void saveButton_Click(object sender, EventArgs e)
        {
            //Employee aEmployee = new Employee();
           aEmployee.name = nameTextBox.Text;
            aEmployee.address = addressTextBox.Text;
            aEmployee.email = emailTextBox.Text;
            aEmployee.salary = Convert.ToDouble(salaryTextBox.Text);

            //nameTextBox.Text = "";
            //addressTextBox.Text = "";
            //emailTextBox.Text = "";
            //salaryTextBox.Text = "";
             
           if (isUpdateMode)
           {
               SqlConnection connection = new SqlConnection(connectionString);

               //write query//

               string query = "UPDATE tb_employee SET name='" + aEmployee.name + "',address='" + aEmployee.address + "',salary='" + aEmployee.salary + "' WHERE id='" + employeeId +"'";

               //execute query//

               SqlCommand command = new SqlCommand(query, connection);

               connection.Open();

               int rowAffected = command.ExecuteNonQuery();

               connection.Close();

               if (rowAffected > 0)
               {
                   MessageBox.Show("updated successfully");
                   saveButton.Text = "save";
                   employeeId = 0;
                   isUpdateMode = false;
                   emailTextBox.Enabled = true;
                   ShowAllEmployee();
               }
               else
               {
                   MessageBox.Show("update failed");
               }
           }
           else
           {
               //email uniqe//
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
                       
                       ShowAllEmployee();
                      
                       nameTextBox.Clear();
                       addressTextBox.Clear();
                       emailTextBox.Clear();
                       salaryTextBox.Clear();
                   }
                   else
                   {
                       MessageBox.Show("Insertion failed");
                   }
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

       

        public void LoadEmployeeListView(List<Employee> employees)
        {
            employeeListView.Items.Clear();
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

        public void ShowAllEmployee()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            //write query//

            string query = "SELECT * FROM tb_employee";

            //execute query//

            SqlCommand command = new SqlCommand(query, connection);

            

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();

            while (reader.Read())
            {
                Employee employees = new Employee();

                employees.id = int.Parse(reader["id"].ToString());
                employees.name = reader["name"].ToString();
                employees.address = reader["address"].ToString();
                employees.email = reader["email"].ToString();
                employees.salary = double.Parse(reader["salary"].ToString());
                employeeList.Add(employees);

            }



            reader.Close();
            connection.Close();

            LoadEmployeeListView(employeeList);


        }
        private void EmployeeInfoUI_Load(object sender, EventArgs e)
        {
            ShowAllEmployee();
        
        }
        
        private void employeeListView_DoubleClick(object sender, EventArgs e)
        {
            //select selected student//
            ListViewItem item = employeeListView.SelectedItems[0];
            int id = int.Parse(item.Text.ToString());
            Employee employees = GetEmployeeById(id);
            if(employees!= null)
            {
                //enable update mode//
                isUpdateMode = true;
                saveButton.Text = "Update";
                employeeId = employees.id;
                //Fill text with employee//
                nameTextBox.Text = employees.name;
                addressTextBox.Text= employees.address;
                emailTextBox.Text = employees.email;
                salaryTextBox.Text = Convert.ToString(employees.salary);
                
            }
        }
        public Employee GetEmployeeById(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //write query//

            string query = "SELECT * FROM tb_employee WHERE id='"+Id+"'";

            //execute query//

            SqlCommand command = new SqlCommand(query, connection);



            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employeeList = new List<Employee>();

            while (reader.Read())
            {
                Employee employees = new Employee();

                employees.id = int.Parse(reader["id"].ToString());
                employees.name = reader["name"].ToString();
                employees.address = reader["address"].ToString();
                employees.email = reader["email"].ToString();
                employees.salary = double.Parse(reader["salary"].ToString());
                employeeList.Add(employees);

            }



            reader.Close();
            connection.Close();
            return employeeList.FirstOrDefault();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //write query//

            string query = "delete from tb_employee where Id='" + employeeId + "'";

            //execute query//

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("deleted successfully");
                saveButton.Text = "save";
                employeeId = 0;
                isUpdateMode = false;
                emailTextBox.Enabled = true;
                ShowAllEmployee();
                nameTextBox.Clear();
                addressTextBox.Clear();
                emailTextBox.Clear();
                salaryTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Not Found");
            }
        }

      
     
       
    }
}
