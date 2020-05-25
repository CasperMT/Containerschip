using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchip2.Types {
    public class Row {
        public Pile PileMiddle { get; private set; }
        public PilesRight PilesRight { get; private set; }
        public PilesLeft PilesLeft { get; private set; }
        public bool Even { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        //public int Id { get; private set; } = 0;

        public Row(int width, int height) {
            PileMiddle = new Pile(height);
            Width = width;
            Height = height;
            if (width%2 == 0) {
                Even = true;
            } else {
                Even = false;
            }

            if (Even) {
                PilesRight = new PilesRight(height, width / 2);
                PilesLeft = new PilesLeft(height, width / 2);
            } else {
                PileMiddle = new Pile(height);
                PilesRight = new PilesRight(height, (width-1) / 2);
                PilesLeft = new PilesLeft(height, (width-1) / 2);
            }
        }

        public bool AddContainer(IContainer container) {
            if (Even) {
                if (PilesRight.GetWeight() < PilesLeft.GetWeight()) {
                    if (PilesRight.AddContainer(container)) {
                        return true;
                    }
                    else {
                        if (PilesLeft.AddContainer(container)) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
                else {
                    if (PilesLeft.AddContainer(container)) {
                        return true;
                    }
                    else {
                        if (PilesRight.AddContainer(container)) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
            } else {
                if (PileMiddle.AddContainer(container)) {
                    return true;
                } else {
                    if (PilesRight.GetWeight() < PilesLeft.GetWeight()) {
                        if (PilesRight.AddContainer(container)) {
                            return true;
                        } else {
                            if (PilesLeft.AddContainer(container)) {
                                return true;
                            } else {
                                return false;
                            }
                        }
                    } else {
                        if (PilesLeft.AddContainer(container)) {
                            return true;
                        } else {
                            if (PilesRight.AddContainer(container)) {
                                return true;
                            }
                            else {
                                return false;
                            }
                        }
                    }
                }
            }
        }

        public void Print() {
            List<Pile> pilesLeft = PilesLeft.Reverse();

            if (Even) {
                for (int i = Height; i > -1; i--) {
                    foreach (Pile pile in pilesLeft) {

                        if (i < pile.Containers.Count) {
                            Console.Write($"{GetString(pile.Containers[i])}:{FormatWeight(pile.Containers[i].Weight)} ");
                        }
                        else {
                            Console.Write("+++++++++ ");
                        }

                    }

                    Console.Write(" ");

                    foreach (Pile pile in PilesRight.Piles) {

                        if (i < pile.Containers.Count) {
                            Console.Write($"{GetString(pile.Containers[i])}:{FormatWeight(pile.Containers[i].Weight)} ");
                        }
                        else {
                            Console.Write("+++++++++ ");
                        }

                    }

                    Console.WriteLine();
                }
            } else {
                for (int i = Height; i > -1; i--) {
                    foreach (Pile pile in pilesLeft) {

                        if (i < pile.Containers.Count) {
                            Console.Write($"{GetString(pile.Containers[i])}:{FormatWeight(pile.Containers[i].Weight)} ");
                        } else {
                            Console.Write("+++++++++ ");
                        }

                    }

                    Console.Write(" ");
                    if (i < PileMiddle.Containers.Count) {
                        Console.Write($"{GetString(PileMiddle.Containers[i])}:{FormatWeight(PileMiddle.Containers[i].Weight)} ");
                    } else {
                        Console.Write("+++++++++ ");
                    }
                    Console.Write(" ");

                    foreach (Pile pile in PilesRight.Piles) {

                        if (i < pile.Containers.Count) {
                            Console.Write($"{GetString(pile.Containers[i])}:{FormatWeight(pile.Containers[i].Weight)} ");
                        } else {
                            Console.Write("+++++++++ ");
                        }

                    }

                    Console.WriteLine();
                }
            }
            
        }

        private string FormatWeight(int weight) {
           
            if (weight.ToString().Length == 6) {
                return weight.ToString();
            } else {
                int amount = 6 - weight.ToString().Length;
                string zeros = "";
                for (int i=1; i <= amount; i++) {
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
        
    }
}
