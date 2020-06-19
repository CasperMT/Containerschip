using ContainerSchip2.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerSchip2.Test {
    [TestClass]
    public class PileTest {


        private Pile pile;

        [TestInitialize]
        public void Setup() {
            pile = new Pile(10);
        }

        [TestMethod]
        public void MaxWeightOnTop() {
            pile.AddContainer(new Container(26000));
            pile.AddContainer(new Container(26000));
            pile.AddContainer(new Container(26000));
            pile.AddContainer(new Container(26000));
            
            Assert.IsTrue(pile.AddContainer(new Container(26000)));
            Assert.IsFalse(pile.AddContainer(new Container(0)));
        }

        [TestMethod]
        public void MaxHeight() {
            pile = new Pile(3);

            pile.AddContainer(new Container(0));
            pile.AddContainer(new Container(0));

            Assert.IsTrue(pile.AddContainer(new Container(0)));
            Assert.IsFalse(pile.AddContainer(new Container(0)));
        }

        [TestMethod]
        public void NotOnValuable() {
            pile.AddContainer(new ContainerValuable(0));

            Assert.IsFalse(pile.AddContainer(new ContainerValuable(0)));
        }

        [TestMethod]
        public void CheckForColdMethod() {
            pile.AddContainer(new ContainerCold(0));

            Assert.IsTrue(pile.CheckForCold());
        }

        [TestMethod]
        public void ValuableOnTop() {
            for (int i=0; i < 4; i++) {
                pile.AddContainer(new Container(26000));
            }

            pile.AddValuable(new ContainerValuable(26000));

            Assert.IsTrue(pile.Containers[pile.Containers.Count - 1] is ContainerValuable);
        }

        [TestMethod]
        public void CalculateTotalWeight() {
            for (int i = 0; i < 4; i++) {
                pile.AddContainer(new Container(26000));
            }

            Assert.AreEqual(pile.GetTotalWeight(), 120000);
        }

    }
}
