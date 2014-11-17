/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'ContentType' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContenttypeInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContenttypeInfo : BaseInfo
	{
		private string _contenttypecode = string.Empty;
		private bool _contenttypecodeNull = true;
		private string _contenttype = string.Empty;
		private bool _contenttypeNull = true;
		private bool[] _diffArray = new bool[2];
		
		public string Contenttypecode
		{
			get { return _contenttypecode; }
			set
			{
				_contenttypecodeNull = false;
				_contenttypecode = value;
				_diffArray[0] = true;
			}
		}
		public bool IsContenttypecodeNull
		{
			get { return _contenttypecodeNull; }
			set
			{
				_contenttypecodeNull = value;
				_diffArray[0] = !value;
			}
		}
		public string Contenttype
		{
			get { return _contenttype; }
			set
			{
				_contenttypeNull = false;
				_contenttype = value;
				_diffArray[1] = true;
			}
		}
		public bool IsContenttypeNull
		{
			get { return _contenttypeNull; }
			set
			{
				_contenttypeNull = value;
				_diffArray[1] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
