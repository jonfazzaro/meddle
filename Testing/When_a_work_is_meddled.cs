using System.Linq;
using Meddle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class When_a_work_is_meddled
    {
        const int SIZE = 1000000;

        [TestMethod]
        public void addables_should_be_meddled()
        {
            using (var work = new TestWork(SIZE))
            {
                Meddler.Meddle(work);
                Assert.IsTrue(work.Entities.All(e => e.MeddledOnAdding));
            }
        }
        [TestMethod]
        public void updatables_should_be_meddled()
        {
            using (var work = new TestWork(SIZE))
            {
                Meddler.Meddle(work);
                Assert.IsTrue(work.Entities.All(e => e.MeddledOnUpdating));
            }
        }
        [TestMethod]
        public void deletables_should_be_meddled()
        {
            using (var work = new TestWork(SIZE))
            {
                Meddler.Meddle(work);
                Assert.IsTrue(work.Entities.All(e => e.MeddledOnDeleting));
            }
        }
    }
}
