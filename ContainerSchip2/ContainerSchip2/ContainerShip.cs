using ContainerSchip2.Types;
using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;

namespace ContainerSchip2 {
    public class ContainerShip {

        public List<Row> Rows { get; set; } = new List<Row>();
        public int Width { get; private set; }
        public int Height { get; private set; }

        private List<IContainer> containersNormal = new List<IContainer>();
        private List<IContainer> containersCold = new List<IContainer>();
        private List<IContainer> containersValuable = new List<IContainer>();
        private List<IContainer> containersValuableCold = new List<IContainer>();

        public ContainerShip(int width, int height) {
            Width = width;
            Height = height;
            Rows.Add(new Row(width, height));
        }

        public Error AddContainer(List<IContainer> containers) {
            
            if (GetAmountOfValuable(containers) > Width * 2) {
                return new Error() { ErrorString = "To many valuable containers for the width." };
            }
            else if (GetAmountOfValuableCold(containers) > Width) {
                return new Error() { ErrorString = "To many ColdValuable containers for the width." };
            }

            SortContainers(containers);

            if ((GetAmountOfValuable(containers) - GetAmountOfValuableCold(containers)) <= Width) {
                return SortOption1(containers);
            }
            else {
                return SortOption2(containers);
            }
            
        }

        private Error SortOption1(List<IContainer> containers) {

            foreach (IContainer container in containersValuableCold) {
                if (!Rows[0].AddContainer(container)) {
                    return new Error() { ErrorString = "To many ColdValuable containers for the width." };
                }
            }

            foreach (IContainer container in containersCold) {
                if (!Rows[0].AddContainer(container)) {
                    return new Error() { ErrorString = "To many Cold containers for the given dimensions." };
                }
            }

            List<IContainer> tempContainers = new List<IContainer>();
            foreach (IContainer container in containersNormal) {
                if (Rows[0].AddContainer(container)) {
                    tempContainers.Add(container);
                }
            }
            DeleteContainersFromList(tempContainers);
            if (containersValuable.Count <= 0 && containersNormal.Count <= 0) {
                if (GetTotalWeight(containers) < GetMinimumWeight()) {
                    return new Error() { ErrorString = "Het totale gewicht van de containers is te weinig voor de boot." };
                }
                else {
                    return null;
                }
            }

            Rows.Add(new Row(Width, Height));
            foreach (IContainer container in containersValuable) {
                if (!Rows[1].AddContainer(container)) {
                    return new Error() { ErrorString = "To many Valuable containers for the given dimensions." };
                }
            }

            tempContainers.Clear();
            foreach (IContainer container in containersNormal) {
                if (Rows[1].AddContainer(container)) {
                    tempContainers.Add(container);
                }
            }
            DeleteContainersFromList(tempContainers);

            if (containersNormal.Count > 0) {
                AddNormalContainers();
            }

            if (GetTotalWeight(containers) < GetMinimumWeight()) {
                return new Error() { ErrorString = "Het totale gewicht van de containers is te weinig voor de boot." };
            }

            if (!CheckWeightDistribution()) {
                return new Error() { ErrorString = "HEt gewicht kan niet goed worden verdeeld" };
            }

            return null;
        }

        private Error SortOption2(List<IContainer> containers) {

            foreach (IContainer container in containersValuableCold) {
                if (!Rows[0].AddContainer(container)) {
                    return new Error() { ErrorString = "To many ColdValuable containers for the width." };
                }
            }

            foreach (IContainer container in containersCold) {
                if (!Rows[0].AddContainer(container)) {
                    return new Error() { ErrorString = "To many Cold containers for the given dimensions." };
                }
            }
            List<IContainer> tempContainersValuable = new List<IContainer>();
            foreach (IContainer container in containersValuable) {
                if (Rows[0].AddContainer(container)) {
                    tempContainersValuable.Add(container);
                }
            }
            DeleteContainersFromListValuable(tempContainersValuable);


            List<IContainer> tempContainers = new List<IContainer>();
            foreach (IContainer container in containersNormal) {
                if (Rows[0].AddContainer(container)) {
                    tempContainers.Add(container);
                }
            }
            DeleteContainersFromList(tempContainers);

            if (containersValuable.Count <= 0 && containersNormal.Count <= 0) {
                if (GetTotalWeight(containers) < GetMinimumWeight()) {
                    return new Error() { ErrorString = "Het totale gewicht van de containers is te weinig voor de boot." };
                } else {
                    return null;
                }
            }

            Rows.Add(new Row(Width, Height));

            foreach (IContainer container in containersValuable) {
                if (!Rows[1].AddContainer(container)) {
                    return new Error() { ErrorString = "To many Valuable containers for the given dimensions." };
                }
            }

            tempContainers.Clear();
            foreach (IContainer container in containersNormal) {
                if (Rows[1].AddContainer(container)) {
                    tempContainers.Add(container);
                }
            }
            DeleteContainersFromList(tempContainers);

            if (containersNormal.Count > 0) {
                AddNormalContainers();
            }

            Console.WriteLine($"--->{GetTotalWeight(containers)} ---->{GetMinimumWeight()}");
            if (GetTotalWeight(containers) < GetMinimumWeight()) {
                return new Error() { ErrorString = "Het totale gewicht van de containers is te weinig voor de boot." };
            }

            if (!CheckWeightDistribution()) {
                return new Error() { ErrorString = "HEt gewicht kan niet goed worden verdeeld" };
            }

            return null;
        }

        private void AddNormalContainers() {
            Row row = new Row(Width, Height);
            Row lastRow = Rows[Rows.Count - 1];
            Rows.Remove(lastRow);
            Rows.Add(row);

            List<IContainer> tempContainers = new List<IContainer>();
            foreach (IContainer container in containersNormal) {
                if (Rows[Rows.Count - 1].AddContainer(container)) {
                    tempContainers.Add(container);
                }
            }
            DeleteContainersFromList(tempContainers);

            Rows.Add(lastRow);

            if (containersNormal.Count > 0) {
                AddNormalContainers();
            }
        }

        private int GetAmountOfValuable(List<IContainer> containers) {
            int amount = 0;

            foreach (IContainer container in containers) {
                if (container is ContainerValuable || container is ContainerValuableCold) {
                    amount++;
                }
            }

            return amount;
        }

        private int GetAmountOfValuableCold(List<IContainer> containers) {
            int amount = 0;

            foreach (IContainer container in containers) {
                if (container is ContainerValuableCold) {
                    amount++;
                }
            }

            return amount;
        }

        private void SortContainers(List<IContainer> containers) {
            foreach (IContainer container in containers) {
                if (container is Container) {
                    containersNormal.Add(container);
                }
                else if (container is ContainerCold) {
                    containersCold.Add(container);
                }
                else if (container is ContainerValuableCold) {
                    containersValuableCold.Add(container);
                }
                else {
                    containersValuable.Add(container);
                }
            }
        }

        private int GetTotalWeight(List<IContainer> containers) {
            int weight = 0;
            foreach (IContainer container in containers) {
                weight += container.Weight;
            }
            return weight;
        }

        private int GetMinimumWeight() {
            return Rows.Count * Width * 160000 / 2;
        }

        private void DeleteContainersFromList(List<IContainer> containers) {
            foreach (IContainer container in containers) {
                containersNormal.Remove(container);
            }
        }

        private void DeleteContainersFromListValuable(List<IContainer> containers) {
            foreach (IContainer container in containers) {
                containersValuable.Remove(container);
            }
        }

        public void Print() {
            foreach (Row row in Rows) {
                row.Print();
                Console.WriteLine("-----------------");
            }

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||");
        }

        public void Show() {
            string urlString = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length={Width}&width={Rows.Count}&stacks=";
            string url = "";
            foreach (Row row in Rows) {
                foreach (Pile pile in row.PilesLeft.Piles) {
                    foreach (IContainer container in pile.Containers) {
                        urlString += ContainerToNumber(container) + "-";
                    }
                    urlString = urlString.Remove(urlString.Length - 1);
                    urlString += ",";
                }


                if (Width%2 == 1) {
                    foreach (IContainer container in row.PileMiddle.Containers) {
                        urlString += ContainerToNumber(container) + "-";
                    }
                    urlString = urlString.Remove(urlString.Length - 1);
                    urlString += ",";
                }
                


                foreach (Pile pile in row.PilesRight.Piles) {
                    foreach (IContainer container in pile.Containers) {
                        urlString += ContainerToNumber(container) + "-";
                    }
                    urlString = urlString.Remove(urlString.Length - 1);
                    urlString += ",";
                }
                urlString = urlString.Remove(urlString.Length - 1);

                urlString += "/";
            }
            urlString = urlString.Remove(urlString.Length - 1);
            urlString += "&weights=";
            foreach (Row row in Rows) {
                foreach (Pile pile in row.PilesLeft.Piles) {
                    foreach (IContainer container in pile.Containers) {
                        urlString += container.Weight.ToString() + "-";
                    }
                    urlString = urlString.Remove(urlString.Length - 1);
                    urlString += ",";
                }


                foreach (IContainer container in row.PileMiddle.Containers) {
                    urlString += container.Weight.ToString() + "-";
                }
                urlString = urlString.Remove(urlString.Length - 1);
                urlString += ",";


                foreach (Pile pile in row.PilesRight.Piles) {
                    foreach (IContainer container in pile.Containers) {
                        urlString += container.Weight.ToString() + "-";
                    }
                    urlString = urlString.Remove(urlString.Length - 1);
                    urlString += ",";
                }
                urlString = urlString.Remove(urlString.Length - 1);

                urlString += "/";
            }
            urlString = urlString.Remove(urlString.Length - 1);
            Console.WriteLine(urlString);
        }

        public void PrintWeightDistribution() {
            double totalWeight = 0;
            double leftWeight = 0;
            double rightWeight = 0;

            foreach (Row row in Rows) {
                totalWeight += row.GetTotalWeight();
                leftWeight += row.GetLeftWeight();
                rightWeight += row.GetRightWeight();
            }

            Console.WriteLine($"Weight distribution: {Math.Round(leftWeight / totalWeight * 100, 2)}/{Math.Round(rightWeight / totalWeight * 100, 2)}");
        }

        private bool CheckWeightDistribution() {
            double totalWeight = 0;
            double leftWeight = 0;
            double rightWeight = 0;

            foreach (Row row in Rows) {
                totalWeight += row.GetTotalWeight();
                leftWeight += row.GetLeftWeight();
                rightWeight += row.GetRightWeight();
            }

            if (leftWeight / totalWeight * 100 > 60 || rightWeight / totalWeight * 100 > 60) {
                return false;
            } else {
                return true;
            }
        }

        private string ContainerToNumber(IContainer container) {

            if (container is Container) {
                return "1";
            }
            else if (container is ContainerValuable) {
                return "2";
            }
            else if (container is ContainerValuableCold) {
                return "4";
            }
            else {
                return "3";
            }

        }
    }
}
