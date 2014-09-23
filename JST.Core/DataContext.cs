using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DTS.AppFramework.Core;

namespace JST.Core
{
    public class DataContext : IDisposable
    {
        private readonly string _connectionStringName;
        private SqlTransaction _sqlTransaction;
        private SqlConnection _sqlConnection;

        public DataContext(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }

        private void Connect()
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString);

                _sqlConnection.Open();
            }
        }

        public void OpenTransation()
        {
            Connect();

            _sqlTransaction = _sqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            if (_sqlTransaction == null)
            {
                throw new Exception("No current Transaction Open.");
            }

            try
            {
                _sqlTransaction.Commit();
            }
            finally
            {
                _sqlTransaction = null;
            }
        }

        public void Rollback()
        {
        }

        public DataRow ExecuteDataRow(string text, CommandType commandType, params  Parameter[] parameters)
        {
            DataRow[] dataRows = ExecuteDataRows(text, commandType, parameters).ToArray();

            if (dataRows.Length > 1)
            {
                throw new Exception("Zero or 1 rows expected.");
            }

            return dataRows.Length == 0 ? null : dataRows[0];
        }

        public IEnumerable<DataRow> ExecuteDataRows(string text, CommandType commandType, params  Parameter[] parameters)
        {
            return ExecuteDataSet(text, commandType, parameters).Tables[0].Rows.Cast<DataRow>();
        }

        public DataTable ExecuteDataTable(string text, CommandType commandType, params  Parameter[] parameters)
        {
            return ExecuteDataSet(text, commandType, parameters).Tables[0];
        }

        public DataSet ExecuteDataSet(string text, CommandType commandType, params  Parameter[] parameters)
        {
            DataSet dataSet = new DataSet();

            ExecuteCommand(command =>
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                {
                    sqlDataAdapter.Fill(dataSet);
                }
            }, text, commandType, parameters);

            return dataSet;
        }

        public T ExecuteScalar<T>(string text, CommandType commandType, params  Parameter[] parameters)
        {
            T t = default(T);

            ExecuteCommand(command =>
            {
                t = (T)command.ExecuteScalar();
            }, text, commandType, parameters);

            return t;
        }

        public IEnumerable<T> ExecuteEnumerable<T>(string text, CommandType commandType, params  Parameter[] parameters)
        {
            return ExecuteDataSet(text, commandType, parameters).Tables[0].Rows.Cast<DataRow>().Select(item => item.Field<T>(0));
        }

        public void ExecuteNonQuery(string text, CommandType commandType, params  Parameter[] parameters)
        {
            ExecuteCommand(command => command.ExecuteNonQuery(), text, commandType, parameters);
        }

        private void ExecuteCommand(Action<SqlCommand> action, string text, CommandType commandType, params  Parameter[] parameters)
        {
            Connect();

            using (SqlCommand sqlCommand = new SqlCommand(text, _sqlConnection, _sqlTransaction) { CommandType = commandType })
            {
                sqlCommand.Parameters.AddRange(parameters.Select(item => new SqlParameter(item.Name, item.SqlDbType) { Value = item.Value }).ToArray());

                action(sqlCommand);
            }
        }

        public void Dispose()
        {
            if (_sqlTransaction != null)
            {
                try
                {
                    _sqlTransaction.Dispose();

                }
                finally
                {
                    _sqlTransaction = null;
                }
            }

            if (_sqlConnection != null)
            {
                try
                {
                    _sqlConnection.Dispose();
                }
                finally
                {
                    _sqlConnection = null;

                }
            }
        }
    }
}