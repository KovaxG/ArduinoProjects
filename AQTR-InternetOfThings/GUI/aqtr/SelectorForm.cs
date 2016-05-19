using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace aqtr
{
	public partial class SelectorForm : Form
	{
		private string[] ports;
		private int[] bauds;

		public SelectorForm()
		{
			InitializeComponent();
			showCommPorts();
			setBaudRates();
			showBaudRates();
		}

		private void getCommPorts()
		{
			ports = SerialPort.GetPortNames();
		}

		private void showCommPorts()
		{
			getCommPorts();
			comboBoxPort.Items.Clear();
			comboBoxPort.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxPort.SelectedIndex = 0;
            }
        }

		private void setBaudRates()
		{
			bauds = new int[] { 300, 600, 1200, 2400, 9600, 14400, 19200, 38400, 57600, 115200 };
		}

		private void showBaudRates()
		{
			comboBoxBauds.Items.Clear();
			comboBoxBauds.Items.AddRange(bauds.Select(x=>x.ToString()).ToArray());
		    comboBoxBauds.SelectedIndex = 4;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if ((comboBoxPort.SelectedIndex != -1) && (comboBoxBauds.SelectedIndex != -1))
			{
				this.Hide();
				new ViewerForm(ports[comboBoxPort.SelectedIndex], bauds[comboBoxBauds.SelectedIndex]).Show();
			}
		}
	}
}
