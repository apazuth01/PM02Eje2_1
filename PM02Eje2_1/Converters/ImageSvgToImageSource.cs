using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Svg;
using Xamarin.Forms;
using System.Globalization;

namespace PM02Eje2_1.Converters
{
    public class ImageSvgToImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uriString = (string)value;
            Uri uri = new Uri(uriString);

            if (uri.AbsolutePath.ToLowerInvariant().EndsWith(".svg"))
            {
                return SvgImageSource.FromSvgUri(uriString, 30, 30, default(Color));
            }
            else
            {
                return ImageSource.FromUri(uri);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
