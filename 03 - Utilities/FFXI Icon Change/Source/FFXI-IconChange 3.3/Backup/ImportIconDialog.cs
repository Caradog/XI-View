using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FFXI_IconChange
{
	/// <summary>
	/// Summary description for ImportIconDialog.
	/// </summary>
	public class ImportIconDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button Browsebtn;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

		private String mFileName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ImportIconDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public String FileName
		{
			get { return mFileName; }
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Browsebtn = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Import From:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(88, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(336, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// Browsebtn
			// 
			this.Browsebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Browsebtn.Location = new System.Drawing.Point(432, 8);
			this.Browsebtn.Name = "Browsebtn";
			this.Browsebtn.Size = new System.Drawing.Size(64, 24);
			this.Browsebtn.TabIndex = 3;
			this.Browsebtn.Text = "Browse...";
			this.Browsebtn.Click += new System.EventHandler(this.Browsebtn_Click);
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(128, 72);
			this.button1.Name = "button1";
			this.button1.TabIndex = 5;
			this.button1.Text = "Import";
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(304, 72);
			this.button2.Name = "button2";
			this.button2.TabIndex = 6;
			this.button2.Text = "Cancel";
			// 
			// ImportIconDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 112);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Browsebtn);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImportIconDialog";
			this.Text = "Import Data...";
			this.ResumeLayout(false);

		}
		#endregion

		private void Browsebtn_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();

			theDialog.Filter = "DAT Files (*.DAT)|*.DAT" ;

			if(theDialog.ShowDialog() == DialogResult.OK)
			{
				if(System.IO.File.Exists(theDialog.FileName))
				{
					textBox1.Text = theDialog.FileName;
					mFileName = theDialog.FileName;
				}
			}
		}
	}
}
