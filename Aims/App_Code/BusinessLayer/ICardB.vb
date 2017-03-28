Imports Microsoft.VisualBasic
Public Class ICardB
    Dim DAL As New ICardD
    Dim prop As New ICardE
    Public Function GetIns() As Data.DataTable
        Dim dt As New Data.DataTable
        dt = DAL.getInstitutes()
        Return dt
    End Function
    'Public Function empnametocode(ByVal Prop As loanmasterE) As Int64
    '    Return DAL.send(Prop)
    'End Function
    Public Function GetBranches() As Data.DataTable
        Dim dt As New Data.DataTable
        dt = DAL.getBranches()
        Return dt
    End Function
    Public Function updateStdDetails(ByVal prop As ICardE) As Int64
        Return DAL.updateStdDetails(prop)
    End Function
    Public Sub delete(ByVal LoanId As Int64)
        DAL.delete(LoanId)
    End Sub
    Public Function GetCourses(ByVal prop As ICardE) As Data.DataTable
        Dim dt As New Data.DataTable
        dt = DAL.GetAllCourses(prop)
        Return dt
    End Function
    'Public Sub recover(ByVal LoanId As Int64)
    '    DAL.recover(LoanId)
    'End Sub
    Public Function GetBatchs(ByVal prop As ICardE) As DataTable
        Dim dt As New Data.DataTable
        dt = DAL.GetAllBatchs(prop)
        Return dt
    End Function
    Public Function FillGrid(ByVal prop As ICardE) As DataTable
        Dim dt As New Data.DataTable
        dt = DAL.FillICardGrid(prop)
        Return dt
    End Function
    Public Function UpdateICardStatus(ByVal prop As ICardE, ByVal flag As Boolean) As Int64
        Return DAL.UpdateICardStatus(prop, flag)
    End Function
    Public Function GetRcptDetails(ByVal prop As ICardE) As DataTable
        Dim dt As New Data.DataTable
        dt = DAL.GetRcptDetails(prop)
        Return dt
    End Function
    Public Function GetReport(ByVal inst As Int64, ByVal brn As Int64, ByVal crs As Int64, ByVal btch As Int64) As DataTable
        Dim dt As DataTable = ICardD.GetReport(inst, brn, crs, btch)
        Return dt
    End Function
End Class

