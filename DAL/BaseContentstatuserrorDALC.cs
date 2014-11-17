/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'ContentStatusError' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContentstatuserrorDALC' class.
'
'  NEVER EDIT THIS FILE.
'===============================================================================
*/
using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

using Model;

namespace DAL
{
	/// <summary>
	/// General database operations related to 'ContentStatusError' table
	/// </summary>
	public abstract class BaseContentstatuserrorDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__statuserrorid">Primay key ID</param>
		/// <returns>
		/// ContentstatuserrorInfo object
		/// </returns>
		public static ContentstatuserrorInfo SelectByPK(int __statuserrorid)
		{ 
			ContentstatuserrorInfo _contentstatuserror = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectByPK", PKParameters(__statuserrorid));
			while (reader.Read())
				_contentstatuserror = RowToObject(reader,0);
			reader.Close();
			
			return _contentstatuserror;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__statuserrorid">Primay key ID</param>
		/// <returns>
		/// ContentstatuserrorInfo object
		/// </returns>
		public static ContentstatuserrorInfo SelectFullByPK(int __statuserrorid)
		{
			//TODO only returning basic object currently
			ContentstatuserrorInfo _contentstatuserror = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectFullByPK", PKParameters(__statuserrorid));
			while (reader.Read())
				_contentstatuserror = RowToObject(reader,0);
			reader.Close();
			
			return _contentstatuserror;		
		} 
		
		/// <summary>
		/// Get all records from 'ContentStatusError' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentstatuserrorInfo objects.
		/// </returns>
		public static IList<ContentstatuserrorInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectAll");

			IList<ContentstatuserrorInfo> _items = new List<ContentstatuserrorInfo>();
			ContentstatuserrorInfo _contentstatuserror = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentstatuserror = RowToObject(reader,0);
				_items.Add(_contentstatuserror);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'ContentStatusError' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentstatuserrorInfo objects.
		/// </returns>
		public static IList<ContentstatuserrorInfo> SelectAllFull()
		{	
			IList<ContentstatuserrorInfo> _items = new List<ContentstatuserrorInfo>();
			//ContentstatuserrorInfo _contentstatuserror = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'ContentStatusError' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ContentstatuserrorInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectAllWhere", sqlParams);

			IList<ContentstatuserrorInfo> _items = new List<ContentstatuserrorInfo>();
			ContentstatuserrorInfo _contentstatuserror = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentstatuserror = RowToObject(reader,0);
				_items.Add(_contentstatuserror);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'ContentStatusError' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'ContentStatusError' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'ContentStatusError' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'ContentStatusError' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'ContentStatusError' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
		/// <returns>
		/// ContentstatuserrorInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ContentstatuserrorInfo Insert(ContentstatuserrorInfo _contentstatuserror) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_Insert", InsertParameters(_contentstatuserror));
			_contentstatuserror.Statuserrorid = autoNumValue;
			
			return _contentstatuserror;
		}
		
		/// <summary>
		/// Update a record in 'ContentStatusError' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContentstatuserrorInfo _contentstatuserror)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_Update", UpdateParameters(_contentstatuserror));
		}

		/// <summary>
		/// Update record(s) in 'ContentStatusError' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContentstatuserrorInfo _contentstatuserror, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_UpdateAllWhere", UpdateAllWhereParameters(_contentstatuserror, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'ContentStatusError' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
		/// <param name="__contentrequestid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentrequestid(ContentstatuserrorInfo _contentstatuserror, int __contentrequestid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentstatuserror, 5);
			// Last parameter containing FK
   			sqlParams[5] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[5].Value = __contentrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_UpdateAllByFK_ContentRequestId", UpdateParameters(_contentstatuserror,5));
		}
		
		/// <summary>
		/// Delete a record in 'ContentStatusError' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__statuserrorid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __statuserrorid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_Delete", PKParameters(__statuserrorid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'ContentStatusError' table according to SQL WHERE condition
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
		/// </summary>
		/// <param name="wQuery">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'ContentStatusError' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="ContentRequestId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_DeleteAllByFK_ContentRequestId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentStatusError' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static IList<ContentstatuserrorInfo> SelectAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", "SqlDbType.Int");
			sqlParams[0].Value = __contentrequestid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectAllByFK_ContentRequestId", sqlParams);

			IList<ContentstatuserrorInfo> _items = new List<ContentstatuserrorInfo>();
			ContentstatuserrorInfo _contentstatuserror = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentstatuserror = RowToObject(reader,0);
				_items.Add(_contentstatuserror);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentStatusError' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentStatusError' table matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static int CountAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_CountAllByFK_ContentRequestId", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'ContentStatusError' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'ContentStatusError' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'ContentStatusError' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'ContentStatusError' table filtered
		/// by the WHERE clause provided to the method
		/// </returns>
		public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentStatusError_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to ContentStatusError object"
		/// <summary>
		/// Converts a data reader row to 'ContentStatusError' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContentstatuserrorInfo' type
		/// </returns>
		protected static ContentstatuserrorInfo RowToObject(SqlDataReader reader, int index)
		{
			ContentstatuserrorInfo _contentstatuserror = new ContentstatuserrorInfo();

			if (!reader.IsDBNull(index))
				_contentstatuserror.Statuserrorid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentstatuserror.Contentrequestid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentstatuserror.Errorcode = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentstatuserror.Description = reader.GetString(index);
			index = index + 1;
			
			return _contentstatuserror;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'ContentStatusError' table
		/// </summary>
		/// <param name="__statuserrorid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __statuserrorid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[0].Value = __statuserrorid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'ContentStatusError' table
		/// </summary>
		/// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ContentstatuserrorInfo _contentstatuserror)
		{
			SqlParameter[] sqlParams = new SqlParameter[4];		
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@Description", SqlDbType.VarChar);								

			bool[] status = _contentstatuserror.Diff();

			if (status[1])
				sqlParams[1].Value = _contentstatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatuserror.Errorcode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentstatuserror.Description;
			else
				sqlParams[3].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'ContentStatusError' table
		/// </summary>
		/// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContentstatuserrorInfo _contentstatuserror)
		{
			SqlParameter[] sqlParams = new SqlParameter[4];		
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _contentstatuserror.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentstatuserror.Statuserrorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentstatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatuserror.Errorcode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentstatuserror.Description;
			else
				sqlParams[3].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'ContentStatusError' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContentstatuserrorInfo _contentstatuserror, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _contentstatuserror.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentstatuserror.Statuserrorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentstatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatuserror.Errorcode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentstatuserror.Description;
			else
				sqlParams[3].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContentstatuserrorInfo _contentstatuserror, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[5];		
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _contentstatuserror.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentstatuserror.Statuserrorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentstatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatuserror.Errorcode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentstatuserror.Description;
			else
				sqlParams[3].Value = DBNull.Value;

   			sqlParams[4] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[4].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
