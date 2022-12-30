using System;
using System.Globalization;

namespace TerraNova3;

public class FloatToIntConverter : IValueConverter
{
public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
{
        //return (int)Math.Round((float)value) ;
        return System.Convert.ToInt32(value);
}

public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
{
    throw new NotImplementedException();
}
}

