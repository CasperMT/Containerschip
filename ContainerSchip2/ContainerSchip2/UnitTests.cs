using ContainerSchip2.Types;
using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerSchip2 {
    public class UnitTests {

        public static void Valuable() {
            List<IContainer> containers = new List<IContainer>();
            containers.Add(new ContainerValuable(20000));
            
            for (int i=0; i < 20; i++) {
                containers.Add(new Container(26000));
            }
            
            containers.Add(new ContainerValuable(20000));
            containers.Add(new ContainerValuable(20000));
            containers.Add(new ContainerValuable(20000));
            containers.Add(new ContainerValuable(20000));

            ContainerShip ship = new ContainerShip(4, 5);
            Error error = ship.AddContainer(containers);

            if (error == null) {
                ship.Print();
            } else {
                MessageBox.Show(error.ErrorString);
            }
        }

        public static void Cooled() {
            List<IContainer> containers = new List<IContainer>();
            containers.Add(new ContainerCold(20000));

            for (int i = 0; i < 10; i++) {
                containers.Add(new Container(20000));
            }

            containers.Add(new ContainerCold(20000));
            containers.Add(new ContainerCold(20000));
            containers.Add(new ContainerCold(20000));
            containers.Add(new ContainerCold(20000));

            ContainerShip ship = new ContainerShip(4, 10);
            Error error = ship.AddContainer(containers);

            if (error == null) {
                ship.Print();
            }
            else {
                MessageBox.Show(error.ErrorString);
            }
        }

        public static void CooledValuable() {
            List<IContainer> containers = new List<IContainer>();
            containers.Add(new ContainerValuableCold(20000));

            for (int i = 0; i < 10; i++) {
                containers.Add(new Container(26000));
            }

            containers.Add(new ContainerValuableCold(20000));
            containers.Add(new ContainerValuableCold(20000));

            ContainerShip ship = new ContainerShip(4, 10);
            Error error = ship.AddContainer(containers);

            if (error == null) {
                ship.Print();
            }
            else {
                MessageBox.Show(error.ErrorString);
            }
        }

        public static void MinWeight() {
            List<IContainer> containers = new List<IContainer>();

            for (int i = 0; i < 3; i++) {
                containers.Add(new Container(10000));
            }


            ContainerShip ship = new ContainerShip(4, 10);
            Error error = ship.AddContainer(containers);

            if (error == null) {
                ship.Print();
            }
            else {
                MessageBox.Show(error.ErrorString);
            }
        }

        public static void MaxWidth() {
            List<IContainer> containers = new List<IContainer>();

            for (int i = 0; i < 5; i++) {
                containers.Add(new ContainerValuableCold(26000));
            }
            for (int i = 0; i < 10; i++) {
                containers.Add(new Container(26000));
            }

            ContainerShip ship = new ContainerShip(4, 10);
            Error error = ship.AddContainer(containers);

            if (error == null) {
                ship.Print();
            }
            else {
                MessageBox.Show(error.ErrorString);
            }
        }

        public static void MaxWeightOnContiainers() {
            List<IContainer> containers = new List<IContainer>();

            for (int i = 0; i < 15; i++) {
                containers.Add(new Container(26000));
            }

            ContainerShip ship = new ContainerShip(4, 10);
            Error error = ship.AddContainer(containers);

            if (error == null) {
                ship.Print();
            }
            else {
                MessageBox.Show(error.ErrorString);
            }
        }

        public static void WeightDistribution() {
            List<IContainer> containers = new List<IContainer>();

            for (int i = 0; i < 15; i++) {
                containers.Add(new Container(26000));
            }

            ContainerShip ship = new ContainerShip(4, 10);
            Error error = ship.AddContainer(containers);

            if (error == null) {
                ship.Print();
                ship.PrintWeightDistribution();
            } else {
                MessageBox.Show(error.ErrorString);
            }


        }

    }
}
