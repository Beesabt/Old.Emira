using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using emira.HelperFunctions;
using NLog;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace emira.GUI
{
    public partial class StatisticsSettingsPage : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        bool bTogMove;
        int iValX;
        int iValY;

        public StatisticsSettingsPage()
        {
            InitializeComponent();

            // Set the colors for the combobox
            cbColor.DataSource = Enum.GetValues(typeof(ChartColorPalette));

            // Set the axis text fonts
            foreach (FontFamily font in FontFamily.Families)
            {
                cbAxisFont.Items.Add(font.Name.ToString());
            }

            // Set the text alignments for the comoboboxes
            cbAxisXTextAlignment.DataSource = Enum.GetValues(typeof(StringAlignment));
            cbAxisYTextAlignment.DataSource = Enum.GetValues(typeof(StringAlignment));

            // Set the text orientations for the comoboboxes
            cbAxisXTextOrientation.DataSource = Enum.GetValues(typeof(TextOrientation));
            cbAxisYTextOrientation.DataSource = Enum.GetValues(typeof(TextOrientation));

            // Title
            tbTitle.Text = StatisticsSettingsPersi.Title;

            // Color
            cbColor.SelectedIndex = StatisticsSettingsPersi.ColorIndex;

            // Font
            cbAxisFont.SelectedIndex = StatisticsSettingsPersi.AxisFont;
            if (StatisticsSettingsPersi.AxisFont == 0)
                cbAxisFont.SelectedIndex = 1;

            // Size
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

            StatisticsSettingsPersi.ColorIndex = cbColor.SelectedIndex;

            StatisticsSettingsPersi.AxisFont = cbAxisFont.SelectedIndex;

            StatisticsSettingsPersi.AxisSize = cbAxisSize.SelectedIndex;

            StatisticsSettingsPersi.AxisXTitle = tbAxisXTitle.Text;
            StatisticsSettingsPersi.XTextAlignment = cbAxisXTextAlignment.SelectedIndex;
            StatisticsSettingsPersi.XTextOrientation = cbAxisXTextOrientation.SelectedIndex;

            StatisticsSettingsPersi.AxisYTitle = tbAxisYTitle.Text;
            StatisticsSettingsPersi.YTextAlignment = cbAxisYTextAlignment.SelectedIndex;
            StatisticsSettingsPersi.YTextOrientation = cbAxisYTextOrientation.SelectedIndex;

            ////XmlDataDocument xmldoc = new XmlDataDocument();
            ////XmlNodeList xmlnode;
            ////int i = 0;
            ////string str = null;
            ////FileStream fs = new FileStream(@"D:\Temp\ChartSettings2.xml", FileMode.Open, FileAccess.Read);
            ////xmldoc.Load(fs);
            ////xmlnode = xmldoc.GetElementsByTagName("Common");

            ////for (i = 0; i <= xmlnode.Count - 1; i++)
            ////{
            ////    xmlnode[i].ChildNodes.Item(0).InnerText = tbTitle.Text.Trim();
            ////    str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
            ////    MessageBox.Show(str);
            ////}

            ////// Create a new file in C:\\ dir  
            ////XmlTextWriter textWriter = new XmlTextWriter("D:\\Temp\\myXmFile.xml", null);
            ////// Opens the document  
            ////textWriter.WriteStartDocument();
            ////// Write comments  
            ////textWriter.WriteComment("First Comment XmlTextWriter Sample Example");
            ////textWriter.WriteComment("myXmlFile.xml in root dir");
            ////// Write first element  
            ////textWriter.WriteStartElement("Student");
            ////textWriter.WriteStartElement("r", "RECORD", "urn:record");
            ////// Write next element  
            ////textWriter.WriteStartElement("Name", "");
            ////textWriter.WriteString("Student");
            ////textWriter.WriteEndElement();
            ////// Write one more element  dfw
            ////textWriter.WriteStartElement("Address", "");
            ////textWriter.WriteString("Colony");
            ////textWriter.WriteEndElement();
            ////// WriteChars  
            ////char[] ch = new char[3];
            ////ch[0] = 'a';
            ////ch[1] = 'r';
            ////ch[2] = 'c';
            ////textWriter.WriteStartElement("Char");
            ////textWriter.WriteChars(ch, 0, ch.Length);
            ////textWriter.WriteEndElement();
            ////// Ends the document.  
            ////textWriter.WriteEndDocument();
            ////// close writer  
            ////textWriter.Close();

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
