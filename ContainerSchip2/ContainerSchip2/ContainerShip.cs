using ContainerSchip2.Types;
using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerSchip2 {
    public class ContainerShip {

        public List<Row> Rows { get; set; } = new List<Row>();
        public int Width { get; private set; }
        public int Height { get; private set; }

        public string ColdValuableError = "To many cooledValuables containers for given width";
        public string ColdError = "To many cooled containers for given dimensions";
        public string NormalError = "Something went wrong";
        public string ValuableError = "To many Valuable containers for given dimensions";
        public string MinWeightError = "Not enough containers to reach minimum weight";
        public string WeightDitributionError = "No weightdistribution possible";

        public ContainerShip(int width, int height) {
            Width = width;
            Height = height;
            Rows.Add(new Row(width, height, true));
        }

        public Error AddContainers(List<IContainer> containers) {

            if (!SortContainersCold((from container in containers where container is ContainerValuableCold orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = ColdValuableError };
            }

            if (!SortContainersCold((from container in containers where container is ContainerCold orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = ColdError };
            }

            if (!SortContainers((from container in containers where container is Container orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = NormalError };
            }

            if (!SortContainersValuable((from container in containers where container is ContainerValuable orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = ValuableError };
            }

            if (GetWeightDistribution() != null) {
                return GetWeightDistribution();
            }

            if (GetTotalWeight() < GetMinimumWeight()) {
                return new Error() { ErrorString = MinWeightError };
            }

            return null;
        }

        private bool SortContainersCold(List<IContainer> containers) {

            if (Rows.Count == 0) {
                Rows.Add(new Row(Width, Height, true));
            }

            foreach (IContainer container in containers) {
                if (!Rows[0].AddContainer(container)) {
                    return false;
                }
            }

            return true;
        }

        private bool SortContainersValuable(List<IContainer> containers) {


            if (Rows.Count == 0) {
                Rows.Add(new Row(Width, Height, true));
            }

            foreach (IContainer container in containers) {
                if (!Rows[0].AddContainerValuableOnTop(container)) {
                    if (Rows.Count > 1) {
                        if (!Rows[Rows.Count - 1].AddContainerValuableOnTop(container)) {
                            return false;
                        }
                    } else {
                        Rows.Add(CreateRow());
                        if (!Rows[Rows.Count - 1].AddContainerValuableOnTop(container)) {
                            return false;
                        }
                    }
                } 
            }

            return true;
        }

        private bool SortContainers(List<IContainer> containers) {

            if (Rows.Count == 0) {
                Rows.Add(new Row(Width, Height, true));
            }

            foreach (IContainer container in containers) {
                bool added = false;
                foreach (Row row in Rows) {
                    if (row.AddContainer(container)) {
                        added = true;
                        break;
                    }
                }

                if (!added) {
                    Rows.Add(CreateRow());

                    Rows[Rows.Count - 1].AddContainer(container);
                }
            }

            return true;
        }

        private Error GetWeightDistribution() {
            float weightLeft = 0;
            float weightTotal = 0;

            foreach (Row row in Rows) {
                weightLeft += row.GetLeftWeight();
                weightTotal += row.GetTotalWeight();
            }

            if (weightLeft/weightTotal > 0.6 || weightLeft/weightTotal < 0.4) {
                return new Error() { ErrorString = WeightDitributionError };
            } else {
                return null;
            }

        }

        private float GetTotalWeight() {
            float weight = 0;

            foreach (Row row in Rows) {
                weight += row.GetTotalWeight();
            }

            return weight;
        }

        private int GetMinimumWeight() {
            return Rows.Count * Width * 160000 / 2;
        }

        private Row CreateRow() {
            float leftWeight = 0;
            float rightWeight = 0;

            foreach (Row row in Rows) {
                leftWeight += row.GetLeftWeight();
                rightWeight += row.GetRightWeight();
            }

            if (leftWeight > rightWeight) {
                return new Row(Width, Height, true);
            } else {
                return new Row(Width, Height, false);
            }
        }

        //Nodig voor het schip uit te printen in console
        public void Print() {
            foreach (Row row in Rows) {
                row.Print();
                Console.WriteLine("-----------------");
            }

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||");
        }

        public bool Show() {
            string urlString = $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length={Width}&width={Rows.Count}&stacks=";
            string url = "";
            foreach (Row row in Rows) {
                foreach (Pile pile in row.Piles) {
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
                foreach (Pile pile in row.Piles) {
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

            return true;
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
