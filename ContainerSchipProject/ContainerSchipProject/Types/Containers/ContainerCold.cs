using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchipProject.Types {
    public class ContainerCold : IContainer {

        public int Weight { get; set; }

        public ContainerCold(int contents) {
            Weight = contents + 4000;
        }

        public ContainerCold() {
            Weight = 4000;
        }
    }
}
