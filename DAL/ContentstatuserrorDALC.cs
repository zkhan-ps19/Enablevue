/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Concrete class (data access component) for 'ContentStatusError' table. For any
'  custom changes use this class instead of 'BaseContentstatuserrorDALC' class.
'===============================================================================
*/
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Model;
using System.Collections.Generic;

namespace DAL
{
    public class ContentstatuserrorDALC : BaseContentstatuserrorDALC
    {
        //Add any custom properties/methods here

        /// <summary>
        /// Get all records from 'ContentStatusError' table matching to the foreign key 'ContentRequestId'
        /// This method is generated for tables who have foreign key(s)
        /// </summary>
        /// <param name="__contentrequestid">Foreign key value</param>
        /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
        /// <returns>
        /// Collection of objects matching with 'ContentRequestId' foreign key value
        /// </returns>
        public static IList<ErrorsInfo> SelectAllByFKContentrequestidCustom(int __contentrequestid)
        {
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@ContentRequestId", "SqlDbType.Int");
            sqlParams[0].Value = __contentrequestid;

            SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectAllByFK_ContentRequestIdCustom", sqlParams);

            IList<ErrorsInfo> _items = new List<ErrorsInfo>();
            ErrorsInfo _contentstatuserror = null;

            //Create the items from the first row and subsequent rows
            while (reader.Read())
            {
                _contentstatuserror = RowToObjectCustom(reader, 0);
                _items.Add(_contentstatuserror);
            }
            reader.Close();
            return _items;
        }

        /// <summary>
        /// Converts a data reader row to 'ContentStatusError' model/DTO object
        /// </summary>
        /// <param name="reader">Datareader containing usually a single record</param>
        /// <param name="index">Datareader field's starting index i.e. 0</param>		
        /// <returns>
        /// Object of 'ContentstatuserrorInfo' type
        /// </returns>
        protected static ErrorsInfo RowToObjectCustom(SqlDataReader reader, int index)
        {
            ErrorsInfo _contentstatuserror = new ErrorsInfo();

            if (!reader.IsDBNull(index))
                _contentstatuserror.Code = reader.GetString(index);
            index = index + 1;

            if (!reader.IsDBNull(index))
                _contentstatuserror.Description = reader.GetString(index);
            index = index + 1;

            return _contentstatuserror;
        }
    }
}
