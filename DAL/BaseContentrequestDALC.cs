/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'ContentRequest' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContentrequestDALC' class.
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
	/// General database operations related to 'ContentRequest' table
	/// </summary>
	public abstract class BaseContentrequestDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__contentrequestid">Primay key ID</param>
		/// <returns>
		/// ContentrequestInfo object
		/// </returns>
		public static ContentrequestInfo SelectByPK(int __contentrequestid)
		{ 
			ContentrequestInfo _contentrequest = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectByPK", PKParameters(__contentrequestid));
			while (reader.Read())
				_contentrequest = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequest;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestid">Primay key ID</param>
		/// <returns>
		/// ContentrequestInfo object
		/// </returns>
		public static ContentrequestInfo SelectFullByPK(int __contentrequestid)
		{
			//TODO only returning basic object currently
			ContentrequestInfo _contentrequest = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectFullByPK", PKParameters(__contentrequestid));
			while (reader.Read())
				_contentrequest = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequest;		
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequest' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestInfo objects.
		/// </returns>
		public static IList<ContentrequestInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAll");

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'ContentRequest' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestInfo objects.
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllFull()
		{	
			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			//ContentrequestInfo _contentrequest = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequest' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllWhere", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'ContentRequest' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'ContentRequest' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'ContentRequest' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'ContentRequest' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <returns>
		/// ContentrequestInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ContentrequestInfo Insert(ContentrequestInfo _contentrequest) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_Insert", InsertParameters(_contentrequest));
			_contentrequest.Contentrequestid = autoNumValue;
			
			return _contentrequest;
		}
		
		/// <summary>
		/// Update a record in 'ContentRequest' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContentrequestInfo _contentrequest)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_Update", UpdateParameters(_contentrequest));
		}

		/// <summary>
		/// Update record(s) in 'ContentRequest' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContentrequestInfo _contentrequest, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllWhere", UpdateAllWhereParameters(_contentrequest, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__customerid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKCustomerid(ContentrequestInfo _contentrequest, int __customerid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[28].Value = __customerid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_CustomerId", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__contenttypecode">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContenttypecode(ContentrequestInfo _contentrequest, string __contenttypecode)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[28].Value = __contenttypecode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_ContentTypeCode", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__requeststatuscode">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKRequeststatuscode(ContentrequestInfo _contentrequest, int __requeststatuscode)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
			sqlParams[28].Value = __requeststatuscode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_RequestStatusCode", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__requesttypecode">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKRequesttypecode(ContentrequestInfo _contentrequest, string __requesttypecode)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[28].Value = __requesttypecode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_RequestTypeCode", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__suggestedauthorid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKSuggestedauthorid(ContentrequestInfo _contentrequest, int __suggestedauthorid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
			sqlParams[28].Value = __suggestedauthorid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_SuggestedAuthorId", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__workrequestid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKWorkrequestid(ContentrequestInfo _contentrequest, int __workrequestid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
			sqlParams[28].Value = __workrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_WorkRequestId", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__contentstatuscode">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentstatuscode(ContentrequestInfo _contentrequest, int __contentstatuscode)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[28].Value = __contentstatuscode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_ContentStatusCode", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__createdby">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKCreatedby(ContentrequestInfo _contentrequest, int __createdby)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@CreatedBy", SqlDbType.Int);
			sqlParams[28].Value = __createdby;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_CreatedBy", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequest' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <param name="__updatedby">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKUpdatedby(ContentrequestInfo _contentrequest, int __updatedby)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequest, 28);
			// Last parameter containing FK
   			sqlParams[28] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[28].Value = __updatedby;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_UpdateAllByFK_UpdatedBy", UpdateParameters(_contentrequest,28));
		}
		
		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__contentrequestid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __contentrequestid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_Delete", PKParameters(__contentrequestid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'ContentRequest' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="CustomerId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKCustomerid(int __customerid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[0].Value = __customerid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_CustomerId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="ContentTypeCode">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKContenttypecode(string __contenttypecode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[0].Value = __contenttypecode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_ContentTypeCode", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="RequestStatusCode">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKRequeststatuscode(int __requeststatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
			sqlParams[0].Value = __requeststatuscode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_RequestStatusCode", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="RequestTypeCode">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKRequesttypecode(string __requesttypecode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[0].Value = __requesttypecode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_RequestTypeCode", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="SuggestedAuthorId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKSuggestedauthorid(int __suggestedauthorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
			sqlParams[0].Value = __suggestedauthorid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_SuggestedAuthorId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="WorkRequestId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKWorkrequestid(int __workrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
			sqlParams[0].Value = __workrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_WorkRequestId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="ContentStatusCode">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKContentstatuscode(int __contentstatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[0].Value = __contentstatuscode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_ContentStatusCode", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="CreatedBy">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKCreatedby(int __createdby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@CreatedBy", SqlDbType.Int);
			sqlParams[0].Value = __createdby;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_CreatedBy", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'ContentRequest' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="UpdatedBy">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[0].Value = __updatedby;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_DeleteAllByFK_UpdatedBy", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'CustomerId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__customerid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'CustomerId' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKCustomerid(int __customerid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CustomerId", "SqlDbType.Int");
			sqlParams[0].Value = __customerid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_CustomerId", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'CustomerId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__customerid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'CustomerId' foreign key value
		/// </returns>
		public static int CountAllByFKCustomerid(int __customerid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[0].Value = __customerid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_CustomerId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'ContentTypeCode'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contenttypecode">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentTypeCode' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKContenttypecode(string __contenttypecode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentTypeCode", "SqlDbType.VarChar");
			sqlParams[0].Value = __contenttypecode;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_ContentTypeCode", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'ContentTypeCode'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contenttypecode">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'ContentTypeCode' foreign key value
		/// </returns>
		public static int CountAllByFKContenttypecode(string __contenttypecode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[0].Value = __contenttypecode;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_ContentTypeCode", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'RequestStatusCode'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__requeststatuscode">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'RequestStatusCode' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKRequeststatuscode(int __requeststatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@RequestStatusCode", "SqlDbType.Int");
			sqlParams[0].Value = __requeststatuscode;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_RequestStatusCode", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'RequestStatusCode'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__requeststatuscode">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'RequestStatusCode' foreign key value
		/// </returns>
		public static int CountAllByFKRequeststatuscode(int __requeststatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
			sqlParams[0].Value = __requeststatuscode;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_RequestStatusCode", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'RequestTypeCode'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__requesttypecode">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'RequestTypeCode' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKRequesttypecode(string __requesttypecode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@RequestTypeCode", "SqlDbType.VarChar");
			sqlParams[0].Value = __requesttypecode;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_RequestTypeCode", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'RequestTypeCode'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__requesttypecode">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'RequestTypeCode' foreign key value
		/// </returns>
		public static int CountAllByFKRequesttypecode(string __requesttypecode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[0].Value = __requesttypecode;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_RequestTypeCode", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'SuggestedAuthorId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__suggestedauthorid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'SuggestedAuthorId' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKSuggestedauthorid(int __suggestedauthorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@SuggestedAuthorId", "SqlDbType.Int");
			sqlParams[0].Value = __suggestedauthorid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_SuggestedAuthorId", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'SuggestedAuthorId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__suggestedauthorid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'SuggestedAuthorId' foreign key value
		/// </returns>
		public static int CountAllByFKSuggestedauthorid(int __suggestedauthorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
			sqlParams[0].Value = __suggestedauthorid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_SuggestedAuthorId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'WorkRequestId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__workrequestid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'WorkRequestId' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKWorkrequestid(int __workrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@WorkRequestId", "SqlDbType.Int");
			sqlParams[0].Value = __workrequestid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_WorkRequestId", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'WorkRequestId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__workrequestid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'WorkRequestId' foreign key value
		/// </returns>
		public static int CountAllByFKWorkrequestid(int __workrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
			sqlParams[0].Value = __workrequestid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_WorkRequestId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'ContentStatusCode'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentstatuscode">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentStatusCode' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKContentstatuscode(int __contentstatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentStatusCode", "SqlDbType.Int");
			sqlParams[0].Value = __contentstatuscode;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_ContentStatusCode", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'ContentStatusCode'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentstatuscode">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'ContentStatusCode' foreign key value
		/// </returns>
		public static int CountAllByFKContentstatuscode(int __contentstatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[0].Value = __contentstatuscode;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_ContentStatusCode", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'CreatedBy'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__createdby">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'CreatedBy' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKCreatedby(int __createdby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CreatedBy", "SqlDbType.Int");
			sqlParams[0].Value = __createdby;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_CreatedBy", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'CreatedBy'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__createdby">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'CreatedBy' foreign key value
		/// </returns>
		public static int CountAllByFKCreatedby(int __createdby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CreatedBy", SqlDbType.Int);
			sqlParams[0].Value = __createdby;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_CreatedBy", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequest' table matching to the foreign key 'UpdatedBy'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__updatedby">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'UpdatedBy' foreign key value
		/// </returns>
		public static IList<ContentrequestInfo> SelectAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UpdatedBy", "SqlDbType.Int");
			sqlParams[0].Value = __updatedby;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllByFK_UpdatedBy", sqlParams);

			IList<ContentrequestInfo> _items = new List<ContentrequestInfo>();
			ContentrequestInfo _contentrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequest = RowToObject(reader,0);
				_items.Add(_contentrequest);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequest' table matching to the foreign key 'UpdatedBy'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__updatedby">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequest' table matching with 'UpdatedBy' foreign key value
		/// </returns>
		public static int CountAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[0].Value = __updatedby;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_CountAllByFK_UpdatedBy", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'ContentRequest' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'ContentRequest' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'ContentRequest' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'ContentRequest' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequest_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to ContentRequest object"
		/// <summary>
		/// Converts a data reader row to 'ContentRequest' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContentrequestInfo' type
		/// </returns>
		protected static ContentrequestInfo RowToObject(SqlDataReader reader, int index)
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
				_contentrequest.Contentstatuscode = reader.GetInt32(index);
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
				_contentrequest.Dcblogurl = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Dcpracticearea = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Dcgeography = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Dcinsforwriter = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Minwordcount = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Maxwordcount = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Isenabled = reader.GetBoolean(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Createddate = reader.GetDateTime(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Createdby = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Updateddate = reader.GetDateTime(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequest.Updatedby = reader.GetInt32(index);
			index = index + 1;
			
			return _contentrequest;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'ContentRequest' table
		/// </summary>
		/// <param name="__contentrequestid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __contentrequestid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;

			return(sqlParams);
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
			SqlParameter[] sqlParams = new SqlParameter[27];		
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
			sqlParams[4] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
			sqlParams[6] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[8] = new SqlParameter("@SubscriptionId", SqlDbType.Int);
			sqlParams[9] = new SqlParameter("@Subscription", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@RequestCode", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[12] = new SqlParameter("@DueDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@DateTimeZone", SqlDbType.VarChar);
			sqlParams[14] = new SqlParameter("@DateFormat", SqlDbType.VarChar);
			sqlParams[15] = new SqlParameter("@DirectionalContent", SqlDbType.Text);
			sqlParams[16] = new SqlParameter("@DCBlogUrl", SqlDbType.VarChar);
			sqlParams[17] = new SqlParameter("@DCPracticeArea", SqlDbType.VarChar);
			sqlParams[18] = new SqlParameter("@DCGeography", SqlDbType.VarChar);
			sqlParams[19] = new SqlParameter("@DCInsForWriter", SqlDbType.VarChar);
			sqlParams[20] = new SqlParameter("@MinWordCount", SqlDbType.Int);
			sqlParams[21] = new SqlParameter("@MaxWordCount", SqlDbType.Int);
			sqlParams[22] = new SqlParameter("@IsEnabled", SqlDbType.Bit);
			sqlParams[23] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
			sqlParams[25] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[26] = new SqlParameter("@UpdatedBy", SqlDbType.Int);								

			bool[] status = _contentrequest.Diff();

			if (status[1])
				sqlParams[1].Value = _contentrequest.Customerid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequest.Contenttypecode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequest.Requeststatuscode;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequest.Requesttypecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequest.Suggestedauthorid;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequest.Workrequestid;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _contentrequest.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _contentrequest.Subscriptionid;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _contentrequest.Subscription;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _contentrequest.Requestcode;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _contentrequest.Name;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _contentrequest.Duedate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _contentrequest.Datetimezone;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _contentrequest.Dateformat;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _contentrequest.Directionalcontent;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _contentrequest.Dcblogurl;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _contentrequest.Dcpracticearea;
			else
				sqlParams[17].Value = DBNull.Value;
			if (status[18])
				sqlParams[18].Value = _contentrequest.Dcgeography;
			else
				sqlParams[18].Value = DBNull.Value;
			if (status[19])
				sqlParams[19].Value = _contentrequest.Dcinsforwriter;
			else
				sqlParams[19].Value = DBNull.Value;
			if (status[20])
				sqlParams[20].Value = _contentrequest.Minwordcount;
			else
				sqlParams[20].Value = DBNull.Value;
			if (status[21])
				sqlParams[21].Value = _contentrequest.Maxwordcount;
			else
				sqlParams[21].Value = DBNull.Value;
			if (status[22])
				sqlParams[22].Value = _contentrequest.Isenabled;
			else
				sqlParams[22].Value = DBNull.Value;
			if (status[23])
				sqlParams[23].Value = _contentrequest.Createddate;
			else
				sqlParams[23].Value = DBNull.Value;
			if (status[24])
				sqlParams[24].Value = _contentrequest.Createdby;
			else
				sqlParams[24].Value = DBNull.Value;
			if (status[25])
				sqlParams[25].Value = _contentrequest.Updateddate;
			else
				sqlParams[25].Value = DBNull.Value;
			if (status[26])
				sqlParams[26].Value = _contentrequest.Updatedby;
			else
				sqlParams[26].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequest' table
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContentrequestInfo _contentrequest)
		{
			SqlParameter[] sqlParams = new SqlParameter[27];		
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
			sqlParams[4] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
			sqlParams[6] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[8] = new SqlParameter("@SubscriptionId", SqlDbType.Int);
			sqlParams[9] = new SqlParameter("@Subscription", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@RequestCode", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[12] = new SqlParameter("@DueDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@DateTimeZone", SqlDbType.VarChar);
			sqlParams[14] = new SqlParameter("@DateFormat", SqlDbType.VarChar);
			sqlParams[15] = new SqlParameter("@DirectionalContent", SqlDbType.Text);
			sqlParams[16] = new SqlParameter("@DCBlogUrl", SqlDbType.VarChar);
			sqlParams[17] = new SqlParameter("@DCPracticeArea", SqlDbType.VarChar);
			sqlParams[18] = new SqlParameter("@DCGeography", SqlDbType.VarChar);
			sqlParams[19] = new SqlParameter("@DCInsForWriter", SqlDbType.VarChar);
			sqlParams[20] = new SqlParameter("@MinWordCount", SqlDbType.Int);
			sqlParams[21] = new SqlParameter("@MaxWordCount", SqlDbType.Int);
			sqlParams[22] = new SqlParameter("@IsEnabled", SqlDbType.Bit);
			sqlParams[23] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
			sqlParams[25] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[26] = new SqlParameter("@UpdatedBy", SqlDbType.Int);

			bool[] status = _contentrequest.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequest.Contentrequestid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequest.Customerid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequest.Contenttypecode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequest.Requeststatuscode;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequest.Requesttypecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequest.Suggestedauthorid;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequest.Workrequestid;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _contentrequest.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _contentrequest.Subscriptionid;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _contentrequest.Subscription;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _contentrequest.Requestcode;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _contentrequest.Name;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _contentrequest.Duedate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _contentrequest.Datetimezone;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _contentrequest.Dateformat;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _contentrequest.Directionalcontent;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _contentrequest.Dcblogurl;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _contentrequest.Dcpracticearea;
			else
				sqlParams[17].Value = DBNull.Value;
			if (status[18])
				sqlParams[18].Value = _contentrequest.Dcgeography;
			else
				sqlParams[18].Value = DBNull.Value;
			if (status[19])
				sqlParams[19].Value = _contentrequest.Dcinsforwriter;
			else
				sqlParams[19].Value = DBNull.Value;
			if (status[20])
				sqlParams[20].Value = _contentrequest.Minwordcount;
			else
				sqlParams[20].Value = DBNull.Value;
			if (status[21])
				sqlParams[21].Value = _contentrequest.Maxwordcount;
			else
				sqlParams[21].Value = DBNull.Value;
			if (status[22])
				sqlParams[22].Value = _contentrequest.Isenabled;
			else
				sqlParams[22].Value = DBNull.Value;
			if (status[23])
				sqlParams[23].Value = _contentrequest.Createddate;
			else
				sqlParams[23].Value = DBNull.Value;
			if (status[24])
				sqlParams[24].Value = _contentrequest.Createdby;
			else
				sqlParams[24].Value = DBNull.Value;
			if (status[25])
				sqlParams[25].Value = _contentrequest.Updateddate;
			else
				sqlParams[25].Value = DBNull.Value;
			if (status[26])
				sqlParams[26].Value = _contentrequest.Updatedby;
			else
				sqlParams[26].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequest' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_contentrequest">ContentrequestInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContentrequestInfo _contentrequest, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
			sqlParams[4] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
			sqlParams[6] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[8] = new SqlParameter("@SubscriptionId", SqlDbType.Int);
			sqlParams[9] = new SqlParameter("@Subscription", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@RequestCode", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[12] = new SqlParameter("@DueDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@DateTimeZone", SqlDbType.VarChar);
			sqlParams[14] = new SqlParameter("@DateFormat", SqlDbType.VarChar);
			sqlParams[15] = new SqlParameter("@DirectionalContent", SqlDbType.Text);
			sqlParams[16] = new SqlParameter("@DCBlogUrl", SqlDbType.VarChar);
			sqlParams[17] = new SqlParameter("@DCPracticeArea", SqlDbType.VarChar);
			sqlParams[18] = new SqlParameter("@DCGeography", SqlDbType.VarChar);
			sqlParams[19] = new SqlParameter("@DCInsForWriter", SqlDbType.VarChar);
			sqlParams[20] = new SqlParameter("@MinWordCount", SqlDbType.Int);
			sqlParams[21] = new SqlParameter("@MaxWordCount", SqlDbType.Int);
			sqlParams[22] = new SqlParameter("@IsEnabled", SqlDbType.Bit);
			sqlParams[23] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
			sqlParams[25] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[26] = new SqlParameter("@UpdatedBy", SqlDbType.Int);

			bool[] status = _contentrequest.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequest.Contentrequestid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequest.Customerid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequest.Contenttypecode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequest.Requeststatuscode;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequest.Requesttypecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequest.Suggestedauthorid;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequest.Workrequestid;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _contentrequest.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _contentrequest.Subscriptionid;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _contentrequest.Subscription;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _contentrequest.Requestcode;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _contentrequest.Name;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _contentrequest.Duedate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _contentrequest.Datetimezone;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _contentrequest.Dateformat;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _contentrequest.Directionalcontent;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _contentrequest.Dcblogurl;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _contentrequest.Dcpracticearea;
			else
				sqlParams[17].Value = DBNull.Value;
			if (status[18])
				sqlParams[18].Value = _contentrequest.Dcgeography;
			else
				sqlParams[18].Value = DBNull.Value;
			if (status[19])
				sqlParams[19].Value = _contentrequest.Dcinsforwriter;
			else
				sqlParams[19].Value = DBNull.Value;
			if (status[20])
				sqlParams[20].Value = _contentrequest.Minwordcount;
			else
				sqlParams[20].Value = DBNull.Value;
			if (status[21])
				sqlParams[21].Value = _contentrequest.Maxwordcount;
			else
				sqlParams[21].Value = DBNull.Value;
			if (status[22])
				sqlParams[22].Value = _contentrequest.Isenabled;
			else
				sqlParams[22].Value = DBNull.Value;
			if (status[23])
				sqlParams[23].Value = _contentrequest.Createddate;
			else
				sqlParams[23].Value = DBNull.Value;
			if (status[24])
				sqlParams[24].Value = _contentrequest.Createdby;
			else
				sqlParams[24].Value = DBNull.Value;
			if (status[25])
				sqlParams[25].Value = _contentrequest.Updateddate;
			else
				sqlParams[25].Value = DBNull.Value;
			if (status[26])
				sqlParams[26].Value = _contentrequest.Updatedby;
			else
				sqlParams[26].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContentrequestInfo _contentrequest, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[28];		
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestStatusCode", SqlDbType.Int);
			sqlParams[4] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@SuggestedAuthorId", SqlDbType.Int);
			sqlParams[6] = new SqlParameter("@WorkRequestId", SqlDbType.Int);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[8] = new SqlParameter("@SubscriptionId", SqlDbType.Int);
			sqlParams[9] = new SqlParameter("@Subscription", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@RequestCode", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[12] = new SqlParameter("@DueDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@DateTimeZone", SqlDbType.VarChar);
			sqlParams[14] = new SqlParameter("@DateFormat", SqlDbType.VarChar);
			sqlParams[15] = new SqlParameter("@DirectionalContent", SqlDbType.Text);
			sqlParams[16] = new SqlParameter("@DCBlogUrl", SqlDbType.VarChar);
			sqlParams[17] = new SqlParameter("@DCPracticeArea", SqlDbType.VarChar);
			sqlParams[18] = new SqlParameter("@DCGeography", SqlDbType.VarChar);
			sqlParams[19] = new SqlParameter("@DCInsForWriter", SqlDbType.VarChar);
			sqlParams[20] = new SqlParameter("@MinWordCount", SqlDbType.Int);
			sqlParams[21] = new SqlParameter("@MaxWordCount", SqlDbType.Int);
			sqlParams[22] = new SqlParameter("@IsEnabled", SqlDbType.Bit);
			sqlParams[23] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
			sqlParams[25] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[26] = new SqlParameter("@UpdatedBy", SqlDbType.Int);

			bool[] status = _contentrequest.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequest.Contentrequestid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequest.Customerid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequest.Contenttypecode;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequest.Requeststatuscode;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequest.Requesttypecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequest.Suggestedauthorid;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequest.Workrequestid;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _contentrequest.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _contentrequest.Subscriptionid;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _contentrequest.Subscription;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _contentrequest.Requestcode;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _contentrequest.Name;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _contentrequest.Duedate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _contentrequest.Datetimezone;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _contentrequest.Dateformat;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _contentrequest.Directionalcontent;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _contentrequest.Dcblogurl;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _contentrequest.Dcpracticearea;
			else
				sqlParams[17].Value = DBNull.Value;
			if (status[18])
				sqlParams[18].Value = _contentrequest.Dcgeography;
			else
				sqlParams[18].Value = DBNull.Value;
			if (status[19])
				sqlParams[19].Value = _contentrequest.Dcinsforwriter;
			else
				sqlParams[19].Value = DBNull.Value;
			if (status[20])
				sqlParams[20].Value = _contentrequest.Minwordcount;
			else
				sqlParams[20].Value = DBNull.Value;
			if (status[21])
				sqlParams[21].Value = _contentrequest.Maxwordcount;
			else
				sqlParams[21].Value = DBNull.Value;
			if (status[22])
				sqlParams[22].Value = _contentrequest.Isenabled;
			else
				sqlParams[22].Value = DBNull.Value;
			if (status[23])
				sqlParams[23].Value = _contentrequest.Createddate;
			else
				sqlParams[23].Value = DBNull.Value;
			if (status[24])
				sqlParams[24].Value = _contentrequest.Createdby;
			else
				sqlParams[24].Value = DBNull.Value;
			if (status[25])
				sqlParams[25].Value = _contentrequest.Updateddate;
			else
				sqlParams[25].Value = DBNull.Value;
			if (status[26])
				sqlParams[26].Value = _contentrequest.Updatedby;
			else
				sqlParams[26].Value = DBNull.Value;

   			sqlParams[27] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[27].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
