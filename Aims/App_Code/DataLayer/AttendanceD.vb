Imports System.Data
Imports System.Data.SqlClient
Public Class AttendanceD
    Dim dt As Data.DataTable
    Dim str As String
    'Dim prop As New AttendanceP
    Public Function UpdateDel(ByVal a As AttendanceP) As Integer
        Dim rowsaffected As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = a.Id
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_EmployeeAttendence_UpdateDel", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Public Function GetdeptData() As DataTable
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getDepatmentFllCombo", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function rptempattendence(ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal branch As String, ByVal Ecode As String) As DataTable
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = branch
        arParms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(2).Value = FromDate
        arParms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(3).Value = ToDate
        arParms(4) = New SqlParameter("@Ecode", SqlDbType.VarChar, 50)
        arParms(4).Value = Ecode


        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_EmpAttendance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetDataByCheckingLogin(ByVal Date1 As Date, ByVal DeptId As Integer, ByVal Empid As String) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Date1", SqlDbType.DateTime)
        arParms(2).Value = Date1

        arParms(3) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(3).Value = DeptId

        arParms(4) = New SqlParameter("@Empid", SqlDbType.VarChar, 50)
        arParms(4).Value = Empid

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDataByCheckingLoginparam", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.AttendanceDataTable) As Integer

    '    Dim returnValue As Integer = Update(dataTable)

    'End Function
    Public Function UpdateLogOff(ByVal Logoff As Date, ByVal log As DateTime, ByVal id As Integer) As Integer
        Dim RowsAffected As New Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Logoff", SqlDbType.DateTime)
        arParms(0).Value = Logoff

        arParms(1) = New SqlParameter("@log", SqlDbType.DateTime)
        arParms(1).Value = log

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        Try
            RowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateLogOffEmpAttendence", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return RowsAffected
    End Function
    Public Function UpdateLogin(ByVal Login As Date, ByVal log As DateTime, ByVal id As Integer) As Integer
        Dim RowsAffected As New Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Login", SqlDbType.DateTime)
        arParms(0).Value = Login

        arParms(1) = New SqlParameter("@log", SqlDbType.DateTime)
        arParms(1).Value = log

        arParms(2) = New SqlParameter("@id", SqlDbType.Int)
        arParms(2).Value = id

        Try
            RowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateLoginEmpAttendence", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return RowsAffected
    End Function
    Public Function GetDataByEmp(ByVal DeptId As Int32, ByVal doj As Date, ByVal dol As Date, ByVal Category As Int16, ByVal insid As Int64, ByVal brnid As Int64) As Data.DataTable
        '''''''''' proc_GetDataByEmp()
        'str = "SELECT AccountNo, Bank_ID, Branch_ID, Contact_No1, Contact_No2, Country, DOB, DOJ, DOL, Del_Flag, Dept_ID, Designation, Email, Emp_Address," & _
        '     "Emp_City, Emp_Code, Emp_Id, Emp_Name, Institute_ID, OpBalanceDate, Opening_Balance_CR, Opening_Balance_DR, Photos, Remarks, Salary," & _
        '     "State, Zip, Category FROM(EmployeeMaster) WHERE (Del_Flag = 0) AND (Dept_ID = @Deptid) AND (DOJ <= @doj) AND (DOL >= @dol OR DOL = #1/1/2001#) AND (Category = @Category) AND (Institute_ID = @insid) AND (Branch_ID = @brnid)"

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim arParms() As SqlParameter = New SqlParameter(5) {}

            arParms(0) = New SqlParameter("@Deptid", SqlDbType.Int)
            arParms(0).Value = DeptId

            arParms(1) = New SqlParameter("@doj", SqlDbType.DateTime)
            arParms(1).Value = doj

            arParms(2) = New SqlParameter("@dol", SqlDbType.DateTime)
            arParms(2).Value = dol

            arParms(3) = New SqlParameter("@Category", SqlDbType.Int)
            arParms(3).Value = Category

            arParms(4) = New SqlParameter("@insid", SqlDbType.Int)
            arParms(4).Value = insid

            arParms(5) = New SqlParameter("@brnid", SqlDbType.Int)
            arParms(5).Value = brnid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDataByEmp", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Class StudentAttendance
        Dim dt As Data.DataTable
        Dim str As String
        Public Function GetDataByChecking(ByVal insid As Int64, ByVal Brnid As Int64, ByVal CrsId As Int32, ByVal batchno As String, ByVal SubjectId As Int32, ByVal monthid As Int32, ByVal yearid As Int32) As Boolean

            '''''''''''''''proc_EmpAtte_GetDataByChecking()
            ' str = "Select Attendance.AttendanceID FROM(Attendance) WHERE (((Attendance.Institute_ID)=@insid) AND ((Attendance.Branch_ID)=@Brnid) AND ((Attendance.Course_ID)=@CrsId) AND ((Attendance.BatchNo)=@batchno) AND ((Attendance.Subject_ID)=@SubjectId) AND ((Attendance.Month)=@monthid) AND ((Attendance.Year)=@Year) AND ((Attendance.Del_Flag)=0))"
            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(6) {}

                arParms(0) = New SqlParameter("@insid", SqlDbType.Int)
                arParms(0).Value = insid

                arParms(1) = New SqlParameter("@Brnid", SqlDbType.Int)
                arParms(1).Value = Brnid

                arParms(2) = New SqlParameter("@CrsId", SqlDbType.Int)
                arParms(2).Value = CrsId

                arParms(3) = New SqlParameter("@batchno", SqlDbType.VarChar, 50)
                arParms(3).Value = batchno

                arParms(4) = New SqlParameter("@SubjectId", SqlDbType.Int)
                arParms(4).Value = SubjectId

                arParms(5) = New SqlParameter("@monthid", SqlDbType.Int)
                arParms(5).Value = monthid

                arParms(6) = New SqlParameter("@Year", SqlDbType.Int)
                arParms(6).Value = yearid

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_GetDataByChecking", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        Public Function GetDataByCourseDate(ByVal insid As Int64, ByVal Brnid As Int64, ByVal CrsId As Int32, ByVal batchno As Int64, ByVal SubjectId As Int32, ByVal monthid As String, ByVal yearid As Int32, ByVal SemsterId As Int64) As Data.DataTable

            Dim ds As New Data.DataSet
            Dim dt, dt1, dt2 As Data.DataTable

            dt = New Data.DataTable
            dt.Columns.Add("StdId")
            dt.Columns.Add("StdName")
            dt.Columns.Add("StdCode")
            dt.Columns.Add("Course_ID")
            dt.Columns.Add("InstituteName")
            dt.Columns.Add("CourseName")
            dt.Columns.Add("BranchName")
            dt.Columns.Add("Institute_ID")
            dt.Columns.Add("Branch_ID")
            dt.Columns.Add("ID")
            dt.Columns.Add("Batch_No")
            dt.Columns.Add("TotalAttendance", GetType(Int32))
            dt.Columns.Add("TotalClass", GetType(Int32))
            dt.Columns.Add("AttendanceID")
            dt.Columns.Add("Subject_ID")
            dt.Columns.Add("Year")
            dt.Columns.Add("Month")
            dt.Columns.Add("Month1")
            dt.Columns.Add("Subject_Name")
            ' proc_EmpAtte_GetDataByCourseDate()
            ' str = "SELECT StdId, TotalAttendance, TotalClass, AttendanceID, Institute_ID, Branch_ID, Course_ID, BatchNo,Attendance.Subject_ID, [Year], [Month] , SubjectMaster.Subject_Name  FROM Attendance  LEFT JOIN SubjectMaster ON Attendance.Subject_ID = SubjectMaster.Subject_ID WHERE ([Month] = @month)AND ([Year] = @year) AND (BatchNo = @Batch) AND ((Attendance.Semster_Id)=@Semster_Id) AND (Attendance.Del_Flag = 0) "
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(3) {}

                arParms(0) = New SqlParameter("@monthid", SqlDbType.Int)
                arParms(0).Value = monthid

                arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
                arParms(1).Value = yearid

                arParms(2) = New SqlParameter("@batchno", SqlDbType.Int)
                arParms(2).Value = batchno

                arParms(3) = New SqlParameter("@Semster_Id", SqlDbType.Int)
                arParms(3).Value = SemsterId

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_GetDataByCourseDate", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            dt2 = New Data.DataTable
            dt2 = ds.Tables(0)

            'proc_EmpAtte_GetDataByCourseDate1()
            'str = "SELECT DISTINCT StudentMaster.StdId, StudentMaster.StdName, StudentMaster.StdCode, CourseMaster.Course_ID, InstituteMaster.InstituteName,BranchMaster.BranchName, CourseMaster.CourseName, InstituteMaster.Institute_ID, BranchMaster.Branch_ID, CoursePlanner.Batch_No, " & _
            '"CoursePlanner.ID FROM ((((StudentMaster LEFT OUTER JOIN InstituteMaster ON StudentMaster.Institute_ID = InstituteMaster.Institute_ID) LEFT OUTER JOIN BranchMaster ON StudentMaster.Branch_ID = BranchMaster.Branch_ID) LEFT OUTER JOIN " & _
            '"CoursePlanner ON StudentMaster.Batch_No = CoursePlanner.ID) LEFT OUTER JOIN CourseMaster ON StudentMaster.Course_ID = CourseMaster.Course_ID) WHERE (StudentMaster.Batch_No = @batchno) and (StudentMaster.Del_Flag = 0) ORDER BY StudentMaster.StdId"
            Dim dss As New DataSet
            Try
                Dim arParms As SqlParameter = New SqlParameter

                arParms = New SqlParameter("@batchno", SqlDbType.Int)
                arParms.Value = batchno

                dss = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_GetDataByCourseDate1", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            dt1 = New Data.DataTable
            dt1 = dss.Tables(0)

            ds.Tables.Add(dt1)
            ds.Tables.Add(dt2)
            If dt2.Rows.Count > 0 Then
                ds.Relations.Add("dr", dt1.Columns("StdId"), dt2.Columns("StdId"))
                For Each dt1Rows As Data.DataRow In dt1.Rows
                    Dim p As Data.DataRow = dt.NewRow
                    p("StdId") = dt1Rows("StdId")
                    p("StdName") = dt1Rows("StdName")
                    p("StdCode") = dt1Rows("StdCode")
                    p("Course_ID") = dt1Rows("Course_ID")
                    p("InstituteName") = dt1Rows("InstituteName")
                    p("CourseName") = dt1Rows("CourseName")
                    p("BranchName") = dt1Rows("BranchName")
                    p("Institute_ID") = dt1Rows("Institute_ID")

                    p("Branch_ID") = dt1Rows("Branch_ID")
                    p("ID") = dt1Rows("ID")
                    p("Batch_No") = dt1Rows("Batch_No")
                    p("Month") = "13"
                    p("AttendanceID") = 0

                    For Each dt2Rows As Data.DataRow In dt1Rows.GetChildRows("dr")
                        p("TotalAttendance") = dt2Rows("TotalAttendance")
                        p("TotalClass") = dt2Rows("TotalClass")
                        p("AttendanceID") = dt2Rows("AttendanceID")
                        p("Subject_ID") = dt2Rows("Subject_ID")
                        p("Year") = dt2Rows("Year")
                        p("Month") = dt2Rows("Month")
                        p("Subject_Name") = dt2Rows("Subject_Name")
                        Select Case dt2Rows("Month")
                            Case 1
                                p("Month1") = "Jan"
                            Case 2
                                p("Month1") = "Feb"
                            Case 3
                                p("Month1") = "Mar"
                            Case 4
                                p("Month1") = "Apr"
                            Case 5
                                p("Month1") = "May"
                            Case 6
                                p("Month1") = "Jun"
                            Case 7
                                p("Month1") = "Jul"
                            Case 8
                                p("Month1") = "Aug"
                            Case 9
                                p("Month1") = "Sep"
                            Case 10
                                p("Month1") = "Oct"
                            Case 11
                                p("Month1") = "Nov"
                            Case 12
                                p("Month1") = "Dec"
                            Case 13
                                p("Month1") = " "
                            Case Else
                                p("Month1") = dt2Rows("Month")
                        End Select
                    Next
                    dt.Rows.Add(p)
                    dt.AcceptChanges()
                Next
            End If
            Return dt
        End Function

        Public Function GetDataByStdCode(ByVal insid As Int64, ByVal Brnid As Int64, ByVal CrsId As Int32, ByVal batchno As Int64, ByVal StdCode As String, ByVal SemsterId As Int64) As Data.DataTable
            'proc_EmpAtte_GetDataByStdCode()
            'str = "SELECT StudentMaster.StdId, StudentMaster.StdName, StudentMaster.StdCode, CourseMaster.Course_ID, SubjectMaster.Subject_ID, SubjectMaster.Subject_Code, SubjectMaster.Subject_Name, Switch([month]=1,'Jan',[month]=2,'Feb',[month]=3,'Mar',[month]=4,'Apr',[month]=5,'May',[month]=6,'Jun',[month]=7,'Jul',[month]=8,'Aug',[month]=9,'Sep',[month]=10,'Oct',[month]=11,'Nov',[month]=12,'Dec') AS [Month1], InstituteMaster.InstituteName, BranchMaster.BranchName, SubjectMaster.Subject_Name, CourseMaster.CourseName, Attendance.AttendanceID, InstituteMaster.Institute_ID, BranchMaster.Branch_ID, Attendance.TotalClass,Attendance.[Year], Attendance.TotalAttendance,CoursePlanner.ID " & _
            '      "FROM ((SubjectMaster RIGHT JOIN (StudentMaster RIGHT JOIN (CourseMaster RIGHT JOIN (InstituteMaster RIGHT JOIN Attendance ON InstituteMaster.Institute_ID=Attendance.Institute_ID) ON CourseMaster.Course_ID=Attendance.Course_ID) ON StudentMaster.StdId=Attendance.StdId) ON SubjectMaster.Subject_ID=Attendance.Subject_ID) LEFT JOIN CoursePlanner ON Attendance.BatchNo=CoursePlanner.ID) LEFT JOIN BranchMaster ON Attendance.Branch_ID=BranchMaster.Branch_ID " & _
            '      "WHERE (((CourseMaster.Course_ID)=@CrsId) AND ((StudentMaster.StdCode)=@stdCode) AND ((InstituteMaster.Institute_ID)=@insid) AND ((BranchMaster.Branch_ID)=@Brnid ) AND ((Attendance.BatchNo)=@batchno)) AND ((Attendance.Semster_Id)=@Semster_Id) and ((Attendance.Del_Flag)=0)"
            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(5) {}

                arParms(0) = New SqlParameter("@CrsId", SqlDbType.Int)
                arParms(0).Value = CrsId

                arParms(1) = New SqlParameter("@stdCode", SqlDbType.Int)
                arParms(1).Value = StdCode

                arParms(2) = New SqlParameter("@insid", SqlDbType.Int)
                arParms(2).Value = insid

                arParms(3) = New SqlParameter("@Brnid", SqlDbType.Int)
                arParms(3).Value = Brnid

                arParms(4) = New SqlParameter("@batchno", SqlDbType.Int)
                arParms(4).Value = batchno

                arParms(5) = New SqlParameter("@Semster_Id", SqlDbType.Int)
                arParms(5).Value = SemsterId

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_GetDataByStdCode", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)

        End Function
        Public Function GetDataByStdCodeDate(ByVal insid As Int64, ByVal Brnid As Int64, ByVal CrsId As Int32, ByVal batchno As Int64, ByVal StdCode As String, ByVal monthid As String, ByVal yearid As Int32, ByVal SemsterId As Int64) As Data.DataTable
            'proc_GetDataByStdCodeDate()
            'str = "SELECT StudentMaster.StdId, StudentMaster.StdName, StudentMaster.StdCode, CourseMaster.Course_ID, SubjectMaster.Subject_ID, SubjectMaster.Subject_Code, SubjectMaster.Subject_Name, Switch([month]=1,'Jan',[month]=2,'Feb',[month]=3,'Mar',[month]=4,'Apr',[month]=5,'May',[month]=6,'Jun',[month]=7,'Jul',[month]=8,'Aug',[month]=9,'Sep',[month]=10,'Oct',[month]=11,'Nov',[month]=12,'Dec') AS [Month1], InstituteMaster.InstituteName, BranchMaster.BranchName, SubjectMaster.Subject_Name, CourseMaster.CourseName, Attendance.AttendanceID, InstituteMaster.Institute_ID, BranchMaster.Branch_ID, Attendance.TotalClass,Attendance.[Year], Attendance.TotalAttendance,CoursePlanner.ID " & _
            '      "FROM ((SubjectMaster RIGHT JOIN (StudentMaster RIGHT JOIN (CourseMaster RIGHT JOIN (InstituteMaster RIGHT JOIN Attendance ON InstituteMaster.Institute_ID=Attendance.Institute_ID) ON CourseMaster.Course_ID=Attendance.Course_ID) ON StudentMaster.StdId=Attendance.StdId) ON SubjectMaster.Subject_ID=Attendance.Subject_ID) LEFT JOIN CoursePlanner ON Attendance.BatchNo=CoursePlanner.ID) LEFT JOIN BranchMaster ON Attendance.Branch_ID=BranchMaster.Branch_ID " & _
            '      "WHERE (((CourseMaster.Course_ID)=@CrsId) AND ((StudentMaster.StdCode)=@stdCode) AND ((Attendance.Month)=@monthid) AND ((InstituteMaster.Institute_ID)=@insid) AND ((BranchMaster.Branch_ID)=@Brnid )AND ((Attendance.Year)=@Year) AND ((Attendance.BatchNo)=@batchno)) AND ((Attendance.Semster_Id)=@Semster_Id) and ((Attendance.Del_Flag)=0)"
            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(7) {}

                arParms(0) = New SqlParameter("@CrsId", SqlDbType.Int)
                arParms(0).Value = CrsId

                arParms(1) = New SqlParameter("@stdCode", SqlDbType.Int)
                arParms(1).Value = StdCode

                arParms(2) = New SqlParameter("@monthid", SqlDbType.VarChar, 50)
                arParms(2).Value = monthid

                arParms(3) = New SqlParameter("@insid", SqlDbType.Int)
                arParms(3).Value = insid

                arParms(4) = New SqlParameter("@Brnid", SqlDbType.Int)
                arParms(4).Value = Brnid

                arParms(5) = New SqlParameter("@Year", SqlDbType.Int)
                arParms(5).Value = yearid

                arParms(6) = New SqlParameter("@batchno", SqlDbType.Int)
                arParms(6).Value = batchno

                arParms(7) = New SqlParameter("@Semster_Id", SqlDbType.Int)
                arParms(7).Value = SemsterId

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetDataByStdCodeDate", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function GvStdAttendance(ByVal prop As AttendanceP) As Data.DataTable
            'proc_EmpAtte_GvStdAttendance()
            'str = "SELECT StudentMaster.Branch_ID, StudentMaster.Institute_ID, StudentMaster.Course_ID, StudentMaster.Batch_No, StudentMaster.StdId, StudentMaster.StdName, StudentMaster.StdCode FROM(StudentMaster) " & _
            '      "WHERE (((StudentMaster.Branch_ID)=@Brnid) AND ((StudentMaster.Institute_ID)=@insid) AND ((StudentMaster.Course_ID)=@CrsId) AND ((StudentMaster.Batch_No)=@batchno) AND ((StudentMaster.Del_Flag)=0))"
            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(3) {}

                arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(0).Value = prop.BrnId

                arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(1).Value = prop.InsId

                arParms(2) = New SqlParameter("@CrsId", SqlDbType.Int)
                arParms(2).Value = prop.Course_ID

                arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
                arParms(3).Value = prop.Batch

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_GvStdAttendance", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        Public Function UpdateEmpAttd(ByVal StdId As Int64, ByVal TotalClass As Int32, ByVal TotalAttendance As Int32, ByVal InsId As Int64, ByVal BrnId As Int64, ByVal Courseid As Int64, ByVal SubjectId As Int64, ByVal Month1 As Int64, ByVal Year1 As Int64, ByVal Batch As Int64, ByVal id As Int64) As Int16
            Dim rowsAffected As Int16 = 0
            If id <> 0 Then
                'proc_EmpAtte_UpdateEmpAttdifid0()
                'str = "Update Attendance SET TotalClass =@totalClass,TotalAttendance=@Present  where AttendanceID=@ID"

                Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
                Try
                    Dim arParms() As SqlParameter = New SqlParameter(2) {}

                    arParms(0) = New SqlParameter("@totalClass", SqlDbType.Int)
                    arParms(0).Value = TotalClass

                    arParms(1) = New SqlParameter("@Present", SqlDbType.Int)
                    arParms(1).Value = TotalAttendance

                    arParms(2) = New SqlParameter("@ID", SqlDbType.Int)
                    arParms(2).Value = id

                    rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_UpdateEmpAttdifid0", arParms)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Else
                'proc_EmpAtte_UpdateEmpAttdifidnot0()
                'str = "Insert Into Attendance(Institute_ID,Branch_ID,Course_ID,BatchNo,StdId,Subject_ID,[Month],[Year],TotalClass,TotalAttendance) VALUES (@insid,@Brnid,@CrsId,@batchno,@stdCode,@SubjectId,@monthid,@Year,@totalClass,@Present)"

                Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
                Try
                    Dim arParms() As SqlParameter = New SqlParameter(9) {}

                    arParms(0) = New SqlParameter("@Brnid", SqlDbType.Int)
                    arParms(0).Value = BrnId

                    arParms(1) = New SqlParameter("@insid", SqlDbType.Int)
                    arParms(1).Value = InsId

                    arParms(2) = New SqlParameter("@CrsId", SqlDbType.Int)
                    arParms(2).Value = Courseid

                    arParms(3) = New SqlParameter("@batchno", SqlDbType.Int)
                    arParms(3).Value = Batch

                    arParms(4) = New SqlParameter("@stdCode", SqlDbType.Int)
                    arParms(4).Value = StdId

                    arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
                    arParms(5).Value = SubjectId

                    arParms(6) = New SqlParameter("@monthid", SqlDbType.Int)
                    arParms(6).Value = Month1

                    arParms(7) = New SqlParameter("@Year", SqlDbType.Int)
                    arParms(7).Value = Year1

                    arParms(8) = New SqlParameter("@totalClass", SqlDbType.Int)
                    arParms(8).Value = TotalClass

                    arParms(9) = New SqlParameter("@Present", SqlDbType.Int)
                    arParms(9).Value = TotalAttendance

                    rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_UpdateEmpAttdifidnot0", arParms)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If
            Return rowsAffected
        End Function

        Public Function DeletebyEmpAttd(ByVal id As Int64) As Int16
            'proc_EmpAtte_DeletebyEmpAttd()
            'str = "Update Attendance SET Del_Flag=-1 where AttendanceID=@ID"
            Dim rowsAffected As Int16 = 0
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim arParms As SqlParameter = New SqlParameter
            arParms = New SqlParameter("@ID", SqlDbType.Int)
            arParms.Value = id
            Try
                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_DeletebyEmpAttd", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        End Function
    End Class
    Public Class EmpAttendance
        Dim dt As Data.DataTable
        Dim str As String
        Public Function Empinsert(ByVal Prop As AttendanceP) As Int16
            'proc_EmpAtte_Empinsert()
            'str = "INSERT INTO EmployeeAttendance(Employee_Id, Dept_Id, Attendance_Date, LoginTime,Branch_Id,Insitute_Id,Remarks) VALUES (@empid,@deptid,@attdDate, @attdtime,@brnid,@insid,@remarks)"
            Dim rowsAffected As Int16 = 0
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(5) {}

                arParms(0) = New SqlParameter("@empid", SqlDbType.Int)
                arParms(0).Value = Prop.Id

                arParms(1) = New SqlParameter("@deptid", SqlDbType.Int)
                arParms(1).Value = Prop.DeptId

                arParms(2) = New SqlParameter("@attdDate", SqlDbType.DateTime)
                arParms(2).Value = Prop.StartDate

                arParms(3) = New SqlParameter("@attdtime", SqlDbType.DateTime)
                arParms(3).Value = Prop.time

                arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(4).Value = HttpContext.Current.Session("BranchCode")

                arParms(5) = New SqlParameter("@remarks", SqlDbType.VarChar, 50)
                arParms(5).Value = Prop.Remarks

                rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_Empinsert", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return rowsAffected
        End Function
        Public Function GetEmpDetails(ByVal Attendance_ID As Integer) As Data.DataTable
            'proc_EmpAtte_GetEmpDetails()
            'str = "SELECT EmployeeAttendance.Attendance_Id, EmployeeMaster.Emp_Id, EmployeeMaster.Emp_Name, EmployeeMaster.Emp_Code, DeptMaster.Dept_ID, DeptMaster.DeptName, EmployeeAttendance.Attendance_Date, EmployeeAttendance.LoginTime, EmployeeAttendance.LogoffTime, EmployeeAttendance.WorkingHours, BranchMaster.Branch_ID, BranchMaster.BranchName, InstituteMaster.Institute_ID, InstituteMaster.InstituteName" & _
            '      " FROM (((EmployeeAttendance LEFT JOIN BranchMaster ON EmployeeAttendance.Branch_Id = BranchMaster.Branch_ID) LEFT JOIN EmployeeMaster ON EmployeeAttendance.Employee_Id = EmployeeMaster.Emp_Id) LEFT JOIN DeptMaster ON EmployeeAttendance.Dept_Id = DeptMaster.Dept_ID) LEFT JOIN InstituteMaster ON EmployeeAttendance.Insitute_Id = InstituteMaster.Institute_ID WHERE (((DeptMaster.Dept_ID)=@deptid) AND ((BranchMaster.Branch_ID)=@brnid) AND ((InstituteMaster.Institute_ID)=@insid) AND ((EmployeeAttendance.Attendance_Date)=@attdDate) AND ((EmployeeMaster.Category)=@Category) AND ((EmployeeAttendance.Del_Flag)=0))"

            Dim ds As New DataSet
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Try
                Dim arParms() As SqlParameter = New SqlParameter(2) {}

                'arParms(0) = New SqlParameter("@deptid", SqlDbType.Int)
                'arParms(0).Value = Prop.DeptId

                arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
                arParms(0).Value = HttpContext.Current.Session("Office")

                arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
                arParms(1).Value = HttpContext.Current.Session("BranchCode")
                'arParms(2) = New SqlParameter("@Attendance_ID", SqlDbType.Int)
                'arParms(2).Value = Attendance_ID

                arParms(2) = New SqlParameter("@Attendance_ID", SqlDbType.Int)
                arParms(2).Value = Attendance_ID

                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_EmpAtte_GetEmpDetails", arParms)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        End Function
        'Public Function GetDataByRpt(ByVal id As Short, ByVal SDate As Date, ByVal Cate As Short) As DataTable
        '    'proc_EmpAtte_GetEmpDetails()
        '    'str = "SELECT EmployeeAttendance.Attendance_Id, EmployeeMaster.Emp_Id, EmployeeMaster.Emp_Name, EmployeeMaster.Emp_Code, DeptMaster.Dept_ID, DeptMaster.DeptName, EmployeeAttendance.Attendance_Date, EmployeeAttendance.LoginTime, EmployeeAttendance.LogoffTime, EmployeeAttendance.WorkingHours, BranchMaster.Branch_ID, BranchMaster.BranchName, InstituteMaster.Institute_ID, InstituteMaster.InstituteName" & _
        '    '      " FROM (((EmployeeAttendance LEFT JOIN BranchMaster ON EmployeeAttendance.Branch_Id = BranchMaster.Branch_ID) LEFT JOIN EmployeeMaster ON EmployeeAttendance.Employee_Id = EmployeeMaster.Emp_Id) LEFT JOIN DeptMaster ON EmployeeAttendance.Dept_Id = DeptMaster.Dept_ID) LEFT JOIN InstituteMaster ON EmployeeAttendance.Insitute_Id = InstituteMaster.Institute_ID WHERE (((DeptMaster.Dept_ID)=@deptid) AND ((BranchMaster.Branch_ID)=@brnid) AND ((InstituteMaster.Institute_ID)=@insid) AND ((EmployeeAttendance.Attendance_Date)=@attdDate) AND ((EmployeeMaster.Category)=@Category) AND ((EmployeeAttendance.Del_Flag)=0))"

        '    Dim ds As New DataSet
        '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        '    Try
        '        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        '        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        '        arParms(0).Value = id

        '        arParms(1) = New SqlParameter("@SDate", SqlDbType.DateTime)
        '        arParms(1).Value = SDate

        '        arParms(2) = New SqlParameter("@Cate", SqlDbType.Int)
        '        arParms(2).Value = Cate

        '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "", arParms)
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try
        '    Return ds.Tables(0)
        'End Function
    End Class
End Class

