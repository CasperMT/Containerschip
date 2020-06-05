using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchip2.Types {
    public class Pile {
        public int Height { get; set; }
        public List<IContainer> Containers { get; private set; }

        public Pile(int height) {
            Containers = new List<IContainer>();
            Height = height;
        }

        public bool AddContainer(IContainer container) {
            if (Containers.Count == Height) {
                return false;
            }

            if (container is ContainerValuable || container is ContainerValuableCold) {
                if (CheckValuableFree()) {

                    if (CheckWeightValuable(container)) {
                        Containers.Add(container);
                        return true;
                    } else {
                        return false;
                    }
                    
                } else {
                    return false;
                }
            } else {
                if (CheckWeight()) {
                    AddContainerOnBottom(container);
                    return true;
                } else {
                    return false;
                }
            }
        }

        public bool AddValuable(IContainer container) {
            if (!Containers.OfType<ContainerValuable>().Any() && !Containers.OfType<ContainerValuableCold>().Any()) {
                if (Containers.Count > 0) {
                    if (GetTotalWeight() - Containers[0].Weight + container.Weight <= 120000) {
                        Containers.Add(container);
                        return true;
                    }
                } else {
                    Containers.Add(container);
                    return true;
                }
                
            }

            return false;
        }

        public int GetTotalWeight() {
            int weight = 0;
            
            foreach (IContainer container in Containers) {
                weight += container.Weight;
            }

            return weight;
        }


        private bool CheckWeight() {
            int weight = 0;
            foreach (IContainer container in Containers) {
                weight += container.Weight;
            }

            if (weight <= 120000) {
                return true;
            } else {
                return false;
            }
        }
        
        private bool CheckWeightValuable(IContainer container) {
            int weight = container.Weight;

            for (int i=1; i < Containers.Count; i++) {
                weight += Containers[i].Weight;
            }

            if (weight <= 120000) {
                return true;
            } else {
                return false;
            }
        }

        private void AddContainerOnBottom(IContainer container) {
            List<IContainer> newContainers = new List<IContainer>();

            foreach (IContainer containerOld in Containers) {
                newContainers.Add(containerOld);
            }

            Containers.Clear();
            Containers.Add(container);

            foreach (IContainer newContainer in newContainers) {
                Containers.Add(newContainer);
            }
        }

        private bool CheckValuableFree() {
            foreach (IContainer container in Containers) {
                if (container is ContainerValuable || container is ContainerValuableCold) {
                    return false;
                }
            }

            return true;
        }


        public bool CheckForCold() {
            bool found = false;

            foreach (IContainer container in Containers) {
                if (container is ContainerCold || container is ContainerValuableCold) {
                    found = true;
                }
            }

            return found;
        }
    }
}
