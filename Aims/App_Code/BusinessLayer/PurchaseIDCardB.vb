Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Public Class PurchaseIDCardB
    ' Dim Dal As New PurchaseIDCardDB

    Public Function GetPurchaseIDCard(ByVal el As PurchaseIDCard) As Data.DataTable
        Return PurchaseIDCardDB.GetPurchaseIDCard(el)
    End Function
   
    Public Function InsertRecord(ByVal el As PurchaseIDCard) As Integer
        Return PurchaseIDCardDB.Insert(el)
    End Function
    Public Function UpdateRecord(ByVal el As PurchaseIDCard) As Integer
        Return PurchaseIDCardDB.Update(el)
    End Function
    Public Function ChangeFlag(ByVal id As Integer) As Integer
        Return PurchaseIDCardDB.ChangeFlag(id)
    End Function
    Public Function CheckDuplicate(ByVal el As PurchaseIDCard) As Data.DataTable
        Return PurchaseIDCardDB.CheckDuplicate(el)
    End Function
End Class
