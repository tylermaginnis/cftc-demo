using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace cftc.demo.DAL
{
    public static class SqlHelper
    {
        public static string ctfcdemo_conn = "data source=localhost\\MSSQLSERVER01;initial catalog=cftc-demo;Trusted_Connection=true;MultipleActiveResultSets=True;";

        public static IEnumerable<Models.Book> GetBooks(string sp)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(ctfcdemo_conn))
                {


                    SqlCommand _sqlCommand = SqlReflectEngine.CreateCommand(sp, null);

                    _sqlCommand.CommandTimeout = 30;

                    _sqlCommand.Connection = _connection;

                    DataTable _dt = new DataTable();

                    new SqlDataAdapter(_sqlCommand).Fill(_dt);

                    Mapping.DataNamesMapper<Models.Book> orderMapper =
                        new Mapping.DataNamesMapper<Models.Book>();

                    IEnumerable<Models.Book> Books = orderMapper.Map(_dt);

                    return Books;
                }
            } catch (Exception ex)
            {
                // to-do: handle ex + log
            }
            return Enumerable.Range(0,0).Select(index => new Models.Book{});
        }

        public static bool UploadBooks(IEnumerable<Models.Book> books)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(ctfcdemo_conn))
                {
                    _connection.Open();
                    DataTable dt =  Models.BookHelper.ToDataTable<Models.Book>(books);

                    SqlBulkCopy _sqlBulkCopy = new SqlBulkCopy(_connection);

                    _sqlBulkCopy.DestinationTableName = "Books";

                    _sqlBulkCopy.WriteToServer(dt);

                    return true;
                }
            }
            catch (Exception ex)
            {
                // to-do: handle ex + log
            }
            return false;
        }


    }

    public static class SqlReflectEngine
    {

        public static SqlCommand CreateCommand(string StoredProcedure, object SqlParameters)
        {
            try
            {
                SqlCommand _sqlCommand = new SqlCommand();
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.CommandText = StoredProcedure;
                _sqlCommand.Parameters.Clear();

                if (SqlParameters != null)
                {
                    PropertyInfo[] _properties = SqlParameters.GetType().GetProperties();
                    foreach (PropertyInfo _property in _properties)
                    {
                        string _typeName = _property.PropertyType.Name;
                        DbType _dbType = new DbType();

                        if (_typeName == "String")
                            _dbType = DbType.String;

                        if (_typeName == "DateTime")
                            _dbType = DbType.DateTime;

                        if (_typeName == "Byte[]")
                            _dbType = DbType.Binary;

                        object _value = SqlParameters.GetType().GetProperty(_property.Name).GetValue(SqlParameters, null);

                        SqlParameter _sqlParameter = new SqlParameter();
                        _sqlParameter.DbType = _dbType;
                        _sqlParameter.ParameterName = "@" + _property.Name;
                        _sqlParameter.Value = _value;

                        _sqlCommand.Parameters.Add(_sqlParameter);
                    }
                }

                return _sqlCommand;
            } catch (Exception ex) {
                // to-do: handle ex + log
            } 
            return new SqlCommand();
        }

    }
}
