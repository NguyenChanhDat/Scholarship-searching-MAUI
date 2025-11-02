using System.Globalization;

namespace FirstMAUI.Utils
{
    public class BoolToVietnameseVerifiedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolValue)
                return string.Empty;

            var param = parameter as string;

            return param switch
            {
                "IsVerified" => boolValue ? "Đã xác thực" : "Chưa xác thực",
                "IsFullScholarship" => boolValue ? "Toàn phần" : "Bán phần",
                _ => string.Empty
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
