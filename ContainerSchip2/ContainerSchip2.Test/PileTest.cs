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
        public void CheckCheckForColdMethod() {
            pile.AddContainer(new ContainerCold(0));

            Assert.IsTrue(pile.CheckForCold());
        }
    }
}
