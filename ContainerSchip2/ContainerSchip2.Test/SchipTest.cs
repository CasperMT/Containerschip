using ContainerSchip2.Types;
using ContainerSchip2Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ContainerSchip2.Test {
    [TestClass]
    public class SchipTest {

        private ContainerShip ship;
        private List<IContainer> containers;

        [TestInitialize]
        public void Setup() {
            ship = new ContainerShip(10, 3);
            containers = new List<IContainer>();
        }

        [TestMethod]
        public void ColdInFrontRow() {
            for (int i=0; i < 10; i++) {
                containers.Add(new Container(26000));
            }
            containers.Add(new ContainerCold(26000));
            containers.Add(new ContainerCold(26000));
            containers.Add(new ContainerCold(26000));

            ship.AddContainers(containers);

            for (int i=1; i < ship.Rows.Count; i++) {
                Assert.IsFalse(ship.Rows[i].CheckForCooled());
            }

            Assert.IsTrue(ship.Rows[0].CheckForCooled());
        }

        [TestMethod]
        public void MaxWidthCold() {
            ship = new ContainerShip(3, 10);
            for (int i = 0; i < 15; i++) {
                containers.Add(new Container(26000));
            }

            containers.Add(new ContainerValuableCold(26000));
            containers.Add(new ContainerValuableCold(26000));
            containers.Add(new ContainerValuableCold(26000));
            containers.Add(new ContainerValuableCold(26000));
            
            Assert.AreEqual(ship.AddContainers(containers).ErrorString, ship.ColdValuableError);
            ship.Print();
        }


    }
}
