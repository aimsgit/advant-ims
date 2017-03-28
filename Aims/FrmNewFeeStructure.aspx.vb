
Partial Class FrmNewFeeStructure
    'Author Anchala Verma 24-Apr-2014
    Inherits BasePage
    Dim BAL As New feeStructureBL
    Dim f As New feeStructureE
    Dim DLL As New feeStructureDL
    Dim Dl As New DLFeeStructDup
    Dim Bl As New BLFeeStructDup
    Dim dt, dt1 As New DataTable

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click

        If BtnDetails.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            display()
        ElseIf BtnDetails.Text = "BACK" Then
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            display()
        End If
    End Sub
    Sub display()
        lblmsg.Text = ""
        msginfo.Text = ""

        Dim b As New CreateBatch
        dt = BAL.GetRecordNew(f)
        dt1 = BAL.GetCategoryGrid(f)
        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            GVCategory.DataSource = dt1
            GVCategory.DataBind()
            GVCategory.Visible = True
            GVCategory.Enabled = True
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            GridView1.Visible = False
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If ListAcademic.SelectedValue = "" Then
            msginfo.Text = "Academic Year field is Mandatory."
            Exit Sub
        End If
        If ListBatch.SelectedValue = "" Then
            msginfo.Text = "Batch field is Mandatory."
            Exit Sub
        End If
        Dim str As String = ""
        Dim id As String = ""
        Dim items As ListItem
        Dim c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15 As Integer
        f.AcademicYear_id = ListAcademic.SelectedValue
        If txtDueDate.Text = "__-___-____" Then
            msginfo.Text = "Due Date field is Mandatory."
            lblmsg.Text = ""
            Exit Sub
        Else
            f.DueDate = txtDueDate.Text
        End If
        Dim i1 As Integer
        For Each items In ListBatch.Items
            If (ListBatch.Items(i1).Selected = True) Then
                f.batchID = ListBatch.Items(i1).Value
                Dim duplicate As New DataTable
                duplicate = Bl.GetDuplicateNew(f)
                If duplicate.Rows.Count > 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Data already Exists."
                    Exit Sub
                End If

            End If
            i1 = i1 + 1
        Next
        For Each Grid As GridViewRow In GVCategory.Rows
            c1 = CType(Grid.FindControl("ddlcat1"), DropDownList).SelectedValue
            c2 = CType(Grid.FindControl("ddlcat2"), DropDownList).SelectedValue
            c3 = CType(Grid.FindControl("ddlcat3"), DropDownList).SelectedValue
            c4 = CType(Grid.FindControl("ddlcat4"), DropDownList).SelectedValue
            c5 = CType(Grid.FindControl("ddlcat5"), DropDownList).SelectedValue
            c6 = CType(Grid.FindControl("ddlcat6"), DropDownList).SelectedValue
            c7 = CType(Grid.FindControl("ddlcat7"), DropDownList).SelectedValue
            c8 = CType(Grid.FindControl("ddlcat8"), DropDownList).SelectedValue
            c9 = CType(Grid.FindControl("ddlcat9"), DropDownList).SelectedValue
            c10 = CType(Grid.FindControl("ddlcat10"), DropDownList).SelectedValue
            c11 = CType(Grid.FindControl("ddlcat11"), DropDownList).SelectedValue
            c12 = CType(Grid.FindControl("ddlcat12"), DropDownList).SelectedValue
            c13 = CType(Grid.FindControl("ddlcat13"), DropDownList).SelectedValue
            c14 = CType(Grid.FindControl("ddlcat14"), DropDownList).SelectedValue
            c15 = CType(Grid.FindControl("ddlcat15"), DropDownList).SelectedValue
        Next
        f.Semester_ID = 0
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBatch.Items.Count - 1
        For Each items In ListBatch.Items
            If (ListBatch.Items(i).Selected = True) Then
                f.batchID = ListBatch.Items(i).Value

                'Dim duplicate As New DataTable
                'duplicate = Bl.GetDuplicateNew(f)
                'If duplicate.Rows.Count > 0 Then
                '    lblmsg.Text = ""
                '    msginfo.Text = "Data already Exists."
                '    Exit Sub
                'End If
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee1"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee1"), TextBox).Text
                    End If

                    f.CategoryID = c1
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee2"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee2"), TextBox).Text
                    End If
                    f.CategoryID = c2
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee3"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee3"), TextBox).Text
                    End If
                    f.CategoryID = c3
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee4"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee4"), TextBox).Text
                    End If
                    f.CategoryID = c4
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee5"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee5"), TextBox).Text
                    End If
                    f.CategoryID = c5
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee6"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee6"), TextBox).Text
                    End If
                    f.CategoryID = c6
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee7"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee7"), TextBox).Text
                    End If
                    f.CategoryID = c7
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee8"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee8"), TextBox).Text
                    End If
                    f.CategoryID = c8
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee9"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee9"), TextBox).Text
                    End If
                    f.CategoryID = c9
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee10"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee10"), TextBox).Text
                    End If
                    f.CategoryID = c10
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee11"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee11"), TextBox).Text
                    End If
                    f.CategoryID = c11
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee12"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee12"), TextBox).Text
                    End If
                    f.CategoryID = c12
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee13"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee13"), TextBox).Text
                    End If
                    f.CategoryID = c13
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee14"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee14"), TextBox).Text
                    End If
                    f.CategoryID = c14
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next
                For Each Grid As GridViewRow In GridView1.Rows
                    f.Feehead_ID = CType(Grid.FindControl("ddlfee_head"), DropDownList).SelectedValue
                    If CType(Grid.FindControl("txtFee15"), TextBox).Text = "" Then
                        f.Amount = 0
                    Else
                        f.Amount = CType(Grid.FindControl("txtFee15"), TextBox).Text
                    End If
                    f.CategoryID = c15
                    If f.Feehead_ID <> 0 And f.Amount <> 0 And f.CategoryID <> 0 Then
                        BAL.InsertRecord(f)
                    End If
                Next

            End If
            i = i + 1
        Next

        lblmsg.Text = "Fee Structure Saved Successfully."
        msginfo.Text = ""
    End Sub

    Protected Sub BtnSelectBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSelectBranch.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        If ListAcademic.SelectedValue = "" Then
            msginfo.Text = "Academic Year field is Mandatory."
            Exit Sub
        Else
            Dim str As String = ""
            Dim id As String = ""
            Dim items As ListItem
            Dim i As Integer
            Dim j As Integer
            i = 0
            j = ListAcademic.Items.Count - 1

            For Each items In ListAcademic.Items

                If (ListAcademic.Items(i).Selected = True) Then
                    str = ListAcademic.Items(i).Value
                    f.AYearid = str + "," + f.AYearid
                End If
                i = i + 1
            Next
        End If
        If ListCourseType.SelectedValue = "" Then
            f.CourseTypeid = 0
        Else

            Dim str As String = ""
            Dim id As String = ""
            Dim items As ListItem
            Dim i As Integer
            Dim j As Integer
            i = 0
            j = ListCourseType.Items.Count - 1
            For Each items In ListCourseType.Items

                If (ListCourseType.Items(i).Selected = True) Then
                    str = ListCourseType.Items(i).Value
                    f.CourseTypeid = str + "," + f.CourseTypeid
                End If
                i = i + 1
            Next
        End If
        If ListCourseName.SelectedValue = "" Then
            f.Course = 0
        Else
            Dim str As String = ""
            Dim id As String = ""
            Dim items As ListItem
            Dim i As Integer
            Dim j As Integer
            i = 0
            j = ListCourseName.Items.Count - 1

            For Each items In ListCourseName.Items

                If (ListCourseName.Items(i).Selected = True) Then
                    str = ListCourseName.Items(i).Value
                    f.Course = str + "," + f.Course
                End If
                i = i + 1
            Next
        End If
        'If ListCourseName.SelectedValue = "" Then
        '    f.Course = 0
        'Else
        '    f.Course = ListCourseName.SelectedValue
        'End If
        dt = BAL.batchList(f)
        ListBatch.DataSource = dt
        ListBatch.DataBind()
        ListBatch.Visible = True
        ListBatch.DataTextField = "Batch_No"
        ListBatch.Focus()
        Dim items1 As ListItem
        Dim i1 As Integer
        i1 = 0
        Dim j1 As Integer
        j1 = ListBatch.Items.Count - 1
        If ListBatch.Items.Count <> 0 Then
            For Each items1 In ListBatch.Items
                ListBatch.Items(i1).Selected = True
                i1 = i1 + 1
            Next
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            f.AYearid = 0
            f.CourseTypeid = 0
            f.Course = 0
            dt = BAL.batchList(f)
            ListBatch.DataSource = dt
            ListBatch.DataBind()
            ListBatch.Visible = True
            ListBatch.DataTextField = "Batch_No"
            ListBatch.Focus()
            display()
        End If
    End Sub

    Protected Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        If ListAcademic.SelectedValue = "" Then
            msginfo.Text = "Academic Year field is Mandatory."
            Exit Sub
        Else
            Dim str As String = ""
            Dim id As String = ""
            Dim items As ListItem
            Dim i As Integer
            Dim j As Integer
            i = 0
            j = ListAcademic.Items.Count - 1

            For Each items In ListAcademic.Items

                If (ListAcademic.Items(i).Selected = True) Then
                    str = ListAcademic.Items(i).Value
                    f.AYearid = str + "," + f.AYearid
                End If
                i = i + 1
            Next
        End If
        If ListBatch.SelectedValue = "" Then
            msginfo.Text = "Batch field is Mandatory."
            Exit Sub
        Else
            Dim str As String = ""
            Dim id As String = ""
            Dim items As ListItem
            Dim i As Integer
            Dim j As Integer
            i = 0
            j = ListBatch.Items.Count - 1

            For Each items In ListBatch.Items

                If (ListBatch.Items(i).Selected = True) Then
                    str = ListBatch.Items(i).Value
                    f.batchNo = str + "," + f.batchNo
                End If
                i = i + 1
            Next
        End If
        BAL.DeleteRecordNew(f)
        lblmsg.Text = "Fee Structure cleared Successfully."
        msginfo.Text = ""
    End Sub

    Protected Sub BtnClearGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClearGrid.Click
        display()
        
    End Sub
End Class
