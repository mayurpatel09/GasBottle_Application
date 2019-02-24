using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace DeppleFunctionLib.DbConnecter
{
    public class DeppleDBConnecter
    {
        //public SqlConnection con;
        //public SqlDataAdapter da;
        public SqlCommand cmd;
        //public SqlDataReader dr;
        //public DataSet ds;
        //public DataTable dt;
        //public SqlTransaction trans;
        string connString = ConfigurationManager.ConnectionStrings["DBCON"].ToString();
        public DeppleDBConnecter()
        {
            //this.connect();
            this.cmd = new SqlCommand();
            //this.ds = new DataSet();
        }
        public void connect()
        {

        }
        public DataSet getDataSet(string sql, params SqlParameter[] parameters)
        {
            SqlTransaction trans = null;


            using (var con = new SqlConnection(connString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                trans = con.BeginTransaction();
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);

                DataSet dt = new DataSet();
                da.Fill(dt);
                trans.Commit();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return dt;
            }
            //trans = null;
            //try
            //{
            //    using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["bawahir"].ToString()))
            //    {
            //        if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            //        {
            //            this.con.Open();
            //        }
            //        cmd.Connection = this.con;
            //        trans = con.BeginTransaction();
            //        cmd.Transaction = trans;
            //        cmd.CommandType = CommandType.Text;
            //        cmd.CommandText = sql;

            //        da = new SqlDataAdapter(cmd);
            //        ds = new DataSet();
            //        da.Fill(ds);
            //        trans.Commit();

            //        if (cmd.Connection.State == ConnectionState.Open)
            //        {
            //            cmd.Connection.Close();
            //            SqlConnection.ClearPool(con);
            //        }
            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();
            //            SqlConnection.ClearPool(con);
            //        }
            //        return ds;
            //    }
            //}
            //catch
            //{

            //    ds = null;
            //    return ds;
            //}
            //finally
            //{
            //    //cmd.Cancel();

            //    if (cmd.Connection.State == ConnectionState.Open)
            //    {
            //        cmd.Connection.Close();
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
        }
        //delegate DataTable GetDataTabelDeleGate(string sqlquery);
        //public DataTable _DataGrid(string sqlQuery)
        //{
        //    GetDataTabelDeleGate sd = getDataTable;
        //    IAsyncResult asyncRes = sd.BeginInvoke(sqlQuery, null, null);
        //    DataTable res = sd.EndInvoke(asyncRes);
        //    return res;
        //}

        public DataTable getDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var con = new SqlConnection(connString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return dt;
            }

        }
        public DataTable getDataTableCmdText(string sql, params SqlParameter[] parameters)
        {
            using (var con = new SqlConnection(connString))
            using (var da = new SqlDataAdapter(sql, con))
            {
                da.SelectCommand.CommandType = CommandType.Text;
                if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return dt;
            }
        }
        public object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            SqlTransaction trans = null;

            using (var con = new SqlConnection(connString))
            using (cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                con.Open();
                trans = con.BeginTransaction();
                object str = cmd.ExecuteScalar();
                trans.Commit();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return str;
            }
            
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            SqlTransaction trans = null;
            using (var con = new SqlConnection(connString))
            using (cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                con.Open();
                trans = con.BeginTransaction();
                int val = cmd.ExecuteNonQuery();
                trans.Commit();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return val;
            }

        }
        public int ExecuteNonQueryText(string sql, params SqlParameter[] parameters)
        {
            SqlTransaction trans = null;
            using (var con = new SqlConnection(connString))
            using (cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                con.Open();
                trans = con.BeginTransaction();
                int val = cmd.ExecuteNonQuery();
                trans.Commit();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return val;
            }

        }
        //public SqlDataReader ExecuteReader(string sql)
        //{
        //    //  trans = null;
        //    //try
        //    //{
        //    //    using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["bawahir"].ToString()))
        //    //    {
        //    //        if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
        //    //        {
        //    //            this.con.Open();
        //    //        }
        //    //        cmd.Connection = this.con;
        //    //        //  trans = con.BeginTransaction();
        //    //        //cmd.Transaction = trans;
        //    //        cmd.CommandType = CommandType.Text;
        //    //        cmd.CommandText = sql;

        //    //        dr = cmd.ExecuteReader();
        //    //        // trans.Commit();
        //    //        if (cmd.Connection.State == ConnectionState.Open)
        //    //        {
        //    //            cmd.Connection.Close();
        //    //        }
        //    //        if (con.State == ConnectionState.Open)
        //    //        {
        //    //            con.Close();
        //    //        }

        //    //        return dr;
        //    //    }
        //    //}
        //    //catch
        //    //{
        //    //    //  trans.Rollback();
        //    //    return dr;
        //    //}
        //    //finally
        //    //{
        //    //    //cmd.Cancel();

        //    //    //if (cmd.Connection.State == ConnectionState.Open)
        //    //    //{
        //    //    //    cmd.Connection.Close();
        //    //    //}
        //    //    //if (con.State == ConnectionState.Open)
        //    //    //{
        //    //    //    con.Close();
        //    //    //}
        //    //}

        //}

        public int MAXID(string TabelName, string ColumnName)
        {
            SqlTransaction trans = null;
            using (var con = new SqlConnection(connString))
            using (var da = new SqlDataAdapter("Select MAX(" + ColumnName + ") from " + TabelName + " Order By " + ColumnName + " ASC", con))
            {
                trans = con.BeginTransaction();
                da.SelectCommand.CommandType = CommandType.Text;

                DataTable dt = new DataTable();
                da.Fill(dt);
                trans.Commit();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (dt.Rows[0][0].ToString() == "")
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                }
            }
        }
    }
}
