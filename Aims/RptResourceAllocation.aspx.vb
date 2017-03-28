
Partial Class RptResourceAllocation
    Inherits BasePage
    Dim dl As New DLExamResources
    Dim dt As New DataTable

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        Dim RType As String
        Dim Rname As Integer
        Dim StartTime As DateTime
        Dim EndDate As DateTime
        Dim Resource As String
        Dim Day As Integer
        RType = ddlResType.SelectedValue
        Rname = ddlResName.SelectedValue
        dt = dl.GetGridDataRes(RType, Rname)
        If dt.Rows.Count = 0 Then
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GVResourceAllc.Visible = False

        Else
            GVResourceAllc.DataSource = dt
            GVResourceAllc.DataBind()
            GVResourceAllc.Visible = True
            Day = 1
            For Each grid As GridViewRow In GVResourceAllc.Rows
                StartTime = CDate(CDate("1/1/1901") + " " + "07:00")

                EndDate = CDate(CDate("1/1/1901") + " " + "07:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl1"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl1"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl1"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "07:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "08:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl2"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl2"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl2"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "08:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "08:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl3"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl3"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl3"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "08:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "09:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl4"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl4"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl4"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "09:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "09:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl5"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl5"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl5"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "09:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "10:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl6"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl6"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl6"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "10:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "10:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl7"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl7"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl7"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "10:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "11:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl8"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl8"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl8"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "11:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "11:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl9"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl9"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl9"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "11:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "12:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl10"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl10"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl10"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "12:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "12:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl11"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl11"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl11"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "12:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "13:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl12"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl12"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl12"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "13:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "13:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl13"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl13"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl13"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "13:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "14:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl14"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl14"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl14"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "14:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "14:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl15"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl15"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl15"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "14:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "15:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl16"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl16"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl16"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "15:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "15:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl17"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl17"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl17"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "15:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "16:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl18"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl18"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl18"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "16:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "16:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl19"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl19"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl19"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "16:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "17:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl20"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl20"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl20"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "17:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "17:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl21"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl21"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl21"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "17:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "18:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl22"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl22"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl22"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "18:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "18:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl23"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl23"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl23"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "18:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "19:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl24"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl24"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl24"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "19:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "19:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl25"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl25"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl25"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "19:30")
                EndDate = CDate(CDate("1/1/1901") + " " + "20:00")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl26"), Label).Text = dt.Rows(0).Item("ResourceId")
                    CType(grid.FindControl("lbl26"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl26"), Label).ForeColor = Drawing.Color.Red
                End If
                StartTime = CDate(CDate("1/1/1901") + " " + "20:00")
                EndDate = CDate(CDate("1/1/1901") + " " + "20:30")

                dt = dl.getdata(StartTime, EndDate, Day, Rname)
                If dt.Rows.Count > 0 Then
                    CType(grid.FindControl("lbl27"), Label).Text = dt.Rows(0).Item("ResourceId")

                    CType(grid.FindControl("lbl27"), Label).BackColor = Drawing.Color.Red
                    CType(grid.FindControl("lbl27"), Label).ForeColor = Drawing.Color.Red
                End If
                Day = Day + 1
            Next
        End If


    End Sub
End Class
