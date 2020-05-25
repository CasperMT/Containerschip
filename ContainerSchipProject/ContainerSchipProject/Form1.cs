using ContainerSchipProject.Types;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerSchipProject {
    public partial class Form1 : Form {

        public string NameRadio { get; private set; }
        List<IContainer> containers = new List<IContainer>();

        public Form1() {
            InitializeComponent();

            foreach (var radio in Controls.OfType<RadioButton>()) {
                radio.Click += radioButton_CheckedChanged;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            int weight = 0;
            if (Controls["ContentWeight"].Text.Length > 0) {
                try {
                    weight = Convert.ToInt32(Controls["ContentWeight"].Text);
                } catch (Exception e1) {
                    MessageBox.Show("The maximum weight is 26000.");
                }
                
            }
            
            if (weight > 26000) {
                MessageBox.Show("The maximum weight is 26000.");
            } else {
                if (NameRadio != null) {
                    containers.Add(CreatContainer(NameRadio.Remove(0, 1), weight));
                } else {
                    MessageBox.Show("Choose a container type.");
                }
                
            }
            
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            var radio = (RadioButton)sender;
            NameRadio = radio.Name;
        }

        private IContainer CreatContainer(string name, int weight) {

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

        private void button2_Click(object sender, EventArgs e) {
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
                Error error = ship.AddContainer(containers);

                if (error == null) {
                    ship.Print();
                } else {
                    MessageBox.Show(error.ErrorString);

                    if (error.ErrorString.Equals("Het totale gewicht van de containers is te weinig voor de boot.")) {
                        ship.Print();
                    }
                }

                
            }

            
            
        }
    }
}
