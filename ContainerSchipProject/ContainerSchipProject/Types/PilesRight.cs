using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchipProject.Types {
    public class PilesRight {
        public List<Pile> Piles{ get; private set; } = new List<Pile>();

        public PilesRight(int height, int width) {
            for (int i=0; i < width; i++) {
                Piles.Add(new Pile(height));
            }
        }

        public bool AddContainer(IContainer container) {
            foreach (Pile pile in Piles) {
                if (pile.AddContainer(container)) {
                    return true;
                }
            }

            return false;
        }

        public int GetWeight() {
            int weight = 0;

            foreach (Pile pile in Piles) {
                weight += pile.GetTotalWeight();
            }

            return weight;
        }
    }
}
