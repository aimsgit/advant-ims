Imports Microsoft.VisualBasic
Imports GlobalDataSetTableAdapters
'Namespace StudentResult

Public Class StdResultB
    Dim DAL As New StudentResultD
    'Nakul 28-Mar-2012 (For filling Student)
    Public Function GetStudentReportCombo(ByVal BatchID As Integer) As Data.DataTable
        Return DAL.GetStudentReportCombo(BatchID)
    End Function
    Private _stdResultAdapter As StudentResultTableAdapter = Nothing
    Public ReadOnly Property Adapter() As StudentResultTableAdapter
        Get
            If _stdResultAdapter Is Nothing Then
                _stdResultAdapter = New StudentResultTableAdapter
            End If
            Return _stdResultAdapter
        End Get
    End Property
    Public Function InsertSem() As DataTable
        Return StudentResultD.insertSem()

    End Function
    Public Function getass() As DataTable
        Return StudentResultD.getass()

    End Function
    'Public Function Update_Transaction(ByVal StdResult As GlobalDataSet.StudentResultDataTable) As Integer
    '    Return Adapter.UpdateWithTransaction(StdResult)
    'End Function
    Public Function GetData(ByVal Prop As StudentResult.StudentResultP, ByVal ChkArrear As Boolean) As Data.DataTable
        'Public Function GetData(ByVal Prop As StudentResultP) As Data.DataTable
        Return DAL.GetStudent(Prop, ChkArrear)
    End Function
    Public Function FillGrid(ByVal Prop As StudentResult.StudentResultP) As Data.DataTable
        'Public Function FillGrid(ByVal Prop As StudentResultP) As Data.DataTable
        Return DAL.FillGrid(Prop)
    End Function
    Public Function UpdateDel(ByVal i As Int64) As Integer
        DAL.UpdateDel(i)
    End Function
    'Public Function Update(ByVal Prop As StudentResultP) As Integer
    '    DAL.Update(Prop)
    'End Function
    Public Function GetStdCode(ByVal ins As Int64, ByVal brn As Int64, ByVal crs As Int64, ByVal btch As Int64) As Data.DataTable
        Return DAL.GetStdCode(ins, brn, crs, btch)
    End Function
    Public Function GetStdEligible(ByVal ins As Int64, ByVal brn As Int64, ByVal crs As Int64, ByVal btch As Int64) As Data.DataTable
        Return DAL.GetstdEligible(btch, ins, brn, crs)
    End Function
    Public Function GetStdEligibleRpt(ByVal ins As Int64, ByVal brn As Int64, ByVal crs As Int64, ByVal btch As Int64) As Data.DataTable
        Return DAL.GetstdEligibleRpt(ins, brn, crs, btch)
    End Function
    Public Function GetBatchData(ByVal Institute_ID As Int64, ByVal Branch_ID As Int64, ByVal Course_ID As Int64) As Data.DataTable
        Return DAL.GetBatchData(Institute_ID, Branch_ID, Course_ID)
    End Function
    Public Function GetSemesterByStdCode(ByVal stdID As Int32) As Data.DataTable
        Return DAL.GetSemesterByStdCode(stdID)
    End Function
    Public Function GetResultByStdCode(ByVal BranchCode As String, ByVal StdId As Integer, ByVal batch As Integer, ByVal sem As Integer, ByVal ass As Integer, ByVal classtype As Integer) As System.Data.DataTable
        Return DAL.GetResultByStdCode(BranchCode, StdId, batch, sem, ass, classtype)
    End Function
    Public Function GetStdPerformance(ByVal Institute As Integer, ByVal Branch As Integer, ByVal course As Integer, ByVal batch As Integer, ByVal Subject As Integer) As Data.DataTable
        Return DAL.GetStdPerformance(Institute, Branch, course, batch, Subject)
    End Function
End Class
'End Namespace

