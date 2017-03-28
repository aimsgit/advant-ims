Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Public Class CertificateIssuedB
    Public Function CertificateDetailsCombo() As DataTable
        Dim dl As New CertificateIssuedD
        Return dl.CertificateDetailsCombo()
    End Function
    Public Function InserCertificateDetails(ByVal el As CertificateIssuedE) As Int16
        Dim dl As New CertificateIssuedD
        Return dl.InsertIssueCertificate(el)
    End Function
    Public Function fillGridViewCertificateDetails(ByVal ins As Long, ByVal brn As Long, ByVal crs As Long, ByVal btch As Long) As DataTable
        Dim dl As New CertificateIssuedD
        Return dl.fillGridViewCertificateDetails(ins, brn, crs, btch)
    End Function
    Public Function Report(ByVal ins As Integer, ByVal brn As Integer, ByVal crs As Integer, ByVal btch As Integer) As DataTable
        Dim dl As New CertificateIssuedD
        Return dl.Report(ins, brn, crs, btch)
    End Function
    Public Function UpdateCertificateIssued(ByVal Certificate_Id As Integer, ByVal IssueDate As Date, ByVal Certificate_No As Integer, ByVal ID As Integer, ByVal StdName As String, ByVal StdCode As String) As Int16
        Dim dl As New CertificateIssuedD
        Return dl.UpdateCertificateIssued(Certificate_Id, IssueDate, Certificate_No, ID)
    End Function
    'Public Function UpdateCertificateIssued(ByVal Certificate_Id As Integer, ByVal IssueDate As DateTime, ByVal Certificate_No As Integer, ByVal ID As Integer, ByVal StdId As Integer, ByVal StdCode As String, ByVal StdName As String) As Int16
    '    Dim dl As New CertificateIssuedD
    '    Return dl.UpdateCertificateIssued(Certificate_Id, IssueDate, Certificate_No, ID)
    'End Function
    Public Function DeleteCertificateIssued(ByVal ID As Integer) As Int16
        Dim dl As New CertificateIssuedD
        return dl.DeleteCertificateIssued(id)
    End Function
    'Public Function CertificateDetailsCombo() As List(Of CertificateIssuedE)
    '    Dim certificate As New List(Of CertificateIssuedE)
    '    Dim dl As New CertificateIssuedD
    '    Dim dt As New DataTable
    '    dt = dl.CertificateDetailsCombo()
    '    Dim row As DataRow
    '    For Each row In dt.Rows
    '        certificate.Add(New certificate(row("Batch_ID"), row("Batch_Name")))
    '    Next
    '    Return certificate
    'End Function
End Class
