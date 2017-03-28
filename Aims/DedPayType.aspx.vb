Imports System.IO

Partial Class DedPayType
    Inherits BasePage
    Dim EL As New ELDeduction
    Dim BL As New BLDeduction
    Dim dt, dt1 As DataTable
    Dim dispId As String

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            msginfo.Text = ""
            lblmsg.Text = ""
            Try
                Dim Dedtype As String = ddlDedtype.SelectedValue
                Dim S As String() = Dedtype.Split(":")
                If btnadd.CommandName = "UPDATE" Then
                    EL.Empid = ddlEmployee.SelectedValue
                    EL.id = ViewState("id")
                    EL.Amount = txtAmt.Text
                    EL.DedType = S(1)
                    EL.ValidFrom = txtfrom.Text
                    EL.Upto = txtupto.Text
                    EL.Dedid = S(0)

                    If (CDate(txtupto.Text) < CDate(txtfrom.Text)) Then
                        msginfo.Text = "Valid Upto cannot be Smaller than Valid From."
                        lblmsg.Text = ""
                        txtupto.Focus()
                        Exit Sub
                    End If

                    'dt1 = BL.GetDuplicateCurrentYear(EL.id)
                    'If dt1.Rows.Count > 0 Then
                    '    For row As Integer = 0 To dt1.Rows.Count - 1
                    '        If dt1.Rows(row).Item("CurrentAppraisal") = "Y" Then
                    '            If ddlcurrAppraisal.SelectedValue = "Y" Then
                    '                lblerrmsg.Text = ValidationMessage(1038)
                    '                lblmsgifo.Text = ValidationMessage(1014)
                    '                Exit Sub
                    '            Else
                    '                EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                    '            End If
                    '        Else
                    '            EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                    '        End If
                    '    Next
                    'Else
                    '    EL.CurrentAppraisal = ddlcurrAppraisal.SelectedValue
                    'End If

                    BL.UpdateRecord(EL)
                    btnadd.CommandName = "ADD"
                    btnview.CommandName = "VIEW"
                    btnadd.Text = "ADD"
                    btnview.Text = "VIEW"
                    Clear()
                    GVDed.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1017)
                    'End If
                ElseIf btnadd.CommandName = "ADD" Then

                    EL.Empid = ddlEmployee.SelectedValue
                    EL.id = 0
                    EL.Amount = txtAmt.Text
                    If ddlDedtype.SelectedValue = "0:0" Then
                        msginfo.Text = "Select Deduction/Earning Type."
                        Exit Sub
                    Else
                        EL.DedType = S(1)
                        msginfo.Text = ""
                    End If
                    If txtfrom.Text = "" Then
                        msginfo.Text = "Enter Valid From Date."
                        Exit Sub
                    Else
                        EL.ValidFrom = txtfrom.Text
                        msginfo.Text = ""
                    End If
                    If txtupto.Text = "" Then
                        msginfo.Text = "Enter Valid Upto Date."
                        Exit Sub
                    Else
                        EL.Upto = txtupto.Text
                        msginfo.Text = ""
                    End If
                    EL.Dedid = S(0)

                    If (CDate(txtupto.Text) < CDate(txtfrom.Text)) Then
                        msginfo.Text = "Valid Upto cannot be Smaller than Valid From."
                        txtupto.Focus()
                        Exit Sub
                    End If
                    'dt1 = BL.GetDuplicateCurrentYear(EL.id)
                    'If dt1.Rows.Count > 0 Then
                    '    For row As Integer = 0 To dt1.Rows.Count - 1
                    '        If dt1.Rows(row).Item("CurrentAppraisal") = "Y" Then
                    '            If ddlcurrAppraisal.SelectedValue = "Y" Then
                    '                lblerrmsg.Text = ValidationMessage(1038)
                    '                lblmsgifo.Text = ValidationMessage(1014)
                    '                Exit Sub
                    '            Else
                    '                EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                    '            End If
                    '        Else
                    '            EL.CurrentAppraisal = ddlcurrAppraisal.SelectedItem.Value
                    '        End If
                    '    Next
                    'Else
                    '    EL.CurrentAppraisal = ddlcurrAppraisal.SelectedValue
                    'End If
                    Dim i As New Integer
                    i = BL.InsertRecord(EL)
                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                    lblmsg.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GVDed.PageIndex = 0
                    ''dt = AcademicYearDB.GetGridDataById(ViewState("dispId "))
                    ''dt = BAL.GetEnquiry(enq)
                    'GrdPerfCycle.Visible = True
                    'GrdPerfCycle.DataSource = dt
                    'GrdPerfCycle.DataBind()
                    DisplayGrid()
                    Clear()
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1020)

                    'End If
                End If
            Catch e1 As Exception
                msginfo.Text = ValidationMessage(1022)
                lblmsg.Text = ValidationMessage(1014)
            End Try
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Sub DisplayGrid()
        EL.id = 0
        dt = BL.GetGridData(EL)
        If dt.Rows.Count = 0 Then
            GVDed.DataSource = Nothing
            GVDed.DataBind()
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1023)
            
        Else
            GVDed.DataSource = dt
            GVDed.DataBind()
            
            GVDed.Enabled = True
            GVDed.Visible = True
            LinkButton.Focus()
        End If
        'Multilingual()
    End Sub
    Sub Clear()
        txtAmt.Text = ""
        txtfrom.Text = Format(Today(), "dd-MMM-yyyy")
        txtupto.Text = Format(Today(), "dd-MMM-yyyy")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVDed_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVDed.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub GVDed_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVDed.PageIndexChanging
        GVDed.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVDed.PageIndex
        DisplayGrid()
    End Sub

    Protected Sub GVDed_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVDed.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GVDed.Rows(e.RowIndex).Cells(1).FindControl("lblID"), Label).Text
            If BL.ChangeFlag(EL) Then
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1028)
                GVDed.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GVDed.Enabled = True
            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GVDed_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVDed.RowEditing
        msginfo.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        ddlEmployee.Items.Clear()
        ddlEmployee.DataSourceID = "ObjEmplyeeName"
        ddlEmployee.DataBind()
        ddlEmployee.SelectedValue = CType(GVDed.Rows(e.NewEditIndex).FindControl("lblEmpid"), Label).Text
        txtAmt.Text = CType(GVDed.Rows(e.NewEditIndex).FindControl("lblAmt"), Label).Text
        ddlDedtype.Items.Clear()
        ddlDedtype.DataSourceID = "ObjDedType"
        ddlDedtype.DataBind()
        ddlDedtype.SelectedValue = CType(GVDed.Rows(e.NewEditIndex).FindControl("lbldedtypeid"), Label).Text
        txtfrom.Text = CType(GVDed.Rows(e.NewEditIndex).FindControl("lblValidFrom"), Label).Text
        txtupto.Text = CType(GVDed.Rows(e.NewEditIndex).FindControl("lblupto"), Label).Text
        ViewState("id") = CType(GVDed.Rows(e.NewEditIndex).FindControl("lblID"), Label).Text
        btnadd.CommandName = "UPDATE"
        btnview.CommandName = "BACK"
        btnadd.Text = "UPDATE"
        btnview.Text = "BACK"
        EL.id = ViewState("id")
        dt = BL.GetGridData(EL)
        GVDed.DataSource = dt
        GVDed.DataBind()
        GVDed.Enabled = False
    End Sub

    Protected Sub GVDed_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVDed.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.id = 0
        dt = BL.GetGridData(EL)
        'GrdAcdYear.DataSource = dt

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVDed.DataSource = sortedView
        GVDed.DataBind()
        GVDed.Enabled = True
        GVDed.Visible = True
        LinkButton.Focus()
        'Multilingual()

    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property

    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        msginfo.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        btnprint.Enabled = True
        If btnview.Text.Equals("BACK") Then
            ViewState("PageIndex") = 0
            GVDed.PageIndex = 0
            DisplayGrid()
            GVDed.Visible = True
            btnview.CommandName = "VIEW"
            btnadd.CommandName = "ADD"
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
        Else
            Clear()
            Dim Dedtype As String = ddlDedtype.SelectedValue
            Dim S As String() = Dedtype.Split(":")
            EL.Empid = ddlEmployee.SelectedValue
            EL.DedType = S(1)
            EL.Dedid = S(0)
            btnview.CommandName = "VIEW"
            btnadd.CommandName = "ADD"
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            GVDed.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
        
    End Sub

    'Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click
    '    GVDed.AllowPaging = False
    '    GVDed.DataBind()
    '    Dim sw As New StringWriter()
    '    Dim hw As New HtmlTextWriter(sw)
    '    GVDed.RenderControl(hw)
    '    Dim gridHTML As String = sw.ToString().Replace("""", "'") _
    '         .Replace(System.Environment.NewLine, "")
    '    Dim sb As New StringBuilder()
    '    sb.Append("<script type = 'text/javascript'>")
    '    sb.Append("window.onload = new function(){")
    '    sb.Append("var printWin = window.open('', 'PrintWindow', 'left=0")
    '    sb.Append(",top=0,width=1000,height=1000,status=0');")
    '    sb.Append("printWin.document.write(""")
    '    sb.Append(gridHTML)
    '    sb.Append(""");")
    '    sb.Append("printWin.document.close();")
    '    sb.Append("printWin.focus();")
    '    sb.Append("printWin.print();")
    '    sb.Append("printWin.close();};")
    '    sb.Append("</script>")
    '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "GridPrint", sb.ToString(), True)
    '    ClientScript.RegisterStartupScript(Me.[GetType](), "GridPrint", sb.ToString())
    '    GVDed.AllowPaging = True
    '    GVDed.DataBind()
    '    DisplayGrid()
    'End Sub
    'Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    '    'Verifies that the control is rendered
    'End Sub

    Protected Sub btndeduction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndeduction.Click
        Dim month As String = ddlMonth.SelectedItem.Text
        Dim Year As String = ddlYear.SelectedItem.Text
        Dim MonthNo As Integer = ddlMonth.SelectedValue
        EL.Month = month
        EL.Year = Year
        DLDeduction.RunDeduction(month, Year, MonthNo)
        msginfo.Text = ""
        lblmsg.Text = "Run Done Sucessfully."
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtfrom.Text = Format(Today(), "dd-MMM-yyyy")
            txtupto.Text = Format(Today(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
