/*
'===============================================================================
'  *** DAL Generated from AAG-Framework 2.00 (c)Powersoft19 ***
'
'  Abstract base class for all DAL components. All common functionalities
'  related to  DAL components will be in this class.
'===============================================================================
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace DAL
{
    public abstract class BaseDALC
    {

        public static string CONN_STRING;//= "";ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

        //Add common functionality for all DAL components
        public BaseDALC()
        {
            //Constructor
        }

        /// <summary>
        /// Remove extra white spaces from a string
        /// i.e. removes all white spaces except a single space
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>
        /// String with extra white spaces removed
        /// </returns>
        private static string RemoveExtraWhiteSpaces(string str)
        {
            if (str.Length > 0)
            {
                while (str.IndexOf("  ") > -1)
                    str = str.Replace("  ", " ");
            }
            return str;
        }

    }
}