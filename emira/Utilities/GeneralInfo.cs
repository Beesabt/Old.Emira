using System.Drawing;

namespace emira.Utilities
{
    public static class GeneralInfo
    {
        public static int UserID = 1;
        public static bool AnnoyingMessage { get; set; }
        public static string DefaultEmail = "Example@emira.com";
        public static string DefaultPassword = "Admin";
    }

    public static class StatisticsSettingsPersi
    {
        public static string Title { get; set; }
        public static FontFamily CommonFont { get; set; }
        public static int CommonSize { get; set; }
        public static int ColorIndex { get; set; }
        public static FontFamily AxisFont { get; set; }
        public static int AxisSize { get; set; }
        public static string AxisXTitle { get; set; }
        public static string AxisYTitle { get; set; }
        public static int XTextAlignment { get; set; }
        public static int YTextAlignment { get; set; }
        public static int XTextOrientation { get; set; }
        public static int YTextOrientation { get; set; }
    }

    public class LocationInfo
    {
        public static Point _location = new Point();
    }
}