Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class AccountHeadManager
    'Public Function GetAccountHeadSubGrp(ByVal id As Long) As DataTable
    '    Dim ds As DataSet = AccountHeadDB.GetAccountHead(id)
    '    Return ds.Tables(0)
    'End Function
    Public Function GetAccountHead1(ByVal AccE As AccountHead) As DataTable
        Return AccountHeadDB.GetAccountHead1(AccE)
    End Function
    Public Function GetAccountHeadById() As Data.DataTable
        Return AccountHeadDB.GetAccountHead()
    End Function
    Public Function GetAccountHeadByIdGroup(ByVal AccE As DayBookEL) As Data.DataTable
        Return AccountHeadDB.GetAccountHeadGroupWise(AccE)
    End Function
    Public Function GetAccountHeadFC(ByVal id As Long) As List(Of AccountHead)
        Dim accounthead As New List(Of AccountHead)
        Dim ds As DataSet = AccountHeadDB.GetAccountHeadFeeC(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            accounthead.Add(New AccountHead(row("Account_Code"), row("Head_type"), row("Acct_One"), row("Acct_two")))
        Next
        Return accounthead
    End Function
    Public Function GetAccountHeadByIdFC(ByVal id As Long) As AccountHead
        Dim accounthead As AccountHead
        Dim ds As DataSet = AccountHeadDB.GetAccountHeadFeeC(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        accounthead = New AccountHead(row("Account_Code"), row("Head_type"), row("Acct_One"), row("Acct_two"))
        Return accounthead
    End Function
    Public Function GetAccountSubGrpById(ByVal id As Long) As DataTable
        Dim ds As DataSet = AccountHeadDB.GetAccountSubGroup(id)
        Return ds.Tables(0)
    End Function

    'Public Function GetAccountHeadSubGrp(ByVal id As Long) As DataTable
    '    Dim ds As DataSet = AccountHeadDB.GetAccountHead(id)
    '    Return ds.Tables(0)
    'End Function

    'rajesh
    Public Function GetAcctsubgroupByAcctgroupID(ByVal id As Long) As DataTable
        Dim ds As DataTable = AccountHeadDB.GetAcctsubgroupByAcctgroupID(id)
        Return ds
    End Function

    Public Function Delete(ByVal id As Long) As Int16
        Return AccountHeadDB.Delete(id)
    End Function

    Public Function Recover(ByVal id As Long) As Int16
        Return AccountHeadDB.Recover(id)
    End Function

    Public Function Insert(ByVal AccE As AccountHead) As Int16
        Return AccountHeadDB.Insert(AccE)
    End Function
    Public Function Update(ByVal AccE As AccountHead) As Int16
        Return AccountHeadDB.Update(AccE)
    End Function
    Public Function ReportCheck() As Int32
        Return AccountHeadDB.ReportCheck
    End Function
    Public Function GetAccountHeadID(ByVal ID As Int64) As Data.DataTable
        Return AccountHeadDB.GetAccountHeadBYID(ID)
    End Function
    'Public Function GetAccountHead(ByVal Id As Long) As System.Data.DataSet
    '    Return AccountHeadDB.GetAccountHead(Id)
    'End Function
End Class
