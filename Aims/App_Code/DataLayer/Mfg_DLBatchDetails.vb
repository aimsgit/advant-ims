Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_DLBatchDetails
    Public Function ProductComboD() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProductNameNew", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ProcessComboD() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProcess", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function ProductComboCode() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProductcCodeNew", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ProductBinCard() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectProductBinCard", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ProductRawMaterial() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectRawMaterialProduct", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetUnit() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetUnit", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ProductFinishedGood() As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_SelectFinishedProduct", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getDetails(ByVal El As Mfg_ELBatchDetails) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = El.Productid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_Proc_GetProductFieldsDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Public Shared Function GridviewDetails(ByVal El As Mfg_ELBatchDetails) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet


        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("id", SqlDbType.Int)
        arParms(2).Value = El.id
        arParms(3) = New SqlParameter("@Productid", SqlDbType.Int)
        arParms(3).Value = El.Productid
       

        Try

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetBatchDetails", arParms)


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Shared Function Insert(ByVal El As Mfg_ELBatchDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(17) {}
	
	    arParms(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(0).Value = El.Batch

        arParms(1) = New SqlParameter("@Product", SqlDbType.Int)
        arParms(1).Value = El.Productid


        arParms(2) = New SqlParameter("@Mfg_Date", SqlDbType.DateTime)
        arParms(2).Value = El.Mfgdate

        If El.Expiry = "#1/1/3000#" Then
            arParms(3) = New SqlParameter("@Expiry", SqlDbType.DateTime)
            arParms(3).Value = System.DBNull.Value
        Else
            arParms(3) = New SqlParameter("@Expiry", SqlDbType.DateTime)
            arParms(3).Value = El.Expiry
        End If
        If El.DealQty = 0 Then
            arParms(4) = New SqlParameter("@Deal_Qty", SqlDbType.VarChar)
            arParms(4).Value = System.DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Deal_Qty", SqlDbType.Int)
            arParms(4).Value = El.DealQty
        End If



        arParms(5) = New SqlParameter("@Deal_free", SqlDbType.Float)
        arParms(5).Value = El.DealFree

        arParms(6) = New SqlParameter("@Packing", SqlDbType.VarChar, 50)
        arParms(6).Value = El.Packing

        arParms(7) = New SqlParameter("@Purchase_Rate", SqlDbType.Float)
        arParms(7).Value = El.PRate

        arParms(8) = New SqlParameter("@vat", SqlDbType.Float)
        arParms(8).Value = El.vat

        arParms(9) = New SqlParameter("@cst", SqlDbType.Float)
        arParms(9).Value = El.cst

        arParms(10) = New SqlParameter("@Discount", SqlDbType.Float)
        arParms(10).Value = El.PurchaseDis

        arParms(11) = New SqlParameter("@Sale_Rate", SqlDbType.Float)
        arParms(11).Value = El.SaleRate


        arParms(12) = New SqlParameter("@MRP", SqlDbType.Float)
        arParms(12).Value = El.MPR

        arParms(13) = New SqlParameter("@Hold", SqlDbType.VarChar, 50)
        arParms(13).Value = El.Hold


        arParms(14) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("BranchCode")

        arParms(15) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("EmpCode")

        arParms(16) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("UserCode")
        arParms(17) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(17).Value = HttpContext.Current.Session("Office")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertBatchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Public Shared Function Update(ByVal El As Mfg_ELBatchDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(17) {}

        arParms(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        arParms(0).Value = El.Batch

        arParms(1) = New SqlParameter("@Product", SqlDbType.Int)
        arParms(1).Value = El.Productid


        arParms(2) = New SqlParameter("@Mfg_Date", SqlDbType.DateTime)
        arParms(2).Value = El.Mfgdate
        If El.Expiry = "#1/1/3000#" Then
            arParms(3) = New SqlParameter("@Expiry", SqlDbType.DateTime)
            arParms(3).Value = System.DBNull.Value
        Else
            arParms(3) = New SqlParameter("@Expiry", SqlDbType.DateTime)
            arParms(3).Value = El.Expiry
        End If
        

        If El.DealQty = 0 Then
            arParms(4) = New SqlParameter("@Deal_Qty", SqlDbType.VarChar)
            arParms(4).Value = System.DBNull.Value
        Else
            arParms(4) = New SqlParameter("@Deal_Qty", SqlDbType.Int)
            arParms(4).Value = El.DealQty
        End If
        arParms(5) = New SqlParameter("@Deal_free", SqlDbType.Float)
        arParms(5).Value = El.DealFree

        arParms(6) = New SqlParameter("@Packing", SqlDbType.VarChar, 50)
        arParms(6).Value = El.Packing

        arParms(7) = New SqlParameter("@Purchase_Rate", SqlDbType.Float)
        arParms(7).Value = El.PRate

        arParms(8) = New SqlParameter("@vat", SqlDbType.Float)
        arParms(8).Value = El.vat

        arParms(9) = New SqlParameter("@cst", SqlDbType.Float)
        arParms(9).Value = El.cst

        arParms(10) = New SqlParameter("@Discount", SqlDbType.Float)
        arParms(10).Value = El.PurchaseDis

        arParms(11) = New SqlParameter("@Sale_Rate", SqlDbType.Float)
        arParms(11).Value = El.SaleRate


        arParms(12) = New SqlParameter("@MRP", SqlDbType.Float)
        arParms(12).Value = El.MPR

        arParms(13) = New SqlParameter("@Hold", SqlDbType.VarChar, 50)
        arParms(13).Value = El.Hold


        arParms(14) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(14).Value = HttpContext.Current.Session("BranchCode")

        arParms(15) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(15).Value = HttpContext.Current.Session("EmpCode")

        arParms(16) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(16).Value = HttpContext.Current.Session("UserCode")

        arParms(17) = New SqlParameter("@id", SqlDbType.Int)
        arParms(17).Value = El.id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateBatchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Delete(ByVal id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim SE As New Supplier
        Dim rowsAffected As Integer = 0


        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_Deletebatchdetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function


    Shared Function GetDuplicateType(ByVal El As Mfg_ELBatchDetails) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = El.id
        arParms(3) = New SqlParameter("@batch", SqlDbType.VarChar, 50)
        arParms(3).Value = El.Batch

        arParms(4) = New SqlParameter("@Product", SqlDbType.Int)
        arParms(4).Value = El.Productid
        Try

            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Mfg_DuplicateBatchDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
