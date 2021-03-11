using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Initialize() { }

        [TestMethod]
        public void Foo()
        {
            //
            var foo = true;

            //

            //
            Assert.IsTrue(foo) ;
        }
    }
}
