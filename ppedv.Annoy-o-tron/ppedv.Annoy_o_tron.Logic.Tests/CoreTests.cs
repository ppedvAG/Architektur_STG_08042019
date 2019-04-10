using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Annoy_o_tron.Model;
using ppedv.Annoy_o_tron.Model.Contracts;

namespace ppedv.Annoy_o_tron.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetItemsOfTheDay_only_processes_of_the_future_return_no_items()
        {
            var repoMock = new Mock<IRepository<Process>>();
            repoMock.Setup(x => x.Query()).Returns(() =>
            {
                var p1 = new Process() { Created = DateTime.Now.AddDays(4) };
                var p2 = new Process() { Created = DateTime.Now.AddDays(1) };
                return new[] { p1, p2 }.AsQueryable();
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepo<Process>()).Returns(repoMock.Object);

            var core = new Core(uowMock.Object);

            var result = core.GetItemsOfTheDay(DateTime.Now);

            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void Core_GetItemsOfTheDay_one_daily()
        {
            var repoMock = new Mock<IRepository<Process>>();
            repoMock.Setup(x => x.Query()).Returns(() =>
            {
                var p1 = new Process() { Created = new DateTime(2019, 4, 8) };
                p1.Template = new Daily() { OnlyWorkdays = true };
                return new[] { p1 }.AsQueryable();
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepo<Process>()).Returns(repoMock.Object);

            var core = new Core(uowMock.Object);

            var result = core.GetItemsOfTheDay(new DateTime(2019, 4, 9));

            Assert.IsTrue(result.Count() == 1);
        }
    }
}
