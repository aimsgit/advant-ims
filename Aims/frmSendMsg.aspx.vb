Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports StudentManager
Imports System.Data.SqlClient
Imports FreeTextBoxControls

Partial Class frmSendMsg
    Inherits BasePage
    Dim dt As New DataTable
    Dim bl As New BLSendMsg
    Dim s As String
    Dim FrmDate, ToDate As DateTime

    Sub dispgrid(ByVal s As String)
        s = cmbstatus.SelectedValue
        If txtFromDate.Text = "" Then
            FrmDate = "1/1/1900"
        Else
            FrmDate = txtFromDate.Text
        End If
        If txtToDate.Text = "" Then
            ToDate = "1/1/2999"
        Else
            ToDate = txtToDate.Text
        End If
        If CDate(txtFromDate.Text) > CDate(txtToDate.Text) Then
            lblmsg.Text = ""
            msginfo.Text = "From date cannot be greater than to date."
            Exit Sub
        End If
        lblmsg.Text = ""
        msginfo.Text = "Please wait..."
        dt = bl.Getdata(s, FrmDate, ToDate)
        If dt.Rows.Count > 0 Then
            GVSendMsg.DataSource = dt
            GVSendMsg.DataBind()
            GVSendMsg.Visible = True
            GVSendMsg.Enabled = True
            GVSendMsg.SelectedIndex = -1
            lblmsg.Text = ""
            msginfo.Text = ""
            Btndelete.Visible = True
        Else
            msginfo.Text = "No records to display."
            lblmsg.Text = ""
            GVSendMsg.Visible = "false"
            Btndelete.Visible = False
        End If
    End Sub

    Protected Sub GVSendMsg_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSendMsg.PageIndexChanging
        If GVSendMsg.EditIndex <> -1 Then
            msginfo.Text = "First Cancel Edit."
            lblmsg.Text = ""
        Else
            GVSendMsg.PageIndex = e.NewPageIndex
            dispgrid(s)
        End If
    End Sub
    'sheela 18-08-2012
    Protected Sub GVSendMsg_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GVSendMsg.RowCancelingEdit
        GVSendMsg.EditIndex = -1
        dispgrid(s)
    End Sub
    Protected Sub GVSendMsg_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSendMsg.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If CType(GVSendMsg.Rows(e.RowIndex).FindControl("lblAppStatus"), Label).Text <> "Approved" And CType(GVSendMsg.Rows(e.RowIndex).FindControl("lblAppStatus"), Label).Text <> "Rejected" Then
                Dim ID As Integer
                ID = Convert.ToInt64(GVSendMsg.DataKeys(e.RowIndex).Value)
                bl.Reject(ID)
                dispgrid(s)
                lblmsg.Text = "Message Rejected Successfully."
                msginfo.Text = ""
            Else
                lblmsg.Text = ""
                msginfo.Text = "Message already approved/rejected cannot reject."
            End If
        Else
            msginfo.Text = "You do not belong to this branch, cannot reject data."
            lblmsg.Text = ""
        End If
    End Sub
    'sheela 18-08-2012
    Protected Sub GVSendMsg_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSendMsg.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If CType(GVSendMsg.Rows(e.NewEditIndex).FindControl("lblAppStatus"), Label).Text <> "Approved" And CType(GVSendMsg.Rows(e.NewEditIndex).FindControl("lblAppStatus"), Label).Text <> "Rejected" Then
                Dim ID As Integer
                GVSendMsg.EditIndex = e.NewEditIndex
                ID = CType(GVSendMsg.Rows(e.NewEditIndex).FindControl("hidCMID"), HiddenField).Value
                dispgrid(s)
            Else
                lblmsg.Text = ""
                msginfo.Text = "Message already approved/rejected, cannot edit."
            End If
        Else
            msginfo.Text = "You do not belong to this branch, cannot edit data."
            lblmsg.Text = ""
        End If
    End Sub

    Sub generatemsg(ByVal id As Integer)
        Dim vm As String
        Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
        dt = bl.GetCommunication(id)
        Dim GlobalFunction As New GlobalFunction
        Try
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim prefix As String
                    Dim ToPhone As String
                    Dim Message As String
                    Dim Mode As String
                    Dim SentDate As Date
                    ToPhone = dt.Rows(i).Item("ContactNo").ToString.Replace(",,", ",")
                    If ToPhone.Length > 0 Then


                        ToPhone = ToPhone.Replace(",,", ",")
                        ToPhone = ToPhone.Replace(",,,", ",")
                        ToPhone = ToPhone.Replace(",,,,", ",")
                        If Len(ToPhone) > 0 Then
                            ToPhone = Left(ToPhone, ToPhone.Length - 1)
                        End If

                        prefix = dt.Rows(i).Item("MsgFrom")
                        If ToPhone.Contains("@") And ToPhone.Contains(".") Then
                            Message = dt.Rows(i).Item("Message")
                        Else
                            Message = GlobalFunction.StripHTML(dt.Rows(i).Item("Message")) '.Split(vbCr.ToCharArray())
                        End If
                        If ToPhone.Contains("@") And ToPhone.Contains(".") Then
                            Mode = "Email"
                        Else
                            Mode = "SMS"
                        End If
                        SentDate = dt.Rows(i).Item("Date")
                        Dim str As String = ""
                        Dim connection As New SqlClient.SqlConnection()
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                        connection.Open()
                        Dim cmd As New SqlCommand()
                        vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode,FromEmailID,FromPassword,SMTPHost) values(@ToPhone,@Message,@MsgFrom,@BranchCode,@Mode,@FromEmailID,@FromPassword,@SMTPHost)"

                        cmd.Connection = connection
                        cmd.CommandText = vm
                        parm_phonesp = New SqlParameter
                        parm_phonesp.ParameterName = "@ToPhone"
                        parm_phonesp.Value = ToPhone
                        parm_phonesp.DbType = DbType.String
                        cmd.Parameters.Add(parm_phonesp)

                        parm_msg = New SqlParameter
                        parm_msg.ParameterName = "@Message"
                        parm_msg.Value = Message
                        parm_msg.DbType = DbType.String
                        cmd.Parameters.Add(parm_msg)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@MsgFrom"
                        parm_msgfrm.Value = prefix
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@BranchCode"
                        parm_msgfrm.Value = Session("BranchCode")
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@Mode"
                        parm_msgfrm.Value = Mode
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@FromEmailID"
                        parm_msgfrm.Value = Session("FromEmailID")
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@FromPassword"
                        parm_msgfrm.Value = Session("FromPassword")
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@SMTPHost"
                        parm_msgfrm.Value = Session("SMTPHost")
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub


    'Anchala Verma 27-jul-12
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            cmbstatus.Focus()
            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
            txtFromDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub
    'Anchala Verma 27-jul-12
    Protected Sub Btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btndelete.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim count As Integer
            count = 0
            For Each grid As GridViewRow In GVSendMsg.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then

                    Dim id As Integer
                    id = CType(grid.FindControl("hidCMID"), HiddenField).Value.ToString
                    count = count + 1
                    bl.DeleteRecord(id)
                End If
            Next
            If count > 0 Then
                s = cmbstatus.SelectedValue
                dispgrid(s)
                msginfo.Text = ""
                lblmsg.Text = "Record(s) Deleted successfully."
            Else
                msginfo.Text = "Select atleast one record."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not belong to this branch, cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub
    'Anchala Verma 27-jul-12
    Sub CheckAll()
        If CType(GVSendMsg.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            Btndelete.Focus()
            For Each grid As GridViewRow In GVSendMsg.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVSendMsg.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Sheela 18-08-2012
    Protected Sub GVSendMsg_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVSendMsg.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim Msg As String
            Dim Remarks As String
            Dim ID As Integer
            ID = CType(GVSendMsg.Rows(e.RowIndex).FindControl("hidCMID"), HiddenField).Value
            Msg = CType(GVSendMsg.Rows(e.RowIndex).FindControl("txtMsg"), FreeTextBox).Text
            Remarks = CType(GVSendMsg.Rows(e.RowIndex).FindControl("txtRemarks"), TextBox).Text
            bl.UpdateRecord(ID, Msg, Remarks)
            GVSendMsg.EditIndex = -1
            dispgrid(s)
            lblmsg.Text = "Data Updated Successfully."
            msginfo.Text = ""
        Else
            msginfo.Text = "You do not belong to this branch, cannot update data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub GVSendMsg_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GVSendMsg.SelectedIndexChanging
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If CType(GVSendMsg.Rows(e.NewSelectedIndex).FindControl("lblAppStatus"), Label).Text <> "Approved" And CType(GVSendMsg.Rows(e.NewSelectedIndex).FindControl("lblAppStatus"), Label).Text <> "Rejected" Then
                Dim ID As Integer
                lblmsg.Text = ""
                msginfo.Text = "Approve message may take some time depending on the no. of recipients. Please be patient..."
                ID = CType(GVSendMsg.Rows(e.NewSelectedIndex).FindControl("hidCMID"), HiddenField).Value
                generatemsg(ID)
                bl.Approve(ID)
                dispgrid(s)
                lblmsg.Text = "Message Approved Successfully."
                msginfo.Text = ""
            Else
                lblmsg.Text = ""
                msginfo.Text = "Message already approved/rejected cannot approve."
            End If
        Else
            msginfo.Text = "You do not belong to this branch, cannot approve data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GVSendMsg_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVSendMsg.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim idd As New Integer

        s = cmbstatus.SelectedValue
        If txtFromDate.Text = "" Then
            FrmDate = "1/1/1900"
        Else
            FrmDate = txtFromDate.Text
        End If
        If txtToDate.Text = "" Then
            ToDate = "1/1/2999"
        Else
            ToDate = txtToDate.Text
        End If
        If CDate(txtFromDate.Text) > CDate(txtToDate.Text) Then
            lblmsg.Text = ""
            msginfo.Text = "From date cannot be greater than to date."
            Exit Sub
        End If
        lblmsg.Text = ""
        msginfo.Text = "Please wait..."
        dt = bl.Getdata(s, FrmDate, ToDate)
        If dt.Rows.Count > 0 Then

            GVSendMsg.Visible = True
            GVSendMsg.Enabled = True
            GVSendMsg.SelectedIndex = -1
            'GVSendMsg.SelectedValue = -1
            lblmsg.Text = ""
            msginfo.Text = ""
            Btndelete.Visible = True
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            ViewState("SortExpression") = e.SortExpression
            ViewState("sortingDirection") = sortingDirection
            GVSendMsg.DataSource = sortedView
            GVSendMsg.DataBind()
        End If
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

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try
            dispgrid(cmbstatus.SelectedValue)
            GVPanel.Visible = True
        Catch ex As Exception
            lblmsg.Text = ""
            msginfo.Text = "Enter correct date."
            GVPanel.Visible = False
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
