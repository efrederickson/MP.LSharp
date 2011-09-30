
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
using System.Collections;
using System.Xml;

namespace Fireball.Xml
{
	/// <summary>
	/// XmlNodeTextReader is Simple Only XmlNode Reader this is usefull when you have
	/// the xmlnode as string and you need to read it as fast is possible
	/// </summary>
	public class XmlNodeTextReader
	{
		public class XmlAttribute
		{
			public string Name;
			public string Value;

			internal XmlAttribute(string name,string value)
			{
				this.Name = name;
				this.Value = value;
			}
		}

		ArrayList m_AttributesNames = null;
		ArrayList m_AttributesValues = null;
		string m_Value = null;
		string m_XmlNode = null;
		string m_LocalName = null;

		bool m_HasChild = false;

		public XmlNodeTextReader(string xmlnode)
		{
			m_AttributesNames = new ArrayList();
			m_AttributesValues = new ArrayList();
			m_XmlNode = "<nodes>" + xmlnode + "</nodes>";
		}

		/// <summary>
		/// Get the attribute value by its name
		/// </summary>
		public string this[string name]
		{
			get
			{
				int index = m_AttributesNames.IndexOf(name);

				if(index == -1) return null;

				return (string)m_AttributesValues[index];
			}
		}

		public string Value
		{
			get
			{
				return m_Value;
			}
		}

		/// <summary>
		/// Get the attribute value by its index
		/// </summary>
		public string this[int index]
		{
			get
			{
				return (string)m_AttributesValues[index];
			}
		}

		/// <summary>
		/// Return the attribute count
		/// </summary>
		public int Count
		{
			get
			{
				return m_AttributesNames.Count;
			}
		}


		
		public XmlAttribute[] Attributes
		{
			get
			{
				XmlAttribute[] attrs = new XmlAttribute[m_AttributesNames.Count];

				for(int i = 0; i < attrs.Length;i++)
				{
					attrs[i] = new XmlAttribute((string)m_AttributesNames[i],
						(string)m_AttributesValues[i]);
				}

				return attrs;
			}
		}

		public bool HasChild
		{
			get
			{
				return m_HasChild;
			}
		}
	
		/// <summary>
		/// Return True if read success
		/// </summary>
		/// <returns></returns>
		public bool ReadAll()
		{
			XmlTextReader xreader = new XmlTextReader(m_XmlNode,XmlNodeType.Document,null);

			bool element = false;

			try
			{
				xreader.Read();

				while(xreader.Read())
				{
					if(xreader.IsStartElement() && element == false)
					{
						m_LocalName = xreader.Value;
						while(xreader.MoveToNextAttribute())
						{
							m_AttributesNames.Add(xreader.LocalName);
							m_AttributesValues.Add(xreader.Value);
						}
						m_Value = xreader.ReadElementString();

						element = true;
					}
					if(element == true) break;
				}
			}
			catch
			{
				return false;
			}
			finally
			{
				xreader.Close();

				try
				{
					XmlTextReader xInnerReader = new XmlTextReader(m_XmlNode,XmlNodeType.Element,null);

					xInnerReader.Read();

					string xmlChild = xInnerReader.ReadInnerXml();

					xInnerReader.Close();

					if(xmlChild != null || (xmlChild != String.Empty))
						m_HasChild = true;
					else
						m_HasChild = false;

				}
				finally
				{
					//NOP	
				}	
				
			}
			return true;
		}
	}
}
