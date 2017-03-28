Imports System.Data.OleDb
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting
Partial Class FrmManagementDashboard
    Inherits BasePage
    Dim dt, dt1 As DataTable
    Dim Dl As New DLReportsR
    'Dim Prop As New QureyStringP
    Dim TotSeats, TotAdmn, TotSeatsLeft As New Integer
    Dim TotFeeColl, TotalFee, Balance As New Double
    Dim arr() As String
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        GVManagementDB.Visible = True
        DisplayGridView()
    End Sub
    Sub DisplayGridView()
        LinkButton1.Focus()
        Try
            Dim dt As New DataTable
            'Dim BranchCode As String = Request.QueryString.Get("Branch")
            Dim BranchCode As String = txtBranchName.SelectedValue
            Dim fromdateE As DateTime
            Dim todateE As DateTime
            If txtFromDateExt.Text = "" Then
                fromdateE = "1/1/1900"
            Else
                fromdateE = txtFromDateExt.Text
            End If
            If txtToDateExt.Text = "" Then
                todateE = "1/1/1900"
            Else
                todateE = txtToDateExt.Text
            End If
            If fromdateE = "1/1/1900" Or todateE = "1/1/1900" Then
                lblE.Text = "Please enter mandatory fields"
            ElseIf fromdateE > todateE Then
                lblE.Text = "From Date cannot be greater than To Date"
                txtFromDateExt.Focus()
            Else
                'If txtBranchName.SelectedValue = 0 Then
                dt = Dl.ManagementDashboard(txtBranchName.SelectedValue, fromdateE, todateE)
                dt1 = Dl.ManagementDashboardCourseWise(txtBranchName.SelectedValue, fromdateE, todateE)

                Dim TotEmpCount As Integer
                TotEmpCount = dt.Rows(0).Item("TotEmpCount")
                'Else
                '    dt = Dl.ManagementDashboard1(BranchCode, fromdateE, todateE)
                'End If
                If dt1.Rows.Count = 0 Then
                    GVManagementDB.DataSource = Nothing
                    GVManagementDB.DataBind()
                    lblE.Text = "No records to display."
                    lblGrandTotal.Visible = False
                    lblTotSeats.Visible = False
                    lblTotFeeColl.Visible = False
                    lblTotAdmiss.Visible = False
                    lblTotNoofSeatsleft.Visible = False
                    lblTotEmpCount.Visible = False
                    'lblmsg.text = ""
                Else

                    lblE.Text = ""
                    GVManagementDB.DataSource = dt1
                    GVManagementDB.DataBind()
                    arr = txtBranchName.SelectedItem.Text.Split(":")
                    'If (Trim(arr(0)) = "HO") Then
                    '    Chart1.Width = 12000
                    '    Chart1.Height = 500
                    '    Chart2.Width = 12000
                    '    Chart2.Height = 500
                    'ElseIf (Trim(arr(0)) = "Zone") Then
                    '    Chart1.Width = 9000
                    '    Chart1.Height = 500
                    '    Chart2.Width = 9000
                    '    Chart2.Height = 500
                    'ElseIf (Trim(arr(0)) = "RO") Then
                    '    Chart1.Width = 4000
                    '    Chart1.Height = 500
                    '    Chart2.Width = 4000
                    '    Chart2.Height = 500
                    'ElseIf (Trim(arr(0)) = "HUB") Then
                    '    Chart1.Width = 2000
                    '    Chart1.Height = 500
                    '    Chart2.Width = 2000
                    '    Chart2.Height = 500
                    'ElseIf (Trim(arr(0)) = "All") Then
                    '    Chart1.Width = 12000
                    '    Chart1.Height = 500
                    '    Chart2.Width = 12000
                    '    Chart2.Height = 500
                    'Else
                    '    Chart1.Width = 1000
                    '    Chart1.Height = 500
                    '    Chart2.Width = 1000
                    '    Chart2.Height = 500
                    'End If

                    'If dt1.Rows.Count > 0 Then
                    Chart1.Series("Series1").YValueMembers = "NoOfSeats"
                    Chart1.Series("Series1").XValueMember = "CourseName"
                    Chart1.Series("Series2").YValueMembers = "NoofAdmission"
                    Chart1.Series("Series2").XValueMember = "CourseName"


                    'Chart1.DataManipulator.Group("Series1", 0, IntervalType.Years, "CourseName")


                    'Chart1.ChartAreas("Series1").Area3DStyle.Enable3D = True

                    Chart1.DataSource = dt1
                    Chart1.DataBind()

                    Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
                    'Chart1.ChartAreas(0).AxisX.ValueToPosition(XXValueMember) = 45
                    Chart1.ChartAreas(0).AxisX.Interval = 1
                    Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
                    'Chart1.ChartAreas(0).Area3DStyle.WallWidth = 200
                    Chart1.ChartAreas(0).Area3DStyle.LightStyle = LightStyle.Simplistic


                    Chart1.Visible = True

                    Chart2.ChartAreas(0).Area3DStyle.Enable3D = True
                    'Chart1.ChartAreas(0).Area3DStyle.WallWidth = 200
                    Chart2.ChartAreas(0).Area3DStyle.LightStyle = LightStyle.Simplistic

                    Chart2.Series("Series1").IsValueShownAsLabel = "false"
                    Chart2.Series("Series2").IsValueShownAsLabel = "false"


                    'Chart2.ChartAreas("ChartArea1").AxisY.Title = "Seats"
                    'Chart2.ChartAreas("ChartArea1").AxisX.Title = "Batch"
                    Chart2.Series("Series1").YValueMembers = "TotalFee"
                    Chart2.Series("Series1").XValueMember = "CourseName"
                    Chart2.Series("Series2").YValueMembers = "TotFeeColl"
                    Chart2.Series("Series2").XValueMember = "CourseName"

                    Chart2.DataSource = dt1
                    Chart2.DataBind()
                    Chart2.ChartAreas(0).AxisX.LabelStyle.Angle = -90
                    Chart2.Series("Series1").SmartLabelStyle.Enabled = False
                    'Chart2.Series("Series1").LabelAngle = -45                    'Can vary from -90 to 90;
                    Chart2.Series("Series2").SmartLabelStyle.Enabled = False
                    'Chart2.Series("Series2").LabelAngle = -45                    'Can vary from -90 to 90;
                    Chart2.ChartAreas(0).AxisX.Interval = 1
                    Chart2.Visible = True
                    'End If

                    TotSeats = 0
                    TotFeeColl = 0
                    TotAdmn = 0
                    TotSeatsLeft = 0
                    TotalFee = 0
                    Balance = 0
                    lblGrandTotal.Visible = False
                    For Each rows As GridViewRow In GVManagementDB.Rows
                        If CType(rows.FindControl("lblNoOfSeats"), Label).Text = "" Then
                            TotSeats = TotSeats + 0
                        Else
                            TotSeats = TotSeats + CType(rows.FindControl("lblNoOfSeats"), Label).Text
                        End If
                        If CType(rows.FindControl("lblNoofAdm"), LinkButton).Text = "" Then
                            TotAdmn = TotAdmn + 0
                        Else
                            TotAdmn = TotAdmn + CType(rows.FindControl("lblNoofAdm"), LinkButton).Text
                        End If
                        If CType(rows.FindControl("lblNoofSeatsLeft"), Label).Text = "" Then
                            TotSeatsLeft = TotSeatsLeft + 0
                        Else
                            TotSeatsLeft = TotSeatsLeft + CType(rows.FindControl("lblNoofSeatsLeft"), Label).Text
                        End If
                        If CType(rows.FindControl("lblTotfeeColl"), LinkButton).Text = "" Then
                            TotFeeColl = TotFeeColl + 0
                        Else
                            TotFeeColl = TotFeeColl + CType(rows.FindControl("lblTotfeeColl"), LinkButton).Text
                        End If
                        If CType(rows.FindControl("lblTotfee"), Label).Text = "" Then
                            TotalFee = TotalFee + 0
                        Else
                            TotalFee = TotalFee + CType(rows.FindControl("lblTotfee"), Label).Text
                        End If
                        If CType(rows.FindControl("lblBalFee"), Label).Text = "" Then
                            Balance = Balance + 0
                        Else
                            Balance = Balance + CType(rows.FindControl("lblBalFee"), Label).Text
                        End If
                    Next

                    dt1.Clear()
                    Dim dRow As DataRow
                    dRow = dt1.NewRow

                    dRow(1) = "Grand Total"
                    dRow(6) = TotSeats
                    dRow(13) = TotFeeColl
                    dRow(10) = TotAdmn
                    dRow(11) = TotSeatsLeft
                    dRow(4) = TotEmpCount
                    dRow(12) = TotalFee
                    dRow(14) = Balance

                    dt1.Rows.InsertAt(dRow, 0)
                    GVTotal.DataSource = dt1
                    GVTotal.DataBind()

                    'lblTotSeats.Visible = True
                    'lblTotFeeColl.Visible = True
                    'lblTotAdmiss.Visible = True
                    'lblTotNoofSeatsLeft.Visible = True
                    'lblTotEmpCount.Visible = True
                    'lblTotSeats.Text = TotSeats
                    'lblTotFeeColl.Text = Format(TotFeeColl, "n2")
                    'lblTotAdmiss.Text = TotAdmn
                    'lblTotNoofSeatsLeft.Text = TotSeatsLeft
                    'lblTotEmpCount.Text = TotEmpCount

                End If
            End If
        Catch ex As Exception
            lblE.Text = "Enter Correct date."
        End Try
    End Sub
    Protected Sub GVManagementDB_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVManagementDB.PageIndexChanging
        If GVManagementDB.EditIndex <> -1 Then
            'msginfo.Text = "First Cancel Edit."
            'lblmsg.Text = ""
        Else
            GVManagementDB.PageIndex = e.NewPageIndex
            DisplayGridView()
        End If
    End Sub

    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        
            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
            If Not IsPostBack Then
                Dim CloseDate As Date
                Dim cd As String
                CloseDate = System.DateTime.Now
                cd = CloseDate.ToString("dd-MMM-yyyy")
                txtToDateExt.Text = cd
                txtFromDateExt.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                txtBranchName.Focus()
                txtBranchName.SelectedValue = Session("BranchCode")
                Chart1.Visible = False
                Chart2.Visible = False
            End If
        Catch ex As Exception
            Response.Redirect("LogIn.aspx")
        End Try
    End Sub

    Protected Sub txtBranchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.TextChanged
        txtBranchName.Focus()
    End Sub

    Protected Sub GVManagementDB_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVManagementDB.RowDeleting
        Dim Branch_Code1 As String
        Dim CourseId, BatchId As Integer
        Dim fromdate, todate As Date
        Branch_Code1 = CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidBranchCode"), HiddenField).Value
        If CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidCourseId"), HiddenField).Value = "" Then
            CourseId = 0
        Else
            CourseId = CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidCourseId"), HiddenField).Value
        End If
        'If CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidBatchId"), HiddenField).Value = "" Then
        '    BatchId = 0
        'Else
        '    BatchId = CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidBatchId"), HiddenField).Value
        'End If
        fromdate = txtFromDateExt.Text
        todate = txtToDateExt.Text
        Dim qrystring As String = "frmManagementFeeCollectionDrillDown.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & Branch_Code1 & "&CourseId=" & CourseId & "&BatchId=" & BatchId & "&FromDate=" & fromdate & "&todate=" & todate
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

    End Sub

    Protected Sub GVManagementDB_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVManagementDB.RowEditing
        Dim Branch_Code As String
        Branch_Code = CType(GVManagementDB.Rows(e.NewEditIndex).FindControl("HidBranchCode"), HiddenField).Value

        Dim qrystring As String = "frmManagementEmployeeDrillDown.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & Branch_Code
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

    End Sub

    Protected Sub GVManagementDB_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVManagementDB.RowUpdating
        Dim Branch_Code1 As String
        Dim CourseId, BatchId As Integer
        Branch_Code1 = CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidBranchCode"), HiddenField).Value
        If CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidCourseId"), HiddenField).Value = "" Then
            CourseId = 0
        Else
            CourseId = CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidCourseId"), HiddenField).Value
        End If
        'BatchId = CType(GVManagementDB.Rows(e.RowIndex).Cells(1).FindControl("HidBatchId"), HiddenField).Value

        Dim qrystring As String = "frmManagementAdmittedDrillDown.aspx?" & QueryStr.Querystring() & "&Branch_Code=" & Branch_Code1 & "&CourseId=" & CourseId & "&BatchId=" & BatchId
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)

    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
