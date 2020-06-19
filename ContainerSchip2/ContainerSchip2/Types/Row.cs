using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerSchip2.Types {
    public class Row {
        public List<Pile> Piles { get; private set; }
        public bool Even { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Offset { get; private set; }

        public Row(int width, int height, bool offset) {
            this.Piles = new List<Pile>();
            Width = width;
            Height = height;
            Offset = offset;

            if (width % 2 == 0) {
                Even = true;
            }
            else {
                Even = false;
            }

            for (int i=0; i < Width; i++) {
                Piles.Add(new Pile(height));
            }
        }

        public bool AddContainer(IContainer container) {
            if (Even) {
                return AddContainerEven(container);
            } else {
                return AddContainerOdd(container);
            }
        }

        public bool AddContainerValuableOnTop(IContainer container) {
            if (Even) {

                foreach (Pile pile in GetSideWithLowestWeight()) {
                    if (pile.AddValuable(container)) {
                        return true;
                    }
                }

                if (CheckWeightDistribution(container)) {
                    foreach (Pile pile in GetSideWithHighestWeight()) {
                        if (pile.AddValuable(container)) {
                            return true;
                        }
                    }

                }

                return false;
            } else {
                if (GetPileInMiddle().AddValuable(container)) {
                    return true;
                }


                foreach (Pile pile in GetSideWithLowestWeight()) {
                    if (pile.AddValuable(container)) {
                        return true;
                    }
                }

                if (CheckWeightDistribution(container)) {
                    foreach (Pile pile in GetSideWithHighestWeight()) {
                        if (pile.AddValuable(container)) {
                            return true;
                        }
                    }

                }

                return false;
            }
        }

        public bool Print() {

            for (int i = Height; i > -1; i--) {
                foreach (Pile pile in Piles) {

                    if (i < pile.Containers.Count) {
                        Console.Write($"{GetString(pile.Containers[i])}:{FormatWeight(pile.Containers[i].Weight)} ");
                    }
                    else {
                        Console.Write("+++++++++ ");
                    }

                }

                Console.WriteLine();
            }

            return true;
        }
        
        private bool AddContainerEven(IContainer container) {
            bool added = false;

            foreach (Pile pile in GetSideWithLowestWeight()) {
                if (!added) {
                    if (pile.AddContainer(container)) {
                        added = true;
                    }
                }
            }

            if (CheckWeightDistribution(container)) {
                foreach (Pile pile in GetSideWithHighestWeight()) {
                    if (!added) {
                        if (pile.AddContainer(container)) {
                            added = true;
                        }
                    }
                    
                }

            }
            

            return added;
        }

        private bool AddContainerOdd(IContainer container) {

            Console.WriteLine("dddd");
            if (GetPileInMiddle().AddContainer(container)) {
                return true;
            }

            foreach (Pile pile in GetSideWithLowestWeight()) {
                if (pile.AddContainer(container)) {
                    return true;
                }
            }

            if (CheckWeightDistribution(container)) {
                foreach (Pile pile in GetSideWithHighestWeight()) {
                    if (pile.AddContainer(container)) {
                        return true;
                    }
                }

            }

            return false;
        }

        //Krijg list met piles vand de kant die het minst weegt
        private List<Pile> GetSideWithLowestWeight() {

            if (Even) {
                int leftWeight = 0;
                foreach (Pile pile in Piles.Take(Piles.Count / 2)) {
                    leftWeight += pile.GetTotalWeight();
                }

                int rightWeight = 0;
                foreach (Pile pile in Piles.Skip(Piles.Count / 2).Take(Piles.Count / 2)) {
                    rightWeight += pile.GetTotalWeight();
                }

                if (Offset) {
                    if (leftWeight < rightWeight) {
                        return Piles.Take(Piles.Count / 2).ToList();
                    } else {
                        return Piles.Skip(Piles.Count / 2 + 1).Take(Piles.Count / 2).ToList();
                    }
                } else {
                    if (leftWeight <= rightWeight) {
                        return Piles.Take(Piles.Count / 2).ToList();
                    } else {
                        return Piles.Skip(Piles.Count / 2 + 1).Take(Piles.Count / 2).ToList();
                    }
                }
            }
            else {
                int leftWeight = 0;
                foreach (Pile pile in Piles.Take((Piles.Count - 1) / 2)) {
                    leftWeight += pile.GetTotalWeight();
                }

                int rightWeight = 0;
                foreach (Pile pile in Piles.Skip(((Piles.Count - 1) / 2)+1).Take((Piles.Count - 1) / 2)) {
                    rightWeight += pile.GetTotalWeight();
                }

                if (Offset) {
                    if (leftWeight < rightWeight) {
                        return Piles.Take((Piles.Count - 1) / 2).ToList();
                    } else {
                        return Piles.Skip(((Piles.Count - 1) / 2) + 1).Take((Piles.Count - 1) / 2).ToList();
                    }
                } else {
                    if (leftWeight <= rightWeight) {
                        return Piles.Take((Piles.Count - 1) / 2).ToList();
                    } else {
                        return Piles.Skip(((Piles.Count - 1) / 2) + 1).Take((Piles.Count - 1) / 2).ToList();
                    }
                }
                
            }


        }

        //Krijg list met piles van de kant die het meest weegt
        private List<Pile> GetSideWithHighestWeight() {

            if (Even) {
                int leftWeight = 0;
                foreach (Pile pile in Piles.Take(Piles.Count / 2)) {
                    leftWeight += pile.GetTotalWeight();
                }

                int rightWeight = 0;
                foreach (Pile pile in Piles.Skip(Piles.Count / 2).Take(Piles.Count / 2)) {
                    rightWeight += pile.GetTotalWeight();
                }

                if (Offset) {
                    if (leftWeight > rightWeight) {
                        return Piles.Take(Piles.Count / 2).ToList();
                    } else {
                        return Piles.Skip(Piles.Count / 2).Take(Piles.Count / 2).ToList();
                    }
                } else {
                    if (leftWeight >= rightWeight) {
                        return Piles.Take(Piles.Count / 2).ToList();
                    } else {
                        return Piles.Skip(Piles.Count / 2).Take(Piles.Count / 2).ToList();
                    }
                }
            } else {
                int leftWeight = 0;
                foreach (Pile pile in Piles.Take((Piles.Count - 1) / 2)) {
                    leftWeight += pile.GetTotalWeight();
                }

                int rightWeight = 0;
                foreach (Pile pile in Piles.Skip(((Piles.Count - 1) / 2) + 1).Take((Piles.Count - 1) / 2)) {
                    rightWeight += pile.GetTotalWeight();
                }

                if (Offset) {
                    if (leftWeight > rightWeight) {
                        return Piles.Take((Piles.Count - 1) / 2).ToList();
                    } else {
                        return Piles.Skip(((Piles.Count - 1) / 2) + 1).Take((Piles.Count - 1) / 2).ToList();
                    }
                } else {
                    if (leftWeight >= rightWeight) {
                        return Piles.Take((Piles.Count - 1) / 2).ToList();
                    } else {
                        return Piles.Skip(((Piles.Count - 1) / 2) + 1).Take((Piles.Count - 1) / 2).ToList();
                    }
                }

            }
        }

        private Pile GetPileInMiddle() {
            return Piles[Piles.Count - ((Piles.Count - 1) / 2) - 1];
        }

        private bool CheckWeightDistribution(IContainer container)  {

            if (GetLeftWeight() > GetRightWeight()) {
                if (GetTotalWeight() != 0) {
                    if ((GetLeftWeight() + container.Weight) / (GetLeftWeight() + GetRightWeight() + container.Weight) > 0.6 || (GetLeftWeight() + GetRightWeight() + container.Weight) / GetTotalWeight() < 0.4) {
                        return false;
                    }
                }
                
            } else {
                if (GetTotalWeight() != 0) {
                    if ((GetRightWeight() + container.Weight) / (GetLeftWeight() + GetRightWeight() + container.Weight) > 0.6 || (GetLeftWeight() + GetRightWeight() + container.Weight) / GetTotalWeight() < 0.4) {
                        return false;
                    }
                }
               
            }

            return true;
        }

        public float GetLeftWeight() {
            float weight = 0;
            if (Even) {
                foreach (Pile pile in Piles.Take(Piles.Count / 2)) {
                    weight += pile.GetTotalWeight();
                }
            } else {
                foreach (Pile pile in Piles.Take((Piles.Count-1) / 2)) {
                    weight += pile.GetTotalWeight();
                }
            }
            

            return weight;
        }

        public float GetRightWeight() {
            float weight = 0;

            if (Even) {
                foreach (Pile pile in Piles.Skip(Piles.Count / 2).Take(Piles.Count / 2)) {
                    weight += pile.GetTotalWeight();
                }
            } else {
                foreach (Pile pile in Piles.Skip((Piles.Count-1) / 2 + 1).Take((Piles.Count-1) / 2)) {
                    weight += pile.GetTotalWeight();
                }
            }
            

            return weight;
        }
       
        public float GetTotalWeight() {
            float weight = 0;

            foreach (Pile pile in Piles) {
                weight += pile.GetTotalWeight();
            }

            return weight;
        }










        //Nodig voor het schip uit te printen in console
        private string FormatWeight(int weight) {

            if (weight.ToString().Length == 6) {
                return weight.ToString();
            }
            else {
                int amount = 6 - weight.ToString().Length;
                string zeros = "";
                for (int i = 1; i <= amount; i++) {
                    zeros += "0";
                }

                return zeros + weight.ToString();
            }
        }

        private string GetString(IContainer container) {

            if (container is Container) {
                return "CO";
            }
            else if (container is ContainerValuable) {
                return "CV";
            }
            else if (container is ContainerValuableCold) {
                return "VC";
            }
            else {
                return "CC";
            }

        }


        //Voor unitTests
        public bool CheckForCooled() {
            foreach (Pile pile in Piles) {
                if (pile.CheckForCold()) {
                    return true;
                }
            }

            return false;
        }
    }
}
