namespace training_ais
{
    partial class AddTrainingForm
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
            dtpDate = new DateTimePicker();
            txtComment = new TextBox();
            lstExercises = new ListBox();
            numSets = new NumericUpDown();
            numReps = new NumericUpDown();
            txtDuration = new TextBox();
            btnAddExercise = new Button();
            btnSave = new Button();
            numWeight = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)numSets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReps).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(245, 13);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 0;
            // 
            // txtComment
            // 
            txtComment.Location = new Point(245, 57);
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(200, 23);
            txtComment.TabIndex = 1;
            // 
            // lstExercises
            // 
            lstExercises.FormattingEnabled = true;
            lstExercises.ItemHeight = 15;
            lstExercises.Location = new Point(127, 86);
            lstExercises.Name = "lstExercises";
            lstExercises.Size = new Size(318, 94);
            lstExercises.TabIndex = 2;
            lstExercises.SelectedIndexChanged += lstExercises_SelectedIndexChanged;
            // 
            // numSets
            // 
            numSets.Location = new Point(245, 197);
            numSets.Name = "numSets";
            numSets.Size = new Size(200, 23);
            numSets.TabIndex = 3;
            // 
            // numReps
            // 
            numReps.Location = new Point(245, 243);
            numReps.Name = "numReps";
            numReps.Size = new Size(200, 23);
            numReps.TabIndex = 4;
            // 
            // txtDuration
            // 
            txtDuration.Location = new Point(245, 341);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(200, 23);
            txtDuration.TabIndex = 5;
            // 
            // btnAddExercise
            // 
            btnAddExercise.Location = new Point(245, 380);
            btnAddExercise.Name = "btnAddExercise";
            btnAddExercise.Size = new Size(200, 23);
            btnAddExercise.TabIndex = 6;
            btnAddExercise.Text = "Добавить упражнение";
            btnAddExercise.UseVisualStyleBackColor = true;
            btnAddExercise.Click += btnAddExercise_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(245, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Сохранить тренировку";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // numWeight
            // 
            numWeight.Location = new Point(245, 290);
            numWeight.Name = "numWeight";
            numWeight.Size = new Size(200, 23);
            numWeight.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(481, 19);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 9;
            label1.Text = "Дата тренировки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(481, 65);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 10;
            label2.Text = "Комментарий";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(481, 135);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 11;
            label3.Text = "Список упражнений";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(481, 199);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 12;
            label4.Text = "Кол-во подходов";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(481, 243);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 13;
            label5.Text = "Кол-во повторений";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(481, 344);
            label6.Name = "label6";
            label6.Size = new Size(121, 15);
            label6.TabIndex = 14;
            label6.Text = "Продолжительность";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(481, 298);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 15;
            label7.Text = "Вес (кг)";
            // 
            // AddTrainingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numWeight);
            Controls.Add(btnSave);
            Controls.Add(btnAddExercise);
            Controls.Add(txtDuration);
            Controls.Add(numReps);
            Controls.Add(numSets);
            Controls.Add(lstExercises);
            Controls.Add(txtComment);
            Controls.Add(dtpDate);
            Name = "AddTrainingForm";
            Text = "AddTrainingForm";
            ((System.ComponentModel.ISupportInitialize)numSets).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReps).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private TextBox txtComment;
        private ListBox lstExercises;
        private NumericUpDown numSets;
        private NumericUpDown numReps;
        private TextBox txtDuration;
        private Button btnAddExercise;
        private Button btnSave;
        private NumericUpDown numWeight;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}