
Partial Class leaveform
    Inherits BasePage
    Dim Emp As String
    Dim leaveid As Integer
    Dim leave As New Leave
    Dim leaveManager As New LeaveManager
    Dim GlobalFunction As New GlobalFunction
    Protected Function GetEmpName(ByVal id As Long) As String
        Dim Emp As New EmployeeManager
        Dim d As EmpCombo = Emp.GetEmpID(id)
        Return d.Emp_Name
    End Function
    Protected Function GetLeavetype(ByVal id As Long) As DataTable
        Dim lea As New LeaveTypes
        Dim d As DataTable ' = lea.GetLeavid)
        Return d
    End Function
    Sub clear()
        CType(FormView1.FindControl("txtEmp"), TextBox).Text = ""
        CType(FormView1.FindControl("textblanceleav"), TextBox).Text = ""
        CType(FormView1.FindControl("txtremark"), TextBox).Text = ""
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim id As HiddenField = CType(GridView1.Rows(e.NewEditIndex).Cells(2).FindControl("lid"), HiddenField)
        Dim idd As Integer = id.Value
        odsleave.SelectParameters.Clear()
        odsleave.SelectParameters.Add("id", idd)
        FormView1.DataBind()
        FormView1.ChangeMode(FormViewMode.Edit)
        GridView1.Columns(0).Visible = False
        GridView1.Enabled = False
        Emp = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("emid"), HiddenField).Value + ":" + CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Label2"), Label).Text
        leaveid = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("lid"), HiddenField).Value
    End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        CType(FormView1.FindControl("txtEmp"), TextBox).Text = Emp
        'CType(FormView1.FindControl("txtEmp"), TextBox).ForeColor = Drawing.Color.Blue
        CType(FormView1.FindControl("txtid"), TextBox).Text = leaveid
    End Sub
    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        Try
            odsleave.SelectParameters.Clear()
            Dim idd As Integer = 0
            odsleave.SelectParameters.Add("id", idd)
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Columns(0).Visible = True
            lblErrorMsg.Text = "Data Updated SucessFully"
        Catch
            lblErrorMsg.Text = "Error Found in Update Operation"
        End Try
    End Sub
    Protected Sub BtnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Inst As String = Session("InstituteID")
        Dim Brch As String = Session("BranchID")
        Dim dt As New DataTable
        dt = leaveManager.GetReport(Inst, Brch)
        Try
            If dt.Rows.Count <> 0 Then
                'Response.Redirect("rptleavemastr.aspx")
                'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "rptleavemastr.aspx?" & QueryStr.Querystring()
                Dim qrystring As String = "rptleavemastr.aspx?" & QueryStr.Querystring()
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                lblErrorMsg.Text = "No Records to Display"
            End If
        Catch
            lblErrorMsg.Text = "Error Found in Report"
        End Try
    End Sub
    Protected Sub BtnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("RecoverForm") = "LeaveMaster"
            Response.Redirect("recover.aspx")
            lblErrorMsg.Text = "Data Recovered Sucessfully"
        Catch
            lblErrorMsg.Text = "Error Found in Recover Operation"
        End Try
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        odsleave.SelectParameters.Clear()
        Dim idd As Integer = 0
        odsleave.SelectParameters.Add("id", idd)
        GridView1.DataSourceID = "odsleave"
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
        GridView1.Columns(0).Visible = True
        'Panel1.Visible = True
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.ValidateFormView("Leave Details")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim txtEmp As TextBox = CType(FormView1.FindControl("txtEmp"), TextBox)
        txtEmp.Focus()
        lblErrorMsg.Text = ""
        'If Not IsPostBack Then
        '    GridView1.Visible = False
        '    Panel1.Visible = False
        'End If
        'ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & FormView1.FindControl("txtemp").ClientID & "').focus();</script>")
    End Sub
    Protected Sub GridView1_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GridView1.RowDeleted
        Try
            GridView1.DataBind()
            GridView1.Visible = True
            lblErrorMsg.Text = "Data Deleted SucessFully"
        Catch
            lblErrorMsg.Text = "Error Found in Delete Operation"
        End Try
    End Sub
    Sub CancelEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        odsleave.SelectParameters.Clear()
        Dim idd As Integer = 0
        odsleave.SelectParameters.Add("id", idd)
        GridView1.DataBind()
        GridView1.Enabled = False
        GridView1.Visible = False
        GridView1.Columns(0).Visible = True
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        leave.EId = GlobalFunction.IdCutter(CType(FormView1.FindControl("txtEmp"), TextBox).Text)
        leave.LeaveType = CType(FormView1.FindControl("txtleav"), DropDownList).SelectedValue
        leave.BalanceLeave = CType(FormView1.FindControl("textblanceleav"), TextBox).Text
        leave.Remarks = CType(FormView1.FindControl("txtremark"), TextBox).Text
        leaveManager.InsertRecord(leave)
        lblErrorMsg.Text = "Data Saved SuccessFully"
        clear()
        GridView1.Visible = False
    End Sub
    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        leave.LmId = CType(FormView1.FindControl("txtid"), TextBox).Text
        leave.EId = GlobalFunction.IdCutter(CType(FormView1.FindControl("txtEmp"), TextBox).Text)
        leave.LeaveType = CType(FormView1.FindControl("txtleav"), DropDownList).SelectedValue
        leave.BalanceLeave = CType(FormView1.FindControl("textblanceleav"), TextBox).Text
        leave.Remarks = CType(FormView1.FindControl("txtremark"), TextBox).Text
        leaveManager.UpdateRecord(leave)
        lblErrorMsg.Text = "Data Updated SuccessFully"
        clear()
        FormView1.ChangeMode(FormViewMode.Insert)
        GridView1.Visible = False
    End Sub

    Protected Sub FormView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.PreRender
        Dim str1 As String
        Try
            'CType(FormView1.FindControl("txtEmp"), TextBox).ForeColor = Drawing.Color.Blue
            If CType(FormView1.FindControl("txtEmp"), TextBox).Text <> "" Then
                str1 = GlobalFunction.IdCutter(CType(FormView1.FindControl("txtEmp"), TextBox).Text)
            End If
        Catch
            CType(FormView1.FindControl("txtEmp"), TextBox).Text = "Not a valid Name.Try again."
            CType(FormView1.FindControl("txtEmp"), TextBox).ForeColor = Drawing.Color.Red
        End Try
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
