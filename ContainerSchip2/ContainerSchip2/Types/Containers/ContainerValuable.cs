using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchip2.Types {
    public class ContainerValuable : IContainer {

        public int Weight { get; set; }

        public ContainerValuable(int contents) {
            Weight = contents + 4000;
        }

        public ContainerValuable() {
            Weight = 4000;
        }
    }
}
