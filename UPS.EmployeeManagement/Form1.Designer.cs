namespace UPS.EmployeeManagement
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgListEmployees = new DataGridView();
            txtSearchUser = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgListEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgListEmployees
            // 
            dgListEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgListEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgListEmployees.Location = new Point(41, 93);
            dgListEmployees.Name = "dgListEmployees";
            dgListEmployees.RowHeadersWidth = 51;
            dgListEmployees.RowTemplate.Height = 29;
            dgListEmployees.Size = new Size(1571, 550);
            dgListEmployees.TabIndex = 0;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Location = new Point(41, 38);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.PlaceholderText = "Enter username for filter";
            txtSearchUser.Size = new Size(516, 27);
            txtSearchUser.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(582, 38);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(704, 38);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1518, 38);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1650, 672);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchUser);
            Controls.Add(dgListEmployees);
            Name = "Form1";
            Text = "EmployeeManagement";
            ((System.ComponentModel.ISupportInitialize)dgListEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgListEmployees;
        private TextBox txtSearchUser;
        private Button btnSearch;
        private Button btnClear;
        private Button btnDelete;
    }
}