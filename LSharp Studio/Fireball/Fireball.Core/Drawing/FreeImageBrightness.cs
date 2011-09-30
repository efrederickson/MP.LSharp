
//    Copyright (C) 2005  Sebastian Faltoni <sebastian@dotnetfireball.net>
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

using System;
using System.Collections.Generic;
using System.Text;
using Fireball.Drawing.Internal;

namespace Fireball.Drawing
{
    public class FreeImageBrightness : FreeImagePixelTransformation
    {
        private double _brightness = 0;
        private bool _completed;

        public bool Completed
        {
            get { return _completed; }
        }

        public double Brightness
        {
            get { return _brightness; }
            set { _brightness = value; }
        }

        public FreeImageBrightness(double brightness)
        {
            //if (brightness > 255)
            //{
            //    brightness = 255;
            //}

            //if (brightness < 0)
            //    brightness = 0;

            _brightness = brightness;
        }

        internal override void Run(FreeImage image)
        {
            _completed = FreeImageApi.AdjustBrightness(image.GetFreeImageHwnd(), _brightness);
        }
    }
}
