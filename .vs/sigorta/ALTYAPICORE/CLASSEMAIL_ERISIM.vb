Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.Collections.Generic
Imports System.Net.Mail
Imports System.Web.HttpContext.Current
Imports System.Net.Mime


Public Class CLASSEMAIL_ERISIM

    Dim result As New CLADBOPRESULT

    Public Function gonder(ByVal email As CLASSEMAIL) As CLADBOPRESULT

        Dim emailayar As New CLASSEMAILAYAR
        Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM

        emailayar = emailayar_erisim.bul(CStr(1))

        Dim objMM As New MailMessage

        objMM.To.Add(New MailAddress(email.kime))
        objMM.From = New MailAddress(email.kimden)
        objMM.Priority = CInt(emailayar.oncelik)
        objMM.BodyEncoding = Encoding.UTF8
        objMM.IsBodyHtml = True
        objMM.Subject = email.subject
        objMM.Body = email.body


        Dim data As Attachment
        If email.attachmentfile <> "" Then
            Dim attachmentfile_path As String = email.attachmentfile
            data = New Attachment(attachmentfile_path, MediaTypeNames.Application.Octet)
            Dim disposition As ContentDisposition
            disposition = data.ContentDisposition
            disposition.CreationDate = System.IO.File.GetCreationTime(attachmentfile_path)
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(attachmentfile_path)
            disposition.ReadDate = System.IO.File.GetLastAccessTime(attachmentfile_path)
            objMM.Attachments.Add(data)
        End If

        Dim host As String = emailayar.hostname
        Dim client As New SmtpClient(host, emailayar.portnumber)

        client.EnableSsl = emailayar.sslvarmi
        client.Port = emailayar.portnumber
        client.Credentials = New System.Net.NetworkCredential(emailayar.username, emailayar.password)

        If emailayar.udckullan = "Evet" Then
            client.UseDefaultCredentials = emailayar.usedefaultcredentials
        End If

        client.PickupDirectoryLocation = emailayar.pickupdirectorylocation
        client.DeliveryMethod = CInt(emailayar.deliverymethod)

        Try
            client.Send(objMM)
            result.durum = "Kaydedildi"
            result.hatastr = ""
            result.etkilenen = 1
        Catch ex As Exception
            result.durum = "Kayıt yapılamadı."
            result.hatastr = ex.Message
            result.etkilenen = 0
        End Try

        If email.attachmentfile <> "" Then
            data.Dispose()
        End If


        'e mail logla
        Dim emaillog As New CLASSEMAILLOG
        Dim emaillog_erisim As New CLASSEMAILLOG_ERISIM
        emaillog.gondermetarih = DateTime.Now
        emaillog.kime = email.kime
        emaillog.kimden = email.kimden
        emaillog.subject = email.subject
        emaillog.body = email.body
        emaillog.sonuc = result.durum
        emaillog.hatatxt = result.hatastr
        emaillog_erisim.Ekle(emaillog)

        Return result

    End Function




End Class
