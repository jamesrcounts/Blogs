using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemporaryFile.Tests
{
    using System.IO;

    using Xunit;

    public class TempTest
    {
        [Fact]
        public void DeleteBackingFile()
        {
            var temp = new Temp("DeleteBackingFile.txt");
            Assert.True(temp.File.Exists);
            temp.Dispose();
            Assert.False(File.Exists(temp.File.FullName));
        }
    }
}