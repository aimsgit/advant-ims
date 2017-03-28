Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Public Class FeeStructureManager
    Dim Dal As New FeeStructureDB
    Public Function GVFill(ByVal BrnId As Int64, ByVal InsID As Int64) As List(Of FeeStructure)
        Dim List As New List(Of FeeStructure)
        Dim dt As Data.DataTable
        dt = Dal.GVFill(BrnId, InsID)
        Dim dr As Data.DataRow
        For Each dr In dt.Rows
            List.Add(New FeeStructure(dr("Institute_ID"), dr("Branch_ID"), dr("Fee_Structure_ID"), dr("Course_ID"), dr("CourseName"), dr("Course_Planner_ID"), dr("Batch_No"), dr("Semester_ID"), dr("AssessmentType"), dr("FeeHead_ID"), dr("Fee_HeadType"), dr("Amount"), dr("Due_Date"), dr("Remarks"), dr("Sponsor"), dr("Discount")))
        Next
        Return List
    End Function
    Public Function GVFill(ByVal Id As Int64, ByVal BrnId As Int64, ByVal InsID As Int64) As List(Of FeeStructure)
        Dim List As New List(Of FeeStructure)
        Dim dt As Data.DataTable = Dal.GVFill(Id, BrnId, InsID)
        Dim dr As Data.DataRow
        For Each dr In dt.Rows
            List.Add(New FeeStructure(dr("Institute_ID"), dr("Branch_ID"), dr("Fee_Structure_ID"), dr("Course_ID"), dr("CourseName"), dr("Course_Planner_ID"), dr("Batch_No"), dr("Semester_ID"), dr("AssessmentType"), dr("FeeHead_ID"), dr("Fee_HeadType"), dr("Amount"), dr("Due_Date"), dr("Remarks"), dr("Sponsor"), dr("Discount")))
        Next
        Return List
    End Function
    Public Function Insert(ByVal c As FeeStructure) As Int16
        If c.Discount = 0 Then
            c.Sponsor = 0
        End If
        Return Dal.Insert(c)
    End Function
    Public Function Update(ByVal FeeProp As FeeStructure) As Int16
        Return Dal.Update(FeeProp)
    End Function
    Public Function Delete(ByVal id As Int64) As Int16
        Return Dal.ChangeFalg(id)
    End Function
    Public Function Report(ByVal ins As Int64, ByVal Brn As Int64, ByVal Crs As Int64, ByVal Bth As Int64, ByVal Sem As Int64) As Data.DataTable
        Return Dal.Reprot(ins, Brn, Crs, Bth, Sem)
    End Function
    Public Function FeeDueReport(ByVal BatchId As Int64, ByVal SemID As Int64, ByVal StdID As Int64, ByVal CategoryID As Int64, ByVal CourseCode As Integer) As Data.DataTable
        Return Dal.FeeDueReprot(BatchId, SemID, StdID, CategoryID, CourseCode)
    End Function
    Public Function GetsElfDetails() As Data.DataTable
        Return selfdetailsDB.GetDeatils(0).Tables(0)
    End Function
    Public Function FillGrid(ByVal batch As Int64, ByVal sem As Int64) As Data.DataTable
        Return Dal.FillGrid(batch, sem)
    End Function
    Public Function GetFullAcctHead() As Data.DataTable
        Return Dal.GetFullAcct_Head()
    End Function
    Public Function SponsorCombo() As Data.DataTable
        Return SponsorDB.SponsorCombo()
    End Function
    Public Function getSemesterCombo(ByVal BatchId As Integer) As Data.DataTable
        Return Dal.getSemester(BatchId)
    End Function
    Public Function FeeDueReportSum(ByVal SemID As Int64, ByVal AcId As Int64, ByVal CategoryID As Int64, ByVal CourseCode As Integer) As Data.DataTable
        Return Dal.FeeDueReprotSum(SemID, AcId, CategoryID, CourseCode)
    End Function
End Class
