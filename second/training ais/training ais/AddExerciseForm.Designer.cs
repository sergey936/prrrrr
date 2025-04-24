namespace training_ais
{
    partial class AddExerciseForm
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
            txtExerciseName = new TextBox();
            cmbCategories = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtExerciseName
            // 
            txtExerciseName.Location = new Point(275, 89);
            txtExerciseName.Name = "txtExerciseName";
            txtExerciseName.Size = new Size(185, 23);
            txtExerciseName.TabIndex = 0;
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(275, 143);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(185, 23);
            cmbCategories.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(274, 208);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(385, 208);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(498, 92);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 4;
            label1.Text = "Название упражнения";
            // 
            // AddExerciseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbCategories);
            Controls.Add(txtExerciseName);
            Name = "AddExerciseForm";
            Text = "AddExerciseForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtExerciseName;
        private ComboBox cmbCategories;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
    }
}