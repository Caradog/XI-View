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
    /// 
    public enum ImportOptions
    {
        Descriptions = 0x01,
        Images = 0x02
    }
	public class ImportIconDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button Browsebtn;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

		private String mFileName;
        private int mOptions;
        private bool[] mIncludeList;


        private GroupBox groupBox1;
        private CheckBox cbDescriptions;
        private CheckBox cbIcons;
        private GroupBox gbRange;
        private Label label2;
        private NumericUpDown nudRangeStop;
        private NumericUpDown nudRangeStart;
        private NumericUpDown nudSingle;
        private RadioButton rbRange;
        private RadioButton rbSingle;
        private RadioButton rbAll;


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

        public int Options
        {
            get { return mOptions; }
        }
        public bool[] IncludeList
        {
            get { return mIncludeList; }
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDescriptions = new System.Windows.Forms.CheckBox();
            this.cbIcons = new System.Windows.Forms.CheckBox();
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.nudSingle = new System.Windows.Forms.NumericUpDown();
            this.nudRangeStart = new System.Windows.Forms.NumericUpDown();
            this.nudRangeStop = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeStop)).BeginInit();
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
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(88, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Browsebtn
            // 
            this.Browsebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Browsebtn.Location = new System.Drawing.Point(372, 8);
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
            this.button1.Location = new System.Drawing.Point(137, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Import";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(233, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbDescriptions);
            this.groupBox1.Controls.Add(this.cbIcons);
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import Options";
            // 
            // cbDescriptions
            // 
            this.cbDescriptions.AutoSize = true;
            this.cbDescriptions.Location = new System.Drawing.Point(112, 24);
            this.cbDescriptions.Name = "cbDescriptions";
            this.cbDescriptions.Size = new System.Drawing.Size(149, 17);
            this.cbDescriptions.TabIndex = 1;
            this.cbDescriptions.Text = "Status Descriptions / Text";
            this.cbDescriptions.UseVisualStyleBackColor = true;
            // 
            // cbIcons
            // 
            this.cbIcons.AutoSize = true;
            this.cbIcons.Location = new System.Drawing.Point(16, 24);
            this.cbIcons.Name = "cbIcons";
            this.cbIcons.Size = new System.Drawing.Size(81, 17);
            this.cbIcons.TabIndex = 0;
            this.cbIcons.Text = "Image Data";
            this.cbIcons.UseVisualStyleBackColor = true;
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.label2);
            this.gbRange.Controls.Add(this.nudRangeStop);
            this.gbRange.Controls.Add(this.nudRangeStart);
            this.gbRange.Controls.Add(this.nudSingle);
            this.gbRange.Controls.Add(this.rbRange);
            this.gbRange.Controls.Add(this.rbSingle);
            this.gbRange.Controls.Add(this.rbAll);
            this.gbRange.Location = new System.Drawing.Point(8, 104);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(416, 104);
            this.gbRange.TabIndex = 8;
            this.gbRange.TabStop = false;
            this.gbRange.Text = "Import Range";
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(16, 24);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(65, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Icons";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Location = new System.Drawing.Point(16, 48);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(78, 17);
            this.rbSingle.TabIndex = 1;
            this.rbSingle.Text = "Single Icon";
            this.rbSingle.UseVisualStyleBackColor = true;
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Location = new System.Drawing.Point(16, 72);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(57, 17);
            this.rbRange.TabIndex = 2;
            this.rbRange.Text = "Range";
            this.rbRange.UseVisualStyleBackColor = true;
            // 
            // nudSingle
            // 
            this.nudSingle.Location = new System.Drawing.Point(104, 48);
            this.nudSingle.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.nudSingle.Name = "nudSingle";
            this.nudSingle.Size = new System.Drawing.Size(72, 20);
            this.nudSingle.TabIndex = 3;
            // 
            // nudRangeStart
            // 
            this.nudRangeStart.Location = new System.Drawing.Point(104, 72);
            this.nudRangeStart.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.nudRangeStart.Name = "nudRangeStart";
            this.nudRangeStart.Size = new System.Drawing.Size(72, 20);
            this.nudRangeStart.TabIndex = 4;
            // 
            // nudRangeStop
            // 
            this.nudRangeStop.Location = new System.Drawing.Point(224, 72);
            this.nudRangeStop.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.nudRangeStop.Name = "nudRangeStop";
            this.nudRangeStop.Size = new System.Drawing.Size(72, 20);
            this.nudRangeStop.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "TO:";
            // 
            // ImportIconDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(444, 259);
            this.Controls.Add(this.gbRange);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Browsebtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 180);
            this.Name = "ImportIconDialog";
            this.Text = "Import Data...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRange.ResumeLayout(false);
            this.gbRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRangeStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private void button1_Click(object sender, EventArgs e)
        {
            mFileName = textBox1.Text;
            int options = 0;

            System.IO.FileInfo fi = new System.IO.FileInfo(mFileName);
            mIncludeList = new bool[fi.Length / FFIcon.SIZE_ICON];


            if (cbDescriptions.Checked == true)
                options += (int)ImportOptions.Descriptions;
            if(cbIcons.Checked == true)
                options += (int)ImportOptions.Images;

            for (int i = 0; i < mIncludeList.Length; ++i)
            {
                if (rbAll.Checked == true)
                    mIncludeList[i] = true;
                else if (rbSingle.Checked == true)
                    if (nudSingle.Value == i)
                        mIncludeList[i] = true;
                    else
                        mIncludeList[i] = false;
                else if (rbRange.Checked == true)
                    if (nudRangeStart.Value <= i && i <= nudRangeStop.Value)
                        mIncludeList[i] = true;
                    else
                        mIncludeList[i] = false;
            }
            mOptions = options;
        }
	}
}
