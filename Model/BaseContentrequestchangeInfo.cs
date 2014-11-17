/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'ContentRequestChange' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContentrequestchangeInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContentrequestchangeInfo : BaseInfo
	{
		private int _contentrequestchangeid;
		private bool _contentrequestchangeidNull = true;
		private int _contentrequestid;
		private bool _contentrequestidNull = true;
		private string _requestchangereasons = string.Empty;
		private bool _requestchangereasonsNull = true;
		private string _requestchange = string.Empty;
		private bool _requestchangeNull = true;
		private string _requestchangecode = string.Empty;
		private bool _requestchangecodeNull = true;
		private bool _islatest;
		private bool _islatestNull = true;
		private bool[] _diffArray = new bool[6];
		
		public int Contentrequestchangeid
		{
			get { return _contentrequestchangeid; }
			set
			{
				_contentrequestchangeidNull = false;
				_contentrequestchangeid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsContentrequestchangeidNull
		{
			get { return _contentrequestchangeidNull; }
			set
			{
				_contentrequestchangeidNull = value;
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
		public string Requestchangereasons
		{
			get { return _requestchangereasons; }
			set
			{
				_requestchangereasonsNull = false;
				_requestchangereasons = value;
				_diffArray[2] = true;
			}
		}
		public bool IsRequestchangereasonsNull
		{
			get { return _requestchangereasonsNull; }
			set
			{
				_requestchangereasonsNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Requestchange
		{
			get { return _requestchange; }
			set
			{
				_requestchangeNull = false;
				_requestchange = value;
				_diffArray[3] = true;
			}
		}
		public bool IsRequestchangeNull
		{
			get { return _requestchangeNull; }
			set
			{
				_requestchangeNull = value;
				_diffArray[3] = !value;
			}
		}
		public string Requestchangecode
		{
			get { return _requestchangecode; }
			set
			{
				_requestchangecodeNull = false;
				_requestchangecode = value;
				_diffArray[4] = true;
			}
		}
		public bool IsRequestchangecodeNull
		{
			get { return _requestchangecodeNull; }
			set
			{
				_requestchangecodeNull = value;
				_diffArray[4] = !value;
			}
		}
		public bool Islatest
		{
			get { return _islatest; }
			set
			{
				_islatestNull = false;
				_islatest = value;
				_diffArray[5] = true;
			}
		}
		public bool IsIslatestNull
		{
			get { return _islatestNull; }
			set
			{
				_islatestNull = value;
				_diffArray[5] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
