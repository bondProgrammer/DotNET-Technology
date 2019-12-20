using System;
using System.Data;
using System.Data.SqlClient;

namespace RServer
{
    /// <summary>
    /// The purpose of the <see cref="SqlData"/> class is to perform all action with sql database.
    /// </summary>
    // ReSharper disable UnusedMember.Local
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ClassNeverInstantiated.Global
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    // ReSharper disable UnusedAutoPropertyAccessor.Global
    public sealed class SqlData
    {
        private SqlConnection _mObjConnection;
        private SqlCommand _mObjCommand;
        private SqlDataAdapter _mObjDataAdapter;
        private SqlTransaction _mObjTransaction;

        /// <summary>
        /// Constructor
        /// </summary>
        public SqlData()
        {
            ConnectionString = "";
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="SqlData"/> is reclaimed by garbage collection.
        /// </summary>
        ~SqlData()
        {
            CloseConnection();
        }

        /// <summary>
        /// Parameterized constructor 
        /// </summary>
        /// <param name="strConnectionString">Connection String</param>
        public SqlData(string strConnectionString)
        {
            ConnectionString = strConnectionString;
            SetConnection();
        }

        #region " Private Member Methods "

        /// <summary>
        /// Method for setting connection.
        /// </summary>
        private void SetConnection()
        {
            if (_mObjConnection == null ||
                (_mObjConnection.State != ConnectionState.Open &&
                 String.Compare(_mObjConnection.ConnectionString, ConnectionString, true) != 0))
                _mObjConnection = new SqlConnection(ConnectionString);
        }

        #endregion

        /// <summary>
        /// ConnectionString
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Sql Connection
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                SetConnection();
                return _mObjConnection;
            }
        }

        /// <summary>
        /// Sql Command
        /// </summary>
        public SqlCommand Command
        {
            get { return _mObjCommand ?? (_mObjCommand = new SqlCommand { Connection = Connection }); }
        }

        /// <summary>
        /// Sql Adapter.
        /// </summary>
        public SqlDataAdapter DataAdapter
        {
            get { return _mObjDataAdapter ?? (_mObjDataAdapter = new SqlDataAdapter()); }
        }

        /// <summary>
        /// InTransaction
        /// </summary>
        public bool InTransaction { get; private set; }

        /// <summary>
        /// Method to start sql transaction
        /// </summary>
        public void StartTransaction()
        {
            if (_mObjTransaction != null) return;
            OpenConnection();
            _mObjTransaction = Command.Connection.BeginTransaction();
            Command.Transaction = _mObjTransaction;
            InTransaction = true;
        }

        /// <summary>
        /// Method to start commit transaction
        /// </summary>
        public void Commit()
        {
            if (!InTransaction) return;
            _mObjTransaction.Commit();
            InTransaction = false;
        }

        /// <summary>
        /// Method to roll back sql transaction
        /// </summary>
        public void Rollback()
        {
            if (!InTransaction) return;
            _mObjTransaction.Rollback();
            InTransaction = false;
        }

        /// <summary>
        /// Method to fill data using data adapter.
        /// </summary>
        /// <param name="ds">dataset</param>
        public void Fill(ref DataSet ds)
        {
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds);
        }

        /// <summary>
        /// Method to fill data using data adapter.
        /// </summary>
        /// <param name="ds">dataset</param>
        /// <param name="srcTable">data table name</param>
        public void Fill(ref DataSet ds, string srcTable)
        {
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(ds, srcTable);
        }

        /// <summary>
        /// Method to fill data using data adapter.
        /// </summary>
        /// <param name="dt">DataTable</param>
        public void Fill(ref DataTable dt)
        {
            DataAdapter.SelectCommand = Command;
            DataAdapter.Fill(dt);
        }

        /// <summary>
        /// Method to open a connection if it's new or closed.
        /// </summary>
        public void OpenConnection()
        {
            if (_mObjConnection != null && _mObjConnection.State == ConnectionState.Closed)
                _mObjConnection.Open();
        }

        /// <summary>
        /// Method to close a connection if not closed.
        /// </summary>
        public void CloseConnection()
        {
            if (_mObjConnection != null && _mObjConnection.State != ConnectionState.Closed)
                _mObjConnection.Close();
        }

        /// <summary>
        /// Method to get data of query provided.
        /// </summary>
        /// <param name="pSQL">SQL Query</param>
        /// <param name="pTable">table name</param>
        /// <param name="dsDataset">dataset</param>
        private void GetData(string pSQL, string pTable, ref DataSet dsDataset)
        {
            Command.CommandType = CommandType.Text;
            Command.CommandText = pSQL;
            Fill(ref dsDataset, pTable);
        }

        #region " IDisposable Support "

        // To detect redundant calls
        private bool _disposedValue;

        /// <summary>
        /// IDisposable
        /// </summary>
        /// <param name="disposing">disposing flag</param>
        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if ((_mObjTransaction != null))
                    {
                        _mObjTransaction.Dispose();
                        _mObjTransaction = null;
                    }
                    CloseConnection();
                    if ((_mObjConnection != null))
                    {
                        _mObjConnection.Dispose();
                        _mObjConnection = null;
                    }
                    if ((_mObjCommand != null))
                    {
                        _mObjCommand.Dispose();
                        _mObjCommand = null;
                    }
                    if ((_mObjDataAdapter != null))
                    {
                        _mObjDataAdapter.Dispose();
                        _mObjDataAdapter = null;
                    }
                }
            }
            _disposedValue = true;
        }

        #endregion
    }
    // ReSharper restore UnusedMember.Local
    // ReSharper restore UnusedMember.Global
    // ReSharper restore MemberCanBePrivate.Global
    // ReSharper restore ClassNeverInstantiated.Global
    // ReSharper restore UnusedAutoPropertyAccessor.Local
    // ReSharper restore UnusedAutoPropertyAccessor.Global
}