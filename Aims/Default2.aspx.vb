
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cacheobject As System.Web.Caching.Cache
        cacheobject = System.Web.HttpContext.Current.Cache
        'Programmatic Caching Setup
        Dim RoleMapCache As DataSet = CType(cacheobject.Get("DataGridCache"), DataSet)
        'Populate the DataSet with data from the database
        Dim dt, dt1 As New DataTable
        Dim ReportType As String
        Dim DL As New DLUserManagement
        If Not IsPostBack Then
            Session("HelpLink") = "User manual.html"
        End If
        dt = DL.RoleMap()

        'Now insert dataset into cache, specifying that it should 
        'expire in 10 minutes
        cacheobject.Insert("RoleMapCache", dt, Nothing, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration)
        'Specify what time the cache was updated
        Application("TimeCachedDataSetAdded") = DateTime.Now
        'Changes made by Kusum for Configuring Default Image on 28-05-2012
        Me.Image1.ImageUrl = Session("DefaultIMG").ToString
        If IsPostBack = False Then
            If Session("LoginType") = "Others" Then
                If Session("RptFrmTitleName") = "STUDENT PERFORMANCE" Then
                    'Dim qrystring As String = "Rpt_StudentPerformanceRpt.aspx?" & QueryStr.Querystring()
                    'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    Response.Redirect("frmStudentPerformance.aspx")

                ElseIf Session("RptFrmTitleName") = "STUDENT REPORT CARD" Then
                    'Changes made by sheela for Configuring Report type on 15-05-2013
                    dt1 = DL.StudRptCard()
                    Dim cnt As Integer = dt1.Rows.Count
                    For i As Integer = 0 To dt1.Rows.Count - 1
                        If dt1.Rows(i).Item("Config_Name") = "Student Report Card" Then
                            If dt1.Rows(i).Item("Branchcode") = HttpContext.Current.Session("BranchCode") Then
                                ReportType = dt1.Rows(i).Item("Config_Value")
                                Exit For
                            Else
                                ReportType = "Marks And Grade"
                            End If
                        End If
                    Next
                    Dim qrystring As String = "rptMarksSheet.aspx?" & QueryStr.Querystring() & "&ReportType=" & ReportType
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)


                ElseIf Session("RptFrmTitleName") = "STUDENT ATTENDANCE" Then
                    Dim qrystring As String = "RptStudentAttendanceDetails.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "STUDENT DASHBOARD" Then
                    Response.Redirect("FrmStudentDashboard.aspx")
                    'Dim qrystring As String = "FrmStudentDashboard.aspx?" & QueryStr.Querystring()
                    'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "TIME TABLE" Then
                    Dim qrystring As String = "Rpt_TimeTableV.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "FEE COLLECTION" Then
                    Dim qrystring As String = "RptFeeCollectionReport.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "FEE DUE STATEMENT" Then
                    Dim qrystring As String = "rptFeeDueStatementV.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "STUDENT LOG BOOK" Then
                    Dim qrystring As String = "RptStudentLogBookV.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "SEMESTER ATTENDANCE LIST" Then
                    Dim qrystring As String = "RptStudAttendListV.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "SEMESTER ASSESSMENT" Then
                    Dim qrystring As String = "RptSemAssessmtParentLogin.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "SEMESTER MARKS AND ATTENDANCE LIST" Then
                    Dim qrystring As String = "RptSemMarksnAttenListParentLogin.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                End If
            Else
                If Session("RptFrmTitleName") = "CURRENT LOGIN REPORT" Then
                    Dim qrystring As String = "RptLoginReportV.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                ElseIf Session("RptFrmTitleName") = "MY FEEDBACK" Then
                    Dim qrystring As String = "FacultywisefeedbackV.aspx?" & QueryStr.Querystring()
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1015,height=700,left=0,top=0')</script>", False)
                End If
            End If
        End If

    End Sub
End Class
