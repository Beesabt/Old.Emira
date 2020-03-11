
using System.Drawing;

namespace emira.HelperFunctions
{
    public static class GeneralInfo
    {
        public static int UserID = 1;
        public static string Email = "Loki@emira.com";
        public static bool AnnoyingMessage;
        public static string DefaultEmail = "Example@emira.com";
        public static string DefaultPassword = "Admin";
    }

    public static class StatisticsSettingsPersi
    {
        public static string Title = string.Empty;
        public static int ColorIndex = 0;
        public static int AxisFont = 0;
        public static int AxisSize = 0;
        public static string AxisXTitle = string.Empty;
        public static string AxisYTitle = string.Empty;
        public static int XTextAlignment = 0;
        public static int YTextAlignment = 0;
        public static int XTextOrientation = 0;
        public static int YTextOrientation = 0;
    }

    public class LocationInfo
    {
        public static Point _location = new Point();
    }
}