using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;


namespace FFXI_IconChange
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private String mFileName;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuItem muFile;
		private System.Windows.Forms.MenuItem muLoad;
		private System.Windows.Forms.MenuItem muSave;
		private System.Windows.Forms.MenuItem muAction;
		private System.Windows.Forms.MenuItem muImport;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private FFIcon[] myIcons;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.muFile = new System.Windows.Forms.MenuItem();
			this.muLoad = new System.Windows.Forms.MenuItem();
			this.muSave = new System.Windows.Forms.MenuItem();
			this.muAction = new System.Windows.Forms.MenuItem();
			this.muImport = new System.Windows.Forms.MenuItem();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.muFile,
																					  this.muAction});
			// 
			// muFile
			// 
			this.muFile.Index = 0;
			this.muFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.muLoad,
																				   this.muSave});
			this.muFile.Text = "File";
			// 
			// muLoad
			// 
			this.muLoad.Index = 0;
			this.muLoad.Text = "Load";
			this.muLoad.Click += new System.EventHandler(this.muLoad_Click);
			// 
			// muSave
			// 
			this.muSave.Index = 1;
			this.muSave.Text = "Save As...";
			this.muSave.Click += new System.EventHandler(this.muSave_Click);
			// 
			// muAction
			// 
			this.muAction.Index = 1;
			this.muAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.muImport});
			this.muAction.Text = "Action";
			// 
			// muImport
			// 
			this.muImport.Index = 0;
			this.muImport.Text = "Import...";
			this.muImport.Click += new System.EventHandler(this.muImport_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(232, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(8, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(208, 21);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(344, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 40);
			this.button1.TabIndex = 3;
			this.button1.Text = "Replace Icon";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3});
			this.listView1.Location = new System.Drawing.Point(40, 96);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(360, 104);
			this.listView1.TabIndex = 4;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Description";
			this.columnHeader2.Width = 119;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Image";
			this.columnHeader3.Width = 87;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 219);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.pictureBox1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "FFXI - IconChange";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	
		private void ImportData(String filename)
		{
			FileStream srcStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

			byte[] temp = new byte[FFIcon.SIZE_ICON];

			int j = 0;

			while(srcStream.Read(temp, 0, FFIcon.SIZE_ICON) == FFIcon.SIZE_ICON)
			{
				for(int i=0x200; i < FFIcon.SIZE_ICON; ++i)
				{
					myIcons[j].Bytes[i]	= temp[i];				
				}
				++j;

			}
			srcStream.Close();
		}

		private void SaveBytes(String filename)
		{
			FileStream destStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);

			for(int i = 0; i < myIcons.Length; ++i)
			{
				destStream.Write(myIcons[i].Bytes, 0, FFIcon.SIZE_ICON);
			}
			
			destStream.Close();

		}

		private void muLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();

			theDialog.Filter = "DAT Files (*.DAT)|*.DAT" ;
			theDialog.Multiselect = false;
			theDialog.Title = "Select an Icon DAT to Load";
			
			if(theDialog.ShowDialog() == DialogResult.OK)
			{
				if(File.Exists(theDialog.FileName))
					mFileName = theDialog.FileName;
			}
			else
				return;

			FileStream srcStream = new FileStream(mFileName, FileMode.Open, FileAccess.Read);				
			
			myIcons = new FFIcon[srcStream.Length / FFIcon.SIZE_ICON];
			byte[] temp = new byte[FFIcon.SIZE_ICON];
			FFIcon tempIcon;

			int i=0;
			comboBox1.Items.Clear();
			while(srcStream.Read(temp, 0, FFIcon.SIZE_ICON) == FFIcon.SIZE_ICON)
			{
				tempIcon = new FFIcon(temp);
				myIcons[i] = tempIcon;
				comboBox1.Items.Add(i.ToString() + " - " + myIcons[i].Description);
				++i;
			}
			srcStream.Close();

			comboBox1.SelectedIndex = 0;
		}

		private void muImport_Click(object sender, System.EventArgs e)
		{
			ImportIconDialog theDialog = new ImportIconDialog();

			if(theDialog.ShowDialog(this) == DialogResult.OK)
				
				if(File.Exists(theDialog.FileName))
					ImportData(theDialog.FileName);

			UpdateThumbnail();
		}

		private void muSave_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog theDialog = new SaveFileDialog();
			theDialog.Filter = "DAT Files (*.DAT)|*.DAT" ;

			String filename;
			if(theDialog.ShowDialog(this) == DialogResult.OK)
			{				
				filename = theDialog.FileName;
				SaveBytes(filename);
			}		
		}


		public bool ThumbnailCallback()
		{
			return false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateThumbnail();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Filter = "Bitmap Image (*.BMP)|*.BMP";

			if(theDialog.ShowDialog() == DialogResult.OK)
			{
				if(File.Exists(theDialog.FileName))
				{
					Bitmap bmp = new Bitmap(theDialog.FileName);
					myIcons[comboBox1.SelectedIndex].InjectBMP(bmp);
					UpdateThumbnail();
				}
			}		
		}

		private void UpdateThumbnail()
		{
            Image.GetThumbnailImageAbort myCallback =
				new Image.GetThumbnailImageAbort(ThumbnailCallback);

			pictureBox1.Image = myIcons[comboBox1.SelectedIndex].Bitmap.GetThumbnailImage(pictureBox1.Width, pictureBox1.Height, myCallback, IntPtr.Zero);
		}
	}
}
