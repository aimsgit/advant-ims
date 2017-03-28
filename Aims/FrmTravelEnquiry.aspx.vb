
Imports System.Web.UI.WebControls
Partial Class FrmTravelEnquiry
    Inherits BasePage
    Dim el As New ELTravelEnquiry

    Dim bl As New BLTravelEnquiry
    Dim dt As New DataTable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Rbtriptype.Focus()

            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblmsg.Text = ""
                msginfo.Text = ""
                el.Triptype = Rbtriptype.Text
                el.Enquiry_Date = txtenqdate.Text
                el.Enquiry_No = txtenqno.Text
                el.Referral = txtref.Text
                el.Passenger_Name = txtnamepass.Text
                el.Leavingfrom = txtleave.Text
                If txtdeptdate.Text = "" Then
                    el.Departure_Date = "1/1/3000"
                Else
                    el.Departure_Date = txtdeptdate.Text
                End If

                el.Goingto = txtgoingto.Text
                If CType(txtenqdate.Text, Date) > CType(txtdeptdate.Text, Date) Then
                    msginfo.Text = ""
                    msginfo.Text = "'Enquiry' date should be lesser than 'Departure' date."
                    txtdeptdate.Focus()
                    Exit Sub
                End If
                If txtreturn.Text = "" Then
                    el.Return_Date = "1/1/3000"
                Else
                    el.Return_Date = txtreturn.Text
                    If CType(txtdeptdate.Text, Date) > CType(txtreturn.Text, Date) Then
                        msginfo.Text = ""
                        msginfo.Text = "'Departure' date should be lesser than 'Return' date."
                        txtreturn.Focus()
                        Exit Sub
                    End If
                End If
                If Rbtriptype.Text = "One Way" Then
                    If txtreturn.Text = "" Then
                        el.Return_Date = "1/1/3000"
                    Else
                        el.Return_Date = txtreturn.Text

                    End If
                ElseIf Rbtriptype.Text = "Two Way" Then
                    If txtreturn.Text = "" Then
                        msginfo.Text = "Return date is mandatory."
                        Exit Sub
                    Else
                        el.Return_Date = txtreturn.Text
                    End If
                ElseIf Rbtriptype.Text = "Multicity" Then
                    If txtreturn.Text = "" Then
                        msginfo.Text = "Return date is mandatory."
                        Exit Sub
                    Else
                        el.Return_Date = txtreturn.Text
                    End If
                End If
                If ddladlts.SelectedValue = 0 Then
                    el.No_Of_Adults = 0
                Else
                    el.No_Of_Adults = ddladlts.SelectedValue
                End If
                If ddlchldrn.SelectedValue = 0 Then
                    el.No_Of_Children = 0
                Else
                    el.No_Of_Children = ddlchldrn.SelectedValue
                End If
                If ddlinfants.SelectedValue = 0 Then
                    el.No_Of_Infants = 0
                Else
                    el.No_Of_Infants = ddlinfants.SelectedValue
                End If
                el.Purpose = txtvisit.Text
                el.Accomodation_Type = txtacco.Text
                el.Contact_Number = txtcontno.Text
                el.Address = txtadrs.Text
                If ddlclass.SelectedValue = 0 Then
                    el.Travelclass = 0
                Else
                    el.Travelclass = ddlclass.SelectedValue
                End If
                el.Email = txtemail.Text
                el.Remarks = txtrmrks.Text

                If Chkquote.Checked = True Then
                    el.Quote = "Y"
                Else
                    el.Quote = "N"

                End If
                If Chkflwup.Checked = True Then
                    el.Follow_Up = "Y"
                Else
                    el.Follow_Up = "N"
                End If
                If Chkclosed.Checked = True Then
                    el.Closed = "Y"
                Else
                    el.Closed = "N"
                End If
                If btnadd.Text = "UPDATE" Then
                    btnprint.Enabled = True
                    el.Id = ViewState("TE_Id")
                    dt = bl.CheckDuplicate(el)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        bl.UpdateTravelEnquiry(el)
                        msginfo.Text = ""
                        btnadd.Text = "ADD"
                        btnview.Text = "VIEW"
                        lblmsg.Text = "Data Updated Successfully."
                        GridView1.PageIndex = ViewState("PageIndex")
                        DisplayGrid()
                        Clear()

                    End If
                ElseIf btnadd.Text = "ADD" Then
                    dt = bl.CheckDuplicate(el)
                    btnprint.Enabled = True
                    If dt.Rows.Count > 0 Then
                        msginfo.Visible = True
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        el.Id = 0
                        bl.AddTravelEnquiry(el)
                        msginfo.Text = ""
                        btnadd.Text = "ADD"
                        lblmsg.Text = "Data Saved successfully."
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DisplayGrid()
                        Clear()
                    End If
                Else

                    msginfo.Text = "You do not belong to this branch, Cannot add data."
                    lblmsg.Text = ""
                End If
            End If
        Catch ex As Exception
            msginfo.Text = "Date is not valid."
        End Try

    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        btnprint.Enabled = False
        Try

       
            If (Session("BranchCode") = Session("ParentBranch")) Then
                txtenqdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblenqdate"), Label).Text
                txtenqno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblenqno"), Label).Text
                txtnamepass.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblnamepass"), Label).Text
                txtref.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblref"), Label).Text
                txtleave.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblleave"), Label).Text
                txtdeptdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbldeptdate"), Label).Text
                txtgoingto.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblgoing"), Label).Text
                txtreturn.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblreturn"), Label).Text
                txtcontno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblcontactno"), Label).Text
                txtemail.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblemail"), Label).Text
                txtacco.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblacco"), Label).Text
                txtvisit.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblvisit"), Label).Text
                txtrmrks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblrmrks"), Label).Text
                txtadrs.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbladrs"), Label).Text
                ddladlts.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbladlts"), Label).Text
                ddlchldrn.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblchldrn"), Label).Text
                ddlinfants.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblinfants"), Label).Text

                ddlclass.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblclass"), Label).Text
                el.Closed = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblclosed"), Label).Text
                If el.Closed = "Y" Then
                    Chkclosed.Checked = True
                Else
                    Chkclosed.Checked = False
                End If
                el.Follow_Up = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblfollowup"), Label).Text
                If el.Follow_Up = "Y" Then
                    Chkflwup.Checked = True
                Else
                    Chkflwup.Checked = False
                End If
                el.Quote = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblquote"), Label).Text
                If el.Quote = "Y" Then
                    Chkquote.Checked = True
                Else
                    Chkquote.Checked = False
                End If

                ViewState("TE_Id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
                btnadd.Text = "UPDATE"
                btnview.Text = "BACK"
                If txtenqdate.Text = "" Then
                    el.Enquiry_Date = "1/1/3000"
                Else
                    el.Enquiry_Date = txtenqdate.Text
                End If

                el.Enquiry_No = txtenqno.Text
                el.Passenger_Name = txtnamepass.Text
                el.Leavingfrom = txtleave.Text

                el.Goingto = txtgoingto.Text

                el.Contact_Number = txtcontno.Text
                el.Email = txtemail.Text

                el.Id = ViewState("TE_Id")
                dt = bl.ViewTravelEnquiry(el)
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Enabled = False
            Else
                msginfo.Text = "You do not belong to this branch, Cannot edit data."
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Date is not valid."
        End Try
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim el As New ELTravelEnquiry
            el.Id = CType(GridView1.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            bl.DeleteTravelEnquiry(el)
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            Rbtriptype.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            If txtenqdate.Text = "" Then
                el.Enquiry_Date = "1/1/3000"
            Else
                el.Enquiry_Date = txtenqdate.Text
            End If

            el.Enquiry_No = txtenqno.Text
            el.Passenger_Name = txtnamepass.Text

            el.Leavingfrom = txtleave.Text

            el.Goingto = txtgoingto.Text
            el.Contact_Number = txtcontno.Text
            el.Email = txtemail.Text
            el.Id = 0
            dt = bl.ViewTravelEnquiry(el)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True

        Else
        msginfo.Text = "You do not belong to this branch, Cannot delete data."
        lblmsg.Text = ""
        End If
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        LinkButton1.Focus()
        If btnview.Text = "VIEW" Then
            GridView1.Enabled = True
            lblmsg.Text = " "
            msginfo.Text = " "
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGrid()

        ElseIf btnview.Text = "BACK" Then
            GridView1.Enabled = True
            btnprint.Enabled = True
            lblmsg.Text = " "
            msginfo.Text = " "
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            Clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub
    Protected Sub Grddept_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
    End Sub
    Sub DisplayGrid()
        Try

        
            Dim dt As New DataTable

            If txtenqdate.Text = "" Then
                el.Enquiry_Date = "1/1/3000"
            Else
                el.Enquiry_Date = txtenqdate.Text
            End If

            el.Enquiry_No = txtenqno.Text
            el.Passenger_Name = txtnamepass.Text

            el.Leavingfrom = txtleave.Text

            el.Goingto = txtgoingto.Text
            el.Contact_Number = txtcontno.Text
            el.Email = txtemail.Text

            el.Id = 0
            dt = bl.ViewTravelEnquiry(el)

            If dt.Rows.Count < 0 Then
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                msginfo.Text = "No records to display."
                lblmsg.Text = ""
            Else
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Enabled = True
            End If
            If dt.Rows.Count = 0 Then
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                lblmsg.Text = ""
                msginfo.Text = "No records to display."
            Else
                msginfo.Visible = True
                GridView1.Visible = True
                GridView1.DataSource = dt
                GridView1.DataBind()
            End If
        Catch ex As Exception
            msginfo.Text = "Date is not valid."
        End Try
    End Sub
    '<System.Web.Services.WebMethod()> Public Sub AbandonSession()

    'End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("BranchCode") = "EDIT" Then

                btnadd.Text = "UPDATE"
                btnview.Text = "BACK"
            Else
                txtenqdate.Text = Format(Today, "dd-MMM-yyyy")

            End If
        End If
    End Sub
    Sub Clear()
        Rbtriptype.Text = ""
        txtenqdate.Text = ""
        txtenqno.Text = ""
        txtnamepass.Text = ""
        txtref.Text = ""
        ddladlts.SelectedValue = ""
        ddlclass.SelectedValue = ""
        ddlchldrn.SelectedValue = ""
        ddlinfants.SelectedValue = ""
        txtadrs.Text = ""
        txtacco.Text = ""
        txtrmrks.Text = ""
        ddlclass.SelectedValue = ""
        txtleave.Text = ""
        txtgoingto.Text = ""
        txtreturn.Text = ""
        txtdeptdate.Text = ""
        txtemail.Text = ""
        txtcontno.Text = ""
        txtvisit.Text = ""
        Chkclosed.Checked = False
        Chkquote.Checked = False
        Chkflwup.Checked = False
    End Sub
    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click

        Dim id As String = ""
        Dim check As String = ""
        Dim id1 As String = ""
        Dim count As New Integer
        For Each grid As GridViewRow In GridView1.Rows
            If CType(grid.FindControl("Chkeach"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("HID"), HiddenField).Value.ToString
                id = check + "," + id
                count = count + 1
            Else
                msginfo.Text = ""
                lblmsg.Text = ""
            End If
        Next
        Try
            id = Left(id, id.Length - 1)
            If txtenqno.Text = "" Then
                ' ELTravelEnquiry.Ref_ID_Auto = ViewState("Ref_ID_Auto")
                Dim Ref_ID As Integer
                Ref_ID = id
                Dim qrystring As String = "RptTravelEnquiry.aspx?" & QueryStr.Querystring() & "&Ref_ID=" & Ref_ID
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Else
                msginfo.Text = ""
                lblmsg.Text = ""
            End If
        Catch ex As ArgumentException
            msginfo.Text = "Select one record."
            lblmsg.Text = ""
        End Try

    End Sub

   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtenqdate.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class

