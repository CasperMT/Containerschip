using ContainerSchip2.Types;
using ContainerSchip2Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ContainerSchip2 {
    public partial class Form1 : Form {
        public string NameRadio { get; private set; }
        List<IContainer> containers = new List<IContainer>();

        public Form1() {;

            InitializeComponent();

            foreach (var radio in Controls.OfType<RadioButton>()) {
                radio.Click += radioButton_CheckedChanged;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            var radio = (RadioButton)sender;
            NameRadio = radio.Name;
        }

        private IContainer CreateContainer(string name, int weight) {

            IContainer container = new Container(weight);

            switch (name) {
                case "normal":
                    container = new Container(weight);
                    break;
                case "valuable":
                    container = new ContainerValuable(weight);
                    break;
                case "cold":
                    container = new ContainerCold(weight);
                    break;
                case "coldValuable":
                    container = new ContainerValuableCold(weight);
                    break;
                default:
                    break;
            }

            return container;
        }

        private void button2_Click_1(object sender, EventArgs e) {
            if (Controls["widthBox"].Text.Length <= 0) {
                MessageBox.Show("no width given.");
            }

            if (Controls["heightBox"].Text.Length <= 0) {
                MessageBox.Show("no height given.");
            }

            if (Controls["widthBox"].Text.Length > 0 && Controls["heightBox"].Text.Length > 0) {
                int width = Convert.ToInt32(Controls["widthBox"].Text);
                int height = Convert.ToInt32(Controls["heightBox"].Text);
                ContainerShip ship = new ContainerShip(width, height);
                Error error = ship.AddContainers(containers);

                if (error == null) {
                    ship.Print();
                } else {
                    if (error.ErrorString.Equals("Het totale gewicht van de containers is te weinig voor de boot.")) {
                        //ship.PrintWeightDistribution();
                    }

                    ship.Print();
                }

            }

        }

        private void button1_Click(object sender, EventArgs e) {
            int weight = 0;

            foreach (Control c in Controls) {
                if (c.Name.Equals("ContentWeight")) {
                    weight = Convert.ToInt32(c.Text);
                }
            }
            Console.WriteLine(NameRadio);
            containers.Add(CreateContainer(NameRadio, weight));
        }
    }
}
