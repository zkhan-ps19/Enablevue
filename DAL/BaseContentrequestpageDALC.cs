/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'ContentRequestPage' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContentrequestpageDALC' class.
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
	/// General database operations related to 'ContentRequestPage' table
	/// </summary>
	public abstract class BaseContentrequestpageDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__pageid">Primay key ID</param>
		/// <returns>
		/// ContentrequestpageInfo object
		/// </returns>
		public static ContentrequestpageInfo SelectByPK(int __pageid)
		{ 
			ContentrequestpageInfo _contentrequestpage = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_SelectByPK", PKParameters(__pageid));
			while (reader.Read())
				_contentrequestpage = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequestpage;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__pageid">Primay key ID</param>
		/// <returns>
		/// ContentrequestpageInfo object
		/// </returns>
		public static ContentrequestpageInfo SelectFullByPK(int __pageid)
		{
			//TODO only returning basic object currently
			ContentrequestpageInfo _contentrequestpage = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_SelectFullByPK", PKParameters(__pageid));
			while (reader.Read())
				_contentrequestpage = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequestpage;		
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequestPage' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestpageInfo objects.
		/// </returns>
		public static IList<ContentrequestpageInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_SelectAll");

			IList<ContentrequestpageInfo> _items = new List<ContentrequestpageInfo>();
			ContentrequestpageInfo _contentrequestpage = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestpage = RowToObject(reader,0);
				_items.Add(_contentrequestpage);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'ContentRequestPage' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestpageInfo objects.
		/// </returns>
		public static IList<ContentrequestpageInfo> SelectAllFull()
		{	
			IList<ContentrequestpageInfo> _items = new List<ContentrequestpageInfo>();
			//ContentrequestpageInfo _contentrequestpage = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequestPage' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ContentrequestpageInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_SelectAllWhere", sqlParams);

			IList<ContentrequestpageInfo> _items = new List<ContentrequestpageInfo>();
			ContentrequestpageInfo _contentrequestpage = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestpage = RowToObject(reader,0);
				_items.Add(_contentrequestpage);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'ContentRequestPage' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'ContentRequestPage' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequestPage' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'ContentRequestPage' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'ContentRequestPage' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
		/// <returns>
		/// ContentrequestpageInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ContentrequestpageInfo Insert(ContentrequestpageInfo _contentrequestpage) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_Insert", InsertParameters(_contentrequestpage));
			_contentrequestpage.Pageid = autoNumValue;
			
			return _contentrequestpage;
		}
		
		/// <summary>
		/// Update a record in 'ContentRequestPage' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContentrequestpageInfo _contentrequestpage)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_Update", UpdateParameters(_contentrequestpage));
		}

		/// <summary>
		/// Update record(s) in 'ContentRequestPage' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContentrequestpageInfo _contentrequestpage, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_UpdateAllWhere", UpdateAllWhereParameters(_contentrequestpage, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequestPage' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
		/// <param name="__contentrequestid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentrequestid(ContentrequestpageInfo _contentrequestpage, int __contentrequestid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequestpage, 8);
			// Last parameter containing FK
   			sqlParams[8] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[8].Value = __contentrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_UpdateAllByFK_ContentRequestId", UpdateParameters(_contentrequestpage,8));
		}
		
		/// <summary>
		/// Delete a record in 'ContentRequestPage' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__pageid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __pageid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_Delete", PKParameters(__pageid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'ContentRequestPage' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'ContentRequestPage' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_DeleteAllByFK_ContentRequestId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequestPage' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static IList<ContentrequestpageInfo> SelectAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", "SqlDbType.Int");
			sqlParams[0].Value = __contentrequestid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_SelectAllByFK_ContentRequestId", sqlParams);

			IList<ContentrequestpageInfo> _items = new List<ContentrequestpageInfo>();
			ContentrequestpageInfo _contentrequestpage = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestpage = RowToObject(reader,0);
				_items.Add(_contentrequestpage);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequestPage' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequestPage' table matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static int CountAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_CountAllByFK_ContentRequestId", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'ContentRequestPage' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'ContentRequestPage' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'ContentRequestPage' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'ContentRequestPage' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequestPage_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to ContentRequestPage object"
		/// <summary>
		/// Converts a data reader row to 'ContentRequestPage' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContentrequestpageInfo' type
		/// </returns>
		protected static ContentrequestpageInfo RowToObject(SqlDataReader reader, int index)
		{
			ContentrequestpageInfo _contentrequestpage = new ContentrequestpageInfo();

			if (!reader.IsDBNull(index))
				_contentrequestpage.Pageid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestpage.Contentrequestid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestpage.Id = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestpage.Pagetitle = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestpage.Pageurl = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestpage.Pageinstruction = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestpage.Iscontentrequired = reader.GetBoolean(index);
			index = index + 1;
			
			return _contentrequestpage;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'ContentRequestPage' table
		/// </summary>
		/// <param name="__pageid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __pageid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@PageId", SqlDbType.Int);
			sqlParams[0].Value = __pageid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'ContentRequestPage' table
		/// </summary>
		/// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ContentrequestpageInfo _contentrequestpage)
		{
			SqlParameter[] sqlParams = new SqlParameter[7];		
			sqlParams[0] = new SqlParameter("@PageId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@PageTitle", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@PageUrl", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@PageInstruction", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@IsContentRequired", SqlDbType.Bit);								

			bool[] status = _contentrequestpage.Diff();

			if (status[1])
				sqlParams[1].Value = _contentrequestpage.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestpage.Id;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestpage.Pagetitle;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestpage.Pageurl;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestpage.Pageinstruction;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequestpage.Iscontentrequired;
			else
				sqlParams[6].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequestPage' table
		/// </summary>
		/// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContentrequestpageInfo _contentrequestpage)
		{
			SqlParameter[] sqlParams = new SqlParameter[7];		
			sqlParams[0] = new SqlParameter("@PageId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@PageTitle", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@PageUrl", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@PageInstruction", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@IsContentRequired", SqlDbType.Bit);

			bool[] status = _contentrequestpage.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestpage.Pageid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestpage.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestpage.Id;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestpage.Pagetitle;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestpage.Pageurl;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestpage.Pageinstruction;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequestpage.Iscontentrequired;
			else
				sqlParams[6].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequestPage' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContentrequestpageInfo _contentrequestpage, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@PageId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@PageTitle", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@PageUrl", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@PageInstruction", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@IsContentRequired", SqlDbType.Bit);

			bool[] status = _contentrequestpage.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestpage.Pageid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestpage.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestpage.Id;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestpage.Pagetitle;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestpage.Pageurl;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestpage.Pageinstruction;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequestpage.Iscontentrequired;
			else
				sqlParams[6].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContentrequestpageInfo _contentrequestpage, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[8];		
			sqlParams[0] = new SqlParameter("@PageId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@PageTitle", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@PageUrl", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@PageInstruction", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@IsContentRequired", SqlDbType.Bit);

			bool[] status = _contentrequestpage.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestpage.Pageid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestpage.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestpage.Id;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestpage.Pagetitle;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestpage.Pageurl;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestpage.Pageinstruction;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _contentrequestpage.Iscontentrequired;
			else
				sqlParams[6].Value = DBNull.Value;

   			sqlParams[7] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[7].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
