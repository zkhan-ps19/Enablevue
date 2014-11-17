/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'Content' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContentDALC' class.
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
	/// General database operations related to 'Content' table
	/// </summary>
	public abstract class BaseContentDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__contentid">Primay key ID</param>
		/// <returns>
		/// ContentInfo object
		/// </returns>
		public static ContentInfo SelectByPK(int __contentid)
		{ 
			ContentInfo _content = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectByPK", PKParameters(__contentid));
			while (reader.Read())
				_content = RowToObject(reader,0);
			reader.Close();
			
			return _content;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentid">Primay key ID</param>
		/// <returns>
		/// ContentInfo object
		/// </returns>
		public static ContentInfo SelectFullByPK(int __contentid)
		{
			//TODO only returning basic object currently
			ContentInfo _content = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectFullByPK", PKParameters(__contentid));
			while (reader.Read())
				_content = RowToObject(reader,0);
			reader.Close();
			
			return _content;		
		} 
		
		/// <summary>
		/// Get all records from 'Content' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentInfo objects.
		/// </returns>
		public static IList<ContentInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAll");

			IList<ContentInfo> _items = new List<ContentInfo>();
			ContentInfo _content = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_content = RowToObject(reader,0);
				_items.Add(_content);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'Content' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentInfo objects.
		/// </returns>
		public static IList<ContentInfo> SelectAllFull()
		{	
			IList<ContentInfo> _items = new List<ContentInfo>();
			//ContentInfo _content = null;
			//TODO full object
			return _items;
		} 
		
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
		public static IList<ContentInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAllWhere", sqlParams);

			IList<ContentInfo> _items = new List<ContentInfo>();
			ContentInfo _content = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_content = RowToObject(reader,0);
				_items.Add(_content);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'Content' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'Content' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Content_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'Content' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'Content' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Content_CountAllWhere", sqlParams);
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
		public static ContentInfo Insert(ContentInfo _content) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Content_Insert", InsertParameters(_content));
			_content.Contentid = autoNumValue;
			
			return _content;
		}
		
		/// <summary>
		/// Update a record in 'Content' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_content">ContentInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContentInfo _content)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_Update", UpdateParameters(_content));
		}

		/// <summary>
		/// Update record(s) in 'Content' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContentInfo _content, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_UpdateAllWhere", UpdateAllWhereParameters(_content, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'Content' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_content">ContentInfo object</param>
		/// <param name="__contentrequestid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentrequestid(ContentInfo _content, int __contentrequestid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_content, 9);
			// Last parameter containing FK
   			sqlParams[9] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[9].Value = __contentrequestid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_UpdateAllByFK_ContentRequestId", UpdateParameters(_content,9));
		}
		
		/// <summary>
		/// Update all records in 'Content' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_content">ContentInfo object</param>
		/// <param name="__authorid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKAuthorid(ContentInfo _content, int __authorid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_content, 9);
			// Last parameter containing FK
   			sqlParams[9] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[9].Value = __authorid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_UpdateAllByFK_AuthorId", UpdateParameters(_content,9));
		}
		
		/// <summary>
		/// Update all records in 'Content' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_content">ContentInfo object</param>
		/// <param name="__contentstatuscode">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKContentstatuscode(ContentInfo _content, int __contentstatuscode)
		{
			SqlParameter[] sqlParams = UpdateParameters(_content, 9);
			// Last parameter containing FK
   			sqlParams[9] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[9].Value = __contentstatuscode;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_UpdateAllByFK_ContentStatusCode", UpdateParameters(_content,9));
		}
		
		/// <summary>
		/// Delete a record in 'Content' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__contentid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __contentid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_Delete", PKParameters(__contentid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'Content' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'Content' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_DeleteAllByFK_ContentRequestId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'Content' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="AuthorId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKAuthorid(int __authorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[0].Value = __authorid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_DeleteAllByFK_AuthorId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'Content' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Content_DeleteAllByFK_ContentStatusCode", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'Content' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static IList<ContentInfo> SelectAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", "SqlDbType.Int");
			sqlParams[0].Value = __contentrequestid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAllByFK_ContentRequestId", sqlParams);

			IList<ContentInfo> _items = new List<ContentInfo>();
			ContentInfo _content = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_content = RowToObject(reader,0);
				_items.Add(_content);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'Content' table matching to the foreign key 'ContentRequestId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentrequestid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'Content' table matching with 'ContentRequestId' foreign key value
		/// </returns>
		public static int CountAllByFKContentrequestid(int __contentrequestid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[0].Value = __contentrequestid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Content_CountAllByFK_ContentRequestId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'Content' table matching to the foreign key 'AuthorId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__authorid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'AuthorId' foreign key value
		/// </returns>
		public static IList<ContentInfo> SelectAllByFKAuthorid(int __authorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@AuthorId", "SqlDbType.Int");
			sqlParams[0].Value = __authorid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAllByFK_AuthorId", sqlParams);

			IList<ContentInfo> _items = new List<ContentInfo>();
			ContentInfo _content = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_content = RowToObject(reader,0);
				_items.Add(_content);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'Content' table matching to the foreign key 'AuthorId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__authorid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'Content' table matching with 'AuthorId' foreign key value
		/// </returns>
		public static int CountAllByFKAuthorid(int __authorid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[0].Value = __authorid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Content_CountAllByFK_AuthorId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'Content' table matching to the foreign key 'ContentStatusCode'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__contentstatuscode">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'ContentStatusCode' foreign key value
		/// </returns>
		public static IList<ContentInfo> SelectAllByFKContentstatuscode(int __contentstatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentStatusCode", "SqlDbType.Int");
			sqlParams[0].Value = __contentstatuscode;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAllByFK_ContentStatusCode", sqlParams);

			IList<ContentInfo> _items = new List<ContentInfo>();
			ContentInfo _content = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_content = RowToObject(reader,0);
				_items.Add(_content);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'Content' table matching to the foreign key 'ContentStatusCode'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__contentstatuscode">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'Content' table matching with 'ContentStatusCode' foreign key value
		/// </returns>
		public static int CountAllByFKContentstatuscode(int __contentstatuscode)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[0].Value = __contentstatuscode;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Content_CountAllByFK_ContentStatusCode", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'Content' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'Content' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'Content' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'Content' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Content_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to Content object"
		/// <summary>
		/// Converts a data reader row to 'Content' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContentInfo' type
		/// </returns>
		protected static ContentInfo RowToObject(SqlDataReader reader, int index)
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
				_content.Contentstatuscode = reader.GetInt32(index);
			index = index + 1;
			
			return _content;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'Content' table
		/// </summary>
		/// <param name="__contentid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __contentid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@ContentId", SqlDbType.Int);
			sqlParams[0].Value = __contentid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'Content' table
		/// </summary>
		/// <param name="_content">ContentInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ContentInfo _content)
		{
			SqlParameter[] sqlParams = new SqlParameter[8];		
			sqlParams[0] = new SqlParameter("@ContentId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@Title", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@Source", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@ContentDetail", SqlDbType.Text);
			sqlParams[6] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);								

			bool[] status = _content.Diff();

			if (status[1])
				sqlParams[1].Value = _content.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _content.Authorid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _content.Title;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _content.Source;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _content.Contentdetail;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _content.Category;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _content.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'Content' table
		/// </summary>
		/// <param name="_content">ContentInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContentInfo _content)
		{
			SqlParameter[] sqlParams = new SqlParameter[8];		
			sqlParams[0] = new SqlParameter("@ContentId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@Title", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@Source", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@ContentDetail", SqlDbType.Text);
			sqlParams[6] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);

			bool[] status = _content.Diff();
			
			if (status[0])
				sqlParams[0].Value = _content.Contentid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _content.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _content.Authorid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _content.Title;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _content.Source;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _content.Contentdetail;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _content.Category;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _content.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'Content' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_content">ContentInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContentInfo _content, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@ContentId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@Title", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@Source", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@ContentDetail", SqlDbType.Text);
			sqlParams[6] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);

			bool[] status = _content.Diff();
			
			if (status[0])
				sqlParams[0].Value = _content.Contentid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _content.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _content.Authorid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _content.Title;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _content.Source;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _content.Contentdetail;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _content.Category;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _content.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContentInfo _content, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[9];		
			sqlParams[0] = new SqlParameter("@ContentId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentRequestId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@Title", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@Source", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@ContentDetail", SqlDbType.Text);
			sqlParams[6] = new SqlParameter("@Category", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);

			bool[] status = _content.Diff();
			
			if (status[0])
				sqlParams[0].Value = _content.Contentid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _content.Contentrequestid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _content.Authorid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _content.Title;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _content.Source;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _content.Contentdetail;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _content.Category;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _content.Contentstatuscode;
			else
				sqlParams[7].Value = DBNull.Value;

   			sqlParams[8] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[8].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
