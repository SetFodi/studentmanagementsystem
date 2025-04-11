namespace StudentManagement.UI
{
    partial class StudentForm
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
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.numGrade = new System.Windows.Forms.NumericUpDown();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox(); // Hidden ID field
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.numFilterMinGrade = new System.Windows.Forms.NumericUpDown();
            this.lblFilterMinGrade = new System.Windows.Forms.Label();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.gbPagination = new System.Windows.Forms.GroupBox();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGrade)).BeginInit();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterMinGrade)).BeginInit();
            this.gbPagination.SuspendLayout();
            this.SuspendLayout();
            //
            // dgvStudents
            //
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(12, 12);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(760, 250);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.SelectionChanged += new System.EventHandler(this.dgvStudents_SelectionChanged);
            //
            // gbDetails
            //
            this.gbDetails.Controls.Add(this.numGrade);
            this.gbDetails.Controls.Add(this.dtpBirthDate);
            this.gbDetails.Controls.Add(this.txtLastName);
            this.gbDetails.Controls.Add(this.txtFirstName);
            this.gbDetails.Controls.Add(this.lblGrade);
            this.gbDetails.Controls.Add(this.lblBirthDate);
            this.gbDetails.Controls.Add(this.lblLastName);
            this.gbDetails.Controls.Add(this.lblFirstName);
            this.gbDetails.Controls.Add(this.txtStudentId); // Add hidden field to group
            this.gbDetails.Location = new System.Drawing.Point(12, 340);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(400, 160);
            this.gbDetails.TabIndex = 4; // GroupBox itself needs a TabIndex
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Student Details";
            //
            // numGrade
            //
            this.numGrade.Location = new System.Drawing.Point(90, 125);
            this.numGrade.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numGrade.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numGrade.Name = "numGrade";
            this.numGrade.Size = new System.Drawing.Size(120, 20);
            this.numGrade.TabIndex = 7; // Inside groupbox, relative index
            this.numGrade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // dtpBirthDate
            //
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(90, 90);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(120, 20);
            this.dtpBirthDate.TabIndex = 6; // Inside groupbox
            //
            // txtLastName
            //
            this.txtLastName.Location = new System.Drawing.Point(90, 55);
            this.txtLastName.MaxLength = 100;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(280, 20);
            this.txtLastName.TabIndex = 5; // Inside groupbox
            //
            // txtFirstName
            //
            this.txtFirstName.Location = new System.Drawing.Point(90, 20);
            this.txtFirstName.MaxLength = 100;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(280, 20);
            this.txtFirstName.TabIndex = 4; // Inside groupbox
            //
            // lblGrade
            //
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(15, 127);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(39, 13);
            this.lblGrade.TabIndex = 3;
            this.lblGrade.Text = "Grade:";
            //
            // lblBirthDate
            //
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(15, 92);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(57, 13);
            this.lblBirthDate.TabIndex = 2;
            this.lblBirthDate.Text = "Birth Date:";
            //
            // lblLastName
            //
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(15, 58);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name:";
            //
            // lblFirstName
            //
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(15, 23);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            //
            // txtStudentId
            //
            this.txtStudentId.Location = new System.Drawing.Point(250, 90); // Position doesn't matter much
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(100, 20);
            this.txtStudentId.TabIndex = 8; // Keep it in tab order but hidden
            this.txtStudentId.Visible = false;
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(430, 350);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 25);
            this.btnAdd.TabIndex = 8; // Main form tab index
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnEdit
            //
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(430, 385);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 25);
            this.btnEdit.TabIndex = 9; // Main form tab index
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(430, 420);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 25);
            this.btnDelete.TabIndex = 10; // Main form tab index
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnSave
            //
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(430, 455);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 11; // Main form tab index
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(430, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 12; // Main form tab index
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // gbFilters
            //
            this.gbFilters.Controls.Add(this.btnApplyFilter);
            this.gbFilters.Controls.Add(this.numFilterMinGrade);
            this.gbFilters.Controls.Add(this.lblFilterMinGrade);
            this.gbFilters.Controls.Add(this.txtFilterName);
            this.gbFilters.Controls.Add(this.lblFilterName);
            this.gbFilters.Location = new System.Drawing.Point(12, 270);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(550, 60);
            this.gbFilters.TabIndex = 1; // Main form tab index
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filters";
            //
            // btnApplyFilter
            //
            this.btnApplyFilter.Location = new System.Drawing.Point(450, 23);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(90, 25);
            this.btnApplyFilter.TabIndex = 4; // Inside groupbox
            this.btnApplyFilter.Text = "Apply Filters";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            //
            // numFilterMinGrade
            //
            this.numFilterMinGrade.Location = new System.Drawing.Point(350, 25);
            this.numFilterMinGrade.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            // Minimum 0 means no filter applied by default
            this.numFilterMinGrade.Name = "numFilterMinGrade";
            this.numFilterMinGrade.Size = new System.Drawing.Size(70, 20);
            this.numFilterMinGrade.TabIndex = 3; // Inside groupbox
            //
            // lblFilterMinGrade
            //
            this.lblFilterMinGrade.AutoSize = true;
            this.lblFilterMinGrade.Location = new System.Drawing.Point(285, 28);
            this.lblFilterMinGrade.Name = "lblFilterMinGrade";
            this.lblFilterMinGrade.Size = new System.Drawing.Size(59, 13);
            this.lblFilterMinGrade.TabIndex = 2;
            this.lblFilterMinGrade.Text = "Min Grade:";
            //
            // txtFilterName
            //
            this.txtFilterName.Location = new System.Drawing.Point(90, 25);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(180, 20);
            this.txtFilterName.TabIndex = 1; // Inside groupbox
            //
            // lblFilterName
            //
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(15, 28);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(69, 13);
            this.lblFilterName.TabIndex = 0;
            this.lblFilterName.Text = "Name Filter:";
            //
            // gbPagination
            //
            this.gbPagination.Controls.Add(this.lblPageInfo);
            this.gbPagination.Controls.Add(this.btnNext);
            this.gbPagination.Controls.Add(this.btnPrevious);
            this.gbPagination.Location = new System.Drawing.Point(570, 270);
            this.gbPagination.Name = "gbPagination";
            this.gbPagination.Size = new System.Drawing.Size(200, 60);
            this.gbPagination.TabIndex = 2; // Main form tab index
            this.gbPagination.TabStop = false;
            this.gbPagination.Text = "Pagination";
            //
            // lblPageInfo
            //
            this.lblPageInfo.Location = new System.Drawing.Point(60, 28);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(80, 13);
            this.lblPageInfo.TabIndex = 1;
            this.lblPageInfo.Text = "Page: 1 / 1";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnNext
            //
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(145, 23);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(45, 25);
            this.btnNext.TabIndex = 2; // Inside groupbox
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            //
            // btnPrevious
            //
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Location = new System.Drawing.Point(10, 23);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(45, 25);
            this.btnPrevious.TabIndex = 0; // Inside groupbox
            this.btnPrevious.Text = "< Prev";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            //
            // StudentForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 521); // Adjusted client size
            this.Controls.Add(this.gbPagination);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.dgvStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentForm_FormClosing);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGrade)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFilterMinGrade)).EndInit();
            this.gbPagination.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.NumericUpDown numGrade;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.NumericUpDown numFilterMinGrade;
        private System.Windows.Forms.Label lblFilterMinGrade;
        private System.Windows.Forms.TextBox txtFilterName;
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.GroupBox gbPagination;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox txtStudentId;
    }
}
