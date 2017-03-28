Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class EnquiryManager
    Public Function GetEnquiryDuplicate(ByVal e As Enquiry) As Data.DataTable
        Return EnquiryDB.GetEnquiryDuplicate(e)
    End Function
    Public Function GetEnquiry(ByVal e As Enquiry) As Data.DataTable
        Return EnquiryDB.GetEnquiry(e)
    End Function
    Public Function GetCriteria() As Data.DataTable
        Return EnquiryDB.GetCriteria()
    End Function
    Public Function GetCriteriavalue(ByVal Criteria_Name As String) As Data.DataTable
        Return EnquiryDB.GetCriteriaValue(Criteria_Name)
    End Function
    Public Function GetAddEnquiry(ByVal e As String) As Data.DataTable
        Return EnquiryDB.GetAddEnquiry(e)
    End Function
    Public Function GetState2(ByVal Country As String) As Data.DataTable
        Return EnquiryDB.GetState2(Country)
    End Function
    Public Function InsertRecord(ByVal e As Enquiry) As Integer
        Return EnquiryDB.Insert(e)
    End Function
   
    Public Function UpdateRecord(ByVal e As Enquiry) As Integer
        Return EnquiryDB.Update(e)
    End Function
    Public Function ChangeFlag(ByVal e As Enquiry, ByVal Branchid As String) As Integer
        Return EnquiryDB.ChangeFlag(e.Id, Branchid)
    End Function
    Public Function Display(ByVal Fname As String, ByVal BranchCode As String, ByVal AdmitFlag As String) As Data.DataTable
        Return EnquiryDB.DisplayGridValue(Fname, BranchCode, AdmitFlag)
    End Function
    Public Function EnquiryEdit(ByVal id As Int64) As Data.DataTable
        Return EnquiryDB.EnquiryEditData(id)
    End Function
    Public Function DelEnqDtls(ByVal e As Enquiry, ByVal Branchid As String) As Integer
        Return EnquiryDB.DelEnq(e.Id, Branchid)
    End Function
    Public Function GetEnqNo() As Data.DataTable
        Return EnquiryDB.GetEnqNo()
    End Function
    Public Function Details(ByVal enq As Long) As Data.DataTable
        Return EnquiryDB.Details(enq)
    End Function
    Public Function GetState(ByVal StateId As Long) As List(Of State)
        Dim st As New List(Of State)
        Dim ds As DataSet = EnquiryDB.GetState(StateId)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            st.Add(New State(row("StateId"), row("StateName")))
        Next
        Return st
    End Function
    'Public Function GetState1(ByVal e As Enquiry) As List(Of State)
    '    Dim st As New List(Of State)
    '    Dim ds As DataSet = EnquiryDB.GetState1(e)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        st.Add(New State(row("StateId"), row("StateName")))
    '    Next
    '    Return st
    'End Function
    Public Function getCountry() As Data.DataTable
        Dim ds As DataTable = EnquiryDB.getCountry()
        Return ds
    End Function
    Public Function getDistrict(ByVal e As Enquiry) As Data.DataTable
        Dim ds As DataTable = EnquiryDB.getDistrict(e)
        Return ds
    End Function
    Public Function GetStateid(ByVal StateId As Long) As State
        Dim State As State
        Dim ds As DataSet = EnquiryDB.GetState(StateId)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        State = New State(row("StateId"), row("StateName"))
        Return State
    End Function
End Class
