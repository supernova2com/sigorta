Public Partial Class errorservis
    Inherits System.Web.UI.Page


    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function okunduyap(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim errorlog_erisim As New CLASSERRORLOG_ERISIM

        Dim errorlog As New CLASSERRORLOG

        errorlog = errorlog_erisim.bultek(pkey)
        errorlog.okunmusmu = "Evet"
        result = errorlog_erisim.Duzenle(errorlog)
        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function okunmadiyap(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim errorlog_erisim As New CLASSERRORLOG_ERISIM

        Dim errorlog As New CLASSERRORLOG

        errorlog = errorlog_erisim.bultek(pkey)
        errorlog.okunmusmu = "Hayır"
        result = errorlog_erisim.Duzenle(errorlog)
        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim errorlog_erisim As New CLASSERRORLOG_ERISIM

        Dim errorlog As New CLASSERRORLOG
        result = errorlog_erisim.Sil(pkey)
        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function epostagonder(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim emailayar As New CLASSEMAILAYAR
        Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM
        emailayar = emailayar_erisim.bul(1)

        Dim email As New CLASSEMAIL
        Dim email_erisim As New CLASSEMAIL_ERISIM

        Dim errorlog As New CLASSERRORLOG
        Dim errorlog_erisim As New CLASSERRORLOG_ERISIM
        errorlog = errorlog_erisim.bultek(pkey)

        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

        kullanici = kullanici_erisim.bultek(errorlog.kullanicipkey)


        Dim body As String
        body = "Hata Tarihi:" + "<b>" + CStr(errorlog.tarih) + "</b><br/>" + _
        "Mesaj:" + "<b>" + CStr(errorlog.exp_msg) + "</b><br/>" + _
        "Source:" + "<b>" + CStr(errorlog.exp_source) + "</b><br/>" + _
        "Stack Trace:" + "<b>" + CStr(errorlog.exp_stacktrace) + "</b><br/>" + _
        "URL:" + "<b>" + CStr(errorlog.exp_url) + "</b><br/>" + _
        "Okunmuş mu:" + "<b>" + CStr(errorlog.okunmusmu) + "</b><br/>"


        email.kimden = emailayar.username
        email.kime = site.hataeposta
        email.subject = site.musteriadsoyad + " " + CStr(errorlog.tarih) + " tarihinde oluşan hata ile ilgili"
        email.body = body


        result = email_erisim.gonder(email)

        'e-posta başarılı bir şekilde gönderildi ise gönderildi evet yap
        If result.durum = "Kaydedildi" Then
            errorlog.emailgonderilmismi = "Evet"
            errorlog_erisim.Duzenle(errorlog)
        End If

        Return result

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listele() As String

        Dim errorlog_erisim As New CLASSERRORLOG_ERISIM
        Return errorlog_erisim.listeleislemicin

    End Function


End Class