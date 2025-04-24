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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace training_ais
{
    public partial class MainForm : Form
    {
        private string _userRole;
        private int _currentUserId;
        private SQLiteConnection _connection = new SQLiteConnection("Data Source=training_diary.sqlite;Version=3;");

        public MainForm(string role, string username)
        {
            InitializeComponent();
            _userRole = role;
            ConfigureAccess();
            LoadUserData(username);
            LoadTrainings();
            LoadStatistics();
            InitializeChart();
        }
        private void LoadUserData(string username)
        {
            try
            {
                _connection.Open();
                string query = "SELECT UserID FROM Users WHERE Username = @username";
                using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    _currentUserId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        private void ConfigureAccess()
        {
            tsmiExercises.Visible = (_userRole == "Admin");
            tsmiUsers.Visible = (_userRole == "Admin");
        }

        private void LoadTrainings()
        {
            try
            {
                _connection.Open();
                string query = @"
                    SELECT t.TrainingID, t.Date, t.Comment, 
                           COUNT(te.ExerciseID) as ExercisesCount
                    FROM Trainings t
                    LEFT JOIN TrainingExercises te ON t.TrainingID = te.TrainingID
                    WHERE t.UserID = @userID
                    GROUP BY t.TrainingID
                    ORDER BY t.Date DESC";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, _connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@userID", _currentUserId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTrainings.DataSource = dt;
                    dgvTrainings.Columns["TrainingID"].Visible = false;
                    dgvTrainings.Columns["Date"].HeaderText = "Дата";
                    dgvTrainings.Columns["Comment"].HeaderText = "Комментарий";
                    dgvTrainings.Columns["ExercisesCount"].HeaderText = "Упражнений";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки тренировок: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        // Загрузка статистики
        private void LoadStatistics()
        {
            try
            {
                _connection.Open();

                // Общее количество тренировок
                string totalQuery = "SELECT COUNT(*) FROM Trainings WHERE UserID = @userID";
                using (SQLiteCommand cmd = new SQLiteCommand(totalQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("@userID", _currentUserId);
                    lblTotalTrainings.Text = $"Всего тренировок: {cmd.ExecuteScalar()}";
                }

                // Суммарный вес
                string weightQuery = @"
                    SELECT SUM(te.Weight) 
                    FROM TrainingExercises te
                    JOIN Trainings t ON te.TrainingID = t.TrainingID
                    WHERE t.UserID = @userID";

                using (SQLiteCommand cmd = new SQLiteCommand(weightQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("@userID", _currentUserId);
                    object result = cmd.ExecuteScalar();
                    lblTotalWeight.Text = $"Суммарный вес: {result ?? 0} кг";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        // Обработчики событий
        private void btnAddTraining_Click(object sender, EventArgs e)
        {
            AddTrainingForm addForm = new AddTrainingForm(_currentUserId);
            addForm.ShowDialog();
            LoadTrainings();
            LoadStatistics();
        }
        private void InitializeChart()
        {
            // Очистка предыдущих данных
            chartStats.Series.Clear();
            chartStats.Titles.Clear();

            // Настройка заголовка
            chartStats.Titles.Add("Статистика тренировок");

            // Создание серии данных
            Series series = new Series("Тренировки");
            series.ChartType = SeriesChartType.Column; // Тип графика (столбцы)

            // Загрузка данных из БД
            string query = @"
        SELECT strftime('%Y-%m', Date) AS Month, COUNT(*) AS Count 
        FROM Trainings 
        WHERE UserID = @userID 
        GROUP BY strftime('%Y-%m', Date)";

            using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@userID", _currentUserId);
                _connection.Open();
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string month = reader["Month"].ToString();
                        int count = Convert.ToInt32(reader["Count"]);
                        series.Points.AddXY(month, count); // Добавление точки
                    }
                }
                _connection.Close();
            }

            // Добавление серии на график
            chartStats.Series.Add(series);

            // Настройка осей
            chartStats.ChartAreas[0].AxisX.Title = "Месяц";
            chartStats.ChartAreas[0].AxisY.Title = "Количество тренировок";
        }

        private void btnDeleteTraining_Click(object sender, EventArgs e)
        {
            if (dgvTrainings.SelectedRows.Count == 0) return;

            int trainingId = Convert.ToInt32(dgvTrainings.SelectedRows[0].Cells["TrainingID"].Value);

            try
            {
                _connection.Open();
                string deleteQuery = "DELETE FROM Trainings WHERE TrainingID = @trainingID";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, _connection))
                {
                    cmd.Parameters.AddWithValue("@trainingID", trainingId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
            }
            finally
            {
                _connection.Close();
                LoadTrainings();
                LoadStatistics();
                InitializeChart();
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrainings();
            LoadStatistics();
            InitializeChart();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsmiExercises_Click(object sender, EventArgs e)
        {
            AddExerciseForm addExerciceForm = new AddExerciseForm();
            addExerciceForm.ShowDialog();
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            ManageUsersForm usersForm = new ManageUsersForm();
            usersForm.ShowDialog();
        }
    }
}
