using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1.model;
using view;

namespace view
{
    public partial class mainForm : Form
    {
        private readonly DatabaseHandler db = new DatabaseHandler();
        private DataSet dataset;
        private LoginForm loginForm;
        private string loggedInEmployee = "";
        private CustomerCollection customerList = new CustomerCollection();

        public mainForm(string loggedInEmployee)
        {
            this.InitializeComponent();
            this.loggedInEmployee = loggedInEmployee;
        }

        private void registerCustomer()
        {
            try
            {
                string fname = this.firstNameTextBox.Text;
                string lname = this.lastNameTextBox.Text;
                int ssnInt = Int32.Parse(this.ssnTextBox.Text);
                int phoneInt = Int32.Parse(this.phoneNumberTextBox.Text);
                string streetAddress = this.streetAddressTextBox.Text;
                string city = this.cityTextBox.Text;
                string state = this.stateComboBox.Text;
                int zipCodeInt = Int32.Parse(this.zipCodeTextBox.Text);

                string ssn = ssnInt.ToString();
                string phone = phoneInt.ToString();
                string zipCode = zipCodeInt.ToString();


                this.db.registerMember(fname, lname, streetAddress, city, state, zipCode, ssn, phone);

                this.registerResultLabel.ForeColor = Color.Black;
                this.registerResultLabel.Text = "Customer successfully registered.";
                this.resetAllTextBoxes();
            }
            catch (Exception)
            {
                this.registerResultLabel.ForeColor = Color.Red;
                this.registerResultLabel.Text = "Invalid/missing data. Please try again.";
            }
        }

        private bool validateEntries()
        {
            if (this.firstNameTextBox.Text.Equals("") || this.lastNameTextBox.Text.Equals("") ||
                this.ssnTextBox.Text.Equals("") || this.phoneNumberTextBox.Text.Equals("") ||
                this.streetAddressTextBox.Text.Equals("") || this.cityTextBox.Text.Equals("") ||
                this.stateComboBox.Text.Equals("") || this.zipCodeTextBox.Text.Equals(""))
            {
                this.registerResultLabel.ForeColor = Color.Red;
                this.registerResultLabel.Text = "Invalid/missing data. Please try again.";
                return false;
            }
            return true;
        }

        private void resetAllTextBoxes()
        {
            this.firstNameTextBox.Text = "";
            this.lastNameTextBox.Text = "";
            this.ssnTextBox.Text = "";
            this.phoneNumberTextBox.Text = "";
            this.cityTextBox.Text = "";
            this.streetAddressTextBox.Text = "";
            this.stateComboBox.Text = "";
            this.zipCodeTextBox.Text = "";
        }

        private void registerUserButton_Click(object sender, EventArgs e)
        {
            if (this.validateEntries())
            {
                this.registerCustomer();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loginForm = new LoginForm();
            this.Hide();
            this.loginForm.Show();
            this.loginForm.SetBounds(this.Location.X, this.Location.Y, this.loginForm.Width, this.loginForm.Height);
        }

        private void phoneNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.registerUserButton_Click(sender, e);
                this.firstNameTextBox.Focus();
            }
        }

        private void nameButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataset = this.db.searchByFirstName(this.searchForTextBox.Text);
                this.memberDataGridView.DataSource = this.dataset.Tables[0];
                this.memberSearchResultLabel.Text = "Search results: ";

                if (this.dataset.Tables[0].Rows.Count == 0)
                {
                    this.memberSearchResultLabel.Text = "Your search returned no results.";
                }
            }
            catch (Exception ex)
            {
                this.memberSearchResultLabel.Text = "Your search returned no results.";
            }
        }

        private void lastNameButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataset = this.db.searchByLastName(this.searchForTextBox.Text);
                this.memberDataGridView.DataSource = this.dataset.Tables[0];
                this.memberSearchResultLabel.Text = "Search results: ";

                if (this.dataset.Tables[0].Rows.Count == 0)
                {
                    this.memberSearchResultLabel.Text = "Your search returned no results.";
                }
            }
            catch (Exception ex)
            {
                this.memberSearchResultLabel.Text = "Your search returned no results.";
            }
        }

        private void phoneNumberButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataset = this.db.searchByPhoneNumber(this.searchForTextBox.Text);
                this.memberDataGridView.DataSource = this.dataset.Tables[0];
                this.memberSearchResultLabel.Text = "Search results: ";

                if (this.dataset.Tables[0].Rows.Count == 0)
                {
                    this.memberSearchResultLabel.Text = "Your search returned no results.";
                }
            }
            catch (Exception ex)
            {
                this.memberSearchResultLabel.Text = "Your search returned no results.";
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            try{

                // User entered ID only
                if(!this.furnitureIDTextBox.Text.Equals("") &&
                    this.furnitureTypeComboBox.Text.Equals("") && 
                    this.furnitureBrandComboBox.Text.Equals(""))
                {
                    this.dataset = this.db.searchFurnitureByIDOnly(this.furnitureIDTextBox.Text);
                }

                // User entered Type only
                if (this.furnitureIDTextBox.Text.Equals("") &&
                    !this.furnitureTypeComboBox.Text.Equals("") &&
                    this.furnitureBrandComboBox.Text.Equals(""))
                {
                    this.dataset = this.db.searchFurnitureByTypeOnly(this.furnitureTypeComboBox.Text);
                }

                // User entered Brand only
                if (this.furnitureIDTextBox.Text.Equals("") &&
                    this.furnitureTypeComboBox.Text.Equals("") &&
                    !this.furnitureBrandComboBox.Text.Equals(""))
                {
                    this.dataset = this.db.searchFurnitureByBrandOnly(this.furnitureBrandComboBox.Text);
                }

                // User entered ID and Type
                if (!this.furnitureIDTextBox.Text.Equals("") &&
                    !this.furnitureTypeComboBox.Text.Equals("") &&
                    this.furnitureBrandComboBox.Text.Equals(""))
                {
                    this.dataset = this.db.searchFurnitureByIDAndType(this.furnitureIDTextBox.Text, this.furnitureTypeComboBox.Text);
                }

                // User entered ID and Brand
                if (!this.furnitureIDTextBox.Text.Equals("") &&
                    this.furnitureTypeComboBox.Text.Equals("") &&
                    !this.furnitureBrandComboBox.Text.Equals(""))
                {
                    this.dataset = this.db.searchFurnitureByIDAndBrand(this.furnitureIDTextBox.Text, this.furnitureBrandComboBox.Text);
                }

                // User entered Type and Brand
                if (this.furnitureIDTextBox.Text.Equals("") &&
                    !this.furnitureTypeComboBox.Text.Equals("") &&
                    !this.furnitureBrandComboBox.Text.Equals(""))
                {
                    this.dataset = this.db.searchFurnitureByTypeAndBrand(this.furnitureTypeComboBox.Text, this.furnitureBrandComboBox.Text);
                }

                // User entered all fields.
                if (!this.furnitureIDTextBox.Text.Equals("") &&
                    !this.furnitureTypeComboBox.Text.Equals("") &&
                    !this.furnitureBrandComboBox.Text.Equals(""))
                {
                    this.dataset = this.db.searchFurnitureByAllTerms(this.furnitureIDTextBox.Text, this.furnitureTypeComboBox.Text, this.furnitureBrandComboBox.Text);
                }

                this.furnitureSearchResultLabel.Text = "Search results: ";
                this.furnitureDataGridView.DataSource = this.dataset.Tables[0];

                if (this.dataset.Tables[0].Rows.Count == 0)
                {
                    this.memberSearchResultLabel.Text = "Your search returned no results.";
                    this.furnitureDataGridView.RowCount = 0;
                }

                }

            catch (Exception ex)
            {
                this.furnitureSearchResultLabel.Text = "Your search returned no results.";
                this.furnitureDataGridView.ClearSelection();
            }
        }

        private void placeOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                db.placeOrder(this.rentMemberIDTextBox.Text, this.loggedInEmployee, this.rentFurnitureIDTextBox.Text, Int32.Parse(this.rentQuantityTextBox.Text));
                this.orderDetailsLabel.Text = "Order placed successfully. Details:";
                this.orderDetailsLabel.ForeColor = Color.Black;

                this.dataset = this.db.getOrderForMember(this.rentMemberIDTextBox.Text);
                this.rentalDataGridView.DataSource = this.dataset.Tables[0];

                this.rentMemberIDTextBox.Text = "";
                this.rentFurnitureIDTextBox.Text = "";
                this.rentQuantityTextBox.Text = "";
            }
            catch
            {
                this.orderDetailsLabel.Text = "There was a problem with your order.";
                this.orderDetailsLabel.ForeColor = Color.Red;
                this.rentalDataGridView.ClearSelection();
            }
        }

        private void getRentalsButton_Click(object sender, EventArgs e)
        {
            this.dataset = this.db.getOrderForMember(this.returnMemberIDTextBox.Text);
            this.returnDataGridView.DataSource = this.dataset.Tables[0];
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.db.returnOrder(this.returnOrderNumTextBox.Text);
                this.dataset = this.db.getOrderForMember(this.returnMemberIDTextBox.Text);
                this.returnDataGridView.DataSource = this.dataset.Tables[0];
                this.returnResultLabel.Text = "Order returned successfully.";
                this.returnResultLabel.ForeColor = Color.Black;
            }
            catch
            {
                this.returnResultLabel.Text = "There was a problem returning your order.";
                this.returnResultLabel.ForeColor = Color.Red;
            }
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}