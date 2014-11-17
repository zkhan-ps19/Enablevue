/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'UserToken' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'UsertokenInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseUsertokenInfo : BaseInfo
	{
		private int _tokenid;
		private bool _tokenidNull = true;
		private int _userid;
		private bool _useridNull = true;
		private string _token = string.Empty;
		private bool _tokenNull = true;
		private DateTime _createdtime;
		private bool _createdtimeNull = true;
		private DateTime _expiretime;
		private bool _expiretimeNull = true;
		private bool[] _diffArray = new bool[5];
		
		public int Tokenid
		{
			get { return _tokenid; }
			set
			{
				_tokenidNull = false;
				_tokenid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsTokenidNull
		{
			get { return _tokenidNull; }
			set
			{
				_tokenidNull = value;
				_diffArray[0] = !value;
			}
		}
		public int Userid
		{
			get { return _userid; }
			set
			{
				_useridNull = false;
				_userid = value;
				_diffArray[1] = true;
			}
		}
		public bool IsUseridNull
		{
			get { return _useridNull; }
			set
			{
				_useridNull = value;
				_diffArray[1] = !value;
			}
		}
		public string Token
		{
			get { return _token; }
			set
			{
				_tokenNull = false;
				_token = value;
				_diffArray[2] = true;
			}
		}
		public bool IsTokenNull
		{
			get { return _tokenNull; }
			set
			{
				_tokenNull = value;
				_diffArray[2] = !value;
			}
		}
		public DateTime Createdtime
		{
			get { return _createdtime; }
			set
			{
				_createdtimeNull = false;
				_createdtime = value;
				_diffArray[3] = true;
			}
		}
		public bool IsCreatedtimeNull
		{
			get { return _createdtimeNull; }
			set
			{
				_createdtimeNull = value;
				_diffArray[3] = !value;
			}
		}
		public DateTime Expiretime
		{
			get { return _expiretime; }
			set
			{
				_expiretimeNull = false;
				_expiretime = value;
				_diffArray[4] = true;
			}
		}
		public bool IsExpiretimeNull
		{
			get { return _expiretimeNull; }
			set
			{
				_expiretimeNull = value;
				_diffArray[4] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
