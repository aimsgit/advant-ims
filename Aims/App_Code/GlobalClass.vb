Imports System.Data.SqlClient
Imports System.data

Public Class globalcnn
    Public Shared glbconnString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    Public Shared myConnection As New Data.SqlClient.SqlConnection(glbconnString)
    Public glbStartDate As Date
    Public glbEndDate As Date
    Public glbDataSet As New DataSet
    Public strFieldValue1 As String
    Public strFieldValue2 As String

    Public Sub glbConfigData()
        Const sql As String = "SELECT * from Configuration"
        Dim myCommand As New SqlClient.SqlCommand(sql, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        myAdapter.Fill(glbDataSet)
        strFieldValue1 = glbDataSet.Tables(0).Rows(27)(3).ToString
        strFieldValue2 = glbDataSet.Tables(0).Rows(28)(3).ToString
    End Sub

    Public Shared Function Del_Validation(ByVal FldValue As Long, ByVal TabName As String) As Boolean
        Dim sda As SqlDataAdapter
        Dim sdt As New DataTable()
        Dim sql As String
        Select Case TabName
            Case "Dept"
                sql = "SELECT DISTINCT EmployeeMaster.Dept_ID,CourseMaster.Dept_ID,StudentMaster.Dept_ID FROM ((DeptMaster LEFT JOIN EmployeeMaster ON DeptMaster.Dept_ID = EmployeeMaster.Dept_ID) LEFT JOIN CourseMaster ON DeptMaster.Dept_ID = CourseMaster.Dept_ID) LEFT JOIN StudentMaster ON DeptMaster.Dept_ID = StudentMaster.Dept_ID WHERE(((DeptMaster.Dept_ID) = " & FldValue & ")) GROUP BY EmployeeMaster.Dept_ID, CourseMaster.Dept_ID, StudentMaster.Dept_ID"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) And IsDBNull(sdt.Rows(0)(2)) Then
                    Return False
                Else
                    Return True
                End If

            Case "Institute"
                sql = "SELECT DISTINCT EmployeeMaster.Institute_ID, CoursePlanner.Institute_ID, StudentMaster.Institute_ID FROM ((CoursePlanner LEFT JOIN InstituteMaster ON CoursePlanner.Institute_ID = InstituteMaster.Institute_ID) LEFT JOIN EmployeeMaster ON InstituteMaster.Institute_ID = EmployeeMaster.Institute_ID) LEFT JOIN StudentMaster ON InstituteMaster.Institute_ID = StudentMaster.Institute_ID WHERE(((InstituteMaster.Institute_ID) = " & FldValue & "))GROUP BY EmployeeMaster.Institute_ID, CoursePlanner.Institute_ID, StudentMaster.Institute_ID "
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Branch"
                sql = "SELECT DISTINCT EmployeeMaster.Branch_ID, InstituteMaster.Branch_ID, StudentMaster.Branch_ID FROM ((BranchMaster LEFT JOIN EmployeeMaster ON BranchMaster.Branch_ID = EmployeeMaster.Branch_ID) LEFT JOIN InstituteMaster ON BranchMaster.Branch_ID = InstituteMaster.Branch_ID) LEFT JOIN StudentMaster ON BranchMaster.Branch_ID = StudentMaster.Branch_ID WHERE (((BranchMaster.Branch_ID)=" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) And IsDBNull(sdt.Rows(0)(2)) Then
                    Return False
                Else
                    Return True
                End If

            Case "MediumMaster"
                sql = "SELECT DISTINCT CourseMaster.Course_ID, StudentMaster.Medium_ID, MediumMaster.Medium_ID FROM (StudentMaster RIGHT JOIN MediumMaster ON StudentMaster.Medium_ID = MediumMaster.Medium_ID) LEFT JOIN CourseMaster ON MediumMaster.Medium_ID = CourseMaster.Medium_ID WHERE (((MediumMaster.Medium_ID)=" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) Then
                    Return False
                Else
                    Return True
                End If

            Case "BankMaster"
                sql = "SELECT DISTINCT Expenses.Bank_ID, Day_Book.Bank_ID, BankMaster.Bank_ID FROM (Day_Book RIGHT JOIN BankMaster ON Day_Book.Bank_ID = BankMaster.Bank_ID) LEFT JOIN Expenses ON BankMaster.Bank_ID = Expenses.Bank_ID WHERE (((BankMaster.Bank_ID)=" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) Then
                    Return False
                Else
                    Return True
                End If

            Case "EmployeeMaster"
                sql = "SELECT DISTINCT BookIssued.Emp_Id, TimeTable.Emp_Id, EmployeeAttendance.Employee_Id FROM ((EmployeeMaster LEFT JOIN BookIssued ON EmployeeMaster.Emp_Id = BookIssued.Emp_Id) LEFT JOIN TimeTable ON EmployeeMaster.Emp_Id = TimeTable.Emp_Id) LEFT JOIN EmployeeAttendance ON EmployeeMaster.Emp_Id = EmployeeAttendance.Employee_Id WHERE(((EmployeeMaster.Emp_Id) =" & FldValue & "))GROUP BY BookIssued.Emp_Id, TimeTable.Emp_Id, EmployeeAttendance.Employee_Id"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) And IsDBNull(sdt.Rows(0)(2)) Then
                    Return False
                Else
                    Return True
                End If

            Case "CourseMaster"
                sql = "SELECT CoursePlanner.Course_ID, StudentResult.Course_ID, EntranceExam.Course_ID FROM ((CourseMaster LEFT JOIN StudentResult ON CourseMaster.Course_ID = StudentResult.Course_ID) LEFT JOIN EntranceExam ON CourseMaster.Course_ID = EntranceExam.Course_ID) LEFT JOIN CoursePlanner ON CourseMaster.Course_ID = CoursePlanner.Course_ID WHERE (((CoursePlanner.Course_ID)=" & FldValue & ")) OR (((StudentResult.Course_ID)=" & FldValue & ")) OR (((EntranceExam.Course_ID)=" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "SupplierMaster"
                sql = "SELECT DISTINCT AssetDetails.Supp_Id FROM SupplierMaster LEFT JOIN AssetDetails ON SupplierMaster.Supp_Id = AssetDetails.Supp_Id WHERE (((AssetDetails.Supp_Id)=" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Assesement"
                sql = "SELECT  DISTINCTROW StudentResult.ResultID FROM StudentResult INNER JOIN AssessmentMaster ON StudentResult.AssessmentType = AssessmentMaster.ID WHERE (((AssessmentMaster.ID)=" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Sponsor"
                sql = "Select DISTINCTROW Sponsor_ID FROM StudentMaster WHERE(((Sponsor_ID) = " & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Certificate"
                sql = "Select Certificate_Id FROM CertificateIssued  WHERE(((Certificate_Id) = " & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Payment"
                sql = "Select DISTINCTROW PaymentMethod_Id FROM AssetDetails  WHERE(((PaymentMethod_Id) = " & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If
            Case "MaintenanceType"
                sql = "Select DISTINCTROW MaintenanceType FROM Machine_Maintenance  WHERE(((MaintenanceType) = " & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "FeeHeads"
                sql = "Select FeeHead_ID FROM FeeStructure  WHERE(((FeeHead_ID) = " & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Asset"
                sql = "Select Asset_Id FROM AssetDetails where Asset_Id = " & FldValue & ""
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "ManuFacturerMaster"
                sql = "SELECT ManuFacturer_Id FROM AssetDetails WHERE ManuFacturer_Id=" & FldValue
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Subject"
                sql = "SELECT DISTINCT BookMaster.Subject_ID,CoursePlannerSubject.Subject_ID,Attendance.Subject_ID FROM ((SubjectMaster LEFT JOIN BookMaster ON SubjectMaster.Subject_ID = BookMaster.Subject_ID) LEFT JOIN CoursePlannerSubject ON SubjectMaster.Subject_ID = CoursePlannerSubject.Subject_ID) LEFT JOIN Attendance ON SubjectMaster.Subject_ID = Attendance.Subject_ID WHERE(((SubjectMaster.Subject_ID) =" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) And IsDBNull(sdt.Rows(0)(2)) Then
                    Return False
                Else
                    Return True
                End If

            Case "Company"
                sql = "Select DISTINCT Company_Name FROM PlacementDetails  WHERE(((Company_Name) = " & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "CourseType"
                sql = "Select CourseType_ID FROM CourseMaster  WHERE(((CourseType_ID) = " & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "Semester"
                sql = "SELECT FeeStructure.Fee_Structure_ID, StudentResult.ResultID FROM (AssessmentMaster INNER JOIN FeeStructure ON AssessmentMaster.ID = FeeStructure.Semester_ID) INNER JOIN StudentResult ON AssessmentMaster.ID = StudentResult.SemesterType " & _
                    "GROUP BY FeeStructure.Fee_Structure_ID, StudentResult.ResultID, AssessmentMaster.ID having ((AssessmentMaster.ID) = " & FldValue & ")"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "CoursePlanner"
                sql = "SELECT StudentMaster.StdId, FeeStructure.Fee_Structure_ID, TimeTable.ID AS TimeTableId FROM ((CoursePlanner INNER JOIN FeeStructure ON CoursePlanner.ID = FeeStructure.Course_Planner_ID) INNER JOIN TimeTable ON CoursePlanner.ID = TimeTable.Cource_Planer_Id) INNER JOIN StudentMaster ON CoursePlanner.ID = StudentMaster.Batch_No " & _
                    "GROUP BY CoursePlanner.ID, StudentMaster.StdId, FeeStructure.Fee_Structure_ID, TimeTable.ID HAVING (((CoursePlanner.ID)=" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "FeeStructure"
                sql = "SELECT Fee_Details.Fee_Structure_ID FROM Fee_Details INNER JOIN FeeStructure ON Fee_Details.Fee_Structure_ID = FeeStructure.Fee_Structure_ID " & _
                   "GROUP BY Fee_Details.Fee_Structure_ID, FeeStructure.Fee_Structure_ID HAVING(((FeeStructure.Fee_Structure_ID) =" & FldValue & "))"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If sdt.Rows.Count = 0 Then
                    Return False
                Else
                    Return True
                End If

            Case "StudentMaster"
                sql = "SELECT DISTINCT BookIssued.StdId, StudentResult.StdCode, Attendance.StdId FROM ((StudentMaster LEFT JOIN BookIssued ON StudentMaster.StdId = BookIssued.StdId) LEFT JOIN StudentResult ON StudentMaster.StdId = StudentResult.StdCode) LEFT JOIN Attendance ON StudentMaster.StdId = Attendance.StdId WHERE(((StudentMaster.StdId) =" & FldValue & "))GROUP BY BookIssued.StdId, StudentResult.StdCode, Attendance.StdId"
                sda = New SqlDataAdapter(sql, myConnection)
                sdt.Clear()
                sda.Fill(sdt)
                If IsDBNull(sdt.Rows(0)(0)) And IsDBNull(sdt.Rows(0)(1)) And IsDBNull(sdt.Rows(0)(2)) Then
                    Return False
                Else
                    Return True
                End If
        End Select
    End Function
End Class
