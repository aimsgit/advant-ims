Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class PerfAppriasalDL
    Shared Function ViewParameters(ByVal app As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@app", SqlDbType.Int)
        arParms(2).Value = app
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPerfParameters", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function
    Shared Function GenerateParameters(ByVal TP As Integer, ByVal Sp As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}


        arParms(0) = New SqlParameter("@App", SqlDbType.Int)
        arParms(0).Value = TP


        arParms(1) = New SqlParameter("@No", SqlDbType.Int)
        arParms(1).Value = Sp

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertPerfParameters2", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ClearParameters(ByVal app As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@app", SqlDbType.Int)
        arParms(1).Value = app
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearPerfParameters", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateFeedBackParameters(ByVal FeedBackId As Integer, ByVal ParameterName As String, ByVal Max As Integer, ByVal Min As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@AppId", SqlDbType.Int)
        arParms(1).Value = FeedBackId

        If ParameterName = "" Then
            arParms(2) = New SqlParameter("@ParameterName", SqlDbType.NVarChar)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@ParameterName", SqlDbType.NVarChar)
            arParms(2).Value = ParameterName
        End If
        If Max = -1 Then
            arParms(3) = New SqlParameter("@Max", SqlDbType.Int)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@Max", SqlDbType.Int)
            arParms(3).Value = Max
        End If

        If Min = -1 Then
            arParms(4) = New SqlParameter("@Min", SqlDbType.Int)
            arParms(4).Value = DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Min", SqlDbType.Int)
            arParms(4).Value = Min
        End If

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpDatePerfParameters", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckFeedBackGenStatus(ByVal app As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@app", SqlDbType.Int)
        arParms(1).Value = app

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckPerfParaGenStatus", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt
    End Function
End Class
