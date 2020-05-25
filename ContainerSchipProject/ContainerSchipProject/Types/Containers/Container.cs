using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchipProject.Types {
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
