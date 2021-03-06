using ContainerSchip2.Types;
using ContainerSchip2Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerSchip2.Test {
    [TestClass]
    public class ContainerTest {


        private IContainer container;

        [TestMethod]
        public void EmptyContainerWeight() {
            container = new Container(0);

            Assert.AreEqual(container.Weight, 4000);
        }

        [TestMethod]
        public void DefaultWeight() {
            container = new Container();

            Assert.AreEqual(container.Weight, 4000);
        }

    }
}
