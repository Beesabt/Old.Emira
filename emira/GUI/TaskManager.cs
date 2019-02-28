using System;
using System.Drawing;
using System.Windows.Forms;

namespace emira.GUI
{
    public partial class TaskManager : UserControl
    {

        public TaskManager()
        {
            InitializeComponent();
        }

        private void UpdateDataGridView()
        {



            #region Data Table Style
            //if (dgvTaskManager.RowCount == 0)
            //{
            //    dgvTaskManager.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //}
            //else
            //{
            //    dgvTaskManager.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //}

            //dgvTaskManager.Rows[0].Selected = false;
            #endregion
        }

        private void btnTaskModification_Click(object sender, EventArgs e)
        {
            try
            {
                TaskModificationPage _taskModificationPage = new TaskModificationPage();
                _taskModificationPage.ShowDialog();
                UpdateDataGridView();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\r\n\r\n" + error.GetBaseException().ToString(), error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle borderRectangle = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Black, borderRectangle);
            base.OnPaint(e);
        }

    }
}
