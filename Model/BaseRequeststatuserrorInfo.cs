/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'RequestStatusError' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'RequeststatuserrorInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseRequeststatuserrorInfo : BaseInfo
	{
		private int _statuserrorid;
		private bool _statuserroridNull = true;
		private int _contentrequestid;
		private bool _contentrequestidNull = true;
		private int _errorid;
		private bool _erroridNull = true;
		private bool[] _diffArray = new bool[3];
		
		public int Statuserrorid
		{
			get { return _statuserrorid; }
			set
			{
				_statuserroridNull = false;
				_statuserrorid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsStatuserroridNull
		{
			get { return _statuserroridNull; }
			set
			{
				_statuserroridNull = value;
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
		public int Errorid
		{
			get { return _errorid; }
			set
			{
				_erroridNull = false;
				_errorid = value;
				_diffArray[2] = true;
			}
		}
		public bool IsErroridNull
		{
			get { return _erroridNull; }
			set
			{
				_erroridNull = value;
				_diffArray[2] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
