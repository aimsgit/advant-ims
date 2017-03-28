Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLBiometric

    Shared Function SyncBiometricData() As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dte As DateTime
        Dim para() As SqlParameter = New SqlParameter(0) {}
        para(0) = New SqlParameter("@DeviceNo", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        'para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        'para(0).Value = HttpContext.Current.Session("BranchCode")
        'para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'para(1).Value = HttpContext.Current.Session("Office")
        'para(2) = New SqlParameter("@DeviceID", SqlDbType.VarChar, 50)
        'para(2).Value = HttpContext.Current.Session("Office")
        'para(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        'para(3).Value = HttpContext.Current.Session("UserCode")
        'para(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        'para(4).Value = HttpContext.Current.Session("Empcode")
        Try
            'ds = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "proc_InsertUpdateEmpAttdfromBiometric", para)
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDatafromBiometric", para)
            dt = ds.Tables(0)
            For Each row As DataRow In dt.Rows
                con = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
                Dim data As New Integer
                Dim param() As SqlParameter = New SqlParameter(5) {}
                param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                param(0).Value = HttpContext.Current.Session("BranchCode")
                'para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                'para(1).Value = HttpContext.Current.Session("Office")
                param(1) = New SqlParameter("@DeviceID", SqlDbType.VarChar, 50)
                param(1).Value = row("SerialNumber")
                'para(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
                'para(3).Value = HttpContext.Current.Session("UserCode")
                'para(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
                'para(4).Value = HttpContext.Current.Session("Empcode")
                param(2) = New SqlParameter("@UserID", SqlDbType.VarChar, 50)
                param(2).Value = row("UserId")
                'dte = CDate((row("LogDate").ToString))
                param(3) = New SqlParameter("@LogDate", SqlDbType.Date)
                param(3).Value = row("LogDate")
                ' dte = Convert.ToDateTime((.ToString))
                param(4) = New SqlParameter("@minLogTime", SqlDbType.DateTime)
                param(4).Value = row("minLogDate")
                'If (row("maxLogTime").Equals("#1/1/1900#")) Then
                '    dte = "01-01-1900"
                'Else
                '    dte = Convert.ToDateTime((row("maxLogDate").ToString))
                'End If
                'dte = Convert.ToDateTime((row("maxLogTime").ToString))
                param(5) = New SqlParameter("@maxLogTime", SqlDbType.DateTime)
                param(5).Value = row("maxLogTime")
                Try
                    data = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "proc_InsertWebEmpAttdfromBiometric", param)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next row
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dt.Rows.Count
    End Function

    Shared Function SyncStdBiometricData() As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New Integer
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@SesBranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@DeviceID", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("UserCode")
        para(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        para(4).Value = HttpContext.Current.Session("Empcode")
        Try
            ds = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "proc_InsertUpdateSTDAttdfromBiometric", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    Shared Function WebBiometricData(ByVal UserID As String, ByVal LogDate As DateTime, ByVal minLogTime As DateTime, ByVal maxLogTime As DateTime, ByVal Branchcode As String, ByVal DeviceNo As String) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim data As New Integer
        Dim para() As SqlParameter = New SqlParameter(5) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = Branchcode
        'para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'para(1).Value = HttpContext.Current.Session("Office")
        para(1) = New SqlParameter("@DeviceID", SqlDbType.VarChar, 50)
        para(1).Value = DeviceNo
        'para(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        'para(3).Value = HttpContext.Current.Session("UserCode")
        'para(4) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        'para(4).Value = HttpContext.Current.Session("Empcode")
        para(2) = New SqlParameter("@UserID", SqlDbType.VarChar, 50)
        para(2).Value = UserID
        para(3) = New SqlParameter("@LogDate", SqlDbType.DateTime)
        para(3).Value = LogDate
        para(4) = New SqlParameter("@minLogTime", SqlDbType.DateTime)
        para(4).Value = minLogTime
        para(5) = New SqlParameter("@maxLogTime", SqlDbType.DateTime)
        para(5).Value = maxLogTime
        Try
            data = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "proc_InsertWebEmpAttdfromBiometric", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       

        Return 0
    End Function

End Class
