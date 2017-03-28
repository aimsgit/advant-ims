Imports System.Collections.Generic
Partial Class fmVistingDetails
    Inherits BasePage
    Dim alt As String
    Dim sql As String
    Dim em As New EmployeeManager
    Dim prop As New Visiting
    Dim BAL As New VisitingManager
    Dim GlobalFunction As New GlobalFunction

    Protected Sub GridView1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Load

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'Code For Row Deleting By Nitin 04/06/2012
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("BMID") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("VID"), HiddenField).Value
            prop.VId = ViewState("BMID")
            BAL.ChangeFlag(prop)
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
            GridView1.Visible = True
            lblErrorMsg.Text = ""
            lblmsginfo.Text = "Data Deleted Successfully."
            txtEmp.Focus()
            DispGrid()

        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsginfo.Text = ""
        End If
    End Sub
    'Code For Retrive Employee Name By Nitin 04/06/2012
    Sub GetempName()
        Dim e As EmpCombo = em.GetEmpID(GlobalFunction.IdCutter(txtEmp.Text))
        txtName.Text = e.Emp_Name
    End Sub

    Protected Sub btnrecover_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RecoverForm") = "Visiting"
        Response.Redirect("Recover.aspx")
    End Sub
    Sub Splitter2(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtEmp.Text = parts(0).ToString()
            txtName.Text = parts(1).ToString()
            HidempId.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtEmp.AutoPostBack = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblmsginfo.Text = ""
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & txtEmp.ClientID & "').focus();</script>")
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
        'Lblmsg.Text = ""
        If Not IsPostBack Then
            txtVisitingDate.Text = Format(Today, "dd-MMM-yyyy")
            txtEmp.Focus()
        End If
        If txtEmp.Text <> "" Then
            Splitter2(txtEmp.Text)
        Else
            txtEmp.AutoPostBack = True
            txtEmp.Text = ""
            Splitter2(txtEmp.Text)
        End If
    End Sub
    'Code For Retrive the Institute information By Nitin 04/06/2012
    Protected Function GetInstName(ByVal id As Long) As String
        Dim im As New InstituteManager
        Dim i As Institute = im.GetInstituteByInstituteId(id)
        Return i.Name
    End Function
    'Code For ADD and UPDATE Button By Nitin 04/06/2012
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        txtEmp.Focus()

        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnsave.Text = "ADD" Then
                Try
                    If HidempId.Value = 0 Then
                        lblErrorMsg.Text = "Select Correct Employee Code"
                        Exit Sub
                    End If
                    prop.Empid = HidempId.Value

                    prop.VisitingDate = CDate(txtVisitingDate.Text)

                    prop.Discussion = txtDiscussion.Text

                    If txtFrom.Text <> "" Then
                        prop.Fromtime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(txtFrom.Text), DateFormat.ShortTime))
                    Else
                        prop.Fromtime = CDate("1/1/1900")
                    End If

                    If txtTo.Text <> "" Then
                        prop.Totime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(txtTo.Text), DateFormat.ShortTime))
                    Else
                        prop.Totime = CDate("1/1/1900")
                    End If

                    prop.Contactdetails = txtContact.Text
                    prop.Remarks = txtRemarks.Text

                    If txtVisitingDate.Text = Today.ToString("dd-MMM-yyyy") Then
                        prop.VisitingDate = Today.ToString("dd-MMM-yyyy")
                    Else
                        prop.VisitingDate = txtVisitingDate.Text
                    End If
                    If prop.Totime = "1/1/1900" Then
                        BAL.InsertRecord(prop)
                        HidempId.Value = 0
                        btnsave.Text = "ADD"
                        clearAll()
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Saved Successfully."
                        txtVisitingDate.Text = Format(Today, "dd-MMM-yyyy")
                    ElseIf prop.Fromtime > prop.Totime Then
                        lblErrorMsg.Text = "In time should not be greater than Out time."
                    ElseIf prop.Fromtime < prop.Totime Then
                        BAL.InsertRecord(prop)
                        btnsave.Text = "ADD"
                        clearAll()
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Saved Successfully."
                        txtVisitingDate.Text = Format(Today, "dd-MMM-yyyy")

                    End If
                Catch ex As Exception
                    lblmsginfo.Text = ""
                    lblErrorMsg.Text = "Time is not in correct format."
                    txtFrom.Focus()
                End Try

            ElseIf btnsave.Text = "UPDATE" Then
                Try
                    prop.VId = TxtVID.Text
                    prop.Empid = HidempId.Value
                    prop.VisitingDate = txtVisitingDate.Text

                    prop.Discussion = txtDiscussion.Text

                    If txtFrom.Text <> "" Then
                        prop.Fromtime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(txtFrom.Text), DateFormat.ShortTime))
                    Else
                        prop.Fromtime = CDate("1/1/1900")
                    End If

                    If txtTo.Text <> "" Then
                        prop.Totime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(txtTo.Text), DateFormat.ShortTime))
                    Else
                        prop.Totime = CDate("1/1/1900")
                    End If

                    prop.Contactdetails = txtContact.Text
                    prop.Remarks = txtRemarks.Text

                    If txtVisitingDate.Text = Today.ToString("dd-MMM-yyyy") Then
                        prop.VisitingDate = Today.ToString("dd-MMM-yyyy")
                    Else
                        prop.VisitingDate = txtVisitingDate.Text
                    End If
                    If prop.Totime = "1/1/1900" Then
                        BAL.UpdateRecord(prop)
                        btnsave.Text = "ADD"
                        btndetails.Text = "VIEW"
                        btnprintslip.Enabled = True
                        clearAll()
                        GridView1.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Updated Successfully."
                        txtVisitingDate.Text = Format(Today, "dd-MMM-yyyy")
                    ElseIf prop.Fromtime > prop.Totime Then
                        lblErrorMsg.Text = "In time should not be greater than Out time."
                    ElseIf prop.Fromtime < prop.Totime Then
                        BAL.UpdateRecord(prop)
                        btnsave.Text = "ADD"
                        btndetails.Text = "VIEW"
                        btnprintslip.Enabled = True
                        clearAll()
                        GridView1.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Updated Successfully."
                        txtVisitingDate.Text = Format(Today, "dd-MMM-yyyy")
                    End If




                    'If prop.Totime <> CDate("1/1/1900") Then
                    '    If prop.Fromtime > prop.Totime Then
                    '        lblmsginfo.Text = ""
                    '        lblErrorMsg.Text = "In time should not be greater than Out time."
                    '    Else
                    '        prop.Contactdetails = txtContact.Text
                    '        prop.Remarks = txtRemarks.Text
                    '        BAL.UpdateRecord(prop)
                    '        btnsave.Text = "ADD"
                    '        btndetails.Text = "VIEW"
                    '        btnprintslip.Enabled = True
                    '        clearAll()
                    '        GridView1.PageIndex = ViewState("PageIndex")
                    '        DispGrid()
                    '        lblErrorMsg.Text = ""
                    '        lblmsginfo.Text = "Data Updated Successfully."
                    '    End If
                    'End If
                Catch ex As Exception
                    lblmsginfo.Text = ""
                    lblErrorMsg.Text = "Time is not in correct format."
                    txtFrom.Focus()
                End Try

            End If

        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsginfo.Text = ""
        End If
    End Sub
    'Code For Display Method It will display the Grid By Nitin 04/06/2012
    Sub DispGrid()
        LinkButton1.Focus()
        Dim dt As New DataTable
        'TxtVID.Text = ViewState("BMID")
        prop.VId = 0
        dt = BAL.GetVisiting(prop)
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("Label9"), Label).Text = "12:00:00 AM" Then
                CType(rows.FindControl("Label9"), Label).Text = ""
            End If
        Next
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblmsginfo.Text = ""
            lblErrorMsg.Text = "No records to display."

        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True

        End If
    End Sub
    Sub clearAll()
        txtEmp.Text = ""
        txtName.Text = ""
        'txtVisitingDate.Text = ""
        txtDiscussion.Text = ""
        txtFrom.Text = ""
        txtTo.Text = ""
        txtContact.Text = ""
        txtRemarks.Text = ""
    End Sub
    'Code For View Button To View the data By Nitin 04/06/2012
    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""
        ViewState("VID") = 0
        If btndetails.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
            GridView1.Visible = True
        ElseIf btndetails.Text = "BACK" Then
            btnprintslip.Enabled = True
            btnsave.Text = "ADD"
            btndetails.Text = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
            clearAll()
            GridView1.Visible = True
            txtVisitingDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Visiting Details")
    End Sub

    Sub AlertEnterAllFields()
        alt = "alert('Select all the required fields.');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alt, True)
    End Sub
    'Code For Row Editng By Nitin 04/06/2012
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""
        TxtVID.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("VID"), HiddenField).Value
        ViewState("VID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("VID"), HiddenField).Value
        ViewState("ECD") = CType(GridView1.Rows(e.NewEditIndex).FindControl("ECODE"), HiddenField).Value
        txtEmp.Text = ViewState("ECD")
        HidempId.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("EID"), HiddenField).Value
        txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        txtVisitingDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtDiscussion.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
        txtFrom.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text
        txtTo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text
        txtContact.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
        prop.VId = ViewState("VID")
        btnprintslip.Enabled = False
        btnsave.Text = "UPDATE"
        btndetails.Text = "BACK"

        Dim dt As DataTable
        'prop.VId = TxtVID.Text
        'prop.VId = ViewState("VID")
        prop.VId = TxtVID.Text
        dt = BAL.GetVisiting(prop)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
    End Sub
    'Code for Print Slip Report By Nitin 05/06/2012
    Protected Sub btnprintslip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprintslip.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            Dim count As New Integer
            For Each grid As GridViewRow In GridView1.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("VID"), HiddenField).Value.ToString
                    id = check + "," + id
                    count = count + 1
                Else
                    lblErrorMsg.Text = ""
                    lblmsginfo.Text = ""
                End If
            Next
            Try
                If count > 1 Then
                    lblErrorMsg.Text = "Select one record."
                    lblmsginfo.Text = ""
                Else
                    id = Left(id, id.Length - 1)
                    If txtEmp.Text = "" Then
                        prop.VId = ViewState("BMID")
                        Dim VID As Integer
                        VID = id
                        Dim qrystring As String = "RptVisitingDetailsV.aspx?" & QueryStr.Querystring() & "&VID=" & VID
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    Else
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = ""
                    End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Select one record."
                lblmsginfo.Text = ""
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot print visitor slip."
            lblmsginfo.Text = ""
        End If
    End Sub

    Protected Sub txtEmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmp.TextChanged
        txtVisitingDate.Text = Today.ToString("dd-MMM-yyyy")

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        LinkButton1.Focus()
        Dim dt As New DataTable
        'TxtVID.Text = ViewState("BMID")
        prop.VId = 0
        dt = BAL.GetVisiting(prop)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
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
End Class

