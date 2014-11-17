/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'RequestStatusError' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'RequeststatuserrorDALC' class.
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
	/// General database operations related to 'RequestStatusError' table
	/// </summary>
	public abstract class BaseRequeststatuserrorDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__statuserrorid">Primay key ID</param>
		/// <returns>
		/// RequeststatuserrorInfo object
		/// </returns>
		public static RequeststatuserrorInfo SelectByPK(int __statuserrorid)
		{ 
			RequeststatuserrorInfo _requeststatuserror = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectByPK", PKParameters(__statuserrorid));
			while (reader.Read())
				_requeststatuserror = RowToObject(reader,0);
			reader.Close();
			
			return _requeststatuserror;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__statuserrorid">Primay key ID</param>
		/// <returns>
		/// RequeststatuserrorInfo object
		/// </returns>
		public static RequeststatuserrorInfo SelectFullByPK(int __statuserrorid)
		{
			//TODO only returning basic object currently
			RequeststatuserrorInfo _requeststatuserror = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectFullByPK", PKParameters(__statuserrorid));
			while (reader.Read())
				_requeststatuserror = RowToObject(reader,0);
			reader.Close();
			
			return _requeststatuserror;		
		} 
		
		/// <summary>
		/// Get all records from 'RequestStatusError' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of RequeststatuserrorInfo objects.
		/// </returns>
		public static IList<RequeststatuserrorInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectAll");

			IList<RequeststatuserrorInfo> _items = new List<RequeststatuserrorInfo>();
			RequeststatuserrorInfo _requeststatuserror = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_requeststatuserror = RowToObject(reader,0);
				_items.Add(_requeststatuserror);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'RequestStatusError' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of RequeststatuserrorInfo objects.
		/// </returns>
		public static IList<RequeststatuserrorInfo> SelectAllFull()
		{	
			IList<RequeststatuserrorInfo> _items = new List<RequeststatuserrorInfo>();
			//RequeststatuserrorInfo _requeststatuserror = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'RequestStatusError' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<RequeststatuserrorInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectAllWhere", sqlParams);

			IList<RequeststatuserrorInfo> _items = new List<RequeststatuserrorInfo>();
			RequeststatuserrorInfo _requeststatuserror = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_requeststatuserror = RowToObject(reader,0);
				_items.Add(_requeststatuserror);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'RequestStatusError' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'RequestStatusError' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'RequestStatusError' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'RequestStatusError' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'RequestStatusError' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
		/// <returns>
		/// RequeststatuserrorInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static RequeststatuserrorInfo Insert(RequeststatuserrorInfo _requeststatuserror) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_Insert", InsertParameters(_requeststatuserror));
			_requeststatuserror.Statuserrorid = autoNumValue;
			
			return _requeststatuserror;
		}
		
		/// <summary>
		/// Update a record in 'RequestStatusError' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(RequeststatuserrorInfo _requeststatuserror)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_Update", UpdateParameters(_requeststatuserror));
		}

		/// <summary>
		/// Update record(s) in 'RequestStatusError' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(RequeststatuserrorInfo _requeststatuserror, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_UpdateAllWhere", UpdateAllWhereParameters(_requeststatuserror, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'RequestStatusError' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
		/// <param name="__contentrequestid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentrequestid(RequeststatuserrorInfo _requeststatuserror, int __contentrequestid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_requeststatuserror, 4);
			// Last parameter containing FK
   			sqlParams[4] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[4].Value = __contentrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_UpdateAllByFK_ContentRequestId", UpdateParameters(_requeststatuserror,4));
		}
		
		/// <summary>
		/// Update all records in 'RequestStatusError' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
		/// <param name="__errorid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKErrorid(RequeststatuserrorInfo _requeststatuserror, int __errorid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_requeststatuserror, 4);
			// Last parameter containing FK
   			sqlParams[4] = new SqlParameter("@ErrorId", SqlDbType.Int);
			sqlParams[4].Value = __errorid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_UpdateAllByFK_ErrorId", UpdateParameters(_requeststatuserror,4));
		}
		
		/// <summary>
		/// Delete a record in 'RequestStatusError' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__statuserrorid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __statuserrorid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_Delete", PKParameters(__statuserrorid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'RequestStatusError' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'RequestStatusError' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_DeleteAllByFK_ContentRequestId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'RequestStatusError' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="ErrorId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKErrorid(int __errorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@ErrorId", SqlDbType.Int);
			sqlParams[0].Value = __errorid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_DeleteAllByFK_ErrorId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'RequestStatusError' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static IList<RequeststatuserrorInfo> SelectAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", "SqlDbType.Int");
			sqlParams[0].Value = __contentrequestid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectAllByFK_ContentRequestId", sqlParams);

			IList<RequeststatuserrorInfo> _items = new List<RequeststatuserrorInfo>();
			RequeststatuserrorInfo _requeststatuserror = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_requeststatuserror = RowToObject(reader,0);
				_items.Add(_requeststatuserror);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'RequestStatusError' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'RequestStatusError' table matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static int CountAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_CountAllByFK_ContentRequestId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'RequestStatusError' table matching to the foreign key 'ErrorId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__errorid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ErrorId' foreign key value
		/// </returns>
		public static IList<RequeststatuserrorInfo> SelectAllByFKErrorid(int __errorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ErrorId", "SqlDbType.Int");
			sqlParams[0].Value = __errorid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectAllByFK_ErrorId", sqlParams);

			IList<RequeststatuserrorInfo> _items = new List<RequeststatuserrorInfo>();
			RequeststatuserrorInfo _requeststatuserror = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_requeststatuserror = RowToObject(reader,0);
				_items.Add(_requeststatuserror);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'RequestStatusError' table matching to the foreign key 'ErrorId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__errorid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'RequestStatusError' table matching with 'ErrorId' foreign key value
		/// </returns>
		public static int CountAllByFKErrorid(int __errorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ErrorId", SqlDbType.Int);
			sqlParams[0].Value = __errorid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_CountAllByFK_ErrorId", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'RequestStatusError' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'RequestStatusError' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'RequestStatusError' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'RequestStatusError' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "RequestStatusError_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to RequestStatusError object"
		/// <summary>
		/// Converts a data reader row to 'RequestStatusError' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'RequeststatuserrorInfo' type
		/// </returns>
		protected static RequeststatuserrorInfo RowToObject(SqlDataReader reader, int index)
		{
			RequeststatuserrorInfo _requeststatuserror = new RequeststatuserrorInfo();

			if (!reader.IsDBNull(index))
				_requeststatuserror.Statuserrorid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_requeststatuserror.Contentrequestid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_requeststatuserror.Errorid = reader.GetInt32(index);
			index = index + 1;
			
			return _requeststatuserror;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'RequestStatusError' table
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
		/// Private method used to build insert parameter array for 'RequestStatusError' table
		/// </summary>
		/// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(RequeststatuserrorInfo _requeststatuserror)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorId", SqlDbType.Int);								

			bool[] status = _requeststatuserror.Diff();

			if (status[1])
				sqlParams[1].Value = _requeststatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _requeststatuserror.Errorid;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'RequestStatusError' table
		/// </summary>
		/// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(RequeststatuserrorInfo _requeststatuserror)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorId", SqlDbType.Int);

			bool[] status = _requeststatuserror.Diff();
			
			if (status[0])
				sqlParams[0].Value = _requeststatuserror.Statuserrorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _requeststatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _requeststatuserror.Errorid;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'RequestStatusError' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(RequeststatuserrorInfo _requeststatuserror, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorId", SqlDbType.Int);

			bool[] status = _requeststatuserror.Diff();
			
			if (status[0])
				sqlParams[0].Value = _requeststatuserror.Statuserrorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _requeststatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _requeststatuserror.Errorid;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(RequeststatuserrorInfo _requeststatuserror, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[4];		
			sqlParams[0] = new SqlParameter("@StatusErrorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ErrorId", SqlDbType.Int);

			bool[] status = _requeststatuserror.Diff();
			
			if (status[0])
				sqlParams[0].Value = _requeststatuserror.Statuserrorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _requeststatuserror.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _requeststatuserror.Errorid;
			else
				sqlParams[2].Value = DBNull.Value;

   			sqlParams[3] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[3].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
