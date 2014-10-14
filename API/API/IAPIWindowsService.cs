using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Model;
using System.Xml.Linq;

namespace RESTfulAPI
{

    #region APIContent Interface

    [ServiceContract]
    public interface IAPIWindowsService
    {
        /*
            /apihome/content 					(supports GET, POST)
            /apihome/content/{id} 				(supports GET, POST and PUT)
        */

        //Get Operation
        /// <summary>
        /// self understanding Return All Objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "version/")]
        string GetVersion();

        //POST operation
        [OperationContract]
        [WebInvoke(UriTemplate = "login/", Method = "POST")]
        string Login(User user);

        //POST operation
        [OperationContract]
        [WebInvoke(UriTemplate = "sendemail/", Method = "POST")]
        string SendEmail(Email email);

    }

    #endregion

    #region

    public class User
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }

    public class Email
    {
        private string _subject;
        private string _body;

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
    }

    #endregion

}
