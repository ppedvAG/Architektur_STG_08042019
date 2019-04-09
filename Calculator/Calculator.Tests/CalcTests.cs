using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_throw_OverFlowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }

        [TestMethod]
        public void Calc_IsWeekend()
        {
            Calc calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 4, 8);
                Assert.IsFalse(calc.IsWeekend()); //Mo
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 4, 9);
                Assert.IsFalse(calc.IsWeekend()); //Di
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 4, 10);
                Assert.IsFalse(calc.IsWeekend()); //Mi
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 4, 11);
                Assert.IsFalse(calc.IsWeekend()); //Do
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 4, 12);
                Assert.IsFalse(calc.IsWeekend()); //Fr

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 4, 13);
                Assert.IsTrue(calc.IsWeekend()); //Sa

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 4, 14);
                Assert.IsTrue(calc.IsWeekend()); //So
            }
        }
    }
}
