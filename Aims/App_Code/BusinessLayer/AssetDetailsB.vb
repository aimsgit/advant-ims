Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class AssetDetailsB
    Public Function GetAssetDetails(ByVal ad As AssetDetails) As Data.DataTable
        'Dim assetd As New List(Of AssetDetails)
        'Dim ds As DataSet = AssetDetailsDB.GetAssetDetails(AssetDet_Id)
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    assetd.Add(New AssetDetails(row("AssetDet_Id"), row("Asset_Id"), row("Branch_Id"), row("Institute_Id"), row("Supp_Id"), row("ManuFacturer_Id"), row("InvoiceNo"), row("PurchaseDate"), row("EntryDate"), row("Quantity"), row("Price"), row("Total_Value"), row("Description"), row("Model_Number"), row("Location"), row("Serial_No"), row("Brought_by"), row("AssetType"), row("AmtPaid"), row("BillType"), row("PaymentMethod_Id"), row("Remarks"), row("From1"), row("To1"), row("MotorNo"), row("PremiumAmt"), row("InsuredAmt"), row("PaidAmt"), row("InsDueDate"), row("InsuredTo")))
        'Next
        Return AssetDetailsDB.GetAssetDetails(ad)
    End Function
    Public Function DType(ByVal ad As AssetDetails) As Data.DataTable

        Return AssetDetailsDB.DType(ad)
    End Function
    'Public Function GetAssetDetails() As List(Of AssetDetails)
    '    Dim assetd As New List(Of AssetDetails)
    '    Dim ds As DataSet = AssetDetailsDB.GetAssetDetails(0)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        assetd.Add(New AssetDetails(row("AssetDet_Id"), row("Asset_Id"), row("Branch_Id"), row("Institute_Id"), row("Supp_Id"), row("ManuFacturer_Id"), row("InvoiceNo"), row("PurchaseDate"), row("EntryDate"), row("Quantity"), row("Price"), row("Total_Value"), row("Description"), row("Model_Number"), row("Location"), row("Serial_No"), row("Brought_by"), row("AssetType"), row("AmtPaid"), row("BillType"), row("PaymentMethod_Id"), row("Remarks"), row("From1"), row("To1"), row("MotorNo"), row("PremiumAmt"), row("InsuredAmt"), row("PaidAmt"), row("InsDueDate"), row("InsuredTo")))
    '    Next
    '    Return assetd
    'End Function
    Public Function InsertRecord(ByVal a As AssetDetails) As Integer
        Return AssetDetailsDB.Insert(a)
    End Function
    Public Function UpdateRecord(ByVal a As AssetDetails) As Integer
        Return AssetDetailsDB.Update(a)
    End Function
    Public Function ChangeFlag(ByVal AssetDet_Id As Long) As Integer
        Return AssetDetailsDB.ChangeFlag(AssetDet_Id)
    End Function
    'Public Function Display(ByVal a As AssetDetails) As Data.DataTable
    '    Return AssetDetailsDB.DisplayGridValue(a)
    'End Function
    'Public Function GetMaxAssetDetls() As Data.DataTable
    '    Return AssetDetailsDB.GetMaxAssetDetID
    'End Function
    'Public Function GetReport(ByVal instituteid As Int64, ByVal branchid As Int64, ByVal assettype As Int64, ByVal asset As Int64) As Data.DataTable
    '    Return AssetDetailsDB.GetReport(instituteid, branchid, assettype, asset)
    'End Function
    Public Function GetAssetTypescombo() As Data.DataTable
        Return AssetDetailsDB.GetAssetTypescombo()
    End Function
    Public Function GetDepreciationTypescombo() As Data.DataTable
        Return AssetDetailsDB.GetDepreciationTypescombo()
    End Function
    Public Function GetSuppliercombo() As Data.DataTable
        Return AssetDetailsDB.GetSuppliercombo()
    End Function
    Public Function GetManufacturercombo() As Data.DataTable
        Return AssetDetailsDB.GetManufacturercombo()
    End Function
    Public Function GetPaymentMethodcombo() As Data.DataTable
        Return AssetDetailsDB.GetPaymentMethodcombo()
    End Function
    Public Function GetDuplicateAssetDetails(ByVal EL As AssetDetails) As DataTable
        Return AssetDetailsDB.GetDuplicateAssetDetails(EL)
    End Function
End Class
