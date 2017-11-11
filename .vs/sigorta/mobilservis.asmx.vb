Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class mobilservis
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function toplampolicesayisi(ByVal UserName As String, _
    ByVal Password As String) As Integer

        Dim kullaniciadsifredogrumu As String = "Hayır"
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_Erisim.kullaniciadsifredogrumu(UserName, Password)
        If sirket.pkey > 0 Then
            kullaniciadsifredogrumu = "Evet"
        End If

        If kullaniciadsifredogrumu = "Evet" Then
            Dim PolicyInfo_erisim As New PolicyInfo_Erisim
            Return PolicyInfo_erisim.toplampolicesayisi()
        Else
            Return 0
        End If

    End Function


    <WebMethod()> _
    Public Function toplamhasarsayisi(ByVal UserName As String, _
    ByVal Password As String) As Integer

        Dim kullaniciadsifredogrumu As String = "Hayır"
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_Erisim.kullaniciadsifredogrumu(UserName, Password)
        If sirket.pkey > 0 Then
            kullaniciadsifredogrumu = "Evet"
        End If

        If kullaniciadsifredogrumu = "Evet" Then
            Dim DamageInfo_erisim As New DamageInfo_Erisim
            Return DamageInfo_erisim.toplamhasarsayisi()
        Else
            Return 0
        End If

    End Function



    <WebMethod()> _
    Public Function toplamsirketsayisi(ByVal UserName As String, _
    ByVal Password As String) As Integer

        Dim kullaniciadsifredogrumu As String = "Hayır"
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_Erisim.kullaniciadsifredogrumu(UserName, Password)
        If sirket.pkey > 0 Then
            kullaniciadsifredogrumu = "Evet"
        End If

        If kullaniciadsifredogrumu = "Evet" Then
            Return sirket_Erisim.toplamsirketsayisi_tipegore("ŞİRKET")
        Else
            Return 0
        End If

    End Function



    <WebMethod()> _
    Public Function toplamacentesayisi(ByVal UserName As String, _
    ByVal Password As String) As Integer

        Dim kullaniciadsifredogrumu As String = "Hayır"
        Dim sirket As New CLASSSIRKET
        Dim sirket_Erisim As New CLASSSIRKET_ERISIM
        sirket = sirket_Erisim.kullaniciadsifredogrumu(UserName, Password)
        If sirket.pkey > 0 Then
            kullaniciadsifredogrumu = "Evet"
        End If

        If kullaniciadsifredogrumu = "Evet" Then
            Dim acente_erisim As New CLASSACENTE_ERISIM
            Return acente_erisim.toplamacentesayisi()
        Else
            Return 0
        End If

    End Function


    <WebMethod()> _
    Public Function logincontrol(ByVal UserName As String, _
    ByVal Password As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)

        Dim kacyanlis, sistem_yanlissifrecount As Integer
        sistem_yanlissifrecount = site.yanlissifrecount

        kacyanlis = kullanici_erisim.sifresinikackereyanlisgirmis(DateTime.Now, UserName)

        If kacyanlis >= sistem_yanlissifrecount Then
            result.durum = "Kaydedilmedi"
            result.etkilenen = 0
            result.hatastr = "Şifrenizi bugün içerisinde " + CStr(sistem_yanlissifrecount) + _
            " sayısına eşit yada bu sayıdan fazla miktarda hatalı girdiniz. " + _
            " Şifrenizin sıfırlanması için lütfen KKSBM ile iletişime geçiniz."
            Return result
        End If


        result = kullanici_erisim.logincontrol(UserName, Password)

        If result.durum = "Hayır" Then
            result.durum = "Kaydedilmedi"
            result.etkilenen = 0
            result.hatastr = "Kullanıcı adınız yada şifre hatalı"
            Return result
        End If


        If result.durum = "Evet" Then
            result.durum = "Kaydedildi"
            result.etkilenen = result.etkilenen
            result.hatastr = ""
            Return result
        End If

    End Function


    <WebMethod()> _
    Public Function bul_kullanici(ByVal pkey As String) As CLASSKULLANICI

        Dim result As New CLADBOPRESULT
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        kullanici = kullanici_erisim.bultek(pkey)
        Return kullanici

    End Function


    <WebMethod()> _
    Public Function loginresimdosyaad(ByVal pkey As String) As String

        Dim tekresim As New CLASSTEKRESIM
        Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
        tekresim = tekresim_erisim.bultek(pkey)
        Return tekresim.dosyaad

    End Function


End Class