/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'CountryState' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'CountrystateDALC' class.
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
	/// General database operations related to 'CountryState' table
	/// </summary>
	public abstract class BaseCountrystateDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__stateid">Primay key ID</param>
		/// <returns>
		/// CountrystateInfo object
		/// </returns>
		public static CountrystateInfo SelectByPK(int __stateid)
		{ 
			CountrystateInfo _countrystate = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "CountryState_SelectByPK", PKParameters(__stateid));
			while (reader.Read())
				_countrystate = RowToObject(reader,0);
			reader.Close();
			
			return _countrystate;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__stateid">Primay key ID</param>
		/// <returns>
		/// CountrystateInfo object
		/// </returns>
		public static CountrystateInfo SelectFullByPK(int __stateid)
		{
			//TODO only returning basic object currently
			CountrystateInfo _countrystate = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "CountryState_SelectFullByPK", PKParameters(__stateid));
			while (reader.Read())
				_countrystate = RowToObject(reader,0);
			reader.Close();
			
			return _countrystate;		
		} 
		
		/// <summary>
		/// Get all records from 'CountryState' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of CountrystateInfo objects.
		/// </returns>
		public static IList<CountrystateInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "CountryState_SelectAll");

			IList<CountrystateInfo> _items = new List<CountrystateInfo>();
			CountrystateInfo _countrystate = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_countrystate = RowToObject(reader,0);
				_items.Add(_countrystate);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'CountryState' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of CountrystateInfo objects.
		/// </returns>
		public static IList<CountrystateInfo> SelectAllFull()
		{	
			IList<CountrystateInfo> _items = new List<CountrystateInfo>();
			//CountrystateInfo _countrystate = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'CountryState' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<CountrystateInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "CountryState_SelectAllWhere", sqlParams);

			IList<CountrystateInfo> _items = new List<CountrystateInfo>();
			CountrystateInfo _countrystate = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_countrystate = RowToObject(reader,0);
				_items.Add(_countrystate);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'CountryState' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'CountryState' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "CountryState_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'CountryState' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'CountryState' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "CountryState_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'CountryState' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_countrystate">CountrystateInfo object</param>
		/// <returns>
		/// CountrystateInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static CountrystateInfo Insert(CountrystateInfo _countrystate) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "CountryState_Insert", InsertParameters(_countrystate));
			_countrystate.Stateid = autoNumValue;
			
			return _countrystate;
		}
		
		/// <summary>
		/// Update a record in 'CountryState' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_countrystate">CountrystateInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(CountrystateInfo _countrystate)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "CountryState_Update", UpdateParameters(_countrystate));
		}

		/// <summary>
		/// Update record(s) in 'CountryState' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(CountrystateInfo _countrystate, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "CountryState_UpdateAllWhere", UpdateAllWhereParameters(_countrystate, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'CountryState' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_countrystate">CountrystateInfo object</param>
		/// <param name="__countryid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKCountryid(CountrystateInfo _countrystate, int __countryid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_countrystate, 4);
			// Last parameter containing FK
   			sqlParams[4] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[4].Value = __countryid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "CountryState_UpdateAllByFK_CountryId", UpdateParameters(_countrystate,4));
		}
		
		/// <summary>
		/// Delete a record in 'CountryState' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__stateid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __stateid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "CountryState_Delete", PKParameters(__stateid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'CountryState' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "CountryState_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'CountryState' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="CountryId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKCountryid(int __countryid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[0].Value = __countryid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "CountryState_DeleteAllByFK_CountryId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'CountryState' table matching to the foreign key 'CountryId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__countryid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'CountryId' foreign key value
		/// </returns>
		public static IList<CountrystateInfo> SelectAllByFKCountryid(int __countryid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CountryId", "SqlDbType.Int");
			sqlParams[0].Value = __countryid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "CountryState_SelectAllByFK_CountryId", sqlParams);

			IList<CountrystateInfo> _items = new List<CountrystateInfo>();
			CountrystateInfo _countrystate = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_countrystate = RowToObject(reader,0);
				_items.Add(_countrystate);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'CountryState' table matching to the foreign key 'CountryId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__countryid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'CountryState' table matching with 'CountryId' foreign key value
		/// </returns>
		public static int CountAllByFKCountryid(int __countryid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[0].Value = __countryid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "CountryState_CountAllByFK_CountryId", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'CountryState' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'CountryState' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "CountryState_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'CountryState' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'CountryState' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "CountryState_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to CountryState object"
		/// <summary>
		/// Converts a data reader row to 'CountryState' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'CountrystateInfo' type
		/// </returns>
		protected static CountrystateInfo RowToObject(SqlDataReader reader, int index)
		{
			CountrystateInfo _countrystate = new CountrystateInfo();

			if (!reader.IsDBNull(index))
				_countrystate.Stateid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_countrystate.Countryid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_countrystate.Name = reader.GetString(index);
			index = index + 1;
			
			return _countrystate;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'CountryState' table
		/// </summary>
		/// <param name="__stateid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __stateid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[0].Value = __stateid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'CountryState' table
		/// </summary>
		/// <param name="_countrystate">CountrystateInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(CountrystateInfo _countrystate)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);								

			bool[] status = _countrystate.Diff();

			if (status[1])
				sqlParams[1].Value = _countrystate.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _countrystate.Name;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'CountryState' table
		/// </summary>
		/// <param name="_countrystate">CountrystateInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(CountrystateInfo _countrystate)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _countrystate.Diff();
			
			if (status[0])
				sqlParams[0].Value = _countrystate.Stateid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _countrystate.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _countrystate.Name;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'CountryState' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_countrystate">CountrystateInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(CountrystateInfo _countrystate, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _countrystate.Diff();
			
			if (status[0])
				sqlParams[0].Value = _countrystate.Stateid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _countrystate.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _countrystate.Name;
			else
				sqlParams[2].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(CountrystateInfo _countrystate, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[4];		
			sqlParams[0] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _countrystate.Diff();
			
			if (status[0])
				sqlParams[0].Value = _countrystate.Stateid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _countrystate.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _countrystate.Name;
			else
				sqlParams[2].Value = DBNull.Value;

   			sqlParams[3] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[3].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
