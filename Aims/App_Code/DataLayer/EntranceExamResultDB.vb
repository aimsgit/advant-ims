Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb

<DataObject(True)> _
Public Class EntranceExamResult

    '<DataObjectMethod(DataObjectMethodType.Select)> _
    'Public Shared Function GetCourse(ByVal Year) As DataSet

    '    Dim selectStatement As String = "SELECT CourseMaster.Course_ID, CourseMaster.CourseName, CourseMaster.SYear, CourseMaster.EDate, CourseMaster.Del_Flag" & _
    '                                    " FROM(CourseMaster)WHERE(((SYear)= @Year)And ((CourseMaster.Del_Flag) = 0))"
    '    Dim connection As New OleDbConnection(GetConnectionString)
    '    Dim selectCommand As New OleDbCommand(selectStatement, connection)
    '    selectCommand.Parameters.AddWithValue("Year", Year)
    '    Dim abDataAdapter As New OleDbDataAdapter(selectCommand)
    '    Dim abDataSet As New DataSet
    '    abDataAdapter.Fill(abDataSet, "CourseMaster")
    '    Return abDataSet
    'End Function

    '<DataObjectMethod(DataObjectMethodType.Select)> _
    'Public Shared Function GetStudentList(ByVal Course_ID As String) As DataSet

    '    Dim selectStatement As String = "SELECT StudentMaster.StdId, StudentMaster.StdCode, StudentMaster.StdName, CourseMaster.Course_ID, StudentMaster.Del_Flag, StudentMaster.AdmissionFlag,EntranceExam.StdId AS StdId1,StudentMaster.RegistrationNo" & _
    '                                    " FROM (CourseMaster RIGHT JOIN StudentMaster ON CourseMaster.Course_ID = StudentMaster.Course_ID) LEFT JOIN EntranceExam ON StudentMaster.StdId = EntranceExam.StdId" & _
    '                                    " WHERE (((CourseMaster.Course_ID)=@Course_ID) AND ((StudentMaster.Del_Flag)=0) AND ((StudentMaster.AdmissionFlag)=0) AND ((EntranceExam.StdId) Is Null))"

    '    Dim connection As New OleDbConnection(GetConnectionString)
    '    Dim selectCommand As New OleDbCommand(selectStatement, connection)
    '    selectCommand.Parameters.AddWithValue("Course_ID", Course_ID)
    '    Dim abDataAdapter As New OleDbDataAdapter(selectCommand)
    '    Dim abDataSet As New DataSet
    '    abDataAdapter.Fill(abDataSet, "StudentMaster")
    '    Return abDataSet
    'End Function

    'Private Shared Function GetConnectionString() As String
    '    Return ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
    'End Function

End Class

