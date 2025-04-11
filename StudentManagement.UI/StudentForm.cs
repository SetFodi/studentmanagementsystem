using StudentManagement.UI.StudentServiceRef; // Namespace from Service Reference
using System;
using System.ServiceModel; // For FaultException, CommunicationState
using System.Windows.Forms;

namespace StudentManagement.UI
{
    public partial class StudentForm : Form
    {
        private StudentServiceClient _client; // WCF client proxy
        private int _currentPage = 1;
        private readonly int _pageSize = 5; // Students per page
        private int _totalRecords = 0;
        private bool _isEditMode = false;

        public StudentForm()
        {
            InitializeComponent();
            // Client is initialized in Form_Load
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize the WCF client proxy
                _client = new StudentServiceClient();
                // Ensure client is ready (optional check)
                if (_client.State != CommunicationState.Created && _client.State != CommunicationState.Opening)
                {
                    // Handle case where client couldn't be created properly
                    // Maybe show error and close, or retry?
                    // For simplicity, we assume it's created ok here.
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize service client: {ex.Message}\n\nPlease ensure the StudentManagement.Service is running.",
                                "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Close the form or disable functionality if client fails
                this.Close();
                return;
            }

            ClearDetailsForm();
            DisableDetailsForm();
            LoadStudents(); // Initial load
        }

        private void LoadStudents()
        {
            if (_client == null || _client.State == CommunicationState.Faulted || _client.State == CommunicationState.Closed)
            {
                MessageBox.Show("Service client is not available. Please restart the application.", "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally try to recreate the client here
                return;
            }

            try
            {
                // Get filter values
                string nameFilter = string.IsNullOrWhiteSpace(txtFilterName.Text) ? null : txtFilterName.Text.Trim();
                // Use null if NumericUpDown value is 0 (our indicator for no grade filter)
                int? minGradeFilter = (numFilterMinGrade.Value > 0) ? (int?)numFilterMinGrade.Value : null;

                // Call WCF Service using the proxy client
                // The proxy generator maps the BLL's PagedResult<Student> to a client-side type.
                // We use 'var' to let the compiler infer this generated type.
                var pagedResult = _client.GetStudents(_currentPage, _pageSize, nameFilter, minGradeFilter);

                if (pagedResult != null)
                {
                    // The proxy generator also maps the Student entity.
                    // Assign the Results list (which contains StudentServiceRef.Student objects)
                    dgvStudents.DataSource = pagedResult.Results;
                    _totalRecords = pagedResult.TotalCount;

                    // Configure DataGridView Columns (only needs to be done once, but safe to repeat)
                    if (dgvStudents.Columns.Count > 0)
                    {
                        if (dgvStudents.Columns.Contains("Id"))
                        {
                            dgvStudents.Columns["Id"].Visible = false; // Hide ID column
                        }
                        // Format the BirthDate column
                        if (dgvStudents.Columns.Contains("BirthDate"))
                        {
                            dgvStudents.Columns["BirthDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                        }
                        // Hide ExtensionData if it appears (common with WCF DataContracts)
                        if (dgvStudents.Columns.Contains("ExtensionData"))
                        {
                            dgvStudents.Columns["ExtensionData"].Visible = false;
                        }
                    }

                    UpdatePaginationControls();
                    dgvStudents.ClearSelection(); // Clear selection after loading
                    // Disable edit/delete buttons initially after load
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    // Handle null result if necessary (e.g., clear grid)
                    dgvStudents.DataSource = null;
                    _totalRecords = 0;
                    UpdatePaginationControls();
                }
            }
            catch (FaultException<ExceptionDetail> faultEx) // Catch detailed faults
            {
                MessageBox.Show($"Service Fault: {faultEx.Detail.Message}\n{faultEx.Detail.StackTrace}",
                                "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Consider aborting client if faulted: _client?.Abort(); _client = null;
            }
            catch (FaultException faultEx) // Catch generic faults
            {
                MessageBox.Show($"Service Error: {faultEx.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Consider aborting client if faulted: _client?.Abort(); _client = null;
            }
            catch (CommunicationException commEx)
            {
                MessageBox.Show($"Communication Error: {commEx.Message}\nEnsure the service is running and accessible.",
                                "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Consider aborting client: _client?.Abort(); _client = null;
            }
            catch (TimeoutException timeEx)
            {
                MessageBox.Show($"The service operation timed out: {timeEx.Message}",
                                "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) // Catch any other unexpected errors
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePaginationControls()
        {
            // Calculate total pages, ensuring at least 1 page even if 0 records
            int totalPages = (_totalRecords > 0) ? (int)Math.Ceiling((double)_totalRecords / _pageSize) : 1;

            lblPageInfo.Text = $"Page: {_currentPage} / {totalPages}";
            btnPrevious.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadStudents();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (_totalRecords > 0) ? (int)Math.Ceiling((double)_totalRecords / _pageSize) : 1;
            if (_currentPage < totalPages)
            {
                _currentPage++;
                LoadStudents();
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            _currentPage = 1; // Reset to first page when applying new filters
            LoadStudents();
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            // Enable Edit/Delete buttons only if a row is selected AND not in Add/Edit mode
            bool isRowSelected = dgvStudents.SelectedRows.Count > 0;
            bool detailsEnabled = gbDetails.Enabled; // Check if details form is active

            btnEdit.Enabled = isRowSelected && !detailsEnabled;
            btnDelete.Enabled = isRowSelected && !detailsEnabled;
        }

        // --- Helper Methods for Form State ---

        private void EnableDetailsForm()
        {
            gbDetails.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            // Disable main buttons and grid interaction while editing/adding
            btnAdd.Enabled = false;
            btnEdit.Enabled = false; // Explicitly disable
            btnDelete.Enabled = false; // Explicitly disable
            gbFilters.Enabled = false;
            gbPagination.Enabled = false;
            dgvStudents.Enabled = false; // Prevent selection changes
        }

        private void DisableDetailsForm()
        {
            gbDetails.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            // Re-enable main controls
            btnAdd.Enabled = true;
            gbFilters.Enabled = true;
            gbPagination.Enabled = true;
            dgvStudents.Enabled = true;

            // Re-evaluate Edit/Delete button state based on current grid selection
            dgvStudents_SelectionChanged(null, null);
        }

        private void ClearDetailsForm()
        {
            txtStudentId.Text = string.Empty; // Hidden field for ID
            txtFirstName.Clear();
            txtLastName.Clear();
            // Set a reasonable default birth date (e.g., 15 years ago)
            dtpBirthDate.Value = DateTime.Now.Date.AddYears(-15);
            // Set grade to minimum or a common default
            numGrade.Value = numGrade.Minimum; // Or perhaps 9?
            _isEditMode = false; // Reset edit mode flag
            txtFirstName.Focus(); // Set focus to the first field
        }

        // --- CRUD Button Handlers ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _isEditMode = false; // Ensure we are in Add mode
            ClearDetailsForm(); // Clear fields and set defaults
            EnableDetailsForm(); // Enable the details groupbox
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                // Get the selected student object (cast to the service reference type)
                var selectedStudent = dgvStudents.SelectedRows[0].DataBoundItem as StudentServiceRef.Student;

                if (selectedStudent != null)
                {
                    _isEditMode = true; // Set flag to indicate Edit mode

                    // Populate form fields from selected student data
                    txtStudentId.Text = selectedStudent.Id.ToString(); // Store ID in hidden field
                    txtFirstName.Text = selectedStudent.FirstName;
                    txtLastName.Text = selectedStudent.LastName;
                    // Ensure DateTimeKind is unspecified or local for DateTimePicker if needed
                    dtpBirthDate.Value = DateTime.SpecifyKind(selectedStudent.BirthDate, DateTimeKind.Unspecified);
                    // Clamp grade value just in case it's outside the NumericUpDown range
                    numGrade.Value = Math.Max(numGrade.Minimum, Math.Min(numGrade.Maximum, selectedStudent.Grade));


                    EnableDetailsForm(); // Enable the details groupbox for editing
                }
                else
                {
                    MessageBox.Show("Could not retrieve student data from the selected row.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearDetailsForm(); // Clear any entered data
            DisableDetailsForm(); // Disable details group and re-enable main controls
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var selectedStudent = dgvStudents.SelectedRows[0].DataBoundItem as StudentServiceRef.Student;
                if (selectedStudent != null)
                {
                    // Confirmation dialog
                    var confirmResult = MessageBox.Show($"Are you sure you want to delete {selectedStudent.FirstName} {selectedStudent.LastName} (ID: {selectedStudent.Id})?",
                                                     "Confirm Delete",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            // Call the service to delete the student
                            bool success = _client.DeleteStudent(selectedStudent.Id);

                            if (success)
                            {
                                MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Refresh the grid - potentially stay on same page or go to page 1?
                                // Let's reload current page, but handle if it becomes empty
                                LoadStudents();
                            }
                            else
                            {
                                // This might happen if the student was deleted by someone else
                                MessageBox.Show("Student could not be found for deletion (it may have been deleted already).", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                LoadStudents(); // Refresh anyway
                            }
                        }
                        catch (FaultException faultEx)
                        {
                            MessageBox.Show($"Service Error deleting student: {faultEx.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (CommunicationException commEx)
                        {
                            MessageBox.Show($"Communication Error deleting student: {commEx.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- Basic Input Validation ---
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }
            // Add any other validation (e.g., birth date sanity check) if needed

            // --- Create Student Object (using Service Reference type) ---
            var student = new StudentServiceRef.Student
            {
                // ID is only set if in edit mode (comes from hidden field)
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                // Ensure only the Date part is sent if time is irrelevant
                BirthDate = dtpBirthDate.Value.Date,
                Grade = (int)numGrade.Value
            };

            try
            {
                if (_isEditMode)
                {
                    // --- Update Existing Student ---
                    // Get ID from the hidden text field
                    if (!int.TryParse(txtStudentId.Text, out int studentId))
                    {
                        MessageBox.Show("Invalid Student ID for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    student.Id = studentId;

                    bool success = _client.UpdateStudent(student);
                    if (success)
                    {
                        MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Student could not be found for update (it may have been deleted).", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // --- Add New Student ---
                    // ID will be generated by the database/service, so we don't set student.Id
                    _client.AddStudent(student);
                    MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Optionally, navigate to the last page to see the new student?
                    // For simplicity, we just reload the current view.
                }

                // --- Post-Save Actions ---
                ClearDetailsForm(); // Clear the input fields
                DisableDetailsForm(); // Disable details group, re-enable main controls
                LoadStudents(); // Refresh the grid to show changes
            }
            catch (FaultException faultEx)
            {
                MessageBox.Show($"Service Error saving student: {faultEx.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CommunicationException commEx)
            {
                MessageBox.Show($"Communication Error saving student: {commEx.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Consider logging the full exception details (ex.ToString()) for debugging
            }
        }

        // --- Form Closing: Dispose Client ---

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Properly dispose of the WCF client proxy to release resources
            if (_client != null)
            {
                try
                {
                    // Only call Close() if the client is in a state where it can be closed.
                    if (_client.State != CommunicationState.Faulted && _client.State != CommunicationState.Closed)
                    {
                        _client.Close();
                    }
                    else
                    {
                        // If it's faulted or already closed, just abort.
                        _client.Abort();
                    }
                }
                catch (CommunicationException)
                {
                    // Error during Close, abort instead.
                    _client.Abort();
                }
                catch (TimeoutException)
                {
                    // Timeout during Close, abort instead.
                    _client.Abort();
                }
                catch (Exception)
                {
                    // Any other error during Close/Abort, ensure it's aborted.
                    _client.Abort();
                    // Optionally log this exception
                }
                finally
                {
                    _client = null; // Help garbage collection
                }
            }
        }
    }
}
