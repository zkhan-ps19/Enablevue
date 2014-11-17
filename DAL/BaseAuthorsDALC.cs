/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Base class (data access component) for 'Authors' table. Avoid making
'  any changes in this class, becauses it will be overwritten when the framework is
'  re-generaetd. For any custom DAL code related to this table use 
'  'AuthorsDALC' class.
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
	/// General database operations related to 'Authors' table
	/// </summary>
	public abstract class BaseAuthorsDALC : BaseDALC
	{
		/// <summary>
		/// Get an object from database using primary key
		/// </summary>
		/// <param name="__authorid">Primay key ID</param>
		/// <returns>
		/// AuthorsInfo object
		/// </returns>
		public static AuthorsInfo SelectByPK(int __authorid)
		{ 
			AuthorsInfo _authors = null;
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Authors_SelectByPK", PKParameters(__authorid));
			while (reader.Read())
				_authors = RowToObject(reader,0);
			reader.Close();
			
			return _authors;
		}
		
		/// <summary>
		/// Get all records from 'Authors' table
		/// </summary>
		/// <param></param>
		/// <returns>
		/// IList containing collection of AuthorsInfo objects.
		/// </returns>
		public static IList<AuthorsInfo> SelectAll()
		{
			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Authors_SelectAll");

			IList<AuthorsInfo> _items = new List<AuthorsInfo>();
			AuthorsInfo _authors = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_authors = RowToObject(reader,0);
				_items.Add(_authors);
			}
			reader.Close();
			return _items;
		}
		
		/// <summary>
		/// Get all records from 'Authors' table, filtered by where clause
		/// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
		/// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// IList containing an ordered collection of objects filtered by the WHERE
		/// clause provided to the method
		/// </returns>
		public static IList<AuthorsInfo> SelectAllWhere(string _whereClause, string _orderBy)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];
  			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;
  			sqlParams[1] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[1].Value = _orderBy;

			SqlDataReader reader = SqlHelper.ExecuteReader(CONN_STRING, CommandType.StoredProcedure, "Authors_SelectAllWhere", sqlParams);

			IList<AuthorsInfo> _items = new List<AuthorsInfo>();
			AuthorsInfo _authors = null;

			//Create the items from the first row and subsequent rows
			while (reader.Read()) {
				_authors = RowToObject(reader,0);
				_items.Add(_authors);
			}
			reader.Close();
			return _items;
		} 
		
		/// <summary>
		/// Get a count of all records from 'Authors' table
		/// </summary>
		/// <returns>
		/// Total number of records in 'Authors' table
		/// </returns>
		public static int CountAll() 
		{
			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Authors_CountAll");
		} 

		/// <summary>
		/// Get a count of all records from 'Authors' table filtered by the WHERE
		/// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="_whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Number of records in 'Authors' table matching with sql WHERE clause
		/// </returns>
		public static int CountAllWhere(string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[1];
   			sqlParams[0] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[0].Value = _whereClause;

			return (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Authors_CountAllWhere", sqlParams);
		} 

		/// <summary>
		/// Insert a record in 'Authors' table
		/// This method is available for tables who have primary key defined
		/// </summary>
		/// <param name="_authors">AuthorsInfo object</param>
		/// <returns>
		/// AuthorsInfo object with any additional computed values such as 
		/// auto-number (identity) added to the object
		/// </returns>
		public static AuthorsInfo Insert(AuthorsInfo _authors) 
		{
			int autoNumValue = -1;
			autoNumValue = (int)SqlHelper.ExecuteScalar(CONN_STRING, CommandType.StoredProcedure, "Authors_Insert", InsertParameters(_authors));
			_authors.Authorid = autoNumValue;
			
			return _authors;
		}
		
		/// <summary>
		/// Update a record in 'Authors' table
		/// This method is available for tables who have primary key defined		
		/// </summary>
		/// <param name="_authors">AuthorsInfo object</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Update(AuthorsInfo _authors)
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Authors_Update", UpdateParameters(_authors));
		}

		/// <summary>
		/// Update record(s) in 'Authors' table according to SQL WHERE condition.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void UpdateAllWhere(AuthorsInfo _authors, string _whereClause)		
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Authors_UpdateAllWhere", UpdateAllWhereParameters(_authors, _whereClause));
		}
		
		/// <summary>
		/// Delete a record in 'Authors' table.
		/// This method is available for tables who have primary key defined	
		/// </summary>
		/// <param name="__authorid">Primay key ID</param>
		/// <returns>
		/// Nothing
		/// </returns>
		public static void Delete(int __authorid) 
		{
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Authors_Delete", PKParameters(__authorid));	
		}
		
		/// <summary>
		/// Delete record(s) in 'Authors' table according to SQL WHERE condition
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
			
			SqlHelper.ExecuteNonQuery(CONN_STRING, CommandType.StoredProcedure, "Authors_DeleteAllWhere", sqlParams);		
		}
		
		#region "Methods returning dataset"
		/// <summary>
		/// Get all records from 'Authors' table in form of a dataset
		/// </summary>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
		/// <returns>
		/// Dataset containing all records from 'Authors' table
		/// </returns>
		public static DataSet SelectAllDataset(string _orderBy) 
		{
			//TODO to be built if required
			SqlParameter[] sqlParams = new SqlParameter[1];
  			sqlParams[0] = new SqlParameter("@orderBy", SqlDbType.VarChar);
			sqlParams[0].Value = _orderBy;

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Authors_SelectAll_Dataset", sqlParams);
		}
		
		/// <summary>
		/// Get all records from 'Authors' table, in form of a dataset, filtered by
		/// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
		/// </summary>
		/// <param name="whereClause">SQL WHERE clause</param>
		/// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
		/// <returns>
		/// DataSet containing all records from 'Authors' table filtered
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

			return SqlHelper.ExecuteDataset(CONN_STRING, CommandType.StoredProcedure, "Authors_SelectAllWhere_Dataset", sqlParams);
		}
		#endregion
		
		#region "Protected RowToObject method to convert data reader row to Authors object"
		/// <summary>
		/// Converts a data reader row to 'Authors' model/DTO object
		/// </summary>
		/// <param name="reader">Datareader containing usually a single record</param>
		/// <param name="index">Datareader field's starting index i.e. 0</param>		
		/// <returns>
		/// Object of 'AuthorsInfo' type
		/// </returns>
		protected static AuthorsInfo RowToObject(SqlDataReader reader, int index)
		{
			AuthorsInfo _authors = new AuthorsInfo();

			if (!reader.IsDBNull(index))
				_authors.Authorid = reader.GetInt32(index);
			index = index + 1;
			if (!reader.IsDBNull(index))
				_authors.Name = reader.GetString(index);
			index = index + 1;
			
			return _authors;
		}

		#endregion		
		
		#region "Private SqlParameter Generator Methods"
		/// <summary>
		/// Private method used to build PK parameter array for 'Authors' table
		/// </summary>
		/// <param name="__authorid">Primary key</param>
		/// <returns>
		/// SQL parameter array containing primary key(s) of the table
		/// </returns>
		private static SqlParameter[] PKParameters(int __authorid) {
			SqlParameter[] sqlParams = new SqlParameter[1];
								
			sqlParams[0] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[0].Value = __authorid;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build insert parameter array for 'Authors' table
		/// </summary>
		/// <param name="_authors">AuthorsInfo object</param>
		/// <returns>
		/// SQL parameter array containing insert parameters
		/// </returns>
		private static SqlParameter[] InsertParameters(AuthorsInfo _authors)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);								

			bool[] status = _authors.Diff();

			if (status[1])
				sqlParams[1].Value = _authors.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}

		/// <summary>
		/// Private method used to build update parameter array for 'Authors' table
		/// </summary>
		/// <param name="_authors">AuthorsInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>
		private static SqlParameter[] UpdateParameters(AuthorsInfo _authors)
		{
			SqlParameter[] sqlParams = new SqlParameter[2];		
			sqlParams[0] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _authors.Diff();
			
			if (status[0])
				sqlParams[0].Value = _authors.Authorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _authors.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		/// <summary>
		/// Private method used to build update parameter array for 'Authors' table
		/// Overloaded method to create a parameter array length bigger by one element to
		/// be used to put FK parameters for FK procedures
		/// </summary>
		/// <param name="_authors">AuthorsInfo object</param>
		/// <returns>
		/// SQL parameter array containing update parameters
		/// </returns>		
		private static SqlParameter[] UpdateParameters(AuthorsInfo _authors, int paramArraySize)
		{
			SqlParameter[] sqlParams = new SqlParameter[paramArraySize];
			sqlParams[0] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _authors.Diff();
			
			if (status[0])
				sqlParams[0].Value = _authors.Authorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _authors.Name;
			else
				sqlParams[1].Value = DBNull.Value;

			return(sqlParams);
		}
		
		private static SqlParameter[] UpdateAllWhereParameters(AuthorsInfo _authors, string _whereClause)
		{
			SqlParameter[] sqlParams = new SqlParameter[3];		
			sqlParams[0] = new SqlParameter("@AuthorId", SqlDbType.Int);
			sqlParams[1] = new SqlParameter("@Name", SqlDbType.VarChar);

			bool[] status = _authors.Diff();
			
			if (status[0])
				sqlParams[0].Value = _authors.Authorid;
			else
				sqlParams[0].Value = DBNull.Value;
			if (status[1])
				sqlParams[1].Value = _authors.Name;
			else
				sqlParams[1].Value = DBNull.Value;

   			sqlParams[2] = new SqlParameter("@whereClause", SqlDbType.VarChar);
			sqlParams[2].Value = _whereClause;

			return(sqlParams);
		}

		#endregion
				
	}
}
