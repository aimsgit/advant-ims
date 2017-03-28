
Partial Class FrmPrincipalDashboard
    Inherits BasePage
    Dim DL As New DLPrincipalDashboard
    Dim male, female, total As New Integer


    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        GVManagementDB.Visible = True
        DisplayGridView()
    End Sub
    Sub DisplayGridView()
        LinkButton1.Focus()
        Try
            Dim dt As New DataTable
            Dim academic As Int16
            Dim course As Int16
            Dim stdcategory As Int16
            academic = cmbAcademic.SelectedValue
            course = ddlCourse.SelectedValue
            stdcategory = ddlcategry.SelectedValue
            dt = DL.PrincipalDashboard(academic, course, stdcategory)
            If dt.Rows.Count = 0 Then
                GVManagementDB.DataSource = Nothing
                GVManagementDB.DataBind()
                lblE.Text = "No records to display."
                'Lblmale.Visible = False
                'Lblfemale.Visible = False
                'lblGrandTotal.Visible = False
                'LblTotal.Visible = False
                lblTotEmpCount.Visible = False
                lblstaff.Visible = False
                lblvisit.Visible = False
            Else
                Dim TotEmpCount, TotTeachingStaff, TotNonTeachingStaff, TotFullTimeStaff, TotPartTimeStaff, VisingEmp, HonoraryEmp As String
                TotEmpCount = dt.Rows(0).Item("TotEmpCount")
                TotTeachingStaff = dt.Rows(0).Item("TeachingStaff")
                TotNonTeachingStaff = dt.Rows(0).Item("NonTeachingStaff")
                TotFullTimeStaff = dt.Rows(0).Item("FullTimeEmp")
                TotPartTimeStaff = dt.Rows(0).Item("PartTimeEmp")
                VisingEmp = dt.Rows(0).Item("VisitingEmp")
                HonoraryEmp = dt.Rows(0).Item("HonoraryEmp")
                'If dt.Rows(0).Item("Approvedby").ToString <> "".ToString Then
                '    Label4.Text = ""
                'Else
                Label4.Text = dt.Rows(0).Item("Approvedby").ToString
                'End If

                'If dt.Rows(0).Item("AffiliatedTo") <> "" Then
                Label5.Text = dt.Rows(0).Item("AffiliatedTo").ToString

                'End If
                'If dt.Rows(0).Item("Accredited") <> "" Then
                Label6.Text = dt.Rows(0).Item("Accredited").ToString
                'End If

                If TotEmpCount = "" Then
                    TotEmpCount = 0
                Else
                    TotEmpCount = dt.Rows(0).Item("TotEmpCount")
                End If

                lblE.Text = ""
                GVManagementDB.DataSource = dt
                GVManagementDB.DataBind()
                male = 0
                female = 0
                total = 0

                For Each rows As GridViewRow In GVManagementDB.Rows
                    If CType(rows.FindControl("lblMale"), Label).Text = "" Then
                        male = male + 0
                    Else
                        male = male + CType(rows.FindControl("lblMale"), Label).Text
                    End If
                    If CType(rows.FindControl("lblFemale"), Label).Text = "" Then
                        female = female + 0
                    Else
                        female = female + CType(rows.FindControl("lblFemale"), Label).Text
                    End If
                    If CType(rows.FindControl("lbltotal"), Label).Text = "" Then
                        total = total + 0
                    Else
                        total = total + CType(rows.FindControl("lbltotal"), Label).Text
                    End If

                Next
                dt.Clear()
                Dim dRow As DataRow
                dRow = dt.NewRow

                dRow(0) = "Grand Total"
                dRow(2) = male
                dRow(3) = female
                dRow(4) = total


                dt.Rows.InsertAt(dRow, 0)
                GvGrnadTotal.DataSource = dt
                GvGrnadTotal.DataBind()
                GvGrnadTotal.Visible = True

                'Lblmale.Visible = True
                'Lblfemale.Visible = True
                'lblGrandTotal.Visible = True
                'LblTotal.Visible = True
                'Lblmale.Text = male
                'Lblfemale.Text = female
                'LblTotal.Text = total
                lblTotEmpCount.Visible = True
                lblstaff.Visible = True
                lblTeachingstaff.Visible = True
                lbltottechstaff.Visible = True
                lblnonteachingstaff.Visible = True
                lblTotNonTeachingStaff.Visible = True
                lblvisit.Visible = True
                lblVisiting.Visible = True
                lblHonoraryemp.Visible = True
                lblHonorary.Visible = True
                lblfultimstaff.Visible = True
                lblparttimstaff.Visible = True
                lbltotfultimstaff.Visible = True
                lbltotparttimstaff.Visible = True
                lblApproved.Visible = True
                lblAffiliatedTo.Visible = True
                lblAccredited.Visible = True
                Label4.Visible = True
                Label5.Visible = True
                Label6.Visible = True

                lblTotEmpCount.Text = TotEmpCount
                lbltottechstaff.Text = TotTeachingStaff
                lblTotNonTeachingStaff.Text = TotNonTeachingStaff
                lbltotfultimstaff.Text = TotFullTimeStaff
                lbltotparttimstaff.Text = TotPartTimeStaff
                lblVisiting.Text = VisingEmp
                lblHonorary.Text = HonoraryEmp


            End If

        Catch ex As Exception
            lblE.Text = "Please Enter Correct data"
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        
            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
            lblstaff.Visible = False
            lblTeachingstaff.Visible = False
            lblnonteachingstaff.Visible = False
            lblfultimstaff.Visible = False
            lblparttimstaff.Visible = False
            lblApproved.Visible = False
            lblAffiliatedTo.Visible = False
            lblAccredited.Visible = False
            lblvisit.Visible = False
            lblHonoraryemp.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            cmbAcademic.Focus()

        Catch ex As Exception
            Response.Redirect("LogIn.aspx")
        End Try
    End Sub

    Protected Sub cmbAcademic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.SelectedIndexChanged
        GVManagementDB.Visible = False
        lblstaff.Visible = False
        'Lblmale.Visible = False
        'Lblfemale.Visible = False
        'lblGrandTotal.Visible = False
        'LblTotal.Visible = False
        lblTotEmpCount.Visible = False
        GvGrnadTotal.Visible = False
        '''''
        lblTeachingstaff.Visible = False
        lbltottechstaff.Visible = False
        lblnonteachingstaff.Visible = False
        lblTotNonTeachingStaff.Visible = False

        lblfultimstaff.Visible = False
        lblparttimstaff.Visible = False

        lblvisit.Visible = False
        lblVisiting.Visible = False
        lblHonoraryemp.Visible = False
        lblHonorary.Visible = False

        lbltotfultimstaff.Visible = False
        lbltotparttimstaff.Visible = False
        lblApproved.Visible = False
        lblAffiliatedTo.Visible = False
        lblAccredited.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
    End Sub

    Protected Sub ddlcategry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcategry.SelectedIndexChanged
        GVManagementDB.Visible = False
        lblstaff.Visible = False
        'Lblmale.Visible = False
        'Lblfemale.Visible = False
        'lblGrandTotal.Visible = False
        'LblTotal.Visible = False
        lblTotEmpCount.Visible = False
        GvGrnadTotal.Visible = False
        ''''''
        lblTeachingstaff.Visible = False
        lbltottechstaff.Visible = False
        lblnonteachingstaff.Visible = False
        lblTotNonTeachingStaff.Visible = False

        lblfultimstaff.Visible = False
        lblparttimstaff.Visible = False
        lblvisit.Visible = False
        lblVisiting.Visible = False

        lblHonoraryemp.Visible = False
        lblHonorary.Visible = False
        lbltotfultimstaff.Visible = False
        lbltotparttimstaff.Visible = False
        lblApproved.Visible = False
        lblAffiliatedTo.Visible = False
        lblAccredited.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        GVManagementDB.Visible = False
        lblstaff.Visible = False
        'Lblmale.Visible = False
        'Lblfemale.Visible = False
        'lblGrandTotal.Visible = False
        'LblTotal.Visible = False
        lblTotEmpCount.Visible = False
        GvGrnadTotal.Visible = False
        '''''''
        lblTeachingstaff.Visible = False
        lbltottechstaff.Visible = False
        lblnonteachingstaff.Visible = False
        lblTotNonTeachingStaff.Visible = False

        lblfultimstaff.Visible = False
        lblparttimstaff.Visible = False
        lblvisit.Visible = False
        lblVisiting.Visible = False
        lblHonoraryemp.Visible = False
        lblHonorary.Visible = False

        lbltotfultimstaff.Visible = False
        lbltotparttimstaff.Visible = False
        lblApproved.Visible = False
        lblAffiliatedTo.Visible = False
        lblAccredited.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
    End Sub

    Protected Sub cmbAcademic_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.TextChanged
        cmbAcademic.Focus()
    End Sub

    Protected Sub ddlCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.TextChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub ddlcategry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcategry.TextChanged
        ddlcategry.Focus()
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
