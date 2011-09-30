﻿
//    Copyright (C) 2005  Sebastian Faltoni <sebastian@dotnetfireball.net>
//
//    Copyright (C) 2005/2006  Riccardo Marzi <riccardo@dotnetfireball.net>
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

#region Using directives

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

#endregion

namespace Fireball.Drawing.Internal
{

	[SuppressUnmanagedCodeSecurityAttribute()]
	internal static class GDIplus
	{

		private const string GDIPlusDLL = "gdiplus.dll";

		internal static IntPtr ConvertPointToMemory(Point[] points)
		{
			if(points == null)
			{
				throw new ArgumentNullException("points");
			}
			int j = Marshal.SizeOf(new GPPOINT().GetType());
			int k = (int)points.Length;
			IntPtr i2 = Marshal.AllocHGlobal(k * j);
			for(int i1 = 0; i1 < k; i1++)
			{
				Marshal.StructureToPtr(new GPPOINT(points[i1]), (IntPtr)((long)i2 + i1 * j), false);
			}
			return i2;
		}

		internal static IntPtr ConvertPointToMemory(PointF[] points)
		{
			if(points == null)
			{
				throw new ArgumentNullException("points");
			}
			int j = Marshal.SizeOf(new GPPOINTF().GetType());
			int k = (int)points.Length;
			IntPtr i2 = Marshal.AllocHGlobal(k * j);
			for(int i1 = 0; i1 < k; i1++)
			{
				Marshal.StructureToPtr(new GPPOINTF(points[i1]), (IntPtr)((long)i2 + i1 * j), false);
			}
			return i2;
		}

        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipCreatePath(int brushMode, ref IntPtr path);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientCenterColor(HandleRef brush, int color);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientCenterPoint(HandleRef brush, GPPOINTF point);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipCreatePathGradient(HandleRef points, int count, int wrapMode, out IntPtr brush);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientPresetBlend(HandleRef brush, HandleRef blend, HandleRef positions, int count);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipSetPathGradientFocusScales(HandleRef brush, float xScale, float yScale);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipCreatePathGradientFromPath(HandleRef path, out IntPtr brush);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipGetPathPoints(HandleRef path, HandleRef points, int count);

		[DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipAddPathCurve3I(HandleRef path, HandleRef memorypts, int count, int offset, int numberOfSegments, float tension);

        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipAddPathArc(HandleRef path, float x, float y, float width, float height, float startAngle, float sweepAngle);

        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipAddPathLine(HandleRef path, float x1, float y1, float x2, float y2);

        [DllImportAttribute(GDIPlusDLL, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int GdipClosePathFigure(HandleRef path);

        [DllImport(GDIPlusDLL, SetLastError = true)]
		internal static extern int GdipCreateBitmapFromGdiDib(IntPtr bminfo, IntPtr pixdat, ref IntPtr image);

        [DllImport(GDIPlusDLL)]
		internal static extern int GdipCreateHBITMAPFromBitmap(IntPtr bitmap, ref IntPtr hbmReturn, int background);

        [DllImport(GDIPlusDLL, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
		internal static extern int GdipCreateBitmapFromHBITMAP(HandleRef hbitmap, HandleRef hpalette, out IntPtr bitmap);
 


	}

	[StructLayoutAttribute(LayoutKind.Sequential)]
	class GPPOINT
	{
		internal int X;
		internal int Y;

		internal GPPOINT()
		{
		}

		internal GPPOINT(PointF pt)
		{
			X = (int)pt.X;
			Y = (int)pt.Y;
		}

		internal GPPOINT(Point pt)
		{
			X = pt.X;
			Y = pt.Y;
		}

		internal PointF ToPoint()
		{
			return new PointF((float)X, (float)Y);
		}
	}

	[StructLayoutAttribute(LayoutKind.Sequential)]
	class GPPOINTF
	{
		internal float X;

		internal float Y;


		internal GPPOINTF()
		{
		}

		internal GPPOINTF(PointF pt)
		{
			X = pt.X;
			Y = pt.Y;
		}

		internal GPPOINTF(Point pt)
		{
			X = pt.X;
			Y = pt.Y;
		}

		internal PointF ToPoint()
		{
			return new PointF(X, Y);
		}
	}

}
