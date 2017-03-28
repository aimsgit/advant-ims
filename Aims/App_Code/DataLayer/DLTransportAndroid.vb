Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLTransportAndroid
    Shared Function Gps_Data(ByVal t As TransportAndroid) As Integer

        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim param() As SqlParameter = New SqlParameter(6) {}
        param(0) = New SqlParameter("@Route", SqlDbType.VarChar, 100)
        param(0).Value = t.Route
        param(1) = New SqlParameter("@Latitude", SqlDbType.VarChar, 100)
        param(1).Value = t.Latitude
        param(2) = New SqlParameter("@Longitude", SqlDbType.VarChar, 100)
        param(2).Value = t.Longitude
        param(3) = New SqlParameter("@Date", SqlDbType.DateTime)
        param(3).Value = t.gpsDate
        param(4) = New SqlParameter("@Time", SqlDbType.DateTime)
        param(4).Value = t.Time
        param(5) = New SqlParameter("@IMEINO", SqlDbType.VarChar, 100)
        param(5).Value = t.IMEINO
        param(6) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 100)
        param(6).Value = t.Branchcode

        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertGpsData", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function


    Shared Function Student_Data(ByVal s As StudentAndroid) As Integer

        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim param() As SqlParameter = New SqlParameter(10) {}
        param(0) = New SqlParameter("@BatchID", SqlDbType.VarChar, 100)
        param(0).Value = s.BatchID
        param(1) = New SqlParameter("@StudentID", SqlDbType.VarChar, 100)
        param(1).Value = s.StudentID
        param(2) = New SqlParameter("@Name", SqlDbType.VarChar, 100)
        param(2).Value = s.Name
        param(3) = New SqlParameter("@Time", SqlDbType.DateTime)
        param(3).Value = s.Time
        param(4) = New SqlParameter("@IMEINO", SqlDbType.VarChar, 100)
        param(4).Value = s.IMEINO
        param(5) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 100)
        param(5).Value = s.Branchcode
        param(6) = New SqlParameter("@Route", SqlDbType.VarChar, 100)
        param(6).Value = s.Route
        param(7) = New SqlParameter("@Status", SqlDbType.VarChar, 100)
        param(7).Value = s.Status
        param(8) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 100)
        param(8).Value = s.StudentCode
        param(9) = New SqlParameter("@AtTime", SqlDbType.VarChar, 100)
        param(9).Value = s.AtTime
        param(10) = New SqlParameter("@Flag", SqlDbType.VarChar, 100)
        param(10).Value = s.Flag
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertstuData", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function

    Shared Function SendSMS(ByVal s As StudentAndroid) As Integer

        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim param() As SqlParameter = New SqlParameter(7) {}
        param(0) = New SqlParameter("@StudentID", SqlDbType.VarChar, 100)
        param(0).Value = s.StudentID
        param(1) = New SqlParameter("@Name", SqlDbType.VarChar, 100)
        param(1).Value = s.Name
        param(2) = New SqlParameter("@Time", SqlDbType.DateTime)
        param(2).Value = s.Time
        param(3) = New SqlParameter("@IMEINO", SqlDbType.VarChar, 100)
        param(3).Value = s.IMEINO
        param(4) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 100)
        param(4).Value = s.Branchcode
        param(5) = New SqlParameter("@Route", SqlDbType.VarChar, 100)
        param(5).Value = s.Route
        param(6) = New SqlParameter("@Status", SqlDbType.VarChar, 100)
        param(6).Value = s.Status
        param(7) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 100)
        param(7).Value = s.StudentCode
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveSMStoBizcom", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function



    Shared Function GetRouteName() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim str As String = HttpContext.Current.Session("StudentCode")
        If (str Is Nothing) Then
            str = ""
        End If
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@User", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("LoginType")
        arParms(2) = New SqlParameter("@Student", SqlDbType.VarChar, 50)
        arParms(2).Value = str
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlRouteMobile", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function GetStudent(ByVal RouteIDAuto As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Try
            Dim str As String = HttpContext.Current.Session("StudentCode")
            If (str Is Nothing) Then
                str = ""
            End If
            Dim Parms() As SqlParameter = New SqlParameter(3) {}
            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@User", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("LoginType")
            Parms(2) = New SqlParameter("@Student", SqlDbType.VarChar, 50)
            Parms(2).Value = str
            Parms(3) = New SqlParameter("@Route", SqlDbType.VarChar, 30)
            Parms(3).Value = RouteIDAuto

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlStudentMobile", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetStudentTransport(ByVal Route As String, ByVal Student As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}
            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Route", SqlDbType.VarChar, 50)
            Parms(1).Value = Route
            Parms(2) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
            Parms(2).Value = Student
            Parms(3) = New SqlParameter("@SDate", SqlDbType.Date)
            Parms(3).Value = FromDate
            Parms(4) = New SqlParameter("@EDate", SqlDbType.Date)
            Parms(4).Value = ToDate

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_Rptstudenttransport", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
