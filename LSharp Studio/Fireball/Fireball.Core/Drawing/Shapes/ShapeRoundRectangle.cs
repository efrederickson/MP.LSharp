
//    Copyright (C) 2005  Riccardo Marzi  <riccardo@dotnetfireball.net>
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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Fireball.Drawing.Shapes
{

	public class ShapeRoundRectangle : ShapeRectangle
	{
		private float _radius;

		#region Constructors

		public ShapeRoundRectangle(float left, float top, float width, float height,float radius)
			: base(new RectangleF(left, top, width, height), 0)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(float left, float top, float width, float height, float radius, float rotation)
			: base(new RectangleF(left, top, width, height), rotation)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius)
			: base(bounds, 0)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius, float rotation)
			: base(bounds, rotation)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius)
			: base(firstCorner, secondCorner, 0)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius, float rotation)
			: base(firstCorner, secondCorner, rotation)
		{
			_radius = radius;
			UpdatePath();
		}


		public ShapeRoundRectangle(float left, float top, float width, float height, float radius, Pen pen)
			: base(new RectangleF(left, top, width, height), 0, pen)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(float left, float top, float width, float height, float radius, float rotation, Pen pen)
			: base(new RectangleF(left, top, width, height), rotation, pen)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius, Pen pen)
			: base(bounds, 0, pen)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius, float rotation, Pen pen)
			: base(bounds, rotation, pen)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius, Pen pen)
			: base(firstCorner, secondCorner, 0, pen)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius, float rotation, Pen pen)
			: base(firstCorner, secondCorner, rotation, pen)
		{
			_radius = radius;
			UpdatePath();
		}

		public ShapeRoundRectangle(float left, float top, float width, float height, float radius, Brush brush)
			: base(new RectangleF(left, top, width, height), 0, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(float left, float top, float width, float height, float radius, float rotation, Brush brush)
			: base(new RectangleF(left, top, width, height), rotation, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius, Brush brush)
			: base(bounds, 0, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius, float rotation, Brush brush)
			: base(bounds, rotation, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius, Brush brush)
			: base(firstCorner, secondCorner, 0, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius, float rotation, Brush brush)
			: base(firstCorner, secondCorner, rotation, brush)
		{
			_radius = radius;
			UpdatePath();
		}

		public ShapeRoundRectangle(float left, float top, float width, float height, float radius, Pen pen, Brush brush)
			: base(new RectangleF(left, top, width, height), 0, pen, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(float left, float top, float width, float height, float radius, float rotation, Pen pen, Brush brush)
			: base(new RectangleF(left, top, width, height), 0, pen, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius, Pen pen, Brush brush)
			: base(bounds, 0, pen, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(RectangleF bounds, float radius, float rotation, Pen pen, Brush brush)
			: base(bounds, rotation, pen, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius, Pen pen, Brush brush)
			: base(firstCorner, secondCorner, 0, pen, brush)
		{
			_radius = radius;
			UpdatePath();
		}
		public ShapeRoundRectangle(PointF firstCorner, PointF secondCorner, float radius, float rotation, Pen pen, Brush brush)
			: base(firstCorner, secondCorner, rotation, pen, brush) 
		{ 
			_radius = radius; 
			UpdatePath(); 
		}

		#endregion

		#region Overrides

        public override Image GetThumb(ShapeThumbSize thumbSize)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override string ToString()
        {
            return "{Fireball.Drawing.Shapes.ShapeRoundRectangle}";
        }

        protected override void UpdatePath()
		{
			if (this.Width <= 0 || this.Height <= 0)
			{
				throw new ArgumentException("", (this.Width <= 0) ? "Bounds.Width" : "Bounds.Height");
			}

			if (_radius <= 0) _radius = 1;

			float biradius = _radius * 2;

			if (biradius > this.Width) biradius = this.Width;
			if (biradius > this.Height) biradius = this.Height;

			float left = this.Bounds.Left;
			float top = this.Bounds.Top;
			float right = left + this.Width;
			float bottom = top + this.Height;

			InternalPath = new GraphicsPath();

			InternalPath.AddArc(right - biradius, top, biradius, biradius, 270, 90);
			InternalPath.AddArc(right - biradius, bottom - biradius, biradius, biradius, 0, 90);
			InternalPath.AddArc(left, bottom - biradius, biradius, biradius, 90, 90);
			InternalPath.AddArc(left, top, biradius, biradius, 180, 90);
			InternalPath.CloseFigure();

			Matrix mtx = new Matrix();
			mtx.RotateAt(this.Rotation, this.Location);
			InternalPath.Transform(mtx);
		}

		#endregion

		public float Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
				UpdatePath();
			}
		}

	}
}