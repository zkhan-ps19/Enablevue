/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation
'  Concrete class (model) for 'WorkRequest' table. For any custom
'  changes use this class  instead of 'BaseWorkrequestInfo' class.
'===============================================================================
*/
using System;

namespace Model
{
    public class WorkrequestInfo : BaseWorkrequestInfo
    {
        //Add any custom properties/methods here
        public WorkrequestInfo()
        { }

        public WorkrequestInfo(int id, string requestKey, string name, string apiVersion)
        {
            Id = id;
            Requestkey = requestKey;
            Name = name;
            Apiversion = apiVersion;
        }
    }
}
