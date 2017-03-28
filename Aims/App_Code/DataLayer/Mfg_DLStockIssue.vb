Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLStockIssue
    Public Function GetStockIssuedReport(ByVal id As String, ByVal partytype As String, ByVal partyName As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.VarChar, 1000)
        arParms(0).Value = id



        arParms(1) = New SqlParameter("@PartyType", SqlDbType.VarChar, 50)
        arParms(1).Value = partytype

        arParms(2) = New SqlParameter("@PartyName", SqlDbType.VarChar, 50)
        arParms(2).Value = partyName


        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockIssueReport2", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetMaterialMI_NO() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlMaterialIndex_MINO", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetMaterialIndent(ByVal ImNO As String, ByVal partytype As String, ByVal partyName As String, ByVal workorder As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@ImNo", SqlDbType.VarChar, 50)
        arParms(0).Value = ImNO


        arParms(1) = New SqlParameter("@PartyType", SqlDbType.VarChar, 50)
        arParms(1).Value = partytype

        arParms(2) = New SqlParameter("@PartyName2", SqlDbType.VarChar, 50)
        arParms(2).Value = partyName

        arParms(3) = New SqlParameter("@WorkOrder", SqlDbType.VarChar, 50)
        arParms(3).Value = workorder


        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetMaterialIndent", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function InsertProductReceipe(ByVal EL As Mfg_ElStockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(0).Value = EL.EntryDate
        arParms(1) = New SqlParameter("@PartyName", SqlDbType.Int)
        arParms(1).Value = EL.PartyName
        arParms(2) = New SqlParameter("@ConvFact", SqlDbType.Float)
        arParms(2).Value = EL.CV
        arParms(3) = New SqlParameter("@ProductID", SqlDbType.Float)
        arParms(3).Value = EL.PID
        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")
        arParms(5) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")
        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")
        arParms(7) = New SqlParameter("@QtyIssued", SqlDbType.Float)
        arParms(7).Value = EL.QtyIssued
        arParms(8) = New SqlParameter("@QtyReturned", SqlDbType.Float)
        arParms(8).Value = EL.QtyReturned

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertStockIssueDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function UpdateProductReceipe(ByVal EL As Mfg_ElStockIssue) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        Dim rowsAffected As Integer = 0
        'arParms(0) = New SqlParameter("@Date", SqlDbType.DateTime)
        'arParms(0).Value = EL.EntryDate
        'arParms(1) = New SqlParameter("@PartyName", SqlDbType.Int)
        'arParms(1).Value = EL.PartyName
        arParms(0) = New SqlParameter("@ConvFact", SqlDbType.Float)
        arParms(0).Value = EL.CV
        arParms(1) = New SqlParameter("@ProductID", SqlDbType.Float)
        arParms(1).Value = EL.PID
        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")
        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")
        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")
        arParms(5) = New SqlParameter("@QtyIssued", SqlDbType.Float)
        arParms(5).Value = EL.QtyIssued
        arParms(6) = New SqlParameter("@QtyReturned", SqlDbType.Float)
        arParms(6).Value = EL.QtyReturned
        arParms(7) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(7).Value = EL.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateStockIssueDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function DeteteProductReceipe(ByVal EL As Mfg_ElStockIssue) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@Id", SqlDbType.Int)
        arParms.Value = EL.id
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteStockIssue", arParms)
        Return rowsaffected
    End Function
    Public Function getProductReceipe(ByVal EL As Mfg_ElStockIssue) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id

        arParms(3) = New SqlParameter("@PartyName", SqlDbType.Int)
        arParms(3).Value = EL.PartyName

        arParms(4) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(4).Value = EL.PartyType

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockIssue", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getProductExpiry(ByVal EL As Mfg_ElStockIssue) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@ProductId", SqlDbType.Int)
        arParms(2).Value = EL.PID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductExipry", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getProducyDetailsReceipe(ByVal EL As Mfg_ElStockIssue) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.id

        arParms(3) = New SqlParameter("@PartyName", SqlDbType.Int)
        arParms(3).Value = EL.PartyName

        arParms(4) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(4).Value = EL.PartyType

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetStockIssueDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetPartyNameddl(ByVal PartyName As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(2).Value = PartyName

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_GetPartyNameddl", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetPartyTypeddl() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        'arParms(2) = New SqlParameter("@PartyType", SqlDbType.Int)
        'arParms(2).Value = PType


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_GetPartyTypeddl", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetPartyNameddl1(ByVal Name As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@PartyType", SqlDbType.Int)
        arParms(2).Value = Name

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Mfg_RptPartyNameddl", arParms)
        Return ds.Tables(0)
    End Function

End Class
