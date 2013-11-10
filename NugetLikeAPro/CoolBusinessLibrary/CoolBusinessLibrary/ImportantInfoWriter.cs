namespace CoolBusinessLibrary
{
    using System.IO;

    public class ImportantInfoWriter
    {
        public static void WriteTo(FileInfo file)
        {
            using (var w = new StreamWriter(file.OpenWrite()))
            {
                w.Write("This information is very important!");
            }
        }
    }
}