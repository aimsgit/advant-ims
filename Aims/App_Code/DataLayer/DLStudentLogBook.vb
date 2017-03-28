Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLStudentLogBook
    'Code written By : Niraj on 14-jun-2013
    Shared Function GetLogType() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLLogType", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetLecturercombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LecturerCombo3", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDepartmentCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "DepartmentDetailsddl", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetEmployeeCombo(ByVal Dept As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@DeptID", SqlDbType.Int)
        param(2).Value = Dept

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "EmployeeDetailsddl", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetFacultyCombo(ByVal Dept As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@DeptID", SqlDbType.Int)
        param(2).Value = Dept

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "EmployeeDetailsddl", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpLogType() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "LogTYpeDetailsddl", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStudentNameCombo(ByVal Batch As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = Batch

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectStudent", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBatchCombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_LogBookBatchCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function Insert(ByVal El As ELStudentLogBook) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(0).Value = El.BatchID

        arParms(1) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(1).Value = El.STID

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = El.EmpID

        If El.LogDate = "01-01-1900" Then
            arParms(3) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(3).Value = El.LogDate
        End If

        arParms(4) = New SqlParameter("@LogType", SqlDbType.Int)
        arParms(4).Value = El.LogType

        arParms(5) = New SqlParameter("@Feedback", SqlDbType.NVarChar, 1000)
        arParms(5).Value = El.Feedback

        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertStudentLog", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Shared Function InsertEmployeeLog(ByVal El As ELEmployeeLogBook) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = El.DeptID


        arParms(1) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(1).Value = El.EmpID


        'arParms(2) = New SqlParameter("@FacultyID", SqlDbType.Int)
        'arParms(2).Value = El.FacultyID


        If El.LogDate = "01-01-1900" Then
            arParms(2) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(2).Value = El.LogDate
        End If

        arParms(3) = New SqlParameter("@LogType", SqlDbType.Int)
        arParms(3).Value = El.LogType

        arParms(4) = New SqlParameter("@Feedback", SqlDbType.NVarChar, 1000)
        arParms(4).Value = El.Feedback

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertEmployeeLog", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function UpdateEmployeeLog(ByVal El As ELEmployeeLogBook) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(8) {}

        arParms(0) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(0).Value = El.DeptID

        arParms(1) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(1).Value = El.EmpID


        'arParms(2) = New SqlParameter("FacultyID", SqlDbType.Int)
        'arParms(2).Value = El.FacultyID

        If El.LogDate = "01-01-1900" Then
            arParms(2) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(2).Value = DBNull.Value
        Else
            arParms(2) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(2).Value = El.LogDate
        End If
        arParms(3) = New SqlParameter("@LogType", SqlDbType.Int)
        arParms(3).Value = El.LogType

        arParms(4) = New SqlParameter("@Feedback", SqlDbType.NVarChar, 1000)
        arParms(4).Value = El.Feedback

        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(8).Value = El.ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateEmployee_Log", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal El As ELStudentLogBook) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(0).Value = El.BatchID

        arParms(1) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(1).Value = El.STID

        arParms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(2).Value = El.EmpID

        If El.LogDate = "01-01-1900" Then
            arParms(3) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(3).Value = DBNull.Value
        Else
            arParms(3) = New SqlParameter("@Date", SqlDbType.Date)
            arParms(3).Value = El.LogDate
        End If
        arParms(4) = New SqlParameter("@LogType", SqlDbType.Int)
        arParms(4).Value = El.LogType

        arParms(5) = New SqlParameter("@Feedback", SqlDbType.NVarChar, 1000)
        arParms(5).Value = El.Feedback

        arParms(6) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("BranchCode")

        arParms(9) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(9).Value = El.ID
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateStudent_Log", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function DisplayEmployeeGridValue(ByVal El As ELEmployeeLogBook) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID

        arParms(3) = New SqlParameter("@DeptID", SqlDbType.Int)
        arParms(3).Value = El.DeptID


        arParms(4) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(4).Value = El.EmpID

        'arParms(5) = New SqlParameter("@FacultyID", SqlDbType.Int)
        'arParms(5).Value = El.FacultyID

        arParms(5) = New SqlParameter("@LogType", SqlDbType.Int)
        arParms(5).Value = El.LogType

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetEmployeeLogBook", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DisplayGridValue(ByVal El As ELStudentLogBook) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = El.ID

        arParms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(3).Value = El.BatchID

        arParms(4) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(4).Value = El.STID

        arParms(5) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(5).Value = El.EmpID

        arParms(6) = New SqlParameter("@LogType", SqlDbType.Int)
        arParms(6).Value = El.LogType

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentLogBook", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function ChangeFlag(ByVal EL As ELStudentLogBook) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteStudentLog", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlagEmpLog(ByVal EL As ELEmployeeLogBook) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteEmployeeLog", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function GetStudentNameComboAll(ByVal Batch As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = Batch

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentDDLSelect", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetLogTypeAll() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DDLLogTypeAll", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetStudentLog(ByVal BatchID As Integer, ByVal StdID As Integer, ByVal LogID As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = BatchID

        arParms(3) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(3).Value = StdID

        arParms(4) = New SqlParameter("@LogID", SqlDbType.Int)
        arParms(4).Value = LogID

        arParms(5) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(5).Value = FromDate

        arParms(6) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(6).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentLogBook", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function RptGetStudentParentLog() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, HttpContext.Current.Session("BranchCode").length)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BatchID")

        arParms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, HttpContext.Current.Session("StudentCode").length)
        arParms(2).Value = HttpContext.Current.Session("StudentCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDtlsForParent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CntData(ByVal Dept As Integer, ByVal EmpName As Integer, ByVal Logtype As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Dept", SqlDbType.Int)
        Parms(1).Value = Dept

        Parms(2) = New SqlParameter("@EmpName", SqlDbType.Int)
        Parms(2).Value = EmpName

        Parms(3) = New SqlParameter("@Logtype", SqlDbType.Int)
        Parms(3).Value = Logtype

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CntEmpLog]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function CntData1(ByVal Dept As Integer, ByVal EmpName As Integer, ByVal Logtype As Integer) As Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Dept", SqlDbType.Int)
        Parms(1).Value = Dept

        Parms(2) = New SqlParameter("@EmpName", SqlDbType.Int)
        Parms(2).Value = EmpName

        Parms(3) = New SqlParameter("@Logtype", SqlDbType.Int)
        Parms(3).Value = Logtype

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_CountRecordsEmpLog]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function CntData2(ByVal Dept As Integer, ByVal EmpName As Integer, ByVal Logtype As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Dept", SqlDbType.Int)
        Parms(1).Value = Dept

        Parms(2) = New SqlParameter("@EmpName", SqlDbType.Int)
        Parms(2).Value = EmpName

        Parms(3) = New SqlParameter("@Logtype", SqlDbType.Int)
        Parms(3).Value = Logtype

        Dim ds As New DataSet
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_LockEmpLog]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UnLockData(ByVal Dept As Integer, ByVal EmpName As Integer, ByVal Logtype As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(3) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Dept", SqlDbType.Int)
        Parms(1).Value = Dept

        Parms(2) = New SqlParameter("@EmpName", SqlDbType.Int)
        Parms(2).Value = EmpName

        Parms(3) = New SqlParameter("@Logtype", SqlDbType.Int)
        Parms(3).Value = Logtype

        Dim ds As New DataSet
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UnLockEempLog]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetunlockData(ByVal role As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(1).Value = role

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetUnlockEmpLog]", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class