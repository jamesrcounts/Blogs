namespace CoolBusinessLibrary.Tests
{
    using System.IO;

    using TemporaryFile;

    using Xunit;

    public class ImportantInfoWriterTest
    {
        [Fact]
        public void WriteImportantInfo()
        {
            using (var tf = new Temp("info.txt"))
            {
                ImportantInfoWriter.WriteTo(tf.File);
                string actual = File.ReadAllText(tf.File.FullName);
                Assert.Equal("This information is very important!", actual);
            }
        }
    }
}