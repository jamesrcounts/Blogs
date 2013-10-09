namespace Exceptions
{
    using System;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

    public static class CrlfParser
    {
        public static dynamic DeserializeJson(string source)
        {
            var text = Regex.Replace(source, @"\r?\n", Environment.NewLine);
            var o = JsonConvert.DeserializeObject(text);
            return o;
        }
    }
}