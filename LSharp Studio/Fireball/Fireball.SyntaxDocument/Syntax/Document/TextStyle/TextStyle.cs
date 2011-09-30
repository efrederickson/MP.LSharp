using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Fireball.Syntax
{
	/// <summary>
	/// TextStyles are used to describe the apperance of text.
	/// </summary>
	[Editor(typeof (TextStyleUIEditor), typeof (UITypeEditor))]
	public class TextStyle : ICloneable
	{
		public event EventHandler Change = null;

		protected virtual void OnChange()
		{
			if (Change != null && !_Cloning)
            {
				Change(this, EventArgs.Empty);
            }
		}

		/// <summary>
		/// Name of the style
		/// </summary>
		public string Name = null;

		/// <summary>
		/// Gets or Sets if the style uses a Bold font
		/// </summary>

		#region PUBLIC PROPERTY BOLD
		private bool _Bold;

		[Category("Font")]
		[Description("Gets or Sets if the style uses a BOLD font")]
		public bool Bold
		{
			get { return _Bold; }
			set
			{
                if (_Bold != value)
                {
                    _Bold = value;
                    OnChange();
                }
			}
		}

		#endregion

        /// <summary>
        /// Gets or Sets if the style uses a DefaultBold font
        /// </summary>

        #region PUBLIC PROPERTY DEFAULT BOLD
        private bool _DefaultBold;

        [Category("Font")]
        [Description("Gets or Sets if the style uses a Default Bold font")]
        public bool DefaultBold
        {
            get { return _DefaultBold; }
            set
            {
                if (_DefaultBold != value)
                {
                    _DefaultBold = value;
                    OnChange();
                }
            }
        }

        #endregion

		/// <summary>
		/// Gets or Sets if the style uses an Italic font
		/// </summary>

		#region PUBLIC PROPERTY ITALIC
		private bool _Italic;

		[Category("Font")]
		[Description("Gets or Sets if the style uses an ITALIC font")]
		public bool Italic
		{
			get { return _Italic; }
			set
			{
                if (_Italic != value)
                {
                    _Italic = value;
                    OnChange();
                }
			}
		}

		#endregion

        /// <summary>
        /// Gets or Sets if the style uses an DefaultItalic font
        /// </summary>

        #region PUBLIC PROPERTY DEFAULT ITALIC
        private bool _DefaultItalic;

        [Category("Font")]
        [Description("Gets or Sets if the style uses a Default Italic font")]
        public bool DefaultItalic
        {
            get { return _DefaultItalic; }
            set
            {
                if (_DefaultItalic != value)
                {
                    _DefaultItalic = value;
                    OnChange();
                }
            }
        }

        #endregion

		/// <summary>
		/// Gets or Sets if the style uses an Underlined font
		/// </summary>

		#region PUBLIC PROPERTY UNDERLINE
		private bool _Underline;

		[Category("Font")]
		[Description("Gets or Sets if the style uses an UNDERLINED font")]
		public bool Underline
		{
			get { return _Underline; }
			set
			{
                if (_Underline != value)
                {
                    _Underline = value;
                    OnChange();
                }
			}
		}

		#endregion

        /// <summary>
        /// Gets or Sets if the style uses a DefaultUnderline font
        /// </summary>

        #region PUBLIC PROPERTY DEFAULT UNDERLINE
        private bool _DefaultUnderline;

        [Category("Font")]
        [Description("Gets or Sets if the style uses a DefaultUnderline font")]
        public bool DefaultUnderline
        {
            get { return _DefaultUnderline; }
            set
            {
                if (_DefaultUnderline != value)
                {
                    _DefaultUnderline = value;
                    OnChange();
                }
            }
        }

        #endregion

		/// <summary>
		/// Gets or Sets the ForeColor of the style
		/// </summary>

		#region PUBLIC PROPERTY FORECOLOR
		private Color _ForeColor = Color.Black;

		[Category("Color")]
		[Description("Gets or Sets the fore color of the style")]
		public Color ForeColor
		{
			get { return _ForeColor; }
			set
			{
                if (_ForeColor != value)
                {
                    _ForeColor = value;
                    OnChange();
                }
			}
		}

		#endregion

		/// <summary>
		/// Gets or Sets the BackColor of the style
		/// </summary>

		#region PUBLIC PROPERTY BACKCOLOR
		private Color _BackColor = Color.Transparent;

		[Category("Color")]
		[Description("Gets or Sets the background color of the style")]
		public Color BackColor
		{
			get { return _BackColor; }
			set
			{
                if (_BackColor != value)
                {
                    _BackColor = value;
                    OnChange();
                }
			}
		}

		#endregion

        /// <summary>
        /// Gets the default ForeColor of the style
        /// </summary>

        #region PUBLIC PROPERTY DEFAULT FORECOLOR
        private Color _DefaultForeColor = Color.Black;

        [Category("Color")]
        [Description("Gets the default fore color of the style")]
        public Color DefaultForeColor
        {
            get { return _DefaultForeColor; }
            set
            {
                if (_DefaultForeColor != value)
                {
                    _DefaultForeColor = value;
                    OnChange();
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the default BackColor of the style
        /// </summary>

        #region PUBLIC PROPERTY DEFAULT BACKCOLOR
        private Color _DefaultBackColor = Color.White;

        [Category("Color")]
        [Description("Gets the default background color of the style")]
        public Color DefaultBackColor
        {
            get { return _DefaultBackColor; }
            set
            {
                if (_DefaultBackColor != value)
                {
                    _DefaultBackColor = value;
                    OnChange();
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the default ForeColor of the style
        /// </summary>

        #region PUBLIC PROPERTY CUSTOM FORECOLOR
        private Color _CustomForeColor = Color.Black;

        [Category("Color")]
        [Description("Gets the custom fore color of the style")]
        public Color CustomForeColor
        {
            get { return _CustomForeColor; }
            set
            {
                if (_CustomForeColor != value)
                {
                    _CustomForeColor = value;
                    OnChange();
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the default BackColor of the style
        /// </summary>

        #region PUBLIC PROPERTY CUSTOM BACKCOLOR
        private Color _CustomBackColor = Color.White;

        [Category("Color")]
        [Description("Gets the custom background color of the style")]
        public Color CustomBackColor
        {
            get { return _CustomBackColor; }
            set
            {
                if (_DefaultBackColor != value)
                {
                    _CustomBackColor = value;
                    OnChange();
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets or Sets the BorderColor of the style
        /// </summary>

        #region PUBLIC PROPERTY BORDER COLOR
        private Color _BorderColor;

        [Category("Font")]
        [Description("Gets or Sets the border color of the style")]
        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                if (_BorderColor != value)
                {
                    _BorderColor = value;
                    OnChange();
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets or Sets the DefaultBorderColor of the style
        /// </summary>

        #region PUBLIC PROPERTY DEFAULT BORDER COLOR
        private Color _DefaultBorderColor;

        [Category("Font")]
        [Description("Gets or Sets the default border color of the style")]
        public Color DefaultBorderColor
        {
            get { return _DefaultBorderColor; }
            set
            {
                if (_DefaultBorderColor != value)
                {
                    _DefaultBorderColor = value;
                    OnChange();
                }
            }
        }

        #endregion

		/// <summary>
		/// Default constructor
		/// </summary>
		public TextStyle()
		{
			ForeColor = Color.Black;
			BackColor = Color.Transparent;
            BorderColor = Color.Transparent;
            DefaultForeColor = Color.Black;
            DefaultBackColor = Color.White;
		}

		/// <summary>
		/// Returns true if no color have been assigned to the backcolor
		/// </summary>
		[Browsable(false)]
		public bool Transparent
		{
			get { return (BackColor.A == 0); }
		}

		public override string ToString()
		{
			if (this.Name == null)
				return "TextStyle";

			return this.Name;
		}

        public void UseDefaults()
        {
            Bold = DefaultBold;
            Italic = DefaultItalic;
            Underline = DefaultUnderline;
            ForeColor = DefaultForeColor;
            BackColor = DefaultBackColor;
            BorderColor = DefaultBorderColor;
        }

		#region Implementation of ICloneable

        private bool _Cloning = false;
		public object Clone()
		{
            TextStyle ts = new TextStyle();
            _Cloning = true;
            ts._Cloning = true;

            try
            {
                ts.Change = this.Change;
                ts.BorderColor = this.BorderColor;
			    ts.BackColor = this.BackColor;
                ts.DefaultBackColor = this.DefaultBackColor;
			    ts.Bold = this.Bold;
			    ts.ForeColor = this.ForeColor;
                ts.DefaultForeColor = this.DefaultForeColor;
			    ts.Italic = this.Italic;
			    ts.Underline = this.Underline;
			    ts.Name = this.Name;
            }
            finally
            {
                ts._Cloning = false;
                _Cloning = false;
            }

			return ts;
		}

		#endregion
	}
}