Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports HttpContext.Current
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSOZELRAPOR2_ERISIM

    Dim donecekrapor As New CLASSRAPOR
    Dim ekrapor As New CLASSRAPOR
    Dim sqldevam As String

    Dim tarihdon As New CLATARIH
    Dim tarih_erisim As New CLATARIH_ERISIM
    Dim baslangictarihp, bitistarihp As Date
    Dim sqlsiralamadevam As String
    Dim siralamaopsiyon As String
    Dim sqlsiralama As String
    Dim geneltoplam As Integer = 0
    Dim sirket As New CLASSSIRKET
    Dim sirket_erisim As New CLASSSIRKET_ERISIM

    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim fieldopvalue2 As New CLASSFIELDOPERATORVALUE2
    Dim fieldopvalues2 As New List(Of CLASSFIELDOPERATORVALUE2)
    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM

    Dim veritabaniad As String = System.Configuration.ConfigurationManager.AppSettings("veritabaniad")

    'RAPORUN BAŞLIĞINI VE VERİSİNİ OLUŞTURAN ANA FONKSİYON
    Public Function temelrapor() As CLASSRAPOR

        Dim sqlstr, istring As String
        Dim veri As SqlDataReader

        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand

        '1. RAPOR --------------------------------------------------------------
        If Current.Session("hangirapor") = "1" Then

            Dim baslik As String

            sqlstr = "select cc.pkey as pkey, tuzukaractippkey, baslangicc, bitiscc, tuzukaractipad " + _
            "from cc,tuzukaractip where cc.tuzukaractippkey=tuzukaractip.pkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            baslik = Current.Session("baslangictarih") + " İLE " + Current.Session("bitistarih") + _
            " TARİHLERİ ARASINDA " + UCase(Current.Session("rbaslik")) + " RAPORU"

            donecekrapor.baslik = baslik
            veri = komut.ExecuteReader
            ekrapor = veriyarat(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If


        '1. RAPOR --------------------------------------------------------------
        If Current.Session("hangirapor") = "2" Then

            ekrapor = veriyaratsinirkapi()

            donecekrapor.baslik = ekrapor.baslik
            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo
            Return donecekrapor

        End If

    End Function



    'HESAP VERİSİ İÇİN----------------------
    Public Function veriyarat(ByVal db_baglanti As SqlConnection, _
     ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim sqlcartypedevam As String = ""
        Dim tabload As String = "PolicyInfo"
        Dim tuzukaractip_erisim As New CLASSTUZUKARACTIP_ERISIM
        Dim tuzukaractip As New CLASSTUZUKARACTIP
        Dim dairearactip As New CLASSDAIREARACTIP
        Dim dairearactip_erisim As New CLASSDAIREARACTIP_ERISIM

        Dim tuzukdairearactipbaglar As New List(Of CLASSTUZUKDAIREARACTIPBAG)
        Dim tuzukdairearactipbag As New CLASSTUZUKDAIREARACTIPBAG
        Dim tuzukdairearactipbag_erisim As New CLASSTUZUKDAIREARACTIPBAG_ERISIM


        Dim tablolar As New List(Of CLASSTEK)
        tablolar.Add(New CLASSTEK("PolicyInfo"))
        tablolar.Add(New CLASSTEK("DamageInfo"))

        Dim baslangictarih, bitistarih As Date
        Dim firmcode, currencycode, productcode, tariffcode, policytype, hangipoliceler, tarihtip As String

        baslangictarih = HttpContext.Current.Session("baslangictarih")
        bitistarih = HttpContext.Current.Session("bitistarih")
        firmcode = HttpContext.Current.Session("firmcode")
        currencycode = HttpContext.Current.Session("currencycode")
        productcode = HttpContext.Current.Session("productcode")
        tariffcode = HttpContext.Current.Session("tariffcode")
        policytype = HttpContext.Current.Session("policytype")
        hangipoliceler = HttpContext.Current.Session("hangipoliceler")
        tarihtip = HttpContext.Current.Session("tarihtip")

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9 As String
        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Araç Tipi</th>" + _
        "<th>Başlangıç CC</th>" + _
        "<th>Bitiş CC</th>" + _
        "<th>Poliçe Adeti</th>" + _
        "<th>Toplam Poliçe Primi TL</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Araç Tipi", GetType(String))
        table.Columns.Add("Başlangıç CC", GetType(String))
        table.Columns.Add("Bitiş CC", GetType(String))
        table.Columns.Add("Poliçe Adeti", GetType(String))
        table.Columns.Add("Toplam Poliçe Primi TL", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(5)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Araç Tipi", fbaslik))
        pdftable.AddCell(New Phrase("Başlangıç CC", fbaslik))
        pdftable.AddCell(New Phrase("Bitiş CC", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe Adeti", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Poliçe Primi TL", fbaslik))

        tabloson = "</tbody></table>"

        Dim tuzukaractipad, baslangicc, bitiscc As String
        Dim policeadet, prim As Decimal
        Dim muallakhasar_adet, muallakhasar_miktar As Decimal
        Dim odenenhasar_adet, odenenhasar_miktar As Decimal

        While veri.Read

            girdi = "1"

            'CARTYPE
            If Not veri.Item("tuzukaractipad") Is System.DBNull.Value Then
                tuzukaractipad = veri.Item("tuzukaractipad")
                tuzukaractip = tuzukaractip_erisim.bultek_adagore(tuzukaractipad)
                tuzukdairearactipbaglar = tuzukdairearactipbag_erisim.doldurilgili(tuzukaractip.pkey)
                kol1 = "<tr><td>" + tuzukaractipad + "</td>"
                saf1 = tuzukaractipad
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            sqlcartypedevam = ""
            For Each Item As CLASSTUZUKDAIREARACTIPBAG In tuzukdairearactipbaglar
                dairearactip = dairearactip_erisim.bultek(Item.dairearactippkey)
                sqlcartypedevam = sqlcartypedevam + "CarType='" + dairearactip.dairearactipad + "' or "
            Next

            sqlcartypedevam = Mid(sqlcartypedevam, 1, Len(sqlcartypedevam) - 3)
            sqlcartypedevam = "(" + sqlcartypedevam + ")"


            'BAŞLANGIÇ CC
            If Not veri.Item("baslangicc") Is System.DBNull.Value Then
                baslangicc = veri.Item("baslangicc")
                kol2 = "<td>" + baslangicc + "</td>"
                saf2 = baslangicc
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If

            'BİTİŞ CC
            If Not veri.Item("bitiscc") Is System.DBNull.Value Then
                bitiscc = veri.Item("bitiscc")
                kol3 = "<td>" + bitiscc + "</td>"
                saf3 = bitiscc
            Else
                kol3 = "<td>-</td>"
                saf3 = "-"
            End If

            'POLİÇE ADETİ 
            policeadet = policerakamgenel(baslangictarih, bitistarih, firmcode, _
            currencycode, productcode, tariffcode, _
            policytype, hangipoliceler, tarihtip, tuzukaractipad, baslangicc, bitiscc, _
            "adet", sqlcartypedevam)
            kol4 = "<td>" + Format(policeadet, "0.00") + "</td>"
            saf4 = Format(policeadet, "0.00")

         

            'TOPLAM POLİÇE PRİMİ TL
            prim = policerakamgenel(baslangictarih, bitistarih, firmcode, _
            currencycode, productcode, tariffcode, _
            policytype, hangipoliceler, tarihtip, tuzukaractipad, baslangicc, bitiscc, _
            "prim", sqlcartypedevam)
            kol5 = "<td>" + prim.ToString("N2") + "</td></tr>"
            saf5 = CStr(prim.ToString("N2"))


            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5


            table.Rows.Add(saf1, saf2, saf3, saf4, saf5)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf3, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
          
        End While

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
            ekrapor.kacadet = recordcount
            ekrapor.veri = donecek
            ekrapor.tablo = table
            ekrapor.pdftablo = pdftable
        Else
            ekrapor.kacadet = 0
            ekrapor.veri = "Herhangi bir kayıt bulunamadı"
        End If

        Return ekrapor

    End Function



    Function policerakamgenel(ByVal p_baslangictarih As Date, ByVal p_bitistarih As Date, _
    ByVal p_firmcode As String, ByVal p_currencycode As String, _
    ByVal p_productcode As String, ByVal p_tariffcode As String, _
    ByVal p_policytype As String, ByVal p_hangipoliceler As String, _
    ByVal p_tarihtip As String, ByVal p_tuzukaractipad As String, _
    ByVal p_baslangic_cc As Integer, ByVal p_bitis_cc As Integer, _
    ByVal p_nedonecek As String, _
    ByVal p_sqlcartypedevam As String) As Decimal


        Dim sqlstr, istring As String

        Dim p_t_toplamadet As Decimal = 0
        Dim pp_prim As Decimal = 0

        Dim pp_pmiktarTL, pp_tmiktarTL, pp_vmiktarTL, pp_rmiktarTL, pp_xmiktarTL As Decimal

        Dim padet, tadet, vadet, radet, xadet As Decimal

        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand

        Dim sqldevam As String = ""
        Dim sqldevamtarih As String = ""
        If p_tarihtip <> "StartDate" Then
            sqldevamtarih = " StartDate>=@baslangictarih and StartDate<=@bitistarih "
        End If
        If p_tarihtip <> "ArrangeDate" Then
            sqldevamtarih = " ArrangeDate>=@baslangictarih and ArrangeDate<=@bitistarih "
        End If
        If p_firmcode <> "Tümü" Then
            sqldevam = " and FirmCode=@FirmCode "
        End If
        If p_currencycode <> "Tümü" Then
            sqldevam = sqldevam + " and CurrencyCode=@CurrencyCode "
        End If
        If p_productcode <> "Tümü" Then
            sqldevam = sqldevam + " and ProductCode=@ProductCode "
        End If
        If p_tariffcode <> "Tümü" Then
            sqldevam = sqldevam + " and TariffCode=@TariffCode "
        End If
        If p_policytype <> "Tümü" Then
            sqldevam = sqldevam + " and PolicyType=@PolicyType "
        End If
        If p_hangipoliceler <> "Tümü" Then
            sqldevam = sqldevam + " and Color=@Color "
        End If

        Dim baslik As String

        sqlstr = "SELECT " + _
        "SUM(case when ZeylCode =  'P' then PolicyPremiumTL end) as pp_pmiktarTL," + _
        "SUM(case when ZeylCode =  'T' then PolicyPremiumTL end) as pp_tmiktarTL," + _
        "SUM(case when ZeylCode =  'V' then PolicyPremiumTL end) as pp_vmiktarTL," + _
        "SUM(case when ZeylCode =  'R' then PolicyPremiumTL end) as pp_rmiktarTL," + _
        "SUM(case when ZeylCode =  'X' then PolicyPremiumTL end) as pp_xmiktarTL," + _
        "count(case when ZeylCode =  'P' then 1 end) as padet," + _
        "count(case when ZeylCode =  'T' then 1 end) as tadet," + _
        "count(case when ZeylCode =  'V' then 1 end) as vadet," + _
        "count(case when ZeylCode =  'R' then 1 end) as radet," + _
        "count(case when ZeylCode =  'X' then 1 end) as xadet " + _
        "from PolicyInfo where " + p_sqlcartypedevam + _
        " and " + _
        sqldevamtarih + sqldevam + " and " + _
        "(EnginePower>=@baslangic_cc and EnginePower<=@bitis_cc) "


        komut = New SqlCommand(sqlstr, db_baglanti)

        '600/60=10 dakika
        komut.CommandTimeout = 600

        If p_firmcode <> "Tümü" Then
            Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = p_firmcode
            komut.Parameters.Add(param1)
        End If
        If p_currencycode <> "Tümü" Then
            Dim param2 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            param2.Value = p_currencycode
            komut.Parameters.Add(param2)
        End If
        If p_productcode <> "Tümü" Then
            Dim param4 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            param4.Value = p_productcode
            komut.Parameters.Add(param4)
        End If
        If p_tariffcode <> "Tümü" Then
            Dim param5 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            param5.Value = p_tariffcode
            komut.Parameters.Add(param5)
        End If
        If p_policytype <> "Tümü" Then
            Dim param6 As New SqlParameter("@PolicyType", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            param6.Value = p_policytype
            komut.Parameters.Add(param6)
        End If
        If p_hangipoliceler <> "Tümü" Then
            Dim param7 As New SqlParameter("@Color", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            param7.Value = p_hangipoliceler
            komut.Parameters.Add(param7)
        End If

        Dim param8 As New SqlParameter("@baslangictarih", SqlDbType.Date)
        param8.Direction = ParameterDirection.Input
        param8.Value = p_baslangictarih
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@bitistarih", SqlDbType.Date)
        param9.Direction = ParameterDirection.Input
        param9.Value = p_bitistarih
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@CarType", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        param10.Value = p_tuzukaractipad
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@baslangic_cc", SqlDbType.Int)
        param11.Direction = ParameterDirection.Input
        param11.Value = p_baslangic_cc
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@bitis_cc", SqlDbType.Int)
        param12.Direction = ParameterDirection.Input
        param12.Value = p_bitis_cc
        komut.Parameters.Add(param12)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()


                'SUM LAR POLICYPREMIUM İÇİN-------------------------------------------------------
                If Not veri.Item("pp_pmiktarTL") Is System.DBNull.Value Then
                    pp_pmiktarTL = veri.Item("pp_pmiktarTL")
                Else
                    pp_pmiktarTL = 0
                End If
                If Not veri.Item("pp_tmiktarTL") Is System.DBNull.Value Then
                    pp_tmiktarTL = veri.Item("pp_tmiktarTL")
                Else
                    pp_tmiktarTL = 0
                End If
                If Not veri.Item("pp_vmiktarTL") Is System.DBNull.Value Then
                    pp_vmiktarTL = veri.Item("pp_vmiktarTL")
                Else
                    pp_vmiktarTL = 0
                End If
                If Not veri.Item("pp_rmiktarTL") Is System.DBNull.Value Then
                    pp_rmiktarTL = veri.Item("pp_rmiktarTL")
                Else
                    pp_rmiktarTL = 0
                End If
                If Not veri.Item("pp_xmiktarTL") Is System.DBNull.Value Then
                    pp_xmiktarTL = veri.Item("pp_xmiktarTL")
                Else
                    pp_xmiktarTL = 0
                End If
                pp_prim = ((pp_pmiktarTL + pp_tmiktarTL + pp_vmiktarTL) - (pp_rmiktarTL + pp_xmiktarTL))

                'SUMLAR ADETLER
                If Not veri.Item("padet") Is System.DBNull.Value Then
                    padet = veri.Item("padet")
                Else
                    padet = 0
                End If
                If Not veri.Item("tadet") Is System.DBNull.Value Then
                    tadet = veri.Item("tadet")
                Else
                    tadet = 0
                End If
                If Not veri.Item("vadet") Is System.DBNull.Value Then
                    vadet = veri.Item("vadet")
                Else
                    vadet = 0
                End If
                If Not veri.Item("radet") Is System.DBNull.Value Then
                    radet = veri.Item("radet")
                Else
                    radet = 0
                End If
                If Not veri.Item("xadet") Is System.DBNull.Value Then
                    xadet = veri.Item("xadet")
                Else
                    xadet = 0
                End If
                p_t_toplamadet = padet + tadet
                '-------------------------------------------------------------------

            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        If p_nedonecek = "adet" Then
            Return p_t_toplamadet
        End If

        If p_nedonecek = "prim" Then
            Return pp_prim
        End If


    End Function




    'SINIR KAPISI RAPORU----------------------
    Public Function veriyaratsinirkapi() As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim basliklar, satir As String
        Dim kol1, kol2 As String
        Dim saf1, saf2 As String

        Dim jvstring, tabloson As String

        Dim baslangictarih, bitistarih As Date
        baslangictarih = HttpContext.Current.Session("baslangictarih")
        bitistarih = HttpContext.Current.Session("bitistarih")

        Dim sinirkapibaslik As String
        Dim sinirkapilar As New List(Of CLASSSINIRKAPI)
        Dim sinirkapi_Erisim As New CLASSSINIRKAPI_ERISIM
        sinirkapilar = sinirkapi_Erisim.doldur

        For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
            sinirkapibaslik = sinirkapibaslik + "<th>" + itemsinirkapi.sinirkapiad + "</th>"
        Next

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Başlangıç Tarihi</th>" + _
        "<th>Bitiş Tarihi</th>" + _
        sinirkapibaslik + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Başlangıç Tarihi", GetType(String))
        table.Columns.Add("Bitiş Tarihi", GetType(String))
        For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
            table.Columns.Add(itemsinirkapi.sinirkapiad, GetType(String))
        Next
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(sinirkapilar.Count + 2)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Şirket Adı", fbaslik))
        For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
            pdftable.AddCell(New Phrase(itemsinirkapi.sinirkapiad, fbaslik))
        Next
        tabloson = "</tbody></table>"

        Dim sirketkod, sirketad As String
        Dim adet As Decimal
        Dim koldevam(sinirkapilar.Count - 1) As String
        Dim safdevam(sinirkapilar.Count - 1) As String

        Dim toplam_aralik1(sinirkapilar.Count - 1) As Integer
        Dim toplam_aralik2(sinirkapilar.Count - 1) As Integer
        Dim toplam_aralik3(sinirkapilar.Count - 1) As Integer

        Dim i As Integer

        Dim bir_baslangic_saat As String
        Dim bir_baslangic_dakika As String
        Dim bir_bitis_saat As String
        Dim bir_bitis_dakika As String

        Dim iki_baslangic_saat As String
        Dim iki_baslangic_dakika As String
        Dim iki_bitis_saat As String
        Dim iki_bitis_dakika As String

        Dim uc_baslangic_saat As String
        Dim uc_baslangic_dakika As String
        Dim uc_bitis_saat As String
        Dim uc_bitis_dakika As String

        Dim toplamyazi As String = ""

        Dim anatoplam_aralik1, anatoplam_aralik2, anatoplam_aralik3 As Integer
        anatoplam_aralik1 = 0
        anatoplam_aralik2 = 0
        anatoplam_aralik3 = 0

        bir_baslangic_saat = HttpContext.Current.Session("bir_baslangic_saat")
        bir_baslangic_dakika = HttpContext.Current.Session("bir_baslangic_dakika")
        bir_bitis_saat = HttpContext.Current.Session("bir_bitis_saat")
        bir_bitis_dakika = HttpContext.Current.Session("bir_bitis_dakika")

        iki_baslangic_saat = HttpContext.Current.Session("iki_baslangic_saat")
        iki_baslangic_dakika = HttpContext.Current.Session("iki_baslangic_dakika")
        iki_bitis_saat = HttpContext.Current.Session("iki_bitis_saat")
        iki_bitis_dakika = HttpContext.Current.Session("iki_bitis_dakika")

        uc_baslangic_saat = HttpContext.Current.Session("uc_baslangic_saat")
        uc_baslangic_dakika = HttpContext.Current.Session("uc_baslangic_dakika")
        uc_bitis_saat = HttpContext.Current.Session("uc_bitis_saat")
        uc_bitis_dakika = HttpContext.Current.Session("uc_bitis_dakika")

        While baslangictarih <= bitistarih

            Dim tarih1_bas As New DateTime(baslangictarih.Year, baslangictarih.Month, baslangictarih.Day, bir_baslangic_saat, bir_baslangic_dakika, "00")
            Dim tarih1_son As New DateTime(baslangictarih.Year, baslangictarih.Month, baslangictarih.Day, bir_bitis_saat, bir_bitis_dakika, "59")

            Dim tarih2_bas As New DateTime(baslangictarih.Year, baslangictarih.Month, baslangictarih.Day, iki_baslangic_saat, iki_baslangic_dakika, "00")
            Dim tarih2_son As New DateTime(baslangictarih.Year, baslangictarih.Month, baslangictarih.Day, iki_bitis_saat, iki_bitis_dakika, "59")

            Dim tarih3_bas As New DateTime(baslangictarih.Year, baslangictarih.Month, baslangictarih.Day, uc_baslangic_saat, uc_baslangic_dakika, "00")
            Dim tarih3_son As New DateTime(baslangictarih.Year, baslangictarih.Month, baslangictarih.Day, uc_bitis_saat, uc_bitis_dakika, "59")


            '3 TARİH İÇİN DÖN
            For a = 1 To 3

                Dim sorgulanacaktarih_bas, sorgulanacaktarih_son As DateTime

                If a = 1 Then
                    sorgulanacaktarih_bas = tarih1_bas
                    sorgulanacaktarih_son = tarih1_son
                End If
                If a = 2 Then
                    sorgulanacaktarih_bas = tarih2_bas
                    sorgulanacaktarih_son = tarih2_son
                End If
                If a = 3 Then
                    sorgulanacaktarih_bas = tarih3_bas
                    sorgulanacaktarih_son = tarih3_son
                End If

                kol1 = "<tr><td>" + CStr(sorgulanacaktarih_bas) + "</td>"
                saf1 = CStr(sorgulanacaktarih_bas)

                kol2 = "<td>" + CStr(sorgulanacaktarih_son) + "</td>"
                saf2 = CStr(sorgulanacaktarih_son)

                i = 0
                For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar

                    fieldopvalues.Clear()
                    If Current.Session("firmcode") <> "Tümü" Then
                        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                    End If
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", "3", " and "))
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "BorderCode", "=", CStr(itemsinirkapi.sinirkapikod), " and "))
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE(" (", "StartDate", ">=", sorgulanacaktarih_bas, " and "))
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "StartDate", "<=", sorgulanacaktarih_son, ") and "))
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE(" (", "ZeylCode", "=", "P", " or "))
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ZeylCode", "=", "T", ") "))

                    adet = genericislem_erisim.countgeneric(veritabaniad, "PolicyInfo", "count(*)", fieldopvalues)

                    If a = 1 Then
                        toplam_aralik1(i) = toplam_aralik1(i) + adet
                        anatoplam_aralik1 = anatoplam_aralik1 + adet
                    End If
                    If a = 2 Then
                        toplam_aralik2(i) = toplam_aralik2(i) + adet
                        anatoplam_aralik2 = anatoplam_aralik2 + adet
                    End If
                    If a = 3 Then
                        toplam_aralik3(i) = toplam_aralik3(i) + adet
                        anatoplam_aralik3 = anatoplam_aralik3 + adet
                    End If

                    koldevam(i) = "<td>" + Format(adet, "0.00") + "</td>"
                    safdevam(i) = Format(adet, "0.00")
                    i = i + 1

                Next

                recordcount = recordcount + 1

                'TOPLAM YAZİ 
                toplamyazi = tarih1_bas + " - " + tarih1_son + ": " + "<b>" + CStr(anatoplam_aralik1) + "</b><br/>" + _
                tarih2_bas + " - " + tarih2_son + ": " + "<b>" + CStr(anatoplam_aralik2) + "</b><br/>" + _
                tarih3_bas + " - " + tarih3_son + ": " + "<b>" + CStr(anatoplam_aralik3) + "</b><br/>"

                'HTML KISMINI OLUŞTUR GÜN GÜN POLİÇE ADETLERİNİ BAS
                satir = satir + kol1 + kol2
                i = 0
                For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
                    satir = satir + koldevam(i)
                    i = i + 1
                Next

                'WORD EXCEL KISMINI OLUŞTUR GÜN GÜN POLİÇE ADETLERİNİ BAS
                Dim R As DataRow = table.NewRow
                R(0) = saf1
                R(1) = saf2
                i = 0
                For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
                    R(i + 2) = safdevam(i)
                    i = i + 1
                Next
                table.Rows.Add(R)

                'PDF KISMINI OLUŞTUR GÜN GÜN POLİÇE ADETLERİNİ BAS
                pdftable.AddCell(New Phrase(saf1, fdata))
                pdftable.AddCell(New Phrase(saf2, fdata))
                i = 0
                For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
                    pdftable.AddCell(New Phrase(safdevam(i), fdata))
                    i = i + 1
                Next

            Next '3 tarih içerisinde dolaş

            baslangictarih = baslangictarih.AddDays(1)

        End While



        'TOPLAMLARI --------------------------------------------------------------------------------

        'bunlar hep toplam satırlarının ilk 2 kolunu
        Dim ilk_2_kolon_aralik1 As String = ""
        Dim ilk_2_kolon_aralik2 As String = ""
        Dim ilk_2_kolon_aralik3 As String = ""

        ilk_2_kolon_aralik1 = "<tr><td>" + baslangictarih + " " + bir_baslangic_saat + ":" + bir_baslangic_dakika + "</td>" + _
        "<td>" + bitistarih + " " + bir_bitis_saat + ":" + bir_bitis_dakika + "</td>"

        ilk_2_kolon_aralik2 = "<tr><td>" + baslangictarih + " " + iki_baslangic_saat + ":" + iki_baslangic_dakika + "</td>" + _
        "<td>" + bitistarih + " " + iki_bitis_saat + ":" + iki_bitis_dakika + "</td>"

        ilk_2_kolon_aralik3 = "<tr><td>" + baslangictarih + " " + uc_baslangic_saat + ":" + uc_baslangic_dakika + "</td>" + _
        "<td>" + bitistarih + " " + uc_bitis_saat + ":" + uc_bitis_dakika + "</td>"

     
        'ÜÇ ARALIK İÇİNDE DOLAŞ VE TOPLAMLARI EKLE. 
        For a = 1 To 3

            Dim R As DataRow = table.NewRow

            i = 0
            'birinci aralik için toplamları yazdır
            If a = 1 Then
                satir = satir + ilk_2_kolon_aralik1
                R(0) = baslangictarih + " " + bir_baslangic_saat + ":" + bir_baslangic_dakika
                R(1) = bitistarih + " " + bir_bitis_saat + ":" + bir_bitis_dakika
                pdftable.AddCell(New Phrase(baslangictarih + " " + bir_baslangic_saat + ":" + bir_baslangic_dakika, fdata))
                pdftable.AddCell(New Phrase(bitistarih + " " + bir_bitis_saat + ":" + bir_bitis_dakika, fdata))

                For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
                    satir = satir + "<td>" + CStr(toplam_aralik1(i)) + "</td>"
                    R(i + 2) = CStr(toplam_aralik1(i))
                    pdftable.AddCell(New Phrase(toplam_aralik1(i), fdata))
                    i = i + 1
                Next
                table.Rows.Add(R)
            End If

            'ikinci aralik için toplamları yazdır
            If a = 2 Then
                satir = satir + ilk_2_kolon_aralik2
                R(0) = baslangictarih + " " + iki_baslangic_saat + ":" + iki_baslangic_dakika
                R(1) = bitistarih + " " + iki_bitis_saat + ":" + iki_bitis_dakika
                pdftable.AddCell(New Phrase(baslangictarih + " " + iki_baslangic_saat + ":" + iki_baslangic_dakika, fdata))
                pdftable.AddCell(New Phrase(bitistarih + " " + iki_bitis_saat + ":" + iki_bitis_dakika, fdata))

                For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
                    satir = satir + "<td>" + CStr(toplam_aralik2(i)) + "</td>"
                    R(i + 2) = CStr(toplam_aralik2(i))
                    pdftable.AddCell(New Phrase(toplam_aralik2(i), fdata))
                    i = i + 1
                Next
                table.Rows.Add(R)
            End If

            'üçüncü aralik için toplamları yazdır
            If a = 3 Then
                satir = satir + ilk_2_kolon_aralik3
                R(0) = baslangictarih + " " + uc_baslangic_saat + ":" + uc_baslangic_dakika
                R(1) = bitistarih + " " + uc_bitis_saat + ":" + uc_bitis_dakika
                pdftable.AddCell(New Phrase(baslangictarih + " " + uc_baslangic_saat + ":" + uc_baslangic_dakika, fdata))
                pdftable.AddCell(New Phrase(bitistarih + " " + uc_bitis_saat + ":" + uc_bitis_dakika, fdata))

                For Each itemsinirkapi As CLASSSINIRKAPI In sinirkapilar
                    satir = satir + "<td>" + CStr(toplam_aralik3(i)) + "</td>"
                    R(i + 2) = CStr(toplam_aralik3(i))
                    pdftable.AddCell(New Phrase(toplam_aralik3(i), fdata))
                    i = i + 1
                Next
                table.Rows.Add(R)
            End If

        Next



        'EN SON HEPSİNİ BİRLEŞTİR -----------------------------------------------------------
        donecek = basliklar + satir + tabloson + toplamyazi + jvstring
        ekrapor.baslik = HttpContext.Current.Session("baslangictarih") + " - " + _
        HttpContext.Current.Session("bitistarih") + " arasında Sınır Kapısı Bazında Poliçe Adeti Raporu"

        ekrapor.kacadet = recordcount
        ekrapor.veri = donecek
        ekrapor.tablo = table
        ekrapor.pdftablo = pdftable

        Return ekrapor

    End Function

End Class
