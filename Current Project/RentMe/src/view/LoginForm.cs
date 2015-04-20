using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.model;
using view;

namespace view
{
    public partial class LoginForm : Form
    {
        private readonly EmployeeCollection employeeList = new EmployeeCollection();
        private readonly DatabaseHandler db = new DatabaseHandler();
        private mainForm customerRegisterForm;
        private AdminForm adminForm;
        private string loggedInEmployee;

        public LoginForm()
        {
            this.employeeList.populateList();
            this.InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (this.db.CheckLoginInfo(this.usernameTextBox.Text, this.passwordTextBox.Text))
            {
                this.loginResultLabel.ForeColor = Color.Black;
                this.loginResultLabel.Text = "Welcome, " + this.usernameTextBox.Text + ".";
                this.loggedInEmployee = this.usernameTextBox.Text;
                this.Hide();
                this.customerRegisterForm = new mainForm(this.loggedInEmployee);
                this.customerRegisterForm.Show();
                this.customerRegisterForm.SetBounds(this.Location.X, this.Location.Y, this.customerRegisterForm.Width,
                    this.customerRegisterForm.Height);
            }
            else
            {
                this.loginResultLabel.ForeColor = Color.Red;
                this.loginResultLabel.Text = "Invalid username/password.";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loginButton_Click(sender, e);
            }
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.adminForm = new AdminForm();
            this.Hide();
            this.adminForm.Show();
            this.adminForm.SetBounds(this.Location.X, this.Location.Y, this.adminForm.Width, this.adminForm.Height);
        }
    }
}