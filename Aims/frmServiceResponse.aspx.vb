Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data
'Aurhor-->Ajit kumar singh.
'Date-->15-May-2012
Partial Class frmServiceResponse
    Inherits BasePage
    Dim en As New ServiceResponseE
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        End If
        txtResponsedate.Text = Today.ToString("dd-MMM-yyyy")
        'txtResponsedate.Enabled = False
        btnUpdate.Enabled = False
        txtBranchname.Enabled = False
        txtInstitute.Enabled = False
        txtReqID.Enabled = False
        txtrequest.Enabled = False
        txtUsername.Enabled = False
    End Sub

    Protected Sub Gridview1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gridview1.PageIndexChanging
        Gridview1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = Gridview1.PageIndex
        en.Status = "Select"
        en.Priority = "Select"
        DispGrid(en)

    End Sub

    Protected Sub Gridview1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Gridview1.RowEditing
        Dim status, priority As String
        btnUpdate.Enabled = True
        msginfo.Text = ""
        lblmsg.Text = ""
        status = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text
        priority = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
        If status = "Open" Then
            ddlStatus.SelectedValue = 1
        Else
            ddlStatus.SelectedValue = 2
        End If
        If priority = "High" Then
            ddlpriority.SelectedValue = 1
        ElseIf priority = "Medium" Then
            ddlpriority.SelectedValue = 2
        Else
            ddlpriority.SelectedValue = 3
        End If
        txtReqID.Text = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtUsername.Text = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        txtInstitute.Text = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        txtBranchname.Text = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
        txtrequest.Text = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label10"), Label).Text
        txtResponse.Text = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label11"), Label).Text
        ViewState("ID") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label0"), Label).Text

        ViewState("requestdateEamil") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        ViewState("EmailserviceRequestNo") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        ViewState("EmailName") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        ViewState("DescOfRequest") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("lblMessage"), Label).Text
        ViewState("EmailPhone") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("lblPhNo"), Label).Text
        ViewState("EmailInstitute") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        ViewState("EmailBranchName") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
        ViewState("Emailpriority") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
        ViewState("Emailstatus") = CType(Gridview1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text
        btnUpdate.Enabled = True
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        en.Id = ViewState("ID")
        'en.ReqID = txtReqID.Text
        'en.UserName = txtUsername.Text
        'en.Institute = txtInstitute.Text
        'en.BranchName = txtBranchname.Text
        en.Status = ddlStatus.SelectedItem.Text
        en.ResponseDate = txtResponsedate.Text
        en.Priority = ddlpriority.SelectedItem.Text
        en.requestdateEamil = ViewState("requestdateEamil")
        en.EmailserviceRequestNo = ViewState("EmailserviceRequestNo")
        en.EmailName = ViewState("EmailName")
        en.DescOfRequest = ViewState("DescOfRequest")

        en.EmailPhone = ViewState("EmailPhone")
        en.EmailInstitute = ViewState("EmailInstitute")
        en.EmailBranchName = ViewState("EmailBranchName")
        en.EmailPriority = ViewState("Emailpriority")
        en.Emailstatus = en.Status

        en.DescOfResponse = txtResponse.Text
        ServiceResponseB.Update(en)
        generatemsg(en)
        msginfo.Text = ""
        lblmsg.Text = "Data Updated Sucessfully."

        clear()
        Gridview1.PageIndex = ViewState("PageIndex")
        en.Status = "Select"
        en.Priority = "Select"
        DispGrid(en)
    End Sub
    Public Sub generatemsg(ByVal en As ServiceResponseE)
        Dim vm As String
        Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
        'Session("EmailService") = dt.Rows(0)("EmailService")
        'Session("SMSService")
        'dt = bl.GetCommunication(id)
        Dim dt As DataTable
        'dt = UserDetailsDB.GetErrorLogEmail()
        dt = ServiceResponseD.GetServiceRepondEmailDetails(en)
        Dim GlobalFunction As New GlobalFunction
        Try
            'If dt.Rows.Count > 0 Then
            'For i As Integer = 0 To dt.Rows.Count
            Dim prefix As String = ""
            Dim ToPhone As String
            Dim Message As String
            Dim Mode As String
            Dim SentDate As DateTime

            ToPhone = dt.Rows(0).Item("ContactNo").ToString
            If ToPhone.Contains("@") Then
                Message = dt.Rows(0).Item("ClientMesg").ToString + " " + en.DescOfResponse
                Dim FromEmailID As String = dt.Rows(0).Item("FromEmailId").ToString
                Dim FromPassword As String = dt.Rows(0).Item("EmailPassword").ToString
                Dim SMTPHost As String = dt.Rows(0).Item("SmtpHost").ToString
                Dim trysmtp As String = Session("SMTPHost")
                'ToPhone = ToPhone.Replace(",,", ",")
                'ToPhone = ToPhone.Replace(",,,", ",")
                'ToPhone = ToPhone.Replace(",,,,", ",")
                'ToPhone = Left(ToPhone, ToPhone.Length - 1)
                prefix = " " + Format(en.requestdateEamil, "dd-MMM-yyyy") + " " + en.EmailserviceRequestNo + " " + en.EmailName + " " + en.Email_id + " " + en.EmailPhone + " " + "Admission: " + en.EmailInstitute + " Center: " + en.EmailBranchName + " " + en.EmailPriority + " " + en.Emailstatus
                'If ToPhone.Contains("@") And ToPhone.Contains(".") Then
                '    Message = dt.Rows(i).Item("Message")
                'Else
                '    Message = GlobalFunction.StripHTML(dt.Rows(i).Item("Message")) '.Split(vbCr.ToCharArray())
                'End If
                If ToPhone.Contains("@") And ToPhone.Contains(".") Then
                    Mode = "Email"
                Else
                    Mode = "SMS"
                End If
                'SentDate = dt.Rows(i).Item("Date")
                SentDate = Format("dd-MMM-yyyy", Today)
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
                parm_msgfrm.Value = FromEmailID
                parm_msgfrm.DbType = DbType.String
                cmd.Parameters.Add(parm_msgfrm)

                parm_msgfrm = New SqlParameter
                parm_msgfrm.ParameterName = "@FromPassword"
                parm_msgfrm.Value = FromPassword
                parm_msgfrm.DbType = DbType.String
                cmd.Parameters.Add(parm_msgfrm)

                parm_msgfrm = New SqlParameter
                parm_msgfrm.ParameterName = "@SMTPHost"
                parm_msgfrm.Value = SMTPHost
                parm_msgfrm.DbType = DbType.String
                cmd.Parameters.Add(parm_msgfrm)
                cmd.ExecuteNonQuery()
                'Next
                '  End If
            End If
            

        Catch ex As Exception

        End Try
    End Sub
    Sub DispGrid(ByVal en As ServiceResponseE)
        Dim dt As New Data.DataTable
        dt = ServiceResponseB.GetData(en)
        If dt.Rows.Count <> 0 Then
            Gridview1.DataSource = dt
            Gridview1.DataBind()
            Gridview1.Visible = True
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            Gridview1.Visible = False
        End If
    End Sub
    Sub clear()
        txtReqID.Text = ""
        txtBranchname.Text = ""
        txtInstitute.Text = ""
        txtrequest.Text = ""
        txtResponse.Text = ""
        txtUsername.Text = ""
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        btnUpdate.Enabled = False
        lblmsg.Text = ""
        msginfo.Text = ""
        en.Priority = ddlpriority.SelectedItem.Text
        en.Status = ddlStatus.SelectedItem.Text
        ViewState("PageIndex") = 0
        Gridview1.PageIndex = 0
        DispGrid(en)
        clear()

    End Sub
End Class
