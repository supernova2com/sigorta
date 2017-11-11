Imports System.Data.SqlClient
Imports System.Data.OracleClient
Imports HttpContext.Current
Imports System.Collections.Generic
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSOZELRAPOR_ERISIM

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

            sirket = sirket_erisim.bultek(Current.Session("sirketpkey"))

            sqlstr = "SELECT * FROM hesap where firmcode=@firmcode and" + _
            " tarih>=@baslangictarih and tarih<=@bitistarih order by firmcode"

            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            Dim param1 As New SqlParameter("@firmcode", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = sirket.sirketkod
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@baslangictarih", SqlDbType.Date)
            param2.Direction = ParameterDirection.Input
            param2.Value = Current.Session("baslangictarih")
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@bitistarih", SqlDbType.Date)
            param3.Direction = ParameterDirection.Input
            param3.Value = Current.Session("bitistarih")
            komut.Parameters.Add(param3)

            donecekrapor.baslik = Current.Session("baslangictarih") + " İLE " + _
            Current.Session("bitistarih") + " TARİHLERİ ARASINDA " + _
            sirket.sirketad + " ŞİRKETİNİN HESAP HAREKETLERİ"

            veri = komut.ExecuteReader
            ekrapor = veriyarat(db_baglanti, veri, komut)

            Dim hesaptablo As String
            Dim gelir, gider, bakiye As Double
            Dim hesap_erisim As New CLASSHESAP_ERISIM
            gelir = hesap_erisim.gelirbultarihli(sirket.sirketkod, Current.Session("baslangictarih"), _
            Current.Session("bitistarih"))
            gider = hesap_erisim.giderbultarihli(sirket.sirketkod, Current.Session("baslangictarih"), _
            Current.Session("bitistarih"))
            bakiye = hesap_erisim.bakiyebultarihli(sirket.sirketkod, Current.Session("baslangictarih"), _
            Current.Session("bitistarih"))

            hesaptablo = "<br/><br/>" + _
            "Gelir:" + Format(gelir, "0.00") + " TL" + "<br/>" + _
            "Gider:" + Format(gider, "0.00") + " TL" + "<br/>" + _
            "Bakiye:" + Format(bakiye, "0.00") + " TL"

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri + hesaptablo
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If

        '2. RAPOR -----------------------------------------------------------
        If Current.Session("hangirapor") = "2" Then

            sqlstr = "SELECT * FROM sirket order by sirketkod"

            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            donecekrapor.baslik = Current.Session("baslangictarih") + " İLE " + _
            Current.Session("bitistarih") + " TARİHLERİ ARASINDA BAKİYE RAPORU"

            veri = komut.ExecuteReader
            ekrapor = veriyarat2(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If

       
        '4. RAPOR --------------------------------------------------------
        If Current.Session("hangirapor") = "4" Then

            If Current.Session("firmcode") <> "Tümü" Then
                sqldevam = " and sirketkod=@sirketkod "
            Else
                sqldevam = ""
            End If

            Dim baslik As String

            sqlstr = "SELECT * FROM sirket where tip=@tip" + sqldevam
            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            Dim param1 As New SqlParameter("@tip", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Şirket"
            komut.Parameters.Add(param1)

            If Current.Session("firmcode") <> "Tümü" Then
                Dim param2 As New SqlParameter("@sirketkod", SqlDbType.VarChar)
                param2.Direction = ParameterDirection.Input
                param2.Value = Current.Session("firmcode")
                komut.Parameters.Add(param2)
            End If

            baslik = Current.Session("baslangictarih") + " İLE " + Current.Session("bitistarih") + _
            " TARİHLERİ ARASINDA POLİÇELERİN ZEYİL KODLARINA GÖRE DAĞILIMI"

            donecekrapor.baslik = baslik

            veri = komut.ExecuteReader
            ekrapor = veriyarat4(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If



        '6. RAPOR ------------------------------------------------------------------
        If Current.Session("hangirapor") = "6" Then

            If Current.Session("firmcode") <> "Tümü" Then
                sqldevam = " and sirketkod=@sirketkod "
            Else
                sqldevam = ""
            End If
            Dim baslik As String

            sqlstr = "SELECT * FROM sirket where tip=@tip" + sqldevam
            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            Dim param1 As New SqlParameter("@tip", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Şirket"
            komut.Parameters.Add(param1)

            If Current.Session("firmcode") <> "Tümü" Then
                Dim param2 As New SqlParameter("@sirketkod", SqlDbType.VarChar)
                param2.Direction = ParameterDirection.Input
                param2.Value = Current.Session("firmcode")
                komut.Parameters.Add(param2)
            End If

            baslik = Current.Session("baslangictarih") + " İLE " + Current.Session("bitistarih") + _
            " TARİHLERİ ARASINDA HASARLARIN HASAR DURUM KODLARINA GÖRE DAĞILIMI"

            donecekrapor.baslik = baslik
            veri = komut.ExecuteReader
            ekrapor = veriyarat6(db_baglanti, veri, komut)

            komut.Dispose()
            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If


        '7. RAPOR SEKTÖR GENEL ŞİRKET GENEL---------------------------------------------
        If Current.Session("hangirapor") = "7" Then

            Dim sqldevamtarih As String
            If Current.Session("tarihtip") = "StartDate" Then
                sqldevamtarih = " StartDate>=@baslangictarih and StartDate<=@bitistarih "
            End If
            If Current.Session("tarihtip") = "ArrangeDate" Then
                sqldevamtarih = " ArrangeDate>=@baslangictarih and ArrangeDate<=@bitistarih "
            End If

            sqldevam = ""
            If Current.Session("firmcode") <> "Tümü" Then
                sqldevam = " and FirmCode=@FirmCode "
            End If

            If Current.Session("currencycode") <> "Tümü" Then
                sqldevam = sqldevam + " and CurrencyCode=@CurrencyCode "
            End If


            If Current.Session("productcode") <> "Tümü" Then
                sqldevam = sqldevam + " and ProductCode=@ProductCode "
            End If

            If Current.Session("tariffcode") <> "Tümü" Then
                sqldevam = sqldevam + " and TariffCode=@TariffCode "
            End If

            If Current.Session("policytype") <> "Tümü" Then
                sqldevam = sqldevam + " and PolicyType=@PolicyType "
            End If

            If Current.Session("hangipoliceler") <> "Tümü" Then
                sqldevam = sqldevam + " and Color=@Color "
            End If


            Dim baslik As String

            sqlstr = "SELECT TariffCode," + _
            "ProductCode," + _
            "CurrencyCode," + _
            "COUNT(*) as adet," + _
            "sum(PublicValue) as kasko," + _
            "sum(PublicValueTL) as kaskoTL," + _
            "SUM(case when ZeylCode =  'P' then PolicyPremium end) as pp_pmiktar," + _
            "SUM(case when ZeylCode =  'T' then PolicyPremium end) as pp_tmiktar," + _
            "SUM(case when ZeylCode =  'V' then PolicyPremium end) as pp_vmiktar," + _
            "SUM(case when ZeylCode =  'R' then PolicyPremium end) as pp_rmiktar," + _
            "SUM(case when ZeylCode =  'X' then PolicyPremium end) as pp_xmiktar," + _
            "SUM(case when ZeylCode =  'P' then InsurancePremium end) as ip_pmiktar," + _
            "SUM(case when ZeylCode =  'T' then InsurancePremium end) as ip_tmiktar," + _
            "SUM(case when ZeylCode =  'V' then InsurancePremium end) as ip_vmiktar," + _
            "SUM(case when ZeylCode =  'R' then InsurancePremium end) as ip_rmiktar," + _
            "SUM(case when ZeylCode =  'X' then InsurancePremium end) as ip_xmiktar," + _
            "SUM(case when ZeylCode =  'P' then PolicyPremiumTL end) as pp_pmiktarTL," + _
            "SUM(case when ZeylCode =  'T' then PolicyPremiumTL end) as pp_tmiktarTL," + _
            "SUM(case when ZeylCode =  'V' then PolicyPremiumTL end) as pp_vmiktarTL," + _
            "SUM(case when ZeylCode =  'R' then PolicyPremiumTL end) as pp_rmiktarTL," + _
            "SUM(case when ZeylCode =  'X' then PolicyPremiumTL end) as pp_xmiktarTL," + _
            "SUM(case when ZeylCode =  'P' then InsurancePremiumTL end) as ip_pmiktarTL," + _
            "SUM(case when ZeylCode =  'T' then InsurancePremiumTL end) as ip_tmiktarTL," + _
            "SUM(case when ZeylCode =  'V' then InsurancePremiumTL end) as ip_vmiktarTL," + _
            "SUM(case when ZeylCode =  'R' then InsurancePremiumTL end) as ip_rmiktarTL," + _
            "SUM(case when ZeylCode =  'X' then InsurancePremiumTL end) as ip_xmiktarTL," + _
            "SUM(case when ZeylCode =  'P' then PublicValueTL end) as pv_pmiktarTL," + _
            "SUM(case when ZeylCode =  'T' then PublicValueTL end) as pv_tmiktarTL," + _
            "SUM(case when ZeylCode =  'V' then PublicValueTL end) as pv_vmiktarTL," + _
            "SUM(case when ZeylCode =  'R' then PublicValueTL end) as pv_rmiktarTL," + _
            "SUM(case when ZeylCode =  'X' then PublicValueTL end) as pv_xmiktarTL," + _
            "count(case when ZeylCode =  'P' then 1 end) as padet," + _
            "count(case when ZeylCode =  'T' then 1 end) as tadet," + _
            "count(case when ZeylCode =  'V' then 1 end) as vadet," + _
            "count(case when ZeylCode =  'R' then 1 end) as radet," + _
            "count(case when ZeylCode =  'X' then 1 end) as xadet " + _
            "from PolicyInfo where " + sqldevamtarih + sqldevam + _
            "group by TariffCode,ProductCode,CurrencyCode " + _
            "order by TariffCode,CurrencyCode"

            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            If Current.Session("firmcode") <> "Tümü" Then
                Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
                param1.Direction = ParameterDirection.Input
                param1.Value = HttpContext.Current.Session("firmcode")
                komut.Parameters.Add(param1)
            End If

            If Current.Session("currencycode") <> "Tümü" Then
                Dim param2 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
                param2.Direction = ParameterDirection.Input
                param2.Value = HttpContext.Current.Session("currencycode")
                komut.Parameters.Add(param2)
            End If

            If Current.Session("productcode") <> "Tümü" Then
                Dim param4 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
                param4.Direction = ParameterDirection.Input
                param4.Value = HttpContext.Current.Session("productcode")
                komut.Parameters.Add(param4)
            End If

            If Current.Session("tariffcode") <> "Tümü" Then
                Dim param5 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
                param5.Direction = ParameterDirection.Input
                param5.Value = HttpContext.Current.Session("tariffcode")
                komut.Parameters.Add(param5)
            End If

            If Current.Session("policytype") <> "Tümü" Then
                Dim param6 As New SqlParameter("@PolicyType", SqlDbType.Int)
                param6.Direction = ParameterDirection.Input
                param6.Value = HttpContext.Current.Session("policytype")
                komut.Parameters.Add(param6)
            End If

            If Current.Session("hangipoliceler") <> "Tümü" Then
                Dim param7 As New SqlParameter("@Color", SqlDbType.VarChar)
                param7.Direction = ParameterDirection.Input
                param7.Value = HttpContext.Current.Session("hangipoliceler")
                komut.Parameters.Add(param7)
            End If

            Dim param8 As New SqlParameter("@baslangictarih", SqlDbType.Date)
            param8.Direction = ParameterDirection.Input
            param8.Value = Current.Session("baslangictarih")
            komut.Parameters.Add(param8)


            Dim param9 As New SqlParameter("@bitistarih", SqlDbType.Date)
            param9.Direction = ParameterDirection.Input
            param9.Value = Current.Session("bitistarih")
            komut.Parameters.Add(param9)


            baslik = Current.Session("baslangictarih") + " İLE " + Current.Session("bitistarih") + _
            " TARİHLERİ ARASINDA " + UCase(Current.Session("rbaslik")) + " RAPORU"

            donecekrapor.baslik = baslik

            veri = komut.ExecuteReader
            ekrapor = veriyarat7(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If


        '8. RAPOR --------------------------------------------------------
        If Current.Session("hangirapor") = "8" Then

            Dim sqldevam1, sqldevam2, sqldevam3 As String

            If Current.Session("FirmCode") <> "Tümü" Then
                sqldevam1 = " and FirmCode=@FirmCode "
            Else
                sqldevam1 = ""
            End If

            If Current.Session("PolicyType") <> "Tümü" Then
                sqldevam2 = " and PolicyType=@PolicyType "
            Else
                sqldevam2 = ""
            End If

            If Current.Session("ProductCode") <> "Tümü" Then
                sqldevam3 = " and ProductCode=@ProductCode "
            Else
                sqldevam3 = ""
            End If


            Dim baslik As String

            sqlstr = "select TariffCode," + _
            "SUM(CASE WHEN DamagelessRate=0 THEN 1 else 0 end) as DamagelessRate_sifir, " + _
            "SUM(CASE WHEN DamagelessRate=10 THEN 1 else 0 end) as DamagelessRate_on, " + _
            "SUM(CASE WHEN DamagelessRate=20 THEN 1 else 0 end) as DamagelessRate_yirmi, " + _
            "SUM(CASE WHEN DamagelessRate=30 THEN 1 else 0 end) as DamagelessRate_otuz, " + _
            "SUM(CASE WHEN DamagelessRate=40 THEN 1 else 0 end) as DamagelessRate_kirk, " + _
            "SUM(CASE WHEN DamageRate=0 THEN 1 else 0 end) as DamageRate_sifir, " + _
            "SUM(CASE WHEN DamageRate=15 THEN 1 else 0 end) as DamageRate_onbes, " + _
            "SUM(CASE WHEN DamageRate=20 THEN 1 else 0 end) as DamageRate_yirmi, " + _
            "SUM(CASE WHEN DamageRate=25 THEN 1 else 0 end) as DamageRate_yirmibes, " + _
            "SUM(CASE WHEN DamageRate=30 THEN 1 else 0 end) as DamageRate_otuz, " + _
            "SUM(CASE WHEN DamageRate=35 THEN 1 else 0 end) as DamageRate_otuzbes, " + _
            "SUM(CASE WHEN DamageRate=40 THEN 1 else 0 end) as DamageRate_kirk, " + _
            "SUM(CASE WHEN DamageRate=50 THEN 1 else 0 end) as DamageRate_elli, " + _
            "SUM(CASE WHEN AgeRate=0 THEN 1 else 0 end) as AgeRate_sifir, " + _
            "SUM(CASE WHEN AgeRate=15 THEN 1 else 0 end) as AgeRate_onbes, " + _
            "SUM(CASE WHEN AgeRate=30 THEN 1 else 0 end) as AgeRate_otuz, " + _
            "SUM(CASE WHEN CCRate=0 THEN 1 else 0 end) as CCRate_sifir, " + _
            "SUM(CASE WHEN CCRate=5 THEN 1 else 0 end) as CCRate_bes, " + _
            "SUM(CASE WHEN CCRate=15 THEN 1 else 0 end) as CCRate_onbes, " + _
            "SUM(CASE WHEN CCRate=20 THEN 1 else 0 end) as CCRate_yirmi, " + _
            "SUM(CASE WHEN CCRate=25 THEN 1 else 0 end) as CCRate_yirmibes, " + _
            "SUM(CASE WHEN CCRate=30 THEN 1 else 0 end) as CCRate_otuz, " + _
            "SUM(CASE WHEN CCRate=35 THEN 1 else 0 end) as CCRate_otuzbes, " + _
            "SUM(CASE WHEN CCRate=45 THEN 1 else 0 end) as CCRate_kirkbes, " + _
            "SUM(CASE WHEN CCRate=50 THEN 1 else 0 end) as CCRate_elli, " + _
            "SUM(CASE WHEN CCRate=75 THEN 1 else 0 end) as CCRate_yetmisbes " + _
            "from PolicyInfo " + _
            "where StartDate>=@baslangictarih and StartDate<=@bitistarih and " + _
            "(ZeylCode='P' or ZeylCode='T') " + _
            sqldevam1 + sqldevam2 + sqldevam3 + _
            "group by TariffCode"

            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600


            Dim param1 As New SqlParameter("@baslangictarih", SqlDbType.Date)
            param1.Direction = ParameterDirection.Input
            param1.Value = Current.Session("baslangictarih")
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@bitistarih", SqlDbType.Date)
            param2.Direction = ParameterDirection.Input
            param2.Value = Current.Session("bitistarih")
            komut.Parameters.Add(param2)


            If Current.Session("FirmCode") <> "Tümü" Then
                Dim param3 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
                param3.Direction = ParameterDirection.Input
                param3.Value = Current.Session("FirmCode")
                komut.Parameters.Add(param3)
            End If

            If Current.Session("PolicyType") <> "Tümü" Then
                Dim param4 As New SqlParameter("@PolicyType", SqlDbType.Int)
                param4.Direction = ParameterDirection.Input
                param4.Value = Current.Session("PolicyType")
                komut.Parameters.Add(param4)
            End If

            If Current.Session("ProductCode") <> "Tümü" Then
                Dim param5 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
                param5.Direction = ParameterDirection.Input
                param5.Value = Current.Session("ProductCode")
                komut.Parameters.Add(param5)
            End If


            baslik = Current.Session("baslangictarih") + " İLE " + Current.Session("bitistarih") + _
            " TARİHLERİ ARASINDA ORANLARIN TARİFE KODLARINA GÖRE DAĞILIMI"

            donecekrapor.baslik = baslik

            veri = komut.ExecuteReader
            ekrapor = veriyarat12(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If






        '9. RAPOR --------------------------------------------------------
        If Current.Session("hangirapor") = "9" Then

            Dim sqldevam1, sqldevam2, sqldevam3, sqldevam4 As String
            sqldevam1 = ""
            sqldevam2 = ""
            sqldevam3 = ""
            sqldevam4 = ""


            If Current.Session("PolicyType") <> "Tümü" Then
                sqldevam1 = " and PolicyType=@PolicyType "
            Else
                sqldevam1 = ""
            End If

            If Current.Session("ProductCode") <> "Tümü" Then
                sqldevam2 = " and ProductCode=@ProductCode "
            Else
                sqldevam2 = ""
            End If

            If Current.Session("FirmCode") <> "Tümü" Then
                sqldevam3 = " and FirmCode=@FirmCode "
            Else
                sqldevam3 = ""
            End If

            If Current.Session("TariffCode") <> "Tümü" Then
                sqldevam4 = " and TariffCode=@TariffCode "
            Else
                sqldevam4 = ""
            End If


            Dim baslik As String

            sqlstr = "select count(*) as policesayig, TariffCode," + _
            "SUM(CASE WHEN ((DamagelessRate=0 and DamageRate=0) or (DamageRate<0)) THEN 1 else 0 end) as DamageveDamagelessRate_sifir, " + _
            "SUM(CASE WHEN DamagelessRate=0 THEN 1 else 0 end) as DamagelessRate_sifir, " + _
            "SUM(CASE WHEN DamagelessRate=10 or DamagelessRate=-10 THEN 1 else 0 end) as DamagelessRate_on, " + _
            "SUM(CASE WHEN DamagelessRate=20 or DamagelessRate=-20 THEN 1 else 0 end) as DamagelessRate_yirmi, " + _
            "SUM(CASE WHEN DamagelessRate=30 or DamagelessRate=-30 THEN 1 else 0 end) as DamagelessRate_otuz, " + _
            "SUM(CASE WHEN DamagelessRate=40 or DamagelessRate=-40 THEN 1 else 0 end) as DamagelessRate_kirk, " + _
            "SUM(CASE WHEN DamageRate=0 THEN 1 else 0 end) as DamageRate_sifir, " + _
            "SUM(CASE WHEN DamageRate=15 THEN 1 else 0 end) as DamageRate_onbes, " + _
            "SUM(CASE WHEN DamageRate=20 THEN 1 else 0 end) as DamageRate_yirmi, " + _
            "SUM(CASE WHEN DamageRate=25 THEN 1 else 0 end) as DamageRate_yirmibes, " + _
            "SUM(CASE WHEN DamageRate=30 THEN 1 else 0 end) as DamageRate_otuz, " + _
            "SUM(CASE WHEN DamageRate=35 THEN 1 else 0 end) as DamageRate_otuzbes, " + _
            "SUM(CASE WHEN DamageRate=40 THEN 1 else 0 end) as DamageRate_kirk, " + _
            "SUM(CASE WHEN DamageRate=50 THEN 1 else 0 end) as DamageRate_elli, " + _
            "SUM(CASE WHEN AgeRate=0 THEN 1 else 0 end) as AgeRate_sifir, " + _
            "SUM(CASE WHEN AgeRate=15 THEN 1 else 0 end) as AgeRate_onbes, " + _
            "SUM(CASE WHEN AgeRate=30 THEN 1 else 0 end) as AgeRate_otuz, " + _
            "SUM(CASE WHEN CCRate=0 THEN 1 else 0 end) as CCRate_sifir, " + _
            "SUM(CASE WHEN CCRate=5 THEN 1 else 0 end) as CCRate_bes, " + _
            "SUM(CASE WHEN CCRate=15 THEN 1 else 0 end) as CCRate_onbes, " + _
            "SUM(CASE WHEN CCRate=20 THEN 1 else 0 end) as CCRate_yirmi, " + _
            "SUM(CASE WHEN CCRate=25 THEN 1 else 0 end) as CCRate_yirmibes, " + _
            "SUM(CASE WHEN CCRate=30 THEN 1 else 0 end) as CCRate_otuz, " + _
            "SUM(CASE WHEN CCRate=35 THEN 1 else 0 end) as CCRate_otuzbes, " + _
            "SUM(CASE WHEN CCRate=45 THEN 1 else 0 end) as CCRate_kirkbes, " + _
            "SUM(CASE WHEN CCRate=50 THEN 1 else 0 end) as CCRate_elli, " + _
            "SUM(CASE WHEN CCRate=75 THEN 1 else 0 end) as CCRate_yetmisbes, " + _
            "SUM(CASE WHEN DamagelessRate=0 THEN DamagelessRateValue*ExchangeRate else 0 end) as DamagelessRateValue_sifir, " + _
            "SUM(CASE WHEN DamagelessRate=10 THEN DamagelessRateValue*ExchangeRate else 0 end) as DamagelessRateValue_on, " + _
            "SUM(CASE WHEN DamagelessRate=20 THEN DamagelessRateValue*ExchangeRate else 0 end) as DamagelessRateValue_yirmi, " + _
            "SUM(CASE WHEN DamagelessRate=30 THEN DamagelessRateValue*ExchangeRate else 0 end) as DamagelessRateValue_otuz, " + _
            "SUM(CASE WHEN DamagelessRate=40 THEN DamagelessRateValue*ExchangeRate else 0 end) as DamagelessRateValue_kirk, " + _
            "SUM(CASE WHEN DamageRate=0 THEN DamageRateValue*ExchangeRate  else 0 end) as DamageRateValue_sifir, " + _
            "SUM(CASE WHEN DamageRate=15 THEN DamageRateValue*ExchangeRate  else 0 end) as DamageRateValue_onbes, " + _
            "SUM(CASE WHEN DamageRate=20 THEN DamageRateValue*ExchangeRate else 0 end) as DamageRateValue_yirmi, " + _
            "SUM(CASE WHEN DamageRate=25 THEN DamageRateValue*ExchangeRate  else 0 end) as DamageRateValue_yirmibes, " + _
            "SUM(CASE WHEN DamageRate=30 THEN DamageRateValue*ExchangeRate else 0 end) as DamageRateValue_otuz, " + _
            "SUM(CASE WHEN DamageRate=35 THEN DamageRateValue*ExchangeRate  else 0 end) as DamageRateValue_otuzbes, " + _
            "SUM(CASE WHEN DamageRate=40 THEN DamageRateValue*ExchangeRate  else 0 end) as DamageRateValue_kirk, " + _
            "SUM(CASE WHEN DamageRate=50 THEN DamageRateValue*ExchangeRate  else 0 end) as DamageRateValue_elli, " + _
            "SUM(CASE WHEN AgeRate=0 THEN AgeRateValue*ExchangeRate else 0 end) as AgeRateValue_sifir, " + _
            "SUM(CASE WHEN AgeRate=15 THEN AgeRateValue*ExchangeRate else 0 end) as AgeRateValue_onbes, " + _
            "SUM(CASE WHEN AgeRate=30 THEN AgeRateValue*ExchangeRate else 0 end) as AgeRateValue_otuz, " + _
            "SUM(CASE WHEN CCRate=0 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_sifir, " + _
            "SUM(CASE WHEN CCRate=5 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_bes, " + _
            "SUM(CASE WHEN CCRate=15 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_onbes, " + _
            "SUM(CASE WHEN CCRate=20 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_yirmi, " + _
            "SUM(CASE WHEN CCRate=25 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_yirmibes, " + _
            "SUM(CASE WHEN CCRate=30 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_otuz, " + _
            "SUM(CASE WHEN CCRate=35 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_otuzbes, " + _
            "SUM(CASE WHEN CCRate=45 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_kirkbes, " + _
            "SUM(CASE WHEN CCRate=50 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_elli, " + _
            "SUM(CASE WHEN CCRate=75 THEN CCRateValue*ExchangeRate else 0 end) as CCRateValue_yetmisbes, " + _
            "SUM(CASE " + _
            "WHEN ZeylCode='P' THEN PolicyPremiumTL " + _
            "WHEN ZeylCode='T' THEN PolicyPremiumTL " + _
            "ELSE 0 END) as PolicyPremiumTL " + _
            "from PolicyInfo " + _
            "where (StartDate>=@baslangictarih and StartDate<=@bitistarih) and " + _
            "(ZeylCode='P' or ZeylCode='T') " + _
            sqldevam1 + sqldevam2 + sqldevam3 + sqldevam4 + _
            "group by TariffCode"

            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600


            Dim param1 As New SqlParameter("@baslangictarih", SqlDbType.Date)
            param1.Direction = ParameterDirection.Input
            param1.Value = Current.Session("baslangictarih")
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@bitistarih", SqlDbType.Date)
            param2.Direction = ParameterDirection.Input
            param2.Value = Current.Session("bitistarih")
            komut.Parameters.Add(param2)


            If Current.Session("FirmCode") <> "Tümü" Then
                Dim param3 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
                param3.Direction = ParameterDirection.Input
                param3.Value = Current.Session("FirmCode")
                komut.Parameters.Add(param3)
            End If

            If Current.Session("PolicyType") <> "Tümü" Then
                Dim param4 As New SqlParameter("@PolicyType", SqlDbType.Int)
                param4.Direction = ParameterDirection.Input
                param4.Value = Current.Session("PolicyType")
                komut.Parameters.Add(param4)
            End If

            If Current.Session("ProductCode") <> "Tümü" Then
                Dim param5 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
                param5.Direction = ParameterDirection.Input
                param5.Value = Current.Session("ProductCode")
                komut.Parameters.Add(param5)
            End If

            If Current.Session("TariffCode") <> "Tümü" Then
                Dim param6 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
                param6.Direction = ParameterDirection.Input
                param6.Value = Current.Session("TariffCode")
                komut.Parameters.Add(param6)
            End If

            If Current.Session("CurrencyCode") <> "Tümü" Then
                Dim param7 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
                param7.Direction = ParameterDirection.Input
                param7.Value = Current.Session("CurrencyCode")
                komut.Parameters.Add(param7)
            End If


            baslik = Current.Session("baslangictarih") + " İLE " + Current.Session("bitistarih") + _
            " TARİHLERİ ARASINDA " + Current.Session("TariffCode") + " TARİFE KODU İLE KESİLEN POLİÇELER İÇİN BAZ FİYAT" + _
            " ANALİZİ"

            donecekrapor.baslik = baslik

            veri = komut.ExecuteReader
            ekrapor = veriyarat13(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If



        '10. RAPOR ------------------------------------------------------------
        If Current.Session("hangirapor") = "10" Then

            Dim baslik As String

            If Current.Session("sirketpkey") <> "Tümü" Then
                sqldevam = " where pkey=@sirketpkey and tip='ŞİRKET'"
                sirket = sirket_erisim.bultek(Current.Session("sirketpkey"))
            Else
                sqldevam = " where tip='ŞİRKET'"
            End If

            sqlstr = "SELECT * FROM sirket" + sqldevam
            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            If Current.Session("sirketpkey") <> "Tümü" Then
                Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
                param1.Direction = ParameterDirection.Input
                param1.Value = Current.Session("sirketpkey")
                komut.Parameters.Add(param1)
            End If

            If Current.Session("sirketpkey") <> "Tümü" Then
                baslik = Current.Session("yil") + " YILINDA " + _
                sirket.sirketad + " HESAPLARININ AYLARA GÖRE DAĞILIMI"
            Else
                baslik = Current.Session("yil") + " YILINDA " + _
                "TÜM ŞİRKETLERİN" + " HESAPLARININ AYLARA GÖRE DAĞILIMI"
            End If

            donecekrapor.baslik = baslik

            veri = komut.ExecuteReader
            ekrapor = veriyarat10(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If


        If Current.Session("hangirapor") = "11" Then

            Dim baslik As String

            If Current.Session("sirketpkey") <> "Tümü" Then
                sqldevam = " where pkey=@sirketpkey and tip='ŞİRKET'"
                sirket = sirket_erisim.bultek(Current.Session("sirketpkey"))
            Else
                sqldevam = " where tip='ŞİRKET'"
            End If

            sqlstr = "SELECT * FROM sirket" + sqldevam
            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            If Current.Session("sirketpkey") <> "Tümü" Then
                Dim param1 As New SqlParameter("@sirketpkey", SqlDbType.Int)
                param1.Direction = ParameterDirection.Input
                param1.Value = Current.Session("sirketpkey")
                komut.Parameters.Add(param1)
            End If

            If Current.Session("sirketpkey") <> "Tümü" Then
                baslik = Current.Session("yil") + " YILINDA " + _
                sirket.sirketad + " HESAPLARININ AYLARA GÖRE DAĞILIMI"
            Else
                baslik = Current.Session("yil") + " YILINDA " + _
                "TÜM ŞİRKETLERİN" + " HESAPLARININ AYLARA GÖRE DAĞILIMI"
            End If

            donecekrapor.baslik = baslik

            veri = komut.ExecuteReader
            ekrapor = veriyarat11(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If




        '12. RAPOR SEKTÖR GENEL SADECE TL-------------------------------------------------------------------
        If Current.Session("hangirapor") = "12" Then

            Dim sqldevamtarih As String
            If Current.Session("tarihtip") = "StartDate" Then
                sqldevamtarih = " StartDate>=@baslangictarih and StartDate<=@bitistarih "
            End If
            If Current.Session("tarihtip") = "ArrangeDate" Then
                sqldevamtarih = " ArrangeDate>=@baslangictarih and ArrangeDate<=@bitistarih "
            End If

            sqldevam = ""
            If Current.Session("firmcode") <> "Tümü" Then
                sqldevam = " and FirmCode=@FirmCode "
            End If

            If Current.Session("currencycode") <> "Tümü" Then
                sqldevam = sqldevam + " and CurrencyCode=@CurrencyCode "
            End If


            If Current.Session("productcode") <> "Tümü" Then
                sqldevam = sqldevam + " and ProductCode=@ProductCode "
            End If

            If Current.Session("tariffcode") <> "Tümü" Then
                sqldevam = sqldevam + " and TariffCode=@TariffCode "
            End If

            If Current.Session("policytype") <> "Tümü" Then
                sqldevam = sqldevam + " and PolicyType=@PolicyType "
            End If

            If Current.Session("hangipoliceler") <> "Tümü" Then
                sqldevam = sqldevam + " and Color=@Color "
            End If


            Dim baslik As String

            sqlstr = "SELECT TariffCode," + _
            "ProductCode," + _
            "COUNT(*) as adet," + _
            "sum(PolicyPremiumTL) as PolicyPremiumTL," + _
            "sum(InsurancePremiumTL) as InsurancePremiumTL," + _
            "sum(PublicValueTL) as kaskoTL," + _
            "SUM(case when ZeylCode =  'P' then PolicyPremium end) as pp_pmiktar," + _
            "SUM(case when ZeylCode =  'T' then PolicyPremium end) as pp_tmiktar," + _
            "SUM(case when ZeylCode =  'V' then PolicyPremium end) as pp_vmiktar," + _
            "SUM(case when ZeylCode =  'R' then PolicyPremium end) as pp_rmiktar," + _
            "SUM(case when ZeylCode =  'X' then PolicyPremium end) as pp_xmiktar," + _
            "SUM(case when ZeylCode =  'P' then InsurancePremium end) as ip_pmiktar," + _
            "SUM(case when ZeylCode =  'T' then InsurancePremium end) as ip_tmiktar," + _
            "SUM(case when ZeylCode =  'V' then InsurancePremium end) as ip_vmiktar," + _
            "SUM(case when ZeylCode =  'R' then InsurancePremium end) as ip_rmiktar," + _
            "SUM(case when ZeylCode =  'X' then InsurancePremium end) as ip_xmiktar," + _
            "SUM(case when ZeylCode =  'P' then PolicyPremiumTL end) as pp_pmiktarTL," + _
            "SUM(case when ZeylCode =  'T' then PolicyPremiumTL end) as pp_tmiktarTL," + _
            "SUM(case when ZeylCode =  'V' then PolicyPremiumTL end) as pp_vmiktarTL," + _
            "SUM(case when ZeylCode =  'R' then PolicyPremiumTL end) as pp_rmiktarTL," + _
            "SUM(case when ZeylCode =  'X' then PolicyPremiumTL end) as pp_xmiktarTL," + _
            "SUM(case when ZeylCode =  'P' then InsurancePremiumTL end) as ip_pmiktarTL," + _
            "SUM(case when ZeylCode =  'T' then InsurancePremiumTL end) as ip_tmiktarTL," + _
            "SUM(case when ZeylCode =  'V' then InsurancePremiumTL end) as ip_vmiktarTL," + _
            "SUM(case when ZeylCode =  'R' then InsurancePremiumTL end) as ip_rmiktarTL," + _
            "SUM(case when ZeylCode =  'X' then InsurancePremiumTL end) as ip_xmiktarTL," + _
            "SUM(case when ZeylCode =  'P' then PublicValueTL end) as pv_pmiktarTL," + _
            "SUM(case when ZeylCode =  'T' then PublicValueTL end) as pv_tmiktarTL," + _
            "SUM(case when ZeylCode =  'V' then PublicValueTL end) as pv_vmiktarTL," + _
            "SUM(case when ZeylCode =  'R' then PublicValueTL end) as pv_rmiktarTL," + _
            "SUM(case when ZeylCode =  'X' then PublicValueTL end) as pv_xmiktarTL," + _
            "count(case when ZeylCode =  'P' then 1 end) as padet," + _
            "count(case when ZeylCode =  'T' then 1 end) as tadet," + _
            "count(case when ZeylCode =  'V' then 1 end) as vadet," + _
            "count(case when ZeylCode =  'R' then 1 end) as radet," + _
            "count(case when ZeylCode =  'X' then 1 end) as xadet " + _
            "from PolicyInfo where " + sqldevamtarih + sqldevam + _
            "group by TariffCode,ProductCode " + _
            "order by TariffCode"

            komut = New SqlCommand(sqlstr, db_baglanti)

            '600/60=10 dakika
            komut.CommandTimeout = 600

            If Current.Session("firmcode") <> "Tümü" Then
                Dim param1 As New SqlParameter("@FirmCode", SqlDbType.VarChar)
                param1.Direction = ParameterDirection.Input
                param1.Value = HttpContext.Current.Session("firmcode")
                komut.Parameters.Add(param1)
            End If

            If Current.Session("currencycode") <> "Tümü" Then
                Dim param2 As New SqlParameter("@CurrencyCode", SqlDbType.VarChar)
                param2.Direction = ParameterDirection.Input
                param2.Value = HttpContext.Current.Session("currencycode")
                komut.Parameters.Add(param2)
            End If

            If Current.Session("productcode") <> "Tümü" Then
                Dim param4 As New SqlParameter("@ProductCode", SqlDbType.VarChar)
                param4.Direction = ParameterDirection.Input
                param4.Value = HttpContext.Current.Session("productcode")
                komut.Parameters.Add(param4)
            End If

            If Current.Session("tariffcode") <> "Tümü" Then
                Dim param5 As New SqlParameter("@TariffCode", SqlDbType.VarChar)
                param5.Direction = ParameterDirection.Input
                param5.Value = HttpContext.Current.Session("tariffcode")
                komut.Parameters.Add(param5)
            End If

            If Current.Session("policytype") <> "Tümü" Then
                Dim param6 As New SqlParameter("@PolicyType", SqlDbType.Int)
                param6.Direction = ParameterDirection.Input
                param6.Value = HttpContext.Current.Session("policytype")
                komut.Parameters.Add(param6)
            End If

            If Current.Session("hangipoliceler") <> "Tümü" Then
                Dim param7 As New SqlParameter("@Color", SqlDbType.VarChar)
                param7.Direction = ParameterDirection.Input
                param7.Value = HttpContext.Current.Session("hangipoliceler")
                komut.Parameters.Add(param7)
            End If

            Dim param8 As New SqlParameter("@baslangictarih", SqlDbType.Date)
            param8.Direction = ParameterDirection.Input
            param8.Value = Current.Session("baslangictarih")
            komut.Parameters.Add(param8)


            Dim param9 As New SqlParameter("@bitistarih", SqlDbType.Date)
            param9.Direction = ParameterDirection.Input
            param9.Value = Current.Session("bitistarih")
            komut.Parameters.Add(param9)


            baslik = Current.Session("baslangictarih") + " İLE " + Current.Session("bitistarih") + _
            " TARİHLERİ ARASINDA " + UCase(Current.Session("rbaslik")) + " RAPORU"

            donecekrapor.baslik = baslik

            veri = komut.ExecuteReader
            ekrapor = veriyaratSEKTORSADECETL(db_baglanti, veri, komut)

            komut.Dispose()

            donecekrapor.veri = ekrapor.veri
            donecekrapor.kacadet = ekrapor.kacadet
            donecekrapor.tablo = ekrapor.tablo
            donecekrapor.pdftablo = ekrapor.pdftablo

            db_baglanti.Close()
            db_baglanti.Dispose()

            Return donecekrapor

        End If




      



    End Function



    'HESAP VERİSİ İÇİN----------------------
    Public Function veriyarat(ByVal db_baglanti As SqlConnection, _
     ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1

      
        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket Kodu</th>" + _
        "<th>Şirket Adı</th>" + _
        "<th>Tip</th>" + _
        "<th>Tarih</th>" + _
        "<th>Fatura No</th>" + _
        "<th>Tutar</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Ay/Yıl</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket Kodu", GetType(String))
        table.Columns.Add("Şirket Adı", GetType(String))
        table.Columns.Add("Tip", GetType(String))
        table.Columns.Add("Tarih", GetType(String))
        table.Columns.Add("Fatura No", GetType(String))
        table.Columns.Add("Tutar", GetType(String))
        table.Columns.Add("Açıklama", GetType(String))
        table.Columns.Add("Ay/Yıl", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(8)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Şirket Adı", fbaslik))
        pdftable.AddCell(New Phrase("Tip", fbaslik))
        pdftable.AddCell(New Phrase("Tarih", fbaslik))
        pdftable.AddCell(New Phrase("Fatura No", fbaslik))
        pdftable.AddCell(New Phrase("Tutar", fbaslik))
        pdftable.AddCell(New Phrase("Açıklama", fbaslik))
        pdftable.AddCell(New Phrase("Ay/Yıl", fbaslik))

        tabloson = "</tbody></table>"

        Dim pkey, faturano, tip, tarih, tutar, aciklama As String
        Dim ay, yil As String
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode As String

        While veri.Read

            girdi = "1"


            If Not veri.Item("firmcode") Is System.DBNull.Value Then
                firmcode = veri.Item("firmcode")
                kol1 = "<tr><td>" + firmcode + "</td>"
                saf1 = sirket.sirketad
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If


            If Not veri.Item("firmcode") Is System.DBNull.Value Then
                firmcode = veri.Item("firmcode")
                sirket = sirket_erisim.bultek_sirketkodagore(firmcode)
                kol2 = "<td>" + sirket.sirketad + "</td>"
                saf2 = sirket.sirketad
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If

            If Not veri.Item("tip") Is System.DBNull.Value Then
                tip = veri.Item("tip")
                kol3 = "<td>" + tip + "</td>"
                saf3 = tip
            Else
                kol3 = "<td>-</td>"
                saf3 = "-"
            End If

            If Not veri.Item("tarih") Is System.DBNull.Value Then
                tarih = veri.Item("tarih")
                kol4 = "<td>" + tarih + "</td>"
                saf4 = tarih
            Else
                kol4 = "<td>-</td>"
                saf4 = "-"
            End If

            If Not veri.Item("faturano") Is System.DBNull.Value Then
                faturano = veri.Item("faturano")
                kol5 = "<td>" + faturano + "</td>"
                saf5 = faturano
            Else
                kol5 = "<td>-</td>"
                saf5 = "-"
            End If

            If Not veri.Item("tutar") Is System.DBNull.Value Then
                tutar = veri.Item("tutar")
                kol6 = "<td>" + tutar + " TL" + "</td>"
                saf6 = tutar + " TL"
            Else
                kol6 = "<td>-</td>"
                saf6 = "-"
            End If

            If Not veri.Item("aciklama") Is System.DBNull.Value Then
                aciklama = veri.Item("aciklama")
                kol7 = "<td>" + aciklama + "</td>"
                saf7 = aciklama
            Else
                kol7 = "<td>-</td>"
                saf7 = "-"
            End If

            '------ay yil -------------------------------------
            If Not veri.Item("ay") Is System.DBNull.Value Then
                ay = veri.Item("ay")
            Else
                ay = "-"

            End If

            If Not veri.Item("yil") Is System.DBNull.Value Then
                yil = veri.Item("yil")
            Else
                yil = "-"
            End If

            kol8 = "<td>" + ay + "/" + yil + "</td></tr>"
            saf8 = ay + "/" + yil

            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol3 + kol4 + _
            kol5 + kol6 + kol7 + kol8


            table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf3, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
            pdftable.AddCell(New Phrase(saf6, fdata))
            pdftable.AddCell(New Phrase(saf7, fdata))
            pdftable.AddCell(New Phrase(saf8, fdata))


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



    'HESAP VERİSİ İÇİN----------------------
    Public Function veriyarat2(ByVal db_baglanti As SqlConnection, _
     ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket Kodu</th>" + _
        "<th>Şirket Adı</th>" + _
        "<th>Borç</th>" + _
        "<th>Ödeme</th>" + _
        "<th>Bakiye</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket Kodu", GetType(String))
        table.Columns.Add("Şirket Adı", GetType(String))
        table.Columns.Add("Borç", GetType(String))
        table.Columns.Add("Ödeme", GetType(String))
        table.Columns.Add("Bakiye", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(5)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Şirket Adı", fbaslik))
        pdftable.AddCell(New Phrase("Borç", fbaslik))
        pdftable.AddCell(New Phrase("Ödeme", fbaslik))
        pdftable.AddCell(New Phrase("Bakiye", fbaslik))

        tabloson = "</tbody></table>"

        Dim hesap_erisim As New CLASSHESAP_ERISIM

        Dim sirketkod, sirketad As String
        Dim gelir, gider, bakiye As Decimal

        While veri.Read

            girdi = "1"

            If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                sirketkod = veri.Item("sirketkod")
                kol1 = "<tr><td>" + sirketkod + "</td>"
                saf1 = sirketkod
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("sirketad") Is System.DBNull.Value Then
                sirketad = veri.Item("sirketad")
                kol2 = "<td>" + sirketad + "</td>"
                saf2 = sirketad
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If


            gelir = hesap_erisim.gelirbultarihli(sirketkod, Current.Session("baslangictarih"), Current.Session("bitistarih"))
            gider = hesap_erisim.giderbultarihli(sirketkod, Current.Session("baslangictarih"), Current.Session("bitistarih"))
            bakiye = hesap_erisim.bakiyebultarihli(sirketkod, Current.Session("baslangictarih"), Current.Session("bitistarih"))

            kol3 = "<td>" + Format(gelir, "0.00") + "</td>"
            saf3 = Format(gelir, "0.00")

            kol4 = "<td>" + Format(gider, "0.00") + "</td>"
            saf4 = Format(gider, "0.00")

            kol5 = "<td>" + Format(bakiye, "0.00") + "</td></tr>"
            saf5 = Format(bakiye, "0.00")

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



    'POLİÇELERİN ZEYL KODLARINA GÖRE DAĞILIMI İÇİN----------------------
    Public Function veriyarat4(ByVal db_baglanti As SqlConnection, _
     ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14, kol15, kol16 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12, saf13, saf14, saf15, saf16 As String
        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1


        Dim baslangictarih, bitistarih As Date
        baslangictarih = HttpContext.Current.Session("baslangictarih")
        bitistarih = HttpContext.Current.Session("bitistarih")


        Dim calc_erisim As New CLASSCALC_ERISIM
        Dim zeylkodbaslik As String
        Dim zeylcodlar As New List(Of CLASSZEYLCODE)
        Dim zeylcode_Erisim As New CLASSZEYLCODE_ERISIM
        zeylcodlar = zeylcode_Erisim.doldur

        For Each itemzeylcode As CLASSZEYLCODE In zeylcodlar
            zeylkodbaslik = zeylkodbaslik + "<th>" + itemzeylcode.kod + "</th>"
        Next


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket Kodu</th>" + _
        "<th>Şirket Adı</th>" + _
        zeylkodbaslik + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket Kodu", GetType(String))
        table.Columns.Add("Şirket Adı", GetType(String))
        For Each itemzeylcode As CLASSZEYLCODE In zeylcodlar
            table.Columns.Add(itemzeylcode.kod, GetType(String))
        Next


        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(zeylcodlar.Count + 2)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Şirket Adı", fbaslik))
        For Each itemzeylcode As CLASSZEYLCODE In zeylcodlar
            pdftable.AddCell(New Phrase(itemzeylcode.kod, fbaslik))
        Next

        tabloson = "</tbody></table>"

        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim sirketkod, sirketad As String
        Dim adet As Decimal
        Dim koldevam(zeylcodlar.Count - 1) As String
        Dim safdevam(zeylcodlar.Count - 1) As String
        Dim i As Integer

        While veri.Read

            girdi = "1"

            If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                sirketkod = veri.Item("sirketkod")
                kol1 = "<tr><td>" + sirketkod + "</td>"
                saf1 = sirketkod
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("sirketad") Is System.DBNull.Value Then
                sirketad = veri.Item("sirketad")
                kol2 = "<td>" + sirketad + "</td>"
                saf2 = sirketad
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If

            i = 0
            For Each itemzeylcode As CLASSZEYLCODE In zeylcodlar
                adet = calc_erisim.zeyilsayibul(sirketkod, baslangictarih, bitistarih, itemzeylcode.kod)
                koldevam(i) = "<td>" + Format(adet, "0.00") + "</td>"
                safdevam(i) = Format(adet, "0.00")
                i = i + 1
            Next

            recordcount = recordcount + 1
            sirano = sirano + 1


            'HTML KISMINI OLUŞTUR
            satir = satir + kol1 + kol2
            i = 0
            For Each itemzeylcode As CLASSZEYLCODE In zeylcodlar
                satir = satir + koldevam(i)
                i = i + 1
            Next


            'WORD EXCEL KISMINI OLUŞTUR
            Dim R As DataRow = table.NewRow
            R(0) = sirketkod
            R(1) = sirketad
            i = 0
            For Each itemzeylcode As CLASSZEYLCODE In zeylcodlar
                R(i + 2) = safdevam(i)
                i = i + 1
            Next
            table.Rows.Add(R)



            'PDF KISMINI OLUŞTUR
            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            i = 0
            For Each itemzeylcode As CLASSZEYLCODE In zeylcodlar
                pdftable.AddCell(New Phrase(safdevam(i), fdata))
                i = i + 1
            Next

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






    'POLİÇELERİN ZEYL KODLARINA GÖRE DAĞILIMI İÇİN----------------------
    Public Function veriyarat6(ByVal db_baglanti As SqlConnection, _
     ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
        Dim kol8, kol9, kol10, kol11, kol12, kol13, kol14, kol15, kol16 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12, saf13, saf14, saf15, saf16 As String
        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1


        Dim baslangictarih, bitistarih As Date
        baslangictarih = HttpContext.Current.Session("baslangictarih")
        bitistarih = HttpContext.Current.Session("bitistarih")


        Dim calc_erisim As New CLASSCALC_ERISIM

        Dim hasardurumkodbaslik As String
        Dim hasardurumkodlar As New List(Of CLASSHASARDURUMKOD)
        Dim hasardurumkod_Erisim As New CLASSHASARDURUMKOD_ERISIM
        hasardurumkodlar = hasardurumkod_Erisim.doldur

        For Each itemhasardurumkod As CLASSHASARDURUMKOD In hasardurumkodlar
            hasardurumkodbaslik = hasardurumkodbaslik + "<th>" + itemhasardurumkod.kod + "</th>"
        Next


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket Kodu</th>" + _
        "<th>Şirket Adı</th>" + _
        hasardurumkodbaslik + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket Kodu", GetType(String))
        table.Columns.Add("Şirket Adı", GetType(String))
        For Each itemhasardurumkod As CLASSHASARDURUMKOD In hasardurumkodlar
            table.Columns.Add(itemhasardurumkod.kod, GetType(String))
        Next


        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(hasardurumkodlar.Count + 2)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Şirket Adı", fbaslik))
        For Each itemhasardurumkod As CLASSHASARDURUMKOD In hasardurumkodlar
            pdftable.AddCell(New Phrase(itemhasardurumkod.kod, fbaslik))
        Next

        tabloson = "</tbody></table>"

        Dim hesap_erisim As New CLASSHESAP_ERISIM
        Dim sirketkod, sirketad As String
        Dim adet As Decimal
        Dim koldevam(hasardurumkodlar.Count - 1) As String
        Dim safdevam(hasardurumkodlar.Count - 1) As String
        Dim i As Integer

        While veri.Read

            girdi = "1"

            If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                sirketkod = veri.Item("sirketkod")
                kol1 = "<tr><td>" + sirketkod + "</td>"
                saf1 = sirketkod
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("sirketad") Is System.DBNull.Value Then
                sirketad = veri.Item("sirketad")
                kol2 = "<td>" + sirketad + "</td>"
                saf2 = sirketad
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If

            i = 0
            For Each itemhasardurumkod As CLASSHASARDURUMKOD In hasardurumkodlar
                adet = calc_erisim.hasarsayibul(sirketkod, baslangictarih, bitistarih, itemhasardurumkod.kod)
                koldevam(i) = "<td>" + Format(adet, "0.00") + "</td>"
                safdevam(i) = Format(adet, "0.00")
                i = i + 1
            Next

            recordcount = recordcount + 1
            sirano = sirano + 1


            'HTML KISMINI OLUŞTUR
            satir = satir + kol1 + kol2
            i = 0
            For Each itemhasardurumkod As CLASSHASARDURUMKOD In hasardurumkodlar
                satir = satir + koldevam(i)
                i = i + 1
            Next

            'WORD EXCEL KISMINI OLUŞTUR
            Dim R As DataRow = table.NewRow
            R(0) = sirketkod
            R(1) = sirketad
            i = 0
            For Each itemhasardurumkod As CLASSHASARDURUMKOD In hasardurumkodlar
                R(i + 2) = safdevam(i)
                i = i + 1
            Next
            table.Rows.Add(R)


            'PDF KISMINI OLUŞTUR
            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            i = 0
            For Each itemhasardurumkod As CLASSHASARDURUMKOD In hasardurumkodlar
                pdftable.AddCell(New Phrase(safdevam(i), fdata))
                i = i + 1
            Next

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




    Public Function veriyarat7(ByVal db_baglanti As SqlConnection, _
    ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR


        Dim veritabaniad As String = System.Configuration.ConfigurationManager.AppSettings("veritabaniad")
        'Dim veritabaniad As String = "sigortay"
        Dim tabload As String = "DamageInfo"

        Dim baslangictarih, bitistarih As Date
        baslangictarih = HttpContext.Current.Session("baslangictarih")
        bitistarih = HttpContext.Current.Session("bitistarih")
        Dim hangihasar As String
        hangihasar = HttpContext.Current.Session("hangihasar")


        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18, kol19, kol20 As String
        Dim kol21, kol22, kol23, kol24, kol25, kol26, kol27, kol28, kol29, kol30 As String
        Dim kol31 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14, saf15, saf16, saf17, saf18, saf19, saf20 As String
        Dim saf21, saf22, saf23, saf24, saf25, saf26, saf27, saf28, saf29, saf30 As String
        Dim saf31 As String

        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1
        Dim currencycode As String

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Tarife Kodu</th>" + _
        "<th>Ürün Kodu</th>" + _
        "<th>Para Birimi</th>" + _
        "<th>Poliçe Adeti</th>" + _
        "<th>İptal Poliçe Adeti</th>" + _
        "<th>İptal İade Toplam Primi</th>" + _
        "<th>Toplam Poliçe Primi</th>" + _
        "<th>Toplam Sigorta Primi</th>" + _
        "<th>Toplam Kasko Bedeli</th>" + _
        "<th>Toplam Kasko Bedeli TL</th>" + _
        "<th>Muallak Adeti</th>" + _
        "<th>Muallak Maddi Adet</th>" + _
        "<th>Muallak Maddi Tutar</th>" + _
        "<th>Muallak Maddi Tutar TL</th>" + _
        "<th>Muallak Bedeni Adet</th>" + _
        "<th>Muallak Bedeni Tutar</th>" + _
        "<th>Muallak Bedeni Tutar TL</th>" + _
        "<th>Muallak Tutar Genel Toplam</th>" + _
        "<th>Muallak Tutar Genel Toplam TL</th>" + _
        "<th>Ödenen Adet</th>" + _
        "<th>Ödenen Maddi Adet</th>" + _
        "<th>Ödenen Maddi Tutar</th>" + _
        "<th>Ödenen Maddi Tutar TL</th>" + _
        "<th>Ödenen Bedeni Adet</th>" + _
        "<th>Ödenen Bedeni Tutar</th>" + _
        "<th>Ödenen Bedeni Tutar TL</th>" + _
        "<th>Ödenen Tutar Genel Toplam</th>" + _
        "<th>Ödenen Tutar Genel Toplam TL</th>" + _
        "<th>Pert Adet</th>" + _
        "<th>Toplam Poliçe Primi TL</th>" + _
        "<th>Toplam Sigorta Primi TL</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Tarife Kodu", GetType(String))
        table.Columns.Add("Ürün Kodu", GetType(String))
        table.Columns.Add("Para Birimi ", GetType(String))
        table.Columns.Add("Poliçe Adeti", GetType(String))
        table.Columns.Add("İptal Poliçe Adeti", GetType(String))
        table.Columns.Add("İptal İade Toplam Primi", GetType(String))
        table.Columns.Add("Toplam Poliçe Primi", GetType(String))
        table.Columns.Add("Toplam Sigorta Primi", GetType(String))
        table.Columns.Add("Toplam Kasko Bedeli", GetType(String))
        table.Columns.Add("Toplam Kasko Bedeli TL", GetType(String))
        table.Columns.Add("Muallak Adeti", GetType(String))
        table.Columns.Add("Muallak Maddi Adet", GetType(String))
        table.Columns.Add("Muallak Maddi Tutar", GetType(String))
        table.Columns.Add("Muallak Maddi Tutar TL", GetType(String))
        table.Columns.Add("Muallak Bedeni Adet", GetType(String))
        table.Columns.Add("Muallak Bedeni Tutar", GetType(String))
        table.Columns.Add("Muallak Bedeni Tutar TL", GetType(String))
        table.Columns.Add("Muallak Tutar Genel Toplam", GetType(String))
        table.Columns.Add("Muallak Tutar Genel Toplam TL", GetType(String))
        table.Columns.Add("Ödenen Adet", GetType(String))
        table.Columns.Add("Ödenenen Maddi Adet", GetType(String))
        table.Columns.Add("Ödenenen Maddi Tutar", GetType(String))
        table.Columns.Add("Ödenenen Maddi Tutar TL", GetType(String))
        table.Columns.Add("Ödenen Bedeni Adet", GetType(String))
        table.Columns.Add("Ödenen Bedeni Tutar", GetType(String))
        table.Columns.Add("Ödenenen Bedeni Tutar TL", GetType(String))
        table.Columns.Add("Ödenen Tutar Genel Toplam", GetType(String))
        table.Columns.Add("Ödenen Tutar Genel Toplam TL", GetType(String))
        table.Columns.Add("Pert Adet", GetType(String))
        table.Columns.Add("Toplam Poliçe Primi TL", GetType(String))
        table.Columns.Add("Toplam Sigorta Primi TL", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(31)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarife Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Ürün Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Para Birimi", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe Adeti", fbaslik))
        pdftable.AddCell(New Phrase("İptal Poliçe Adeti", fbaslik))
        pdftable.AddCell(New Phrase("İptal İade Toplam Primi", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Poliçe Primi", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Sigorta Primi", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Kasko Bedeli", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Kasko Bedeli TL", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Adeti", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Maddi Adet", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Maddi Tutar", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Maddi Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Bedeni Adet", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Bedeni Tutar", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Bedeni Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Tutar Genel Toplam", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Tutar Genel Toplam TL", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Adet", fbaslik))
        pdftable.AddCell(New Phrase("Ödenenen Maddi Adet", fbaslik))
        pdftable.AddCell(New Phrase("Ödenenen Maddi Tutar", fbaslik))
        pdftable.AddCell(New Phrase("Ödenenen Maddi Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Bedeni Adet", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Bedeni Tutar", fbaslik))
        pdftable.AddCell(New Phrase("Ödenenen Bedeni Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Tutar Genel Toplam", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Tutar Genel Toplam TL", fbaslik))
        pdftable.AddCell(New Phrase("Pert Adet", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Poliçe Primi TL", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Sigorta Primi TL", fbaslik))


        tabloson = "</tbody></table>"

        Dim pp_pmiktar, pp_tmiktar, pp_vmiktar, pp_rmiktar, pp_xmiktar As Decimal
        Dim ip_pmiktar, ip_tmiktar, ip_vmiktar, ip_rmiktar, ip_xmiktar As Decimal
        Dim pp_pmiktarTL, pp_tmiktarTL, pp_vmiktarTL, pp_rmiktarTL, pp_xmiktarTL As Decimal
        Dim ip_pmiktarTL, ip_tmiktarTL, ip_vmiktarTL, ip_rmiktarTL, ip_xmiktarTL As Decimal
        Dim padet, tadet, vadet, radet, xadet As Integer
   
        Dim STG_policeadet, STG_muallakmiktar, STG_odenen, STG_odenenmiktar As Decimal
        Dim TL_policeadet, TL_muallakmiktar, TL_odenen, TL_odenenmiktar As Decimal
        Dim USD_policeadet, USD_muallakmiktar, USD_odenen, USD_odenenmiktar As Decimal
        Dim EUR_policeadet, EUR_muallakmiktar, EUR_odenen, EUR_odenenmiktar As Decimal

        STG_policeadet = 0
        STG_muallakmiktar = 0
        STG_odenen = 0
        STG_odenenmiktar = 0

        TL_policeadet = 0
        TL_muallakmiktar = 0
        TL_odenen = 0
        TL_odenenmiktar = 0

        USD_policeadet = 0
        USD_muallakmiktar = 0
        USD_odenen = 0
        USD_odenenmiktar = 0

        EUR_policeadet = 0
        EUR_muallakmiktar = 0
        EUR_odenen = 0
        EUR_odenenmiktar = 0
        '---------------------------------------------

        Dim tarihtip As String = HttpContext.Current.Session("tarihtip")
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode, tariffcode, productcode, policytype, adet As String
        Dim pp_prim, ip_prim, kasko As Decimal
        Dim calc_erisim As New CLASSCALC_ERISIM

        Dim muallakmiktar, odenenhasaradet, odenenhasarmiktar As Decimal
        Dim geneltoplammuallakhda, geneltoplammuallakmiktar, geneltoplamodenenhasaradet As Decimal
        Dim geneltoplamodenenhasarmiktar As Decimal
        Dim toplamsatir As String


        Dim iptaladet_STG, iptaladet_TL, iptaladet_USD, iptaladet_EUR As Decimal
        Dim iptaliadetoplamprim_STG, iptaliadetoplamprim_TL, iptaliadetoplamprim_USD, iptaliadetoplamprim_EUR As Decimal
        Dim pp_toplamprim_STG, pp_toplamprim_TL, pp_toplamprim_USD, pp_toplamprim_EUR As Decimal
        Dim ip_toplamprim_STG, ip_toplamprim_TL, ip_toplamprim_USD, ip_toplamprim_EUR As Decimal
        Dim toplamkasko_STG, toplamkasko_TL, toplamkasko_USD, toplamkasko_EUR As Decimal
        Dim muallakadet_STG, muallakadet_TL, muallakadet_USD, muallakadet_EUR As Decimal
        Dim muallakmaddiadet_STG, muallakmaddiadet_TL, muallakmaddiadet_USD, muallakmaddiadet_EUR As Decimal
        Dim muallakmaddimiktar_STG, muallakmaddimiktar_TL, muallakmaddimiktar_USD, muallakmaddimiktar_EUR As Decimal
        Dim muallakbedeniadet_STG, muallakbedeniadet_TL, muallakbedeniadet_USD, muallakbedeniadet_EUR As Decimal
        Dim muallakbedenimiktar_STG, muallakbedenimiktar_TL, muallakbedenimiktar_USD, muallakbedenimiktar_EUR As Decimal
        Dim muallakgenelmiktar_STG, muallakgenelmiktar_TL, muallakgenelmiktar_USD, muallakgenelmiktar_EUR As Decimal
        Dim odenenadet_STG, odenenadet_TL, odenenadet_USD, odenenadet_EUR As Decimal
        Dim odenenmaddiadet_STG, odenenmaddiadet_TL, odenenmaddiadet_USD, odenenmaddiadet_EUR As Decimal
        Dim odenenmaddimiktar_STG, odenenmaddimiktar_TL, odenenmaddimiktar_USD, odenenmaddimiktar_EUR As Decimal
        Dim odenenbedeniadet_STG, odenenbedeniadet_TL, odenenbedeniadet_USD, odenenbedeniadet_EUR As Decimal
        Dim odenenbedenimiktar_STG, odenenbedenimiktar_TL, odenenbedenimiktar_USD, odenenbedenimiktar_EUR As Decimal
        Dim odenengenelmiktar_STG, odenengenelmiktar_TL, odenengenelmiktar_USD, odenengenelmiktar_EUR As Decimal
        Dim pertadet_STG, pertadet_TL, pertadet_USD, pertadet_EUR As Decimal

        Dim pp_primTL, ip_primTL As Decimal
        Dim pp_primTL_STG, pp_primTL_TL, pp_primTL_USD, pp_primTL_EUR As Decimal
        Dim ip_primTL_STG, ip_primTL_TL, ip_primTL_USD, ip_primTL_EUR As Decimal
        Dim anatoplam_pp_primTL, anatoplam_ip_primTL As Decimal

        Dim anatoplam_policeadet, anatoplam_iptalpoliceadet, anatoplam_muallakadet, anatoplam_muallakmaddiadet As Integer
        Dim anatoplam_muallakbedeniadet, anatoplam_odenenadet As Integer
        Dim anatoplam_odenenmaddiadet, anatoplam_odenenbedeniadet As Integer
        Dim anatoplam_pertadet As Integer

        Dim odenenmaddimiktarTL_STG, odenenmaddimiktarTL_TL, odenenmaddimiktarTL_USD, odenenmaddimiktarTL_EUR As Decimal
        Dim odenenbedenimiktarTL_STG, odenenbedenimiktarTL_TL, odenenbedenimiktarTL_USD, odenenbedenimiktarTL_EUR As Decimal

        Dim muallakmaddimiktarTL_STG, muallakmaddimiktarTL_TL, muallakmaddimiktarTL_USD, muallakmaddimiktarTL_EUR As Decimal
        Dim muallakbedenimiktarTL_STG, muallakbedenimiktarTL_TL, muallakbedenimiktarTL_USD, muallakbedenimiktarTL_EUR As Decimal

        Dim muallakgenelmiktarTL_STG, muallakgenelmiktarTL_TL, muallakgenelmiktarTL_USD, muallakgenelmiktarTL_EUR As Decimal
        Dim odenengenelmiktarTL_STG, odenengenelmiktarTL_TL, odenengenelmiktarTL_USD, odenengenelmiktarTL_EUR As Decimal

        'ANA TOPLAMLARI SIFIRLA -----------
        anatoplam_policeadet = 0
        anatoplam_iptalpoliceadet = 0
        anatoplam_muallakadet = 0
        anatoplam_muallakmaddiadet = 0
        anatoplam_muallakbedeniadet = 0
        anatoplam_odenenadet = 0
        anatoplam_odenenmaddiadet = 0
        anatoplam_odenenbedeniadet = 0
        anatoplam_pertadet = 0
        anatoplam_pp_primTL = 0
        anatoplam_ip_primTL = 0
        '---------------------------------

        pp_toplamprim_STG = 0
        pp_toplamprim_TL = 0
        pp_toplamprim_USD = 0
        pp_toplamprim_EUR = 0

        ip_toplamprim_STG = 0
        ip_toplamprim_TL = 0
        ip_toplamprim_USD = 0
        ip_toplamprim_EUR = 0

        toplamkasko_STG = 0
        toplamkasko_TL = 0
        toplamkasko_USD = 0
        toplamkasko_EUR = 0

        muallakadet_STG = 0
        muallakadet_TL = 0
        muallakadet_USD = 0
        muallakadet_EUR = 0

        iptaladet_STG = 0
        iptaladet_TL = 0
        iptaladet_USD = 0
        iptaladet_EUR = 0

        iptaliadetoplamprim_STG = 0
        iptaliadetoplamprim_TL = 0
        iptaliadetoplamprim_USD = 0
        iptaliadetoplamprim_EUR = 0

        muallakmaddiadet_STG = 0
        muallakmaddiadet_TL = 0
        muallakmaddiadet_USD = 0
        muallakmaddiadet_EUR = 0

        muallakmaddimiktar_STG = 0
        muallakmaddimiktar_TL = 0
        muallakmaddimiktar_USD = 0
        muallakmaddimiktar_EUR = 0

        muallakbedeniadet_STG = 0
        muallakbedeniadet_TL = 0
        muallakbedeniadet_USD = 0
        muallakbedeniadet_EUR = 0

        muallakbedenimiktar_STG = 0
        muallakbedenimiktar_TL = 0
        muallakbedenimiktar_USD = 0
        muallakbedenimiktar_EUR = 0

        muallakgenelmiktar_STG = 0
        muallakgenelmiktar_TL = 0
        muallakgenelmiktar_USD = 0
        muallakgenelmiktar_EUR = 0

        odenenadet_STG = 0
        odenenadet_TL = 0
        odenenadet_USD = 0
        odenenadet_EUR = 0

        odenenmaddiadet_STG = 0
        odenenmaddiadet_TL = 0
        odenenmaddiadet_USD = 0
        odenenmaddiadet_EUR = 0

        odenenmaddimiktar_STG = 0
        odenenmaddimiktar_TL = 0
        odenenmaddimiktar_USD = 0
        odenenmaddimiktar_EUR = 0

        odenenbedeniadet_STG = 0
        odenenbedeniadet_TL = 0
        odenenbedeniadet_USD = 0
        odenenbedeniadet_EUR = 0

        odenenbedenimiktar_STG = 0
        odenenbedenimiktar_TL = 0
        odenenbedenimiktar_USD = 0
        odenenbedenimiktar_EUR = 0

        odenengenelmiktar_STG = 0
        odenengenelmiktar_TL = 0
        odenengenelmiktar_USD = 0
        odenengenelmiktar_EUR = 0

        pertadet_STG = 0
        pertadet_TL = 0
        pertadet_USD = 0
        pertadet_EUR = 0

        pp_primTL = 0
        ip_primTL = 0

        pp_primTL_STG = 0
        pp_primTL_TL = 0
        pp_primTL_USD = 0
        pp_primTL_EUR = 0

        ip_primTL_STG = 0
        ip_primTL_TL = 0
        ip_primTL_USD = 0
        ip_primTL_EUR = 0

 
        odenenmaddimiktarTL_STG = 0
        odenenmaddimiktarTL_TL = 0
        odenenmaddimiktarTL_USD = 0
        odenenmaddimiktarTL_EUR = 0
        odenenbedenimiktarTL_STG = 0
        odenenbedenimiktarTL_TL = 0
        odenenbedenimiktarTL_USD = 0
        odenenbedenimiktarTL_EUR = 0

        muallakmaddimiktarTL_STG = 0
        muallakmaddimiktarTL_TL = 0
        muallakmaddimiktarTL_USD = 0
        muallakmaddimiktarTL_EUR = 0
        muallakbedenimiktarTL_STG = 0
        muallakbedenimiktarTL_TL = 0
        muallakbedenimiktarTL_USD = 0
        muallakbedenimiktarTL_EUR = 0

        muallakgenelmiktarTL_STG = 0
        muallakgenelmiktarTL_TL = 0
        muallakgenelmiktarTL_USD = 0
        muallakgenelmiktarTL_EUR = 0

        odenengenelmiktarTL_STG = 0
        odenengenelmiktarTL_TL = 0
        odenengenelmiktarTL_USD = 0
        odenengenelmiktarTL_EUR = 0

        Dim anatoplam_kaskoTL As Decimal
        Dim kaskoTL As Decimal
        Dim toplamkaskoTL_STG, toplamkaskoTL_TL, toplamkaskoTL_USD, toplamkaskoTL_EUR As Decimal
        anatoplam_kaskoTL = 0
        toplamkaskoTL_STG = 0
        toplamkaskoTL_TL = 0
        toplamkaskoTL_USD = 0
        toplamkaskoTL_EUR = 0


        While veri.Read

            girdi = "1"

            If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                tariffcode = veri.Item("TariffCode")
                kol1 = "<tr><td>" + tariffcode + "</td>"
                saf1 = tariffcode
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                productcode = veri.Item("productcode")
                kol2 = "<td>" + productcode + "</td>"
                saf2 = productcode
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If


            If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
                currencycode = veri.Item("CurrencyCode")
                kol3 = "<td>" + currencycode + "</td>"
                saf3 = currencycode
            Else
                kol3 = "<td>-</td>"
                saf3 = "-"
            End If


            'SUM LAR POLICYPREMIUM İÇİN-------------------------------------------------------
            If Not veri.Item("pp_pmiktar") Is System.DBNull.Value Then
                pp_pmiktar = veri.Item("pp_pmiktar")
            Else
                pp_pmiktar = 0
            End If
            If Not veri.Item("pp_tmiktar") Is System.DBNull.Value Then
                pp_tmiktar = veri.Item("pp_tmiktar")
            Else
                pp_tmiktar = 0
            End If
            If Not veri.Item("pp_vmiktar") Is System.DBNull.Value Then
                pp_vmiktar = veri.Item("pp_vmiktar")
            Else
                pp_vmiktar = 0
            End If
            If Not veri.Item("pp_rmiktar") Is System.DBNull.Value Then
                pp_rmiktar = veri.Item("pp_rmiktar")
            Else
                pp_rmiktar = 0
            End If
            If Not veri.Item("pp_xmiktar") Is System.DBNull.Value Then
                pp_xmiktar = veri.Item("pp_xmiktar")
            Else
                pp_xmiktar = 0
            End If



            'SUM LAR INSURANCEPREMIUM İÇİN-------------------------------------------------------
            If Not veri.Item("ip_pmiktar") Is System.DBNull.Value Then
                ip_pmiktar = veri.Item("ip_pmiktar")
            Else
                ip_pmiktar = 0
            End If
            If Not veri.Item("ip_tmiktar") Is System.DBNull.Value Then
                ip_tmiktar = veri.Item("ip_tmiktar")
            Else
                ip_tmiktar = 0
            End If
            If Not veri.Item("ip_vmiktar") Is System.DBNull.Value Then
                ip_vmiktar = veri.Item("ip_vmiktar")
            Else
                ip_vmiktar = 0
            End If
            If Not veri.Item("ip_rmiktar") Is System.DBNull.Value Then
                ip_rmiktar = veri.Item("ip_rmiktar")
            Else
                ip_rmiktar = 0
            End If
            If Not veri.Item("ip_xmiktar") Is System.DBNull.Value Then
                ip_xmiktar = veri.Item("ip_xmiktar")
            Else
                ip_xmiktar = 0
            End If



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
            '-------------------------------------------------------------------



            'SUM LAR POLICYPREMIUM tl İÇİN-------------------------------------------------------
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



            'SUM LAR INSURANCEPREMIUM İÇİN-------------------------------------------------------
            If Not veri.Item("ip_pmiktarTL") Is System.DBNull.Value Then
                ip_pmiktarTL = veri.Item("ip_pmiktarTL")
            Else
                ip_pmiktarTL = 0
            End If
            If Not veri.Item("ip_tmiktarTL") Is System.DBNull.Value Then
                ip_tmiktarTL = veri.Item("ip_tmiktarTL")
            Else
                ip_tmiktarTL = 0
            End If
            If Not veri.Item("ip_vmiktarTL") Is System.DBNull.Value Then
                ip_vmiktarTL = veri.Item("ip_vmiktarTL")
            Else
                ip_vmiktarTL = 0
            End If
            If Not veri.Item("ip_rmiktarTL") Is System.DBNull.Value Then
                ip_rmiktarTL = veri.Item("ip_rmiktarTL")
            Else
                ip_rmiktarTL = 0
            End If
            If Not veri.Item("ip_xmiktarTL") Is System.DBNull.Value Then
                ip_xmiktarTL = veri.Item("ip_xmiktarTL")
            Else
                ip_xmiktarTL = 0
            End If


            'POLİÇE ADETİ
            Dim p_t_toplamadet As Decimal
            p_t_toplamadet = padet + tadet
            kol4 = "<td>" + CStr(p_t_toplamadet) + "</td>"
            saf4 = CStr(p_t_toplamadet)
            If currencycode = "STG" Then
                STG_policeadet = STG_policeadet + CStr(p_t_toplamadet)
            End If
            If currencycode = "TL" Then
                TL_policeadet = TL_policeadet + CStr(p_t_toplamadet)
            End If
            If currencycode = "USD" Then
                USD_policeadet = USD_policeadet + CStr(p_t_toplamadet)
            End If
            If currencycode = "EUR" Then
                EUR_policeadet = EUR_policeadet + CStr(p_t_toplamadet)
            End If
            anatoplam_policeadet = anatoplam_policeadet + p_t_toplamadet

         
            'İPTAL POLİÇE ADETİ
            kol5 = "<td>" + CStr(xadet) + "</td>"
            saf5 = CStr(xadet)
            If currencycode = "STG" Then
                iptaladet_STG = iptaladet_STG + xadet
            End If
            If currencycode = "TL" Then
                iptaladet_TL = iptaladet_TL + xadet
            End If
            If currencycode = "USD" Then
                iptaladet_USD = iptaladet_USD + xadet
            End If
            If currencycode = "EUR" Then
                iptaladet_EUR = iptaladet_EUR + xadet
            End If
            anatoplam_iptalpoliceadet = anatoplam_iptalpoliceadet + xadet


            'İPTAL İADE TOPLAM PRİMİ
            kol6 = "<td>" + pp_xmiktar.ToString("N2") + "</td>"
            saf6 = pp_xmiktar.ToString("N2")
            If currencycode = "STG" Then
                iptaliadetoplamprim_STG = iptaliadetoplamprim_STG + pp_xmiktar
            End If
            If currencycode = "TL" Then
                iptaliadetoplamprim_TL = iptaliadetoplamprim_TL + pp_xmiktar
            End If
            If currencycode = "USD" Then
                iptaliadetoplamprim_USD = iptaliadetoplamprim_USD + pp_xmiktar
            End If
            If currencycode = "EUR" Then
                iptaliadetoplamprim_EUR = iptaliadetoplamprim_EUR + pp_xmiktar
            End If


            'TOPLAM POLICY PREMIUM
            pp_prim = ((pp_pmiktar + pp_tmiktar + pp_vmiktar) - (pp_rmiktar + pp_xmiktar))
            kol7 = "<td>" + pp_prim.ToString("N2") + "</td>"
            saf7 = pp_prim.ToString("N2")
            If currencycode = "STG" Then
                pp_toplamprim_STG = pp_toplamprim_STG + pp_prim
            End If
            If currencycode = "TL" Then
                pp_toplamprim_TL = pp_toplamprim_TL + pp_prim
            End If
            If currencycode = "USD" Then
                pp_toplamprim_USD = pp_toplamprim_USD + pp_prim
            End If
            If currencycode = "EUR" Then
                pp_toplamprim_EUR = pp_toplamprim_EUR + pp_prim
            End If


            'TOPLAM INSURANCE PREMIUM
            ip_prim = ((ip_pmiktar + ip_tmiktar + ip_vmiktar) - (ip_rmiktar + ip_xmiktar))
            kol8 = "<td>" + ip_prim.ToString("N2") + "</td>"
            saf8 = ip_prim.ToString("N2")
            If currencycode = "STG" Then
                ip_toplamprim_STG = ip_toplamprim_STG + ip_prim
            End If
            If currencycode = "TL" Then
                ip_toplamprim_TL = ip_toplamprim_TL + ip_prim
            End If
            If currencycode = "USD" Then
                ip_toplamprim_USD = ip_toplamprim_USD + ip_prim
            End If
            If currencycode = "EUR" Then
                ip_toplamprim_EUR = ip_toplamprim_EUR + ip_prim
            End If


            'TOPLAM KASKO BEDELİ
            If Not veri.Item("kasko") Is System.DBNull.Value Then
                kasko = veri.Item("kasko")
                kol9 = "<td>" + kasko.ToString("N2") + "</td>"
                saf9 = kasko.ToString("N2")
                If currencycode = "STG" Then
                    toplamkasko_STG = toplamkasko_STG + kasko
                End If
                If currencycode = "TL" Then
                    toplamkasko_TL = toplamkasko_TL + kasko
                End If
                If currencycode = "USD" Then
                    toplamkasko_USD = toplamkasko_USD + kasko
                End If
                If currencycode = "EUR" Then
                    toplamkasko_EUR = toplamkasko_EUR + kasko
                End If
            Else
                kol9 = "<td>-</td>"
                saf9 = "-"
            End If



            'TOPLAM KASKO BEDELİ TL
            If Not veri.Item("kaskoTL") Is System.DBNull.Value Then
                kaskoTL = veri.Item("kaskoTL")
                anatoplam_kaskoTL = anatoplam_kaskoTL + kaskoTL
                kol10 = "<td>" + kaskoTL.ToString("N2") + "</td>"
                saf10 = kaskoTL.ToString("N2")
                If currencycode = "STG" Then
                    toplamkaskoTL_STG = toplamkaskoTL_STG + kaskoTL
                End If
                If currencycode = "TL" Then
                    toplamkaskoTL_TL = toplamkaskoTL_TL + kaskoTL
                End If
                If currencycode = "USD" Then
                    toplamkaskoTL_USD = toplamkaskoTL_USD + kaskoTL
                End If
                If currencycode = "EUR" Then
                    toplamkaskoTL_EUR = toplamkaskoTL_EUR + kaskoTL
                End If
            Else
                kol10 = "<td>-</td>"
                saf10 = "-"
            End If




            'HASARLARA BAŞLIYORUZ -----------------------------------------------
            Dim tablolar As New List(Of CLASSTEK)
            tablolar.Add(New CLASSTEK("PolicyInfo"))
            tablolar.Add(New CLASSTEK("DamageInfo"))


            'MUALLAK ADETİ
            Dim muallak_adeti As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "EstimatedMaterialDamage", ">", "1", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedCorporalDamage", ">", "1", ")"))
                muallak_adeti = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "EstimatedMaterialDamage", ">", "1", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedCorporalDamage", ">", "1", ")"))
                muallak_adeti = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol11 = "<td>" + CStr(muallak_adeti) + "</td>"
            saf11 = CStr(muallak_adeti)
            If currencycode = "STG" Then
                muallakadet_STG = muallakadet_STG + muallak_adeti
            End If
            If currencycode = "TL" Then
                muallakadet_TL = muallakadet_TL + muallak_adeti
            End If
            If currencycode = "USD" Then
                muallakadet_USD = muallakadet_USD + muallak_adeti
            End If
            If currencycode = "EUR" Then
                muallakadet_EUR = muallakadet_EUR + muallak_adeti
            End If
            anatoplam_muallakadet = anatoplam_muallakadet + muallak_adeti



            'MUALLAK MADDİ ADET
            Dim muallak_maddi_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol12 = "<td>" + CStr(muallak_maddi_adet) + "</td>"
            saf12 = CStr(muallak_maddi_adet)
            If currencycode = "STG" Then
                muallakmaddiadet_STG = muallakmaddiadet_STG + muallak_maddi_adet
            End If
            If currencycode = "TL" Then
                muallakmaddiadet_TL = muallakmaddiadet_TL + muallak_maddi_adet
            End If
            If currencycode = "USD" Then
                muallakmaddiadet_USD = muallakmaddiadet_USD + muallak_maddi_adet
            End If
            If currencycode = "EUR" Then
                muallakmaddiadet_EUR = muallakmaddiadet_EUR + muallak_maddi_adet
            End If
            anatoplam_muallakmaddiadet = anatoplam_muallakmaddiadet + muallak_maddi_adet




            'MUALLAK MADDİ MİKTAR
            Dim muallak_maddi_miktar As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_miktar = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(EstimatedMaterialDamage)-sum(PaidMaterialDamage)", fieldopvalues)
                If muallak_maddi_miktar < 0 Then
                    muallak_maddi_miktar = 0
                End If
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_miktar = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(EstimatedMaterialDamage)-sum(PaidMaterialDamage)", fieldopvalues2)
                If muallak_maddi_miktar < 0 Then
                    muallak_maddi_miktar = 0
                End If
            End If
            kol13 = "<td>" + muallak_maddi_miktar.ToString("N2") + "</td>"
            saf13 = muallak_maddi_miktar.ToString("N2")
            If currencycode = "STG" Then
                muallakmaddimiktar_STG = muallakmaddimiktar_STG + muallak_maddi_miktar
            End If
            If currencycode = "TL" Then
                muallakmaddimiktar_TL = muallakmaddimiktar_TL + muallak_maddi_miktar
            End If
            If currencycode = "USD" Then
                muallakmaddimiktar_USD = muallakmaddimiktar_USD + muallak_maddi_miktar
            End If
            If currencycode = "EUR" Then
                muallakmaddimiktar_EUR = muallakmaddimiktar_EUR + muallak_maddi_miktar
            End If



            'MUALLAK MADDİ MİKTAR TL
            Dim muallak_maddi_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(EstimatedMaterialAmountTL)-sum(PaidMaterialAmountTL)", fieldopvalues)
                If muallak_maddi_miktarTL < 0 Then
                    muallak_maddi_miktarTL = 0
                End If
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(EstimatedMaterialAmountTL)-sum(PaidMaterialAmountTL)", fieldopvalues2)
                If muallak_maddi_miktarTL < 0 Then
                    muallak_maddi_miktarTL = 0
                End If
            End If
            kol14 = "<td>" + muallak_maddi_miktarTL.ToString("N2") + "</td>"
            saf14 = muallak_maddi_miktarTL.ToString("N2")
            If currencycode = "STG" Then
                muallakmaddimiktarTL_STG = muallakmaddimiktarTL_STG + muallak_maddi_miktarTL
            End If
            If currencycode = "TL" Then
                muallakmaddimiktarTL_TL = muallakmaddimiktarTL_TL + muallak_maddi_miktarTL
            End If
            If currencycode = "USD" Then
                muallakmaddimiktarTL_USD = muallakmaddimiktarTL_USD + muallak_maddi_miktarTL
            End If
            If currencycode = "EUR" Then
                muallakmaddimiktarTL_EUR = muallakmaddimiktarTL_EUR + muallak_maddi_miktarTL
            End If





            'MUALLAK BEDENİ ADET
            Dim muallak_bedeni_adet As Integer = 0
            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)  
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If

            kol15 = "<td>" + CStr(muallak_bedeni_adet) + "</td>"
            saf15 = CStr(muallak_bedeni_adet)
            If currencycode = "STG" Then
                muallakbedeniadet_STG = muallakbedeniadet_STG + muallak_bedeni_adet
            End If
            If currencycode = "TL" Then
                muallakbedeniadet_TL = muallakbedeniadet_TL + muallak_bedeni_adet
            End If
            If currencycode = "USD" Then
                muallakbedeniadet_USD = muallakbedeniadet_USD + muallak_bedeni_adet
            End If
            If currencycode = "EUR" Then
                muallakbedeniadet_EUR = muallakbedeniadet_EUR + muallak_bedeni_adet
            End If
            anatoplam_muallakbedeniadet = anatoplam_muallakbedeniadet + muallak_bedeni_adet


            'MUALLAK BEDENİ MİKTAR
            Dim muallak_bedeni_miktar As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_miktar = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(EstimatedCorporalDamage)-sum(PaidCorporalDamage)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_miktar = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(EstimatedCorporalDamage)-sum(PaidCorporalDamage)", fieldopvalues2)
                If muallak_bedeni_miktar > 0 Then
                    muallak_bedeni_miktar = 0
                End If
            End If
            kol16 = "<td>" + muallak_bedeni_miktar.ToString("N2") + "</td>"
            saf16 = muallak_bedeni_miktar.ToString("N2")
            If currencycode = "STG" Then
                muallakbedenimiktar_STG = muallakbedenimiktar_STG + muallak_bedeni_miktar
            End If
            If currencycode = "TL" Then
                muallakbedenimiktar_TL = muallakbedenimiktar_TL + muallak_bedeni_miktar
            End If
            If currencycode = "USD" Then
                muallakbedenimiktar_USD = muallakbedenimiktar_USD + muallak_bedeni_miktar
            End If
            If currencycode = "EUR" Then
                muallakbedenimiktar_EUR = muallakbedenimiktar_EUR + muallak_bedeni_miktar
            End If



            'MUALLAK BEDENİ MİKTAR TL
            Dim muallak_bedeni_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(EstimatedCorporalAmountTL)-sum(PaidCorporalAmountTL)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(EstimatedCorporalAmountTL)-sum(PaidCorporalAmountTL)", fieldopvalues2)
                If muallak_bedeni_miktarTL > 0 Then
                    muallak_bedeni_miktarTL = 0
                End If
            End If
            kol17 = "<td>" + muallak_bedeni_miktarTL.ToString("N2") + "</td>"
            saf17 = muallak_bedeni_miktarTL.ToString("N2")
            If currencycode = "STG" Then
                muallakbedenimiktarTL_STG = muallakbedenimiktarTL_STG + muallak_bedeni_miktarTL
            End If
            If currencycode = "TL" Then
                muallakbedenimiktarTL_TL = muallakbedenimiktarTL_TL + muallak_bedeni_miktarTL
            End If
            If currencycode = "USD" Then
                muallakbedenimiktarTL_USD = muallakbedenimiktarTL_USD + muallak_bedeni_miktarTL
            End If
            If currencycode = "EUR" Then
                muallakbedenimiktarTL_EUR = muallakbedenimiktarTL_EUR + muallak_bedeni_miktarTL
            End If




            'MUALLAK GENEL MİKTAR TOPLAM
            Dim muallak_genel_miktar_toplam As Decimal
            muallak_genel_miktar_toplam = muallak_maddi_miktar + muallak_bedeni_miktar
            kol18 = "<td>" + muallak_genel_miktar_toplam.ToString("N2") + "</td>"
            saf18 = muallak_genel_miktar_toplam.ToString("N2")
            If currencycode = "STG" Then
                muallakgenelmiktar_STG = muallakgenelmiktar_STG + muallak_genel_miktar_toplam
            End If
            If currencycode = "TL" Then
                muallakgenelmiktar_TL = muallakgenelmiktar_TL + muallak_genel_miktar_toplam
            End If
            If currencycode = "USD" Then
                muallakgenelmiktar_USD = muallakgenelmiktar_USD + muallak_genel_miktar_toplam
            End If
            If currencycode = "EUR" Then
                muallakgenelmiktar_EUR = muallakgenelmiktar_EUR + muallak_genel_miktar_toplam
            End If



            'MUALLAK GENEL MİKTAR TOPLAM TL
            Dim muallak_genel_miktar_toplamTL As Decimal
            muallak_genel_miktar_toplamTL = muallak_maddi_miktarTL + muallak_bedeni_miktarTL
            kol19 = "<td>" + muallak_genel_miktar_toplamTL.ToString("N2") + "</td>"
            saf19 = muallak_genel_miktar_toplamTL.ToString("N2")
            If currencycode = "STG" Then
                muallakgenelmiktarTL_STG = muallakgenelmiktarTL_STG + muallak_genel_miktar_toplamTL
            End If
            If currencycode = "TL" Then
                muallakgenelmiktarTL_TL = muallakgenelmiktarTL_TL + muallak_genel_miktar_toplamTL
            End If
            If currencycode = "USD" Then
                muallakgenelmiktarTL_USD = muallakgenelmiktarTL_USD + muallak_genel_miktar_toplamTL
            End If
            If currencycode = "EUR" Then
                muallakgenelmiktarTL_EUR = muallakgenelmiktarTL_EUR + muallak_genel_miktar_toplamTL
            End If



            'ÖDENEN ADET
            Dim odenen_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidMaterialDamage", ">", "1", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PaidCorporalDamage", ">", "1", ")"))
                odenen_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidMaterialDamage", ">", "1", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "PaidCorporalDamage", ">", "1", ")"))
                odenen_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol20 = "<td>" + CStr(odenen_adet) + "</td>"
            saf20 = CStr(odenen_adet)
            If currencycode = "STG" Then
                odenenadet_STG = odenenadet_STG + odenen_adet
            End If
            If currencycode = "TL" Then
                odenenadet_TL = odenenadet_TL + odenen_adet
            End If
            If currencycode = "USD" Then
                odenenadet_USD = odenenadet_USD + odenen_adet
            End If
            If currencycode = "EUR" Then
                odenenadet_EUR = odenenadet_EUR + odenen_adet
            End If
            anatoplam_odenenadet = anatoplam_odenenadet + odenen_adet


            'ÖDENEN MADDİ ADET
            Dim odenen_maddi_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol21 = "<td>" + CStr(odenen_maddi_adet) + "</td>"
            saf21 = CStr(odenen_maddi_adet)
            If currencycode = "STG" Then
                odenenmaddiadet_STG = odenenmaddiadet_STG + odenen_maddi_adet
            End If
            If currencycode = "TL" Then
                odenenmaddiadet_TL = odenenmaddiadet_TL + odenen_maddi_adet
            End If
            If currencycode = "USD" Then
                odenenmaddiadet_USD = odenenmaddiadet_USD + odenen_maddi_adet
            End If
            If currencycode = "EUR" Then
                odenenmaddiadet_EUR = odenenmaddiadet_EUR + odenen_maddi_adet
            End If
            anatoplam_odenenmaddiadet = anatoplam_odenenmaddiadet + odenen_maddi_adet


            'ÖDENEN MADDİ MİKTAR
            Dim odenen_maddi_miktar As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_miktar = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(PaidMaterialDamage)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_miktar = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(PaidMaterialDamage)", fieldopvalues2)
            End If
            kol22 = "<td>" + odenen_maddi_miktar.ToString("N2") + "</td>"
            saf22 = odenen_maddi_miktar.ToString("N2")
            If currencycode = "STG" Then
                odenenmaddimiktar_STG = odenenmaddimiktar_STG + odenen_maddi_miktar
            End If
            If currencycode = "TL" Then
                odenenmaddimiktar_TL = odenenmaddimiktar_TL + odenen_maddi_miktar
            End If
            If currencycode = "USD" Then
                odenenmaddimiktar_USD = odenenmaddimiktar_USD + odenen_maddi_miktar
            End If
            If currencycode = "EUR" Then
                odenenmaddimiktar_EUR = odenenmaddimiktar_EUR + odenen_maddi_miktar
            End If


            'ÖDENEN MADDİ MİKTAR TL
            Dim odenen_maddi_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(PaidMaterialAmountTL)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(PaidMaterialAmountTL)", fieldopvalues2)
            End If
            kol23 = "<td>" + odenen_maddi_miktarTL.ToString("N2") + "</td>"
            saf23 = odenen_maddi_miktarTL.ToString("N2")
            If currencycode = "STG" Then
                odenenmaddimiktarTL_STG = odenenmaddimiktarTL_STG + odenen_maddi_miktarTL
            End If
            If currencycode = "TL" Then
                odenenmaddimiktarTL_TL = odenenmaddimiktarTL_TL + odenen_maddi_miktarTL
            End If
            If currencycode = "USD" Then
                odenenmaddimiktarTL_USD = odenenmaddimiktarTL_USD + odenen_maddi_miktarTL
            End If
            If currencycode = "EUR" Then
                odenenmaddimiktarTL_EUR = odenenmaddimiktarTL_EUR + odenen_maddi_miktarTL
            End If



            'ÖDENEN BEDENİ ADET
            Dim odenen_bedeni_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol24 = "<td>" + CStr(odenen_bedeni_adet) + "</td>"
            saf24 = CStr(odenen_bedeni_adet)
            If currencycode = "STG" Then
                odenenbedeniadet_STG = odenenbedeniadet_STG + odenen_bedeni_adet
            End If
            If currencycode = "TL" Then
                odenenbedeniadet_TL = odenenbedeniadet_TL + odenen_bedeni_adet
            End If
            If currencycode = "USD" Then
                odenenbedeniadet_USD = odenenbedeniadet_USD + odenen_bedeni_adet
            End If
            If currencycode = "EUR" Then
                odenenbedeniadet_EUR = odenenbedeniadet_EUR + odenen_bedeni_adet
            End If
            anatoplam_odenenbedeniadet = anatoplam_odenenbedeniadet + odenen_bedeni_adet


            'ÖDENEN BEDENİ MİKTAR
            Dim odenen_bedeni_miktar As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_miktar = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(PaidCorporalDamage)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_miktar = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(PaidCorporalDamage)", fieldopvalues2)
            End If
            kol25 = "<td>" + odenen_bedeni_miktar.ToString("N2") + "</td>"
            saf25 = odenen_bedeni_miktar.ToString("N2")
            If currencycode = "STG" Then
                odenenbedenimiktar_STG = odenenbedenimiktar_STG + odenen_bedeni_miktar
            End If
            If currencycode = "TL" Then
                odenenbedenimiktar_TL = odenenbedenimiktar_TL + odenen_bedeni_miktar
            End If
            If currencycode = "USD" Then
                odenenbedenimiktar_USD = odenenbedenimiktar_USD + odenen_bedeni_miktar
            End If
            If currencycode = "EUR" Then
                odenenbedenimiktar_EUR = odenenbedenimiktar_EUR + odenen_bedeni_miktar
            End If



            'ÖDENEN BEDENİ MİKTAR TL
            Dim odenen_bedeni_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(PaidCorporalAmountTL)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(PaidCorporalAmountTL)", fieldopvalues2)
            End If
            kol26 = "<td>" + odenen_bedeni_miktarTL.ToString("N2") + "</td>"
            saf26 = odenen_bedeni_miktarTL.ToString("N2")
            If currencycode = "STG" Then
                odenenbedenimiktarTL_STG = odenenbedenimiktarTL_STG + odenen_bedeni_miktarTL
            End If
            If currencycode = "TL" Then
                odenenbedenimiktarTL_TL = odenenbedenimiktarTL_TL + odenen_bedeni_miktarTL
            End If
            If currencycode = "USD" Then
                odenenbedenimiktarTL_USD = odenenbedenimiktarTL_USD + odenen_bedeni_miktarTL
            End If
            If currencycode = "EUR" Then
                odenenbedenimiktarTL_EUR = odenenbedenimiktarTL_EUR + odenen_bedeni_miktarTL
            End If



            'ÖDENEN GENEL MİKTAR TOPLAM
            Dim odenen_genel_miktar_toplam As Decimal
            odenen_genel_miktar_toplam = odenen_maddi_miktar + odenen_bedeni_miktar
            kol27 = "<td>" + odenen_genel_miktar_toplam.ToString("N2") + "</td>"
            saf27 = odenen_genel_miktar_toplam.ToString("N2")
            If currencycode = "STG" Then
                odenengenelmiktar_STG = odenengenelmiktar_STG + odenen_genel_miktar_toplam
            End If
            If currencycode = "TL" Then
                odenengenelmiktar_TL = odenengenelmiktar_TL + odenen_genel_miktar_toplam
            End If
            If currencycode = "USD" Then
                odenengenelmiktar_USD = odenengenelmiktar_USD + odenen_genel_miktar_toplam
            End If
            If currencycode = "EUR" Then
                odenengenelmiktar_EUR = odenengenelmiktar_EUR + odenen_genel_miktar_toplam
            End If



            'ÖDENEN GENEL MİKTAR TOPLAM TL
            Dim odenen_genel_miktar_toplamTL As Decimal
            odenen_genel_miktar_toplamTL = odenen_maddi_miktarTL + odenen_bedeni_miktarTL
            kol28 = "<td>" + odenen_genel_miktar_toplamTL.ToString("N2") + "</td>"
            saf28 = odenen_genel_miktar_toplamTL.ToString("N2")
            If currencycode = "STG" Then
                odenengenelmiktarTL_STG = odenengenelmiktarTL_STG + odenen_genel_miktar_toplamTL
            End If
            If currencycode = "TL" Then
                odenengenelmiktarTL_TL = odenengenelmiktarTL_TL + odenen_genel_miktar_toplamTL
            End If
            If currencycode = "USD" Then
                odenengenelmiktarTL_USD = odenengenelmiktarTL_USD + odenen_genel_miktar_toplamTL
            End If
            If currencycode = "EUR" Then
                odenengenelmiktarTL_EUR = odenengenelmiktarTL_EUR + odenen_genel_miktar_toplamTL
            End If


            'PERT ADET
            Dim pert_adet As Decimal

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "TotalLost", "=", "0", ") "))
                pert_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "TotalLost", "=", "0", ") "))
                pert_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol29 = "<td>" + CStr(pert_adet) + "</td>"
            saf29 = CStr(pert_adet)
            If currencycode = "STG" Then
                pertadet_STG = pertadet_STG + pert_adet
            End If
            If currencycode = "TL" Then
                pertadet_TL = pertadet_TL + pert_adet
            End If
            If currencycode = "USD" Then
                pertadet_USD = pertadet_USD + pert_adet
            End If
            If currencycode = "EUR" Then
                pertadet_EUR = pertadet_EUR + pert_adet
            End If
            anatoplam_pertadet = anatoplam_pertadet + pert_adet




            'TOPLAM POLICY PREMIUM TL
            pp_primTL = ((pp_pmiktarTL + pp_tmiktarTL + pp_vmiktarTL) - (pp_rmiktarTL + pp_xmiktarTL))
            kol30 = "<td>" + pp_primTL.ToString("N2") + "</td>"
            saf30 = pp_primTL.ToString("N2")
            If currencycode = "STG" Then
                pp_primTL_STG = pp_primTL_STG + pp_primTL
            End If
            If currencycode = "TL" Then
                pp_primTL_TL = pp_primTL_TL + pp_primTL
            End If
            If currencycode = "USD" Then
                pp_primTL_USD = pp_primTL_USD + pp_primTL
            End If
            If currencycode = "EUR" Then
                pp_primTL_EUR = pp_primTL_EUR + pp_primTL
            End If
            anatoplam_pp_primTL = anatoplam_pp_primTL + pp_primTL



            'TOPLAM INSURANCE PREMIUM TL
            ip_primTL = ((ip_pmiktarTL + ip_tmiktarTL + ip_vmiktarTL) - (ip_rmiktarTL + ip_xmiktarTL))
            kol31 = "<td>" + ip_primTL.ToString("N2") + "</td>"
            saf31 = ip_primTL.ToString("N2")
            If currencycode = "STG" Then
                ip_primTL_STG = ip_primTL_STG + ip_primTL
            End If
            If currencycode = "TL" Then
                ip_primTL_TL = ip_primTL_TL + ip_primTL
            End If
            If currencycode = "USD" Then
                ip_primTL_USD = ip_primTL_USD + ip_primTL
            End If
            If currencycode = "EUR" Then
                ip_primTL_EUR = ip_primTL_EUR + ip_primTL
            End If
            anatoplam_ip_primTL = anatoplam_ip_primTL + ip_primTL



            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol3 + kol4 + _
            kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + _
            kol11 + kol12 + kol13 + kol14 + kol15 + _
            kol16 + kol17 + kol18 + kol19 + kol20 + _
            kol21 + kol22 + kol23 + kol24 + kol25 + _
            kol26 + kol27 + kol28 + kol29 + kol30 + kol31

            table.Rows.Add(saf1, saf2, saf3, saf4, saf5, _
            saf6, saf7, saf8, saf9, saf10, _
            saf11, saf12, saf13, saf14, saf15, _
            saf16, saf17, saf18, saf19, saf20, _
            saf21, saf22, saf23, saf24, saf25, _
            saf26, saf27, saf28, saf29, saf30, saf31)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf3, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
            pdftable.AddCell(New Phrase(saf6, fdata))
            pdftable.AddCell(New Phrase(saf7, fdata))
            pdftable.AddCell(New Phrase(saf8, fdata))
            pdftable.AddCell(New Phrase(saf9, fdata))
            pdftable.AddCell(New Phrase(saf10, fdata))
            pdftable.AddCell(New Phrase(saf11, fdata))
            pdftable.AddCell(New Phrase(saf12, fdata))
            pdftable.AddCell(New Phrase(saf13, fdata))
            pdftable.AddCell(New Phrase(saf14, fdata))
            pdftable.AddCell(New Phrase(saf15, fdata))
            pdftable.AddCell(New Phrase(saf16, fdata))
            pdftable.AddCell(New Phrase(saf17, fdata))
            pdftable.AddCell(New Phrase(saf18, fdata))
            pdftable.AddCell(New Phrase(saf19, fdata))
            pdftable.AddCell(New Phrase(saf20, fdata))
            pdftable.AddCell(New Phrase(saf21, fdata))
            pdftable.AddCell(New Phrase(saf22, fdata))
            pdftable.AddCell(New Phrase(saf23, fdata))
            pdftable.AddCell(New Phrase(saf24, fdata))
            pdftable.AddCell(New Phrase(saf25, fdata))
            pdftable.AddCell(New Phrase(saf26, fdata))
            pdftable.AddCell(New Phrase(saf27, fdata))
            pdftable.AddCell(New Phrase(saf28, fdata))
            pdftable.AddCell(New Phrase(saf29, fdata))
            pdftable.AddCell(New Phrase(saf30, fdata))
            pdftable.AddCell(New Phrase(saf31, fdata))

        End While


        'HTML İÇİN EKLE
        toplamsatir = "<tr>" + _
        "<td>STG</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>" + CStr(STG_policeadet) + "</td>" + _
        "<td>" + CStr(iptaladet_STG) + "</td>" + _
        "<td>" + iptaliadetoplamprim_STG.ToString("N2") + "</td>" + _
        "<td>" + pp_toplamprim_STG.ToString("N2") + "</td>" + _
        "<td>" + ip_toplamprim_STG.ToString("N2") + "</td>" + _
        "<td>" + toplamkasko_STG.ToString("N2") + "</td>" + _
        "<td>" + toplamkaskoTL_STG.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakadet_STG, "0.00") + "</td>" + _
        "<td>" + Format(muallakmaddiadet_STG, "0.00") + "</td>" + _
        "<td>" + muallakmaddimiktar_STG.ToString("N2") + "</td>" + _
        "<td>" + muallakmaddimiktarTL_STG.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakbedeniadet_STG, "0.00") + "</td>" + _
        "<td>" + muallakbedenimiktar_STG.ToString("N2") + "</td>" + _
        "<td>" + muallakbedenimiktarTL_STG.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktar_STG.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktarTL_STG.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenadet_STG, "0.00") + "</td>" + _
        "<td>" + Format(odenenmaddiadet_STG, "0.00") + "</td>" + _
        "<td>" + odenenmaddimiktar_STG.ToString("N2") + "</td>" + _
        "<td>" + odenenmaddimiktarTL_STG.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenbedeniadet_STG, "0.00") + "</td>" + _
        "<td>" + odenenbedenimiktar_STG.ToString("N2") + "</td>" + _
        "<td>" + odenenmaddimiktarTL_STG.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktar_STG.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktarTL_STG.ToString("N2") + "</td>" + _
        "<td>" + Format(pertadet_STG, "0.00") + "</td>" + _
        "<td>" + pp_primTL_STG.ToString("N2") + "</td>" + _
        "<td>" + ip_primTL_STG.ToString("N2") + "</td>" + _
        "</tr>" + _
        "<tr>" + _
        "<td>TL</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>" + CStr(TL_policeadet) + "</td>" + _
        "<td>" + CStr(iptaladet_TL) + "</td>" + _
        "<td>" + iptaliadetoplamprim_TL.ToString("N2") + "</td>" + _
        "<td>" + pp_toplamprim_TL.ToString("N2") + "</td>" + _
        "<td>" + ip_toplamprim_TL.ToString("N2") + "</td>" + _
        "<td>" + toplamkasko_TL.ToString("N2") + "</td>" + _
        "<td>" + toplamkaskoTL_TL.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakadet_TL, "0.00") + "</td>" + _
        "<td>" + Format(muallakmaddiadet_TL, "0.00") + "</td>" + _
        "<td>" + muallakmaddimiktar_TL.ToString("N2") + "</td>" + _
        "<td>" + muallakmaddimiktarTL_TL.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakbedeniadet_TL, "0.00") + "</td>" + _
        "<td>" + muallakbedenimiktar_TL.ToString("N2") + "</td>" + _
        "<td>" + muallakbedenimiktarTL_TL.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktar_TL.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktarTL_TL.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenadet_TL, "0.00") + "</td>" + _
        "<td>" + Format(odenenmaddiadet_TL, "0.00") + "</td>" + _
        "<td>" + odenenmaddimiktar_TL.ToString("N2") + "</td>" + _
        "<td>" + odenenmaddimiktarTL_TL.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenbedeniadet_TL, "0.00") + "</td>" + _
        "<td>" + odenenbedenimiktar_TL.ToString("N2") + "</td>" + _
        "<td>" + odenenbedenimiktarTL_TL.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktar_TL.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktarTL_TL.ToString("N2") + "</td>" + _
        "<td>" + Format(pertadet_TL, "0.00") + "</td>" + _
        "<td>" + pp_primTL_TL.ToString("N2") + "</td>" + _
        "<td>" + ip_primTL_TL.ToString("N2") + "</td>" + _
        "</tr>" + _
        "<tr>" + _
        "<td>USD</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>" + CStr(USD_policeadet) + "</td>" + _
        "<td>" + CStr(iptaladet_USD) + "</td>" + _
        "<td>" + iptaliadetoplamprim_USD.ToString("N2") + "</td>" + _
        "<td>" + pp_toplamprim_USD.ToString("N2") + "</td>" + _
        "<td>" + ip_toplamprim_USD.ToString("N2") + "</td>" + _
        "<td>" + toplamkasko_USD.ToString("N2") + "</td>" + _
        "<td>" + toplamkaskoTL_USD.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakadet_USD, "0.00") + "</td>" + _
        "<td>" + Format(muallakmaddiadet_USD, "0.00") + "</td>" + _
        "<td>" + muallakmaddimiktar_USD.ToString("N2") + "</td>" + _
        "<td>" + muallakmaddimiktarTL_USD.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakbedeniadet_USD, "0.00") + "</td>" + _
        "<td>" + muallakbedenimiktar_USD.ToString("N2") + "</td>" + _
        "<td>" + muallakbedenimiktarTL_USD.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktar_USD.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktarTL_USD.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenadet_USD, "0.00") + "</td>" + _
        "<td>" + Format(odenenmaddiadet_USD, "0.00") + "</td>" + _
        "<td>" + odenenmaddimiktar_USD.ToString("N2") + "</td>" + _
        "<td>" + odenenmaddimiktarTL_USD.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenbedeniadet_USD, "0.00") + "</td>" + _
        "<td>" + odenenbedenimiktar_USD.ToString("N2") + "</td>" + _
        "<td>" + odenenbedenimiktarTL_USD.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktar_USD.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktarTL_USD.ToString("N2") + "</td>" + _
        "<td>" + Format(pertadet_USD, "0.00") + "</td>" + _
        "<td>" + pp_primTL_USD.ToString("N2") + "</td>" + _
        "<td>" + ip_primTL_USD.ToString("N2") + "</td>" + _
        "</tr>" + _
        "<tr>" + _
        "<td>EUR</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>" + CStr(EUR_policeadet) + "</td>" + _
        "<td>" + CStr(iptaladet_EUR) + "</td>" + _
        "<td>" + iptaliadetoplamprim_EUR.ToString("N2") + "</td>" + _
        "<td>" + pp_toplamprim_EUR.ToString("N2") + "</td>" + _
        "<td>" + ip_toplamprim_EUR.ToString("N2") + "</td>" + _
        "<td>" + toplamkasko_EUR.ToString("N2") + "</td>" + _
        "<td>" + toplamkaskoTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakadet_EUR, "0.00") + "</td>" + _
        "<td>" + Format(muallakmaddiadet_EUR, "0.00") + "</td>" + _
        "<td>" + muallakmaddimiktar_EUR.ToString("N2") + "</td>" + _
        "<td>" + muallakmaddimiktarTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + Format(muallakbedeniadet_EUR, "0.00") + "</td>" + _
        "<td>" + muallakbedenimiktar_EUR.ToString("N2") + "</td>" + _
        "<td>" + muallakbedenimiktarTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktar_EUR.ToString("N2") + "</td>" + _
        "<td>" + muallakgenelmiktarTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenadet_EUR, "0.00") + "</td>" + _
        "<td>" + Format(odenenmaddiadet_EUR, "0.00") + "</td>" + _
        "<td>" + odenenmaddimiktar_EUR.ToString("N2") + "</td>" + _
        "<td>" + odenenmaddimiktarTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + Format(odenenbedeniadet_EUR, "0.00") + "</td>" + _
        "<td>" + odenenbedenimiktar_EUR.ToString("N2") + "</td>" + _
        "<td>" + odenenbedenimiktarTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktar_EUR.ToString("N2") + "</td>" + _
        "<td>" + odenengenelmiktarTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + Format(pertadet_EUR, "0.00") + "</td>" + _
         "<td>" + pp_primTL_EUR.ToString("N2") + "</td>" + _
        "<td>" + ip_primTL_EUR.ToString("N2") + "</td>" + _
        "</tr>" + _
        "<tr>" + _
        "<td>TOPLAM</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>" + CStr(anatoplam_policeadet) + "</td>" + _
        "<td>" + CStr(anatoplam_iptalpoliceadet) + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + anatoplam_kaskoTL.ToString("N2") + "</td>" + _
        "<td>" + CStr(anatoplam_muallakadet) + "</td>" + _
        "<td>" + CStr(anatoplam_muallakmaddiadet) + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + CStr(anatoplam_muallakbedeniadet) + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + CStr(anatoplam_odenenadet) + "</td>" + _
        "<td>" + CStr(anatoplam_odenenmaddiadet) + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + CStr(anatoplam_odenenbedeniadet) + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + "-" + "</td>" + _
        "<td>" + CStr(anatoplam_pertadet) + "</td>" + _
        "<td>" + anatoplam_pp_primTL.ToString("N2") + "</td>" + _
        "<td>" + anatoplam_ip_primTL.ToString("N2") + "</td>" + _
        "</tr>"
       
        satir = satir + toplamsatir


        'WORD EXCEL KISMINI OLUŞTUR
        Dim RSTG As DataRow = table.NewRow
        Dim RTL As DataRow = table.NewRow
        Dim RUSD As DataRow = table.NewRow
        Dim REUR As DataRow = table.NewRow
        Dim RANATOPLAM As DataRow = table.NewRow


        RSTG(0) = "STG"
        RSTG(1) = "-"
        RSTG(2) = "-"
        RSTG(3) = CStr(STG_policeadet)
        RSTG(4) = CStr(iptaladet_STG)
        RSTG(5) = iptaliadetoplamprim_STG.ToString("N2")
        RSTG(6) = pp_toplamprim_STG.ToString("N2")
        RSTG(7) = ip_toplamprim_STG.ToString("N2")
        RSTG(8) = toplamkasko_STG.ToString("N2")
        RSTG(9) = toplamkaskoTL_STG.ToString("N2")
        RSTG(10) = Format(muallakadet_STG, "0.00")
        RSTG(11) = Format(muallakmaddiadet_STG, "0.00")
        RSTG(12) = muallakmaddimiktar_STG.ToString("N2")
        RSTG(13) = muallakmaddimiktarTL_STG.ToString("N2")
        RSTG(14) = Format(muallakbedeniadet_STG, "0.00")
        RSTG(15) = muallakbedenimiktar_STG.ToString("N2")
        RSTG(16) = muallakbedenimiktarTL_STG.ToString("N2")
        RSTG(17) = muallakgenelmiktar_STG.ToString("N2")
        RSTG(18) = muallakgenelmiktarTL_STG.ToString("N2")
        RSTG(19) = Format(odenenadet_STG, "0.00")
        RSTG(20) = Format(odenenmaddiadet_STG, "0.00")
        RSTG(21) = odenenmaddimiktar_STG.ToString("N2")
        RSTG(22) = odenenmaddimiktarTL_STG.ToString("N2")
        RSTG(23) = Format(odenenbedeniadet_STG, "0.00")
        RSTG(24) = odenenbedenimiktar_STG.ToString("N2")
        RSTG(25) = odenenbedenimiktarTL_STG.ToString("N2")
        RSTG(26) = odenengenelmiktar_STG.ToString("N2")
        RSTG(27) = odenengenelmiktarTL_STG.ToString("N2")
        RSTG(28) = Format(pertadet_STG, "0.00")
        RSTG(29) = pp_primTL_STG.ToString("N2")
        RSTG(30) = ip_primTL_STG.ToString("N2")
        table.Rows.Add(RSTG)


        RTL(0) = "TL"
        RTL(1) = "-"
        RTL(2) = "-"
        RTL(3) = CStr(TL_policeadet)
        RTL(4) = CStr(iptaladet_TL)
        RTL(5) = iptaliadetoplamprim_TL.ToString("N2")
        RTL(6) = pp_toplamprim_TL.ToString("N2")
        RTL(7) = ip_toplamprim_TL.ToString("N2")
        RTL(8) = toplamkasko_TL.ToString("N2")
        RTL(9) = toplamkaskoTL_TL.ToString("N2")
        RTL(10) = Format(muallakadet_TL, "0.00")
        RTL(11) = Format(muallakmaddiadet_TL, "0.00")
        RTL(12) = muallakmaddimiktar_TL.ToString("N2")
        RTL(13) = muallakmaddimiktarTL_TL.ToString("N2")
        RTL(14) = Format(muallakbedeniadet_TL, "0.00")
        RTL(15) = muallakbedenimiktar_TL.ToString("N2")
        RTL(16) = muallakbedenimiktarTL_TL.ToString("N2")
        RTL(17) = muallakgenelmiktar_TL.ToString("N2")
        RTL(18) = muallakgenelmiktarTL_TL.ToString("N2")
        RTL(19) = Format(odenenadet_TL, "0.00")
        RTL(20) = Format(odenenmaddiadet_TL, "0.00")
        RTL(21) = odenenmaddimiktar_TL.ToString("N2")
        RTL(22) = odenenmaddimiktarTL_TL.ToString("N2")
        RTL(23) = Format(odenenbedeniadet_TL, "0.00")
        RTL(24) = odenenbedenimiktar_TL.ToString("N2")
        RTL(25) = odenenbedenimiktarTL_TL.ToString("N2")
        RTL(26) = odenengenelmiktar_TL.ToString("N2")
        RTL(27) = odenengenelmiktarTL_TL.ToString("N2")
        RTL(28) = Format(pertadet_TL, "0.00")
        RTL(29) = pp_primTL_TL.ToString("N2")
        RTL(30) = ip_primTL_TL.ToString("N2")
        table.Rows.Add(RTL)


        RUSD(0) = "USD"
        RUSD(1) = "-"
        RUSD(2) = "-"
        RUSD(3) = CStr(USD_policeadet)
        RUSD(4) = CStr(iptaladet_USD)
        RUSD(5) = iptaliadetoplamprim_USD.ToString("N2")
        RUSD(6) = pp_toplamprim_USD.ToString("N2")
        RUSD(7) = ip_toplamprim_USD.ToString("N2")
        RUSD(8) = toplamkasko_USD.ToString("N2")
        RUSD(9) = toplamkaskoTL_USD.ToString("N2")
        RUSD(10) = Format(muallakadet_USD, "0.00")
        RUSD(11) = Format(muallakmaddiadet_USD, "0.00")
        RUSD(12) = muallakmaddimiktar_USD.ToString("N2")
        RUSD(13) = muallakmaddimiktarTL_USD.ToString("N2")
        RUSD(14) = Format(muallakbedeniadet_USD, "0.00")
        RUSD(15) = muallakbedenimiktar_USD.ToString("N2")
        RUSD(16) = muallakbedenimiktarTL_USD.ToString("N2")
        RUSD(17) = muallakgenelmiktar_USD.ToString("N2")
        RUSD(18) = muallakgenelmiktarTL_USD.ToString("N2")
        RUSD(19) = Format(odenenadet_USD, "0.00")
        RUSD(20) = Format(odenenmaddiadet_USD, "0.00")
        RUSD(21) = odenenmaddimiktar_USD.ToString("N2")
        RUSD(22) = odenenmaddimiktarTL_USD.ToString("N2")
        RUSD(23) = Format(odenenbedeniadet_USD, "0.00")
        RUSD(24) = odenenbedenimiktar_USD.ToString("N2")
        RUSD(25) = odenenbedenimiktarTL_USD.ToString("N2")
        RUSD(26) = odenengenelmiktar_USD.ToString("N2")
        RUSD(27) = odenengenelmiktarTL_USD.ToString("N2")
        RUSD(28) = Format(pertadet_USD, "0.00")
        RUSD(29) = pp_primTL_USD.ToString("N2")
        RUSD(30) = ip_primTL_USD.ToString("N2")
        table.Rows.Add(RUSD)



        REUR(0) = "EUR"
        REUR(1) = "-"
        REUR(2) = "-"
        REUR(3) = CStr(EUR_policeadet)
        REUR(4) = CStr(iptaladet_EUR)
        REUR(5) = iptaliadetoplamprim_EUR.ToString("N2")
        REUR(6) = pp_toplamprim_EUR.ToString("N2")
        REUR(7) = ip_toplamprim_EUR.ToString("N2")
        REUR(8) = toplamkasko_EUR.ToString("N2")
        REUR(9) = toplamkaskoTL_EUR.ToString("N2")
        REUR(10) = Format(muallakadet_EUR, "0.00")
        REUR(11) = Format(muallakmaddiadet_EUR, "0.00")
        REUR(12) = muallakmaddimiktar_EUR.ToString("N2")
        REUR(13) = muallakmaddimiktarTL_EUR.ToString("N2")
        REUR(14) = Format(muallakbedeniadet_EUR, "0.00")
        REUR(15) = muallakbedenimiktar_EUR.ToString("N2")
        REUR(16) = muallakbedenimiktarTL_EUR.ToString("N2")
        REUR(17) = muallakgenelmiktar_EUR.ToString("N2")
        REUR(18) = muallakgenelmiktarTL_EUR.ToString("N2")
        REUR(19) = Format(odenenadet_EUR, "0.00")
        REUR(20) = Format(odenenmaddiadet_EUR, "0.00")
        REUR(21) = odenenmaddimiktar_EUR.ToString("N2")
        REUR(22) = odenenmaddimiktarTL_EUR.ToString("N2")
        REUR(23) = Format(odenenbedeniadet_EUR, "0.00")
        REUR(24) = odenenbedenimiktar_EUR.ToString("N2")
        REUR(25) = odenenbedenimiktarTL_EUR.ToString("N2")
        REUR(26) = odenengenelmiktar_EUR.ToString("N2")
        REUR(27) = odenengenelmiktarTL_EUR.ToString("N2")
        REUR(28) = Format(pertadet_EUR, "0.00")
        REUR(29) = pp_primTL_EUR.ToString("N2")
        REUR(30) = ip_primTL_EUR.ToString("N2")
        table.Rows.Add(REUR)



        'ANA TOPLAM ADETLER
        RANATOPLAM(0) = "TOPLAM"
        RANATOPLAM(1) = "-"
        RANATOPLAM(2) = "-"
        RANATOPLAM(3) = CStr(anatoplam_policeadet)
        RANATOPLAM(4) = CStr(anatoplam_iptalpoliceadet)
        RANATOPLAM(5) = "-"
        RANATOPLAM(6) = "-"
        RANATOPLAM(7) = "-"
        RANATOPLAM(8) = "-"
        RANATOPLAM(9) = anatoplam_kaskoTL.ToString("N2")
        RANATOPLAM(10) = CStr(anatoplam_muallakadet)
        RANATOPLAM(11) = CStr(anatoplam_muallakmaddiadet)
        RANATOPLAM(12) = "-"
        RANATOPLAM(13) = "-"
        RANATOPLAM(14) = CStr(anatoplam_muallakbedeniadet)
        RANATOPLAM(15) = "-"
        RANATOPLAM(16) = "-"
        RANATOPLAM(17) = "-"
        RANATOPLAM(18) = "-"
        RANATOPLAM(19) = CStr(anatoplam_odenenadet)
        RANATOPLAM(20) = CStr(anatoplam_odenenmaddiadet)
        RANATOPLAM(21) = "-"
        RANATOPLAM(22) = "-"
        RANATOPLAM(23) = CStr(anatoplam_odenenbedeniadet)
        RANATOPLAM(24) = "-"
        RANATOPLAM(25) = "-"
        RANATOPLAM(26) = "-"
        RANATOPLAM(27) = "-"
        RANATOPLAM(28) = CStr(anatoplam_pertadet)
        RANATOPLAM(29) = anatoplam_pp_primTL.ToString("N2")
        RANATOPLAM(30) = anatoplam_ip_primTL.ToString("N2")
        table.Rows.Add(RANATOPLAM)


        'PDF İÇİN EKLE
        pdftable.AddCell(New Phrase("STG", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(CStr(STG_policeadet), fdata))
        pdftable.AddCell(New Phrase(CStr(iptaladet_STG), fdata))
        pdftable.AddCell(New Phrase(iptaliadetoplamprim_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(pp_toplamprim_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_toplamprim_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkasko_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkaskoTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakadet_STG, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakmaddiadet_STG, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktar_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktarTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakbedeniadet_STG, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktar_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktarTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktar_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktarTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenadet_STG, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenmaddiadet_STG, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktar_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktarTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenbedeniadet_STG, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktar_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktarTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktar_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktarTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(pertadet_STG, "0.00"), fdata))
        pdftable.AddCell(New Phrase(pp_primTL_STG.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_primTL_STG.ToString("N2"), fdata))
  

        pdftable.AddCell(New Phrase("TL", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(CStr(TL_policeadet), fdata))
        pdftable.AddCell(New Phrase(CStr(iptaladet_TL), fdata))
        pdftable.AddCell(New Phrase(iptaliadetoplamprim_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(pp_toplamprim_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_toplamprim_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkasko_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkaskoTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakadet_TL, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakmaddiadet_TL, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktar_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktarTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakbedeniadet_TL, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktar_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktarTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktar_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktarTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenadet_TL, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenmaddiadet_TL, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktar_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktarTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenbedeniadet_TL, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktar_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktarTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktar_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktarTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(pertadet_TL, "0.00"), fdata))
        pdftable.AddCell(New Phrase(pp_primTL_TL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_primTL_TL.ToString("N2"), fdata))


        pdftable.AddCell(New Phrase("USD", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(CStr(USD_policeadet), fdata))
        pdftable.AddCell(New Phrase(CStr(iptaladet_USD), fdata))
        pdftable.AddCell(New Phrase(iptaliadetoplamprim_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(pp_toplamprim_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_toplamprim_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkasko_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkaskoTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakadet_USD, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakmaddiadet_USD, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktar_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktarTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakbedeniadet_USD, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktar_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktarTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktar_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktarTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenadet_USD, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenmaddiadet_USD, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktar_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktarTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenbedeniadet_USD, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktar_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktarTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktar_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktarTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(pertadet_USD, "0.00"), fdata))
        pdftable.AddCell(New Phrase(pp_primTL_USD.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_primTL_USD.ToString("N2"), fdata))


        pdftable.AddCell(New Phrase("EUR", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(CStr(EUR_policeadet), fdata))
        pdftable.AddCell(New Phrase(CStr(iptaladet_EUR), fdata))
        pdftable.AddCell(New Phrase(iptaliadetoplamprim_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(pp_toplamprim_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_toplamprim_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkasko_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(toplamkaskoTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakadet_EUR, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakmaddiadet_EUR, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktar_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakmaddimiktarTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(muallakbedeniadet_EUR, "0.00"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktar_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakbedenimiktarTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktar_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(muallakgenelmiktarTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenadet_EUR, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenmaddiadet_EUR, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktar_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenmaddimiktarTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(odenenbedeniadet_EUR, "0.00"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktar_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenenbedenimiktarTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktar_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(odenengenelmiktarTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(Format(pertadet_EUR, "0.00"), fdata))
        pdftable.AddCell(New Phrase(pp_primTL_EUR.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(ip_primTL_EUR.ToString("N2"), fdata))

        'ANA TOPLAM PDF
        pdftable.AddCell(New Phrase("TOPLAM", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(anatoplam_policeadet, fdata))
        pdftable.AddCell(New Phrase(anatoplam_iptalpoliceadet, fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(anatoplam_kaskoTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(anatoplam_muallakadet, fdata))
        pdftable.AddCell(New Phrase(anatoplam_muallakmaddiadet, fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(anatoplam_muallakbedeniadet, fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(anatoplam_odenenadet, fdata))
        pdftable.AddCell(New Phrase(anatoplam_odenenmaddiadet, fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(anatoplam_odenenbedeniadet, fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(anatoplam_pertadet, fdata))
        pdftable.AddCell(New Phrase(anatoplam_pp_primTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(anatoplam_ip_primTL.ToString("N2"), fdata))
     

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




    'AYLARA GÖRE DAĞILIMI İÇİN DETAYLI----------------------
    Public Function veriyarat10(ByVal db_baglanti As SqlConnection, _
     ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18, kol19, kol20 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12, saf13, saf14, saf15, saf16, saf17 As String
        Dim saf18, saf19, saf20 As String
        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket Kodu</th>" + _
        "<th>Şirket Adı</th>" + _
        "<th>Ocak</th>" + _
        "<th>Şubat</th>" + _
        "<th>Mart</th>" + _
        "<th>Nisan</th>" + _
        "<th>Mayıs</th>" + _
        "<th>Haziran</th>" + _
        "<th>Temmuz</th>" + _
        "<th>Ağustos</th>" + _
        "<th>Eylül</th>" + _
        "<th>Ekim</th>" + _
        "<th>Kasım</th>" + _
        "<th>Aralık</th>" + _
        "<th>Yıl İçinde Toplam Faturalandırılan Miktar</th>" + _
        "<th>Sadece Yıl İçinde Toplam Ödenen Miktar</th>" + _
        "<th>Yıl İçinde Kesilen Faturaların Genel Ödeme Toplamı</th>" + _
        "<th>Yıl Sonu Bakiyesi</th>" + _
        "<th>Genel Bakiyesi</th>" + _
        "<th>Toplam Poliçe Adeti</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket Kodu", GetType(String))
        table.Columns.Add("Şirket Adı", GetType(String))
        table.Columns.Add("Ocak", GetType(String))
        table.Columns.Add("Şubat", GetType(String))
        table.Columns.Add("Mart", GetType(String))
        table.Columns.Add("Nisan", GetType(String))
        table.Columns.Add("Mayıs", GetType(String))
        table.Columns.Add("Haziran", GetType(String))
        table.Columns.Add("Temmuz", GetType(String))
        table.Columns.Add("Ağustos", GetType(String))
        table.Columns.Add("Eylül", GetType(String))
        table.Columns.Add("Ekim", GetType(String))
        table.Columns.Add("Kasım", GetType(String))
        table.Columns.Add("Aralık", GetType(String))
        table.Columns.Add("Yıl İçinde Toplam Faturalandırılan Miktar", GetType(String))
        table.Columns.Add("Sadece Yıl İçinde Toplam Ödenen Miktar", GetType(String))
        table.Columns.Add("Yıl İçinde Kesilen Faturaların Genel Ödeme Toplamı", GetType(String))
        table.Columns.Add("Yıl Sonu Bakiyesi", GetType(String))
        table.Columns.Add("Genel Bakiyesi", GetType(String))
        table.Columns.Add("Toplam Poliçe Adeti", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(20)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Şirket Adı", fbaslik))
        pdftable.AddCell(New Phrase("Ocak", fbaslik))
        pdftable.AddCell(New Phrase("Şubat", fbaslik))
        pdftable.AddCell(New Phrase("Mart", fbaslik))
        pdftable.AddCell(New Phrase("Nisan", fbaslik))
        pdftable.AddCell(New Phrase("Mayıs", fbaslik))
        pdftable.AddCell(New Phrase("Haziran", fbaslik))
        pdftable.AddCell(New Phrase("Temmuz", fbaslik))
        pdftable.AddCell(New Phrase("Ağustos", fbaslik))
        pdftable.AddCell(New Phrase("Eylül", fbaslik))
        pdftable.AddCell(New Phrase("Ekim", fbaslik))
        pdftable.AddCell(New Phrase("Kasım", fbaslik))
        pdftable.AddCell(New Phrase("Aralık", fbaslik))
        pdftable.AddCell(New Phrase("Yıl İçinde Toplam Faturalandırılan Miktar", fbaslik))
        pdftable.AddCell(New Phrase("Sadece Yıl İçinde Toplam Ödenen Miktar", fbaslik))
        pdftable.AddCell(New Phrase("Yıl İçinde Kesilen Faturaların Genel Ödeme Toplamı", fbaslik))
        pdftable.AddCell(New Phrase("Yıl Sonu Bakiyesi", fbaslik))
        pdftable.AddCell(New Phrase("Genel Bakiyesi", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Poliçe Adeti", fbaslik))

        tabloson = "</tbody></table>"

        Dim hesap_erisim As New CLASSHESAP_ERISIM

        Dim toplamsatir As String
        Dim sirketkod, sirketad As String
        Dim gelir, gider, bakiye As Decimal
        Dim yazi As String
        Dim gidert, gelirt As Decimal
        Dim genelodemetoplam As Decimal = 0
        Dim genelbakiye As Decimal = 0



        Dim alt_ocak, alt_subat, alt_mart, alt_nisan, alt_mayis, alt_haziran As Double
        Dim alt_temmuz, alt_agustos, alt_eylul, alt_ekim, alt_kasim, alt_aralik As Double
        alt_ocak = 0
        alt_subat = 0
        alt_mart = 0
        alt_nisan = 0
        alt_mayis = 0
        alt_haziran = 0
        alt_temmuz = 0
        alt_agustos = 0
        alt_eylul = 0
        alt_ekim = 0
        alt_kasim = 0
        alt_aralik = 0

        Dim adet_toplamyil As Double = 0
        Dim adet_ocak, adet_subat, adet_mart, adet_nisan, adet_mayis, adet_haziran As Double
        Dim adet_temmuz, adet_agustos, adet_eylul, adet_ekim, adet_kasim, adet_aralik As Double


        While veri.Read

            genelodemetoplam = 0

            girdi = "1"

            If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                sirketkod = veri.Item("sirketkod")
                kol1 = "<tr><td>" + sirketkod + "</td>"
                saf1 = sirketkod
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("sirketad") Is System.DBNull.Value Then
                sirketad = veri.Item("sirketad")
                kol2 = "<td>" + sirketad + "</td>"
                saf2 = sirketad
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If


            Dim ghesap As New CLASSHESAP
            Dim faturano As String
            Dim ilgiliodemesi_pkey As Integer
            Dim ilgiliodeme As New CLASSHESAP

            Dim yil As String
            yil = Current.Session("yil")

            'OCAK AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 1, yil)


            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 1, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 1, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_ocak = 0
            If ghesap.pkey <> 0 Then
                adet_ocak = ghesap.tutar / ghesap.eder
                alt_ocak = alt_ocak + adet_ocak
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_ocak) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol3 = "<td>" + yazi + "</td>"
            saf3 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_ocak) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'ŞUBAT AYI İÇİN HESAPLA 
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 2, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 2, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 2, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_subat = 0
            If ghesap.pkey <> 0 Then
                adet_subat = ghesap.tutar / ghesap.eder
                alt_subat = alt_subat + adet_subat
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_subat) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol4 = "<td>" + yazi + "</td>"

            saf4 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_subat) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")


            'MART AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 3, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 3, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 3, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_mart = 0
            If ghesap.pkey <> 0 Then
                adet_mart = ghesap.tutar / ghesap.eder
                alt_mart = alt_mart + adet_mart
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_mart) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol5 = "<td>" + yazi + "</td>"

            saf5 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_mart) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")


            'NİSAN AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 4, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 4, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 4, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_nisan = 0
            If ghesap.pkey <> 0 Then
                adet_nisan = ghesap.tutar / ghesap.eder
                alt_nisan = alt_nisan + adet_nisan
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_nisan) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol6 = "<td>" + yazi + "</td>"

            saf6 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_nisan) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")


            'MAYIS AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 5, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 5, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 5, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_mayis = 0
            If ghesap.pkey <> 0 Then
                adet_mayis = ghesap.tutar / ghesap.eder
                alt_mayis = alt_mayis + adet_mayis
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_mayis) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol7 = "<td>" + yazi + "</td>"

            saf7 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_mayis) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'HAZİRAN AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 6, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 6, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 6, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_haziran = 0
            If ghesap.pkey <> 0 Then
                adet_haziran = ghesap.tutar / ghesap.eder
                alt_haziran = alt_haziran + adet_haziran
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_haziran) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol8 = "<td>" + yazi + "</td>"


            saf8 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_haziran) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'TEMMUZ AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 7, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 7, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 7, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_temmuz = 0
            If ghesap.pkey <> 0 Then
                adet_temmuz = ghesap.tutar / ghesap.eder
                alt_temmuz = alt_temmuz + adet_temmuz
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_temmuz) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol9 = "<td>" + yazi + "</td>"


            saf9 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_temmuz) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'AĞUSTOS AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 8, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 8, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 8, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_agustos = 0
            If ghesap.pkey <> 0 Then
                adet_agustos = ghesap.tutar / ghesap.eder
                alt_agustos = alt_agustos + adet_agustos
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_agustos) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol10 = "<td>" + yazi + "</td>"

            saf10 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_agustos) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'EYLÜL AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 9, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 9, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 9, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_eylul = 0
            If ghesap.pkey <> 0 Then
                adet_eylul = ghesap.tutar / ghesap.eder
                alt_eylul = alt_eylul + adet_eylul
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_eylul) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol11 = "<td>" + yazi + "</td>"


            saf11 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_eylul) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'EKİM AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 10, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 10, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 10, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_ekim = 0
            If ghesap.pkey <> 0 Then
                adet_ekim = ghesap.tutar / ghesap.eder
                alt_ekim = alt_ekim + adet_ekim
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_ekim) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol12 = "<td>" + yazi + "</td>"

            saf12 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_ekim) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'KASIM AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 11, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 11, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 11, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_kasim = 0
            If ghesap.pkey <> 0 Then
                adet_kasim = ghesap.tutar / ghesap.eder
                alt_kasim = alt_kasim + adet_kasim
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_kasim) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol13 = "<td>" + yazi + "</td>"

            saf13 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_kasim) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'ARALIK AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 12, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 12, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 12, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_aralik = 0
            If ghesap.pkey <> 0 Then
                adet_aralik = ghesap.tutar / ghesap.eder
                alt_aralik = alt_aralik + adet_aralik
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            yazi = "F:" + Format(gelir, "0.00") + "<br/>" + _
            "E:" + Format(ghesap.eder, "0.00") + "<br/>" + _
            "A:" + CStr(adet_aralik) + "<br/>" + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00") + "<br/>"

            kol14 = "<td>" + yazi + "</td>"

            saf14 = "F:" + Format(gelir, "0.00") + System.Environment.NewLine + _
            "E:" + Format(ghesap.eder, "0.00") + System.Environment.NewLine + _
            "A:" + CStr(adet_aralik) + System.Environment.NewLine + _
            "Ö:" + Format(ilgiliodeme.tutar, "0.00")



            'YIL İÇİNDEKİ FATURALANDIRILAN TOPLAM
            gelirt = hesap_erisim.gelirbulyilli(sirketkod, yil)
            kol15 = "<td>" + Format(gelirt, "0.00") + "</td>"
            saf15 = Format(gelirt, "0.00")

            'SADECE YIL İÇİNDE TOPLAM ÖDENEN MİKTAR
            gidert = hesap_erisim.giderbulyilli(sirketkod, yil)
            kol16 = "<td>" + Format(gidert, "0.00") + "</td>"
            saf16 = Format(gidert, "0.00")


            'GENEL ÖDEME TOPLAMI
            kol17 = "<td>" + Format(genelodemetoplam, "0.00") + "</td>"
            saf17 = Format(genelodemetoplam, "0.00")


            'YIL SONU BAKİYESİ
            bakiye = hesap_erisim.bakiyebulyilli(sirketkod, yil)
            kol18 = "<td>" + Format(bakiye, "0.00") + "</td>"
            saf18 = Format(bakiye, "0.00")

            'GENEL BAKİYESİ 
            genelbakiye = hesap_erisim.bakiyebul(sirketkod)
            kol19 = "<td>" + Format(genelbakiye, "0.00") + "</td>"
            saf19 = Format(genelbakiye, "0.00")


            'YIL İÇİNDEKİ TOPLAM KESİLEN POLİÇE ADETİ
            adet_toplamyil = adet_ocak + adet_subat + adet_mart + adet_nisan + adet_mayis + _
            adet_haziran + adet_temmuz + adet_agustos + adet_eylul + adet_ekim + adet_kasim + adet_aralik

            kol20 = "<td>" + CStr(adet_toplamyil) + "</td></tr>"
            saf20 = CStr(adet_toplamyil)

            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + _
            kol11 + kol12 + kol13 + kol14 + kol15 + _
            kol16 + kol17 + kol18 + kol19 + kol20

            table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, _
            saf7, saf8, saf9, saf10, saf11, saf12, saf13, saf14, saf15, saf16, saf17, _
            saf18, saf19, saf20)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf3, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
            pdftable.AddCell(New Phrase(saf6, fdata))
            pdftable.AddCell(New Phrase(saf7, fdata))
            pdftable.AddCell(New Phrase(saf8, fdata))
            pdftable.AddCell(New Phrase(saf9, fdata))
            pdftable.AddCell(New Phrase(saf10, fdata))
            pdftable.AddCell(New Phrase(saf11, fdata))
            pdftable.AddCell(New Phrase(saf12, fdata))
            pdftable.AddCell(New Phrase(saf13, fdata))
            pdftable.AddCell(New Phrase(saf14, fdata))
            pdftable.AddCell(New Phrase(saf15, fdata))
            pdftable.AddCell(New Phrase(saf16, fdata))
            pdftable.AddCell(New Phrase(saf17, fdata))
            pdftable.AddCell(New Phrase(saf18, fdata))
            pdftable.AddCell(New Phrase(saf19, fdata))
            pdftable.AddCell(New Phrase(saf20, fdata))


        End While


        'EN ALT TOPLAM SATIRI
        'HTML İÇİN EKLE
        toplamsatir = "<tr>" + _
        "<td>TOPLAM</td>" + _
        "<td>TOPLAM</td>" + _
        "<td>" + CStr(alt_ocak) + "</td>" + _
        "<td>" + CStr(alt_subat) + "</td>" + _
        "<td>" + CStr(alt_mart) + "</td>" + _
        "<td>" + CStr(alt_nisan) + "</td>" + _
        "<td>" + CStr(alt_mayis) + "</td>" + _
        "<td>" + CStr(alt_haziran) + "</td>" + _
        "<td>" + CStr(alt_temmuz) + "</td>" + _
        "<td>" + CStr(alt_agustos) + "</td>" + _
        "<td>" + CStr(alt_eylul) + "</td>" + _
        "<td>" + CStr(alt_ekim) + "</td>" + _
        "<td>" + CStr(alt_kasim) + "</td>" + _
        "<td>" + CStr(alt_aralik) + "</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "<td>-</td>" + _
        "</tr>"

        satir = satir + toplamsatir


        'WORD EXCEL KISMINI OLUŞTUR
        Dim R As DataRow = table.NewRow
        R(0) = "-"
        R(1) = "-"
        R(2) = CStr(alt_ocak)
        R(3) = CStr(alt_subat)
        R(4) = CStr(alt_mart)
        R(5) = CStr(alt_nisan)
        R(6) = CStr(alt_mayis)
        R(7) = CStr(alt_haziran)
        R(8) = CStr(alt_temmuz)
        R(9) = CStr(alt_agustos)
        R(10) = CStr(alt_eylul)
        R(11) = CStr(alt_ekim)
        R(12) = CStr(alt_kasim)
        R(13) = CStr(alt_aralik)
        R(14) = "-"
        R(15) = "-"
        R(16) = "-"
        R(17) = "-"
        R(18) = "-"
        R(19) = "-"
        table.Rows.Add(R)


        'PDF İÇİN EKLE
        pdftable.AddCell(New Phrase("Toplam", fdata))
        pdftable.AddCell(New Phrase(Format("Toplam", "0.00"), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_ocak), fdata))

        pdftable.AddCell(New Phrase(CStr(alt_ocak), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_subat), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_mart), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_nisan), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_mayis), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_haziran), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_temmuz), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_agustos), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_eylul), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_ekim), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_kasim), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_aralik), fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase("-", fdata))

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







    'AYLARA GÖRE DAĞILIMI İÇİN DETAYLI----------------------
    Public Function veriyarat11(ByVal db_baglanti As SqlConnection, _
     ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9 As String
        Dim saf10, saf11, saf12, saf13, saf14, saf15 As String
        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Şirket Kodu</th>" + _
        "<th>Şirket Adı</th>" + _
        "<th>Ocak</th>" + _
        "<th>Şubat</th>" + _
        "<th>Mart</th>" + _
        "<th>Nisan</th>" + _
        "<th>Mayıs</th>" + _
        "<th>Haziran</th>" + _
        "<th>Temmuz</th>" + _
        "<th>Ağustos</th>" + _
        "<th>Eylül</th>" + _
        "<th>Ekim</th>" + _
        "<th>Kasım</th>" + _
        "<th>Aralık</th>" + _
        "<th>Toplam Poliçe Adeti</th>" + _
        "</tr>" + _
        "</thead>"

        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Şirket Kodu", GetType(String))
        table.Columns.Add("Şirket Adı", GetType(String))
        table.Columns.Add("Ocak", GetType(String))
        table.Columns.Add("Şubat", GetType(String))
        table.Columns.Add("Mart", GetType(String))
        table.Columns.Add("Nisan", GetType(String))
        table.Columns.Add("Mayıs", GetType(String))
        table.Columns.Add("Haziran", GetType(String))
        table.Columns.Add("Temmuz", GetType(String))
        table.Columns.Add("Ağustos", GetType(String))
        table.Columns.Add("Eylül", GetType(String))
        table.Columns.Add("Ekim", GetType(String))
        table.Columns.Add("Kasım", GetType(String))
        table.Columns.Add("Aralık", GetType(String))
        table.Columns.Add("Toplam Poliçe Adeti", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(15)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Şirket Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Şirket Adı", fbaslik))
        pdftable.AddCell(New Phrase("Ocak", fbaslik))
        pdftable.AddCell(New Phrase("Şubat", fbaslik))
        pdftable.AddCell(New Phrase("Mart", fbaslik))
        pdftable.AddCell(New Phrase("Nisan", fbaslik))
        pdftable.AddCell(New Phrase("Mayıs", fbaslik))
        pdftable.AddCell(New Phrase("Haziran", fbaslik))
        pdftable.AddCell(New Phrase("Temmuz", fbaslik))
        pdftable.AddCell(New Phrase("Ağustos", fbaslik))
        pdftable.AddCell(New Phrase("Eylül", fbaslik))
        pdftable.AddCell(New Phrase("Ekim", fbaslik))
        pdftable.AddCell(New Phrase("Kasım", fbaslik))
        pdftable.AddCell(New Phrase("Aralık", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Poliçe Adeti", fbaslik))

        tabloson = "</tbody></table>"

        Dim hesap_erisim As New CLASSHESAP_ERISIM

        Dim toplamsatir As String
        Dim sirketkod, sirketad As String
        Dim gelir, gider, bakiye As Decimal
        Dim yazi As String
        Dim gidert, gelirt As Decimal
        Dim genelodemetoplam As Decimal = 0
        Dim genelbakiye As Decimal = 0



        Dim alt_ocak, alt_subat, alt_mart, alt_nisan, alt_mayis, alt_haziran As Double
        Dim alt_temmuz, alt_agustos, alt_eylul, alt_ekim, alt_kasim, alt_aralik As Double
        alt_ocak = 0
        alt_subat = 0
        alt_mart = 0
        alt_nisan = 0
        alt_mayis = 0
        alt_haziran = 0
        alt_temmuz = 0
        alt_agustos = 0
        alt_eylul = 0
        alt_ekim = 0
        alt_kasim = 0
        alt_aralik = 0

        Dim adet_toplamyil As Double = 0
        Dim adet_ocak, adet_subat, adet_mart, adet_nisan, adet_mayis, adet_haziran As Double
        Dim adet_temmuz, adet_agustos, adet_eylul, adet_ekim, adet_kasim, adet_aralik As Double


        While veri.Read

            genelodemetoplam = 0

            girdi = "1"

            If Not veri.Item("sirketkod") Is System.DBNull.Value Then
                sirketkod = veri.Item("sirketkod")
                kol1 = "<tr><td>" + sirketkod + "</td>"
                saf1 = sirketkod
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("sirketad") Is System.DBNull.Value Then
                sirketad = veri.Item("sirketad")
                kol2 = "<td>" + sirketad + "</td>"
                saf2 = sirketad
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If


            Dim ghesap As New CLASSHESAP
            Dim faturano As String
            Dim ilgiliodemesi_pkey As Integer
            Dim ilgiliodeme As New CLASSHESAP

            Dim yil As String
            yil = Current.Session("yil")

            'OCAK AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 1, yil)


            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 1, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 1, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_ocak = 0
            If ghesap.pkey <> 0 Then
                adet_ocak = ghesap.tutar / ghesap.eder
                alt_ocak = alt_ocak + adet_ocak
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol3 = "<td>" + CStr(adet_ocak) + "</td>"
            saf3 = CStr(adet_ocak)



            'ŞUBAT AYI İÇİN HESAPLA 
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 2, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 2, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 2, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_subat = 0
            If ghesap.pkey <> 0 Then
                adet_subat = ghesap.tutar / ghesap.eder
                alt_subat = alt_subat + adet_subat
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol4 = "<td>" + CStr(adet_subat) + "</td>"
            saf4 = CStr(adet_subat)


            'MART AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 3, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 3, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 3, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_mart = 0
            If ghesap.pkey <> 0 Then
                adet_mart = ghesap.tutar / ghesap.eder
                alt_mart = alt_mart + adet_mart
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol5 = "<td>" + CStr(adet_mart) + "</td>"
            saf5 = CStr(adet_mart)


            'NİSAN AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 4, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 4, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 4, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_nisan = 0
            If ghesap.pkey <> 0 Then
                adet_nisan = ghesap.tutar / ghesap.eder
                alt_nisan = alt_nisan + adet_nisan
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If

            kol6 = "<td>" + CStr(adet_nisan) + "</td>"
            saf6 = CStr(adet_nisan)


            'MAYIS AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 5, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 5, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 5, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_mayis = 0
            If ghesap.pkey <> 0 Then
                adet_mayis = ghesap.tutar / ghesap.eder
                alt_mayis = alt_mayis + adet_mayis
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol7 = "<td>" + CStr(adet_mayis) + "</td>"
            saf7 = CStr(adet_mayis)



            'HAZİRAN AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 6, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 6, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 6, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_haziran = 0
            If ghesap.pkey <> 0 Then
                adet_haziran = ghesap.tutar / ghesap.eder
                alt_haziran = alt_haziran + adet_haziran
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol8 = "<td>" + CStr(adet_haziran) + "</td>"
            saf8 = CStr(adet_haziran)



            'TEMMUZ AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 7, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 7, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 7, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_temmuz = 0
            If ghesap.pkey <> 0 Then
                adet_temmuz = ghesap.tutar / ghesap.eder
                alt_temmuz = alt_temmuz + adet_temmuz
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol9 = "<td>" + CStr(adet_temmuz) + "</td>"
            saf9 = CStr(adet_temmuz)




            'AĞUSTOS AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 8, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 8, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 8, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_agustos = 0
            If ghesap.pkey <> 0 Then
                adet_agustos = ghesap.tutar / ghesap.eder
                alt_agustos = alt_agustos + adet_agustos
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol10 = "<td>" + CStr(adet_agustos) + "</td>"
            saf10 = CStr(adet_agustos)

      



            'EYLÜL AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 9, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 9, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 9, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_eylul = 0
            If ghesap.pkey <> 0 Then
                adet_eylul = ghesap.tutar / ghesap.eder
                alt_eylul = alt_eylul + adet_eylul
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol11 = "<td>" + CStr(adet_eylul) + "</td>"
            saf11 = CStr(adet_eylul)




            'EKİM AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 10, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 10, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 10, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_ekim = 0
            If ghesap.pkey <> 0 Then
                adet_ekim = ghesap.tutar / ghesap.eder
                alt_ekim = alt_ekim + adet_ekim
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol12 = "<td>" + CStr(adet_ekim) + "</td>"
            saf12 = CStr(adet_ekim)



            'KASIM AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 11, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 11, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 11, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_kasim = 0
            If ghesap.pkey <> 0 Then
                adet_kasim = ghesap.tutar / ghesap.eder
                alt_kasim = alt_kasim + adet_kasim
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol13 = "<td>" + CStr(adet_kasim) + "</td>"
            saf13 = CStr(adet_kasim)



            'ARALIK AYI İÇİN HESAPLA
            gelir = hesap_erisim.gelirbulayli_yilli(sirketkod, 12, yil)
            gider = hesap_erisim.giderbulayli_yilli(sirketkod, 12, yil)
            faturano = hesap_erisim.faturanobul(sirketkod, "Gelir", 12, yil)
            ghesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            ilgiliodeme = New CLASSHESAP

            adet_aralik = 0
            If ghesap.pkey <> 0 Then
                adet_aralik = ghesap.tutar / ghesap.eder
                alt_aralik = alt_aralik + adet_aralik
            End If

            If faturano <> "0" Then
                ilgiliodemesi_pkey = hesap_erisim.odemesibul_pkey(sirketkod, faturano, "Gider")
                If ilgiliodemesi_pkey <> 0 Then
                    ilgiliodeme = hesap_erisim.bultek(ilgiliodemesi_pkey)
                    genelodemetoplam = genelodemetoplam + ilgiliodeme.tutar
                End If
            End If
            kol14 = "<td>" + CStr(adet_aralik) + "</td>"
            saf14 = CStr(adet_aralik)




            'YIL İÇİNDEKİ TOPLAM KESİLEN POLİÇE ADETİ
            adet_toplamyil = adet_ocak + adet_subat + adet_mart + adet_nisan + adet_mayis + _
            adet_haziran + adet_temmuz + adet_agustos + adet_eylul + adet_ekim + adet_kasim + adet_aralik

            kol15 = "<td>" + CStr(adet_toplamyil) + "</td></tr>"
            saf15 = CStr(adet_toplamyil)

            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + _
            kol6 + kol7 + kol8 + kol9 + kol10 + _
            kol11 + kol12 + kol13 + kol14 + kol15

            table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, _
            saf7, saf8, saf9, saf10, saf11, saf12, saf13, saf14, saf15)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf3, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
            pdftable.AddCell(New Phrase(saf6, fdata))
            pdftable.AddCell(New Phrase(saf7, fdata))
            pdftable.AddCell(New Phrase(saf8, fdata))
            pdftable.AddCell(New Phrase(saf9, fdata))
            pdftable.AddCell(New Phrase(saf10, fdata))
            pdftable.AddCell(New Phrase(saf11, fdata))
            pdftable.AddCell(New Phrase(saf12, fdata))
            pdftable.AddCell(New Phrase(saf13, fdata))
            pdftable.AddCell(New Phrase(saf14, fdata))
            pdftable.AddCell(New Phrase(saf15, fdata))


        End While


        'EN ALT TOPLAM SATIRI
        'HTML İÇİN EKLE
        toplamsatir = "<tr>" + _
        "<td>TOPLAM</td>" + _
        "<td>TOPLAM</td>" + _
        "<td>" + CStr(alt_ocak) + "</td>" + _
        "<td>" + CStr(alt_subat) + "</td>" + _
        "<td>" + CStr(alt_mart) + "</td>" + _
        "<td>" + CStr(alt_nisan) + "</td>" + _
        "<td>" + CStr(alt_mayis) + "</td>" + _
        "<td>" + CStr(alt_haziran) + "</td>" + _
        "<td>" + CStr(alt_temmuz) + "</td>" + _
        "<td>" + CStr(alt_agustos) + "</td>" + _
        "<td>" + CStr(alt_eylul) + "</td>" + _
        "<td>" + CStr(alt_ekim) + "</td>" + _
        "<td>" + CStr(alt_kasim) + "</td>" + _
        "<td>" + CStr(alt_aralik) + "</td>" + _
        "<td>-</td>" + _
        "</tr>"

        satir = satir + toplamsatir


        'WORD EXCEL KISMINI OLUŞTUR
        Dim R As DataRow = table.NewRow
        R(0) = "-"
        R(1) = "-"
        R(2) = CStr(alt_ocak)
        R(3) = CStr(alt_subat)
        R(4) = CStr(alt_mart)
        R(5) = CStr(alt_nisan)
        R(6) = CStr(alt_mayis)
        R(7) = CStr(alt_haziran)
        R(8) = CStr(alt_temmuz)
        R(9) = CStr(alt_agustos)
        R(10) = CStr(alt_eylul)
        R(11) = CStr(alt_ekim)
        R(12) = CStr(alt_kasim)
        R(13) = CStr(alt_aralik)
        R(14) = "-"
        table.Rows.Add(R)


        'PDF İÇİN EKLE
        pdftable.AddCell(New Phrase("Toplam", fdata))
        pdftable.AddCell(New Phrase(Format("Toplam", "0.00"), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_ocak), fdata))

        pdftable.AddCell(New Phrase(CStr(alt_ocak), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_subat), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_mart), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_nisan), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_mayis), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_haziran), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_temmuz), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_agustos), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_eylul), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_ekim), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_kasim), fdata))
        pdftable.AddCell(New Phrase(CStr(alt_aralik), fdata))
        pdftable.AddCell(New Phrase("-", fdata))
   
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



    Public Function veriyarat12(ByVal db_baglanti As SqlConnection, _
    ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18, kol19, kol20 As String
        Dim kol21, kol22, kol23, kol24, kol25, kol26, kol27 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14, saf15, saf16, saf17, saf18, saf19, saf20 As String
        Dim saf21, saf22, saf23, saf24, saf25, saf26, saf27 As String

        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Tarife Kodu</th>" + _
        "<th>Hİ 0</th>" + _
        "<th>Hİ 10</th>" + _
        "<th>Hİ 20</th>" + _
        "<th>Hİ 30</th>" + _
        "<th>Hİ 40</th>" + _
        "<th>HZ 0</th>" + _
        "<th>HZ 15</th>" + _
        "<th>HZ 20</th>" + _
        "<th>HZ 25</th>" + _
        "<th>HZ 30</th>" + _
        "<th>HZ 35</th>" + _
        "<th>HZ 40</th>" + _
        "<th>HZ 50</th>" + _
        "<th>YZ 0</th>" + _
        "<th>YZ 15</th>" + _
        "<th>YZ 30</th>" + _
        "<th>CC 0</th>" + _
        "<th>CC 5</th>" + _
        "<th>CC 15</th>" + _
        "<th>CC 20</th>" + _
        "<th>CC 25</th>" + _
        "<th>CC 30</th>" + _
        "<th>CC 35</th>" + _
        "<th>CC 45</th>" + _
        "<th>CC 50</th>" + _
        "<th>CC 75</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Tarife Kodu", GetType(String))
        table.Columns.Add("Hİ 0", GetType(String))
        table.Columns.Add("Hİ 10", GetType(String))
        table.Columns.Add("Hİ 20", GetType(String))
        table.Columns.Add("Hİ 30", GetType(String))
        table.Columns.Add("Hİ 40", GetType(String))
        table.Columns.Add("HZ 0", GetType(String))
        table.Columns.Add("HZ 15", GetType(String))
        table.Columns.Add("HZ 20", GetType(String))
        table.Columns.Add("HZ 25", GetType(String))
        table.Columns.Add("HZ 30", GetType(String))
        table.Columns.Add("HZ 35", GetType(String))
        table.Columns.Add("HZ 40", GetType(String))
        table.Columns.Add("HZ 50", GetType(String))
        table.Columns.Add("YZ 0", GetType(String))
        table.Columns.Add("YZ 15", GetType(String))
        table.Columns.Add("YZ 30", GetType(String))
        table.Columns.Add("CC 0", GetType(String))
        table.Columns.Add("CC 5", GetType(String))
        table.Columns.Add("CC 15", GetType(String))
        table.Columns.Add("CC 20", GetType(String))
        table.Columns.Add("CC 25", GetType(String))
        table.Columns.Add("CC 30", GetType(String))
        table.Columns.Add("CC 35", GetType(String))
        table.Columns.Add("CC 45", GetType(String))
        table.Columns.Add("CC 50", GetType(String))
        table.Columns.Add("CC 75", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(27)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarife Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 0", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 10", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 20", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 30", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 40", fbaslik))
        pdftable.AddCell(New Phrase("HZ 0", fbaslik))
        pdftable.AddCell(New Phrase("HZ 15", fbaslik))
        pdftable.AddCell(New Phrase("HZ 20", fbaslik))
        pdftable.AddCell(New Phrase("HZ 25", fbaslik))
        pdftable.AddCell(New Phrase("HZ 30", fbaslik))
        pdftable.AddCell(New Phrase("HZ 35", fbaslik))
        pdftable.AddCell(New Phrase("HZ 40", fbaslik))
        pdftable.AddCell(New Phrase("HZ 50", fbaslik))
        pdftable.AddCell(New Phrase("YZ 0", fbaslik))
        pdftable.AddCell(New Phrase("YZ 15", fbaslik))
        pdftable.AddCell(New Phrase("YZ 30", fbaslik))
        pdftable.AddCell(New Phrase("CC 0", fbaslik))
        pdftable.AddCell(New Phrase("CC 5", fbaslik))
        pdftable.AddCell(New Phrase("CC 15", fbaslik))
        pdftable.AddCell(New Phrase("CC 20", fbaslik))
        pdftable.AddCell(New Phrase("CC 25", fbaslik))
        pdftable.AddCell(New Phrase("CC 30", fbaslik))
        pdftable.AddCell(New Phrase("CC 35", fbaslik))
        pdftable.AddCell(New Phrase("CC 45", fbaslik))
        pdftable.AddCell(New Phrase("CC 50", fbaslik))
        pdftable.AddCell(New Phrase("CC 75", fbaslik))
        tabloson = "</tbody></table>"


        Dim toplamsatir As String
        Dim TariffCode As String
        Dim DamagelessRate_sifir, DamagelessRate_on, DamagelessRate_yirmi, DamagelessRate_otuz, DamagelessRate_kirk As String
        Dim DamageRate_sifir, DamageRate_onbes, DamageRate_yirmi, DamageRate_yirmibes, DamageRate_otuz, DamageRate_otuzbes As String
        Dim DamageRate_kirk, DamageRate_elli As String
        Dim AgeRate_sifir, AgeRate_onbes As String
        Dim AgeRate_otuz, CCRate_sifir, CCRate_bes As String
        Dim CCRate_onbes, CCRate_yirmi, CCRate_yirmibes, CCRate_otuz, CCRate_otuzbes, CCRate_kirkbes, CCRate_elli, CCRate_yetmisbes As String

        Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16, t17, t18, t19, t20 As Integer
        Dim t21, t22, t23, t24, t25, t26 As Integer

        t1 = 0
        t2 = 0
        t3 = 0
        t4 = 0
        t5 = 0
        t6 = 0
        t7 = 0
        t8 = 0
        t9 = 0
        t10 = 0
        t11 = 0
        t12 = 0
        t13 = 0
        t14 = 0
        t15 = 0
        t16 = 0
        t17 = 0
        t18 = 0
        t19 = 0
        t20 = 0
        t20 = 0
        t21 = 0
        t22 = 0
        t23 = 0
        t24 = 0
        t25 = 0
        t26 = 0



        While veri.Read

            girdi = "1"


            If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                TariffCode = veri.Item("TariffCode")
                kol1 = "<tr><td>" + TariffCode + "</td>"
                saf1 = TariffCode
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If


            If Not veri.Item("DamagelessRate_sifir") Is System.DBNull.Value Then
                DamagelessRate_sifir = veri.Item("DamagelessRate_sifir")
                t1 = t1 + CInt(DamagelessRate_sifir)
                kol2 = "<td>" + DamagelessRate_sifir + "</td>"
                saf2 = DamagelessRate_sifir
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If


            If Not veri.Item("DamagelessRate_on") Is System.DBNull.Value Then
                DamagelessRate_on = veri.Item("DamagelessRate_on")
                t2 = t2 + CInt(DamagelessRate_on)
                kol3 = "<td>" + DamagelessRate_on + "</td>"
                saf3 = DamagelessRate_on
            Else
                kol3 = "<td>-</td>"
                saf3 = "-"
            End If


            If Not veri.Item("DamagelessRate_yirmi") Is System.DBNull.Value Then
                DamagelessRate_yirmi = veri.Item("DamagelessRate_yirmi")
                t3 = t3 + CInt(DamagelessRate_yirmi)
                kol4 = "<td>" + DamagelessRate_yirmi + "</td>"
                saf4 = DamagelessRate_yirmi
            Else
                kol4 = "<td>-</td>"
                saf4 = "-"
            End If


            If Not veri.Item("DamagelessRate_otuz") Is System.DBNull.Value Then
                DamagelessRate_otuz = veri.Item("DamagelessRate_otuz")
                t4 = t4 + CInt(DamagelessRate_otuz)
                kol5 = "<td>" + DamagelessRate_otuz + "</td>"
                saf5 = DamagelessRate_otuz
            Else
                kol5 = "<td>-</td>"
                saf5 = "-"
            End If

            If Not veri.Item("DamagelessRate_kirk") Is System.DBNull.Value Then
                DamagelessRate_kirk = veri.Item("DamagelessRate_kirk")
                t5 = t5 + CInt(DamagelessRate_kirk)
                kol6 = "<td>" + DamagelessRate_kirk + "</td>"
                saf6 = DamagelessRate_kirk
            Else
                kol6 = "<td>-</td>"
                saf6 = "-"
            End If

            If Not veri.Item("DamageRate_sifir") Is System.DBNull.Value Then
                DamageRate_sifir = veri.Item("DamageRate_sifir")
                t6 = t6 + CInt(DamageRate_sifir)
                kol7 = "<td>" + DamageRate_sifir + "</td>"
                saf7 = DamageRate_sifir
            Else
                kol7 = "<td>-</td>"
                saf7 = "-"
            End If


            If Not veri.Item("DamageRate_onbes") Is System.DBNull.Value Then
                DamageRate_onbes = veri.Item("DamageRate_onbes")
                t7 = t7 + CInt(DamageRate_onbes)
                kol8 = "<td>" + DamageRate_onbes + "</td>"
                saf8 = DamageRate_onbes
            Else
                kol8 = "<td>-</td>"
                saf8 = "-"
            End If


            If Not veri.Item("DamageRate_yirmi") Is System.DBNull.Value Then
                DamageRate_yirmi = veri.Item("DamageRate_yirmi")
                t8 = t8 + CInt(DamageRate_yirmi)
                kol9 = "<td>" + DamageRate_yirmi + "</td>"
                saf9 = DamageRate_yirmi
            Else
                kol9 = "<td>-</td>"
                saf9 = "-"
            End If

            If Not veri.Item("DamageRate_yirmibes") Is System.DBNull.Value Then
                DamageRate_yirmibes = veri.Item("DamageRate_yirmibes")
                t9 = t9 + CInt(DamageRate_yirmibes)
                kol10 = "<td>" + DamageRate_yirmibes + "</td>"
                saf10 = DamageRate_yirmibes
            Else
                kol10 = "<td>-</td>"
                saf10 = "-"
            End If


            If Not veri.Item("DamageRate_otuz") Is System.DBNull.Value Then
                DamageRate_otuz = veri.Item("DamageRate_otuz")
                t10 = t10 + CInt(DamageRate_otuz)
                kol11 = "<td>" + DamageRate_otuz + "</td>"
                saf11 = DamageRate_otuz
            Else
                kol11 = "<td>-</td>"
                saf11 = "-"
            End If


            If Not veri.Item("DamageRate_otuzbes") Is System.DBNull.Value Then
                DamageRate_otuzbes = veri.Item("DamageRate_otuzbes")
                t11 = t11 + CInt(DamageRate_otuzbes)
                kol12 = "<td>" + DamageRate_otuzbes + "</td>"
                saf12 = DamageRate_otuzbes
            Else
                kol12 = "<td>-</td>"
                saf12 = "-"
            End If


            If Not veri.Item("DamageRate_kirk") Is System.DBNull.Value Then
                DamageRate_kirk = veri.Item("DamageRate_kirk")
                t12 = t12 + CInt(DamageRate_kirk)
                kol13 = "<td>" + DamageRate_kirk + "</td>"
                saf13 = DamageRate_kirk
            Else
                kol13 = "<td>-</td>"
                saf13 = "-"
            End If

            If Not veri.Item("DamageRate_elli") Is System.DBNull.Value Then
                DamageRate_elli = veri.Item("DamageRate_elli")
                t13 = t13 + CInt(DamageRate_elli)
                kol14 = "<td>" + DamageRate_elli + "</td>"
                saf14 = DamageRate_elli
            Else
                kol14 = "<td>-</td>"
                saf14 = "-"
            End If


            If Not veri.Item("AgeRate_sifir") Is System.DBNull.Value Then
                AgeRate_sifir = veri.Item("AgeRate_sifir")
                t14 = t14 + CInt(AgeRate_sifir)
                kol15 = "<td>" + AgeRate_sifir + "</td>"
                saf15 = AgeRate_sifir
            Else
                kol15 = "<td>-</td>"
                saf15 = "-"
            End If


            If Not veri.Item("AgeRate_onbes") Is System.DBNull.Value Then
                AgeRate_onbes = veri.Item("AgeRate_onbes")
                t15 = t15 + CInt(AgeRate_onbes)
                kol16 = "<td>" + AgeRate_onbes + "</td>"
                saf16 = AgeRate_onbes
            Else
                kol16 = "<td>-</td>"
                saf16 = "-"
            End If

            If Not veri.Item("AgeRate_otuz") Is System.DBNull.Value Then
                AgeRate_otuz = veri.Item("AgeRate_otuz")
                t16 = t16 + CInt(AgeRate_otuz)
                kol17 = "<td>" + AgeRate_otuz + "</td>"
                saf17 = AgeRate_otuz
            Else
                kol17 = "<td>-</td>"
                saf17 = "-"
            End If


            If Not veri.Item("CCRate_sifir") Is System.DBNull.Value Then
                CCRate_sifir = veri.Item("CCRate_sifir")
                t17 = t17 + CInt(CCRate_sifir)
                kol18 = "<td>" + CCRate_sifir + "</td>"
                saf18 = CCRate_sifir
            Else
                kol18 = "<td>-</td>"
                saf18 = "-"
            End If

            If Not veri.Item("CCRate_bes") Is System.DBNull.Value Then
                CCRate_bes = veri.Item("CCRate_bes")
                t18 = t18 + CInt(CCRate_bes)
                kol19 = "<td>" + CCRate_bes + "</td>"
                saf19 = CCRate_bes
            Else
                kol19 = "<td>-</td>"
                saf19 = "-"
            End If

            If Not veri.Item("CCRate_onbes") Is System.DBNull.Value Then
                CCRate_onbes = veri.Item("CCRate_onbes")
                t19 = t19 + CInt(CCRate_onbes)
                kol20 = "<td>" + CCRate_onbes + "</td>"
                saf20 = CCRate_onbes
            Else
                kol20 = "<td>-</td>"
                saf20 = "-"
            End If


            If Not veri.Item("CCRate_yirmi") Is System.DBNull.Value Then
                CCRate_yirmi = veri.Item("CCRate_yirmi")
                t20 = t20 + CInt(CCRate_yirmi)
                kol21 = "<td>" + CCRate_yirmi + "</td>"
                saf21 = CCRate_yirmi
            Else
                kol21 = "<td>-</td>"
                saf21 = "-"
            End If

            If Not veri.Item("CCRate_yirmibes") Is System.DBNull.Value Then
                CCRate_yirmibes = veri.Item("CCRate_yirmibes")
                t21 = t21 + CInt(CCRate_yirmibes)
                kol22 = "<td>" + CCRate_yirmibes + "</td>"
                saf22 = CCRate_yirmibes
            Else
                kol22 = "<td>-</td>"
                saf22 = "-"
            End If

            If Not veri.Item("CCRate_otuz") Is System.DBNull.Value Then
                CCRate_otuz = veri.Item("CCRate_otuz")
                t22 = t22 + CInt(CCRate_otuz)
                kol23 = "<td>" + CCRate_otuz + "</td>"
                saf23 = CCRate_otuz
            Else
                kol23 = "<td>-</td>"
                saf23 = "-"
            End If

            If Not veri.Item("CCRate_otuzbes") Is System.DBNull.Value Then
                CCRate_otuzbes = veri.Item("CCRate_otuzbes")
                t23 = t23 + CInt(CCRate_otuzbes)
                kol24 = "<td>" + CCRate_otuzbes + "</td>"
                saf24 = CCRate_otuzbes
            Else
                kol24 = "<td>-</td>"
                saf24 = "-"
            End If

            If Not veri.Item("CCRate_kirkbes") Is System.DBNull.Value Then
                CCRate_kirkbes = veri.Item("CCRate_kirkbes")
                t24 = t24 + CInt(CCRate_kirkbes)
                kol25 = "<td>" + CCRate_kirkbes + "</td>"
                saf25 = CCRate_kirkbes
            Else
                kol25 = "<td>-</td>"
                saf25 = "-"
            End If

            If Not veri.Item("CCRate_elli") Is System.DBNull.Value Then
                CCRate_elli = veri.Item("CCRate_elli")
                t25 = t25 + CInt(CCRate_elli)
                kol26 = "<td>" + CCRate_elli + "</td>"
                saf26 = CCRate_elli
            Else
                kol26 = "<td>-</td>"
                saf26 = "-"
            End If

            If Not veri.Item("CCRate_yetmisbes") Is System.DBNull.Value Then
                CCRate_yetmisbes = veri.Item("CCRate_yetmisbes")
                t26 = t26 + CInt(CCRate_yetmisbes)
                kol27 = "<td>" + CCRate_yetmisbes + "</td></tr>"
                saf27 = CCRate_yetmisbes
            Else
                kol27 = "<td>-</td></tr>"
                saf27 = "-"
            End If



            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + _
            kol11 + kol12 + kol13 + kol14 + kol15 + kol16 + kol17 + kol18 + kol19 + kol20 + _
            kol21 + kol22 + kol23 + kol24 + kol25 + kol26 + kol27


            table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10, _
            saf11, saf12, saf13, saf14, saf15, saf16, saf17, saf18, saf19, saf20, _
            saf21, saf22, saf23, saf24, saf25, saf26, saf27)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf3, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
            pdftable.AddCell(New Phrase(saf6, fdata))
            pdftable.AddCell(New Phrase(saf7, fdata))
            pdftable.AddCell(New Phrase(saf8, fdata))
            pdftable.AddCell(New Phrase(saf9, fdata))
            pdftable.AddCell(New Phrase(saf10, fdata))
            pdftable.AddCell(New Phrase(saf11, fdata))
            pdftable.AddCell(New Phrase(saf12, fdata))
            pdftable.AddCell(New Phrase(saf13, fdata))
            pdftable.AddCell(New Phrase(saf14, fdata))
            pdftable.AddCell(New Phrase(saf15, fdata))
            pdftable.AddCell(New Phrase(saf16, fdata))
            pdftable.AddCell(New Phrase(saf17, fdata))
            pdftable.AddCell(New Phrase(saf18, fdata))
            pdftable.AddCell(New Phrase(saf19, fdata))
            pdftable.AddCell(New Phrase(saf20, fdata))
            pdftable.AddCell(New Phrase(saf21, fdata))
            pdftable.AddCell(New Phrase(saf22, fdata))
            pdftable.AddCell(New Phrase(saf23, fdata))
            pdftable.AddCell(New Phrase(saf24, fdata))
            pdftable.AddCell(New Phrase(saf25, fdata))
            pdftable.AddCell(New Phrase(saf26, fdata))
            pdftable.AddCell(New Phrase(saf27, fdata))

        End While


        'EN ALT TOPLAM SATIRI
        'HTML İÇİN EKLE
        toplamsatir = "<tr>" + _
        "<td>TOPLAM</td>" + _
        "<td>" + CStr(t1) + "</td>" + _
        "<td>" + CStr(t2) + "</td>" + _
        "<td>" + CStr(t3) + "</td>" + _
        "<td>" + CStr(t4) + "</td>" + _
        "<td>" + CStr(t5) + "</td>" + _
        "<td>" + CStr(t6) + "</td>" + _
        "<td>" + CStr(t7) + "</td>" + _
        "<td>" + CStr(t8) + "</td>" + _
        "<td>" + CStr(t9) + "</td>" + _
        "<td>" + CStr(t10) + "</td>" + _
        "<td>" + CStr(t11) + "</td>" + _
        "<td>" + CStr(t12) + "</td>" + _
        "<td>" + CStr(t13) + "</td>" + _
        "<td>" + CStr(t14) + "</td>" + _
        "<td>" + CStr(t15) + "</td>" + _
        "<td>" + CStr(t16) + "</td>" + _
        "<td>" + CStr(t17) + "</td>" + _
        "<td>" + CStr(t18) + "</td>" + _
        "<td>" + CStr(t19) + "</td>" + _
        "<td>" + CStr(t20) + "</td>" + _
        "<td>" + CStr(t21) + "</td>" + _
        "<td>" + CStr(t22) + "</td>" + _
        "<td>" + CStr(t23) + "</td>" + _
        "<td>" + CStr(t24) + "</td>" + _
        "<td>" + CStr(t25) + "</td>" + _
        "<td>" + CStr(t26) + "</td>" + _
        "</tr>"

        satir = satir + toplamsatir


        'WORD EXCEL KISMINI OLUŞTUR
        Dim R As DataRow = table.NewRow
        R(0) = "-"
        R(1) = CStr(t1)
        R(2) = CStr(t2)
        R(3) = CStr(t3)
        R(4) = CStr(t4)
        R(5) = CStr(t5)
        R(6) = CStr(t6)
        R(7) = CStr(t7)
        R(8) = CStr(t8)
        R(9) = CStr(t9)
        R(10) = CStr(t10)
        R(11) = CStr(t11)
        R(12) = CStr(t12)
        R(13) = CStr(t13)
        R(14) = CStr(t14)
        R(15) = CStr(t15)
        R(16) = CStr(t16)
        R(17) = CStr(t17)
        R(18) = CStr(t18)
        R(19) = CStr(t19)
        R(20) = CStr(t20)
        R(21) = CStr(t21)
        R(22) = CStr(t22)
        R(23) = CStr(t23)
        R(24) = CStr(t24)
        R(25) = CStr(t25)
        R(26) = CStr(t26)

        table.Rows.Add(R)


        'PDF İÇİN EKLE
        pdftable.AddCell(New Phrase("Toplam", fdata))
        pdftable.AddCell(New Phrase(CStr(t1), fdata))
        pdftable.AddCell(New Phrase(CStr(t2), fdata))
        pdftable.AddCell(New Phrase(CStr(t3), fdata))
        pdftable.AddCell(New Phrase(CStr(t4), fdata))
        pdftable.AddCell(New Phrase(CStr(t5), fdata))
        pdftable.AddCell(New Phrase(CStr(t6), fdata))
        pdftable.AddCell(New Phrase(CStr(t7), fdata))
        pdftable.AddCell(New Phrase(CStr(t8), fdata))
        pdftable.AddCell(New Phrase(CStr(t9), fdata))
        pdftable.AddCell(New Phrase(CStr(t10), fdata))
        pdftable.AddCell(New Phrase(CStr(t11), fdata))
        pdftable.AddCell(New Phrase(CStr(t12), fdata))
        pdftable.AddCell(New Phrase(CStr(t13), fdata))
        pdftable.AddCell(New Phrase(CStr(t14), fdata))
        pdftable.AddCell(New Phrase(CStr(t15), fdata))
        pdftable.AddCell(New Phrase(CStr(t16), fdata))
        pdftable.AddCell(New Phrase(CStr(t17), fdata))
        pdftable.AddCell(New Phrase(CStr(t18), fdata))
        pdftable.AddCell(New Phrase(CStr(t19), fdata))
        pdftable.AddCell(New Phrase(CStr(t20), fdata))
        pdftable.AddCell(New Phrase(CStr(t21), fdata))
        pdftable.AddCell(New Phrase(CStr(t22), fdata))
        pdftable.AddCell(New Phrase(CStr(t23), fdata))
        pdftable.AddCell(New Phrase(CStr(t24), fdata))
        pdftable.AddCell(New Phrase(CStr(t25), fdata))
        pdftable.AddCell(New Phrase(CStr(t26), fdata))


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





    Public Function veriyarat13(ByVal db_baglanti As SqlConnection, _
    ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR

        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18, kol19, kol20 As String
        Dim kol21, kol22, kol23, kol24, kol25, kol26, kol27, kol28, kol29, kol30 As String

        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14, saf15, saf16, saf17, saf18, saf19, saf20 As String
        Dim saf21, saf22, saf23, saf24, saf25, saf26, saf27, saf28, saf29, saf30 As String

        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Tarife Kodu</th>" + _
        "<th>Genel Toplam</th>" + _
        "<th>İndirim ve Zam Almayanlar</th>" + _
        "<th>Hİ 0</th>" + _
        "<th>Hİ 10</th>" + _
        "<th>Hİ 20</th>" + _
        "<th>Hİ 30</th>" + _
        "<th>Hİ 40</th>" + _
        "<th>HZ 0</th>" + _
        "<th>HZ 15</th>" + _
        "<th>HZ 20</th>" + _
        "<th>HZ 25</th>" + _
        "<th>HZ 30</th>" + _
        "<th>HZ 35</th>" + _
        "<th>HZ 40</th>" + _
        "<th>HZ 50</th>" + _
        "<th>YZ 0</th>" + _
        "<th>YZ 15</th>" + _
        "<th>YZ 30</th>" + _
        "<th>CC 0</th>" + _
        "<th>CC 5</th>" + _
        "<th>CC 15</th>" + _
        "<th>CC 20</th>" + _
        "<th>CC 25</th>" + _
        "<th>CC 30</th>" + _
        "<th>CC 35</th>" + _
        "<th>CC 45</th>" + _
        "<th>CC 50</th>" + _
        "<th>CC 75</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Tarife Kodu", GetType(String))
        table.Columns.Add("Genel Toplam", GetType(String))
        table.Columns.Add("İndirim ve Zam Almayanlar", GetType(String))
        table.Columns.Add("Hİ 0", GetType(String))
        table.Columns.Add("Hİ 10", GetType(String))
        table.Columns.Add("Hİ 20", GetType(String))
        table.Columns.Add("Hİ 30", GetType(String))
        table.Columns.Add("Hİ 40", GetType(String))
        table.Columns.Add("HZ 0", GetType(String))
        table.Columns.Add("HZ 15", GetType(String))
        table.Columns.Add("HZ 20", GetType(String))
        table.Columns.Add("HZ 25", GetType(String))
        table.Columns.Add("HZ 30", GetType(String))
        table.Columns.Add("HZ 35", GetType(String))
        table.Columns.Add("HZ 40", GetType(String))
        table.Columns.Add("HZ 50", GetType(String))
        table.Columns.Add("YZ 0", GetType(String))
        table.Columns.Add("YZ 15", GetType(String))
        table.Columns.Add("YZ 30", GetType(String))
        table.Columns.Add("CC 0", GetType(String))
        table.Columns.Add("CC 5", GetType(String))
        table.Columns.Add("CC 15", GetType(String))
        table.Columns.Add("CC 20", GetType(String))
        table.Columns.Add("CC 25", GetType(String))
        table.Columns.Add("CC 30", GetType(String))
        table.Columns.Add("CC 35", GetType(String))
        table.Columns.Add("CC 45", GetType(String))
        table.Columns.Add("CC 50", GetType(String))
        table.Columns.Add("CC 75", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim intTblWidth() As Integer = {10, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
        Dim pdftable As New PdfPTable(29)
        pdftable.WidthPercentage = 105.0F
        pdftable.SetWidths(intTblWidth)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarife Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Genel Toplam", fbaslik))
        pdftable.AddCell(New Phrase("İndirim ve Zam Almayanlar", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 0", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 10", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 20", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 30", fbaslik))
        pdftable.AddCell(New Phrase("Hİ 40", fbaslik))
        pdftable.AddCell(New Phrase("HZ 0", fbaslik))
        pdftable.AddCell(New Phrase("HZ 15", fbaslik))
        pdftable.AddCell(New Phrase("HZ 20", fbaslik))
        pdftable.AddCell(New Phrase("HZ 25", fbaslik))
        pdftable.AddCell(New Phrase("HZ 30", fbaslik))
        pdftable.AddCell(New Phrase("HZ 35", fbaslik))
        pdftable.AddCell(New Phrase("HZ 40", fbaslik))
        pdftable.AddCell(New Phrase("HZ 50", fbaslik))
        pdftable.AddCell(New Phrase("YZ 0", fbaslik))
        pdftable.AddCell(New Phrase("YZ 15", fbaslik))
        pdftable.AddCell(New Phrase("YZ 30", fbaslik))
        pdftable.AddCell(New Phrase("CC 0", fbaslik))
        pdftable.AddCell(New Phrase("CC 5", fbaslik))
        pdftable.AddCell(New Phrase("CC 15", fbaslik))
        pdftable.AddCell(New Phrase("CC 20", fbaslik))
        pdftable.AddCell(New Phrase("CC 25", fbaslik))
        pdftable.AddCell(New Phrase("CC 30", fbaslik))
        pdftable.AddCell(New Phrase("CC 35", fbaslik))
        pdftable.AddCell(New Phrase("CC 45", fbaslik))
        pdftable.AddCell(New Phrase("CC 50", fbaslik))
        pdftable.AddCell(New Phrase("CC 75", fbaslik))
        tabloson = "</tbody></table>"


        Dim kontrolbazfiyat As Double = HttpContext.Current.Session("kontrolbazfiyat")

        Dim toplamsatir, degersatir, oransatir, carpimsatir As String
        Dim TariffCode As String
        Dim sonucyazi As String

        Dim PolicyPremiumTL As Decimal
    
        Dim toplamupolice As Decimal
        Dim toplamhz, toplamhi, toplamyz, toplamcc, toplampolice, toplamindirim, toplamzam As Decimal

        Dim DamageveDamagelessRate_sifir As Integer
        Dim DamagelessRate_sifir, DamagelessRate_on, DamagelessRate_yirmi, DamagelessRate_otuz, DamagelessRate_kirk As Integer
        Dim DamageRate_sifir, DamageRate_onbes, DamageRate_yirmi, DamageRate_yirmibes, DamageRate_otuz As Integer
        Dim DamageRate_otuzbes, DamageRate_kirk, DamageRate_elli, AgeRate_sifir, AgeRate_onbes As Integer
        Dim AgeRate_otuz, CCRate_sifir, CCRate_bes, CCRate_onbes, CCRate_yirmi As Integer
        Dim CCRate_yirmibes, CCRate_otuz, CCRate_otuzbes, CCRate_kirkbes, CCRate_elli As Integer
        Dim CCRate_yetmisbes As Integer

        Dim toplam_DamageveDamagelessRate_sifir As Integer
        Dim toplam_DamagelessRate_sifir, toplam_DamagelessRate_on, toplam_DamagelessRate_yirmi, toplam_DamagelessRate_otuz, toplam_DamagelessRate_kirk As Integer
        Dim toplam_DamageRate_sifir, toplam_DamageRate_onbes, toplam_DamageRate_yirmi, toplam_DamageRate_yirmibes, toplam_DamageRate_otuz As Integer
        Dim toplam_DamageRate_otuzbes, toplam_DamageRate_kirk, toplam_DamageRate_elli, toplam_AgeRate_sifir, toplam_AgeRate_onbes As Integer
        Dim toplam_AgeRate_otuz, toplam_CCRate_sifir, toplam_CCRate_bes, toplam_CCRate_onbes, toplam_CCRate_yirmi As Integer
        Dim toplam_CCRate_yirmibes, toplam_CCRate_otuz, toplam_CCRate_otuzbes, toplam_CCRate_kirkbes, toplam_CCRate_elli As Integer
        Dim toplam_CCRate_yetmisbes As Integer

        Dim DamageveDamagelessRate_oran As Decimal
        Dim DamagelessRate_sifir_oran, DamagelessRate_on_oran, DamagelessRate_yirmi_oran, DamagelessRate_otuz_oran, DamagelessRate_kirk_oran As Decimal
        Dim DamageRate_sifir_oran, DamageRate_onbes_oran, DamageRate_yirmi_oran, DamageRate_yirmibes_oran, DamageRate_otuz_oran As Decimal
        Dim DamageRate_otuzbes_oran, DamageRate_kirk_oran, DamageRate_elli_oran, AgeRate_sifir_oran, AgeRate_onbes_oran As Decimal
        Dim AgeRate_otuz_oran, CCRate_sifir_oran, CCRate_bes_oran, CCRate_onbes_oran, CCRate_yirmi_oran As Decimal
        Dim CCRate_yirmibes_oran, CCRate_otuz_oran, CCRate_otuzbes_oran, CCRate_kirkbes_oran, CCRate_elli_oran As Decimal
        Dim CCRate_yetmisbes_oran As Decimal

        Dim DamageveDamagelessRate_carpim As Decimal
        Dim DamagelessRate_sifir_carpim, DamagelessRate_on_carpim, DamagelessRate_yirmi_carpim, DamagelessRate_otuz_carpim, DamagelessRate_kirk_carpim As Decimal
        Dim DamageRate_sifir_carpim, DamageRate_onbes_carpim, DamageRate_yirmi_carpim, DamageRate_yirmibes_carpim, DamageRate_otuz_carpim As Decimal
        Dim DamageRate_otuzbes_carpim, DamageRate_kirk_carpim, DamageRate_elli_carpim, AgeRate_sifir_carpim, AgeRate_onbes_carpim As Decimal
        Dim AgeRate_otuz_carpim, CCRate_sifir_carpim, CCRate_bes_carpim, CCRate_onbes_carpim, CCRate_yirmi_carpim As Decimal
        Dim CCRate_yirmibes_carpim, CCRate_otuz_carpim, CCRate_otuzbes_carpim, CCRate_kirkbes_carpim, CCRate_elli_carpim As Decimal
        Dim CCRate_yetmisbes_carpim As Decimal

        Dim toplam_policesayigercek As Integer
        Dim toplam_PolicyPremiumTL As Decimal
        toplam_policesayigercek = 0
        toplam_PolicyPremiumTL = 0

        toplam_DamageveDamagelessRate_sifir = 0
        toplam_DamagelessRate_sifir = 0
        toplam_DamagelessRate_on = 0
        toplam_DamagelessRate_yirmi = 0
        toplam_DamagelessRate_otuz = 0
        toplam_DamagelessRate_kirk = 0
        toplam_DamageRate_sifir = 0
        toplam_DamageRate_onbes = 0
        toplam_DamageRate_yirmi = 0
        toplam_DamageRate_yirmibes = 0
        toplam_DamageRate_otuz = 0
        toplam_DamageRate_otuzbes = 0
        toplam_DamageRate_kirk = 0
        toplam_DamageRate_elli = 0
        toplam_AgeRate_sifir = 0
        toplam_AgeRate_onbes = 0
        toplam_AgeRate_otuz = 0
        toplam_CCRate_sifir = 0
        toplam_CCRate_bes = 0
        toplam_CCRate_onbes = 0
        toplam_CCRate_yirmi = 0
        toplam_CCRate_yirmibes = 0
        toplam_CCRate_otuz = 0
        toplam_CCRate_otuzbes = 0
        toplam_CCRate_kirkbes = 0
        toplam_CCRate_elli = 0
        toplam_CCRate_yetmisbes = 0


        DamageveDamagelessRate_oran = (kontrolbazfiyat / 100) * 0
        DamagelessRate_sifir_oran = (kontrolbazfiyat / 100) * Current.Session("hi0oran")
        DamagelessRate_on_oran = (kontrolbazfiyat / 100) * Current.Session("hi10oran")
        DamagelessRate_yirmi_oran = (kontrolbazfiyat / 100) * Current.Session("hi20oran")
        DamagelessRate_otuz_oran = (kontrolbazfiyat / 100) * Current.Session("hi30oran")
        DamagelessRate_kirk_oran = (kontrolbazfiyat / 100) * Current.Session("hi40oran")
        DamageRate_sifir_oran = (kontrolbazfiyat / 100) * Current.Session("hz0oran")
        DamageRate_onbes_oran = (kontrolbazfiyat / 100) * Current.Session("hz15oran")
        DamageRate_yirmi_oran = (kontrolbazfiyat / 100) * Current.Session("hz20oran")
        DamageRate_yirmibes_oran = (kontrolbazfiyat / 100) * Current.Session("hz25oran")
        DamageRate_otuz_oran = (kontrolbazfiyat / 100) * Current.Session("hz30oran")
        DamageRate_otuzbes_oran = (kontrolbazfiyat / 100) * Current.Session("hz35oran")
        DamageRate_kirk_oran = (kontrolbazfiyat / 100) * Current.Session("hz40oran")
        DamageRate_elli_oran = (kontrolbazfiyat / 100) * Current.Session("hz50oran")
        AgeRate_sifir_oran = (kontrolbazfiyat / 100) * Current.Session("yz0oran")
        AgeRate_onbes_oran = (kontrolbazfiyat / 100) * Current.Session("yz15oran")
        AgeRate_otuz_oran = (kontrolbazfiyat / 100) * Current.Session("yz30oran")
        CCRate_sifir_oran = (kontrolbazfiyat / 100) * Current.Session("cc0oran")
        CCRate_bes_oran = (kontrolbazfiyat / 100) * Current.Session("cc5oran")
        CCRate_onbes_oran = (kontrolbazfiyat / 100) * Current.Session("cc15oran")
        CCRate_yirmi_oran = (kontrolbazfiyat / 100) * Current.Session("cc20oran")
        CCRate_yirmibes_oran = (kontrolbazfiyat / 100) * Current.Session("cc25oran")
        CCRate_otuz_oran = (kontrolbazfiyat / 100) * Current.Session("cc30oran")
        CCRate_otuzbes_oran = (kontrolbazfiyat / 100) * Current.Session("cc35oran")
        CCRate_kirkbes_oran = (kontrolbazfiyat / 100) * Current.Session("cc45oran")
        CCRate_elli_oran = (kontrolbazfiyat / 100) * Current.Session("cc50oran")
        CCRate_yetmisbes_oran = (kontrolbazfiyat / 100) * Current.Session("cc75oran")

        Dim toplam_DamageveDamagelessRateValue As Decimal
        Dim toplam_DamagelessRateValue As Decimal
        Dim toplam_DamageRateValue As Decimal


        Dim DamageveDamagelessRateValue_sifir As Decimal = 0
        Dim DamagelessRateValue_sifir As Decimal
        Dim DamagelessRateValue_on As Decimal
        Dim DamagelessRateValue_yirmi As Decimal
        Dim DamagelessRateValue_otuz As Decimal
        Dim DamagelessRateValue_kirk As Decimal
        Dim DamageRateValue_sifir As Decimal
        Dim DamageRateValue_onbes As Decimal
        Dim DamageRateValue_yirmi As Decimal
        Dim DamageRateValue_yirmibes As Decimal
        Dim DamageRateValue_otuz As Decimal
        Dim DamageRateValue_otuzbes As Decimal
        Dim DamageRateValue_kirk As Decimal
        Dim DamageRateValue_elli As Decimal

        Dim toplam_AgeRateValue As Decimal
        Dim toplam_CCRateValue As Decimal
        Dim AgeRateValue_sifir As Decimal
        Dim AgeRateValue_onbes As Decimal
        Dim AgeRateValue_otuz As Decimal
        Dim CCRateValue_sifir As Decimal
        Dim CCRateValue_bes As Decimal
        Dim CCRateValue_onbes As Decimal
        Dim CCRateValue_yirmi As Decimal
        Dim CCRateValue_yirmibes As Decimal
        Dim CCRateValue_otuz As Decimal
        Dim CCRateValue_otuzbes As Decimal
        Dim CCRateValue_kirkbes As Decimal
        Dim CCRateValue_elli As Decimal
        Dim CCRateValue_yetmisbes As Decimal

        Dim toplamzam_damage, toplamzam_age, toplamzam_cc As Decimal

        While veri.Read

            girdi = "1"

            If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                TariffCode = veri.Item("TariffCode")
                kol1 = "<tr><td>" + TariffCode + "</td>"
                saf1 = TariffCode
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("policesayig") Is System.DBNull.Value Then
                toplam_policesayigercek = toplam_policesayigercek + veri.Item("policesayig")
            End If

            'genel toplam 
            kol2 = "<td>-</td>"
            saf2 = "-"

            'zam ve indirim almayanlar
            If Not veri.Item("DamageveDamagelessRate_sifir") Is System.DBNull.Value Then
                DamageveDamagelessRate_sifir = veri.Item("DamageveDamagelessRate_sifir")
                toplam_DamageveDamagelessRate_sifir = toplam_DamageveDamagelessRate_sifir + DamageveDamagelessRate_sifir
                kol3 = "<td>" + CStr(DamageveDamagelessRate_sifir) + "</td>"
                saf3 = CStr(DamageveDamagelessRate_sifir)
            Else
                kol3 = "<td>-</td>"
                saf3 = "-"
            End If

            If Not veri.Item("DamagelessRate_sifir") Is System.DBNull.Value Then
                DamagelessRate_sifir = veri.Item("DamagelessRate_sifir")
                toplam_DamagelessRate_sifir = toplam_DamagelessRate_sifir + DamagelessRate_sifir
                kol4 = "<td>" + CStr(DamagelessRate_sifir) + "</td>"
                saf4 = CStr(DamagelessRate_sifir)
            Else
                kol4 = "<td>-</td>"
                saf4 = "-"
            End If

            If Not veri.Item("DamagelessRate_on") Is System.DBNull.Value Then
                DamagelessRate_on = veri.Item("DamagelessRate_on")
                toplam_DamagelessRate_on = toplam_DamagelessRate_on + DamagelessRate_on
                kol5 = "<td>" + CStr(DamagelessRate_on) + "</td>"
                saf5 = CStr(DamagelessRate_on)
            Else
                kol5 = "<td>-</td>"
                saf5 = "-"
            End If

            If Not veri.Item("DamagelessRate_yirmi") Is System.DBNull.Value Then
                DamagelessRate_yirmi = veri.Item("DamagelessRate_yirmi")
                toplam_DamagelessRate_yirmi = toplam_DamagelessRate_yirmi + DamagelessRate_yirmi
                kol6 = "<td>" + CStr(DamagelessRate_yirmi) + "</td>"
                saf6 = CStr(DamagelessRate_yirmi)
            Else
                kol6 = "<td>-</td>"
                saf6 = "-"
            End If

            If Not veri.Item("DamagelessRate_otuz") Is System.DBNull.Value Then
                DamagelessRate_otuz = veri.Item("DamagelessRate_otuz")
                toplam_DamagelessRate_otuz = toplam_DamagelessRate_otuz + DamagelessRate_otuz
                kol7 = "<td>" + CStr(DamagelessRate_otuz) + "</td>"
                saf7 = CStr(DamagelessRate_otuz)
            Else
                kol7 = "<td>-</td>"
                saf7 = "-"
            End If

            If Not veri.Item("DamagelessRate_kirk") Is System.DBNull.Value Then
                DamagelessRate_kirk = veri.Item("DamagelessRate_kirk")
                toplam_DamagelessRate_kirk = toplam_DamagelessRate_kirk + DamagelessRate_kirk
                kol8 = "<td>" + CStr(DamagelessRate_kirk) + "</td>"
                saf8 = CStr(DamagelessRate_kirk)
            Else
                kol8 = "<td>-</td>"
                saf8 = "-"
            End If

            If Not veri.Item("DamageRate_sifir") Is System.DBNull.Value Then
                DamageRate_sifir = veri.Item("DamageRate_sifir")
                toplam_DamageRate_sifir = toplam_DamageRate_sifir + DamageRate_sifir
                kol9 = "<td>" + CStr(DamageRate_sifir) + "</td>"
                saf9 = CStr(DamageRate_sifir)
            Else
                kol9 = "<td>-</td>"
                saf9 = "-"
            End If

            If Not veri.Item("DamageRate_onbes") Is System.DBNull.Value Then
                DamageRate_onbes = veri.Item("DamageRate_onbes")
                toplam_DamageRate_onbes = toplam_DamageRate_onbes + DamageRate_onbes
                kol10 = "<td>" + CStr(DamageRate_onbes) + "</td>"
                saf10 = CStr(DamageRate_onbes)
            Else
                kol10 = "<td>-</td>"
                saf10 = "-"
            End If


            If Not veri.Item("DamageRate_yirmi") Is System.DBNull.Value Then
                DamageRate_yirmi = veri.Item("DamageRate_yirmi")
                toplam_DamageRate_yirmi = toplam_DamageRate_yirmi + DamageRate_yirmi
                kol11 = "<td>" + CStr(DamageRate_yirmi) + "</td>"
                saf11 = CStr(DamageRate_yirmi)
            Else
                kol11 = "<td>-</td>"
                saf11 = "-"
            End If

            If Not veri.Item("DamageRate_yirmibes") Is System.DBNull.Value Then
                DamageRate_yirmibes = veri.Item("DamageRate_yirmibes")
                DamageRate_yirmibes_carpim = DamageRate_yirmibes * DamageRate_yirmibes_oran
                toplam_DamageRate_yirmibes = toplam_DamageRate_yirmibes + DamageRate_yirmibes
                kol12 = "<td>" + CStr(DamageRate_yirmibes) + "</td>"
                saf12 = CStr(DamageRate_yirmibes)
            Else
                kol12 = "<td>-</td>"
                saf12 = "-"
            End If

            If Not veri.Item("DamageRate_otuz") Is System.DBNull.Value Then
                DamageRate_otuz = veri.Item("DamageRate_otuz")
                toplam_DamageRate_otuz = toplam_DamageRate_otuz + CStr(DamageRate_otuz)
                kol13 = "<td>" + CStr(DamageRate_otuz) + "</td>"
                saf13 = DamageRate_otuz
            Else
                kol13 = "<td>-</td>"
                saf13 = "-"
            End If

            If Not veri.Item("DamageRate_otuzbes") Is System.DBNull.Value Then
                DamageRate_otuzbes = veri.Item("DamageRate_otuzbes")
                toplam_DamageRate_otuzbes = toplam_DamageRate_otuzbes + CStr(DamageRate_otuzbes)
                kol14 = "<td>" + CStr(DamageRate_otuzbes) + "</td>"
                saf14 = DamageRate_otuzbes
            Else
                kol14 = "<td>-</td>"
                saf14 = "-"
            End If

            If Not veri.Item("DamageRate_kirk") Is System.DBNull.Value Then
                DamageRate_kirk = veri.Item("DamageRate_kirk")
                toplam_DamageRate_kirk = toplam_DamageRate_kirk + CStr(DamageRate_kirk)
                kol15 = "<td>" + CStr(DamageRate_kirk) + "</td>"
                saf15 = DamageRate_kirk
            Else
                kol15 = "<td>-</td>"
                saf15 = "-"
            End If

            If Not veri.Item("DamageRate_elli") Is System.DBNull.Value Then
                DamageRate_elli = veri.Item("DamageRate_elli")
                toplam_DamageRate_elli = toplam_DamageRate_elli + CStr(DamageRate_elli)
                kol16 = "<td>" + CStr(DamageRate_elli) + "</td>"
                saf16 = DamageRate_elli
            Else
                kol16 = "<td>-</td>"
                saf16 = "-"
            End If

            If Not veri.Item("AgeRate_sifir") Is System.DBNull.Value Then
                AgeRate_sifir = veri.Item("AgeRate_sifir")
                toplam_AgeRate_sifir = toplam_AgeRate_sifir + CStr(AgeRate_sifir)
                kol17 = "<td>" + CStr(AgeRate_sifir) + "</td>"
                saf17 = AgeRate_sifir
            Else
                kol17 = "<td>-</td>"
                saf17 = "-"
            End If

            If Not veri.Item("AgeRate_onbes") Is System.DBNull.Value Then
                AgeRate_onbes = veri.Item("AgeRate_onbes")
                toplam_AgeRate_onbes = toplam_AgeRate_onbes + CStr(AgeRate_onbes)
                kol18 = "<td>" + CStr(AgeRate_onbes) + "</td>"
                saf18 = AgeRate_onbes
            Else
                kol18 = "<td>-</td>"
                saf18 = "-"
            End If

            If Not veri.Item("AgeRate_otuz") Is System.DBNull.Value Then
                AgeRate_otuz = veri.Item("AgeRate_otuz")
                toplam_AgeRate_otuz = toplam_AgeRate_otuz + CStr(AgeRate_otuz)
                kol19 = "<td>" + CStr(AgeRate_otuz) + "</td>"
                saf19 = AgeRate_otuz
            Else
                kol19 = "<td>-</td>"
                saf19 = "-"
            End If

            If Not veri.Item("CCRate_sifir") Is System.DBNull.Value Then
                CCRate_sifir = veri.Item("CCRate_sifir")
                toplam_CCRate_sifir = toplam_CCRate_sifir + CStr(CCRate_sifir)
                kol20 = "<td>" + CStr(CCRate_sifir) + "</td>"
                saf20 = CCRate_sifir
            Else
                kol20 = "<td>-</td>"
                saf20 = "-"
            End If

            If Not veri.Item("CCRate_bes") Is System.DBNull.Value Then
                CCRate_bes = veri.Item("CCRate_bes")
                toplam_CCRate_bes = toplam_CCRate_bes + CStr(CCRate_bes)
                kol21 = "<td>" + CStr(CCRate_bes) + "</td>"
                saf21 = CCRate_bes
            Else
                kol21 = "<td>-</td>"
                saf21 = "-"
            End If

            If Not veri.Item("CCRate_onbes") Is System.DBNull.Value Then
                CCRate_onbes = veri.Item("CCRate_onbes")
                toplam_CCRate_onbes = toplam_CCRate_onbes + CStr(CCRate_onbes)
                kol22 = "<td>" + CStr(CCRate_onbes) + "</td>"
                saf22 = CCRate_onbes
            Else
                kol22 = "<td>-</td>"
                saf22 = "-"
            End If

            If Not veri.Item("CCRate_yirmi") Is System.DBNull.Value Then
                CCRate_yirmi = veri.Item("CCRate_yirmi")
                toplam_CCRate_yirmi = toplam_CCRate_yirmi + CStr(CCRate_yirmi)
                kol23 = "<td>" + CStr(CCRate_yirmi) + "</td>"
                saf23 = CCRate_yirmi
            Else
                kol23 = "<td>-</td>"
                saf23 = "-"
            End If

            If Not veri.Item("CCRate_yirmibes") Is System.DBNull.Value Then
                CCRate_yirmibes = veri.Item("CCRate_yirmibes")
                toplam_CCRate_yirmibes = toplam_CCRate_yirmibes + CStr(CCRate_yirmibes)
                kol24 = "<td>" + CStr(CCRate_yirmibes) + "</td>"
                saf24 = CCRate_yirmibes
            Else
                kol24 = "<td>-</td>"
                saf24 = "-"
            End If

            If Not veri.Item("CCRate_otuz") Is System.DBNull.Value Then
                CCRate_otuz = veri.Item("CCRate_otuz")
                toplam_CCRate_otuz = toplam_CCRate_otuz + CStr(CCRate_otuz)
                kol25 = "<td>" + CStr(CCRate_otuz) + "</td>"
                saf25 = CCRate_otuz
            Else
                kol25 = "<td>-</td>"
                saf25 = "-"
            End If

            If Not veri.Item("CCRate_otuzbes") Is System.DBNull.Value Then
                CCRate_otuzbes = veri.Item("CCRate_otuzbes")
                toplam_CCRate_otuzbes = toplam_CCRate_otuzbes + CStr(CCRate_otuzbes)
                kol26 = "<td>" + CStr(CCRate_otuzbes) + "</td>"
                saf26 = CCRate_otuzbes
            Else
                kol26 = "<td>-</td>"
                saf26 = "-"
            End If

            If Not veri.Item("CCRate_kirkbes") Is System.DBNull.Value Then
                CCRate_kirkbes = veri.Item("CCRate_kirkbes")
                toplam_CCRate_kirkbes = toplam_CCRate_kirkbes + CStr(CCRate_kirkbes)
                kol27 = "<td>" + CStr(CCRate_kirkbes) + "</td>"
                saf27 = CCRate_kirkbes
            Else
                kol27 = "<td>-</td>"
                saf27 = "-"
            End If

            If Not veri.Item("CCRate_elli") Is System.DBNull.Value Then
                CCRate_elli = veri.Item("CCRate_elli")
                toplam_CCRate_elli = toplam_CCRate_elli + CStr(CCRate_elli)
                kol28 = "<td>" + CStr(CCRate_elli) + "</td>"
                saf28 = CCRate_elli
            Else
                kol28 = "<td>-</td>"
                saf28 = "-"
            End If

            If Not veri.Item("CCRate_yetmisbes") Is System.DBNull.Value Then
                CCRate_yetmisbes = veri.Item("CCRate_yetmisbes")
                toplam_CCRate_yetmisbes = toplam_CCRate_yetmisbes + CStr(CCRate_yetmisbes)
                kol29 = "<td>" + CStr(CCRate_yetmisbes) + "</td></tr>"
                saf29 = CCRate_yetmisbes
            Else
                kol29 = "<td>-</td></tr>"
                saf29 = "-"
            End If

            If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                toplam_PolicyPremiumTL = toplam_PolicyPremiumTL + PolicyPremiumTL
            End If





            'DamagalessRateValue ve DamageRateValue'lar

            If Not veri.Item("DamagelessRateValue_sifir") Is System.DBNull.Value Then
                DamagelessRateValue_sifir = veri.Item("DamagelessRateValue_sifir")
                DamagelessRateValue_sifir = 0
            End If
            If Not veri.Item("DamagelessRateValue_on") Is System.DBNull.Value Then
                DamagelessRateValue_on = veri.Item("DamagelessRateValue_on")
            End If
            If Not veri.Item("DamagelessRateValue_yirmi") Is System.DBNull.Value Then
                DamagelessRateValue_yirmi = veri.Item("DamagelessRateValue_yirmi")
            End If
            If Not veri.Item("DamagelessRateValue_otuz") Is System.DBNull.Value Then
                DamagelessRateValue_otuz = veri.Item("DamagelessRateValue_otuz")
            End If
            If Not veri.Item("DamagelessRateValue_kirk") Is System.DBNull.Value Then
                DamagelessRateValue_kirk = veri.Item("DamagelessRateValue_kirk")
            End If


            If Not veri.Item("DamageRateValue_sifir") Is System.DBNull.Value Then
                DamageRateValue_sifir = veri.Item("DamageRateValue_sifir")
                DamageRateValue_sifir = 0
            End If
            If Not veri.Item("DamageRateValue_onbes") Is System.DBNull.Value Then
                DamageRateValue_onbes = veri.Item("DamageRateValue_onbes")
            End If
            If Not veri.Item("DamageRateValue_yirmi") Is System.DBNull.Value Then
                DamageRateValue_yirmi = veri.Item("DamageRateValue_yirmi")
            End If
            If Not veri.Item("DamageRateValue_yirmibes") Is System.DBNull.Value Then
                DamageRateValue_yirmibes = veri.Item("DamageRateValue_yirmibes")
            End If
            If Not veri.Item("DamageRateValue_otuz") Is System.DBNull.Value Then
                DamageRateValue_otuz = veri.Item("DamageRateValue_otuz")
            End If
            If Not veri.Item("DamageRateValue_otuzbes") Is System.DBNull.Value Then
                DamageRateValue_otuzbes = veri.Item("DamageRateValue_otuzbes")
            End If
            If Not veri.Item("DamageRateValue_kirk") Is System.DBNull.Value Then
                DamageRateValue_kirk = veri.Item("DamageRateValue_kirk")
            End If
            If Not veri.Item("DamageRateValue_elli") Is System.DBNull.Value Then
                DamageRateValue_elli = veri.Item("DamageRateValue_elli")
            End If

            'AgeRateValue ve CCRateValue 
            If Not veri.Item("AgeRateValue_sifir") Is System.DBNull.Value Then
                AgeRateValue_sifir = veri.Item("AgeRateValue_sifir")
                AgeRateValue_sifir = 0
            End If
            If Not veri.Item("AgeRateValue_onbes") Is System.DBNull.Value Then
                AgeRateValue_onbes = veri.Item("AgeRateValue_onbes")
            End If
            If Not veri.Item("AgeRateValue_otuz") Is System.DBNull.Value Then
                AgeRateValue_otuz = veri.Item("AgeRateValue_otuz")
            End If

            If Not veri.Item("CCRateValue_sifir") Is System.DBNull.Value Then
                CCRateValue_sifir = veri.Item("CCRateValue_sifir")
                CCRateValue_sifir = 0
            End If
            If Not veri.Item("CCRateValue_bes") Is System.DBNull.Value Then
                CCRateValue_bes = veri.Item("CCRateValue_bes")
            End If
            If Not veri.Item("CCRateValue_onbes") Is System.DBNull.Value Then
                CCRateValue_onbes = veri.Item("CCRateValue_onbes")
            End If
            If Not veri.Item("CCRateValue_yirmi") Is System.DBNull.Value Then
                CCRateValue_yirmi = veri.Item("CCRateValue_yirmi")
            End If
            If Not veri.Item("CCRateValue_yirmibes") Is System.DBNull.Value Then
                CCRateValue_yirmibes = veri.Item("CCRateValue_yirmibes")
            End If
            If Not veri.Item("CCRateValue_otuz") Is System.DBNull.Value Then
                CCRateValue_otuz = veri.Item("CCRateValue_otuz")
            End If
            If Not veri.Item("CCRateValue_otuzbes") Is System.DBNull.Value Then
                CCRateValue_otuzbes = veri.Item("CCRateValue_otuzbes")
            End If
            If Not veri.Item("CCRateValue_kirkbes") Is System.DBNull.Value Then
                CCRateValue_kirkbes = veri.Item("CCRateValue_kirkbes")
            End If
            If Not veri.Item("CCRateValue_elli") Is System.DBNull.Value Then
                CCRateValue_elli = veri.Item("CCRateValue_elli")
            End If
            If Not veri.Item("CCRateValue_yetmisbes") Is System.DBNull.Value Then
                CCRateValue_yetmisbes = veri.Item("CCRateValue_yetmisbes")
            End If

            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + _
            kol11 + kol12 + kol13 + kol14 + kol15 + kol16 + kol17 + kol18 + kol19 + kol20 + _
            kol21 + kol22 + kol23 + kol24 + kol25 + kol26 + kol27 + kol28 + kol29


            table.Rows.Add(saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10, _
            saf11, saf12, saf13, saf14, saf15, saf16, saf17, saf18, saf19, saf20, _
            saf21, saf22, saf23, saf24, saf25, saf26, saf27, saf28, saf29)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf3, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
            pdftable.AddCell(New Phrase(saf6, fdata))
            pdftable.AddCell(New Phrase(saf7, fdata))
            pdftable.AddCell(New Phrase(saf8, fdata))
            pdftable.AddCell(New Phrase(saf9, fdata))
            pdftable.AddCell(New Phrase(saf10, fdata))
            pdftable.AddCell(New Phrase(saf11, fdata))
            pdftable.AddCell(New Phrase(saf12, fdata))
            pdftable.AddCell(New Phrase(saf13, fdata))
            pdftable.AddCell(New Phrase(saf14, fdata))
            pdftable.AddCell(New Phrase(saf15, fdata))
            pdftable.AddCell(New Phrase(saf16, fdata))
            pdftable.AddCell(New Phrase(saf17, fdata))
            pdftable.AddCell(New Phrase(saf18, fdata))
            pdftable.AddCell(New Phrase(saf19, fdata))
            pdftable.AddCell(New Phrase(saf20, fdata))
            pdftable.AddCell(New Phrase(saf21, fdata))
            pdftable.AddCell(New Phrase(saf22, fdata))
            pdftable.AddCell(New Phrase(saf23, fdata))
            pdftable.AddCell(New Phrase(saf24, fdata))
            pdftable.AddCell(New Phrase(saf25, fdata))
            pdftable.AddCell(New Phrase(saf26, fdata))
            pdftable.AddCell(New Phrase(saf27, fdata))
            pdftable.AddCell(New Phrase(saf28, fdata))
            pdftable.AddCell(New Phrase(saf29, fdata))

        End While

        DamageveDamagelessRate_carpim = 0
        DamagelessRate_sifir_carpim = toplam_DamagelessRate_sifir * DamagelessRate_sifir_oran
        DamagelessRate_on_carpim = toplam_DamagelessRate_on * DamagelessRate_on_oran
        DamagelessRate_yirmi_carpim = toplam_DamagelessRate_yirmi * DamagelessRate_yirmi_oran
        DamagelessRate_otuz_carpim = toplam_DamagelessRate_otuz * DamagelessRate_otuz_oran
        DamagelessRate_kirk_carpim = toplam_DamagelessRate_kirk * DamagelessRate_kirk_oran
        DamageRate_sifir_carpim = toplam_DamageRate_sifir * DamageRate_sifir_oran
        DamageRate_onbes_carpim = toplam_DamageRate_onbes * DamageRate_onbes_oran
        DamageRate_yirmi_carpim = toplam_DamageRate_yirmi * DamageRate_yirmi_oran
        DamageRate_otuz_carpim = toplam_DamageRate_otuz * DamageRate_otuz_oran
        DamageRate_otuzbes_carpim = toplam_DamageRate_otuzbes * DamageRate_otuzbes_oran
        DamageRate_kirk_carpim = toplam_DamageRate_kirk * DamageRate_kirk_oran
        DamageRate_elli_carpim = toplam_DamageRate_elli * DamageRate_elli_oran
        AgeRate_sifir_carpim = toplam_AgeRate_sifir * AgeRate_sifir_oran
        AgeRate_onbes_carpim = toplam_AgeRate_onbes * AgeRate_onbes_oran
        AgeRate_otuz_carpim = toplam_AgeRate_otuz * AgeRate_otuz_oran
        CCRate_sifir_carpim = toplam_CCRate_sifir * CCRate_sifir_oran
        CCRate_bes_carpim = toplam_CCRate_bes * CCRate_bes_oran
        CCRate_onbes_carpim = toplam_CCRate_onbes * CCRate_onbes_oran
        CCRate_yirmi_carpim = toplam_CCRate_yirmi * CCRate_yirmi_oran
        CCRate_yirmibes_carpim = toplam_CCRate_yirmibes * CCRate_yirmibes_oran
        CCRate_otuz_carpim = toplam_CCRate_otuz * CCRate_otuz_oran
        CCRate_otuzbes_carpim = toplam_CCRate_otuzbes * CCRate_otuzbes_oran
        CCRate_kirkbes_carpim = toplam_CCRate_kirkbes * CCRate_kirkbes_oran
        CCRate_elli_carpim = toplam_CCRate_elli * CCRate_elli_oran
        CCRate_yetmisbes_carpim = toplam_CCRate_yetmisbes * CCRate_yetmisbes_oran

        toplamhi = DamagelessRate_on + _
        DamagelessRate_yirmi + _
        DamagelessRate_otuz + _
        DamagelessRate_kirk

        toplamhz = DamageRate_onbes + _
        DamageRate_yirmi + _
        DamageRate_yirmibes + _
        DamageRate_otuz + _
        DamageRate_otuzbes + _
        DamageRate_kirk + _
        DamageRate_elli

        toplamyz = AgeRate_onbes + _
        AgeRate_otuz

        toplamcc = CCRate_bes + _
        CCRate_onbes + _
        CCRate_yirmi + _
        CCRate_yirmibes + _
        CCRate_otuz + _
        CCRate_otuzbes + _
        CCRate_kirkbes + _
        CCRate_elli + _
        CCRate_yetmisbes

        toplampolice = DamagelessRate_sifir + _
        DamagelessRate_on + _
        DamagelessRate_yirmi + _
        DamagelessRate_otuz + _
        DamagelessRate_kirk + _
        DamageRate_sifir + _
        DamageRate_onbes + _
        DamageRate_yirmi + _
        DamageRate_yirmibes + _
        DamageRate_otuz + _
        DamageRate_otuzbes + _
        DamageRate_kirk + _
        DamageRate_elli

        toplamindirim = DamagelessRate_on_carpim + _
        DamagelessRate_yirmi_carpim + _
        DamagelessRate_otuz_carpim + _
        DamagelessRate_kirk_carpim + _
        DamageRate_sifir_carpim

        '----------zamları hesapla--------------------
        toplamzam_damage = DamageRate_onbes_carpim + _
        DamageRate_yirmi_carpim + _
        DamageRate_yirmibes_carpim + _
        DamageRate_otuz_carpim + _
        DamageRate_otuzbes_carpim + _
        DamageRate_kirk_carpim + _
        DamageRate_elli_carpim

        toplamzam_age = AgeRate_sifir_carpim + _
        AgeRate_onbes_carpim + _
        AgeRate_otuz_carpim

        toplamzam_cc = CCRate_sifir_carpim + _
        CCRate_bes_carpim + _
        CCRate_onbes_carpim + _
        CCRate_yirmi_carpim + _
        CCRate_yirmibes_carpim + _
        CCRate_otuz_carpim + _
        CCRate_otuzbes_carpim + _
        CCRate_kirkbes_carpim + _
        CCRate_elli_carpim + _
        CCRate_yetmisbes_carpim
        '----------------------------------------

        toplam_DamagelessRateValue = DamagelessRateValue_sifir + DamagelessRateValue_on + DamagelessRateValue_yirmi + _
        DamagelessRateValue_otuz + DamagelessRateValue_kirk

        toplam_DamageRateValue = DamageRateValue_sifir + DamageRateValue_onbes + DamageRateValue_yirmi + _
        DamageRateValue_yirmibes + DamageRateValue_otuz + DamageRateValue_otuzbes + DamageRateValue_kirk + _
        DamageRateValue_elli

        toplam_AgeRateValue = AgeRateValue_sifir + AgeRateValue_onbes + AgeRateValue_otuz

        toplam_CCRateValue = CCRateValue_sifir + CCRateValue_bes + CCRateValue_onbes + _
        CCRateValue_yirmi + CCRateValue_yirmibes + CCRateValue_otuz + _
        CCRateValue_otuzbes + CCRateValue_kirkbes + CCRateValue_elli + _
        CCRateValue_yetmisbes


        'EN ALT TOPLAM SATIRI
        'HTML İÇİN EKLE
        toplamsatir = "<tr>" + _
        "<td>TOPLAM</td>" + _
        "<td>-</td>" + _
        "<td>" + CStr(toplam_DamageveDamagelessRate_sifir) + "</td>" + _
        "<td>" + CStr(toplam_DamagelessRate_sifir) + "</td>" + _
        "<td>" + CStr(toplam_DamagelessRate_on) + "</td>" + _
        "<td>" + CStr(toplam_DamagelessRate_yirmi) + "</td>" + _
        "<td>" + CStr(toplam_DamagelessRate_otuz) + "</td>" + _
        "<td>" + CStr(toplam_DamagelessRate_kirk) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_sifir) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_onbes) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_yirmi) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_yirmibes) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_otuz) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_otuzbes) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_kirk) + "</td>" + _
        "<td>" + CStr(toplam_DamageRate_elli) + "</td>" + _
        "<td>" + CStr(toplam_AgeRate_sifir) + "</td>" + _
        "<td>" + CStr(toplam_AgeRate_onbes) + "</td>" + _
        "<td>" + CStr(toplam_AgeRate_otuz) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_sifir) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_bes) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_onbes) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_yirmi) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_yirmibes) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_otuz) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_otuzbes) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_kirkbes) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_elli) + "</td>" + _
        "<td>" + CStr(toplam_CCRate_yetmisbes) + "</td>" + _
        "</tr>"


        degersatir = "<tr>" + _
        "<td>DEĞER (DamageRateValue/DamagelessRateValue)</td>" + _
        "<td>-</td>" + _
        "<td>" + DamageveDamagelessRateValue_sifir.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRateValue_sifir.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRateValue_on.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRateValue_yirmi.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRateValue_otuz.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRateValue_kirk.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_sifir.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_onbes.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_yirmi.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_yirmibes.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_otuz.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_otuzbes.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_kirk.ToString("N0") + "</td>" + _
        "<td>" + DamageRateValue_elli.ToString("N0") + "</td>" + _
        "<td>" + AgeRateValue_sifir.ToString("N0") + "</td>" + _
        "<td>" + AgeRateValue_onbes.ToString("N0") + "</td>" + _
        "<td>" + AgeRateValue_otuz.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_sifir.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_bes.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_onbes.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_yirmi.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_yirmibes.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_otuz.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_otuzbes.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_kirkbes.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_elli.ToString("N0") + "</td>" + _
        "<td>" + CCRateValue_yetmisbes.ToString("N0") + "</td>" + _
        "</tr>"


        oransatir = "<tr>" + _
        "<td>ORAN</td>" + _
        "<td>-</td>" + _
        "<td>" + DamagelessRate_sifir_oran.ToString("N0") + "</td>" + _
        "<td>" + Format(DamagelessRate_sifir_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamagelessRate_on_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamagelessRate_yirmi_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamagelessRate_otuz_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamagelessRate_kirk_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_sifir_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_onbes_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_yirmi_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_yirmibes_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_otuz_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_otuzbes_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_kirk_oran, "0.00") + "</td>" + _
        "<td>" + Format(DamageRate_elli_oran, "0.00") + "</td>" + _
        "<td>" + Format(AgeRate_sifir_oran, "0.00") + "</td>" + _
        "<td>" + Format(AgeRate_onbes_oran, "0.00") + "</td>" + _
        "<td>" + Format(AgeRate_otuz_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_sifir_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_bes_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_onbes_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_yirmi_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_yirmibes_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_otuz_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_otuzbes_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_kirkbes_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_elli_oran, "0.00") + "</td>" + _
        "<td>" + Format(CCRate_yetmisbes_oran, "0.00") + "</td>" + _
        "</tr>"

        carpimsatir = "<tr>" + _
        "<td>ÇARPIM</td>" + _
        "<td>-</td>" + _
        "<td>" + DamageveDamagelessRate_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRate_sifir_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRate_on_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRate_yirmi_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRate_otuz_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamagelessRate_kirk_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_sifir_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_onbes_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_yirmi_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_yirmibes_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_otuz_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_otuzbes_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_kirk_carpim.ToString("N0") + "</td>" + _
        "<td>" + DamageRate_elli_carpim.ToString("N0") + "</td>" + _
        "<td>" + AgeRate_sifir_carpim.ToString("N0") + "</td>" + _
        "<td>" + AgeRate_onbes_carpim.ToString("N0") + "</td>" + _
        "<td>" + AgeRate_otuz_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_sifir_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_bes_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_onbes_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_yirmi_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_yirmibes_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_otuz_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_otuzbes_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_kirkbes_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_elli_carpim.ToString("N0") + "</td>" + _
        "<td>" + CCRate_yetmisbes_carpim.ToString("N0") + "</td>" + _
        "</tr>"


        Dim satir1, satir2, satir3, satir4, satir5, satir6, satir7, satir8, satir9, satir10 As String
        Dim satir11, satir12, satir13, satir14, satir15 As String
        Dim satirdevamhtml As String
        For i = 1 To 27
            satirdevamhtml = satirdevamhtml + "<td>-</td>"
        Next
        satirdevamhtml = satirdevamhtml + "</tr>"

        'toplam satirlari html e ekle
        satir1 = "<tr>" + _
        "<td>Toplam Hasar Zammı Uygulanan Poliçe Adeti</td>" + _
        "<td>" + CStr(toplamhz) + "</td>" + _
        satirdevamhtml

        satir2 = "<tr>" + _
        "<td>Toplam Hasarsızlık İndirimi Uygulanan Poliçe Adeti</td>" + _
        "<td>" + CStr(toplamhi) + "</td>" + _
        satirdevamhtml

        satir3 = "<tr>" + _
        "<td>Toplam Yaş Zammı Uygulanan Poliçe Adeti</td>" + _
        "<td>" + CStr(toplamyz) + "</td>" + _
        satirdevamhtml

        satir4 = "<tr>" + _
        "<td>Toplam CC Zammı Uygulanan Poliçe Adeti</td>" + _
        "<td>" + CStr(toplamcc) + "</td>" + _
        satirdevamhtml

        satir5 = "<tr>" + _
        "<td>Toplam Poliçe Adeti</td>" + _
        "<td>" + CStr(toplam_policesayigercek) + "</td>" + _
        satirdevamhtml

        satir6 = "<tr>" + _
        "<td>Toplam İndirim Tutarı</td>" + _
        "<td>" + toplamindirim.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir7 = "<tr>" + _
        "<td>Toplam Hasar Zammı Tutarı</td>" + _
        "<td>" + toplamzam_damage.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir8 = "<tr>" + _
        "<td>Toplam Yaş Zammı Tutarı</td>" + _
        "<td>" + toplamzam_age.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir9 = "<tr>" + _
        "<td>Toplam CC Zammı Tutarı</td>" + _
        "<td>" + toplamzam_cc.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir10 = "<tr>" + _
        "<td>Toplam DamagelessRateValue</td>" + _
        "<td>" + toplam_DamagelessRateValue.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir11 = "<tr>" + _
        "<td>Toplam DamageRateValue</td>" + _
        "<td>" + toplam_DamageRateValue.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir12 = "<tr>" + _
        "<td>Toplam AgeRateValue</td>" + _
        "<td>" + toplam_AgeRateValue.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir13 = "<tr>" + _
        "<td>Toplam CCRateValue</td>" + _
        "<td>" + toplam_CCRateValue.ToString("N0") + "</td>" + _
        satirdevamhtml

        satir14 = "<tr>" + _
        "<td>Toplam Poliçe Primi</td>" + _
        "<td>" + toplam_PolicyPremiumTL.ToString("N0") + "</td>" + _
        satirdevamhtml


        satir = satir + toplamsatir + degersatir + oransatir + carpimsatir + satir1 + _
        satir2 + satir3 + satir4 + satir5 + satir6 + satir7 + satir8 + satir9 + satir10 + _
        satir11 + satir12 + satir13 + satir14

        'WORD EXCEL KISMINI OLUŞTUR
        'toplam
        Dim R As DataRow = table.NewRow
        R(0) = "Toplam"
        R(1) = "-"
        R(2) = CStr(toplam_DamageveDamagelessRate_sifir)
        R(3) = CStr(toplam_DamagelessRate_sifir)
        R(4) = CStr(toplam_DamagelessRate_on)
        R(5) = CStr(toplam_DamagelessRate_yirmi)
        R(6) = CStr(toplam_DamagelessRate_otuz)
        R(7) = CStr(toplam_DamagelessRate_kirk)
        R(8) = CStr(toplam_DamageRate_sifir)
        R(9) = CStr(toplam_DamageRate_onbes)
        R(10) = CStr(toplam_DamageRate_yirmi)
        R(11) = CStr(toplam_DamageRate_yirmibes)
        R(12) = CStr(toplam_DamageRate_otuz)
        R(13) = CStr(toplam_DamageRate_otuzbes)
        R(14) = CStr(toplam_DamageRate_kirk)
        R(15) = CStr(toplam_DamageRate_elli)
        R(16) = CStr(toplam_AgeRate_sifir)
        R(17) = CStr(toplam_AgeRate_onbes)
        R(18) = CStr(toplam_AgeRate_otuz)
        R(19) = CStr(toplam_CCRate_sifir)
        R(20) = CStr(toplam_CCRate_bes)
        R(21) = CStr(toplam_CCRate_onbes)
        R(22) = CStr(toplam_CCRate_yirmi)
        R(23) = CStr(toplam_CCRate_yirmibes)
        R(24) = CStr(toplam_CCRate_otuz)
        R(25) = CStr(toplam_CCRate_otuzbes)
        R(26) = CStr(toplam_CCRate_kirkbes)
        R(27) = CStr(toplam_CCRate_elli)
        R(28) = CStr(toplam_CCRate_yetmisbes)
        table.Rows.Add(R)


        'deger
        Dim Rdeger As DataRow = table.NewRow
        Rdeger(0) = "DEĞER (DamageRateValue/DamagelessRateValue)"
        Rdeger(1) = "-"
        Rdeger(2) = DamageveDamagelessRateValue_sifir.ToString("N0")
        Rdeger(3) = DamagelessRateValue_sifir.ToString("N0")
        Rdeger(4) = DamagelessRateValue_on.ToString("N0")
        Rdeger(5) = DamagelessRateValue_yirmi.ToString("N0")
        Rdeger(6) = DamagelessRateValue_otuz.ToString("N0")
        Rdeger(7) = DamagelessRateValue_kirk.ToString("N0")
        Rdeger(8) = DamageRateValue_sifir.ToString("N0")
        Rdeger(9) = DamageRateValue_onbes.ToString("N0")
        Rdeger(10) = DamageRateValue_yirmi.ToString("N0")
        Rdeger(11) = DamageRateValue_yirmibes.ToString("N0")
        Rdeger(12) = DamageRateValue_otuz.ToString("N0")
        Rdeger(13) = DamageRateValue_otuzbes.ToString("N0")
        Rdeger(14) = DamageRateValue_kirk.ToString("N0")
        Rdeger(15) = DamageRateValue_elli.ToString("N0")
        Rdeger(16) = AgeRateValue_sifir.ToString("N0")
        Rdeger(17) = AgeRateValue_onbes.ToString("N0")
        Rdeger(18) = AgeRateValue_otuz.ToString("N0")
        Rdeger(19) = CCRateValue_sifir.ToString("N0")
        Rdeger(20) = CCRateValue_bes.ToString("N0")
        Rdeger(21) = CCRateValue_onbes.ToString("N0")
        Rdeger(22) = CCRateValue_yirmi.ToString("N0")
        Rdeger(23) = CCRateValue_yirmibes.ToString("N0")
        Rdeger(24) = CCRateValue_otuz.ToString("N0")
        Rdeger(25) = CCRateValue_otuzbes.ToString("N0")
        Rdeger(26) = CCRateValue_kirkbes.ToString("N0")
        Rdeger(27) = CCRateValue_elli.ToString("N0")
        Rdeger(28) = CCRateValue_yetmisbes.ToString("N0")
        table.Rows.Add(Rdeger)


        'oran
        Dim Roran As DataRow = table.NewRow
        Roran(0) = "Oran"
        Roran(1) = "-"
        Roran(2) = DamagelessRate_sifir_oran.ToString("N0")
        Roran(3) = Format(DamagelessRate_sifir_oran, "0.00")
        Roran(4) = Format(DamagelessRate_on_oran, "0.00")
        Roran(5) = Format(DamagelessRate_yirmi_oran, "0.00")
        Roran(6) = Format(DamagelessRate_otuz_oran, "0.00")
        Roran(7) = Format(DamagelessRate_kirk_oran, "0.00")
        Roran(8) = Format(DamageRate_sifir_oran, "0.00")
        Roran(9) = Format(DamageRate_onbes_oran, "0.00")
        Roran(10) = Format(DamageRate_yirmi_oran, "0.00")
        Roran(11) = Format(DamageRate_yirmibes_oran, "0.00")
        Roran(12) = Format(DamageRate_otuz_oran, "0.00")
        Roran(13) = Format(DamageRate_otuzbes_oran, "0.00")
        Roran(14) = Format(DamageRate_kirk_oran, "0.00")
        Roran(15) = Format(DamageRate_elli_oran, "0.00")
        Roran(16) = Format(AgeRate_sifir_oran, "0.00")
        Roran(17) = Format(AgeRate_onbes_oran, "0.00")
        Roran(18) = Format(AgeRate_otuz_oran, "0.00")
        Roran(19) = Format(CCRate_sifir_oran, "0.00")
        Roran(20) = Format(CCRate_bes_oran, "0.00")
        Roran(21) = Format(CCRate_onbes_oran, "0.00")
        Roran(22) = Format(CCRate_yirmi_oran, "0.00")
        Roran(23) = Format(CCRate_yirmibes_oran, "0.00")
        Roran(24) = Format(CCRate_otuz_oran, "0.00")
        Roran(25) = Format(CCRate_otuzbes_oran, "0.00")
        Roran(26) = Format(CCRate_kirkbes_oran, "0.00")
        Roran(27) = Format(CCRate_elli_oran, "0.00")
        Roran(28) = Format(CCRate_yetmisbes_oran, "0.00")
        table.Rows.Add(Roran)


        'carpim
        Dim Rcarpim As DataRow = table.NewRow
        Rcarpim(0) = "Çarpım"
        Rcarpim(1) = "-"
        Rcarpim(2) = DamageveDamagelessRate_carpim.ToString("N0")
        Rcarpim(3) = DamagelessRate_sifir_carpim.ToString("N0")
        Rcarpim(4) = DamagelessRate_on_carpim.ToString("N0")
        Rcarpim(5) = DamagelessRate_yirmi_carpim.ToString("N0")
        Rcarpim(6) = DamagelessRate_otuz_carpim.ToString("N0")
        Rcarpim(7) = DamagelessRate_kirk_carpim.ToString("N0")
        Rcarpim(8) = DamageRate_sifir_carpim.ToString("N0")
        Rcarpim(9) = DamageRate_onbes_carpim.ToString("N0")
        Rcarpim(10) = DamageRate_yirmi_carpim.ToString("N0")
        Rcarpim(11) = DamageRate_yirmibes_carpim.ToString("N0")
        Rcarpim(12) = DamageRate_otuz_carpim.ToString("N0")
        Rcarpim(13) = DamageRate_otuzbes_carpim.ToString("N0")
        Rcarpim(14) = DamageRate_kirk_carpim.ToString("N0")
        Rcarpim(15) = DamageRate_elli_carpim.ToString("N0")
        Rcarpim(16) = AgeRate_sifir_carpim.ToString("N0")
        Rcarpim(17) = AgeRate_onbes_carpim.ToString("N0")
        Rcarpim(18) = AgeRate_otuz_carpim.ToString("N0")
        Rcarpim(19) = CCRate_sifir_carpim.ToString("N0")
        Rcarpim(20) = CCRate_bes_carpim.ToString("N0")
        Rcarpim(21) = CCRate_onbes_carpim.ToString("N0")
        Rcarpim(22) = CCRate_yirmi_carpim.ToString("N0")
        Rcarpim(23) = CCRate_yirmibes_carpim.ToString("N0")
        Rcarpim(24) = CCRate_otuz_carpim.ToString("N0")
        Rcarpim(25) = CCRate_otuzbes_carpim.ToString("N0")
        Rcarpim(26) = CCRate_kirkbes_carpim.ToString("N0")
        Rcarpim(27) = CCRate_elli_carpim.ToString("N0")
        Rcarpim(28) = CCRate_yetmisbes_carpim.ToString("N0")
        table.Rows.Add(Rcarpim)

        'EXCEL E SONUÇ YAZILARINI EKLE
        Dim Rsatir1 As DataRow = table.NewRow
        Rsatir1(0) = "Toplam Hasar Zammı Uygulanan Poliçe Adeti"
        Rsatir1(1) = CStr(toplamhz)
        table.Rows.Add(Rsatir1)

        Dim Rsatir2 As DataRow = table.NewRow
        Rsatir2(0) = "Toplam Hasarsızlık İndirimi Uygulanan Poliçe Adeti"
        Rsatir2(1) = CStr(toplamhi)
        table.Rows.Add(Rsatir2)

        Dim Rsatir3 As DataRow = table.NewRow
        Rsatir3(0) = "Toplam Yaş Zammı Uygulanan Poliçe Adeti"
        Rsatir3(1) = CStr(toplamyz)
        table.Rows.Add(Rsatir3)

        Dim Rsatir4 As DataRow = table.NewRow
        Rsatir4(0) = "Toplam CC Zammı Uygulanan Poliçe Adeti"
        Rsatir4(1) = CStr(toplamcc)
        table.Rows.Add(Rsatir4)

        Dim Rsatir5 As DataRow = table.NewRow
        Rsatir5(0) = "Toplam Poliçe Adeti"
        Rsatir5(1) = CStr(toplam_policesayigercek)
        table.Rows.Add(Rsatir5)

        Dim Rsatir6 As DataRow = table.NewRow
        Rsatir6(0) = "Toplam İndirim Tutarı"
        Rsatir6(1) = toplamindirim.ToString("N0")
        table.Rows.Add(Rsatir6)

        Dim Rsatir7 As DataRow = table.NewRow
        Rsatir7(0) = "Toplam Hasar Zammı Tutarı"
        Rsatir7(1) = toplamzam_damage.ToString("N0")
        table.Rows.Add(Rsatir7)

        Dim Rsatir8 As DataRow = table.NewRow
        Rsatir8(0) = "Toplam Yaş Zammı Tutarı"
        Rsatir8(1) = toplamzam_age.ToString("N0")
        table.Rows.Add(Rsatir8)

        Dim Rsatir9 As DataRow = table.NewRow
        Rsatir9(0) = "Toplam CC Zammı Tutarı"
        Rsatir9(1) = toplamzam_cc.ToString("N0")
        table.Rows.Add(Rsatir9)

        Dim Rsatir10 As DataRow = table.NewRow
        Rsatir10(0) = "Toplam DamagelessRateValue"
        Rsatir10(1) = toplam_DamagelessRateValue.ToString("N0")
        table.Rows.Add(Rsatir10)

        Dim Rsatir11 As DataRow = table.NewRow
        Rsatir11(0) = "Toplam DamageRateValue"
        Rsatir11(1) = toplam_DamageRateValue.ToString("N0")
        table.Rows.Add(Rsatir11)

        Dim Rsatir12 As DataRow = table.NewRow
        Rsatir12(0) = "Toplam AgeRateValue"
        Rsatir12(1) = toplam_AgeRateValue.ToString("N0")
        table.Rows.Add(Rsatir12)

        Dim Rsatir13 As DataRow = table.NewRow
        Rsatir13(0) = "Toplam CCRateValue"
        Rsatir13(1) = toplam_CCRateValue.ToString("N0")
        table.Rows.Add(Rsatir13)

        Dim Rsatir14 As DataRow = table.NewRow
        Rsatir14(0) = "Toplam Poliçe Primi"
        Rsatir14(1) = toplam_PolicyPremiumTL.ToString("N0")
        table.Rows.Add(Rsatir14)


        'PDF İÇİN EKLE
        'toplam
        pdftable.AddCell(New Phrase("Toplam", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageveDamagelessRate_sifir), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamagelessRate_sifir), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamagelessRate_on), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamagelessRate_yirmi), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamagelessRate_otuz), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamagelessRate_kirk), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_sifir), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_onbes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_yirmi), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_yirmibes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_otuz), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_otuzbes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_kirk), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_DamageRate_elli), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_AgeRate_sifir), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_AgeRate_onbes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_AgeRate_otuz), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_sifir), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_bes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_onbes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_yirmi), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_yirmibes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_otuz), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_otuzbes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_kirkbes), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_elli), fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_CCRate_yetmisbes), fdata))



        'pdf değer ekle
        'değer
        pdftable.AddCell(New Phrase("DEĞER (DamageRateValue/DamagelessRateValue)", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(DamageveDamagelessRate_sifir.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRateValue_sifir.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRateValue_on.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRateValue_yirmi.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRateValue_otuz.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRateValue_kirk.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_sifir.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_onbes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_yirmi.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_yirmibes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_otuz.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_otuzbes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_kirk.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRateValue_elli.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(AgeRateValue_sifir.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(AgeRateValue_onbes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(AgeRateValue_otuz.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_sifir.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_bes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_onbes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_yirmi.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_yirmibes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_otuz.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_otuzbes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_kirkbes.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_elli.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRateValue_yetmisbes.ToString("N0"), fdata))


        'PDF oran ekle
        'oran
        pdftable.AddCell(New Phrase("Oran", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(DamagelessRate_sifir_oran.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(Format(DamagelessRate_sifir_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamagelessRate_on_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamagelessRate_yirmi_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamagelessRate_otuz_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamagelessRate_kirk_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_sifir_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_onbes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_yirmi_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_yirmibes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_otuz_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_otuzbes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_kirk_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(DamageRate_elli_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(AgeRate_sifir_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(AgeRate_onbes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(AgeRate_otuz_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_sifir_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_bes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_onbes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_yirmi_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_yirmibes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_otuz_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_otuzbes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_kirkbes_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_elli_oran, "0.00"), fdata))
        pdftable.AddCell(New Phrase(Format(CCRate_yetmisbes_oran, "0.00"), fdata))



        'carpim
        pdftable.AddCell(New Phrase("Çarpım", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(DamageveDamagelessRate_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRate_sifir_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRate_on_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRate_yirmi_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRate_otuz_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamagelessRate_kirk_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_sifir_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_onbes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_yirmi_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_yirmibes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_otuz_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_otuzbes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_kirk_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(DamageRate_elli_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(AgeRate_sifir_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(AgeRate_onbes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(AgeRate_otuz_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_sifir_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_bes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_onbes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_yirmi_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_yirmibes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_otuz_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_otuzbes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_kirkbes_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_elli_carpim.ToString("N0"), fdata))
        pdftable.AddCell(New Phrase(CCRate_yetmisbes_carpim.ToString("N0"), fdata))


        'PDF E SONUÇ YAZILARINI EKLE
        '1
        pdftable.AddCell(New Phrase("Toplam Hasar Zammı Uygulanan Poliçe Adeti", fdata))
        pdftable.AddCell(New Phrase(CStr(toplamhz), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '2
        pdftable.AddCell(New Phrase("Toplam Hasarsızlık İndirimi Uygulanan Poliçe Adeti", fdata))
        pdftable.AddCell(New Phrase(CStr(toplamhi), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '3
        pdftable.AddCell(New Phrase("Toplam Yaş Zammı Uygulanan Poliçe Adeti", fdata))
        pdftable.AddCell(New Phrase(CStr(toplamyz), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '4
        pdftable.AddCell(New Phrase("Toplam CC Zammı Uygulanan Poliçe Adeti", fdata))
        pdftable.AddCell(New Phrase(CStr(toplamcc), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '5
        pdftable.AddCell(New Phrase("Tarihler Arası Toplam Tekil Poliçe Adeti (Gerçek Sayı)", fdata))
        pdftable.AddCell(New Phrase(CStr(toplam_policesayigercek), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '6
        pdftable.AddCell(New Phrase("Toplam İndirim Tutarı", fdata))
        pdftable.AddCell(New Phrase(toplamindirim.ToString("N0"), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '7
        pdftable.AddCell(New Phrase("Toplam Zam Tutarı", fdata))
        pdftable.AddCell(New Phrase(toplamzam.ToString("N0"), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '8
        pdftable.AddCell(New Phrase("Toplam DamagelessRateValue", fdata))
        pdftable.AddCell(New Phrase(toplam_DamagelessRateValue.ToString("N0"), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '9
        pdftable.AddCell(New Phrase("Toplam DamageRateValue", fdata))
        pdftable.AddCell(New Phrase(toplam_DamageRateValue.ToString("N0"), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '10
        pdftable.AddCell(New Phrase("Toplam AgeRateValue", fdata))
        pdftable.AddCell(New Phrase(toplam_AgeRateValue.ToString("N0"), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '11
        pdftable.AddCell(New Phrase("Toplam CCRateValue", fdata))
        pdftable.AddCell(New Phrase(toplam_CCRateValue.ToString("N0"), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next

        '12
        pdftable.AddCell(New Phrase("Toplam Poliçe Primi", fdata))
        pdftable.AddCell(New Phrase(toplam_PolicyPremiumTL.ToString("N0"), fdata))
        For i = 1 To 27
            pdftable.AddCell(New Phrase("-", fdata))
        Next


        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + sonucyazi + jvstring
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



    Public Function veriyaratSEKTORSADECETL(ByVal db_baglanti As SqlConnection, _
    ByVal veri As SqlDataReader, ByVal komut As SqlCommand) As CLASSRAPOR


        Dim veritabaniad As String = System.Configuration.ConfigurationManager.AppSettings("veritabaniad")
        'Dim veritabaniad As String = "sigortay"
        Dim tabload As String = "DamageInfo"

        Dim baslangictarih, bitistarih As Date
        baslangictarih = HttpContext.Current.Session("baslangictarih")
        bitistarih = HttpContext.Current.Session("bitistarih")
        Dim hangihasar As String
        hangihasar = HttpContext.Current.Session("hangihasar")


        Dim ekrapor As New CLASSRAPOR

        Dim table As New DataTable
        Dim recordcount As Integer = 0

        Dim donecek As String
        Dim girdi As String = "0"
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8, kol9, kol10 As String
        Dim kol11, kol12, kol13, kol14, kol15, kol16, kol17, kol18, kol19, kol20 As String


        Dim saf1, saf2, saf3, saf4, saf5, saf6, saf7, saf8, saf9, saf10 As String
        Dim saf11, saf12, saf13, saf14, saf15, saf16, saf17, saf18, saf19, saf20 As String


        Dim jvstring, tabloson As String
        Dim sirano As Integer = 1
        Dim currencycode As String

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Tarife Kodu</th>" + _
        "<th>Ürün Kodu</th>" + _
        "<th>Poliçe Adeti</th>" + _
        "<th>Toplam Kasko Bedeli TL</th>" + _
        "<th>Muallak Adeti</th>" + _
        "<th>Muallak Maddi Adet</th>" + _
        "<th>Muallak Maddi Tutar TL</th>" + _
        "<th>Muallak Bedeni Adet</th>" + _
        "<th>Muallak Bedeni Tutar TL</th>" + _
        "<th>Muallak Tutar Genel Toplam TL</th>" + _
        "<th>Ödenen Adet</th>" + _
        "<th>Ödenen Maddi Adet</th>" + _
        "<th>Ödenen Maddi Tutar TL</th>" + _
        "<th>Ödenen Bedeni Adet</th>" + _
        "<th>Ödenen Bedeni Tutar TL</th>" + _
        "<th>Ödenen Tutar Genel Toplam TL</th>" + _
        "<th>Pert Adet</th>" + _
        "<th>Toplam Poliçe Primi TL</th>" + _
        "<th>Toplam Sigorta Primi TL</th>" + _
        "</tr>" + _
        "</thead>"


        'WORD EXCEL İÇİN---------------------------------------------------
        table.Columns.Add("Tarife Kodu", GetType(String))
        table.Columns.Add("Ürün Kodu", GetType(String))
        table.Columns.Add("Poliçe Adeti", GetType(String))
        table.Columns.Add("Toplam Kasko Bedeli TL", GetType(String))
        table.Columns.Add("Muallak Adeti", GetType(String))
        table.Columns.Add("Muallak Maddi Adet", GetType(String))
        table.Columns.Add("Muallak Maddi Tutar TL", GetType(String))
        table.Columns.Add("Muallak Bedeni Adet", GetType(String))
        table.Columns.Add("Muallak Bedeni Tutar TL", GetType(String))
        table.Columns.Add("Muallak Tutar Genel Toplam TL", GetType(String))
        table.Columns.Add("Ödenen Adet", GetType(String))
        table.Columns.Add("Ödenenen Maddi Adet", GetType(String))
        table.Columns.Add("Ödenenen Maddi Tutar TL", GetType(String))
        table.Columns.Add("Ödenen Bedeni Adet", GetType(String))
        table.Columns.Add("Ödenenen Bedeni Tutar TL", GetType(String))
        table.Columns.Add("Ödenen Tutar Genel Toplam TL", GetType(String))
        table.Columns.Add("Pert Adet", GetType(String))
        table.Columns.Add("Toplam Poliçe Primi TL", GetType(String))
        table.Columns.Add("Toplam Sigorta Primi TL", GetType(String))
        '------------------------------------------------------------------

        'PDF İÇİN ---------------------------------------------------------
        Dim pdftable As New PdfPTable(19)
        Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
        Dim fontsize As Single = 8.0
        Dim fbaslik = New Font(BF, fontsize, iTextSharp.text.Font.BOLD)
        Dim fdata = New Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
        pdftable.AddCell(New Phrase("Tarife Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Ürün Kodu", fbaslik))
        pdftable.AddCell(New Phrase("Poliçe Adeti", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Kasko Bedeli TL", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Adeti", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Maddi Adet", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Maddi Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Bedeni Adet", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Bedeni Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Muallak Tutar Genel Toplam TL", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Adet", fbaslik))
        pdftable.AddCell(New Phrase("Ödenenen Maddi Adet", fbaslik))
        pdftable.AddCell(New Phrase("Ödenenen Maddi Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Bedeni Adet", fbaslik))
        pdftable.AddCell(New Phrase("Ödenenen Bedeni Tutar TL", fbaslik))
        pdftable.AddCell(New Phrase("Ödenen Tutar Genel Toplam TL", fbaslik))
        pdftable.AddCell(New Phrase("Pert Adet", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Poliçe Primi TL", fbaslik))
        pdftable.AddCell(New Phrase("Toplam Sigorta Primi TL", fbaslik))


        tabloson = "</tbody></table>"

        Dim pp_pmiktar, pp_tmiktar, pp_vmiktar, pp_rmiktar, pp_xmiktar As Decimal
        Dim ip_pmiktar, ip_tmiktar, ip_vmiktar, ip_rmiktar, ip_xmiktar As Decimal
        Dim pp_pmiktarTL, pp_tmiktarTL, pp_vmiktarTL, pp_rmiktarTL, pp_xmiktarTL As Decimal
        Dim ip_pmiktarTL, ip_tmiktarTL, ip_vmiktarTL, ip_rmiktarTL, ip_xmiktarTL As Decimal
        Dim padet, tadet, vadet, radet, xadet As Integer

        Dim STG_policeadet, STG_muallakmiktar, STG_odenen, STG_odenenmiktar As Decimal
        Dim TL_policeadet, TL_muallakmiktar, TL_odenen, TL_odenenmiktar As Decimal
        Dim USD_policeadet, USD_muallakmiktar, USD_odenen, USD_odenenmiktar As Decimal
        Dim EUR_policeadet, EUR_muallakmiktar, EUR_odenen, EUR_odenenmiktar As Decimal

        STG_policeadet = 0
        STG_muallakmiktar = 0
        STG_odenen = 0
        STG_odenenmiktar = 0

        TL_policeadet = 0
        TL_muallakmiktar = 0
        TL_odenen = 0
        TL_odenenmiktar = 0

        USD_policeadet = 0
        USD_muallakmiktar = 0
        USD_odenen = 0
        USD_odenenmiktar = 0

        EUR_policeadet = 0
        EUR_muallakmiktar = 0
        EUR_odenen = 0
        EUR_odenenmiktar = 0
        '---------------------------------------------

        Dim tarihtip As String = HttpContext.Current.Session("tarihtip")
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim firmcode, tariffcode, productcode, policytype, adet As String
        Dim pp_prim, ip_prim, kasko As Decimal
        Dim calc_erisim As New CLASSCALC_ERISIM

        Dim muallakmiktar, odenenhasaradet, odenenhasarmiktar As Decimal
        Dim geneltoplammuallakhda, geneltoplammuallakmiktar, geneltoplamodenenhasaradet As Decimal
        Dim geneltoplamodenenhasarmiktar As Decimal
        Dim toplamsatir As String


        Dim iptaladet_STG, iptaladet_TL, iptaladet_USD, iptaladet_EUR As Decimal
        Dim iptaliadetoplamprim_STG, iptaliadetoplamprim_TL, iptaliadetoplamprim_USD, iptaliadetoplamprim_EUR As Decimal
        Dim pp_toplamprim_STG, pp_toplamprim_TL, pp_toplamprim_USD, pp_toplamprim_EUR As Decimal
        Dim ip_toplamprim_STG, ip_toplamprim_TL, ip_toplamprim_USD, ip_toplamprim_EUR As Decimal
        Dim toplamkasko_STG, toplamkasko_TL, toplamkasko_USD, toplamkasko_EUR As Decimal
        Dim muallakadet_STG, muallakadet_TL, muallakadet_USD, muallakadet_EUR As Decimal
        Dim muallakmaddiadet_STG, muallakmaddiadet_TL, muallakmaddiadet_USD, muallakmaddiadet_EUR As Decimal
        Dim muallakmaddimiktar_STG, muallakmaddimiktar_TL, muallakmaddimiktar_USD, muallakmaddimiktar_EUR As Decimal
        Dim muallakbedeniadet_STG, muallakbedeniadet_TL, muallakbedeniadet_USD, muallakbedeniadet_EUR As Decimal
        Dim muallakbedenimiktar_STG, muallakbedenimiktar_TL, muallakbedenimiktar_USD, muallakbedenimiktar_EUR As Decimal
        Dim muallakgenelmiktar_STG, muallakgenelmiktar_TL, muallakgenelmiktar_USD, muallakgenelmiktar_EUR As Decimal
        Dim odenenadet_STG, odenenadet_TL, odenenadet_USD, odenenadet_EUR As Decimal
        Dim odenenmaddiadet_STG, odenenmaddiadet_TL, odenenmaddiadet_USD, odenenmaddiadet_EUR As Decimal
        Dim odenenmaddimiktar_STG, odenenmaddimiktar_TL, odenenmaddimiktar_USD, odenenmaddimiktar_EUR As Decimal
        Dim odenenbedeniadet_STG, odenenbedeniadet_TL, odenenbedeniadet_USD, odenenbedeniadet_EUR As Decimal
        Dim odenenbedenimiktar_STG, odenenbedenimiktar_TL, odenenbedenimiktar_USD, odenenbedenimiktar_EUR As Decimal
        Dim odenengenelmiktar_STG, odenengenelmiktar_TL, odenengenelmiktar_USD, odenengenelmiktar_EUR As Decimal
        Dim pertadet_STG, pertadet_TL, pertadet_USD, pertadet_EUR As Decimal

        Dim pp_primTL, ip_primTL As Decimal
        Dim pp_primTL_STG, pp_primTL_TL, pp_primTL_USD, pp_primTL_EUR As Decimal
        Dim ip_primTL_STG, ip_primTL_TL, ip_primTL_USD, ip_primTL_EUR As Decimal
        Dim anatoplam_pp_primTL, anatoplam_ip_primTL As Decimal

        Dim anatoplam_policeadet, anatoplam_iptalpoliceadet, anatoplam_muallakadet, anatoplam_muallakmaddiadet As Integer
        Dim anatoplam_muallakbedeniadet, anatoplam_odenenadet As Integer
        Dim anatoplam_odenenmaddiadet, anatoplam_odenenbedeniadet As Integer
        Dim anatoplam_pertadet As Integer

        Dim odenenmaddimiktarTL_STG, odenenmaddimiktarTL_TL, odenenmaddimiktarTL_USD, odenenmaddimiktarTL_EUR As Decimal
        Dim odenenbedenimiktarTL_STG, odenenbedenimiktarTL_TL, odenenbedenimiktarTL_USD, odenenbedenimiktarTL_EUR As Decimal

        Dim muallakmaddimiktarTL_STG, muallakmaddimiktarTL_TL, muallakmaddimiktarTL_USD, muallakmaddimiktarTL_EUR As Decimal
        Dim muallakbedenimiktarTL_STG, muallakbedenimiktarTL_TL, muallakbedenimiktarTL_USD, muallakbedenimiktarTL_EUR As Decimal

        Dim muallakgenelmiktarTL_STG, muallakgenelmiktarTL_TL, muallakgenelmiktarTL_USD, muallakgenelmiktarTL_EUR As Decimal
        Dim odenengenelmiktarTL_STG, odenengenelmiktarTL_TL, odenengenelmiktarTL_USD, odenengenelmiktarTL_EUR As Decimal

        'ANA TOPLAMLARI SIFIRLA -----------
        anatoplam_policeadet = 0
        anatoplam_iptalpoliceadet = 0
        anatoplam_muallakadet = 0
        anatoplam_muallakmaddiadet = 0
        anatoplam_muallakbedeniadet = 0
        anatoplam_odenenadet = 0
        anatoplam_odenenmaddiadet = 0
        anatoplam_odenenbedeniadet = 0
        anatoplam_pertadet = 0
        anatoplam_pp_primTL = 0
        anatoplam_ip_primTL = 0
        '---------------------------------

        pp_toplamprim_STG = 0
        pp_toplamprim_TL = 0
        pp_toplamprim_USD = 0
        pp_toplamprim_EUR = 0

        ip_toplamprim_STG = 0
        ip_toplamprim_TL = 0
        ip_toplamprim_USD = 0
        ip_toplamprim_EUR = 0

        toplamkasko_STG = 0
        toplamkasko_TL = 0
        toplamkasko_USD = 0
        toplamkasko_EUR = 0

        muallakadet_STG = 0
        muallakadet_TL = 0
        muallakadet_USD = 0
        muallakadet_EUR = 0

        iptaladet_STG = 0
        iptaladet_TL = 0
        iptaladet_USD = 0
        iptaladet_EUR = 0

        iptaliadetoplamprim_STG = 0
        iptaliadetoplamprim_TL = 0
        iptaliadetoplamprim_USD = 0
        iptaliadetoplamprim_EUR = 0

        muallakmaddiadet_STG = 0
        muallakmaddiadet_TL = 0
        muallakmaddiadet_USD = 0
        muallakmaddiadet_EUR = 0

        muallakmaddimiktar_STG = 0
        muallakmaddimiktar_TL = 0
        muallakmaddimiktar_USD = 0
        muallakmaddimiktar_EUR = 0

        muallakbedeniadet_STG = 0
        muallakbedeniadet_TL = 0
        muallakbedeniadet_USD = 0
        muallakbedeniadet_EUR = 0

        muallakbedenimiktar_STG = 0
        muallakbedenimiktar_TL = 0
        muallakbedenimiktar_USD = 0
        muallakbedenimiktar_EUR = 0

        muallakgenelmiktar_STG = 0
        muallakgenelmiktar_TL = 0
        muallakgenelmiktar_USD = 0
        muallakgenelmiktar_EUR = 0

        odenenadet_STG = 0
        odenenadet_TL = 0
        odenenadet_USD = 0
        odenenadet_EUR = 0

        odenenmaddiadet_STG = 0
        odenenmaddiadet_TL = 0
        odenenmaddiadet_USD = 0
        odenenmaddiadet_EUR = 0

        odenenmaddimiktar_STG = 0
        odenenmaddimiktar_TL = 0
        odenenmaddimiktar_USD = 0
        odenenmaddimiktar_EUR = 0

        odenenbedeniadet_STG = 0
        odenenbedeniadet_TL = 0
        odenenbedeniadet_USD = 0
        odenenbedeniadet_EUR = 0

        odenenbedenimiktar_STG = 0
        odenenbedenimiktar_TL = 0
        odenenbedenimiktar_USD = 0
        odenenbedenimiktar_EUR = 0

        odenengenelmiktar_STG = 0
        odenengenelmiktar_TL = 0
        odenengenelmiktar_USD = 0
        odenengenelmiktar_EUR = 0

        pertadet_STG = 0
        pertadet_TL = 0
        pertadet_USD = 0
        pertadet_EUR = 0

        pp_primTL = 0
        ip_primTL = 0

        pp_primTL_STG = 0
        pp_primTL_TL = 0
        pp_primTL_USD = 0
        pp_primTL_EUR = 0

        ip_primTL_STG = 0
        ip_primTL_TL = 0
        ip_primTL_USD = 0
        ip_primTL_EUR = 0


        odenenmaddimiktarTL_STG = 0
        odenenmaddimiktarTL_TL = 0
        odenenmaddimiktarTL_USD = 0
        odenenmaddimiktarTL_EUR = 0
        odenenbedenimiktarTL_STG = 0
        odenenbedenimiktarTL_TL = 0
        odenenbedenimiktarTL_USD = 0
        odenenbedenimiktarTL_EUR = 0

        muallakmaddimiktarTL_STG = 0
        muallakmaddimiktarTL_TL = 0
        muallakmaddimiktarTL_USD = 0
        muallakmaddimiktarTL_EUR = 0
        muallakbedenimiktarTL_STG = 0
        muallakbedenimiktarTL_TL = 0
        muallakbedenimiktarTL_USD = 0
        muallakbedenimiktarTL_EUR = 0

        muallakgenelmiktarTL_STG = 0
        muallakgenelmiktarTL_TL = 0
        muallakgenelmiktarTL_USD = 0
        muallakgenelmiktarTL_EUR = 0

        odenengenelmiktarTL_STG = 0
        odenengenelmiktarTL_TL = 0
        odenengenelmiktarTL_USD = 0
        odenengenelmiktarTL_EUR = 0

        Dim anatoplam_kaskoTL As Decimal
        Dim kaskoTL As Decimal
        Dim toplamkaskoTL_STG, toplamkaskoTL_TL, toplamkaskoTL_USD, toplamkaskoTL_EUR As Decimal
        anatoplam_kaskoTL = 0
        toplamkaskoTL_STG = 0
        toplamkaskoTL_TL = 0
        toplamkaskoTL_USD = 0
        toplamkaskoTL_EUR = 0



        Dim aa_anatoplam_muallakmaddimiktar As Decimal
        Dim aa_anatoplam_muallakbedenimiktar As Decimal
        Dim aa_muallak_genel_miktar_toplamTL As Decimal
        Dim aa_odenen_maddi_miktarTL As Decimal
        Dim aa_odenen_bedeni_miktarTL As Decimal
        Dim aa_PolicyPremiumTL As Decimal
        Dim aa_InsurancePremiumTL As Decimal
        Dim aa_odenen_genel_miktar_toplamTL As Decimal


        aa_anatoplam_muallakmaddimiktar = 0
        aa_anatoplam_muallakbedenimiktar = 0
        aa_muallak_genel_miktar_toplamTL = 0
        aa_odenen_maddi_miktarTL = 0
        aa_odenen_bedeni_miktarTL = 0
        aa_PolicyPremiumTL = 0
        aa_InsurancePremiumTL = 0
        aa_odenen_genel_miktar_toplamTL = 0


        While veri.Read

            girdi = "1"

            If Not veri.Item("TariffCode") Is System.DBNull.Value Then
                tariffcode = veri.Item("TariffCode")
                kol1 = "<tr><td>" + tariffcode + "</td>"
                saf1 = tariffcode
            Else
                kol1 = "<tr><td>-</td>"
                saf1 = "-"
            End If

            If Not veri.Item("ProductCode") Is System.DBNull.Value Then
                productcode = veri.Item("productcode")
                kol2 = "<td>" + productcode + "</td>"
                saf2 = productcode
            Else
                kol2 = "<td>-</td>"
                saf2 = "-"
            End If


            'If Not veri.Item("CurrencyCode") Is System.DBNull.Value Then
            'currencycode = veri.Item("CurrencyCode")
            'kol3 = "<td>" + currencycode + "</td>"
            'saf3 = currencycode
            'Else
            'kol3 = "<td>-</td>"
            'saf3 = "-"
            'End If


            'SUM LAR POLICYPREMIUM İÇİN-------------------------------------------------------
            If Not veri.Item("pp_pmiktar") Is System.DBNull.Value Then
                pp_pmiktar = veri.Item("pp_pmiktar")
            Else
                pp_pmiktar = 0
            End If
            If Not veri.Item("pp_tmiktar") Is System.DBNull.Value Then
                pp_tmiktar = veri.Item("pp_tmiktar")
            Else
                pp_tmiktar = 0
            End If
            If Not veri.Item("pp_vmiktar") Is System.DBNull.Value Then
                pp_vmiktar = veri.Item("pp_vmiktar")
            Else
                pp_vmiktar = 0
            End If
            If Not veri.Item("pp_rmiktar") Is System.DBNull.Value Then
                pp_rmiktar = veri.Item("pp_rmiktar")
            Else
                pp_rmiktar = 0
            End If
            If Not veri.Item("pp_xmiktar") Is System.DBNull.Value Then
                pp_xmiktar = veri.Item("pp_xmiktar")
            Else
                pp_xmiktar = 0
            End If



            'SUM LAR INSURANCEPREMIUM İÇİN-------------------------------------------------------
            If Not veri.Item("ip_pmiktar") Is System.DBNull.Value Then
                ip_pmiktar = veri.Item("ip_pmiktar")
            Else
                ip_pmiktar = 0
            End If
            If Not veri.Item("ip_tmiktar") Is System.DBNull.Value Then
                ip_tmiktar = veri.Item("ip_tmiktar")
            Else
                ip_tmiktar = 0
            End If
            If Not veri.Item("ip_vmiktar") Is System.DBNull.Value Then
                ip_vmiktar = veri.Item("ip_vmiktar")
            Else
                ip_vmiktar = 0
            End If
            If Not veri.Item("ip_rmiktar") Is System.DBNull.Value Then
                ip_rmiktar = veri.Item("ip_rmiktar")
            Else
                ip_rmiktar = 0
            End If
            If Not veri.Item("ip_xmiktar") Is System.DBNull.Value Then
                ip_xmiktar = veri.Item("ip_xmiktar")
            Else
                ip_xmiktar = 0
            End If



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
            '-------------------------------------------------------------------



            'SUM LAR POLICYPREMIUM tl İÇİN-------------------------------------------------------
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



            'SUM LAR INSURANCEPREMIUM İÇİN-------------------------------------------------------
            If Not veri.Item("ip_pmiktarTL") Is System.DBNull.Value Then
                ip_pmiktarTL = veri.Item("ip_pmiktarTL")
            Else
                ip_pmiktarTL = 0
            End If
            If Not veri.Item("ip_tmiktarTL") Is System.DBNull.Value Then
                ip_tmiktarTL = veri.Item("ip_tmiktarTL")
            Else
                ip_tmiktarTL = 0
            End If
            If Not veri.Item("ip_vmiktarTL") Is System.DBNull.Value Then
                ip_vmiktarTL = veri.Item("ip_vmiktarTL")
            Else
                ip_vmiktarTL = 0
            End If
            If Not veri.Item("ip_rmiktarTL") Is System.DBNull.Value Then
                ip_rmiktarTL = veri.Item("ip_rmiktarTL")
            Else
                ip_rmiktarTL = 0
            End If
            If Not veri.Item("ip_xmiktarTL") Is System.DBNull.Value Then
                ip_xmiktarTL = veri.Item("ip_xmiktarTL")
            Else
                ip_xmiktarTL = 0
            End If


            'POLİÇE ADETİ
            Dim p_t_toplamadet As Decimal
            p_t_toplamadet = padet + tadet
            kol4 = "<td>" + CStr(p_t_toplamadet) + "</td>"
            saf4 = CStr(p_t_toplamadet)
            If currencycode = "STG" Then
                STG_policeadet = STG_policeadet + CStr(p_t_toplamadet)
            End If
            If currencycode = "TL" Then
                TL_policeadet = TL_policeadet + CStr(p_t_toplamadet)
            End If
            If currencycode = "USD" Then
                USD_policeadet = USD_policeadet + CStr(p_t_toplamadet)
            End If
            If currencycode = "EUR" Then
                EUR_policeadet = EUR_policeadet + CStr(p_t_toplamadet)
            End If
            anatoplam_policeadet = anatoplam_policeadet + p_t_toplamadet




            'TOPLAM KASKO BEDELİ TL
            If Not veri.Item("kaskoTL") Is System.DBNull.Value Then
                kaskoTL = veri.Item("kaskoTL")
                anatoplam_kaskoTL = anatoplam_kaskoTL + kaskoTL
                kol5 = "<td>" + kaskoTL.ToString("N2") + "</td>"
                saf5 = kaskoTL.ToString("N2")
                If currencycode = "STG" Then
                    toplamkaskoTL_STG = toplamkaskoTL_STG + kaskoTL
                End If
                If currencycode = "TL" Then
                    toplamkaskoTL_TL = toplamkaskoTL_TL + kaskoTL
                End If
                If currencycode = "USD" Then
                    toplamkaskoTL_USD = toplamkaskoTL_USD + kaskoTL
                End If
                If currencycode = "EUR" Then
                    toplamkaskoTL_EUR = toplamkaskoTL_EUR + kaskoTL
                End If
            Else
                kol5 = "<td>-</td>"
                saf5 = "-"
            End If




            'HASARLARA BAŞLIYORUZ -----------------------------------------------
            Dim tablolar As New List(Of CLASSTEK)
            tablolar.Add(New CLASSTEK("PolicyInfo"))
            tablolar.Add(New CLASSTEK("DamageInfo"))


            'MUALLAK ADETİ
            Dim muallak_adeti As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "EstimatedMaterialDamage", ">", "1", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedCorporalDamage", ">", "1", ")"))
                muallak_adeti = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "EstimatedMaterialDamage", ">", "1", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedCorporalDamage", ">", "1", ")"))
                muallak_adeti = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol6 = "<td>" + CStr(muallak_adeti) + "</td>"
            saf6 = CStr(muallak_adeti)
            If currencycode = "STG" Then
                muallakadet_STG = muallakadet_STG + muallak_adeti
            End If
            If currencycode = "TL" Then
                muallakadet_TL = muallakadet_TL + muallak_adeti
            End If
            If currencycode = "USD" Then
                muallakadet_USD = muallakadet_USD + muallak_adeti
            End If
            If currencycode = "EUR" Then
                muallakadet_EUR = muallakadet_EUR + muallak_adeti
            End If
            anatoplam_muallakadet = anatoplam_muallakadet + muallak_adeti



            'MUALLAK MADDİ ADET
            Dim muallak_maddi_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol7 = "<td>" + CStr(muallak_maddi_adet) + "</td>"
            saf7 = CStr(muallak_maddi_adet)
            If currencycode = "STG" Then
                muallakmaddiadet_STG = muallakmaddiadet_STG + muallak_maddi_adet
            End If
            If currencycode = "TL" Then
                muallakmaddiadet_TL = muallakmaddiadet_TL + muallak_maddi_adet
            End If
            If currencycode = "USD" Then
                muallakmaddiadet_USD = muallakmaddiadet_USD + muallak_maddi_adet
            End If
            If currencycode = "EUR" Then
                muallakmaddiadet_EUR = muallakmaddiadet_EUR + muallak_maddi_adet
            End If
            anatoplam_muallakmaddiadet = anatoplam_muallakmaddiadet + muallak_maddi_adet



            'MUALLAK MADDİ MİKTAR TL
            Dim muallak_maddi_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(EstimatedMaterialAmountTL)-sum(PaidMaterialAmountTL)", fieldopvalues)
                If muallak_maddi_miktarTL < 0 Then
                    muallak_maddi_miktarTL = 0
                End If
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedMaterialDamage", ">", "1", ""))
                muallak_maddi_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(EstimatedMaterialAmountTL)-sum(PaidMaterialAmountTL)", fieldopvalues2)
                If muallak_maddi_miktarTL < 0 Then
                    muallak_maddi_miktarTL = 0
                End If
            End If
            kol8 = "<td>" + muallak_maddi_miktarTL.ToString("N2") + "</td>"
            saf8 = muallak_maddi_miktarTL.ToString("N2")
            aa_anatoplam_muallakmaddimiktar = aa_anatoplam_muallakmaddimiktar + muallak_maddi_miktarTL

            If currencycode = "STG" Then
                muallakmaddimiktarTL_STG = muallakmaddimiktarTL_STG + muallak_maddi_miktarTL
            End If
            If currencycode = "TL" Then
                muallakmaddimiktarTL_TL = muallakmaddimiktarTL_TL + muallak_maddi_miktarTL
            End If
            If currencycode = "USD" Then
                muallakmaddimiktarTL_USD = muallakmaddimiktarTL_USD + muallak_maddi_miktarTL
            End If
            If currencycode = "EUR" Then
                muallakmaddimiktarTL_EUR = muallakmaddimiktarTL_EUR + muallak_maddi_miktarTL
            End If







            'MUALLAK BEDENİ ADET
            Dim muallak_bedeni_adet As Integer = 0
            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If

            kol9 = "<td>" + CStr(muallak_bedeni_adet) + "</td>"
            saf9 = CStr(muallak_bedeni_adet)
            If currencycode = "STG" Then
                muallakbedeniadet_STG = muallakbedeniadet_STG + muallak_bedeni_adet
            End If
            If currencycode = "TL" Then
                muallakbedeniadet_TL = muallakbedeniadet_TL + muallak_bedeni_adet
            End If
            If currencycode = "USD" Then
                muallakbedeniadet_USD = muallakbedeniadet_USD + muallak_bedeni_adet
            End If
            If currencycode = "EUR" Then
                muallakbedeniadet_EUR = muallakbedeniadet_EUR + muallak_bedeni_adet
            End If
            anatoplam_muallakbedeniadet = anatoplam_muallakbedeniadet + muallak_bedeni_adet




            'MUALLAK BEDENİ MİKTAR TL
            Dim muallak_bedeni_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(EstimatedCorporalAmountTL)-sum(PaidCorporalAmountTL)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "MU", " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "EstimatedCorporalDamage", ">", "1", ""))
                muallak_bedeni_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(EstimatedCorporalAmountTL)-sum(PaidCorporalAmountTL)", fieldopvalues2)
                If muallak_bedeni_miktarTL > 0 Then
                    muallak_bedeni_miktarTL = 0
                End If
            End If
            kol10 = "<td>" + muallak_bedeni_miktarTL.ToString("N2") + "</td>"
            saf10 = muallak_bedeni_miktarTL.ToString("N2")
            aa_anatoplam_muallakbedenimiktar = aa_anatoplam_muallakbedenimiktar + muallak_bedeni_miktarTL

            If currencycode = "STG" Then
                muallakbedenimiktarTL_STG = muallakbedenimiktarTL_STG + muallak_bedeni_miktarTL
            End If
            If currencycode = "TL" Then
                muallakbedenimiktarTL_TL = muallakbedenimiktarTL_TL + muallak_bedeni_miktarTL
            End If
            If currencycode = "USD" Then
                muallakbedenimiktarTL_USD = muallakbedenimiktarTL_USD + muallak_bedeni_miktarTL
            End If
            If currencycode = "EUR" Then
                muallakbedenimiktarTL_EUR = muallakbedenimiktarTL_EUR + muallak_bedeni_miktarTL
            End If




            'MUALLAK GENEL MİKTAR TOPLAM TL
            Dim muallak_genel_miktar_toplamTL As Decimal
            muallak_genel_miktar_toplamTL = muallak_maddi_miktarTL + muallak_bedeni_miktarTL
            kol11 = "<td>" + muallak_genel_miktar_toplamTL.ToString("N2") + "</td>"
            saf11 = muallak_genel_miktar_toplamTL.ToString("N2")

            aa_muallak_genel_miktar_toplamTL = aa_muallak_genel_miktar_toplamTL + muallak_genel_miktar_toplamTL
            If currencycode = "STG" Then
                muallakgenelmiktarTL_STG = muallakgenelmiktarTL_STG + muallak_genel_miktar_toplamTL
            End If
            If currencycode = "TL" Then
                muallakgenelmiktarTL_TL = muallakgenelmiktarTL_TL + muallak_genel_miktar_toplamTL
            End If
            If currencycode = "USD" Then
                muallakgenelmiktarTL_USD = muallakgenelmiktarTL_USD + muallak_genel_miktar_toplamTL
            End If
            If currencycode = "EUR" Then
                muallakgenelmiktarTL_EUR = muallakgenelmiktarTL_EUR + muallak_genel_miktar_toplamTL
            End If



            'ÖDENEN ADET
            Dim odenen_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidMaterialDamage", ">", "1", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PaidCorporalDamage", ">", "1", ")"))
                odenen_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidMaterialDamage", ">", "1", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "PaidCorporalDamage", ">", "1", ")"))
                odenen_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol12 = "<td>" + CStr(odenen_adet) + "</td>"
            saf12 = CStr(odenen_adet)
            If currencycode = "STG" Then
                odenenadet_STG = odenenadet_STG + odenen_adet
            End If
            If currencycode = "TL" Then
                odenenadet_TL = odenenadet_TL + odenen_adet
            End If
            If currencycode = "USD" Then
                odenenadet_USD = odenenadet_USD + odenen_adet
            End If
            If currencycode = "EUR" Then
                odenenadet_EUR = odenenadet_EUR + odenen_adet
            End If
            anatoplam_odenenadet = anatoplam_odenenadet + odenen_adet


            'ÖDENEN MADDİ ADET
            Dim odenen_maddi_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol13 = "<td>" + CStr(odenen_maddi_adet) + "</td>"
            saf13 = CStr(odenen_maddi_adet)
            If currencycode = "STG" Then
                odenenmaddiadet_STG = odenenmaddiadet_STG + odenen_maddi_adet
            End If
            If currencycode = "TL" Then
                odenenmaddiadet_TL = odenenmaddiadet_TL + odenen_maddi_adet
            End If
            If currencycode = "USD" Then
                odenenmaddiadet_USD = odenenmaddiadet_USD + odenen_maddi_adet
            End If
            If currencycode = "EUR" Then
                odenenmaddiadet_EUR = odenenmaddiadet_EUR + odenen_maddi_adet
            End If
            anatoplam_odenenmaddiadet = anatoplam_odenenmaddiadet + odenen_maddi_adet




            'ÖDENEN MADDİ MİKTAR TL
            Dim odenen_maddi_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(PaidMaterialAmountTL)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidMaterialDamage", ">", "1", ")"))
                odenen_maddi_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(PaidMaterialAmountTL)", fieldopvalues2)
            End If
            kol14 = "<td>" + odenen_maddi_miktarTL.ToString("N2") + "</td>"
            saf14 = odenen_maddi_miktarTL.ToString("N2")
            aa_odenen_maddi_miktarTL = aa_odenen_maddi_miktarTL + odenen_maddi_miktarTL

            If currencycode = "STG" Then
                odenenmaddimiktarTL_STG = odenenmaddimiktarTL_STG + odenen_maddi_miktarTL
            End If
            If currencycode = "TL" Then
                odenenmaddimiktarTL_TL = odenenmaddimiktarTL_TL + odenen_maddi_miktarTL
            End If
            If currencycode = "USD" Then
                odenenmaddimiktarTL_USD = odenenmaddimiktarTL_USD + odenen_maddi_miktarTL
            End If
            If currencycode = "EUR" Then
                odenenmaddimiktarTL_EUR = odenenmaddimiktarTL_EUR + odenen_maddi_miktarTL
            End If



            'ÖDENEN BEDENİ ADET
            Dim odenen_bedeni_adet As Integer = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol15 = "<td>" + CStr(odenen_bedeni_adet) + "</td>"
            saf15 = CStr(odenen_bedeni_adet)
            If currencycode = "STG" Then
                odenenbedeniadet_STG = odenenbedeniadet_STG + odenen_bedeni_adet
            End If
            If currencycode = "TL" Then
                odenenbedeniadet_TL = odenenbedeniadet_TL + odenen_bedeni_adet
            End If
            If currencycode = "USD" Then
                odenenbedeniadet_USD = odenenbedeniadet_USD + odenen_bedeni_adet
            End If
            If currencycode = "EUR" Then
                odenenbedeniadet_EUR = odenenbedeniadet_EUR + odenen_bedeni_adet
            End If
            anatoplam_odenenbedeniadet = anatoplam_odenenbedeniadet + odenen_bedeni_adet



            'ÖDENEN BEDENİ MİKTAR TL
            Dim odenen_bedeni_miktarTL As Decimal = 0

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_miktarTL = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "sum(PaidCorporalAmountTL)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "DamageStatusCode", "=", "OD", " or "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "", "DamageStatusCode", "=", "KP", " ) and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "PaidCorporalDamage", ">", "1", ")"))
                odenen_bedeni_miktarTL = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "sum(PaidCorporalAmountTL)", fieldopvalues2)
            End If
            kol16 = "<td>" + odenen_bedeni_miktarTL.ToString("N2") + "</td>"
            saf16 = odenen_bedeni_miktarTL.ToString("N2")
            aa_odenen_bedeni_miktarTL = aa_odenen_bedeni_miktarTL + odenen_bedeni_miktarTL

            If currencycode = "STG" Then
                odenenbedenimiktarTL_STG = odenenbedenimiktarTL_STG + odenen_bedeni_miktarTL
            End If
            If currencycode = "TL" Then
                odenenbedenimiktarTL_TL = odenenbedenimiktarTL_TL + odenen_bedeni_miktarTL
            End If
            If currencycode = "USD" Then
                odenenbedenimiktarTL_USD = odenenbedenimiktarTL_USD + odenen_bedeni_miktarTL
            End If
            If currencycode = "EUR" Then
                odenenbedenimiktarTL_EUR = odenenbedenimiktarTL_EUR + odenen_bedeni_miktarTL
            End If




            'ÖDENEN GENEL MİKTAR TOPLAM TL
            Dim odenen_genel_miktar_toplamTL As Decimal
            odenen_genel_miktar_toplamTL = odenen_maddi_miktarTL + odenen_bedeni_miktarTL
            kol17 = "<td>" + odenen_genel_miktar_toplamTL.ToString("N2") + "</td>"
            saf17 = odenen_genel_miktar_toplamTL.ToString("N2")

            aa_odenen_genel_miktar_toplamTL = aa_odenen_genel_miktar_toplamTL + odenen_genel_miktar_toplamTL
            If currencycode = "STG" Then
                odenengenelmiktarTL_STG = odenengenelmiktarTL_STG + odenen_genel_miktar_toplamTL
            End If
            If currencycode = "TL" Then
                odenengenelmiktarTL_TL = odenengenelmiktarTL_TL + odenen_genel_miktar_toplamTL
            End If
            If currencycode = "USD" Then
                odenengenelmiktarTL_USD = odenengenelmiktarTL_USD + odenen_genel_miktar_toplamTL
            End If
            If currencycode = "EUR" Then
                odenengenelmiktarTL_EUR = odenengenelmiktarTL_EUR + odenen_genel_miktar_toplamTL
            End If


            'PERT ADET
            Dim pert_adet As Decimal

            If hangihasar = "kazatarih" Then
                fieldopvalues.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", productcode, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "AccidentDate", ">=", baslangictarih, " and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "AccidentDate", "<=", bitistarih, ") and "))
                fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "TotalLost", "=", "0", ") "))
                pert_adet = genericislem_erisim.countgeneric(veritabaniad, "DamageInfo", "count(*)", fieldopvalues)
            End If

            If hangihasar = "policebagli" Then
                fieldopvalues2.Clear()
                If Current.Session("firmcode") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "FirmCode", "=", Current.Session("firmcode"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "ProductCode", "=", productcode, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "TariffCode", "=", tariffcode, " and "))
                'fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "CurrencyCode", "=", currencycode, " and "))
                If Current.Session("policytype") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "PolicyType", "=", Current.Session("policytype"), " and "))
                End If
                If Current.Session("hangipoliceler") <> "Tümü" Then
                    fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", "Color", "=", Current.Session("hangipoliceler"), " and "))
                End If
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "(", tarihtip, ">=", baslangictarih, " and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("PolicyInfo", "", tarihtip, "<=", bitistarih, ") and "))
                fieldopvalues2.Add(New CLASSFIELDOPERATORVALUE2("DamageInfo", "(", "TotalLost", "=", "0", ") "))
                pert_adet = genericislem_erisim.countgenericbirdenfazlatablo(veritabaniad, tablolar, "count(*)", fieldopvalues2)
            End If
            kol18 = "<td>" + CStr(pert_adet) + "</td>"
            saf18 = CStr(pert_adet)
            If currencycode = "STG" Then
                pertadet_STG = pertadet_STG + pert_adet
            End If
            If currencycode = "TL" Then
                pertadet_TL = pertadet_TL + pert_adet
            End If
            If currencycode = "USD" Then
                pertadet_USD = pertadet_USD + pert_adet
            End If
            If currencycode = "EUR" Then
                pertadet_EUR = pertadet_EUR + pert_adet
            End If
            anatoplam_pertadet = anatoplam_pertadet + pert_adet




            'TOPLAM POLICY PREMIUM TL
            'pp_primTL = ((pp_pmiktarTL + pp_tmiktarTL + pp_vmiktarTL) - (pp_rmiktarTL + pp_xmiktarTL))
            'kol19 = "<td>" + pp_primTL.ToString("N2") + "</td>"
            'saf19 = pp_primTL.ToString("N2")
            'If currencycode = "STG" Then
            'pp_primTL_STG = pp_primTL_STG + pp_primTL
            'End If
            'If currencycode = "TL" Then
            ' pp_primTL_TL = pp_primTL_TL + pp_primTL
            ' End If
            ' If currencycode = "USD" Then
            ' pp_primTL_USD = pp_primTL_USD + pp_primTL
            ' End If
            ' If currencycode = "EUR" Then
            ' pp_primTL_EUR = pp_primTL_EUR + pp_primTL
            ' End If
            ' anatoplam_pp_primTL = anatoplam_pp_primTL + pp_primTL


            'TOPLAM POLICY PREMIUM TL
            Dim PolicyPremiumTL As Decimal
            If Not veri.Item("PolicyPremiumTL") Is System.DBNull.Value Then
                PolicyPremiumTL = veri.Item("PolicyPremiumTL")
                kol19 = "<td>" + PolicyPremiumTL.ToString("N2") + "</td>"
                saf19 = PolicyPremiumTL.ToString("N2")
            Else
                kol19 = "<td>-</td>"
                kol19 = "-"
            End If
            aa_PolicyPremiumTL = aa_PolicyPremiumTL + PolicyPremiumTL


            'TOPLAM INSURANCE PREMIUM TL
            'ip_primTL = ((ip_pmiktarTL + ip_tmiktarTL + ip_vmiktarTL) - (ip_rmiktarTL + ip_xmiktarTL))
            'kol20 = "<td>" + ip_primTL.ToString("N2") + "</td>"
            'saf20 = ip_primTL.ToString("N2")
            'If currencycode = "STG" Then
            ' ip_primTL_STG = ip_primTL_STG + ip_primTL
            'End If
            'If currencycode = "TL" Then
            ' ip_primTL_TL = ip_primTL_TL + ip_primTL
            ' End If
            'If currencycode = "USD" Then
            ' ip_primTL_USD = ip_primTL_USD + ip_primTL
            ' End If
            ' If currencycode = "EUR" Then
            'ip_primTL_EUR = ip_primTL_EUR + ip_primTL
            'End If
            'anatoplam_ip_primTL = anatoplam_ip_primTL + ip_primTL



            'TOPLAM INSURANCE PREMIUM TL
            Dim InsurancePremiumTL As Decimal
            If Not veri.Item("InsurancePremiumTL") Is System.DBNull.Value Then
                InsurancePremiumTL = veri.Item("InsurancePremiumTL")
                kol20 = "<td>" + InsurancePremiumTL.ToString("N2") + "</td>"
                saf20 = InsurancePremiumTL.ToString("N2")
            Else
                kol20 = "<td>-</td>"
                saf20 = "-"
            End If
            aa_InsurancePremiumTL = aa_InsurancePremiumTL + InsurancePremiumTL

            recordcount = recordcount + 1
            sirano = sirano + 1

            satir = satir + kol1 + kol2 + kol4 + _
            kol5 + kol6 + kol7 + kol8 + kol9 + kol10 + _
            kol11 + kol12 + kol13 + kol14 + kol15 + _
            kol16 + kol17 + kol18 + kol19 + kol20

            table.Rows.Add(saf1, saf2, saf4, saf5, _
            saf6, saf7, saf8, saf9, saf10, _
            saf11, saf12, saf13, saf14, saf15, _
            saf16, saf17, saf18, saf19, saf20)

            pdftable.AddCell(New Phrase(saf1, fdata))
            pdftable.AddCell(New Phrase(saf2, fdata))
            pdftable.AddCell(New Phrase(saf4, fdata))
            pdftable.AddCell(New Phrase(saf5, fdata))
            pdftable.AddCell(New Phrase(saf6, fdata))
            pdftable.AddCell(New Phrase(saf7, fdata))
            pdftable.AddCell(New Phrase(saf8, fdata))
            pdftable.AddCell(New Phrase(saf9, fdata))
            pdftable.AddCell(New Phrase(saf10, fdata))
            pdftable.AddCell(New Phrase(saf11, fdata))
            pdftable.AddCell(New Phrase(saf12, fdata))
            pdftable.AddCell(New Phrase(saf13, fdata))
            pdftable.AddCell(New Phrase(saf14, fdata))
            pdftable.AddCell(New Phrase(saf15, fdata))
            pdftable.AddCell(New Phrase(saf16, fdata))
            pdftable.AddCell(New Phrase(saf17, fdata))
            pdftable.AddCell(New Phrase(saf18, fdata))
            pdftable.AddCell(New Phrase(saf19, fdata))
            pdftable.AddCell(New Phrase(saf20, fdata))

        End While


        'HTML İÇİN EKLE
        toplamsatir = "<tr>" + _
        "<td>TOPLAM</td>" + _
        "<td>-</td>" + _
        "<td>" + CStr(anatoplam_policeadet) + "</td>" + _
        "<td>" + anatoplam_kaskoTL.ToString("N2") + "</td>" + _
        "<td>" + CStr(anatoplam_muallakadet) + "</td>" + _
        "<td>" + CStr(anatoplam_muallakmaddiadet) + "</td>" + _
        "<td>" + aa_anatoplam_muallakmaddimiktar.ToString("N2") + "</td>" + _
        "<td>" + CStr(anatoplam_muallakbedeniadet) + "</td>" + _
        "<td>" + aa_anatoplam_muallakbedenimiktar.ToString("N2") + "</td>" + _
        "<td>" + aa_muallak_genel_miktar_toplamTL.ToString("N2") + "</td>" + _
        "<td>" + CStr(anatoplam_odenenadet) + "</td>" + _
        "<td>" + CStr(anatoplam_odenenmaddiadet) + "</td>" + _
        "<td>" + aa_odenen_maddi_miktarTL.ToString("N2") + "</td>" + _
        "<td>" + CStr(anatoplam_odenenbedeniadet) + "</td>" + _
        "<td>" + aa_odenen_bedeni_miktarTL.ToString("N2") + "</td>" + _
        "<td>" + aa_odenen_genel_miktar_toplamTL.ToString("N2") + "</td>" + _
        "<td>" + CStr(anatoplam_pertadet) + "</td>" + _
        "<td>" + aa_PolicyPremiumTL.ToString("N2") + "</td>" + _
        "<td>" + aa_InsurancePremiumTL.ToString("N2") + "</td>" + _
        "</tr>"

        satir = satir + toplamsatir

        Dim RANATOPLAM As DataRow = table.NewRow

        'ANA TOPLAM ADETLER
        RANATOPLAM(0) = "TOPLAM"
        RANATOPLAM(1) = "-"
        RANATOPLAM(2) = CStr(anatoplam_policeadet)
        RANATOPLAM(3) = anatoplam_kaskoTL.ToString("N2")
        RANATOPLAM(4) = CStr(anatoplam_muallakadet)
        RANATOPLAM(5) = CStr(anatoplam_muallakmaddiadet)
        RANATOPLAM(6) = aa_anatoplam_muallakmaddimiktar.ToString("N2")
        RANATOPLAM(7) = CStr(anatoplam_muallakbedeniadet)
        RANATOPLAM(8) = aa_anatoplam_muallakbedenimiktar.ToString("N2")
        RANATOPLAM(9) = aa_muallak_genel_miktar_toplamTL.ToString("N2")
        RANATOPLAM(10) = CStr(anatoplam_odenenadet)
        RANATOPLAM(11) = CStr(anatoplam_odenenmaddiadet)
        RANATOPLAM(12) = aa_odenen_maddi_miktarTL.ToString("N2")
        RANATOPLAM(13) = CStr(anatoplam_odenenbedeniadet)
        RANATOPLAM(14) = aa_odenen_bedeni_miktarTL.ToString("N2")
        RANATOPLAM(15) = aa_odenen_genel_miktar_toplamTL.ToString("N2")
        RANATOPLAM(16) = CStr(anatoplam_pertadet)
        RANATOPLAM(17) = aa_PolicyPremiumTL.ToString("N2")
        RANATOPLAM(18) = aa_InsurancePremiumTL.ToString("N2")
        table.Rows.Add(RANATOPLAM)

    
        'ANA TOPLAM PDF
        pdftable.AddCell(New Phrase("TOPLAM", fdata))
        pdftable.AddCell(New Phrase("-", fdata))
        pdftable.AddCell(New Phrase(anatoplam_policeadet, fdata))
        pdftable.AddCell(New Phrase(anatoplam_kaskoTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(CStr(anatoplam_muallakadet), fdata))
        pdftable.AddCell(New Phrase(CStr(anatoplam_muallakmaddiadet), fdata))
        pdftable.AddCell(New Phrase(aa_anatoplam_muallakmaddimiktar.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(CStr(anatoplam_muallakbedeniadet), fdata))
        pdftable.AddCell(New Phrase(aa_anatoplam_muallakmaddimiktar.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(aa_muallak_genel_miktar_toplamTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(anatoplam_odenenadet, fdata))
        pdftable.AddCell(New Phrase(anatoplam_odenenmaddiadet, fdata))
        pdftable.AddCell(New Phrase(aa_odenen_maddi_miktarTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(anatoplam_odenenbedeniadet, fdata))
        pdftable.AddCell(New Phrase(aa_odenen_bedeni_miktarTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(aa_odenen_genel_miktar_toplamTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(anatoplam_pertadet, fdata))
        pdftable.AddCell(New Phrase(aa_PolicyPremiumTL.ToString("N2"), fdata))
        pdftable.AddCell(New Phrase(aa_InsurancePremiumTL.ToString("N2"), fdata))


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




End Class
