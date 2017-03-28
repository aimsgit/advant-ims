Imports Microsoft.VisualBasic
'Namespace GlobalDataSetTableAdapters
Imports System.Data.SqlClient
'Imports System.Data
Public Class AssetDetailsDB
    Shared Function GetAssetDetails(ByVal ad As AssetDetails) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@AssetDet_Id", SqlDbType.Int)
        arParms(2).Value = ad.AssetDet_Id

        arParms(3) = New SqlParameter("@AssetType", SqlDbType.VarChar)
        arParms(3).Value = ad.AssetType

        arParms(4) = New SqlParameter("@AssetName", SqlDbType.VarChar)
        arParms(4).Value = ad.AssetName

        arParms(5) = New SqlParameter("@ReceivedBy", SqlDbType.VarChar)
        arParms(5).Value = ad.Receivedby

        arParms(6) = New SqlParameter("@PurchaseDate", SqlDbType.DateTime)
        arParms(6).Value = ad.purchasedate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewGetAssetDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DType(ByVal ad As AssetDetails) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Asset_Type", SqlDbType.VarChar, 50)
        arParms(2).Value = ad.AssetType

        arParms(3) = New SqlParameter("@DType", SqlDbType.Int)
        arParms(3).Value = ad.DType

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectDepreciation_Rate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function Insert(ByVal ad As AssetDetails) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(46) {}

        arParms(0) = New SqlParameter("@AssetName", SqlDbType.VarChar, 50)
        arParms(0).Value = ad.AssetName
        arParms(1) = New SqlParameter("@Price", SqlDbType.Money)
        arParms(1).Value = ad.Bookvalueprice

        arParms(2) = New SqlParameter("@AssetCode", SqlDbType.VarChar, 50)
        arParms(2).Value = ad.AssetCode

        arParms(3) = New SqlParameter("@Supp_Id_Auto", SqlDbType.Int)
        arParms(3).Value = ad.supplier

        arParms(4) = New SqlParameter("@Emp_ID", SqlDbType.VarChar, 50)
        arParms(4).Value = ad.Receivedby

        arParms(5) = New SqlParameter("@ManuFacturerCode", SqlDbType.Int)
        arParms(5).Value = ad.Manufacturer

        arParms(6) = New SqlParameter("@Location", SqlDbType.Int)
        arParms(6).Value = ad.Location

        arParms(7) = New SqlParameter("@MachineSerialNo", SqlDbType.VarChar, 50)
        arParms(7).Value = ad.Machineslno

        arParms(8) = New SqlParameter("@PaymentMethod_Id", SqlDbType.Int)
        arParms(8).Value = ad.Paymentmethod

        arParms(9) = New SqlParameter("@Asset_Photo", SqlDbType.VarChar, 250)
        arParms(9).Value = ad.APhoto

        If ad.purchasedate = "01/01/1900" Then
            arParms(10) = New SqlParameter("@PurchaseDate", SqlDbType.VarChar)
            arParms(10).Value = System.DBNull.Value
        Else
            arParms(10) = New SqlParameter("@PurchaseDate", SqlDbType.DateTime)
            arParms(10).Value = ad.purchasedate
        End If

        arParms(11) = New SqlParameter("@Model_Number", SqlDbType.VarChar, 50)
        arParms(11).Value = ad.Modelno

        arParms(12) = New SqlParameter("@BillType", SqlDbType.VarChar, 50)
        arParms(12).Value = ad.Billtype

        arParms(13) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
        arParms(13).Value = ad.invoiceno

        arParms(14) = New SqlParameter("@Brought_by", SqlDbType.VarChar, 50)
        arParms(14).Value = ad.broughtby

        arParms(15) = New SqlParameter("@AmtPaid", SqlDbType.Money)
        arParms(15).Value = ad.amountpaid

        arParms(16) = New SqlParameter("@Description", SqlDbType.VarChar, 500)
        arParms(16).Value = ad.Description

        arParms(17) = New SqlParameter("@Quantity", SqlDbType.VarChar)
        arParms(17).Value = ad.Quantity

        arParms(18) = New SqlParameter("@SentBy", SqlDbType.VarChar, 500)
        arParms(18).Value = ad.sentby

        arParms(19) = New SqlParameter("@InsuredTo", SqlDbType.VarChar, ad.InsuredTo.Length)
        arParms(19).Value = ad.InsuredTo.Trim
        arParms(20) = New SqlParameter("@InsuredAmt", SqlDbType.Money)
        arParms(20).Value = ad.InsuredAmt

        arParms(21) = New SqlParameter("@PremiumAmt", SqlDbType.Money)
        arParms(21).Value = ad.PremiumAmt

        If ad.DueDate = "01/01/9100" Then
            arParms(22) = New SqlParameter("@InsDueDate", SqlDbType.VarChar)
            arParms(22).Value = System.DBNull.Value
        Else
            arParms(22) = New SqlParameter("@InsDueDate", SqlDbType.DateTime)
            arParms(22).Value = ad.DueDate
        End If


        arParms(23) = New SqlParameter("@InsuredPaidAmt", SqlDbType.Money)
        arParms(23).Value = ad.Insuranceamtpaid


        arParms(24) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("UserCode")

        arParms(25) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(25).Value = HttpContext.Current.Session("EmpCode")

        arParms(26) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(26).Value = HttpContext.Current.Session("BranchCode")

        arParms(27) = New SqlParameter("@AssetType_IDAuto", SqlDbType.Int)
        arParms(27).Value = ad.AssetType

        arParms(28) = New SqlParameter("@Warranty", SqlDbType.VarChar, 2)
        arParms(28).Value = ad.Warranty

        arParms(29) = New SqlParameter("@Warranty_Period", SqlDbType.Int)
        arParms(29).Value = ad.Warrantyp


        arParms(30) = New SqlParameter("@Guaranty", SqlDbType.VarChar, 2)
        arParms(30).Value = ad.Guaranty


        arParms(31) = New SqlParameter("@Guaranty_Period", SqlDbType.Int)
        arParms(31).Value = ad.Guarantyp


        arParms(32) = New SqlParameter("@AMC_To", SqlDbType.VarChar, 100)
        arParms(32).Value = ad.AMC_To


        If ad.AMC_SDate = "01/01/9100" Then
            arParms(33) = New SqlParameter("@AMC_StartDate", SqlDbType.VarChar)
            arParms(33).Value = System.DBNull.Value
        Else
            arParms(33) = New SqlParameter("@AMC_StartDate", SqlDbType.DateTime)
            arParms(33).Value = ad.AMC_SDate
        End If
        If ad.AMC_EDate = "01/01/9100" Then
            arParms(34) = New SqlParameter("@AMC_EndDate", SqlDbType.VarChar)
            arParms(34).Value = System.DBNull.Value
        Else
            arParms(34) = New SqlParameter("@AMC_EndDate", SqlDbType.DateTime)
            arParms(34).Value = ad.AMC_EDate
        End If
        arParms(35) = New SqlParameter("@AMC_Amount", SqlDbType.Money)
        arParms(35).Value = ad.AMC_Amount

        arParms(36) = New SqlParameter("@DRate", SqlDbType.Int)
        arParms(36).Value = ad.DepreciationType

        arParms(37) = New SqlParameter("@Invoice_Value", SqlDbType.Int)
        arParms(37).Value = ad.Invvalue


        If ad.PremiumPaidDate = "01/01/9100" Then
            arParms(38) = New SqlParameter("@Premium_Paid_Date", SqlDbType.VarChar)
            arParms(38).Value = System.DBNull.Value
        Else
            arParms(38) = New SqlParameter("@Premium_Paid_Date", SqlDbType.DateTime)
            arParms(38).Value = ad.PremiumPaidDate
        End If
        arParms(39) = New SqlParameter("@DepreciationType", SqlDbType.Int)
        arParms(39).Value = ad.DesType
        If ad.Registrationdate = "01/01/9100" Then
            arParms(40) = New SqlParameter("@RegistrationDate", SqlDbType.VarChar)
            arParms(40).Value = System.DBNull.Value
        Else
            arParms(40) = New SqlParameter("@RegistrationDate", SqlDbType.DateTime)
            arParms(40).Value = ad.Registrationdate
        End If
        arParms(41) = New SqlParameter("@RegistrationNo", SqlDbType.VarChar, 50)
        arParms(41).Value = ad.RegistrationNo
        'If ad.Grnno = 0 Then
        '    arParms(42) = New SqlParameter("@Grnno", SqlDbType.VarChar, 50)
        '    arParms(42).Value = System.DBNull.Value
        'Else

        arParms(42) = New SqlParameter("@Grnno", SqlDbType.VarChar, 50)
        arParms(42).Value = ad.Grnno

        'End If
        'If ad.Mrnno = 0 Then
        '    arParms(43) = New SqlParameter("@Mrnno", SqlDbType.VarChar, 50)
        '    arParms(43).Value = System.DBNull.Value

        'Else
        arParms(43) = New SqlParameter("@Mrnno", SqlDbType.VarChar, 50)
        arParms(43).Value = ad.Mrnno

        'End If

        arParms(44) = New SqlParameter("@Assetstatus", SqlDbType.Int)
        arParms(44).Value = ad.Assetstatus
        If ad.invoicedate = "01/01/9100" Then
            arParms(45) = New SqlParameter("@InvoiceDate", SqlDbType.VarChar)
            arParms(45).Value = System.DBNull.Value
        Else
            arParms(45) = New SqlParameter("@InvoiceDate", SqlDbType.DateTime)
            arParms(45).Value = ad.invoicedate
        End If


        arParms(46) = New SqlParameter("@Po", SqlDbType.VarChar, 50)
        arParms(46).Value = ad.Po
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveAssetDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function Update(ByVal ad As AssetDetails) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(47) {}

        arParms(0) = New SqlParameter("@AssetName", SqlDbType.VarChar, 50)
        arParms(0).Value = ad.AssetName
        arParms(1) = New SqlParameter("@Price", SqlDbType.Money)
        arParms(1).Value = ad.Bookvalueprice

        arParms(2) = New SqlParameter("@AssetCode", SqlDbType.VarChar, 50)
        arParms(2).Value = ad.AssetCode

        arParms(3) = New SqlParameter("@Supp_Id_Auto", SqlDbType.Int)
        arParms(3).Value = ad.supplier

        arParms(4) = New SqlParameter("@Emp_ID", SqlDbType.VarChar, 50)
        arParms(4).Value = ad.Receivedby

        arParms(5) = New SqlParameter("@ManuFacturerCode", SqlDbType.Int)
        arParms(5).Value = ad.Manufacturer

        arParms(6) = New SqlParameter("@Location", SqlDbType.Int)
        arParms(6).Value = ad.Location

        arParms(7) = New SqlParameter("@MachineSerialNo", SqlDbType.VarChar, 50)
        arParms(7).Value = ad.Machineslno

        arParms(8) = New SqlParameter("@PaymentMethod_Id", SqlDbType.Int)
        arParms(8).Value = ad.Paymentmethod

        arParms(9) = New SqlParameter("@Asset_Photo", SqlDbType.VarChar, 250)
        arParms(9).Value = ad.APhoto

        If ad.purchasedate = "01/01/1900" Then
            arParms(10) = New SqlParameter("@PurchaseDate", SqlDbType.VarChar)
            arParms(10).Value = System.DBNull.Value
        Else
            arParms(10) = New SqlParameter("@PurchaseDate", SqlDbType.DateTime)
            arParms(10).Value = ad.purchasedate
        End If

        arParms(11) = New SqlParameter("@Model_Number", SqlDbType.VarChar, 50)
        arParms(11).Value = ad.Modelno

        arParms(12) = New SqlParameter("@BillType", SqlDbType.VarChar, 50)
        arParms(12).Value = ad.Billtype

        arParms(13) = New SqlParameter("@InvoiceNo", SqlDbType.VarChar, 50)
        arParms(13).Value = ad.invoiceno

        arParms(14) = New SqlParameter("@Brought_by", SqlDbType.VarChar, 50)
        arParms(14).Value = ad.broughtby

        arParms(15) = New SqlParameter("@AmtPaid", SqlDbType.Money)
        arParms(15).Value = ad.amountpaid

        arParms(16) = New SqlParameter("@Description", SqlDbType.VarChar, 500)
        arParms(16).Value = ad.Description

        arParms(17) = New SqlParameter("@Quantity", SqlDbType.VarChar)
        arParms(17).Value = ad.Quantity

        arParms(18) = New SqlParameter("@SentBy", SqlDbType.VarChar, 500)
        arParms(18).Value = ad.sentby

        arParms(19) = New SqlParameter("@InsuredTo", SqlDbType.VarChar, ad.InsuredTo.Length)
        arParms(19).Value = ad.InsuredTo.Trim
        arParms(20) = New SqlParameter("@InsuredAmt", SqlDbType.Money)
        arParms(20).Value = ad.InsuredAmt

        arParms(21) = New SqlParameter("@PremiumAmt", SqlDbType.Money)
        arParms(21).Value = ad.PremiumAmt

        If ad.DueDate = "01/01/9100" Then
            arParms(22) = New SqlParameter("@InsDueDate", SqlDbType.VarChar)
            arParms(22).Value = System.DBNull.Value
        Else
            arParms(22) = New SqlParameter("@InsDueDate", SqlDbType.DateTime)
            arParms(22).Value = ad.DueDate
        End If


        arParms(23) = New SqlParameter("@InsuredPaidAmt", SqlDbType.Money)
        arParms(23).Value = ad.Insuranceamtpaid


        arParms(24) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(24).Value = HttpContext.Current.Session("UserCode")

        arParms(25) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(25).Value = HttpContext.Current.Session("EmpCode")

        arParms(26) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(26).Value = HttpContext.Current.Session("BranchCode")

        arParms(27) = New SqlParameter("@AssetType_IDAuto", SqlDbType.Int)
        arParms(27).Value = ad.AssetType

        arParms(28) = New SqlParameter("@Warranty", SqlDbType.VarChar, 2)
        arParms(28).Value = ad.Warranty

        arParms(29) = New SqlParameter("@Warranty_Period", SqlDbType.Int)
        arParms(29).Value = ad.Warrantyp


        arParms(30) = New SqlParameter("@Guaranty", SqlDbType.VarChar, 2)
        arParms(30).Value = ad.Guaranty


        arParms(31) = New SqlParameter("@Guaranty_Period", SqlDbType.Int)
        arParms(31).Value = ad.Guarantyp


        arParms(32) = New SqlParameter("@AMC_To", SqlDbType.VarChar, 100)
        arParms(32).Value = ad.AMC_To

        If ad.AMC_SDate = "01/01/9100" Then
            arParms(33) = New SqlParameter("@AMC_StartDate", SqlDbType.VarChar)
            arParms(33).Value = System.DBNull.Value
        Else
            arParms(33) = New SqlParameter("@AMC_StartDate", SqlDbType.DateTime)
            arParms(33).Value = ad.AMC_SDate
        End If
        If ad.AMC_EDate = "01/01/9100" Then
            arParms(34) = New SqlParameter("@AMC_EndDate", SqlDbType.VarChar)
            arParms(34).Value = System.DBNull.Value
        Else
            arParms(34) = New SqlParameter("@AMC_EndDate", SqlDbType.DateTime)
            arParms(34).Value = ad.AMC_EDate
        End If
      
        arParms(35) = New SqlParameter("@AMC_Amount", SqlDbType.Money)
        arParms(35).Value = ad.AMC_Amount

        arParms(36) = New SqlParameter("@DRate", SqlDbType.Int)
        arParms(36).Value = ad.DepreciationType

        arParms(37) = New SqlParameter("@AssetDet_Id", SqlDbType.Int)
        arParms(37).Value = ad.Id

        arParms(38) = New SqlParameter("@Invoice_Value", SqlDbType.Int)
        arParms(38).Value = ad.Invvalue


        If ad.PremiumPaidDate = "01/01/9100" Then
            arParms(39) = New SqlParameter("@Premium_Paid_Date", SqlDbType.VarChar)
            arParms(39).Value = System.DBNull.Value
        Else
            arParms(39) = New SqlParameter("@Premium_Paid_Date", SqlDbType.DateTime)
            arParms(39).Value = ad.PremiumPaidDate
        End If
        arParms(40) = New SqlParameter("@DepreciationType", SqlDbType.Int)
        arParms(40).Value = ad.DesType

        If ad.Registrationdate = "01/01/9100" Then
            arParms(41) = New SqlParameter("@RegistrationDate", SqlDbType.VarChar)
            arParms(41).Value = System.DBNull.Value
        Else
            arParms(41) = New SqlParameter("@RegistrationDate", SqlDbType.DateTime)
            arParms(41).Value = ad.Registrationdate
        End If
        arParms(42) = New SqlParameter("@RegistrationNo", SqlDbType.VarChar, 50)
        arParms(42).Value = ad.RegistrationNo
        'If ad.Grnno = 0 Then
        '    arParms(43) = New SqlParameter("@Grnno", SqlDbType.Int)
        '    arParms(43).Value = System.DBNull.Value
        'Else
        arParms(43) = New SqlParameter("@Grnno", SqlDbType.VarChar, 50)
        arParms(43).Value = ad.Grnno

        'End If
        'If ad.Mrnno = 0 Then
        '    arParms(44) = New SqlParameter("@Mrnno", SqlDbType.VarChar, 50)
        '    arParms(44).Value = System.DBNull.Value

        'Else
        arParms(44) = New SqlParameter("@Mrnno", SqlDbType.VarChar, 50)
        arParms(44).Value = ad.Mrnno

        'End If


        arParms(45) = New SqlParameter("@Assetstatus", SqlDbType.Int)
        arParms(45).Value = ad.Assetstatus

        If ad.invoicedate = "01/01/9100" Then
            arParms(46) = New SqlParameter("@InvoiceDate", SqlDbType.VarChar)
            arParms(46).Value = System.DBNull.Value
        Else
            arParms(46) = New SqlParameter("@InvoiceDate", SqlDbType.DateTime)
            arParms(46).Value = ad.invoicedate
        End If

        arParms(47) = New SqlParameter("@Po", SqlDbType.VarChar, 50)
        arParms(47).Value = ad.Po

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateAssetDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected

    End Function

    Shared Function ChangeFlag(ByVal AssetDet_Id As Long) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@AssetDet_Id ", SqlDbType.Int)
        arParms(0).Value = AssetDet_Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteAssetDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetAssetTypescombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetAssetTypeCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAssetTypescomboAll() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetAssetTypeComboAll", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDepreciationTypescombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_Depreciation_RatesDDL", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSuppliercombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_SupplierMasterDDL", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetManufacturercombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetManuFacturerMasterDDL", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPaymentMethodcombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetPaymentMethodCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPaymentMethodcombo1() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetPaymentMethodCombo1", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetPaymentMethodcombo12() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetPaymentMethodCombo12", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetRecievedBy(ByVal prefixText As String) As Data.DataTable

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@prefix", SqlDbType.NVarChar, prefixText.Length)
        Para(2).Value = prefixText

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "SP_GetHOEmpExt", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDuplicateAssetDetails(ByVal EL As AssetDetails) As DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@AssetCode", SqlDbType.VarChar, 50)
        para(0).Value = EL.AssetCode
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = EL.Id
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetDuplicateAssetCode", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetAssetDetailsReport(ByVal AssetType As Integer, ByVal Supplier As Integer, ByVal Manufacturer As Integer, ByVal Grnno As String, ByVal FromDate As String, ByVal ToDate As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@AssetType", SqlDbType.Int)
        arParms(2).Value = AssetType
        arParms(3) = New SqlParameter("@Supplier", SqlDbType.Int)
        arParms(3).Value = Supplier
        arParms(4) = New SqlParameter("@Manufacturer", SqlDbType.Int)
        arParms(4).Value = Manufacturer
        arParms(5) = New SqlParameter("@Grnno", SqlDbType.VarChar, 50)
        arParms(5).Value = Grnno
        arParms(6) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(6).Value = FromDate
        arParms(7) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(7).Value = ToDate

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_AssetDetailsReport", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
    Shared Function GetAssetTransfer(ByVal AssetType As Integer, ByVal AssetName As Integer, ByVal FromDate As String, ByVal ToDate As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@AssetType", SqlDbType.Int)
        arParms(2).Value = AssetType
        arParms(3) = New SqlParameter("@AssetName", SqlDbType.Int)
        arParms(3).Value = AssetName
        arParms(4) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(4).Value = FromDate
        arParms(5) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(5).Value = ToDate
        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_AssetTransfer", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
    Shared Function GetAssetDepreciationTypescombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetAssetDepreciationTypeCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function AssetDep(ByVal ad As AssetDetails) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@DepreciationYear", SqlDbType.Int)
        arParms(1).Value = ad.DepreciationYear

        arParms(2) = New SqlParameter("@DepType", SqlDbType.Int)
        arParms(2).Value = ad.DepreciationType

        arParms(3) = New SqlParameter("@DepRate", SqlDbType.Int)
        arParms(3).Value = ad.DesType

        arParms(4) = New SqlParameter("@id", SqlDbType.Int)
        arParms(4).Value = ad.Id
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_AssetDepRate", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function RptAssetDep(ByVal FrmDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Frmdate", SqlDbType.Date)
        arParms(2).Value = FrmDate

        arParms(3) = New SqlParameter("@Todate", SqlDbType.Date)
        arParms(3).Value = ToDate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_AssetDepreciation", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RptAssetMaintenance(ByVal assetType As Integer, ByVal AssetName As Integer, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(3).Value = ToDate

        arParms(4) = New SqlParameter("@AssetType", SqlDbType.Int)
        arParms(4).Value = assetType

        arParms(5) = New SqlParameter("@AssetName", SqlDbType.Int)
        arParms(5).Value = AssetName


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_AssetMaintenance", arParms)
        Return ds.Tables(0)

    End Function



    'Shared Function DisplayGridValue(ByVal a As AssetDetails) As Data.DataTable
    '    'modified by abhishek garg on 23-feb-2012
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}

    '    arParms(0) = New SqlParameter("@assetid", SqlDbType.Int)
    '    arParms(0).Value = a.AssetId

    '    arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    arParms(1).Value = HttpContext.Current.Session("Office")

    '    arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(2).Value = HttpContext.Current.Session("BranchCode")

    '    arParms(3) = New SqlParameter("@assettype", SqlDbType.Int)
    '    arParms(3).Value = a.AssetType

    '    arParms(4) = New SqlParameter("@supplier", SqlDbType.Int)
    '    arParms(4).Value = a.SupplierId

    '    arParms(5) = New SqlParameter("@purchasedate", SqlDbType.DateTime)
    '    arParms(5).Value = a.PurchaseDate

    '    arParms(6) = New SqlParameter("@quantity", SqlDbType.Float)
    '    arParms(6).Value = a.Quantity

    '    arParms(7) = New SqlParameter("@price", SqlDbType.Float)
    '    arParms(7).Value = a.Price

    '    arParms(8) = New SqlParameter("@remarks", SqlDbType.VarChar, 50)
    '    arParms(8).Value = a.Remarks

    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAssetDetails", arParms)
    '    Return ds.Tables(0)
    'End Function
    'Shared Function GetMaxAssetDetID() As Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAsetDetlsId")
    '    Return ds.Tables(0)
    'End Function
    'Shared Function GetReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As System.Data.DataTable

    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}

    '    arParms(0) = New SqlParameter("@instituteid", SqlDbType.Int)
    '    arParms(0).Value = instituteid

    '    arParms(1) = New SqlParameter("@branchid", SqlDbType.Int)
    '    arParms(1).Value = branchid

    '    arParms(2) = New SqlParameter("@assettype", SqlDbType.Int)
    '    arParms(2).Value = assettype

    '    arParms(3) = New SqlParameter("@asset", SqlDbType.Int)
    '    arParms(3).Value = asset

    '    Dim ds As DataSet
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AssetDetailsReport", arParms)
    '    Return ds.Tables(0)

    'End Function


    '    Shared Function GetAssetDetailsByAssetId(ByVal assetid As Long) As System.Data.DataSet
    '        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '        Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionString)
    '        Dim queryString As String
    '        If assetid = 0 Then
    '            queryString = "SELECT AssetDetails.AssetDet_Id, AssetDetails.Asset_Id, AssetDetails.Branch_Id, AssetDetails.Institute_Id,AssetDetails.Supp_Id,AssetDetails.ManuFacturer,AssetDetails.PurchaseDate,AssetDetails.EntryDate,AssetDetails.TransferDate,AssetDetails.Quantity,AssetDetails.Price FROM(AssetDetails)WHERE (((AssetDetails.Del_Flag)=0))"
    '        Else
    '            queryString = "SELECT AssetDetails.AssetDet_Id, AssetDetails.Asset_Id, AssetDetails.Branch_Id, AssetDetails.Institute_Id,AssetDetails.Supp_Id,AssetDetails.ManuFacturer,AssetDetails.PurchaseDate,AssetDetails.EntryDate,AssetDetails.TransferDate,AssetDetails.Quantity,AssetDetails.Price FROM(AssetDetails)WHERE (((AssetDetails.Del_Flag)=0)AND((AssetDetails.Asset_Id)=@assetid))"
    '        End If
    '        Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '        dbCommand.CommandText = queryString
    '        dbCommand.Connection = dbConnection
    '        If Not (assetid = 0) Then
    '            Dim dbParam_assetid As System.Data.IDataParameter = New System.Data.OleDb.OleDbParameter
    '            dbParam_assetid.ParameterName = "@assetid"
    '            dbParam_assetid.Value = assetid
    '            dbParam_assetid.DbType = System.Data.DbType.Int64
    '            dbCommand.Parameters.Add(dbParam_assetid)
    '        End If
    '        Dim dataAdapter As System.Data.IDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
    '        dataAdapter.SelectCommand = dbCommand
    '        Dim dataSet As System.Data.DataSet = New System.Data.DataSet
    '        dataAdapter.Fill(dataSet)
    '        Return dataSet
    '    End Function
    'Private Shared Function ManageParameters(ByVal ad As AssetDetails) As System.Data.OleDb.OleDbCommand
    '    Dim queryString As String = "INSERT INTO AssetDetails (Asset_Id,Branch_Id,Institute_Id,ManuFacturer,EntryDate,TransferDate,Quantity,Price)SELECT @assetid,@branchid,@instituteid,@manufacturer,@entrydate,@transferdate,@quantity,@price"
    '    Dim dbCommand As System.Data.IDbCommand = New System.Data.OleDb.OleDbCommand
    '    dbCommand.CommandText = queryString

    '    Dim dbParam_assetid As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_assetid.ParameterName = "@assetid"
    '    dbParam_assetid.Value = ad.AssetId
    '    dbParam_assetid.DbType = System.Data.DbType.[Int64]
    '    dbCommand.Parameters.Add(dbParam_assetid)

    '    Dim dbParam_branchid As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_branchid.ParameterName = "@branchid"
    '    dbParam_branchid.Value = ad.BranchId
    '    dbParam_branchid.DbType = System.Data.DbType.[Int64]
    '    dbCommand.Parameters.Add(dbParam_branchid)

    '    Dim dbParam_instituteid As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_instituteid.ParameterName = "@instituteid"
    '    dbParam_instituteid.Value = ad.InstituteId
    '    dbParam_instituteid.DbType = System.Data.DbType.[Int64]
    '    dbCommand.Parameters.Add(dbParam_instituteid)

    '    Dim dbParam_manufacturer As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_manufacturer.ParameterName = "@manufacturer"
    '    dbParam_manufacturer.Value = ad.Manufacturer
    '    dbParam_manufacturer.DbType = System.Data.DbType.[String]
    '    dbCommand.Parameters.Add(dbParam_manufacturer)

    '    Dim dbParam_entrydate As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_entrydate.ParameterName = "@entrydate"
    '    dbParam_entrydate.Value = ad.EntryDate
    '    dbParam_entrydate.DbType = System.Data.DbType.[Date]
    '    dbCommand.Parameters.Add(dbParam_entrydate)

    '    Dim dbParam_transferdate As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_transferdate.ParameterName = "@transferdate"
    '    dbParam_transferdate.Value = ad.TransferDate
    '    dbParam_transferdate.DbType = System.Data.DbType.[Date]
    '    dbCommand.Parameters.Add(dbParam_transferdate)

    '    Dim dbParam_quantity As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_quantity.ParameterName = "@quantity"
    '    dbParam_quantity.Value = ad.Quantity
    '    dbParam_quantity.DbType = System.Data.DbType.[Int32]
    '    dbCommand.Parameters.Add(dbParam_quantity)

    '    Dim dbParam_price As System.Data.IDbDataParameter = New System.Data.OleDb.OleDbParameter
    '    dbParam_price.ParameterName = "@price"
    '    dbParam_price.Value = ad.Price
    '    dbParam_price.DbType = System.Data.DbType.[Int64]
    '    dbCommand.Parameters.Add(dbParam_price)

    '    Return dbCommand
    'End Function
    'Shared Sub InsertTransfer(ByVal ad1 As AssetDetails, ByVal ad2 As AssetDetails)
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    '    Dim dbConnection As System.Data.IDbConnection = New System.Data.OleDb.OleDbConnection(connectionString)
    '    Dim dbCommand1 As System.Data.OleDb.OleDbCommand = AssetDetailsDB.ManageParameters(ad1)
    '    Dim dbCommand2 As System.Data.OleDb.OleDbCommand = AssetDetailsDB.ManageParameters(ad2)
    '    dbCommand1.Connection = dbConnection
    '    dbCommand2.Connection = dbConnection
    '    dbConnection.Open()

    '    Dim transaction As OleDbTransaction = dbConnection.BeginTransaction()
    '    Try
    '        dbCommand1.ExecuteNonQuery()
    '        dbCommand2.ExecuteNonQuery()
    '        transaction.Commit()
    '    Catch ex As Exception
    '        transaction.Rollback()
    '    Finally
    '        dbConnection.Close()
    '    End Try
    'End Sub
    'Partial Public Class AssetDetailsTableAdapter
    '    Dim newidd As Integer
    '    Public Function InsertRecord_Details(ByVal AssetType As Int32, ByVal Asset_Id As Int32, ByVal Branch_Id As Int32, ByVal Institute_Id As Int32, ByVal Supp_Id As Int32, ByVal ManuFacturer_Id As Int32, ByVal InvoiceNo As String, ByVal PurchaseDate As Date, ByVal EntryDate As Date, ByVal Quantity As Double, ByVal Price As Double, ByVal Model_Number As String, ByVal Brought_by As String, ByVal AmtPaid As Double, ByVal BillType As String, ByVal PaymentMethod_Id As Int32, ByVal Total_Value As Double, ByVal Serial_No As String, ByVal Description As String, ByVal Location As String, ByVal Remarks As String, ByVal From1 As String, ByVal To1 As String, ByVal MotorNo As String) As Integer
    '        Dim assetdetails As New GlobalDataSet.AssetDetailsDataTable
    '        Dim newdetails As GlobalDataSet.AssetDetailsRow = assetdetails.NewAssetDetailsRow()
    '        newdetails.AssetType = AssetType
    '        newdetails.Asset_Id = Asset_Id
    '        newdetails.Branch_Id = Branch_Id
    '        newdetails.Institute_Id = Institute_Id
    '        newdetails.Supp_Id = Supp_Id
    '        newdetails.ManuFacturer_Id = ManuFacturer_Id
    '        newdetails.InvoiceNo = InvoiceNo
    '        newdetails.PurchaseDate = PurchaseDate
    '        newdetails.EntryDate = EntryDate
    '        newdetails.Quantity = Quantity
    '        newdetails.Price = Price
    '        newdetails.Model_Number = Model_Number
    '        newdetails.Remarks = Remarks
    '        newdetails.From1 = From1
    '        newdetails.To1 = To1
    '        newdetails.Brought_by = Brought_by
    '        newdetails.AmtPaid = AmtPaid
    '        newdetails.BillType = BillType
    '        newdetails.PaymentMethod_Id = PaymentMethod_Id
    '        newdetails.Total_Value = Total_Value
    '        newdetails.Location = Location
    '        newdetails.Serial_No = Serial_No
    '        newdetails.Description = Description
    '        newdetails.MotorNo = MotorNo
    '        assetdetails.AddAssetDetailsRow(newdetails)
    '        Me.Adapter.Update(assetdetails)
    '        Return newidd
    '    End Function
    '    Public Function InsertRecord_Details1(ByVal AssetType As Int32, ByVal Asset_Id As Int32, ByVal Branch_Id As Int32, ByVal Institute_Id As Int32, ByVal Supp_Id As Int32, ByVal ManuFacturer_Id As Int32, ByVal InvoiceNo As String, ByVal PurchaseDate As Date, ByVal EntryDate As Date, ByVal Quantity As Double, ByVal Price As Double, ByVal Model_Number As String, ByVal Brought_by As String, ByVal AmtPaid As Double, ByVal BillType As String, ByVal PaymentMethod_Id As Int32, ByVal Total_Value As Double, ByVal Serial_No As String, ByVal Description As String, ByVal Location As String, ByVal Remarks As String, ByVal From1 As String, ByVal To1 As String) As Integer
    '        Dim assetdetails As New GlobalDataSet.AssetDetailsDataTable
    '        Dim newdetails As GlobalDataSet.AssetDetailsRow = assetdetails.NewAssetDetailsRow()
    '        newdetails.AssetType = AssetType
    '        newdetails.Asset_Id = Asset_Id
    '        newdetails.Branch_Id = Branch_Id
    '        newdetails.Institute_Id = Institute_Id
    '        newdetails.Supp_Id = Supp_Id
    '        newdetails.ManuFacturer_Id = ManuFacturer_Id
    '        newdetails.InvoiceNo = InvoiceNo
    '        newdetails.PurchaseDate = PurchaseDate
    '        newdetails.EntryDate = EntryDate
    '        newdetails.Quantity = Quantity
    '        newdetails.Price = Price
    '        newdetails.Model_Number = Model_Number
    '        newdetails.Remarks = Remarks
    '        newdetails.From1 = From1
    '        newdetails.To1 = To1
    '        newdetails.Brought_by = Brought_by
    '        newdetails.AmtPaid = AmtPaid
    '        newdetails.BillType = BillType
    '        newdetails.PaymentMethod_Id = PaymentMethod_Id
    '        newdetails.Total_Value = Total_Value
    '        newdetails.Location = Location
    '        newdetails.Serial_No = Serial_No
    '        newdetails.Description = Description
    '        assetdetails.AddAssetDetailsRow(newdetails)
    '        Me.Adapter.Update(assetdetails)
    '        Return newidd
    '    End Function
    'End Class
    'End Namespace
    Shared Function Getdeptcombo() As DataTable
        'Nitin. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DepartmentComboforAssetDetails", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAssetStaus() As DataTable
        'Nitin. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_AssetStatuscombo", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetGRNNo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetGRN", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetItemddl() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetItemDDL", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class