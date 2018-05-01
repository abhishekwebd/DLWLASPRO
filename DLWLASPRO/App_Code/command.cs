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
    //--------------------Backup and Restore----------------
    //public static void BackupDatabase(String databaseName, String userName,
    //        String password, String serverName, String destinationPath)
    //{
        
    //    Microsoft.SqlServer.Management.Smo.Backup sqlBackup = new Backup();

    //    sqlBackup.Action = BackupActionType.Database;
    //    sqlBackup.BackupSetDescription = "ArchiveDataBase:" +
    //                                     UtilityByNAwaziSH.getIndianStandardTime().ToShortDateString();
    //    sqlBackup.BackupSetName = "Archive";

    //    sqlBackup.Database = databaseName;

    //    //BackupDeviceItem deviceItem = new BackupDeviceItem(@"C:\BackupFile2.bak", DeviceType.File);
    //    BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
    //    ServerConnection connection = new ServerConnection(serverName, userName, password);
    //    Server sqlServer = new Server(connection);

    //    Database db = sqlServer.Databases[databaseName];

    //    sqlBackup.Initialize = true;
    //    sqlBackup.Checksum = true;
    //    sqlBackup.ContinueAfterError = true;

    //    sqlBackup.Devices.Add(deviceItem);
    //    sqlBackup.Incremental = false;

    //    sqlBackup.ExpirationDate = UtilityByNAwaziSH.getIndianStandardTime().AddDays(3);
    //    sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

    //    sqlBackup.FormatMedia = false;

    //    sqlBackup.SqlBackup(sqlServer);
    //}
    
    //public static void RestoreDatabase(String databaseName, String filePath,
    //   String serverName, String userName, String password,
    //   String dataFilePath, String logFilePath)
    //{
    //    Restore sqlRestore = new Restore();

    //    BackupDeviceItem deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
    //    sqlRestore.Devices.Add(deviceItem);
    //    sqlRestore.Database = databaseName;

    //    ServerConnection connection = new ServerConnection(serverName, userName, password);
    //    Server sqlServer = new Server(connection);

    //    Database db = sqlServer.Databases[databaseName];
    //    sqlRestore.Action = RestoreActionType.Database;
    //    String dataFileLocation = dataFilePath + databaseName + ".mdf";
    //    String logFileLocation = logFilePath + databaseName + "_Log.ldf";
    //    db = sqlServer.Databases[databaseName];
    //    RelocateFile rf = new RelocateFile(databaseName, dataFileLocation);

    //    sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName, dataFileLocation));
    //    sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName + "_log", logFileLocation));
    //    sqlRestore.ReplaceDatabase = true;
    //    //sqlRestore.Complete += new ServerMessageEventHandler(sqlRestore_Complete);
    //    //sqlRestore.PercentCompleteNotification = 10;
    //    //sqlRestore.PercentComplete +=
    //    //   new PercentCompleteEventHandler(sqlRestore_PercentComplete);

    //    sqlRestore.SqlRestore(sqlServer);
    //    db = sqlServer.Databases[databaseName];
    //    db.SetOnline();
    //    sqlServer.Refresh();
    //}

    //----------------------------------------------------


        //static void Main(string[] args)
        //{
        //    Server myServer = new Server(@"ARSHADALI-LAP\ARSHADALI");
        //    try
        //    {
        //        //Using windows authentication
        //        myServer.ConnectionContext.LoginSecure = true;
        //        myServer.ConnectionContext.Connect();
        //        Database myDatabase = myServer.Databases["AdventureWorks"];
        //       // BackupDatabaseFull(myServer, myDatabase);
        //        //BackupDatabaseDifferential(myServer, myDatabase);
        //        //BackupDatabaseLog(myServer, myDatabase);
        //        //BackupDatabaseFullWithCompression(myServer, myDatabase);
                
        //        RestoreDatabase(myServer, myDatabase);
        //        //RestoreDatabaseLog(myServer, myDatabase);
        //        //RestoreDatabaseWithDifferentNameAndLocation(myServer, myDatabase);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine(ex.InnerException.Message);
        //    }
        //    finally
        //    {
        //        if (myServer.ConnectionContext.IsOpen)
        //            myServer.ConnectionContext.Disconnect();
        //        Console.WriteLine("Press any key to terminate...");
        //        Console.ReadKey();
        //    }
        //}
        //public static void BackupDatabaseFull(Server myServer, Database myDatabase)
        //{            
        //    //myServer.ConnectionContext.LoginSecure = true;
        //    //myServer.ConnectionContext.Connect();
        //    Backup bkpDBFull = new Backup();
        //    /* Specify whether you want to back up database or files or log */
        //    bkpDBFull.Action = BackupActionType.Database;
        //    /* Specify the name of the database to back up */
        //    bkpDBFull.Database = myDatabase.Name;
        //    /* You can take backup on several media type (disk or tape), here I am using
        //     * File type and storing backup on the file system */
            
        //    bkpDBFull.Devices.AddDevice("/backup/AdventureWorksFull.bak", DeviceType.File);
        //    bkpDBFull.BackupSetName = "Adventureworks database Backup";
        //    bkpDBFull.BackupSetDescription = "Adventureworks database - Full Backup";
        //    /* You can specify the expiration date for your backup data
        //     * after that date backup data would not be relevant */
        //    bkpDBFull.ExpirationDate = DateTime.Today.AddDays(10);
        //    /* You can specify Initialize = false (default) to create a new 
        //     * backup set which will be appended as last backup set on the media. You can
        //     * specify Initialize = true to make the backup as first set on the mediuam and
        //     * to overwrite any other existing backup sets if the all the backup sets have
        //     * expired and specified backup set name matches with the name on the medium */
        //    bkpDBFull.Initialize = false;
        //    /* Wiring up events for progress monitoring */
        //    bkpDBFull.PercentComplete += CompletionStatusInPercent;
        //    bkpDBFull.Complete += Backup_Completed;
        //    /* SqlBackup method starts to take back up
        //     * You cab also use SqlBackupAsync method to perform backup 
        //     * operation asynchronously */
        //    bkpDBFull.SqlBackup(myServer);
        //}
        //public static void BackupDatabaseDifferential(Server myServer, Database myDatabase)
        //{
        //    Backup bkpDBDifferential = new Backup();
        //    /* Specify whether you want to back up database or files or log */
        //    bkpDBDifferential.Action = BackupActionType.Database;
        //    /* Specify the name of the database to back up */
        //    bkpDBDifferential.Database = myDatabase.Name;
        //    /* You can take backup on several media type (disk or tape), here I am using
        //     * File type and storing backup on the file system */
        //    bkpDBDifferential.Devices.AddDevice(@"~/AdventureWorksDifferential.bak", DeviceType.File);
        //    bkpDBDifferential.BackupSetName = "Adventureworks database Backup";
        //    bkpDBDifferential.BackupSetDescription = "Adventureworks database - Differential Backup";
        //    /* You can specify the expiration date for your backup data
        //     * after that date backup data would not be relevant */
        //    bkpDBDifferential.ExpirationDate = DateTime.Today.AddDays(10);
        //    /* You can specify Initialize = false (default) to create a new 
        //     * backup set which will be appended as last backup set on the media. You can
        //     * specify Initialize = true to make the backup as first set on the mediuam and
        //     * to overwrite any other existing backup sets if the all the backup sets have
        //     * expired and specified backup set name matches with the name on the medium */
        //    bkpDBDifferential.Initialize = false;
        //    /* You can specify Incremental = false (default) to perform full backup
        //     * or Incremental = true to perform differential backup since most recent
        //     * full backup */
        //    bkpDBDifferential.Incremental = true;
        //    /* Wiring up events for progress monitoring */
        //    bkpDBDifferential.PercentComplete += CompletionStatusInPercent;
        //    bkpDBDifferential.Complete += Backup_Completed;
        //    /* SqlBackup method starts to take back up
        //     * You cab also use SqlBackupAsync method to perform backup 
        //     * operation asynchronously */
        //    bkpDBDifferential.SqlBackup(myServer);
        //}
        //public static void BackupDatabaseLog(Server myServer, Database myDatabase)
        //{
        //    Backup bkpDBLog = new Backup();
        //    /* Specify whether you want to back up database or files or log */
        //    bkpDBLog.Action = BackupActionType.Log;
        //    /* Specify the name of the database to back up */
        //    bkpDBLog.Database = myDatabase.Name;
        //    /* You can take backup on several media type (disk or tape), here I am using
        //     * File type and storing backup on the file system */
        //    bkpDBLog.Devices.AddDevice(@"~/AdventureWorksLog.bak", DeviceType.File);
        //    bkpDBLog.BackupSetName = "Adventureworks database Backup";
        //    bkpDBLog.BackupSetDescription = "Adventureworks database - Log Backup";
        //    /* You can specify the expiration date for your backup data
        //     * after that date backup data would not be relevant */
        //    bkpDBLog.ExpirationDate = DateTime.Today.AddDays(10);
        //    /* You can specify Initialize = false (default) to create a new 
        //     * backup set which will be appended as last backup set on the media. You can
        //     * specify Initialize = true to make the backup as first set on the mediuam and
        //     * to overwrite any other existing backup sets if the all the backup sets have
        //     * expired and specified backup set name matches with the name on the medium */
        //    bkpDBLog.Initialize = false;
        //    /* Wiring up events for progress monitoring */
        //    bkpDBLog.PercentComplete += CompletionStatusInPercent;
        //    bkpDBLog.Complete += Backup_Completed;
        //    /* SqlBackup method starts to take back up
        //     * You cab also use SqlBackupAsync method to perform backup 
        //     * operation asynchronously */
        //    bkpDBLog.SqlBackup(myServer);
        //}
        //public static void BackupDatabaseFullWithCompression(Server myServer, Database myDatabase)
        //{
        //    Backup bkpDBFullWithCompression = new Backup();
        //    /* Specify whether you want to back up database or files or log */
        //    bkpDBFullWithCompression.Action = BackupActionType.Database;
        //    /* Specify the name of the database to back up */
        //    bkpDBFullWithCompression.Database = myDatabase.Name;
        //    /* You can use back up compression technique of SQL Server 2008,
        //     * specify CompressionOption property to On for compressed backup */
        //    //bkpDBFullWithCompression.CompressionOption = BackupCompressionOptions.On;
        //    bkpDBFullWithCompression.Devices.AddDevice("~/AdventureWorksFullWithCompression.bak", DeviceType.File);
        //    bkpDBFullWithCompression.BackupSetName = "Adventureworks database Backup - Compressed";
        //    bkpDBFullWithCompression.BackupSetDescription = "Adventureworks database - Full Backup with Compressin - only in SQL Server 2008";
        //    bkpDBFullWithCompression.SqlBackup(myServer);
        //}
        ////public static void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        ////{
        ////    //Console.Clear();
        ////    //Console.WriteLine("Percent completed: {0}%.", args.Percent);
        ////}
        //public static void Backup_Completed(object sender, ServerMessageEventArgs args)
        //{
        //    //Console.WriteLine("Hurray...Backup completed." );
        //    //Console.WriteLine(args.Error.Message);
        //}
        //public static void Restore_Completed(object sender, ServerMessageEventArgs args)
        //{
        //    //Console.WriteLine("Hurray...Restore completed.");
        //    //Console.WriteLine(args.Error.Message);
        //}
        //public static void RestoreDatabase(Server myServer, Database myDatabase)
        //{
        //    Restore restoreDB = new Restore();
        //    restoreDB.Database = myDatabase.Name;
        //    /* Specify whether you want to restore database or files or log etc */
        //    restoreDB.Action = RestoreActionType.Database;
        //    restoreDB.Devices.AddDevice("~/AdventureWorksFull.bak", DeviceType.File);
        //    /* You can specify ReplaceDatabase = false (default) to not create a new image
        //     * of the database, the specified database must exist on SQL Server instance.
        //     * If you can specify ReplaceDatabase = true to create new database image 
        //     * regardless of the existence of specified database with same name */
        //    restoreDB.ReplaceDatabase = true;

        //    /* If you have differential or log restore to be followed, you would need
        //     * to specify NoRecovery = true, this will ensure no recovery is done after the 
        //     * restore and subsequent restores are allowed. It means it will database
        //     * in the Restoring state. */
        //    restoreDB.NoRecovery = true;
        //    /* Wiring up events for progress monitoring */
        //    restoreDB.PercentComplete += CompletionStatusInPercent;
        //    restoreDB.Complete += Restore_Completed;
        //    /* SqlRestore method starts to restore database
        //     * You cab also use SqlRestoreAsync method to perform restore 
        //     * operation asynchronously */
        //    restoreDB.SqlRestore(myServer);
        //}
        //public static void RestoreDatabaseLog(Server myServer, Database myDatabase)
        //{
        //    Restore restoreDBLog = new Restore();
        //    restoreDBLog.Database = myDatabase.Name;
        //    restoreDBLog.Action = RestoreActionType.Log;
        //    restoreDBLog.Devices.AddDevice("~/AdventureWorksLog.bak", DeviceType.File);
        //    /* You can specify NoRecovery = false (default) so that transactions are
        //     * rolled forward and recovered. */
        //    restoreDBLog.NoRecovery = false;
        //    /* Wiring up events for progress monitoring */
        //    restoreDBLog.PercentComplete += CompletionStatusInPercent;
        //    restoreDBLog.Complete += Restore_Completed;
        //    /* SqlRestore method starts to restore database
        //     * You cab also use SqlRestoreAsync method to perform restore 
        //     * operation asynchronously */
        //    restoreDBLog.SqlRestore(myServer);
        //}
        //public static void RestoreDatabaseWithDifferentNameAndLocation(Server myServer, Database myDatabase)
        //{
        //    Restore restoreDB = new Restore();
        //    restoreDB.Database = myDatabase.Name + "New";
        //    /* Specify whether you want to restore database or files or log etc */
        //    restoreDB.Action = RestoreActionType.Database;
        //    restoreDB.Devices.AddDevice("~/AdventureWorksFull.bak", DeviceType.File);
        //    /* You can specify ReplaceDatabase = false (default) to not create a new image
        //     * of the database, the specified database must exist on SQL Server instance.
        //     * You can specify ReplaceDatabase = true to create new database image 
        //     * regardless of the existence of specified database with same name */
        //    restoreDB.ReplaceDatabase = true;
        //    /* If you have differential or log restore to be followed, you would need
        //     * to specify NoRecovery = true, this will ensure no recovery is done after the 
        //     * restore and subsequent restores are allowed. It means it will database
        //     * in the Restoring state. */
        //    restoreDB.NoRecovery = false;
        //    /* RelocateFiles collection allows you to specify the logical file names and 
        //     * physical file names (new locations) if you want to restore to a different location.*/
        //    restoreDB.RelocateFiles.Add(new RelocateFile("AdventureWorks_Data", @"~/AdventureWorksNew_Data.mdf"));
        //    restoreDB.RelocateFiles.Add(new RelocateFile("AdventureWorks_Log", @"~/AdventureWorksNew_Log.ldf"));
        //    /* Wiring up events for progress monitoring */
        //    restoreDB.PercentComplete += CompletionStatusInPercent;
        //    restoreDB.Complete += Restore_Completed;
        //    /* SqlRestore method starts to restore database
        //     * You cab also use SqlRestoreAsync method to perform restore 
        //     * operation asynchronously */
        //    restoreDB.SqlRestore(myServer);
        //}


    //public static void BulkCopySql(string SourceConnectionString, string tableName, HttpContext Context,string workSession)
    //{
    //    SqlConnection cnn = new SqlConnection(SourceConnectionString);
    //    SqlCommand cmd = new SqlCommand("UPDATE "+tableName+" SET BranchCode = " + LoginUtility.GetBranchCode("UserSysId", Context), cnn);
    //    SqlCommand cmd2;
    //    if (workSession == "")
    //    {
    //        cmd2 = new SqlCommand("SELECT * FROM " + tableName, cnn);
    //        executeNonQuery("DELETE FROM " + tableName + " WHERE BranchCode = " + LoginUtility.GetBranchCode("UserSysId", Context));
    //    }
    //    else
    //        cmd2 = new SqlCommand("SELECT *," + workSession + " AS Session FROM " + tableName, cnn);
        
    //    cmd.CommandTimeout = 50000;
    //    cmd2.CommandTimeout = 50000;
    //    cnn.Open();
    //    cmd.ExecuteNonQuery();
        
    //    SqlDataReader rdr = cmd2.ExecuteReader();
    //    SqlConnection dcnn = connection.CreateConneciton();
        
    //    dcnn.Open();
    //    SqlBulkCopy sbc = new SqlBulkCopy(dcnn);
    //    sbc.BulkCopyTimeout = 50000;
    //    sbc.DestinationTableName = tableName;

               
    //    sbc.WriteToServer(rdr);
    //    sbc.Close();
    //    rdr.Close();
    //    cnn.Close();
    //    dcnn.Close();
    //}
}
