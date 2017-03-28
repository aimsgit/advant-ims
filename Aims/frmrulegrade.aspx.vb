Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Globalization

Partial Class frmrulegrade
    Inherits BasePage
    Dim dt As DataTable
    Dim dl As New DLRuleGrade
    Dim SubFlag As Integer = 0
    Dim SubId As Integer = 0
    Dim SubText1 As String = ""
    Dim SubText2 As String = ""
    Dim GPAFlag As Integer = 0
    Dim GPAText1 As String = ""
    Dim GPAText2 As String = ""
    Dim CreditFlag As Integer = 0
    Dim CreditText1 As String = ""
    Dim CreditText2 As String = ""
    Dim MarksFlag As Integer = 0
    Dim MarksText1 As String = ""
    Dim MarksText2 As String = ""
    Dim CourseFlag As Integer = 0
    Dim CourseText1 As String = ""
    Dim CourseText2 As String = ""
    Dim GPAFormula As String = ""
    Dim CreditFormula As String = ""
    Dim MarksFormula As String = ""
    Dim CourseFormula As String = ""
    Dim SubFormula As String = ""
    Dim MainFormula As String = ""
    Dim OrFormula As String = ""
    Dim AndFormula As String = ""
    Dim Condition1 As Integer = 0
    Dim Condition2 As Integer = 0
    Dim Subject As Integer = 0
    Dim Split() As String
    Dim table As New DataTable
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        Try
            ViewState("Run") = ""
            lblcorrect.Text = ""
            lblerror.Text = ""
            table = DLRuleGrade.GetStudentData(ddlbatch.SelectedValue, MainFormula, Subject, Condition1, Condition2, ddlsemester.SelectedValue)

            If (table.Rows.Count > 0) Then
                GridStud.DataSource = table
                GridStud.DataBind()
                lblcorrect.Text = table.Rows.Count.ToString + " no of records generated."
            Else
                GridStud.DataSource = Nothing
                GridStud.DataBind()
                lblerror.Text = "No records to display."
            End If


            'lblcorrect.Text = ""
            'lblerror.Text = ""
            ''If Not IsPostBack Then
            'panel1.Visible = True
            'Dim table1 As New DataTable
            'table1.Columns.Add("Options")
            'table1.Columns.Add("Criteria1")
            'table1.Columns.Add("Criteria2")

            'table1.Rows.Add("Overall GPA", "<=", ">")
            'table1.Rows.Add("Total Credit Point", "<=", ">")
            'table1.Rows.Add("Total Marks", "<=", ">")
            'table1.Rows.Add("Course Duration", "<=", "Days")

            'GridView1.DataSource = table1
            'GridView1.DataBind()

            'Dim table As New DataTable
            'table.Columns.Add("Criteria1")
            'table.Columns.Add("Criteria2")

            'table.Rows.Add(">=", "Grade")

            'GvRule.DataSource = table
            'GvRule.DataBind()
            'Dim txt2 As TextBox = GridView1.Rows(3).FindControl("txtvalue2")
            'txt2.Enabled = False
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim heading As String
                heading = Session("RptFrmTitleName")
                Me.Lblheading.Text = heading


                panel1.Visible = True
                'Dim table1 As New DataTable
                'table1.Columns.Add("Options")
                'table1.Columns.Add("Criteria1")
                'table1.Columns.Add("Criteria2")

                'table1.Rows.Add("Overall Grade", ">=", "Total Credit")
                'table1.Rows.Add("Total Credit Point", "<=", ">")
                'table1.Rows.Add("Total Marks", "<=", ">")
                'table1.Rows.Add("Course Duration", "<=", "Days")

                'GridView1.DataSource = table1
                'GridView1.DataBind()

                Dim tabrun As New DataTable
                tabrun.Columns.Add("Check1")
                tabrun.Columns.Add("Check2")
                tabrun.Columns.Add("Run")
                tabrun.Columns.Add("Rule")
                tabrun.Columns.Add("Assessment")
                tabrun.Columns.Add("Assessmentid")
                tabrun.Columns.Add("Options1")
                tabrun.Columns.Add("Options1id")
                tabrun.Columns.Add("Value1")
                tabrun.Columns.Add("Value2")
                tabrun.Columns.Add("Options2")
                tabrun.Columns.Add("Options2id")

                ViewState("tabrun") = tabrun
                ViewState("Run") = ""
                Dim table As New DataTable
                table.Columns.Add("Option1")
                table.Columns.Add("Option2")
                table.Columns.Add("Criteria1")
                table.Columns.Add("Criteria2")
                table.Columns.Add("value")
                table.Rows.Add("Overall Grade", "", ">=", "Total Credit", "1")

                GvRule.DataSource = table
                GvRule.DataBind()

                table.Clear()
                table.Rows.Add("Overall Grade", "", ">=", "", "2")
                GridView2.DataSource = table
                GridView2.DataBind()

                table.Clear()
                table.Rows.Add("Overall CGPA", "", ">=", "<", "3")
                GridView3.DataSource = table
                GridView3.DataBind()

                table.Clear()
                table.Rows.Add("", "", ">=", "Total Credit", "4")
                GridView4.DataSource = table
                GridView4.DataBind()

                table.Clear()
                table.Rows.Add("", "", ">=", "Total Credit", "5")
                GridView6.DataSource = table
                GridView6.DataBind()

                table.Clear()
                table.Rows.Add("Course Duration(Days)", "", "<=", "Grad Day", "6")
                GridView5.DataSource = table
                GridView5.DataBind()

                table.Clear()
                table.Rows.Add("Total Marks", "", ">=", "<", "7")
                GridView1.DataSource = table
                GridView1.DataBind()
                'Dim txt2 As TextBox = GridView1.Rows(0).FindControl("txtvalue2")
                'txt2.Visible = False


                'Dim ddlsubject As DropDownList
                'ddlsubject = New DropDownList
                'ddlsubject.ID = "ddlsubject"
                'ddlsubject.Width = 200
                'ddlsubject.DataTextField = "Subject_Name"
                'ddlsubject.DataValueField = "Subject_Code"
                'dt = DLRuleGrade.GetSubCombo()
                'ddlsubject.DataSource = dt
                'ddlsubject.DataBind()
                ''End If


                'GvRule.Rows(0).Cells(2).Controls.Add(ddlsubject)
            End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Public Sub check1(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'Dim courseid As Integer = CType(GridView1.FindControl("ddloption"), DropDownList).SelectedValue
            'Dim ddlSizes As DropDownList = DirectCast(sender, DropDownList)
            'Dim ri As RepeaterItem = DirectCast(ddlSizes.Parent, RepeaterItem)

            'lbldummy.Text = ddlSizes.SelectedValue
            'If (RadioButtonList1.SelectedValue = "1") Then

            Dim activeCheckBox As CheckBox = sender
            If (activeCheckBox.Checked) Then
                For Each rows As GridViewRow In GridRun.Rows
                    Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
                    Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
                    If activeCheckBox.Equals(checkbox1) Then
                        checkbox2.Checked = False
                        Exit For
                    End If
                Next
            End If
            'foreach (GridViewRow gvr in GridView1.Rows)
            '{
            '    CheckBox checkBox = ((CheckBox)gvr.FindControl("cbGV"));
            '    checkBox.Checked = checkBox == activeCheckBox;
            '}



            'End If
            'txtGrade.Text = S
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
        End Try
    End Sub
    Public Sub check2(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim activeCheckBox As CheckBox = sender
            If (activeCheckBox.Checked) Then
                For Each rows As GridViewRow In GridRun.Rows
                    Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
                    Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
                    If activeCheckBox.Equals(checkbox2) Then
                        checkbox1.Checked = False
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub
    'Public Sub check3(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView1.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox1) Then
    '                    checkbox2.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub
    'Public Sub check4(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView1.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox2) Then
    '                    checkbox1.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub
    'Public Sub check5(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView2.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox1) Then
    '                    checkbox2.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub
    'Public Sub check6(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView2.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox2) Then
    '                    checkbox1.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub
    'Public Sub check7(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView3.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox1) Then
    '                    checkbox2.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub
    'Public Sub check8(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView3.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox2) Then
    '                    checkbox1.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub
    'Public Sub check9(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView4.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox1) Then
    '                    checkbox2.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub
    'Public Sub check10(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        Dim activeCheckBox As CheckBox = sender
    '        If (activeCheckBox.Checked) Then
    '            For Each rows As GridViewRow In GridView4.Rows
    '                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
    '                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
    '                If activeCheckBox.Equals(checkbox2) Then
    '                    checkbox1.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        lblerror.Text = "Error on Loading Data."
    '        lblcorrect.Text = ""
    '    End Try
    'End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try
            lblcorrect.Text = ""
            lblerror.Text = ""
            Dim AndStr As String = ""
            Dim OrStr As String = ""
            For Each rows As GridViewRow In GridRun.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
                Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
                Dim lblvalue As Label = rows.FindControl("lblRun")
                If checkbox1.Checked = True Then
                    OrStr = OrStr + "," + lblvalue.Text
                End If
                If checkbox2.Checked = True Then
                    AndStr = AndStr + "," + lblvalue.Text
                End If
            Next
            If (AndStr.Length <> 0) Then
                dt = DLRuleGrade.CheckCondition(ddlbatch.SelectedValue, AndStr, OrStr, ddlsemester.SelectedValue)
                If (dt.Rows.Count > 0) Then
                    GridStud.DataSource = dt
                    GridStud.DataBind()
                    lblcorrect.Text = dt.Rows.Count.ToString + " no of records generated."
                Else
                    GridStud.DataSource = Nothing
                    GridStud.DataBind()
                    lblerror.Text = "No records to display."
                End If
                Exit Sub
            ElseIf (OrStr.Length <> 0) Then
                dt = DLRuleGrade.CheckCondition(ddlbatch.SelectedValue, AndStr, OrStr, ddlsemester.SelectedValue)
                If (dt.Rows.Count > 0) Then
                    GridStud.DataSource = dt
                    GridStud.DataBind()
                    lblcorrect.Text = dt.Rows.Count.ToString + " no of records generated."
                Else
                    GridStud.DataSource = Nothing
                    GridStud.DataBind()
                    lblerror.Text = "No records to display."
                End If
            Else
                lblerror.Text = "Select Condition."
            End If
            'If GvRule.Rows.Count > 0 Then
            'For Each rows As GridViewRow In GvRule.Rows
            '    Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
            '    Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
            '    'Dim ddlsubject As DropDownList = rows.FindControl("cmbSubject")
            '    'Dim txt1 As DropDownList = rows.FindControl("cmbGrade")
            '    'Dim txt2 As TextBox = rows.FindControl("txtvalue2")
            '    'SubId = ddlsubject.SelectedValue
            '    'SubText1 = txt1.SelectedValue
            '    'SubText2 = txt2.Text
            '    'If (SubId <> 0) Then
            '    If checkbox1.Checked = True Then
            '        'SubFlag = 1
            '        OrStr = OrStr + ",1"
            '    End If
            '    If checkbox2.Checked = True Then
            '        'SubFlag = 2
            '        'SubFormula = " and , ( SCredit"
            '        AndStr = AndStr + ",1"
            '    End If
            '    'If (ddlsubject.SelectedValue = 0) Then
            '    '    SubFormula = ""
            '    '    Condition1 = 0
            '    'Else
            '    '    SubFormula = SubFormula + " >= " + txt1.SelectedValue + " )"
            '    '    Condition1 = 1
            '    '    Subject = ddlsubject.SelectedValue
            '    'End If
            '    'End If
            'Next
            'For Each rows As GridViewRow In GridView2.Rows
            '    Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
            '    Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
            '    Dim lblvalue As Label = rows.FindControl("lblmval")
            '    If (lblvalue.Text = "2") Then
            '        If checkbox1.Checked = True Then
            '            OrStr = OrStr + ",2"
            '        End If
            '        If checkbox2.Checked = True Then
            '            AndStr = AndStr + ",2"
            '        End If
            '    End If
            'Next
            'For Each rows As GridViewRow In GridView3.Rows
            '    Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
            '    Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
            '    Dim lblvalue As Label = rows.FindControl("lblmval")
            '    If (lblvalue.Text = "3") Then
            '        If checkbox1.Checked = True Then
            '            OrStr = OrStr + ",3"
            '        End If
            '        If checkbox2.Checked = True Then
            '            AndStr = AndStr + ",3"
            '        End If
            '    End If
            'Next
            'For Each rows As GridViewRow In GridView4.Rows
            '    Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
            '    Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
            '    Dim lblvalue As Label = rows.FindControl("lblmval")
            '    If (lblvalue.Text = "4") Then
            '        If checkbox1.Checked = True Then
            '            OrStr = OrStr + ",4"
            '        End If
            '        If checkbox2.Checked = True Then
            '            AndStr = AndStr + ",4"
            '        End If
            '    End If
            '    If (lblvalue.Text = "5") Then
            '        If checkbox1.Checked = True Then
            '            OrStr = OrStr + ",5"
            '        End If
            '        If checkbox2.Checked = True Then
            '            AndStr = AndStr + ",5"
            '        End If
            '    End If
            'Next
            'For Each rows As GridViewRow In GridView1.Rows
            '    Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
            '    Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
            '    Dim lblvalue As Label = rows.FindControl("lblmval")
            '    If (lblvalue.Text = "6") Then
            '        If checkbox1.Checked = True Then
            '            OrStr = OrStr + ",6"
            '        End If
            '        If checkbox2.Checked = True Then
            '            AndStr = AndStr + ",6"
            '        End If
            '    End If
            '    If (lblvalue.Text = "7") Then
            '        If checkbox1.Checked = True Then
            '            OrStr = OrStr + ",7"
            '        End If
            '        If checkbox2.Checked = True Then
            '            AndStr = AndStr + ",7"
            '        End If
            '    End If
            'Next




            '        For Each rows As GridViewRow In GridView1.Rows
            '            Dim checkbox1 As CheckBox = rows.FindControl("ChkBx1")
            '            Dim checkbox2 As CheckBox = rows.FindControl("ChkBx2")
            '            Dim txt1 As TextBox = rows.FindControl("txtvalue1")
            '            Dim txt2 As TextBox = rows.FindControl("txtvalue2")
            '            If (rows.RowIndex = 0) Then
            '                If checkbox1.Checked = True Then
            '                    GPAFlag = 1
            '                    GPAFormula = " or , ( CGPA "
            '                End If
            '                If checkbox2.Checked = True Then
            '                    GPAFlag = 2
            '                    GPAFormula = " and , ( CGPA "
            '                End If
            '                GPAText1 = txt1.Text
            '                GPAText2 = txt2.Text
            '                If (txt1.Text = "" And txt2.Text = "") Then
            '                    GPAFormula = ""
            '                ElseIf (txt1.Text = "" And txt2.Text <> "") Then
            '                    GPAFormula = GPAFormula + "> " + txt2.Text + " )"
            '                ElseIf (txt1.Text <> "" And txt2.Text = "") Then
            '                    GPAFormula = GPAFormula + "<= " + txt1.Text + " )"
            '                ElseIf (txt1.Text <> "" And txt2.Text <> "") Then
            '                    GPAFormula = GPAFormula + "<= " + txt1.Text + " and CGPA > " + txt2.Text + " )"
            '                End If
            '            End If
            '            If (rows.RowIndex = 1) Then
            '                If checkbox1.Checked = True Then
            '                    CreditFlag = 1
            '                    CreditFormula = " or , ( Credit "
            '                End If
            '                If checkbox2.Checked = True Then
            '                    CreditFlag = 2
            '                    CreditFormula = " and  , ( Credit "
            '                End If
            '                CreditText1 = txt1.Text
            '                CreditText2 = txt2.Text

            '                If (txt1.Text = "" And txt2.Text = "") Then
            '                    CreditFormula = ""
            '                ElseIf (txt1.Text = "" And txt2.Text <> "") Then
            '                    CreditFormula = CreditFormula + "> " + txt2.Text + " )"
            '                ElseIf (txt1.Text <> "" And txt2.Text = "") Then
            '                    CreditFormula = CreditFormula + "<= " + txt1.Text + " )"
            '                ElseIf (txt1.Text <> "" And txt2.Text <> "") Then
            '                    CreditFormula = CreditFormula + "<= " + txt1.Text + " and Credit > " + txt2.Text + " )"
            '                End If
            '            End If
            '            If (rows.RowIndex = 2) Then
            '                If checkbox1.Checked = True Then
            '                    MarksFlag = 1
            '                    MarksFormula = " or , ( TotalMarks "
            '                End If
            '                If checkbox2.Checked = True Then
            '                    MarksFlag = 2
            '                    MarksFormula = " and , ( TotalMarks "
            '                End If
            '                MarksText1 = txt1.Text
            '                MarksText2 = txt2.Text

            '                If (txt1.Text = "" And txt2.Text = "") Then
            '                    MarksFormula = ""
            '                ElseIf (txt1.Text = "" And txt2.Text <> "") Then
            '                    MarksFormula = MarksFormula + "> " + txt2.Text + " )"
            '                ElseIf (txt1.Text <> "" And txt2.Text = "") Then
            '                    MarksFormula = MarksFormula + "<= " + txt1.Text + " )"
            '                ElseIf (txt1.Text <> "" And txt2.Text <> "") Then
            '                    MarksFormula = MarksFormula + "<= " + txt1.Text + " and TotalMarks > " + txt2.Text + " )"
            '                End If
            '            End If
            '            If (rows.RowIndex = 3) Then
            '                If checkbox1.Checked = True Then
            '                    CourseFlag = 1
            '                    CourseFormula = " or , ( Duration "
            '                End If
            '                If checkbox2.Checked = True Then
            '                    CourseFlag = 2
            '                    CourseFormula = " and , ( Duration "
            '                End If
            '                CourseText1 = txt1.Text
            '                CourseText2 = txt2.Text
            '                If (txt1.Text = "" And txt2.Text = "") Then
            '                    CourseFormula = ""
            '                ElseIf (txt1.Text = "" And txt2.Text <> "") Then
            '                    CourseFormula = CourseFormula + "> " + txt2.Text + " )"
            '                ElseIf (txt1.Text <> "" And txt2.Text = "") Then
            '                    CourseFormula = CourseFormula + "<= " + txt1.Text + " )"
            '                    Condition2 = 1
            '                    'ElseIf (txt1.Text <> "" And txt2.Text <> "") Then
            '                    '    CourseFormula = CourseFormula + "<= " + txt1.Text + " and Course > " + txt2.Text + " )"
            '                    '    Condition2 = 1
            '                End If
            '            End If
            '        Next
            '        If (SubFormula <> "") Then
            '            Split = SubFormula.Split(",")
            '            If (Trim(Split(0)) = "or") Then
            '                If (OrFormula = "") Then
            '                    OrFormula = Split(1)
            '                Else
            '                    OrFormula = OrFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '            If (Trim(Split(0)) = "and") Then
            '                If (AndFormula = "") Then
            '                    AndFormula = Split(1)
            '                Else
            '                    AndFormula = AndFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '        End If
            '        If (GPAFormula <> "") Then
            '            Split = GPAFormula.Split(",")
            '            If (Trim(Split(0)) = "or") Then
            '                If (OrFormula = "") Then
            '                    OrFormula = Split(1)
            '                Else
            '                    OrFormula = OrFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '            If (Trim(Split(0)) = "and") Then
            '                If (AndFormula = "") Then
            '                    AndFormula = Split(1)
            '                Else
            '                    AndFormula = AndFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '        End If
            '        If (CreditFormula <> "") Then
            '            Split = CreditFormula.Split(",")
            '            If (Trim(Split(0)) = "or") Then
            '                If (OrFormula = "") Then
            '                    OrFormula = Split(1)
            '                Else
            '                    OrFormula = OrFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '            If (Trim(Split(0)) = "and") Then
            '                If (AndFormula = "") Then
            '                    AndFormula = Split(1)
            '                Else
            '                    AndFormula = AndFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '        End If
            '        If (MarksFormula <> "") Then
            '            Split = MarksFormula.Split(",")
            '            If (Trim(Split(0)) = "or") Then
            '                If (OrFormula = "") Then
            '                    OrFormula = Split(1)
            '                Else
            '                    OrFormula = OrFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '            If (Trim(Split(0)) = "and") Then
            '                If (AndFormula = "") Then
            '                    AndFormula = Split(1)
            '                Else
            '                    AndFormula = AndFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '        End If
            '        If (CourseFormula <> "") Then
            '            Split = CourseFormula.Split(",")
            '            If (Trim(Split(0)) = "or") Then
            '                If (OrFormula = "") Then
            '                    OrFormula = Split(1)
            '                Else
            '                    OrFormula = OrFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '            If (Trim(Split(0)) = "and") Then
            '                If (AndFormula = "") Then
            '                    AndFormula = Split(1)
            '                Else
            '                    AndFormula = AndFormula + Split(0) + Split(1)
            '                End If
            '            End If
            '        End If
            '        If (AndFormula = "" And OrFormula = "") Then
            '            MainFormula = ""
            '        ElseIf (AndFormula <> "" And OrFormula = "") Then
            '            MainFormula = "where " + AndFormula
            '        ElseIf (AndFormula = "" And OrFormula <> "") Then
            '            MainFormula = ""
            '        ElseIf (AndFormula <> "" And OrFormula <> "") Then
            '            MainFormula = "where ( " + AndFormula + " ) and ( " + OrFormula + " )"
            '        End If


            '        table = DLRuleGrade.GetStudentData(ddlbatch.SelectedValue, MainFormula, Subject, Condition1, Condition2)

            '    Else
            '        lblerror.Text = "Select Rules for Loading Data."
            '    End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            lblcorrect.Text = ""
            lblerror.Text = ""
            If (GridStud.Rows.Count > 0) Then
                Dim sw As New StringWriter()
                Dim hw As New System.Web.UI.HtmlTextWriter(sw)
                Dim frm As HtmlForm = New HtmlForm()

                Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
                Page.Response.AddHeader("content-disposition", "attachment;filename=Data.xls")
                Page.Response.ContentType = "application/vnd.ms-excel"
                Page.Response.Charset = ""
                Page.EnableViewState = False
                frm.Attributes("runat") = "server"
                Controls.Add(frm)
                frm.Controls.Add(GridStud)
                frm.RenderControl(hw)
                Response.Write(style)
                'Response.Write(sw.ToString())
                Response.Output.Write(style & sw.ToString())
                Response.Flush()
                Response.End()
                lblcorrect.Text = "Records exported successfully."
                lblerror.Text = ""
            Else
                lblcorrect.Text = ""
                lblerror.Text = "No records to Export."
            End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub


    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            lblcorrect.Text = ""
            lblerror.Text = ""
            If ddlcolumn.SelectedItem.ToString = "Division" Then
                For Each rows As GridViewRow In GridStud.Rows
                    Dim LblDiv As Label = rows.FindControl("lbldiv")
                    LblDiv.Text = txtDivision.Text
                Next
            Else
                For Each rows As GridViewRow In GridStud.Rows
                    Dim Lblgrade As Label = rows.FindControl("lblgrade")
                    Lblgrade.Text = txtDivision.Text
                Next
            End If
            lblcorrect.Text = "Results updated successfully in gridview under column " + ddlcolumn.SelectedItem.ToString + " ."
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            lblcorrect.Text = ""
            lblerror.Text = ""
            If GridStud.Rows.Count > 0 Then
                Dim sid As String = ""
                Dim Batch As Integer
                'Dim Sem As Integer
                Dim column As String = ""
                Dim value As String = ""
                For Each rows As GridViewRow In GridStud.Rows
                    Dim Lblgrade As Label = rows.FindControl("lblStdid")
                    sid = sid + Lblgrade.Text + ","
                    'Dim Lblsem As Label = rows.FindControl("lblsemid")
                    'Sem = Lblsem.Text
                Next
                Batch = ddlbatch.SelectedValue
                column = ddlcolumn.SelectedItem.ToString
                value = txtDivision.Text
                DLRuleGrade.UpdateData(Batch, value, column, sid.Substring(0, sid.Length - 1), ddlsemester.SelectedValue)
                lblcorrect.Text = "Records Saved Successfully."
                lblerror.Text = ""
            Else
                lblerror.Text = "No records to Save."
            End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Protected Sub GridStud_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridStud.Sorting
        Try
            Dim sortingDirection As String = String.Empty
            If dir() = SortDirection.Ascending Then
                dir = SortDirection.Descending
                sortingDirection = "Desc"
            Else
                dir = SortDirection.Ascending
                sortingDirection = "Asc"
            End If


            Dim sortedView As New DataView(table)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            GridStud.DataSource = sortedView
            GridStud.DataBind()
            GridStud.Enabled = True
            GridStud.Visible = True
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try

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

    Protected Sub btnRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Try
            lblcorrect.Text = ""
            lblerror.Text = ""
            Dim dtrun As DataTable
            dtrun = ViewState("tabrun")
            Dim str As String = ""
            For Each rows As GridViewRow In GvRule.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx3")
                Dim lblvalue As Label = rows.FindControl("lblmval")
                Dim ddl1 As DropDownList = rows.FindControl("ddlassesment")
                Dim ddl2 As DropDownList = rows.FindControl("cmbGrade")
                Dim ddl3 As DropDownList = rows.FindControl("ddlSubCategory")
                Dim txt1 As TextBox = rows.FindControl("txtvalue2")
                Dim val As Integer
                If checkbox1.Checked Then
                    If (lblvalue.Text = "1") Then
                        str = str + ",1"
                        If (txt1.Text <> "") Then
                            val = CInt(txt1.Text)
                        Else
                            val = 0
                        End If
                        If (ViewState("Run").ToString = "") Then
                            ViewState("Run") = 1
                        Else
                            ViewState("Run") = CInt(ViewState("Run")) + 1
                        End If
                        dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, ddl1.SelectedItem.Text, ddl1.SelectedValue, ddl3.SelectedItem.Text, ddl3.SelectedValue, ddl2.SelectedItem.Text, txt1.Text, "", "")
                        DLRuleGrade.Condition1(ddlbatch.SelectedValue, ddl1.SelectedValue, ddl2.SelectedItem.Text, val, ddlsemester.SelectedValue, ViewState("Run"), ddl3.SelectedValue)
                    End If
                End If
            Next
            For Each rows As GridViewRow In GridView2.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx3")
                Dim lblvalue As Label = rows.FindControl("lblmval")
                Dim ddl1 As DropDownList = rows.FindControl("ddlassesment")
                Dim ddl2 As DropDownList = rows.FindControl("cmbGrade")
                Dim ddl3 As DropDownList = rows.FindControl("ddlSubCategory")
                If checkbox1.Checked Then
                    If (lblvalue.Text = "2") Then
                        str = str + ",2"
                        If (ViewState("Run").ToString = "") Then
                            ViewState("Run") = 1
                        Else
                            ViewState("Run") = CInt(ViewState("Run")) + 1
                        End If
                        dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, ddl1.SelectedItem.Text, ddl1.SelectedValue, "", "", ddl2.SelectedItem.Text, ddl3.SelectedItem.Text, "", ddl3.SelectedValue)
                        DLRuleGrade.Condition2(ddlbatch.SelectedValue, ddl1.SelectedValue, ddl2.SelectedItem.ToString, ddl3.SelectedValue, ddlsemester.SelectedValue, ViewState("Run"))
                    End If
                End If
            Next
            For Each rows As GridViewRow In GridView3.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx3")
                Dim lblvalue As Label = rows.FindControl("lblmval")
                Dim txt1 As TextBox = rows.FindControl("txtvalue1")
                Dim txt2 As TextBox = rows.FindControl("txtvalue2")
                Dim val1 As Double
                Dim val2 As Double
                If checkbox1.Checked Then
                    If (lblvalue.Text = "3") Then
                        str = str + ",3"
                        If (txt1.Text <> "") Then
                            val1 = CDbl(txt1.Text)
                        Else
                            val1 = 0
                        End If
                        If (txt2.Text <> "") Then
                            val2 = CDbl(txt2.Text)
                        Else
                            val2 = 0
                        End If
                        If (ViewState("Run").ToString = "") Then
                            ViewState("Run") = 1
                        Else
                            ViewState("Run") = CInt(ViewState("Run")) + 1
                        End If
                        dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, "", "", "", "", txt1.Text, txt2.Text, "", "")
                        DLRuleGrade.Condition3(ddlbatch.SelectedValue, val1, val2, ddlsemester.SelectedValue, ViewState("Run"))
                    End If
                End If
            Next
            For Each rows As GridViewRow In GridView4.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx3")
                Dim lblvalue As Label = rows.FindControl("lblmval")
                Dim ddl1 As DropDownList = rows.FindControl("ddlassesment")
                Dim ddl2 As DropDownList = rows.FindControl("cmbGrade")
                Dim ddl3 As DropDownList = rows.FindControl("cmbSemester1")
                Dim ddl4 As DropDownList = rows.FindControl("cmbSemester2")
                Dim txt1 As TextBox = rows.FindControl("txtvalue2")
                Dim val As Integer
                If checkbox1.Checked Then
                    If (txt1.Text <> "") Then
                        val = CDbl(txt1.Text)
                    Else
                        val = 0
                    End If
                    If (lblvalue.Text = "4") Then
                        str = str + ",4"
                        If (ViewState("Run").ToString = "") Then
                            ViewState("Run") = 1
                        Else
                            ViewState("Run") = CInt(ViewState("Run")) + 1
                        End If
                        dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, ddl1.SelectedItem.Text, ddl1.SelectedValue, ddl3.SelectedItem.Text, ddl3.SelectedValue, ddl2.SelectedItem.Text, txt1.Text, ddl4.SelectedItem.Text, ddl4.SelectedValue)
                        DLRuleGrade.Condition4(ddlbatch.SelectedValue, ddl1.SelectedValue, ddl2.SelectedItem.Text, val, ddl3.SelectedValue, ddl4.SelectedValue, ddlsemester.SelectedValue, ViewState("Run"))
                    End If
                End If
            Next
            For Each rows As GridViewRow In GridView6.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx3")
                Dim lblvalue As Label = rows.FindControl("lblmval")
                Dim ddl1 As DropDownList = rows.FindControl("ddlassesment")
                Dim ddl2 As DropDownList = rows.FindControl("cmbGrade")
                Dim ddl3 As DropDownList = rows.FindControl("cmbSemester1")
                Dim ddl4 As DropDownList = rows.FindControl("cmbSemester2")
                Dim txt1 As TextBox = rows.FindControl("txtvalue2")
                Dim val As Integer
                If checkbox1.Checked Then
                    If (txt1.Text <> "") Then
                        val = CDbl(txt1.Text)
                    Else
                        val = 0
                    End If
                    If (lblvalue.Text = "5") Then
                        str = str + ",5"
                        If (ViewState("Run").ToString = "") Then
                            ViewState("Run") = 1
                        Else
                            ViewState("Run") = CInt(ViewState("Run")) + 1
                        End If
                        dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, ddl1.SelectedItem.Text, ddl1.SelectedValue, ddl3.SelectedItem.Text, ddl3.SelectedValue, ddl2.SelectedItem.Text, txt1.Text, ddl4.SelectedItem.Text, ddl4.SelectedValue)
                        DLRuleGrade.Condition5(ddlbatch.SelectedValue, ddl1.SelectedValue, ddl2.SelectedItem.ToString, val, ddl3.SelectedValue, ddl4.SelectedValue, ddlsemester.SelectedValue, ViewState("Run"))
                    End If
                End If
            Next

            For Each rows As GridViewRow In GridView5.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx3")
                Dim lblvalue As Label = rows.FindControl("lblmval")
                Dim txt1 As TextBox = rows.FindControl("txtvalue1")
                Dim txt2 As TextBox = rows.FindControl("txtvalue2")
                Dim val1 As Integer
                If checkbox1.Checked Then
                    If (txt1.Text <> "") Then
                        val1 = CDbl(txt1.Text)
                    Else
                        val1 = 0
                    End If
                    Dim val2 As Date
                    If (txt2.Text <> "") Then
                        val2 = Date.ParseExact(txt2.Text, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)

                    Else
                        val2 = Nothing
                    End If
                    If (lblvalue.Text = "6") Then
                        str = str + ",6"
                        If (ViewState("Run").ToString = "") Then
                            ViewState("Run") = 1
                        Else
                            ViewState("Run") = CInt(ViewState("Run")) + 1
                        End If
                        If txt2.Text.Length = 0 Then
                            dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, "", "", "", "", txt1.Text, "", "", "")
                        Else
                            dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, "", "", "", "", txt1.Text, val2.ToString("dd/MM/yyyy"), "", "")
                        End If

                        DLRuleGrade.Condition6(ddlbatch.SelectedValue, val1, ddlsemester.SelectedValue, ViewState("Run"), val2)
                    End If
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                Dim checkbox1 As CheckBox = rows.FindControl("ChkBx3")
                Dim lblvalue As Label = rows.FindControl("lblmval")
                Dim txt1 As TextBox = rows.FindControl("txtvalue1")
                Dim txt2 As TextBox = rows.FindControl("txtvalue2")
                Dim val1 As Integer
                If checkbox1.Checked Then
                    If (txt1.Text <> "") Then
                        val1 = CDbl(txt1.Text)
                    Else
                        val1 = 0
                    End If
                    Dim val2 As Integer
                    If (txt2.Text <> "") Then
                        val2 = CDbl(txt2.Text)
                    Else
                        val2 = 0
                    End If
                    If (lblvalue.Text = "7") Then
                        str = str + ",7"
                        If (ViewState("Run").ToString = "") Then
                            ViewState("Run") = 1
                        Else
                            ViewState("Run") = CInt(ViewState("Run")) + 1
                        End If
                        dtrun.Rows.Add(0, 0, ViewState("Run"), lblvalue.Text, "", "", "", "", txt1.Text, txt2.Text, "", "")
                        DLRuleGrade.Condition7(ddlbatch.SelectedValue, val2, val1, ddlsemester.SelectedValue, ViewState("Run"))
                    End If
                End If
            Next
            lblcorrect.Text = ""
            lblerror.Text = ""
            If (str.Length = 0) Then
                lblerror.Text = "Please Select Condition to Run. "
            Else
                lblcorrect.Text = "Rule " + str.Substring(1, str.Length - 1) + " have run successfully."
            End If


            'dt = DLRuleGrade.CheckCondition(ddlbatch.SelectedValue, str, "", ddlsemester.SelectedValue)
            'If (dt.Rows.Count > 0) Then
            '    GridStud.DataSource = dt
            '    GridStud.DataBind()
            '    lblcorrect.Text = dt.Rows.Count.ToString + " no of records generated."
            'Else
            '    GridStud.DataSource = Nothing
            '    GridStud.DataBind()
            '    lblcorrect.Text = ""
            '    lblerror.Text = "No records to display."
            'End If

            If (dtrun.Rows.Count > 0) Then
                'Div2.visible = True
                panel4.Visible = True
                GridRun.DataSource = dtrun
                GridRun.DataBind()
            End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Protected Sub btnsaveFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsaveFormula.Click
        Try
            lblcorrect.Text = ""
            lblerror.Text = ""
            'Dim Formula As Integer = 1

            If GridRun.Rows.Count > 0 Then
                DLRuleGrade.DeleteRule(ddlformula.SelectedValue)
                For Each rows As GridViewRow In GridRun.Rows
                    Dim AndCheck As CheckBox = rows.FindControl("ChkBx1")
                    Dim OrCheck As CheckBox = rows.FindControl("ChkBx2")
                    Dim Run As Label = rows.FindControl("lblRun")
                    Dim Rules As Label = rows.FindControl("lblRules")
                    Dim Assessment As Label = rows.FindControl("lblAssessment")
                    Dim Assessmentid As Label = rows.FindControl("lblAssessmentid")
                    Dim Options1 As Label = rows.FindControl("lbloptions1")
                    Dim Options1id As Label = rows.FindControl("lbloptions1id")
                    Dim Options2 As Label = rows.FindControl("lbloptions2")
                    Dim Options2id As Label = rows.FindControl("lbloptions2id")
                    Dim Value1 As Label = rows.FindControl("lblval1")
                    Dim Value2 As Label = rows.FindControl("lblval2")
                    Dim Assessmentvalue As String
                    Dim Options1value As String
                    Dim Options2value As String
                    Dim valdate As Date
                    Dim AndValue As Integer = 0
                    If (AndCheck.Checked = True) Then
                        AndValue = 1
                    End If
                    Dim OrValue As Integer = 0
                    If (OrCheck.Checked = True) Then
                        OrValue = 1
                    End If
                    If (Assessment.Text.Length <> 0) Then
                        Assessmentvalue = (Assessment.Text) + "," + (Assessmentid.Text)
                    Else
                        Assessmentvalue = ""
                    End If
                    If (Options1.Text.Length <> 0) Then
                        Options1value = (Options1.Text) + "," + (Options1id.Text)
                    Else
                        Options1value = ""
                    End If
                    If (Options2.Text.Length <> 0) Then
                        Options2value = (Options2.Text) + "," + (Options2id.Text)
                    Else
                        Options2value = ""
                    End If
                    If (Rules.Text = 2) Then
                        DLRuleGrade.SaveRule(AndValue, OrValue, CInt(Rules.Text), CInt(Run.Text), Assessmentvalue, Options1value, Value1.Text, Value2.Text + "," + Options2id.Text, ddlformula.SelectedValue, Options2value)
                    ElseIf (Rules.Text = 6) Then
                        valdate = Date.ParseExact(Value2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy")
                        DLRuleGrade.SaveRule(AndValue, OrValue, CInt(Rules.Text), CInt(Run.Text), Assessmentvalue, Options1value, Value1.Text, valdate.ToString + "," + Options2id.Text, ddlformula.SelectedValue, Options2value)
                    Else
                        DLRuleGrade.SaveRule(AndValue, OrValue, CInt(Rules.Text), CInt(Run.Text), Assessmentvalue, Options1value, Value1.Text, Value2.Text, ddlformula.SelectedValue, Options2value)
                    End If
                Next
                lblcorrect.Text = "Formula Saved Successfully."
                lblerror.Text = ""
            Else
                lblerror.Text = "No records to Save."
            End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Protected Sub btnrun1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrun1.Click
        Try
            lblerror.Text = ""
            lblcorrect.Text = ""
            Dim dt As DataTable
            Dim dtrun As DataTable
            dtrun = ViewState("tabrun")
            Dim Options1() As String
            Dim AndRule As Integer
            Dim OrRule As Integer
            Dim Rule As Integer
            Dim Run As Integer
            Dim Assessment() As String
            Dim Options2() As String
            Dim Value1 As String
            Dim Value2 As String
            Dim val() As String
            'If (ViewState("Run").ToString = "") Then
            '    ViewState("Run") = 1
            'Else
            '    ViewState("Run") = CInt(ViewState("Run")) + 1
            'End If
            clear()
            dt = DLRuleGrade.GetRule(ddlformula.SelectedValue)
            If (dt.Rows.Count > 0) Then
                For Each row As DataRow In dt.Rows
                    Rule = row("RuleNo")
                    Run = row("RunNo")
                    AndRule = row("AndFormula")
                    OrRule = row("OrFormula")
                    Options1 = row("Options1").ToString.Split(",")
                    Assessment = row("AssessmentID").ToString.Split(",")
                    Options2 = row("Options2").ToString.Split(",")
                    Value1 = row("Value1")
                    Value2 = row("Value2")
                    If (Value2 Is DBNull.Value) Then
                        Value2 = 0
                    End If
                    If (Value2 = "") Then
                        Value2 = 0
                    End If
                    If (Value1 = "") Then
                        Value1 = 0
                    End If
                    If (Rule = 1) Then
                        dtrun.Rows.Add(AndRule, OrRule, Run, Rule, Assessment(0), Assessment(1), Options1(0), Options1(1), Value1, Value2, "", "")
                        DLRuleGrade.Condition1(ddlbatch.SelectedValue, Assessment(1), Value1, Value2, ddlsemester.SelectedValue, Run, Options1(1))
                    ElseIf (Rule = 2) Then
                        val = Value2.Split(",")
                        '(ByVal Batch As Integer, ByVal Assessment As Integer, ByVal Grade As String, ByVal SubCategory As Integer, ByVal Semester As Integer, ByVal Run As String)
                        dtrun.Rows.Add(AndRule, OrRule, Run, Rule, Assessment(0), Assessment(1), "", "", Value1, val(0), "", val(1))
                        DLRuleGrade.Condition2(ddlbatch.SelectedValue, Assessment(1), Value1, val(1), ddlsemester.SelectedValue, Run)
                    ElseIf (Rule = 3) Then
                        dtrun.Rows.Add(AndRule, OrRule, Run, Rule, "", "", "", "", Value1, Value2, "", "")
                        DLRuleGrade.Condition3(ddlbatch.SelectedValue, Value1, Value2, ddlsemester.SelectedValue, Run)
                    ElseIf (Rule = 4) Then
                        dtrun.Rows.Add(AndRule, OrRule, Run, Rule, Assessment(0), Assessment(1), Options1(0), Options1(1), Value1, Value2, Options2(0), Options2(1))
                        DLRuleGrade.Condition4(ddlbatch.SelectedValue, Assessment(1), Value1, Value2, Options1(1), Options2(1), ddlsemester.SelectedValue, Run)
                    ElseIf (Rule = 5) Then
                        dtrun.Rows.Add(AndRule, OrRule, Run, Rule, Assessment(0), Assessment(1), Options1(0), Options1(1), Value1, Value2, Options2(0), Options2(1))
                        DLRuleGrade.Condition5(ddlbatch.SelectedValue, Assessment(1), Value1, Value2, Options1(1), Options2(1), ddlsemester.SelectedValue, Run)
                    ElseIf (Rule = 6) Then
                        If (Value2 = "0") Then
                            Value2 = ""
                        ElseIf (Value2 <> "") Then
                            Value2 = Date.Parse(Value2, CultureInfo.InvariantCulture)
                            'Value2 = Format(Value2, "dd/MM/yyyy")
                        End If
                        'If (Value2 <> "") Then
                        '    Value2 = Date.ParseExact(Value2, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                        'End If
                        dtrun.Rows.Add(AndRule, OrRule, Run, Rule, "", "", "", "", Value1, Value2, "", "")
                        If (Value2 = "") Then
                            Value2 = "1/1/3000"
                        End If
                        DLRuleGrade.Condition6(ddlbatch.SelectedValue, Value1, ddlsemester.SelectedValue, Run, Value2)
                    ElseIf (Rule = 7) Then
                        dtrun.Rows.Add(AndRule, OrRule, Run, Rule, "", "", "", "", Value1, Value2, "", "")
                        DLRuleGrade.Condition7(ddlbatch.SelectedValue, Value1, Value2, ddlsemester.SelectedValue, Run)
                    End If
                Next row
                If (dtrun.Rows.Count > 0) Then
                    'Div2.visible = True
                    panel4.Visible = True
                    GridRun.DataSource = dtrun
                    GridRun.DataBind()
                End If
                lblcorrect.Text = ddlformula.SelectedItem.Text + " Rules Run Sucessfully."
            Else
                lblerror.Text = "No records."
            End If
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub

    Public Sub clear()
        Try
            lblcorrect.Text = ""
            lblerror.Text = ""
            Dim rows As Integer
            'panel1.Visible = True
            'Dim table1 As New DataTable
            'table1.Columns.Add("Options")
            'table1.Columns.Add("Criteria1")
            'table1.Columns.Add("Criteria2")

            'table1.Rows.Add("Overall GPA", "<=", ">")
            'table1.Rows.Add("Total Credit Point", "<=", ">")
            'table1.Rows.Add("Total Marks", "<=", ">")
            'table1.Rows.Add("Course Duration", "<=", "Days")

            'GridView1.DataSource = table1
            'GridView1.DataBind()

            'Dim table As New DataTable
            'table.Columns.Add("Criteria1")
            'table.Columns.Add("Criteria2")

            'table.Rows.Add(">=", "Grade")

            'GvRule.DataSource = table
            'GvRule.DataBind()

            'GridStud.DataSource = Nothing
            'GridStud.DataBind()
            'Dim txt2 As TextBox = GridView1.Rows(3).FindControl("txtvalue2")
            'txt2.Enabled = False
            rows = DLRuleGrade.ClearCondition(ddlbatch.SelectedValue, ddlsemester.SelectedValue)
            If (rows > 0) Then
                lblcorrect.Text = "Rules are cleared successfully."
            Else
                lblerror.Text = "No records to clear."
            End If
            Dim tabrun As New DataTable
            tabrun.Columns.Add("Check1")
            tabrun.Columns.Add("Check2")
            tabrun.Columns.Add("Run")
            tabrun.Columns.Add("Rule")
            tabrun.Columns.Add("Assessment")
            tabrun.Columns.Add("Assessmentid")
            tabrun.Columns.Add("Options1")
            tabrun.Columns.Add("Options1id")
            tabrun.Columns.Add("Value1")
            tabrun.Columns.Add("Value2")
            tabrun.Columns.Add("Options2")
            tabrun.Columns.Add("Options2id")
            panel4.Visible = False
            ViewState("tabrun") = tabrun
            GridRun.DataSource = tabrun
            GridRun.DataBind()
            GridStud.DataSource = Nothing
            GridStud.DataBind()
            ViewState("Run") = ""
        Catch ex As Exception
            lblerror.Text = "Error on Loading Data."
            lblcorrect.Text = ""
        End Try
    End Sub
End Class
