/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'Content' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContentInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContentInfo : BaseInfo
	{
		private int _contentid;
		private bool _contentidNull = true;
		private int _contentrequestid;
		private bool _contentrequestidNull = true;
		private int _authorid;
		private bool _authoridNull = true;
		private string _title = string.Empty;
		private bool _titleNull = true;
		private string _source = string.Empty;
		private bool _sourceNull = true;
		private string _contentdetail = string.Empty;
		private bool _contentdetailNull = true;
		private string _category = string.Empty;
		private bool _categoryNull = true;
		private int _contentstatuscode;
		private bool _contentstatuscodeNull = true;
		private bool[] _diffArray = new bool[8];
		
		public int Contentid
		{
			get { return _contentid; }
			set
			{
				_contentidNull = false;
				_contentid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsContentidNull
		{
			get { return _contentidNull; }
			set
			{
				_contentidNull = value;
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
		public int Authorid
		{
			get { return _authorid; }
			set
			{
				_authoridNull = false;
				_authorid = value;
				_diffArray[2] = true;
			}
		}
		public bool IsAuthoridNull
		{
			get { return _authoridNull; }
			set
			{
				_authoridNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Title
		{
			get { return _title; }
			set
			{
				_titleNull = false;
				_title = value;
				_diffArray[3] = true;
			}
		}
		public bool IsTitleNull
		{
			get { return _titleNull; }
			set
			{
				_titleNull = value;
				_diffArray[3] = !value;
			}
		}
		public string Source
		{
			get { return _source; }
			set
			{
				_sourceNull = false;
				_source = value;
				_diffArray[4] = true;
			}
		}
		public bool IsSourceNull
		{
			get { return _sourceNull; }
			set
			{
				_sourceNull = value;
				_diffArray[4] = !value;
			}
		}
		public string Contentdetail
		{
			get { return _contentdetail; }
			set
			{
				_contentdetailNull = false;
				_contentdetail = value;
				_diffArray[5] = true;
			}
		}
		public bool IsContentdetailNull
		{
			get { return _contentdetailNull; }
			set
			{
				_contentdetailNull = value;
				_diffArray[5] = !value;
			}
		}
		public string Category
		{
			get { return _category; }
			set
			{
				_categoryNull = false;
				_category = value;
				_diffArray[6] = true;
			}
		}
		public bool IsCategoryNull
		{
			get { return _categoryNull; }
			set
			{
				_categoryNull = value;
				_diffArray[6] = !value;
			}
		}
		public int Contentstatuscode
		{
			get { return _contentstatuscode; }
			set
			{
				_contentstatuscodeNull = false;
				_contentstatuscode = value;
				_diffArray[7] = true;
			}
		}
		public bool IsContentstatuscodeNull
		{
			get { return _contentstatuscodeNull; }
			set
			{
				_contentstatuscodeNull = value;
				_diffArray[7] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
