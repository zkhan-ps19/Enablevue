/*
'===============================================================================
'  *** Model Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Model (also called DTO, Data Objects, Business Entities) generation
'  Concrete class (model) for 'Content' table. For any custom
'  changes use this class  instead of 'BaseContentInfo' class.
'===============================================================================
*/
using System;

namespace Model
{
    public class ContentInfo : BaseContentInfo
    {

        //Add any custom properties/methods here
        private string authorNickname;
        private string authorFullname;

        public string AuthorFullname
        {
            get { return authorFullname; }
            set { authorFullname = value; }
        }

        public string AuthorNickname
        {
            get { return authorNickname; }
            set { authorNickname = value; }
        }

    }

    public class Content
    {
        private string _subscriptionId;
        private string _authorName = string.Empty;
        private string _title = string.Empty;
        private string _contentdetail = string.Empty;
        private string _category = string.Empty;
        private string _source = string.Empty;

        public string SubscriptionId
        {
            get { return _subscriptionId; }
            set { _subscriptionId = value; }
        }

        public string AuthorName
        {
            get { return _authorName; }
            set { _authorName = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public string Contentdetail
        {
            get { return _contentdetail; }
            set { _contentdetail = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

    }
}
