/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'User' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'UserInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseUserInfo : BaseInfo
	{
		private int _userid;
		private bool _useridNull = true;
		private int _countryid;
		private bool _countryidNull = true;
		private int _stateid;
		private bool _stateidNull = true;
		private string _username = string.Empty;
		private bool _usernameNull = true;
		private string _firstname = string.Empty;
		private bool _firstnameNull = true;
		private string _lastname = string.Empty;
		private bool _lastnameNull = true;
		private string _password = string.Empty;
		private bool _passwordNull = true;
		private string _email = string.Empty;
		private bool _emailNull = true;
		private string _city = string.Empty;
		private bool _cityNull = true;
		private string _address = string.Empty;
		private bool _addressNull = true;
		private string _phone = string.Empty;
		private bool _phoneNull = true;
		private DateTime _createddate;
		private bool _createddateNull = true;
		private DateTime _updateddate;
		private bool _updateddateNull = true;
		private int _updatedby;
		private bool _updatedbyNull = true;
		private bool _isadminright;
		private bool _isadminrightNull = true;
		private bool _isdefault;
		private bool _isdefaultNull = true;
		private bool _isdeleted;
		private bool _isdeletedNull = true;
		private bool _isenabled;
		private bool _isenabledNull = true;
		private bool[] _diffArray = new bool[18];
		
		public int Userid
		{
			get { return _userid; }
			set
			{
				_useridNull = false;
				_userid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsUseridNull
		{
			get { return _useridNull; }
			set
			{
				_useridNull = value;
				_diffArray[0] = !value;
			}
		}
		public int Countryid
		{
			get { return _countryid; }
			set
			{
				_countryidNull = false;
				_countryid = value;
				_diffArray[1] = true;
			}
		}
		public bool IsCountryidNull
		{
			get { return _countryidNull; }
			set
			{
				_countryidNull = value;
				_diffArray[1] = !value;
			}
		}
		public int Stateid
		{
			get { return _stateid; }
			set
			{
				_stateidNull = false;
				_stateid = value;
				_diffArray[2] = true;
			}
		}
		public bool IsStateidNull
		{
			get { return _stateidNull; }
			set
			{
				_stateidNull = value;
				_diffArray[2] = !value;
			}
		}
		public string Username
		{
			get { return _username; }
			set
			{
				_usernameNull = false;
				_username = value;
				_diffArray[3] = true;
			}
		}
		public bool IsUsernameNull
		{
			get { return _usernameNull; }
			set
			{
				_usernameNull = value;
				_diffArray[3] = !value;
			}
		}
		public string Firstname
		{
			get { return _firstname; }
			set
			{
				_firstnameNull = false;
				_firstname = value;
				_diffArray[4] = true;
			}
		}
		public bool IsFirstnameNull
		{
			get { return _firstnameNull; }
			set
			{
				_firstnameNull = value;
				_diffArray[4] = !value;
			}
		}
		public string Lastname
		{
			get { return _lastname; }
			set
			{
				_lastnameNull = false;
				_lastname = value;
				_diffArray[5] = true;
			}
		}
		public bool IsLastnameNull
		{
			get { return _lastnameNull; }
			set
			{
				_lastnameNull = value;
				_diffArray[5] = !value;
			}
		}
		public string Password
		{
			get { return _password; }
			set
			{
				_passwordNull = false;
				_password = value;
				_diffArray[6] = true;
			}
		}
		public bool IsPasswordNull
		{
			get { return _passwordNull; }
			set
			{
				_passwordNull = value;
				_diffArray[6] = !value;
			}
		}
		public string Email
		{
			get { return _email; }
			set
			{
				_emailNull = false;
				_email = value;
				_diffArray[7] = true;
			}
		}
		public bool IsEmailNull
		{
			get { return _emailNull; }
			set
			{
				_emailNull = value;
				_diffArray[7] = !value;
			}
		}
		public string City
		{
			get { return _city; }
			set
			{
				_cityNull = false;
				_city = value;
				_diffArray[8] = true;
			}
		}
		public bool IsCityNull
		{
			get { return _cityNull; }
			set
			{
				_cityNull = value;
				_diffArray[8] = !value;
			}
		}
		public string Address
		{
			get { return _address; }
			set
			{
				_addressNull = false;
				_address = value;
				_diffArray[9] = true;
			}
		}
		public bool IsAddressNull
		{
			get { return _addressNull; }
			set
			{
				_addressNull = value;
				_diffArray[9] = !value;
			}
		}
		public string Phone
		{
			get { return _phone; }
			set
			{
				_phoneNull = false;
				_phone = value;
				_diffArray[10] = true;
			}
		}
		public bool IsPhoneNull
		{
			get { return _phoneNull; }
			set
			{
				_phoneNull = value;
				_diffArray[10] = !value;
			}
		}
		public DateTime Createddate
		{
			get { return _createddate; }
			set
			{
				_createddateNull = false;
				_createddate = value;
				_diffArray[11] = true;
			}
		}
		public bool IsCreateddateNull
		{
			get { return _createddateNull; }
			set
			{
				_createddateNull = value;
				_diffArray[11] = !value;
			}
		}
		public DateTime Updateddate
		{
			get { return _updateddate; }
			set
			{
				_updateddateNull = false;
				_updateddate = value;
				_diffArray[12] = true;
			}
		}
		public bool IsUpdateddateNull
		{
			get { return _updateddateNull; }
			set
			{
				_updateddateNull = value;
				_diffArray[12] = !value;
			}
		}
		public int Updatedby
		{
			get { return _updatedby; }
			set
			{
				_updatedbyNull = false;
				_updatedby = value;
				_diffArray[13] = true;
			}
		}
		public bool IsUpdatedbyNull
		{
			get { return _updatedbyNull; }
			set
			{
				_updatedbyNull = value;
				_diffArray[13] = !value;
			}
		}
		public bool Isadminright
		{
			get { return _isadminright; }
			set
			{
				_isadminrightNull = false;
				_isadminright = value;
				_diffArray[14] = true;
			}
		}
		public bool IsIsadminrightNull
		{
			get { return _isadminrightNull; }
			set
			{
				_isadminrightNull = value;
				_diffArray[14] = !value;
			}
		}
		public bool Isdefault
		{
			get { return _isdefault; }
			set
			{
				_isdefaultNull = false;
				_isdefault = value;
				_diffArray[15] = true;
			}
		}
		public bool IsIsdefaultNull
		{
			get { return _isdefaultNull; }
			set
			{
				_isdefaultNull = value;
				_diffArray[15] = !value;
			}
		}
		public bool Isdeleted
		{
			get { return _isdeleted; }
			set
			{
				_isdeletedNull = false;
				_isdeleted = value;
				_diffArray[16] = true;
			}
		}
		public bool IsIsdeletedNull
		{
			get { return _isdeletedNull; }
			set
			{
				_isdeletedNull = value;
				_diffArray[16] = !value;
			}
		}
		public bool Isenabled
		{
			get { return _isenabled; }
			set
			{
				_isenabledNull = false;
				_isenabled = value;
				_diffArray[17] = true;
			}
		}
		public bool IsIsenabledNull
		{
			get { return _isenabledNull; }
			set
			{
				_isenabledNull = value;
				_diffArray[17] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
