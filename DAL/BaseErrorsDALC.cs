/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'Errors' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ErrorsDALC' class.
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
	/// General database operations related to 'Errors' table
	/// </summary>
	public abstract class BaseErrorsDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__code">Primay key ID</param>
		/// <returns>
		/// ErrorsInfo object
		/// </returns>
		public static ErrorsInfo SelectByPK(string __code)
		{ 
			ErrorsInfo _errors = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Errors_SelectByPK", PKParameters(__code));
			while (reader.Read())
				_errors = RowToObject(reader,0);
			reader.Close();
			
			return _errors;
		}
		
		/// <summary>
		/// Get all records from 'Errors' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ErrorsInfo objects.
		/// </returns>
		public static IList<ErrorsInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Errors_SelectAll");

			IList<ErrorsInfo> _items = new List<ErrorsInfo>();
			ErrorsInfo _errors = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_errors = RowToObject(reader,0);
				_items.Add(_errors);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'Errors' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ErrorsInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Errors_SelectAllWhere", sqlParams);

			IList<ErrorsInfo> _items = new List<ErrorsInfo>();
			ErrorsInfo _errors = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_errors = RowToObject(reader,0);
				_items.Add(_errors);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'Errors' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'Errors' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Errors_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'Errors' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'Errors' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Errors_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'Errors' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_errors">ErrorsInfo object</param>
		/// <returns>
		/// ErrorsInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ErrorsInfo Insert(ErrorsInfo _errors) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Errors_Insert", InsertParameters(_errors));
			
			return _errors;
		}
		
		/// <summary>
		/// Update a record in 'Errors' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_errors">ErrorsInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ErrorsInfo _errors)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Errors_Update", UpdateParameters(_errors));
		}

		/// <summary>
		/// Update record(s) in 'Errors' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ErrorsInfo _errors, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Errors_UpdateAllWhere", UpdateAllWhereParameters(_errors, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'Errors' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__code">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(string __code) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Errors_Delete", PKParameters(__code));	
		}
		
		/// <summary>
		/// Delete record(s) in 'Errors' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Errors_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'Errors' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'Errors' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Errors_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'Errors' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'Errors' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Errors_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to Errors object"
		/// <summary>
		/// Converts a data reader row to 'Errors' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ErrorsInfo' type
		/// </returns>
		protected static ErrorsInfo RowToObject(SqlDataReader reader, int index)
		{
			ErrorsInfo _errors = new ErrorsInfo();

			if (!reader.IsDBNull(index))
				_errors.Code = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_errors.Description = reader.GetString(index);
			index = index + 1;
			
			return _errors;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'Errors' table
		/// </summary>
		/// <param name="__code">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(string __code) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@Code", SqlDbType.VarChar);
			sqlParams[0].Value = __code;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'Errors' table
		/// </summary>
		/// <param name="_errors">ErrorsInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ErrorsInfo _errors)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@Code", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@Description", SqlDbType.VarChar);								

			bool[] status = _errors.Diff();

			if (status[0])
				sqlParams[0].Value = _errors.Code;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _errors.Description;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'Errors' table
		/// </summary>
		/// <param name="_errors">ErrorsInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ErrorsInfo _errors)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@Code", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _errors.Diff();
			
			if (status[0])
				sqlParams[0].Value = _errors.Code;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _errors.Description;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'Errors' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_errors">ErrorsInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ErrorsInfo _errors, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@Code", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _errors.Diff();
			
			if (status[0])
				sqlParams[0].Value = _errors.Code;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _errors.Description;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ErrorsInfo _errors, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@Code", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@Description", SqlDbType.VarChar);

			bool[] status = _errors.Diff();
			
			if (status[0])
				sqlParams[0].Value = _errors.Code;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _errors.Description;
			else
				sqlParams[1].Value = DBNull.Value;

   			sqlParams[2] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[2].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
