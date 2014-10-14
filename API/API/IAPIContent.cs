using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Model;
using System.Xml.Linq;

namespace RESTfulAPI
{

    #region APIContent Interface

    [ServiceContract]
    public interface IAPIContent
    {
        /*
            /apihome/content 					(supports GET, POST)
            /apihome/content/{id} 				(supports GET, POST and PUT)
        */        

        //POST operation
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        string CreateContent(Content objContent);

        //Get Operation
        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        XElement GetContentbyid(string id);

        //PUT Operation
        [OperationContract]
        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        void UpdateContent(string id, XElement data);

        ////DELETE Operation
        //[OperationContract]
        //[WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        //void DeletePerson(string id);
    }

    #endregion

}
