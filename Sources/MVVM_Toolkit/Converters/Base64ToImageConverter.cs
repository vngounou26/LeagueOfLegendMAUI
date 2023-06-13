using Model;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Toolkit.Converters
{
    public class Base64ToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LargeImage base64LargeImage)
            {
                byte[] imageBytes = System.Convert.FromBase64String(base64LargeImage.Base64);
                Stream memoryStream = new MemoryStream(imageBytes);
                return ImageSource.FromStream(() => memoryStream);
            }
            else if (value is string base64String)
            {
                byte[] imageBytes = System.Convert.FromBase64String(base64String);
                Stream memoryStream = new MemoryStream(imageBytes);
                return ImageSource.FromStream(() => memoryStream);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Stream stream)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return System.Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return null;
        }
    }

}
