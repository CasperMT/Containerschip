using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchip2.Types {
    public class Container : IContainer {

        public int Weight { get; set; }
        public Container(int contents) {
            Weight = contents + 4000;
        }

        public Container() {
            Weight = 4000;
        }
    }
}
