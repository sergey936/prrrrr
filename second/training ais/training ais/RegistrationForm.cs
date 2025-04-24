using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace training_ais
{
    public partial class RegistrationForm : Form
    {
        private const string ConnectionString = "Data Source=training_diary.sqlite;Version=3;";

        public RegistrationForm()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;

            if (password != confirm)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            try
            {
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    // Проверка существующего пользователя
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                    using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (exists > 0)
                        {
                            MessageBox.Show("Логин уже занят!");
                            return;
                        }
                    }

                    // Регистрация нового пользователя
                    string insertQuery = @"INSERT INTO Users (Username, Password, Role) 
                                        VALUES (@username, @password, 'User')";

                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Регистрация успешна!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}