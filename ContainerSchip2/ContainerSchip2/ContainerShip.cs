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

        public ContainerShip(int width, int height) {
            Width = width;
            Height = height;
            Rows.Add(new Row(width, height));
        }

        public Error AddContainers(List<IContainer> containers) {

            if (!SortContainersCold((from container in containers where container is ContainerValuableCold orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = ColdValuableError };
            }

            if (!SortContainersCold((from container in containers where container is ContainerCold orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = "To many cooled containers for given dimensions" };
            }

            if (!SortContainers((from container in containers where container is Container orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = "Something went wrong" };
            }

            if (!SortContainersValuable((from container in containers where container is ContainerValuable orderby container.Weight descending select container).ToList())) {
                return new Error() { ErrorString = "To many Valuable containers for given dimensions" };
            }

            if (GetWeightDistribution() != null) {
                return GetWeightDistribution();
            }

            if (GetTotalWeight() < GetMinimumWeight()) {
                return new Error() { ErrorString = "Not enough containers to reach minimum weight" };
            }

            return null;
        }

        private bool SortContainersCold(List<IContainer> containers) {

            if (Rows.Count == 0) {
                Rows.Add(new Row(Width, Height));
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
                Rows.Add(new Row(Width, Height));
            }

            foreach (IContainer container in containers) {
                if (!Rows[0].AddContainerValuableOnTop(container)) {
                    if (Rows.Count > 1) {
                        if (!Rows[Rows.Count - 1].AddContainerValuableOnTop(container)) {
                            return false;
                        }
                    } else {
                        Rows.Add(new Row(Width, Height));
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
                Rows.Add(new Row(Width, Height));
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
                    Rows.Add(new Row(Width, Height));

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
                return new Error() { ErrorString = "No weightdistribution possible" };
            } else {
                return null;
            }

        }

        private int GetTotalWeight() {
            int weight = 0;

            foreach (Row row in Rows) {
                weight += row.GetTotalWeight();
            }

            return weight;
        }

        private int GetMinimumWeight() {
            return Rows.Count * Width * 160000 / 2;
        }


        //Nodig voor het schip uit te printen in console
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
