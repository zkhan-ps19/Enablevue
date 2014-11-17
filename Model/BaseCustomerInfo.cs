/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'Customer' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'CustomerInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseCustomerInfo : BaseInfo
	{
		private int _customerid;
		private bool _customeridNull = true;
		private string _name = string.Empty;
		private bool _nameNull = true;
		private bool[] _diffArray = new bool[2];
		
		public int Customerid
		{
			get { return _customerid; }
			set
			{
				_customeridNull = false;
				_customerid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsCustomeridNull
		{
			get { return _customeridNull; }
			set
			{
				_customeridNull = value;
				_diffArray[0] = !value;
			}
		}
		public string Name
		{
			get { return _name; }
			set
			{
				_nameNull = false;
				_name = value;
				_diffArray[1] = true;
			}
		}
		public bool IsNameNull
		{
			get { return _nameNull; }
			set
			{
				_nameNull = value;
				_diffArray[1] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
