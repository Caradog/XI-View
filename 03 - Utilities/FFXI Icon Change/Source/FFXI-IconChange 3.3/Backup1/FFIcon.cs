using System;

using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using PlayOnline.FFXI;

namespace FFXI_IconChange
{

	/// <summary>
	/// Summary description for FFIcon.
	/// </summary>
	public class FFIcon
	{
        //Entire Icon Object
        public static int SIZE_ICON = 0xC00;

        //The Text Portion (Description, Help Text, etc)
        public static int OFFSET_TEXT = 0x0;
        public static int SIZE_TEXT = 0x280;

        //The Image Portion (Image Header and raw data)
        public static int OFFSET_IMAGE = 0x280;
        public static int SIZE_IMAGE = 0x980;


        //Individual Fields below:
        private static int OFFSET_ID = 0x0;
        private static int SIZE_ID = 0x2;

        private static int OFFSET_DESCR = 0x2;
        private static int SIZE_DESCR = 0x20;

        private static int OFFSET_DESCR_2 = 0x22;
        private static int SIZE_DESCR_2 = 0x20;

        private static int OFFSET_HELPTEXT = 0x42;
        private static int SIZE_HELPTEXT = 0x80;

        private static int OFFSET_HELPTEXT_2 = 0xC2;
        private static int SIZE_HELPTEXT_2 = 0x80;

        private static int OFFSET_UNKNOWN = 0x142;
        private static int SIZE_UNKNOWN = 0x143;
        
		private static int OFFSET_IMAGE_NAME = 0x285;
		private static int SIZE_IMAGE_NAME = 0x10;

        private static int OFFSET_UNKNOWN_2 = 0x295;
        private static int SIZE_UNKNOWN_2 = 0x28;

		private static int OFFSET_IMAGE_DATA = 0x2BD;
		private static int SIZE_IMAGE_DATA = 0x400;
        //Hopefully the total of the field sizes = SIZE_ICON (0xC00)
        

		byte[] mBytes;	// Store all the bytes here

        public FFIcon()
        {
            mBytes = new byte[SIZE_ICON];

        }

		public FFIcon(byte[] input)
		{
			mBytes = new byte[SIZE_ICON];
			input.CopyTo(mBytes,0);

		}

        /// <summary>
        /// This method was mostly copied from the Internet.  It works, but I do not fully understand
        /// the inner working of the Data Marshal.  Perhaps there is a better way to Implement this method.
        /// 
        /// Also, this assumes that the Image is stored as a 32-bit RGBA image.  Some of the Icons use 8-bit BMP, so those images are returned as garbage.
        /// </summary>
		public Bitmap Bitmap
		{
			get
			{
				Bitmap mIcon;

                mIcon = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

				BitmapData data = mIcon.LockBits(new System.Drawing.Rectangle(0, 0, mIcon.Width, mIcon.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, mIcon.PixelFormat);

				IntPtr ptr = data.Scan0;

                System.Runtime.InteropServices.Marshal.Copy(mBytes, OFFSET_IMAGE_DATA, ptr, SIZE_IMAGE_DATA);
				
				mIcon.UnlockBits(data);

				mIcon.RotateFlip(RotateFlipType.RotateNoneFlipY); //For some reason, the Image comes out upside-down, so flip it here
				return mIcon;
			}
		}


		public String Description
		{
			get
			{
                byte[] temp = (byte[])mBytes.Clone();
                FFXIEncryption.DecodeDataBlock(temp);

                FFXIEncoding e = new FFXIEncoding();

                return e.GetString(temp, OFFSET_DESCR, SIZE_DESCR).Trim("\0".ToCharArray());
			}
		}

        public String Description_2
        {
            get
            {
                byte[] temp = (byte[])mBytes.Clone();
                FFXIEncryption.DecodeDataBlock(temp);

                FFXIEncoding e = new FFXIEncoding();

                return e.GetString(temp, OFFSET_DESCR_2, SIZE_DESCR_2).Trim("\0".ToCharArray());
            }
        }

        public String HelpText
        {
            get
            {
                byte[] temp = (byte[])mBytes.Clone();
                FFXIEncryption.DecodeDataBlock(temp);

                FFXIEncoding e = new FFXIEncoding();

                return e.GetString(temp, OFFSET_HELPTEXT, SIZE_HELPTEXT).Trim("\0".ToCharArray());
            }
        }

        public String HelpText_2
        {
            get
            {
                byte[] temp = (byte[])mBytes.Clone();
                FFXIEncryption.DecodeDataBlock(temp);

                FFXIEncoding e = new FFXIEncoding();

                return e.GetString(temp, OFFSET_HELPTEXT_2, SIZE_HELPTEXT_2).Trim("\0".ToCharArray());
            }
        }

    	public String Name
		{
			get
			{
                FFXIEncoding e = new FFXIEncoding();
                return e.GetString(mBytes, OFFSET_IMAGE_NAME, SIZE_IMAGE_NAME);
			}
		}

		public String ID
		{
			get
			{
                FFXIEncoding e = new FFXIEncoding();
                return e.GetString(mBytes, OFFSET_ID, SIZE_ID);
			}
		}

		public void InjectBMP(Bitmap bmp)
		{
			bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
			BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

			IntPtr ptr = data.Scan0;

			System.Runtime.InteropServices.Marshal.Copy(ptr, mBytes, OFFSET_IMAGE_DATA, bmp.Width * bmp.Height * 4);

			bmp.UnlockBits(data);

            //A bit of a hack, we are saying that this is a 32 bit BMP image
            mBytes[OFFSET_IMAGE + 1] = 0x04;
            mBytes[OFFSET_IMAGE_DATA - 0x1A] = 0x20;
		}

		public byte[] Bytes
		{
			get{return mBytes;}
		}

	}
}
