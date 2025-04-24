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
    public partial class ManageUsersForm : Form
    {
        private SQLiteConnection _connection = new SQLiteConnection("Data Source=training_diary.sqlite;Version=3;");
        public ManageUsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
                _connection.Open();
                string query = "SELECT UserID, Username, Role FROM Users";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, _connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        // Изменение роли
        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            var selectedRow = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            try
            {
                _connection.Open();
                string query = "UPDATE Users SET Role = @role WHERE UserID = @userId";

                using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@role", cmbRoles.Text);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }

                LoadUsers();
                MessageBox.Show("Роль обновлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        // Удаление пользователя
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            var selectedRow = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["UserID"].Value);

            try
            {
                _connection.Open();
                string query = "DELETE FROM Users WHERE UserID = @userId";

                using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }

                LoadUsers();
                MessageBox.Show("Пользователь удален!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
