/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'RequestType' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'RequesttypeDALC' class.
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
	/// General database operations related to 'RequestType' table
	/// </summary>
	public abstract class BaseRequesttypeDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__requesttypecode">Primay key ID</param>
		/// <returns>
		/// RequesttypeInfo object
		/// </returns>
		public static RequesttypeInfo SelectByPK(string __requesttypecode)
		{ 
			RequesttypeInfo _requesttype = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestType_SelectByPK", PKParameters(__requesttypecode));
			while (reader.Read())
				_requesttype = RowToObject(reader,0);
			reader.Close();
			
			return _requesttype;
		}
		
		/// <summary>
		/// Get all records from 'RequestType' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of RequesttypeInfo objects.
		/// </returns>
		public static IList<RequesttypeInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestType_SelectAll");

			IList<RequesttypeInfo> _items = new List<RequesttypeInfo>();
			RequesttypeInfo _requesttype = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_requesttype = RowToObject(reader,0);
				_items.Add(_requesttype);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'RequestType' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<RequesttypeInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "RequestType_SelectAllWhere", sqlParams);

			IList<RequesttypeInfo> _items = new List<RequesttypeInfo>();
			RequesttypeInfo _requesttype = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_requesttype = RowToObject(reader,0);
				_items.Add(_requesttype);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'RequestType' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'RequestType' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "RequestType_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'RequestType' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'RequestType' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "RequestType_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'RequestType' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_requesttype">RequesttypeInfo object</param>
		/// <returns>
		/// RequesttypeInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static RequesttypeInfo Insert(RequesttypeInfo _requesttype) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestType_Insert", InsertParameters(_requesttype));
			
			return _requesttype;
		}
		
		/// <summary>
		/// Update a record in 'RequestType' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_requesttype">RequesttypeInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(RequesttypeInfo _requesttype)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestType_Update", UpdateParameters(_requesttype));
		}

		/// <summary>
		/// Update record(s) in 'RequestType' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(RequesttypeInfo _requesttype, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestType_UpdateAllWhere", UpdateAllWhereParameters(_requesttype, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'RequestType' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__requesttypecode">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(string __requesttypecode) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestType_Delete", PKParameters(__requesttypecode));	
		}
		
		/// <summary>
		/// Delete record(s) in 'RequestType' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "RequestType_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'RequestType' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'RequestType' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "RequestType_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'RequestType' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'RequestType' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "RequestType_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to RequestType object"
		/// <summary>
		/// Converts a data reader row to 'RequestType' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'RequesttypeInfo' type
		/// </returns>
		protected static RequesttypeInfo RowToObject(SqlDataReader reader, int index)
		{
			RequesttypeInfo _requesttype = new RequesttypeInfo();

			if (!reader.IsDBNull(index))
				_requesttype.Requesttypecode = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_requesttype.Requesttype = reader.GetString(index);
			index = index + 1;
			
			return _requesttype;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'RequestType' table
		/// </summary>
		/// <param name="__requesttypecode">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(string __requesttypecode) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[0].Value = __requesttypecode;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'RequestType' table
		/// </summary>
		/// <param name="_requesttype">RequesttypeInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(RequesttypeInfo _requesttype)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@RequestType", SqlDbType.VarChar);								

			bool[] status = _requesttype.Diff();

			if (status[0])
				sqlParams[0].Value = _requesttype.Requesttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _requesttype.Requesttype;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'RequestType' table
		/// </summary>
		/// <param name="_requesttype">RequesttypeInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(RequesttypeInfo _requesttype)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@RequestType", SqlDbType.VarChar);

			bool[] status = _requesttype.Diff();
			
			if (status[0])
				sqlParams[0].Value = _requesttype.Requesttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _requesttype.Requesttype;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'RequestType' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_requesttype">RequesttypeInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(RequesttypeInfo _requesttype, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@RequestType", SqlDbType.VarChar);

			bool[] status = _requesttype.Diff();
			
			if (status[0])
				sqlParams[0].Value = _requesttype.Requesttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _requesttype.Requesttype;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(RequesttypeInfo _requesttype, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@RequestTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@RequestType", SqlDbType.VarChar);

			bool[] status = _requesttype.Diff();
			
			if (status[0])
				sqlParams[0].Value = _requesttype.Requesttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _requesttype.Requesttype;
			else
				sqlParams[1].Value = DBNull.Value;

   			sqlParams[2] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[2].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
