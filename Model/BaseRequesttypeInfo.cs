/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'RequestType' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'RequesttypeInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseRequesttypeInfo : BaseInfo
	{
		private string _requesttypecode = string.Empty;
		private bool _requesttypecodeNull = true;
		private string _requesttype = string.Empty;
		private bool _requesttypeNull = true;
		private bool[] _diffArray = new bool[2];
		
		public string Requesttypecode
		{
			get { return _requesttypecode; }
			set
			{
				_requesttypecodeNull = false;
				_requesttypecode = value;
				_diffArray[0] = true;
			}
		}
		public bool IsRequesttypecodeNull
		{
			get { return _requesttypecodeNull; }
			set
			{
				_requesttypecodeNull = value;
				_diffArray[0] = !value;
			}
		}
		public string Requesttype
		{
			get { return _requesttype; }
			set
			{
				_requesttypeNull = false;
				_requesttype = value;
				_diffArray[1] = true;
			}
		}
		public bool IsRequesttypeNull
		{
			get { return _requesttypeNull; }
			set
			{
				_requesttypeNull = value;
				_diffArray[1] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
