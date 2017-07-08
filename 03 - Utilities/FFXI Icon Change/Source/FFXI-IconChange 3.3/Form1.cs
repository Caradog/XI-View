using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
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
        private IContainer components;

		private String mFileName;
		private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuItem muFile;
		private System.Windows.Forms.MenuItem muOpen;
		private System.Windows.Forms.MenuItem muSaveAs;
		private System.Windows.Forms.MenuItem muAction;
		private System.Windows.Forms.MenuItem muImport;
        private System.Windows.Forms.ListView listView1;
        private ColumnHeader chDescription;
        private TextBox textBox1;
        private MenuItem muView;
        private MenuItem muIcons;
        private MenuItem muList;
        private MenuItem muDetails;
        private MenuItem muSave;
        private Button button2;
        private MenuItem muExport;
        private MenuItem muCompare;
        private MenuItem muCompareDescriptions;
        private MenuItem muCompareIcons;
        private MenuItem muOptions;
        private MenuItem muSmallIcons;
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
        protected override void Dispose(bool disposing)
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.muFile = new System.Windows.Forms.MenuItem();
            this.muOpen = new System.Windows.Forms.MenuItem();
            this.muSave = new System.Windows.Forms.MenuItem();
            this.muSaveAs = new System.Windows.Forms.MenuItem();
            this.muView = new System.Windows.Forms.MenuItem();
            this.muList = new System.Windows.Forms.MenuItem();
            this.muIcons = new System.Windows.Forms.MenuItem();
            this.muDetails = new System.Windows.Forms.MenuItem();
            this.muAction = new System.Windows.Forms.MenuItem();
            this.muImport = new System.Windows.Forms.MenuItem();
            this.muExport = new System.Windows.Forms.MenuItem();
            this.muCompare = new System.Windows.Forms.MenuItem();
            this.muCompareDescriptions = new System.Windows.Forms.MenuItem();
            this.muCompareIcons = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.muOptions = new System.Windows.Forms.MenuItem();
            this.muSmallIcons = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muFile,
            this.muView,
            this.muAction,
            this.muOptions});
            // 
            // muFile
            // 
            this.muFile.Index = 0;
            this.muFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muOpen,
            this.muSave,
            this.muSaveAs});
            this.muFile.Text = "File";
            // 
            // muOpen
            // 
            this.muOpen.Index = 0;
            this.muOpen.Text = "Open";
            this.muOpen.Click += new System.EventHandler(this.muLoad_Click);
            // 
            // muSave
            // 
            this.muSave.Index = 1;
            this.muSave.Text = "Save";
            this.muSave.Click += new System.EventHandler(this.muSave_Click_1);
            // 
            // muSaveAs
            // 
            this.muSaveAs.Index = 2;
            this.muSaveAs.Text = "Save As...";
            this.muSaveAs.Click += new System.EventHandler(this.muSave_Click);
            // 
            // muView
            // 
            this.muView.Index = 1;
            this.muView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muList,
            this.muIcons,
            this.muDetails});
            this.muView.Text = "View";
            // 
            // muList
            // 
            this.muList.Checked = true;
            this.muList.Index = 0;
            this.muList.RadioCheck = true;
            this.muList.Text = "List";
            this.muList.Click += new System.EventHandler(this.muList_Click);
            // 
            // muIcons
            // 
            this.muIcons.Index = 1;
            this.muIcons.RadioCheck = true;
            this.muIcons.Text = "Icons";
            this.muIcons.Click += new System.EventHandler(this.muIcons_Click);
            // 
            // muDetails
            // 
            this.muDetails.Index = 2;
            this.muDetails.RadioCheck = true;
            this.muDetails.Text = "Details";
            this.muDetails.Click += new System.EventHandler(this.muDetails_Click);
            // 
            // muAction
            // 
            this.muAction.Index = 2;
            this.muAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muImport,
            this.muExport,
            this.muCompare});
            this.muAction.Text = "Action";
            // 
            // muImport
            // 
            this.muImport.Index = 0;
            this.muImport.Text = "Import...";
            this.muImport.Click += new System.EventHandler(this.muImport_Click);
            // 
            // muExport
            // 
            this.muExport.Index = 1;
            this.muExport.Text = "Export Icons";
            this.muExport.Click += new System.EventHandler(this.muExport_Click);
            // 
            // muCompare
            // 
            this.muCompare.Index = 2;
            this.muCompare.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muCompareDescriptions,
            this.muCompareIcons});
            this.muCompare.Text = "Compare";
            // 
            // muCompareDescriptions
            // 
            this.muCompareDescriptions.Index = 0;
            this.muCompareDescriptions.Text = "Descriptions";
            this.muCompareDescriptions.Click += new System.EventHandler(this.muCompareDescriptions_Click);
            // 
            // muCompareIcons
            // 
            this.muCompareIcons.Index = 1;
            this.muCompareIcons.Text = "Icons";
            this.muCompareIcons.Click += new System.EventHandler(this.muCompareIcons_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 64);
            this.button1.TabIndex = 3;
            this.button1.Text = "Replace Icon";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDescription});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 80);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(423, 163);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chDescription
            // 
            this.chDescription.Text = "Status";
            this.chDescription.Width = 80;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(80, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(184, 27);
            this.textBox1.TabIndex = 5;
            this.textBox1.TabStop = false;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(354, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 64);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save Icon";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // muOptions
            // 
            this.muOptions.Index = 3;
            this.muOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muSmallIcons});
            this.muOptions.Text = "Options";
            // 
            // muSmallIcons
            // 
            this.muSmallIcons.Index = 0;
            this.muSmallIcons.Text = "Small Icons";
            this.muSmallIcons.Click += new System.EventHandler(this.muSmallIcons_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(438, 251);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(360, 250);
            this.Name = "Form1";
            this.Text = "FFXI IconChanger v3.3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
	
		private void ImportData(String filename, int options, bool[] includelist)
		{
			FileStream srcStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

			byte[] temp = new byte[FFIcon.SIZE_ICON];

			int j = 0;

			while(srcStream.Read(temp, 0, FFIcon.SIZE_ICON) == FFIcon.SIZE_ICON)
			{
                // Stop if exceeding array length
                //if(j > myIcons.Length)
                //    break;

                if (includelist[j] == true)
                {
                    // Expand array if necessary
                    if (j >= myIcons.Length)
                    {
                        List<FFIcon> myList = new List<FFIcon>(myIcons);
                        myList.Add(new FFIcon());
                        myIcons = myList.ToArray();
                    }

                    // Import image 
                    if ((options & (int)ImportOptions.Images) > 0)
                    {
                        for (int i = 0x200; i < FFIcon.SIZE_ICON; ++i)
                        {
                            myIcons[j].Bytes[i] = temp[i];
                        }
                    }

                    // Import description
                    if ((options & (int)ImportOptions.Descriptions) > 0)
                    {
                        for (int i = 0x0; i < FFIcon.SIZE_TEXT; ++i)
                        {
                            myIcons[j].Bytes[i] = temp[i];
                        }
                    }
                }
                ++j;
			}

			srcStream.Close();

            UpdateView();
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

            int i = 0;
			while(srcStream.Read(temp, 0, FFIcon.SIZE_ICON) == FFIcon.SIZE_ICON)
			{
				tempIcon = new FFIcon(temp);
				myIcons[i] = tempIcon;
                ++i;
			}

			srcStream.Close();
            UpdateView();
		}

		private void muImport_Click(object sender, System.EventArgs e)
		{
            if (mFileName == null)
            {
                MessageBox.Show("Please Open a File First (usually ROM\\119\\57.DAT)");
                return;
            }

			ImportIconDialog theDialog = new ImportIconDialog();

            if (theDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (File.Exists(theDialog.FileName))
                {               
                    ImportData(theDialog.FileName, theDialog.Options, theDialog.IncludeList);
                }
            }

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

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateThumbnail();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Filter = "32-bit Bitmap Image(*.BMP)|*.BMP";
            int index = 0;

            if (listView1.SelectedIndices.Count > 0)
                index = listView1.SelectedIndices[0];

			if(theDialog.ShowDialog() == DialogResult.OK)
			{
				if(File.Exists(theDialog.FileName))
				{
					Bitmap bmp = new Bitmap(theDialog.FileName);
					myIcons[index].InjectBMP(bmp);
                    if (muSmallIcons.Checked)
                        listView1.SmallImageList.Images[index] = myIcons[index].SmallBitmap;
                    else
                        listView1.SmallImageList.Images[index] = myIcons[index].Bitmap;
                    UpdateView();
				}
			}		
		}

        private void button2_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog theDialog = new SaveFileDialog();
            theDialog.Filter = "32-bit Bitmap Image(*.bmp)|*.bmp";
            int index = -1;

            if (listView1.SelectedIndices.Count > 0)
                index = listView1.SelectedIndices[0];
            else
            {
                MessageBox.Show("No icon selected", "Error");
                return;
            }

            if (theDialog.ShowDialog() == DialogResult.OK && index > -1)
            {
                Bitmap bmp;
                if (muSmallIcons.Checked)
                    bmp = myIcons[index].SmallBitmap;
                else
                    bmp = myIcons[index].Bitmap;

                bmp.Save(theDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }

        private void UpdateThumbnail()
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                if (muSmallIcons.Checked)
                    pictureBox1.Image = myIcons[listView1.SelectedIndices[0]].SmallBitmap;
                else
                    pictureBox1.Image = myIcons[listView1.SelectedIndices[0]].Bitmap;
                textBox1.Text = myIcons[listView1.SelectedIndices[0]].Description;
            }
        }

        private void UpdateView()
        {
            if (mFileName == null)
                return;

            listView1.Items.Clear();
            listView1.SmallImageList = null;
            listView1.SelectedIndices.Clear();
            ImageList myImageList = new ImageList();
            for (int i = 0; i < myIcons.Length; ++i)
            {
                ListViewItem lvi = new ListViewItem(i.ToString() + ": " + myIcons[i].Description, i);

                if (muSmallIcons.Checked)
                    myImageList.Images.Add(i.ToString(), myIcons[i].SmallBitmap);
                else
                    myImageList.Images.Add(i.ToString(), myIcons[i].Bitmap);

                listView1.Items.Add(lvi);
            }
            listView1.SmallImageList = myImageList;
            listView1.SelectedIndices.Add(0);

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            
            listView1.Refresh();
            UpdateThumbnail();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThumbnail();
        }

        private void muList_Click(object sender, EventArgs e)
        {
            muList.Checked = true;
            muIcons.Checked = false;
            muDetails.Checked = false;

            listView1.View = View.List;
            UpdateView();
        }

        private void muIcons_Click(object sender, EventArgs e)
        {
            muList.Checked = false;
            muIcons.Checked = true;
            muDetails.Checked = false;

            listView1.View = View.SmallIcon;
            UpdateView();
        }

        private void muDetails_Click(object sender, EventArgs e)
        {
            muList.Checked = false;
            muIcons.Checked = false;
            muDetails.Checked = true;

            listView1.View = View.Details;
            UpdateView();
        }

        private void muSave_Click_1(object sender, EventArgs e)
        {
            int backup = 0;
            while(File.Exists(mFileName + ".BAK" + backup.ToString()))
                ++backup;
            try
            {
                File.Copy(mFileName, mFileName + ".BAK" + backup.ToString());
                SaveBytes(mFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to create backup file.  Nothing will be saved\nReason: " + ex.Message);
            }

        }

        private void muExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog theDialog = new FolderBrowserDialog();

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < myIcons.Length; ++i)
                {
                    Bitmap bmp;
                    if (muSmallIcons.Checked)
                        bmp = myIcons[i].SmallBitmap;
                    else
                        bmp = myIcons[i].Bitmap;
                    bmp.Save(theDialog.SelectedPath + "\\" + i.ToString() + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
        }

        private void muCompareDescriptions_Click(object sender, EventArgs e)
        {
            if (myIcons == null)
            {
                MessageBox.Show("You must open an icon dat file before comparing to another file.", "Error");
                return;
            }

            OpenFileDialog theDialog = new OpenFileDialog();
            string filename = "";

            theDialog.Filter = "DAT Files (*.DAT)|*.DAT";
            theDialog.Multiselect = false;
            theDialog.Title = "Select an Icon DAT to Load";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(theDialog.FileName))
                    filename = theDialog.FileName;
            }
            else
                return;

            FileStream srcStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte[] temp = new byte[FFIcon.SIZE_ICON];
            FFIcon tempIcon;
            ArrayList DifferencesList = new ArrayList();
            string differences = "Differences:\n";

            int i = 0;
            while (srcStream.Read(temp, 0, FFIcon.SIZE_ICON) == FFIcon.SIZE_ICON)
            {
                tempIcon = new FFIcon(temp);

                if (i >= myIcons.Length || myIcons[i].Description != tempIcon.Description)
                {
                    DifferencesList.Add(i);
                    differences += i.ToString() + ", ";
                    if (DifferencesList.Count % 10 == 0)
                        differences += "\n";
                }

                ++i;
            }

            srcStream.Close();

            if (DifferencesList.Count > 0)
            {
                // remove trailing commas and new lines
                if (DifferencesList.Count % 10 == 0)
                    differences = differences.Substring(0, differences.Length - 3);
                else
                    differences = differences.Substring(0, differences.Length - 2);

                if (DifferencesList.Count == 1)
                    differences = differences.Replace("s", "");

                // show the differences
                MessageBox.Show(DifferencesList.Count.ToString() + " " + differences);
            }
            else
            {
                MessageBox.Show("All descriptions match.");
            }
        }

        private void muCompareIcons_Click(object sender, EventArgs e)
        {
            if (myIcons == null)
            {
                MessageBox.Show("You must open an icon dat file before comparing to another file.", "Error");
                return;
            }

            OpenFileDialog theDialog = new OpenFileDialog();
            string filename = "";

            theDialog.Filter = "DAT Files (*.DAT)|*.DAT";
            theDialog.Multiselect = false;
            theDialog.Title = "Select an Icon DAT to Load";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(theDialog.FileName))
                    filename = theDialog.FileName;
            }
            else
                return;

            FileStream srcStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

            byte[] temp = new byte[FFIcon.SIZE_ICON];
            FFIcon tempIcon;
            ArrayList DifferencesList = new ArrayList();
            string differences = "Differences:\n";

            int i = 0;
            while (srcStream.Read(temp, 0, FFIcon.SIZE_ICON) == FFIcon.SIZE_ICON)
            {
                tempIcon = new FFIcon(temp);

                if (i >= myIcons.Length || 
                    (!muSmallIcons.Checked && !myIcons[i].BitmapEquals(tempIcon.Bitmap)) || 
                    (muSmallIcons.Checked && !myIcons[i].SmallBitmapEquals(tempIcon.SmallBitmap)))
                {
                    DifferencesList.Add(i);
                    differences += i.ToString() + ", ";
                    if (DifferencesList.Count % 10 == 0)
                        differences += "\n";
                }

                ++i;
            }

            srcStream.Close();

            if (DifferencesList.Count > 0)
            {
                // remove trailing commas and new lines
                if (DifferencesList.Count % 10 == 0)
                    differences = differences.Substring(0, differences.Length - 3);
                else
                    differences = differences.Substring(0, differences.Length - 2);

                if (DifferencesList.Count == 1)
                    differences = differences.Replace("s", "");

                // show the differences
                MessageBox.Show(DifferencesList.Count.ToString() + " " + differences);
            }
            else
            {
                MessageBox.Show("All icons match.");
            }
        }

        private void muSmallIcons_Click(object sender, EventArgs e)
        {
            if (muSmallIcons.Checked == false)
            {
                muSmallIcons.Checked = true;
                //FFIcon.SIZE_IMAGE_DATA = 0x400;
            }
            else
            {
                muSmallIcons.Checked = false;
                //FFIcon.SIZE_IMAGE_DATA = 0x1000;
            }

            // clear the loaded icons so nothing gets messed up
            myIcons = new FFIcon[0];
            listView1.Items.Clear();
            listView1.SmallImageList = null;
            listView1.SelectedIndices.Clear();
            listView1.Refresh();
            pictureBox1.Image = null;
            textBox1.Text = "";
        }
	}
}
