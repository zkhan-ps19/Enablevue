using DAL;
using Model;
using System.Data;
using System.Collections.Generic;

namespace BLL
{
    public static class Admin
    {
       public enum eContentStatus
        {
            ContentFailed = 201,
            ContentReceived = 201,
            ValidationFailed = 250,
            ContentRejected = 260,
            ContentAccepted = 300
        }

        #region Inner Classes

        /// <summary>
        /// General database operations related to 'Authors' table
        /// </summary>
        public static class Author
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
                return AuthorsDALC.SelectByPK(__authorid);
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
                return AuthorsDALC.SelectAll();
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
                return AuthorsDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'Authors' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'Authors' table
            /// </returns>
            public static int CountAll()
            {
                return AuthorsDALC.CountAll();
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
                return AuthorsDALC.CountAllWhere(_whereClause);
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
                return AuthorsDALC.Insert(_authors);
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
                AuthorsDALC.Update(_authors);
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
                AuthorsDALC.UpdateAllWhere(_authors, _whereClause);
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
                AuthorsDALC.Delete(__authorid);
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
                AuthorsDALC.DeleteAllWhere(_whereClause);

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
                return AuthorsDALC.SelectAllDataset(_orderBy);
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
                return AuthorsDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'Country' table
        /// </summary>
        public static class Country
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
                return CountryDALC.SelectByPK(__countryid);
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
                return CountryDALC.SelectAll();
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
                return CountryDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'Country' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'Country' table
            /// </returns>
            public static int CountAll()
            {
                return CountryDALC.CountAll();
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
                return CountryDALC.CountAllWhere(_whereClause);
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
                return CountryDALC.Insert(_country);
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
                CountryDALC.Update(_country);
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
                CountryDALC.UpdateAllWhere(_country, _whereClause);
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
                CountryDALC.Delete(__countryid);
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
                CountryDALC.DeleteAllWhere(_whereClause);

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
                return CountryDALC.SelectAllDataset(_orderBy);
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
                return CountryDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'CountryState' table
        /// </summary>
        public static class CountryState
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
                return CountrystateDALC.SelectByPK(__stateid);
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
                return CountrystateDALC.SelectFullByPK(__stateid);
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
                return CountrystateDALC.SelectAll();
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
                return CountrystateDALC.SelectAllFull();
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
                return CountrystateDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'CountryState' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'CountryState' table
            /// </returns>
            public static int CountAll()
            {
                return CountrystateDALC.CountAll();
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
                return CountrystateDALC.CountAllWhere(_whereClause);
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
                return CountrystateDALC.Insert(_countrystate);
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
                CountrystateDALC.Update(_countrystate);
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
                CountrystateDALC.UpdateAllWhere(_countrystate, _whereClause);
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
                CountrystateDALC.UpdateAllByFKCountryid(_countrystate, __countryid);
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
                CountrystateDALC.Delete(__stateid);
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
                CountrystateDALC.DeleteAllWhere(_whereClause);

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
                CountrystateDALC.DeleteAllByFKCountryid(__countryid);
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
                return CountrystateDALC.SelectAllByFKCountryid(__countryid);
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
                return CountrystateDALC.CountAllByFKCountryid(__countryid);
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
                return CountrystateDALC.SelectAllDataset(_orderBy);
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
                return CountrystateDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'Content' table
        /// </summary>
        public static class Content
        {

            #region custom methods

            /// <summary>
            /// Get all records from 'Content' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentInfo> SelectAllWhereCustom(string _whereClause, string _orderBy)
            {
                return ContentDALC.SelectAllWhereCustom(_whereClause, _orderBy);
            }

            /// <summary>
            /// Insert a record in 'Content' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_content">ContentInfo object</param>
            /// <returns>
            /// ContentInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static int Insert(Model.Content _content, int contentRequestId)
            {
                return ContentDALC.Insert(_content, contentRequestId);
            }

            #endregion

            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__contentid">Primay key ID</param>
            /// <returns>
            /// ContentInfo object
            /// </returns>
            public static ContentInfo SelectByPK(int __contentid)
            {
                return ContentDALC.SelectByPK(__contentid);
            }

            /// <summary>
            /// Get a data reader against a primary key joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentid">Primay key ID</param>
            /// <returns>
            /// ContentInfo object
            /// </returns>
            public static ContentInfo SelectFullByPK(int __contentid)
            {
                return ContentDALC.SelectFullByPK(__contentid);
            }

            /// <summary>
            /// Get all records from 'Content' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentInfo objects.
            /// </returns>
            public static IList<ContentInfo> SelectAll()
            {
                return ContentDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'Content' table joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentInfo objects.
            /// </returns>
            public static IList<ContentInfo> SelectAllFull()
            {
                return ContentDALC.SelectAllFull();
            }

            /// <summary>
            /// Get all records from 'Content' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return ContentDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'Content' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'Content' table
            /// </returns>
            public static int CountAll()
            {
                return ContentDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'Content' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'Content' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return ContentDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'Content' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_content">ContentInfo object</param>
            /// <returns>
            /// ContentInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static ContentInfo Insert(ContentInfo _content)
            {
                return ContentDALC.Insert(_content);
            }

            /// <summary>
            /// Update a record in 'Content' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_content">ContentInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(ContentInfo _content)
            {
                ContentDALC.Update(_content);
            }

            /// <summary>
            /// Update record(s) in 'Content' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(ContentInfo _content, string _whereClause)
            {
                ContentDALC.UpdateAllWhere(_content, _whereClause);
            }

            /// <summary>
            /// Update all records in 'Content' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_content">ContentInfo object</param>
            /// <param name="__contentrequestid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKContentrequestid(ContentInfo _content, int __contentrequestid)
            {
                ContentDALC.UpdateAllByFKContentrequestid(_content, __contentrequestid);
            }

            /// <summary>
            /// Update all records in 'Content' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_content">ContentInfo object</param>
            /// <param name="__authorid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKAuthorid(ContentInfo _content, int __authorid)
            {
                ContentDALC.UpdateAllByFKAuthorid(_content, __authorid);
            }

            /// <summary>
            /// Delete a record in 'Content' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__contentid">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __contentid)
            {
                ContentDALC.Delete(__contentid);
            }

            /// <summary>
            /// Delete record(s) in 'Content' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                ContentDALC.DeleteAllWhere(_whereClause);

            }

            /// <summary>
            /// Delete a record in 'Content' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ContentRequestId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKContentrequestid(int __contentrequestid)
            {
                ContentDALC.DeleteAllByFKContentrequestid(__contentrequestid);
            }


            /// <summary>
            /// Delete a record in 'Content' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="AuthorId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKAuthorid(int __authorid)
            {
                ContentDALC.DeleteAllByFKAuthorid(__authorid);
            }

            /// <summary>
            /// Get all records from 'Content' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static IList<ContentInfo> SelectAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentDALC.SelectAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get a count of all records from 'Content' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'Content' table matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static int CountAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentDALC.CountAllByFKContentrequestid(__contentrequestid);
            }


            /// <summary>
            /// Get all records from 'Content' table matching to the foreign key 'AuthorId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__authorid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'AuthorId' foreign key value
            /// </returns>
            public static IList<ContentInfo> SelectAllByFKAuthorid(int __authorid)
            {
                return ContentDALC.SelectAllByFKAuthorid(__authorid);
            }

            /// <summary>
            /// Get a count of all records from 'Content' table matching to the foreign key 'AuthorId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__authorid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'Content' table matching with 'AuthorId' foreign key value
            /// </returns>
            public static int CountAllByFKAuthorid(int __authorid)
            {
                return ContentDALC.CountAllByFKAuthorid(__authorid);
            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'Content' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'Content' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return ContentDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'Content' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'Content' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return ContentDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'ContentType' table
        /// </summary>
        public static class ContentType
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
                return ContenttypeDALC.SelectByPK(__contenttypecode);
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
                return ContenttypeDALC.SelectAll();
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
                return ContenttypeDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'ContentType' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'ContentType' table
            /// </returns>
            public static int CountAll()
            {
                return ContenttypeDALC.CountAll();
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
                return ContenttypeDALC.CountAllWhere(_whereClause);
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
                return ContenttypeDALC.Insert(_contenttype);
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
                ContenttypeDALC.Update(_contenttype);
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
                ContenttypeDALC.UpdateAllWhere(_contenttype, _whereClause);
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
                ContenttypeDALC.Delete(__contenttypecode);
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
                ContenttypeDALC.DeleteAllWhere(_whereClause);

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
                return ContenttypeDALC.SelectAllDataset(_orderBy);
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
                return ContenttypeDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'ContentStatus' table
        /// </summary>
        public static class ContentStatus
        {
            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__contentstatuscode">Primay key ID</param>
            /// <returns>
            /// ContentstatusInfo object
            /// </returns>
            public static ContentstatusInfo SelectByPK(int __contentstatuscode)
            {
                return ContentstatusDALC.SelectByPK(__contentstatuscode);
            }

            /// <summary>
            /// Get all records from 'ContentStatus' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentstatusInfo objects.
            /// </returns>
            public static IList<ContentstatusInfo> SelectAll()
            {
                return ContentstatusDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'ContentStatus' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentstatusInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return ContentstatusDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'ContentStatus' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'ContentStatus' table
            /// </returns>
            public static int CountAll()
            {
                return ContentstatusDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'ContentStatus' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'ContentStatus' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return ContentstatusDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'ContentStatus' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_contentstatus">ContentstatusInfo object</param>
            /// <returns>
            /// ContentstatusInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static ContentstatusInfo Insert(ContentstatusInfo _contentstatus)
            {
                return ContentstatusDALC.Insert(_contentstatus);
            }

            /// <summary>
            /// Update a record in 'ContentStatus' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_contentstatus">ContentstatusInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(ContentstatusInfo _contentstatus)
            {
                ContentstatusDALC.Update(_contentstatus);
            }

            /// <summary>
            /// Update record(s) in 'ContentStatus' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(ContentstatusInfo _contentstatus, string _whereClause)
            {
                ContentstatusDALC.UpdateAllWhere(_contentstatus, _whereClause);
            }

            /// <summary>
            /// Delete a record in 'ContentStatus' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__contentstatuscode">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __contentstatuscode)
            {
                ContentstatusDALC.Delete(__contentstatuscode);
            }

            /// <summary>
            /// Delete record(s) in 'ContentStatus' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                ContentstatusDALC.DeleteAllWhere(_whereClause);

            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'ContentStatus' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'ContentStatus' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return ContentstatusDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'ContentStatus' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'ContentStatus' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return ContentstatusDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'Customer' table
        /// </summary>
        public static class Customer
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
                return CustomerDALC.SelectByPK(__customerid);
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
                return CustomerDALC.SelectAll();
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
                return CustomerDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'Customer' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'Customer' table
            /// </returns>
            public static int CountAll()
            {
                return CustomerDALC.CountAll();
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
                return CustomerDALC.CountAllWhere(_whereClause);
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
                return CustomerDALC.Insert(_customer);
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
                CustomerDALC.Update(_customer);
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
                CustomerDALC.UpdateAllWhere(_customer, _whereClause);
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
                CustomerDALC.Delete(__customerid);
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
                CustomerDALC.DeleteAllWhere(_whereClause);

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
                return CustomerDALC.SelectAllDataset(_orderBy);
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
                return CustomerDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'ContentStatusError' table
        /// </summary>
        public static class ContentStatusError
        {
            #region Custom Methods

            /// <summary>
            /// Get all records from 'ContentStatusError' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static IList<ErrorsInfo> SelectAllByFKContentrequestidCustom(int __contentrequestid)
            {
                return ContentstatuserrorDALC.SelectAllByFKContentrequestidCustom(__contentrequestid);
            }

            #endregion

            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__statuserrorid">Primay key ID</param>
            /// <returns>
            /// ContentstatuserrorInfo object
            /// </returns>
            public static ContentstatuserrorInfo SelectByPK(int __statuserrorid)
            {
                return ContentstatuserrorDALC.SelectByPK(__statuserrorid);
            }

            /// <summary>
            /// Get a data reader against a primary key joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__statuserrorid">Primay key ID</param>
            /// <returns>
            /// ContentstatuserrorInfo object
            /// </returns>
            public static ContentstatuserrorInfo SelectFullByPK(int __statuserrorid)
            {
                return ContentstatuserrorDALC.SelectFullByPK(__statuserrorid);
            }

            /// <summary>
            /// Get all records from 'ContentStatusError' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentstatuserrorInfo objects.
            /// </returns>
            public static IList<ContentstatuserrorInfo> SelectAll()
            {
                return ContentstatuserrorDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'ContentStatusError' table joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentstatuserrorInfo objects.
            /// </returns>
            public static IList<ContentstatuserrorInfo> SelectAllFull()
            {
                return ContentstatuserrorDALC.SelectAllFull();
            }

            /// <summary>
            /// Get all records from 'ContentStatusError' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentstatuserrorInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return ContentstatuserrorDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'ContentStatusError' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'ContentStatusError' table
            /// </returns>
            public static int CountAll()
            {
                return ContentstatuserrorDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'ContentStatusError' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'ContentStatusError' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return ContentstatuserrorDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'ContentStatusError' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
            /// <returns>
            /// ContentstatuserrorInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static ContentstatuserrorInfo Insert(ContentstatuserrorInfo _contentstatuserror)
            {
                return ContentstatuserrorDALC.Insert(_contentstatuserror);
            }

            /// <summary>
            /// Update a record in 'ContentStatusError' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(ContentstatuserrorInfo _contentstatuserror)
            {
                ContentstatuserrorDALC.Update(_contentstatuserror);
            }

            /// <summary>
            /// Update record(s) in 'ContentStatusError' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(ContentstatuserrorInfo _contentstatuserror, string _whereClause)
            {
                ContentstatuserrorDALC.UpdateAllWhere(_contentstatuserror, _whereClause);
            }

            /// <summary>
            /// Update all records in 'ContentStatusError' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentstatuserror">ContentstatuserrorInfo object</param>
            /// <param name="__contentrequestid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKContentrequestid(ContentstatuserrorInfo _contentstatuserror, int __contentrequestid)
            {
                ContentstatuserrorDALC.UpdateAllByFKContentrequestid(_contentstatuserror, __contentrequestid);
            }

            /// <summary>
            /// Delete a record in 'ContentStatusError' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__statuserrorid">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __statuserrorid)
            {
                ContentstatuserrorDALC.Delete(__statuserrorid);
            }

            /// <summary>
            /// Delete record(s) in 'ContentStatusError' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                ContentstatuserrorDALC.DeleteAllWhere(_whereClause);

            }

            /// <summary>
            /// Delete a record in 'ContentStatusError' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ContentRequestId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKContentrequestid(int __contentrequestid)
            {
                ContentstatuserrorDALC.DeleteAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get all records from 'ContentStatusError' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static IList<ContentstatuserrorInfo> SelectAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentstatuserrorDALC.SelectAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get a count of all records from 'ContentStatusError' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentStatusError' table matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static int CountAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentstatuserrorDALC.CountAllByFKContentrequestid(__contentrequestid);
            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'ContentStatusError' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'ContentStatusError' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return ContentstatuserrorDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'ContentStatusError' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'ContentStatusError' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return ContentstatuserrorDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'ContentRequest' table
        /// </summary>
        public static class ContentRequest
        {

            #region custom methods

            /// <summary>
            /// Insert a record in 'ContentRequest' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <returns>
            /// ContentrequestInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static int InsertCustom(ContentrequestInfo _contentrequest)
            {
                return ContentrequestDALC.InsertCustom(_contentrequest);
            }

            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__contentrequestid">Primay key ID</param>
            /// <returns>
            /// ContentrequestInfo object
            /// </returns>
            public static ContentrequestInfo SelectByRequestCode(string requestCode)
            {
                return ContentrequestDALC.SelectByRequestCode(requestCode);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="WhereClause"></param>
            /// <param name="OrderBy"></param>
            /// <returns></returns>
            public static IList<ContentrequestInfo> SelectAllWhere(string _whereClause, string _searchClause, string _orderBy, int _pageNumber, int _pageSize)
            {
                return ContentrequestDALC.SelectAllWhere(_whereClause, _searchClause, _orderBy, _pageNumber, _pageSize);
            }

            /// <summary>
            /// Update record(s) in 'ContentRequest' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(string _setClause, string _whereClause)
            {
                ContentrequestDALC.UpdateAllWhere(_setClause, _whereClause);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentrequestInfo> SelectContentRequestById(string _whereClause)
            {
                return ContentrequestDALC.SelectContentRequestById(_whereClause);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'ContentRequest' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhereCustom(string _whereClause)
            {
                return ContentrequestDALC.CountAllWhereCustom(_whereClause);
            }

            #endregion

            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__contentrequestid">Primay key ID</param>
            /// <returns>
            /// ContentrequestInfo object
            /// </returns>
            public static ContentrequestInfo SelectByPK(int __contentrequestid)
            {
                return ContentrequestDALC.SelectByPK(__contentrequestid);
            }

            /// <summary>
            /// Get a data reader against a primary key joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestid">Primay key ID</param>
            /// <returns>
            /// ContentrequestInfo object
            /// </returns>
            public static ContentrequestInfo SelectFullByPK(int __contentrequestid)
            {
                return ContentrequestDALC.SelectFullByPK(__contentrequestid);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestInfo objects.
            /// </returns>
            public static IList<ContentrequestInfo> SelectAll()
            {
                return ContentrequestDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestInfo objects.
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllFull()
            {
                return ContentrequestDALC.SelectAllFull();
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return ContentrequestDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'ContentRequest' table
            /// </returns>
            public static int CountAll()
            {
                return ContentrequestDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'ContentRequest' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return ContentrequestDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'ContentRequest' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <returns>
            /// ContentrequestInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static ContentrequestInfo Insert(ContentrequestInfo _contentrequest)
            {
                return ContentrequestDALC.Insert(_contentrequest);
            }

            /// <summary>
            /// Update a record in 'ContentRequest' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(ContentrequestInfo _contentrequest)
            {
                ContentrequestDALC.Update(_contentrequest);
            }

            /// <summary>
            /// Update record(s) in 'ContentRequest' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(ContentrequestInfo _contentrequest, string _whereClause)
            {
                ContentrequestDALC.UpdateAllWhere(_contentrequest, _whereClause);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__customerid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKCustomerid(ContentrequestInfo _contentrequest, int __customerid)
            {
                ContentrequestDALC.UpdateAllByFKCustomerid(_contentrequest, __customerid);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__contenttypecode">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKContenttypecode(ContentrequestInfo _contentrequest, string __contenttypecode)
            {
                ContentrequestDALC.UpdateAllByFKContenttypecode(_contentrequest, __contenttypecode);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__requeststatuscode">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKRequeststatuscode(ContentrequestInfo _contentrequest, int __requeststatuscode)
            {
                ContentrequestDALC.UpdateAllByFKRequeststatuscode(_contentrequest, __requeststatuscode);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__requesttypecode">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKRequesttypecode(ContentrequestInfo _contentrequest, string __requesttypecode)
            {
                ContentrequestDALC.UpdateAllByFKRequesttypecode(_contentrequest, __requesttypecode);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__suggestedauthorid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKSuggestedauthorid(ContentrequestInfo _contentrequest, int __suggestedauthorid)
            {
                ContentrequestDALC.UpdateAllByFKSuggestedauthorid(_contentrequest, __suggestedauthorid);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__workrequestid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKWorkrequestid(ContentrequestInfo _contentrequest, int __workrequestid)
            {
                ContentrequestDALC.UpdateAllByFKWorkrequestid(_contentrequest, __workrequestid);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__createdby">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKCreatedby(ContentrequestInfo _contentrequest, int __createdby)
            {
                ContentrequestDALC.UpdateAllByFKCreatedby(_contentrequest, __createdby);
            }

            /// <summary>
            /// Update all records in 'ContentRequest' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequest">ContentrequestInfo object</param>
            /// <param name="__updatedby">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKUpdatedby(ContentrequestInfo _contentrequest, int __updatedby)
            {
                ContentrequestDALC.UpdateAllByFKUpdatedby(_contentrequest, __updatedby);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__contentrequestid">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __contentrequestid)
            {
                ContentrequestDALC.Delete(__contentrequestid);
            }

            /// <summary>
            /// Delete record(s) in 'ContentRequest' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                ContentrequestDALC.DeleteAllWhere(_whereClause);

            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="CustomerId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKCustomerid(int __customerid)
            {
                ContentrequestDALC.DeleteAllByFKCustomerid(__customerid);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ContentTypeCode">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKContenttypecode(string __contenttypecode)
            {
                ContentrequestDALC.DeleteAllByFKContenttypecode(__contenttypecode);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="RequestStatusCode">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKRequeststatuscode(int __requeststatuscode)
            {
                ContentrequestDALC.DeleteAllByFKRequeststatuscode(__requeststatuscode);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="RequestTypeCode">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKRequesttypecode(string __requesttypecode)
            {
                ContentrequestDALC.DeleteAllByFKRequesttypecode(__requesttypecode);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="SuggestedAuthorId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKSuggestedauthorid(int __suggestedauthorid)
            {
                ContentrequestDALC.DeleteAllByFKSuggestedauthorid(__suggestedauthorid);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="WorkRequestId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKWorkrequestid(int __workrequestid)
            {
                ContentrequestDALC.DeleteAllByFKWorkrequestid(__workrequestid);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="CreatedBy">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKCreatedby(int __createdby)
            {
                ContentrequestDALC.DeleteAllByFKCreatedby(__createdby);
            }

            /// <summary>
            /// Delete a record in 'ContentRequest' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="UpdatedBy">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKUpdatedby(int __updatedby)
            {
                ContentrequestDALC.DeleteAllByFKUpdatedby(__updatedby);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'CustomerId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__customerid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'CustomerId' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKCustomerid(int __customerid)
            {
                return ContentrequestDALC.SelectAllByFKCustomerid(__customerid);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'CustomerId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__customerid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'CustomerId' foreign key value
            /// </returns>
            public static int CountAllByFKCustomerid(int __customerid)
            {
                return ContentrequestDALC.CountAllByFKCustomerid(__customerid);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'ContentTypeCode'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contenttypecode">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentTypeCode' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKContenttypecode(string __contenttypecode)
            {
                return ContentrequestDALC.SelectAllByFKContenttypecode(__contenttypecode);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'ContentTypeCode'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contenttypecode">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'ContentTypeCode' foreign key value
            /// </returns>
            public static int CountAllByFKContenttypecode(string __contenttypecode)
            {
                return ContentrequestDALC.CountAllByFKContenttypecode(__contenttypecode);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'RequestStatusCode'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__requeststatuscode">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'RequestStatusCode' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKRequeststatuscode(int __requeststatuscode)
            {
                return ContentrequestDALC.SelectAllByFKRequeststatuscode(__requeststatuscode);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'RequestStatusCode'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__requeststatuscode">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'RequestStatusCode' foreign key value
            /// </returns>
            public static int CountAllByFKRequeststatuscode(int __requeststatuscode)
            {
                return ContentrequestDALC.CountAllByFKRequeststatuscode(__requeststatuscode);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'RequestTypeCode'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__requesttypecode">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'RequestTypeCode' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKRequesttypecode(string __requesttypecode)
            {
                return ContentrequestDALC.SelectAllByFKRequesttypecode(__requesttypecode);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'RequestTypeCode'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__requesttypecode">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'RequestTypeCode' foreign key value
            /// </returns>
            public static int CountAllByFKRequesttypecode(string __requesttypecode)
            {
                return ContentrequestDALC.CountAllByFKRequesttypecode(__requesttypecode);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'SuggestedAuthorId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__suggestedauthorid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'SuggestedAuthorId' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKSuggestedauthorid(int __suggestedauthorid)
            {
                return ContentrequestDALC.SelectAllByFKSuggestedauthorid(__suggestedauthorid);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'SuggestedAuthorId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__suggestedauthorid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'SuggestedAuthorId' foreign key value
            /// </returns>
            public static int CountAllByFKSuggestedauthorid(int __suggestedauthorid)
            {
                return ContentrequestDALC.CountAllByFKSuggestedauthorid(__suggestedauthorid);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'WorkRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__workrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'WorkRequestId' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKWorkrequestid(int __workrequestid)
            {
                return ContentrequestDALC.SelectAllByFKWorkrequestid(__workrequestid);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'WorkRequestId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__workrequestid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'WorkRequestId' foreign key value
            /// </returns>
            public static int CountAllByFKWorkrequestid(int __workrequestid)
            {
                return ContentrequestDALC.CountAllByFKWorkrequestid(__workrequestid);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'CreatedBy'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__createdby">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'CreatedBy' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKCreatedby(int __createdby)
            {
                return ContentrequestDALC.SelectAllByFKCreatedby(__createdby);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'CreatedBy'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__createdby">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'CreatedBy' foreign key value
            /// </returns>
            public static int CountAllByFKCreatedby(int __createdby)
            {
                return ContentrequestDALC.CountAllByFKCreatedby(__createdby);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table matching to the foreign key 'UpdatedBy'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__updatedby">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'UpdatedBy' foreign key value
            /// </returns>
            public static IList<ContentrequestInfo> SelectAllByFKUpdatedby(int __updatedby)
            {
                return ContentrequestDALC.SelectAllByFKUpdatedby(__updatedby);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequest' table matching to the foreign key 'UpdatedBy'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__updatedby">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequest' table matching with 'UpdatedBy' foreign key value
            /// </returns>
            public static int CountAllByFKUpdatedby(int __updatedby)
            {
                return ContentrequestDALC.CountAllByFKUpdatedby(__updatedby);
            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'ContentRequest' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'ContentRequest' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return ContentrequestDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'ContentRequest' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'ContentRequest' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return ContentrequestDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'ContentRequestChange' table
        /// </summary>
        public static class ContentRequestChange
        {
            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__contentrequestchangeid">Primay key ID</param>
            /// <returns>
            /// ContentrequestchangeInfo object
            /// </returns>
            public static ContentrequestchangeInfo SelectByPK(int __contentrequestchangeid)
            {
                return ContentrequestchangeDALC.SelectByPK(__contentrequestchangeid);
            }

            /// <summary>
            /// Get a data reader against a primary key joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestchangeid">Primay key ID</param>
            /// <returns>
            /// ContentrequestchangeInfo object
            /// </returns>
            public static ContentrequestchangeInfo SelectFullByPK(int __contentrequestchangeid)
            {
                return ContentrequestchangeDALC.SelectFullByPK(__contentrequestchangeid);
            }

            /// <summary>
            /// Get all records from 'ContentRequestChange' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestchangeInfo objects.
            /// </returns>
            public static IList<ContentrequestchangeInfo> SelectAll()
            {
                return ContentrequestchangeDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'ContentRequestChange' table joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestchangeInfo objects.
            /// </returns>
            public static IList<ContentrequestchangeInfo> SelectAllFull()
            {
                return ContentrequestchangeDALC.SelectAllFull();
            }

            /// <summary>
            /// Get all records from 'ContentRequestChange' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentrequestchangeInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return ContentrequestchangeDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestChange' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'ContentRequestChange' table
            /// </returns>
            public static int CountAll()
            {
                return ContentrequestchangeDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestChange' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'ContentRequestChange' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return ContentrequestchangeDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'ContentRequestChange' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
            /// <returns>
            /// ContentrequestchangeInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static ContentrequestchangeInfo Insert(ContentrequestchangeInfo _contentrequestchange)
            {
                return ContentrequestchangeDALC.Insert(_contentrequestchange);
            }

            /// <summary>
            /// Update a record in 'ContentRequestChange' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(ContentrequestchangeInfo _contentrequestchange)
            {
                ContentrequestchangeDALC.Update(_contentrequestchange);
            }

            /// <summary>
            /// Update record(s) in 'ContentRequestChange' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(ContentrequestchangeInfo _contentrequestchange, string _whereClause)
            {
                ContentrequestchangeDALC.UpdateAllWhere(_contentrequestchange, _whereClause);
            }

            /// <summary>
            /// Update all records in 'ContentRequestChange' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequestchange">ContentrequestchangeInfo object</param>
            /// <param name="__contentrequestid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKContentrequestid(ContentrequestchangeInfo _contentrequestchange, int __contentrequestid)
            {
                ContentrequestchangeDALC.UpdateAllByFKContentrequestid(_contentrequestchange, __contentrequestid);
            }

            /// <summary>
            /// Delete a record in 'ContentRequestChange' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__contentrequestchangeid">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __contentrequestchangeid)
            {
                ContentrequestchangeDALC.Delete(__contentrequestchangeid);
            }

            /// <summary>
            /// Delete record(s) in 'ContentRequestChange' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                ContentrequestchangeDALC.DeleteAllWhere(_whereClause);

            }

            /// <summary>
            /// Delete a record in 'ContentRequestChange' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ContentRequestId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKContentrequestid(int __contentrequestid)
            {
                ContentrequestchangeDALC.DeleteAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get all records from 'ContentRequestChange' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static IList<ContentrequestchangeInfo> SelectAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentrequestchangeDALC.SelectAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestChange' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequestChange' table matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static int CountAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentrequestchangeDALC.CountAllByFKContentrequestid(__contentrequestid);
            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'ContentRequestChange' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'ContentRequestChange' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return ContentrequestchangeDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'ContentRequestChange' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'ContentRequestChange' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return ContentrequestchangeDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'ContentRequestPage' table
        /// </summary>
        public static class ContentRequestPage
        {
            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__pageid">Primay key ID</param>
            /// <returns>
            /// ContentrequestpageInfo object
            /// </returns>
            public static ContentrequestpageInfo SelectByPK(int __pageid)
            {
                return ContentrequestpageDALC.SelectByPK(__pageid);
            }

            /// <summary>
            /// Get a data reader against a primary key joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__pageid">Primay key ID</param>
            /// <returns>
            /// ContentrequestpageInfo object
            /// </returns>
            public static ContentrequestpageInfo SelectFullByPK(int __pageid)
            {
                return ContentrequestpageDALC.SelectFullByPK(__pageid);
            }

            /// <summary>
            /// Get all records from 'ContentRequestPage' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestpageInfo objects.
            /// </returns>
            public static IList<ContentrequestpageInfo> SelectAll()
            {
                return ContentrequestpageDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'ContentRequestPage' table joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestpageInfo objects.
            /// </returns>
            public static IList<ContentrequestpageInfo> SelectAllFull()
            {
                return ContentrequestpageDALC.SelectAllFull();
            }

            /// <summary>
            /// Get all records from 'ContentRequestPage' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentrequestpageInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return ContentrequestpageDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestPage' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'ContentRequestPage' table
            /// </returns>
            public static int CountAll()
            {
                return ContentrequestpageDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestPage' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'ContentRequestPage' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return ContentrequestpageDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'ContentRequestPage' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
            /// <returns>
            /// ContentrequestpageInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static ContentrequestpageInfo Insert(ContentrequestpageInfo _contentrequestpage)
            {
                return ContentrequestpageDALC.Insert(_contentrequestpage);
            }

            /// <summary>
            /// Update a record in 'ContentRequestPage' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(ContentrequestpageInfo _contentrequestpage)
            {
                ContentrequestpageDALC.Update(_contentrequestpage);
            }

            /// <summary>
            /// Update record(s) in 'ContentRequestPage' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(ContentrequestpageInfo _contentrequestpage, string _whereClause)
            {
                ContentrequestpageDALC.UpdateAllWhere(_contentrequestpage, _whereClause);
            }

            /// <summary>
            /// Update all records in 'ContentRequestPage' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequestpage">ContentrequestpageInfo object</param>
            /// <param name="__contentrequestid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKContentrequestid(ContentrequestpageInfo _contentrequestpage, int __contentrequestid)
            {
                ContentrequestpageDALC.UpdateAllByFKContentrequestid(_contentrequestpage, __contentrequestid);
            }

            /// <summary>
            /// Delete a record in 'ContentRequestPage' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__pageid">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __pageid)
            {
                ContentrequestpageDALC.Delete(__pageid);
            }

            /// <summary>
            /// Delete record(s) in 'ContentRequestPage' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                ContentrequestpageDALC.DeleteAllWhere(_whereClause);

            }

            /// <summary>
            /// Delete a record in 'ContentRequestPage' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ContentRequestId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKContentrequestid(int __contentrequestid)
            {
                ContentrequestpageDALC.DeleteAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get all records from 'ContentRequestPage' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static IList<ContentrequestpageInfo> SelectAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentrequestpageDALC.SelectAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestPage' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequestPage' table matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static int CountAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentrequestpageDALC.CountAllByFKContentrequestid(__contentrequestid);
            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'ContentRequestPage' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'ContentRequestPage' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return ContentrequestpageDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'ContentRequestPage' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'ContentRequestPage' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return ContentrequestpageDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'ContentRequestCategory' table
        /// </summary>
        public static class ContentRequestCategory
        {
            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__contentrequestcategoryid">Primay key ID</param>
            /// <returns>
            /// ContentrequestcategoryInfo object
            /// </returns>
            public static ContentrequestcategoryInfo SelectByPK(int __contentrequestcategoryid)
            {
                return ContentrequestcategoryDALC.SelectByPK(__contentrequestcategoryid);
            }

            /// <summary>
            /// Get a data reader against a primary key joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestcategoryid">Primay key ID</param>
            /// <returns>
            /// ContentrequestcategoryInfo object
            /// </returns>
            public static ContentrequestcategoryInfo SelectFullByPK(int __contentrequestcategoryid)
            {
                return ContentrequestcategoryDALC.SelectFullByPK(__contentrequestcategoryid);
            }

            /// <summary>
            /// Get all records from 'ContentRequestCategory' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestcategoryInfo objects.
            /// </returns>
            public static IList<ContentrequestcategoryInfo> SelectAll()
            {
                return ContentrequestcategoryDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'ContentRequestCategory' table joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of ContentrequestcategoryInfo objects.
            /// </returns>
            public static IList<ContentrequestcategoryInfo> SelectAllFull()
            {
                return ContentrequestcategoryDALC.SelectAllFull();
            }

            /// <summary>
            /// Get all records from 'ContentRequestCategory' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<ContentrequestcategoryInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return ContentrequestcategoryDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestCategory' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'ContentRequestCategory' table
            /// </returns>
            public static int CountAll()
            {
                return ContentrequestcategoryDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestCategory' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'ContentRequestCategory' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return ContentrequestcategoryDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'ContentRequestCategory' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
            /// <returns>
            /// ContentrequestcategoryInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static ContentrequestcategoryInfo Insert(ContentrequestcategoryInfo _contentrequestcategory)
            {
                return ContentrequestcategoryDALC.Insert(_contentrequestcategory);
            }

            /// <summary>
            /// Update a record in 'ContentRequestCategory' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(ContentrequestcategoryInfo _contentrequestcategory)
            {
                ContentrequestcategoryDALC.Update(_contentrequestcategory);
            }

            /// <summary>
            /// Update record(s) in 'ContentRequestCategory' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(ContentrequestcategoryInfo _contentrequestcategory, string _whereClause)
            {
                ContentrequestcategoryDALC.UpdateAllWhere(_contentrequestcategory, _whereClause);
            }

            /// <summary>
            /// Update all records in 'ContentRequestCategory' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_contentrequestcategory">ContentrequestcategoryInfo object</param>
            /// <param name="__contentrequestid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKContentrequestid(ContentrequestcategoryInfo _contentrequestcategory, int __contentrequestid)
            {
                ContentrequestcategoryDALC.UpdateAllByFKContentrequestid(_contentrequestcategory, __contentrequestid);
            }
            /// <summary>
            /// Delete a record in 'ContentRequestCategory' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__contentrequestcategoryid">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __contentrequestcategoryid)
            {
                ContentrequestcategoryDALC.Delete(__contentrequestcategoryid);
            }

            /// <summary>
            /// Delete record(s) in 'ContentRequestCategory' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                ContentrequestcategoryDALC.DeleteAllWhere(_whereClause);

            }

            /// <summary>
            /// Delete a record in 'ContentRequestCategory' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ContentRequestId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKContentrequestid(int __contentrequestid)
            {
                ContentrequestcategoryDALC.DeleteAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get all records from 'ContentRequestCategory' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static IList<ContentrequestcategoryInfo> SelectAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentrequestcategoryDALC.SelectAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get a count of all records from 'ContentRequestCategory' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'ContentRequestCategory' table matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static int CountAllByFKContentrequestid(int __contentrequestid)
            {
                return ContentrequestcategoryDALC.CountAllByFKContentrequestid(__contentrequestid);
            }


            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'ContentRequestCategory' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'ContentRequestCategory' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return ContentrequestcategoryDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'ContentRequestCategory' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'ContentRequestCategory' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return ContentrequestcategoryDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'Errors' table
        /// </summary>
        public static class Error
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
                return ErrorsDALC.SelectByPK(__code);
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
                return ErrorsDALC.SelectAll();
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
                return ErrorsDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'Errors' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'Errors' table
            /// </returns>
            public static int CountAll()
            {
                return ErrorsDALC.CountAll();
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
                return ErrorsDALC.CountAllWhere(_whereClause);
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
                return ErrorsDALC.Insert(_errors);
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
                ErrorsDALC.Update(_errors);
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
                ErrorsDALC.UpdateAllWhere(_errors, _whereClause);
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
                ErrorsDALC.Delete(__code);
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
                ErrorsDALC.DeleteAllWhere(_whereClause);

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
                return ErrorsDALC.SelectAllDataset(_orderBy);
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
                return ErrorsDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'RequestStatus' table
        /// </summary>
        public abstract class RequestStatus
        {
            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__requeststatuscode">Primay key ID</param>
            /// <returns>
            /// RequeststatusInfo object
            /// </returns>
            public static RequeststatusInfo SelectByPK(int __requeststatuscode)
            {
                return RequeststatusDALC.SelectByPK(__requeststatuscode);
            }

            /// <summary>
            /// Get all records from 'RequestStatus' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of RequeststatusInfo objects.
            /// </returns>
            public static IList<RequeststatusInfo> SelectAll()
            {
                return RequeststatusDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'RequestStatus' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<RequeststatusInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return RequeststatusDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'RequestStatus' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'RequestStatus' table
            /// </returns>
            public static int CountAll()
            {
                return RequeststatusDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'RequestStatus' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'RequestStatus' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return RequeststatusDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'RequestStatus' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_requeststatus">RequeststatusInfo object</param>
            /// <returns>
            /// RequeststatusInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static RequeststatusInfo Insert(RequeststatusInfo _requeststatus)
            {
                return RequeststatusDALC.Insert(_requeststatus);
            }

            /// <summary>
            /// Update a record in 'RequestStatus' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_requeststatus">RequeststatusInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(RequeststatusInfo _requeststatus)
            {
                RequeststatusDALC.Update(_requeststatus);
            }

            /// <summary>
            /// Update record(s) in 'RequestStatus' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(RequeststatusInfo _requeststatus, string _whereClause)
            {
                RequeststatusDALC.UpdateAllWhere(_requeststatus, _whereClause);
            }

            /// <summary>
            /// Delete a record in 'RequestStatus' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__requeststatuscode">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __requeststatuscode)
            {
                RequeststatusDALC.Delete(__requeststatuscode);
            }

            /// <summary>
            /// Delete record(s) in 'RequestStatus' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                RequeststatusDALC.DeleteAllWhere(_whereClause);

            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'RequestStatus' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'RequestStatus' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return RequeststatusDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'RequestStatus' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'RequestStatus' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return RequeststatusDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'RequestType' table
        /// </summary>
        public static class RequestType
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
                return RequesttypeDALC.SelectByPK(__requesttypecode);
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
                return RequesttypeDALC.SelectAll();
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
                return RequesttypeDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'RequestType' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'RequestType' table
            /// </returns>
            public static int CountAll()
            {
                return RequesttypeDALC.CountAll();
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
                return RequesttypeDALC.CountAllWhere(_whereClause);
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
                return RequesttypeDALC.Insert(_requesttype);
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
                RequesttypeDALC.Update(_requesttype);
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
                RequesttypeDALC.UpdateAllWhere(_requesttype, _whereClause);
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
                RequesttypeDALC.Delete(__requesttypecode);
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
                RequesttypeDALC.DeleteAllWhere(_whereClause);

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
                return RequesttypeDALC.SelectAllDataset(_orderBy);
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
                return RequesttypeDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'RequestStatusError' table
        /// </summary>
        public static class RequestStatusError
        {
            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__statuserrorid">Primay key ID</param>
            /// <returns>
            /// RequeststatuserrorInfo object
            /// </returns>
            public static RequeststatuserrorInfo SelectByPK(int __statuserrorid)
            {
                return RequeststatuserrorDALC.SelectByPK(__statuserrorid);
            }

            /// <summary>
            /// Get a data reader against a primary key joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__statuserrorid">Primay key ID</param>
            /// <returns>
            /// RequeststatuserrorInfo object
            /// </returns>
            public static RequeststatuserrorInfo SelectFullByPK(int __statuserrorid)
            {
                return RequeststatuserrorDALC.SelectFullByPK(__statuserrorid);
            }

            /// <summary>
            /// Get all records from 'RequestStatusError' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of RequeststatuserrorInfo objects.
            /// </returns>
            public static IList<RequeststatuserrorInfo> SelectAll()
            {
                return RequeststatuserrorDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'RequestStatusError' table joined to all foreign keys tables
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of RequeststatuserrorInfo objects.
            /// </returns>
            public static IList<RequeststatuserrorInfo> SelectAllFull()
            {
                return RequeststatuserrorDALC.SelectAllFull();
            }

            /// <summary>
            /// Get all records from 'RequestStatusError' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<RequeststatuserrorInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return RequeststatuserrorDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'RequestStatusError' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'RequestStatusError' table
            /// </returns>
            public static int CountAll()
            {
                return RequeststatuserrorDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'RequestStatusError' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'RequestStatusError' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return RequeststatuserrorDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'RequestStatusError' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
            /// <returns>
            /// RequeststatuserrorInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static RequeststatuserrorInfo Insert(RequeststatuserrorInfo _requeststatuserror)
            {
                return RequeststatuserrorDALC.Insert(_requeststatuserror);
            }

            /// <summary>
            /// Update a record in 'RequestStatusError' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(RequeststatuserrorInfo _requeststatuserror)
            {
                RequeststatuserrorDALC.Update(_requeststatuserror);
            }

            /// <summary>
            /// Update record(s) in 'RequestStatusError' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(RequeststatuserrorInfo _requeststatuserror, string _whereClause)
            {
                RequeststatuserrorDALC.UpdateAllWhere(_requeststatuserror, _whereClause);
            }

            /// <summary>
            /// Update all records in 'RequestStatusError' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
            /// <param name="__contentrequestid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKContentrequestid(RequeststatuserrorInfo _requeststatuserror, int __contentrequestid)
            {
                RequeststatuserrorDALC.UpdateAllByFKContentrequestid(_requeststatuserror, __contentrequestid);
            }

            /// <summary>
            /// Update all records in 'RequestStatusError' table matching to the foreign key value
            /// This method is available for tables who have foreign key(s) defined		
            /// </summary>
            /// <param name="_requeststatuserror">RequeststatuserrorInfo object</param>
            /// <param name="__errorid">Foreign key value</param>		
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllByFKErrorid(RequeststatuserrorInfo _requeststatuserror, int __errorid)
            {
                RequeststatuserrorDALC.UpdateAllByFKErrorid(_requeststatuserror, __errorid);
            }

            /// <summary>
            /// Delete a record in 'RequestStatusError' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__statuserrorid">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __statuserrorid)
            {
                RequeststatuserrorDALC.Delete(__statuserrorid);
            }

            /// <summary>
            /// Delete record(s) in 'RequestStatusError' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                RequeststatuserrorDALC.DeleteAllWhere(_whereClause);

            }

            /// <summary>
            /// Delete a record in 'RequestStatusError' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ContentRequestId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKContentrequestid(int __contentrequestid)
            {
                RequeststatuserrorDALC.DeleteAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Delete a record in 'RequestStatusError' table.
            /// This method is available for tables who have foreign key(s) defined	
            /// </summary>
            /// <param name="ErrorId">Foreign key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllByFKErrorid(int __errorid)
            {
                RequeststatuserrorDALC.DeleteAllByFKErrorid(__errorid);
            }

            /// <summary>
            /// Get all records from 'RequestStatusError' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static IList<RequeststatuserrorInfo> SelectAllByFKContentrequestid(int __contentrequestid)
            {
                return RequeststatuserrorDALC.SelectAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get a count of all records from 'RequestStatusError' table matching to the foreign key 'ContentRequestId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__contentrequestid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'RequestStatusError' table matching with 'ContentRequestId' foreign key value
            /// </returns>
            public static int CountAllByFKContentrequestid(int __contentrequestid)
            {
                return RequeststatuserrorDALC.CountAllByFKContentrequestid(__contentrequestid);
            }

            /// <summary>
            /// Get all records from 'RequestStatusError' table matching to the foreign key 'ErrorId'
            /// This method is generated for tables who have foreign key(s)
            /// </summary>
            /// <param name="__errorid">Foreign key value</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Collection of objects matching with 'ErrorId' foreign key value
            /// </returns>
            public static IList<RequeststatuserrorInfo> SelectAllByFKErrorid(int __errorid)
            {
                return RequeststatuserrorDALC.SelectAllByFKErrorid(__errorid);
            }

            /// <summary>
            /// Get a count of all records from 'RequestStatusError' table matching to the foreign key 'ErrorId'
            /// This method is generated for tables who have foreign key(s)		
            /// </summary>
            /// <param name="__errorid">Foreign key value</param>
            /// <returns>
            /// Total number of records from 'RequestStatusError' table matching with 'ErrorId' foreign key value
            /// </returns>
            public static int CountAllByFKErrorid(int __errorid)
            {
                return RequeststatuserrorDALC.CountAllByFKErrorid(__errorid);
            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'RequestStatusError' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'RequestStatusError' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return RequeststatuserrorDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'RequestStatusError' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'RequestStatusError' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return RequeststatuserrorDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'SmtpSetting' table
        /// </summary>
        public static class Smtpsetting
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
                return SmtpsettingDALC.SelectByPK(__pmhost);
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
                return SmtpsettingDALC.SelectFullByPK(__pmhost);
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
                return SmtpsettingDALC.SelectAll();
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
                return SmtpsettingDALC.SelectAllFull();
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
                return SmtpsettingDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'SmtpSetting' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'SmtpSetting' table
            /// </returns>
            public static int CountAll()
            {
                return SmtpsettingDALC.CountAll();
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
                return SmtpsettingDALC.CountAllWhere(_whereClause);
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
                return SmtpsettingDALC.Insert(_smtpsetting);
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
                SmtpsettingDALC.Update(_smtpsetting);
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
                SmtpsettingDALC.UpdateAllWhere(_smtpsetting, _whereClause);
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
                SmtpsettingDALC.UpdateAllByFKUpdatedby(_smtpsetting, __updatedby);
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
                SmtpsettingDALC.Delete(__pmhost);
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
                SmtpsettingDALC.DeleteAllWhere(_whereClause);

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
                SmtpsettingDALC.DeleteAllByFKUpdatedby(__updatedby);
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
                return SmtpsettingDALC.SelectAllByFKUpdatedby(__updatedby);
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
                return SmtpsettingDALC.CountAllByFKUpdatedby(__updatedby);
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
                return SmtpsettingDALC.SelectAllDataset(_orderBy);
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
                return SmtpsettingDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'User' table
        /// </summary>
        public static class User
        {
            #region custom methods

            /// <summary>
            /// 
            /// </summary>
            /// <param name="WhereClause"></param>
            /// <param name="OrderBy"></param>
            /// <returns></returns>
            public static IList<UserInfo> SelectAllWhere(string _whereClause, string _orderBy, int _pageNumber, int _pageSize)
            {
                return UserDALC.SelectAllWhere(_whereClause, _orderBy, _pageNumber, _pageSize);
            }

            #endregion

            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__userid">Primay key ID</param>
            /// <returns>
            /// UserInfo object
            /// </returns>
            public static UserInfo SelectByPK(int __userid)
            {
                return UserDALC.SelectByPK(__userid);
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
                return UserDALC.SelectFullByPK(__userid);
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
                return UserDALC.SelectAll();
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
                return UserDALC.SelectAllFull();
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
                return UserDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'User' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'User' table
            /// </returns>
            public static int CountAll()
            {
                return UserDALC.CountAll();
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
                return UserDALC.CountAllWhere(_whereClause);
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
                return UserDALC.Insert(_user);
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
                UserDALC.Update(_user);
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
                UserDALC.UpdateAllWhere(_user, _whereClause);
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
                UserDALC.UpdateAllByFKCountryid(_user, __countryid);
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
                UserDALC.UpdateAllByFKStateid(_user, __stateid);
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
                UserDALC.UpdateAllByFKUpdatedby(_user, __updatedby);
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
                UserDALC.Delete(__userid);
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
                UserDALC.DeleteAllWhere(_whereClause);

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
                UserDALC.DeleteAllByFKCountryid(__countryid);
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
                UserDALC.DeleteAllByFKStateid(__stateid);
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
                UserDALC.DeleteAllByFKUpdatedby(__updatedby);
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
                return UserDALC.SelectAllByFKCountryid(__countryid);
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
                return UserDALC.CountAllByFKCountryid(__countryid);
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
                return UserDALC.SelectAllByFKStateid(__stateid);
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
                return UserDALC.CountAllByFKStateid(__stateid);
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
                return UserDALC.SelectAllByFKUpdatedby(__updatedby);
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
                return UserDALC.CountAllByFKUpdatedby(__updatedby);
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
                return UserDALC.SelectAllDataset(_orderBy);
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
                return UserDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'UserToken' table
        /// </summary>
        public static class UserToken
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
                return UsertokenDALC.SelectByPK(__tokenid);
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
                return UsertokenDALC.SelectFullByPK(__tokenid);
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
                return UsertokenDALC.SelectAll();
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
                return UsertokenDALC.SelectAllFull();
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
                return UsertokenDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'UserToken' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'UserToken' table
            /// </returns>
            public static int CountAll()
            {
                return UsertokenDALC.CountAll();
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
                return UsertokenDALC.CountAllWhere(_whereClause);
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
                return UsertokenDALC.Insert(_usertoken);
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
                UsertokenDALC.Update(_usertoken);
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
                UsertokenDALC.UpdateAllWhere(_usertoken, _whereClause);
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
                UsertokenDALC.UpdateAllByFKUserid(_usertoken, __userid);
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
                UsertokenDALC.Delete(__tokenid);
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
                UsertokenDALC.DeleteAllWhere(_whereClause);

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
                UsertokenDALC.DeleteAllByFKUserid(__userid);
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
                return UsertokenDALC.SelectAllByFKUserid(__userid);
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
                return UsertokenDALC.CountAllByFKUserid(__userid);
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
                return UsertokenDALC.SelectAllDataset(_orderBy);
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
                return UsertokenDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        /// <summary>
        /// General database operations related to 'WorkRequest' table
        /// </summary>
        public static class WorkRequest
        {
            /// <summary>
            /// Get an object from database using primary key
            /// </summary>
            /// <param name="__id">Primay key ID</param>
            /// <returns>
            /// WorkrequestInfo object
            /// </returns>
            public static WorkrequestInfo SelectByPK(int __id)
            {
                return WorkrequestDALC.SelectByPK(__id);
            }

            /// <summary>
            /// Get all records from 'WorkRequest' table
            /// </summary>
            /// <param></param>
            /// <returns>
            /// IList containing collection of WorkrequestInfo objects.
            /// </returns>
            public static IList<WorkrequestInfo> SelectAll()
            {
                return WorkrequestDALC.SelectAll();
            }

            /// <summary>
            /// Get all records from 'WorkRequest' table, filtered by where clause
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause, pass string.Empty to get a complete ordered list</param>
            /// <param name="_orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// IList containing an ordered collection of objects filtered by the WHERE
            /// clause provided to the method
            /// </returns>
            public static IList<WorkrequestInfo> SelectAllWhere(string _whereClause, string _orderBy)
            {
                return WorkrequestDALC.SelectAllWhere(_whereClause, _orderBy);
            }

            /// <summary>
            /// Get a count of all records from 'WorkRequest' table
            /// </summary>
            /// <returns>
            /// Total number of records in 'WorkRequest' table
            /// </returns>
            public static int CountAll()
            {
                return WorkrequestDALC.CountAll();
            }

            /// <summary>
            /// Get a count of all records from 'WorkRequest' table filtered by the WHERE
            /// clause e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="_whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Number of records in 'WorkRequest' table matching with sql WHERE clause
            /// </returns>
            public static int CountAllWhere(string _whereClause)
            {
                return WorkrequestDALC.CountAllWhere(_whereClause);
            }

            /// <summary>
            /// Insert a record in 'WorkRequest' table
            /// This method is available for tables who have primary key defined
            /// </summary>
            /// <param name="_workrequest">WorkrequestInfo object</param>
            /// <returns>
            /// WorkrequestInfo object with any additional computed values such as 
            /// auto-number (identity) added to the object
            /// </returns>
            public static WorkrequestInfo Insert(WorkrequestInfo _workrequest)
            {
                return WorkrequestDALC.Insert(_workrequest);
            }

            /// <summary>
            /// Update a record in 'WorkRequest' table
            /// This method is available for tables who have primary key defined		
            /// </summary>
            /// <param name="_workrequest">WorkrequestInfo object</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Update(WorkrequestInfo _workrequest)
            {
                WorkrequestDALC.Update(_workrequest);
            }

            /// <summary>
            /// Update record(s) in 'WorkRequest' table according to SQL WHERE condition.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void UpdateAllWhere(WorkrequestInfo _workrequest, string _whereClause)
            {
                WorkrequestDALC.UpdateAllWhere(_workrequest, _whereClause);
            }

            /// <summary>
            /// Delete a record in 'WorkRequest' table.
            /// This method is available for tables who have primary key defined	
            /// </summary>
            /// <param name="__id">Primay key ID</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void Delete(int __id)
            {
                WorkrequestDALC.Delete(__id);
            }

            /// <summary>
            /// Delete record(s) in 'WorkRequest' table according to SQL WHERE condition
            /// e.g. --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.		
            /// </summary>
            /// <param name="wQuery">SQL WHERE clause</param>
            /// <returns>
            /// Nothing
            /// </returns>
            public static void DeleteAllWhere(string _whereClause)
            {
                WorkrequestDALC.DeleteAllWhere(_whereClause);

            }

            #region "Methods returning dataset"
            /// <summary>
            /// Get all records from 'WorkRequest' table in form of a dataset
            /// </summary>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>
            /// <returns>
            /// Dataset containing all records from 'WorkRequest' table
            /// </returns>
            public static DataSet SelectAllDataset(string _orderBy)
            {
                return WorkrequestDALC.SelectAllDataset(_orderBy);
            }

            /// <summary>
            /// Get all records from 'WorkRequest' table, in form of a dataset, filtered by
            /// WHERE clause --ORDER_DATE = '6/7/2005'-- or --ID=10-- or user='guest' etc.
            /// </summary>
            /// <param name="whereClause">SQL WHERE clause</param>
            /// <param name="orderBy">SQL ORDER By clause e.g. Name ASC, Date DESC, or BookingDate, Name or string.Empty</param>		
            /// <returns>
            /// DataSet containing all records from 'WorkRequest' table filtered
            /// by the WHERE clause provided to the method
            /// </returns>
            public static DataSet SelectAllWhereDataset(string _whereClause, string _orderBy)
            {
                return WorkrequestDALC.SelectAllWhereDataset(_whereClause, _orderBy);
            }
            #endregion
        }

        #endregion
    }

    public static class SharedClass
    {
        public static string uri_content = "apihome/content";
        public static string uri_workrequests = "apihome/workrequests";
        public static string uri_contentrequests = "apihome/contentrequests";
        public static string uri_windowsServerapi = "apihome/";

        public static void setConnString(string strConnString)
        {
            BaseDALC.CONN_STRING = strConnString;
        }

        public static string handleCsvComma(string strData)
        {
            if (strData.Contains(","))
            {
                if (strData.Contains("\""))
                    strData = "\"\"" + strData + "\"\"";
                else
                    strData = "\"" + strData + "\"";
            }

            return strData;
        }

        //public static void LoadConfig()
        //{
        //    if (ConfigurationManager.AppSettings.Count > 0 && ConfigurationManager.AppSettings.Count == 3)
        //    {
        //        uri_content = ConfigurationManager.AppSettings.Get("content");
        //        uri_workrequests = ConfigurationManager.AppSettings.Get("workrequests");
        //        uri_contentrequests = ConfigurationManager.AppSettings.Get("contentrequests");
        //    }
        //}

        //private static HttpWebRequest CreateWebRequest(string endPoint, string method)
        //{
        //    var request = (HttpWebRequest)WebRequest.Create(endPoint);

        //    request.Method = method.ToUpper();
        //    request.ContentLength = 0;
        //    request.ContentType = "text/xml";

        //    return request;
        //}

        //public static string testing() { return "asdf"; }

        //public static string GetMessage(string endPoint, string method)
        //{
        //    HttpWebRequest request = CreateWebRequest(endPoint, method);

        //    using (var response = (HttpWebResponse)request.GetResponse())
        //    {
        //        var responseValue = string.Empty;

        //        if (response.StatusCode != HttpStatusCode.OK)
        //        {
        //            string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
        //            throw new ApplicationException(message);
        //        }

        //        // grab the response
        //        using (var responseStream = response.GetResponseStream())
        //        {
        //            using (var reader = new StreamReader(responseStream))
        //            {
        //                responseValue = reader.ReadToEnd();
        //            }
        //        }

        //        return responseValue;
        //    }
        //}

        //public static string WIndowsForms(string uri_ENDPoint, string method, string contentProvided = "")
        //{

        //    try
        //    {
        //        string content;
        //        string Method = method;

        //        string uri = uri_ENDPoint;

        //        HttpWebRequest req = WebRequest.Create(uri.Trim()) as HttpWebRequest;
        //        req.KeepAlive = false;
        //        req.Method = Method.ToUpper();

        //        if (("POST,PUT").Split(',').Contains(Method.ToUpper()))
        //        {
        //            var t = "http://schemas.datacontract.org/2004/07/RESTfulAPI.ModelandDAL";
        //            // Console.WriteLine("Enter XML FilePath:");
        //            // string FilePath = Console.ReadLine();
        //            content = "<Content xmlns=\"" + t + "\">" +
        //           "<ContentAuthorId>1</ContentAuthorId><ContentRequestId>6</ContentRequestId><ContentStatus>6</ContentStatus>"
        //           + "<ContentText>mnz33333xcvmnx.,czmvn</ContentText><ContentTitle>asdf</ContentTitle><Id>99</Id></Content>";
        //            //   content = contentProvided;

        //            //  content = content.Replace("\n", "");

        //            byte[] buffer = Encoding.ASCII.GetBytes(content);
        //            req.ContentLength = buffer.Length;
        //            req.ContentType = "text/xml";
        //            Stream PostData = req.GetRequestStream();
        //            PostData.Write(buffer, 0, buffer.Length);
        //            PostData.Close();

        //        }

        //        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;


        //        Encoding enc = System.Text.Encoding.GetEncoding(1252);
        //        StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);

        //        string Response = loResponseStream.ReadToEnd();

        //        loResponseStream.Close();
        //        resp.Close();
        //        return Response;

        //        //XMLcolor.HighlightRTF(richTextBox2, "content");
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //        //Console.WriteLine(ex.Message.ToString());

        //    }



        //}

    }
}