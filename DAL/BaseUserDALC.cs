/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'User' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'UserDALC' class.
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
	/// General database operations related to 'User' table
	/// </summary>
	public abstract class BaseUserDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__userid">Primay key ID</param>
		/// <returns>
		/// UserInfo object
		/// </returns>
		public static UserInfo SelectByPK(int __userid)
		{ 
			UserInfo _user = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectByPK", PKParameters(__userid));
			while (reader.Read())
				_user = RowToObject(reader,0);
			reader.Close();
			
			return _user;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__userid">Primay key ID</param>
		/// <returns>
		/// UserInfo object
		/// </returns>
		public static UserInfo SelectFullByPK(int __userid)
		{
			//TODO only returning basic object currently
			UserInfo _user = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectFullByPK", PKParameters(__userid));
			while (reader.Read())
				_user = RowToObject(reader,0);
			reader.Close();
			
			return _user;		
		} 
		
		/// <summary>
		/// Get all records from 'User' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of UserInfo objects.
		/// </returns>
		public static IList<UserInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectAll");

			IList<UserInfo> _items = new List<UserInfo>();
			UserInfo _user = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_user = RowToObject(reader,0);
				_items.Add(_user);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'User' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of UserInfo objects.
		/// </returns>
		public static IList<UserInfo> SelectAllFull()
		{	
			IList<UserInfo> _items = new List<UserInfo>();
			//UserInfo _user = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'User' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<UserInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectAllWhere", sqlParams);

			IList<UserInfo> _items = new List<UserInfo>();
			UserInfo _user = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_user = RowToObject(reader,0);
				_items.Add(_user);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'User' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'User' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "User_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'User' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'User' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "User_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'User' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <returns>
		/// UserInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static UserInfo Insert(UserInfo _user) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "User_Insert", InsertParameters(_user));
			_user.Userid = autoNumValue;
			
			return _user;
		}
		
		/// <summary>
		/// Update a record in 'User' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(UserInfo _user)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_Update", UpdateParameters(_user));
		}

		/// <summary>
		/// Update record(s) in 'User' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(UserInfo _user, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_UpdateAllWhere", UpdateAllWhereParameters(_user, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'User' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <param name="__countryid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKCountryid(UserInfo _user, int __countryid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_user, 19);
			// Last parameter containing FK
   			sqlParams[19] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[19].Value = __countryid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_UpdateAllByFK_CountryId", UpdateParameters(_user,19));
		}
		
		/// <summary>
		/// Update all records in 'User' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <param name="__stateid">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKStateid(UserInfo _user, int __stateid)
		{
			SqlParameter[] sqlParams = UpdateParameters(_user, 19);
			// Last parameter containing FK
   			sqlParams[19] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[19].Value = __stateid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_UpdateAllByFK_StateId", UpdateParameters(_user,19));
		}
		
		/// <summary>
		/// Update all records in 'User' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <param name="__updatedby">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKUpdatedby(UserInfo _user, int __updatedby)
		{
			SqlParameter[] sqlParams = UpdateParameters(_user, 19);
			// Last parameter containing FK
   			sqlParams[19] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[19].Value = __updatedby;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_UpdateAllByFK_UpdatedBy", UpdateParameters(_user,19));
		}
		
		/// <summary>
		/// Delete a record in 'User' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__userid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __userid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_Delete", PKParameters(__userid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'User' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'User' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_DeleteAllByFK_CountryId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'User' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="StateId">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKStateid(int __stateid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[0].Value = __stateid;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_DeleteAllByFK_StateId", sqlParams);
		}

		/// <summary>
		/// Delete a record in 'User' table.
		/// This method is available for tables who have foreign key(s) defined	
		/// </summary>
		/// <param name="UpdatedBy">Foreign key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void DeleteAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[0].Value = __updatedby;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "User_DeleteAllByFK_UpdatedBy", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'User' table matching to the foreign key 'CountryId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__countryid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'CountryId' foreign key value
		/// </returns>
		public static IList<UserInfo> SelectAllByFKCountryid(int __countryid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CountryId", "SqlDbType.Int");
			sqlParams[0].Value = __countryid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectAllByFK_CountryId", sqlParams);

			IList<UserInfo> _items = new List<UserInfo>();
			UserInfo _user = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_user = RowToObject(reader,0);
				_items.Add(_user);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'User' table matching to the foreign key 'CountryId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__countryid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'User' table matching with 'CountryId' foreign key value
		/// </returns>
		public static int CountAllByFKCountryid(int __countryid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[0].Value = __countryid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "User_CountAllByFK_CountryId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'User' table matching to the foreign key 'StateId'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__stateid">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'StateId' foreign key value
		/// </returns>
		public static IList<UserInfo> SelectAllByFKStateid(int __stateid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@StateId", "SqlDbType.Int");
			sqlParams[0].Value = __stateid;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectAllByFK_StateId", sqlParams);

			IList<UserInfo> _items = new List<UserInfo>();
			UserInfo _user = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_user = RowToObject(reader,0);
				_items.Add(_user);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'User' table matching to the foreign key 'StateId'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__stateid">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'User' table matching with 'StateId' foreign key value
		/// </returns>
		public static int CountAllByFKStateid(int __stateid)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[0].Value = __stateid;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "User_CountAllByFK_StateId", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'User' table matching to the foreign key 'UpdatedBy'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__updatedby">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'UpdatedBy' foreign key value
		/// </returns>
		public static IList<UserInfo> SelectAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UpdatedBy", "SqlDbType.Int");
			sqlParams[0].Value = __updatedby;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "User_SelectAllByFK_UpdatedBy", sqlParams);

			IList<UserInfo> _items = new List<UserInfo>();
			UserInfo _user = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_user = RowToObject(reader,0);
				_items.Add(_user);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'User' table matching to the foreign key 'UpdatedBy'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__updatedby">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'User' table matching with 'UpdatedBy' foreign key value
		/// </returns>
		public static int CountAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[0].Value = __updatedby;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "User_CountAllByFK_UpdatedBy", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'User' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'User' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "User_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'User' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'User' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "User_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to User object"
		/// <summary>
		/// Converts a data reader row to 'User' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'UserInfo' type
		/// </returns>
		protected static UserInfo RowToObject(SqlDataReader reader, int index)
		{
			UserInfo _user = new UserInfo();

			if (!reader.IsDBNull(index))
				_user.Userid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Countryid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Stateid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Username = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Firstname = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Lastname = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Password = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Email = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.City = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Address = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Phone = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Createddate = reader.GetDateTime(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Updateddate = reader.GetDateTime(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Updatedby = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Isadminright = reader.GetBoolean(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Isdefault = reader.GetBoolean(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Isdeleted = reader.GetBoolean(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_user.Isenabled = reader.GetBoolean(index);
			index = index + 1;
			
			return _user;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'User' table
		/// </summary>
		/// <param name="__userid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __userid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[0].Value = __userid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'User' table
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(UserInfo _user)
		{
			SqlParameter[] sqlParams = new SqlParameter[18];		
			sqlParams[0] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@UserName", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@FirstName", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@LastName", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@Password", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@Email", SqlDbType.VarChar);
			sqlParams[8] = new SqlParameter("@City", SqlDbType.VarChar);
			sqlParams[9] = new SqlParameter("@Address", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@Phone", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[12] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[14] = new SqlParameter("@IsAdminRight", SqlDbType.Bit);
			sqlParams[15] = new SqlParameter("@IsDefault", SqlDbType.Bit);
			sqlParams[16] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
			sqlParams[17] = new SqlParameter("@IsEnabled", SqlDbType.Bit);								

			bool[] status = _user.Diff();

			if (status[1])
				sqlParams[1].Value = _user.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _user.Stateid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _user.Username;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _user.Firstname;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _user.Lastname;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _user.Password;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _user.Email;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _user.City;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _user.Address;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _user.Phone;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _user.Createddate;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _user.Updateddate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _user.Updatedby;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _user.Isadminright;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _user.Isdefault;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _user.Isdeleted;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _user.Isenabled;
			else
				sqlParams[17].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'User' table
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(UserInfo _user)
		{
			SqlParameter[] sqlParams = new SqlParameter[18];		
			sqlParams[0] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@UserName", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@FirstName", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@LastName", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@Password", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@Email", SqlDbType.VarChar);
			sqlParams[8] = new SqlParameter("@City", SqlDbType.VarChar);
			sqlParams[9] = new SqlParameter("@Address", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@Phone", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[12] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[14] = new SqlParameter("@IsAdminRight", SqlDbType.Bit);
			sqlParams[15] = new SqlParameter("@IsDefault", SqlDbType.Bit);
			sqlParams[16] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
			sqlParams[17] = new SqlParameter("@IsEnabled", SqlDbType.Bit);

			bool[] status = _user.Diff();
			
			if (status[0])
				sqlParams[0].Value = _user.Userid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _user.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _user.Stateid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _user.Username;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _user.Firstname;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _user.Lastname;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _user.Password;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _user.Email;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _user.City;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _user.Address;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _user.Phone;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _user.Createddate;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _user.Updateddate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _user.Updatedby;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _user.Isadminright;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _user.Isdefault;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _user.Isdeleted;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _user.Isenabled;
			else
				sqlParams[17].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'User' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_user">UserInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(UserInfo _user, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@UserName", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@FirstName", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@LastName", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@Password", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@Email", SqlDbType.VarChar);
			sqlParams[8] = new SqlParameter("@City", SqlDbType.VarChar);
			sqlParams[9] = new SqlParameter("@Address", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@Phone", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[12] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[14] = new SqlParameter("@IsAdminRight", SqlDbType.Bit);
			sqlParams[15] = new SqlParameter("@IsDefault", SqlDbType.Bit);
			sqlParams[16] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
			sqlParams[17] = new SqlParameter("@IsEnabled", SqlDbType.Bit);

			bool[] status = _user.Diff();
			
			if (status[0])
				sqlParams[0].Value = _user.Userid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _user.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _user.Stateid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _user.Username;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _user.Firstname;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _user.Lastname;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _user.Password;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _user.Email;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _user.City;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _user.Address;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _user.Phone;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _user.Createddate;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _user.Updateddate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _user.Updatedby;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _user.Isadminright;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _user.Isdefault;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _user.Isdeleted;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _user.Isenabled;
			else
				sqlParams[17].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(UserInfo _user, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[19];		
			sqlParams[0] = new SqlParameter("@UserId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@CountryId", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@StateId", SqlDbType.Int);
			sqlParams[3] = new SqlParameter("@UserName", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@FirstName", SqlDbType.VarChar);
			sqlParams[5] = new SqlParameter("@LastName", SqlDbType.VarChar);
			sqlParams[6] = new SqlParameter("@Password", SqlDbType.VarChar);
			sqlParams[7] = new SqlParameter("@Email", SqlDbType.VarChar);
			sqlParams[8] = new SqlParameter("@City", SqlDbType.VarChar);
			sqlParams[9] = new SqlParameter("@Address", SqlDbType.VarChar);
			sqlParams[10] = new SqlParameter("@Phone", SqlDbType.VarChar);
			sqlParams[11] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
			sqlParams[12] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[13] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[14] = new SqlParameter("@IsAdminRight", SqlDbType.Bit);
			sqlParams[15] = new SqlParameter("@IsDefault", SqlDbType.Bit);
			sqlParams[16] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
			sqlParams[17] = new SqlParameter("@IsEnabled", SqlDbType.Bit);

			bool[] status = _user.Diff();
			
			if (status[0])
				sqlParams[0].Value = _user.Userid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _user.Countryid;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _user.Stateid;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _user.Username;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _user.Firstname;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _user.Lastname;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _user.Password;
			else
				sqlParams[6].Value = DBNull.Value;
			if (status[7])
				sqlParams[7].Value = _user.Email;
			else
				sqlParams[7].Value = DBNull.Value;
			if (status[8])
				sqlParams[8].Value = _user.City;
			else
				sqlParams[8].Value = DBNull.Value;
			if (status[9])
				sqlParams[9].Value = _user.Address;
			else
				sqlParams[9].Value = DBNull.Value;
			if (status[10])
				sqlParams[10].Value = _user.Phone;
			else
				sqlParams[10].Value = DBNull.Value;
			if (status[11])
				sqlParams[11].Value = _user.Createddate;
			else
				sqlParams[11].Value = DBNull.Value;
			if (status[12])
				sqlParams[12].Value = _user.Updateddate;
			else
				sqlParams[12].Value = DBNull.Value;
			if (status[13])
				sqlParams[13].Value = _user.Updatedby;
			else
				sqlParams[13].Value = DBNull.Value;
			if (status[14])
				sqlParams[14].Value = _user.Isadminright;
			else
				sqlParams[14].Value = DBNull.Value;
			if (status[15])
				sqlParams[15].Value = _user.Isdefault;
			else
				sqlParams[15].Value = DBNull.Value;
			if (status[16])
				sqlParams[16].Value = _user.Isdeleted;
			else
				sqlParams[16].Value = DBNull.Value;
			if (status[17])
				sqlParams[17].Value = _user.Isenabled;
			else
				sqlParams[17].Value = DBNull.Value;

   			sqlParams[18] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[18].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
