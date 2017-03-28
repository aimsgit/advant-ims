Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLRuleGrade
    Shared Function getBatchPlannerComboSelectAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "getBatch", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSubCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetSubCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetGrade(ByVal Batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetGradeCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function GetColumn() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlcolumnMarks", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStudentData(ByVal Batch As Integer, ByVal condition As String, ByVal subject As Integer, ByVal condition1 As Integer, ByVal condition2 As Integer, ByVal Semester As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(3).Value = Semester


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentData", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function Condition1(ByVal Batch As Integer, ByVal Assessment As Integer, ByVal Grade As String, ByVal totCredit As Integer, ByVal Semester As Integer, ByVal Run As String, ByVal SubCategory As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(8) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Assessment", SqlDbType.Int)
            Parms(3).Value = Assessment

            Parms(4) = New SqlParameter("@Grade", SqlDbType.VarChar, 10)
            Parms(4).Value = Grade

            Parms(5) = New SqlParameter("@totalCredit", SqlDbType.Float)
            Parms(5).Value = totCredit

            Parms(6) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(6).Value = Semester

            Parms(7) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(7).Value = Run

            Parms(8) = New SqlParameter("@SubCategory", SqlDbType.Int)
            Parms(8).Value = Subcategory

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Condition1", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Condition2(ByVal Batch As Integer, ByVal Assessment As Integer, ByVal Grade As String, ByVal SubCategory As Integer, ByVal Semester As Integer, ByVal Run As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(7) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Assessment", SqlDbType.Int)
            Parms(3).Value = Assessment

            Parms(4) = New SqlParameter("@Grade", SqlDbType.VarChar, 10)
            Parms(4).Value = Grade

            Parms(5) = New SqlParameter("@SubCategory", SqlDbType.Float)
            Parms(5).Value = SubCategory

            Parms(6) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(6).Value = Semester

            Parms(7) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(7).Value = Run

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Condition2", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Condition3(ByVal Batch As Integer, ByVal StartCGPA As Double, ByVal EndCGPA As Double, ByVal Semester As Integer, ByVal Run As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(6) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@StartCGPA", SqlDbType.Float)
            Parms(3).Value = StartCGPA

            Parms(4) = New SqlParameter("@EndCGPA", SqlDbType.Float)
            Parms(4).Value = EndCGPA

            Parms(5) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(5).Value = Semester

            Parms(6) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(6).Value = Run

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Condition3", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Condition4(ByVal Batch As Integer, ByVal Assessment As Integer, ByVal Grade As String, ByVal totCredit As Integer, ByVal Semester1 As Integer, ByVal Semester2 As Integer, ByVal MainSemester As Integer, ByVal Run As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(9) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Assessment", SqlDbType.Int)
            Parms(3).Value = Assessment

            Parms(4) = New SqlParameter("@Grade", SqlDbType.VarChar, 10)
            Parms(4).Value = Grade

            Parms(5) = New SqlParameter("@totalCredit", SqlDbType.Float)
            Parms(5).Value = totCredit

            Parms(6) = New SqlParameter("@Semester1", SqlDbType.Int)
            Parms(6).Value = Semester1

            Parms(7) = New SqlParameter("@MainSemester", SqlDbType.Int)
            Parms(7).Value = MainSemester

            Parms(8) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(8).Value = Run

            Parms(9) = New SqlParameter("@Semester2", SqlDbType.Int)
            Parms(9).Value = Semester2

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Condition4", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Condition5(ByVal Batch As Integer, ByVal Assessment As Integer, ByVal Grade As String, ByVal totCredit As Integer, ByVal Semester1 As Integer, ByVal Semester2 As Integer, ByVal MainSemester As Integer, ByVal Run As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(9) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Assessment", SqlDbType.Int)
            Parms(3).Value = Assessment

            Parms(4) = New SqlParameter("@Grade", SqlDbType.VarChar, 10)
            Parms(4).Value = Grade

            Parms(5) = New SqlParameter("@totalCredit", SqlDbType.Float)
            Parms(5).Value = totCredit

            Parms(6) = New SqlParameter("@Semester1", SqlDbType.Int)
            Parms(6).Value = Semester1

            Parms(7) = New SqlParameter("@MainSemester", SqlDbType.Int)
            Parms(7).Value = MainSemester

            Parms(8) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(8).Value = Run

            Parms(9) = New SqlParameter("@Semester2", SqlDbType.Int)
            Parms(9).Value = Semester2

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Condition5", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Condition6(ByVal Batch As Integer, ByVal Days As Integer, ByVal Semester As Integer, ByVal Run As String, ByVal GradDate As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(6) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@days", SqlDbType.Int)
            Parms(3).Value = Days

            Parms(4) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(4).Value = Semester

            Parms(5) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(5).Value = Run

            Parms(6) = New SqlParameter("@GradDate", SqlDbType.Date)
            Parms(6).Value = GradDate

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Condition6", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Condition7(ByVal Batch As Integer, ByVal TotMaxMarks As Integer, ByVal TotMinMarks As Integer, ByVal Semester As Integer, ByVal Run As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(6) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@TotMaxMarks", SqlDbType.Float)
            Parms(3).Value = TotMaxMarks

            Parms(4) = New SqlParameter("@TotMinMarks", SqlDbType.Float)
            Parms(4).Value = TotMinMarks

            Parms(5) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(5).Value = Semester

            Parms(6) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(6).Value = Run


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Condition8", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function


    Shared Function UpdateData(ByVal Batch As Integer, ByVal value As String, ByVal column As String, ByVal sid As String, ByVal Semester As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(8) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Value", SqlDbType.VarChar, value.Length)
            Parms(3).Value = value

            'Parms(4) = New SqlParameter("@Sem", SqlDbType.Int)
            'Parms(4).Value = sem

            Parms(4) = New SqlParameter("@SID", SqlDbType.VarChar, sid.Length)
            Parms(4).Value = sid

            Parms(5) = New SqlParameter("@Column", SqlDbType.VarChar, column.Length)
            Parms(5).Value = column

            Parms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(6).Value = HttpContext.Current.Session("EmpID")

            Parms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
            Parms(7).Value = HttpContext.Current.Session("UserCode")

            Parms(8) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(8).Value = Semester

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "UpdateBatchSemesterTable", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function CheckCondition(ByVal Batch As Integer, ByVal AndRule As String, ByVal OrRule As String, ByVal Semester As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            If (AndRule.Length > 1) Then
                AndRule = AndRule.Substring(1, AndRule.Length - 1)
            End If
            If (OrRule.Length > 1) Then
                OrRule = OrRule.Substring(1, OrRule.Length - 1)
            End If

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@AndRule", SqlDbType.VarChar, 50)
            Parms(3).Value = AndRule

            Parms(4) = New SqlParameter("@OrRule", SqlDbType.VarChar, 50)
            Parms(4).Value = OrRule

            Parms(5) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(5).Value = Semester

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_checkRules", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function


    Shared Function ClearCondition(ByVal Batch As Integer, ByVal Semester As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rows As New Integer
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@Semester", SqlDbType.Int)
            Parms(3).Value = Semester

            rows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_clearRules", Parms)
            Return rows
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function SaveRule(ByVal AndRule As Integer, ByVal OrRule As Integer, ByVal Rule As Integer, ByVal Run As Integer, ByVal Assessment As String, ByVal Options1 As String, ByVal Value1 As String, ByVal Value2 As String, ByVal Formula As Integer, ByVal options2 As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(13) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@AndRule", SqlDbType.Int)
            Parms(2).Value = AndRule

            Parms(3) = New SqlParameter("@OrRule", SqlDbType.Int)
            Parms(3).Value = OrRule

            Parms(4) = New SqlParameter("@Rule", SqlDbType.Int)
            Parms(4).Value = Rule

            Parms(5) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(5).Value = Run

            Parms(6) = New SqlParameter("@Assessment", SqlDbType.VarChar, Assessment.Length)
            Parms(6).Value = Assessment

            Parms(7) = New SqlParameter("@Options1", SqlDbType.VarChar, Options1.Length)
            Parms(7).Value = Options1

            Parms(8) = New SqlParameter("@Value1", SqlDbType.VarChar, Value1.Length)
            Parms(8).Value = Value1

            Parms(9) = New SqlParameter("@Value2", SqlDbType.VarChar, Value2.Length)
            Parms(9).Value = Value2

            Parms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 100)
            Parms(10).Value = HttpContext.Current.Session("EmpID")

            Parms(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
            Parms(11).Value = HttpContext.Current.Session("UserCode")

            Parms(12) = New SqlParameter("@Formula", SqlDbType.Int)
            Parms(12).Value = Formula

            Parms(13) = New SqlParameter("@Options2", SqlDbType.VarChar, Options2.Length)
            Parms(13).Value = Options2

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SaveRules", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function UpdateRule(ByVal AndRule As Integer, ByVal OrRule As Integer, ByVal Rule As Integer, ByVal Run As Integer, ByVal Assessment As String, ByVal Options As String, ByVal Value1 As String, ByVal Value2 As String, ByVal Formula As Integer, ByVal Autoid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(13) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@AndRule", SqlDbType.Int)
            Parms(2).Value = AndRule

            Parms(3) = New SqlParameter("@OrRule", SqlDbType.Int)
            Parms(3).Value = OrRule

            Parms(4) = New SqlParameter("@Rule", SqlDbType.Int)
            Parms(4).Value = Rule

            Parms(5) = New SqlParameter("@Run", SqlDbType.Int)
            Parms(5).Value = Run

            Parms(6) = New SqlParameter("@Assessment", SqlDbType.VarChar, Assessment.Length)
            Parms(6).Value = Assessment

            Parms(7) = New SqlParameter("@Options", SqlDbType.VarChar, Options.Length)
            Parms(7).Value = Options

            Parms(8) = New SqlParameter("@Value1", SqlDbType.VarChar, Value1.Length)
            Parms(8).Value = Value1

            Parms(9) = New SqlParameter("@Value2", SqlDbType.VarChar, Value1.Length)
            Parms(9).Value = Value2

            Parms(10) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 100)
            Parms(10).Value = HttpContext.Current.Session("EmpID")

            Parms(11) = New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
            Parms(11).Value = HttpContext.Current.Session("UserCode")

            Parms(12) = New SqlParameter("@Formula", SqlDbType.Int)
            Parms(12).Value = Formula

            Parms(13) = New SqlParameter("@Autoid", SqlDbType.Int)
            Parms(13).Value = Autoid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SaveRules", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetFormulaCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetFormulaCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DeleteRule(ByVal Formula As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 100)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
            Parms(3).Value = HttpContext.Current.Session("UserCode")

            Parms(4) = New SqlParameter("@Formula", SqlDbType.Int)
            Parms(4).Value = Formula

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DeleteRules", Parms)
            Return Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Shared Function GetRule(ByVal Formula As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Formula", SqlDbType.Int)
            Parms(2).Value = Formula

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetRules", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSubjectCategoryForRules", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectCategory1() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSubjectCategoryGrade", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
End Class
