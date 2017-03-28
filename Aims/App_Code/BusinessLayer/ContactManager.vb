Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Public Class ContactManager
    Public Function GetContact(ByVal id As Long) As List(Of Contact)
        Dim contact As New List(Of Contact)
        Dim ds As DataSet = ContactDB.GVDetails(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            contact.Add(New Contact(row("ContactId"), row("FirstName"), row("LastName"), row("Address"), row("City"), row("State"), row("PostalCode")))
        Next
        Return contact
    End Function
    Public Function GetContact() As List(Of Contact)
        Dim contact As New List(Of Contact)
        Dim ds As DataSet = ContactDB.GVDetails(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            contact.Add(New Contact(row("ContactId"), row("FirstName"), row("LastName"), row("Address"), row("City"), row("State"), row("PostalCode")))
        Next
        Return contact
    End Function
    Public Function GetContactByID(ByVal contactID As Long) As Contact
        Dim contact As Contact
        Dim ds As DataSet = ContactDB.GVDetails(contactID)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        contact = New Contact(row("ContactId"), row("FirstName"), row("LastName"), row("Address"), row("City"), row("State"), row("PostalCode"))
        Return contact
    End Function
    Public Function InsertRecord(ByVal c As Contact) As Integer
        Return ContactDB.Insert(c)
    End Function
    Public Function UpdateRecord(ByVal c As Contact) As Integer
        Return ContactDB.Insert(c)
    End Function
    Public Function DeleteRecord(ByVal c As Contact) As Integer
        Return ContactDB.Delete(c.ContactId)
    End Function
End Class
