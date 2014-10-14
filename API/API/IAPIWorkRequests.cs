using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml.Linq;

namespace RESTfulAPI
{

    #region APIWorkRequests Interface

    [ServiceContract]
    public interface IAPIWorkRequests
    {
        /*
        /apihome/workrequests 				                (supports GET, POST)
        /apihome/workrequests/{id} 				            (supports GET, POST and PUT)
        /apihome/workequests/{id}/contentrequests 	        (supports GET)
        /apihome/workrequests/{id}/contentrequests/{id} 	(supports GET, PUT)

         */

        //POST operation
        [OperationContract]
        [WebInvoke(UriTemplate = "", Method = "POST")]
        XElement CreateWorkRequest(XElement data);

    }

    #endregion

}
