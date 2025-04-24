namespace training_ais
{
    partial class ManageUsersForm
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
            dgvUsers = new DataGridView();
            cmbRoles = new ComboBox();
            btnDeleteUser = new Button();
            btnChangeRole = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 29);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(520, 278);
            dgvUsers.TabIndex = 0;
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(548, 135);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(240, 23);
            cmbRoles.TabIndex = 1;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(588, 242);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(141, 23);
            btnDeleteUser.TabIndex = 2;
            btnDeleteUser.Text = "Удалить пользователя";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnChangeRole
            // 
            btnChangeRole.Location = new Point(588, 197);
            btnChangeRole.Name = "btnChangeRole";
            btnChangeRole.Size = new Size(141, 23);
            btnChangeRole.TabIndex = 3;
            btnChangeRole.Text = "Изменить роль";
            btnChangeRole.UseVisualStyleBackColor = true;
            btnChangeRole.Click += btnChangeRole_Click;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnChangeRole);
            Controls.Add(btnDeleteUser);
            Controls.Add(cmbRoles);
            Controls.Add(dgvUsers);
            Name = "ManageUsersForm";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private ComboBox cmbRoles;
        private Button btnDeleteUser;
        private Button btnChangeRole;
    }
}