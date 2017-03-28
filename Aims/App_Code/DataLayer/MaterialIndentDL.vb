Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class MaterialIndentDL
    Shared Function GetCustomerDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCustomerDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetMaterialIndentReport(ByVal Fromdate As DateTime, ByVal Todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(0).Value = Fromdate

        arParms(1) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(1).Value = Todate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetMaterialIndentReport", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetWorkOrderDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_WorkOrderDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetItemDescriptionDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetItemDescriptionDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function InsertMaterialIndent(ByVal AddMaterial As MaterialIndentEL) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(9) {}
        Params(0) = New SqlParameter("@Mino", Data.SqlDbType.VarChar)
        Params(0).Value = AddMaterial.mino
        If AddMaterial.midate = "01/01/1900" Then
            Params(1) = New SqlParameter("@Midate", Data.SqlDbType.DateTime)
            Params(1).Value = DBNull.Value
        Else
            Params(1) = New SqlParameter("@Midate", Data.SqlDbType.DateTime)
            Params(1).Value = AddMaterial.midate
        End If
        Params(2) = New SqlParameter("@Customer", Data.SqlDbType.Int)
        Params(2).Value = AddMaterial.custmr
        Params(3) = New SqlParameter("@Wo", Data.SqlDbType.Int)
        Params(3).Value = AddMaterial.wo_id
        Params(4) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(4).Value = AddMaterial.id1
        Params(5) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(5).Value = HttpContext.Current.Session("BranchCode")
        Params(6) = New SqlParameter("@EmpCode", Data.SqlDbType.VarChar)
        Params(6).Value = HttpContext.Current.Session("EmpCode")
        Params(7) = New SqlParameter("@UserCode", Data.SqlDbType.VarChar)
        Params(7).Value = HttpContext.Current.Session("UserCode")
        Params(8) = New SqlParameter("@Office", Data.SqlDbType.VarChar)
        Params(8).Value = HttpContext.Current.Session("Office")
        Params(9) = New SqlParameter("@PartyType", Data.SqlDbType.Int)
        Params(9).Value = AddMaterial.party_id

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_InsertMaterialIndent", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function MaterialMaineGridView(ByVal AddMaterial As MaterialIndentEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}
            Parms(0) = New SqlParameter("@ID", SqlDbType.Int)
            Parms(0).Value = AddMaterial.id1

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@PartyType", SqlDbType.Int)
            Parms(2).Value = AddMaterial.party_id

            Parms(3) = New SqlParameter("@PartyName", SqlDbType.Int)
            Parms(3).Value = AddMaterial.custmr

            Parms(4) = New SqlParameter("@Office", SqlDbType.VarChar)
            Parms(4).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "prc_MaterialIndentMainGridView", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function CheckDuplicateMaterialIndent(ByVal AddMaterial As MaterialIndentEL) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Mino", SqlDbType.VarChar)
        arParms(1).Value = AddMaterial.mino
        arParms(2) = New SqlParameter("@Midate", SqlDbType.DateTime)
        arParms(2).Value = AddMaterial.midate
        arParms(3) = New SqlParameter("@id", SqlDbType.Int)
        arParms(3).Value = AddMaterial.id1
        arParms(4) = New SqlParameter("@Customer", SqlDbType.Int)
        arParms(4).Value = AddMaterial.custmr
        arParms(5) = New SqlParameter("@Wo", SqlDbType.Int)
        arParms(5).Value = AddMaterial.wo_id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateMaterialIndentMain", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function CheckStatus(ByVal AddMaterial As MaterialIndentEL) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = AddMaterial.id1
        
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_CheckStatus", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function CheckStatus1(ByVal AddMaterial As MaterialIndentEL) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@id", SqlDbType.Int)
        arParms(1).Value = AddMaterial.id

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_CheckStatus1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Shared Function DeleteMaterialIndent(ByVal AddMaterial As MaterialIndentEL) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Params(0) = New SqlParameter("@ID", Data.SqlDbType.Int)
        Params(0).Value = AddMaterial.id1

        Params(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        Params(1).Value = HttpContext.Current.Session("Office")

        Params(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        Params(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_DeleteMaterialIndent", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function PostMaterialIndentMain(ByVal ID As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
            Parms(1).Value = ID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_PostMaterialIndentMain", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Nothing
    End Function
    Shared Function InsertMaterialIndentDetails(ByVal AddMaterial As MaterialIndentEL) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(7) {}
        Params(0) = New SqlParameter("@ItemDesc", Data.SqlDbType.Int)
        Params(0).Value = AddMaterial.itemdesc
        Params(1) = New SqlParameter("@Quantity", Data.SqlDbType.Int)
        Params(1).Value = AddMaterial.quantity
        Params(2) = New SqlParameter("@mino", Data.SqlDbType.VarChar, 50)
        Params(2).Value = AddMaterial.mino
        Params(3) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(3).Value = AddMaterial.id
        Params(4) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(4).Value = HttpContext.Current.Session("BranchCode")
        Params(5) = New SqlParameter("@EmpCode", Data.SqlDbType.VarChar, 50)
        Params(5).Value = HttpContext.Current.Session("EmpCode")
        Params(6) = New SqlParameter("@UserCode", Data.SqlDbType.VarChar, 50)
        Params(6).Value = HttpContext.Current.Session("UserCode")
        Params(7) = New SqlParameter("@Office", Data.SqlDbType.VarChar, 2)
        Params(7).Value = HttpContext.Current.Session("Office")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_InsertMaterialIndentDetails", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function MaterialIndentDetailsGridView(ByVal AddMaterial As MaterialIndentEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}
            Parms(0) = New SqlParameter("@ID", SqlDbType.Int)
            Parms(0).Value = AddMaterial.id

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@MI_No", SqlDbType.VarChar, 50)
            Parms(2).Value = AddMaterial.mino

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "prc_MaterialIndentDetailsGridView", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteMaterialIndentDetails(ByVal AddMaterial As MaterialIndentEL) As Integer
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Params(0) = New SqlParameter("@ID", Data.SqlDbType.Int)
        Params(0).Value = AddMaterial.id

        Params(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        Params(1).Value = HttpContext.Current.Session("Office")

        Params(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        Params(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "proc_DeleteMaterialIndentDetails", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function MIndentCodeAutofill() As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Params() As SqlParameter = New SqlParameter(0) {}
        Params(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(0).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_MIndentCodedAutofill", Params)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function CheckMaterialIndentNo(ByVal AddMaterial As MaterialIndentEL) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@MINo", SqlDbType.VarChar)
        arParms(1).Value = AddMaterial.mino
        'arParms(1) = New SqlParameter("@Midate", SqlDbType.DateTime)
        'arParms(1).Value = AddMaterial.midate
        'arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        'arParms(2).Value = AddMaterial.id
        'arParms(3) = New SqlParameter("@Customer", SqlDbType.Int)
        'arParms(3).Value = AddMaterial.custmr
        'arParms(4) = New SqlParameter("@Wo", SqlDbType.Int)
        'arParms(4).Value = AddMaterial.wo_id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_CheckMateriaIndentNo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function Approve(ByVal AddMaterial As MaterialIndentEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer
        Dim Parms() As SqlParameter = New SqlParameter(3) {}
        Parms(0) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
        Parms(0).Value = AddMaterial.id
        Parms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(1).Value = HttpContext.Current.Session("UserCode")
        Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("EmpCode")
        Parms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(3).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_PurchaseRequisitionApprove", Parms)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetUnit(ByVal AddMaterial As MaterialIndentEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}
            Parms(0) = New SqlParameter("@Product_Id", SqlDbType.Int)
            Parms(0).Value = AddMaterial.itemdesc

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetUnit", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
