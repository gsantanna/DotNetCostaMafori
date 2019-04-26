
using System.Reflection;

public static class Util
{
    public static object GetPropValue(object src, string propName)
    {
        if (src == null) return null;
        var prop = src.GetType().GetProperty(propName);
        return prop.GetValue(src, null);
    }

    
    public static void SetPropValue(object src, string propName, object vlr)
    {
        if (src == null) return;
        var prop = src.GetType().GetProperty(propName);
        prop.SetValue(src, vlr);
    } 
    



}
