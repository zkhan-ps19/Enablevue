/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'Country' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'CountryDALC' class.
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
	/// General database operations related to 'Country' table
	/// </summary>
	public abstract class BaseCountryDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__countryid">Primay key ID</param>
		/// <returns>
		/// CountryInfo object
		/// </returns>
		public static CountryInfo SelectByPK(int __countryid)
		{ 
			CountryInfo _country = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Country_SelectByPK", PKParameters(__countryid));
			while (reader.Read())
				_country = RowToObject(reader,0);
			reader.Close();
			
			return _country;
		}
		
		/// <summary>
		/// Get all records from 'Country' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of CountryInfo objects.
		/// </returns>
		public static IList<CountryInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Country_SelectAll");

			IList<CountryInfo> _items = new List<CountryInfo>();
			CountryInfo _country = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_country = RowToObject(reader,0);
				_items.Add(_country);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'Country' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<CountryInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Country_SelectAllWhere", sqlParams);

			IList<CountryInfo> _items = new List<CountryInfo>();
			CountryInfo _country = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_country = RowToObject(reader,0);
				_items.Add(_country);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'Country' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'Country' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Country_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'Country' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'Country' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Country_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'Country' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_country">CountryInfo object</param>
		/// <returns>
		/// CountryInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static CountryInfo Insert(CountryInfo _country) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Country_Insert", InsertParameters(_country));
			_country.Countryid = autoNumValue;
			
			return _country;
		}
		
		/// <summary>
		/// Update a record in 'Country' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_country">CountryInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(CountryInfo _country)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Country_Update", UpdateParameters(_country));
		}

		/// <summary>
		/// Update record(s) in 'Country' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(CountryInfo _country, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Country_UpdateAllWhere", UpdateAllWhereParameters(_country, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'Country' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__countryid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __countryid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Country_Delete", PKParameters(__countryid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'Country' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Country_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'Country' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'Country' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Country_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'Country' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'Country' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Country_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to Country object"
		/// <summary>
		/// Converts a data reader row to 'Country' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'CountryInfo' type
		/// </returns>
		protected static CountryInfo RowToObject(SqlDataReader reader, int index)
		{
			CountryInfo _country = new CountryInfo();

			if (!reader.IsDBNull(index))
				_country.Countryid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_country.Name = reader.GetString(index);
			index = index + 1;
			
			return _country;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'Country' table
		/// </summary>
		/// <param name="__countryid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __countryid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[0].Value = __countryid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'Country' table
		/// </summary>
		/// <param name="_country">CountryInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(CountryInfo _country)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);								

			bool[] status = _country.Diff();

			if (status[1])
				sqlParams[1].Value = _country.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'Country' table
		/// </summary>
		/// <param name="_country">CountryInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(CountryInfo _country)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _country.Diff();
			
			if (status[0])
				sqlParams[0].Value = _country.Countryid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _country.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'Country' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_country">CountryInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(CountryInfo _country, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _country.Diff();
			
			if (status[0])
				sqlParams[0].Value = _country.Countryid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _country.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(CountryInfo _country, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _country.Diff();
			
			if (status[0])
				sqlParams[0].Value = _country.Countryid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _country.Name;
			else
				sqlParams[1].Value = DBNull.Value;

   			sqlParams[2] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[2].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
