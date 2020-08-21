﻿using System;
using System.Collections;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
///MYSQLHelper 的摘要说明/MYSQLHelper's summary notes
/// </summary>
public abstract class MySqlHelper
{
    //数据库连接字符串/Database connection string
    public static string Conn = "Database='db_speechnote';Data Source='localhost';User Id='root';Password='123456';charset='utf8';pooling=true";

    // 用于缓存参数的HASH表/HASH table for caching parameters
    private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

    /// <summary>
    ///  给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
    ///  Given a connection to the database with a hypothetical parameter to execute a sql command (do not return the data set)
    /// </summary>
    /// <param name="connectionString">一个有效的连接字符串/A valid connection string</param>
    /// <param name="cmdType">命令类型(存储过程, 文本, 等等)/Command type (stored procedure, text, etc.)</param>
    /// <param name="cmdText">存储过程名称或者sql命令语句/Name of stored procedure or sql command statement</param>
    /// <param name="commandParameters">执行命令所用参数的集合/A collection of parameters used to execute the command</param>
    /// <returns>执行命令所影响的行数/The number of rows affected by the execution of the command</returns>
    public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
    {

        MySqlCommand cmd = new MySqlCommand();

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 用现有的数据库连接执行一个sql命令（不返回数据集）
    /// Use the existing database connection to execute a sql command (do not return the data set)
    /// </summary>
    /// <param name="connection">一个现有的数据库连接/An existing database connection</param>
    /// <param name="cmdType">命令类型(存储过程, 文本, 等等)/Command type (stored procedure, text, etc.)</param>
    /// <param name="cmdText">存储过程名称或者sql命令语句/Name of stored procedure or sql command statement</param>
    /// <param name="commandParameters">执行命令所用参数的集合/A collection of parameters used to execute the command</param>
    /// <returns>执行命令所影响的行数/The number of rows affected by the execution of the command</returns>
    public static int ExecuteNonQuery(MySqlConnection connection, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
    {

        MySqlCommand cmd = new MySqlCommand();

        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    ///使用现有的SQL事务执行一个sql命令（不返回数据集）
    ///Use the existing SQL transaction to execute a sql command (do not return the data set)
    /// </summary>
    /// <remarks>
    ///举例:
    ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="trans">一个现有的事务/An existing transaction</param>
    /// <param name="cmdType">命令类型(存储过程, 文本, 等等)/Command type (stored procedure, text, etc.)</param>
    /// <param name="cmdText">存储过程名称或者sql命令语句/Name of stored procedure or sql command statement</param>
    /// <param name="commandParameters">执行命令所用参数的集合/A collection of parameters used to execute the command</param>
    /// <returns>执行命令所影响的行数/The number of rows affected by the execution of the command</returns>
    public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
    {
        MySqlCommand cmd = new MySqlCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 用执行的数据库连接执行一个返回数据集的sql命令
    /// Execute a sql command that returns a dataset with an executing database connection
    /// </summary>
    /// <remarks>
    /// 举例:
    ///  MySqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connectionString">一个有效的连接字符串/A valid connection string</param>
    /// <param name="cmdType">命令类型(存储过程, 文本, 等等)/Command type (stored procedure, text, etc.)</param>
    /// <param name="cmdText">存储过程名称或者sql命令语句/Name of stored procedure or sql command statement</param>
    /// <param name="commandParameters">执行命令所用参数的集合/A collection of parameters used to execute the command</param>
    /// <returns>包含结果的读取器/Reader containing results</returns>
    public static MySqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
    {
        //创建一个MySqlCommand对象
        MySqlCommand cmd = new MySqlCommand();
        //创建一个MySqlConnection对象
        MySqlConnection conn = new MySqlConnection(connectionString);

        //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
        //因此commandBehaviour.CloseConnection 就不会执行
        try
        {
            //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
            //Call the PrepareCommand method to set parameters for the MySqlCommand object
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            //调用 MySqlCommand  的 ExecuteReader 方法
            //Call the ExecuteReader method of MySqlCommand
            MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //清除参数
            cmd.Parameters.Clear();
            return reader;
        }
        catch
        {
            //关闭连接，抛出异常
            //Close the connection and throw the exception
            conn.Close();
            throw;
        }
    }

    /// <summary>
    /// 返回DataSet
    /// Returns the DataSet
    /// </summary>
    /// <param name="connectionString">一个有效的连接字符串/A valid connection string</param>
    /// <param name="cmdType">命令类型(存储过程, 文本, 等等)/Command type (stored procedure, text, etc.)</param>
    /// <param name="cmdText">存储过程名称或者sql命令语句/Stored procedure name or sql command statement</param>
    /// <param name="commandParameters">执行命令所用参数的集合/A collection of parameters used to execute the command</param>
    /// <returns></returns>
    public static DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
    {
        //创建一个MySqlCommand对象
        MySqlCommand cmd = new MySqlCommand();
        //创建一个MySqlConnection对象
        MySqlConnection conn = new MySqlConnection(connectionString);

        //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，

        try
        {
            //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            //调用 MySqlCommand  的 ExecuteReader 方法
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();

            adapter.Fill(ds);
            //清除参数
            //Clear the parameters
            cmd.Parameters.Clear();
            conn.Close();
            return ds;
        }
        catch (Exception e)
        {
            throw e;
        }
    }



    /// <summary>
    /// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
    /// Executes a command with the specified database connection string and returns the first column of a data set
    /// </summary>
    /// <remarks>
    ///例如:
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
    /// </remarks>
    ///<param name="connectionString">一个有效的连接字符串/A valid connection string</param>
    /// <param name="cmdType">命令类型(存储过程, 文本, 等等)/Command type (stored procedures, text, etc.)</param>
    /// <param name="cmdText">存储过程名称或者sql命令语句/Stored procedure name or SQL command statement</param>
    /// <param name="commandParameters">执行命令所用参数的集合/A collection of parameters used to execute commands</param>
    /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
    public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
    {
        MySqlCommand cmd = new MySqlCommand();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
    /// Executes a command with the specified database connection and returns the first column of a data set
    /// </summary>
    /// <remarks>
    /// 例如:
    ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
    /// </remarks>
    /// <param name="connection">一个存在的数据库连接/An existing database connection</param>
    /// <param name="cmdType">命令类型(存储过程, 文本, 等等)/Command type (stored procedures, text, etc.)</param>
    /// <param name="cmdText">存储过程名称或者sql命令语句/Stored procedure name or SQL command statement</param>
    /// <param name="commandParameters">执行命令所用参数的集合/A collection of parameters used to execute commands</param>
    /// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
    public static object ExecuteScalar(MySqlConnection connection, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
    {

        MySqlCommand cmd = new MySqlCommand();

        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 将参数集合添加到缓存
    /// Add a parameter collection to the cache
    /// </summary>
    /// <param name="cacheKey">添加到缓存的变量/Variables added to the cache</param>
    /// <param name="commandParameters">一个将要添加到缓存的sql参数集合/A collection of SQL parameters that will be added to the cache</param>
    public static void CacheParameters(string cacheKey, params MySqlParameter[] commandParameters)
    {
        parmCache[cacheKey] = commandParameters;
    }

    /// <summary>
    /// 找回缓存参数集合
    /// Retrieve cache parameter sets
    /// </summary>
    /// <param name="cacheKey">用于找回参数的关键字/Keywords used to retrieve parameters</param>
    /// <returns>缓存的参数集合/Cache parameter collection</returns>
    public static MySqlParameter[] GetCachedParameters(string cacheKey)
    {
        MySqlParameter[] cachedParms = (MySqlParameter[])parmCache[cacheKey];

        if (cachedParms == null)
            return null;

        MySqlParameter[] clonedParms = new MySqlParameter[cachedParms.Length];

        for (int i = 0, j = cachedParms.Length; i < j; i++)
            clonedParms[i] = (MySqlParameter)((ICloneable)cachedParms[i]).Clone();

        return clonedParms;
    }

    /// <summary>
    /// 准备执行一个命令
    /// Ready to execute a command
    /// </summary>
    /// <param name="cmd">sql命令/Sql command</param>
    /// <param name="conn">OleDb连接/OleDb connection</param>
    /// <param name="trans">OleDb事务/OleDb transaction</param>
    /// <param name="cmdType">命令类型例如 存储过程或者文本/Command type, such as stored procedures or text</param>
    /// <param name="cmdText">命令文本,例如:Select * from Products/Command text</param>
    /// <param name="cmdParms">执行命令的参数</param>
    private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
    {

        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdText;

        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParms != null)
        {
            foreach (MySqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }

}