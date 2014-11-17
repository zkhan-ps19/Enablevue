using System.Collections.Generic;
/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Concrete class (data access component) for 'User' table. For any
'  custom changes use this class instead of 'BaseUserDALC' class.
'===============================================================================
*/
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Model;

namespace DAL
{
    public class UserDALC : BaseUserDALC
    {
        //Add any custom properties/methods here

        /// <summary>
        /// Get all records from 'VRMSUser' table, filtered by where clause
        /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
        /// </summary>
        /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
        /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
        /// <returns>
        /// IList containing an ordered collection of objects filtered by the WHERE
        /// clause provided to the method
        /// </returns>
        public static IList<UserInfo> SelectAllWhere(string _whereClause, string _orderBy, int _pageNumber, int _pageSize)
        {
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
            sqlParams[0].Value = _whereClause;
            sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
            sqlParams[1].Value = _orderBy;
            sqlParams[2] = new SqlParameter("@pageNumber", SqlDbType.Int);
            sqlParams[2].Value = _pageNumber;
            sqlParams[3] = new SqlParameter("@pageSize", SqlDbType.Int);
            sqlParams[3].Value = _pageSize;

            SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectAllWhereCustom", sqlParams);

            IList<UserInfo> _items = new List<UserInfo>();
            UserInfo _user = null;

            //Create the items from the first row and subsequent rows
            while (reader.Read())
            {
                _user = RowToObjectCustom(reader, 0);
                _items.Add(_user);
            }
            reader.Close();
            return _items;
        }

        #region "Protected RowToObject method to convert data reader row to VRMSUser object"
        /// <summary>
        /// Converts a data reader row to 'VRMSUser' model/DTO object
        /// </summary>
        /// <param name="reader">Datareader containing usually a single record</param>
        /// <param name="index">Datareader field's starting index i.e. 0</param>		
        /// <returns>
        /// Object of 'VrmsuserInfo' type
        /// </returns>
        protected static UserInfo RowToObjectCustom(SqlDataReader reader, int index)
        {
            UserInfo _user = new UserInfo();

            if (!reader.IsDBNull(index))
                _user.Userid = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _user.Username = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _user.Firstname = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _user.Isenabled = reader.GetBoolean(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _user.Isadminright = reader.GetBoolean(index);
            index = index + 1;

            return _user;
        }
        #endregion
    }
}
