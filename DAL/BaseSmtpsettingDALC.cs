/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'SmtpSetting' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'SmtpsettingDALC' class.
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
	/// General database operations related to 'SmtpSetting' table
	/// </summary>
	public abstract class BaseSmtpsettingDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__pmhost">Primay key ID</param>
		/// <returns>
		/// SmtpsettingInfo object
		/// </returns>
		public static SmtpsettingInfo SelectByPK(string __pmhost)
		{ 
			SmtpsettingInfo _smtpsetting = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_SelectByPK", PKParameters(__pmhost));
			while (reader.Read())
				_smtpsetting = RowToObject(reader,0);
			reader.Close();
			
			return _smtpsetting;
		}
		
		/// <summary>
		/// Get a data reader against a primary key joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__pmhost">Primay key ID</param>
		/// <returns>
		/// SmtpsettingInfo object
		/// </returns>
		public static SmtpsettingInfo SelectFullByPK(string __pmhost)
		{
			//TODO only returning basic object currently
			SmtpsettingInfo _smtpsetting = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_SelectFullByPK", PKParameters(__pmhost));
			while (reader.Read())
				_smtpsetting = RowToObject(reader,0);
			reader.Close();
			
			return _smtpsetting;		
		} 
		
		/// <summary>
		/// Get all records from 'SmtpSetting' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of SmtpsettingInfo objects.
		/// </returns>
		public static IList<SmtpsettingInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_SelectAll");

			IList<SmtpsettingInfo> _items = new List<SmtpsettingInfo>();
			SmtpsettingInfo _smtpsetting = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_smtpsetting = RowToObject(reader,0);
				_items.Add(_smtpsetting);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'SmtpSetting' table joined to all foreign keys tables
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of SmtpsettingInfo objects.
		/// </returns>
		public static IList<SmtpsettingInfo> SelectAllFull()
		{	
			IList<SmtpsettingInfo> _items = new List<SmtpsettingInfo>();
			//SmtpsettingInfo _smtpsetting = null;
			//TODO full object
			return _items;
		} 
		
		/// <summary>
		/// Get all records from 'SmtpSetting' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<SmtpsettingInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_SelectAllWhere", sqlParams);

			IList<SmtpsettingInfo> _items = new List<SmtpsettingInfo>();
			SmtpsettingInfo _smtpsetting = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_smtpsetting = RowToObject(reader,0);
				_items.Add(_smtpsetting);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'SmtpSetting' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'SmtpSetting' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'SmtpSetting' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'SmtpSetting' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'SmtpSetting' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_smtpsetting">SmtpsettingInfo object</param>
		/// <returns>
		/// SmtpsettingInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static SmtpsettingInfo Insert(SmtpsettingInfo _smtpsetting) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_Insert", InsertParameters(_smtpsetting));
			
			return _smtpsetting;
		}
		
		/// <summary>
		/// Update a record in 'SmtpSetting' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_smtpsetting">SmtpsettingInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(SmtpsettingInfo _smtpsetting)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_Update", UpdateParameters(_smtpsetting));
		}

		/// <summary>
		/// Update record(s) in 'SmtpSetting' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(SmtpsettingInfo _smtpsetting, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_UpdateAllWhere", UpdateAllWhereParameters(_smtpsetting, _whereClause));
		}
		
		/// <summary>
		/// Update all records in 'SmtpSetting' table matching to the foreign key value
		/// This method is available for tables who have foreign key(s) defined		
		/// </summary>
		/// <param name="_smtpsetting">SmtpsettingInfo object</param>
		/// <param name="__updatedby">Foreign key value</param>		
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllByFKUpdatedby(SmtpsettingInfo _smtpsetting, int __updatedby)
		{
			SqlParameter[] sqlParams = UpdateParameters(_smtpsetting, 8);
			// Last parameter containing FK
   			sqlParams[8] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[8].Value = __updatedby;
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_UpdateAllByFK_UpdatedBy", UpdateParameters(_smtpsetting,8));
		}
		
		/// <summary>
		/// Delete a record in 'SmtpSetting' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__pmhost">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(string __pmhost) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_Delete", PKParameters(__pmhost));	
		}
		
		/// <summary>
		/// Delete record(s) in 'SmtpSetting' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_DeleteAllWhere", sqlParams);		
		}

		/// <summary>
		/// Delete a record in 'SmtpSetting' table.
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
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_DeleteAllByFK_UpdatedBy", sqlParams);
		}		
		
		/// <summary>
		/// Get all records from 'SmtpSetting' table matching to the foreign key 'UpdatedBy'
		/// This method is generated for tables who have foreign key(s)
		/// </summary>
		/// <param name="__updatedby">Foreign key value</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Collection of objects matching with 'UpdatedBy' foreign key value
		/// </returns>
		public static IList<SmtpsettingInfo> SelectAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UpdatedBy", "SqlDbType.Int");
			sqlParams[0].Value = __updatedby;
			
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_SelectAllByFK_UpdatedBy", sqlParams);

			IList<SmtpsettingInfo> _items = new List<SmtpsettingInfo>();
			SmtpsettingInfo _smtpsetting = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_smtpsetting = RowToObject(reader,0);
				_items.Add(_smtpsetting);
			}
			reader.Close();
			return _items;
		} 

		/// <summary>
		/// Get a count of all records from 'SmtpSetting' table matching to the foreign key 'UpdatedBy'
		/// This method is generated for tables who have foreign key(s)		
		/// </summary>
		/// <param name="__updatedby">Foreign key value</param>
		/// <returns>
		/// Total number of records from 'SmtpSetting' table matching with 'UpdatedBy' foreign key value
		/// </returns>
		public static int CountAllByFKUpdatedby(int __updatedby)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
			sqlParams[0] = new SqlParameter("@UpdatedBy", SqlDbType.Int);
			sqlParams[0].Value = __updatedby;
			
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_CountAllByFK_UpdatedBy", sqlParams);
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'SmtpSetting' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'SmtpSetting' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'SmtpSetting' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'SmtpSetting' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "SmtpSetting_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to SmtpSetting object"
		/// <summary>
		/// Converts a data reader row to 'SmtpSetting' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'SmtpsettingInfo' type
		/// </returns>
		protected static SmtpsettingInfo RowToObject(SqlDataReader reader, int index)
		{
			SmtpsettingInfo _smtpsetting = new SmtpsettingInfo();

			if (!reader.IsDBNull(index))
				_smtpsetting.Pmhost = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_smtpsetting.Pmport = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_smtpsetting.Pmusername = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_smtpsetting.Pmpasswrd = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_smtpsetting.Pmsecure = reader.GetBoolean(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_smtpsetting.Updateddate = reader.GetDateTime(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_smtpsetting.Updatedby = reader.GetInt32(index);
			index = index + 1;
			
			return _smtpsetting;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'SmtpSetting' table
		/// </summary>
		/// <param name="__pmhost">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(string __pmhost) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@pmHost", SqlDbType.VarChar);
			sqlParams[0].Value = __pmhost;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'SmtpSetting' table
		/// </summary>
		/// <param name="_smtpsetting">SmtpsettingInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(SmtpsettingInfo _smtpsetting)
		{
			SqlParameter[] sqlParams = new SqlParameter[7];		
			sqlParams[0] = new SqlParameter("@pmHost", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@pmPort", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@pmUserName", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@pmPasswrd", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@pmSecure", SqlDbType.Bit);
			sqlParams[5] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[6] = new SqlParameter("@UpdatedBy", SqlDbType.Int);								

			bool[] status = _smtpsetting.Diff();

			if (status[0])
				sqlParams[0].Value = _smtpsetting.Pmhost;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _smtpsetting.Pmport;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _smtpsetting.Pmusername;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _smtpsetting.Pmpasswrd;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _smtpsetting.Pmsecure;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _smtpsetting.Updateddate;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _smtpsetting.Updatedby;
			else
				sqlParams[6].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'SmtpSetting' table
		/// </summary>
		/// <param name="_smtpsetting">SmtpsettingInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(SmtpsettingInfo _smtpsetting)
		{
			SqlParameter[] sqlParams = new SqlParameter[7];		
			sqlParams[0] = new SqlParameter("@pmHost", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@pmPort", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@pmUserName", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@pmPasswrd", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@pmSecure", SqlDbType.Bit);
			sqlParams[5] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[6] = new SqlParameter("@UpdatedBy", SqlDbType.Int);

			bool[] status = _smtpsetting.Diff();
			
			if (status[0])
				sqlParams[0].Value = _smtpsetting.Pmhost;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _smtpsetting.Pmport;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _smtpsetting.Pmusername;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _smtpsetting.Pmpasswrd;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _smtpsetting.Pmsecure;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _smtpsetting.Updateddate;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _smtpsetting.Updatedby;
			else
				sqlParams[6].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'SmtpSetting' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_smtpsetting">SmtpsettingInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(SmtpsettingInfo _smtpsetting, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@pmHost", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@pmPort", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@pmUserName", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@pmPasswrd", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@pmSecure", SqlDbType.Bit);
			sqlParams[5] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[6] = new SqlParameter("@UpdatedBy", SqlDbType.Int);

			bool[] status = _smtpsetting.Diff();
			
			if (status[0])
				sqlParams[0].Value = _smtpsetting.Pmhost;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _smtpsetting.Pmport;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _smtpsetting.Pmusername;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _smtpsetting.Pmpasswrd;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _smtpsetting.Pmsecure;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _smtpsetting.Updateddate;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _smtpsetting.Updatedby;
			else
				sqlParams[6].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(SmtpsettingInfo _smtpsetting, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[8];		
			sqlParams[0] = new SqlParameter("@pmHost", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@pmPort", SqlDbType.Int);
			sqlParams[2] = new SqlParameter("@pmUserName", SqlDbType.VarChar);
			sqlParams[3] = new SqlParameter("@pmPasswrd", SqlDbType.VarChar);
			sqlParams[4] = new SqlParameter("@pmSecure", SqlDbType.Bit);
			sqlParams[5] = new SqlParameter("@UpdatedDate", SqlDbType.DateTime);
			sqlParams[6] = new SqlParameter("@UpdatedBy", SqlDbType.Int);

			bool[] status = _smtpsetting.Diff();
			
			if (status[0])
				sqlParams[0].Value = _smtpsetting.Pmhost;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _smtpsetting.Pmport;
			else
				sqlParams[1].Value = DBNull.Value;
			if (status[2])
				sqlParams[2].Value = _smtpsetting.Pmusername;
			else
				sqlParams[2].Value = DBNull.Value;
			if (status[3])
				sqlParams[3].Value = _smtpsetting.Pmpasswrd;
			else
				sqlParams[3].Value = DBNull.Value;
			if (status[4])
				sqlParams[4].Value = _smtpsetting.Pmsecure;
			else
				sqlParams[4].Value = DBNull.Value;
			if (status[5])
				sqlParams[5].Value = _smtpsetting.Updateddate;
			else
				sqlParams[5].Value = DBNull.Value;
			if (status[6])
				sqlParams[6].Value = _smtpsetting.Updatedby;
			else
				sqlParams[6].Value = DBNull.Value;

   			sqlParams[7] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[7].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
