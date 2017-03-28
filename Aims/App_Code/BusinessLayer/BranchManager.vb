Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BranchManager
    Public Function FillHO() As DataSet
        Dim ds As DataSet
        ds = DLBranchDB.FillHo()
        Return ds
    End Function
    Public Function FillBranchType() As DataSet
        Dim ds As DataSet
        ds = DLBranchDB.FillBranchType()
        Return ds
    End Function
    Public Function GetRptBrnId(ByVal code As String, ByVal HO As String) As Data.DataTable
        Try
            Dim ds As DataSet = DLBranchDB.GetRptBrnId(code, HO)
            Return ds.Tables(0)
        Catch ex As Exception

        End Try
    End Function
    
    Public Function GetAllDistrict() As List(Of BranchCombo)
        Dim Bran As New List(Of BranchCombo)
        Dim ds As DataSet = DLBranchDB.GetDistrict()
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            Bran.Add(New BranchCombo(row("DistrictCode"), row("DistrictName")))
        Next
        Return Bran
    End Function
    'Public Function GetBranch() As DataSet
    '    Dim branch As New List(Of Branch)
    '    Dim ds As DataSet = DLBranchDB.GetBranch(0)
    '    Dim row As DataRow
    '    'For Each row In ds.Tables(0).Rows
    '    '    branch.Add(New Branch(row("Branch_ID"), row("BranchName"), row("BranchCode"), row("SlssbCode"), row("Address"), row("ContactNo"), row("DistrictCode"), row("HOCode"), row("BranchTypeCode"), row("ReportBrnCode"), row("ContactPersonCode"), row("Designation"), row("AccountNo"), row("BankCode"), row("BankBranch")))
    '    'Next
    '    Return ds
    'End Function
    Public Function GetBranchByBranchId(ByVal branchid As Long, ByVal code As String) As System.Data.DataTable
        Dim ds As DataSet = DLBranchDB.GetBranch(branchid, code)
        Return ds.Tables(0)
    End Function
    Public Function GetBrType(ByVal code As String) As System.Data.DataTable
        Return DLBranchDB.GetBrType(code)
    End Function
    Public Function GetBrTypeCode(ByVal code As String) As System.Data.DataTable
        Return DLBranchDB.GetBrTypeCode(code)
    End Function
    Public Function InsertRecord(ByVal b As Branch) As Integer
        If b.Address = Nothing Then
            b.Address = ""
        End If
        If b.SSBCode = Nothing Then
            b.SSBCode = ""
        End If
        If b.Name = Nothing Then
            b.Name = ""
        End If
        If b.ContactNo = Nothing Then
            b.ContactNo = ""
        End If
        Return DLBranchDB.Insert(b)
    End Function
    Public Function UpdateRecord(ByVal b As Branch) As Integer
        If b.Address = Nothing Then
            b.Address = ""
        End If
        If b.SSBCode = Nothing Then
            b.SSBCode = ""
        End If
        If b.Name = Nothing Then
            b.Name = ""
        End If
        If b.ContactNo = Nothing Then
            b.ContactNo = ""
        End If
        If b.ContactNo = Nothing Then
            b.ContactNo = ""
        End If
        Return DLBranchDB.Update(b)
    End Function
    Public Function ChangeFlag(ByVal b As Branch) As Integer
        Dim Status As Boolean
        'Status = globalcnn.Del_Validation(b.Id, "Branch")
        If (Status) = True Then
            Return 0
        Else
            Return DLBranchDB.ChangeFlag(b.Id)
        End If
    End Function
    Public Function GetBranchByUID() As Data.DataTable
        Return BranchDB.FillBranchByUID()
    End Function
    Public Function FillBranchCenter() As Data.DataTable
        Return BranchDB.FillBranchCenter()
    End Function
    Public Function GetBranchCombo() As System.Data.DataTable
        Return DLBranchDB.GetBranchCombo()
    End Function
End Class
