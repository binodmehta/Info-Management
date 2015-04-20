using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.model;

namespace view
{
    public partial class AdminForm : Form
    {

        private LoginForm loginForm;
        private DataSet dataset;
        private readonly DatabaseHandler db = new DatabaseHandler();

        public AdminForm()
        {
            InitializeComponent();
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

        private void submitQueryButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataset = this.db.runAdminQuery(this.adminQueryRichTextBox.Text);
                this.rentalDataGridView.DataSource = this.dataset.Tables[0];
                this.adminResultLabel.Text = "Query Results: ";
                this.adminResultLabel.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                this.adminResultLabel.Text = "Invalid query.";
                this.adminResultLabel.ForeColor = Color.Red;
            }
        }
    }
}
