Imports System.Web
Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Partial Class Recover
    Inherits BasePage
    Dim da, Recoverda As New OleDbDataAdapter
    Dim dt, Recoverdt As New Data.DataTable
    Public row_position As Integer
    Private conn As New OleDbConnection
    Dim sql, sql1 As String

    Dim Rec As New BLRecover
    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    Dim cn As New SqlConnection(ConnectionString)
    Protected Sub DatagridBind()
        If Session("RecoverForm") = "TimeTable" Then
            Rec.TimeTableGridFill()
        End If
        '        If Session("RecoverForm") = "CertificateMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Certificate_Id as ID, Certificate_Name FROM [CertificateMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "FeeStructure" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT FeeStructure.Fee_Structure_ID AS ID, InstituteMaster.InstituteName, BranchMaster.BranchName, CourseMaster.CourseName, CoursePlanner.Batch_No AS Batch, AssessmentMaster.AssessmentType AS Semster, FeeHeads.Fee_HeadType AS FeeHead, FeeStructure.Amount, FeeStructure.Due_Date AS DueDate, FeeStructure.Remarks " & _
        '                        "FROM ((CourseMaster RIGHT JOIN (((FeeStructure LEFT JOIN CoursePlanner ON FeeStructure.Course_Planner_ID = CoursePlanner.ID) LEFT JOIN AssessmentMaster ON FeeStructure.Semester_ID = AssessmentMaster.ID) LEFT JOIN FeeHeads ON FeeStructure.FeeHead_ID = FeeHeads.Fee_Head_ID) ON CourseMaster.Course_ID = CoursePlanner.Course_ID) LEFT JOIN BranchMaster ON FeeStructure.Branch_ID = BranchMaster.Branch_ID) LEFT JOIN InstituteMaster ON FeeStructure.Institute_ID = InstituteMaster.Institute_ID WHERE (FeeStructure.Del_Flag)=-1", conn)
        '        ElseIf Session("RecoverForm") = "TimeTable" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT TimeTable.ID as ID, BranchMaster.BranchName, CourseMaster.CourseName, InstituteMaster.InstituteName, EmployeeMaster.Emp_Name as EmpName, SubjectMaster.Subject_Name as SubjectName, Day.[Day], TimeTable.[Session] FROM ((((((TimeTable LEFT JOIN CoursePlanner ON TimeTable.Cource_Planer_Id = CoursePlanner.ID) LEFT JOIN BranchMaster ON CoursePlanner.Branch_ID = BranchMaster.Branch_ID) LEFT JOIN CourseMaster ON CoursePlanner.Course_ID = CourseMaster.Course_ID) LEFT JOIN InstituteMaster ON CoursePlanner.Institute_ID = InstituteMaster.Institute_ID) LEFT JOIN SubjectMaster ON TimeTable.Subject_Id = SubjectMaster.Subject_ID) LEFT JOIN EmployeeMaster ON TimeTable.Emp_Id = EmployeeMaster.Emp_Id) LEFT JOIN [Day] ON TimeTable.Day_Id = Day.ID " & _
        '                      "WHERE (((TimeTable.Del_flag)=-1))", conn)
        '        ElseIf Session("RecoverForm") = "MediumMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Medium_Id as ID, MediumName FROM [MediumMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "InstituteMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Institute_ID as ID, InstituteName,BranchName FROM [Institute] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "DeptMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Dept_ID as ID, DeptName FROM [DeptMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "SubjectMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Subject_ID as ID, Subject_Name FROM [SubjectMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "CoursePlanner" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT  CoursePlanner.ID as ID,BranchMaster.BranchName, InstituteMaster.InstituteName, CourseMaster.CourseName, CoursePlanner.Batch_No as BatchNo, CoursePlanner.Date_Commenecement as DateCommencement, CoursePlanner.Date_Completion as DateCompletion " & _
        '"FROM ((CoursePlanner LEFT JOIN CourseMaster ON CoursePlanner.Course_ID = CourseMaster.Course_ID) RIGHT JOIN InstituteMaster ON CoursePlanner.Institute_ID = InstituteMaster.Institute_ID) LEFT JOIN BranchMaster ON CoursePlanner.Branch_ID = BranchMaster.Branch_ID WHERE(((CoursePlanner.Del_flag) = -1))", conn)
        '        ElseIf Session("RecoverForm") = "StudentResult" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT ResultID as ID,Batch_No,AssessmentType,CourseName,StdCode,Subject_Name,SemesterType,BranchName,InstituteName FROM [Recover_StudentResultDetails] WHERE ([Del_Flag] = -1) ", conn)
        '        ElseIf Session("RecoverForm") = "SponsorMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Sponsor_ID as ID, SponsorName,SponsorAddress, ContactNumber, Email, Remarks FROM [SponsorMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "SectionMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Section_ID as ID, SectionName,Del_Flag FROM [SectionMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "AssetMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Asset_ID as ID, AssetName,AssetCode,Remarks FROM [AssetMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "AssetDetails" Then
        '            'Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT AssetDet_Id as ID, AssetName,Branch,Institute,Supplier,ManuFacturer,Quantity,Price FROM [GrdAssetDetails] WHERE ([Del_Flag] = -1)", conn)
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT GrdAssetDetails.AssetDet_Id AS ID, GrdAssetDetails.AssetName, GrdAssetDetails.Branch, GrdAssetDetails.Institute, GrdAssetDetails.Supplier, GrdAssetDetails.ManuFacturer, GrdAssetDetails.Quantity, GrdAssetDetails.Price, AssetType.AssetType_ID FROM (GrdAssetDetails LEFT JOIN AssetDetails ON GrdAssetDetails.AssetDet_Id = AssetDetails.AssetDet_Id) LEFT JOIN AssetType ON AssetDetails.AssetType = AssetType.AssetType_ID WHERE (((GrdAssetDetails.Del_Flag)=-1) AND ((AssetType.AssetType_ID)<>4))", conn)
        '        ElseIf Session("RecoverForm") = "BookIssue" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT ID as ID,Book_ID,Emp_Id, StdId, IssueDate,ReturnDate FROM [BookIssued] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "Assessment" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT ID as ID,AssessmentType FROM [AssessmentMaster] WHERE [Del_Flag] = -1 and Type1=-1", conn)
        '        ElseIf Session("RecoverForm") = "Semester" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT ID as ID,AssessmentType FROM [AssessmentMaster] WHERE [Del_Flag] = -1 and Type2=-1", conn)
        '        ElseIf Session("RecoverForm") = "Institute" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Institute_ID as ID,InstituteName,Branch_ID,InstituteAdress  FROM [InstituteMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "EmpDetails" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Emp_Id as ID,Emp_Name as Name ,Designation, Del_Flag FROM [EmployeeMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "Registration" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT StdId as ID,StdName,StdCode,DOB,FatherName, Batch_No, CourseName,BranchName,InstituteName FROM [DispStudentMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "frmBranch" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Branch_Id as ID,BranchName,BranchCode FROM [BranchMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "frmInstitute" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Institute_ID as ID,InstituteName,Branch_ID FROM [InstituteMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "frmCourse" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Course_ID as ID,CourseName,CourseCode, Del_Flag FROM [CourseMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "EmpAttd" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Attendance_Id as ID, Emp_Name as Name, Emp_Code as Code,DeptName as Department, Attendance_Date as AttdDate, LoginTime as LogIn, LogoffTime as LogOff, WorkingHours FROM Qry_EmpAttd WHERE Del_Flag=-1 ", conn)
        '        ElseIf Session("RecoverForm") = "StdAttd" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT AttendanceID as ID,CourseName as Course,Subject_Name as Subject,StdName as Name, StdCode as Code,TotalClass,TotalAttendance as Present, Month1 as Attendance_Month ,Year FROM Qry_StdAttdDetails where ([Del_Flag] = -1) ", conn)
        '        ElseIf Session("RecoverForm") = "Enquiry" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT EId as ID,Title,FName,Address,Country,Email,ERelates FROM EnquiryMaster where ([Del_Flag] = -1) ", conn)
        '        ElseIf Session("RecoverForm") = "EntranceExam" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT EntResultId as id,CourseName, StudentMaster.StdName, EntranceExam.ExamDate FROM (EntranceExam LEFT JOIN CourseMaster ON EntranceExam.Course_ID = CourseMaster.Course_ID) LEFT JOIN StudentMaster ON EntranceExam.StdId = StudentMaster.StdId WHERE EntranceExam.Del_Flag=-1", conn)
        '        ElseIf Session("RecoverForm") = "DayBook" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Expenses.Expense_ID AS ID, Account_heads.Head_type AS AccountHead, Switch([Expenses]![Party_Type]=4,[Emp_Name],[Expenses]![Party_Type]=2,[Supp_Name],[Expenses]![Party_Type]=3,[Bank_Name],[Expenses]![Party_Type]=5,[OP_Name],[Expenses]![Party_Type]=1,[StdName]) AS Name,  PartyType.PartyName, Expenses.Bill_No AS BillNo, Expenses.Bill_Date AS Bill_Date, Expenses.Amount, Expenses.Item, Expenses.Remarks " & _
        '                        "FROM ((((((Expenses LEFT JOIN Account_heads ON Expenses.Account_Head = Account_heads.Account_Code) LEFT JOIN EmployeeMaster ON Expenses.Party_Id_Name = EmployeeMaster.Emp_Id) LEFT JOIN SupplierMaster ON Expenses.Party_Id_Name = SupplierMaster.Supp_Id) LEFT JOIN StudentMaster ON Expenses.Party_Id_Name = StudentMaster.StdId) LEFT JOIN OtherParty ON Expenses.Party_Id_Name = OtherParty.OP_Id) LEFT JOIN BankMaster ON (Expenses.Party_Id_Name = BankMaster.Bank_ID) AND (Expenses.Bank_ID = BankMaster.Bank_ID)) LEFT JOIN PartyType ON Expenses.Party_Type = PartyType.PartyId " & _
        '                        "WHERE (((Expenses.Del_Flag)=-1)) ", conn)
        '        ElseIf Session("RecoverForm") = "Bank" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Bank_ID as ID,Bank_Name,Bank_Address,Remarks FROM BankMaster where ([Del_Flag] = -1) ", conn)
        '        ElseIf Session("RecoverForm") = "BookMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Book_ID as ID,BookCode,BookName FROM BookMaster where ([Del_Flag] = -1) ", conn)
        '        ElseIf Session("RecoverForm") = "AccountHead" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Account_Head_Id as ID,Head_Type,Acct_Group_ID,Acct_One FROM Account_Heads where ([Del_Flag] = -1) ", conn)
        '        ElseIf Session("RecoverForm") = "CertificateIssued" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT ID as ID,Certificate_Name,StdCode,IssueDate FROM DispGV_CertificateIssued where ([Del_Flag] = -1) ", conn)
        '        ElseIf Session("RecoverForm") = "AssetTrBK" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT BookID as ID,OrignalBookID,Quantity,OriginalBookQty,BookName,Author,BranchName,InstituteName,BookPrice,AssetDetail_ID as AssetID ,OriginalAssetID,AssetQty,AssetPrice,OriginalAssetPrice from Qry_AssetRecover ", conn)
        '        ElseIf Session("RecoverForm") = "AssetTr" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT TargetID as ID, SourceID as AssetDetailID, AssetName, BranchName, InstituteName, Supp_Name as SupplierName, ManuFacturer, TransferDate, Model_Number as ModelNumber,AssetPrice, Price AS SourcePrice from Qry_AssetTransferRecover", conn)
        '            'ElseIf Session("RecoverForm") = "NormalAsset" Then
        '            Recoverdt.Clear()
        '            Me.GridView2.Visible = True
        '            label2.Visible = True
        '            Recoverda.Fill(Recoverdt)
        '            Me.GridView2.DataSource = Recoverdt
        '            Me.GridView2.DataBind()

        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT AssetDet_Id as ID, BranchName, InstituteName, AssetName, Quantity, TransferDate, ManuFacturer, Supp_Name as SupplierName, Price, Model_Number FROM Qry_NormalAssetRecover", conn)
        '        ElseIf Session("RecoverForm") = "frmManufacturer" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT ManuFacturer_ID AS ID, ManuFacturer AS ManufacturerName FROM ManuFacturerMaster WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "PaymentMethod" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT PaymentMethodID as ID, Payment_Method as PaymentMethod FROM PaymentMethods WHERE [Del_Flag] = -1", conn)
        '        ElseIf Session("RecoverForm") = "SupplierMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Supp_Id as ID,Supp_Name AS Name,Supp_Code as Code FROM [SupplierMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "OtherParty" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT OPAutoNo as ID,OP_Id, OP_Name, OP_Address, City, State, Postal_Code, Country, Contact_Person, Contact_Number1, Email, Credit_Period, Credit_Limit, Opening_Balance_CR, Opening_Balance_DR, OpBalanceDate, Remarks FROM OtherParty WHERE [Del_Flag] = -1", conn)
        '        ElseIf Session("RecoverForm") = "Payroll" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT PayrollMaster.PM_ID AS ID, EmployeeMaster.Emp_Name, Format([SalaryRevDate],'dd/mmm/yyyy') AS SalRevDate FROM PayrollMaster LEFT JOIN EmployeeMaster ON PayrollMaster.EMP_ID = EmployeeMaster.Emp_Id WHERE (((PayrollMaster.Del_Flag)=-1));", conn)
        '        ElseIf Session("RecoverForm") = "MSPayroll" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT MS_ID as ID, Emp_Name, PaymentDate FROM MonthlySalary LEFT JOIN EmployeeMaster ON MonthlySalary.EMP_ID = EmployeeMaster.Emp_Id WHERE (((MonthlySalary.Del_flag)=-1));", conn)
        '        ElseIf Session("RecoverForm") = "LeaveMaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT LM_ID as ID, E_ID,BalanceLeave, Emp_Name FROM LeaveMaster LEFT JOIN EmployeeMaster ON LeaveMaster.E_ID = EmployeeMaster.Emp_Id WHERE (((LeaveMaster.Del_flag)=-1));", conn)
        '        ElseIf Session("RecoverForm") = "leavereg" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT LR_ID AS ID, Emp_Name, LeaveFrom, LeaveTo,LeaveTypes FROM LeaveRegister LEFT JOIN EmployeeMaster ON LeaveRegister.E_ID = EmployeeMaster.Emp_Id WHERE (((LeaveRegister.Del_Flag)=-1));", conn)
        '        ElseIf Session("RecoverForm") = "frmLetterPad" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Ref_ID as ID, Ref_No,Ref_Person,Ref_Date,Subject,Content FROM [LetterPad] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "frmBatch" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Batch_ID as ID, Batch_Name FROM [BatchMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "CourseType" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT CourseType_ID as ID,CourseType FROM [CourseType] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "placementdetails" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Placement_ID as ID,Institute,Branch,Course,Batch_No,StdId,Company_Name,Date_Of_Placement,Remarks FROM [GV_PlacementDetails] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "Company" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT PCId as ID,PCName,PCCntPerson,PCCntNo,PCAdd FROM [PlacementCompany] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "Prospectus" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Prospectus_Details.Prosp_ID AS ID, Prospectus_Details.Name, BranchMaster.BranchName, InstituteMaster.InstituteName, Prospectus_Details.Entry_Date as EntryDate, IIf([Prosp_Quantity]>0,[Prosp_Quantity],0) AS QtyIn, IIf([Prosp_Quantity]<0,[Prosp_Quantity]*(-1),0) AS QtyOut, Prospectus_Details.Prosp_Price as Price, Prospectus_Details.Remarks FROM (Prospectus_Details LEFT JOIN InstituteMaster ON Prospectus_Details.Institute_ID = InstituteMaster.Institute_ID) LEFT JOIN BranchMaster ON Prospectus_Details.Branch_ID = BranchMaster.Branch_ID WHERE (((Prospectus_Details.Del_Flag)=-1))", conn)
        '        ElseIf Session("RecoverForm") = "MaintenanceType" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT M_ID as ID, MaintenanceType,Remarks FROM [Maintenance_Type] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "Maintenance" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Maintain_ID as ID,Maintenance_Type, ManuFacturer,AssetName,InstituteName, BranchName,Machine_Model, Machine_No,Cleaned_Date, Due_Date,Time_Stopped,Part_Changed,Time_Run,Operation,Operator_Name,Needle,Parts,Batch_No FROM [DispGV_Maintenance] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "Visiting" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT VID as ID,Institute_ID,Branch_ID, Visiting_Date,Emp_ID,From_Time,To_Time,Contact_Details,Discussion,Remarks FROM [Visiting_Details] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "FeeHead" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Fee_Head_ID as ID, Fee_HeadType as FeeHeadType FROM FeeHeads WHERE [Del_Flag] = -1", conn)
        '        ElseIf Session("RecoverForm") = "feepaymentdetails" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT Fee_Details.ExpenseID AS ID, InstituteMaster.InstituteName, BranchMaster.BranchName, CourseMaster.CourseName, CoursePlanner.Batch_No AS Batch, StudentMaster.StdName AS Student, Fee_Details.Amount, Fee_Details.Entry_Date AS EntryDate, Fee_Details.Fee_Date AS FeeDate " & _
        '                        "FROM ((((Fee_Details LEFT JOIN InstituteMaster ON Fee_Details.Institute_ID = InstituteMaster.Institute_ID) LEFT JOIN BranchMaster ON Fee_Details.Branch_ID = BranchMaster.Branch_ID) LEFT JOIN CourseMaster ON Fee_Details.Course_ID = CourseMaster.Course_ID) LEFT JOIN CoursePlanner ON Fee_Details.Course_Planner_ID = CoursePlanner.ID) INNER JOIN StudentMaster ON Fee_Details.Std_ID = StudentMaster.StdId " & _
        '                        "WHERE (((Fee_Details.Del_Flag)=-1))", conn)
        '        ElseIf Session("RecoverForm") = "AssetDetails" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT AssetDetails.Asset_Id, AssetMaster.AssetName, AssetDetails.Branch_Id, BranchMaster.BranchName, AssetDetails.Institute_Id, InstituteMaster.InstituteName, AssetDetails.Supp_Id, SupplierMaster.Supp_Name, AssetDetails.ManuFacturer_Id, ManuFacturerMaster.ManuFacturer, AssetDetails.InvoiceNo, AssetDetails.PurchaseDate, AssetDetails.EntryDate, AssetDetails.TransferDate, AssetDetails.Quantity, AssetDetails.Price, AssetDetails.Transfer_Flag, AssetDetails.Total_Value, AssetDetails.Description, AssetDetails.Location, AssetDetails.AssetType, AssetDetails.AmtPaid, AssetDetails.BillType, AssetDetails.PaymentMethod_Id " & _
        '                       "FROM ((((AssetDetails INNER JOIN BranchMaster ON AssetDetails.Branch_Id = BranchMaster.Branch_ID) INNER JOIN AssetMaster ON AssetDetails.Asset_Id = AssetMaster.Asset_ID) INNER JOIN InstituteMaster ON AssetDetails.Institute_Id = InstituteMaster.Institute_ID) INNER JOIN ManuFacturerMaster ON AssetDetails.ManuFacturer_Id = ManuFacturerMaster.ManuFacturer_ID) INNER JOIN SupplierMaster ON AssetDetails.Supp_Id = SupplierMaster.Supp_Id;", conn)
        '        ElseIf Session("RecoverForm") = "loanmaster" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT LoanID as ID,EmpId,LoanType,LoanDate,LoanAmt,InterestRate,ChequeDate,MonthlyDed,BalanceLoan,StartDate,Hold FROM [LoanMaster] WHERE ([Del_Flag] = -1)", conn)
        '        ElseIf Session("RecoverForm") = "Incometax" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT IT_ID as ID,ITDescription,LowerLimit,UpperLimit,Category,StdDeduction,ITPercent,FinancialYear FROM [IncomeTax] WHERE ([Del_Flag]= -1)", conn)
        '        ElseIf Session("RecoverForm") = "LeaveType" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT TY_ID as ID, LeaveType,LeaveDescription FROM LeaveTypes WHERE [Del_Flag] = -1", conn)
        '        ElseIf Session("RecoverForm") = "AssetUsage" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT AssetUsage.Asset_Usage_Id AS ID, AssetMaster.AssetName, BranchMaster.BranchName, InstituteMaster.InstituteName, AssetUsage.UsedQuantity, AssetUsage.Remarks FROM ((AssetUsage LEFT JOIN AssetMaster ON AssetUsage.Asset_Id = AssetMaster.Asset_ID) LEFT JOIN BranchMaster ON AssetUsage.Branch_Id = BranchMaster.Branch_ID) LEFT JOIN InstituteMaster ON AssetUsage.Institute_Id = InstituteMaster.Institute_ID WHERE (((AssetUsage.Del_flag)=-1))", conn)
        '        ElseIf Session("RecoverForm") = "TrainingMaterial" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT GrdTrainingMaterial.AssetDet_Id AS ID, GrdTrainingMaterial.AssetName AS TrainingMaterialName, GrdTrainingMaterial.Branch, GrdTrainingMaterial.Institute, GrdTrainingMaterial.Supplier, GrdTrainingMaterial.ManuFacturer, GrdTrainingMaterial.Quantity, GrdTrainingMaterial.Price, AssetType.AssetType_ID as TypeID FROM (AssetDetails LEFT JOIN AssetType ON AssetDetails.AssetType = AssetType.AssetType_ID) LEFT JOIN GrdTrainingMaterial ON AssetDetails.AssetDet_Id = GrdTrainingMaterial.AssetDet_Id WHERE (((AssetType.AssetType_ID)=4) AND ((GrdTrainingMaterial.Del_Flag)=-1))", conn)
        '        ElseIf Session("RecoverForm") = "TrainingMaterialTr" Then
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT TargetID as ID, SourceID as AssetDetailID, AssetName as TrainingMaterialName, BranchName, InstituteName, Supp_Name as SupplierName, ManuFacturer, TransferDate, Model_Number as ModelNumber,AssetPrice, Price AS SourcePrice from Qry_TrainingMtrTrlRecover", conn)
        '            Recoverdt.Clear()
        '            Me.GridView2.Visible = True
        '            label2.Visible = False
        '            Recoverda.Fill(Recoverdt)
        '            Me.GridView2.DataSource = Recoverdt
        '            Me.GridView2.DataBind()
        '            Recoverda = New Data.OleDb.OleDbDataAdapter("SELECT AssetDet_Id as ID, BranchName, InstituteName, AssetName as TrainingMaterialName, Quantity, TransferDate, ManuFacturer, Supp_Name as SupplierName, Price, Model_Number FROM Qry_TraingMtrlTrRecover", conn)
        '            Recoverdt.Clear()
        '            Me.GridView1.Visible = False
        '            'label2.Visible = True
        '            Recoverda.Fill(Recoverdt)
        '            Me.GridView1.DataSource = Recoverdt
        '            Me.GridView1.DataBind()
        '        End If
        '        Recoverdt.Clear()
        '        Recoverda.Fill(Recoverdt)
        '        Me.GridView1.DataSource = Recoverdt
        '        Me.GridView1.DataBind()
        '        If Session("RecoverForm") = "CertificateIssued" Then
        '            'Me.GridView1.DataBind()
        '        ElseIf Session("RecoverForm") = "AssetTrBK" Then
        '            ' Me.GridView1.DataBind()
        '        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'conn.ConnectionString = Application("Strcontent")
        'conn.Open()
        cn.ConnectionString = Application("Strcontent1")
        cn.Open()
        If Not IsPostBack Then
            Call DatagridBind()
        End If
    End Sub
    Public Sub CallForm(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back.Click
        If Session("RecoverForm") = "CertificateMaster" Then
            Response.Redirect("CertificateMaster.aspx")
        ElseIf Session("RecoverForm") = "FeeStructure" Then
            Response.Redirect("frmFeeStructure.aspx")
        ElseIf Session("RecoverForm") = "TimeTable" Then
            Response.Redirect("frmTimeTable.aspx")
        ElseIf Session("RecoverForm") = "SupplierMaster" Then
            Response.Redirect("frmSuppMaster.aspx")
        ElseIf Session("RecoverForm") = "MediumMaster" Then
            Response.Redirect("FrmMedium.aspx")
        ElseIf Session("RecoverForm") = "InstituteMaster" Then
            Response.Redirect("FrmInsDetails.aspx")
        ElseIf Session("RecoverForm") = "DeptMaster" Then
            Response.Redirect("FrmDept.aspx")
        ElseIf Session("RecoverForm") = "SubjectMaster" Then
            Response.Redirect("FrmAddSubject.aspx")
        ElseIf Session("RecoverForm") = "CoursePlanner" Then
            Response.Redirect("frmCoursePlanner.aspx")
        ElseIf Session("RecoverForm") = "StudentResult" Then
            Response.Redirect("frmStudentResultDetails.aspx")
        ElseIf Session("RecoverForm") = "SponsorMaster" Then
            Response.Redirect("Sponsor.aspx")
        ElseIf Session("RecoverForm") = "SectionMaster" Then
            Response.Redirect("SectionMaster.aspx")
        ElseIf Session("RecoverForm") = "AssetMaster" Then
            Response.Redirect("FrmAsset.aspx")
        ElseIf Session("RecoverForm") = "AssetDetails" Then
            Response.Redirect("FrmAssetDetails.aspx")
        ElseIf Session("RecoverForm") = "BookIssue" Then
            Response.Redirect("FrmBookIssue.aspx")
        ElseIf Session("RecoverForm") = "Assessment" Then
            Response.Redirect("frmAssessment.aspx")
        ElseIf Session("RecoverForm") = "Semester" Then
            Response.Redirect("frmSemester.aspx")
        ElseIf Session("RecoverForm") = "Institute" Then
            Response.Redirect("frmInstitute.aspx")
        ElseIf Session("RecoverForm") = "EmpDetails" Then
            Response.Redirect("EmpDetails.aspx")
        ElseIf Session("RecoverForm") = "frmBatch" Then
            Response.Redirect("frmBatch.aspx")
        ElseIf Session("RecoverForm") = "Registration" Then
            Response.Redirect("frmAdmissionDetails.aspx")
        ElseIf Session("RecoverForm") = "frmBranch" Then
            Response.Redirect("frmBranch.aspx")
        ElseIf Session("RecoverForm") = "frmInstitute" Then
            Response.Redirect("frmInstitute.aspx")
        ElseIf Session("RecoverForm") = "frmCourse" Then
            Response.Redirect("frmCourse.aspx")
        ElseIf Session("RecoverForm") = "EmpAttd" Then
            Response.Redirect("frmEmpAttdView.aspx")
        ElseIf Session("RecoverForm") = "CoursePlanner" Then
            Response.Redirect("FrmCoursePlanner.aspx")
        ElseIf Session("RecoverForm") = "StdAttd" Then
            Response.Redirect("frmStdAttdDetails.aspx")
        ElseIf Session("RecoverForm") = "Enquiry" Then
            Response.Redirect("frmEnquiryDetails.aspx")
        ElseIf Session("RecoverForm") = "EntranceExam" Then
            Response.Redirect("ViewEntranceExamResult.aspx")
        ElseIf Session("RecoverForm") = "DayBook" Then
            Response.Redirect("DayBookDetails.aspx")
        ElseIf Session("RecoverForm") = "Bank" Then
            Response.Redirect("frmBankMaster.aspx")
        ElseIf Session("RecoverForm") = "BookMaster" Then
            Response.Redirect("frmBookMaster.aspx")
        ElseIf Session("RecoverForm") = "BookIssue" Then
            Response.Redirect("frmBookIssued.aspx")
        ElseIf Session("RecoverForm") = "AccountHead" Then
            Response.Redirect("frmAccountHead.aspx")
        ElseIf Session("RecoverForm") = "CertificateIssued" Then
            Response.Redirect("frmCertificateIssued.aspx")
        ElseIf Session("RecoverForm") = "frmManufacturer" Then
            Response.Redirect("frmManufacturer.aspx")
        ElseIf Session("RecoverForm") = "PaymentMethod" Then
            Response.Redirect("frmPayment.aspx")
        ElseIf Session("RecoverForm") = "OtherParty" Then
            Response.Redirect("frmOtherParty.aspx")
        ElseIf Session("RecoverForm") = "AssetTr" Or Session("RecoverForm") = "NormalAsset" Or Session("RecoverForm") = "AssetTrBK" Then
            Response.Redirect("frmAssetTrDetails.aspx")
        ElseIf Session("RecoverForm") = "Payroll" Then
            Response.Redirect("FrmPayrollMaster.aspx")
        ElseIf Session("RecoverForm") = "MSPayroll" Then
            Response.Redirect("FrmMonthlySalary.aspx")
        ElseIf Session("RecoverForm") = "LeaveMaster" Then
            Response.Redirect("leaveform.aspx")
        ElseIf Session("RecoverForm") = "leavereg" Then
            Response.Redirect("frmregister.aspx")
        ElseIf Session("RecoverForm") = "frmLetterPad" Then
            Response.Redirect("frmLetterPad.aspx")
        ElseIf Session("RecoverForm") = "CourseType" Then
            Response.Redirect("frmCourseType.aspx")
        ElseIf Session("RecoverForm") = "placementdetails" Then
            Response.Redirect("frmPlacementDetails.aspx")
        ElseIf Session("RecoverForm") = "Company" Then
            Response.Redirect("frmCompany.aspx")
        ElseIf Session("RecoverForm") = "Prospectus" Then
            Response.Redirect("frmProspectus.aspx")
        ElseIf Session("RecoverForm") = "MaintenanceType" Then
            Response.Redirect("frmMaintenanceType.aspx")
        ElseIf Session("RecoverForm") = "Maintenance" Then
            Response.Redirect("frmMaintenanceDetails.aspx")
        ElseIf Session("RecoverForm") = "Visiting" Then
            Response.Redirect("frmVistingDetails.aspx")
        ElseIf Session("RecoverForm") = "FeeHead" Then
            Response.Redirect("frmFeeHead.aspx")
        ElseIf Session("RecoverForm") = "feepaymentdetails" Then
            Response.Redirect("frmFeePaymentDetails.aspx")
        ElseIf Session("RecoverForm") = "AssetDetails" Then
            Response.Redirect("frmAssetDetailsView.aspx")
        ElseIf Session("RecoverForm") = "loanmaster" Then
            Response.Redirect("loanmaster.aspx")
        ElseIf Session("RecoverForm") = "Incometax" Then
            Response.Redirect("Incometax.aspx")
        ElseIf Session("RecoverForm") = "LeaveType" Then
            Response.Redirect("FrmLeaveTypes.aspx")
        ElseIf Session("RecoverForm") = "AssetUsage" Then
            Response.Redirect("frmAssetUsage.aspx")
        ElseIf Session("RecoverForm") = "TrainingMaterial" Then
            Response.Redirect("FrmTrainingMatrlView.aspx")
        ElseIf Session("RecoverForm") = "TrainingMaterialTr" Then
            Response.Redirect("frmTrainingMtrlTransfer.aspx")
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim Hid As HiddenField = CType(GridView1.Rows(e.RowIndex).FindControl("Cid"), HiddenField)
        Dim Cid1 As Integer
        '        Dim cmd As New OleDbCommand
        Cid1 = Hid.Value
        If Session("RecoverForm") = "TimeTable" Then
            Rec.RecoverTimeTable(ID)
        End If
        '        If Session("RecoverForm") = "CertificateMaster" Then
        '            sql = "Update CertificateMaster set del_flag=0 where Certificate_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "FeeStructure" Then
        '            sql = "Update FeeStructure set del_flag=0 where Fee_Structure_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "TimeTable" Then
        '            sql = "Update TimeTable set del_flag=0 where ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "SupplierMaster" Then
        '            sql = "Update SupplierMaster set Del_Flag=0 where  Supp_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "frmBatch" Then
        '            sql = "Update BatchMaster set Del_Flag=0 where  Batch_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "MediumMaster" Then
        '            sql = "Update MediumMaster set del_flag=0 where Medium_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "InstituteMaster" Then
        '            SQL = "Update InstituteMaster set Del_Flag=0 where Institute_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "DeptMaster" Then
        '            sql = "Update DeptMaster set Del_Flag=0 where Dept_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "SubjectMaster" Then
        '            sql = "Update SubjectMaster set Del_Flag=0 where Subject_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "CoursePlanner" Then
        '            sql = "Update CoursePlanner set Del_flag=0 where ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "StudentResult" Then
        '            sql = "Update StudentResult set Del_Flag=0 where ResultID=" & Cid1
        '        ElseIf Session("RecoverForm") = "SponsorMaster" Then
        '            sql = "Update SponsorMaster set Del_Flag=0 where Sponsor_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "SectionMaster" Then
        '            sql = "Update SectionMaster set Del_Flag=0 where Section_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "AssetMaster" Then
        '            sql = "Update AssetMaster set Del_Flag=0 where Asset_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "AssetDetails" Then
        '            sql = "Update AssetDetails set Del_Flag=0 where AssetDet_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "Institute" Then
        '            sql = "Update InstituteMaster set Del_Flag=0 where  Institute_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "EmpDetails" Then
        '            sql = "Update EmployeeMaster set Del_Flag=0 where  Emp_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "Registration" Then
        '            sql = "Update StudentMaster set Del_Flag=0 where  StdId=" & Cid1
        '        ElseIf Session("RecoverForm") = "frmBranch" Then
        '            sql = "Update BranchMaster set Del_Flag=0 where  Branch_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "frmInstitute" Then
        '            sql = "Update InstituteMaster set Del_Flag=0 where  Institute_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "frmCourse" Then
        '            sql = "Update CourseMaster set Del_Flag=0 where  Course_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "CoursePlanner" Then
        '            sql = "Update CoursePlanner set Del_Flag=0 where Planner_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "Enquiry" Then
        '            sql = "Update EnquiryMaster set Del_Flag=0 where EId=" & Cid1
        '            Recoverprosp(Cid1)
        '        ElseIf Session("RecoverForm") = "Bank" Then
        '            sql = "Update BankMaster set Del_Flag=0 where Bank_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "BookMaster" Then
        '            sql = "Update BookMaster set Del_Flag=0 where Book_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "EntranceExam" Then
        '            sql = "Update EntranceExam set Del_Flag=0 where EntResultId=" & Cid1
        '        ElseIf Session("RecoverForm") = "CertificateIssued" Then
        '            sql = "Update CertificateIssued set Del_Flag=0 where ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "AccountHead" Then
        '            sql = "Update Account_Heads set Del_Flag=0 where Account_Head_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "Assessment" Then
        '            sql = "Update AssessmentMaster set Del_Flag=0 where ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "BookIssue" Then
        '            sql = "Update BookIssued set Del_Flag=0 where ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "frmLetterPad" Then
        '            sql = "Update LetterPad set Del_Flag=0 where Ref_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "Semester" Then
        '            sql = "Update AssessmentMaster set Del_Flag=0 where ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "EmpAttd" Then
        '            sql = "Update EmployeeAttendance set Del_Flag=0 where Attendance_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "StdAttd" Then
        '            sql = "Update Attendance set Del_Flag=0 where AttendanceID=" & Cid1
        '        ElseIf Session("RecoverForm") = "frmManufacturer" Then
        '            sql = "Update ManuFacturerMaster set Del_Flag=0 where ManuFacturer_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "PaymentMethod" Then
        '            sql = "Update PaymentMethods SET Del_Flag=0 WHERE PaymentMethodID=" & Cid1
        '        ElseIf Session("RecoverForm") = "OtherParty" Then
        '            sql = "Update OtherParty SET Del_Flag=0 WHERE OPAutoNo=" & Cid1
        '        ElseIf Session("RecoverForm") = "CourseType" Then
        '            sql = "Update CourseType SET Del_Flag=0 WHERE CourseType_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "Maintenance" Then
        '            sql = "Update Machine_Maintenance SET Del_Flag=0 WHERE Maintain_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "placementdetails" Then
        '            sql = "Update PlacementDetails set Del_Flag=0 where Placement_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "AssetTrBK" Then
        '            Dim BookId As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(1).Text)
        '            Dim OBKID As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(2).Text)
        '            Dim Quantity As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(3).Text)
        '            Dim OriginalBookQty As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(4).Text)
        '            Dim BookPrice As Double = CInt(GridView1.Rows(e.RowIndex).Cells(9).Text)
        '            Dim AssetDetail_ID As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(10).Text)
        '            Dim OriginalAssetID As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(11).Text)
        '            Dim AssetQty As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(12).Text)
        '            Dim AssetPrice As Double = CInt(GridView1.Rows(e.RowIndex).Cells(13).Text)
        '            Dim OriginalAssetPrice As Double = CInt(GridView1.Rows(e.RowIndex).Cells(14).Text)
        '            Dim BAL As New AssetTransfer.AssetTransferB
        '            BAL.Recover(BookId, OBKID, Quantity, OriginalBookQty, BookPrice, AssetDetail_ID, OriginalAssetID, AssetQty, AssetPrice, OriginalAssetPrice)
        '            GoTo EndBind
        '        ElseIf Session("RecoverForm") = "AssetTr" Then
        '            '    Dim TargetID As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(1).Text)
        '            '    Dim SourceID As Int64 = CInt(GridView1.Rows(e.RowIndex).Cells(2).Text)
        '            '    Dim SourcePrice As Double = CDbl(GridView1.Rows(e.RowIndex).Cells(11).Text)
        '            '    Dim BAL As New AssetTransfer.AssetTransferB
        '            '    BAL.RecoverMain(TargetID, SourceID, SourcePrice)
        '            '    GoTo EndBind
        '            'ElseIf Session("RecoverForm") = "NormalAsset" Then
        '            sql = "Update AssetDetails set Del_Flag=0 where AssetDet_Id=" & Cid1
        '            cmd.Connection = conn
        '            cmd.CommandText = sql
        '            cmd.ExecuteNonQuery()
        '            sql = "Update AssetTransfer set Del_Flag=0 where Target_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "DayBook" Then
        '            sql = "UPDATE Expenses SET Del_Flag=0 WHERE Expense_ID = " & Cid1
        '            RecoverDayBook(Cid1)
        '        ElseIf Session("RecoverForm") = "Payroll" Then
        '            sql = "UPDATE PayrollMaster SET Del_Flag=0 WHERE PM_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "MSPayroll" Then
        '            sql = "UPDATE MonthlySalary SET Del_Flag=0 WHERE MS_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "LeaveMaster" Then
        '            sql = "UPDATE LeaveMaster SET Del_Flag=0 WHERE LM_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "leavereg" Then
        '            sql = "UPDATE LeaveRegister SET Del_Flag = 0 WHERE LR_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "Company" Then
        '            sql = "UPDATE PlacementCompany SET Del_Flag = 0 WHERE PCId=" & Cid1
        '        ElseIf Session("RecoverForm") = "Prospectus" Then
        '            sql = "UPDATE Prospectus_Details SET Del_Flag = 0 WHERE Prosp_ID=" & Cid1
        '            enqprospflag(Cid1)
        '        ElseIf Session("RecoverForm") = "MaintenanceType" Then
        '            sql = "UPDATE Maintenance_Type SET Del_Flag = 0 WHERE M_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "Visiting" Then
        '            sql = "UPDATE Visiting_Details SET Del_Flag = 0 WHERE VID=" & Cid1
        '        ElseIf Session("RecoverForm") = "FeeHead" Then
        '            sql = "UPDATE FeeHeads SET Del_Flag = 0 WHERE Fee_Head_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "feepaymentdetails" Then
        '            sql = "UPDATE Fee_Details SET Del_Flag = 0 WHERE ExpenseID=" & Cid1
        '            RecoverDayBook(Cid1)
        '        ElseIf Session("RecoverForm") = "AssetDetails" Then
        '            sql = "UPDATE AssetDetails SET Del_Flag = 0 WHERE AssetDet_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "loanmaster" Then
        '            sql = "UPDATE Loanmaster SET Del_Flag = 0 where LoanID=" & Cid1
        '        ElseIf Session("Recoverform") = "Incometax" Then
        '            sql = "Update IncomeTax SET Del_Flag = 0 where IT_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "LeaveType" Then
        '            sql = "Update LeaveTypes SET Del_Flag=0 WHERE TY_ID=" & Cid1
        '        ElseIf Session("RecoverForm") = "AssetUsage" Then
        '            sql = "Update AssetUsage SET Del_flag=0 WHERE Asset_Usage_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "TrainingMaterial" Then
        '            sql = "Update AssetDetails set Del_Flag=0 where AssetDet_Id=" & Cid1
        '        ElseIf Session("RecoverForm") = "TrainingMaterialTr" Then
        '            sql = "Update AssetTransfer set Del_Flag=0 where Target_Id=" & Cid1
        '        End If
        '        cmd.Connection = conn
        '        cmd.CommandText = SQL
        '        cmd.ExecuteNonQuery()
        'EndBind: Call DatagridBind()
    End Sub
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim TargetID As Int64 = CInt(GridView2.Rows(e.RowIndex).Cells(1).Text)
        Dim SourceID As Int64 = CInt(GridView2.Rows(e.RowIndex).Cells(2).Text)
        Dim SourcePrice As Double = CDbl(GridView2.Rows(e.RowIndex).Cells(11).Text)
        Dim BAL As New AssetTransfer.AssetTransferB
        'BAL.RecoverMain(TargetID, SourceID, SourcePrice)
        Call DatagridBind()
    End Sub
    Sub RecoverDayBook(ByVal Cid1 As Int64)
        Dim Parm_ID As New OleDb.OleDbParameter
        Dim sql As String
        Dim Appendcmd As New OleDbCommand()
        Dim cmd As New OleDbCommand()

        Appendcmd.Connection = conn

        With Parm_ID
            .ParameterName = "HC_Type"
            .OleDbType = OleDb.OleDbType.VarChar
            .Value = Cid1
        End With
        Appendcmd.Parameters.Add(Parm_ID)
        Appendcmd.CommandType = CommandType.StoredProcedure
        Appendcmd.CommandText = "Append_Acct_One_Qry"
        Appendcmd.ExecuteNonQuery()

        Appendcmd = New OleDbCommand()
        Appendcmd.Connection = conn
        Parm_ID = New OleDb.OleDbParameter
        With Parm_ID
            .ParameterName = "HC_Type"
            .OleDbType = OleDb.OleDbType.VarChar
            .Value = Cid1
        End With
        Appendcmd.Parameters.Add(Parm_ID)
        Appendcmd.CommandType = CommandType.StoredProcedure
        Appendcmd.CommandText = "Append_Acct_two_Qry"
        Appendcmd.ExecuteNonQuery()


        cmd.Connection = conn

        sql = "UPDATE Expenses SET Expenses.AppendAcc_One_Flag = '-1', Expenses.AppendAcc_Two_Flag = '-1',Del_Flag=0 WHERE Expense_ID = " & Cid1
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

        cmd = New OleDbCommand
        sql = "UPDATE Fee_Details SET Del_Flag = 0 WHERE ExpenseID=" & Cid1
        cmd.CommandText = sql
        cmd.Connection = conn
        cmd.ExecuteNonQuery()

    End Sub

    Sub Recoverprosp(ByVal Cid1 As Int64)
        Dim cmd As New OleDbCommand()
        cmd.Connection = conn
        sql = "Update EnquiryMaster set Del_Flag=0 where EId=" & Cid1
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

        cmd = New OleDbCommand
        sql = "UPDATE Prospectus_Details SET Del_Flag = 0 WHERE EID=" & Cid1
        cmd.CommandText = sql
        cmd.Connection = conn
        cmd.ExecuteNonQuery()
    End Sub
    Sub enqprospflag(ByVal Cid1)
        Dim cmd As New OleDbCommand

        sql = "UPDATE Prospectus_Details SET Del_Flag = 0 WHERE Prosp_ID=" & Cid1
        cmd.CommandText = sql
        cmd.Connection = conn
        cmd.ExecuteNonQuery()

        sql = "SELECT EID as enqid FROM Prospectus_Details where Prosp_ID= " & Cid1
        da = New OleDbDataAdapter(sql, new_dbconn1)
        dt.Clear()
        da.Fill(dt)

        cmd = New OleDbCommand
        cmd.Connection = new_dbconn1
        new_dbconn1.Open()
        sql = "Update EnquiryMaster set Prospectus_Given = -1 where EId = " & dt.Rows(0)("enqid") & " "
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        new_dbconn1.Close()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If GridView1.EditIndex = -1 Then
            GridView1.PageIndex = e.NewPageIndex
            Call DatagridBind()
        End If
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        'conn.Close()
        cn.Close()
    End Sub
End Class
