/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation
'  Concrete class (model) for 'ContentRequest' table. For any custom
'  changes use this class  instead of 'BaseContentrequestInfo' class.
'===============================================================================
*/
using System;

namespace Model
{
    public class ContentrequestInfo : BaseContentrequestInfo
    {
        //Add any custom properties/methods here
        private string customername;
        private string contenttypename;
        private string requesttypename;
        private string suggestedauthornickname;
        private string suggestedauthorfullname;
        private string requeststatus;

        public string Requeststatus
        {
            get { return requeststatus; }
            set { requeststatus = value; }
        }
        

        public string suggestedauthorFullname
        {
            get { return suggestedauthorfullname; }
            set { suggestedauthorfullname = value; }
        }
        

        public string SuggestedauthorNickname
        {
            get { return suggestedauthornickname; }
            set { suggestedauthornickname = value; }
        }

        public string Requesttypename
        {
            get { return requesttypename; }
            set { requesttypename = value; }
        }

        public string Contenttypename
        {
            get { return contenttypename; }
            set { contenttypename = value; }
        }

        public string Customername
        {
            get { return customername; }
            set { customername = value; }
        }

    }
}
