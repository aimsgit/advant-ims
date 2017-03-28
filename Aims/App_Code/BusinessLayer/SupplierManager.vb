Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class SupplierManager
    Public Function InsertRecord(ByVal SE As Supplier) As Integer
        Return SupplierDB.Insert(SE)
    End Function
    Public Function UpdateRecord(ByVal SE As Supplier) As Integer
        Return SupplierDB.Update(SE)
    End Function
    Public Function DeleteRecord(ByVal id As Long) As Integer
        Return SupplierDB.Delete(id)
    End Function
    Public Function GetSupplierDetails(ByVal se As Supplier) As System.Data.DataTable
        Return SupplierDB.GridviewDetails(se)
    End Function
    Public Function GetAreaCobmo() As DataTable
        Return SupplierDB.GetAreaCobmo()
    End Function
    Public Function GetSECobmo() As DataTable
        Return SupplierDB.GetSECobmo()
    End Function
    Public Function GetSupplierDetailsRpt() As System.Data.DataTable
        Dim ds As DataSet = SupplierDB.SupplierDetailsRpt()
        Return ds.Tables(0)
    End Function
    'Public Function GetSupplierDetailsById(ByVal Suppid As Integer) As Supplier
    '    Dim suppEdit As Supplier
    '    Dim ds As DataSet = SupplierDB.GridviewDetails(Suppid)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    suppEdit = New Supplier(row("Supp_Name"), row("Supp_Code"), row("Supp_Address"), row("Contact_Person"), row("Contact_Number1"), row("Credit_Period"), row("Credit_Limit"), row("Opening_Balance_CR"), row("Opening_Balance_DR"), row("OpBalanceDate"), row("Supp_ID"))
    '    Return suppEdit
    'End Function

    Public Function GetSuppComboDB(ByVal id As Int32) As List(Of DayBookPartyName)
        Dim em As New List(Of DayBookPartyName)
        Dim ds As DataSet = SupplierDB.GetSuppComboDayBook(0)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        For Each row In ds.Tables(0).Rows
            em.Add(New DayBookPartyName(row("Name"), row("Id")))
        Next
        Return em
    End Function
    Public Function GetSuppComboDBID(ByVal id As Int32) As DayBookPartyName
        Dim em As DayBookPartyName
        Dim ds As DataSet = SupplierDB.GetSuppComboDayBook(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        em = New DayBookPartyName(row("Name"), row("Id"))
        Return em
    End Function
    Public Function GetDuplicateSupplierMaster(ByVal SE As Supplier) As DataTable
        Return SupplierDB.GetSuppDuplicateType(SE)
    End Function
    Public Function GetReport(ByVal insID As Int64, ByVal brnID As Int64) As Data.DataTable
        Return SupplierDB.GetReport(insID, brnID)
    End Function

End Class
