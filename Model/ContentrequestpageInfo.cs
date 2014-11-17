/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation
'  Concrete class (model) for 'ContentRequestPage' table. For any custom
'  changes use this class  instead of 'BaseContentrequestpageInfo' class.
'===============================================================================
*/
using System;

namespace Model
{
    public class ContentrequestpageInfo : BaseContentrequestpageInfo
    {
        //Add any custom properties/methods here

        public ContentrequestpageInfo()
        { }

        public ContentrequestpageInfo(int contentrequestid, int id, bool isContentRequired, string pageTitle, string pageUrl, string pageInstruction)
        {
            Contentrequestid = contentrequestid;

            Id = id;
            Iscontentrequired = isContentRequired;
            Pagetitle = pageTitle;
            Pageurl = pageUrl;
            Pageinstruction = pageInstruction;
        }

        public ContentrequestpageInfo(int id, bool isContentRequired, string pageTitle, string pageUrl, string pageInstruction)
        {
            Id = id;
            Iscontentrequired = isContentRequired;
            Pagetitle = pageTitle;
            Pageurl = pageUrl;
            Pageinstruction = pageInstruction;
        }

        public ContentrequestpageInfo(int id, bool isContentRequired, string pageTitle, string pageUrl)
        {
            Id = id;
            Iscontentrequired = isContentRequired;
            Pagetitle = pageTitle;
            Pageurl = pageUrl;
        }
    }
}
