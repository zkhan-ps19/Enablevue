/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'ContentRequestPage' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContentrequestpageInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContentrequestpageInfo : BaseInfo
	{
		private int _pageid;
		private bool _pageidNull = true;
		private int _contentrequestid;
		private bool _contentrequestidNull = true;
		private int _id;
		private bool _idNull = true;
		private string _pagetitle = string.Empty;
		private bool _pagetitleNull = true;
		private string _pageurl = string.Empty;
		private bool _pageurlNull = true;
		private string _pageinstruction = string.Empty;
		private bool _pageinstructionNull = true;
		private bool _iscontentrequired;
		private bool _iscontentrequiredNull = true;
		private bool[] _diffArray = new bool[7];
		
		public int Pageid
		{
			get { return _pageid; }
			set
			{
				_pageidNull = false;
				_pageid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsPageidNull
		{
			get { return _pageidNull; }
			set
			{
				_pageidNull = value;
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
		public int Id
		{
			get { return _id; }
			set
			{
				_idNull = false;
				_id = value;
				_diffArray[2] = true;
			}
		}
		public bool IsIdNull
		{
			get { return _idNull; }
			set
			{
				_idNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Pagetitle
		{
			get { return _pagetitle; }
			set
			{
				_pagetitleNull = false;
				_pagetitle = value;
				_diffArray[3] = true;
			}
		}
		public bool IsPagetitleNull
		{
			get { return _pagetitleNull; }
			set
			{
				_pagetitleNull = value;
				_diffArray[3] = !value;
			}
		}
		public string Pageurl
		{
			get { return _pageurl; }
			set
			{
				_pageurlNull = false;
				_pageurl = value;
				_diffArray[4] = true;
			}
		}
		public bool IsPageurlNull
		{
			get { return _pageurlNull; }
			set
			{
				_pageurlNull = value;
				_diffArray[4] = !value;
			}
		}
		public string Pageinstruction
		{
			get { return _pageinstruction; }
			set
			{
				_pageinstructionNull = false;
				_pageinstruction = value;
				_diffArray[5] = true;
			}
		}
		public bool IsPageinstructionNull
		{
			get { return _pageinstructionNull; }
			set
			{
				_pageinstructionNull = value;
				_diffArray[5] = !value;
			}
		}
		public bool Iscontentrequired
		{
			get { return _iscontentrequired; }
			set
			{
				_iscontentrequiredNull = false;
				_iscontentrequired = value;
				_diffArray[6] = true;
			}
		}
		public bool IsIscontentrequiredNull
		{
			get { return _iscontentrequiredNull; }
			set
			{
				_iscontentrequiredNull = value;
				_diffArray[6] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
