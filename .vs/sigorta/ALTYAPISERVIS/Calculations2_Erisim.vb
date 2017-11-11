Public Class Calculations2_Erisim


    Dim log As String = ""

    '1 TAMAM '0 HATALI
    Public Function hesapla(ByVal PolicyInfo As PolicyInfo) As hesapsonuc

        Dim donecekhesapsonuc As New hesapsonuc
        Dim hasarsorgulog As String = ""

        If PolicyInfo.ZeylCode <> "P" And PolicyInfo.ZeylCode <> "T" Then
            donecekhesapsonuc.hatakodu = 0
            donecekhesapsonuc.log = "P veya T olmadığından herhangi bir hesaplama yapmadım"
            donecekhesapsonuc.hatamsg = ""
            donecekhesapsonuc.sonuckodu = 1
        End If

        Dim yaskontrol_girecekmi = "Hayır"
        If PolicyInfo.AuthorizedDrivers = "N" Then
            If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                If PolicyInfo.PolicyOwnerIdentityCode = "KN" Or PolicyInfo.PolicyOwnerIdentityCode = "PN" Then
                    yaskontrol_girecekmi = "Evet"
                End If
            End If
        End If

        Dim gelenbazfiyat As Decimal = PolicyInfo.BasePriceValue
        Dim gelenbazfiyat_orginal As Decimal = PolicyInfo.BasePriceValue
        Dim yuzdeon_asagisi As Decimal
        Dim yuzdeyirmi_ustu As Decimal

        Dim sigortaprimi As Decimal = 0

        Dim yuzdeellisi As Decimal
        Dim bazfiyat As Decimal
        Dim bazfiyat_kurlacarpilmis As Decimal
        Dim anydriver_degeri As Decimal = 0

        Dim yas_zammi_oran As Integer = 0
        Dim yas_zammi As Decimal = 0

        Dim cc_oran As Integer = 0
        Dim cc_zammi As Decimal = 0

        Dim hasarsizlikindirimi As Decimal = 0
        Dim hasarzammi As Decimal = 0

        Dim bazfiyat_hesaplanan As Decimal = 0
        Dim hesaplananpublicvalue As Decimal = 0

        'HASARSIZLIK İNDİRİM VE HASAR ZAMMI 
        hasarsizlikindirimi = PolicyInfo.DamagelessRateValue
        hasarzammi = PolicyInfo.DamageRateValue

        Dim hesapsonuc As New hesapsonuc
        Dim sirket As New CLASSSIRKET
        Dim sirket_erisim As New CLASSSIRKET_ERISIM
        Dim bazfiyat_erisim As New CLASSBAZFIYAT_ERISIM
        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM

        Dim PolicyOwner_yz, Name1_yz, Name2_yz, Name3_yz, Name4_yz, Name5_yz, Name6_yz As Integer
        Dim hesaplanan_yaszamlari As New List(Of Integer)
        hesaplanan_yaszamlari.Clear()
        Dim enbuyuk_yz As Integer = 0
        PolicyOwner_yz = 0
        Name1_yz = 0
        Name2_yz = 0
        Name3_yz = 0
        Name4_yz = 0
        Name5_yz = 0
        Name6_yz = 0

        servisayar = servisayar_erisim.bultek(1)
        If servisayar.bazfiyatdikkat = "Hayır" Then
            log = "Baz fiyatlar loglanmıyor ve dikkate alınmıyor. Ayar Kapalı--"
            donecekhesapsonuc.sonuckodu = 1
            donecekhesapsonuc.hatakodu = 0
            donecekhesapsonuc.hatamsg = ""
            donecekhesapsonuc.log = log
            Return donecekhesapsonuc
        End If
        sirket = sirket_erisim.bultek_sirketkodagore(PolicyInfo.FirmCode)

        bazfiyat = bazfiyat_erisim.tarifeucretbul(PolicyInfo.ProductCode, _
        sirket.pkey, PolicyInfo.TariffCode, PolicyInfo.PolicyType, PolicyInfo.ProductType, PolicyInfo.StartDate)

        log = log + "Para Birimi: " + PolicyInfo.CurrencyCode + " --"
        log = log + "Kur:" + Format(PolicyInfo.ExchangeRate, "0.0000") + " --"
        log = log + "Sistemde Kayıtlı Baz Fiyat: " + Format(bazfiyat, "0.00") + " --"
        log = log + "Gönderilen Baz Fiyat: " + Format(gelenbazfiyat, "0.00") + PolicyInfo.CurrencyCode + " --"

        gelenbazfiyat = gelenbazfiyat * PolicyInfo.ExchangeRate
        log = log + "Gönderilen Baz Fiyat (Kurla Çarpılmış): " + Format(gelenbazfiyat, "0.00") + "TL" + " --"


        If bazfiyat = 0 Then

            donecekhesapsonuc.sonuckodu = 0
            donecekhesapsonuc.hatakodu = 99
            donecekhesapsonuc.hatamsg = "Baz Fiyat Bulunamadı"
            Return donecekhesapsonuc

            'log = "Şirket Baz Fiyatları girmemiş."
            'donecekhesapsonuc.sonuckodu = 0
            'donecekhesapsonuc.hatakodu = 404
            'donecekhesapsonuc.hatamsg = "Şirket Baz Fiyatları girmemiş."
            'donecekhesapsonuc.log = log
            'hesaplogla(PolicyInfo, sigortaprimi, bazfiyat, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
            'Return donecekhesapsonuc

        End If


        log = log + "AutorizedDrivers: " + CStr(PolicyInfo.AuthorizedDrivers) + "--"

        'GELEN BAZ FİYATIN DOĞRULUĞUNU HESAPLA 
        yuzdeon_asagisi = (bazfiyat - (bazfiyat * 10) / 100) - 1
        yuzdeyirmi_ustu = (bazfiyat + (bazfiyat * 20) / 100) + 1

        If PolicyInfo.ProductCode = 15 Then

            Dim q As Decimal
            q = ((100 * gelenbazfiyat) - (100 * bazfiyat)) / bazfiyat
            If gelenbazfiyat > bazfiyat Then
                log = log + "Artış oranı:%" + Format(q, "0.00") + "--"
            Else
                log = log + "İndirim oranı:%" + Format(q, "0.00") + "--"
            End If

            If gelenbazfiyat > yuzdeyirmi_ustu Then
                log = log + "Gelen Baz Fiyat:" + Format(gelenbazfiyat, "0.00") + "--" + _
                "Sistemde Kayıtlı Baz Fiyat:" + Format(bazfiyat, "0.00") + "--" + _
                "%20 Yukarısı:" + Format(yuzdeyirmi_ustu, "0.00") + "--" + _
                "Gelen Baz Fiyat Sistemde kaydedilen baz fiyatın %20'sinden büyüktür."
                donecekhesapsonuc.sonuckodu = 0
                donecekhesapsonuc.hatakodu = 100
                donecekhesapsonuc.hatamsg = log
                donecekhesapsonuc.log = log
                hesaplogla(PolicyInfo, sigortaprimi, bazfiyat, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                Return donecekhesapsonuc
            End If
            If gelenbazfiyat < yuzdeon_asagisi Then
                log = log + "Gelen Baz Fiyat:" + Format(gelenbazfiyat, "0.00") + "--" + _
                "Sistemde Kayıtlı Baz Fiyat:" + Format(bazfiyat, "0.00") + "--" + _
                "%10 Aşağısı:" + Format(yuzdeon_asagisi, "0.00") + "--" + _
                "Gelen Baz Fiyat Sistemde kaydedilen baz fiyatın %10'undan daha küçüktür."
                donecekhesapsonuc.sonuckodu = 0
                donecekhesapsonuc.hatakodu = 101
                donecekhesapsonuc.hatamsg = log
                donecekhesapsonuc.log = log
                hesaplogla(PolicyInfo, sigortaprimi, bazfiyat, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                Return donecekhesapsonuc
            End If

            log = log + "Ürün Kodu:15 3. Şahıs Zorunlu Trafik Sigortası Hesaplaması Uyguluyorum--"
            log = log + "************--"
            log = log + "Şirket Kodu: " + CStr(PolicyInfo.FirmCode) + "--"
            log = log + "Tarife Kodu: " + CStr(PolicyInfo.TariffCode) + "--"

            'ANY DRIVER 
            If PolicyInfo.AuthorizedDrivers = "A" Then
                yuzdeellisi = (gelenbazfiyat * 50) / 100
                log = log + "Bulunan Baz Fiyatın Yüzde 50'si: " + Format(yuzdeellisi, "0.00") + "--"
                anydriver_degeri = yuzdeellisi
                log = log + Format(gelenbazfiyat, "0.00") + " -> %50: " + Format(anydriver_degeri, "0.00") + "--"
            Else
                yuzdeellisi = 0
                anydriver_degeri = 0
                log = log + "Name Driver olduğundan %50 artış uygulamıyorum." + "--"
            End If


            If yaskontrol_girecekmi = "Evet" Then

                'YAŞ ZAMMI ORANI
                If Not PolicyInfo.PolicyOwnerBirthDate Is Nothing Then
                    PolicyOwner_yz = tuzukyasoranbul(PolicyInfo.PolicyOwnerBirthDate)
                    hesaplanan_yaszamlari.Add(PolicyOwner_yz)
                End If
                If Not PolicyInfo.BirthDate1 Is Nothing Then
                    Name1_yz = tuzukyasoranbul(PolicyInfo.BirthDate1)
                    hesaplanan_yaszamlari.Add(Name1_yz)
                End If
                If Not PolicyInfo.BirthDate2 Is Nothing Then
                    Name2_yz = tuzukyasoranbul(PolicyInfo.BirthDate2)
                    hesaplanan_yaszamlari.Add(Name2_yz)
                End If
                If Not PolicyInfo.BirthDate3 Is Nothing Then
                    Name3_yz = tuzukyasoranbul(PolicyInfo.BirthDate3)
                    hesaplanan_yaszamlari.Add(Name3_yz)
                End If
                If Not PolicyInfo.BirthDate4 Is Nothing Then
                    Name4_yz = tuzukyasoranbul(PolicyInfo.BirthDate4)
                    hesaplanan_yaszamlari.Add(Name4_yz)
                End If
                If Not PolicyInfo.BirthDate5 Is Nothing Then
                    Name5_yz = tuzukyasoranbul(PolicyInfo.BirthDate5)
                    hesaplanan_yaszamlari.Add(Name5_yz)
                End If
                If Not PolicyInfo.BirthDate6 Is Nothing Then
                    Name6_yz = tuzukyasoranbul(PolicyInfo.BirthDate6)
                    hesaplanan_yaszamlari.Add(Name6_yz)
                End If
                enbuyuk_yz = hesaplanan_yaszamlari.Max()
                yas_zammi = (gelenbazfiyat_orginal * enbuyuk_yz) / 100

                If PolicyInfo.AgeRate <> enbuyuk_yz Then
                    log = log + "Hesaplanan Yaş Zammı Oranı: " + Format(enbuyuk_yz, "0.00") + "--"
                    log = log + "Gönderilen Yaş Zammı Oranı: " + Format(PolicyInfo.AgeRate, "0.00") + "--"
                    log = log + "************--"
                End If

                If PolicyInfo.AgeRateValue <> yas_zammi Then
                    log = log + "Hesaplanan Yaş Zammı: " + Format(yas_zammi, "0.00") + "--"
                    log = log + "Gönderilen Yaş Zammı: " + Format(PolicyInfo.AgeRateValue, "0.00") + "--"
                    log = log + "************--"
                End If

            End If 'yas kontrol girecekmi

            'CC ORANI BUL
            cc_oran = tuzukccoranbul(PolicyInfo.TariffCode, PolicyInfo.CarType, PolicyInfo.EnginePower)
            log = log + "CC Oranı: " + Format(cc_oran, "0.00") + "--"
            cc_zammi = (gelenbazfiyat_orginal * cc_oran) / 100
            log = log + "Hesaplanan CC Zammı: " + Format(cc_zammi, "0.00") + "--"
            log = log + "Gönderilen CC Zammı: " + Format(PolicyInfo.CCRateValue, "0.00") + "--"
            log = log + "************--"

            If cc_oran = -99999 Then
                log = log + "Tüzükte bu araç için CC Oranı bulamadım--"
                donecekhesapsonuc.sonuckodu = 1
                donecekhesapsonuc.hatakodu = 106
                donecekhesapsonuc.hatamsg = ""
                donecekhesapsonuc.log = log
                hesaplogla(PolicyInfo, sigortaprimi, bazfiyat, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                Return donecekhesapsonuc
            End If

            log = log + "Hasarsızlık İndirimi (DamagelessRateValue): " + Format(hasarsizlikindirimi, "0.00") + "--"
            log = log + "Hasar Zammı (DamageRateValue): " + Format(hasarzammi, "0.00") + "--"
            log = log + "************--"

            If PolicyInfo.AuthorizedDrivers = "A" Then
                sigortaprimi = (gelenbazfiyat + anydriver_degeri + cc_zammi + hasarzammi) - (hasarsizlikindirimi)
                log = log + "AnyDriver formulünü uyguluyorum--"

                log = log + "Sigorta Primi = ((Baz Fiyat  + Any Driver + CC Zammı + Hasar Zammı) - (Hasarsızlık İndirimi ))--"

                log = log + "Sistem Sigorta Primi = ((" + Format(gelenbazfiyat, "0.00") + " + " + Format(anydriver_degeri, "0.00") + _
                " + " + Format(cc_zammi, "0.00") + " + " + Format(hasarzammi, "0.00") + ") - (" + _
                Format(hasarsizlikindirimi, "0.00") + ") = " + Format(sigortaprimi, "0.00") + "))--"
                log = log + "************--"
            End If

            If PolicyInfo.AuthorizedDrivers = "N" Then
                sigortaprimi = (bazfiyat + yas_zammi + cc_zammi + hasarzammi) - (hasarsizlikindirimi)
                log = log + "NameDriver formulünü uyguluyorum--"

                log = log + "Sigorta Primi= ((Baz Fiyat + Yaş Zammı + CC Zammı + Hazar Zammı) - (Hasarsızlık İndirimi)) --"

                log = log + "Sigorta Primi = ((" + Format(gelenbazfiyat, "0.00") + " + " + Format(yas_zammi, "0.00") + _
                " + " + Format(cc_zammi, "0.00") + " + " + Format(hasarzammi, "0.00") + _
                ") - (" + Format(hasarsizlikindirimi, "0.00") + ")) = " + Format(sigortaprimi, "0.00") + "--"
                log = log + "************--"
            End If

        End If















        '----------------------------------------------------------------------------------------------------
        'KASKO VE KISMİ KASKO
        Dim publicvalue As Decimal

        If PolicyInfo.ProductCode = 16 Or PolicyInfo.ProductCode = 17 Then

            publicvalue = PolicyInfo.PublicValue

            log = log + "Ürün Kodu:" + CStr(PolicyInfo.ProductCode) + " Kasko ve Kısmi Kasko Hesaplaması Uyguluyorum--"
            log = log + "************--"
            log = log + "Şirket Kodu: " + CStr(PolicyInfo.FirmCode) + "--"
            log = log + "Tarife Kodu: " + CStr(PolicyInfo.TariffCode) + "--"

            log = log + "Sigorta / Araç Bedeli (Public Value): " + Format(publicvalue, "0.00") + "--"

            bazfiyat = bazfiyat_erisim.tarifeucretbul(PolicyInfo.ProductCode, _
            sirket.pkey, PolicyInfo.TariffCode, PolicyInfo.PolicyType, PolicyInfo.ProductType, PolicyInfo.StartDate)
            log = log + "Bulunan Baz Fiyat Oranı: " + Format(bazfiyat, "0.00") + "--"
            log = log + "AutorizedDrivers: " + CStr(PolicyInfo.AuthorizedDrivers) + "--"


            'BAZ FİYAT KONTROLÜNE GİRİLİP GİRİLMEYECEĞİNİ TESPİT EDİYORUZ-------------
            Dim bazfiyat_bulunan_arakontrolicin As Decimal = 0
            bazfiyat_bulunan_arakontrolicin = bazfiyat_erisim.tarifeucretbul_arakontrolicin(PolicyInfo.ProductCode, _
            sirket.pkey, PolicyInfo.TariffCode, PolicyInfo.PolicyType, PolicyInfo.ProductType, PolicyInfo.StartDate)

            Dim arakontrole_girilecekmi As String = "Hayır"
            If bazfiyat_bulunan_arakontrolicin <= 0 Then
                log = log + "Minimum prim 0 (sıfır) dan küçük yada eşit olduğundan baz fiyat kontrolüne giriliyor.--"
                arakontrole_girilecekmi = "Evet"
            End If
            If bazfiyat_bulunan_arakontrolicin > 0 Then
                If PolicyInfo.PolicyPremiumTL > bazfiyat_bulunan_arakontrolicin Then
                    log = log + "Gönderilen PolicyPremium bulunan baz fiyattan büyük olduğundan baz fiyat kontrolüne giriliyor.--"
                    arakontrole_girilecekmi = "Evet"
                End If
            End If
            '---------------------------------------------------------------------------

            If arakontrole_girilecekmi = "Evet" Then

                bazfiyat_hesaplanan = (publicvalue * bazfiyat) / 100

                yuzdeon_asagisi = bazfiyat_hesaplanan - (bazfiyat_hesaplanan * 10) / 100
                yuzdeyirmi_ustu = bazfiyat_hesaplanan + (bazfiyat_hesaplanan * 20) / 100

                yuzdeon_asagisi = Math.Round(yuzdeon_asagisi, 2) - 1
                yuzdeyirmi_ustu = Math.Round(yuzdeyirmi_ustu, 2) + 1

                If gelenbazfiyat_orginal > yuzdeyirmi_ustu Then
                    log = log + "Gelen Orjinal Baz Fiyat:" + Format(gelenbazfiyat_orginal, "0.00") + PolicyInfo.CurrencyCode + "--" + _
                    "Gelen Baz Fiyat (Kurla Çarpılmış):" + Format(gelenbazfiyat, "0.00") + "TL" + "--" + _
                    "Sistemde Kayıtlı Baz Fiyat:" + Format(bazfiyat, "0.00") + "--" + _
                    "%20 Yukarısı:" + Format(yuzdeyirmi_ustu, "0.00") + "--" + _
                    "Gelen Baz Fiyat Sistemde kaydedilen baz fiyatın %20'sinden büyüktür."
                    donecekhesapsonuc.sonuckodu = 0
                    donecekhesapsonuc.hatakodu = 100
                    donecekhesapsonuc.hatamsg = log
                    donecekhesapsonuc.log = log
                    hesaplogla(PolicyInfo, sigortaprimi, bazfiyat, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                    Return donecekhesapsonuc
                End If

                If gelenbazfiyat_orginal < yuzdeon_asagisi Then
                    log = log + "Gelen Orjinal Baz Fiyat:" + Format(gelenbazfiyat_orginal, "0.00") + PolicyInfo.CurrencyCode + "--" + _
                    "Gelen Baz Fiyat:" + Format(gelenbazfiyat, "0.00") + "TL" + "--" + _
                    "Sistemde Kayıtlı Baz Fiyat:" + Format(bazfiyat, "0.00") + "--" + _
                    "%10 Aşağısı:" + Format(yuzdeon_asagisi, "0.00") + "--" + _
                    "Gelen Baz Fiyat Sistemde kaydedilen baz fiyatın %10'undan daha küçüktür."
                    donecekhesapsonuc.sonuckodu = 0
                    donecekhesapsonuc.hatakodu = 101
                    donecekhesapsonuc.hatamsg = log
                    donecekhesapsonuc.log = log
                    hesaplogla(PolicyInfo, sigortaprimi, bazfiyat, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                    Return donecekhesapsonuc
                End If

            End If 'baz fiyat kontrolüne girilecek ise


            'ANY DRIVER 
            If PolicyInfo.AuthorizedDrivers = "A" Then
                yuzdeellisi = (gelenbazfiyat * 50) / 100
                log = log + "Bulunan Baz Fiyatın Yüzde 50'si: " + Format(yuzdeellisi, "0.00") + "--"
                anydriver_degeri = yuzdeellisi
                log = log + Format(gelenbazfiyat, "0.00") + " -> %50: " + Format(anydriver_degeri, "0.00") + "--"
            Else
                yuzdeellisi = 0
                anydriver_degeri = 0
                log = log + "Name Driver olduğundan %50 artış uygulamıyorum." + "--"
            End If


            If yaskontrol_girecekmi = "Evet" Then
                'YAŞ ZAMMI ORANI
                If Not PolicyInfo.PolicyOwnerBirthDate Is Nothing Then
                    PolicyOwner_yz = tuzukyasoranbul(PolicyInfo.PolicyOwnerBirthDate)
                    'hesaplanan_yaszamlari.Add(PolicyOwner_yz)
                End If
                If Not PolicyInfo.BirthDate1 Is Nothing Then
                    Name1_yz = tuzukyasoranbul(PolicyInfo.BirthDate1)
                    hesaplanan_yaszamlari.Add(Name1_yz)
                End If
                If Not PolicyInfo.BirthDate2 Is Nothing Then
                    Name2_yz = tuzukyasoranbul(PolicyInfo.BirthDate2)
                    hesaplanan_yaszamlari.Add(Name2_yz)
                End If
                If Not PolicyInfo.BirthDate3 Is Nothing Then
                    Name3_yz = tuzukyasoranbul(PolicyInfo.BirthDate3)
                    hesaplanan_yaszamlari.Add(Name3_yz)
                End If
                If Not PolicyInfo.BirthDate4 Is Nothing Then
                    Name4_yz = tuzukyasoranbul(PolicyInfo.BirthDate4)
                    hesaplanan_yaszamlari.Add(Name4_yz)
                End If
                If Not PolicyInfo.BirthDate5 Is Nothing Then
                    Name5_yz = tuzukyasoranbul(PolicyInfo.BirthDate5)
                    hesaplanan_yaszamlari.Add(Name5_yz)
                End If
                If Not PolicyInfo.BirthDate6 Is Nothing Then
                    Name6_yz = tuzukyasoranbul(PolicyInfo.BirthDate6)
                    hesaplanan_yaszamlari.Add(Name6_yz)
                End If
                enbuyuk_yz = hesaplanan_yaszamlari.Max()
                yas_zammi = (gelenbazfiyat_orginal * enbuyuk_yz) / 100
                If PolicyInfo.AgeRate <> enbuyuk_yz Then
                    log = log + "Hesaplanan Yaş Zammı Oranı: " + Format(enbuyuk_yz, "0.00") + "--"
                    log = log + "Gönderilen Yaş Zammı Oranı: " + Format(PolicyInfo.AgeRate, "0.00") + "--"
                    log = log + "************--"
                End If
                If PolicyInfo.AgeRateValue <> yas_zammi Then
                    log = log + "Hesaplanan Yaş Zammı: " + Format(yas_zammi, "0.00") + "--"
                    log = log + "Gönderilen Yaş Zammı: " + Format(PolicyInfo.AgeRateValue, "0.00") + "--"
                    log = log + "************--"
                End If
            End If

            'CC ORANI BUL-----------------------
            cc_oran = tuzukccoranbul(PolicyInfo.TariffCode, PolicyInfo.CarType, PolicyInfo.EnginePower)
            log = log + "CC Oranı: " + Format(cc_oran, "0.00") + "--"
            cc_zammi = (gelenbazfiyat_orginal * cc_oran) / 100
            log = log + "Hesaplanan CC Zammı: " + Format(cc_zammi, "0.00") + "--"
            log = log + "Gönderilen CC Zammı: " + Format(PolicyInfo.CCRateValue, "0.00") + "--"
            log = log + "************--"

            If cc_oran = -99999 Then
                log = log + "Tüzükte bu araç için CC Oranı bulamadım--"
                donecekhesapsonuc.sonuckodu = 1
                donecekhesapsonuc.hatakodu = 106
                donecekhesapsonuc.hatamsg = ""
                donecekhesapsonuc.log = log
                hesaplogla(PolicyInfo, sigortaprimi, bazfiyat, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                Return donecekhesapsonuc
            End If

            log = log + "Hasarsızlık İndirimi (DamagelessRateValue): " + Format(hasarsizlikindirimi, "0.00") + "--"
            log = log + "Hasar Zammı (DamageRateValue): " + Format(hasarzammi, "0.00") + "--"
            log = log + "************--"

            'KASKO VE KISMİ KASKO SİGORTASI PRİM HESAPLAMASINI 
            If PolicyInfo.AuthorizedDrivers = "A" Then
                sigortaprimi = (gelenbazfiyat + anydriver_degeri + cc_zammi + hasarzammi) - hasarsizlikindirimi
                log = log + "AnyDriver formulünü uyguluyorum. --"
                log = log + "Sistem Sigorta Primi = (Baz Fiyat + Any Driver + CC Zammı + Hasar Zammı ) - (Hasarsızlık İndirimi ) --"
                log = log + "Sistem Sigorta Primi = (" + Format(gelenbazfiyat, "0.00") + " + " + Format(anydriver_degeri, "0.00") + _
                " + " + Format(cc_zammi, "0.00") + " + " + Format(hasarzammi, "0.00") + ") - " + Format(hasarsizlikindirimi, "0.00") + ") = " + Format(sigortaprimi, "0.00") + "--"
                log = log + "************--"
            End If

            If PolicyInfo.AuthorizedDrivers = "N" Then
                sigortaprimi = (gelenbazfiyat + yas_zammi + cc_zammi + hasarzammi) - (hasarsizlikindirimi)
                log = log + "NameDriver formulünü uyguluyorum--"
                log = log + "Sigorta Primi= ((Baz Fiyat + Yaş Zammı + CC Zammı + Hazar Zammı) - (Hasarsızlık İndirimi)) --"
                log = log + "Sigorta Primi = ((" + Format(gelenbazfiyat, "0.00") + " + " + Format(yas_zammi, "0.00") + _
                " + " + Format(cc_zammi, "0.00") + " + " + Format(hasarzammi, "0.00") + ") - (" + Format(hasarsizlikindirimi, "0.00") + _
                ")) = " + Format(sigortaprimi, "0.00") + "--"
                log = log + "************--"
            End If

        End If '16 ve 17 icin


        '---KONTROLLER -------------------------------------------------------------------------------------
        'yaş

        If yaskontrol_girecekmi = "Evet" Then
            If enbuyuk_yz <> PolicyInfo.AgeRate Then
                log = log + " Gönderilen Yaş Zammı Oranı:" + Format(PolicyInfo.AgeRate, "0.00") + "--"
                log = log + " Gönderilen yaş zammı Oranı ile hesaplan yaş zammı oranı birbirini tutmuyor--"
                log = log + " Hesaplanan Yaş Zammı Oranı:" + Format(enbuyuk_yz, "0.00") + "."
                log = log + " Any Driver Değeri:" + Format(anydriver_degeri, "0.00")
                donecekhesapsonuc.sonuckodu = 0
                donecekhesapsonuc.hatakodu = 105
                donecekhesapsonuc.hatamsg = "Gönderilen yaş zammı oranı ile hesaplan yaş zammı oranı birbirini tutmuyor." + _
                " Gönderilen Yaş Zammı Oranı:" + Format(PolicyInfo.AgeRate, "0.00") + "." + _
                " Hesaplanan Yaş Zammı Oranı:" + Format(enbuyuk_yz, "0.00") + "." + _
                " Any Driver Değeri:" + Format(anydriver_degeri, "0.00")
                donecekhesapsonuc.log = log
                hesaplogla(PolicyInfo, sigortaprimi, bazfiyat_hesaplanan, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                Return donecekhesapsonuc
            End If
            If (yas_zammi > PolicyInfo.AgeRateValue + 1) Or (yas_zammi < PolicyInfo.AgeRateValue - 1) Then
                log = log + " Gönderilen Yaş Zammı:" + Format(PolicyInfo.AgeRateValue, "0.00") + "--"
                log = log + " Gönderilen yaş zammı  ile hesaplan yaş zammı birbirini tutmuyor--"
                log = log + " Hesaplanan Yaş Zammı:" + Format(yas_zammi, "0.00") + "."
                log = log + " Any Driver Değeri:" + Format(anydriver_degeri, "0.00")
                donecekhesapsonuc.sonuckodu = 0
                donecekhesapsonuc.hatakodu = 105
                donecekhesapsonuc.hatamsg = "Gönderilen yaş zammı ile hesaplan yaş zammı birbirini tutmuyor." + _
                " Gönderilen Yaş Zammı:" + Format(PolicyInfo.AgeRateValue, "0.00") + "." + _
                " Hesaplanan Yaş Zammı:" + Format(yas_zammi, "0.00") + "." + _
                " Any Driver Değeri:" + Format(anydriver_degeri, "0.00")
                donecekhesapsonuc.log = log
                hesaplogla(PolicyInfo, sigortaprimi, bazfiyat_hesaplanan, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
                Return donecekhesapsonuc
            End If
        End If 'yaskontrol_girecekmi = "Evet"


        'CC
        If cc_oran <> PolicyInfo.CCRate Then
            log = log + "Gönderilen CC Rate:" + Format(PolicyInfo.CCRate, "0.00") + "--"
            log = log + "Gönderilen CC Rate ile hesaplan CC Rate birbirini tutmuyor--"
            donecekhesapsonuc.sonuckodu = 0
            donecekhesapsonuc.hatakodu = 106
            donecekhesapsonuc.hatamsg = "Gönderilen CC Rate ile hesaplan CC Rate birbirini tutmuyor." + _
            " Gönderilen CC Rate:" + Format(PolicyInfo.CCRate, "0.00") + "." + _
            " Hesaplanan CC Rate:" + Format(cc_oran, "0.00")
            donecekhesapsonuc.log = log
            hesaplogla(PolicyInfo, sigortaprimi, bazfiyat_hesaplanan, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
            Return donecekhesapsonuc
        End If
        If (cc_zammi > PolicyInfo.CCRateValue + 1) Or (cc_zammi < PolicyInfo.CCRateValue - 1) Then
            log = log + "Gönderilen CC Rate Value:" + Format(PolicyInfo.CCRateValue, "0.00") + "--"
            log = log + "Gönderilen CC Rate Value ile hesaplan CC Rate Value birbirini tutmuyor--"
            donecekhesapsonuc.sonuckodu = 0
            donecekhesapsonuc.hatakodu = 106
            donecekhesapsonuc.hatamsg = "Gönderilen CC Rate Value ile hesaplan CC Rate Value birbirini tutmuyor." + _
            " Gönderilen CC Rate Value:" + Format(PolicyInfo.CCRateValue, "0.00") + "." + _
            " Hesaplanan CC Rate Value:" + Format(cc_zammi, "0.00")
            donecekhesapsonuc.log = log
            hesaplogla(PolicyInfo, sigortaprimi, bazfiyat_hesaplanan, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
            Return donecekhesapsonuc
        End If

        'sigorta primi
        If (sigortaprimi > PolicyInfo.InsurancePremium + 1) Or (sigortaprimi < PolicyInfo.InsurancePremium - 1) Then
            log = log + "Gönderilen Sigora Primi:" + Format(PolicyInfo.InsurancePremium, "0.00") + "--"
            log = log + "Gönderilen sigorta primi ile hesaplanan sigorta primi birbirini tutmuyor--"
            donecekhesapsonuc.sonuckodu = 0
            donecekhesapsonuc.hatakodu = 107
            donecekhesapsonuc.hatamsg = "Gönderilen Sigorta Primi ile hesaplanan Sigorta Primi birbirini tutmuyor. " + _
            " Gönderilen Sigorta Primi:" + Format(PolicyInfo.InsurancePremium, "0.00") + "." + _
            " Hesaplanan Sigorta Primi:" + Format(sigortaprimi, "0.00") + "."
            donecekhesapsonuc.log = log
            hesaplogla(PolicyInfo, sigortaprimi, bazfiyat_hesaplanan, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi_oran, donecekhesapsonuc, hasarsorgulog)
            Return donecekhesapsonuc
        End If

        log = log + "Gelen Sigorta Primi:" + Format(PolicyInfo.InsurancePremium, "0.00") + "--"
        log = log + "************--"
        log = log + "HESAPLAR UYUŞTU"
        donecekhesapsonuc.hatakodu = 0
        donecekhesapsonuc.log = log
        donecekhesapsonuc.hatamsg = ""
        donecekhesapsonuc.sonuckodu = 1

        hesaplogla(PolicyInfo, sigortaprimi, bazfiyat_hesaplanan, anydriver_degeri, cc_zammi, yas_zammi, cc_oran, yas_zammi, donecekhesapsonuc, hasarsorgulog)

        Return donecekhesapsonuc

    End Function


    Public Function tuzukyasoranbul(ByVal dogumtarihi As Date) As Integer

        Dim donecekoran As Integer
        Dim simdikitarih As Date

        simdikitarih = Date.Now
        Dim yas As Integer
        Dim yasyil As Integer

        yas = simdikitarih.Subtract(dogumtarihi).Days
        yasyil = yas / 365

        log = log + " Bu Sürücü " + CStr(yasyil) + " yaşındadır.--"

        Dim age_erisim As New CLASSAGE_ERISIM
        Dim ageler As New List(Of CLASSAGE)
        ageler = age_erisim.doldur

        If ageler.Count < 1 Then
            log = log + CStr(yasyil) + " yaşı için herhangi bir tanımlama yapılmamış."
            donecekoran = 0
            Return donecekoran
        End If

        If ageler.Count > 0 Then

            For Each itemage As CLASSAGE In ageler
                If yasyil >= itemage.baslangicage And yasyil <= itemage.bitisage Then
                    log = log + " SBM tarafından tanımlamış Yaş Zammı oranı %" + CStr(itemage.agerate) + ".--"
                    donecekoran = itemage.agerate
                    Return donecekoran
                End If
            Next
        End If

        Return donecekoran

    End Function




    Public Function tuzukccoranbul(ByVal TariffCode As String, ByVal CarType As String, _
    ByVal EnginePower As Integer) As Integer

        Dim dairearactip As New CLASSDAIREARACTIP
        Dim dairearactip_erisim As New CLASSDAIREARACTIP_ERISIM
        dairearactip = dairearactip_erisim.bultek_adagore(CarType)

        Dim aractarife As New CLASSARACTARIFE
        Dim aractarife_erisim As New CLASSARACTARIFE_ERISIM
        aractarife = aractarife_erisim.bultarifekodagore(TariffCode)

        Dim tuzukdairearactipbag As New CLASSTUZUKDAIREARACTIPBAG
        Dim tuzukdairearactipbag_erisim As New CLASSTUZUKDAIREARACTIPBAG_ERISIM
        tuzukdairearactipbag = tuzukdairearactipbag_erisim.bultek_ilgili(dairearactip.pkey)


        Dim girdi As String = "Hayır"
        Dim donecekoran As Integer = 0

        Dim cc_erisim As New CLASSCC_ERISIM
        Dim cc As New CLASSCC
        Dim ccler As New List(Of CLASSCC)
        ccler = cc_erisim.doldurilgili(tuzukdairearactipbag.tuzukaractippkey)

        If ccler.Count < 1 Then
            log = log + dairearactip.dairearactipad + " için SBM tarafından herhangi bir CC Zammı oranı tanımlanmamış."
            donecekoran = 0
            Return donecekoran
        End If

        For Each itemcc As CLASSCC In ccler
            If EnginePower >= itemcc.baslangicc And EnginePower <= itemcc.bitiscc Then
                log = log + " Bakılan Tüzük Araç Tipi: " + CStr(itemcc.tuzukaractippkey) + " --"
                log = log + " SBM tarafından tanımlamış CC Zammı oranı %" + CStr(itemcc.oran) + ". dır. --"
                donecekoran = itemcc.oran
                Return donecekoran
            End If
        Next


    End Function



    Public Function hesaplogla(ByVal PolicyInfo As PolicyInfo, ByVal sigortaprimi As Decimal, _
    ByVal bazfiyat As Decimal, ByVal anydriver_degeri As Decimal, _
    ByVal cc_zammi As Decimal, ByVal yas_zammi As Decimal, _
    ByVal cc_oran As Decimal, ByVal yas_zammi_oran As Decimal, _
    ByVal hesapsonuc As hesapsonuc, ByVal hasarsorgulog As String)

        'HESAP LOGLA 
        Dim result As New CLADBOPRESULT

        Dim loghesap As New CLASSLOGHESAP
        Dim loghesap_erisim As New CLASSLOGHESAP_ERISIM
        loghesap.tarih = DateTime.Now
        loghesap.FirmCode = PolicyInfo.FirmCode
        loghesap.ProductCode = PolicyInfo.ProductCode
        loghesap.AgencyCode = PolicyInfo.AgencyCode
        loghesap.PolicyNumber = PolicyInfo.PolicyNumber
        loghesap.TecditNumber = PolicyInfo.TecditNumber
        loghesap.ZeylCode = PolicyInfo.ZeylCode
        loghesap.ZeylNo = PolicyInfo.ZeylNo
        loghesap.s_InsuarencePremium = sigortaprimi
        loghesap.s_BasePriceValue = bazfiyat
        loghesap.s_CCRateValue = cc_zammi
        loghesap.s_AgeRateValue = yas_zammi
        loghesap.s_DamageRateValue = PolicyInfo.DamageRateValue
        loghesap.hesaplog = log
        loghesap.tuzukccoran = cc_oran
        loghesap.tuzukyasoran = yas_zammi_oran
        loghesap.sonuckodu = hesapsonuc.sonuckodu
        loghesap.hatakodu = hesapsonuc.hatakodu
        loghesap.hatamsg = hesapsonuc.hatamsg
        loghesap.s_AnyDriver = anydriver_degeri
        loghesap.g_AuthorizedDrivers = PolicyInfo.AuthorizedDrivers
        loghesap.g_CurrencyCode = PolicyInfo.CurrencyCode
        loghesap.g_InsurancePremium = PolicyInfo.InsurancePremium
        loghesap.g_AssistantFees = PolicyInfo.AssistantFees
        loghesap.g_OtherFees = PolicyInfo.OtherFees
        loghesap.g_BasePriceValue = PolicyInfo.BasePriceValue
        loghesap.g_CCRateValue = PolicyInfo.CCRateValue
        loghesap.g_DamageRateValue = PolicyInfo.DamageRateValue
        loghesap.g_AgeRateValue = PolicyInfo.AgeRateValue
        loghesap.g_DamagelessRateValue = PolicyInfo.DamagelessRateValue
        loghesap.ArrangeDate = PolicyInfo.ArrangeDate
        loghesap.hasarsorgulog = hasarsorgulog
        loghesap.ProductType = PolicyInfo.ProductType


        result = loghesap_erisim.Ekle(loghesap)


        'eğer kayıt yapamaz ise kayıt yapılamadığını logla--
        If result.durum <> "Kaydedildi" Then
            loghesap.s_InsuarencePremium = sigortaprimi
            loghesap.s_BasePriceValue = 0
            loghesap.s_CCRateValue = 0
            loghesap.s_AgeRateValue = 0
            loghesap.s_DamageRateValue = 0
            loghesap.hesaplog = ""
            loghesap.tuzukccoran = 0
            loghesap.tuzukyasoran = 0
            loghesap.sonuckodu = 0
            loghesap.hatakodu = 999
            loghesap.hatamsg = result.hatastr
            loghesap.s_AnyDriver = 0
            loghesap.g_AuthorizedDrivers = "-"
            loghesap.g_CurrencyCode = "-"
            loghesap.g_InsurancePremium = 0
            loghesap.g_AssistantFees = 0
            loghesap.g_OtherFees = 0
            loghesap.g_BasePriceValue = 0
            loghesap.g_CCRateValue = 0
            loghesap.g_DamageRateValue = 0
            loghesap.g_AgeRateValue = 0
            loghesap.g_DamagelessRateValue = 0
            loghesap.ArrangeDate = Date.Now
            loghesap.hasarsorgulog = hasarsorgulog
            loghesap.ProductType = "-"


            loghesap_erisim.Ekle(loghesap)
        End If


    End Function




End Class
