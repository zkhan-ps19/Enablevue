/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'ContentRequestCategory' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContentrequestcategoryInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContentrequestcategoryInfo : BaseInfo
	{
		private int _contentrequestcategoryid;
		private bool _contentrequestcategoryidNull = true;
		private int _contentrequestid;
		private bool _contentrequestidNull = true;
		private string _category = string.Empty;
		private bool _categoryNull = true;
		private string _categoryprimaryurl = string.Empty;
		private bool _categoryprimaryurlNull = true;
		private string _categoryanchortext = string.Empty;
		private bool _categoryanchortextNull = true;
		private string _categorypreferredkeyword = string.Empty;
		private bool _categorypreferredkeywordNull = true;
		private bool[] _diffArray = new bool[6];
		
		public int Contentrequestcategoryid
		{
			get { return _contentrequestcategoryid; }
			set
			{
				_contentrequestcategoryidNull = false;
				_contentrequestcategoryid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsContentrequestcategoryidNull
		{
			get { return _contentrequestcategoryidNull; }
			set
			{
				_contentrequestcategoryidNull = value;
				_diffArray[0] = !value;
			}
		}
		public int Contentrequestid
		{
			get { return _contentrequestid; }
			set
			{
				_contentrequestidNull = false;
				_contentrequestid = value;
				_diffArray[1] = true;
			}
		}
		public bool IsContentrequestidNull
		{
			get { return _contentrequestidNull; }
			set
			{
				_contentrequestidNull = value;
				_diffArray[1] = !value;
			}
		}
		public string Category
		{
			get { return _category; }
			set
			{
				_categoryNull = false;
				_category = value;
				_diffArray[2] = true;
			}
		}
		public bool IsCategoryNull
		{
			get { return _categoryNull; }
			set
			{
				_categoryNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Categoryprimaryurl
		{
			get { return _categoryprimaryurl; }
			set
			{
				_categoryprimaryurlNull = false;
				_categoryprimaryurl = value;
				_diffArray[3] = true;
			}
		}
		public bool IsCategoryprimaryurlNull
		{
			get { return _categoryprimaryurlNull; }
			set
			{
				_categoryprimaryurlNull = value;
				_diffArray[3] = !value;
			}
		}
		public string Categoryanchortext
		{
			get { return _categoryanchortext; }
			set
			{
				_categoryanchortextNull = false;
				_categoryanchortext = value;
				_diffArray[4] = true;
			}
		}
		public bool IsCategoryanchortextNull
		{
			get { return _categoryanchortextNull; }
			set
			{
				_categoryanchortextNull = value;
				_diffArray[4] = !value;
			}
		}
		public string Categorypreferredkeyword
		{
			get { return _categorypreferredkeyword; }
			set
			{
				_categorypreferredkeywordNull = false;
				_categorypreferredkeyword = value;
				_diffArray[5] = true;
			}
		}
		public bool IsCategorypreferredkeywordNull
		{
			get { return _categorypreferredkeywordNull; }
			set
			{
				_categorypreferredkeywordNull = value;
				_diffArray[5] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
