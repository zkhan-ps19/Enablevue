/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'ContentStatus' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContentstatusDALC' class.
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
	/// General database operations related to 'ContentStatus' table
	/// </summary>
	public abstract class BaseContentstatusDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__contentstatuscode">Primay key ID</param>
		/// <returns>
		/// ContentstatusInfo object
		/// </returns>
		public static ContentstatusInfo SelectByPK(int __contentstatuscode)
		{ 
			ContentstatusInfo _contentstatus = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_SelectByPK", PKParameters(__contentstatuscode));
			while (reader.Read())
				_contentstatus = RowToObject(reader,0);
			reader.Close();
			
			return _contentstatus;
		}
		
		/// <summary>
		/// Get all records from 'ContentStatus' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContentstatusInfo objects.
		/// </returns>
		public static IList<ContentstatusInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_SelectAll");

			IList<ContentstatusInfo> _items = new List<ContentstatusInfo>();
			ContentstatusInfo _contentstatus = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentstatus = RowToObject(reader,0);
				_items.Add(_contentstatus);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'ContentStatus' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ContentstatusInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_SelectAllWhere", sqlParams);

			IList<ContentstatusInfo> _items = new List<ContentstatusInfo>();
			ContentstatusInfo _contentstatus = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contentstatus = RowToObject(reader,0);
				_items.Add(_contentstatus);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'ContentStatus' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'ContentStatus' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'ContentStatus' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'ContentStatus' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'ContentStatus' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_contentstatus">ContentstatusInfo object</param>
		/// <returns>
		/// ContentstatusInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ContentstatusInfo Insert(ContentstatusInfo _contentstatus) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_Insert", InsertParameters(_contentstatus));
			
			return _contentstatus;
		}
		
		/// <summary>
		/// Update a record in 'ContentStatus' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_contentstatus">ContentstatusInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContentstatusInfo _contentstatus)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_Update", UpdateParameters(_contentstatus));
		}

		/// <summary>
		/// Update record(s) in 'ContentStatus' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContentstatusInfo _contentstatus, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_UpdateAllWhere", UpdateAllWhereParameters(_contentstatus, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'ContentStatus' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__contentstatuscode">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __contentstatuscode) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_Delete", PKParameters(__contentstatuscode));	
		}
		
		/// <summary>
		/// Delete record(s) in 'ContentStatus' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'ContentStatus' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'ContentStatus' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'ContentStatus' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'ContentStatus' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentStatus_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to ContentStatus object"
		/// <summary>
		/// Converts a data reader row to 'ContentStatus' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContentstatusInfo' type
		/// </returns>
		protected static ContentstatusInfo RowToObject(SqlDataReader reader, int index)
		{
			ContentstatusInfo _contentstatus = new ContentstatusInfo();

			if (!reader.IsDBNull(index))
				_contentstatus.Contentstatuscode = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentstatus.Contentstatus = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contentstatus.Description = reader.GetString(index);
			index = index + 1;
			
			return _contentstatus;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'ContentStatus' table
		/// </summary>
		/// <param name="__contentstatuscode">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __contentstatuscode) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[0].Value = __contentstatuscode;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'ContentStatus' table
		/// </summary>
		/// <param name="_contentstatus">ContentstatusInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ContentstatusInfo _contentstatus)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentStatus", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Description", SqlDbType.VarChar);								

			bool[] status = _contentstatus.Diff();

			if (status[0])
				sqlParams[0].Value = _contentstatus.Contentstatuscode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentstatus.Contentstatus;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatus.Description;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'ContentStatus' table
		/// </summary>
		/// <param name="_contentstatus">ContentstatusInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContentstatusInfo _contentstatus)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentStatus", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _contentstatus.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentstatus.Contentstatuscode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentstatus.Contentstatus;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatus.Description;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'ContentStatus' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_contentstatus">ContentstatusInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContentstatusInfo _contentstatus, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentStatus", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _contentstatus.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentstatus.Contentstatuscode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentstatus.Contentstatus;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatus.Description;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContentstatusInfo _contentstatus, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[4];		
			sqlParams[0] = new SqlParameter("@ContentStatusCode", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@ContentStatus", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _contentstatus.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contentstatus.Contentstatuscode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contentstatus.Contentstatus;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _contentstatus.Description;
			else
				sqlParams[2].Value = DBNull.Value;

   			sqlParams[3] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[3].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
