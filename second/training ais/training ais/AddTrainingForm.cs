using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AddTrainingForm : Form
    {
        private int _userId;
        private List<ExerciseItem> _selectedExercises = new List<ExerciseItem>();
        private SQLiteConnection _connection = new SQLiteConnection("Data Source=training_diary.sqlite;Version=3;");

        public AddTrainingForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadExercises();
            dtpDate.MaxDate = DateTime.Today;
        }
        private class ExerciseItem
        {
            public int ExerciseID { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public int Sets { get; set; }
            public int Reps { get; set; }
            public decimal Weight { get; set; }
            public TimeSpan Duration { get; set; }
        }

        // Загрузка упражнений в ListBox
        private void LoadExercises()
        {
            try
            {
                _connection.Open();
                string query = @"
                    SELECT e.ExerciseID, e.Name, c.Name as Category 
                    FROM Exercises e
                    JOIN Categories c ON e.CategoryID = c.CategoryID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    lstExercises.Items.Clear();
                    while (reader.Read())
                    {
                        lstExercises.Items.Add(new
                        {
                            ExerciseID = reader.GetInt32(0),
                            Display = $"{reader["Name"]} ({reader["Category"]})",
                            Category = reader["Category"].ToString()
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки упражнений: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        // Добавление упражнения в список выбранных
        private void btnAddExercise_Click(object sender, EventArgs e)
        {
            if (lstExercises.SelectedItem == null)
            {
                MessageBox.Show("Выберите упражнение из списка!");
                return;
            }

            dynamic selected = lstExercises.SelectedItem;
            string category = selected.Category;

            // Валидация параметров
            if (category == "Силовые" && (numSets.Value == 0 || numReps.Value == 0))
            {
                MessageBox.Show("Для силовых упражнений укажите подходы и повторения!");
                return;
            }

            if (category == "Кардио" && !TimeSpan.TryParse(txtDuration.Text, out _))
            {
                MessageBox.Show("Некорректный формат времени (используйте ЧЧ:ММ:СС)!");
                return;
            }

            var exercise = new ExerciseItem
            {
                ExerciseID = selected.ExerciseID,
                Name = selected.Display.ToString().Split('(')[0].Trim(),
                Category = category,
                Sets = (int)numSets.Value,
                Reps = (int)numReps.Value,
                Weight = numWeight.Value,
                Duration = TimeSpan.Parse(category == "Кардио" ? txtDuration.Text : "00:00:00")
            };

            _selectedExercises.Add(exercise);
            MessageBox.Show("Упражнение добавлено!");
            ClearExerciseFields();
        }

        // Очистка полей ввода
        private void ClearExerciseFields()
        {
            numSets.Value = numReps.Value = numWeight.Value = 0;
            txtDuration.Text = "00:00:00";
            lstExercises.SelectedIndex = -1;
        }

        // Сохранение тренировки
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedExercises.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одно упражнение!");
                return;
            }

            try
            {
                _connection.Open();
                using (SQLiteTransaction transaction = _connection.BeginTransaction())
                {
                    // Сохранение тренировки
                    string insertTraining = @"
                        INSERT INTO Trainings (UserID, Date, Comment)
                        VALUES (@userID, @date, @comment);
                        SELECT last_insert_rowid();";

                    int trainingId;
                    using (SQLiteCommand cmd = new SQLiteCommand(insertTraining, _connection))
                    {
                        cmd.Parameters.AddWithValue("@userID", _userId);
                        cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@comment", txtComment.Text.Trim());
                        trainingId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Сохранение упражнений
                    foreach (var ex in _selectedExercises)
                    {
                        string insertExercise = @"
                            INSERT INTO TrainingExercises 
                            (TrainingID, ExerciseID, Sets, Reps, Weight, Duration)
                            VALUES (@trainingID, @exerciseID, @sets, @reps, @weight, @duration)";

                        using (SQLiteCommand cmd = new SQLiteCommand(insertExercise, _connection))
                        {
                            cmd.Parameters.AddWithValue("@trainingID", trainingId);
                            cmd.Parameters.AddWithValue("@exerciseID", ex.ExerciseID);
                            cmd.Parameters.AddWithValue("@sets", ex.Sets);
                            cmd.Parameters.AddWithValue("@reps", ex.Reps);
                            cmd.Parameters.AddWithValue("@weight", ex.Weight);
                            cmd.Parameters.AddWithValue("@duration", ex.Duration.ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Тренировка сохранена!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        // Автоматическое управление полями ввода
        private void lstExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExercises.SelectedItem == null) return;

            dynamic selected = lstExercises.SelectedItem;
            string category = selected.Category;

            numSets.Enabled = numReps.Enabled = numWeight.Enabled = (category == "Силовые");
            txtDuration.Enabled = (category == "Кардио");
        }
    }
}