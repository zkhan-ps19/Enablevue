/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'Authors' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'AuthorsInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseAuthorsInfo : BaseInfo
	{
		private int _authorid;
		private bool _authoridNull = true;
		private string _name = string.Empty;
		private bool _nameNull = true;
		private bool[] _diffArray = new bool[2];
		
		public int Authorid
		{
			get { return _authorid; }
			set
			{
				_authoridNull = false;
				_authorid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsAuthoridNull
		{
			get { return _authoridNull; }
			set
			{
				_authoridNull = value;
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
