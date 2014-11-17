/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'Customer' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'CustomerDALC' class.
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
	/// General database operations related to 'Customer' table
	/// </summary>
	public abstract class BaseCustomerDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__customerid">Primay key ID</param>
		/// <returns>
		/// CustomerInfo object
		/// </returns>
		public static CustomerInfo SelectByPK(int __customerid)
		{ 
			CustomerInfo _customer = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Customer_SelectByPK", PKParameters(__customerid));
			while (reader.Read())
				_customer = RowToObject(reader,0);
			reader.Close();
			
			return _customer;
		}
		
		/// <summary>
		/// Get all records from 'Customer' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of CustomerInfo objects.
		/// </returns>
		public static IList<CustomerInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Customer_SelectAll");

			IList<CustomerInfo> _items = new List<CustomerInfo>();
			CustomerInfo _customer = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_customer = RowToObject(reader,0);
				_items.Add(_customer);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'Customer' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<CustomerInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Customer_SelectAllWhere", sqlParams);

			IList<CustomerInfo> _items = new List<CustomerInfo>();
			CustomerInfo _customer = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_customer = RowToObject(reader,0);
				_items.Add(_customer);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'Customer' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'Customer' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Customer_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'Customer' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'Customer' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Customer_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'Customer' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_customer">CustomerInfo object</param>
		/// <returns>
		/// CustomerInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static CustomerInfo Insert(CustomerInfo _customer) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Customer_Insert", InsertParameters(_customer));
			_customer.Customerid = autoNumValue;
			
			return _customer;
		}
		
		/// <summary>
		/// Update a record in 'Customer' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_customer">CustomerInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(CustomerInfo _customer)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Customer_Update", UpdateParameters(_customer));
		}

		/// <summary>
		/// Update record(s) in 'Customer' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(CustomerInfo _customer, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Customer_UpdateAllWhere", UpdateAllWhereParameters(_customer, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'Customer' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__customerid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __customerid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Customer_Delete", PKParameters(__customerid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'Customer' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Customer_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'Customer' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'Customer' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Customer_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'Customer' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'Customer' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Customer_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to Customer object"
		/// <summary>
		/// Converts a data reader row to 'Customer' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'CustomerInfo' type
		/// </returns>
		protected static CustomerInfo RowToObject(SqlDataReader reader, int index)
		{
			CustomerInfo _customer = new CustomerInfo();

			if (!reader.IsDBNull(index))
				_customer.Customerid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_customer.Name = reader.GetString(index);
			index = index + 1;
			
			return _customer;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'Customer' table
		/// </summary>
		/// <param name="__customerid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __customerid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[0].Value = __customerid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'Customer' table
		/// </summary>
		/// <param name="_customer">CustomerInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(CustomerInfo _customer)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);								

			bool[] status = _customer.Diff();

			if (status[1])
				sqlParams[1].Value = _customer.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'Customer' table
		/// </summary>
		/// <param name="_customer">CustomerInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(CustomerInfo _customer)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _customer.Diff();
			
			if (status[0])
				sqlParams[0].Value = _customer.Customerid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _customer.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'Customer' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_customer">CustomerInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(CustomerInfo _customer, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _customer.Diff();
			
			if (status[0])
				sqlParams[0].Value = _customer.Customerid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _customer.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(CustomerInfo _customer, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@CustomerId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _customer.Diff();
			
			if (status[0])
				sqlParams[0].Value = _customer.Customerid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _customer.Name;
			else
				sqlParams[1].Value = DBNull.Value;

   			sqlParams[2] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[2].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
