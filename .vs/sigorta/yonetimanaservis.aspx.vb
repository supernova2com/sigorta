Public Partial Class yonetimanaservis
    Inherits System.Web.UI.Page


    '--SEÇİLEN AKTİF ŞİRKETİ BUL
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aktifsirketbul() As String

        Dim donecek As String
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        donecek = kullanici_erisim.aktifsirketbul
        Return donecek

    End Function

    '---AKTİF ŞİRKET SEÇİLMİŞ Mİ KONTROL ET -------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function aktifsirketsecilmismi() As String

        Dim donecek As String

        'bu adam şirket admin
        If HttpContext.Current.Session("kullanici_rolpkey") = "3" Then
            Dim kullanici_sirketpkey As String
            kullanici_sirketpkey = HttpContext.Current.Session("kullanici_sirketpkey")
            HttpContext.Current.Session("kullanici_aktifsirket") = kullanici_sirketpkey
            donecek = "Evet"
            Return donecek
        End If

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        donecek = kullanici_erisim.aktifsirketsecilmismi()
        Return donecek


    End Function


    '--- BAZ FİYAT UYARI -------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function bazfiyatuyari() As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        'şirket admini değilse zaten uyarı vermeyecek.
        If HttpContext.Current.Session("kullanici_rolpkey") <> "3" Then
            result.durum = "Kaydedilmiş"
            result.etkilenen = 1
            result.hatastr = ""
        End If


        'bu adam şirket admini ise kontrol et bakalım bazfiyat girilmişmi
        If HttpContext.Current.Session("kullanici_rolpkey") = "3" Then
            Dim kullanici_sirketpkey As String
            kullanici_sirketpkey = HttpContext.Current.Session("kullanici_sirketpkey")

            Dim ensonkayitno As Integer
            Dim bazfiyat As New CLASSBAZFIYAT
            Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM
            ensonkayitno = bazfiyat_erisim.kayitnobul(kullanici_sirketpkey)
            bazfiyat = bazfiyat_erisim.bulsirketpkeykayitnovepolicetipgore(kullanici_sirketpkey, ensonkayitno, "1")
            'girilmemiş
            If bazfiyat.pkey = 0 Then
                result.durum = "Kaydedilmemiş"
                result.etkilenen = 0
                result.hatastr = "Kayıt numarası " + CStr(ensonkayitno) + " için baz fiyatlar girilmemiş."
            End If
            If bazfiyat.pkey > 0 Then
                result.durum = "Kaydedilmiş"
                result.etkilenen = 1
                result.hatastr = ""
            End If

        End If

        Return result

    End Function

    '-- KULLANICININ AKTİF ŞİRKETLERİ MODAL IN İÇİNDEKİ DROP DOWN İÇİNE DOLDUR ---------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aktifsirketleridoldur() As List(Of CLASSSIRKET)

        Dim doneceksirketler As New List(Of CLASSSIRKET)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        Dim kullanici_acentepkey As String
        kullanici_acentepkey = HttpContext.Current.Session("kullanici_acentepkey")

        Dim acentenincalistigisirketler As New List(Of CLASSSIRKET)
        doneceksirketler = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler_sirkettipinde(kullanici_acentepkey)

        Return doneceksirketler

    End Function

    '-- AKTİF ŞİRKETİ KAYDET -----------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aktifsirketkaydet(ByVal aktifsirketpkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        HttpContext.Current.Session("kullanici_aktifsirket") = aktifsirketpkey
        result.durum = "Kaydedildi"
        result.etkilenen = 1
        result.hatastr = ""

        Return result

    End Function


    '-- ŞİRKETİ BUL -----------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketbul(ByVal sirketpkey As String) As CLASSSIRKET

        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim sirket As New CLASSSIRKET
        sirket = sirket_erisim.bultek(sirketpkey)
        Return sirket

    End Function


    '-- ACENTE BİLGİ BUL
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function bulacente(ByVal sicilno As String, _
    ByVal sirketpkey As String) As CLASSACENTE

        Dim girdi As String = "Hayır"
        Dim sirketleri As New List(Of CLASSSIRKETACENTEBAG)

        Dim sirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        acente = acente_erisim.bulsicilnogore(sicilno)

        sirketleri = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler(acente.pkey)
        For Each sirketacentebagitem As CLASSSIRKETACENTEBAG In sirketleri
            If sirketpkey = sirketacentebagitem.sirketpkey Then
                girdi = "Evet"
            End If
        Next

        If girdi = "Evet" Then
            Return acente
        End If

        If girdi = "Hayır" Then
            acente.pkey = 0
            Return acente
        End If

    End Function

    'bak bakalım başka şirket tarafından bu acente tanımlanmış mı
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function acenteninbaglioldugusirketler(ByVal acentepkey As String) As List(Of CLASSSIRKETACENTEBAG)

        Dim sirketacentebaglar As New List(Of CLASSSIRKETACENTEBAG)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM

        sirketacentebaglar = sirketacentebag_erisim.doldur_acenteninbaglioldugusirketler(acentepkey)
        Return sirketacentebaglar

    End Function


    'bak bakalım başka şirket tarafından bu acente tanımlanmış mı
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function acenteoncedentanimlanmismi(ByVal acentepkey As String) As String

        Dim tanimlanmismi As String
        tanimlanmismi = "Evet"

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        acente = acente_erisim.bultek(acentepkey)
        If acente.yetkiemail = "" Then
            tanimlanmismi = "Hayır"
        End If

        Return tanimlanmismi


    End Function



    '---E-MAIL AYAR --------------------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function emailayarara(ByVal kriter As String) As List(Of CLASSEMAILAYAR)
        Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM
        Return (emailayar_erisim.ara(kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function emailayargoster(ByVal kriter As String) As String
        Dim emailayar_erisim As New CLASSEMAILAYAR_ERISIM
        HttpContext.Current.Session("ltip") = "hostname"
        HttpContext.Current.Session("kriter") = kriter
        Return (emailayar_erisim.listele())
    End Function


    '--- TEK RESİM ----------------------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function tekresimara(ByVal kriter As String) As List(Of CLASSTEKRESIM)
        Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
        HttpContext.Current.Session("ltip") = "ara"
        HttpContext.Current.Session("kriter") = kriter
        Return (tekresim_erisim.ara(kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function tekresimgoster(ByVal kriter As String) As String
        Dim donecek As String
        Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
        HttpContext.Current.Session("ltip") = "ara"
        HttpContext.Current.Session("kriter") = kriter
        donecek = tekresim_erisim.listele()
        Return donecek
    End Function

    'tek resim göster galeriye göre
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function tekresimgoster_galeriyegore(ByVal galeripkey As String) As String
        Dim donecek As String
        Dim tekresim_erisim As New CLASSTEKRESIM_ERISIM
        HttpContext.Current.Session("ltip") = "galeriyegore"
        HttpContext.Current.Session("kriter") = galeripkey
        donecek = tekresim_erisim.listele()
        Return donecek
    End Function


    '--- ARAÇ TARİFE ---------------------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aractarifeara1(ByVal kriter As String) As List(Of CLASSARACTARIFE)
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        Return (aractarife_erisim.ara("tarifekod", kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aractarifeara2(ByVal kriter As String) As List(Of CLASSARACTARIFE)
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        Return (aractarife_erisim.ara("tarifead", kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aractarifegoster1(ByVal kriter As String) As String
        Dim donecek As String
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        HttpContext.Current.Session("ltip") = "tarifekod"
        HttpContext.Current.Session("kriter") = kriter
        donecek = aractarife_erisim.listele()
        Return donecek
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aractarifegoster2(ByVal kriter As String) As String
        Dim donecek As String
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        HttpContext.Current.Session("ltip") = "tarifead"
        HttpContext.Current.Session("kriter") = kriter
        donecek = aractarife_erisim.listele()

        Return donecek

    End Function


    '--- SİRKET -------------------------------------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketara1(ByVal kriter As String) As List(Of CLASSSIRKET)
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Return (sirket_erisim.ara("yetkilikisiadsoyad", kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketgoster1(ByVal kriter As String) As String
        Dim donecek As String
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        HttpContext.Current.Session("ltip") = "yetkilikisiadsoyad"
        HttpContext.Current.Session("kriter") = kriter
        donecek = sirket_erisim.listele()
        Return donecek
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function logoolustur(ByVal resimpkey As String) As String

        Dim donecek As String
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        donecek = sirket_erisim.logoolustur(resimpkey)
        Return donecek

    End Function



    '--- ACENTE -------------------------------------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function acenteara1(ByVal kriter As String) As List(Of CLASSACENTE)
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Return (acente_erisim.ara("acentead", kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function acenteara2(ByVal kriter As String) As List(Of CLASSACENTE)
        Dim acente_erisim As New CLASSACENTE_ERISIM
        Return (acente_erisim.ara("sicilno", kriter))
    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function acentegoster1(ByVal kriter As String) As String
        Dim donecek As String
        Dim acente_erisim As New CLASSACENTE_ERISIM
        HttpContext.Current.Session("ltip") = "acentead"
        HttpContext.Current.Session("kriter") = kriter
        donecek = acente_erisim.listele()
        Return donecek
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function acentegoster2(ByVal kriter As String) As String
        Dim donecek As String
        Dim acente_erisim As New CLASSACENTE_ERISIM
        HttpContext.Current.Session("ltip") = "sicilno"
        HttpContext.Current.Session("kriter") = kriter
        donecek = acente_erisim.listele()
        Return donecek
    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aktifyap(ByVal pkey As String) As String

        'öncelikle bu acentede çalışan tüm kullanıcıları aktif yap
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        kullanici_erisim.acentekullanicilarini_aktifpasifyap(pkey, "Evet")

        Dim donecek As String
        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        acente = acente_erisim.bultek(pkey)
        acente.aktifmi = "Evet"
        acente_erisim.Duzenle(acente)

        HttpContext.Current.Session("ltip") = "TÜMÜ"
        donecek = acente_erisim.listele

        Return donecek

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function pasifyap(ByVal pkey As String) As String

        'öncelikle bu acentede çalışan tüm kullanıcıları pasif yap
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        kullanici_erisim.acentekullanicilarini_aktifpasifyap(pkey, "Hayır")

        Dim donecek As String
        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        acente = acente_erisim.bultek(pkey)
        acente.aktifmi = "Hayır"
        acente_erisim.Duzenle(acente)

        HttpContext.Current.Session("ltip") = "TÜMÜ"
        donecek = acente_erisim.listele

        Return donecek

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function aktifyapsirkettaraf(ByVal pkey As String) As String

        'öncelikle bu acentede çalışan tüm kullanıcıları aktif yap
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        kullanici_erisim.acentekullanicilarini_aktifpasifyap(pkey, "Evet")

        Dim donecek As String
        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        acente = acente_erisim.bultek(pkey)
        acente.aktifmi = "Evet"
        acente_erisim.Duzenle(acente)

        HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi"
        donecek = acente_erisim.listele_sirketadminicin

        Return donecek

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function pasifyapsirkettaraf(ByVal pkey As String) As String

        'öncelikle bu acentede çalışan tüm kullanıcıları pasif yap
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        kullanici_erisim.acentekullanicilarini_aktifpasifyap(pkey, "Hayır")

        Dim donecek As String
        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM

        acente = acente_erisim.bultek(pkey)
        acente.aktifmi = "Hayır"
        acente_erisim.Duzenle(acente)

        HttpContext.Current.Session("ltip") = "sadecekullanicininekledigi"
        donecek = acente_erisim.listele_sirketadminicin

        Return donecek

    End Function



    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function doldursirketinacenteleri(ByVal sirketpkey As String) As List(Of CLASSACENTE)

        Dim acenteler As New List(Of CLASSACENTE)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM

        acenteler = sirketacentebag_erisim.doldursirketinacenteleri_acentetipinde(sirketpkey)
        Return acenteler

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function doldursirketinacentelerionunekledigi(ByVal sirketpkey As String) As List(Of CLASSACENTE)

        Dim acenteler As New List(Of CLASSACENTE)
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM

        acenteler = sirketacentebag_erisim.doldursirketinacenteleri_acentetipindeonunekledigi(sirketpkey)
        Return acenteler

    End Function


    'ŞİRKET ACENTE BAĞ---------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketacentebagsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim sirketacentebag As New CLASSSIRKETACENTEBAG
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        result = sirketacentebag_erisim.Sil(pkey)
        Return result

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketacentebaggoster_sirketegore(ByVal sirketpkey As String) As String
        Dim donecek As String
        Dim sirketacentebag_erisim As New CLASSSIRKETACENTEBAG_ERISIM
        donecek = sirketacentebag_erisim.listele("sirket", sirketpkey)
        Return donecek
    End Function


    'ŞİRKET IP BAĞ--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketipbagsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim sirketipbag As New CLASSSIRKETIPBAG
        Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
        result = sirketipbag_erisim.Sil(pkey)
        Return result

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketipbaggoster_sirketegore(ByVal sirketpkey As String) As String
        Dim donecek As String
        Dim sirketipbag_erisim As New CLASSSIRKETIPBAG_ERISIM
        donecek = sirketipbag_erisim.listele("sirket", sirketpkey)
        Return donecek
    End Function



    'ŞİRKET FATURA E-POSTA BAĞ--------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketfaturabagsil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim sirketfaturabag As New CLASSSIRKETFATURABAG
        Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM
        result = sirketfaturabag_erisim.Sil(pkey)
        Return result

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketfaturabaggoster_sirketegore(ByVal sirketpkey As String) As String
        Dim donecek As String
        Dim sirketfaturabag_erisim As New CLASSSIRKETFATURABAG_ERISIM
        donecek = sirketfaturabag_erisim.listele("sirket", sirketpkey)
        Return donecek
    End Function

    '--- PERSONEL -------------------------------------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function personelara1(ByVal kriter As String) As List(Of CLASSPERSONEL)
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        Return (personel_erisim.ara("personeladsoyad", kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function personelara2(ByVal kriter As String) As List(Of CLASSPERSONEL)
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        Return (personel_erisim.ara("kimlikno", kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function personelara3(ByVal kriter As String) As List(Of CLASSPERSONEL)
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        Return (personel_erisim.ara("tpno", kriter))
    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function personelgoster(ByVal kriter As String) As String
        Dim donecek As String
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        donecek = personel_erisim.listele()
        Return donecek

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketcalisangoster(ByVal sirketpkey As String) As String

        Dim donecek As String = ""
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        donecek = personel_erisim.sirketinpersonellerinilistele(sirketpkey)
        Return donecek

    End Function

    '--- HESAP EKSTRE GÖSTER ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function onayla(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim personel As New CLASSPERSONEL
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        personel = personel_erisim.bultek(pkey)
        personel.onaylanmismi = "Evet"
        result = personel_erisim.Duzenle(personel)
        Return result

    End Function


    '--- BAZFİYAT -------------------------------------------------------------------------

    'BAZFİYAT KAYIT NUMARASINI BULMAYA YARAYAN FONKSİYON
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kayitnobul(ByVal sirketpkey As String) As Integer
        Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM
        Dim kac As Integer
        kac = bazfiyat_erisim.kayitnobul(sirketpkey)
        Return kac
    End Function



    '--- KULLANICILAR ----------------------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kullaniciara(ByVal kriter As String) As List(Of CLASSKULLANICI)
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        HttpContext.Current.Session("ltip") = "adsoyad"
        HttpContext.Current.Session("kriter") = kriter
        Return (kullanici_erisim.ara("adsoyad", kriter))
    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kullaniciara_sirkettarafinda(ByVal kriter As String) As List(Of CLASSKULLANICI)
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        HttpContext.Current.Session("ltip") = "sirkettarafindaadsoyadli"
        HttpContext.Current.Session("kriter") = kriter
        Return (kullanici_erisim.ara("adsoyad", kriter))
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function kullanicigoster(ByVal kriter As String) As String

        Dim donecek As String
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        HttpContext.Current.Session("ltip") = "adsoyad"
        HttpContext.Current.Session("kriter") = kriter
        donecek = kullanici_erisim.listele()
        Return donecek
    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function kullanicigoster_sirkettarafinda(ByVal kriter As String) As String

        Dim donecek As String
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        HttpContext.Current.Session("ltip") = "sirkettarafindaadsoyadli"
        HttpContext.Current.Session("kriter") = kriter
        donecek = kullanici_erisim.listele()
        Return donecek
    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function lockyonlendir(ByVal password As String) As String

        Dim sifreleme_erisim As New CLASSSIFRELEME_ERISIM
        Dim link As String

        If IsNumeric(HttpContext.Current.Session("kullanici_pkey")) = False Then
            link = "yonetimgiris.aspx"
        End If

        If IsNumeric(HttpContext.Current.Session("kullanici_pkey")) = True Then
            Dim kullanici As New CLASSKULLANICI
            Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
            kullanici = kullanici_erisim.bultek(HttpContext.Current.Session("kullanici_pkey"))

            'sifre dogru ise
            If kullanici.kullanicisifre = sifreleme_erisim.getMD5Hash(password) Then
                Dim kullanicirol As New CLASSKULLANICIROL
                Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
                kullanicirol = kullanicirol_erisim.bultek(kullanici.rolpkey)
                link = kullanicirol.yonsayfa
            End If

            'sifre yanliş ise
            If kullanici.kullanicisifre <> sifreleme_erisim.getMD5Hash(password) Then
                link = "yonetimgiris.aspx"
            End If

        End If

        Return link

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sifremigonder(ByVal eposta As String, _
    ByVal kullaniciad As String) As String

        Dim donecek As String
        Dim result As New CLADBOPRESULT

        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
        result = kullanici_Erisim.sifremigonder(eposta, kullaniciad)

        If result.durum = "Kaydedildi" Then
            donecek = "<div class='alert alert-success'>" + _
            "Şifreniz e-posta adresinize başarılı bir şekilde gönderildi" + _
            "</div>"
        End If

        If result.durum <> "Kaydedildi" Then
            donecek = "<div class='alert alert-danger'>" + result.hatastr + "</div>"
        End If

        Return donecek

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function doldurkullanicilar_grupagore(ByVal kullanicigruppkey As String) As List(Of CLASSKULLANICI)

        Dim result As New CLADBOPRESULT

        Dim kullanicilar As New List(Of CLASSKULLANICI)
        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM

        kullanicilar = kullanici_Erisim.doldur_kullanicigruppkeyegore_benimdisimda(kullanicigruppkey)

        Return kullanicilar

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function doldurkullanicilar_grupagore_mesajicin(ByVal kullanicigruppkey As String) As List(Of CLASSKULLANICI)

        Dim result As New CLADBOPRESULT

        Dim kullanicilar As New List(Of CLASSKULLANICI)
        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM

        kullanicilar = kullanici_Erisim.doldur_kullanicigruppkeyegore_benimdisimda_mesajicin(kullanicigruppkey)

        Return kullanicilar

    End Function



    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function doldursirketinacentelerinkullanicilari(ByVal sirketpkey As String, _
    ByVal acentepkey As String) As List(Of CLASSKULLANICI)

        Dim result As New CLADBOPRESULT
        Dim kullanicilar As New List(Of CLASSKULLANICI)
        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM
        kullanicilar = kullanici_Erisim.doldur_acentepkeyegore(acentepkey)

        Return kullanicilar

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sirketpoliceyuklemegrafikdata(ByVal neyegore As String) As List(Of CLASSGRAFIKBILGI)

        Dim policyinfo_Erisim As New PolicyInfo_Erisim
        Return policyinfo_Erisim.grafikdata(neyegore)

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function hasaryuklemegrafikdata(ByVal neyegore As String) As List(Of CLASSGRAFIKBILGI)

        Dim DamageInfo_Erisim As New DamageInfo_Erisim
        Return DamageInfo_Erisim.grafikdata(neyegore)

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function tekpolice_digerkisilertablo(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal ZeylCode As String, _
    ByVal ZeylNo As String, ByVal ProductType As String) As String

        Dim donecek As String
        Dim PolicyInfo_Erisim As New PolicyInfo_Erisim

        donecek = PolicyInfo_Erisim.tekpolice_digerkisilertablo(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, ZeylCode, ZeylNo, ProductType)

        Return donecek


    End Function


    'DAMAGECANCEL -----------------------------------------------------

    'sil
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function damagecancelsil(ByVal pkey As String) As CLADBOPRESULT

        Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM

        Dim result As New CLADBOPRESULT
        result = damagecancel_erisim.Sil(pkey)
        Return result

    End Function

    'goster
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function damagecancelgoster(ByVal FirmCode As String, ByVal ProductCode As String, _
    ByVal AgencyCode As String, ByVal PolicyNumber As String, _
    ByVal TecditNumber As String, ByVal FileNo As String, _
    ByVal RequestNo As String, ByVal ProductType As String) As String

        Dim donecek As String
        Dim damagecancel_erisim As New CLASSDAMAGECANCEL_ERISIM

        donecek = damagecancel_erisim.hasariptal_tablo(FirmCode, ProductCode, _
        AgencyCode, PolicyNumber, TecditNumber, FileNo, RequestNo, ProductType)

        Return donecek

    End Function


    'ilgili veritabanın tablolarını dolduruyoruz.
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function veritabanitablodoldur(ByVal veritabaniad As String) As List(Of CLASSVERITABANI)

        Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
        Dim tablolar As New List(Of CLASSVERITABANI)
        tablolar = sqlveritabani_erisim.doldurtabloadlari(veritabaniad)
        Return tablolar

    End Function


    'SADECE BABA MENULERİ GÖSTERİYORUZ
    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function doldursadecebaba(ByVal anamenupkey As String) As List(Of CLASSMENU)

        Dim menu_erisim As New CLASSMENU_ERISIM
        Dim menuler As New List(Of CLASSMENU)
        menuler = menu_erisim.doldursadecebaba(anamenupkey)
        Return menuler

    End Function

    'MENU SIRALAMA YAP
    <System.Web.Services.WebMethod(EnableSession:=True)> _
      Public Shared Sub menusiralamayap(ByVal anamenupkey As String, ByVal degerler As String)

        Dim menu_erisim As New CLASSMENU_ERISIM
        menu_erisim.siralamayap(anamenupkey, degerler)

    End Sub


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function siralamagosterrecursive(ByVal anamenupkey As String) As String


        Dim jvstring As String
        jvstring = "<script>" + _
        "jQuery(document).ready(function() {" + _
        "$('.sortable').bind('sortupdate', function(event, ui) {" + _
        "var anamenupkey;" + _
        "var siralaarr = new Array();" + _
        "var degerler = '';" + _
        "siralaarr = $(this).sortable('toArray');" + _
        "$.each(siralaarr, function(key, value) {" + _
            "degerler = degerler + value + ','" + _
        "});" + _
        "anamenupkey= document.getElementById('DropDownList9').value;" + _
        "degerler = degerler.substring(0, degerler.length - 1);" + _
        "var veriler = { anamenupkey:anamenupkey, degerler: degerler};" + _
        "$.ajax({" + _
        "type:   'POST'," + _
        "url:    'yonetimanaservis.aspx/menusiralamayap'," + _
        "contentType:  'application/json; charset=utf-8'," + _
        "dataType:  'json'," + _
        "data: $.toJSON(veriler),  " + _
        "success: function(result) {" + _
        "showtoast('info', 'Bilgi', 'Menu Sıralaması Değişti...');" + _
        "siralamagosterrecursive(anamenupkey);" + _
        "}," + _
        "error: function() {" + _
        "alert('Sıralama işlemini gerçekleştiremiyorum.');" + _
        "}" + _
        "});" + _
        "});" + _
            "$('.sortable').sortable({" + _
                "placeholder:  'ui-state-highlight'," + _
                "axis:   'y'," + _
            "});" + _
        "});" + _
        "</script>"

        Dim donecek As String
        Dim menu_erisim As New CLASSMENU_ERISIM
        donecek = menu_erisim.siralamagosterrecursive(anamenupkey, 0) + jvstring
        Return donecek

    End Function



    '--- SOL DAKİ MENUYU TEKRAR GÖSTERİYOR ----------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function menuyuyenile() As String

        Dim donecek As String
        Dim menu_Erisim As New CLASSMENU_ERISIM
        donecek = menu_Erisim.menuyuolustur
        Return donecek

    End Function


    '---ANASAYFADAN PLAKAYA GÖRE ARAMA -------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function plakaarayonlendir(ByVal plaka As String) As String

        Dim donecek As String
        Dim mensup As String
        mensup = HttpContext.Current.Session("kullanici_mensup")

        Dim site As New CLASSSITE
        Dim site_erisim As New CLASSSITE_ERISIM
        site = site_erisim.bultek(1)
        HttpContext.Current.Session("sirket") = "0"
        HttpContext.Current.Session("urunkodu") = "0"
        HttpContext.Current.Session("parabirimi") = "0"
        HttpContext.Current.Session("tarife") = "0"
        HttpContext.Current.Session("baslangic") = Site.kullanimbaslangictarih
        HttpContext.Current.Session("bitis") = DateTime.Now.AddYears(10)
        HttpContext.Current.Session("plakano") = UCase(plaka)
        HttpContext.Current.Session("zeylcode") = "P veya T"

        If mensup = "KKSBM" Then
            donecek = "policeara.aspx"
        Else
            donecek = "policearasirket.aspx"
        End If

        Return donecek

    End Function



    '---ANASAYFADAN PLAKAYA GÖRE ARAMA -------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
   Public Shared Function kimliknovetpnokontrol(ByVal kimlikno As String, _
   ByVal tpno As String) As CLASSPERSONEL

        Dim personel As New CLASSPERSONEL
        Dim personel_erisim As New CLASSPERSONEL_ERISIM
        personel = personel_erisim.bultpnovekimliknogore(tpno, kimlikno)
        Return personel

    End Function



    '---FATURALANDIR-------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function faturalandir(ByVal sirketkod As String, ByVal faturano As String, _
    ByVal policedegeri As String, ByVal ay As String, ByVal yil As String) As CLADBOPRESULT

        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim hesap As New CLASSHESAP
        Dim result As New CLADBOPRESULT

        hesap.firmcode = sirketkod
        hesap.aciklama = "Otomatik Faturalandırma İşlemi"
        hesap.faturano = faturano
        hesap.tarih = DateTime.Now
        hesap.tip = "Gelir"
        hesap.tutar = policedegeri
        hesap.ay = ay
        hesap.yil = yil
        hesap.eder = HttpContext.Current.Session("eder")
        hesap.tur = "Fatura"
        hesap.oran = 0

        result = hesap_erisim.Ekle(hesap)
        Return result


    End Function


    '---FATURA RAPORUNU YENİDEN LİSTELE-------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listelefaturarapor() As String

        Dim rapor As New CLASSRAPOR
        Dim raporozel_erisim As New CLASSFATURA_ERISIM
        HttpContext.Current.Session("hangirapor") = "1"
        rapor = raporozel_erisim.temelrapor
        Return rapor.veri

    End Function


    '---FATURA SİL-------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function faturasil(ByVal faturano As String) As CLADBOPRESULT

        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim hesap As New CLASSHESAP
        Dim result As New CLADBOPRESULT
        result = hesap_erisim.sil_faturanovetipveturegore(faturano, "Gelir", "Fatura")
        Return result

    End Function


    '---FATURA EMAİL GÖNDER-------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function faturaemailgonder(ByVal faturano As String) As CLADBOPRESULT

        Dim hesap_erisim As New CLASSHESAP_ERISIM

        Dim result As New CLADBOPRESULT
        result = hesap_erisim.emailgonder(faturano)

        Return result

    End Function

    '--- HESAP SİL ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function hesapsil(ByVal pkey As String) As CLADBOPRESULT

        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim result As New CLADBOPRESULT
        result = hesap_erisim.Sil(pkey)

        Return result

    End Function


    '--- HESAP EKSTRE GÖSTER ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ekstregoster(ByVal firmcode As String) As String

        Dim donecek As String
        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim result As New CLADBOPRESULT

        HttpContext.Current.Session("ltip") = "ekstre"
        HttpContext.Current.Session("firmcode") = CStr(firmcode)
        donecek = hesap_erisim.listele()

        Return donecek

    End Function


    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function doldurrollersirketicin(ByVal sirketpkey As String, ByVal acentepkey As String) As List(Of CLASSKULLANICIROL)


        Dim kullaniciroller As New List(Of CLASSKULLANICIROL)

        Dim kullanicirol As New CLASSKULLANICIROL
        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM

        Dim acente As New CLASSACENTE
        Dim acente_erisim As New CLASSACENTE_ERISIM
        acente = acente_erisim.bultek(acentepkey)

        If acente.merkezmi = "Evet" Then
            kullaniciroller = kullanicirol_erisim.doldur_sadecesirketinverebilecegi_rol("Evet")
        End If
        If acente.merkezmi = "Hayır" Then
            kullaniciroller = kullanicirol_erisim.doldur_sadecesirketinverebilecegi_rol("Hayır")
        End If

        Return kullaniciroller

    End Function



    '--- ÖZEL RAPOR LOG GÖSTER ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ozelraporloggoster() As String

        Dim donecek As String
        Dim ozelraporlog_erisim As New CLASSOZELRAPORLOG_ERISIM
        donecek = ozelraporlog_erisim.listele()
        Return donecek

    End Function


    '--- ÖZEL RAPOR LOG SİL ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function ozelraporlogsil(ByVal pkey As String) As CLADBOPRESULT

        Dim ozelraporlog_erisim As New CLASSOZELRAPORLOG_ERISIM
        Dim result As New CLADBOPRESULT
        result = ozelraporlog_erisim.Sil(pkey)

        Return result

    End Function



    '--- BACK SERVİS LOG GÖSTER ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function backservisloggoster() As String

        Dim donecek As String
        Dim backservislog_erisim As New CLASSBACKSERVISLOG_ERISIM
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        donecek = backservislog_erisim.listele()
        Return donecek

    End Function


    '--- ÖZEL RAPOR LOG SİL ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function backservislogsil(ByVal pkey As String) As CLADBOPRESULT

        Dim backservislog_erisim As New CLASSBACKSERVISLOG_ERISIM

        Dim result As New CLADBOPRESULT
        result = backservislog_erisim.Sil(pkey)

        Return result

    End Function



    '--- KULLANICININ BAĞLANTISINI KES ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function baglantikesyap(ByVal kacdakika As String, ByVal kullanicipkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim kullanici As New CLASSKULLANICI
        Dim kullanici_Erisim As New CLASSKULLANICI_ERISIM

        kullanici = kullanici_Erisim.bultek(kullanicipkey)

        'ÖNCE BAĞLANTIYI KES
        Dim baglantikes As New CLASSBAGLANTIKES
        Dim baglantikes_erisim As New CLASSBAGLANTIKES_ERISIM

        baglantikes.kesenkullanicipkey = HttpContext.Current.Session("kullanici_pkey")
        baglantikes.kesilenkullanicipkey = kullanicipkey
        baglantikes.kesmebaslangictarih = DateTime.Now
        baglantikes.kesmebitistarih = DateTime.Now.AddMinutes(kacdakika)
        result = baglantikes_erisim.Ekle(baglantikes)

        If result.durum = "Kaydedildi" Then

            'ÇIKIŞ İÇİN LOG EKLE
            Dim loggenel As New CLASSLOGGENEL
            Dim loggenel_erisim As New CLASSLOGGENEL_ERISIM

            loggenel = New CLASSLOGGENEL(0, DateTime.Now, kullanicipkey, "Admin", _
              "kullanici", "Çıkış", "", "", 0, "Hayır", HttpContext.Current.Session("kullanici_adsoyad"), "", "Web")
            loggenel_erisim.Ekle(loggenel)


        End If

        Return result

    End Function


    '--- ONLINE KULLANICILARI LİSTELE ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listeleonline() As String

        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        Return kullanici_erisim.onlinekullanicilar()

    End Function


    '--- BAĞLANTISI KEİLMİŞ KULLANICILARI LİSTELE ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function listelekesilmis() As String

        Dim baglantikes_erisim As New CLASSBAGLANTIKES_ERISIM
        Return baglantikes_erisim.listele

    End Function


    '--- BAĞLANTIKES SİL ------------------------------------------
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function baglantikessil(ByVal pkey As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim baglantikes_erisim As New CLASSBAGLANTIKES_ERISIM
        result = baglantikes_erisim.Sil(pkey)
        Return result

    End Function


    'SINIR KAPI İP SİL
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sinirkapiipsil(ByVal pkey As String) As CLADBOPRESULT

        Dim sinirkapiip_erisim As New CLASSSINIRKAPIIP_ERISIM
        Dim result As New CLADBOPRESULT
        result = sinirkapiip_erisim.Sil(pkey)

        Return result

    End Function


    'SINIR KAPI IP GÖSTER
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function sinirkapiipgoster_sinirkapigore(ByVal sinirkapipkey As String) As String

        Dim donecek As String
        Dim sinirkapiip_erisim As New CLASSSINIRKAPIIP_ERISIM
        HttpContext.Current.Session("ltip") = "ilgili"
        HttpContext.Current.Session("sinirkapipkey") = sinirkapipkey
        donecek = sinirkapiip_erisim.listele()
        Return donecek

    End Function



    'PLAKADIŞ AUTO COMPLETE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function autocompleteplakadis(ByVal plaka As String) As List(Of CLASSPLAKADIS)

        Dim plakadis_erisim As New CLASSPLAKADIS_ERISIM
        Dim plakadislar As New List(Of CLASSPLAKADIS)

        plakadislar = plakadis_erisim.doldur_plakayagore(plaka)
        Return plakadislar

    End Function


    'PLAKADIŞ LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function plakalistele(ByVal plaka As String) As String

        Dim donecek As String
        Dim plakadis_erisim As New CLASSPLAKADIS_ERISIM

        HttpContext.Current.Session("ltip") = "ARAMA"
        HttpContext.Current.Session("plaka") = plaka
        donecek = plakadis_erisim.listele
        Return donecek

    End Function




    'ARAÇ KAYIT DAİRE AUTO COMPLETE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function autocompletearackayitdaire(ByVal PlakaNo As String) As List(Of CLASSARACKAYITDAIRE)

        Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
        Dim arackayitdaireler As New List(Of CLASSARACKAYITDAIRE)
        arackayitdaireler = arackayitdaire_erisim.doldur_plakayagore(PlakaNo)
        Return arackayitdaireler

    End Function


    'ARAÇ KAYIT DAİRE LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function arackayitdairelistele(ByVal PlakaNo As String) As String

        Dim donecek As String
        Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM

        HttpContext.Current.Session("ltip") = "ARAMA"
        HttpContext.Current.Session("PlakaNo") = PlakaNo
        donecek = arackayitdaire_erisim.listele()
        Return donecek

    End Function




    'PLAKA SINIR KAPI AUTO COMPLETE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function autocompleteplakasinirkapi(ByVal plaka As String) As List(Of CLASSPLAKASINIRKAPI)

        Dim plakasinirkapi_erisim As New CLASSPLAKASINIRKAPI_ERISIM
        Dim plakasinirkapilar As New List(Of CLASSPLAKASINIRKAPI)

        plakasinirkapilar = plakasinirkapi_erisim.doldur_plakayagore(plaka)
        Return plakasinirkapilar

    End Function


    'PLAKA SINIR KAPI LİSTELE
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function plakasinirkapilistele(ByVal plaka As String) As String

        Dim donecek As String
        Dim plakasinirkapi_erisim As New CLASSPLAKASINIRKAPI_ERISIM

        HttpContext.Current.Session("ltip") = "ARAMA"
        HttpContext.Current.Session("plaka") = plaka
        donecek = plakasinirkapi_erisim.listele
        Return donecek

    End Function




End Class