Imports System.Data.SqlClient
Partial Class frmSendUserCredentials
    Inherits BasePage

    Dim dt As DataTable
    Dim bl As New BLCommunication
    Dim el As New ELCommunication

    Protected Sub ddlGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        Try
            'lblError.Text = ""
            'lblcorrect.Text = ""
            display()
        Catch ex As Exception

        End Try
    End Sub
    Sub display()
        dt = bl.GetNameCombo(ddlGroup.SelectedValue, "", "")
        GVName.DataSource = dt
        GVName.DataBind()
        lblGreen1.Text = ""
        lblRed1.Text = ""
        dt.Dispose()
        GVName.Visible = True
    End Sub
    Sub CheckAll()
        If CType(GVName.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVName.Rows
                CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVName.Rows
                CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim id2 As String = ""
            Dim check As String = ""
            Dim ab As Integer
            Dim Emp_Code As String = ""
            Dim GroupName As String = ""
            Dim ChkID As String
            Dim count As New Integer
            Dim dt As New DataTable
            count = 0
            lblGreen1.Text = ""
            lblRed1.Text = ""
            For Each grid As GridViewRow In GVName.Rows
                If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("lblID"), Label).Text
                    Emp_Code = CType(grid.FindControl("lblEmp_Code"), Label).Text
                    id = check + "," + id
                    id2 = Emp_Code + "," + id2
                    count = count + 1
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If
            Dim role As String

            If count = 0 Then
                lblRed1.Text = "Select Atleast One Record."
                lblGreen1.Text = ""
            Else
                ChkID = id
                ab = ddlGroup.SelectedValue
                GroupName = ddlGroup.SelectedItem.ToString
                Emp_Code = id2
                'If ddlGroup.SelectedValue = 1 Then

                'Else

                'End If
                '' bl.PostFeeCollection(ChkID)
                'lblGreen1.Text = "Data posted successfully."
                'lblRed1.Text = ""
                'el.ID = 0
                Try
                    id = Left(id, id.Length - 1)
                    Dim qrystring As String = "RptSendUserCredentialsV.aspx?" & QueryStr.Querystring() & "&ChkID=" & ChkID & "&Group=" & ab & "&GroupName=" & GroupName & "&Emp_Code=" & Emp_Code
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                Catch ex As ArgumentException
                    'lblE.Text = "Select Atleast one record."
                    'lblS.Text = ""
                End Try
            End If
        Else
            lblRed1.Text = "You do not belong to this branch, Cannot Print."
            lblGreen1.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt1 As DataTable
            Dim tablecount As Integer
            Dim password As String = ""
            Dim decryptpassword As String = ""
            Dim Mode As String = ""
            Dim id As String = ""
            Dim id2 As String = ""
            Dim check As String = ""
            Dim ab As Integer
            Dim Emp_Code As String = ""
            Dim GroupName As String = ""
            Dim ChkID As String
            Dim count As New Integer
            Dim dt As New DataTable
            count = 0

            If Session("EmailService") <> "N" Then

            End If



            If CheckSMS.Checked = False And CheckEmail.Checked = False Then
                lblRed1.Text = "Please Select SMS or Email."
                lblGreen1.Text = ""
                Exit Sub
            End If
            If CheckSMS.Checked And CheckEmail.Checked Then
                Mode = "Both"
            ElseIf CheckSMS.Checked Then
                Mode = "SMS"
            ElseIf CheckEmail.Checked Then
                Mode = "email"
            End If
            For Each grid As GridViewRow In GVName.Rows
                If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("lblID"), Label).Text
                    Emp_Code = CType(grid.FindControl("lblEmp_Code"), Label).Text
                    id = check + "," + id
                    id2 = Emp_Code + "," + id2
                    count = count + 1
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If

            If count = 0 Then
                lblRed1.Text = "Select Atleast One Record."
                lblGreen1.Text = ""
            Else
                ChkID = id
                ab = ddlGroup.SelectedValue
                GroupName = ddlGroup.SelectedItem.ToString
                Emp_Code = id2

                Try
                    dt1 = DLSendUserCredentials.GetParentEMAILSMSLoginDetails(ChkID, GroupName, Emp_Code, Mode)
                    'Else
                    '    dt1 = DLSendUserCredentials.GetEmployeeDetails(ChkID)
                    'End If
                    tablecount = dt1.Rows.Count
                    'tablecount1 = 0
                    'While tablecount > 0
                    '    password = dt1.Rows(tablecount - 1).Item("password")
                    '    decryptpassword = RijndaelSimple.Decrypt(password, _
                    '                                   RijndaelSimple.passPhrase, _
                    '                                   RijndaelSimple.saltValue, _
                    '                                   RijndaelSimple.hashAlgorithm, _
                    '                                   RijndaelSimple.passwordIterations, _
                    '                                   RijndaelSimple.initVector, _
                    '                                   RijndaelSimple.keySize)

                    '    dt1.Rows(tablecount - 1).Item("Password") = decryptpassword

                    '    tablecount = tablecount - 1
                    'End While
                    generatemsg(dt1)
                Catch ex As ArgumentException
                    'lblE.Text = "Select Atleast one record."
                    'lblS.Text = ""
                End Try
            End If
        Else
            lblRed1.Text = "You do not belong to this branch, Cannot Send Message."
            lblGreen1.Text = ""
        End If
    End Sub
    Sub generatemsg(ByVal dt As DataTable)
        Dim vm As String
        Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
        'Session("EmailService") = dt.Rows(0)("EmailService")
        'Session("SMSService")
        'dt = bl.GetCommunication(id)
        Dim rowcount As Integer = dt.Rows.Count
        While rowcount > 0

            Dim GlobalFunction As New GlobalFunction
            Try
                If dt.Rows.Count > 0 Then
                    'For i As Integer = 0 To dt.Rows.Count
                    Dim prefix As String = ""
                    Dim ToPhone As String
                    Dim Message As String
                    Dim Mode As String
                    Dim SentDate As DateTime
                    ToPhone = dt.Rows(rowcount - 1).Item("ContactNo").ToString
                    Message = dt.Rows(rowcount - 1).Item("line2") + " " + dt.Rows(rowcount - 1).Item("StdName") + " " + dt.Rows(rowcount - 1).Item("UserName") + " " + "Password : " + RijndaelSimple.Decrypt(dt.Rows(rowcount - 1).Item("Password"), _
                                                   RijndaelSimple.passPhrase, _
                                                   RijndaelSimple.saltValue, _
                                                   RijndaelSimple.hashAlgorithm, _
                                                   RijndaelSimple.passwordIterations, _
                                                   RijndaelSimple.initVector, _
                                                   RijndaelSimple.keySize) + " " + dt.Rows(rowcount - 1).Item("line3")

                    'ToPhone = ToPhone.Replace(",,", ",")
                    'ToPhone = ToPhone.Replace(",,,", ",")
                    'ToPhone = ToPhone.Replace(",,,,", ",")
                    'ToPhone = Left(ToPhone, ToPhone.Length - 1)
                    prefix = dt.Rows(rowcount - 1).Item("prefix")
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
                    'Next
                End If

            Catch ex As Exception
                lblRed1.Text = "Enter Correct data."
            End Try
            rowcount = rowcount - 1
        End While
        lblGreen1.Text = "Message Sent Successfully."
        lblRed1.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub CheckEmail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckEmail.CheckedChanged
        If Session("EmailService") = "N" Then
            CheckEmail.Checked = False
            lblRed1.Text = " Email Service is blocked. "
            lblGreen1.Text = ""
        End If
    End Sub
    Protected Sub CheckSMS_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckSMS.CheckedChanged
        If Session("SMSService") = "N" Then
            CheckSMS.Checked = False
            lblRed1.Text = " SMS Service is blocked. "
            lblGreen1.Text = ""
        End If
    End Sub
    Protected Sub GVName_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVName.PageIndexChanging
        Try
            GVName.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVName.PageIndex
            display()
            GVName.Visible = True
        Catch ex As Exception
            lblRed1.Text = "Enter Correct data."
        End Try

    End Sub
    Protected Sub GVName_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVName.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        dt = bl.GetNameCombo(ddlGroup.SelectedValue, "", "")
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVName.DataSource = sortedView
        GVName.DataBind()
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
