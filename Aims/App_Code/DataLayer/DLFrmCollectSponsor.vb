Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLFrmCollectSponsor
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
    Shared Function GetStudentAutoComplete(ByVal prefixText As String) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_CSM_StdCodeAutoComplete", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStudentCategory(ByVal CategoryId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@CategoryId", SqlDbType.Int)
        arParms(0).Value = CategoryId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentCategorySponsor", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function sponsorddl() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        'arParms(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        'arParms(0).Value = Batch
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SposorDDL", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function InsertSponsor(ByVal EL As ELFrmCollectSponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(13) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Empcode")
        arParms(3) = New SqlParameter("@SpId", SqlDbType.Int)
        arParms(3).Value = EL.SpId
        arParms(4) = New SqlParameter("@amount", SqlDbType.Money)
        arParms(4).Value = EL.amount
        'arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        'arParms(5).Value = EL.id
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@mode", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.mode
        arParms(7) = New SqlParameter("@chqno", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.chqno
        arParms(8) = New SqlParameter("@chqdate", SqlDbType.Date)
        arParms(8).Value = EL.chqdate
        arParms(9) = New SqlParameter("@remarks", SqlDbType.VarChar, 200)
        arParms(9).Value = EL.remarks
        arParms(10) = New SqlParameter("@date", SqlDbType.Date)
        arParms(10).Value = EL.date1
        arParms(11) = New SqlParameter("@SId", SqlDbType.Int)
        arParms(11).Value = EL.SId
        arParms(12) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(12).Value = EL.Batch
        arParms(13) = New SqlParameter("@academic", SqlDbType.Int)
        arParms(13).Value = EL.academic
     

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NewInsertSponsor", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateSponsor(ByVal EL As ELFrmCollectSponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(15) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Empcode")
        arParms(3) = New SqlParameter("@SpId", SqlDbType.Int)
        arParms(3).Value = EL.SpId
        arParms(4) = New SqlParameter("@amount", SqlDbType.Money)
        arParms(4).Value = EL.amount
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@mode", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.mode
        arParms(7) = New SqlParameter("@chqno", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.chqno
        arParms(8) = New SqlParameter("@chqdate", SqlDbType.Date)
        arParms(8).Value = EL.chqdate
        arParms(9) = New SqlParameter("@remarks", SqlDbType.VarChar, 200)
        arParms(9).Value = EL.remarks
        arParms(10) = New SqlParameter("@date", SqlDbType.Date)
        arParms(10).Value = EL.date1
        arParms(11) = New SqlParameter("@SId", SqlDbType.Int)
        arParms(11).Value = EL.SId
        arParms(12) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(12).Value = EL.Batch
        arParms(13) = New SqlParameter("@academic", SqlDbType.Int)
        arParms(13).Value = EL.academic
        arParms(14) = New SqlParameter("@id", SqlDbType.Int)
        arParms(14).Value = EL.id
      
        arParms(15) = New SqlParameter("@Modified_By", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("Empcode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NewUpdateSponsor", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DisplayGridview(ByVal id As Integer,ByVal STDID As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        'Dim rowsAffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(3) {}
        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = id


        Params(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(1).Value = HttpContext.Current.Session("BranchCode")

        Params(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(2).Value = HttpContext.Current.Session("Office")

        Params(3) = New SqlParameter("@STDID", SqlDbType.Int)
        Params(3).Value = STDID

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "NewDisplaysponsor", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetPaymentMethodComboforsponsor", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function DeleteSponsor(ByVal EL As ELFrmCollectSponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_DeleteSponsorcoll", arParms)
        Return rowsAffected
    End Function
    Shared Function CheckDuplicate(ByVal EL As ELFrmCollectSponsor) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Stdid", SqlDbType.Int)
        arParms(1).Value = EL.SId
        arParms(2) = New SqlParameter("@batchid", SqlDbType.Int)
        arParms(2).Value = EL.Batch
        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = EL.id
        arParms(4) = New SqlParameter("@AID", SqlDbType.Int)
        arParms(4).Value = EL.academic
        arParms(5) = New SqlParameter("@SpId", SqlDbType.Int)
        arParms(5).Value = EL.SpId

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetNewDuplicateSponsor", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function GetFeePaidDetails(ByVal A_Year As Integer, ByVal BatchId As Integer, ByVal StdID As Integer, ByVal Category As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@batchid", SqlDbType.Int)
        param(1).Value = BatchId

        param(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(2).Value = A_Year

        param(3) = New SqlParameter("@Std_Id", SqlDbType.Int)
        param(3).Value = StdID

        param(4) = New SqlParameter("@category", SqlDbType.Int)
        param(4).Value = Category

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetFeePaidDetails", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function

    Shared Function GetFeePayableDetails(ByVal A_Year As Integer, ByVal BatchId As Integer, ByVal StdID As Integer, ByVal Category As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@batchid", SqlDbType.Int)
        param(1).Value = BatchId

        param(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(2).Value = A_Year

        param(3) = New SqlParameter("@Std_Id", SqlDbType.Int)
        param(3).Value = StdID

        param(4) = New SqlParameter("@category", SqlDbType.Int)
        param(4).Value = Category

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetFeePayableDetails", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Shared Function GetStudentByDDL(ByVal stdId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(0).Value = stdId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StdCodeAutoCompleteByDDL", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetYearByBatch(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(0).Value = BatchId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getAYearByBatch", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

    End Function

    Public Function InsertSponsorRef(ByVal EL As ELFrmCollectSponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(13) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Empcode")
        arParms(3) = New SqlParameter("@SpId", SqlDbType.Int)
        arParms(3).Value = EL.SpId
        arParms(4) = New SqlParameter("@amount", SqlDbType.Money)
        arParms(4).Value = EL.amount
        'arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        'arParms(5).Value = EL.id
        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")
        arParms(6) = New SqlParameter("@mode", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.mode
        arParms(7) = New SqlParameter("@chqno", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.chqno
        arParms(8) = New SqlParameter("@chqdate", SqlDbType.Date)
        arParms(8).Value = EL.chqdate
        arParms(9) = New SqlParameter("@SId", SqlDbType.Int)
        arParms(9).Value = EL.STDID
        arParms(10) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(10).Value = EL.Batch
        arParms(11) = New SqlParameter("@academic", SqlDbType.Int)
        arParms(11).Value = EL.academic
        arParms(12) = New SqlParameter("@Ref", SqlDbType.VarChar, 50)
        arParms(12).Value = EL.ref
        arParms(13) = New SqlParameter("@SDate", SqlDbType.Date)
        arParms(13).Value = EL.date1

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NewInsertrefund", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function CheckDuplicateRef(ByVal EL As ELFrmCollectSponsor) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Stdid", SqlDbType.Int)
        arParms(1).Value = EL.STDID
        arParms(2) = New SqlParameter("@batchid", SqlDbType.Int)
        arParms(2).Value = EL.Batch
        arParms(3) = New SqlParameter("@AID", SqlDbType.Int)
        arParms(3).Value = EL.academic


        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetDuplicateSponsorRefund", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Shared Function UpdateSponsorTransfer(ByVal EL As ELFrmCollectSponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(12) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@SpId", SqlDbType.Int)
        arParms(1).Value = EL.SpId
        arParms(2) = New SqlParameter("@SId", SqlDbType.Int)
        arParms(2).Value = EL.STDID
        arParms(3) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(3).Value = EL.Batch
        arParms(4) = New SqlParameter("@academic", SqlDbType.Int)
        arParms(4).Value = EL.academic
        arParms(5) = New SqlParameter("@date", SqlDbType.Date)
        arParms(5).Value = EL.date1
        arParms(6) = New SqlParameter("@category", SqlDbType.Int)
        arParms(6).Value = EL.Category
        arParms(7) = New SqlParameter("@TAmount", SqlDbType.Money)
        arParms(7).Value = EL.amount
        arParms(8) = New SqlParameter("@ChequeNo", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.chqno
        arParms(9) = New SqlParameter("@ChqDate", SqlDbType.Date)
        arParms(9).Value = EL.chqdate
        arParms(10) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("Empcode")
        arParms(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("UserCode")
        arParms(12) = New SqlParameter("@mode ", SqlDbType.Int)
        arParms(12).Value = EL.mode

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "NewUpdateTransferFee", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetRef(ByVal EL As ELFrmCollectSponsor) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = EL.id
  

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "getrefund", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function UpdateRefund(ByVal EL As ELFrmCollectSponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@amount", SqlDbType.Money)
        arParms(1).Value = EL.amount
        arParms(2) = New SqlParameter("@mode", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.mode
        arParms(3) = New SqlParameter("@chqno", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.chqno
        arParms(4) = New SqlParameter("@chqdate", SqlDbType.Date)
        arParms(4).Value = EL.chqdate
        arParms(5) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(5).Value = EL.id
        arParms(6) = New SqlParameter("@Modified_By", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Empcode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UpdateforRefundStdudent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateTransfer(ByVal EL As ELFrmCollectSponsor) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@amount", SqlDbType.Money)
        arParms(1).Value = EL.amount
        arParms(2) = New SqlParameter("@mode", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.mode
        arParms(3) = New SqlParameter("@chqno", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.chqno
        arParms(4) = New SqlParameter("@chqdate", SqlDbType.Date)
        arParms(4).Value = EL.chqdate
        arParms(5) = New SqlParameter("@Id", SqlDbType.VarChar, 50)
        arParms(5).Value = EL.id
        arParms(6) = New SqlParameter("@Modified_By", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Empcode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UpdateTransfertoFee", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetSponsorAmt(ByVal STDID As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim rowsAffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(2) {}
      


        Params(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(0).Value = HttpContext.Current.Session("BranchCode")

        Params(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(1).Value = HttpContext.Current.Session("Office")

        Params(2) = New SqlParameter("@STDID", SqlDbType.Int)
        Params(2).Value = STDID

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_getsponsor", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetTransfer(ByVal EL As ELFrmCollectSponsor) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = EL.id


        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "gettransfer", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function GetRefundtot(ByVal STDID As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim rowsAffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(2) {}



        Params(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(0).Value = HttpContext.Current.Session("BranchCode")

        Params(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(1).Value = HttpContext.Current.Session("Office")

        Params(2) = New SqlParameter("@STDID", SqlDbType.Int)
        Params(2).Value = STDID

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_getRefundAmount", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
