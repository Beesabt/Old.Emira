using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using emira.BusinessLogicLayer;
using emira.Utilities;

namespace emira.GUI
{
    public partial class StatisticsForm : Form
    {
        Statistics statistics;
        DataTable dataTable;
        int togMove;
        int mValX;
        int mValY;

        public StatisticsForm()
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
                Double _actualNumberOfHour = 0;
                statistics = new Statistics();
                dataTable = new DataTable();

                if (chart == null)
                    return;

                // Make the chart visible
                chart.Visible = true;

                // Clear the chart area
                chart.Series[0].Points.Clear();

                // Set the type of the chart
                chart.Series[0].ChartType = SeriesChartType.Column;
                if (rbPieChart.Checked)
                {
                    chart.Series[0].ChartType = SeriesChartType.Pie;
                }

                ChartSettings();

                if (cbWhat.SelectedIndex == 0)
                {
                    dataTable = statistics.GetDataCurrentMonth(_selectedYear, _selectedMonth);

                    foreach (DataRow task in dataTable.Rows)
                    {
                        _actualTaskName = task[Texts.CatalogProperties.TaskName].ToString();
                        _actualNumberOfHours = task[Texts.CatalogProperties.NumberOfHours].ToString();

                        if (chart.Series[0].ChartType == SeriesChartType.Pie)
                        {
                            chart.Series[0].IsVisibleInLegend = true;
                            chart.Series[0].LabelFormat = "{#%}";
                            Double.TryParse(_actualNumberOfHours, out _actualNumberOfHour);
                            _actualNumberOfHour = _actualNumberOfHour / 100;
                            chart.Series[0].Points.AddXY(_actualTaskName, _actualNumberOfHour);
                        }
                        else
                        {
                            chart.Series[0].LabelFormat = "{#}";
                            chart.Series[0].IsVisibleInLegend = false;
                            chart.Series[0].Points.AddXY(_actualTaskName, _actualNumberOfHours);
                        }
                    }
                }
                else
                {
                    //statistics.GetDataCurrentYear();
                }
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
                return;
            }
        }

        public void ChartSettings()
        {
            // Clear
            chart.Titles.Clear();

            // Title
            Title title = new Title();
            if (StatisticsSettingsPersi.CommonFont == null)
            {
                title.Font = new Font("Arial", 14);
            }
            else
            {
                title.Font = new Font(StatisticsSettingsPersi.CommonFont, StatisticsSettingsPersi.CommonSize);
            }
            if (string.IsNullOrEmpty(StatisticsSettingsPersi.Title))
            {
                // Set default text
                chart.Titles.Add("Név");
            }
            else
            {
                chart.Titles.Add(StatisticsSettingsPersi.Title);
            } 

            // Color
            chart.Series[0].Palette = (ChartColorPalette)StatisticsSettingsPersi.ColorIndex;

            // Axis X
            if (StatisticsSettingsPersi.AxisFont == null)
            {
                chart.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 14);
            }
            else
            {
                chart.ChartAreas[0].AxisX.TitleFont = new Font(StatisticsSettingsPersi.AxisFont, StatisticsSettingsPersi.AxisSize);
            }            
            chart.ChartAreas[0].AxisX.Title = StatisticsSettingsPersi.AxisXTitle;
            if (string.IsNullOrEmpty(StatisticsSettingsPersi.AxisXTitle))
            {
                // Set default text
                chart.ChartAreas[0].AxisX.Title = "X tengely";
            }
            chart.ChartAreas[0].AxisX.TitleAlignment = (StringAlignment)StatisticsSettingsPersi.XTextAlignment;
            chart.ChartAreas[0].AxisX.TextOrientation = (TextOrientation)StatisticsSettingsPersi.XTextOrientation;

            // Axis Y
            if (StatisticsSettingsPersi.AxisFont == null)
            {
                chart.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 14);
            }
            else
            {
                chart.ChartAreas[0].AxisY.TitleFont = new Font(StatisticsSettingsPersi.AxisFont, StatisticsSettingsPersi.AxisSize);
            }
            chart.ChartAreas[0].AxisY.Title = StatisticsSettingsPersi.AxisYTitle;
            if (string.IsNullOrEmpty(StatisticsSettingsPersi.AxisYTitle))
            {
                // Set default text
                chart.ChartAreas[0].AxisY.Title = "Y tengely";
            }
            chart.ChartAreas[0].AxisY.TitleAlignment = (StringAlignment)StatisticsSettingsPersi.YTextAlignment;
            chart.ChartAreas[0].AxisY.TextOrientation = (TextOrientation)StatisticsSettingsPersi.YTextOrientation;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            StatisticsSettingsForm _statisticsSettingsPage = new StatisticsSettingsForm();
            _statisticsSettingsPage.ShowDialog();
            ChartSettings();
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
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            HomeForm _homePage = new HomeForm();
            _homePage.Show();
            Hide();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
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
