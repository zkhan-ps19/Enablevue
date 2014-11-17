/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'WorkRequest' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'WorkrequestDALC' class.
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
	/// General database operations related to 'WorkRequest' table
	/// </summary>
	public abstract class BaseWorkrequestDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__id">Primay key ID</param>
		/// <returns>
		/// WorkrequestInfo object
		/// </returns>
		public static WorkrequestInfo SelectByPK(int __id)
		{ 
			WorkrequestInfo _workrequest = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_SelectByPK", PKParameters(__id));
			while (reader.Read())
				_workrequest = RowToObject(reader,0);
			reader.Close();
			
			return _workrequest;
		}
		
		/// <summary>
		/// Get all records from 'WorkRequest' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of WorkrequestInfo objects.
		/// </returns>
		public static IList<WorkrequestInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_SelectAll");

			IList<WorkrequestInfo> _items = new List<WorkrequestInfo>();
			WorkrequestInfo _workrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_workrequest = RowToObject(reader,0);
				_items.Add(_workrequest);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'WorkRequest' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<WorkrequestInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_SelectAllWhere", sqlParams);

			IList<WorkrequestInfo> _items = new List<WorkrequestInfo>();
			WorkrequestInfo _workrequest = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_workrequest = RowToObject(reader,0);
				_items.Add(_workrequest);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'WorkRequest' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'WorkRequest' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'WorkRequest' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'WorkRequest' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'WorkRequest' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_workrequest">WorkrequestInfo object</param>
		/// <returns>
		/// WorkrequestInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static WorkrequestInfo Insert(WorkrequestInfo _workrequest) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_Insert", InsertParameters(_workrequest));
			
			return _workrequest;
		}
		
		/// <summary>
		/// Update a record in 'WorkRequest' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_workrequest">WorkrequestInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(WorkrequestInfo _workrequest)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_Update", UpdateParameters(_workrequest));
		}

		/// <summary>
		/// Update record(s) in 'WorkRequest' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(WorkrequestInfo _workrequest, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_UpdateAllWhere", UpdateAllWhereParameters(_workrequest, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'WorkRequest' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__id">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __id) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_Delete", PKParameters(__id));	
		}
		
		/// <summary>
		/// Delete record(s) in 'WorkRequest' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'WorkRequest' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'WorkRequest' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'WorkRequest' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'WorkRequest' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "WorkRequest_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to WorkRequest object"
		/// <summary>
		/// Converts a data reader row to 'WorkRequest' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'WorkrequestInfo' type
		/// </returns>
		protected static WorkrequestInfo RowToObject(SqlDataReader reader, int index)
		{
			WorkrequestInfo _workrequest = new WorkrequestInfo();

			if (!reader.IsDBNull(index))
				_workrequest.Id = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_workrequest.Requestkey = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_workrequest.Name = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_workrequest.Apiversion = reader.GetString(index);
			index = index + 1;
			
			return _workrequest;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'WorkRequest' table
		/// </summary>
		/// <param name="__id">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __id) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[0].Value = __id;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'WorkRequest' table
		/// </summary>
		/// <param name="_workrequest">WorkrequestInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(WorkrequestInfo _workrequest)
		{
			SqlParameter[] sqlParams = new SqlParameter[4];		
			sqlParams[0] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@RequestKey", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@APIVersion", SqlDbType.VarChar);								

			bool[] status = _workrequest.Diff();

			if (status[0])
				sqlParams[0].Value = _workrequest.Id;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _workrequest.Requestkey;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _workrequest.Name;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _workrequest.Apiversion;
			else
				sqlParams[3].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'WorkRequest' table
		/// </summary>
		/// <param name="_workrequest">WorkrequestInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(WorkrequestInfo _workrequest)
		{
			SqlParameter[] sqlParams = new SqlParameter[4];		
			sqlParams[0] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@RequestKey", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@APIVersion", SqlDbType.VarChar);

			bool[] status = _workrequest.Diff();
			
			if (status[0])
				sqlParams[0].Value = _workrequest.Id;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _workrequest.Requestkey;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _workrequest.Name;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _workrequest.Apiversion;
			else
				sqlParams[3].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'WorkRequest' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_workrequest">WorkrequestInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(WorkrequestInfo _workrequest, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@RequestKey", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@APIVersion", SqlDbType.VarChar);

			bool[] status = _workrequest.Diff();
			
			if (status[0])
				sqlParams[0].Value = _workrequest.Id;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _workrequest.Requestkey;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _workrequest.Name;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _workrequest.Apiversion;
			else
				sqlParams[3].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(WorkrequestInfo _workrequest, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[5];		
			sqlParams[0] = new SqlParameter("@Id", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@RequestKey", SqlDbType.VarChar);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@APIVersion", SqlDbType.VarChar);

			bool[] status = _workrequest.Diff();
			
			if (status[0])
				sqlParams[0].Value = _workrequest.Id;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _workrequest.Requestkey;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _workrequest.Name;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _workrequest.Apiversion;
			else
				sqlParams[3].Value = DBNull.Value;

   			sqlParams[4] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[4].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
