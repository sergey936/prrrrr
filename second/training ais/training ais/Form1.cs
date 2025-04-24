using System.Data.SQLite;
using System.IO;


namespace training_ais
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = "Data Source=training_diary.sqlite;Version=3;";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDatabase()
        {
            string dbFilePath = "training_diary.sqlite";

            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);

                using (var conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))
                {
                    conn.Open();

                    // 1. Таблица Users (пароли в открытом виде)
                    string createUsersTable = @"
                CREATE TABLE Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,    -- Изменили PasswordHash → Password
                    Role TEXT NOT NULL CHECK (Role IN ('User', 'Admin'))
                )";

                    new SQLiteCommand(createUsersTable, conn).ExecuteNonQuery();

                    // 2. Таблица Trainings
                    string createTrainingsTable = @"
                CREATE TABLE Trainings (
                    TrainingID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserID INTEGER NOT NULL,
                    Date DATETIME NOT NULL,
                    Comment TEXT,
                    FOREIGN KEY (UserID) REFERENCES Users(UserID)
                )";

                    new SQLiteCommand(createTrainingsTable, conn).ExecuteNonQuery();

                    // 3. Таблица Exercises
                    string createExercisesTable = @"
                CREATE TABLE Exercises (
                    ExerciseID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    CategoryID INTEGER NOT NULL,
                    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
                )";

                    new SQLiteCommand(createExercisesTable, conn).ExecuteNonQuery();

                    // 4. Таблица Categories
                    string createCategoriesTable = @"
                CREATE TABLE Categories (
                    CategoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                )";

                    new SQLiteCommand(createCategoriesTable, conn).ExecuteNonQuery();

                    // 5. Таблица TrainingExercises
                    string createTrainingExercisesTable = @"
                CREATE TABLE TrainingExercises (
                    TrainingID INTEGER NOT NULL,
                    ExerciseID INTEGER NOT NULL,
                    Sets INTEGER,
                    Reps INTEGER,
                    Weight REAL,
                    Duration TEXT,
                    PRIMARY KEY (TrainingID, ExerciseID),
                    FOREIGN KEY (TrainingID) REFERENCES Trainings(TrainingID),
                    FOREIGN KEY (ExerciseID) REFERENCES Exercises(ExerciseID)
                )";

                    new SQLiteCommand(createTrainingExercisesTable, conn).ExecuteNonQuery();
                }

                // Добавляем тестовые данные
                AddTestData();
            }
        }
        private void AddTestData()
        {
            using (var conn = new SQLiteConnection("Data Source=training_diary.sqlite;Version=3;"))
            {
                conn.Open();

                // Добавляем тестового администратора
                string insertAdmin = @"
            INSERT INTO Users (Username, Password, Role)
            VALUES ('admin', 'admin123', 'Admin')";
        

        new SQLiteCommand(insertAdmin, conn).ExecuteNonQuery();

                // Добавляем категории
                string insertCategories = @"
            INSERT INTO Categories (Name)
            VALUES 
                ('Силовые'),
                ('Кардио'),
                ('Растяжка')";

                new SQLiteCommand(insertCategories, conn).ExecuteNonQuery();

                // Добавляем упражнения
                string insertExercises = @"
            INSERT INTO Exercises (Name, CategoryID)
            VALUES 
                ('Жим штанги', 1),
                ('Бег', 2),
                ('Планка', 3)";

                new SQLiteCommand(insertExercises, conn).ExecuteNonQuery();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            try
            {
                using (var conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Password, Role FROM Users WHERE Username = @username";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["Password"].ToString();
                                string role = reader["Role"].ToString();

                                if (password == storedPassword)
                                {
                                    MainForm mainForm = new MainForm(role, username);
                                    mainForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.ShowDialog();
        }

    }
}
