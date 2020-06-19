using ContainerSchip2.Types;
using ContainerSchip2Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerSchip2.Test {
    [TestClass]
    public class RowTest {


        private Row row;

        [TestInitialize]
        public void Setup() {
            row = new Row(4, 5, true);
        }

        [TestMethod]
        public void PilesListIsCreated() {
            row = new Row(4, 5, true);

            Assert.IsNotNull(row.Piles);
        }

        [TestMethod]
        public void SetWidthAndHeight() {
            row = new Row(4, 5, true);

            Assert.AreEqual(row.Width, 4);
            Assert.AreEqual(row.Height, 5);
        }

        [TestMethod]
        public void SetEven() {
            row = new Row(4, 5, true);

            Assert.IsTrue(row.Even);
        }

        [TestMethod]
        public void ContainerAdded() {
            IContainer container = new Container(0);

            row.AddContainer(container);

            bool found = false;
            foreach (Pile pile in row.Piles) {
                if (pile.Containers.Contains(container)) {
                    found = true;
                }
            }
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void AddContainerOffsetLeftOdd() {
            row = new Row(5, 5, false);

            row.AddContainer(new Container(26000));
            row.AddContainer(new Container(10000));
            row.AddContainer(new Container(10000));

            Assert.IsTrue(row.AddContainer(new ContainerValuable(0)));
        }

        [TestMethod]
        public void AddContainerOffsetLeftEven() {
            row = new Row(4, 5, false);

            row.AddContainer(new Container(26000));
            row.AddContainer(new Container(10000));
            row.AddContainer(new Container(10000));

            Assert.IsTrue(row.AddContainer(new ContainerValuable(0)));
        }

        [TestMethod]
        public void AddContainerLowestWeightFullEven() {
            row = new Row(4, 1, true);

            row.AddContainer(new Container(26000));
            row.AddContainer(new Container(10000));
            row.AddContainer(new Container(10000));

            Assert.IsTrue(row.AddContainer(new ContainerValuable(0)));
        }

        [TestMethod]
        public void AddContainerLowestWeightFullOdd() {
            row = new Row(5, 1, true);

            row.AddContainer(new Container(26000));
            row.AddContainer(new Container(26000));
            row.AddContainer(new Container(10000));
            row.AddContainer(new Container(10000));

            Assert.IsTrue(row.AddContainer(new Container(0)));
        }

        [TestMethod]
        public void AddValuableOnTopEven() {
            for(int i=0; i < 8; i++) {
                row.AddContainer(new Container(0));
            }
            IContainer container = new ContainerValuable();

            row.AddContainerValuableOnTop(container);

            bool ontop = false;
            foreach (Pile pile in row.Piles) {
                if (pile.Containers.Contains(container)) {
                    if (pile.Containers.IndexOf(container) == pile.Containers.Count-1) {
                        ontop = true;
                    }
                }
            }
            Assert.IsTrue(ontop);
        }

        [TestMethod]
        public void AddValuableOnTopOdd() {
            row = new Row(5, 4, true);
            for (int i = 0; i < 8; i++) {
                row.AddContainer(new Container(0));
            }

            IContainer container = new ContainerValuable();
            IContainer container1 = new ContainerValuable();
            IContainer container2 = new ContainerValuable();

            row.AddContainerValuableOnTop(container);
            row.AddContainerValuableOnTop(container1);
            row.AddContainerValuableOnTop(container2);
            
            bool ontop = false;
            foreach (Pile pile in row.Piles) {
                if (pile.Containers.Contains(container)) {
                    if (pile.Containers.IndexOf(container) == pile.Containers.Count - 1) {
                        ontop = true;
                    }
                }

                if (pile.Containers.Contains(container1)) {
                    if (pile.Containers.IndexOf(container1) == pile.Containers.Count - 1) {
                        ontop = true;
                    }
                }

                if (pile.Containers.Contains(container2)) {
                    if (pile.Containers.IndexOf(container2) == pile.Containers.Count - 1) {
                        ontop = true;
                    }
                }
            }

            Assert.IsTrue(ontop);
        }

        [TestMethod]
        public void GetTotalWeight() {
            for (int i = 0; i < 8; i++) {
                row.AddContainer(new Container(0));
            }

            Assert.AreEqual(row.GetTotalWeight(), 32000);
        }

        [TestMethod]
        public void GetLeftWeight() {
            for (int i = 0; i < 8; i++) {
                row.AddContainer(new Container(0));
            }

            Assert.AreEqual(row.GetLeftWeight(), 16000);
        }

        [TestMethod]
        public void GetRightWeight() {
            for (int i = 0; i < 8; i++) {
                row.AddContainer(new Container(0));
            }

            Assert.AreEqual(row.GetRightWeight(), 16000);
        }

        [TestMethod]
        public void EvenLowestFullValuable() {
            row = new Row(4, 5, true);

            row.AddContainerValuableOnTop(new ContainerValuable(26000));
            row.AddContainerValuableOnTop(new ContainerValuable(10000));
            row.AddContainerValuableOnTop(new ContainerValuable(10000));

            Assert.IsTrue(row.AddContainerValuableOnTop(new ContainerValuable(0)));
        }

        [TestMethod]
        public void OddLowestFullValuable() {
            row = new Row(5, 5, true);

            row.AddContainerValuableOnTop(new ContainerValuable(26000));
            row.AddContainerValuableOnTop(new ContainerValuable(26000));
            row.AddContainerValuableOnTop(new ContainerValuable(10000));
            row.AddContainerValuableOnTop(new ContainerValuable(10000));

            Assert.IsTrue(row.AddContainerValuableOnTop(new ContainerValuable(0)));
        }

        [TestMethod]
        public void NoErrorInPrint() {
            row.AddContainerValuableOnTop(new ContainerValuable(26000));
            row.AddContainerValuableOnTop(new ContainerValuable(10000));
            row.AddContainerValuableOnTop(new ContainerValuable(10000));

            Assert.IsNotNull(row.Print());
        }
    }
}
