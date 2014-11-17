/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'ContentType' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'ContenttypeDALC' class.
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
	/// General database operations related to 'ContentType' table
	/// </summary>
	public abstract class BaseContenttypeDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__contenttypecode">Primay key ID</param>
		/// <returns>
		/// ContenttypeInfo object
		/// </returns>
		public static ContenttypeInfo SelectByPK(string __contenttypecode)
		{ 
			ContenttypeInfo _contenttype = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentType_SelectByPK", PKParameters(__contenttypecode));
			while (reader.Read())
				_contenttype = RowToObject(reader,0);
			reader.Close();
			
			return _contenttype;
		}
		
		/// <summary>
		/// Get all records from 'ContentType' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of ContenttypeInfo objects.
		/// </returns>
		public static IList<ContenttypeInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentType_SelectAll");

			IList<ContenttypeInfo> _items = new List<ContenttypeInfo>();
			ContenttypeInfo _contenttype = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contenttype = RowToObject(reader,0);
				_items.Add(_contenttype);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'ContentType' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<ContenttypeInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "ContentType_SelectAllWhere", sqlParams);

			IList<ContenttypeInfo> _items = new List<ContenttypeInfo>();
			ContenttypeInfo _contenttype = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_contenttype = RowToObject(reader,0);
				_items.Add(_contenttype);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'ContentType' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'ContentType' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentType_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'ContentType' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'ContentType' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "ContentType_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'ContentType' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_contenttype">ContenttypeInfo object</param>
		/// <returns>
		/// ContenttypeInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static ContenttypeInfo Insert(ContenttypeInfo _contenttype) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentType_Insert", InsertParameters(_contenttype));
			
			return _contenttype;
		}
		
		/// <summary>
		/// Update a record in 'ContentType' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_contenttype">ContenttypeInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(ContenttypeInfo _contenttype)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentType_Update", UpdateParameters(_contenttype));
		}

		/// <summary>
		/// Update record(s) in 'ContentType' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(ContenttypeInfo _contenttype, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentType_UpdateAllWhere", UpdateAllWhereParameters(_contenttype, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'ContentType' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__contenttypecode">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(string __contenttypecode) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentType_Delete", PKParameters(__contenttypecode));	
		}
		
		/// <summary>
		/// Delete record(s) in 'ContentType' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "ContentType_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'ContentType' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'ContentType' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentType_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'ContentType' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'ContentType' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "ContentType_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to ContentType object"
		/// <summary>
		/// Converts a data reader row to 'ContentType' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'ContenttypeInfo' type
		/// </returns>
		protected static ContenttypeInfo RowToObject(SqlDataReader reader, int index)
		{
			ContenttypeInfo _contenttype = new ContenttypeInfo();

			if (!reader.IsDBNull(index))
				_contenttype.Contenttypecode = reader.GetString(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_contenttype.Contenttype = reader.GetString(index);
			index = index + 1;
			
			return _contenttype;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'ContentType' table
		/// </summary>
		/// <param name="__contenttypecode">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(string __contenttypecode) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[0].Value = __contenttypecode;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'ContentType' table
		/// </summary>
		/// <param name="_contenttype">ContenttypeInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(ContenttypeInfo _contenttype)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@ContentType", SqlDbType.VarChar);								

			bool[] status = _contenttype.Diff();

			if (status[0])
				sqlParams[0].Value = _contenttype.Contenttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contenttype.Contenttype;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'ContentType' table
		/// </summary>
		/// <param name="_contenttype">ContenttypeInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(ContenttypeInfo _contenttype)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@ContentType", SqlDbType.VarChar);

			bool[] status = _contenttype.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contenttype.Contenttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contenttype.Contenttype;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'ContentType' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_contenttype">ContenttypeInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(ContenttypeInfo _contenttype, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@ContentType", SqlDbType.VarChar);

			bool[] status = _contenttype.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contenttype.Contenttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contenttype.Contenttype;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(ContenttypeInfo _contenttype, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@ContentTypeCode", SqlDbType.VarChar);
			sqlParams[1] = new SqlParameter("@ContentType", SqlDbType.VarChar);

			bool[] status = _contenttype.Diff();
			
			if (status[0])
				sqlParams[0].Value = _contenttype.Contenttypecode;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _contenttype.Contenttype;
			else
				sqlParams[1].Value = DBNull.Value;

   			sqlParams[2] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[2].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
