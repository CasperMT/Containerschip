using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchip2.Types {
    public class ContainerValuableCold : IContainer {

        public int Weight { get; set; }

        public ContainerValuableCold(int contents) {
            Weight = contents + 4000;
        }

        public ContainerValuableCold() {
            Weight = 4000;
        }
    }
}
