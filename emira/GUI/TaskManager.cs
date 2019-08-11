using emira.BusinessLogicLayer;
using emira.HelperFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class TaskManager : UserControl
    {
        DataTable _dataTable;
        TaskModification _taskModification;

        public TaskManager()
        {
            InitializeComponent();
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            try
            {
                //UpdateTable();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTable()
        {
            _taskModification = new TaskModification();
            _dataTable = new DataTable();
            _dataTable = _taskModification.GetTasks();
            BindingSource bSource = new BindingSource();
            bSource.Clear();
            bSource.DataSource = _dataTable;
            dgvTaskModification.DataSource = bSource;
        }

        private void dgvTaskModification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string _taskID = string.Empty;
                int _index = 0;
                tbTaskGroupID.Text = dgvTaskModification.SelectedRows[0].Cells[0].Value.ToString();
                tbTaskGroup.Text = dgvTaskModification.SelectedRows[0].Cells[1].Value.ToString();

                _taskID = dgvTaskModification.SelectedRows[0].Cells[2].Value.ToString();
                _index = _taskID.LastIndexOf('_');
                tbTaskID.Text = _taskID.Substring(_index + 1);

                tbTaskName.Text = dgvTaskModification.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool _isSuccess = false;
                _taskModification = new TaskModification();
                if (!_taskModification.TextBoxValueValidation(tbTaskGroupID.Text) || !_taskModification.TextBoxValueValidation(tbTaskGroup.Text) ||
                    !_taskModification.TextBoxValueValidation(tbTaskID.Text) || !_taskModification.TextBoxValueValidation(tbTaskName.Text))
                {
                    MessageBox.Show(Texts.ErrorMessages.RequiredFieldIsEmpty, Texts.Captions.EmptyRequiredField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(tbTaskGroupID.Text, "^[a-z A-Z]"))
                {
                    MessageBox.Show(lTaskGroupID.Text + Texts.ErrorMessages.NumericField, Texts.Captions.NumericField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (System.Text.RegularExpressions.Regex.IsMatch(tbTaskID.Text, "^[a-z A-Z]"))
                {
                    MessageBox.Show(lTaskID.Text + Texts.ErrorMessages.NumericField, Texts.Captions.NumericField, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _taskModification = new TaskModification();
                _isSuccess = _taskModification.AddNewTask(tbTaskGroupID.Text, tbTaskGroup.Text, tbTaskID.Text, tbTaskName.Text);

                if (!_isSuccess)
                {
                    MessageBox.Show(Texts.ErrorMessages.CheckValuesOfFields, Texts.Captions.InvalidValue, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tbTaskGroupID.Text = string.Empty;
                tbTaskGroup.Text = string.Empty;
                tbTaskID.Text = string.Empty;
                tbTaskName.Text = string.Empty;
                UpdateTable();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _taskModification = new TaskModification();
                string oldTaskID = dgvTaskModification.SelectedRows[0].Cells[2].Value.ToString();
                _taskModification.UpdateTask(oldTaskID, tbTaskGroupID.Text, tbTaskGroup.Text, tbTaskID.Text, tbTaskName.Text);
                tbTaskGroupID.Text = string.Empty;
                tbTaskGroup.Text = string.Empty;
                tbTaskID.Text = string.Empty;
                tbTaskName.Text = string.Empty;
                UpdateTable();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow actualRow in dgvTaskModification.SelectedRows)
                {
                    string TaskGroupID = actualRow.Cells[0].Value.ToString();
                    string TaskGroup = actualRow.Cells[1].Value.ToString();
                    string TaskID = actualRow.Cells[2].Value.ToString();
                    string TaskName = actualRow.Cells[3].Value.ToString();
                    _taskModification = new TaskModification();
                    _taskModification.DeleteItem(TaskGroupID, TaskGroup, TaskID, TaskName);
                }
                UpdateTable();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            _taskModification = new TaskModification();
            _dataTable = new DataTable();
            _dataTable = _taskModification.GetTasks();
            DataSet ds = new DataSet();
            ds.Tables.Add(_dataTable);
            ds.DataSetName = "TaskModification";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.WriteXml(sfd.FileName);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            printDocument.PrintPage += printDocument_PrintPage;

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font header_font = new Font("Times New Roman", 16, FontStyle.Bold))
            {
                using (Font body_font = new Font("Times New Roman", 12))
                {

                    string[] _headers = {Texts.TaskProperties.TaskGroupID,
                                         Texts.TaskProperties.TaskGroupName,
                                         Texts.TaskProperties.TaskID,
                                         Texts.TaskProperties.TaskName };

                    _taskModification = new TaskModification();
                    _dataTable = new DataTable();
                    _dataTable = _taskModification.GetTasks(false);

                    int count = 0;
                    //string[] _row = new string[_dataTable.Rows.Count];
                    List<string> _row = new List<string>();
                    List<string[]> _data = new List<string[]>();
                    foreach (DataRow row in _dataTable.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            //_row[count] = item.ToString();
                            _row.Add(item.ToString());
                            count++;
                        }
                        _data.Add(_row.ToArray());
                        count = 0;
                        _row.Clear();
                    }

                    // We'll skip this much space between rows.
                    int line_spacing = 20;

                    string[][] _dataArray = _data.ToArray();

                    // See how wide the columns must be.
                    int[] column_widths = FindColumnWidths(
                                    e.Graphics, header_font, body_font, _headers, _dataArray);

                    // Start at the left margin.
                    int x = e.MarginBounds.Left;

                    // Print by columns.
                    for (int col = 0; col < _headers.Length; col++)
                    {
                        // Print the header.
                        int y = e.MarginBounds.Top;
                        e.Graphics.DrawString(_headers[col],
                            header_font, Brushes.Blue, x, y);
                        y += (int)(line_spacing * 1.5);

                        // Print the items in the column.
                        for (int row = 0; row <=
                            _dataArray.GetUpperBound(0); row++)
                        {
                            e.Graphics.DrawString(_dataArray[row][col],
                                body_font, Brushes.Black, x, y);
                            y += line_spacing;
                        }

                        // Move to the next column.
                        x += column_widths[col];
                    } // Looping over columns


                    //DrawGrid(e, y)
                    e.HasMorePages = false;
                }
            }
        }

        //Figure out how wide each column should be.
        private int[] FindColumnWidths(Graphics gr, Font header_font,
            Font body_font, string[] headers, string[][] values)
        {
            // Make room for the widths.
            int[] widths = new int[headers.Length];

            // Find the width for each column.
            for (int col = 0; col < widths.Length; col++)
            {
                // Check the column header.
                widths[col] = (int)gr.MeasureString(
                    headers[col], header_font).Width;

                // Check the items.
                for (int row = 0; row <= values.GetUpperBound(0); row++)
                {
                    int value_width = (int)gr.MeasureString(
                        values[row][col], body_font).Width;
                    if (widths[col] < value_width)
                        widths[col] = value_width;
                }

                // Add some extra space.
                widths[col] += 20;
            }

            return widths;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle borderRectangle = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Black, borderRectangle);
            base.OnPaint(e);
        }

        
    }
}
