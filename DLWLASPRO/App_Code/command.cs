using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using DLWLASPRO.App_Code;
//using Microsoft.ApplicationBlocks.Data;//For SQLHelper
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;

/// <summary>
/// Summary description for command
/// </summary>
public class command
{
    
	public command()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataTable ExecuteQuery(string Query)
    {      
        DataTable dt = new DataTable();
        SqlConnection sqlcon = dbConnect.getConnection();
        try
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(Query, sqlcon);
            sqlda.Fill(dt);
        }
        catch (Exception ee)
        {
            //ErrorLogs .logerrors(ee,HttpContext.Current.Request.Url .ToString ());
        }
        return dt;
    }
    public static DataTable ExecuteQueryWithConnectionString(string Query, string connectionstring)
    {
        DataTable dt = new DataTable();
        SqlConnection sqlcon = new SqlConnection(connectionstring);
        //try
        //{
        SqlDataAdapter sqlda = new SqlDataAdapter(Query, sqlcon);
        sqlda.Fill(dt);
        //}
        //catch (Exception ee)
        //{
        //    //ErrorLogs .logerrors(ee,HttpContext.Current.Request.Url .ToString ());
        //}
        return dt;
    }
    public static void executeNonQuery(string sql)
    {
        SqlConnection sqlcon = dbConnect.getConnection();
        try{
                    
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
        }
        finally{
            sqlcon.Close();
        }
        
    }
    public static int  executeNonQuery1(string sql)
    {
        SqlConnection sqlcon = dbConnect.getConnection();
        try
        {

            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            sqlcon.Open();
           int i= cmd.ExecuteNonQuery();
           return i;
        }
        finally
        {
            sqlcon.Close();
        }

    }
    public static DataTable ExecuteSP(string Spname)
    {
        DataTable dt = new DataTable();
        SqlConnection sqlcon = dbConnect.getConnection();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandText = Spname;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.Connection = sqlcon;
        try
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcmd);
            sqlda.Fill(dt);
        }
        catch (Exception ee)
        {
           // ErrorLogs.logerrors(ee, HttpContext.Current.Request.Url.ToString());
        }
        return dt;

    }

    public static string ExecuteScalar(string query)
    {
        string output = string.Empty;
        SqlConnection sqlcon = dbConnect.getConnection();
        SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
        if (sqlcon.State == ConnectionState.Closed)
            sqlcon.Open();
        object o = sqlcmd.ExecuteScalar();
        sqlcon.Close();
        if (o != null)
            output = o.ToString();
        return output;
    }

    public static DataTable ExecuteStoredProcedure(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ee)
        {
            // ErrorLog.LogError(ee, HttpContext.Current.Request.Url.ToString());
        }
        return dt;
    }


    public static int getMaxId(string sql)
    {
        int maxPno = 0;
        int.TryParse(command.ExecuteScalar(sql).ToString(), out maxPno);
        return maxPno;
        
    }

}
