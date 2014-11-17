/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'SmtpSetting' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'SmtpsettingInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseSmtpsettingInfo : BaseInfo
	{
		private string _pmhost = string.Empty;
		private bool _pmhostNull = true;
		private int _pmport;
		private bool _pmportNull = true;
		private string _pmusername = string.Empty;
		private bool _pmusernameNull = true;
		private string _pmpasswrd = string.Empty;
		private bool _pmpasswrdNull = true;
		private bool _pmsecure;
		private bool _pmsecureNull = true;
		private DateTime _updateddate;
		private bool _updateddateNull = true;
		private int _updatedby;
		private bool _updatedbyNull = true;
		private bool[] _diffArray = new bool[7];
		
		public string Pmhost
		{
			get { return _pmhost; }
			set
			{
				_pmhostNull = false;
				_pmhost = value;
				_diffArray[0] = true;
			}
		}
		public bool IsPmhostNull
		{
			get { return _pmhostNull; }
			set
			{
				_pmhostNull = value;
				_diffArray[0] = !value;
			}
		}
		public int Pmport
		{
			get { return _pmport; }
			set
			{
				_pmportNull = false;
				_pmport = value;
				_diffArray[1] = true;
			}
		}
		public bool IsPmportNull
		{
			get { return _pmportNull; }
			set
			{
				_pmportNull = value;
				_diffArray[1] = !value;
			}
		}
		public string Pmusername
		{
			get { return _pmusername; }
			set
			{
				_pmusernameNull = false;
				_pmusername = value;
				_diffArray[2] = true;
			}
		}
		public bool IsPmusernameNull
		{
			get { return _pmusernameNull; }
			set
			{
				_pmusernameNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Pmpasswrd
		{
			get { return _pmpasswrd; }
			set
			{
				_pmpasswrdNull = false;
				_pmpasswrd = value;
				_diffArray[3] = true;
			}
		}
		public bool IsPmpasswrdNull
		{
			get { return _pmpasswrdNull; }
			set
			{
				_pmpasswrdNull = value;
				_diffArray[3] = !value;
			}
		}
		public bool Pmsecure
		{
			get { return _pmsecure; }
			set
			{
				_pmsecureNull = false;
				_pmsecure = value;
				_diffArray[4] = true;
			}
		}
		public bool IsPmsecureNull
		{
			get { return _pmsecureNull; }
			set
			{
				_pmsecureNull = value;
				_diffArray[4] = !value;
			}
		}
		public DateTime Updateddate
		{
			get { return _updateddate; }
			set
			{
				_updateddateNull = false;
				_updateddate = value;
				_diffArray[5] = true;
			}
		}
		public bool IsUpdateddateNull
		{
			get { return _updateddateNull; }
			set
			{
				_updateddateNull = value;
				_diffArray[5] = !value;
			}
		}
		public int Updatedby
		{
			get { return _updatedby; }
			set
			{
				_updatedbyNull = false;
				_updatedby = value;
				_diffArray[6] = true;
			}
		}
		public bool IsUpdatedbyNull
		{
			get { return _updatedbyNull; }
			set
			{
				_updatedbyNull = value;
				_diffArray[6] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
