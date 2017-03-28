Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class LeaveTypesDB
    Shared Function GetLeavTypes(ByVal el As ELLeavTypes) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@TY_ID", SqlDbType.Int)
        arParms(0).Value = el.TY_ID
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLeaveTypeDetailsByLTypeID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal el As ELLeavTypes) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@LeaveType", SqlDbType.Char, el.Leave_Type.Length)
        arParms(1).Value = el.Leave_Type

        arParms(2) = New SqlParameter("@LeaveDescp", SqlDbType.Char, el.LeaveDescription.Length)
        arParms(2).Value = el.LeaveDescription

        arParms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("UserCode")

        arParms(4) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpCode")

        arParms(5) = New SqlParameter("@PaidStatus", SqlDbType.VarChar, 2)
        arParms(5).Value = el.Paid

        arParms(6) = New SqlParameter("@leavetypecode", SqlDbType.VarChar, el.Leave_TypeCode.Length)
        arParms(6).Value = el.Leave_TypeCode
        arParms(7) = New SqlParameter("@LeaveFor", SqlDbType.VarChar, 5)
        arParms(7).Value = el.LeaveFor
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveLeaveTypeDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetDuplicateLeaveType(ByVal el As ELLeavTypes) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        'para(2) = New SqlParameter("@leaveType", SqlDbType.Char, el.Leave_Type.Length)
        'para(2).Value = el.Leave_Type
        'para(3) = New SqlParameter("@leavedesc", SqlDbType.Char, el.LeaveDescription.Length)
        'para(3).Value = el.LeaveDescription
        para(2) = New SqlParameter("@leavetypecode", SqlDbType.VarChar, el.Leave_TypeCode.Length)
        para(2).Value = el.Leave_TypeCode
        para(3) = New SqlParameter("@id", SqlDbType.Int)
        para(3).Value = el.TY_ID
        para(4) = New SqlParameter("@LeaveFor", SqlDbType.VarChar, 5)
        para(4).Value = el.LeaveFor

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Proc_GetDuplicateLeaveType", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function Update(ByVal el As ELLeavTypes) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@LeaveType", SqlDbType.Char, el.Leave_Type.Length)
        arParms(1).Value = el.Leave_Type

        arParms(2) = New SqlParameter("@LeaveDescp", SqlDbType.Char, el.LeaveDescription.Length)
        arParms(2).Value = el.LeaveDescription

        arParms(3) = New SqlParameter("@TY_ID", SqlDbType.Int)
        arParms(3).Value = el.TY_ID

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@PaidStatus", SqlDbType.VarChar, 2)
        arParms(6).Value = el.Paid


        arParms(7) = New SqlParameter("@leavetypecode", SqlDbType.VarChar, el.Leave_TypeCode.Length)
        arParms(7).Value = el.Leave_TypeCode
        arParms(8) = New SqlParameter("@LeaveFor", SqlDbType.VarChar, 5)
        arParms(8).Value = el.LeaveFor


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLeaveTypeDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@TY_ID", SqlDbType.Int)
        arParms(1).Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteLeaveTypeDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    'Shared Function GetReport() As Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select* from LeaveTypes where Del_Flag=0")
    '    Return ds.Tables(0)
    'End Function
End Class
