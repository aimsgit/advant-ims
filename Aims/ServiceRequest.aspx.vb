Imports System.Data.SqlClient
Partial Class ServiceRequest
    Inherits BasePage
    Dim entity As New ServiceRequestE
    Dim bal As New ServiceRequestB
    Dim dt As New Data.DataTable

    Protected Sub btnSendReq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendReq.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            entity.UserName = txtuserName.Text
            entity.RequestDate = txtDate.Text
            entity.Priority = ddlprority.SelectedItem.Text
            entity.DescOfRequest = txtDescription.Text
            entity.Email = txtEmailId.Text
            entity.PhNo = txtPhNo.Text
            entity.ModuleId = ddlModule.SelectedValue
            entity.ServReqId = txtSerReqId.Text
            ServiceRequestB.Insert(entity)
            generatemsg(entity)
            msginfo.Text = ""
            lblmsg.Text = "Request Sent successfully."
            Dim dt1 As DataTable
            dt1 = ServiceRequestD.GetSerReqId()
            If dt1.Rows.Count > 0 Then
                txtSerReqId.Text = dt1.Rows(0).Item("Config_Value")
            Else
                txtSerReqId.Text = ""
            End If
            ddlprority.Focus()
            Gridview1.Visible = True
            clear()
            entity.Priority = "Select"
            DispGrid(entity)
        Else
            msginfo.Text = "You do not belong to this branch, Cannot send request."
            lblmsg.Text = ""
        End If
    End Sub
    Sub generatemsg(ByVal entity As ServiceRequestE)
        Dim vm As String
        Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
        'Session("EmailService") = dt.Rows(0)("EmailService")
        'Session("SMSService")
        'dt = bl.GetCommunication(id)
        Dim dt As DataTable
        'dt = UserDetailsDB.GetErrorLogEmail()
        dt = ServiceRequestD.GetServiceEmailDetails(entity)
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
                Message = dt.Rows(0).Item("Message").ToString
                Dim FromEmailID As String = dt.Rows(0).Item("FromEmailId").ToString
                Dim FromPassword As String = dt.Rows(0).Item("EmailPassword").ToString
                Dim SMTPHost As String = dt.Rows(0).Item("SmtpHost").ToString
                Dim trysmtp As String = Session("SMTPHost")
                'ToPhone = ToPhone.Replace(",,", ",")
                'ToPhone = ToPhone.Replace(",,,", ",")
                'ToPhone = ToPhone.Replace(",,,,", ",")
                'ToPhone = Left(ToPhone, ToPhone.Length - 1)
                prefix = " " + Format(dt.Rows(0).Item("ErrorDate"), "dd-MMM-yyyy") + " " + dt.Rows(0).Item("ServiceRequestId").ToString + " " + dt.Rows(0).Item("EmpName").ToString + " " + dt.Rows(0).Item("email").ToString + " " + dt.Rows(0).Item("PhNo").ToString + " " + "Admission: " + dt.Rows(0).Item("Institute").ToString + " Center: " + dt.Rows(0).Item("BranchName").ToString + " " + dt.Rows(0).Item("Priority").ToString + " Open"
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
            ToPhone = dt.Rows(0).Item("email").ToString
            If ToPhone.Contains("@") Then
                Message = dt.Rows(0).Item("ClientMesg").ToString
                Dim FromEmailID As String = dt.Rows(0).Item("FromEmailId").ToString
                Dim FromPassword As String = dt.Rows(0).Item("EmailPassword").ToString
                Dim SMTPHost As String = dt.Rows(0).Item("SmtpHost").ToString
                'ToPhone = ToPhone.Replace(",,", ",")
                'ToPhone = ToPhone.Replace(",,,", ",")
                'ToPhone = ToPhone.Replace(",,,,", ",")
                'ToPhone = Left(ToPhone, ToPhone.Length - 1)
                prefix = " " + Format(dt.Rows(0).Item("ErrorDate"), "dd-MMM-yyyy") + " " + dt.Rows(0).Item("ServiceRequestId").ToString + " " + dt.Rows(0).Item("EmpName").ToString + " " + dt.Rows(0).Item("email").ToString + " " + dt.Rows(0).Item("PhNo").ToString + " " + "Admission: " + dt.Rows(0).Item("Institute").ToString + " Center: " + dt.Rows(0).Item("BranchName").ToString + " " + dt.Rows(0).Item("Priority").ToString + " Open"
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

        'lblGreen1.Text = "Message Sent Successfully."
        'lblRed1.Text = ""
    End Sub

    Sub DispGrid(ByVal entity As ServiceRequestE)
        dt = ServiceRequestB.GetData(entity)
        If dt.Rows.Count <> 0 Then
            Gridview1.DataSource = dt
            Gridview1.DataBind()
            Gridview1.Visible = True
            clear()
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            Gridview1.Visible = False
        End If
    End Sub
    Sub clear()

        txtDescription.Text = ""

    End Sub
    Protected Sub btnCheckStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckStatus.Click
        LinkButton1.Focus()
        lblmsg.Text = ""
        msginfo.Text = ""
        entity.Priority = ddlprority.SelectedItem.Text
        'If ddlprority.SelectedValue <> "0" Then
        '    If ddlprority.SelectedValue = "1" Then
        '        b = ddlprority.SelectedValue
        '    End If
        '    If ddlprority.SelectedValue = "2" Then
        '        b = ddlprority.SelectedValue
        '    End If
        '    If ddlprority.SelectedValue = "3" Then
        '        b = ddlprority.SelectedValue
        '    End If
        'Else
        '    b = ddlprority.SelectedValue
        'End If
        ViewState("PageIndex") = 0
        Gridview1.PageIndex = 0
        DispGrid(entity)
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        Dim Empcode As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        txtDate.Text = Today.ToString("dd-MMM-yyyy")
        txtuserName.Text = HttpContext.Current.Session("EmpName")
        Empcode = HttpContext.Current.Session("EmpCode")
        dt = ServiceRequestD.GetEmpData(Empcode)
        txtEmailId.Text = dt.Rows(0).Item("Email")
        txtPhNo.Text = dt.Rows(0).Item("ContactNo")
        If Not IsPostBack Then
            Dim dt1 As DataTable
            dt1 = ServiceRequestD.GetSerReqId()
            If dt1.Rows.Count > 0 Then
                txtSerReqId.Text = dt1.Rows(0).Item("Config_Value")
            Else
                txtSerReqId.Text = ""
            End If
        End If

        txtEmailId.Enabled = True
        txtPhNo.Enabled = True
        txtDate.Enabled = False
        txtuserName.Enabled = False
        ddlprority.Focus()
    End Sub

    Protected Sub Gridview1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gridview1.PageIndexChanging
        Gridview1.Enabled = True
        Gridview1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = Gridview1.PageIndex
        entity.Priority = "Select"
        DispGrid(entity)
    End Sub
    Protected Sub Gridview1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Gridview1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("ID") = CType(Gridview1.Rows(e.RowIndex).FindControl("Label0"), Label).Text
            ServiceRequestB.Delete(ViewState("ID"))
            entity.Priority = "Select"
            Gridview1.PageIndex = ViewState("PageIndex")
            DispGrid(entity)
            msginfo.Text = ""
            lblmsg.Text = "Data deleted successfully."
            ddlprority.Focus()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlprority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlprority.Load
        ddlprority.Focus()
    End Sub
End Class
