Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web.Configuration
Imports System.Data.SqlClient
Public Class FeeStructureDB
    Public Function GetFullAcct_Head() As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetFullAcct_Head")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ChangeFalg(ByVal Id As Int64) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@ID", SqlDbType.Int)
        arParms.Value = Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_Fee_Structure_changeFlag", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Function Update(ByVal c As FeeStructure) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("InstituteID")

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BranchID")

        arParms(2) = New SqlParameter("@Course_Planner_ID", SqlDbType.Int)
        arParms(2).Value = c.Course_Planner_ID

        arParms(3) = New SqlParameter("@Semester_ID", SqlDbType.Int)
        arParms(3).Value = c.Semester_ID

        arParms(4) = New SqlParameter("@FeeHead_ID", SqlDbType.Int)
        arParms(4).Value = c.Fee_Head_ID

        arParms(5) = New SqlParameter("@Amount", SqlDbType.Real)
        arParms(5).Value = c.Amount

        arParms(6) = New SqlParameter("@Due_Date", SqlDbType.DateTime)
        arParms(6).Value = c.Due_date

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar, c.Remarks.Length)
        arParms(7).Value = c.Remarks

        arParms(8) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(8).Value = c.Fee_Structure_ID

        arParms(9) = New SqlParameter("@Sponsor", SqlDbType.Int)
        arParms(9).Value = c.Sponsor

        arParms(10) = New SqlParameter("@Discount", SqlDbType.Int)
        arParms(10).Value = c.Discount

        arParms(11) = New SqlParameter("@Category", SqlDbType.NChar, 10)
        arParms(11).Value = c.Category
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateFee_Structure", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function Insert(ByVal c As FeeStructure) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(10) {}

        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("InstituteID")

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BranchID")

        arParms(2) = New SqlParameter("@Course_Planner_ID", SqlDbType.Int)
        arParms(2).Value = c.Course_Planner_ID

        arParms(3) = New SqlParameter("@Semester_ID", SqlDbType.Int)
        arParms(3).Value = c.Semester_ID

        arParms(4) = New SqlParameter("@FeeHead_ID", SqlDbType.Int)
        arParms(4).Value = c.Fee_Head_ID

        arParms(5) = New SqlParameter("@Amount", SqlDbType.Real)
        arParms(5).Value = c.Amount

        arParms(6) = New SqlParameter("@Due_Date", SqlDbType.DateTime)
        arParms(6).Value = c.Due_date

        arParms(7) = New SqlParameter("@Remarks", SqlDbType.NVarChar, c.Remarks.Length)
        arParms(7).Value = c.Remarks

        arParms(8) = New SqlParameter("@Sponsor", SqlDbType.Int)
        arParms(8).Value = c.Sponsor

        arParms(9) = New SqlParameter("@Discount", SqlDbType.Int)
        arParms(9).Value = c.Discount

        arParms(10) = New SqlParameter("@Category", SqlDbType.NChar, 10)
        arParms(10).Value = c.Category
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertFee_Structure", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function GVFill(ByVal BrnId As Int64, ByVal InsID As Int64) As Data.DataTable
        Dim Connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = InsID

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = BrnId

        Try
            ds = SqlHelper.ExecuteDataset(Connectionstring, CommandType.StoredProcedure, "proc_Fee_Structure_Fill_GVFillBy_InsID_BrnID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GVFill(ByVal Id As Int64, ByVal BrnId As Int64, ByVal InsID As Int64) As Data.DataTable
        Dim Connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = InsID

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = BrnId

        arParms(2) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(2).Value = Id
        Try
            ds = SqlHelper.ExecuteDataset(Connectionstring, CommandType.StoredProcedure, "proc_Fee_Structure_Fill_GVFillBy_InsID_BrnID_FSID", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetFeeStructureByID(ByVal Id As Int64) As Data.DataTable
        Dim Connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim arParms As SqlParameter = New SqlParameter

        arParms = New SqlParameter("@FeeStructure_ID", SqlDbType.Int)
        arParms.Value = Id
        Try
            ds = SqlHelper.ExecuteDataset(Connectionstring, CommandType.StoredProcedure, "Proc_GetFeestructureById", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Reprot(ByVal Ins As Int64, ByVal Brn As Int64, ByVal Crs As Int64, ByVal Bth As Int64, ByVal Sem As Int64) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = Ins

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = Brn

        arParms(2) = New SqlParameter("@Course_ID", SqlDbType.Int)
        arParms(2).Value = Crs

        arParms(3) = New SqlParameter("@Batch_ID", SqlDbType.Int)
        arParms(3).Value = Bth

        arParms(4) = New SqlParameter("@Semester_ID", SqlDbType.Int)
        arParms(4).Value = Sem

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_Fee_Structure_Report", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function FillGrid(ByVal batch As Int64, ByVal semster As Int32) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(0).Value = batch

        arParms(1) = New SqlParameter("@semster", SqlDbType.Int)
        arParms(1).Value = semster

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GetFeeStructureByBatchanSemster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function FeeDueReprot(ByVal BatchId As Int64, ByVal SemID As Int64, ByVal StdID As Int64, ByVal CategoryID As Int64, ByVal CourseCode As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = BatchId

        arParms(3) = New SqlParameter("@SemID", SqlDbType.Int)
        arParms(3).Value = SemID

        arParms(4) = New SqlParameter("@StdID", SqlDbType.Int)
        arParms(4).Value = StdID

        arParms(5) = New SqlParameter("@CategoryID", SqlDbType.Int)
        arParms(5).Value = CategoryID

        arParms(6) = New SqlParameter("@CourseCode", SqlDbType.Int)
        arParms(6).Value = CourseCode

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_FeeDueStatement", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function RPT_GetFeeFinancialyrwise(ByVal Inst As Int16, ByVal Bran As Int16, ByVal Cour As Int16, ByVal Btch As Int16) As System.Data.DataTable
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As DataSet
            Dim rowsAffected As Integer = 0
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@Inst", SqlDbType.Int)
            arParms(0).Value = Inst

            arParms(1) = New SqlParameter("@Bran", SqlDbType.Int)
            arParms(1).Value = Bran

            arParms(2) = New SqlParameter("@Cour", SqlDbType.Int)
            arParms(2).Value = Cour

            arParms(3) = New SqlParameter("@Btch", SqlDbType.Int)
            arParms(3).Value = Btch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT * FROM View_GetFeeAmt_FinancialYear Where Institute_ID=" & Inst & " and Branch_ID=" & Bran & "and Course_ID=" & Cour & "and Batch=" & Btch)
            'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RPT_StudentwiseDetails", arParms)
            Return ds.Tables(0)

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
    Shared Function SponsorCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("InstituteID")

        arParms(1) = New SqlParameter("@brid", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BranchID")
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetSponsor", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getSemester(ByVal BatchId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = BatchId
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetSemesterOnBatchIdDDL", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getSemesterALL(ByVal BatchId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = BatchId
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetSemesterOnBatchIdDDLALL", arParms)
        Return ds.Tables(0)
    End Function
    Public Function getAcadamicYearALL(ByVal BatchId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = BatchId
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getAcadamicYearALL", arParms)
        Return ds.Tables(0)
    End Function
    Public Function FeeDueReprotSum(ByVal SemID As Int64, ByVal AcId As Int64, ByVal CategoryID As Int64, ByVal CourseCode As Integer) As Data.DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        arParms(2) = New SqlParameter("@SemID", SqlDbType.Int)
        arParms(2).Value = SemID

        arParms(3) = New SqlParameter("@AcId", SqlDbType.Int)
        arParms(3).Value = AcId

        arParms(4) = New SqlParameter("@CategoryID", SqlDbType.Int)
        arParms(4).Value = CategoryID

        arParms(5) = New SqlParameter("@CourseCode", SqlDbType.Int)
        arParms(5).Value = CourseCode

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_FeeDueStatementSum", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
