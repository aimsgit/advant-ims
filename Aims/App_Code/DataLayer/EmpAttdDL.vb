Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Attendance

Public Class EmpAttdDL


    Shared Function GetEmpCode(ByVal prefixText As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@prefixText", SqlDbType.VarChar, 50)
        arParms(2).Value = prefixText
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Shared Function getEmpName() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_AttendanceEmpCode", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Shared Function EmpAttendanceduplicate(ByVal El As Employee) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("EmpID")

        arParms(2) = New SqlParameter("@Attendance_Date", SqlDbType.DateTime)
        arParms(2).Value = El.StartDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAttendanceDuplicate", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Public Function UpdateDel(ByVal El As Employee) As Integer
        Dim rowsaffected As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@AttID", SqlDbType.Int)
        arParms(0).Value = El.AttendanceID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteEmpAttendance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function EmpAttd(ByVal El As Employee) As Data.DataTable
        Dim ds As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(0).Value = El.Emp_Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAttendance", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function

    Shared Function getTimeIn(ByVal El As Employee) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As String = ""

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpID")

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar, 255)
        arParms(4).Value = El.Remarks


        Try
            Rowseffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "New_InsertAttendance", arParms)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return Rowseffected

    End Function
    Shared Function getTimeOut(ByVal El As Employee) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As String = ""

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpID")

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar, 255)
        arParms(4).Value = El.Remarks

        Try
            Rowseffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "New_UpdateEmpAttendance", arParms)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return Rowseffected

    End Function

    Shared Function getDetails(ByVal El As Employee) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@from_Date", SqlDbType.DateTime)
        arParms(2).Value = El.EndDate

        arParms(3) = New SqlParameter("@to_Date", SqlDbType.DateTime)
        arParms(3).Value = El.StartDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmpAttendance", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
End Class
