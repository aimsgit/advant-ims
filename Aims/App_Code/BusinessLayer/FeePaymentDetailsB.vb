Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
Imports System.Collections.Generic
Imports System.Data

Public Class FeePaymentDetailsB
    Public Function GetStd(ByVal insId As Int64, ByVal brnId As Int64, ByVal crsId As Int64, ByVal batchId As Int64) As Data.DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.GetStd(insId, brnId, crsId, batchId)
    End Function
    Public Function GetFeeStructureId(ByVal batchId As Int64, ByVal semsterId As Int64) As Data.DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.GetFeeStructureId(batchId, semsterId)
    End Function
    Public Function GetStdName(ByVal stdId As Int64) As DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.GetStdName(stdId)
    End Function
    Public Function GetFeeStructureByID(ByVal Id As Int64) As Data.DataTable
        Dim DAL As New FeeStructureDB
        Return DAL.GetFeeStructureByID(Id)
    End Function
    Public Function FillGrid(ByVal Batch As Int64, ByVal crsID As Int64, ByVal stdID As Int64, ByVal semID As Int64) As Data.DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.FillGrid(Batch, crsID, stdID, semID)
    End Function
    Public Function GetReport(ByVal Batch As Int64, ByVal Feestructure_id As Int64) As Int32
        Dim DAL As New FeeDetailsDB
        Return DAL.GetReport(Batch, Feestructure_id)
    End Function
    Public Function Insert(ByVal prop As FeePaymentDetails) As Int64
        Dim DAL As New FeeDetailsDB
        Return DAL.FeeDetailsInsert(prop)
    End Function
    Public Function Update(ByVal Prop As FeePaymentDetails) As Int16
        Dim DAL As New FeeDetailsDB
        Return DAL.Update(Prop)
    End Function
    Public Function GetUpdate(ByVal ID As Int64) As Data.DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.GetUpdate(ID)
    End Function
    Public Function rptReceipt(ByVal Stid As String, ByVal ID As String) As Data.DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.getReceipt(Stid, ID)
    End Function
    Public Function Receipt(ByVal Department As Integer, ByVal FromReceipt As Integer, ByVal ToReceipt As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal Radio As String) As Data.DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.Receipt(Department, FromReceipt, ToReceipt, StartDate, EndDate, Radio)
    End Function

    Public Function getAdhocFeeReceipt(ByVal Stid As String, ByVal ID As String) As Data.DataTable
        Dim DAL As New FeeDetailsDB
        Return DAL.getAdhocFeeReceipt(Stid, ID)
    End Function
    Public Function GetsElfDetails() As Data.DataTable
        Return selfdetailsDB.GetDeatils(0).Tables(0)
    End Function
    Public Function GetGrid(ByVal crsId As Int64, ByVal batchId As Int64, ByVal semsterId As Int16, ByVal stdId As Int64) As Data.DataTable
        Dim DAL As New GlobalDataSetTableAdapters.FeeDetailsDB
        Return DAL.GetGrid(crsId, batchId, semsterId, stdId)
    End Function
    'Public Function PaymentMethode() As DataTable
    '    Dim DAL As New FeeDetailsDB
    '    Return DAL.Payment_Methode()
    'End Function
    Private _attendanceAdapter As Fee_DetailsTableAdapter = Nothing
    Public ReadOnly Property Adapter() As Fee_DetailsTableAdapter
        Get
            If _attendanceAdapter Is Nothing Then
                _attendanceAdapter = New Fee_DetailsTableAdapter
            End If
            Return _attendanceAdapter
        End Get
    End Property
    'Public Function UpdateWithTransaction(ByVal FeeDetails As GlobalDataSet.Fee_DetailsDataTable) As Integer
    '    Return Adapter.UpdateWithTransaction(FeeDetails)
    'End Function
    Public Function Delete(ByVal id As Int64) As Int16
        Dim DAL As New FeeDetailsDB
        Return DAL.Delete(id)
    End Function
    'Protected Function GetPaymentMode(ByVal PaymentMethodID As Long) As List(Of FeeStructure)
    '    Dim pobj As New FeePaymentDetailsB
    '    Dim py As FeeStructure = pobj.GetPaymentid(PaymentMethodID)
    '    Return py.Name
    'End Function
    Public Function GetPaymentMode(ByVal PaymentMethodID As Long) As List(Of FeePaymentDetails)
        Dim py As New List(Of FeePaymentDetails)
        Dim ds As DataSet = FeeDetailsDB.GetPaymentMode(PaymentMethodID)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            py.Add(New FeePaymentDetails(row("PaymentMethodID"), row("Payment_Method")))
        Next
        Return py
    End Function
    Public Function GetPaymentid(ByVal PaymentMethodID As Long) As FeePaymentDetails
        Dim FeePaymentDetails As FeePaymentDetails
        Dim ds As DataSet = FeeDetailsDB.GetPaymentMode(PaymentMethodID)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        FeePaymentDetails = New FeePaymentDetails(row("PaymentMethodID"), row("Payment_Method"))
        Return FeePaymentDetails
    End Function
End Class
