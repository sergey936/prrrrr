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
    public partial class AddExerciseForm : Form
    {
        private SQLiteConnection _connection = new SQLiteConnection("Data Source=training_diary.sqlite;Version=3;");
        public AddExerciseForm()
        {
            InitializeComponent();
            LoadCategories();
        }
        private void LoadCategories()
        {
            try
            {
                _connection.Open();
                string query = "SELECT CategoryID, Name FROM Categories";
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, _connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbCategories.DataSource = dt;
                    cmbCategories.DisplayMember = "Name";
                    cmbCategories.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        // Сохранение упражнения
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExerciseName.Text))
            {
                MessageBox.Show("Введите название упражнения!");
                return;
            }

            try
            {
                _connection.Open();
                string query = "INSERT INTO Exercises (Name, CategoryID) VALUES (@name, @categoryId)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@name", txtExerciseName.Text.Trim());
                    cmd.Parameters.AddWithValue("@categoryId", cmbCategories.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Упражнение успешно добавлено!");
                this.Close();
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