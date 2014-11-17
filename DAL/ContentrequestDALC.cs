/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Concrete class (data access component) for 'ContentRequest' table. For any
'  custom changes use this class instead of 'BaseContentrequestDALC' class.
'===============================================================================
*/
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Model;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class ContentrequestDALC : BaseContentrequestDALC
    {

        /// <summary>
        /// Insert a record in 'ContentRequest' table
        /// This method is available for tables who have primary key defined
        /// </summary>
        /// <param name="_contentrequest">ContentrequestInfo object</param>
        /// <returns>
        /// ContentrequestInfo object with any additional computed values such as 
        /// auto-number (identity) added to the object
        /// </returns>
        public static int InsertCustom(ContentrequestInfo _contentrequest)
        {
            int autoNumValue = -1;
            autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_InsertCustom", InsertParameters(_contentrequest));
            //_contentrequest.Contentrequestid = autoNumValue;

            return autoNumValue;
        }

        /// <summary>
        /// Get an object from database using primary key
        /// </summary>
        /// <param name="__contentrequestid">Primay key ID</param>
        /// <returns>
        /// ContentrequestInfo object
        /// </returns>
        public static ContentrequestInfo SelectByRequestCode(string requestCode)
        {
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@RequestCode", requestCode);

            ContentrequestInfo contentrequest = null;
            SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectByPKCustom", sqlParams);

            while (reader.Read())
                contentrequest = RowToObjectCustom(reader, 0);

            reader.Close();

            return contentrequest;
        }

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
        public static IList<ContentrequestInfo> SelectAllWhere(string _whereClause, string _searchClause, string _orderBy, int _pageNumber, int _pageSize)
        {
            SqlParameter[] sqlParams = new SqlParameter[5];
            sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
            sqlParams[0].Value = _whereClause;
            sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
            sqlParams[1].Value = _orderBy;
            sqlParams[2] = new SqlParameter("@pageNumber", SqlDbType.Int);
            sqlParams[2].Value = _pageNumber;
            sqlParams[3] = new SqlParameter("@pageSize", SqlDbType.Int);
            sqlParams[3].Value = _pageSize;
            sqlParams[4] = new SqlParameter("@searchClause", SqlDbType.VarChar);
            sqlParams[4].Value = _searchClause;

            SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllWhereCustom", sqlParams);

            IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
            ContentrequestInfo _cReq = null;

            //Create the items from the first row and subsequent rows
            while (reader.Read())
            {
                _cReq = RowToObjectWhereCustom(reader, 0);
                _items.Add(_cReq);
            }

            reader.Close();
            return _items;
        }

        /// <summary>
        /// Update record(s) in 'ContentRequest' table according to SQL WHERE condition.
        /// </summary>
        /// <param name="whereClause">SQL WHERE clause</param>
        /// <returns>
        /// Nothing
        /// </returns>
        public static void UpdateAllWhere(string setClause, string _whereClause)
        {
            SqlParameter[] sqlParams = new SqlParameter[2];
            sqlParams[0] = new SqlParameter("@setClause", SqlDbType.VarChar);
            sqlParams[0].Value = setClause;
            sqlParams[1] = new SqlParameter("@whereClause", SqlDbType.VarChar);
            sqlParams[1].Value = _whereClause;

            SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllWhereCustom", sqlParams);
        }

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
        public static IList<ContentrequestInfo> SelectContentRequestById(string _whereClause)
        {
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
            sqlParams[0].Value = _whereClause;

            SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_Export", sqlParams);

            IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
            ContentrequestInfo _cReq = null;

            //Create the items from the first row and subsequent rows
            while (reader.Read())
            {
                _cReq = RowToObjectExport(reader, 0);
                _items.Add(_cReq);
            }

            reader.Close();
            return _items;
        }

        /// <summary>
        /// Get a count of all records from 'ContentRequest' table filtered by the WHERE
        /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
        /// </summary>
        /// <param name="_whereClause">SQL WHERE clause</param>
        /// <returns>
        /// Number of records in 'ContentRequest' table matching with sql WHERE clause
        /// </returns>
        public static int CountAllWhereCustom(string _whereClause)
        {
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
            sqlParams[0].Value = _whereClause;

            return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllWhereCustom", sqlParams);
        }

        /// <summary>
        /// Private method used to build insert parameter array for 'ContentRequest' table
        /// </summary>
        /// <param name="_contentrequest">ContentrequestInfo object</param>
        /// <returns>
        /// SQL parameter array containing insert parameters
        /// </returns>
        private static SqlParameter[] InsertParameters(ContentrequestInfo _contentrequest)
        {
            SqlParameter[] sqlParams = new SqlParameter[26];
            sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
            sqlParams[1] = new SqlParameter("@CustomerId", SqlDbType.Int);
            sqlParams[2] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
            sqlParams[3] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
            sqlParams[4] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
            sqlParams[5] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
            sqlParams[6] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
            sqlParams[7] = new SqlParameter("@SubscriptionId", SqlDbType.Int);
            sqlParams[8] = new SqlParameter("@Subscription", SqlDbType.VarChar);
            sqlParams[9] = new SqlParameter("@RequestCode", SqlDbType.VarChar);
            sqlParams[10] = new SqlParameter("@Name", SqlDbType.VarChar);
            sqlParams[11] = new SqlParameter("@DueDate", SqlDbType.DateTime);
            sqlParams[12] = new SqlParameter("@DateTimeZone", SqlDbType.VarChar);
            sqlParams[13] = new SqlParameter("@DateFormat", SqlDbType.VarChar);
            sqlParams[14] = new SqlParameter("@DirectionalContent", SqlDbType.Text);
            sqlParams[15] = new SqlParameter("@DCBlogUrl", SqlDbType.VarChar);
            sqlParams[16] = new SqlParameter("@DCPracticeArea", SqlDbType.VarChar);
            sqlParams[17] = new SqlParameter("@DCGeography", SqlDbType.VarChar);
            sqlParams[18] = new SqlParameter("@DCInsForWriter", SqlDbType.VarChar);
            sqlParams[19] = new SqlParameter("@MinWordCount", SqlDbType.Int);
            sqlParams[20] = new SqlParameter("@MaxWordCount", SqlDbType.Int);
            sqlParams[21] = new SqlParameter("@CustomerName", SqlDbType.VarChar);
            sqlParams[22] = new SqlParameter("@ContentTypeName", SqlDbType.VarChar);
            sqlParams[23] = new SqlParameter("@RequestTypeName", SqlDbType.VarChar);
            sqlParams[24] = new SqlParameter("@SuggestedauthorNickname", SqlDbType.VarChar);
            sqlParams[25] = new SqlParameter("@suggestedauthorFullname", SqlDbType.VarChar);

            bool[] status = _contentrequest.Diff();

            sqlParams[1].Value = _contentrequest.Customerid;
            sqlParams[2].Value = _contentrequest.Contenttypecode;
            sqlParams[3].Value = _contentrequest.Requeststatuscode;
            sqlParams[4].Value = _contentrequest.Requesttypecode;
            sqlParams[5].Value = _contentrequest.Suggestedauthorid;
            sqlParams[6].Value = _contentrequest.Workrequestid;
            sqlParams[7].Value = _contentrequest.Subscriptionid;

            if (status[9])
                sqlParams[8].Value = _contentrequest.Subscription;
            else
                sqlParams[8].Value = DBNull.Value;

            sqlParams[9].Value = _contentrequest.Requestcode;
            sqlParams[10].Value = _contentrequest.Name;
            sqlParams[11].Value = _contentrequest.Duedate;
            sqlParams[12].Value = _contentrequest.Datetimezone;
            sqlParams[13].Value = _contentrequest.Dateformat;
            sqlParams[14].Value = _contentrequest.Directionalcontent;

            if (status[16])
                sqlParams[15].Value = _contentrequest.Dcblogurl;
            else
                sqlParams[15].Value = DBNull.Value;

            if (status[17])
                sqlParams[16].Value = _contentrequest.Dcpracticearea;
            else
                sqlParams[16].Value = DBNull.Value;

            if (status[18])
                sqlParams[17].Value = _contentrequest.Dcgeography;
            else
                sqlParams[17].Value = DBNull.Value;

            if (status[19])
                sqlParams[18].Value = _contentrequest.Dcinsforwriter;
            else
                sqlParams[18].Value = DBNull.Value;

            if (status[20])
                sqlParams[19].Value = _contentrequest.Minwordcount;
            else
                sqlParams[19].Value = DBNull.Value;

            if (status[21])
                sqlParams[20].Value = _contentrequest.Maxwordcount;
            else
                sqlParams[20].Value = DBNull.Value;

            if (status[24])
                sqlParams[24].Value = _contentrequest.Createdby;
            else
                sqlParams[24].Value = DBNull.Value;


            sqlParams[21].Value = _contentrequest.Customername;

            sqlParams[22].Value = _contentrequest.Contenttypename;

            sqlParams[23].Value = _contentrequest.Requesttypename;

            sqlParams[24].Value = _contentrequest.SuggestedauthorNickname;

            sqlParams[25].Value = _contentrequest.suggestedauthorFullname;


            return (sqlParams);
        }

        #region "Protected RowToObject method to convert data reader row to ContentRequest object"
        /// <summary>
        /// Converts a data reader row to 'ContentRequest' model/DTO object
        /// </summary>
        /// <param name="reader">Datareader containing usually a single record</param>
        /// <param name="index">Datareader field's starting index i.e. 0</param>		
        /// <returns>
        /// Object of 'ContentrequestInfo' type
        /// </returns>
        protected static ContentrequestInfo RowToObjectCustom(SqlDataReader reader, int index)
        {
            ContentrequestInfo _contentrequest = new ContentrequestInfo();

            if (!reader.IsDBNull(index))
                _contentrequest.Contentrequestid = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Customerid = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Contenttypecode = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Requeststatuscode = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Requesttypecode = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Suggestedauthorid = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Workrequestid = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Subscriptionid = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Subscription = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Requestcode = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Name = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Duedate = reader.GetDateTime(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Datetimezone = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Dateformat = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Directionalcontent = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Minwordcount = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Maxwordcount = reader.GetInt32(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Contenttypename = reader.GetString(index);
            index = index + 1;
            if (!reader.IsDBNull(index))
                _contentrequest.Requeststatus = reader.GetString(index);
            index = index + 1;

            return _contentrequest;
        }

        protected static ContentrequestInfo RowToObjectWhereCustom(SqlDataReader reader, int index)
        {
            ContentrequestInfo _contentrequest = new ContentrequestInfo();

            if (!reader.IsDBNull(index))
                _contentrequest.Contentrequestid = reader.GetInt32(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Contenttypecode = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Requeststatuscode = reader.GetInt32(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Workrequestid = reader.GetInt32(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Requestcode = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Name = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Customername = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Contenttypename = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Contentstatuscode = reader.GetInt32(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Requeststatus = reader.GetString(index);
            else _contentrequest.Requeststatus = string.Empty;
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Createdby = reader.GetInt32(index);
            index = index + 1;

            return _contentrequest;
        }

        protected static ContentrequestInfo RowToObjectExport(SqlDataReader reader, int index)
        {
            ContentrequestInfo _contentrequest = new ContentrequestInfo();

            if (!reader.IsDBNull(index))
                _contentrequest.Contentrequestid = reader.GetInt32(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Requestcode = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Name = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Contenttypename = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Subscriptionid = reader.GetInt32(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Duedate = reader.GetDateTime(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Dcpracticearea = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Dcgeography = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Dcblogurl = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentrequest.Dcinsforwriter = reader.GetString(index);
            index = index + 1;

            return _contentrequest;
        }

        #endregion
    }
}
