Public Partial Class adresajax
    Inherits System.Web.UI.Page



    'LOGİN OLAN MUHTARIN MAHALLESİ 
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function loginmahalle() As String

        Return HttpContext.Current.Session("kullanici_mahallepkey")

    End Function


    'TÜM İLÇELERİ DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function tumilceleridoldur() As List(Of CLASSILCE)

        Dim ilceler As New List(Of CLASSILCE)
        Dim ilce_erisim As New CLASSILCE_ERISIM
        ilceler = ilce_erisim.doldur()
        Return ilceler

    End Function


    'SEÇİLEN İLÇENİN BUCAKLARINI DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ilgilibucaklaridoldur(ByVal ilcepkey As String) As List(Of CLASSBUCAK)

        Dim bucaklar As New List(Of CLASSBUCAK)
        Dim bucak_erisim As New CLASSBUCAK_ERISIM
        bucaklar = bucak_erisim.doldurilgili(ilcepkey)
        Return bucaklar

    End Function

    'SEÇİLEN BUCAĞIN BELEDİYELERİNİ DOLDURUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ilgilibelediyeleridoldur(ByVal bucakpkey As String) As List(Of CLASSBELEDIYE)

        Dim belediyelar As New List(Of CLASSBELEDIYE)
        Dim belediye_erisim As New CLASSBELEDİYE_ERISIM
        belediyelar = belediye_erisim.doldurilgili(bucakpkey)
        Return belediyelar

    End Function


    'SEÇİLEN BELEDİYENİN MAHALLELERİNİ DOLDURUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ilgilimahalleleridoldur(ByVal belediyepkey As String) As List(Of CLASSMAHALLE)

        Dim mahalleler As New List(Of CLASSMAHALLE)
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        mahalleler = mahalle_erisim.doldurilgili(belediyepkey)
        Return mahalleler

    End Function


    'SEÇİLEN MAHALLENIN SOKAKLARINI DOLDURUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ilgilisokaklaridoldur(ByVal mahallepkey As String) As List(Of CLASSSOKAK)

        Dim sokaklar As New List(Of CLASSSOKAK)
        Dim sokak_erisim As New CLASSSOKAK_ERISIM
        sokaklar = sokak_erisim.doldurilgili(mahallepkey)
        Return sokaklar

    End Function


    'SADECE İSTEDİĞİM İLÇEYİ DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sadeceistedigimilceyidoldur(ByVal ilcepkey As String) As List(Of CLASSILCE)

        Dim ilceler As New List(Of CLASSILCE)
        Dim ilce_erisim As New CLASSILCE_ERISIM
        ilceler = ilce_erisim.doldur_sadeceistedigim(ilcepkey)
        Return ilceler

    End Function



    'SADECE İSTEDİĞİM BUCAĞI DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sadeceistedigimbucagidoldur(ByVal bucakpkey As String) As List(Of CLASSBUCAK)

        Dim bucaklar As New List(Of CLASSBUCAK)
        Dim bucak_erisim As New CLASSBUCAK_ERISIM
        bucaklar = bucak_erisim.doldur_sadeceistedigim(bucakpkey)
        Return bucaklar

    End Function


    'SADECE İSTEDİĞİM BELEDİYEYİ DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sadeceistedigimbelediyeyidoldur(ByVal belediyepkey As String) As List(Of CLASSBELEDIYE)

        Dim belediyelar As New List(Of CLASSBELEDIYE)
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        belediyelar = belediye_erisim.doldur_sadeceistedigim(belediyepkey)
        Return belediyelar

    End Function


    'SADECE İSTEDİĞİM MAHALLEYİ DOLDUR
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sadeceistedigimmahalleyidoldur(ByVal mahallepkey As String) As List(Of CLASSMAHALLE)

        Dim mahalleler As New List(Of CLASSMAHALLE)
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        mahalleler = mahalle_erisim.doldur_sadeceistedigim(mahallepkey)
        Return mahalleler

    End Function


    '-----------------------------------------------------------------------------------------------------------------
    'İLGİLİ İLÇENİN BUCAKLARI LİSTELER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listele_ilgiliilceninbucaklari(ByVal ilcepkey As String) As String

        Dim donecek As String
        HttpContext.Current.Session("ltip") = "ilgiliilcenin"
        HttpContext.Current.Session("ilcepkey") = ilcepkey
        Dim bucak_erisim As New CLASSBUCAK_ERISIM
        donecek = bucak_erisim.listele

        Return donecek

    End Function

    'İLGİLİ BUCAĞIN BELEDİYELERİNİ LİSTELER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listele_ilgilibucaginbelediyeleri(ByVal bucakpkey As String) As String

        Dim donecek As String
        HttpContext.Current.Session("ltip") = "ilgilibucagin"
        HttpContext.Current.Session("bucakpkey") = bucakpkey
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        donecek = belediye_erisim.listele

        Return donecek

    End Function


    'İLGİLİ BELEDİYENİN MAHALLELERİNİ LİSTELER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listele_ilgilibelediyeninmahallelerini(ByVal belediyepkey As String) As String

        Dim donecek As String
        HttpContext.Current.Session("ltip") = "ilgilibelediyenin"
        HttpContext.Current.Session("belediyepkey") = belediyepkey
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        donecek = mahalle_erisim.listele

        Return donecek

    End Function


    'İLGİLİ BELEDİYENİN MAHALLELERİNİ LİSTELER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listele_ilgilibelediyeninmahallelerini_tip(ByVal belediyepkey As String, ByVal tip As String) As String

        Dim donecek As String
        HttpContext.Current.Session("ltip") = "ilgilibelediyenin_tip"
        HttpContext.Current.Session("belediyepkey") = belediyepkey
        HttpContext.Current.Session("tip") = tip
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        donecek = mahalle_erisim.listele

        Return donecek

    End Function


    'İLGİLİ MAHALLENİN SOKAKLARINI LİSTELER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listele_ilgilimahalleninsokaklari(ByVal mahallepkey As String) As String

        Dim donecek As String
        HttpContext.Current.Session("ltip") = "ilgilimahallenin"
        HttpContext.Current.Session("mahallepkey") = mahallepkey
        Dim sokak_erisim As New CLASSSOKAK_ERISIM
        donecek = sokak_erisim.listele

        Return donecek

    End Function


    'İLGİLİ MAHALLENİN SOKAKLARINI LİSTELER SOKAKTUR E GÖRE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listele_ilgilimahalleninsokaklari_sokaktur(ByVal mahallepkey As String, ByVal sokaktur As String) As String

        Dim donecek As String
        HttpContext.Current.Session("ltip") = "ilgilimahalleninvesokaktur"
        HttpContext.Current.Session("mahallepkey") = mahallepkey
        HttpContext.Current.Session("sokaktur") = sokaktur
        Dim sokak_erisim As New CLASSSOKAK_ERISIM
        donecek = sokak_erisim.listele

        Return donecek

    End Function





    'ilce bul
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bultek_ilce(ByVal ilcepkey As String) As CLASSILCE

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM
        ilce = ilce_erisim.bultek(ilcepkey)
        Return ilce

    End Function

    'bucak bul
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bultek_bucak(ByVal bucakpkey As String) As CLASSBUCAK

        Dim bucak As New CLASSBUCAK
        Dim bucak_erisim As New CLASSBUCAK_ERISIM
        bucak = bucak_erisim.bultek(bucakpkey)
        Return bucak

    End Function


    'belediye bul
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bultek_belediye(ByVal belediyepkey As String) As CLASSBELEDIYE

        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        belediye = belediye_erisim.bultek(belediyepkey)
        Return belediye

    End Function


    'mahalle bul
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bultek_mahalle(ByVal mahallepkey As String) As CLASSMAHALLE

        Dim mahalle As New CLASSMAHALLE
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        mahalle = mahalle_erisim.bultek(mahallepkey)
        Return mahalle

    End Function



    'sokak bul
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bultek_sokak(ByVal sokakpkey As String) As CLASSSOKAK

        Dim sokak As New CLASSSOKAK
        Dim sokak_erisim As New CLASSSOKAK_ERISIM
        sokak = sokak_erisim.bultek(sokakpkey)
        Return sokak

    End Function


  

    'dortlu adresi bul
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function dortluadresibul(ByVal mahallepkey As String) As CLASSADRESDORTLU

        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        Return adrescore_erisim.dortluadresibul(mahallepkey)

    End Function


    'mahalledegorevlimi
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function mahalledegorevlimi(ByVal mahallepkey As String) As String
        Dim donecek As String
        If mahallepkey = HttpContext.Current.Session("kullanici_mahallepkey") Then
            donecek = "Evet"
        Else
            donecek = "Hayır"
        End If
        Return donecek
    End Function

    'ilcedegorevlimi
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ilcedegorevlimi(ByVal mahallepkey As String, ByVal secilenilcepkey As String) As String
        Dim donecek As String
        Dim ilce As New CLASSILCE
        Dim adrescore_erisim As New CLASSADRESCORE_ERISIM
        ilce = adrescore_erisim.mahalledenilceyibul(mahallepkey)
        If CStr(ilce.pkey) = secilenilcepkey Then
            donecek = "Evet"
        Else
            donecek = "Hayır"
        End If
        Return donecek
    End Function


End Class