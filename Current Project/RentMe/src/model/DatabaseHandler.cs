using System;
using System.Data;
using MySql.Data.MySqlClient;
using MySql;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.model
{
    internal class DatabaseHandler
    {
        private const string ConStr =
            "server=cs.westga.edu; port=3307; uid=cs3230f13p;" +
            "pwd=uz2TNhQnPjFMAQKf;database=cs3230f13p;AllowZeroDateTime=true;";

        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataSet dataset;

        public bool CheckLoginInfo(string username, string password)
        {
            this.dataset = new DataSet();
            string query = "Select * From EMPLOYEE WHERE username='" + username + "' AND password = '" + password +
                           "';";
            bool isValid = true;

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(this.dataset);
            }

            catch (Exception ex)
            {
                isValid = false;
            }
            this.connection.Close();
            if (this.dataset.Tables[0].Rows.Count == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public DataSet runAdminQuery(string query)
        {
            DataSet set = new DataSet();

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);
                return set;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public void registerMember(string fname, string lname, string streetAddress, string city,
            string state, string zipCode, string ssn, string phone)
        {
            string query =
                "INSERT INTO MEMBER (`fName`, `lName`, `phone`, `streetAddress`, `city`, `state`, `zipCode`, `ssn`)" +
                " VALUES(@fname, @lname, @phone, @streetAddress, @city, @state, @zipCode, @ssn)";

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.connection.Open();

                var cmd = new MySqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@streetAddress", streetAddress);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@zipCode", zipCode);
                cmd.Parameters.AddWithValue("@ssn", ssn);

                cmd.ExecuteNonQuery();
                this.connection.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        private string getEmployeeNumFromUserName(string userName)
        {
            this.dataset = new DataSet();
            string id = "";
            string query = "Select `employee#` From EMPLOYEE WHERE `username`='" + userName + "';";

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(this.dataset);

                foreach (DataTable table in dataset.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (Object item in row.ItemArray)
                        {
                            id = item.ToString();
                        }
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        private double getFurniturePriceFromID(string furnitureID)
        {
            this.dataset = new DataSet();
            double pricePerDay = 0;
            string query = "Select pricePerDay From FURNITURE WHERE `furniture#`='" + furnitureID + "';";

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(this.dataset);

                foreach (DataTable table in dataset.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (Object item in row.ItemArray)
                        {
                            pricePerDay = Double.Parse(item.ToString());
                        }
                    }
                }

                return pricePerDay;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }


        public void placeOrder(string memberID, string employeeUserName, string furnitureID, int quantity)
        {

            string query =
                "INSERT INTO `ORDER` (`member#`, `employee#`, `furniture#`, `quantity`, `startDateTime`, `dueDate`, `pricePerDay`)" +
                " VALUES(@memberID, @employeeID, @furnitureID, @quantity, (SELECT NOW()), (SELECT NOW() + interval 1 month), @pricePerDay)";

            try
            {
                double pricePerDay = this.getFurniturePriceFromID(furnitureID) * quantity;
                string employeeNum = this.getEmployeeNumFromUserName(employeeUserName);

                this.connection = new MySqlConnection(ConStr);
                this.connection.Open();

                var cmd = new MySqlCommand(query, this.connection);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                cmd.Parameters.AddWithValue("@employeeID", employeeNum);
                cmd.Parameters.AddWithValue("@furnitureID", furnitureID);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@pricePerDay", pricePerDay);

                cmd.ExecuteNonQuery();
                this.connection.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public void returnOrder(string orderNum)
        {
            DataSet set = new DataSet();
            string query = "DELETE FROM `ORDER` WHERE `order#` = '" + orderNum + "';";
            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.connection.Open();

                var cmd = new MySqlCommand(query, this.connection);
                cmd.ExecuteNonQuery();

                this.connection.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet getOrderForMember(string memberNum)
        {
            DataSet set = new DataSet();
            string query = "SELECT * FROM `ORDER` WHERE `member#` = '" + memberNum + "';";

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);
                return set;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchByFirstName(string searchTerm)
        {
            DataSet set = new DataSet();
            string query = "SELECT * FROM MEMBER WHERE fName = '" + searchTerm + "';";

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);
                return set;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchByLastName(string searchTerm)
        {
            DataSet set = new DataSet();
            string query = "SELECT * FROM MEMBER WHERE lName = '" + searchTerm + "';";

            try
            {
                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);
                return set;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchByPhoneNumber(string searchTerm)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM MEMBER WHERE phone = '" + searchTerm + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchFurnitureByIDOnly(string furnitureID)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM FURNITURE WHERE `Furniture#` = '" + furnitureID + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchFurnitureByTypeOnly(string type)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM FURNITURE WHERE type = '" + type + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchFurnitureByBrandOnly(string brand)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM FURNITURE WHERE brand = '" + brand + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchFurnitureByIDAndType(string furnitureID, string type)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM FURNITURE WHERE `Furniture#` = '" + furnitureID + "' AND type = '" + type + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchFurnitureByIDAndBrand(string furnitureID, string brand)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM FURNITURE WHERE `Furniture#` = '" + furnitureID + "' AND brand = '" + brand + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchFurnitureByTypeAndBrand(string type, string brand)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM FURNITURE WHERE type = '" + type + "' AND brand = '" + brand + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }

        public DataSet searchFurnitureByAllTerms(string furnitureID, string type, string brand)
        {
            DataSet set = new DataSet();

            try
            {
                string query = "SELECT * FROM FURNITURE WHERE `Furniture#` = '" + furnitureID + "' AND type = '" + type + "' AND brand = '" + brand + "';";

                this.connection = new MySqlConnection(ConStr);
                this.adapter = new MySqlDataAdapter(query, this.connection);
                this.adapter.Fill(set);

                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.connection != null)
                    this.connection.Close();
            }
        }
    }
}