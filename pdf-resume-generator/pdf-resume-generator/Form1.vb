Imports Newtonsoft.Json
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports System.IO
Public Class Form1
    Private Sub generatorBtn_Click(sender As Object, e As EventArgs) Handles generatorBtn.Click
        Dim jsonFile As String = File.ReadAllText("resume.json")
        Dim getJson As JsonValue = JsonConvert.DeserializeObject(Of JsonValue)(jsonFile)

        Dim pdfFileWriter As Document = New Document()
        PdfWriter.GetInstance(pdfFileWriter, New FileStream("NATIVIDAD_MARY ANN.pdf", FileMode.Create))

        pdfFileWriter.Open()

        Dim name As Paragraph = New Paragraph(getJson.fullName)
        name.Alignment = Element.ALIGN_CENTER
        pdfFileWriter.Add(name)

        Dim residentAddress As Paragraph = New Paragraph(getJson.address)
        residentAddress.Alignment = Element.ALIGN_CENTER
        pdfFileWriter.Add(residentAddress)

        Dim emailAddress As Paragraph = New Paragraph(getJson.email)
        emailAddress.Alignment = Element.ALIGN_CENTER
        pdfFileWriter.Add(emailAddress)

        Dim phoneNumber As Paragraph = New Paragraph(getJson.contact & vbLf & vbLf)
        phoneNumber.Alignment = Element.ALIGN_CENTER
        pdfFileWriter.Add(phoneNumber)

        Dim lineBar As LineSeparator = New LineSeparator(3.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)
        pdfFileWriter.Add(lineBar)

        Dim careerObjective As Paragraph = New Paragraph("Career Objective")
        pdfFileWriter.Add(careerObjective)
        Dim objective As Paragraph = New Paragraph(getJson.careerObj & vbLf & vbLf & vbLf)
        pdfFileWriter.Add(objective)

        Dim profAttri As Paragraph = New Paragraph("Proffessional Attributes")
        pdfFileWriter.Add(profAttri)
        Dim careerAttribute As Paragraph = New Paragraph(getJson.attribute & vbLf & vbLf & vbLf)
        pdfFileWriter.Add(careerAttribute)


        Dim education As Paragraph = New Paragraph("Education")
        pdfFileWriter.Add(education)
        Dim pup As Paragraph = New Paragraph(getJson.school)
        pdfFileWriter.Add(pup)
        Dim courseProgram As Paragraph = New Paragraph(getJson.course)
        pdfFileWriter.Add(courseProgram)
        Dim schoolYear As Paragraph = New Paragraph(getJson.year & vbLf & vbLf & vbLf)
        pdfFileWriter.Add(schoolYear)


        Dim certEtc As Paragraph = New Paragraph("Certifications, Workshops, and Seminars Attended")
        pdfFileWriter.Add(certEtc)
        Dim cert1 As Paragraph = New Paragraph(getJson.certificate1)
        pdfFileWriter.Add(cert1)
        Dim cert2 As Paragraph = New Paragraph(getJson.certificate2)
        pdfFileWriter.Add(cert2)
        Dim cert3 As Paragraph = New Paragraph(getJson.certificate3)
        pdfFileWriter.Add(cert3)

        pdfFileWriter.Close()

        filnameLabel.Visible = True
        fullnameLabel.Text = getJson.fullName
        fullnameLabel.Visible = True

        MessageBox.Show("PDF resume file generate successfully")
    End Sub

    Public Class JsonValue
        Public Property fullName As String
        Public Property address As String
        Public Property email As String
        Public Property contact As String
        Public Property careerObj As String
        Public Property attribute As String
        Public Property school As String
        Public Property course As String
        Public Property year As String
        Public Property certificate1 As String
        Public Property certificate2 As String
        Public Property certificate3 As String

    End Class
End Class
