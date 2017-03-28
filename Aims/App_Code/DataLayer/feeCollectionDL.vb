Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class feeCollectionDL

    Shared Function GetStudentFee(ByVal prefixText As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeeCollectionStdCodeAutoComplete", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCurrentAcademicYear() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCurrentFeeAcademicYear", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStudent(ByVal prefixText As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@prefixText", SqlDbType.VarChar, prefixText.Length)
        arParms(0).Value = prefixText
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StdCodeAutoComplete", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStudent1(ByVal stdId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(0).Value = stdId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StdCodeAutoCompletefee", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStudentDDL(ByVal Batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(0).Value = Batch
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectStudent", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStudentDDLALL(ByVal Batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(0).Value = Batch
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectStudentALL", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboB() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee2", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterCombo2(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee2", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboD1(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        If HttpContext.Current.Session("LoginType") = "Others" Then
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = HttpContext.Current.Session("BatchID")
        Else
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = Batch
        End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboAsse() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        'If HttpContext.Current.Session("LoginType") = "Others" Then
        '    param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        '    param(2).Value = HttpContext.Current.Session("BatchID")
        'Else
        '    param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        '    param(2).Value = Batch
        'End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee_ATT", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboDNew(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        If HttpContext.Current.Session("LoginType") = "Others" Then
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = HttpContext.Current.Session("BatchID")
        Else
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = batch
        End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_feeNew", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboMeritList(ByVal BatchID As String) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        If HttpContext.Current.Session("LoginType") = "Others" Then
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = HttpContext.Current.Session("BatchID")
        Else
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 500)
            param(2).Value = BatchID
        End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_MeritList", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboBatRptCard(ByVal BatchID As String) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        If HttpContext.Current.Session("LoginType") = "Others" Then
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = HttpContext.Current.Session("BatchID")
        Else
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 500)
            param(2).Value = BatchID
        End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_BatRptCard", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function SemesterCombo12(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee11", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterCombo121(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee111", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function BatchComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        'param(2) = New SqlParameter("@CourseId", SqlDbType.Int)
        'param(2).Value = CourseCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectBatch", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboBatchPlanner(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SemesterComboBatchPlanner", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function BankComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBankCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function BankComboD1() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBankCombo1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function PaymentMethodComboD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPaymentMethodCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function getGrd1(ByVal b As Integer, ByVal AYear As Integer, ByVal Category As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@batch", SqlDbType.Int)
        param(2).Value = b
        param(3) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(3).Value = AYear
        param(4) = New SqlParameter("@Category", SqlDbType.Int)
        param(4).Value = Category
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetFeeCollectionGrid", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function TotalFeePaid(ByVal STD_ID As Integer, ByVal Semester As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@STD_ID", SqlDbType.Int)
        param(0).Value = STD_ID
        param(1) = New SqlParameter("@Ayear", SqlDbType.Int) '
        param(1).Value = Semester
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetTotalFeePaid", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function getGrd2(ByVal El As FeeCollectionEl) As DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@StdId", SqlDbType.Int)
        param(2).Value = El.SID
        param(3) = New SqlParameter("@id", SqlDbType.Int)
        param(3).Value = El.Id
        'param(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        'param(2).Value = b
        param(4) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(4).Value = El.SemId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectFeeCollection", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function InsertRecord(ByVal a As FeeCollectionEl) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(15) {}
        param(0) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        param(0).Value = a.Remarks
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@AmountPaid", SqlDbType.Money)
        param(2).Value = a.Amountpaid
        param(3) = New SqlParameter("@Discount", SqlDbType.Money)
        param(3).Value = a.Discount
        param(4) = New SqlParameter("@TotalFee", SqlDbType.Money)
        param(4).Value = a.Totalfee
        param(5) = New SqlParameter("@Bank", SqlDbType.Int)
        param(5).Value = a.Bankid
        param(6) = New SqlParameter("@PaymentMethod", SqlDbType.Int)
        param(6).Value = a.Paymentmethodid
        param(7) = New SqlParameter("@Dd", SqlDbType.VarChar, 50)
        param(7).Value = a.Dd
        param(8) = New SqlParameter("@PaymentDate", SqlDbType.DateTime)
        param(8).Value = a.PaymentDate
        param(9) = New SqlParameter("@sid", SqlDbType.Int)
        param(9).Value = a.SID

        param(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(10).Value = HttpContext.Current.Session("EmpCode")

        param(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(11).Value = HttpContext.Current.Session("UserCode")

        param(12) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
        param(12).Value = a.Chequedate

        param(13) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(13).Value = HttpContext.Current.Session("Office")
        param(14) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(14).Value = a.SemId
        param(15) = New SqlParameter("@Fine", SqlDbType.Int)
        param(15).Value = a.Fine
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertFeeCollection", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function
    Public Function insert(ByVal a As FeeCollectionEl) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(14) {}
        param(0) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        param(0).Value = a.Remarks
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@AmountPaid", SqlDbType.Money)
        param(2).Value = a.Amountpaid
        param(3) = New SqlParameter("@Discount", SqlDbType.Money)
        param(3).Value = a.Discount
        param(4) = New SqlParameter("@FeeHead", SqlDbType.Money)
        param(4).Value = a.Fee
        param(5) = New SqlParameter("@Bank", SqlDbType.Int)
        param(5).Value = a.Bankid
        param(6) = New SqlParameter("@PaymentMethod", SqlDbType.Int)
        param(6).Value = a.Paymentmethodid
        param(7) = New SqlParameter("@Dd", SqlDbType.VarChar, 50)
        param(7).Value = a.Dd
        param(8) = New SqlParameter("@PaymentDate", SqlDbType.DateTime)
        param(8).Value = a.PaymentDate
        param(9) = New SqlParameter("@sid", SqlDbType.Int)
        param(9).Value = a.SID

        param(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(10).Value = HttpContext.Current.Session("EmpCode")

        param(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(11).Value = HttpContext.Current.Session("UserCode")

        param(12) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
        param(12).Value = a.Chequedate

        param(13) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(13).Value = HttpContext.Current.Session("Office")
        param(14) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(14).Value = a.SemId
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertAdhocFeeCollection", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function
    Shared Function GetSemesterCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SemesterComboAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function getFeecollection(ByVal stdid As Integer, ByVal sem As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Stdid", SqlDbType.Int)
        param(2).Value = stdid
        param(3) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(3).Value = sem
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetStdFeeTotalAmt", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function UpdateRecord(ByVal a As FeeCollectionEl) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(14) {}
        param(0) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        param(0).Value = a.Remarks
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@AmountPaid", SqlDbType.Money)
        param(2).Value = a.Amountpaid
        param(3) = New SqlParameter("@Discount", SqlDbType.Money)
        param(3).Value = a.Discount
        param(4) = New SqlParameter("@TotalFee", SqlDbType.Money)
        param(4).Value = a.Totalfee
        param(5) = New SqlParameter("@Bank", SqlDbType.Int)
        param(5).Value = a.Bankid
        param(6) = New SqlParameter("@PaymentMethod", SqlDbType.Int)
        param(6).Value = a.Paymentmethodid
        param(7) = New SqlParameter("@Dd", SqlDbType.VarChar, 50)
        param(7).Value = a.Dd
        param(8) = New SqlParameter("@PaymentDate", SqlDbType.DateTime)
        param(8).Value = a.PaymentDate
        param(9) = New SqlParameter("@sid", SqlDbType.Int)
        param(9).Value = a.SID
        param(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(10).Value = HttpContext.Current.Session("EmpCode")
        param(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(11).Value = HttpContext.Current.Session("UserCode")
        param(12) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
        param(12).Value = a.Chequedate
        param(13) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(13).Value = a.SemId
        param(14) = New SqlParameter("@id", SqlDbType.Int)
        param(14).Value = a.Id

        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateFeeDetails", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function
    Public Function Update(ByVal a As FeeCollectionEl) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(14) {}
        param(0) = New SqlParameter("@Remarks", SqlDbType.VarChar, 50)
        param(0).Value = a.Remarks
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@AmountPaid", SqlDbType.Money)
        param(2).Value = a.Amountpaid
        param(3) = New SqlParameter("@Discount", SqlDbType.Money)
        param(3).Value = a.Discount
        param(4) = New SqlParameter("@FeeHead", SqlDbType.Int)
        param(4).Value = a.Fee
        param(5) = New SqlParameter("@Bank", SqlDbType.Int)
        param(5).Value = a.Bankid
        param(6) = New SqlParameter("@PaymentMethod", SqlDbType.Int)
        param(6).Value = a.Paymentmethodid
        param(7) = New SqlParameter("@Dd", SqlDbType.VarChar, 50)
        param(7).Value = a.Dd
        param(8) = New SqlParameter("@PaymentDate", SqlDbType.DateTime)
        param(8).Value = a.PaymentDate
        param(9) = New SqlParameter("@sid", SqlDbType.Int)
        param(9).Value = a.SID
        param(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(10).Value = HttpContext.Current.Session("EmpCode")
        param(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(11).Value = HttpContext.Current.Session("UserCode")
        param(12) = New SqlParameter("@ChequeDate", SqlDbType.DateTime)
        param(12).Value = a.Chequedate
        param(13) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(13).Value = a.SemId
        param(14) = New SqlParameter("@id", SqlDbType.Int)
        param(14).Value = a.Id

        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateAdhocFeeDetails", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function
    Shared Function ChangeFlag(ByVal El As FeeCollectionEl) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = El.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_DeleteFeeDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Public Function FeeCollectionReport(ByVal Bat As String, ByVal Sem As String, ByVal Payment As Integer, ByVal StudentCode As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal CollectionType As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}
        'param(0) = New SqlParameter("@a_year", SqlDbType.Int)
        'param(0).Value = AT

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@batchid", SqlDbType.Int)
        param(1).Value = Bat

        param(2) = New SqlParameter("@semesterid", SqlDbType.Int)
        param(2).Value = Sem

        param(3) = New SqlParameter("@Payment", SqlDbType.Int)
        param(3).Value = Payment

        param(4) = New SqlParameter("@StudentCode", SqlDbType.Int)
        param(4).Value = StudentCode

        param(5) = New SqlParameter("@StartDate", SqlDbType.Date)
        param(5).Value = StartDate

        param(6) = New SqlParameter("@EndDate", SqlDbType.Date)
        param(6).Value = EndDate

        param(7) = New SqlParameter("@CollectionType", SqlDbType.Int)
        param(7).Value = CollectionType
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_FeeCollectionReport", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Public Function FeeCollectionStudentWiseReport(ByVal AYear As String, ByVal Bat As String, ByVal Sem As String, ByVal StudentCode As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@a_year", SqlDbType.Int)
        param(0).Value = AYear

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@batchid", SqlDbType.Int)
        param(2).Value = Bat

        param(3) = New SqlParameter("@semesterid", SqlDbType.Int)
        param(3).Value = Sem

        param(4) = New SqlParameter("@StudentCode", SqlDbType.Int)
        param(4).Value = StudentCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_FeeCollectionStudentWiseReport", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Shared Function GetBatchComboAll(ByVal A_Year As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BatchAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetOpenBatchComboAll(ByVal A_Year As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(2).Value = A_Year
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_OpenBatchAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetStudentDtlsForParent() As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDetailsForParent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStdSemester(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(0).Value = BatchId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdCurrentSemester", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function getAdhocFeeCollection(ByVal El As FeeCollectionEl) As DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@StdId", SqlDbType.Int)
        param(2).Value = El.SID
        param(3) = New SqlParameter("@id", SqlDbType.Int)
        param(3).Value = El.Id
        'param(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        'param(2).Value = b
        param(4) = New SqlParameter("@Ayear", SqlDbType.Int)
        param(4).Value = El.SemId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_GetAdhocFeeCollection", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function PostFeeCollection(ByVal ChkID As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "PostFeeCollection", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function PostCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPostApproval", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Function SemesterCombo122(ByVal BranchCode As String, ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = BranchCode
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee11", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetAcademicYr() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        'param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        'param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFeeAcademicYear", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function Semesterddl(ByVal BranchCode As String, ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = BranchCode
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[proc_getSelectSemester]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function PostAuthorizeCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPostAuthorization", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    'Code By Jina
    Public Function SemComboD(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        If HttpContext.Current.Session("LoginType") = "Others" Then
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = HttpContext.Current.Session("BatchID")
        Else
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = Batch
        End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSem_fee", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    'Code By Jina
    Public Function SemCombo1D(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        If HttpContext.Current.Session("LoginType") = "Others" Then
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = HttpContext.Current.Session("BatchID")
        Else
            param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
            param(2).Value = batch
        End If
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemfee", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Courseddl() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter() {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        'param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        'param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[GetCourseddl]", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function CourseRpt() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        'If Branchcode = "0" Then
        '    arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        '    arParms(0).Value = HttpContext.Current.Session("Branchcode")
        'Else
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")
        'End If

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "NewCourseRPT", arParms)
        Return ds.Tables(0)
    End Function

    Public Function BatchComboDDL(ByVal CourseCode As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Courseid", SqlDbType.Int)
        param(2).Value = CourseCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectBatchCourse", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function AdhocFeeCollectionReport(ByVal Payment As Integer, ByVal FeeHead As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}


        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")



        param(1) = New SqlParameter("@Payment", SqlDbType.Int)
        param(1).Value = Payment

        param(2) = New SqlParameter("@FeeHead", SqlDbType.Int)
        param(2).Value = FeeHead

        param(3) = New SqlParameter("@StartDate", SqlDbType.Date)
        param(3).Value = StartDate

        param(4) = New SqlParameter("@EndDate", SqlDbType.Date)
        param(4).Value = EndDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_AdhocFeeCollectionReport", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Public Function GetAcademicYrFD() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        'param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        'param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetFeeAcademicYearFD", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function CourseRptFD() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        'If Branchcode = "0" Then
        '    arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        '    arParms(0).Value = HttpContext.Current.Session("Branchcode")
        'Else
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Branchcode")
        'End If

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "NewCourseRPTFD", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SemesterFD() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SemesterComboAllFD", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getsemesterFeeSummary(ByVal batch As Integer, ByVal stdcode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batcheid", SqlDbType.Int)
            Parms(1).Value = batch

            Parms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar)
            Parms(2).Value = stdcode


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_semFeeSummary", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
