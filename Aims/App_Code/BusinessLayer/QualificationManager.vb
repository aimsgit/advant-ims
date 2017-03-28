Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class QualificationManager
    'Public Function GetQualification(ByVal std_code As String) As List(Of Qualification)
    '    Dim qualification As New List(Of Qualification)
    '    Dim ds As DataSet = QualificationDB.GetQualification(std_code)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        qualification.Add(New Qualification(row("Qualification_ID"), row("Std_code"), row("Qualification"), row("Board_Univ"), row("Marks"), row("YearofPassing"), row("CERT_SBMT")))
    '    Next
    '    Return qualification
    'End Function
    'Public Function GetQualificationById(ByVal id As Long) As Qualification
    '    Dim ds As DataSet = QualificationDB.GetQualification(id)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    Dim qualification As Qualification = New Qualification(row("Qualification_ID"), row("Qualification"))
    '    Return qualification
    'End Function
    Public Function InsertRecord(ByVal q As Qualification) As Integer
        Return QualificationDB.Insert(q)
    End Function
    Public Function UpdateRecord(ByVal q As Qualification) As Integer
        Return QualificationDB.Insert(q)
    End Function
    Public Function ChangeFlag(ByVal q As Qualification) As Integer
        Return QualificationDB.ChangeFlag(q.Qualification_ID)
    End Function
    Public Function ChangeFlag(ByVal Qualification_ID As Int32) As Integer
        Return QualificationDB.ChangeFlag(Qualification_ID)
    End Function
    'CERTIFICATE RECEIVED FUNCTIONS
    Public Function SaveRecord(ByVal c As CertificateReceived) As Integer
        Return QualificationDB.Save(c)
    End Function
    'Public Function GetCertificate(ByVal std_code As String) As List(Of CertificateReceived)
    '    ''Dim certificate As New List(Of CertificateReceived)
    '    ''Dim ds As DataSet = QualificationDB.GetCertificate(std_code)
    '    ''Dim row As DataRow
    '    ''For Each row In ds.Tables(0).Rows
    '    ''    certificate.Add(New CertificateReceived(row("Qualification_ID"), row("Std_code"), row("Qualification"), row("Remarks")))
    '    ''Next
    '    Return 0
    'End Function
    Public Function UpdateCerti(ByVal c As CertificateReceived) As Integer
        Return QualificationDB.Save(c)
    End Function
    Public Function DeleteCerti(ByVal Qualification_ID As Int32) As Integer
        Return QualificationDB.DeleteCertificate(Qualification_ID)
    End Function
    'CERTIFICATE iSSUED (LATERAL ENTRY)
    Public Function InsertCertiIssued(ByVal ci As CertificateIssuedLateral) As Integer
        Return QualificationDB.SaveCertiIssued(ci)
    End Function
    Public Function UpdateCertiIssued(ByVal ci As CertificateIssuedLateral) As Integer
        Return QualificationDB.SaveCertiIssued(ci)
    End Function
    Public Function GetCertiIssued(ByVal std_code As String) As List(Of CertificateIssuedLateral)
        'Dim certificate As New List(Of CertificateIssuedLateral)
        'Dim ds As DataSet = QualificationDB.GetCertiIssued(std_code)
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    certificate.Add(New CertificateIssuedLateral(row("Qualification_ID"), row("Std_code"), row("Qualification"), row("Board_Univ"), row("Marks"), row("YearofPassing")))
        'Next
        'Return certificate
    End Function

End Class
