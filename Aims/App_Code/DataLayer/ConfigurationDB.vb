Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Data

Public Class ConfigurationDB
    Public Shared Function GetConfig(ByVal cid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If cid = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GetConfiguration")
        Else
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GetConfiguration Where Config_ID=" & cid)
        End If
        Return ds
    End Function
    Public Shared Function GetStdNameConfig(ByVal Config_Name As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds, query As String
        query = "select top 1 Config_Value from Configuration where (BranchCode='" + HttpContext.Current.Session("BranchCode") + "' or BranchCode='000000000000') and Config_Name='" + Config_Name + "' order by BranchCode desc"
        Try
            ds = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, query)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetRandomTheme() As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Theme As String = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, "Proc_GetRandomTheme")
        Return Theme
    End Function
    Public Shared Function Update(ByVal C As EntConfiguration) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Date_Value", SqlDbType.DateTime)
        arParms(0).Value = C.Date_Value

        'arParms(1) = New SqlParameter("@enddate", SqlDbType.DateTime)
        'arParms(1).Value = C.EndDate

        arParms(1) = New SqlParameter("@config_id", SqlDbType.Int)
        arParms(1).Value = C.Config_ID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateConfig", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
End Class
