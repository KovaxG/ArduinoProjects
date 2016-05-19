using System.Drawing;

namespace aqtr
{
	partial class ViewerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
            this.labelConnectionData = new System.Windows.Forms.Label();
            this.textBoxHistory = new System.Windows.Forms.TextBox();
            this.labelDataName = new System.Windows.Forms.Label();
            this.labelDataValue = new System.Windows.Forms.Label();
            this.labelOffset = new System.Windows.Forms.Label();
            this.textBoxOffsetValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelConnectionData
            // 
            this.labelConnectionData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConnectionData.AutoSize = true;
            this.labelConnectionData.Enabled = false;
            this.labelConnectionData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionData.Location = new System.Drawing.Point(-1, 151);
            this.labelConnectionData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectionData.Name = "labelConnectionData";
            this.labelConnectionData.Size = new System.Drawing.Size(134, 20);
            this.labelConnectionData.TabIndex = 4;
            this.labelConnectionData.Text = "Connection Data";
            this.labelConnectionData.Visible = false;
            // 
            // textBoxHistory
            // 
            this.textBoxHistory.Enabled = false;
            this.textBoxHistory.Location = new System.Drawing.Point(3, 205);
            this.textBoxHistory.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHistory.Multiline = true;
            this.textBoxHistory.Name = "textBoxHistory";
            this.textBoxHistory.ReadOnly = true;
            this.textBoxHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHistory.Size = new System.Drawing.Size(416, 235);
            this.textBoxHistory.TabIndex = 5;
            this.textBoxHistory.Visible = false;
            this.textBoxHistory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHistory_KeyPress);
            // 
            // labelDataName
            // 
            this.labelDataName.AutoSize = true;
            this.labelDataName.BackColor = System.Drawing.Color.Transparent;
            this.labelDataName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataName.Location = new System.Drawing.Point(308, 69);
            this.labelDataName.Name = "labelDataName";
            this.labelDataName.Size = new System.Drawing.Size(245, 32);
            this.labelDataName.TabIndex = 6;
            this.labelDataName.Text = "No data recieved";
            // 
            // labelDataValue
            // 
            this.labelDataValue.AutoSize = true;
            this.labelDataValue.BackColor = System.Drawing.Color.Transparent;
            this.labelDataValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataValue.Location = new System.Drawing.Point(388, 132);
            this.labelDataValue.Name = "labelDataValue";
            this.labelDataValue.Size = new System.Drawing.Size(31, 44);
            this.labelDataValue.TabIndex = 7;
            this.labelDataValue.Text = " ";
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Enabled = false;
            this.labelOffset.Location = new System.Drawing.Point(232, 151);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(97, 17);
            this.labelOffset.TabIndex = 8;
            this.labelOffset.Text = "Current Offset";
            this.labelOffset.Visible = false;
            // 
            // textBoxOffsetValue
            // 
            this.textBoxOffsetValue.Enabled = false;
            this.textBoxOffsetValue.Location = new System.Drawing.Point(347, 148);
            this.textBoxOffsetValue.Name = "textBoxOffsetValue";
            this.textBoxOffsetValue.Size = new System.Drawing.Size(72, 22);
            this.textBoxOffsetValue.TabIndex = 9;
            this.textBoxOffsetValue.Visible = false;
            this.textBoxOffsetValue.TextChanged += new System.EventHandler(this.textBoxOffsetValue_TextChanged);
            this.textBoxOffsetValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOffsetValue_KeyPress);
            // 
            // ViewerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::aqtr.Properties.Resources.f;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.textBoxOffsetValue);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.labelDataValue);
            this.Controls.Add(this.labelDataName);
            this.Controls.Add(this.textBoxHistory);
            this.Controls.Add(this.labelConnectionData);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewerForm";
            this.Text = "Traffic Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingHandler);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ViewerForm_DragDrop);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ViewerForm_KeyPress);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ViewerForm_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelConnectionData;
		private System.Windows.Forms.TextBox textBoxHistory;
        private System.Windows.Forms.Label labelDataName;
        private System.Windows.Forms.Label labelDataValue;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.TextBox textBoxOffsetValue;
    }
}