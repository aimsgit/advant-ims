Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class AccountHeadDB
    Shared Function GetAccountHead() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAccountHeadDetails1", para)
            Return dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Shared Function GetAccountHeadGroupWise(ByVal AccE As DayBookEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@AGOne", SqlDbType.Int)
        para(2).Value = AccE.AGOne

        para(3) = New SqlParameter("@AOT", SqlDbType.Int)
        para(3).Value = AccE.ATOne

        para(4) = New SqlParameter("@Code", SqlDbType.VarChar, 2)
        para(4).Value = AccE.Code

        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAccountHeadDetails", para)
            Return dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Shared Function GetAccountHeadFeeC(ByVal Id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Try
            If Id = 0 Then
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAccountHeadDetailsFeeC")
            Else
                Dim arParms As SqlParameter = New SqlParameter("@Account_Code", SqlDbType.Int, 10)
                arParms.Value = Id
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAccountHeadDetailsFeeCByID", arParms)
            End If
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Shared Function GetAccountSubGroup(ByVal Id As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms As SqlParameter = New SqlParameter("@Acct_Sub_Group_ID", SqlDbType.Int, 10)
        arParms.Value = Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAccountsubGroup", arParms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Shared Function GetAcctsubgroupByAcctgroupID(ByVal Id As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet = Nothing
        Dim arParms As SqlParameter = New SqlParameter("@ID", SqlDbType.Int, 10)
        arParms.Value = Id

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAcctsubgroupByAcctgroupID", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Shared Function Insert(ByVal AccE As AccountHead) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim Param() As SqlParameter = New SqlParameter(11) {}

        Param(0) = New SqlParameter("@AccHead", SqlDbType.NVarChar, AccE.AccHead.Length)
        Param(0).Value = AccE.AccHead

        Param(1) = New SqlParameter("@AGOnevalue", SqlDbType.Int)
        Param(1).Value = AccE.AGOnevalue

        Param(2) = New SqlParameter("@AcctOneValue", SqlDbType.Int)
        Param(2).Value = AccE.AcctOneValue

        Param(3) = New SqlParameter("@AGTwoValue", SqlDbType.Int)
        Param(3).Value = AccE.AGTwoValue

        Param(4) = New SqlParameter("@AcctTwoValue", SqlDbType.Int)
        Param(4).Value = AccE.AcctTwoValue

        Param(5) = New SqlParameter("@AOTValue", SqlDbType.Int)
        Param(5).Value = AccE.AOTValue

        Param(6) = New SqlParameter("@ATTValue", SqlDbType.Int)
        Param(6).Value = AccE.ATTValue

        Param(7) = New SqlParameter("@UserCod", SqlDbType.NVarChar, AccE.UserCod.Length)
        Param(7).Value = AccE.UserCod

        Param(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Param(8).Value = HttpContext.Current.Session("UserCode")


        Param(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Param(9).Value = HttpContext.Current.Session("EmpCode")

        Param(10) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Param(10).Value = HttpContext.Current.Session("BranchCode")

        Param(11) = New SqlParameter("@BudgetAmount", SqlDbType.Money)
        Param(11).Value = AccE.Budget_Amount





        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_SaveAccountHead", Param)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return Rowseffected
    End Function
    Shared Function Update(ByVal AccE As AccountHead) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        'Dim id As new Int16 = 0
        Dim ds As New DataSet

        Dim Param() As SqlParameter = New SqlParameter(12) {}

        Param(0) = New SqlParameter("@AccHead", SqlDbType.NVarChar, AccE.AccHead.Length)
        Param(0).Value = AccE.AccHead

        Param(1) = New SqlParameter("@AGOnevalue", SqlDbType.Int)
        Param(1).Value = AccE.AGOnevalue

        Param(2) = New SqlParameter("@AcctOneValue", SqlDbType.Int)
        Param(2).Value = AccE.AcctOneValue

        Param(3) = New SqlParameter("@AGTwoValue", SqlDbType.Int)
        Param(3).Value = AccE.AGTwoValue

        Param(4) = New SqlParameter("@AcctTwoValue", SqlDbType.Int)
        Param(4).Value = AccE.AcctTwoValue

        Param(5) = New SqlParameter("@AOTValue", SqlDbType.Int)
        Param(5).Value = AccE.AOTValue

        Param(6) = New SqlParameter("@ATTValue", SqlDbType.Int)
        Param(6).Value = AccE.ATTValue

        Param(7) = New SqlParameter("@UserCod", SqlDbType.NVarChar, AccE.UserCod.Length)
        Param(7).Value = AccE.UserCod

        Param(8) = New SqlParameter("@AccheadID", SqlDbType.VarChar, 50)
        Param(8).Value = AccE.AccHeadID

        Param(9) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Param(9).Value = HttpContext.Current.Session("UserCode")


        Param(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Param(10).Value = HttpContext.Current.Session("EmpCode")

        Param(11) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Param(11).Value = HttpContext.Current.Session("BranchCode")

        Param(12) = New SqlParameter("@BudgeAmount", SqlDbType.Money)
        Param(12).Value = AccE.Budget_Amount




        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateAccountHead", Param)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return Rowseffected
    End Function
    Shared Function Delete(ByVal AccHeadID As Int64) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim id As Int16 = 0

        Dim arParms As SqlParameter = New SqlParameter("@AccheadID", SqlDbType.Int)
        arParms.Value = AccHeadID

        Try
            id = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteAccountHead", arParms)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function
    Shared Function Recover(ByVal AccHeadID As Int64) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim id As Int16 = 0

        Dim arParms As SqlParameter = New SqlParameter("@AccheadID", SqlDbType.Int)
        arParms.Value = AccHeadID

        Try
            id = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_RecoverAccountHead", arParms)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return id
    End Function
    Shared Function ReportCheck() As Int32
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim id As Int16 = 0
        Try
            id = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_AccountHeadDetailsCount")
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return id
    End Function
    Shared Function GetAccountHeadBYID(ByVal id As Long) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As Data.DataSet = Nothing

        Dim arParms As SqlParameter = New SqlParameter("@ID", SqlDbType.Int)
        arParms.Value = id

        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAccountHeadByID", arParms)
            Return dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Shared Function GetAccountHead1(ByVal AccE As AccountHead) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet
        Dim para() As SqlParameter = New SqlParameter(6) {}

        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = AccE.AccHeadID
        para(3) = New SqlParameter("@AccHead", SqlDbType.VarChar)
        para(3).Value = AccE.AccHead
        para(4) = New SqlParameter("@AGOnevalue", SqlDbType.Int)
        para(4).Value = AccE.AGOnevalue
        para(5) = New SqlParameter("@AGTwoValue", SqlDbType.Int)
        para(5).Value = AccE.AGTwoValue
        para(6) = New SqlParameter("@OrderBy", SqlDbType.VarChar, 2)
        para(6).Value = "N"

        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAccountHead", para)
            Return dt.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Shared Function RptAccountHead(ByVal id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet
        Dim para() As SqlParameter = New SqlParameter(6) {}
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("Office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = "0"
        para(3) = New SqlParameter("@AccHead", SqlDbType.VarChar)
        para(3).Value = "0"
        para(4) = New SqlParameter("@AGOnevalue", SqlDbType.Int)
        para(4).Value = "0"
        para(5) = New SqlParameter("@AGTwoValue", SqlDbType.Int)
        para(5).Value = "0"
        para(6) = New SqlParameter("@OrderBy", SqlDbType.VarChar, 2)
        para(6).Value = "Y"
        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetAccountHead", para)
            Return dt.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
