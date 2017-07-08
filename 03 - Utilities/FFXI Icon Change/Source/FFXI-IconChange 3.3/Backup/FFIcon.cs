using System;

using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FFXI_IconChange
{

	/// <summary>
	/// Summary description for FFIcon.
	/// </summary>
	public class FFIcon
	{        
		public static int SIZE_ICON = 0xC00;

		public static int OFFSET_IMAGE = 0x200;
		public static int SIZE_IMAGE = 0xa00;


		private static int OFFSET_NAME = 0x205;
		private static int SIZE_NAME = 16;

		private static int SIZE_DESCR = 0x16;
		private static int OFFSET_DESCR = 0x2;

		private static int OFFSET_BMPDATA = 0x23D;
		private static int SIZE_BMPDATA = 0x400;

		private static int OFFSET_NUM = 0x0;
		private static int SIZE_NUM = 0x2;


		byte[] mBytes;	// Store all the bytes here


		public FFIcon(byte[] input)
		{
			mBytes = new byte[SIZE_ICON];
			input.CopyTo(mBytes,0);

		}

		public Bitmap Bitmap
		{
			get
			{



				Bitmap mIcon;
				int datasize;

				datasize = SIZE_BMPDATA;
				mIcon = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

				BitmapData data = mIcon.LockBits(new System.Drawing.Rectangle(0, 0, mIcon.Width, mIcon.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, mIcon.PixelFormat);

				IntPtr ptr = data.Scan0;

				System.Runtime.InteropServices.Marshal.Copy(mBytes, OFFSET_BMPDATA, ptr, datasize);
				
				mIcon.UnlockBits(data);
				mIcon.RotateFlip(RotateFlipType.RotateNoneFlipY);
				return mIcon;
			}
		}


		public String Description
		{
			get
			{
				byte[] temp = decode(OFFSET_DESCR, SIZE_DESCR);

				return Encoding.GetEncoding("shift-jis").GetString(temp, 0, SIZE_DESCR).Trim();
			}
		}

		private byte[] decode(int from, int length)
		{
			byte[] temp = new byte[length];
			int rotate = getRotation(mBytes);
			for(int i=0; i<length; ++i)
				temp[i] = rotateBitsRight(mBytes[i + from], rotate);

			return temp;
		}

		private byte[] encode(int from, int length)
		{
			byte[] temp = new byte[length];
			int rotate = getRotation(mBytes);
			for(int i=0; i<length; ++i)
				temp[i] = rotateBitsLeft(mBytes[i + from], rotate);

			return temp;
		}

		private byte rotateBitsRight(byte data, int rotate)
		{
			byte[] temp = new byte[1];
			temp[0] = data;
			System.Collections.BitArray ba = new System.Collections.BitArray(temp);
			byte b = 0;

			for(int i = 0; i < ba.Length; ++i)
			{
				if(ba.Get(i) == true)
					b += (byte)(0x80 >> ((rotate - i + 7) % 8));
			
			}

            return b;
		}

		private byte rotateBitsLeft(byte data, int rotate)
		{
			byte[] temp = new byte[1];
			temp[0] = data;
			System.Collections.BitArray ba = new System.Collections.BitArray(temp);
			byte b = 0;

			for(int i = 0; i < ba.Length; ++i)
			{
				if(ba.Get(i) == true)
					b += (byte)(0x1 << (rotate + i) % 8);			
			}

			return b;
		}
		private int getRotation(byte[] temp)
		{
			int seed = countbits(temp[2]) - countbits(temp[11]) + countbits(temp[12]);
			if(seed < 0)
				seed = -seed;

			switch (seed % 5) 
			{
				case 0: return 7;
				case 1: return 1;
				case 2: return 6;
				case 3: return 2;
				case 4: return 5;
			}
			return 1;
		}

		private int countbits(byte data)
		{
			int result=0;
			byte[] temp = new byte[1];
			temp[0] = data;
			System.Collections.BitArray ba = new System.Collections.BitArray(temp);
			for(int i = 0; i < ba.Length; ++i)
                if(ba.Get(i) == true)
					result++;
			
			return result;

		}
		public String Name
		{
			get
			{
				return Encoding.ASCII.GetString(mBytes, OFFSET_NAME, SIZE_NAME);
			}
		}

		public String Number
		{
			get
			{
				return Encoding.BigEndianUnicode.GetString(mBytes, OFFSET_NUM, SIZE_NUM);
			}
		}

		public void InjectBMP(Bitmap bmp)
		{
			bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
			BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

			IntPtr ptr = data.Scan0;

			System.Runtime.InteropServices.Marshal.Copy(ptr, mBytes, OFFSET_BMPDATA, SIZE_BMPDATA);

			bmp.UnlockBits(data);

			mBytes[0x201] = 0x04;
		}

		public byte[] Bytes
		{
			get{return mBytes;}
		}

	}
}
