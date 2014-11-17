/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'CountryState' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'CountrystateInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseCountrystateInfo : BaseInfo
	{
		private int _stateid;
		private bool _stateidNull = true;
		private int _countryid;
		private bool _countryidNull = true;
		private string _name = string.Empty;
		private bool _nameNull = true;
		private bool[] _diffArray = new bool[3];
		
		public int Stateid
		{
			get { return _stateid; }
			set
			{
				_stateidNull = false;
				_stateid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsStateidNull
		{
			get { return _stateidNull; }
			set
			{
				_stateidNull = value;
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
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
