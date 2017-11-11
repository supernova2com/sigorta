Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports HttpContext.Current
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState


Public Class CLASSFATURA_ERISIM

    Dim donecekrapor As New CLASSRAPOR
    Dim ekrapor As New CLASSRAPOR
    Dim sqldevam As String

    Dim tarihdon As New CLATARIH
    Dim tarih_erisim As New CLATARIH_ERISIM
    Dim baslangictarih, bitistarih As Date
    Dim sqlsiralamadevam As String
    Dim siralamaopsiyon As String
    Dim sqlsiralama As String
    Dim geneltoplam As Integer = 0
    Dim sqlstr, istring As String
    Dim veri As SqlDataReader
    Dim komut As SqlCommand

    'RAPORUN BAŞLIĞINI VE VERİSİNİ OLUŞTURAN ANA FONKSİYON
    Public Function temelrapor() As CLASSRAPOR

        Dim donecekrapor As New CLASSRAPOR

        If Current.Session("hangirapor") = "1" Then

            donecekrapor = rapor1yap()
            Return donecekrapor

        End If


    End Function


    Function rapor1yap() As CLASSRAPOR

        Dim rapor As New CLASSRAPOR
        Dim eder As Decimal = HttpContext.Current.Session("eder")

        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10 As String
        Dim jvstring, tabloson As String

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
            "<tr>" + _
                "<th>Seç</th>" + _
                "<th>Şirket Kodu</th>" + _
                "<th>Şirket Adı</th>" + _
                "<th>Eder</th>" + _
                "<th>Poliçe Adeti</th>" + _
                "<th>Poliçe Değeri</th>" + _
                "<th>Faturalandır</th>" + _
                "<th>Yazdır</th>" + _
                "<th>Gönder</th>" + _
                "<th>Ödeme/Gecikme</th>" + _
            "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        Dim recordcount As Integer = 0
        Dim sirketler As New List(Of CLASSSIRKET)
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim PolicyInfo_erisim As New PolicyInfo_Erisim
        Dim policeadeti As Integer
        Dim policedegeri As Decimal
        Dim toplampoliceadeti, toplampolicedegeri As Decimal
        Dim secinput As String
        Dim faturano As String
        Dim hesap_erisim As New CLASSHESAP_ERISIM

        Dim ajaxfaturalandirlink As String
        Dim ajaxfaturasillink As String
        Dim ajaxfaturayazdirlink As String
        Dim ajaxfaturagonderlink As String

        Dim ajaxfaturaodemelink, faturaodemedugme As String

        Dim faturagonderdugme As String

        Dim data_pkey As String
        Dim bpkey As String

        Dim fdugme As String
        Dim faturayazdirdugme As String

        Dim ay, yil As String
        Dim dahaoncefaturalandirilmismi As String
        Dim oncedenhesap As New CLASSHESAP

        toplampoliceadeti = 0
        toplampolicedegeri = 0

        ay = Current.Session("ay")
        yil = Current.Session("yil")

        sirketler = sirket_erisim.dolduraktifseceneksadecesirket(Current.Session("aktif"))

        For Each Item As CLASSSIRKET In sirketler

            dahaoncefaturalandirilmismi = hesap_erisim.dahaoncefaturalandirilmismi(Item.sirketkod, ay, yil, "Gelir", "Fatura")

            If dahaoncefaturalandirilmismi = "Hayır" Then
                bpkey = hesap_erisim.pkeybul
                faturano = CStr(Item.sirketkod) + "-" + CStr(bpkey) + _
                "-" + CStr(Current.Session("yil")) + CStr(Current.Session("ay"))
                data_pkey = bpkey
            End If
            If dahaoncefaturalandirilmismi = "Evet" Then
                oncedenhesap = hesap_erisim.bulcoklu(Item.sirketkod, ay, yil, "Gelir", "Fatura")
                faturano = CStr(Item.sirketkod) + "-" + CStr(oncedenhesap.pkey) + _
                "-" + CStr(Current.Session("yil")) + CStr(Current.Session("ay"))
                data_pkey = CStr(oncedenhesap.pkey)
            End If

            secinput = "<input type=" + Chr(34) + "checkbox" + Chr(34) + _
            " class=" + Chr(34) + "checkbox" + Chr(34) + _
            " id=" + Chr(34) + "A_" + CStr(Item.sirketkod) + Chr(34) + _
            " name=" + Chr(34) + "A_" + CStr(Item.sirketkod) + Chr(34) + _
            " data-pkey=" + Chr(34) + data_pkey + Chr(34) + _
            "/>"

            kol1 = "<tr><td>" + secinput + "</td>"
            kol2 = "<td>" + Item.sirketkod + "</td>"



            'KOL3------------------------------------------------------------------------------
            ajaxfaturaodemelink = "odemepopup.aspx?faturano=" + faturano + _
                  "&firmcode=" + Item.sirketkod + _
                  "&op=yenikayit&k=1"

            faturaodemedugme = "<a class='iframeyenikayit' href='" + ajaxfaturaodemelink + "'" + _
            " target='_blank'><span class='button'>Hesap Haraketleri</span></a>"
            kol3 = "<td>" + Item.sirketad + "<br/>" + _
            faturaodemedugme+ "</td>"
            '------------------------------------------------------------------------------

            'EDER KOLONU -------------------------------------------------------
            If dahaoncefaturalandirilmismi = "Hayır" Then
                eder = Format(Current.Session("eder"))
            Else
                eder = Format(oncedenhesap.eder, "0.00")
            End If
            kol4 = "<td>" + CStr(eder) + "</td>"
            '-------------------------------------------------------------------

            policeadeti = sayibul(Item.sirketkod)
            policedegeri = policeadeti * Current.Session("eder")
            toplampoliceadeti = toplampoliceadeti + policeadeti
            toplampolicedegeri = toplampolicedegeri + policedegeri
            kol5 = "<td>" + CStr(policeadeti) + "</td>"
            kol6 = "<td>" + Format(policedegeri, "0.00") + "</td>"


            '----FATURALANDIRMA DÜĞMESİ ----------------------------------------
            If dahaoncefaturalandirilmismi = "Evet" Then
                ajaxfaturasillink = "faturasil(" + Chr(34) + faturano + Chr(34) + ")"
                fdugme = "<span onclick='" + ajaxfaturasillink + "'" + _
                " class=" + Chr(34) + "button" + Chr(34) + ">Faturayı Sil</span>"
            End If
            If dahaoncefaturalandirilmismi = "Hayır" Then
                ajaxfaturalandirlink = "faturalandir(" + Chr(34) + Item.sirketkod + Chr(34) + "," + Chr(34) + _
                faturano + Chr(34) + "," + Chr(34) + CStr(policedegeri) + Chr(34) + _
                "," + Chr(34) + ay + Chr(34) + "," + Chr(34) + yil + Chr(34) + ")"

                fdugme = "<span onclick='" + ajaxfaturalandirlink + "'" + _
                " class=" + Chr(34) + "button" + Chr(34) + ">Faturalandır</span>"
            End If
            kol7 = "<td>" + fdugme + "</td>"
            '-----------------------------------------------------------------------


            '----YAZDIR DÜĞMESİ ----------------------------------------------------
            If dahaoncefaturalandirilmismi = "Evet" Then
                ajaxfaturayazdirlink = "faturayazdir.aspx?faturano=" + faturano
                faturayazdirdugme = "<a href='" + ajaxfaturayazdirlink + "'" + _
                " target='_blank'><span class='button'>Yazdır</span></a>"
                kol8 = "<td>" + faturayazdirdugme + "</td>"
            Else
                kol8 = "<td><span>Faturalandırılmamış</span></td>"
            End If
            '-----------------------------------------------------------------------

            '---GÖNDER DÜĞMESİ --------------------------------------
            If dahaoncefaturalandirilmismi = "Evet" Then
                ajaxfaturagonderlink = "faturagonder(" + Chr(34) + faturano + Chr(34) + ")"
                faturagonderdugme = "<span onclick='" + ajaxfaturagonderlink + "'" + _
                " class=" + Chr(34) + "button" + Chr(34) + ">Gönder</span>"
                kol9 = "<td>" + faturagonderdugme + "</td>"
            Else
                kol9 = "<td><span>Faturalandırılmamış</span></td>"
            End If

            '---ÖDEME DÜĞMESİ --------------------------------------
            If dahaoncefaturalandirilmismi = "Evet" Then

                ajaxfaturaodemelink = "odemepopup.aspx?faturano=" + faturano + _
                "&firmcode=" + Item.sirketkod + _
                "&op=yenikayit"

                faturaodemedugme = "<a class='iframeyenikayit' href='" + ajaxfaturaodemelink + "'" + _
                " target='_blank'><span class='button'>Ödeme/Gecikme</span></a>"
                kol10 = "<td>" + faturaodemedugme + "</td></tr>"
            Else
                kol10 = "<td><span>Faturalandırılmamış</span></td></tr>"
            End If

            satir = satir + kol1 + kol2 + kol3 + kol4 + _
            kol5 + kol6 + kol7 + kol8 + kol9 + kol10

        Next

        satir = satir + _
        "<td>Toplam</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>" + Format(toplampoliceadeti, "0.00") + "</td>" + _
        "<td>" + Format(toplampolicedegeri, "0.00") + "</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>-</td></tr>"


        rapor.baslik = CStr(baslangictarih) + " ile " + CStr(bitistarih) + " arasında Poliçe Değer Raporu"
        rapor.veri = jvstring + basliklar + satir + tabloson

        Return rapor


    End Function



    Public Function sayibul(ByVal FirmCode As String) As Integer

        Dim kayitsayisi As Integer

        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim ayinsongunu As Integer = System.DateTime.DaysInMonth(HttpContext.Current.Session("yil"), HttpContext.Current.Session("ay"))
        baslangictarih = "01." + HttpContext.Current.Session("ay") + "." + HttpContext.Current.Session("yil") + " 00:00:00"
        bitistarih = CStr(ayinsongunu) + "." + HttpContext.Current.Session("ay") + "." + HttpContext.Current.Session("yil") + " 23:59:59"

        Dim sqldevam1 As String = ""
        Dim sqldevam2 As String = ""

        'tüm poliçe tipleri
        If Current.Session("policetip") <> "Tümü" And Current.Session("policetip") <> "4" Then
            sqldevam1 = " and PolicyType=@PolicyType"
        End If
        'normal ve sınır kapısı birlikte
        If Current.Session("policetip") = "4" Then
            sqldevam1 = " and (PolicyType=@PolicyType1 or PolicyType=@PolicyType2)"
        End If


        If Current.Session("urunkod") <> "Tümü" Then
            sqldevam2 = " and ProductCode=@ProductCode"
        End If

        sqlstr = "SELECT count(*) FROM PolicyInfo where " + _
        "(ArrangeDate>=@baslangictarih and ArrangeDate<=@bitistarih) " + _
        " and FirmCode=@FirmCode and (ZeylCode='P' or ZeylCode='T')" + _
        sqldevam1 + sqldevam2

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangictarih", SqlDbType.DateTime)
        komut.Parameters("@baslangictarih").Value = baslangictarih

        komut.Parameters.Add("@bitistarih", SqlDbType.DateTime)
        komut.Parameters("@bitistarih").Value = bitistarih

        komut.Parameters.Add("@FirmCode", SqlDbType.VarChar)
        komut.Parameters("@FirmCode").Value = FirmCode

        If Current.Session("policetip") <> "Tümü" And Current.Session("policetip") <> "4" Then
            komut.Parameters.Add("@PolicyType", SqlDbType.Int)
            komut.Parameters("@PolicyType").Value = Current.Session("policetip")
        End If

        'normal + sinir kapisi secilmis
        If Current.Session("policetip") = "4" Then
            komut.Parameters.Add("@PolicyType1", SqlDbType.Int)
            komut.Parameters("@PolicyType1").Value = "1"

            komut.Parameters.Add("@PolicyType2", SqlDbType.Int)
            komut.Parameters("@PolicyType2").Value = "3"
        End If


        If Current.Session("urunkod") <> "Tümü" Then
            komut.Parameters.Add("@ProductCode", SqlDbType.VarChar)
            komut.Parameters("@ProductCode").Value = Current.Session("urunkod")
        End If

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kayitsayisi = 0
        Else
            kayitsayisi = maxkayit1
        End If

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return kayitsayisi

    End Function



End Class
