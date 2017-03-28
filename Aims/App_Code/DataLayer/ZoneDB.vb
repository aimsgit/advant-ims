Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class ZoneDB
    Public Shared Function FillHo(ByVal ID As Int64) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
     
        Dim arParms As SqlParameter = New SqlParameter("@ID", SqlDbType.Int)
        arParms.Value = ID
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFullHO", arParms)

        Return ds
    End Function
    Shared Function Insert(ByVal id As Int64, ByVal name As String) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim i As Int16
        arParms(0) = New SqlParameter("@HOID", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@ZoneName", SqlDbType.VarChar, 50)
        arParms(1).Value = name

        i = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertZoneMaster", arParms)
        Return i
    End Function
    Shared Function GetZoneDetails(ByVal id As Int64) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms As SqlParameter = New SqlParameter("@ID", SqlDbType.Int)
        arParms.Value = id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetZoneDetails", arParms)

        Return ds
    End Function
    Shared Function Update(ByVal id As Int64, ByVal name As String) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim i As Int16
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@name", SqlDbType.VarChar, 50)
        arParms(1).Value = name

        i = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateZoneMaster", arParms)
        Return i
    End Function
    Shared Function Delete(ByVal id As Int64) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms As SqlParameter = New SqlParameter()
        Dim i As Int16
        arParms = New SqlParameter("@id", SqlDbType.Int)
        arParms.Value = id

        i = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_deleteZoneMaster", arParms)
        Return i
    End Function
End Class

