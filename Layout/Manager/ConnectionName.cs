using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Layout.Manager
{
        //using Common;
        public enum ConnectionName
        {
            DefaultConnection, CustomConnection
        }

        public class clsConnection
        {

            #region Creating Database Objects

            internal static string GetConnectionString(ConnectionName objConnectionName)
            {
                if (objConnectionName == ConnectionName.DefaultConnection)
                {
                    return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                }
                else
                {
                    return ConfigurationManager.ConnectionStrings["CustomConnection"].ConnectionString;
                }

            }

            public static SqlConnection GetConnection(ConnectionName objConnectionName)
            {
                SqlConnection objConnection = new SqlConnection();
                objConnection.ConnectionString = GetConnectionString(objConnectionName);
                return objConnection;
            }

            private static SqlCommand GetCommand(SqlConnection objConnection, string strQuery, CommandType objType)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = strQuery;
                objCommand.CommandType = objType;
                return objCommand;
            }

            private static SqlCommand GetCommand(SqlConnection objConnection, string strQuery)
            {
                return GetCommand(objConnection, strQuery, CommandType.Text);
            }

            private static SqlDataAdapter GetDataAdapter(SqlCommand objCommand)
            {
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(objCommand);
                return objDataAdapter;
            }

            #endregion

            #region Return DataReader Against a Select Query

            public static SqlDataReader GetDataReader(string strQuery)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataReader(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static SqlDataReader GetDataReader(string strQuery, CommandType objType)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataReader(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery)
            {
                return GetDataReader(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
            {
                return GetDataReader(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static SqlDataReader GetDataReader(string strQuery, ConnectionName objConnectionName)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataReader(objParameterList, strQuery, CommandType.Text, objConnectionName);
            }

            public static SqlDataReader GetDataReader(string strQuery, CommandType objType, ConnectionName objConnectionName)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataReader(objParameterList, strQuery, objType, objConnectionName);
            }

            public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery, ConnectionName objConnectionName)
            {
                return GetDataReader(objParameterList, strQuery, CommandType.Text, objConnectionName);
            }

            public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName

    objConnectionName)
            {
                SqlConnection objConnection = null;
                SqlCommand objCommand = null;
                SqlDataReader objDataReader;

                objConnection = GetConnection(objConnectionName);
                objConnection.Open();
                using (objCommand = GetCommand(objConnection, strQuery, objType))
                {
                    foreach (SqlParameter objParameter in objParameterList)
                    {
                        if (objParameter.Value == null)
                            objParameter.Value = DBNull.Value;
                        objCommand.Parameters.Add(objParameter);
                    }
                    objDataReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                }
                return objDataReader;
            }

            #endregion

            #region Return DataTable Against a select query

            public static DataTable GetDataTable(string strQuery)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataTable(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }
            public static DataTable GetDataTable(string strQuery, CommandType objType)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataTable(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }
            public static DataTable GetDataTable(List<SqlParameter> objParameterList, string strQuery)
            {
                return GetDataTable(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }
            public static DataTable GetDataTable(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
            {
                return GetDataTable(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }
            public static DataTable GetDataTable(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName

    objConnectionName)
            {
                SqlCommand objCommand = null;
                DataTable objDataTable = null;
                SqlDataAdapter objDataAdapter = null;

                using (objCommand = GetCommand(GetConnection(objConnectionName), strQuery, objType))
                {
                    foreach (SqlParameter objParameter in objParameterList)
                    {
                        if (objParameter.Value == null)
                            objParameter.Value = DBNull.Value;
                        objCommand.Parameters.Add(objParameter);
                    }
                    objCommand.CommandTimeout = 0;
                    objDataAdapter = GetDataAdapter(objCommand);
                    objDataTable = new DataTable();
                    objDataAdapter.Fill(objDataTable);

                }
                return objDataTable;
            }

            //Fill DataTable Using Entity Framework using linq Query with all Possible way
            public static DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }

            #endregion

            #region Return Dataset Against a select query

            public static DataSet GetDataSet(string strQuery)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataSet(objParameterList, strQuery, CommandType.Text, string.Empty, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(string strQuery, string tableName)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataSet(objParameterList, strQuery, CommandType.Text, tableName, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(string strQuery, CommandType objType)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataSet(objParameterList, strQuery, objType, string.Empty, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(string strQuery, CommandType objType, string tableName)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetDataSet(objParameterList, strQuery, objType, tableName, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery)
            {
                return GetDataSet(objParameterList, strQuery, CommandType.Text, string.Empty, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, string tableName)
            {
                return GetDataSet(objParameterList, strQuery, CommandType.Text, tableName, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
            {
                return GetDataSet(objParameterList, strQuery, objType, string.Empty, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, CommandType objType, string tableName)
            {
                return GetDataSet(objParameterList, strQuery, objType, tableName, ConnectionName.DefaultConnection);
            }

            public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, CommandType objType, string tableName,

    ConnectionName objConnectionName)
            {
                SqlCommand objCommand = null;
                DataSet objDataSet = null;
                SqlDataAdapter objDataAdapter = null;

                using (objCommand = GetCommand(GetConnection(objConnectionName), strQuery, objType))
                {
                    foreach (SqlParameter objParameter in objParameterList)
                    {
                        if (objParameter.Value == null)
                            objParameter.Value = DBNull.Value;
                        objCommand.Parameters.Add(objParameter);
                    }

                    objCommand.CommandTimeout = 0;
                    objDataAdapter = GetDataAdapter(objCommand);
                    objDataSet = new DataSet();
                    if (tableName.Equals(string.Empty))
                    {
                        objDataAdapter.Fill(objDataSet);
                    }
                    else
                    {
                        objDataAdapter.Fill(objDataSet, tableName);
                    }
                }
                return objDataSet;
            }

            #endregion

            #region Return Scaler value against a query

            public static object GetScalarValue(string strQuery)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetScalarValue(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static object GetScalarValue(string strQuery, CommandType objType)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return GetScalarValue(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static object GetScalarValue(List<SqlParameter> objParameterList, string strQuery)
            {
                return GetScalarValue(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static object GetScalarValue(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
            {
                return GetScalarValue(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static object GetScalarValue(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName

    objConnectionName)
            {
                SqlConnection objConnection = null;
                SqlCommand objCommand = null;
                object objValue = null;

                using (objConnection = GetConnection(objConnectionName))
                {
                    objConnection.Open();
                    using (objCommand = GetCommand(objConnection, strQuery, objType))
                    {
                        foreach (SqlParameter objParameter in objParameterList)
                        {
                            if (objParameter.Value == null)
                                objParameter.Value = DBNull.Value;
                            objCommand.Parameters.Add(objParameter);
                        }

                        objValue = objCommand.ExecuteScalar();
                    }
                    return objValue;
                }
            }

            #endregion

            #region Execute a query against a database

            public static int ExecuteQuery(string strQuery)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return ExecuteQuery(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static int ExecuteQuery(string strQuery, CommandType objType)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return ExecuteQuery(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static int ExecuteQuery(List<SqlParameter> objParameterList, string strQuery)
            {
                return ExecuteQuery(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static int ExecuteQuery(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
            {
                return ExecuteQuery(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static int ExecuteQuery(string strQuery, ConnectionName objConnectionName)
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return ExecuteQuery(objParameterList, strQuery, CommandType.Text, objConnectionName);
            }

            public static int ExecuteQuery(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName

    objConnectionName)
            {
                SqlConnection objConnection = null;
                SqlCommand objCommand = null;
                int rowAffected = 0;

                using (objConnection = GetConnection(objConnectionName))
                {
                    objConnection.Open();
                    using (objCommand = GetCommand(objConnection, strQuery, objType))
                    {
                        foreach (SqlParameter objParameter in objParameterList)
                        {
                            if (objParameter.Value == null)
                                objParameter.Value = DBNull.Value;
                            objCommand.Parameters.Add(objParameter);
                        }
                        objCommand.CommandTimeout = 0;
                        rowAffected = objCommand.ExecuteNonQuery();
                    }
                    return rowAffected;
                }
            }

            public static int ExecuteDataSet(DataSet objDataSet, string strSelectQuery, CommandType objType)
            {
                return ExecuteDataSet(new List<SqlParameter>(), objDataSet, strSelectQuery, objType, ConnectionName.DefaultConnection);
            }

            public static int ExecuteDataSet(List<SqlParameter> objParameterList, DataSet objDataSet, string strSelectQuery, CommandType

    objType)
            {
                return ExecuteDataSet(objParameterList, objDataSet, strSelectQuery, objType, ConnectionName.DefaultConnection);
            }

            public static int ExecuteDataSet(List<SqlParameter> objParameterList, DataSet objDataSet, string strSelectQuery, CommandType

    objType, ConnectionName objConnectionName)
            {
                SqlConnection objConnection = null;
                SqlCommand objCommand = null;
                SqlDataAdapter objDataAdapter = null;
                SqlCommandBuilder objCommandBuilder = null;
                int rowAffected = 0;

                using (objConnection = GetConnection(objConnectionName))
                {
                    objConnection.Open();
                    using (objCommand = GetCommand(objConnection, strSelectQuery, objType))
                    {
                        foreach (SqlParameter objParameter in objParameterList)
                        {
                            if (objParameter.Value == null)
                                objParameter.Value = DBNull.Value;
                            objCommand.Parameters.Add(objParameter);
                        }

                        objDataAdapter = GetDataAdapter(objCommand);
                        objCommandBuilder = new SqlCommandBuilder(objDataAdapter);

                        rowAffected = objDataAdapter.Update(objDataSet);
                    }
                    return rowAffected;
                }
            }

            #endregion

            #region Load a List of Object

            public static List<T> LoadObjectList<T>(string strQuery) where T : new()
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();

                return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static List<T> LoadObjectList<T>(string strQuery, CommandType objType) where T : new()
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return LoadObjectList<T>(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery) where T : new()
            {
                return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
            }

            public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery, CommandType objType) where T : new()
            {
                return LoadObjectList<T>(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
            }

            public static List<T> LoadObjectList<T>(string strQuery, ConnectionName objConnectionName) where T : new()
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, objConnectionName);
            }

            public static List<T> LoadObjectList<T>(string strQuery, CommandType objType, ConnectionName objConnectionName) where T : new()
            {
                List<SqlParameter> objParameterList = new List<SqlParameter>();
                return LoadObjectList<T>(objParameterList, strQuery, objType, objConnectionName);
            }

            public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery, ConnectionName objConnectionName)

    where T : new()
            {
                return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, objConnectionName);
            }

            public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName

    objConnectionName) where T : new()
            {
                List<T> objList = new List<T>();
                SqlDataReader objDataReader = null;
                T obj, addObject;
                try
                {
                    using (objDataReader = GetDataReader(objParameterList, strQuery, objType, objConnectionName))
                    {
                        while (objDataReader.Read())
                        {
                            addObject = new T();
                            foreach (PropertyInfo objProInfo in addObject.GetType().GetProperties())
                            {
                                if (IsColumnExists(objDataReader, objProInfo.Name))
                                {
                                    if (!objDataReader.IsDBNull(objDataReader.GetOrdinal(objProInfo.Name)))
                                    {
                                        Type convertTo = Nullable.GetUnderlyingType(objProInfo.PropertyType) ?? objProInfo.PropertyType;
                                        objProInfo.SetValue(addObject, Convert.ChangeType(objDataReader[objProInfo.Name], convertTo), null);
                                    }
                                }

                            }

                            objList.Add(addObject);
                        }

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

                return objList;
            }

            private static bool IsColumnExists(SqlDataReader dr, string columnName)
            {
                bool ColumnExists;
                try
                {
                    int columnOrdinal = dr.GetOrdinal(columnName);
                    ColumnExists = true;
                }
                catch (IndexOutOfRangeException)
                {
                    ColumnExists = false;
                }

                return ColumnExists;
            }

            #endregion


            #region Execute procedure using SqlParameter[]

            public static int RunSP_ReturnInt(string procedureName, SqlParameter[] parameters)
            {
                int AddRow = -1;
                using (SqlConnection sqlConn = GetConnection(ConnectionName.DefaultConnection))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            sqlCommand.Parameters.AddRange(parameters);
                        }
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlConn.Open();
                        }

                        AddRow = sqlCommand.ExecuteNonQuery();
                    }
                }
                return AddRow;
            }
            public static DataTable RunSP_ReturnDT(string procedureName, SqlParameter[] parameters)
            {
                DataTable dtData = new DataTable();
                using (SqlConnection sqlConn = GetConnection(ConnectionName.DefaultConnection))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());
                        }
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dtData);
                        }
                    }
                }
                return dtData;
            }

            #endregion
        }
    }