Imports System.IO
Partial Class frmSemesterResultAnalysis
    Inherits BasePage
    Dim Dl As New DLSemesterResultAnalysis
    Protected Sub btngenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerate.Click
        Try
            'lblRed.Text = ""
            'lblGreen.Text = ""
            Dim dt As New DataTable
            dt = Dl.GetReportData(0, ddlbatch.SelectedValue, ddlsemester.SelectedValue, ddlassesment.SelectedValue)
            If dt.Rows.Count > 0 Then
                GrdSemResAna.DataSource = dt
                GrdSemResAna.DataBind()
                GrdSemResAna.Columns(4).HeaderText = ""
                GrdSemResAna.Columns(5).HeaderText = ""
                GrdSemResAna.Columns(6).HeaderText = ""
                GrdSemResAna.Columns(7).HeaderText = ""
                GrdSemResAna.Columns(8).HeaderText = ""
                GrdSemResAna.Columns(9).HeaderText = ""
                GrdSemResAna.Columns(10).HeaderText = ""
                GrdSemResAna.Columns(11).HeaderText = ""
                GrdSemResAna.Columns(12).HeaderText = ""
                GrdSemResAna.Columns(13).HeaderText = ""

                If dt.Rows(0).Item("Grade1").ToString = "" And dt.Rows(0).Item("Grade1").ToString = "0" Then
                    GrdSemResAna.Columns(4).Visible = False
                Else
                    If dt.Rows(0).Item("Grade11").ToString <> "" Then
                        GrdSemResAna.Columns(4).HeaderText = ""
                        GrdSemResAna.Columns(4).HeaderText = "% of " + dt.Rows(0).Item("Grade11").ToString
                        GrdSemResAna.Columns(4).Visible = True

                    Else
                        GrdSemResAna.Columns(4).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade2").ToString = "" And dt.Rows(0).Item("Grade2").ToString = "0" Then
                    GrdSemResAna.Columns(5).Visible = False
                Else
                    If dt.Rows(0).Item("Grade12").ToString <> "" Then
                        GrdSemResAna.Columns(5).HeaderText = ""
                        GrdSemResAna.Columns(5).HeaderText = "% of " + dt.Rows(0).Item("Grade12").ToString
                        GrdSemResAna.Columns(5).Visible = True
                    Else
                        GrdSemResAna.Columns(5).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade3").ToString = "" And dt.Rows(0).Item("Grade3").ToString = "0" Then
                    GrdSemResAna.Columns(6).Visible = False
                Else
                    If dt.Rows(0).Item("Grade13").ToString <> "" Then
                        GrdSemResAna.Columns(6).HeaderText = ""
                        GrdSemResAna.Columns(6).HeaderText = "% of " + dt.Rows(0).Item("Grade13").ToString
                        GrdSemResAna.Columns(6).Visible = True
                    Else
                        GrdSemResAna.Columns(6).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade4").ToString = "" And dt.Rows(0).Item("Grade4").ToString = "0" Then
                    GrdSemResAna.Columns(7).Visible = False
                Else
                    If dt.Rows(0).Item("Grade14").ToString <> "" Then
                        GrdSemResAna.Columns(7).HeaderText = ""
                        GrdSemResAna.Columns(7).HeaderText = "% of " + dt.Rows(0).Item("Grade14").ToString
                        GrdSemResAna.Columns(7).Visible = True
                    Else
                        GrdSemResAna.Columns(7).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade5").ToString = "" And dt.Rows(0).Item("Grade5").ToString = "0" Then
                    GrdSemResAna.Columns(8).Visible = False
                Else
                    If dt.Rows(0).Item("Grade15").ToString <> "" Then
                        GrdSemResAna.Columns(8).HeaderText = ""
                        GrdSemResAna.Columns(8).HeaderText = "% of " + dt.Rows(0).Item("Grade15").ToString
                        GrdSemResAna.Columns(8).Visible = True
                    Else
                        GrdSemResAna.Columns(8).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade6").ToString = "" And dt.Rows(0).Item("Grade6").ToString = "0" Then
                    GrdSemResAna.Columns(9).Visible = False
                Else
                    If dt.Rows(0).Item("Grade16").ToString <> "" Then
                        GrdSemResAna.Columns(9).HeaderText = ""
                        GrdSemResAna.Columns(9).HeaderText = "% of " + dt.Rows(0).Item("Grade16").ToString
                        GrdSemResAna.Columns(9).Visible = True
                    Else
                        GrdSemResAna.Columns(9).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade7").ToString = "" And dt.Rows(0).Item("Grade7").ToString = "0" Then
                    GrdSemResAna.Columns(10).Visible = False
                Else
                    If dt.Rows(0).Item("Grade17").ToString <> "" Then
                        GrdSemResAna.Columns(10).HeaderText = ""
                        GrdSemResAna.Columns(10).HeaderText = "% of " + dt.Rows(0).Item("Grade17").ToString
                        GrdSemResAna.Columns(10).Visible = True
                    Else
                        GrdSemResAna.Columns(10).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade8").ToString = "" And dt.Rows(0).Item("Grade8").ToString = "0" Then
                    GrdSemResAna.Columns(11).Visible = False
                Else
                    If dt.Rows(0).Item("Grade18").ToString <> "" Then
                        GrdSemResAna.Columns(11).HeaderText = ""
                        GrdSemResAna.Columns(11).HeaderText = "% of " + dt.Rows(0).Item("Grade18").ToString
                        GrdSemResAna.Columns(11).Visible = True
                    Else
                        GrdSemResAna.Columns(11).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade9").ToString = "" And dt.Rows(0).Item("Grade9").ToString = "0" Then
                    GrdSemResAna.Columns(12).Visible = False
                Else
                    If dt.Rows(0).Item("Grade19").ToString <> "" Then
                        GrdSemResAna.Columns(12).HeaderText = ""
                        GrdSemResAna.Columns(12).HeaderText = "% of " + dt.Rows(0).Item("Grade19").ToString
                        GrdSemResAna.Columns(12).Visible = True
                    Else
                        GrdSemResAna.Columns(12).Visible = False
                    End If
                End If

                If dt.Rows(0).Item("Grade10").ToString = "" And dt.Rows(0).Item("Grade10").ToString = "0" Then
                    GrdSemResAna.Columns(13).Visible = False
                Else
                    If dt.Rows(0).Item("Grade20").ToString <> "" Then
                        GrdSemResAna.Columns(13).HeaderText = ""
                        GrdSemResAna.Columns(13).HeaderText = "% of " + dt.Rows(0).Item("Grade20").ToString
                        GrdSemResAna.Columns(13).Visible = True
                    Else
                        GrdSemResAna.Columns(13).Visible = False
                    End If
                End If
                GrdSemResAna.Visible = True
                panel1.Visible = True
                lblRed.Text = ""
                lblGreen.Text = dt.Rows.Count.ToString + " records are generated successfully."
                panel1.Visible = True
                GrdSemResAna.DataBind()
                lblttlappearedAns.Text = dt.Rows(0).Item("AppearedStudents").ToString
                lblttlpassans.Text = dt.Rows(0).Item("PassCount").ToString
                lbloverallpassans.Text = dt.Rows(0).Item("PassPercent").ToString
                lblhighestttl.Text = dt.Rows(0).Item("MaxMarksTotal").ToString + " (" + dt.Rows(0).Item("MaxMarksPercent").ToString + "%)</br>(" + dt.Rows(0).Item("StdName").ToString + ")"
                

            Else
                lblRed.Text = "No records to display."
                GrdSemResAna.Visible = False
                panel1.Visible = False
                lblGreen.Text = ""
            End If
        Catch ex As Exception
            lblRed.Text = "Error in Data."
            lblGreen.Text = ""
            GrdSemResAna.Visible = False
            panel1.Visible = False
        End Try
    End Sub

    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.Clear()
        Response.ClearHeaders()
        Response.ClearContent()
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254")
        Response.Charset = "windows-1254"

        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=SemesterResult.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GrdSemResAna.Parent.Controls.Add(frm)
        frm.Controls.Add(GrdSemResAna)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub

    Protected Sub GrdSemResAna_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdSemResAna.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As DataTable
        dt = Dl.GetReportData(0, ddlbatch.SelectedValue, ddlsemester.SelectedValue, ddlassesment.SelectedValue)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GrdSemResAna.DataSource = sortedView
        GrdSemResAna.DataBind()
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

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlbatch.Focus()
        End If
    End Sub

    Protected Sub ddlassesment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.TextChanged
        ddlassesment.Focus()
    End Sub

    Protected Sub ddlbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.TextChanged
        ddlbatch.Focus()
    End Sub

    Protected Sub ddlsemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsemester.TextChanged
        ddlsemester.Focus()
    End Sub
End Class
