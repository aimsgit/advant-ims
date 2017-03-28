Imports System.Data.SqlClient

Partial Class frmSelectElective
    Inherits BasePage
    Dim Dt, Dt1, Dt2, dt3, dt4, dt5 As New DataTable
    Dim BatchId, SemId As Integer
    Dim DL As New DLSelectElective
    Dim StdCode, ConfigValue, BranchCode As String
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("heading") = Session("RptFrmTitleName")
            Me.Lblheading.Text = ViewState("heading")
        End If
        If Not IsPostBack Then
            If Session("LoginType") = "Others" Then
                'Panel3.Visible = True
                StdCode = Session("StudentCode")
                dt3 = DLSelectElective.StudentCurrentBatch(StdCode)
                BatchId = dt3.Rows(0).Item("Batch_No").ToString
                Session("CourseID") = dt3.Rows(0).Item("Courseid").ToString
                BranchCode = dt3.Rows(0).Item("BranchCode").ToString
                lblbatch1.Text = dt3.Rows(0).Item("Batch").ToString
                lblstdcode1.Text = Session("StudentCode").ToString
                lblcourse1.Text = dt3.Rows(0).Item("CourseName").ToString
                lblstdname1.Text = Session("StudentName")
                dt4 = DLSelectElective.StudentCurrentSem(BatchId, BranchCode)
                SemId = dt4.Rows(0).Item("SemesterID").ToString
                Session("SemesterID") = dt4.Rows(0).Item("SemesterID").ToString
                lblsem1.Text = dt4.Rows(0).Item("SemName").ToString
            ElseIf Session("Form") = "frmStudentEnquiryForm.aspx" Then
                StdCode = Request.QueryString.Get("StudentCode")
                Session("StudentCode") = StdCode
                dt3 = DLSelectElective.StudentCurrentBatch(StdCode)
                BatchId = dt3.Rows(0).Item("Batch_No").ToString
                Session("BatchID") = BatchId
                Session("CourseID") = dt3.Rows(0).Item("Courseid").ToString
                BranchCode = dt3.Rows(0).Item("BranchCode").ToString
                lblbatch1.Text = dt3.Rows(0).Item("Batch").ToString
                lblstdcode1.Text = StdCode
                lblcourse1.Text = dt3.Rows(0).Item("CourseName").ToString
                lblstdname1.Text = dt3.Rows(0).Item("StdName").ToString
                dt4 = DLSelectElective.StudentCurrentSem(BatchId, BranchCode)
                SemId = dt4.Rows(0).Item("SemesterID").ToString
                Session("SemesterID") = dt4.Rows(0).Item("SemesterID").ToString
                lblsem1.Text = dt4.Rows(0).Item("SemName").ToString
            End If
            GridView1.Visible = False
            GvOptions.Visible = False
        End If
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        Dim i As Integer = 0
        Dim Elective As Integer
        Dim Options As Integer
        Dim Subjectid As String = ""
        Dim Flag As Integer = 0

        Dim FlagCheck As Integer = 0
        If (RadioButtonList1.SelectedValue = "1") Then
            For Each rows As GridViewRow In GvOptions.Rows
                If CType(rows.FindControl("ChkBx1"), CheckBox).Checked = True Then
                    Subjectid = Subjectid + CType(rows.FindControl("lblsubjectid"), Label).Text + ","
                    Flag = 1
                End If
            Next
            If (Flag = 0) Then
                lblMsg.Text = ""
                msginfo.Text = "Please Select Options."
            Else
                Dt = DL.insertoption(Subjectid.Substring(Options, Subjectid.Length - 1))
                lblMsg.Text = "Options Submitted Successfully."
                msginfo.Text = ""
            End If

        Else
            Dim elec(GridView1.Rows.Count - 1) As Integer
            Dim subj(GridView1.Rows.Count - 1) As Integer
            Dim y As Integer = 0
            Dim a As Integer = 0
            Dim f As Integer = 0
            Dim m As Integer = 0
            Dim x As Integer = 0
            For Each rows As GridViewRow In GridView1.Rows
                If (CType(rows.FindControl("ddlelective"), DropDownList).SelectedValue <> 0) Then
                    elec(y) = CType(rows.FindControl("ddlelective"), DropDownList).SelectedValue
                    y = y + 1
                End If
            Next
            If (elec.Length > 0) Then
                For index As Integer = 0 To elec.Length - 1
                    a = elec(index)
                    For x = 0 To elec.Length - 1
                        If (a = elec(x)) Then
                            f = f + 1
                            If (f = 2) Then
                                m = 1
                                Exit For
                            End If
                        End If
                    Next
                    f = 0
                Next
            End If
            If (m = 1) Then
                msginfo.Text = "Select Elective Correctly."
                lblMsg.Text = ""
                Exit Sub
            End If
            y = 0
            a = 0
            f = 0
            m = 0
            x = 0
            For Each rows As GridViewRow In GridView1.Rows
                If (CType(rows.FindControl("ddloption"), DropDownList).SelectedValue <> 0) Then
                    subj(y) = CType(rows.FindControl("ddloption"), DropDownList).SelectedValue
                    y = y + 1
                End If
            Next
            If (subj.Length > 0) Then
                For index As Integer = 0 To elec.Length - 1
                    a = subj(index)
                    For x = 0 To subj.Length - 1
                        If (a = subj(x)) Then
                            f = f + 1
                            If (f = 2) Then
                                m = 1
                                Exit For
                            End If
                        End If
                    Next
                    f = 0
                Next
            End If
            If (m = 1) Then
                msginfo.Text = "Select Options Correctly."
                lblMsg.Text = ""
                Exit Sub
            End If

            For Each Grid As GridViewRow In GridView1.Rows
                If (i = 0) Then
                    If (CType(Grid.FindControl("ddlelective"), DropDownList).SelectedValue = 0) Then
                        msginfo.Text = "Please select Elective"
                        Exit Sub
                    Else
                        If (CType(Grid.FindControl("ddlelective"), DropDownList).SelectedValue <> 0) Then
                            Elective = CType(Grid.FindControl("ddlelective"), DropDownList).SelectedValue
                            If (CType(Grid.FindControl("ddloption"), DropDownList).SelectedValue <> 0) Then
                                Options = CType(Grid.FindControl("ddloption"), DropDownList).SelectedValue
                                DL.UpdateElective(Elective, Options)
                                FlagCheck = 1
                            End If
                        End If
                    End If
                Else
                    If (CType(Grid.FindControl("ddlelective"), DropDownList).SelectedValue <> 0) Then
                        Elective = CType(Grid.FindControl("ddlelective"), DropDownList).SelectedValue
                        If (CType(Grid.FindControl("ddloption"), DropDownList).SelectedValue <> 0) Then
                            Options = CType(Grid.FindControl("ddloption"), DropDownList).SelectedValue
                            DL.UpdateElective(Elective, Options)
                        End If
                    End If
                End If
                i = i + 1

            Next
            If (FlagCheck = 1) Then
                msginfo.Text = ""
                lblMsg.Text = "Elective Assigned Successfully"
            Else
                msginfo.Text = "Select Options."
                lblMsg.Text = ""
            End If
        End If

    End Sub

    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        'con.Open()
    '        Dim courseid As Integer = CType(GridView1.FindControl("ddloption"), DropDownList).SelectedValue
    '        'Dim CountryId As Integer = Convert.ToInt32(e.Row.Cells(0).Text)
    '        'Dim cmd As New SqlCommand("select * from State where CountryID=" & CountryId, con)
    '        'Dim da As New SqlDataAdapter(cmd)
    '        'Dim ds As New DataSet()
    '        'da.Fill(ds)
    '        'con.Close()
    '        'ddl.DataSource = ds
    '        'ddl.DataTextField = "StateName"
    '        'ddl.DataValueField = "StateID"
    '        'ddl.DataBind()
    '        'ddl.Items.Insert(0, New ListItem("--Select--", "0"))
    '    End If
    'End Sub

    Public Sub optionchanged(ByVal sender As Object, ByVal e As EventArgs)
        'Dim courseid As Integer = CType(GridView1.FindControl("ddloption"), DropDownList).SelectedValue
        Dim ddlSizes As DropDownList = DirectCast(sender, DropDownList)
        'Dim ri As RepeaterItem = DirectCast(ddlSizes.Parent, RepeaterItem)
        Dim S As Double
        'lbldummy.Text = ddlSizes.SelectedValue
        Dim courseid As Integer = ddlSizes.SelectedValue
        dt5 = DL.creditpoint(courseid)
        For Each row In GridView1.Rows
            Dim reqType As DropDownList = CType(row.FindControl("ddloption"), DropDownList)
            Dim txtHideMe As Label = CType(row.FindControl("lblcred"), Label)
            Dim txtprequ As Label = CType(row.FindControl("lblprequ"), Label)
            If reqType.SelectedItem.Value = courseid Then
                If (dt5.Rows(0).Item("Credit") = 0) Then
                    txtHideMe.Text = ""
                    txtprequ.Text = dt5.Rows(0).Item("Pre_Requisites")
                Else
                    txtHideMe.Text = dt5.Rows(0).Item("Credit")
                    txtprequ.Text = dt5.Rows(0).Item("Pre_Requisites")
                End If
            End If
            If (txtHideMe.Text = "") Then
                S = S + 0
            Else
                S = S + CDbl(txtHideMe.Text)
            End If
        Next
        'Dim lbldummy As TextBox = DirectCast(sender, TextBox)
        'lbldummy.Text = dt5.Rows(0).Item(0)
        txtGrade.Text = S
    End Sub

    Public Sub AddCredit(ByVal sender As Object, ByVal e As EventArgs)
        'Dim courseid As Integer = CType(GridView1.FindControl("ddloption"), DropDownList).SelectedValue
        'Dim ddlSizes As DropDownList = DirectCast(sender, DropDownList)
        'Dim ri As RepeaterItem = DirectCast(ddlSizes.Parent, RepeaterItem)
        Dim S As Double = 0

        'lbldummy.Text = ddlSizes.SelectedValue
        If (RadioButtonList1.SelectedValue = "1") Then
            For Each rows As GridViewRow In GvOptions.Rows
                If CType(rows.FindControl("ChkBx1"), CheckBox).Checked = True Then
                    S = S + CDbl(CType(rows.FindControl("lblcredit"), Label).Text)
                End If
            Next
        End If
        txtGrade.Text = S
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim S As Double = 0
        If (RadioButtonList1.SelectedValue = "1") Then
            lblMsg.Text = ""
            msginfo.Text = ""
            Dt = DL.getoptions()
            If (Dt.Rows.Count > 0) Then
                GvOptions.DataSource = Dt
                GvOptions.DataBind()
                For Each rows As GridViewRow In GvOptions.Rows
                    If CType(rows.FindControl("lblSelect1"), Label).Text = "Y" Then
                        CType(rows.FindControl("ChkBx1"), CheckBox).Checked = True
                        S = S + CDbl(CType(rows.FindControl("lblcredit"), Label).Text)
                    End If
                Next
                txtGrade.Text = S
                lblcredit.Visible = True
                txtGrade.Visible = True
                GvOptions.Visible = True
                GridView1.Visible = False
            Else
                lblcredit.Visible = False
                txtGrade.Visible = False
                GvOptions.Visible = False
                GridView1.Visible = False
                lblMsg.Text = ""
                msginfo.Text = "No Records."
            End If
        Else
            lblMsg.Text = ""
            msginfo.Text = ""
            Dt = DL.countsub(BatchId, 0)
            If (Dt.Rows.Count > 0) Then
                'If (Dt.Rows(0).Item("SubjectID") = 0) Then
                '    GridView1.DataSource = Dt
                '    GridView1.DataBind()
                'Else
                Dim i As Integer = 1
                GridView1.DataSource = Dt
                GridView1.DataBind()
                'For Each dtrow In Dt.Rows
                S = 0
                For Each row In GridView1.Rows
                    Dt = DL.countsub(BatchId, i)
                    Dim elective As DropDownList = CType(row.FindControl("ddlelective"), DropDownList)
                    Dim options As DropDownList = CType(row.FindControl("ddloption"), DropDownList)
                    Dim credit As Label = CType(row.FindControl("lblcred"), Label)
                    'elective.ClearSelection()
                    'elective.DataSourceID = ""
                    elective.SelectedValue = Dt.Rows(0).Item(0)
                    options.SelectedValue = Dt.Rows(0).Item(2)
                    If (Dt.Rows(0).Item(3) Is DBNull.Value) Then
                        credit.Text = ""
                    Else
                        credit.Text = Dt.Rows(0).Item(3)
                        S = S + CDbl(Dt.Rows(0).Item(3))
                    End If
                    i = i + 1
                Next
                'Next
                'End If
                txtGrade.Text = S
                lblcredit.Visible = True
                txtGrade.Visible = True
                GvOptions.Visible = False
                GridView1.Visible = True
            Else
                lblcredit.Visible = False
                txtGrade.Visible = False
                GvOptions.Visible = False
                GridView1.Visible = False
                lblMsg.Text = ""
                msginfo.Text = "No Records."
            End If
        End If
    End Sub
    Sub CheckAllGv1()
        Dim S As Double = 0
        If CType(GvOptions.HeaderRow.FindControl("ChkAll1"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GvOptions.Rows
                CType(grid.FindControl("ChkSelect1"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GvOptions.Rows
                CType(grid.FindControl("ChkSelect1"), CheckBox).Checked = False
            Next
        End If
        If (RadioButtonList1.SelectedValue = "1") Then
            For Each rows As GridViewRow In GvOptions.Rows
                If CType(rows.FindControl("ChkBx1"), CheckBox).Checked = True Then
                    S = S + CDbl(CType(rows.FindControl("lblcredit"), Label).Text)
                End If
            Next
        End If
        txtGrade.Text = S
    End Sub
    'Sub CheckAllGv2()
    '    If CType(GridView1.HeaderRow.FindControl("ChkAll2"), CheckBox).Checked = True Then
    '        For Each grid As GridViewRow In GridView1.Rows
    '            CType(grid.FindControl("ChkSelect2"), CheckBox).Checked = True
    '        Next
    '    Else
    '        For Each grid As GridViewRow In GridView1.Rows
    '            CType(grid.FindControl("ChkSelect2"), CheckBox).Checked = False
    '        Next
    '    End If
    'End Sub
End Class
