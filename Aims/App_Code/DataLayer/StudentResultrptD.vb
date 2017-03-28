Imports Microsoft.VisualBasic
Imports Student_ResultrptP
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Student_ResultrptD
    Public Class CreateConnection
        ' Public new_dbconn1 As String = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        ' Public dbconnection As New Data.OleDb.OleDbConnection()
        Public Sub New()

        End Sub
        Public Function ExecuteSql(ByVal Sql As String, ByVal dt As String) As Data.DataSet
            'dbconnection.ConnectionString = new_dbconn1
            'Dim da As System.Data.OleDb.OleDbDataAdapter
            'Dim ds As New System.Data.DataSet
            'If dbconnection.State = Data.ConnectionState.Open Then
            '    dbconnection.Close()
            'End If
            'dbconnection.Open()
            'da = New System.Data.OleDb.OleDbDataAdapter(Sql, dbconnection)
            'ds.Clear()
            'da.Fill(ds, dt)
            'dbconnection.Dispose()
            'dbconnection.Close()
            'Return ds
        End Function
    End Class
    Public Class StudentResultdb
        Dim CreConn As New CreateConnection
        Public Function getdata_ID(ByVal obj As Student_ResultrptP.RPT_StudentResult) As Data.DataSet
            Dim ds As New Data.DataSet
            Dim dt As String = "RPT_StudentResult"
            Dim sql As String
            sql = "Select * from RPT_StudentResult where StdCode=" + obj.StdCode
            ds = CreConn.ExecuteSql(sql, dt)
            Return ds
        End Function

        Public Function GetDataByrptStdResult(ByVal Branch As String, ByVal CourseId As Integer, ByVal Subjectid As Integer, ByVal SemesterId As Integer, ByVal BatchNo As Integer, ByVal AssessmentId As Integer, ByVal ClassType As Integer, ByVal SortBy As Integer) As Data.DataTable
            Dim ds As New DataSet
            Dim dt As New Data.DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            'Dim dt As New Data.DataTable
            'Dim query As String
            'query = "SELECT Emp_Id,Emp_Name FROM EmployeeMaster WHERE Del_Flag=0 order by Emp_name"
            'da = New OleDbDataAdapter(query, Conn)
            'da.Fill(dt)
            'Return dt
            Dim arParms() As SqlParameter = New SqlParameter(8) {}


            arParms(0) = New SqlParameter("@Batch", SqlDbType.Int, 50)
            arParms(0).Value = BatchNo

            arParms(1) = New SqlParameter("@Semester", SqlDbType.Int, 50)
            arParms(1).Value = SemesterId

            arParms(2) = New SqlParameter("@Course", SqlDbType.Int, 50)
            arParms(2).Value = CourseId

            arParms(3) = New SqlParameter("@Subject", SqlDbType.Int, 50)
            arParms(3).Value = Subjectid

            arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(4).Value = Branch

            arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(5).Value = HttpContext.Current.Session("Office")

            arParms(6) = New SqlParameter("@AssesmentType", SqlDbType.Int, 50)
            arParms(6).Value = AssessmentId

            arParms(7) = New SqlParameter("@Classtype", SqlDbType.Int)
            arParms(7).Value = ClassType

            arParms(8) = New SqlParameter("@SortBy", SqlDbType.Int)
            arParms(8).Value = SortBy




            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StdSubjectResult", arParms)
            Return ds.Tables(0)


            Return dt
        End Function



    End Class
End Namespace

