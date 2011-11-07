﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VVVV.Nodes.EmguCV
{
	public enum TColourData { UnInitialised, RGB8, RGB32F, RGBA8, L8, L16};

	public class CVImageAttributes
	{
		public TColourData ColourFormat;
		public Size Dimensions = new Size();

		public CVImageAttributes()
		{
			ColourFormat = TColourData.UnInitialised;
			Dimensions = new Size(0, 0);
		}

		public CVImageAttributes(TColourData c, int w, int h)
		{
			ColourFormat = c;
			Dimensions.Width = w;
			Dimensions.Height = h;
		}

		public bool CheckChanges(TColourData c, Size s)
		{
			bool changed = false;
			if (c != ColourFormat)
			{
				ColourFormat = c;
				changed = true;
			}

			if (s != Dimensions)
			{
				Dimensions = s;
				changed = true;
			}
			return changed;
		}

		public bool Initialised
		{
			get
			{
				return ColourFormat != TColourData.UnInitialised;
			}
		}
		public int Width
		{
			get
			{
				return Dimensions.Width;
			}
		}

		public int Height
		{
			get
			{
				return Dimensions.Height;
			}
		}

		public uint BytesPerPixel
		{
			get
			{
				return CVImageConversion.BytesPerPixel(ColourFormat);
			}
		}

		public uint SizeInBytes
		{
			get
			{
				return this.BytesPerPixel * (uint)this.Width * (uint)this.Height;
			}
		}
	}
}
