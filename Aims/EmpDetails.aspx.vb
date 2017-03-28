Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Partial Public Class EmpDetails
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    'Dim str As String = "Add"
    '    'Session("editstr") = str
    '    'Response.Redirect("EmployeeMaster.aspx")
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ODSEmpDetails.Select()
        Try
            GVDetails.DataBind()
            If GVDetails.SelectedIndex = 0 Then
                btnPreview.Enabled = False
            Else
                btnPreview.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'OpenNewWindow.Opennewwindow(btnPreview, "EmployeeReptV.aspx")
        ' txtEmp.ForeColor = Drawing.Color.Blue
    End Sub
    Protected Sub GVDetails_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVDetails.DataBound
        'ddlEmp.DataBind()
        'Dim footer As GridViewRow
        'footer = GVDetails.FooterRow
        'footer.Cells(0).ColumnSpan = 4
        'footer.Cells(0).HorizontalAlign = HorizontalAlign.Center
        'footer.Cells.RemoveAt(2)
        'footer.Cells.RemoveAt(1)
        'footer.Cells.RemoveAt(3)
        'footer.Cells(0).Text = "This is footer"
    End Sub
    Protected Sub GVDetails_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GVDetails.RowDeleted
        GVDetails.DataBind()
    End Sub
    Protected Sub GVDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVDetails.RowDeleting
        Dim id As HiddenField = CType(GVDetails.Rows(e.RowIndex).Cells(1).FindControl("EID"), HiddenField)
        Dim Status As Boolean
        Status = globalcnn.Del_Validation(id.Value, "EmployeeMaster")
        If (Status) = True Then
            MsgBox1.Text = "Record is already used."
        End If
    End Sub
    Protected Sub GVDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVDetails.RowEditing
        GVDetails.EditIndex = CInt(e.NewEditIndex)
        Dim idedit As Integer = GVDetails.EditIndex
        Dim id As HiddenField = CType(GVDetails.Rows(GVDetails.EditIndex).Cells(0).FindControl("EID"), HiddenField)
        'Dim id As Integer = GVDetails.Rows(GVDetails.EditIndex).Cells(0).FindControl("ID").ToString
        Dim idd As Integer = id.Value
        Dim str As String = "Edit"
        Session("editid") = idd
        Session("editstr") = str
        Response.Redirect("EmployeeMaster.aspx")
    End Sub
    Protected Sub GVDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVDetails.SelectedIndexChanged
        Dim index As Integer = GVDetails.SelectedIndex
        Dim ID As Integer = GVDetails.SelectedDataKey.Values("Emp_Id")
        Dim str As String = GVDetails.SelectedRow.Cells(2).ToString
    End Sub
    Protected Function GetBranchName(ByVal id As Long) As String
        'Response.Write(id.ToString)
        Dim obj As New BranchManager
        'Dim br As Branch = obj.GetBranchByBranchId(id)
        'Return Dept.Name
        Return "a"
    End Function
    Protected Function GetInstituteName(ByVal id As Long) As String
        Dim obj As New InstituteManager
        Dim Inst As Institute = obj.GetInstituteByInstituteId(id)
        Return Inst.Name
    End Function
    Protected Function GetDepartmentName(ByVal id As Long) As String
        Dim obj As New DepartmentManager
        'Dim Dept As Department = obj.GetDepartmentByDepartmentId(id)
        'Return Dept.Name
        Return "a"
    End Function
    Protected Function GetEmpType(ByVal id As Long) As String
        Dim rtstr As String
        If id = 0 Then
            rtstr = "Permanent"
        Else
            rtstr = "Contract"
        End If
        Return rtstr
    End Function
    Protected Function GetCategoryName(ByVal id As Long) As String
        Dim obj As New CategoryManager
        Dim Categry As Category = obj.GetCategoryByCategoryId(id)
        Return Categry.CategoryName
    End Function
    'Protected Function GetCatgory(ByVal id As Long) As String
    '    Dim str As String
    '    If id = 0 Then
    '        str = "IT"
    '    Else
    '        str = "Marketing"
    '    End If
    '    Return str
    'End Function

    'Protected Sub DDLbranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLbranch.SelectedIndexChanged
    'Dim im As New SearchManager
    'Dim id As Long
    'id = DDLbranch.SelectedValue.ToString
    'Dim inst As New List(Of Institute)
    'inst = im.GetInstituteByBranchId(id)
    'For Each row As Institute In inst
    '    'DDLInstitute.DataSource = inst
    '    DDLInstitute.DataTextField = row.Name
    '    DDLInstitute.DataValueField = row.Id
    'Next
    'Dim PCol(1) As DataColumn
    ''PCol(0) = pdt.Columns("PaymentMethodID")
    'DDLInstitute.DataSource() = ODSInstitute
    'DDLInstitute.DataTextField = inst.Name
    'DDLInstitute.DataValueField = inst.Id
    'End Sub
    Protected Sub btnRec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRec.Click
        Session("RecoverForm") = "EmpDetails"
        Response.Redirect("recover.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("EmployeeMaster.aspx")
    End Sub
    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim Bll As New EmployeeManager
        Dim Inst As Int64
        If Session("InstituteID") = "" Then
            Inst = 0
        Else
            Inst = (Int64).Parse(Session("InstituteID"))
        End If
        Dim Brch As Int64
        If Session("BranchID") = Nothing Then
            Brch = 0
        Else
            Brch = (Int64).Parse(Session("BranchID"))
        End If
        Dim dt As New DataTable
        dt = Bll.RptGVDetails(Inst, Brch)
        If dt.Rows.Count <> 0 Then
            'If GVDetails.Rows.Count <> 0 Then
            'Updated by sendhil-Abishek Type:Table
            Dim qrystring As String = "EmployeeReptV.aspx?" & QueryStr.Querystring()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Else
            MsgBox1.Text = "No records to display."
            MsgBox1.Visible = True
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Employee Details")
    End Sub
    Protected Sub ODSEmpDetails_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ODSEmpDetails.Selecting
        'If txtEmp.Text <> "" Then
        '    e.InputParameters("id") = GlobalFunction.IdCutter(txtEmp.Text)

        'End If
    End Sub

    'Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
    '    Dim str1 As String
    '    Try
    '        txtEmp.ForeColor = Drawing.Color.Blue
    '        If txtEmp.Text <> "" Then
    '            str1 = GlobalFunction.IdCutter(txtEmp.Text)
    '        End If
    '    Catch
    '        txtEmp.Text = "Not a valid Name.Try again."
    '        txtEmp.ForeColor = Drawing.Color.Red
    '    End Try
    'End Sub
    Protected Function GetStateName(ByVal id As Long) As String
        Dim sobj As New EnquiryManager
        Dim st As State = sobj.GetStateid(id)
        Return st.StateName
    End Function
End Class

