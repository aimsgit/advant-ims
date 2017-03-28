Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class TextBoxExt
    Inherits System.Web.Services.WebService
    'Modified by Nitin 20/12/2011
    <WebMethod(EnableSession:=True)> _
    Public Function GetHOEmpExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DLTableConfiguration.GetHOEmpExt(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Name").ToString() + ":" + dr("Emp_Code").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getAssetName(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = AssetDB.getAssetName(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("AssetCode").ToString() + ":" + dr("AssetName").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getIssued(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = AssetDB.GetDatEmpCode(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    '<WebMethod(EnableSession:=True)> _
    'Public Function getIssued(ByVal prefixText As String) As String()
    '        Dim dt As New DataTable
    '        dt = AssetDB.GetDatEmpCode(prefixText)
    '        Dim items As String() = New String(dt.Rows.Count - 1) {}
    '        Dim i As Integer = 0
    '        For Each dr As DataRow In dt.Rows
    '            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
    '            i += 1
    '        Next
    '        Return items
    '    End Function
    <WebMethod(EnableSession:=True)> _
 Public Function getStudentCode(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = feeCollectionDL.GetStudentFee(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("StdName").ToString() + ":" + dr("StdId").ToString() + ":" + dr("BatchID").ToString() + ":" + dr("categoryid").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getStudentid(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = feeCollectionDL.GetStudent(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("StdName").ToString() + ":" + dr("StdId").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getStudentIdName(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = feeCollectionDL.GetStudent(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("StdName").ToString() + ":" + dr("StdId").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getEmpCodeExt1(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BookIssueDB.GetEmpCodeExt(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString() + ":" + dr("EmpID").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getEmpCodeExtExraC(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BookIssueDB.GetEmpCodeExt(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getEmpCodeExt2(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = EmpTransD.GetEmp(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString() + ":" + dr("EmpID").ToString() + ":" + dr("BranchName").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getEmpCodeExt3(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DLProjectMaster.GetEmpCodeExt(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString() + ":" + dr("EmpID").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getStudentIdName1(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BookIssueDB.getStudentIdName(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("StdName").ToString() + ":" + dr("StdId").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getStudentIdNameEx(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BookIssueDB.getStudentIdName(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("StdName").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
        Public Function getBatchNo(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DLReportsP.GetBatchNo(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("BatchNo").ToString(), i)
            i += 1
        Next
        Return items
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getCourseExt() As String()
        Dim dt As New DataTable
        'dt = CourseDB.GetDtaCourse(StdCode)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Course_ID").ToString() + ":" + dr("Course").ToString(), i)
            i += 1
        Next

        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
  Public Function getStudentExt2(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = StudentDB.GetDatStd2(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("Std_Id").ToString() + ":" + dr("StdName").ToString() + ":" + dr("Perm_Address").ToString() + ":" + dr("AcademicYear").ToString() + ":" + dr("A_Code").ToString() + ":" + dr("CourseName").ToString() + ":" + dr("Courseid").ToString() + ":" + dr("Batch_No").ToString() + ":" + dr("BatchID").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    'Code By JinaPriya - 9/3/2015 [Autofill studentcode on selecting StudentName]
    <WebMethod(EnableSession:=True)> _
Public Function getStudentName(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DLStudentEnquiryForm.GetDataStudent(prefixText, Session("CourseId"), Session("BatchId"))
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdName").ToString() + ":" + dr("Std_Id").ToString() + ":" + dr("StdCode").ToString() + ":" + dr("A_Code").ToString() + ":" + dr("CourseName").ToString() + ":" + dr("Courseid").ToString() + ":" + dr("Batch_No").ToString() + ":" + dr("BatchID").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    'Code By JinaPriya - 9/3/2015 [Autofill StudentName on selecting studentcode]
    <WebMethod(EnableSession:=True)> _
        Public Function getStudentEnquiryId(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DLStudentEnquiryForm.GetDataStudentID(prefixText, Session("CourseId"), Session("BatchId"))
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("Std_Id").ToString() + ":" + dr("StdName").ToString() + ":" + dr("CourseName").ToString() + ":" + dr("Courseid").ToString() + ":" + dr("Batch_No").ToString() + ":" + dr("BatchID").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=False)> _
Public Function getStudentExt3(ByVal prefixText As String, ByVal Branchcode As String) As String()
        Dim dt As New DataTable
        dt = StudentDB.GetDatStd3(prefixText, Branchcode)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("Std_Id").ToString() + ":" + dr("StdName").ToString() + ":" + dr("Perm_Address").ToString() + ":" + dr("AcademicYear").ToString() + ":" + dr("A_Code").ToString() + ":" + dr("CourseName").ToString() + ":" + dr("Courseid").ToString() + ":" + dr("Batch_No").ToString() + ":" + dr("BatchID").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getProductName(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = StudentDB.GetProductName(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Product_Name").ToString() + ":" + dr("Product_Id").ToString(), i)
            i += 1
        Next
        Return items
    End Function

    <WebMethod(EnableSession:=True)> _
     Public Function getBatchExt1(ByVal CourseID As Integer) As String()
        Dim dt As New DataTable
        dt = BatchDB.GetDtaBatch1(CourseID)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("ID").ToString() + ":" + dr("Batch_No").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
     Public Function getBatchExt(ByVal Course_ID As Integer, ByVal StdCode As Integer) As String()
        Dim dt As New DataTable
        dt = BatchDB.GetDtaBatch(Course_ID, StdCode)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("ID").ToString() + ":" + dr("Batch_No").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getStudentExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        'dt = StudentDB.GetDatStd(prefixText, HttpContext.Current.Session("sesCourse"), HttpContext.Current.Session("sesBatch"))
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdId").ToString() + ":" + dr("StdCode").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
   Public Function getStudentNameBatchByCode(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DLParentMngt.getStudentNameBatchByCode(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("StdName").ToString() + ":" + dr("StdId").ToString() + ":" + dr("BatchId").ToString() + ":" + dr("Batch_No").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getStudentExt1(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = StudentDB.GetDatStd1(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdId").ToString() + ":" + dr("StdCode").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getStudentNameExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = StudentDB.GetDatStdName(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("STD_ID").ToString() + ":" + dr("StdName").ToString(), i)
            i += 1

        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getEmpExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = EmployeeDB.GetDatEmp(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Id").ToString() + ":" + dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
   Public Function GetBranchName(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DLUserManagement.GetBranchName(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("EmpID").ToString() + ":" + dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString() + ":" + dr("BranchName").ToString() + ":" + dr("BranchCode").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
   Public Function SearchLinkName(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = UserDetailsDB.SearchLinkName(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Code").ToString() + ":" + dr("Title").ToString() + ":" + dr("LinkName").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getEmpCodeExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = EmployeeDB.GetDatEmpCode(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function getEmpCodeExtender(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        If Session("Admin") = 1 Then
            dt = EmployeeDB.GetDatEmpCodeExt(prefixText, 0, HttpContext.Current.Session("NewBranchID"))
        Else
            dt = EmployeeDB.GetDatEmpCodeExt(prefixText, HttpContext.Current.Session("sesInstitute"), HttpContext.Current.Session("sesbranch"))
        End If
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Id").ToString() + ":" + dr("Emp_Code").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetEmpSelExt(ByVal prefixText As String, ByVal Attendance_ID As Integer) As String()

        Dim dt As New DataTable

        dt = EmployeeDB.GetEmpSelExt(prefixText, HttpContext.Current.Session("sesDepartment"), Attendance_ID)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetBatchExtForCoursePlanner(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BatchDB.GetBatchExtForCoursePlanner(prefixText, HttpContext.Current.Session("sesInstitute"), HttpContext.Current.Session("sesbranch"), HttpContext.Current.Session("sesCourse"))
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("ID").ToString() + ":" + dr("Batch_No").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetAllCourseExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = CourseDB.GetAllCourseExt(prefixText, HttpContext.Current.Session("sesInstitute"), HttpContext.Current.Session("sesbranch"))
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Course_ID").ToString() + ":" + dr("Course").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getSupExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = SupplierDB.GetDatSup(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Supp_Id_Auto").ToString() + ":" + dr("Supp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getBankExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BankDB.GetDatBank(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Bank_IDAuto").ToString() + ":" + dr("Bank_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getOthPrtyExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = OtherpartyDB.GetDatOthParty(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("OPAutoNoAuto").ToString() + ":" + dr("OP_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    'coded by neha 23-feb-2012 to get the student name
    <WebMethod(EnableSession:=True)> _
    Public Function getEnquiryExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = EnquiryDB.getEnquiryExt(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("FName").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    '<WebMethod(EnableSession:=True)> _
    ' Public Function GetCourseByTypeExt(ByVal prefixText As String) As String()
    '    Dim dt As New DataTable
    '    'dt = CourseDB.GetCourseByTypeExt(prefixText)
    '    Dim items As String() = New String(dt.Rows.Count - 1) {}
    '    Dim i As Integer = 0
    '    For Each dr As DataRow In dt.Rows
    '        items.SetValue(dr("Course_ID").ToString() + ":" + dr("CourseName").ToString(), i)
    '        i += 1
    '    Next
    '    Return items
    'End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getEmployeeExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = EmployeeDB.getEmployeeExt(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function getStudentCodeExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        'dt = CertificateIssuedD.GetCertificateDatEmpCode(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Code").ToString() + ":" + dr("Emp_Name").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
   Public Function GetRecievedBy(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = AssetDetailsDB.GetRecievedBy(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Emp_Name").ToString() + ":" + dr("EmpID").ToString(), i)
            i += 1
        Next
        Return items
    End Function


    <WebMethod(EnableSession:=True)> _
Public Function getBookNameExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BookIssueDB.GetBookNameExt(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("BookCode").ToString() + ":" + dr("BookName").ToString() + ":" + dr("Book_IDAuto").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function getStudentIdName2(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BookReturnD.getStudentIdName2(prefixText)
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("StdCode").ToString() + ":" + dr("StdName").ToString() + ":" + dr("StdId").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
    Public Function GetPartyTypeExt(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = DayBookDB.GetPartyTypeExt(prefixText, Session("DayBkPType"))
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("Name").ToString() + ":" + dr("ID").ToString(), i)
            i += 1
        Next
        Return items
    End Function

    <WebMethod(EnableSession:=True)> _
Public Function getBookNameExtN(ByVal prefixText As String) As String()
        Dim dt As New DataTable
        dt = BookIssueDB.GetBookNameExtN(prefixText, Session("Dept"))
        Dim items As String() = New String(dt.Rows.Count - 1) {}
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            items.SetValue(dr("BookCode").ToString() + ":" + dr("BookName").ToString() + ":" + dr("Book_IDAuto").ToString(), i)
            i += 1
        Next
        Return items
    End Function
    <WebMethod(EnableSession:=True)> _
Public Function title(ByVal name As String, ByVal code As Integer, ByVal Link As String) As String
        Dim FormName As String = name.ToUpper()

        Session("RptFrmTitleName") = FormName
        Session("Code") = code
        Session("Form") = Link
        Return Nothing
    End Function
End Class

