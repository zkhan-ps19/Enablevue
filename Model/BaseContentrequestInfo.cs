/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation.
'  Base class (model) for 'ContentRequest' table. Avoid making any changes in 
'  this class, becauses it will be overwritten if the framework is re-
'  generated - for any custom changes use 'ContentrequestInfo' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Collections;

namespace Model
{
	public abstract class BaseContentrequestInfo : BaseInfo
	{
		private int _contentrequestid;
		private bool _contentrequestidNull = true;
		private int _customerid;
		private bool _customeridNull = true;
		private string _contenttypecode = string.Empty;
		private bool _contenttypecodeNull = true;
		private int _requeststatuscode;
		private bool _requeststatuscodeNull = true;
		private string _requesttypecode = string.Empty;
		private bool _requesttypecodeNull = true;
		private int _suggestedauthorid;
		private bool _suggestedauthoridNull = true;
		private int _workrequestid;
		private bool _workrequestidNull = true;
		private int _contentstatuscode;
		private bool _contentstatuscodeNull = true;
		private int _subscriptionid;
		private bool _subscriptionidNull = true;
		private string _subscription = string.Empty;
		private bool _subscriptionNull = true;
		private string _requestcode = string.Empty;
		private bool _requestcodeNull = true;
		private string _name = string.Empty;
		private bool _nameNull = true;
		private DateTime _duedate;
		private bool _duedateNull = true;
		private string _datetimezone = string.Empty;
		private bool _datetimezoneNull = true;
		private string _dateformat = string.Empty;
		private bool _dateformatNull = true;
		private string _directionalcontent = string.Empty;
		private bool _directionalcontentNull = true;
		private string _dcblogurl = string.Empty;
		private bool _dcblogurlNull = true;
		private string _dcpracticearea = string.Empty;
		private bool _dcpracticeareaNull = true;
		private string _dcgeography = string.Empty;
		private bool _dcgeographyNull = true;
		private string _dcinsforwriter = string.Empty;
		private bool _dcinsforwriterNull = true;
		private int _minwordcount;
		private bool _minwordcountNull = true;
		private int _maxwordcount;
		private bool _maxwordcountNull = true;
		private bool _isenabled;
		private bool _isenabledNull = true;
		private DateTime _createddate;
		private bool _createddateNull = true;
		private int _createdby;
		private bool _createdbyNull = true;
		private DateTime _updateddate;
		private bool _updateddateNull = true;
		private int _updatedby;
		private bool _updatedbyNull = true;
		private bool[] _diffArray = new bool[27];
		
		public int Contentrequestid
		{
			get { return _contentrequestid; }
			set
			{
				_contentrequestidNull = false;
				_contentrequestid = value;
				_diffArray[0] = true;
			}
		}
		public bool IsContentrequestidNull
		{
			get { return _contentrequestidNull; }
			set
			{
				_contentrequestidNull = value;
				_diffArray[0] = !value;
			}
		}
		public int Customerid
		{
			get { return _customerid; }
			set
			{
				_customeridNull = false;
				_customerid = value;
				_diffArray[1] = true;
			}
		}
		public bool IsCustomeridNull
		{
			get { return _customeridNull; }
			set
			{
				_customeridNull = value;
				_diffArray[1] = !value;
			}
		}
		public string Contenttypecode
		{
			get { return _contenttypecode; }
			set
			{
				_contenttypecodeNull = false;
				_contenttypecode = value;
				_diffArray[2] = true;
			}
		}
		public bool IsContenttypecodeNull
		{
			get { return _contenttypecodeNull; }
			set
			{
				_contenttypecodeNull = value;
				_diffArray[2] = !value;
			}
		}
		public int Requeststatuscode
		{
			get { return _requeststatuscode; }
			set
			{
				_requeststatuscodeNull = false;
				_requeststatuscode = value;
				_diffArray[3] = true;
			}
		}
		public bool IsRequeststatuscodeNull
		{
			get { return _requeststatuscodeNull; }
			set
			{
				_requeststatuscodeNull = value;
				_diffArray[3] = !value;
			}
		}
		public string Requesttypecode
		{
			get { return _requesttypecode; }
			set
			{
				_requesttypecodeNull = false;
				_requesttypecode = value;
				_diffArray[4] = true;
			}
		}
		public bool IsRequesttypecodeNull
		{
			get { return _requesttypecodeNull; }
			set
			{
				_requesttypecodeNull = value;
				_diffArray[4] = !value;
			}
		}
		public int Suggestedauthorid
		{
			get { return _suggestedauthorid; }
			set
			{
				_suggestedauthoridNull = false;
				_suggestedauthorid = value;
				_diffArray[5] = true;
			}
		}
		public bool IsSuggestedauthoridNull
		{
			get { return _suggestedauthoridNull; }
			set
			{
				_suggestedauthoridNull = value;
				_diffArray[5] = !value;
			}
		}
		public int Workrequestid
		{
			get { return _workrequestid; }
			set
			{
				_workrequestidNull = false;
				_workrequestid = value;
				_diffArray[6] = true;
			}
		}
		public bool IsWorkrequestidNull
		{
			get { return _workrequestidNull; }
			set
			{
				_workrequestidNull = value;
				_diffArray[6] = !value;
			}
		}
		public int Contentstatuscode
		{
			get { return _contentstatuscode; }
			set
			{
				_contentstatuscodeNull = false;
				_contentstatuscode = value;
				_diffArray[7] = true;
			}
		}
		public bool IsContentstatuscodeNull
		{
			get { return _contentstatuscodeNull; }
			set
			{
				_contentstatuscodeNull = value;
				_diffArray[7] = !value;
			}
		}
		public int Subscriptionid
		{
			get { return _subscriptionid; }
			set
			{
				_subscriptionidNull = false;
				_subscriptionid = value;
				_diffArray[8] = true;
			}
		}
		public bool IsSubscriptionidNull
		{
			get { return _subscriptionidNull; }
			set
			{
				_subscriptionidNull = value;
				_diffArray[8] = !value;
			}
		}
		public string Subscription
		{
			get { return _subscription; }
			set
			{
				_subscriptionNull = false;
				_subscription = value;
				_diffArray[9] = true;
			}
		}
		public bool IsSubscriptionNull
		{
			get { return _subscriptionNull; }
			set
			{
				_subscriptionNull = value;
				_diffArray[9] = !value;
			}
		}
		public string Requestcode
		{
			get { return _requestcode; }
			set
			{
				_requestcodeNull = false;
				_requestcode = value;
				_diffArray[10] = true;
			}
		}
		public bool IsRequestcodeNull
		{
			get { return _requestcodeNull; }
			set
			{
				_requestcodeNull = value;
				_diffArray[10] = !value;
			}
		}
		public string Name
		{
			get { return _name; }
			set
			{
				_nameNull = false;
				_name = value;
				_diffArray[11] = true;
			}
		}
		public bool IsNameNull
		{
			get { return _nameNull; }
			set
			{
				_nameNull = value;
				_diffArray[11] = !value;
			}
		}
		public DateTime Duedate
		{
			get { return _duedate; }
			set
			{
				_duedateNull = false;
				_duedate = value;
				_diffArray[12] = true;
			}
		}
		public bool IsDuedateNull
		{
			get { return _duedateNull; }
			set
			{
				_duedateNull = value;
				_diffArray[12] = !value;
			}
		}
		public string Datetimezone
		{
			get { return _datetimezone; }
			set
			{
				_datetimezoneNull = false;
				_datetimezone = value;
				_diffArray[13] = true;
			}
		}
		public bool IsDatetimezoneNull
		{
			get { return _datetimezoneNull; }
			set
			{
				_datetimezoneNull = value;
				_diffArray[13] = !value;
			}
		}
		public string Dateformat
		{
			get { return _dateformat; }
			set
			{
				_dateformatNull = false;
				_dateformat = value;
				_diffArray[14] = true;
			}
		}
		public bool IsDateformatNull
		{
			get { return _dateformatNull; }
			set
			{
				_dateformatNull = value;
				_diffArray[14] = !value;
			}
		}
		public string Directionalcontent
		{
			get { return _directionalcontent; }
			set
			{
				_directionalcontentNull = false;
				_directionalcontent = value;
				_diffArray[15] = true;
			}
		}
		public bool IsDirectionalcontentNull
		{
			get { return _directionalcontentNull; }
			set
			{
				_directionalcontentNull = value;
				_diffArray[15] = !value;
			}
		}
		public string Dcblogurl
		{
			get { return _dcblogurl; }
			set
			{
				_dcblogurlNull = false;
				_dcblogurl = value;
				_diffArray[16] = true;
			}
		}
		public bool IsDcblogurlNull
		{
			get { return _dcblogurlNull; }
			set
			{
				_dcblogurlNull = value;
				_diffArray[16] = !value;
			}
		}
		public string Dcpracticearea
		{
			get { return _dcpracticearea; }
			set
			{
				_dcpracticeareaNull = false;
				_dcpracticearea = value;
				_diffArray[17] = true;
			}
		}
		public bool IsDcpracticeareaNull
		{
			get { return _dcpracticeareaNull; }
			set
			{
				_dcpracticeareaNull = value;
				_diffArray[17] = !value;
			}
		}
		public string Dcgeography
		{
			get { return _dcgeography; }
			set
			{
				_dcgeographyNull = false;
				_dcgeography = value;
				_diffArray[18] = true;
			}
		}
		public bool IsDcgeographyNull
		{
			get { return _dcgeographyNull; }
			set
			{
				_dcgeographyNull = value;
				_diffArray[18] = !value;
			}
		}
		public string Dcinsforwriter
		{
			get { return _dcinsforwriter; }
			set
			{
				_dcinsforwriterNull = false;
				_dcinsforwriter = value;
				_diffArray[19] = true;
			}
		}
		public bool IsDcinsforwriterNull
		{
			get { return _dcinsforwriterNull; }
			set
			{
				_dcinsforwriterNull = value;
				_diffArray[19] = !value;
			}
		}
		public int Minwordcount
		{
			get { return _minwordcount; }
			set
			{
				_minwordcountNull = false;
				_minwordcount = value;
				_diffArray[20] = true;
			}
		}
		public bool IsMinwordcountNull
		{
			get { return _minwordcountNull; }
			set
			{
				_minwordcountNull = value;
				_diffArray[20] = !value;
			}
		}
		public int Maxwordcount
		{
			get { return _maxwordcount; }
			set
			{
				_maxwordcountNull = false;
				_maxwordcount = value;
				_diffArray[21] = true;
			}
		}
		public bool IsMaxwordcountNull
		{
			get { return _maxwordcountNull; }
			set
			{
				_maxwordcountNull = value;
				_diffArray[21] = !value;
			}
		}
		public bool Isenabled
		{
			get { return _isenabled; }
			set
			{
				_isenabledNull = false;
				_isenabled = value;
				_diffArray[22] = true;
			}
		}
		public bool IsIsenabledNull
		{
			get { return _isenabledNull; }
			set
			{
				_isenabledNull = value;
				_diffArray[22] = !value;
			}
		}
		public DateTime Createddate
		{
			get { return _createddate; }
			set
			{
				_createddateNull = false;
				_createddate = value;
				_diffArray[23] = true;
			}
		}
		public bool IsCreateddateNull
		{
			get { return _createddateNull; }
			set
			{
				_createddateNull = value;
				_diffArray[23] = !value;
			}
		}
		public int Createdby
		{
			get { return _createdby; }
			set
			{
				_createdbyNull = false;
				_createdby = value;
				_diffArray[24] = true;
			}
		}
		public bool IsCreatedbyNull
		{
			get { return _createdbyNull; }
			set
			{
				_createdbyNull = value;
				_diffArray[24] = !value;
			}
		}
		public DateTime Updateddate
		{
			get { return _updateddate; }
			set
			{
				_updateddateNull = false;
				_updateddate = value;
				_diffArray[25] = true;
			}
		}
		public bool IsUpdateddateNull
		{
			get { return _updateddateNull; }
			set
			{
				_updateddateNull = value;
				_diffArray[25] = !value;
			}
		}
		public int Updatedby
		{
			get { return _updatedby; }
			set
			{
				_updatedbyNull = false;
				_updatedby = value;
				_diffArray[26] = true;
			}
		}
		public bool IsUpdatedbyNull
		{
			get { return _updatedbyNull; }
			set
			{
				_updatedbyNull = value;
				_diffArray[26] = !value;
			}
		}
		public bool[] Diff()
		{
			return _diffArray;
		}
	}
}
