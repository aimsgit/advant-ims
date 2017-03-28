Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class Mfg_DLProductDetails
    Public Function Insert(ByVal i As Mfg_ELProductDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(28) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Product_Name", SqlDbType.VarChar, 50)
        arParms(0).Value = i.Product

        arParms(1) = New SqlParameter("@ProductCode", SqlDbType.VarChar, 50)
        arParms(1).Value = i.Code

        arParms(2) = New SqlParameter("@ProductCategory", SqlDbType.VarChar, 50)
        arParms(2).Value = i.Category

        arParms(3) = New SqlParameter("@Description_Id", SqlDbType.Int)
        arParms(3).Value = i.Description

        arParms(4) = New SqlParameter("@Packing_Details", SqlDbType.VarChar, 50)
        arParms(4).Value = i.Packing

        arParms(5) = New SqlParameter("@Company_ID", SqlDbType.Int)
        arParms(5).Value = i.Supplier

        arParms(6) = New SqlParameter("@Manufacture_Name", SqlDbType.Int)
        arParms(6).Value = i.Company

        arParms(7) = New SqlParameter("@Reorder_Level", SqlDbType.Int)
        arParms(7).Value = i.Reorder

        arParms(8) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(8).Value = i.Remarks

        arParms(9) = New SqlParameter("@Unit", SqlDbType.Int)
        arParms(9).Value = i.Unit

        arParms(10) = New SqlParameter("@PurchaseTaxPlan", SqlDbType.Int)
        arParms(10).Value = i.Purchase

        arParms(11) = New SqlParameter("@PDealQty", SqlDbType.Float)
        arParms(11).Value = i.PDeal1

        arParms(12) = New SqlParameter("@PDealFree", SqlDbType.Float)
        arParms(12).Value = i.PDeal2

        arParms(13) = New SqlParameter("@PurchaseRate", SqlDbType.Money)
        arParms(13).Value = i.PRate

        arParms(14) = New SqlParameter("@MRP", SqlDbType.Money)
        arParms(14).Value = i.MPR

        arParms(15) = New SqlParameter("@SaleRate", SqlDbType.Money)
        arParms(15).Value = i.SaleRate

        arParms(16) = New SqlParameter("@PflatRate", SqlDbType.Float)
        arParms(16).Value = i.PurchRate

        arParms(17) = New SqlParameter("@PDiscount", SqlDbType.Float)
        arParms(17).Value = i.PurchaseDis

        arParms(18) = New SqlParameter("@SaleTaxPlan", SqlDbType.Int)
        arParms(18).Value = i.SalePlan

        arParms(19) = New SqlParameter("@OfferPeriod", SqlDbType.DateTime)
        arParms(19).Value = i.OfferPeriod

        arParms(20) = New SqlParameter("@DiscountLock", SqlDbType.VarChar, 2)
        arParms(20).Value = i.Discount

        arParms(21) = New SqlParameter("@SaleDiscount", SqlDbType.Float)
        arParms(21).Value = i.SaleDiscount

        arParms(22) = New SqlParameter("@SDealQty", SqlDbType.Float)
        arParms(22).Value = i.SaleDeal1

        arParms(23) = New SqlParameter("@SDealFree", SqlDbType.Float)
        arParms(23).Value = i.SaleDeal2

        arParms(24) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("UserCode")

        arParms(25) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(25).Value = HttpContext.Current.Session("EmpCode")

        arParms(26) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(26).Value = HttpContext.Current.Session("BranchCode")

        arParms(27) = New SqlParameter("@ProductType", SqlDbType.Int)
        arParms(27).Value = i.Type

        arParms(28) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(28).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_InsertProductDetail", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal s As Mfg_ELProductDetails) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.id
        para(1) = New SqlParameter("@Code", SqlDbType.VarChar, 50)
        para(1).Value = s.Code

        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Mfg_DuplicateProductDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function Update(ByVal i As Mfg_ELProductDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(28) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@Product_Name", SqlDbType.VarChar, 50)
        arParms(0).Value = i.Product

        arParms(1) = New SqlParameter("@ProductCode", SqlDbType.VarChar, 50)
        arParms(1).Value = i.Code



        arParms(2) = New SqlParameter("@Description_Id", SqlDbType.Int)
        arParms(2).Value = i.Description

        arParms(3) = New SqlParameter("@Packing_Details", SqlDbType.VarChar, 50)
        arParms(3).Value = i.Packing

        arParms(4) = New SqlParameter("@Company_ID", SqlDbType.Int)
        arParms(4).Value = i.Supplier

        arParms(5) = New SqlParameter("@Manufacture_Name", SqlDbType.Int)
        arParms(5).Value = i.Company

        arParms(6) = New SqlParameter("@Reorder_Level", SqlDbType.Int)
        arParms(6).Value = i.Reorder

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(7).Value = i.Remarks

        arParms(8) = New SqlParameter("@Unit", SqlDbType.Int)
        arParms(8).Value = i.Unit

        arParms(9) = New SqlParameter("@PurchaseTaxPlan", SqlDbType.Int)
        arParms(9).Value = i.Purchase

        arParms(10) = New SqlParameter("@PDealQty", SqlDbType.Float)
        arParms(10).Value = i.PDeal1

        arParms(11) = New SqlParameter("@PDealFree", SqlDbType.Float)
        arParms(11).Value = i.PDeal2

        arParms(12) = New SqlParameter("@PurchaseRate", SqlDbType.Money)
        arParms(12).Value = i.PRate

        arParms(13) = New SqlParameter("@MRP", SqlDbType.Money)
        arParms(13).Value = i.MPR

        arParms(14) = New SqlParameter("@SaleRate", SqlDbType.Money)
        arParms(14).Value = i.SaleRate

        arParms(15) = New SqlParameter("@PflatRate", SqlDbType.Float)
        arParms(15).Value = i.PurchRate

        arParms(16) = New SqlParameter("@PDiscount", SqlDbType.Float)
        arParms(16).Value = i.PurchaseDis

        arParms(17) = New SqlParameter("@SaleTaxPlan", SqlDbType.Int)
        arParms(17).Value = i.SalePlan

        arParms(18) = New SqlParameter("@OfferPeriod", SqlDbType.DateTime)
        arParms(18).Value = i.OfferPeriod

        arParms(19) = New SqlParameter("@DiscountLock", SqlDbType.VarChar, 2)
        arParms(19).Value = i.Discount

        arParms(20) = New SqlParameter("@SaleDiscount", SqlDbType.Float)
        arParms(20).Value = i.SaleDiscount

        arParms(21) = New SqlParameter("@SDealQty", SqlDbType.Float)
        arParms(21).Value = i.SaleDeal1

        arParms(22) = New SqlParameter("@SDealFree", SqlDbType.Float)
        arParms(22).Value = i.SaleDeal2

        arParms(23) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(23).Value = HttpContext.Current.Session("UserCode")

        arParms(24) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("EmpCode")

        arParms(25) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(25).Value = HttpContext.Current.Session("BranchCode")

        arParms(26) = New SqlParameter("@ProductType", SqlDbType.Int)
        arParms(26).Value = i.Type

        arParms(27) = New SqlParameter("@ProductAutoNo", SqlDbType.Int)
        arParms(27).Value = i.id

        arParms(28) = New SqlParameter("@ProductCategory", SqlDbType.VarChar, 50)
        arParms(28).Value = i.Category

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_UpdateProductDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function getProduct(ByVal s As Mfg_ELProductDetails) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = s.id
        arParms(3) = New SqlParameter("@productName", SqlDbType.VarChar, 100)
        arParms(3).Value = s.Product

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetProductDetails", arParms)
        Return ds.Tables(0)
    End Function

    Public Function GetCategory() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_CategoryDetails", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteProduct(ByVal s As Mfg_ELProductDetails) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = s.id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Mfg_DeleteProductDetails", arParms)
        Return rowsaffected
    End Function
    Public Function GetDescription() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlDescription", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetCompany() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlStockStmtManfCompany", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function getPurchaseTaxPlan() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlTaxPlan", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function getUnit() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlUnit", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function getSupplier() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlSupplierName", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function GetSaleTaxPlan() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ddlTaxPlan", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function

End Class
