/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation
'  Concrete class (model) for 'ContentRequestCategory' table. For any custom
'  changes use this class  instead of 'BaseContentrequestcategoryInfo' class.
'===============================================================================
*/
using System;

namespace Model
{
    public class ContentrequestcategoryInfo : BaseContentrequestcategoryInfo
    {
        //Add any custom properties/methods here

        public ContentrequestcategoryInfo()
        { }

        public ContentrequestcategoryInfo(string category, string primaryUrl, string anchorText, string preferredKey)
        {
            Category = category;
            Categoryprimaryurl = primaryUrl;
            Categoryanchortext = anchorText;
            Categorypreferredkeyword = preferredKey;
        }
    }
}
