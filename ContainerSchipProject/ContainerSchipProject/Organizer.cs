using ContainerSchipProject.Types;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSchipProject {

    public class Organizer {

        public List<IContainer> Containers { get; private set; } = new List<IContainer>();

        private List<IContainer> containersNormal = new List<IContainer>();
        private List<IContainer> containersCold = new List<IContainer>();
        private List<IContainer> containersValuableCold = new List<IContainer>();
        private List<IContainer> containersValuable = new List<IContainer>();

        public Organizer(List<IContainer> containers) {
            Containers = containers;
        }


    }
}
