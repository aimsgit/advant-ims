Imports System.Data.SqlClient

Partial Class RptTimeTablewithattendance
    Inherits BasePage
    Dim dt1, dt As New DataTable
    Dim ContactNo As String
    Dim EmailId As String
    Dim PEmailId As String
    Dim vm, vm1, vm2 As String
    Dim parm_msg, parm_phonesp, parm_msgfrm As SqlParameter
    Dim GlobalFunction As New GlobalFunction
    Dim prefix As String = "Attendance Missed Detail"
    Dim prefix1 As String = "Principal"
    Dim id1 As String = ""
    Dim id2 As String = ""
    Dim id3 As String = ""
    Dim id4 As String = ""
    Dim id5 As String = ""
    Dim princimsg As String = ""
    Dim PrincipalMsg As String = ""


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtdate.Text = Format(Today, "dd-MMM-yyyy")
        End If

    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        Dim QS As String
        Dim Sdate As Date
        'Dim Batch As Integer
        'Dim Semester As Integer
        Sdate = txtdate.Text
        If Sdate > Today() Then
            lblErrorMsg.Text = "Attendance Date cannot be greater than Today\'s Date."

            Exit Sub
            'Else
            '    Sdate = txtdate.Text
        End If
        'Batch = ddlbatch.SelectedValue
        'Semester = ddlsem.SelectedValue
        'Dim BatchName As String = ddlbatch.SelectedItem.Text
        'Dim SemesterName As String = ddlsem.SelectedItem.Text
        QS = Request.QueryString.Get("QS")

        Dim qrystring As String = "RptTimeTablewithattendanceV.aspx?" & QueryStr.Querystring() & "&Sdate=" & Sdate
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        'lblMsg.Text = ""
    End Sub

    Protected Sub btnsendsms_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsendsms.Click
        Dim Sdate As Date
        Try


            'Dim Batch As Integer
            'Dim Semester As Integer
            lblErrorMsg.Text = ""
            lblgreen.Text = ""

            Sdate = txtdate.Text
            If Sdate > Today() Then
                lblErrorMsg.Text = "Attendance Date cannot be greater than Today\'s Date."

                Exit Sub

            End If
            Dim i As Integer = 0
            Dim i1 As Integer = 0


            'Batch = 0
            'Semester = 0
            'Dim BatchName As String = ddlbatch.SelectedItem.Text
            'Dim SemesterName As String = ddlsem.SelectedItem.Text

            dt1 = DLTimeTableWithattendance.Getmisseddetail(Sdate)
            If dt1.Rows.Count > 0 Then
                For Each row As DataRow In dt1.Rows

                    generatemsg(i)
                    'id3 = ViewState("id1")
                    'id4 = id3 + "<br/>" + id4
                    i = i + 1
                Next row

                PrincipalMsg = princimsg + ""
                'SENDING SMS FOR PRINCIPAL -- Coded by Khushi
                dt = DLTimeTableWithattendance.GetPrincipalDetail()
                If dt.Rows.Count <> 0 Then
                    'For Each row As DataRow In dt.Rows
                    If IsDBNull(dt.Rows(0).Item("Email")) Then
                        PEmailId = "NA"
                    Else
                        ViewState("PEmailId") = dt.Rows(0).Item("Email") + "," + "amita@advant-tech.com" + "," + "ganesha@advant-tech.com" + "," + "vk100pandey@gmail.com"
                        principal(PrincipalMsg)
                        'ViewState("PEmailId") = "amita@advant-tech.com"
                        'principal(PrincipalMsg)
                        'ViewState("PEmailId") = "ganesha@advant-tech.com"
                        'principal(PrincipalMsg)
                        'ViewState("PEmailId") = "vk100pandey@gmail.com"
                        'principal(PrincipalMsg)
                    End If
                    'i1 = i1 + 1
                    'Next row

                Else
                    ViewState("PEmailId") = "Khushi@advant-tech.com" '+ ";" + "roseserene@gmail.com" + ";" + "vk100pandey@gmail.com" + ";" + "amita@advant-tech.com" + ";" + "ganesha@advant-tech.com"
                    principal(PrincipalMsg)
                    ViewState("PEmailId") = "roseserene@gmail.com"
                    principal(PrincipalMsg)
                End If

            Else
                lblErrorMsg.Text = "No Records found to Send SMS."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter Correct data."
        End Try
    End Sub

    Sub generatemsg(ByVal i As Integer)
      
        Try


            Dim ToPhone As String
            Dim Message As String

            Dim SentDate As DateTime
            Dim ToEmail As String

            Dim Subject As String = dt1.Rows(i).Item("TSubjectName")
           
            Dim BatchNo As String = dt1.Rows(i).Item("TBatchName")
            Dim SemName As String = dt1.Rows(i).Item("TSemName")
            Dim EmpName As String = dt1.Rows(i).Item("TEmpName")
            Dim PeriodNo As String = dt1.Rows(i).Item("PeriodNo")
            Dim PMessage As String = txtdate.Text + " , " + BatchNo + " , " + SemName + " , " + EmpName + " , " + Subject + " , Period No. = " + PeriodNo

            ViewState("id1") = PMessage
            princimsg = PMessage + "<br/>" + princimsg
            If IsDBNull(dt1.Rows(i).Item("TContactNo")) Then
                ToPhone = "0000000000"
            Else
                ToPhone = dt1.Rows(i).Item("TContactNo")
            End If
            If IsDBNull(dt1.Rows(i).Item("TEmailId")) Then
                ToEmail = "NA"
            Else
                ToEmail = dt1.Rows(i).Item("TEmailId")
            End If
            Message = txtdate.Text + ": Class Attendance Missing for " + Subject

            SentDate = Format("dd-MMM-yyyy", Today)
            'Dim SentTime As DateTime = dt1.Rows(i).Item("SentTime")
            'Dim SentTimeStr As String = Convert.ToString(SentTime).Trim

            Dim str As String = ""
            Dim connection As New SqlClient.SqlConnection()
            connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
            connection.Open()
            Dim cmd As New SqlCommand()
            vm = "insert into Outbox_tbl (ToPhone,Message,BranchCode,CommunicationMode,FromEmailID,FromPassword,SMTPHost,Prefix,SentDate,SentTime) values(@ToPhone,@Message,@BranchCode,'SMS',@FromEmailID,@FromPassword,@SMTPHost,@MsgFrom,@SentDate,CONVERT(VARCHAR(8),GETDATE(),108))"
            vm1 = "insert into Outbox_tbl (ToPhone,Message,BranchCode,CommunicationMode,FromEmailID,FromPassword,SMTPHost,Prefix,SentDate,SentTime) values(@ToEmail,@Message,@BranchCode,'Email',@FromEmailID,@FromPassword,@SMTPHost,@MsgFrom,@SentDate,CONVERT(VARCHAR(8),GETDATE(),108))"

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
            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@SentDate"
            parm_msgfrm.Value = SentDate
            parm_msgfrm.DbType = DbType.DateTime

            cmd.Parameters.Add(parm_msgfrm)

            parm_phonesp = New SqlParameter
            parm_phonesp.ParameterName = "@ToEmail"
            parm_phonesp.Value = ToEmail
            parm_phonesp.DbType = DbType.String
            cmd.Parameters.Add(parm_phonesp)

            cmd.ExecuteNonQuery()
            cmd.CommandText = vm1

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            lblErrorMsg.Text = "Enter Correct data."
        End Try
        lblgreen.Text = "Message Sent Successfully."
        lblErrorMsg.Text = ""
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Sub principal(ByVal PrincipalMsg As String)
        Try
            lblErrorMsg.Text = ""
            lblgreen.Text = ""
            Dim SentDate As DateTime = Format("dd-MMM-yyyy", Today)
            Dim str As String = ""
            Dim connection As New SqlClient.SqlConnection()
            connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
            connection.Open()
            Dim cmd As New SqlCommand()
            Dim id6 As String = "Class Attendance Missing as Below : <br/><br/>" + PrincipalMsg
            vm2 = "insert into Outbox_tbl (ToPhone,Message,BranchCode,CommunicationMode,FromEmailID,FromPassword,SMTPHost,Prefix,SentDate,SentTime) values(@ToEmail,@Message,@BranchCode,'Email',@FromEmailID,@FromPassword,@SMTPHost,@MsgFrom,@SentDate,CONVERT(VARCHAR(8),GETDATE(),108))"
            cmd.Connection = connection

            cmd.CommandText = vm2

            parm_msg = New SqlParameter
            parm_msg.ParameterName = "@Message"
            parm_msg.Value = id6
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
            parm_msgfrm = New SqlParameter
            parm_msgfrm.ParameterName = "@SentDate"
            parm_msgfrm.Value = SentDate
            parm_msgfrm.DbType = DbType.DateTime

            cmd.Parameters.Add(parm_msgfrm)

            parm_phonesp = New SqlParameter
            parm_phonesp.ParameterName = "@ToEmail"
            parm_phonesp.Value = ViewState("PEmailId")
            parm_phonesp.DbType = DbType.String
            cmd.Parameters.Add(parm_phonesp)

            cmd.CommandText = vm2
            cmd.ExecuteNonQuery()
            lblgreen.Text = "Message Sent Successfully."
            lblErrorMsg.Text = ""
        Catch ex As Exception
            lblErrorMsg.Text = "Enter Correct data."
        End Try
    End Sub
End Class