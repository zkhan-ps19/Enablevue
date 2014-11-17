/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'ContentRequestChange' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContentrequestchangeDALC' class.
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
	/// General database operations related to 'ContentRequestChange' table
	/// </summary>
	public abstract class BaseContentrequestchangeDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__contentrequestchangeid">Primay key ID</param>
		/// <returns>
		/// ContentrequestchangeInfo object
		/// </returns>
		public static ContentrequestchangeInfo SelectByPK(int __contentrequestchangeid)
		{ 
			ContentrequestchangeInfo _contentrequestchange = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_SelectByPK", PKParameters(__contentrequestchangeid));
			while (reader.Read())
				_contentrequestchange = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequestchange;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestchangeid">Primay key ID</param>
		/// <returns>
		/// ContentrequestchangeInfo object
		/// </returns>
		public static ContentrequestchangeInfo SelectFullByPK(int __contentrequestchangeid)
		{
			//TODO only returning basic object currently
			ContentrequestchangeInfo _contentrequestchange = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_SelectFullByPK", PKParameters(__contentrequestchangeid));
			while (reader.Read())
				_contentrequestchange = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequestchange;		
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequestChange' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestchangeInfo objects.
		/// </returns>
		public static IList<ContentrequestchangeInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_SelectAll");

			IList<ContentrequestchangeInfo> _items = new List<ContentrequestchangeInfo>();
			ContentrequestchangeInfo _contentrequestchange = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestchange = RowToObject(reader,0);
				_items.Add(_contentrequestchange);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'ContentRequestChange' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestchangeInfo objects.
		/// </returns>
		public static IList<ContentrequestchangeInfo> SelectAllFull()
		{	
			IList<ContentrequestchangeInfo> _items = new List<ContentrequestchangeInfo>();
			//ContentrequestchangeInfo _contentrequestchange = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequestChange' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ContentrequestchangeInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_SelectAllWhere", sqlParams);

			IList<ContentrequestchangeInfo> _items = new List<ContentrequestchangeInfo>();
			ContentrequestchangeInfo _contentrequestchange = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestchange = RowToObject(reader,0);
				_items.Add(_contentrequestchange);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'ContentRequestChange' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'ContentRequestChange' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequestChange' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'ContentRequestChange' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'ContentRequestChange' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
		/// <returns>
		/// ContentrequestchangeInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ContentrequestchangeInfo Insert(ContentrequestchangeInfo _contentrequestchange) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_Insert", InsertParameters(_contentrequestchange));
			_contentrequestchange.Contentrequestchangeid = autoNumValue;
			
			return _contentrequestchange;
		}
		
		/// <summary>
		/// Update a record in 'ContentRequestChange' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContentrequestchangeInfo _contentrequestchange)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_Update", UpdateParameters(_contentrequestchange));
		}

		/// <summary>
		/// Update record(s) in 'ContentRequestChange' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContentrequestchangeInfo _contentrequestchange, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_UpdateAllWhere", UpdateAllWhereParameters(_contentrequestchange, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequestChange' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
		/// <param name="__contentrequestid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentrequestid(ContentrequestchangeInfo _contentrequestchange, int __contentrequestid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequestchange, 7);
			// Last parameter containing FK
   			sqlParams[7] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[7].Value = __contentrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_UpdateAllByFK_ContentRequestId", UpdateParameters(_contentrequestchange,7));
		}
		
		/// <summary>
		/// Delete a record in 'ContentRequestChange' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__contentrequestchangeid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __contentrequestchangeid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_Delete", PKParameters(__contentrequestchangeid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'ContentRequestChange' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'ContentRequestChange' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_DeleteAllByFK_ContentRequestId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequestChange' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static IList<ContentrequestchangeInfo> SelectAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", "SqlDbType.Int");
			sqlParams[0].Value = __contentrequestid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_SelectAllByFK_ContentRequestId", sqlParams);

			IList<ContentrequestchangeInfo> _items = new List<ContentrequestchangeInfo>();
			ContentrequestchangeInfo _contentrequestchange = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestchange = RowToObject(reader,0);
				_items.Add(_contentrequestchange);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequestChange' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequestChange' table matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static int CountAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_CountAllByFK_ContentRequestId", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'ContentRequestChange' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'ContentRequestChange' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'ContentRequestChange' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'ContentRequestChange' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequestChange_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to ContentRequestChange object"
		/// <summary>
		/// Converts a data reader row to 'ContentRequestChange' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContentrequestchangeInfo' type
		/// </returns>
		protected static ContentrequestchangeInfo RowToObject(SqlDataReader reader, int index)
		{
			ContentrequestchangeInfo _contentrequestchange = new ContentrequestchangeInfo();

			if (!reader.IsDBNull(index))
				_contentrequestchange.Contentrequestchangeid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestchange.Contentrequestid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestchange.Requestchangereasons = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestchange.Requestchange = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestchange.Requestchangecode = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestchange.Islatest = reader.GetBoolean(index);
			index = index + 1;
			
			return _contentrequestchange;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'ContentRequestChange' table
		/// </summary>
		/// <param name="__contentrequestchangeid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __contentrequestchangeid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@ContentRequestChangeId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestchangeid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'ContentRequestChange' table
		/// </summary>
		/// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ContentrequestchangeInfo _contentrequestchange)
		{
			SqlParameter[] sqlParams = new SqlParameter[6];		
			sqlParams[0] = new SqlParameter("@ContentRequestChangeId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@RequestChangeReasons", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestChange", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@RequestChangeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@IsLatest", SqlDbType.Bit);								

			bool[] status = _contentrequestchange.Diff();

			if (status[1])
				sqlParams[1].Value = _contentrequestchange.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestchange.Requestchangereasons;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestchange.Requestchange;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestchange.Requestchangecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestchange.Islatest;
			else
				sqlParams[5].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequestChange' table
		/// </summary>
		/// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContentrequestchangeInfo _contentrequestchange)
		{
			SqlParameter[] sqlParams = new SqlParameter[6];		
			sqlParams[0] = new SqlParameter("@ContentRequestChangeId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@RequestChangeReasons", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestChange", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@RequestChangeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@IsLatest", SqlDbType.Bit);

			bool[] status = _contentrequestchange.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestchange.Contentrequestchangeid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestchange.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestchange.Requestchangereasons;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestchange.Requestchange;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestchange.Requestchangecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestchange.Islatest;
			else
				sqlParams[5].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequestChange' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContentrequestchangeInfo _contentrequestchange, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@ContentRequestChangeId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@RequestChangeReasons", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestChange", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@RequestChangeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@IsLatest", SqlDbType.Bit);

			bool[] status = _contentrequestchange.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestchange.Contentrequestchangeid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestchange.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestchange.Requestchangereasons;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestchange.Requestchange;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestchange.Requestchangecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestchange.Islatest;
			else
				sqlParams[5].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContentrequestchangeInfo _contentrequestchange, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[7];		
			sqlParams[0] = new SqlParameter("@ContentRequestChangeId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@RequestChangeReasons", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@RequestChange", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@RequestChangeCode", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@IsLatest", SqlDbType.Bit);

			bool[] status = _contentrequestchange.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestchange.Contentrequestchangeid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestchange.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestchange.Requestchangereasons;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestchange.Requestchange;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestchange.Requestchangecode;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestchange.Islatest;
			else
				sqlParams[5].Value = DBNull.Value;

   			sqlParams[6] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[6].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
