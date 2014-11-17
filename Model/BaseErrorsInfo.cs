/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'Errors' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ErrorsInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseErrorsInfo : BaseInfo
	{
		private string _code = string.Empty;
		private bool _codeNull = true;
		private string _description = string.Empty;
		private bool _descriptionNull = true;
		private bool[] _diffArray = new bool[2];
		
		public string Code
		{
			get { return _code; }
			set
			{
				_codeNull = false;
				_code = value;
				_diffArray[0] = true;
			}
		}
		public bool IsCodeNull
		{
			get { return _codeNull; }
			set
			{
				_codeNull = value;
				_diffArray[0] = !value;
			}
		}
		public string Description
		{
			get { return _description; }
			set
			{
				_descriptionNull = false;
				_description = value;
				_diffArray[1] = true;
			}
		}
		public bool IsDescriptionNull
		{
			get { return _descriptionNull; }
			set
			{
				_descriptionNull = value;
				_diffArray[1] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
