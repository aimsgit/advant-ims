Imports Microsoft.VisualBasic

Public Class StudentB
    Public Function GetBranch() As DataTable
        Return StudentListDB.insertBranch()
    End Function
    Public Function GetAdmissionReport(ByVal Branch As String, ByVal Course As Integer, ByVal Batch As Integer, ByVal AYear As Integer, ByVal Gender As String, ByVal State As Integer, ByVal Feecollected As String, ByVal Country As String, ByVal District As String, ByVal FromAge As Integer, ByVal ToAge As Integer, ByVal categry As Integer, ByVal Caste As Integer, ByVal Hostel As String, ByVal Transport As String, ByVal CurrentDate As DateTime) As DataTable
        Return StudentListDB.GetAdmissionReport(Branch, Course, Batch, AYear, Gender, State, Feecollected, Country, District, FromAge, ToAge, categry, Caste, Hostel, Transport, CurrentDate)
    End Function
    Public Function GetAdmissionReport1(ByVal Branch As String, ByVal Course As Integer, ByVal Batch As Integer, ByVal AYear As Integer, ByVal Gender As String, ByVal State As Integer, ByVal Feecollected As String, ByVal Country As String, ByVal District As String, ByVal FromAge As Integer, ByVal ToAge As Integer, ByVal categry As Integer, ByVal Caste As Integer, ByVal Hostel As String, ByVal Transport As String) As DataTable
        Return StudentListDB.GetAdmissionReport1(Branch, Course, Batch, AYear, Gender, State, Feecollected, Country, District, FromAge, ToAge, categry, Caste, Hostel, Transport)
    End Function
    Public Function GetCourse(ByVal Branchcode As String) As DataTable
        Return StudentListDB.insertCourse(Branchcode)

    End Function
    Public Function GetYear(ByVal Courseid As Integer, ByVal Branchcode As String) As DataTable
        Return StudentListDB.insertYear(Courseid, Branchcode)
    End Function
    Public Function GetBatchOpenNew(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable
        Return DLBranchCombo.insertBatch(Aid, CourseID, BranchCode)
    End Function

    Public Function GetBatchOpen(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable
        Return StudentListDB.insertBatch(Aid, CourseID, BranchCode)
    End Function
    'Public Function GetBatchOpen(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable
    '    Return StudentListDB.insertOpenBatch(Aid, CourseID, BranchCode)
    'End Function
    Public Function GetBatch1(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable
        Return StudentListDB.insertBatch1(Aid, CourseID, BranchCode)
    End Function

    Public Function GetSemester() As DataTable
        Return StudentListDB.insertSemester()
    End Function

    Public Function GetSummaryRpt(ByVal BranchCode As String, ByVal CId As Integer, ByVal BNo As Integer, ByVal DojDob As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal SemID As Integer) As DataTable
        Return StudentListDB.summaryRpt(BranchCode, CId, BNo, DojDob, FromDate, ToDate, SemID)
    End Function

    Public Function GetDetailedRpt(ByVal BranchCode As String, ByVal CId As Integer, ByVal BNo As Integer, ByVal DojDob As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal semid As Integer) As DataTable
        Return StudentListDB.detailedRpt(BranchCode, CId, BNo, DojDob, FromDate, ToDate, semid)
    End Function
    Public Function GetDetailedRptSort(ByVal BranchCode As String, ByVal CId As Integer, ByVal BNo As Integer, ByVal DojDob As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal semid As Integer) As DataTable
        Return StudentListDB.detailedRptSort(BranchCode, CId, BNo, DojDob, FromDate, ToDate, semid)
    End Function
    Public Function finalExamRpt(ByVal Brid As String, ByVal Cid As Integer, ByVal Aid As Integer, ByVal Bid As Integer, ByVal Sid As Integer) As DataTable
        Return StudentListDB.finalExamRpt(Brid, Cid, Aid, Bid, Sid)
    End Function
End Class
