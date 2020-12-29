using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using emira.Utilities;

namespace emira.GUI
{
    public partial class StatisticsSettingsForm : Form
    {
        bool bTogMove;
        int iValX;
        int iValY;

        public StatisticsSettingsForm()
        {
            InitializeComponent();

            // Set the common fonts
            foreach (FontFamily font in FontFamily.Families)
            {
                cbCommonFont.Items.Add(font.Name.ToString());
            }

            // Set the axis fonts
            foreach (FontFamily font in FontFamily.Families)
            {
                cbAxisFont.Items.Add(font.Name.ToString());
            }

            // Set the colors for the combobox
            cbColor.DataSource = Enum.GetValues(typeof(ChartColorPalette));

            // Set the text alignments for the comboboxes
            cbAxisXTextAlignment.DataSource = Enum.GetValues(typeof(StringAlignment));
            cbAxisYTextAlignment.DataSource = Enum.GetValues(typeof(StringAlignment));

            // Set the text orientations for the comboboxes
            cbAxisXTextOrientation.DataSource = Enum.GetValues(typeof(TextOrientation));
            cbAxisYTextOrientation.DataSource = Enum.GetValues(typeof(TextOrientation));

            // Title
            tbTitle.Text = StatisticsSettingsPersi.Title;

            // Common Font
            cbCommonFont.SelectedValue = StatisticsSettingsPersi.CommonFont;
            if (StatisticsSettingsPersi.CommonFont == null)
                cbCommonFont.SelectedIndex = 1;

            // Common Size
            cbCommonSize.SelectedIndex = StatisticsSettingsPersi.CommonSize;
            if (StatisticsSettingsPersi.CommonSize == 0)
                cbCommonSize.SelectedIndex = 2;

            // Color
            cbColor.SelectedIndex = StatisticsSettingsPersi.ColorIndex;

            // Axis Font
            cbAxisFont.SelectedValue = StatisticsSettingsPersi.AxisFont;
            if (StatisticsSettingsPersi.AxisFont == null)
                cbAxisFont.SelectedIndex = 1;

            // Axis Size
            cbAxisSize.SelectedIndex = StatisticsSettingsPersi.AxisSize;
            if (StatisticsSettingsPersi.AxisSize == 0)
                cbAxisSize.SelectedIndex = 2;

            // Axis X
            tbAxisXTitle.Text = StatisticsSettingsPersi.AxisXTitle;
            cbAxisXTextAlignment.SelectedIndex = StatisticsSettingsPersi.XTextAlignment;
            cbAxisXTextOrientation.SelectedIndex = StatisticsSettingsPersi.XTextOrientation;

            // Axis Y
            tbAxisYTitle.Text = StatisticsSettingsPersi.AxisYTitle;
            cbAxisYTextAlignment.SelectedIndex = StatisticsSettingsPersi.YTextAlignment;
            cbAxisYTextOrientation.SelectedIndex = StatisticsSettingsPersi.YTextOrientation;
        }

        private void StatisticsSettingsPage_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StatisticsSettingsPersi.Title = tbTitle.Text;
            StatisticsSettingsPersi.CommonFont = new FontFamily(cbCommonFont.SelectedItem.ToString());
            StatisticsSettingsPersi.CommonSize = cbCommonSize.SelectedIndex;

            StatisticsSettingsPersi.ColorIndex = cbColor.SelectedIndex;

            StatisticsSettingsPersi.AxisFont = new FontFamily(cbAxisFont.SelectedItem.ToString());
            StatisticsSettingsPersi.AxisSize = cbAxisSize.SelectedIndex;

            StatisticsSettingsPersi.AxisXTitle = tbAxisXTitle.Text;
            StatisticsSettingsPersi.XTextAlignment = cbAxisXTextAlignment.SelectedIndex;
            StatisticsSettingsPersi.XTextOrientation = cbAxisXTextOrientation.SelectedIndex;

            StatisticsSettingsPersi.AxisYTitle = tbAxisYTitle.Text;
            StatisticsSettingsPersi.YTextAlignment = cbAxisYTextAlignment.SelectedIndex;
            StatisticsSettingsPersi.YTextOrientation = cbAxisYTextOrientation.SelectedIndex;        

            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbAxisXTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void tbAxisYTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbAxisXTextAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbAxisYTextAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbAxisXTextOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbAxisYTextOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cbColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbAxisXTextAlignment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbAxisYTextAlignment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbAxisXTextOrientation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbAxisYTextOrientation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbAxisUnderline_Click(object sender, EventArgs e)
        {
            cbAxisUnderline.FlatAppearance.BorderSize = 0;
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

        }

        private void cbAxisUnderline_MouseHover(object sender, EventArgs e)
        {
            if (cbAxisUnderline.Checked)
            {
                cbAxisUnderline.FlatAppearance.BorderSize = 1;
            }
            else
            {
                cbAxisUnderline.FlatAppearance.BorderSize = 0;
            }
        }



        private void pHeader_MouseUp(object sender, MouseEventArgs e)
        {
            bTogMove = false;
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            bTogMove = true;
            iValX = e.X;
            iValY = e.Y;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (bTogMove)
            {
                SetDesktopLocation(MousePosition.X - iValX, MousePosition.Y - iValY);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle borderRectangle = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            Color _Win10BlueBorderColor = new Color();
            _Win10BlueBorderColor = Color.FromArgb(24, 116, 188);
            e.Graphics.DrawRectangle(new Pen(_Win10BlueBorderColor), borderRectangle);
            base.OnPaint(e);
        }
    }
}
