/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'UserToken' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'UsertokenDALC' class.
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
	/// General database operations related to 'UserToken' table
	/// </summary>
	public abstract class BaseUsertokenDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__tokenid">Primay key ID</param>
		/// <returns>
		/// UsertokenInfo object
		/// </returns>
		public static UsertokenInfo SelectByPK(int __tokenid)
		{ 
			UsertokenInfo _usertoken = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "UserToken_SelectByPK", PKParameters(__tokenid));
			while (reader.Read())
				_usertoken = RowToObject(reader,0);
			reader.Close();
			
			return _usertoken;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__tokenid">Primay key ID</param>
		/// <returns>
		/// UsertokenInfo object
		/// </returns>
		public static UsertokenInfo SelectFullByPK(int __tokenid)
		{
			//TODO only returning basic object currently
			UsertokenInfo _usertoken = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "UserToken_SelectFullByPK", PKParameters(__tokenid));
			while (reader.Read())
				_usertoken = RowToObject(reader,0);
			reader.Close();
			
			return _usertoken;		
		} 
		
		/// <summary>
		/// Get all records from 'UserToken' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of UsertokenInfo objects.
		/// </returns>
		public static IList<UsertokenInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "UserToken_SelectAll");

			IList<UsertokenInfo> _items = new List<UsertokenInfo>();
			UsertokenInfo _usertoken = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_usertoken = RowToObject(reader,0);
				_items.Add(_usertoken);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'UserToken' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of UsertokenInfo objects.
		/// </returns>
		public static IList<UsertokenInfo> SelectAllFull()
		{	
			IList<UsertokenInfo> _items = new List<UsertokenInfo>();
			//UsertokenInfo _usertoken = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'UserToken' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<UsertokenInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "UserToken_SelectAllWhere", sqlParams);

			IList<UsertokenInfo> _items = new List<UsertokenInfo>();
			UsertokenInfo _usertoken = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_usertoken = RowToObject(reader,0);
				_items.Add(_usertoken);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'UserToken' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'UserToken' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "UserToken_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'UserToken' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'UserToken' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "UserToken_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'UserToken' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_usertoken">UsertokenInfo object</param>
		/// <returns>
		/// UsertokenInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static UsertokenInfo Insert(UsertokenInfo _usertoken) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "UserToken_Insert", InsertParameters(_usertoken));
			_usertoken.Tokenid = autoNumValue;
			
			return _usertoken;
		}
		
		/// <summary>
		/// Update a record in 'UserToken' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_usertoken">UsertokenInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(UsertokenInfo _usertoken)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "UserToken_Update", UpdateParameters(_usertoken));
		}

		/// <summary>
		/// Update record(s) in 'UserToken' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(UsertokenInfo _usertoken, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "UserToken_UpdateAllWhere", UpdateAllWhereParameters(_usertoken, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'UserToken' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_usertoken">UsertokenInfo object</param>
		/// <param name="__userid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKUserid(UsertokenInfo _usertoken, int __userid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_usertoken, 6);
			// Last parameter containing FK
   			sqlParams[6] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[6].Value = __userid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "UserToken_UpdateAllByFK_UserId", UpdateParameters(_usertoken,6));
		}
		
		/// <summary>
		/// Delete a record in 'UserToken' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__tokenid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __tokenid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "UserToken_Delete", PKParameters(__tokenid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'UserToken' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "UserToken_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'UserToken' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="UserId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKUserid(int __userid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[0].Value = __userid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "UserToken_DeleteAllByFK_UserId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'UserToken' table matching to the foreign key 'UserId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__userid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'UserId' foreign key value
		/// </returns>
		public static IList<UsertokenInfo> SelectAllByFKUserid(int __userid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UserId", "SqlDbType.Int");
			sqlParams[0].Value = __userid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "UserToken_SelectAllByFK_UserId", sqlParams);

			IList<UsertokenInfo> _items = new List<UsertokenInfo>();
			UsertokenInfo _usertoken = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_usertoken = RowToObject(reader,0);
				_items.Add(_usertoken);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'UserToken' table matching to the foreign key 'UserId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__userid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'UserToken' table matching with 'UserId' foreign key value
		/// </returns>
		public static int CountAllByFKUserid(int __userid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[0].Value = __userid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "UserToken_CountAllByFK_UserId", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'UserToken' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'UserToken' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "UserToken_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'UserToken' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'UserToken' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "UserToken_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to UserToken object"
		/// <summary>
		/// Converts a data reader row to 'UserToken' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'UsertokenInfo' type
		/// </returns>
		protected static UsertokenInfo RowToObject(SqlDataReader reader, int index)
		{
			UsertokenInfo _usertoken = new UsertokenInfo();

			if (!reader.IsDBNull(index))
				_usertoken.Tokenid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_usertoken.Userid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_usertoken.Token = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_usertoken.Createdtime = reader.GetDateTime(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_usertoken.Expiretime = reader.GetDateTime(index);
			index = index + 1;
			
			return _usertoken;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'UserToken' table
		/// </summary>
		/// <param name="__tokenid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __tokenid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@TokenId", SqlDbType.Int);
			sqlParams[0].Value = __tokenid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'UserToken' table
		/// </summary>
		/// <param name="_usertoken">UsertokenInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(UsertokenInfo _usertoken)
		{
			SqlParameter[] sqlParams = new SqlParameter[5];		
			sqlParams[0] = new SqlParameter("@TokenId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Token", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CreatedTime", SqlDbType.DateTime);
			sqlParams[4] = new SqlParameter("@ExpireTime", SqlDbType.DateTime);								

			bool[] status = _usertoken.Diff();

			if (status[1])
				sqlParams[1].Value = _usertoken.Userid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _usertoken.Token;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _usertoken.Createdtime;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _usertoken.Expiretime;
			else
				sqlParams[4].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'UserToken' table
		/// </summary>
		/// <param name="_usertoken">UsertokenInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(UsertokenInfo _usertoken)
		{
			SqlParameter[] sqlParams = new SqlParameter[5];		
			sqlParams[0] = new SqlParameter("@TokenId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Token", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CreatedTime", SqlDbType.DateTime);
			sqlParams[4] = new SqlParameter("@ExpireTime", SqlDbType.DateTime);

			bool[] status = _usertoken.Diff();
			
			if (status[0])
				sqlParams[0].Value = _usertoken.Tokenid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _usertoken.Userid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _usertoken.Token;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _usertoken.Createdtime;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _usertoken.Expiretime;
			else
				sqlParams[4].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'UserToken' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_usertoken">UsertokenInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(UsertokenInfo _usertoken, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@TokenId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Token", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CreatedTime", SqlDbType.DateTime);
			sqlParams[4] = new SqlParameter("@ExpireTime", SqlDbType.DateTime);

			bool[] status = _usertoken.Diff();
			
			if (status[0])
				sqlParams[0].Value = _usertoken.Tokenid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _usertoken.Userid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _usertoken.Token;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _usertoken.Createdtime;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _usertoken.Expiretime;
			else
				sqlParams[4].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(UsertokenInfo _usertoken, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[6];		
			sqlParams[0] = new SqlParameter("@TokenId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@Token", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@CreatedTime", SqlDbType.DateTime);
			sqlParams[4] = new SqlParameter("@ExpireTime", SqlDbType.DateTime);

			bool[] status = _usertoken.Diff();
			
			if (status[0])
				sqlParams[0].Value = _usertoken.Tokenid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _usertoken.Userid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _usertoken.Token;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _usertoken.Createdtime;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _usertoken.Expiretime;
			else
				sqlParams[4].Value = DBNull.Value;

   			sqlParams[5] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[5].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
