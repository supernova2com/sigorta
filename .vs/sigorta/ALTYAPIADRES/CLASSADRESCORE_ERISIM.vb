Public Class CLASSADRESCORE_ERISIM


    Dim ilceler As New List(Of CLASSILCE)
    Dim ilce As New CLASSILCE
    Dim ilce_erisim As New CLASSILCE_ERISIM

    Dim bucaklar As New List(Of CLASSBUCAK)
    Dim bucak As New CLASSBUCAK
    Dim bucak_erisim As New CLASSBUCAK_ERISIM

    Dim belediyeler As New List(Of CLASSBELEDIYE)
    Dim belediye As New CLASSBELEDIYE
    Dim belediye_erisim As New CLASSBELEDIYE_ERISIM

    Dim mahalleler As New List(Of CLASSMAHALLE)
    Dim mahalle As New CLASSMAHALLE
    Dim mahalle_erisim As New CLASSMAHALLE_ERISIM

    Dim sokaklar As New List(Of CLASSSOKAK)
    Dim sokak As New CLASSSOKAK
    Dim sokak_erisim As New CLASSSOKAK_ERISIM




    Public Function mahalledenilceyibul(ByVal mahallepkey As String) As CLASSILCE

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM

        Dim bucak As New CLASSBUCAK
        Dim bucak_erisim As New CLASSBUCAK_ERISIM

        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM

        Dim mahalle As New CLASSMAHALLE
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM

        mahalle = mahalle_erisim.bultek(mahallepkey)
        belediye = belediye_erisim.bultek(mahalle.belediyepkey)
        bucak = bucak_erisim.bultek(belediye.bucakpkey)
        ilce = ilce_erisim.bultek(bucak.ilcepkey)

        Return ilce

    End Function


    Public Function mahalledenbucagibul(ByVal mahallepkey As String) As CLASSBUCAK

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM

        Dim bucak As New CLASSBUCAK
        Dim bucak_erisim As New CLASSBUCAK_ERISIM

        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM

        Dim mahalle As New CLASSMAHALLE
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM

        mahalle = mahalle_erisim.bultek(mahallepkey)
        belediye = belediye_erisim.bultek(mahalle.belediyepkey)
        bucak = bucak_erisim.bultek(belediye.bucakpkey)

        Return bucak

    End Function

    Public Function mahalledenbelediyeyibul(ByVal mahallepkey As String) As CLASSBELEDIYE

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM

        Dim bucak As New CLASSBUCAK
        Dim bucak_erisim As New CLASSBUCAK_ERISIM

        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM

        Dim mahalle As New CLASSMAHALLE
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM

        mahalle = mahalle_erisim.bultek(mahallepkey)
        belediye = belediye_erisim.bultek(mahalle.belediyepkey)

        Return belediye

    End Function


    Public Function dortluadresibul(ByVal mahallepkey As String) As CLASSADRESDORTLU

        Dim adresdortlu As New CLASSADRESDORTLU

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM

        Dim bucak As New CLASSBUCAK
        Dim bucak_erisim As New CLASSBUCAK_ERISIM

        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM

        Dim mahalle As New CLASSMAHALLE
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM

        mahalle = mahalle_erisim.bultek(mahallepkey)
        belediye = belediye_erisim.bultek(mahalle.belediyepkey)
        bucak = bucak_erisim.bultek(belediye.bucakpkey)
        ilce = ilce_erisim.bultek(bucak.ilcepkey)

        adresdortlu.ilcepkey = ilce.pkey
        adresdortlu.bucakpkey = bucak.pkey
        adresdortlu.belediyepkey = belediye.pkey
        adresdortlu.mahallepkey = mahalle.pkey

        Return adresdortlu

    End Function



    Public Function doldur_ilce(ByVal servisad As String, ByVal wskullaniciad As String, ByVal wssifre As String) As List(Of CLASSILCE)

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM
        Dim ilceler As New List(Of CLASSILCE)

        Dim ipadres As String
        ipadres = ip_erisim.ipadresibul()

        Dim girdisayisi As Integer = 0

        Dim xmlhata As String = ""
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'TÜM İP YETKİLİMİ KONTROL ET
        If sirket.pkey = 0 Then

            root.ResultCode = 0
            ErrorInfo.Code = 1
            ErrorInfo.Message = "Kullanıcı adı yada şifre hatalı"
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
            0, "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ipadres))

            ilce.ilcead = "Kullanıcı adı yada şifre hatalı"
            ilce.pkey = 0
            ilce.ilcekod = ""
            ilceler.Add(ilce)
            Return ilceler


        End If

        'İŞLEMLERE BAŞLA

        root.ResultCode = 1
        ErrorInfo.Code = 0
        ErrorInfo.Message = Nothing
        root.ErrorInfo = ErrorInfo

        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
        root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0,
        0, "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "-", wskullaniciad,
        wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        ilceler = ilce_erisim.doldur
        Return ilceler

    End Function


    Public Function doldur_bucak(ByVal servisad As String, ByVal wskullaniciad As String,
    ByVal wssifre As String, ByVal ilcepkey As String) As List(Of CLASSBUCAK)

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM

        Dim bucak As New CLASSBUCAK
        Dim bucak_erisim As New CLASSBUCAK_ERISIM
        Dim bucaklar As New List(Of CLASSBUCAK)

        Dim ipadres As String
        ipadres = ip_erisim.ipadresibul()

        Dim girdisayisi As Integer = 0

        Dim xmlhata As String = ""
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'TÜM İP YETKİLİMİ KONTROL ET
        If sirket.pkey = 0 Then

            root.ResultCode = 0
            ErrorInfo.Code = 1
            ErrorInfo.Message = "Kullanıcı adı yada şifre hatalı"
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
            0, "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ipadres))

            bucak.bucakad = "Kullanıcı adı yada şifre hatalı"
            bucak.pkey = 0
            bucak.ilcepkey = 0
            bucaklar.Add(bucak)
            Return bucaklar

        End If

        If IsNumeric(ilcepkey) = False Then

            bucak.bucakad = "ilcepkey parametresi numeric bir değer olmalıdır."
            bucak.pkey = 0
            bucak.ilcepkey = 0
            bucaklar.Add(bucak)
            Return bucaklar

        End If

        'İŞLEMLERE BAŞLA
        root.ResultCode = 1
        ErrorInfo.Code = 0
        ErrorInfo.Message = Nothing
        root.ErrorInfo = ErrorInfo

        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
        root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0,
        0, "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "-", wskullaniciad,
        wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        bucaklar = bucak_erisim.doldurilgili(ilcepkey)
        Return bucaklar

    End Function


    Public Function doldur_belediye(ByVal servisad As String, ByVal wskullaniciad As String,
    ByVal wssifre As String, ByVal bucakpkey As String) As List(Of CLASSBELEDIYE)

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM

        Dim belediye As New CLASSBELEDIYE
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        Dim belediyelar As New List(Of CLASSBELEDIYE)

        Dim ipadres As String
        ipadres = ip_erisim.ipadresibul()

        Dim girdisayisi As Integer = 0

        Dim xmlhata As String = ""
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'TÜM İP YETKİLİMİ KONTROL ET
        If sirket.pkey = 0 Then

            root.ResultCode = 0
            ErrorInfo.Code = 1
            ErrorInfo.Message = "Kullanıcı adı yada şifre hatalı"
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
            0, "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ipadres))

            belediye.pkey = 0
            belediye.bucakpkey = 0
            belediye.belediyead = "Kullanıcı adı yada şifre hatalı"
            belediyelar.Add(belediye)
            Return belediyelar

        End If

        If IsNumeric(bucakpkey) = False Then

            belediye.pkey = 0
            belediye.bucakpkey = 0
            belediye.belediyead = "bucakpkey parametresi numeric bir değer olmalıdır."
            belediyelar.Add(belediye)
            Return belediyelar

        End If

        'İŞLEMLERE BAŞLA
        root.ResultCode = 1
        ErrorInfo.Code = 0
        ErrorInfo.Message = Nothing
        root.ErrorInfo = ErrorInfo

        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
        root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0,
        0, "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "-", wskullaniciad,
        wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        belediyelar = belediye_erisim.doldurilgili(bucakpkey)
        Return belediyelar

    End Function



    Public Function doldur_mahalle(ByVal servisad As String, ByVal wskullaniciad As String,
    ByVal wssifre As String, ByVal belediyepkey As String) As List(Of CLASSMAHALLE)

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM

        Dim mahalle As New CLASSMAHALLE
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        Dim mahallelar As New List(Of CLASSMAHALLE)

        Dim ipadres As String
        ipadres = ip_erisim.ipadresibul()

        Dim girdisayisi As Integer = 0

        Dim xmlhata As String = ""
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'TÜM İP YETKİLİMİ KONTROL ET
        If sirket.pkey = 0 Then

            root.ResultCode = 0
            ErrorInfo.Code = 1
            ErrorInfo.Message = "Kullanıcı adı yada şifre hatalı"
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
            0, "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ipadres))

            mahalle.pkey = 0
            mahalle.belediyepkey = 0
            mahalle.mahallead = "Kullanıcı adı yada şifre hatalı"
            mahalle.tip = ""
            mahalle.muhtarivarmi = ""
            mahalle.postakod = ""
            mahallelar.Add(mahalle)
            Return mahallelar

        End If

        If IsNumeric(belediyepkey) = False Then

            mahalle.pkey = 0
            mahalle.belediyepkey = 0
            mahalle.mahallead = "bucakpkey parametresi numeric bir değer olmalıdır."
            mahalle.tip = ""
            mahalle.muhtarivarmi = ""
            mahalle.postakod = ""
            mahallelar.Add(mahalle)
            Return mahallelar

        End If

        'İŞLEMLERE BAŞLA
        root.ResultCode = 1
        ErrorInfo.Code = 0
        ErrorInfo.Message = Nothing
        root.ErrorInfo = ErrorInfo

        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
        root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0,
        0, "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "-", wskullaniciad,
        wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        mahallelar = mahalle_erisim.doldurilgili(belediyepkey)
        Return mahallelar

    End Function



    Public Function doldur_sokak(ByVal servisad As String, ByVal wskullaniciad As String,
    ByVal wssifre As String, ByVal mahallepkey As String) As List(Of CLASSSOKAK)

        Dim donecek As String = ""
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim logservis As New CLASSLOGSERVIS
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM

        Dim sokak As New CLASSSOKAK
        Dim sokak_erisim As New CLASSSOKAK_ERISIM
        Dim sokaklar As New List(Of CLASSSOKAK)

        Dim ipadres As String
        ipadres = ip_erisim.ipadresibul()

        Dim girdisayisi As Integer = 0

        Dim xmlhata As String = ""
        Dim root As New root
        Dim ErrorInfo As New ErrorInfo

        sirket = sirket_erisim.kullaniciadsifredogrumu(wskullaniciad, wssifre)

        'TÜM İP YETKİLİMİ KONTROL ET
        If sirket.pkey = 0 Then

            root.ResultCode = 0
            ErrorInfo.Code = 1
            ErrorInfo.Message = "Kullanıcı adı yada şifre hatalı"
            root.ErrorInfo = ErrorInfo

            logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
            root.ResultCode, root.ErrorInfo.Code, root.ErrorInfo.Message, 0,
            0, "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "0",
            "0", "0", "0", "0", "", wskullaniciad, wssifre, "", 0, "", "", "", ipadres))

            sokak.pkey = 0
            sokak.mahallepkey = 0
            sokak.sokakad = "Kullanıcı adı yada şifre hatalı"
            sokak.sokaktur = ""

            sokaklar.Add(sokak)
            Return sokaklar

        End If

        If IsNumeric(mahallepkey) = False Then

            sokak.pkey = 0
            sokak.mahallepkey = 0
            sokak.sokakad = "bucakpkey parametresi numeric bir değer olmalıdır."
            sokak.sokaktur = ""
            sokaklar.Add(sokak)
            Return sokaklar

        End If

        'İŞLEMLERE BAŞLA
        root.ResultCode = 1
        ErrorInfo.Code = 0
        ErrorInfo.Message = Nothing
        root.ErrorInfo = ErrorInfo

        logservis_erisim.Ekle(New CLASSLOGSERVIS(0, DateTime.Now, sirket.pkey, servisad,
        root.ResultCode, ErrorInfo.Code, ErrorInfo.Message, 0,
        0, "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "0",
        "0", "0", "0", "0", "-", wskullaniciad,
        wssifre, "", 0, "", "", "", ip_erisim.ipadresibul))

        sokaklar = sokak_erisim.doldurilgili(mahallepkey)
        Return sokaklar

    End Function


    Public Function adreskontrolugectimi(ByVal site As CLASSSITE, ByVal ilcepkey As Integer, ByVal bucakpkey As Integer,
                                 ByVal belediyepkey As Integer, ByVal mahallepkey As Integer,
                                 ByVal sokakpkey As String) As CLADBOPRESULT


        Dim result As New CLADBOPRESULT
        result.durum = "Evet"
        result.etkilenen = 1
        result.hatastr = ""

        Dim ilce As New CLASSILCE
        Dim ilce_erisim As New CLASSILCE_ERISIM
        Dim bucak_erisim As New CLASSBUCAK_ERISIM
        Dim belediye_erisim As New CLASSBELEDIYE_ERISIM
        Dim mahalle_erisim As New CLASSMAHALLE_ERISIM
        Dim sokak_erisim As New CLASSSOKAK_ERISIM

        'İLÇEYİ KONTROL ET
        ilce = ilce_erisim.bultek(ilcepkey)
        If ilce.pkey = 0 Then
            result.durum = "Hayır"
            result.etkilenen = 0
            result.hatastr = "Risk adresi ilçe kodu KKSBM tarafından tanımlanmamış."
            Return result
        End If

        'BUCAĞI KONTROL ET 
        Dim bucakdogrumu As String
        bucakdogrumu = bucak_erisim.bucakilceninmi(site, ilcepkey, bucakpkey)
        If bucakdogrumu = "Hayır" Then
            result.durum = "Hayır"
            result.etkilenen = 0
            result.hatastr = "Gönderdiğiniz bucak kodu, gönderdiğiniz ilçe altında tanımlı değil."
            Return result
        End If

        'BELEDİYEYİ KONTROL ET
        Dim belediyedogrumu As String
        belediyedogrumu = belediye_erisim.belediyebucaginmi(site, bucakpkey, belediyepkey)
        If belediyedogrumu = "Hayır" Then
            result.durum = "Hayır"
            result.etkilenen = 0
            result.hatastr = "Gönderdiğiniz belediye kodu, gönderdiğiniz bucak altında tanımlı değil."
            Return result
        End If


        'MAHALLE KONTROL ET
        Dim mahalledogrumu As String
        mahalledogrumu = mahalle_erisim.mahallebelediyeninmi(site, belediyepkey, mahallepkey)
        If mahalledogrumu = "Hayır" Then
            result.durum = "Hayır"
            result.etkilenen = 0
            result.hatastr = "Gönderdiğiniz mahalle kodu, gönderdiğiniz belediye altında tanımlı değil."
            Return result
        End If

        'SOKAK KONTROL ET
        Dim sokakdogrumu As String
        sokakdogrumu = sokak_erisim.sokakmahalleninmi(site, mahallepkey, sokakpkey)
        If sokakdogrumu = "Hayır" Then
            result.durum = "Hayır"
            result.etkilenen = 0
            result.hatastr = "Gönderdiğiniz sokak kodu, gönderdiğiniz mahalle altında tanımlı değil."
            Return result
        End If




        Return result


    End Function


End Class
