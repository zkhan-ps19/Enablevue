/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'RequestStatus' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'RequeststatusInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseRequeststatusInfo : BaseInfo
	{
		private int _requeststatuscode;
		private bool _requeststatuscodeNull = true;
		private string _status = string.Empty;
		private bool _statusNull = true;
		private string _description = string.Empty;
		private bool _descriptionNull = true;
		private bool[] _diffArray = new bool[3];
		
		public int Requeststatuscode
		{
			get { return _requeststatuscode; }
			set
			{
				_requeststatuscodeNull = false;
				_requeststatuscode = value;
				_diffArray[0] = true;
			}
		}
		public bool IsRequeststatuscodeNull
		{
			get { return _requeststatuscodeNull; }
			set
			{
				_requeststatuscodeNull = value;
				_diffArray[0] = !value;
			}
		}
		public string Status
		{
			get { return _status; }
			set
			{
				_statusNull = false;
				_status = value;
				_diffArray[1] = true;
			}
		}
		public bool IsStatusNull
		{
			get { return _statusNull; }
			set
			{
				_statusNull = value;
				_diffArray[1] = !value;
			}
		}
		public string Description
		{
			get { return _description; }
			set
			{
				_descriptionNull = false;
				_description = value;
				_diffArray[2] = true;
			}
		}
		public bool IsDescriptionNull
		{
			get { return _descriptionNull; }
			set
			{
				_descriptionNull = value;
				_diffArray[2] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
