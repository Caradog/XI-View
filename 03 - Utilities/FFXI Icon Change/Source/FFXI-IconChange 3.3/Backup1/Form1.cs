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
        private ColumnHeader chHelpText;
        private ColumnHeader chDescr2;
        private ColumnHeader chHelpText2;
        private MenuItem muSave;
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chDescription = new System.Windows.Forms.ColumnHeader();
            this.chHelpText = new System.Windows.Forms.ColumnHeader();
            this.chDescr2 = new System.Windows.Forms.ColumnHeader();
            this.chHelpText2 = new System.Windows.Forms.ColumnHeader();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.muFile,
            this.muView,
            this.muAction});
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
            this.chDescription,
            this.chHelpText,
            this.chDescr2,
            this.chHelpText2});
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
            // chHelpText
            // 
            this.chHelpText.Text = "Help Text";
            // 
            // chDescr2
            // 
            this.chDescr2.Text = "Other Description";
            // 
            // chHelpText2
            // 
            this.chHelpText2.Text = "Other Help Text";
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
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(438, 251);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(360, 250);
            this.Name = "Form1";
            this.Text = "FFXI IconChanger v1.10";
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
                if(j > myIcons.Length)
                    break;

                if (includelist[j] == true)
                {
                    if ((options & (int)ImportOptions.Images) > 0)
                    {
                        for (int i = 0x200; i < FFIcon.SIZE_ICON; ++i)
                        {
                            myIcons[j].Bytes[i] = temp[i];
                        }
                    }
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
                    listView1.SmallImageList.Images[index] = myIcons[index].Bitmap;
                    UpdateView();
				}
			}		
		}

        private void UpdateThumbnail()
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                pictureBox1.Image = myIcons[listView1.SelectedIndices[0]].Bitmap;
                textBox1.Text = myIcons[listView1.SelectedIndices[0]].Description;
            }
        }


        private void UpdateView()
        {
            if (mFileName == null)
                return;
            
            if (listView1.Items.Count == 0)
            {
                ImageList myImageList = new ImageList();
                for (int i = 0; i < myIcons.Length; ++i)
                {
                    ListViewItem lvi = new ListViewItem(myIcons[i].Description, i);
                    lvi.SubItems.Add(myIcons[i].HelpText);
                    lvi.SubItems.Add(myIcons[i].Description_2);
                    lvi.SubItems.Add(myIcons[i].HelpText_2);

                    myImageList.Images.Add(i.ToString(), myIcons[i].Bitmap);

                    listView1.Items.Add(lvi);
                }
                listView1.SmallImageList = myImageList;
                listView1.SelectedIndices.Add(0);
            }
            else
            {
                for (int i = 0; i < myIcons.Length; ++i)
                {
                    listView1.Items[i].Text = myIcons[i].Description;
                    listView1.SmallImageList.Images[i] = myIcons[i].Bitmap;
                    listView1.Items[i].SubItems[1].Text = myIcons[i].HelpText;
                    listView1.Items[i].SubItems[2].Text = myIcons[i].Description_2;
                    listView1.Items[i].SubItems[3].Text = myIcons[i].HelpText_2;
                }
            }

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
	}
}
