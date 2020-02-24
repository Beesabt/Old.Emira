﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using emira.BusinessLogicLayer;
using emira.HelperFunctions;

using NLog;

namespace emira.GUI
{
    public partial class StatisticsPage : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        Statistics statistics;
        DataTable dataTable;
        int togMove;
        int mValX;
        int mValY;

        public StatisticsPage()
        {
            InitializeComponent();

            // Set the location of the form according to the parent form's location
            // If it is zero then it set to the center of the screen
            Point _zeroLocation = new Point(0, 0);

            if (LocationInfo._location == _zeroLocation)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = LocationInfo._location;
            }

            // Load the content of the 'What' combobox
            cbWhat.Items.Add("Breakdown of current month without holidays");
            cbWhat.Items.Add("Breakdown of current year without holidays");
            cbWhat.SelectedIndex = 0;

            statistics = new Statistics();

            // Fill the 'Year' combox with years
            List<string> _years = statistics.GetYears();

            foreach (var item in _years)
            {
                cbYear.Items.Add(item);
            }

            // Set the actual year for the 'Year' combobox
            DateTime _today = DateTime.UtcNow;
            cbYear.SelectedItem = _today.Year.ToString();

            // Fill the 'Month' combox with months
            CultureInfo ci = new CultureInfo("hu-HU");
            for (int i = 1; i < 13; i++)
            {
                cbMonth.Items.Add(ci.DateTimeFormat.GetMonthName(i));
            }

            // Set the actual month for the 'Month' combobox
            cbMonth.SelectedItem = ci.DateTimeFormat.GetMonthName(_today.Month);

            // Default selected is the bar chart
            rbColumnChart.Checked = true;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string _selectedYear = cbYear.Text;
                string _selectedMonth = cbMonth.Text;
                string _actualTaskName = string.Empty;
                string _actualNumberOfHours = string.Empty;
                statistics = new Statistics();
                dataTable = new DataTable();

                // Make the chart visible
                chart.Series["Tasks"].Enabled = true;

                // Clear the chart area
                chart.Series["Tasks"].Points.Clear();

                // Set the type of the chart
                chart.Series["Tasks"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                if (rbPieChart.Checked)
                {
                    chart.Series["Tasks"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                }
                
                if (cbWhat.SelectedIndex == 0)
                {
                    dataTable = statistics.GetDataCurrentMonth(_selectedYear, _selectedMonth);

                    foreach (DataRow task in dataTable.Rows)
                    {
                        _actualTaskName = task[Texts.CatalogProperties.TaskName].ToString();
                        _actualNumberOfHours = task[Texts.CatalogProperties.NumberOfHours].ToString();

                        chart.Series["Tasks"].Points.AddXY(_actualTaskName, _actualNumberOfHours);

                    }
                }
                else
                {
                    //statistics.GetDataCurrentYear();
                }
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void cbWhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWhat.SelectedIndex == 1)
            {
                cbMonth.Enabled = false;
            }
            else
            {
                cbMonth.Enabled = true;
            }
        }

        private void cbWhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimalize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LocationInfo._location = this.Location;
            Cursor.Current = Cursors.WaitCursor;
            HomePage _homePage = new HomePage();
            _homePage.Show();
            Hide();
            Cursor.Current = Cursors.Default;
        }


        private void pHeader_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            mValX = e.X;
            mValY = e.Y;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
            {
                SetDesktopLocation(MousePosition.X - mValX, MousePosition.Y - mValY);
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
