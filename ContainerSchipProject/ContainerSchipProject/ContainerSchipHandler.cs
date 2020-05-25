using ContainerSchipProject.Types;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchipProject {
    public class ContainerSchipHandler {

        public int Width { get; set; }
        public int Height { get; set; }
        public List<IContainer> Containers { get; private set; } = new List<IContainer>();
        public List<Row> Rows { get; private set; } = new List<Row>();

        

        
        public void AddContainer (IContainer container) {
            Containers.Add(container);
        }

        

    }
}
