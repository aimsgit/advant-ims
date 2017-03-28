
Partial Class frmParentManagement
    Inherits BasePage
    Dim el As New ELParentMngt
    Dim bl As New BLParentMngt
    Dim dt As New DataTable
    Sub SplitName(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtstd.Text = parts(0).ToString()
            txtstdName.Text = parts(1).ToString()
            HidstdId.Value = parts(2).ToString()
            HidBatch.Value = parts(3).ToString()
            txtbatch.Text = parts(4).ToString()
            'ViewState("StdID") = StdID
        Else
            txtstd.AutoPostBack = True
        End If
    End Sub
    Protected Sub Btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsearch.Click
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        If txtsrchuser.Text <> "" Or txtsrchstd.Text <> "" Then
            el.Id = 0
            el.StdCode = txtsrchstd.Text
            el.srchuser = txtsrchuser.Text
            dt = bl.SearchParent(el)
            If dt.Rows.Count > 0 Then
                GVParentMngmnt.DataSource = dt
                GVParentMngmnt.DataBind()
                GVParentMngmnt.Visible = True
                ClearAll()
            Else
                lblErrorMsg.Text = "No search result found."
                lblmsg.Text = ""
                GVParentMngmnt.Visible = False
            End If
        Else
            lblErrorMsg.Text = "Please enter the search criteria."
            lblmsg.Text = ""
        End If
    End Sub
    Sub ClearAll()
        txtbatch.Text = ""
        txtstd.Text = ""
        txtstdName.Text = ""
        txtsrchstd.Text = ""
        txtpassword.Attributes.Clear()
        txtverpass.Attributes.Clear()
        txtsrchuser.Text = ""
        txtuserid.Text = ""
        txtverpass.Text = ""
        Chkprint.Checked = False
        Chkread.Checked = False
        Chkwrite.Checked = False
        txtExpDate.Text = ""
    End Sub
    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        LinkButton1.Focus()
        If BtnView.Text = "BACK" Then
            txtuserid.Enabled = True
            txtpassword.Enabled = True
            txtverpass.Enabled = True
            btnAddGrid.Text = "ADD"
            BtnView.Text = "VIEW"
            ClearAll()
            DispGrid()
            txtbatch.Enabled = False
            txtstd.Enabled = True
            lblmsg.Text = ""
            lblErrorMsg.Text = ""
        Else
            DispGrid()
        End If
    End Sub
    Sub DispGrid()
        GVParentMngmnt.Visible = True
        GVParentMngmnt.Enabled = True
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
        Dim dt1 As New DataTable
        el.Id = 0
        dt1 = bl.GetParentDetails(el)
        If dt1.Rows.Count > 0 Then
            GVParentMngmnt.DataSource = dt1
            GVParentMngmnt.DataBind()
            'Dim s As String = ""
            For Each row As GridViewRow In GVParentMngmnt.Rows

                If CType(row.FindControl("lblExpDate"), Label).Text = "01-Jan-2999" Then
                    CType(row.FindControl("lblExpDate"), Label).Text = ""
                End If
            Next
            GVParentMngmnt.Enabled = True
        Else
            lblErrorMsg.Text = "No records to display."
        End If
    End Sub
    Protected Sub btnAddGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddGrid.Click
        Try
            txtsrchstd.Focus()
            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblErrorMsg.Text = ""
                If btnAddGrid.Text = "ADD" Then
                    el.LoginType = ddlLoginType.SelectedValue
                    el.StdCode = txtstd.Text
                    el.Username = txtPrefix.Text.Trim() + txtuserid.Text.Trim()
                    dt = bl.GetDuplicateUser(el)
                    If dt.Rows(0).Item("UIDCount").ToString() > 1 Then
                        lblErrorMsg.Text = "Username already exists."
                        txtuserid.Focus()
                        lblmsg.Text = ""
                    ElseIf dt.Rows(0).Item("STDCodeCount").ToString() >= 1 Then
                        lblErrorMsg.Text = "Username already created for the particular Student."
                        txtuserid.Focus()
                        lblmsg.Text = ""
                    Else
                        If txtpassword.Text = txtuserid.Text Then
                            lblErrorMsg.Text = "Username and Password cannnot be same."
                            txtuserid.Focus()
                            lblmsg.Text = ""
                        Else
                            If txtpassword.Text <> "" Then
                                If (txtpassword.Text.Contains(" ") Or txtverpass.Text.Contains(" ")) Then
                                    lblErrorMsg.Text = "Password or Verify password cannot have Space."
                                    txtpassword.Focus()
                                    lblmsg.Text = ""
                                Else
                                    If txtpassword.Text = txtverpass.Text Then
                                        If txtstd.Text = "" Then
                                            lblErrorMsg.Text = "Student Code Field is mandatory."
                                            txtstd.Focus()
                                            lblmsg.Text = ""
                                        Else
                                            Dim s As String
                                            s = ""
                                            Dim q As New ListItem
                                            s = ""
                                            If Chkread.Checked = True Then
                                                s = "R"
                                            End If
                                            If Chkwrite.Checked = True Then
                                                If s <> "" Then
                                                    s = s + "," + "W"
                                                Else
                                                    s = "W"
                                                End If
                                            End If
                                            If Chkprint.Checked = True Then
                                                If s <> "" Then
                                                    s = s + "," + "P"
                                                Else
                                                    s = "P"
                                                End If
                                            End If

                                            Session("BatchName") = txtbatch.Text.ToString()
                                            Session("Empnum") = txtstd.Text.ToString()
                                            el.Username = txtPrefix.Text + txtuserid.Text
                                            el.Password = RijndaelSimple.Encrypt(txtpassword.Text.ToString(), _
                                                               RijndaelSimple.passPhrase, _
                                                               RijndaelSimple.saltValue, _
                                                               RijndaelSimple.hashAlgorithm, _
                                                               RijndaelSimple.passwordIterations, _
                                                               RijndaelSimple.initVector, _
                                                               RijndaelSimple.keySize)
                                            el.Privilages = s
                                            Dim defaultdate, edate As Date
                                            defaultdate = "1-1-2999"
                                            If txtExpDate.Text = "" Then
                                                el.ExpDate = defaultdate
                                                edate = defaultdate
                                            Else
                                                el.ExpDate = txtExpDate.Text
                                                edate = txtExpDate.Text
                                            End If
                                            If edate < Date.Today Then
                                                lblErrorMsg.Text = "Expiry date cannot be past date."
                                                txtExpDate.Focus()
                                                lblmsg.Text = ""
                                            ElseIf Chkread.Checked = False And Chkwrite.Checked = False And Chkprint.Checked = False Then
                                                lblErrorMsg.Text = "Please select the privileges."
                                                Chkread.Focus()
                                                lblmsg.Text = ""
                                            Else
                                                el.LoginType = ddlLoginType.SelectedValue
                                                el.StdCode = txtstd.Text
                                                el.BatchID = HidBatch.Value
                                                Dim j As Integer = bl.InsertRecord(el)
                                                If j = 1 Then
                                                    ClearAll()
                                                    DispGrid()
                                                    lblmsg.Text = "Data saved successfully."
                                                    lblErrorMsg.Text = ""
                                                Else
                                                    lblErrorMsg.Text = "LogIn details for selected Student and user name already exist."
                                                    txtuserid.Focus()
                                                    lblmsg.Text = ""
                                                End If
                                            End If
                                        End If

                                    Else
                                        lblErrorMsg.Text = "Password and Verify passwords are not matching."
                                        txtpassword.Focus()
                                        lblmsg.Text = ""
                                    End If
                                End If

                            Else
                                lblErrorMsg.Text = "Password and Verify passwords cannot be blank."
                                txtpassword.Focus()
                                lblmsg.Text = ""
                            End If
                        End If

                    End If
                Else
                    If txtpassword.Text <> "" And txtverpass.Text <> "" Then
                        If txtpassword.Text = txtverpass.Text Then
                            Session("BatchName") = txtbatch.Text.ToString()
                            Session("Empnum") = txtstd.Text.ToString()
                            el.Username = txtPrefix.Text + txtuserid.Text
                            el.Password = RijndaelSimple.Encrypt(txtpassword.Text.ToString(), _
                                               RijndaelSimple.passPhrase, _
                                               RijndaelSimple.saltValue, _
                                               RijndaelSimple.hashAlgorithm, _
                                               RijndaelSimple.passwordIterations, _
                                               RijndaelSimple.initVector, _
                                               RijndaelSimple.keySize)

                            Dim defaultdate, edate As Date
                            defaultdate = "1-1-2999"
                            If txtExpDate.Text = "" Then
                                el.ExpDate = defaultdate
                                edate = defaultdate
                            Else
                                el.ExpDate = txtExpDate.Text
                                edate = txtExpDate.Text
                            End If
                            el.Id = CType(Session("UMID"), Int32)
                            Dim s As String = ""
                            If Chkread.Checked = True Then
                                s = "R"
                            End If
                            If Chkwrite.Checked = True Then
                                If s <> "" Then
                                    s = s + "," + "W"
                                Else
                                    s = "W"
                                End If
                            End If
                            If Chkprint.Checked = True Then
                                If s <> "" Then
                                    s = s + "," + "P"
                                Else
                                    s = "P"
                                End If
                            End If

                            el.Privilages = s
                            s = ""

                            If edate < Date.Today Then
                                lblErrorMsg.Text = "Expiry date cannot be past date."
                                txtExpDate.Focus()
                                lblmsg.Text = ""
                            ElseIf Chkread.Checked = False And Chkwrite.Checked = False And Chkprint.Checked = False Then
                                lblErrorMsg.Text = "Please select the privileges."
                                Chkread.Focus()
                                lblmsg.Text = ""
                            Else
                                el.StdCode = txtstd.Text
                                el.Id = HidstdId.Value
                                el.LoginType = ddlLoginType.SelectedValue
                                Dim j As Integer = bl.UpdateRecord(el)
                                If j <> 0 Then
                                    el.Id = 0
                                    DispGrid()
                                    ClearAll()
                                    btnAddGrid.Text = "ADD"
                                    BtnView.Text = "VIEW"
                                    lblmsg.Text = "Data updated successfully."
                                    lblErrorMsg.Text = ""
                                    txtstd.Enabled = True
                                    txtuserid.Enabled = True
                                    txtpassword.Enabled = True
                                    txtverpass.Enabled = True
                                Else
                                    DispGrid()
                                    ClearAll()
                                    lblErrorMsg.Text = "Data cannot be updated."
                                    lblmsg.Text = ""
                                End If

                            End If
                        Else
                            lblErrorMsg.Text = "Password and Verify passwords are not matching."
                            txtpassword.Focus()
                            lblmsg.Text = ""
                        End If
                    Else
                        lblErrorMsg.Text = "Password and Verify passwords cannot be blank."
                        txtpassword.Focus()
                        lblmsg.Text = ""
                    End If
                End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct date."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub GVParentMngmnt_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVParentMngmnt.PageIndexChanging
        lblErrorMsg.Text = ""
        GVParentMngmnt.PageIndex = e.NewPageIndex
        DispGrid()
    End Sub

    Protected Sub GVParentMngmnt_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVParentMngmnt.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState(ID) = CType(GVParentMngmnt.Rows(e.RowIndex).Cells(1).FindControl("HidUDID"), Label).Text
            el.Id = ViewState(ID)
            bl.DeleteRecord(el)
            el.Id = 0
            DispGrid()
            lblmsg.Text = "Data deleted successfully."
            txtsrchstd.Focus()
            lblErrorMsg.Text = ""
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtsrchstd.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Try
            txtPrefix.Text = Session("UserPrefix").ToString
            txtbatch.Enabled = False
            If IsPostBack Then
                If Not String.IsNullOrEmpty(txtpassword.Text.Trim()) Then
                    txtpassword.Attributes.Add("value", txtpassword.Text)
                End If
                If Not String.IsNullOrEmpty(txtverpass.Text.Trim()) Then
                    txtverpass.Attributes.Add("value", txtverpass.Text)
                End If
            End If
            If txtstd.Text <> "" Then
                SplitName(txtstd.Text)
            Else
                txtstd.AutoPostBack = True
                txtstdName.Text = ""
                SplitName(txtstd.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GVParentMngmnt_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVParentMngmnt.RowEditing
        Dim dt1 As New DataTable
        lblErrorMsg.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ""
        HidstdId.Value = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("HidUDID"), Label).Text
        el.Id = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("HidUDID"), Label).Text
        Try
            txtuserid.Text = Right(CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblusrName"), Label).Text, CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblusrName"), Label).Text.Length - txtPrefix.Text.Trim.Length)
        Catch ex As Exception
            Dim s As String = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblusrName"), Label).Text.ToString
            txtuserid.Text = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblusrName"), Label).Text
        End Try
        txtuserid.Enabled = False
        txtpassword.Text = RijndaelSimple.Decrypt(CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblPassword"), Label).Text, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)
        txtpassword.Attributes.Add("value", txtpassword.Text)
        txtpassword.Enabled = False
        txtverpass.Text = RijndaelSimple.Decrypt(CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblPassword"), Label).Text, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)
        txtverpass.Attributes.Add("value", txtverpass.Text)
        txtverpass.Enabled = False
        Dim type As String = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("Label5"), Label).Text
        ddlLoginType.SelectedValue = type
        txtstd.Text = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblstdNo"), Label).Text
        txtstdName.Text = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblstdName"), Label).Text
        txtbatch.Text = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblBatchName"), Label).Text
        txtExpDate.Text = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblExpDate"), Label).Text
        Dim Privilage As String = CType(GVParentMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblPrivilages"), Label).Text

        Dim PrivilageArray As Array = Privilage.Split(",")
        Privilage = ""
        For Each Privilage In PrivilageArray
            If Privilage = "R" Then
                Chkread.Checked = True
            End If
            If Privilage = "P" Then
                Chkprint.Checked = True
            End If
            If Privilage = "W" Then
                Chkwrite.Checked = True
            End If
        Next
        txtbatch.Enabled = False
        txtstd.Enabled = False
        txtuserid.Enabled = False
        BtnView.Text = "BACK"
        btnAddGrid.Text = "UPDATE"
        dt1 = bl.GetParentDetails(el)
        GVParentMngmnt.DataSource = dt1
        GVParentMngmnt.DataBind()
        GVParentMngmnt.Visible = True
        GVParentMngmnt.Enabled = False
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVParentMngmnt_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVParentMngmnt.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        GVParentMngmnt.Visible = True
        GVParentMngmnt.Enabled = True
        Dim dt1 As New DataTable
        el.Id = 0
        dt1 = bl.GetParentDetails(el)
        Dim sortedView As New DataView(dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVParentMngmnt.DataSource = sortedView
        GVParentMngmnt.DataBind()
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
