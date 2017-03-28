Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class CompanyManager
    Public Function GetCompany(ByVal id As Long) As List(Of Company)
        Dim company As New List(Of Company)
        Dim ds As DataSet = CompanyDB.GetCompany(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            company.Add(New Company(row("PCId"), row("PCName"), row("PCCntPerson"), row("PCCntNo"), row("PCAdd")))
        Next
        Return company
    End Function
    Public Function GetCompany() As List(Of Company)
        Dim company As New List(Of Company)
        Dim ds As DataSet = CompanyDB.GetCompany(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            company.Add(New Company(row("PCId"), row("PCName"), row("PCCntPerson"), row("PCCntNo"), row("PCAdd")))
        Next
        Return company
    End Function
    Public Function InsertRecord(ByVal c As Company) As Integer
        If c.ContactPerson = Nothing Then
            c.ContactPerson = ""
        End If
        Return CompanyDB.Insert(c)
    End Function
    Public Function UpdateRecord(ByVal c As Company) As Integer
        If c.ContactPerson = Nothing Then
            c.ContactPerson = ""
        End If
        Return CompanyDB.Update(c)
    End Function
    Public Function ChangeFlag(ByVal c As Company) As Integer
        Return CompanyDB.ChangeFlag(c.Id)
    End Function
    Public Function DelVal(ByVal id) As Data.DataTable
        Return CompanyDB.DeleteValidation(id)
    End Function
    Public Function RptCompany(ByVal insID As Int64, ByVal brnID As Int64) As Data.DataTable
        Return CompanyDB.RptCompany(insID, brnID)
    End Function
    'Code for get Company Master Report By Nitin 07/05/2012
    Public Function RptCompanyMaster(ByVal insID As Int64, ByVal brnID As Int64) As Data.DataTable
        Return CompanyDB.RptCompanyMaster(insID, brnID)
    End Function
End Class
