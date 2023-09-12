using FunctionApp3;
using FunctionApp3.Helpers;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEmailParserPositive()
        {
            string fileName = "abc@mail.com my superfile.docx";

            if(EmailHelper.ParseEmailFormFileName(fileName) == "abc@mail.com")
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void TestEmailParserNegative()
        {
            string fileName = "abc@mail.com my superfile.docx";

            if (EmailHelper.ParseEmailFormFileName(fileName) == "ac@mail.com")
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}