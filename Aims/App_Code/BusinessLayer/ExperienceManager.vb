Imports Microsoft.VisualBasic

Imports System.Collections.Generic
Imports System.Data
Public Class ExperienceManager
    Public Function InsertRecord(ByVal exp As Experience) As Integer
        Return ExperienceDB.Insert(exp)
    End Function
    Public Function UpdateRecord(ByVal exp As Experience) As Integer
        Return ExperienceDB.Insert(exp)
    End Function
    Public Function GetExperience(ByVal std_code As Integer) As List(Of Experience)
        'Dim exper As New List(Of Experience)
        ''Dim ds As DataSet = ExperienceDB.GetExperience2(std_code)
        'Dim row As DataRow
        ''For Each row In ds.Tables(0).Rows
        'exper.Add(New Experience(row("ExpId"), row("Std_code"), row("NameofOrganisation"), row("NoOfYears"), row("Natureofjob")))
        'Next
        'Return exper
    End Function
    Public Function ChangeFlag(ByVal exp As Experience) As Integer
        Return ExperienceDB.ChangeFlag(exp.ExpId)
    End Function
    Public Function ChangeFlag(ByVal ExpId As Int32) As Integer
        Return ExperienceDB.ChangeFlag(ExpId)
    End Function
End Class
