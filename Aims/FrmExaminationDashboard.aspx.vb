Imports System.Data.OleDb
Imports System.Data
Imports System.Web.UI.DataVisualization.Charting
Partial Class FrmExaminationDashboard
    Inherits BasePage
    Dim dl As New DLBatchReportCardElect
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Then
            ErrMsg.Text = "Select All Mandatory Fields."
            lblmsg.Text = ""

        Else

            Try
                lblmsg.Text = ""
                ErrMsg.Text = ""
                Dim dt As New DataTable
                Dim Sem, Subj, AType, RBMarks As Integer
                Dim Frm1, Frm2, Frm3, Frm4, To1, To2, To3, To4 As Integer
                Dim Batch As String

                Batch = ddlbatch.SelectedValue
                Sem = ddlsemester.SelectedValue
                Subj = ddlsubject.SelectedValue
                AType = ddlassesment.SelectedValue
                RBMarks = RBMarks1.SelectedValue
                If TxtFrm1.Text = "" Then
                    Frm1 = 0
                Else
                    Frm1 = TxtFrm1.Text
                End If
                If TxtFrm2.Text = "" Then
                    Frm2 = 0
                Else
                    Frm2 = TxtFrm2.Text
                End If
                If TxtFrm3.Text = "" Then
                    Frm3 = 0
                Else
                    Frm3 = TxtFrm3.Text
                End If
                If TxtFrm4.Text = "" Then
                    Frm4 = 0
                Else
                    Frm4 = TxtFrm4.Text
                End If
                If TxtTo1.Text = "" Then
                    To1 = 0
                Else
                    To1 = TxtTo1.Text
                End If
                If TxtTo2.Text = "" Then
                    To2 = 0
                Else
                    To2 = TxtTo2.Text
                End If
                If TxtTo3.Text = "" Then
                    To3 = 0
                Else
                    To3 = TxtTo3.Text
                End If
                If TxtTo4.Text = "" Then
                    To4 = 0
                Else
                    To4 = TxtTo4.Text
                End If



                dt = dl.ExamDashboard(Batch, Sem, AType, Subj, Frm1, Frm2, Frm3, Frm4, To1, To2, To3, To4, RBMarks)
                If dt.Rows.Count = 0 Then
                    ErrMsg.Text = "No Records To Display."
                    lblmsg.Text = ""

                Else
                    lblmsg.Text = ""
                    Chart1.Series("Series1").YValueMembers = "StudCnt"
                    Chart1.Series("Series1").XValueMember = "StudRange"

                    Chart1.DataSource = dt
                    Chart1.DataBind()

                    Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -90
                    Chart1.ChartAreas(0).AxisX.Interval = 1

                    Chart1.Visible = True
                    Chart1.Series("Series1").IsValueShownAsLabel = "True"
                End If

            Catch ex As Exception
                ErrMsg.Text = "Enter Correct date."
            End Try
        End If
    End Sub
    Private Sub Chart1_Customize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart1.Customize
        For Each dp As DataPoint In Chart1.Series("Series1").Points
            dp.Color = Drawing.Color.Maroon
        Next

    End Sub
    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
