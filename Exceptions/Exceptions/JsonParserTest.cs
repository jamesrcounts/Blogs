namespace Exceptions
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JsonParserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldValidateSource()
        {
            CrlfParser.DeserializeJson(null);
        }
    }
}