Namespace SampleProgress

Partial  Class ProgressBar
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Sub SetProgress(ByVal current As Integer, ByVal max As Integer)
        Dim percent As String = Double.Parse(current * 100 / max).ToString("0")

        If Not percent.Equals("0") And Not percent.Equals("100") Then
            lblProgress.Text = percent + "% complete (" + _
                current.ToString() + " of " + max.ToString() + ")"

            lblProgress.Text = lblProgress.Text & _
                "<TABLE cellspacing=0 cellpadding=0 border=1 width=200><TR><TD bgcolor=#000066 width=" + _
                percent.ToString() + _
                "%>&nbsp;</TD><TD bgcolor=#FFF7CE>&nbsp;</TD></TR></TABLE>"
        End If

        If Integer.Parse(percent) < 10 Then
            'only start showing at 10%
            lblProgress.Visible = False
        Else
            lblProgress.Visible = True
        End If
    End Sub
End Class

End Namespace
