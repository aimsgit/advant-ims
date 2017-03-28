Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLQuestionBank
    Shared Function getQuestionBank(ByVal el As ELQuestionBank) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = el.Id
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetQuesBank", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Insert(ByVal el As ELQuestionBank) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(12) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(3).Value = el.Q_date
        arParms(4) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(4).Value = el.CourseId
        arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(5).Value = el.SubjectId
        arParms(6) = New SqlParameter("@Q_Type", SqlDbType.NVarChar, 50)
        arParms(6).Value = el.Q_Type
        arParms(7) = New SqlParameter("@Q_No", SqlDbType.NVarChar, 50)
        arParms(7).Value = el.Q_No
        arParms(8) = New SqlParameter("@Ques", SqlDbType.NVarChar, 250)
        arParms(8).Value = el.Ques
        arParms(9) = New SqlParameter("@Answer", SqlDbType.NVarChar, 500)
        arParms(9).Value = el.Ans
        arParms(10) = New SqlParameter("@Q_SbuNo", SqlDbType.NVarChar, 50)
        arParms(10).Value = el.Q_SubNo
        arParms(11) = New SqlParameter("@Diagram", SqlDbType.VarChar, 250)
        arParms(11).Value = el.APhoto
        arParms(12) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("Office")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertQuestionBank", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function CheckDuplicate(ByVal el As ELQuestionBank) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        'Dim para() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(1).Value = el.CourseId
        arParms(2) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(2).Value = el.SubjectId
        arParms(3) = New SqlParameter("@Q_Type", SqlDbType.Int)
        arParms(3).Value = el.Q_date
        arParms(4) = New SqlParameter("@Q_No", SqlDbType.NVarChar, 50)
        arParms(4).Value = el.CourseId
        arParms(5) = New SqlParameter("@Ques", SqlDbType.NVarChar, 250)
        arParms(5).Value = el.Ques
        arParms(6) = New SqlParameter("@Answer", SqlDbType.NVarChar, 500)
        arParms(6).Value = el.Ans
        arParms(7) = New SqlParameter("@id", SqlDbType.Int)
        arParms(7).Value = el.id
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_DuplicateHolidayMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal el As ELQuestionBank) As Integer
      
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(12) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")
        arParms(1) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("UserCode")
        arParms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        arParms(3) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(3).Value = el.Q_date
        arParms(4) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(4).Value = el.CourseId
        arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(5).Value = el.SubjectId
        arParms(6) = New SqlParameter("@Q_Type", SqlDbType.NVarChar, 50)
        arParms(6).Value = el.Q_Type
        arParms(7) = New SqlParameter("@Q_No", SqlDbType.NVarChar, 50)
        arParms(7).Value = el.Q_No
        arParms(8) = New SqlParameter("@Ques", SqlDbType.NVarChar, 250)
        arParms(8).Value = el.Ques
        arParms(9) = New SqlParameter("@Answer", SqlDbType.NVarChar, 500)
        arParms(9).Value = el.Ans
        arParms(10) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(10).Value = el.id
        arParms(11) = New SqlParameter("@Q_SbuNo", SqlDbType.NVarChar, 50)
        arParms(11).Value = el.Q_SubNo
        arParms(12) = New SqlParameter("@Diagram", SqlDbType.VarChar, 250)
        arParms(12).Value = el.APhoto
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateQuesBank", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal Id As Long) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteQuestionbank", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function PostQuestion(ByVal EL As ELQuestionBank) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = EL.ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "mfg_PostQuestion", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
