Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient

Public Class TimeTableDl
    Dim dt As New DataTable
    Dim query As String
    Dim ds As New DataSet

    Shared Function GetSubject(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubject", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetElecSubjectDDl(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_SelectElecSubject]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetAllElecSubjectDDl(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_AllElecSubject]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_SelectSubjectDdl]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetBatchCombo(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@CourseCode", SqlDbType.Int)
            Parms(2).Value = Courseid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TimeTableBatchCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetMeritListBatchCombo(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@CourseCode", SqlDbType.Int)
            Parms(2).Value = Courseid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MeritListBatchCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetBatchComboForum() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TimeTableBatchComboForum", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function insert(ByVal Prop As TimeTableEL) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(49) {}
        Dim rowsAffected As Integer = 0


        arParms(0) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(0).Value = Prop.CourseId

        arParms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(1).Value = Prop.BatchId

        arParms(2) = New SqlParameter("@SemesterID", SqlDbType.Int)
        arParms(2).Value = Prop.SemId


        arParms(3) = New SqlParameter("@Period", SqlDbType.VarChar)
        arParms(3).Value = Prop.Period

        arParms(4) = New SqlParameter("@SubjectID1", SqlDbType.Int)
        arParms(4).Value = Prop.Day1Sub

        arParms(5) = New SqlParameter("@SubjectID2", SqlDbType.Int)
        arParms(5).Value = Prop.Day2Sub

        arParms(6) = New SqlParameter("@SubjectID3", SqlDbType.Int)
        arParms(6).Value = Prop.Day3Sub

        arParms(7) = New SqlParameter("@SubjectID4", SqlDbType.Int)
        arParms(7).Value = Prop.Day4Sub

        arParms(8) = New SqlParameter("@SubjectID5", SqlDbType.Int)
        arParms(8).Value = Prop.Day5Sub

        arParms(9) = New SqlParameter("@SubjectID6", SqlDbType.Int)
        arParms(9).Value = Prop.Day6Sub

        arParms(10) = New SqlParameter("SubjectID7", SqlDbType.Int)
        arParms(10).Value = Prop.Day7Sub

        arParms(11) = New SqlParameter("@TeacherID1", SqlDbType.Int)
        arParms(11).Value = Prop.Day1Teacher

        arParms(12) = New SqlParameter("@TeacherID2", SqlDbType.Int)
        arParms(12).Value = Prop.Day2Teacher

        arParms(13) = New SqlParameter("TeacherID3", SqlDbType.Int)
        arParms(13).Value = Prop.Day3Teacher

        arParms(14) = New SqlParameter("TeacherID4", SqlDbType.Int)
        arParms(14).Value = Prop.Day4Teacher

        arParms(15) = New SqlParameter("TeacherID5", SqlDbType.Int)
        arParms(15).Value = Prop.Day5Teacher

        arParms(16) = New SqlParameter("TeacherID6", SqlDbType.Int)
        arParms(16).Value = Prop.Day6Teacher

        arParms(17) = New SqlParameter("TeacherID7", SqlDbType.Int)
        arParms(17).Value = Prop.Day7Teacher

        If Prop.Day1StartTime = "1/1/1900" Then
            arParms(18) = New SqlParameter("@StartTime1", SqlDbType.VarChar)
            arParms(18).Value = DBNull.Value
        Else
            arParms(18) = New SqlParameter("@StartTime1", SqlDbType.DateTime)
            arParms(18).Value = Prop.Day1StartTime
        End If

        If Prop.Day2StartTime = "1/1/1900" Then
            arParms(19) = New SqlParameter("StartTime2", SqlDbType.VarChar)
            arParms(19).Value = DBNull.Value
        Else
            arParms(19) = New SqlParameter("StartTime2", SqlDbType.DateTime)
            arParms(19).Value = Prop.Day2StartTime
        End If
        If Prop.Day3StartTime = "1/1/1900" Then
            arParms(20) = New SqlParameter("StartTime3", SqlDbType.VarChar)
            arParms(20).Value = DBNull.Value
        Else
            arParms(20) = New SqlParameter("StartTime3", SqlDbType.DateTime)
            arParms(20).Value = Prop.Day3StartTime
        End If
        If Prop.Day4StartTime = "1/1/1900" Then
            arParms(21) = New SqlParameter("StartTime4", SqlDbType.VarChar)
            arParms(21).Value = DBNull.Value
        Else
            arParms(21) = New SqlParameter("StartTime4", SqlDbType.DateTime)
            arParms(21).Value = Prop.Day4StartTime
        End If

        If Prop.Day5StartTime = "1/1/1900" Then
            arParms(22) = New SqlParameter("StartTime5", SqlDbType.VarChar)
            arParms(22).Value = DBNull.Value
        Else
            arParms(22) = New SqlParameter("StartTime5", SqlDbType.DateTime)
            arParms(22).Value = Prop.Day5StartTime
        End If

        If Prop.Day6StartTime = "1/1/1900" Then
            arParms(23) = New SqlParameter("StartTime6", SqlDbType.VarChar)
            arParms(23).Value = DBNull.Value
        Else
            arParms(23) = New SqlParameter("StartTime6", SqlDbType.DateTime)
            arParms(23).Value = Prop.Day6StartTime
        End If
        If Prop.Day7StartTime = "1/1/1900" Then
            arParms(24) = New SqlParameter("StartTime7", SqlDbType.VarChar)
            arParms(24).Value = DBNull.Value
        Else
            arParms(24) = New SqlParameter("StartTime7", SqlDbType.DateTime)
            arParms(24).Value = Prop.Day7StartTime
        End If
        If Prop.Day1EndTime = "1/1/1900" Then
            arParms(25) = New SqlParameter("@EndTime1", SqlDbType.VarChar)
            arParms(25).Value = DBNull.Value
        Else
            arParms(25) = New SqlParameter("@EndTime1", SqlDbType.DateTime)
            arParms(25).Value = Prop.Day1EndTime
        End If
        If Prop.Day2EndTime = "1/1/1900" Then
            arParms(26) = New SqlParameter("@EndTime2", SqlDbType.VarChar)
            arParms(26).Value = DBNull.Value
        Else
            arParms(26) = New SqlParameter("@EndTime2", SqlDbType.DateTime)
            arParms(26).Value = Prop.Day2EndTime
        End If
        If Prop.Day3EndTime = "1/1/1900" Then
            arParms(27) = New SqlParameter("@EndTime3", SqlDbType.VarChar)
            arParms(27).Value = DBNull.Value
        Else
            arParms(27) = New SqlParameter("@EndTime3", SqlDbType.DateTime)
            arParms(27).Value = Prop.Day3EndTime
        End If
        If Prop.Day4EndTime = "1/1/1900" Then
            arParms(28) = New SqlParameter("@EndTime4", SqlDbType.VarChar)
            arParms(28).Value = DBNull.Value
        Else
            arParms(28) = New SqlParameter("@EndTime4", SqlDbType.DateTime)
            arParms(28).Value = Prop.Day4EndTime
        End If
        If Prop.Day5EndTime = "1/1/1900" Then
            arParms(29) = New SqlParameter("@EndTime5", SqlDbType.VarChar)
            arParms(29).Value = DBNull.Value
        Else
            arParms(29) = New SqlParameter("@EndTime5", SqlDbType.DateTime)
            arParms(29).Value = Prop.Day5EndTime
        End If
        If Prop.Day6EndTime = "1/1/1900" Then
            arParms(30) = New SqlParameter("@EndTime6", SqlDbType.VarChar)
            arParms(30).Value = DBNull.Value
        Else
            arParms(30) = New SqlParameter("@EndTime6", SqlDbType.DateTime)
            arParms(30).Value = Prop.Day6EndTime
        End If
        If Prop.Day7EndTime = "1/1/1900" Then
            arParms(31) = New SqlParameter("@EndTime7", SqlDbType.VarChar)
            arParms(31).Value = DBNull.Value
        Else
            arParms(31) = New SqlParameter("@EndTime7", SqlDbType.DateTime)
            arParms(31).Value = Prop.Day7EndTime
        End If

        arParms(32) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(32).Value = HttpContext.Current.Session("UserCode")

        arParms(33) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(33).Value = HttpContext.Current.Session("EmpCode")

        arParms(34) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(34).Value = HttpContext.Current.Session("BranchCode")

        arParms(35) = New SqlParameter("@RId1", SqlDbType.Int)
        arParms(35).Value = Prop.RId1

        arParms(36) = New SqlParameter("@RId2", SqlDbType.Int)
        arParms(36).Value = Prop.RId2

        arParms(37) = New SqlParameter("@RId3", SqlDbType.Int)
        arParms(37).Value = Prop.RId3

        arParms(38) = New SqlParameter("@RId4", SqlDbType.Int)
        arParms(38).Value = Prop.RId4

        arParms(39) = New SqlParameter("@RId5", SqlDbType.Int)
        arParms(39).Value = Prop.RId5

        arParms(40) = New SqlParameter("@RId6", SqlDbType.Int)
        arParms(40).Value = Prop.RId6

        arParms(41) = New SqlParameter("@RId7", SqlDbType.Int)
        arParms(41).Value = Prop.RId7

        arParms(42) = New SqlParameter("@Remarks1", SqlDbType.VarChar, 255)
        arParms(42).Value = Prop.Remarks1

        arParms(43) = New SqlParameter("@Remarks2", SqlDbType.VarChar, 255)
        arParms(43).Value = Prop.Remarks2

        arParms(44) = New SqlParameter("@Remarks3", SqlDbType.VarChar, 255)
        arParms(44).Value = Prop.Remarks3

        arParms(45) = New SqlParameter("@Remarks4", SqlDbType.VarChar, 255)
        arParms(45).Value = Prop.Remarks4

        arParms(46) = New SqlParameter("@Remarks5", SqlDbType.VarChar, 255)
        arParms(46).Value = Prop.Remarks5

        arParms(47) = New SqlParameter("@Remarks6", SqlDbType.VarChar, 255)
        arParms(47).Value = Prop.Remarks6

        arParms(48) = New SqlParameter("@Remarks7", SqlDbType.VarChar, 255)
        arParms(48).Value = Prop.Remarks7
        arParms(49) = New SqlParameter("@WeekNo", SqlDbType.Int)
        arParms(49).Value = Prop.WeekNo
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveTimeTable", arParms)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function GetData(ByVal el As TimeTableEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(5) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@SemesterID", SqlDbType.Int)
            arParms(2).Value = el.SemId

            arParms(3) = New SqlParameter("@BatchID", SqlDbType.Int)
            arParms(3).Value = el.BatchId

            arParms(4) = New SqlParameter("@TTID", SqlDbType.Int)
            arParms(4).Value = el.Id
            arParms(5) = New SqlParameter("@WeekNo", SqlDbType.Int)
            arParms(5).Value = el.WeekNo
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetTimeTable", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
        'Return ds.Tables(0)
    End Function
    Shared Function Delete(ByVal id As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@TTID", SqlDbType.Int)
        arParms(0).Value = id

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteTimeTable", arParms)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetDuplicatedata(ByVal el As TimeTableEL) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try

            Dim Parms() As SqlParameter = New SqlParameter(31) {}

            Parms(0) = New SqlParameter("@Period", SqlDbType.VarChar)
            Parms(0).Value = el.Period

            Parms(1) = New SqlParameter("@TeacherID1", SqlDbType.Int)
            Parms(1).Value = el.Day1Teacher

            Parms(2) = New SqlParameter("@TeacherID2", SqlDbType.Int)
            Parms(2).Value = el.Day2Teacher

            Parms(3) = New SqlParameter("@TeacherID3", SqlDbType.Int)
            Parms(3).Value = el.Day3Teacher

            Parms(4) = New SqlParameter("@TeacherID4", SqlDbType.Int)
            Parms(4).Value = el.Day4Teacher

            Parms(5) = New SqlParameter("@TeacherID5", SqlDbType.Int)
            Parms(5).Value = el.Day5Teacher

            Parms(6) = New SqlParameter("@TeacherID6", SqlDbType.Int)
            Parms(6).Value = el.Day6Teacher

            Parms(7) = New SqlParameter("@TeacherID7", SqlDbType.Int)
            Parms(7).Value = el.Day7Teacher

            If el.Day1StartTime = "1/1/1900" Then
                Parms(8) = New SqlParameter("@StartTime1", SqlDbType.VarChar)
                Parms(8).Value = DBNull.Value
            Else
                Parms(8) = New SqlParameter("@StartTime1", SqlDbType.DateTime)
                Parms(8).Value = el.Day1StartTime
            End If

            If el.Day2StartTime = "1/1/1900" Then
                Parms(9) = New SqlParameter("StartTime2", SqlDbType.VarChar)
                Parms(9).Value = DBNull.Value
            Else
                Parms(9) = New SqlParameter("StartTime2", SqlDbType.DateTime)
                Parms(9).Value = el.Day2StartTime
            End If

            If el.Day3StartTime = "1/1/1900" Then
                Parms(10) = New SqlParameter("StartTime3", SqlDbType.VarChar)
                Parms(10).Value = DBNull.Value
            Else
                Parms(10) = New SqlParameter("StartTime3", SqlDbType.DateTime)
                Parms(10).Value = el.Day3StartTime
            End If
            If el.Day4StartTime = "1/1/1900" Then
                Parms(11) = New SqlParameter("StartTime4", SqlDbType.VarChar)
                Parms(11).Value = DBNull.Value
            Else
                Parms(11) = New SqlParameter("StartTime4", SqlDbType.DateTime)
                Parms(11).Value = el.Day4StartTime
            End If

            If el.Day5StartTime = "1/1/1900" Then
                Parms(12) = New SqlParameter("StartTime5", SqlDbType.VarChar)
                Parms(12).Value = DBNull.Value
            Else
                Parms(12) = New SqlParameter("StartTime5", SqlDbType.DateTime)
                Parms(12).Value = el.Day5StartTime
            End If

            If el.Day6StartTime = "1/1/1900" Then
                Parms(13) = New SqlParameter("StartTime6", SqlDbType.VarChar)
                Parms(13).Value = DBNull.Value
            Else
                Parms(13) = New SqlParameter("StartTime6", SqlDbType.DateTime)
                Parms(13).Value = el.Day6StartTime
            End If
            If el.Day7StartTime = "1/1/1900" Then
                Parms(14) = New SqlParameter("StartTime7", SqlDbType.VarChar)
                Parms(14).Value = DBNull.Value
            Else
                Parms(14) = New SqlParameter("StartTime7", SqlDbType.DateTime)
                Parms(14).Value = el.Day7StartTime
            End If
            If el.Day1EndTime = "1/1/1900" Then
                Parms(15) = New SqlParameter("@EndTime1", SqlDbType.VarChar)
                Parms(15).Value = DBNull.Value
            Else
                Parms(15) = New SqlParameter("@EndTime1", SqlDbType.DateTime)
                Parms(15).Value = el.Day1EndTime
            End If
            If el.Day2EndTime = "1/1/1900" Then
                Parms(16) = New SqlParameter("@EndTime2", SqlDbType.VarChar)
                Parms(16).Value = DBNull.Value
            Else
                Parms(16) = New SqlParameter("@EndTime2", SqlDbType.DateTime)
                Parms(16).Value = el.Day2EndTime
            End If
            If el.Day3EndTime = "1/1/1900" Then
                Parms(17) = New SqlParameter("@EndTime3", SqlDbType.VarChar)
                Parms(17).Value = DBNull.Value
            Else
                Parms(17) = New SqlParameter("@EndTime3", SqlDbType.DateTime)
                Parms(17).Value = el.Day3EndTime
            End If
            If el.Day4EndTime = "1/1/1900" Then
                Parms(18) = New SqlParameter("@EndTime4", SqlDbType.VarChar)
                Parms(18).Value = DBNull.Value
            Else
                Parms(18) = New SqlParameter("@EndTime4", SqlDbType.DateTime)
                Parms(18).Value = el.Day4EndTime
            End If
            If el.Day5EndTime = "1/1/1900" Then
                Parms(19) = New SqlParameter("@EndTime5", SqlDbType.VarChar)
                Parms(19).Value = DBNull.Value
            Else
                Parms(19) = New SqlParameter("@EndTime5", SqlDbType.DateTime)
                Parms(19).Value = el.Day5EndTime
            End If
            If el.Day6EndTime = "1/1/1900" Then
                Parms(20) = New SqlParameter("@EndTime6", SqlDbType.VarChar)
                Parms(20).Value = DBNull.Value
            Else
                Parms(20) = New SqlParameter("@EndTime6", SqlDbType.DateTime)
                Parms(20).Value = el.Day6EndTime
            End If
            If el.Day7EndTime = "1/1/1900" Then
                Parms(21) = New SqlParameter("@EndTime7", SqlDbType.VarChar)
                Parms(21).Value = DBNull.Value
            Else
                Parms(21) = New SqlParameter("@EndTime7", SqlDbType.DateTime)
                Parms(21).Value = el.Day7EndTime
            End If

            Parms(22) = New SqlParameter("@ResourceID1", SqlDbType.Int)
            Parms(22).Value = el.RId1


            Parms(23) = New SqlParameter("@ResourceID2", SqlDbType.Int)
            Parms(23).Value = el.RId2


            Parms(24) = New SqlParameter("@ResourceID3", SqlDbType.Int)
            Parms(24).Value = el.RId3


            Parms(25) = New SqlParameter("@ResourceID4", SqlDbType.Int)
            Parms(25).Value = el.RId4


            Parms(26) = New SqlParameter("@ResourceID5", SqlDbType.Int)
            Parms(26).Value = el.RId5


            Parms(27) = New SqlParameter("@ResourceID6", SqlDbType.Int)
            Parms(27).Value = el.RId6


            Parms(28) = New SqlParameter("@ResourceID7", SqlDbType.Int)
            Parms(28).Value = el.RId7

            Parms(29) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 100)
            Parms(29).Value = HttpContext.Current.Session("BranchCode")

            Parms(30) = New SqlParameter("@Id", SqlDbType.Int)
            Parms(30).Value = el.Id

            Parms(31) = New SqlParameter("@WeekNo", SqlDbType.Int)
            Parms(31).Value = el.WeekNo

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateTimeTable", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function

    Shared Function Update(ByVal Prop As TimeTableEL) As Int64
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(50) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@TTID", SqlDbType.Int)
        arParms(0).Value = Prop.Id

        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = Prop.CourseId

        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = Prop.BatchId

        arParms(3) = New SqlParameter("@SemesterID", SqlDbType.Int)
        arParms(3).Value = Prop.SemId

        arParms(4) = New SqlParameter("@Period", SqlDbType.VarChar)
        arParms(4).Value = Prop.Period

        arParms(5) = New SqlParameter("@SubjectID1", SqlDbType.Int)
        arParms(5).Value = Prop.Day1Sub

        arParms(6) = New SqlParameter("@SubjectID2", SqlDbType.Int)
        arParms(6).Value = Prop.Day2Sub

        arParms(7) = New SqlParameter("@SubjectID3", SqlDbType.Int)
        arParms(7).Value = Prop.Day3Sub

        arParms(8) = New SqlParameter("@SubjectID4", SqlDbType.Int)
        arParms(8).Value = Prop.Day4Sub

        arParms(9) = New SqlParameter("@SubjectID5", SqlDbType.Int)
        arParms(9).Value = Prop.Day5Sub

        arParms(10) = New SqlParameter("@SubjectID6", SqlDbType.Int)
        arParms(10).Value = Prop.Day6Sub

        arParms(11) = New SqlParameter("SubjectID7", SqlDbType.Int)
        arParms(11).Value = Prop.Day7Sub

        arParms(12) = New SqlParameter("@TeacherID1", SqlDbType.Int)
        arParms(12).Value = Prop.Day1Teacher

        arParms(13) = New SqlParameter("@TeacherID2", SqlDbType.Int)
        arParms(13).Value = Prop.Day2Teacher

        arParms(14) = New SqlParameter("TeacherID3", SqlDbType.Int)
        arParms(14).Value = Prop.Day3Teacher

        arParms(15) = New SqlParameter("TeacherID4", SqlDbType.Int)
        arParms(15).Value = Prop.Day4Teacher

        arParms(16) = New SqlParameter("TeacherID5", SqlDbType.Int)
        arParms(16).Value = Prop.Day5Teacher

        arParms(17) = New SqlParameter("TeacherID6", SqlDbType.Int)
        arParms(17).Value = Prop.Day6Teacher

        arParms(18) = New SqlParameter("TeacherID7", SqlDbType.Int)
        arParms(18).Value = Prop.Day7Teacher

        If Prop.Day1StartTime = "1/1/1900" Then
            arParms(19) = New SqlParameter("@StartTime1", SqlDbType.VarChar)
            arParms(19).Value = DBNull.Value
        Else
            arParms(19) = New SqlParameter("@StartTime1", SqlDbType.DateTime)
            arParms(19).Value = Prop.Day1StartTime
        End If

        If Prop.Day2StartTime = "1/1/1900" Then
            arParms(20) = New SqlParameter("StartTime2", SqlDbType.VarChar)
            arParms(20).Value = DBNull.Value
        Else
            arParms(20) = New SqlParameter("StartTime2", SqlDbType.DateTime)
            arParms(20).Value = Prop.Day2StartTime
        End If
        If Prop.Day3StartTime = "1/1/1900" Then
            arParms(21) = New SqlParameter("StartTime3", SqlDbType.VarChar)
            arParms(21).Value = DBNull.Value
        Else
            arParms(21) = New SqlParameter("StartTime3", SqlDbType.DateTime)
            arParms(21).Value = Prop.Day3StartTime
        End If
        If Prop.Day4StartTime = "1/1/1900" Then
            arParms(22) = New SqlParameter("StartTime4", SqlDbType.VarChar)
            arParms(22).Value = DBNull.Value
        Else
            arParms(22) = New SqlParameter("StartTime4", SqlDbType.DateTime)
            arParms(22).Value = Prop.Day4StartTime
        End If

        If Prop.Day5StartTime = "1/1/1900" Then
            arParms(23) = New SqlParameter("StartTime5", SqlDbType.VarChar)
            arParms(23).Value = DBNull.Value
        Else
            arParms(23) = New SqlParameter("StartTime5", SqlDbType.DateTime)
            arParms(23).Value = Prop.Day5StartTime
        End If

        If Prop.Day6StartTime = "1/1/1900" Then
            arParms(24) = New SqlParameter("StartTime6", SqlDbType.VarChar)
            arParms(24).Value = DBNull.Value
        Else
            arParms(24) = New SqlParameter("StartTime6", SqlDbType.DateTime)
            arParms(24).Value = Prop.Day6StartTime
        End If
        If Prop.Day7StartTime = "1/1/1900" Then
            arParms(25) = New SqlParameter("StartTime7", SqlDbType.VarChar)
            arParms(25).Value = DBNull.Value
        Else
            arParms(25) = New SqlParameter("StartTime7", SqlDbType.DateTime)
            arParms(25).Value = Prop.Day7StartTime
        End If
        If Prop.Day1EndTime = "1/1/1900" Then
            arParms(26) = New SqlParameter("@EndTime1", SqlDbType.VarChar)
            arParms(26).Value = DBNull.Value
        Else
            arParms(26) = New SqlParameter("@EndTime1", SqlDbType.DateTime)
            arParms(26).Value = Prop.Day1EndTime
        End If
        If Prop.Day2EndTime = "1/1/1900" Then
            arParms(27) = New SqlParameter("@EndTime2", SqlDbType.VarChar)
            arParms(27).Value = DBNull.Value
        Else
            arParms(27) = New SqlParameter("@EndTime2", SqlDbType.DateTime)
            arParms(27).Value = Prop.Day2EndTime
        End If
        If Prop.Day3EndTime = "1/1/1900" Then
            arParms(28) = New SqlParameter("@EndTime3", SqlDbType.VarChar)
            arParms(28).Value = DBNull.Value
        Else
            arParms(28) = New SqlParameter("@EndTime3", SqlDbType.DateTime)
            arParms(28).Value = Prop.Day3EndTime
        End If
        If Prop.Day4EndTime = "1/1/1900" Then
            arParms(29) = New SqlParameter("@EndTime4", SqlDbType.VarChar)
            arParms(29).Value = DBNull.Value
        Else
            arParms(29) = New SqlParameter("@EndTime4", SqlDbType.DateTime)
            arParms(29).Value = Prop.Day4EndTime
        End If
        If Prop.Day5EndTime = "1/1/1900" Then
            arParms(30) = New SqlParameter("@EndTime5", SqlDbType.VarChar)
            arParms(30).Value = DBNull.Value
        Else
            arParms(30) = New SqlParameter("@EndTime5", SqlDbType.DateTime)
            arParms(30).Value = Prop.Day5EndTime
        End If
        If Prop.Day6EndTime = "1/1/1900" Then
            arParms(31) = New SqlParameter("@EndTime6", SqlDbType.VarChar)
            arParms(31).Value = DBNull.Value
        Else
            arParms(31) = New SqlParameter("@EndTime6", SqlDbType.DateTime)
            arParms(31).Value = Prop.Day6EndTime
        End If
        If Prop.Day7EndTime = "1/1/1900" Then
            arParms(32) = New SqlParameter("@EndTime7", SqlDbType.VarChar)
            arParms(32).Value = DBNull.Value
        Else
            arParms(32) = New SqlParameter("@EndTime7", SqlDbType.DateTime)
            arParms(32).Value = Prop.Day7EndTime
        End If
        arParms(33) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(33).Value = HttpContext.Current.Session("UserCode")

        arParms(34) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(34).Value = HttpContext.Current.Session("EmpCode")

        arParms(35) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(35).Value = HttpContext.Current.Session("BranchCode")

        arParms(36) = New SqlParameter("@RId1", SqlDbType.Int)
        arParms(36).Value = Prop.RId1

        arParms(37) = New SqlParameter("@RId2", SqlDbType.Int)
        arParms(37).Value = Prop.RId2

        arParms(38) = New SqlParameter("@RId3", SqlDbType.Int)
        arParms(38).Value = Prop.RId3

        arParms(39) = New SqlParameter("@RId4", SqlDbType.Int)
        arParms(39).Value = Prop.RId4

        arParms(40) = New SqlParameter("@RId5", SqlDbType.Int)
        arParms(40).Value = Prop.RId5

        arParms(41) = New SqlParameter("@RId6", SqlDbType.Int)
        arParms(41).Value = Prop.RId6

        arParms(42) = New SqlParameter("@RId7", SqlDbType.Int)
        arParms(42).Value = Prop.RId7

        arParms(43) = New SqlParameter("@Remarks1", SqlDbType.VarChar, 255)
        arParms(43).Value = Prop.Remarks1

        arParms(44) = New SqlParameter("@Remarks2", SqlDbType.VarChar, 255)
        arParms(44).Value = Prop.Remarks2

        arParms(45) = New SqlParameter("@Remarks3", SqlDbType.VarChar, 255)
        arParms(45).Value = Prop.Remarks3

        arParms(46) = New SqlParameter("@Remarks4", SqlDbType.VarChar, 255)
        arParms(46).Value = Prop.Remarks4

        arParms(47) = New SqlParameter("@Remarks5", SqlDbType.VarChar, 255)
        arParms(47).Value = Prop.Remarks5

        arParms(48) = New SqlParameter("@Remarks6", SqlDbType.VarChar, 255)
        arParms(48).Value = Prop.Remarks6

        arParms(49) = New SqlParameter("@Remarks7", SqlDbType.VarChar, 255)
        arParms(49).Value = Prop.Remarks7
        arParms(50) = New SqlParameter("@WeekNo", SqlDbType.Int)
        arParms(50).Value = Prop.WeekNo

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateTimeTable", arParms)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ViewRecord(ByVal el As TimeTableEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(6) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@SemId", SqlDbType.Int)
            arParms(2).Value = el.SemId

            arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
            arParms(3).Value = el.BatchId

            arParms(4) = New SqlParameter("@TeacherId", SqlDbType.Int)
            arParms(4).Value = el.TeacherId

            arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
            arParms(5).Value = el.SubjectId

            arParms(6) = New SqlParameter("@CourseId", SqlDbType.Int)
            arParms(6).Value = el.CourseId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TimeTableCalender", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function ViewRecord1(ByVal el As TimeTableEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(6) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            arParms(2) = New SqlParameter("@SemId", SqlDbType.Int)
            arParms(2).Value = el.SemId

            arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
            arParms(3).Value = el.BatchId

            arParms(4) = New SqlParameter("@TeacherId", SqlDbType.Int)
            arParms(4).Value = el.TeacherId

            arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
            arParms(5).Value = el.SubjectId

            arParms(6) = New SqlParameter("@CourseId", SqlDbType.Int)
            arParms(6).Value = el.CourseId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TimeTableTeacher", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ViewHolidayRecord(ByVal el As TimeTableEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(2) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@HM_ID", SqlDbType.Int)
            arParms(2).Value = el.HMId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetHolidayMaster", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetEmployeeCombo(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "PRoc_EmployeeCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchCombo1(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@CourseCode", SqlDbType.Int)
            Parms(2).Value = Courseid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_TimeTableBatchCombo1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Function SemesterComboD1(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee11", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function


    Shared Function GetresourceAllocationCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetResourceAllocation", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function ViewHolidayDeatils() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetHolidayDetails]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetHolidayDeatils() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_GetHolidayDetails]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ViewCalOfEvents(ByVal FromDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@FrmDate", SqlDbType.Date)
            arParms(2).Value = FromDate

            arParms(3) = New SqlParameter("@ToDate", SqlDbType.Date)
            arParms(3).Value = ToDate


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_CalendarOfEvents]", arParms)
            Return ds.Tables(1)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function RptCalOfEvents(ByVal FromDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@FrmDate", SqlDbType.Date)
            arParms(2).Value = FromDate

            arParms(3) = New SqlParameter("@ToDate", SqlDbType.Date)
            arParms(3).Value = ToDate


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_CalOfEvents]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetWeekNo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetWeekNo", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetWeekAutoFill(ByVal el As TimeTableEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(3) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("Office")

            arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
            arParms(2).Value = el.CourseId

            arParms(3) = New SqlParameter("@SemesterID", SqlDbType.Int)
            arParms(3).Value = el.SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetWeekAutoFill", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
