Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports GlobalDataSetTableAdapters

Public Class StudentManager
    Dim Dl As New StudentDB
    Public Function InsertStudent(ByVal s As Student) As Integer
        Return StudentDB.Insert(s)
    End Function
    Public Function UpdateRecord(ByVal s As Student) As Integer
        Return StudentDB.update(s)
    End Function
    Public Function getTotalseats(ByVal a As Long) As Data.DataTable
        Return StudentDB.getTotalseats(a)
    End Function
    Public Function GetDtaBatch1(ByVal StdCode As String) As Data.DataTable

        Return BatchDB.GetDtaBatch1(StdCode)
    End Function
    Public Function DeleteRecord(ByVal s As Student) As Integer
        Return StudentDB.Delete(s.Id)
    End Function
    Public Function GetStdId(ByVal code As String, ByVal batch As Long) As Data.DataTable
        Return StudentDB.GetStdID(code, batch)
    End Function
    Public Function GetStudComboDB(ByVal id As Int32) As List(Of DayBookPartyName)
        Dim em As New List(Of DayBookPartyName)
        Dim ds As DataSet = StudentDB.GetStudentComboDayBook(0)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        For Each row In ds.Tables(0).Rows
            em.Add(New DayBookPartyName(row("Name"), row("Id")))
        Next
        Return em
    End Function
    Public Function GetStudComboDBID(ByVal id As Int32) As DayBookPartyName
        Dim em As DayBookPartyName
        Dim ds As DataSet = StudentDB.GetStudentComboDayBook(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        em = New DayBookPartyName(row("Name"), row("Id"))
        Return em
    End Function
    'data to fill fee collection form based on code
    Public Function GetStudentDetails(ByVal code As String) As Data.DataTable
        Return StudentDB.GetStudentDetls(code)
    End Function
    Public Function InsertCoursePlanner(ByVal Crse As Int16, ByVal BtchTo As String) As Integer
        Return StudentDB.InsertCoursePlanner(Crse, BtchTo)
    End Function
    Public Function GetStudentsForRollOver(ByVal instID As Long, ByVal branchID As Long, ByVal corsID As Long, ByVal batchID As Long) As List(Of Student)
        Dim RollOver As New List(Of Student)
        Dim ds As DataSet = StudentDB.GetStudentsForRollOver(instID, branchID, corsID, batchID)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            'RollOver.Add(New Student(row("StdId"), row("StdName"), row("StdCode"), row("DOB"), row("FatherName"), row("FatherOccupation"), row("AnnualIncome"), row("Perm_Address"), row("Temp_Address"), row("ContactNo"), row("StdSex"), row("StdCategory"), row("Course_ID"), row("Branch_ID"), row("Institute_ID"), row("Sponsor_ID"), row("AdmissionDate"), row("Batch_No"), row("Caste"), row("Std_Photo"), row("SLNumber"), row("Prospectus_No"), row("StdAge"), row("Title"), row("Std_email"), row("DDPayOrderNo"), row("Receipt_No"), row("District"), row("Admission_Type"), row("Transfer_Branch"), row("City"), row("PinCode"), row("State"), row("Country"), row("UniqueCode"), row("RollOver")))
        Next
        Return RollOver
    End Function
    Public Function getHouseName() As DataTable
        Return StudentDB.GetHouseName()
    End Function
    Private _StudentRollOverAdapter As StudentMasterRollOverTableAdapter = Nothing
    Public ReadOnly Property Adapter() As StudentMasterRollOverTableAdapter
        Get
            If _StudentRollOverAdapter Is Nothing Then
                _StudentRollOverAdapter = New StudentMasterRollOverTableAdapter
            End If
            Return _StudentRollOverAdapter
        End Get
    End Property
   
End Class



