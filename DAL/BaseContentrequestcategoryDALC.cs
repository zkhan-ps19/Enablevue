/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'ContentRequestCategory' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContentrequestcategoryDALC' class.
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
	/// General database operations related to 'ContentRequestCategory' table
	/// </summary>
	public abstract class BaseContentrequestcategoryDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__contentrequestcategoryid">Primay key ID</param>
		/// <returns>
		/// ContentrequestcategoryInfo object
		/// </returns>
		public static ContentrequestcategoryInfo SelectByPK(int __contentrequestcategoryid)
		{ 
			ContentrequestcategoryInfo _contentrequestcategory = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_SelectByPK", PKParameters(__contentrequestcategoryid));
			while (reader.Read())
				_contentrequestcategory = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequestcategory;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestcategoryid">Primay key ID</param>
		/// <returns>
		/// ContentrequestcategoryInfo object
		/// </returns>
		public static ContentrequestcategoryInfo SelectFullByPK(int __contentrequestcategoryid)
		{
			//TODO only returning basic object currently
			ContentrequestcategoryInfo _contentrequestcategory = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_SelectFullByPK", PKParameters(__contentrequestcategoryid));
			while (reader.Read())
				_contentrequestcategory = RowToObject(reader,0);
			reader.Close();
			
			return _contentrequestcategory;		
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequestCategory' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestcategoryInfo objects.
		/// </returns>
		public static IList<ContentrequestcategoryInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_SelectAll");

			IList<ContentrequestcategoryInfo> _items = new List<ContentrequestcategoryInfo>();
			ContentrequestcategoryInfo _contentrequestcategory = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestcategory = RowToObject(reader,0);
				_items.Add(_contentrequestcategory);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'ContentRequestCategory' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentrequestcategoryInfo objects.
		/// </returns>
		public static IList<ContentrequestcategoryInfo> SelectAllFull()
		{	
			IList<ContentrequestcategoryInfo> _items = new List<ContentrequestcategoryInfo>();
			//ContentrequestcategoryInfo _contentrequestcategory = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'ContentRequestCategory' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ContentrequestcategoryInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_SelectAllWhere", sqlParams);

			IList<ContentrequestcategoryInfo> _items = new List<ContentrequestcategoryInfo>();
			ContentrequestcategoryInfo _contentrequestcategory = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestcategory = RowToObject(reader,0);
				_items.Add(_contentrequestcategory);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'ContentRequestCategory' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'ContentRequestCategory' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequestCategory' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'ContentRequestCategory' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'ContentRequestCategory' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
		/// <returns>
		/// ContentrequestcategoryInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ContentrequestcategoryInfo Insert(ContentrequestcategoryInfo _contentrequestcategory) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_Insert", InsertParameters(_contentrequestcategory));
			_contentrequestcategory.Contentrequestcategoryid = autoNumValue;
			
			return _contentrequestcategory;
		}
		
		/// <summary>
		/// Update a record in 'ContentRequestCategory' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContentrequestcategoryInfo _contentrequestcategory)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_Update", UpdateParameters(_contentrequestcategory));
		}

		/// <summary>
		/// Update record(s) in 'ContentRequestCategory' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContentrequestcategoryInfo _contentrequestcategory, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_UpdateAllWhere", UpdateAllWhereParameters(_contentrequestcategory, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'ContentRequestCategory' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
		/// <param name="__contentrequestid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentrequestid(ContentrequestcategoryInfo _contentrequestcategory, int __contentrequestid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_contentrequestcategory, 7);
			// Last parameter containing FK
   			sqlParams[7] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[7].Value = __contentrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_UpdateAllByFK_ContentRequestId", UpdateParameters(_contentrequestcategory,7));
		}
		
		/// <summary>
		/// Delete a record in 'ContentRequestCategory' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__contentrequestcategoryid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __contentrequestcategoryid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_Delete", PKParameters(__contentrequestcategoryid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'ContentRequestCategory' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'ContentRequestCategory' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_DeleteAllByFK_ContentRequestId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'ContentRequestCategory' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static IList<ContentrequestcategoryInfo> SelectAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", "SqlDbType.Int");
			sqlParams[0].Value = __contentrequestid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_SelectAllByFK_ContentRequestId", sqlParams);

			IList<ContentrequestcategoryInfo> _items = new List<ContentrequestcategoryInfo>();
			ContentrequestcategoryInfo _contentrequestcategory = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentrequestcategory = RowToObject(reader,0);
				_items.Add(_contentrequestcategory);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'ContentRequestCategory' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'ContentRequestCategory' table matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static int CountAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_CountAllByFK_ContentRequestId", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'ContentRequestCategory' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'ContentRequestCategory' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'ContentRequestCategory' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'ContentRequestCategory' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentRequestCategory_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to ContentRequestCategory object"
		/// <summary>
		/// Converts a data reader row to 'ContentRequestCategory' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContentrequestcategoryInfo' type
		/// </returns>
		protected static ContentrequestcategoryInfo RowToObject(SqlDataReader reader, int index)
		{
			ContentrequestcategoryInfo _contentrequestcategory = new ContentrequestcategoryInfo();

			if (!reader.IsDBNull(index))
				_contentrequestcategory.Contentrequestcategoryid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestcategory.Contentrequestid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestcategory.Category = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestcategory.Categoryprimaryurl = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestcategory.Categoryanchortext = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentrequestcategory.Categorypreferredkeyword = reader.GetString(index);
			index = index + 1;
			
			return _contentrequestcategory;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'ContentRequestCategory' table
		/// </summary>
		/// <param name="__contentrequestcategoryid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __contentrequestcategoryid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@ContentRequestCategoryId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestcategoryid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'ContentRequestCategory' table
		/// </summary>
		/// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ContentrequestcategoryInfo _contentrequestcategory)
		{
			SqlParameter[] sqlParams = new SqlParameter[6];		
			sqlParams[0] = new SqlParameter("@ContentRequestCategoryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CategoryPrimaryUrl", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@CategoryAnchorText", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@CategoryPreferredKeyword", SqlDbType.VarChar);								

			bool[] status = _contentrequestcategory.Diff();

			if (status[1])
				sqlParams[1].Value = _contentrequestcategory.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestcategory.Category;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestcategory.Categoryprimaryurl;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestcategory.Categoryanchortext;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestcategory.Categorypreferredkeyword;
			else
				sqlParams[5].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequestCategory' table
		/// </summary>
		/// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContentrequestcategoryInfo _contentrequestcategory)
		{
			SqlParameter[] sqlParams = new SqlParameter[6];		
			sqlParams[0] = new SqlParameter("@ContentRequestCategoryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CategoryPrimaryUrl", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@CategoryAnchorText", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@CategoryPreferredKeyword", SqlDbType.VarChar);

			bool[] status = _contentrequestcategory.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestcategory.Contentrequestcategoryid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestcategory.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestcategory.Category;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestcategory.Categoryprimaryurl;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestcategory.Categoryanchortext;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestcategory.Categorypreferredkeyword;
			else
				sqlParams[5].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'ContentRequestCategory' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContentrequestcategoryInfo _contentrequestcategory, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@ContentRequestCategoryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CategoryPrimaryUrl", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@CategoryAnchorText", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@CategoryPreferredKeyword", SqlDbType.VarChar);

			bool[] status = _contentrequestcategory.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestcategory.Contentrequestcategoryid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestcategory.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestcategory.Category;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestcategory.Categoryprimaryurl;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestcategory.Categoryanchortext;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestcategory.Categorypreferredkeyword;
			else
				sqlParams[5].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContentrequestcategoryInfo _contentrequestcategory, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[7];		
			sqlParams[0] = new SqlParameter("@ContentRequestCategoryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CategoryPrimaryUrl", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@CategoryAnchorText", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@CategoryPreferredKeyword", SqlDbType.VarChar);

			bool[] status = _contentrequestcategory.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentrequestcategory.Contentrequestcategoryid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentrequestcategory.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentrequestcategory.Category;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _contentrequestcategory.Categoryprimaryurl;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _contentrequestcategory.Categoryanchortext;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _contentrequestcategory.Categorypreferredkeyword;
			else
				sqlParams[5].Value = DBNull.Value;

   			sqlParams[6] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[6].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
