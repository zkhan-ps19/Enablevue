/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'ContentStatus' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContentstatusInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContentstatusInfo : BaseInfo
	{
		private int _contentstatuscode;
		private bool _contentstatuscodeNull = true;
		private string _contentstatus = string.Empty;
		private bool _contentstatusNull = true;
		private string _description = string.Empty;
		private bool _descriptionNull = true;
		private bool[] _diffArray = new bool[3];
		
		public int Contentstatuscode
		{
			get { return _contentstatuscode; }
			set
			{
				_contentstatuscodeNull = false;
				_contentstatuscode = value;
				_diffArray[0] = true;
			}
		}
		public bool IsContentstatuscodeNull
		{
			get { return _contentstatuscodeNull; }
			set
			{
				_contentstatuscodeNull = value;
				_diffArray[0] = !value;
			}
		}
		public string Contentstatus
		{
			get { return _contentstatus; }
			set
			{
				_contentstatusNull = false;
				_contentstatus = value;
				_diffArray[1] = true;
			}
		}
		public bool IsContentstatusNull
		{
			get { return _contentstatusNull; }
			set
			{
				_contentstatusNull = value;
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
