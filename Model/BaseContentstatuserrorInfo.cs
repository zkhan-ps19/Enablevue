/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'ContentStatusError' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContentstatuserrorInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContentstatuserrorInfo : BaseInfo
	{
		private int _statuserrorid;
		private bool _statuserroridNull = true;
		private int _contentrequestid;
		private bool _contentrequestidNull = true;
		private string _errorcode = string.Empty;
		private bool _errorcodeNull = true;
		private string _description = string.Empty;
		private bool _descriptionNull = true;
		private bool[] _diffArray = new bool[4];
		
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
		public string Errorcode
		{
			get { return _errorcode; }
			set
			{
				_errorcodeNull = false;
				_errorcode = value;
				_diffArray[2] = true;
			}
		}
		public bool IsErrorcodeNull
		{
			get { return _errorcodeNull; }
			set
			{
				_errorcodeNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Description
		{
			get { return _description; }
			set
			{
				_descriptionNull = false;
				_description = value;
				_diffArray[3] = true;
			}
		}
		public bool IsDescriptionNull
		{
			get { return _descriptionNull; }
			set
			{
				_descriptionNull = value;
				_diffArray[3] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
