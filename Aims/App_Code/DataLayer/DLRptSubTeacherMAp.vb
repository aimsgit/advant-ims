Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLRptSubTeacherMAp

    Public Function GetSubject(ByVal Subject As String) As Data.DataTable
       

        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(1) {}
     
        para(0) = New SqlParameter("@Sub", SqlDbType.VarChar, 50)
        para(0).Value = Subject

        para(1) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 30)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "[Proc_SelectSubjectRpt]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

     
    End Function

    Public Function GetTeacherdetails(ByVal Subject As String) As Data.DataTable


        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(0) {}

        para(0) = New SqlParameter("@SubId", SqlDbType.VarChar, 5000)
        para(0).Value = Subject
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_GetTeacherDetails", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)


    End Function

    Public Function GetTeacher(ByVal Teacher As String) As Data.DataTable


        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@teacher", SqlDbType.VarChar, 50)
        para(0).Value = Teacher

        para(1) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 30)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "[Proc_SelectTeacherRpt]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
    Public Function GetTeacherid(ByVal Teacher As String) As Data.DataTable


        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(1) {}

        para(0) = New SqlParameter("@teacher", SqlDbType.VarChar, 50)
        para(0).Value = Teacher

        para(1) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 30)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "[Proc_SelectTeacheridRpt]", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Public Function GetSubdetails(ByVal Subject As String, ByVal NIC As String, ByVal PAN As String, ByVal PASSNo As String) As Data.DataTable
        Try

            Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim para() As SqlParameter = New SqlParameter(3) {}

            para(0) = New SqlParameter("@TId", SqlDbType.VarChar, 500)
            para(0).Value = Subject

            para(1) = New SqlParameter("@NIC", SqlDbType.VarChar, 100)
            para(1).Value = NIC

            para(2) = New SqlParameter("@PAN", SqlDbType.VarChar, 100)
            para(2).Value = PAN

            para(3) = New SqlParameter("@PassNo", SqlDbType.VarChar, 100)
            para(3).Value = PASSNo

            Try
                ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "[Proc_GetSubjectDetails]", para)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        Catch e As Exception

        End Try
    End Function
End Class
