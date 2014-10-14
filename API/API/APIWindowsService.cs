using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;
using System.ServiceModel.Activation;
using BLL;
using Model;

namespace RESTfulAPI
{
    /// <summary>
    /// Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class APIWindowsService : IAPIWindowsService
    {
        string IAPIWindowsService.GetVersion()
        {
            return "1.0.0";
        }

        string IAPIWindowsService.Login(User user)
        {
            IList<UserInfo> lstUsers = Admin.User.SelectAllWhere("UserName = '" + user.UserName + "' and Password = '" + user.Password + "'", "");

            if (lstUsers.Count > 0)
            {
                IList<UsertokenInfo> lstUserTokenInfo = Admin.UserToken.SelectAllByFKUserid(lstUsers[0].Userid);

                if (lstUserTokenInfo.Count > 0)
                    return lstUserTokenInfo[0].Token;
                else
                {
                    UsertokenInfo objUserTokenInfo = new UsertokenInfo();

                    objUserTokenInfo.Userid = lstUsers[0].Userid;
                    objUserTokenInfo.Createdtime = System.DateTime.Now;
                    objUserTokenInfo.Token = System.String.Format("{0:X}", (lstUsers[0].Userid.ToString() + lstUsers[0].Firstname).GetHashCode()) + objUserTokenInfo.Createdtime.ToString("dd-mm-yyyy-hh-mm-ss");

                    Admin.UserToken.Insert(objUserTokenInfo);

                    return objUserTokenInfo.Token;
                }
            }
            else return "Incorrect UserName/Password.";
        }

        string IAPIWindowsService.SendEmail(Email email)
        {
            IList<UserInfo> lstUsers = Admin.User.SelectAllWhere("IsDefault='1'", "");

            if (lstUsers.Count > 0)
            {
                if (EVueSharedClass.SendEmail(lstUsers[0].Email, email.Subject, email.Body))
                    return "Message sent";
                else return "Message not sent";
            }
            else return "Message not sent";
        }
    }
}