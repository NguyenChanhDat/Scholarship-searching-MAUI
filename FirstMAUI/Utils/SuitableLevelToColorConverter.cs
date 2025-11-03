using System.Globalization;

namespace FirstMAUI.Utils
{
    public class SuitableLevelToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int level)
            {
                if (level >= 70)
                    return Colors.DarkGreen;
                else if (level >= 40)
                    return Colors.RosyBrown;
                else
                    return Colors.DarkRed;
            }
<<<<<<< HEAD
            Console.WriteLine("This commit came from master branch");
=======
            Console.WriteLine("This commit came from other branch than master");
>>>>>>> 3701782 (feat: add log for 2nd branch)
            return Colors.Black; // fallback
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
