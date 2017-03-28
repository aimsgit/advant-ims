Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class DLRptIndividualEmployeeDetails
    'Function for Inserting the data into DDL By: Niraj 21-Mar-2013 
    Shared Function GetBranchName() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_BranchComboAll", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Function for Inserting the data into DDL By: Niraj 21-Mar-2013 
    Shared Function GetDepartment() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_DeptCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpNameCombo(ByVal DeptId As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        Para(2).Value = DeptId
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_EmpNameCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    'Function for Inserting the data into DDL By: Niraj 21-Mar-2013 
    Shared Function GetEmpName(ByVal DeptId As String, ByVal EmpType As String, ByVal EmpCat As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(4) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        Para(2).Value = DeptId
        Para(3) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        Para(3).Value = EmpType
        Para(4) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        Para(4).Value = EmpCat
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_Emp_NameCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetIndividualEmpDetails(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As String, ByVal Qualification As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchName", SqlDbType.VarChar, 50)
        arParms(2).Value = BranchName

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 50)
        arParms(3).Value = Department

        arParms(4) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        arParms(4).Value = EmpType

        arParms(5) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        arParms(5).Value = EmpCat

        arParms(6) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(6).Value = EmpName

        arParms(7) = New SqlParameter("@Designation", SqlDbType.VarChar, 150)
        arParms(7).Value = Designation


        arParms(8) = New SqlParameter("@Qualification", SqlDbType.VarChar, 150)
        arParms(8).Value = Qualification

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_IndividualEmployeeDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetIndividualEmp(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As Integer, ByVal Qualification As Integer) As DataTable
        Dim dt As DataTable
        dt = DLRptIndividualEmployeeDetails.GetIndividualEmpDetails(BranchName, Department, EmpType, EmpCat, EmpName, Designation, Qualification)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("Photos").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Photos").ToString)
                If File.Exists(s) Then
                    LoadImage(dt.Rows(i), "image_stream", s)
                Else
                    LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
                End If
            Else
                LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
            End If
            i = i - 1
        End While
        Return dt
    End Function
    'Added Merge All Employee Details : 
    'Code Writen by : Niraj on 30 jul 2014
    Shared Function GetIndividualEmpDetailsMerge(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As String, ByVal Qualification As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchName

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchName", SqlDbType.VarChar, 50)
        arParms(2).Value = BranchName

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 50)
        arParms(3).Value = Department

        arParms(4) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        arParms(4).Value = EmpType

        arParms(5) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        arParms(5).Value = EmpCat

        arParms(6) = New SqlParameter("@EmpName", SqlDbType.VarChar, 50)
        arParms(6).Value = EmpName

        arParms(7) = New SqlParameter("@Designation", SqlDbType.VarChar, 150)
        arParms(7).Value = Designation


        arParms(8) = New SqlParameter("@Qualification", SqlDbType.VarChar, 150)
        arParms(8).Value = Qualification

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_IndividualEmployeeDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetIndividualEmpMerge(ByVal BranchName As String, ByVal Department As String, ByVal EmpType As String, ByVal EmpCat As String, ByVal EmpName As String, ByVal Designation As Integer, ByVal Qualification As Integer) As DataTable
        Dim dt As DataTable
        dt = DLRptIndividualEmployeeDetails.GetIndividualEmpDetailsMerge(BranchName, Department, EmpType, EmpCat, EmpName, Designation, Qualification)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("Photos").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Photos").ToString)
                If File.Exists(s) Then
                    LoadImage(dt.Rows(i), "image_stream", s)
                Else
                    LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
                End If
            Else
                LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
            End If
            i = i - 1
        End While
        Return dt
    End Function
    Shared Sub LoadImage(ByVal objDataRow As DataRow, ByVal strImageField As String, ByVal FilePath As String)
        Try
            Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim Image(fs.Length) As Byte
            fs.Read(Image, 0, CInt(fs.Length))
            fs.Close()
            objDataRow(strImageField) = Image
        Catch ex As Exception
            'Response.Write("<font color=red>" + ex.Message + "</font>")
        End Try
    End Sub
    Shared Function GetDepartment1(ByVal BranchCode As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = BranchCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_DeptCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpName1(ByVal BranchCode As String, ByVal DeptId As String, ByVal EmpType As String, ByVal EmpCat As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(4) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = BranchCode
        Para(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        Para(2).Value = DeptId
        Para(3) = New SqlParameter("@EmpType", SqlDbType.VarChar, 50)
        Para(3).Value = EmpType
        Para(4) = New SqlParameter("@EmpCat", SqlDbType.VarChar, 50)
        Para(4).Value = EmpCat
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_Emp_NameCombo", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetDesignation() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "ddlDesignation", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetQualification() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        'Dim Para() As SqlParameter = New SqlParameter(0) {}

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "ddlQualification")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDepartmentSal() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Rpt_DeptComboSal", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class