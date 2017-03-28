Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class LeaveApplicationDL
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

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_AttendanceEmpCode", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function DispGrid(ByVal id As Integer) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlClient.SqlParameter("@LR_ID", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlClient.SqlParameter("@Emp_ID", SqlDbType.VarChar, 50)
        arParms(3).Value = IIf(HttpContext.Current.Session("LoginType") = "Employee", HttpContext.Current.Session("EmpID"), HttpContext.Current.Session("StudentCode"))

        arParms(4) = New SqlClient.SqlParameter("@LoginType", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("LoginType")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLeaveApplication", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return Nothing
    End Function
    Shared Function DispGrid1(ByVal id As Integer, ByVal Empid As Integer) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlClient.SqlParameter("@LR_ID", SqlDbType.Int)
        arParms(2).Value = id

        arParms(3) = New SqlClient.SqlParameter("@Emp_ID", SqlDbType.VarChar, 50)
        arParms(3).Value = IIf(HttpContext.Current.Session("LoginType") = "Employee", Empid, HttpContext.Current.Session("StudentCode"))

        arParms(4) = New SqlClient.SqlParameter("@LoginType", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("LoginType")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLeaveApplication", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return Nothing
    End Function
    Shared Function balanceleave(ByVal leavetype As Integer, ByVal empid As Integer) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Leavetype", SqlDbType.Int)
        arParms(0).Value = leavetype

        arParms(1) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(1).Value = empid
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FillBalanceLeave", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function InsertRecord(ByVal EL As LeaveApplicationEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(0).Value = IIf(HttpContext.Current.Session("EmpID") = "", HttpContext.Current.Session("StudentCode"), EL.empid)

        arParms(1) = New SqlParameter("@LeaveFrom", SqlDbType.DateTime)
        arParms(1).Value = EL.Leavefrom

        arParms(2) = New SqlParameter("@LeaveTo", SqlDbType.DateTime)
        arParms(2).Value = EL.Leaveto

        arParms(3) = New SqlParameter("@LeaveTypes", SqlDbType.Int)
        arParms(3).Value = EL.leavetype

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(4).Value = EL.reason

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = IIf(HttpContext.Current.Session("EmpCode") = "", HttpContext.Current.Session("StudentCode"), EL.Emp_Code)

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@FeedBack", SqlDbType.VarChar, 250)
        arParms(8).Value = EL.FeedBack

        arParms(9) = New SqlParameter("@LoginType", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("LoginType")

        arParms(10) = New SqlParameter("@DaysApplied", SqlDbType.Float)
        arParms(10).Value = EL.nofdays

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveLeaveAppn", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function email(ByVal EL As LeaveApplicationEL) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(1).Value = IIf(HttpContext.Current.Session("EmpID") = "", HttpContext.Current.Session("StudentCode"), EL.empid)


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetApproverEmailID", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function CheckDuplicate(ByVal leaveApp As LeaveApplicationEL) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")

        arParms(3) = New SqlParameter("@LeaveTypes", SqlDbType.Int)
        arParms(3).Value = leaveApp.leavetype

        arParms(4) = New SqlParameter("@LeaveFrom", SqlDbType.DateTime)
        arParms(4).Value = leaveApp.Leavefrom

        arParms(5) = New SqlParameter("@LeaveTo", SqlDbType.DateTime)
        arParms(5).Value = leaveApp.Leaveto

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CheckDuplicate]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpcombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EmployeeComboAll", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpcomboSelect() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmployeeCombo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpcombo(ByVal Branchcode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = Branchcode
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_EmployeeCombo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetUserRole(ByVal UserId As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@RoleCode", SqlDbType.NVarChar)
            Parms(1).Value = IIf(UserId = "", 0, UserId)
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SP_GetUserRoleDetails", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetLeaveType() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_LeaveTypeComboAll", arParms)
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
    Public Function GetLeaveApplicationReport(ByVal EmpID As Integer, ByVal LeaveID As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = EmpID

        arParms(3) = New SqlParameter("@LeaveID", SqlDbType.Int)
        arParms(3).Value = LeaveID

        arParms(4) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(4).Value = FromDate

        arParms(5) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(5).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_LeaveApplication", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetLeave() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("Office")
        Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_LeaveTypeComboAll", Parms)
        Return ds.Tables(0)
    End Function
    Shared Function getHolidayCount(ByVal leaveApp As LeaveApplicationEL) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@LeaveFrom", SqlDbType.DateTime)
        arParms(1).Value = leaveApp.Leavefrom

        arParms(2) = New SqlParameter("@LeaveTo", SqlDbType.DateTime)
        arParms(2).Value = leaveApp.Leaveto

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetHolidayData]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function ChangeFlag(ByVal EL As LeaveApplicationEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        'Dim arParms As SqlParameter = New SqlParameter
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = EL.Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@DaysApplied", SqlDbType.Float)
        arParms(2).Value = EL.nofdays

        arParms(3) = New SqlParameter("@Leavetype", SqlDbType.Int)
        arParms(3).Value = EL.leavetype

        arParms(4) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(4).Value = EL.empid

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteLeaves", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ApprovalRequest(ByVal EL As LeaveApplicationEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        'Dim arParms As SqlParameter = New SqlParameter
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = EL.Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.Emp_Code

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.UserCode

        arParms(4) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(4).Value = EL.empid

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_CancelLeavesRequest", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function HRemail(ByVal EL As LeaveApplicationEL) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(1).Value = IIf(HttpContext.Current.Session("EmpID") = "", HttpContext.Current.Session("StudentCode"), EL.empid)


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getHREMployeeEmailIDforLA", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function InsertRecordforOtherEmployee(ByVal EL As LeaveApplicationEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.empid

        arParms(1) = New SqlParameter("@LeaveFrom", SqlDbType.DateTime)
        arParms(1).Value = EL.Leavefrom

        arParms(2) = New SqlParameter("@LeaveTo", SqlDbType.DateTime)
        arParms(2).Value = EL.Leaveto

        arParms(3) = New SqlParameter("@LeaveTypes", SqlDbType.Int)
        arParms(3).Value = EL.leavetype

        arParms(4) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(4).Value = EL.reason

        arParms(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("BranchCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.Emp_Code

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@FeedBack", SqlDbType.VarChar, 250)
        arParms(8).Value = EL.FeedBack

        arParms(9) = New SqlParameter("@LoginType", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("LoginType")

        arParms(10) = New SqlParameter("@DaysApplied", SqlDbType.Float)
        arParms(10).Value = EL.nofdays

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveLeaveAppn", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function CheckDuplicateforOtherEmployee(ByVal leaveApp As LeaveApplicationEL) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = leaveApp.Emp_Code

        arParms(3) = New SqlParameter("@LeaveTypes", SqlDbType.Int)
        arParms(3).Value = leaveApp.leavetype

        arParms(4) = New SqlParameter("@LeaveFrom", SqlDbType.DateTime)
        arParms(4).Value = leaveApp.Leavefrom

        arParms(5) = New SqlParameter("@LeaveTo", SqlDbType.DateTime)
        arParms(5).Value = leaveApp.Leaveto

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckDuplicate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CheckDuplicateforStudent(ByVal leaveApp As LeaveApplicationEL) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = leaveApp.Emp_Code

        arParms(3) = New SqlParameter("@LeaveTypes", SqlDbType.Int)
        arParms(3).Value = leaveApp.leavetype

        arParms(4) = New SqlParameter("@LeaveFrom", SqlDbType.DateTime)
        arParms(4).Value = leaveApp.Leavefrom

        arParms(5) = New SqlParameter("@LeaveTo", SqlDbType.DateTime)
        arParms(5).Value = leaveApp.Leaveto

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CheckDuplicateforStudent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function emailforCancel(ByVal EL As LeaveApplicationEL) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.empid


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetApproverEmailID", arParms)
        Return ds.Tables(0)
    End Function

    Public Function HRemailforCancel(ByVal EL As LeaveApplicationEL) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.empid


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getHREMployeeEmailIDforLA", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function delegatename(ByVal empid As Integer) As System.Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(0).Value = empid

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getDelegate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function DelegateMail(ByVal EL As LeaveApplicationEL) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.empid

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getdelegateEmail", arParms)
        Return ds.Tables(0)
    End Function
End Class
