/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'WorkRequest' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'WorkrequestInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseWorkrequestInfo : BaseInfo
	{
		private int _id;
		private bool _idNull = true;
		private string _requestkey = string.Empty;
		private bool _requestkeyNull = true;
		private string _name = string.Empty;
		private bool _nameNull = true;
		private string _apiversion = string.Empty;
		private bool _apiversionNull = true;
		private bool[] _diffArray = new bool[4];
		
		public int Id
		{
			get { return _id; }
			set
			{
				_idNull = false;
				_id = value;
				_diffArray[0] = true;
			}
		}
		public bool IsIdNull
		{
			get { return _idNull; }
			set
			{
				_idNull = value;
				_diffArray[0] = !value;
			}
		}
		public string Requestkey
		{
			get { return _requestkey; }
			set
			{
				_requestkeyNull = false;
				_requestkey = value;
				_diffArray[1] = true;
			}
		}
		public bool IsRequestkeyNull
		{
			get { return _requestkeyNull; }
			set
			{
				_requestkeyNull = value;
				_diffArray[1] = !value;
			}
		}
		public string Name
		{
			get { return _name; }
			set
			{
				_nameNull = false;
				_name = value;
				_diffArray[2] = true;
			}
		}
		public bool IsNameNull
		{
			get { return _nameNull; }
			set
			{
				_nameNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Apiversion
		{
			get { return _apiversion; }
			set
			{
				_apiversionNull = false;
				_apiversion = value;
				_diffArray[3] = true;
			}
		}
		public bool IsApiversionNull
		{
			get { return _apiversionNull; }
			set
			{
				_apiversionNull = value;
				_diffArray[3] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
