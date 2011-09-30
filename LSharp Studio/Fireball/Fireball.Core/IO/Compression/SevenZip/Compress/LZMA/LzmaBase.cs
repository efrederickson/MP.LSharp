#region Licenze

//    Copyright (C) 2004  Sebastian Faltoni <sebastian@dotnetfireball.net>
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
//
//    NB: Original Code Grabbed From sevenzip lzma sdk http://www.7-zip.org/
#endregion

// LzmaBase.cs

namespace Fireball.IO.Compression.SevenZip.Compression.LZMA
{
	internal abstract class Base
	{
		public const uint kNumRepDistances = 4;
		public const uint kNumStates = 12;

		// static byte []kLiteralNextStates  = {0, 0, 0, 0, 1, 2, 3, 4,  5,  6,   4, 5};
		// static byte []kMatchNextStates    = {7, 7, 7, 7, 7, 7, 7, 10, 10, 10, 10, 10};
		// static byte []kRepNextStates      = {8, 8, 8, 8, 8, 8, 8, 11, 11, 11, 11, 11};
		// static byte []kShortRepNextStates = {9, 9, 9, 9, 9, 9, 9, 11, 11, 11, 11, 11};

		public struct State
		{
			public uint Index;
			public void Init() { Index = 0; }
			public void UpdateChar()
			{
				if (Index < 4) Index = 0;
				else if (Index < 10) Index -= 3;
				else Index -= 6;
			}
			public void UpdateMatch() { Index = (uint)(Index < 7 ? 7 : 10); }
			public void UpdateRep() { Index = (uint)(Index < 7 ? 8 : 11); }
			public void UpdateShortRep() { Index = (uint)(Index < 7 ? 9 : 11); }
			public bool IsCharState() { return Index < 7; }
		}

		public const int kNumPosSlotBits = 6;
		public const int kDicLogSizeMin = 0;
		// public const int kDicLogSizeMax = 30;
		// public const uint kDistTableSizeMax = kDicLogSizeMax * 2;

		public const int kNumLenToPosStatesBits = 2; // it's for speed optimization
		public const uint kNumLenToPosStates = 1 << kNumLenToPosStatesBits;

		public const uint kMatchMinLen = 2;

		public static uint GetLenToPosState(uint len)
		{
			len -= kMatchMinLen;
			if (len < kNumLenToPosStates)
				return len;
			return (uint)(kNumLenToPosStates - 1);
		}

		public const int kNumAlignBits = 4;
		public const uint kAlignTableSize = 1 << kNumAlignBits;
		public const uint kAlignMask = (kAlignTableSize - 1);

		public const uint kStartPosModelIndex = 4;
		public const uint kEndPosModelIndex = 14;
		public const uint kNumPosModels = kEndPosModelIndex - kStartPosModelIndex;

		public const uint kNumFullDistances = 1 << ((int)kEndPosModelIndex / 2);

		public const uint kNumLitPosStatesBitsEncodingMax = 4;
		public const uint kNumLitContextBitsMax = 8;

		public const int kNumPosStatesBitsMax = 4;
		public const uint kNumPosStatesMax = (1 << kNumPosStatesBitsMax);
		public const int kNumPosStatesBitsEncodingMax = 4;
		public const uint kNumPosStatesEncodingMax = (1 << kNumPosStatesBitsEncodingMax);

		public const int kNumLowLenBits = 3;
		public const int kNumMidLenBits = 3;
		public const int kNumHighLenBits = 8;
		public const uint kNumLowLenSymbols = 1 << kNumLowLenBits;
		public const uint kNumMidLenSymbols = 1 << kNumMidLenBits;
		public const uint kNumLenSymbols = kNumLowLenSymbols + kNumMidLenSymbols +
				(1 << kNumHighLenBits);
		public const uint kMatchMaxLen = kMatchMinLen + kNumLenSymbols - 1;
	}
}
