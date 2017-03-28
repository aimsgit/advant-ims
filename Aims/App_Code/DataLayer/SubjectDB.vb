Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class SubjectDB
    Shared Function GetSubject(ByVal Course_ID As Integer, ByVal Batch_No As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As DataSet
        'If id = 0 Then
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@courseId", SqlDbType.Int)
        arParms(2).Value = Course_ID

        arParms(3) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(3).Value = Batch_No
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSubjectMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'Else
        '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSubjectMasterById", New System.Data.SqlClient.SqlParameter("@id", SqlDbType.SmallInt, 10, ParameterDirection.Input, False, 0, 0, "id", DataRowVersion.Current, id))

        'End If
        Return ds.Tables(0)
    End Function
    Shared Function GetSubjectByCourse(ByVal courseid As Long) As System.Data.DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        If courseid = 0 Then
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSubjects")
        Else
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSubjectsById", New System.Data.SqlClient.SqlParameter("@ID", SqlDbType.Int, courseid))
        End If
        Return ds
    
    End Function
    Public Function CheckDuplicate(ByVal s As Subject) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(2) {}
        'para(0) = New SqlParameter("@Subject_Name", SqlDbType.VarChar, 50)
        'para(0).Value = s.Name
        para(0) = New SqlParameter("@Subject_Code", SqlDbType.NVarChar, 50)
        para(0).Value = s.Code

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@id", SqlDbType.Int)
        para(2).Value = s.Id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_GetsubjectDuplicate", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function
Public Function Update(ByVal s As Subject) As Long
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Subject_Name", SqlDbType.NVarChar, 200)
        arParms(0).Value = s.Name
        arParms(1) = New SqlParameter("@Subject_Code", SqlDbType.NVarChar, 100)
        arParms(1).Value = s.Code
        arParms(2) = New SqlParameter("@Subject_ID", SqlDbType.Int)
        arParms(2).Value = s.Id
        arParms(3) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(5).Value = s.DeptId

        arParms(6) = New SqlParameter("@Subgrp", SqlDbType.VarChar, 2)
        arParms(6).Value = s.Subgrp

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@Prin_Subj", SqlDbType.Int)
        arParms(8).Value = s.PrincipleSubject

        arParms(9) = New SqlParameter("@SubCategory", SqlDbType.Int)
        arParms(9).Value = s.SubjectCategory

        arParms(10) = New SqlParameter("@Pre_Req", SqlDbType.VarChar, 50)
        arParms(10).Value = s.PreRequisites

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateSubjectDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function Insert(ByVal s As Subject) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Count As Int32

        Dim arParms() As SqlParameter = New SqlParameter(10) {} ' abhishek tyagi 30 mar 

        arParms(0) = New SqlParameter("@Sub_Name", SqlDbType.NVarChar, 200)
        arParms(0).Value = s.Name

        arParms(1) = New SqlParameter("@Sub_Code", SqlDbType.NVarChar, 100)
        arParms(1).Value = s.Code

        'arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        'arParms(5).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@Prin_Subj", SqlDbType.Int)
        arParms(5).Value = s.PrincipleSubject

        arParms(6) = New SqlParameter("@SubCategory", SqlDbType.Int)
        arParms(6).Value = s.SubjectCategory

        arParms(7) = New SqlParameter("@Pre_Req", SqlDbType.VarChar, 50)
        arParms(7).Value = s.PreRequisites

        arParms(8) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(8).Value = s.DeptId

        arParms(9) = New SqlParameter("@Subgrp", SqlDbType.VarChar, 2)
        arParms(9).Value = s.Subgrp
        arParms(10) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("Office")


        Try
            Count = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_saveSubjectMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Count
    End Function
    Public Function Report() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getRptSubjectMaster")

        Return ds.Tables(0)
    End Function
    
    Public Function GetBatchFullSubject() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchFullSubject")

        Return ds.Tables(0)
    End Function
    Public Function getGVSubjectMaster(ByVal s As Subject) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = s.Id

        arParms(3) = New SqlParameter("@SubName", SqlDbType.VarChar)
        arParms(3).Value = s.Name

        arParms(4) = New SqlParameter("@SubCode", SqlDbType.VarChar)
        arParms(4).Value = s.Code

        arParms(5) = New SqlParameter("@DepID", SqlDbType.VarChar)
        arParms(5).Value = s.DeptId
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getGVSubjectMasterView", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Getdeptcombo() As DataTable
        'Nitin. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DepartmentCombo", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Getdeptcombo1() As DataTable
        'Nitin. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DepartmentCombo1", Para)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Function DeleteGVSubjectMaster(ByVal s As Subject) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms As SqlParameter() = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = s.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_SubjectMasterGVDelete", arParms)
        Return rowsaffected
    End Function
    Public Function delsubjectValidation(ByVal idd As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@id", SqlDbType.Int)
        arParms.Value = idd
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_delsubjectValidation", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetSubject_TimeTable(ByVal Id As Int64) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetSubjectByBatch", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetBatchWiseSubject(ByVal Batch As Int64) As Data.DataTable

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@Batch", SqlDbType.Int)
        arParms.Value = Batch

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchWiseSubject", arParms)

        Return ds.Tables(0)
    End Function
    Public Function RptSubjectMaster(ByVal id As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getGVSubjectMaster", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Getdeptcombo2() As DataTable
        'Jina. Function for Retrieving the data
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Para(1).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ProcDeptCombo", Para)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetPrincipalSubject() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPrincipalSubject", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetSubjectCategory() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSubjectCategory", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
End Class
