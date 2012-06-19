using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    /// <summary>
    /// Summary description for When_an_entity_is_materialized
    /// </summary>
    [TestClass]
    public class When_an_entity_is_materialized
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void its_context_should_be_populated()
        {
            using (var db = new AdventureWorksEntities())
            {
                var firstContact = db.Contacts.First();
                Assert.IsNotNull(firstContact.Context, "Context was null.");
            }
        }
    }
}
