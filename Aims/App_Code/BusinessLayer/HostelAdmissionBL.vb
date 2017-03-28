Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class HostelAdmissionBL
    Dim Dl As New HostelAdmissionDL
    'Public Function InsertRecord(ByVal f As HostelAdmissionE) As Integer
    '    Return HostelAdmissionDL.Insert(f)
    'End Function
    'Public Function UpdateRecord(ByVal f As HostelAdmissionE) As Integer
    '    Return HostelAdmissionDL.UpdateRecord(f)
    'End Function
    Public Function GetRecord(ByVal RId As Integer, ByVal Id As Integer, ByVal HId As Integer) As DataTable
        Return Dl.GetRecords(RId, Id, HId)
    End Function
    Public Function DeleteRecord(ByVal id As Integer, ByVal Studid As Integer) As Integer
        Return HostelAdmissionDL.DeleteRecord(id, Studid)
    End Function
    Public Function VacateRecord(ByVal id As Integer, ByVal Studid As Integer, ByVal DOL As Date) As Integer
        Return HostelAdmissionDL.VacateRecord(id, Studid, DOL)
    End Function
    Public Function CheckDuplicate(ByVal f As HostelAdmissionE) As DataTable
        Return HostelAdmissionDL.CheckDuplicate(f)
    End Function
    Public Function GetHosNameCombo(ByVal BranchCode As String) As DataTable
        Return Dl.GetHosNameCombo(BranchCode)
    End Function

    Public Function GetHosNameCombo1(ByVal BranchCode As String) As DataTable
        Return Dl.GetHosNameCombo1(BranchCode)
    End Function
    Public Function GetRoomTypeCombo(ByVal Hid As Integer, ByVal Branchcode As String) As DataTable
        Return Dl.GetRoomTypeCombo(Hid, Branchcode)
    End Function
    Public Function GetRoomDetails(ByVal Rid As Integer, ByVal Hid As Integer) As DataTable
        Return Dl.GetRoomDetails(Rid, Hid)
    End Function

    Public Function GetSelectBranch() As DataTable
        Return Dl.GetSelectBranch()
    End Function
End Class
