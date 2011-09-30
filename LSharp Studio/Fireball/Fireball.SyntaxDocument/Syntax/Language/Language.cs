
//	Copyright (C) 2005  Sebastian Faltoni <sebastian@dotnetfireball.org>
//	
//	Copyright (C) compona.com 
//	
//	This library is free software; you can redistribute it and/or
//	modify it under the terms of the GNU Lesser General Public
//	License as published by the Free Software Foundation; either
//	version 2.1 of the License, or (at your option) any later version.
//	
//	This library is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//	Lesser General Public License for more details.
//	
//	You should have received a copy of the GNU Lesser General Public
//	License along with this library; if not, write to the Free Software
//	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

namespace Fireball.Syntax
{
	/// <summary>
	/// File type struct
	/// </summary>
	public class FileType
	{
		/// <summary>
		/// The file type extension
		/// </summary>
		public string Extension="";
		/// <summary>
		/// The name of the file type
		/// </summary>
		public string Name="";

	}

    public class GutterInfo
    {
        public int Size = 0;
        public TextStyle Style;
    }

	/// <summary>
	/// The Language class describes a language.<br/>
	/// It consists of a MainBlock , which is the start BlockType of the Language<br/>
	/// It also have a list of filetypes that is valid for this language<br/>
	/// </summary>
	/// <example>
	/// <b>Apply a Syntax to a SyntaxBox</b>
	/// <code>
	/// SyntaxBoxControl1.Document.SyntaxFile="C#.syn";
	/// </code>
	/// </example>
	public class Language
	{
		#region PUBLIC PROPERTY SEPARATORS
		private string _Separators=".,:;{}()[]+-*/\\ \t=&%$#@!|&";
		public string Separators
		{
			get
			{
				return _Separators;
			}
			set
			{
				_Separators = value;
			}
		}
		#endregion

        public string FileDialogFilters
        {
            get
            {
                FileType current = null;
                StringBuilder sb = new StringBuilder();

                sb.Append(this.Name);
                sb.Append(" |");

                for (int i = 0; i < FileTypes.Count; i++)
                {
                    current = (FileType)FileTypes[i];

                    sb.Append("*");
                    sb.Append(current.Extension);
                    if (i < FileTypes.Count - 1)
                        sb.Append(";");
                }

                return sb.ToString();
            }
        }

            #region PUBLIC PROPERTY VERSION
            private long _Version = long.MinValue;
		public long Version
		{
			get
			{
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}
		#endregion

		public void UpdateLists()
		{
			BlockType[] blocks =this.Blocks;
			foreach (BlockType block in blocks)
			{
				block.Parent = this;
				block.ResetLookupTable ();				

				block.KeywordsList.Parent=block;
				foreach (PatternList patterns in block.KeywordsList)
				{
					patterns.Parent = block.KeywordsList;

					foreach (Pattern pattern in patterns)
					{
						block.AddToLookupTable (pattern);
					}
				}

				block.OperatorsList.Parent=block;
				foreach (PatternList patterns in block.OperatorsList)
				{
					patterns.Parent = block.OperatorsList;

					foreach (Pattern pattern in patterns)
					{
						block.AddToLookupTable (pattern);
					}
				}
				block.BuildLookupTable ();
			}
		}
		
		public void ChangeVersion()
		{
			this.Version ++;
			if (this.Version > long.MaxValue-10)
				this.Version = long.MinValue;
		}

		private Hashtable			_Blocks=new Hashtable ();
		private Hashtable			_Styles=new Hashtable ();

        /// <summary>
        /// Filename of the Language
        /// </summary>
        public string FileName = "";

		/// <summary>
		/// Name of the Language
		/// </summary>
		public string Name="";	
		/// <summary>
		/// The start BlockType for this language
		/// </summary>
		public BlockType MainBlock=null;
        /// <summary>
        /// Event raised when styles are updated
        /// </summary>
        public event EventHandler StyleUpdated;

		/// <summary>
		/// ArrayList containing the valid filetypes for this language
		/// </summary>
        private ArrayList fileTypes = new ArrayList();

        public ArrayList FileTypes
        {
            get
            {
                return fileTypes;
            }
        }

        private GutterInfo _gutterInfo;
        public GutterInfo GutterInfo
        {
            get { return _gutterInfo; }
            set
            {
                if (_gutterInfo != value)
                {
                    _gutterInfo = value;

                    if (StyleUpdated != null)
                    {
                        StyleUpdated(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Name of the font used for this Language
        /// </summary>
        private string _FontName = "";
        public string FontName
        {
            get { return _FontName; }
            set
            {
                if (!_FontName.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    _FontName = value;

                    if (StyleUpdated != null)
                    {
                        StyleUpdated(this, EventArgs.Empty);
                    }
                }
            }
        }

        public string DefaultFontName = "";

        /// <summary>
        /// Size of the font used for this Language
        /// </summary>
        private int _FontSize = 0;
        public int FontSize
        {
            get { return _FontSize; }
            set
            {
                if (_FontSize != value)
                {
                    _FontSize = value;

                    if (StyleUpdated != null)
                    {
                        StyleUpdated(this, EventArgs.Empty);
                    }
                }
            }
        }

        public int DefaultFontSize = 0;

		/// <summary>
		/// 
		/// </summary>
		public Language()
		{
		}

		public static Language FromSyntaxFile(string filename)
		{
			SyntaxLoader sl=new SyntaxLoader();
			return sl.Load (filename);
		}

        public static Language FromSyntaxFile(Stream stream)
        {
            SyntaxLoader sl = new SyntaxLoader();
            return sl.Load(stream);
        }

		public void MergeByMainBlock(Language Target)
		{
			BlockType [] blocks = this.Blocks;
			foreach (BlockType current in blocks)
			{
				current.ChildBlocks.Insert (0,Target.MainBlock);
			}
		}

		public void MergeByChildBlocks(Language Target)
		{
			BlockType [] blocks = this.Blocks;
			foreach (BlockType current in blocks)
			{
				for (int i=Target.MainBlock.ChildBlocks.Count-1 ;i>=0;i--)
				{
					BlockType child=Target.MainBlock.ChildBlocks[i];
					current.ChildBlocks.Insert (0,child);
				}
			}
		}


		/// <summary>
		/// Gets all BlockTypes in a given language.
		/// </summary>
		public BlockType[] Blocks
		{
			get
			{
				_Blocks.Clear ();
				FillBlocks(this.MainBlock);
				BlockType[] blocks=new BlockType[_Blocks.Values.Count];
				int i=0;
				foreach (BlockType current in _Blocks.Values)
				{
					blocks[i]=current;
					i++;
				}
				

				return blocks;
			}	
		}

		public TextStyle[] Styles
		{
			get
			{
				/*_Styles.Clear ();
				BlockType[] blocks=this.Blocks ;
				foreach (BlockType bt in blocks)
				{
					_Styles[bt.Style]=bt.Style;
					
					foreach (Scope current in bt.ScopePatterns)
					{

						if (current.Style!= null)
							_Styles[current.Style]=current.Style;						
					}

					foreach (PatternList current in bt.KeywordsList)
					{
						if (current.Style!= null)
							_Styles[current.Style]=current.Style;												
					}

					foreach (PatternList current in bt.OperatorsList)
					{
						if (current.Style!= null)
							_Styles[current.Style]=current.Style;												
					}
				}*/

				TextStyle[] styles=new TextStyle[_Styles.Values.Count];
				int i=0;
				foreach (TextStyle st in _Styles.Values)
				{
					styles[i]=st;
					++i;
				}
				return styles;
			}
		}

		private void FillBlocks(BlockType blockType)
		{
			if (blockType==null)
				return;

			if (_Blocks[blockType]!=null)
				return;

			_Blocks[blockType]=blockType;

			foreach (BlockType current in blockType.ChildBlocks)
			{
				FillBlocks(current);
			}
			foreach (Scope current in blockType.ScopePatterns)
			{
				FillBlocks(current.SpawnBlockOnEnd);
				FillBlocks(current.SpawnBlockOnStart);
			}
		}

        public void SetStyles(Hashtable styles)
        {
            _Styles = styles;
            if (StyleUpdated != null)
            {
                StyleUpdated(this, EventArgs.Empty);
            }
        }

        public void UpdateStyles(TextStyle[] styles)
        {
            _Styles.Clear();
            foreach (TextStyle ts in styles)
            {
                _Styles[ts] = ts;

                if (this.GutterInfo != null && this.GutterInfo.Style.Name.Equals(ts.Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    this.GutterInfo.Style = ts;
                }

				foreach (BlockType bt in this.Blocks)
				{
                    if (bt.Style != null && !string.IsNullOrEmpty(bt.Style.Name) && bt.Style.Name.Equals(ts.Name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        bt.Style = ts;
                    }

					foreach (Scope current in bt.ScopePatterns)
					{
                        if (current.Style != null && !string.IsNullOrEmpty(current.Style.Name) && current.Style.Name.Equals(ts.Name, StringComparison.CurrentCultureIgnoreCase))
                        {
                            current.Style = ts;
                        }
					}

					foreach (PatternList current in bt.KeywordsList)
					{
                        if (current.Style != null && !string.IsNullOrEmpty(current.Style.Name) && current.Style.Name.Equals(ts.Name, StringComparison.CurrentCultureIgnoreCase))
                        {
                            current.Style = ts;
                        }
					}

					foreach (PatternList current in bt.OperatorsList)
					{
                        if (current.Style != null && !string.IsNullOrEmpty(current.Style.Name) && current.Style.Name.Equals(ts.Name, StringComparison.CurrentCultureIgnoreCase))
                        {
                            current.Style = ts;
                        }
					}
				}
            }

            if (StyleUpdated != null)
            {
                StyleUpdated(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Resets back to default all text styles and font size and name values
        /// </summary>
        public void UseDefaults()
        {
            FontName = DefaultFontName;
            FontSize = DefaultFontSize;

            foreach (TextStyle ts in this.Styles)
            {
                ts.UseDefaults();
            }
        }

        /// <summary>
        /// Save user styles configuration on the directory set on UserCustomStyles
        /// if UserCustomStyles is null the function throw an exception.
        /// </summary>
        /// <returns></returns>
        public void SaveStyles()
        {
            if (string.IsNullOrEmpty(SyntaxLoader.UserCustomStyles))
            {
                throw new IOException("Invalid user config dir. Cannot save styles.");
            }

            if (!Directory.Exists(SyntaxLoader.UserCustomStyles))
            {
                Directory.CreateDirectory(SyntaxLoader.UserCustomStyles);
            }

            string path = Path.Combine(SyntaxLoader.UserCustomStyles, this.Name + ".conf");
            using (XmlTextWriter xwr = new XmlTextWriter(path, Encoding.UTF8))
            {
                xwr.Formatting = Formatting.Indented;
                xwr.WriteStartDocument();
                xwr.WriteStartElement("UserConf");

                xwr.WriteStartElement("Font");
                xwr.WriteAttributeString("Name", this.FontName);
                xwr.WriteAttributeString("Size", this.FontSize.ToString());
                xwr.WriteEndElement();

                xwr.WriteStartElement("Styles");

                TextStyle[] styles = this.Styles;

                foreach (TextStyle style in styles)
                {
                    xwr.WriteStartElement("Style");

                    xwr.WriteAttributeString("Name", style.Name);
                    xwr.WriteAttributeString("BorderColor", style.BorderColor.Name);
                    xwr.WriteAttributeString("ForeColor", style.ForeColor.Name);
                    xwr.WriteAttributeString("BackColor", style.BackColor.Name);
                    xwr.WriteAttributeString("DefaultForeColor", style.DefaultForeColor.Name);
                    xwr.WriteAttributeString("DefaultBackColor", style.DefaultBackColor.Name);
                    xwr.WriteAttributeString("CustomForeColor", style.CustomForeColor.Name);
                    xwr.WriteAttributeString("CustomBackColor", style.CustomBackColor.Name);
                    xwr.WriteAttributeString("Bold", style.Bold.ToString());
                    xwr.WriteAttributeString("Italic", style.Italic.ToString());
                    xwr.WriteAttributeString("Underline", style.Underline.ToString());

                    xwr.WriteEndElement(); // style
                }

                xwr.WriteEndElement(); // styles
                xwr.WriteEndElement(); // userconf
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
	}
}
