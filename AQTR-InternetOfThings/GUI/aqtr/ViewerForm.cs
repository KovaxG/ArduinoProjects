using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Reflection;

namespace aqtr
{
	public partial class ViewerForm : Form
	{
		private SerialPort ComPort;
	    private DataMessage MessageLast;
	    private string MessageBuffer;
	    private StreamWriter log;
	    private int ValueOffset=0;

		public ViewerForm(string portName, int baudRate)
		{
			InitializeComponent();
			labelConnectionData.Text = portName + " " + baudRate;
			initializeCom(portName, baudRate);
		    try
		    {
		        string fileName = "log_<date>.txt";
		        fileName = fileName.Replace("<date>", DateTime.Now.ToString());
                fileName = fileName.Replace(':', '-');
                fileName = fileName.Replace(' ', '_');
                log = new StreamWriter(fileName);
                if (log == null)
                {
                    MessageBox.Show("Please check if you have write permissions\nThe data will not be logged", "Could not write to file");
                }
            }
		    catch (Exception)
		    {
		        MessageBox.Show("Please check if you have write permissions\nThe data will not be logged", "Could not write to file");
		    }

		}

		private void initializeCom(string portName, int baudRate)
		{
			ComPort = new SerialPort(portName, baudRate);
			ComPort.Parity = Parity.None;
			ComPort.StopBits = StopBits.One;
			ComPort.DataBits = 8;
			ComPort.Handshake = Handshake.None;
			ComPort.RtsEnable = true;
			ComPort.DataReceived += new SerialDataReceivedEventHandler(DataRecieved);
			ComPort.Open();
		}


	    private void DataRecieved(object sender, SerialDataReceivedEventArgs e)
	    {
	        SerialPort sp = (SerialPort) sender;
	        string data = sp.ReadExisting();

	        MessageBuffer += data;

	        // the message is logically terminated by endline, but is not the end of a transmission data chunk
	        if (MessageBuffer.Contains("\n"))
	        {
	            string[] tempArray = MessageBuffer.Split('\n');
	            MessageLast = new DataMessage(tempArray[0]);
	            if (ValueOffset != 0)
	            {
	                MessageLast.ValueIntOffset = ValueOffset;
	            }

	            MessageBuffer = tempArray[tempArray.Length - 1];
	            if (log != null)
	            {
	                log.WriteLine(DateTime.Now + "|" + MessageLast.Identifier+"|"+MessageLast.ValueInt);
	            }
	        }
			//textBox1.Text = data;
            ChangeText(data);
		}

		public void FormClosingHandler(object sender, FormClosingEventArgs e)
		{
		    if (log != null)
		    {
		        log.Flush();
		        log.Close();
		    }
		    if (ComPort != null)
			{
				ComPort.Close();
			}
			Application.Exit();
		}


	    public delegate void ChangeTextCallBack(string text);

	    public void ChangeText(string text)
	    {
	        if (textBoxHistory.InvokeRequired || labelDataName.InvokeRequired)
	        {
                ChangeTextCallBack d= new ChangeTextCallBack(ChangeText);
                this.Invoke(d, new object[] { text });
            }
	        else
	        {
	            textBoxHistory.Text += text;
	            labelDataName.Text = MessageLast.Identifier+":";
	            labelDataValue.Text = MessageLast.ValueInt.ToString();
	        }
	    }

        private void ViewerForm_DragDrop(object sender, DragEventArgs e)
        {
            this.textBoxHistory.Text = sender.ToString();
        }


        private void ViewerForm_MouseDoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "JPG Image Files|*.jpg|PNG Image Files|*.png|TIFF Image Files|*.tiff|Icon|*.ico|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image backgroundImage = Image.FromFile(openFileDialog1.FileName);
                this.Size = new Size(backgroundImage.Width, backgroundImage.Height);
                this.labelDataName.Location = 
                    new System.Drawing.Point(backgroundImage.Width/2-this.labelDataName.Text.Length*5,
                    backgroundImage.Height/3);
                this.labelDataValue.Location=
                    new System.Drawing.Point(backgroundImage.Width / 2 - this.labelDataValue.Text.Length * 5,
                    backgroundImage.Height / 3 + 30);
                this.BackgroundImage = backgroundImage;
            }
        }

        private void ViewerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ('h'):
                    this.textBoxHistory.Visible = !this.textBoxHistory.Visible;
                    this.textBoxHistory.Enabled = !this.textBoxHistory.Enabled;
                    this.labelConnectionData.Visible = !this.labelConnectionData.Visible;
                    this.labelConnectionData.Enabled = !this.labelConnectionData.Enabled;
                    this.labelOffset.Visible = !this.labelOffset.Visible;
                    this.labelOffset.Enabled = !this.labelOffset.Enabled;
                    this.labelOffsetValue.Visible = !this.labelOffsetValue.Visible;
                    this.labelOffsetValue.Enabled = !this.labelOffsetValue.Enabled;
                    break;
                case ('c'):
                    if (this.labelDataName.ForeColor == Color.White)
                    {
                        this.labelDataValue.ForeColor = Color.Black;
                        this.labelDataName.ForeColor = Color.Black;
                    }
                    else
                    {
                        this.labelDataValue.ForeColor = Color.White;
                        this.labelDataName.ForeColor = Color.White;
                    }
                    break;
                case ((char)27):
                    if (log != null)
                    {
                        log.Flush();
                        log.Close();
                    }
                    this.Dispose();
                    this.Close();
                    Application.Exit();
                    break;
            }
        }
    }

}
