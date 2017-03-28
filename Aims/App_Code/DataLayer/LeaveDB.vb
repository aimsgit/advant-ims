Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class LeaveDB
    Shared Function GetLeave(ByVal Leave As Leave) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@LM_ID", SqlDbType.Int)
        Parms(0).Value = Leave.LmId
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLeaveDetails", Parms)
        Return ds.Tables(0)
    End Function
    Shared Function GetLeaveType() As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}
            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(0).Value = HttpContext.Current.Session("Office")
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
            arParms(2) = New SqlClient.SqlParameter("@LoginType", SqlDbType.VarChar, 50)
            arParms(2).Value = HttpContext.Current.Session("LoginType")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_LeaveTypeCombo", arParms)
        Catch e As Exception
            ds = New DataSet
        End Try
        Return ds
    End Function
    Shared Function Insert(ByVal l As Leave) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@E_ID", SqlDbType.Int)
        arParms(0).Value = l.EId
        arParms(1) = New SqlParameter("@LeaveType", SqlDbType.Int)
        arParms(1).Value = l.LeaveType
        arParms(2) = New SqlParameter("@BalanceLeave", SqlDbType.Float)
        arParms(2).Value = l.BalanceLeave
        arParms(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(3).Value = l.Remarks
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")
        arParms(7) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(7).Value = l.Year
        arParms(8) = New SqlParameter("@Dept_Id", SqlDbType.Int)
        arParms(8).Value = l.Dept_Id


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveLeaveDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function InsertAll(ByVal l As Leave) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        'arParms(0) = New SqlParameter("@E_ID", SqlDbType.Int)
        'arParms(0).Value = l.EId
        arParms(0) = New SqlParameter("@LeaveType", SqlDbType.Int)
        arParms(0).Value = l.LeaveType
        arParms(1) = New SqlParameter("@BalanceLeave", SqlDbType.Float)
        arParms(1).Value = l.BalanceLeave
        arParms(2) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        arParms(2).Value = l.Remarks
        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(3).Value = HttpContext.Current.Session("Office")
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")
        arParms(7) = New SqlParameter("@Dept_Id", SqlDbType.Int)
        arParms(7).Value = l.Dept_Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveAllLeaveDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function Update(ByVal leave As Leave) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@LM_ID", SqlDbType.Int)
        arParms(0).Value = leave.LmId
        arParms(1) = New SqlParameter("@E_ID", SqlDbType.Int)
        arParms(1).Value = leave.EId
        arParms(2) = New SqlParameter("@leavetype", SqlDbType.Int)
        arParms(2).Value = leave.LeaveType
        arParms(3) = New SqlParameter("@balanceleave", SqlDbType.Float)
        arParms(3).Value = leave.BalanceLeave
        arParms(4) = New SqlParameter("@remarks", SqlDbType.VarChar, 50)
        arParms(4).Value = leave.Remarks
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")
        arParms(7) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(7).Value = leave.Year
        arParms(8) = New SqlParameter("@Dept_Id", SqlDbType.Int)
        arParms(8).Value = leave.Dept_Id
        arParms(9) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("BranchCode")
        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLeaveDetails", arParms)
    

        Return rowsAffected
    End Function
    Shared Function GetReport(ByVal insid As Int64, ByVal brnId As Int64) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@institute", SqlDbType.Int)
        arParms(0).Value = insid

        arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
        arParms(1).Value = brnId
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Rpt_LeaveMaster", arParms)
        ' ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM rptleavmaster where Institute_ID=" & insid & " and Branch_ID=" & brnId)    
        Return ds.Tables(0)
    End Function
   
    Public Function Delete(ByVal leave As Leave) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@LM_ID", SqlDbType.Int)
        param(0).Value = leave.LmId
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteLeaveDetails", param)
        Return rowsaffected
    End Function

    Public Function GetDuplicateLeaveDtl(ByVal Leave As Leave) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@EmpId", SqlDbType.Int)
        para(1).Value = Leave.EId
        para(2) = New SqlParameter("@LeaveType", SqlDbType.Int)
        para(2).Value = Leave.LeaveType
        para(3) = New SqlParameter("@LM_ID", SqlDbType.Int)
        para(3).Value = Leave.LmId
        para(4) = New SqlParameter("@Year", SqlDbType.Int)
        para(4).Value = Leave.Year
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateLeaveDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptLeaveApplcation(ByVal Dept As Integer, ByVal Emp As Integer, ByVal LeaveType As Integer, ByVal LeaveStatus As String, ByVal FrmDate As Date, ByVal Todate As Date) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(6) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Dept", SqlDbType.Int)
        para(1).Value = Dept
        para(2) = New SqlParameter("@Emp", SqlDbType.Int)
        para(2).Value = Emp
        para(3) = New SqlParameter("@LeaveType", SqlDbType.Int)
        para(3).Value = LeaveType
        para(4) = New SqlParameter("@LeaveStatus", SqlDbType.VarChar, 10)
        para(4).Value = LeaveStatus
        para(5) = New SqlParameter("@FrmDate", SqlDbType.Date)
        para(5).Value = FrmDate
        para(6) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(6).Value = Todate


        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Rpt_LeaveApplication", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptLeaveApplcationDetailed(ByVal Dept As Integer, ByVal Emp As Integer, ByVal LeaveType As Integer, ByVal LeaveStatus As Integer, ByVal FrmDate As Date, ByVal Todate As Date) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(7) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Dept", SqlDbType.Int)
        para(1).Value = Dept

        para(2) = New SqlParameter("@EmpId", SqlDbType.Int)
        para(2).Value = Emp

        para(3) = New SqlParameter("@LeaveType", SqlDbType.Int)
        para(3).Value = LeaveType

        para(4) = New SqlParameter("@LeaveStatus", SqlDbType.Int)
        para(4).Value = LeaveStatus

        para(5) = New SqlParameter("@FromDate", SqlDbType.Date)
        para(5).Value = FrmDate

        para(6) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(6).Value = Todate

        para(7) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        para(7).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Rpt_GetLeaveApplicationDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptLeaveApplcationSummary(ByVal Dept As Integer, ByVal FrmDate As Date, ByVal Todate As Date, ByVal Emp As Integer) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Dept", SqlDbType.Int)
        para(1).Value = Dept

        para(2) = New SqlParameter("@FromDate", SqlDbType.Date)
        para(2).Value = FrmDate

        para(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(3).Value = Todate

        para(4) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        para(4).Value = HttpContext.Current.Session("Office")

        para(5) = New SqlParameter("@EmpId", SqlDbType.Int)
        para(5).Value = Emp


        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Rpt_GetLeaveApplicationSummary", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SearchLeave(ByVal Leave As Leave) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(4) {}
        Parms(0) = New SqlParameter("@EmpId", SqlDbType.Int)
        Parms(0).Value = Leave.EmpId
        Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("Office")
        Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
        Parms(2).Value = HttpContext.Current.Session("BranchCode")
        Parms(3) = New SqlParameter("@Dept_Id", SqlDbType.Int)
        Parms(3).Value = Leave.Dept_Id
        Parms(4) = New SqlParameter("@LeaveType", SqlDbType.Int)
        Parms(4).Value = Leave.LeaveType

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SearchLeaveDetails", Parms)
        Return ds.Tables(0)
    End Function

End Class


