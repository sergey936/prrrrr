namespace training_ais
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            menuStrip = new MenuStrip();
            tsmiTrainings = new ToolStripMenuItem();
            tsmiAddTraining = new ToolStripMenuItem();
            tsmiHistory = new ToolStripMenuItem();
            tsmiExercises = new ToolStripMenuItem();
            tsmiStats = new ToolStripMenuItem();
            tsmiReports = new ToolStripMenuItem();
            tsmiUsers = new ToolStripMenuItem();
            dgvTrainings = new DataGridView();
            dtpFilter = new DateTimePicker();
            cmbCategoryFilter = new ComboBox();
            btnRefresh = new Button();
            chartStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblTotalWeight = new Label();
            lblAvgDuration = new Label();
            btnAddExercise = new Button();
            btnDeleteTraining = new Button();
            lblTotalTrainings = new Label();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrainings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartStats).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { tsmiTrainings, tsmiExercises, tsmiStats, tsmiReports, tsmiUsers });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "Главно меню";
            // 
            // tsmiTrainings
            // 
            tsmiTrainings.DropDownItems.AddRange(new ToolStripItem[] { tsmiAddTraining, tsmiHistory });
            tsmiTrainings.Name = "tsmiTrainings";
            tsmiTrainings.Size = new Size(85, 20);
            tsmiTrainings.Text = "Тренировки";
            // 
            // tsmiAddTraining
            // 
            tsmiAddTraining.Name = "tsmiAddTraining";
            tsmiAddTraining.Size = new Size(193, 22);
            tsmiAddTraining.Text = "Добавить тренировку";
            tsmiAddTraining.Click += btnAddTraining_Click;
            // 
            // tsmiHistory
            // 
            tsmiHistory.Name = "tsmiHistory";
            tsmiHistory.Size = new Size(193, 22);
            tsmiHistory.Text = "История тренировок";
            // 
            // tsmiExercises
            // 
            tsmiExercises.Name = "tsmiExercises";
            tsmiExercises.Size = new Size(88, 20);
            tsmiExercises.Text = "Упражнения";
            tsmiExercises.Click += tsmiExercises_Click;
            // 
            // tsmiStats
            // 
            tsmiStats.Name = "tsmiStats";
            tsmiStats.Size = new Size(80, 20);
            tsmiStats.Text = "Статистика";
            // 
            // tsmiReports
            // 
            tsmiReports.Name = "tsmiReports";
            tsmiReports.Size = new Size(60, 20);
            tsmiReports.Text = "Отчеты";
            // 
            // tsmiUsers
            // 
            tsmiUsers.Name = "tsmiUsers";
            tsmiUsers.Size = new Size(97, 20);
            tsmiUsers.Text = "Пользователи";
            tsmiUsers.Click += tsmiUsers_Click;
            // 
            // dgvTrainings
            // 
            dgvTrainings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainings.Location = new Point(12, 38);
            dgvTrainings.Name = "dgvTrainings";
            dgvTrainings.Size = new Size(401, 314);
            dgvTrainings.TabIndex = 1;
            // 
            // dtpFilter
            // 
            dtpFilter.Location = new Point(12, 369);
            dtpFilter.Name = "dtpFilter";
            dtpFilter.Size = new Size(200, 23);
            dtpFilter.TabIndex = 2;
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(249, 369);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(121, 23);
            cmbCategoryFilter.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(12, 415);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // chartStats
            // 
            chartArea1.Name = "ChartArea1";
            chartStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartStats.Legends.Add(legend1);
            chartStats.Location = new Point(529, 38);
            chartStats.Name = "chartStats";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartStats.Series.Add(series1);
            chartStats.Size = new Size(259, 252);
            chartStats.TabIndex = 5;
            chartStats.Text = "chart1";
            // 
            // lblTotalWeight
            // 
            lblTotalWeight.AutoSize = true;
            lblTotalWeight.Location = new Point(529, 304);
            lblTotalWeight.Name = "lblTotalWeight";
            lblTotalWeight.Size = new Size(122, 15);
            lblTotalWeight.TabIndex = 6;
            lblTotalWeight.Text = "Суммарный вес: 0 кг";
            // 
            // lblAvgDuration
            // 
            lblAvgDuration.AutoSize = true;
            lblAvgDuration.Location = new Point(529, 337);
            lblAvgDuration.Name = "lblAvgDuration";
            lblAvgDuration.Size = new Size(206, 15);
            lblAvgDuration.TabIndex = 7;
            lblAvgDuration.Text = "Средняя продолжительность: 0 мин";
            // 
            // btnAddExercise
            // 
            btnAddExercise.Location = new Point(479, 415);
            btnAddExercise.Name = "btnAddExercise";
            btnAddExercise.Size = new Size(142, 23);
            btnAddExercise.TabIndex = 8;
            btnAddExercise.Text = "Добавить упражнение";
            btnAddExercise.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTraining
            // 
            btnDeleteTraining.Location = new Point(646, 415);
            btnDeleteTraining.Name = "btnDeleteTraining";
            btnDeleteTraining.Size = new Size(142, 23);
            btnDeleteTraining.TabIndex = 9;
            btnDeleteTraining.Text = "Удалить тренировку";
            btnDeleteTraining.UseVisualStyleBackColor = true;
            btnDeleteTraining.Click += btnDeleteTraining_Click;
            // 
            // lblTotalTrainings
            // 
            lblTotalTrainings.AutoSize = true;
            lblTotalTrainings.Location = new Point(529, 369);
            lblTotalTrainings.Name = "lblTotalTrainings";
            lblTotalTrainings.Size = new Size(193, 15);
            lblTotalTrainings.TabIndex = 10;
            lblTotalTrainings.Text = "Общее количество тренировок: 0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTotalTrainings);
            Controls.Add(btnDeleteTraining);
            Controls.Add(btnAddExercise);
            Controls.Add(lblAvgDuration);
            Controls.Add(lblTotalWeight);
            Controls.Add(chartStats);
            Controls.Add(btnRefresh);
            Controls.Add(cmbCategoryFilter);
            Controls.Add(dtpFilter);
            Controls.Add(dgvTrainings);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "Form2";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrainings).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartStats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem tsmiTrainings;
        private ToolStripMenuItem tsmiAddTraining;
        private ToolStripMenuItem tsmiHistory;
        private ToolStripMenuItem tsmiExercises;
        private ToolStripMenuItem tsmiStats;
        private ToolStripMenuItem tsmiReports;
        private ToolStripMenuItem tsmiUsers;
        private DataGridView dgvTrainings;
        private DateTimePicker dtpFilter;
        private ComboBox cmbCategoryFilter;
        private Button btnRefresh;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStats;
        private Label lblTotalWeight;
        private Label lblAvgDuration;
        private Button btnAddExercise;
        private Button btnDeleteTraining;
        private Label lblTotalTrainings;
    }
}