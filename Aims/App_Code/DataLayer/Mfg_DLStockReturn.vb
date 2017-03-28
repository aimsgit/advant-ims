Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLStockReturn
    Public Function Insert(ByVal Id As Mfg_ELStockReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(8) {}

            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")
            'Parms(3) = New SqlParameter("@Id", SqlDbType.Int)
            'Parms(3).Value = Id.ReturnId
            Parms(3) = New SqlParameter("@Party_Type", SqlDbType.Int)
            Parms(3).Value = Id.PartyType
            Parms(4) = New SqlParameter("@Party_ID", SqlDbType.Int)
            Parms(4).Value = Id.Party
            Parms(5) = New SqlParameter("@ReturnNo", SqlDbType.VarChar, 20)
            Parms(5).Value = Id.ReturnNo
            Parms(6) = New SqlParameter("@WorkOrder", SqlDbType.Int)
            Parms(6).Value = Id.WorkOrder
           
            Parms(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
            Parms(7).Value = Id.Remarks
            Parms(8) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            Parms(8).Value = Id.ReturnDate
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockReturnM", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function Update(ByVal Id As Mfg_ELStockReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(9) {}

            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")
            Parms(3) = New SqlParameter("@StockReturn_Id", SqlDbType.Int)
            Parms(3).Value = Id.ReturnId
            Parms(4) = New SqlParameter("@Party_Type", SqlDbType.Int)
            Parms(4).Value = Id.PartyType
            Parms(5) = New SqlParameter("@Party_ID", SqlDbType.Int)
            Parms(5).Value = Id.Party
            Parms(6) = New SqlParameter("@ReturnNo", SqlDbType.VarChar, 20)
            Parms(6).Value = Id.ReturnNo
            Parms(7) = New SqlParameter("@WorkOrder", SqlDbType.Int)
            Parms(7).Value = Id.WorkOrder

            Parms(8) = New SqlParameter("@Remarks", SqlDbType.NVarChar, 250)
            Parms(8).Value = Id.Remarks
            Parms(9) = New SqlParameter("@ReturnDate", SqlDbType.DateTime)
            Parms(9).Value = Id.ReturnDate

            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateStockReturnM", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function GetStockReturnM(ByVal El As Mfg_ELStockReturn) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.Int)
            Parms(2).Value = El.id
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockReturnM", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetStockReturnNo(ByVal El As Mfg_ELStockReturn) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockReturnNo", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetIssueNoDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_GetIssueNoddl", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetItemDescDDL(ByVal Name As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@IssueNo", SqlDbType.VarChar, 50)
        arParms(2).Value = Name

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_GetItemDescDDL", arParms)
        Return ds.Tables(0)
    End Function
    Public Function Insertrecord(ByVal Id As Mfg_ELStockReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(8) {}

            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")
            Parms(3) = New SqlParameter("@IssueNo", SqlDbType.VarChar, 50)
            Parms(3).Value = Id.IssueNo
            Parms(4) = New SqlParameter("@ChallanNo", SqlDbType.VarChar, 50)
            Parms(4).Value = Id.ChallanNo
            Parms(5) = New SqlParameter("@ItemDesc", SqlDbType.Int)
            Parms(5).Value = Id.ItemDesc
            Parms(6) = New SqlParameter("@Qty", SqlDbType.Int)
            Parms(6).Value = Id.Qty
            Parms(7) = New SqlParameter("@StockReturnNo", SqlDbType.VarChar, 50)
            Parms(7).Value = Id.ReturnNo
            Parms(8) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(8).Value = Id.BatchId
            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockReturnD", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function UpdateRecord(ByVal Id As Mfg_ELStockReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(9) {}

            Parms(0) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("EmpCode")
            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")
            Parms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("UserCode")
            Parms(3) = New SqlParameter("@IssueNo", SqlDbType.Int)
            Parms(3).Value = Id.IssueNo
            Parms(4) = New SqlParameter("@ChallanNo", SqlDbType.Int)
            Parms(4).Value = Id.ChallanNo
            Parms(5) = New SqlParameter("@ItemDesc", SqlDbType.Int)
            Parms(5).Value = Id.ItemDesc
            Parms(6) = New SqlParameter("@Qty", SqlDbType.Int)
            Parms(6).Value = Id.Qty
            Parms(7) = New SqlParameter("@Id", SqlDbType.Int)
            Parms(7).Value = Id.id
            Parms(8) = New SqlParameter("@StockReturnNo", SqlDbType.VarChar, 50)
            Parms(8).Value = Id.ReturnNo
            Parms(9) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(9).Value = Id.BatchId

            ds = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateStockReturnD", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Public Function GetStockReturnDetails(ByVal El As Mfg_ELStockReturn) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@id", SqlDbType.Int)
            Parms(2).Value = El.id

            Parms(3) = New SqlParameter("@ReturnNo", SqlDbType.VarChar, 50)
            Parms(3).Value = El.ReturnNo

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockReturnDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetChallanNo(ByVal Number As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@IssueNo", SqlDbType.VarChar, 50)
        arParms(2).Value = Number

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_GetChallanNo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetQtyIssued(ByVal Desc As String, ByVal Pid As String, ByVal Bid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Desc", SqlDbType.VarChar, 50)
        arParms(2).Value = Desc

        arParms(3) = New SqlParameter("@PID", SqlDbType.VarChar, 50)
        arParms(3).Value = Pid

        arParms(4) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(4).Value = Bid

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_GetIssuedQty", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteStockReturn(ByVal id As Mfg_ELStockReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteStockReturnM", param)
        Return rowsaffected
    End Function

    Public Function DeleteStockReturnD(ByVal id As Mfg_ELStockReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Id", SqlDbType.Int)
        param(0).Value = id.id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteStockReturnD", param)
        Return rowsaffected
    End Function
    Shared Function BatchCombo(ByVal pid As Integer, ByVal Name As String) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@ProductId", SqlDbType.Int)
        param(1).Value = pid
        param(2) = New SqlParameter("@IssueNo", SqlDbType.VarChar, 50)
        param(2).Value = Name
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ProductBatchesDDL", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function PostToStockReturn(ByVal EL As Mfg_ELStockReturn) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@StockReturnNo", SqlDbType.Int)
        arParms(3).Value = EL.ReturnId
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_PostStockReturn", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function PrintStockReturnNote(ByVal ReturnNo As String) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@ReturnNo", SqlDbType.VarChar)
        param(2).Value = ReturnNo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptStockReturnNote", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
