/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Concrete class (data access component) for 'Content' table. For any
'  custom changes use this class instead of 'BaseContentDALC' class.
'===============================================================================
*/
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections.Generic;
using Model;

namespace DAL
{
    public class ContentDALC : BaseContentDALC
    {
        //Add any custom properties/methods here

        /// <summary>
        /// Get all records from 'Content' table, filtered by where clause
        /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
        /// </summary>
        /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
        /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
        /// <returns>
        /// IList containing an ordered collection of objects filtered by the WHERE
        /// clause provided to the method
        /// </returns>
        public static IList<ContentInfo> SelectAllWhereCustom(string _whereClause, string _orderBy)
        {
            SqlParameter[] sqlParams = new SqlParameter[2];
            sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
            sqlParams[0].Value = _whereClause;
            sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
            sqlParams[1].Value = _orderBy;

            SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAllWhereCustom", sqlParams);

            IList<ContentInfo> _items = new List<ContentInfo>();
            ContentInfo _content = null;

            //Create the items from the first row and subsequent rows
            while (reader.Read())
            {
                _content = RowToObjectCustom(reader, 0);
                _items.Add(_content);
            }
            reader.Close();
            return _items;
        }

        /// <summary>
        /// Insert a record in 'Content' table
        /// This method is available for tables who have primary key defined
        /// </summary>
        /// <param name="_content">ContentInfo object</param>
        /// <returns>
        /// ContentInfo object with any additional computed values such as 
        /// auto-number (identity) added to the object
        /// </returns>
        public static int Insert(Model.Content objContent, int contentRequestId)
        {
            SqlParameter[] sqlParams = new SqlParameter[6];

            sqlParams[0] = new SqlParameter("@ContentRequestId", contentRequestId);
            sqlParams[1] = new SqlParameter("@AuthorName", objContent.AuthorName);
            sqlParams[2] = new SqlParameter("@Title", objContent.Title);
            sqlParams[3] = new SqlParameter("@Source", objContent.Source);
            sqlParams[4] = new SqlParameter("@ContentDetail", objContent.Contentdetail);
            sqlParams[5] = new SqlParameter("@Category", objContent.Category);

            return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Content_InsertCustom", sqlParams);
        }

        #region "Protected RowToObject method to convert data reader row to Content object"
        /// <summary>
        /// Converts a data reader row to 'Content' model/DTO object
        /// </summary>
        /// <param name="reader">Datareader containing usually a single record</param>
        /// <param name="index">Datareader field's starting index i.e. 0</param>		
        /// <returns>
        /// Object of 'ContentInfo' type
        /// </returns>
        protected static ContentInfo RowToObjectCustom(SqlDataReader reader, int index)
        {
            ContentInfo _content = new ContentInfo();

            if (!reader.IsDBNull(index))
                _content.Contentid = reader.GetInt32(index);
            index = index + 1;
           
            if (!reader.IsDBNull(index))
                _content.Contentrequestid = reader.GetInt32(index);
            index = index + 1;
           
            if (!reader.IsDBNull(index))
                _content.Authorid = reader.GetInt32(index);
            index = index + 1;
            
            if (!reader.IsDBNull(index))
                _content.Title = reader.GetString(index);
            index = index + 1;
            
            if (!reader.IsDBNull(index))
                _content.Source = reader.GetString(index);
            index = index + 1;
           
            if (!reader.IsDBNull(index))
                _content.Contentdetail = reader.GetString(index);
            index = index + 1;
            
            if (!reader.IsDBNull(index))
                _content.Category = reader.GetString(index);
            index = index + 1;
            
            if (!reader.IsDBNull(index))
                _content.AuthorFullname = reader.GetString(index);
            index = index + 1;
            
            //if (!reader.IsDBNull(index))
            //    _content.AuthorNickname = reader.GetString(index);
            //index = index + 1;

            return _content;
        }
        #endregion
    }
}
