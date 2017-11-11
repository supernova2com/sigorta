Public Class PolicyInfoServiceHelper_Erisim

    Public Function eksurucusayisi(ByVal PolicyInfo As PolicyInfo) As Integer

        Dim kacsurucu As Integer = 0

        If PolicyInfo.IdentityCode2 <> "" Then
            kacsurucu = kacsurucu + 1
        End If
        If PolicyInfo.IdentityCode3 <> "" Then
            kacsurucu = kacsurucu + 1
        End If
        If PolicyInfo.IdentityCode4 <> "" Then
            kacsurucu = kacsurucu + 1
        End If
        If PolicyInfo.IdentityCode5 <> "" Then
            kacsurucu = kacsurucu + 1
        End If
        If PolicyInfo.IdentityCode6 <> "" Then
            kacsurucu = kacsurucu + 1
        End If

        Return kacsurucu


    End Function


    Public Function sbmcodebul(ByVal PolicyInfo As PolicyInfo) As String

        Dim PolicyInfo_erisim As New PolicyInfo_Erisim

        Dim nn As String = ""
        Dim kacadet As Integer
        Dim kacadetstr As String
        kacadet = PolicyInfo_erisim.policeadet_sirketin(PolicyInfo.FirmCode)

        kacadetstr = CStr(kacadet)

        Dim donecek As String
        donecek = "MP" + PolicyInfo.FirmCode + PolicyInfo.ProductCode + PolicyInfo.ProductType + _
        PolicyInfo.AgencyCode + PolicyInfo.PolicyNumber + PolicyInfo.TecditNumber + _
        PolicyInfo.ZeylCode + PolicyInfo.ZeylNo + CStr(kacadetstr)

        Return donecek

    End Function



    Public Function sinirkapitoplukontrolyetkilimi(ByVal PolicyInfo As PolicyInfo, ByVal servisayar As CLASSSERVISAYAR) As CLADBOPRESULT

        Dim policyinfoservicehelper_erisim As New PolicyInfoServiceHelper_Erisim

        Dim result As New CLADBOPRESULT
        result.durum = "Evet"
        result.etkilenen = 1
        result.hatastr = ""

        Dim acente_erisim As New CLASSACENTE_ERISIM
        Dim sinirkapi As New CLASSSINIRKAPI
        Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM
        Dim sinirkapitakvim_erisim As New CLASSSINIRKAPITAKVIM_ERISIM
        Dim sinirkapiip_erisim As New CLASSSINIRKAPIIP_ERISIM
        Dim ip_erisim As New CLASSIP_ERISIM
        Dim plakasinirkapi_erisim As New CLASSPLAKASINIRKAPI_ERISIM
        Dim plaka_kacadet As Integer
        plaka_kacadet = plakasinirkapi_erisim.kacadet(PolicyInfo.PlateNumber)

        'ÖNCE AGENCYREGISTERCODE'U KONTROL ET SINIR KAPISININ MI GERÇEK AGENCY REGİSTERCODE MU
        Dim varmikapikod As String
        Dim varmi_agencyregistercode As String
        'Dim varmi_agencyregistercode_merkez As String

        varmikapikod = sinirkapi_erisim.varmikapikod(PolicyInfo.AgencyRegisterCode)
        varmi_agencyregistercode = acente_erisim.ciftkayitkontrol("sicilno", PolicyInfo.AgencyRegisterCode)
        'varmi_agencyregistercode_merkez = acente_erisim.varmimerkez(PolicyInfo.AgencyRegisterCode)

        If varmikapikod = "Hayır" And varmi_agencyregistercode = "Hayır" Then
            result.durum = "Hayır"
            result.etkilenen = 851
            result.hatastr = "Gönderdiğiniz AgencyRegisterCode herhangi bir sınır kapısı için tanımlanmamış veya AgencyRegisterCode doğru bir acente değil."
            Return result
        End If

        'BAK BAKALIM EURO MU GÖNDERMİŞ
        If PolicyInfo.ArrangeDate > "01.01.2017" Then
            If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                If PolicyInfo.CurrencyCode <> "EUR" Then
                    result.durum = "Hayır"
                    result.etkilenen = 850
                    result.hatastr = "Sınır kapıları poliçelerinde CurrencyCode 'EUR' gönderilmelidir."
                    Return result
                End If
            End If
        End If

        'BAK BAKALIM POLİÇE STARTDATE ŞİMDİKİ GÜNÜN TARİHİ Mİ?
        If PolicyInfo.StartDate > "01.22.2017" Then
            If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                'sadece sınır kapısından gelenler ileri tarihli poliçe kesemez
                If varmikapikod = "Evet" Then
                    'ileri tarihli poliçe kesemesin
                    Dim startdate As Date
                    Dim simdikitarih As Date
                    startdate = PolicyInfo.StartDate
                    simdikitarih = Date.Today
                    Dim gunfark As Integer = 0

                    gunfark = startdate.Subtract(simdikitarih).Days
                    If gunfark > 0 Then
                        result.durum = "Hayır"
                        result.etkilenen = 857
                        result.hatastr = "Poliçenin başlangıç tarihi  " + Date.Now.ToShortDateString + " den küçük yada eşit olmalıdır. Sınır Kapısı"
                        Return result
                    End If
                End If
            End If
        End If

        'Sınır kapısı poliçeleri N olmalıdır
        If PolicyInfo.AuthorizedDrivers <> "N" Then
            result.durum = "Hayır"
            result.etkilenen = 852
            result.hatastr = "Sınır kapısı poliçeleri için AuthorizedDriver N olmalıdır."
            Return result
        End If

        'Sınır kapısı poliçesi için R gönderemez.
        If PolicyInfo.StartDate > "01.22.2017" Then
            If PolicyInfo.ZeylCode = "R" Then
                result.durum = "Hayır"
                result.etkilenen = 855
                result.hatastr = "Sınır kapısı poliçelerine R gönderemezsiniz."
                Return result
            End If
        End If


        'Sınır kapısından sadece P gönderebilir 
        If PolicyInfo.StartDate > "01.22.2017" Then
            If varmikapikod = "Evet" Then
                If PolicyInfo.ZeylCode <> "P" Then
                    result.durum = "Hayır"
                    result.etkilenen = 857
                    result.hatastr = "Sınır kapısından sadece zeyil kodu P olan poliçeler gönderebilirsiniz."
                    Return result
                End If
            End If
        End If

        'Merkez den gönderdi
        If PolicyInfo.StartDate > "01.22.2017" Then
            If varmi_agencyregistercode = "Evet" Then
                If PolicyInfo.ZeylCode <> "V" And PolicyInfo.ZeylCode <> "X" Then
                    'admin sınır kapısı için plaka tanımlamamış ise
                    If plaka_kacadet <= 0 Then
                        'result.durum = "Hayır"
                        'result.etkilenen = 857
                        'result.hatastr = "Merkez den gönderilen sınır kapısı poliçelerinin zeyil kodu yalnızca V veya X olmalıdır."
                        'Return result
                    End If
                End If
            End If
        End If


        'BAK BAKALIM O TARİH VE SAATTE KAYIT YAPABİLİRMİ ------------------------
        If servisayar.sinirkapitakvimkontrol = "Evet" Then
            'sadece sınır kapısından gelenler takvim kontrolune girer
            If varmikapikod = "Evet" Then
                'takvim kontrolü sadece sınır kapısından gelen poliçeler için
                If varmikapikod = "Evet" Then
                    Dim BorderCode As String
                    BorderCode = sinirkapi_erisim.bordercodebul(PolicyInfo.AgencyRegisterCode)
                    sinirkapi = sinirkapi_erisim.bultek_kapikodgore(BorderCode)
                    Dim gorevlimiresult As New CLADBOPRESULT
                    gorevlimiresult = sinirkapitakvim_erisim.yetkilimi(PolicyInfo, sinirkapi)
                    If gorevlimiresult.durum = "Hayır" Then
                        result.durum = "Hayır"
                        result.etkilenen = 853
                        result.hatastr = gorevlimiresult.hatastr
                        Return result
                    End If
                End If
            End If
        End If


        'PARA KONTROL YAP BAKALIM ------------------------------
        If PolicyInfo.ArrangeDate > "01.23.2017" Then
            If PolicyInfo.ZeylCode = "P" Or PolicyInfo.ZeylCode = "T" Then
                If PolicyInfo.ProductCode = 15 Then

                    Dim eksurucu_sayisi As Integer
                    Dim eklenecektutar As Decimal = 0
                    eksurucu_sayisi = PolicyInfoServiceHelper_Erisim.eksurucusayisi(PolicyInfo)
                    If eksurucu_sayisi > 0 Then
                        eklenecektutar = ((5 * eksurucu_sayisi) / 1.08)
                        eklenecektutar = Math.Round(eklenecektutar, 2, MidpointRounding.AwayFromZero)
                    End If

                    Dim sinirkapibazfiyat As New CLASSSINIRKAPIBAZFIYAT
                    Dim sinirkapibazfiyat_erisim As New CLASSSINIRKAPIBAZFIYAT_ERISIM
                    Dim sonkayit As Integer
                    sonkayit = sinirkapibazfiyat_erisim.ensonkayitnobul
                    If sonkayit > 0 Then

                        Dim bazfiyat As Decimal
                        Dim policefiyat As Decimal
                        Dim bazfiyatsinirkapi_erisim As New CLASSBAZFIYATTARIFESINIRKAPI_ERISIM
                        Dim bazfiyatsinirkapi As New CLASSBAZFIYATTARIFESINIRKAPI
                        Dim sinirkapiaractip As New CLASSSINIRKAPIARACTIP
                        Dim sinirkapiaractip_erisim As New CLASSSINIRKAPIARACTIP_ERISIM

                        sinirkapibazfiyat = sinirkapibazfiyat_erisim.bul_kayitnogore(sonkayit)
                        sinirkapiaractip = sinirkapiaractip_erisim.bultek_adagore(PolicyInfo.CarType)

                        Dim pb, ps As DateTime
                        pb = PolicyInfo.StartDate
                        ps = PolicyInfo.EndDate
                        Dim kacgun As Integer
                        kacgun = ps.Subtract(pb).Days
                        bazfiyatsinirkapi = bazfiyatsinirkapi_erisim.bul_ilgili(sinirkapibazfiyat.pkey, sinirkapiaractip.pkey)

                        '3 GÜN
                        If kacgun <= 3 Then
                            bazfiyat = bazfiyatsinirkapi.ucgun
                        End If
                        '1 AY
                        If (kacgun > 3 And kacgun <= 31) Then
                            bazfiyat = bazfiyatsinirkapi.biray
                        End If
                        '3 AY
                        If kacgun > 31 And kacgun <= 94 Then
                            bazfiyat = bazfiyatsinirkapi.ucay
                        End If
                        '6 AY
                        If kacgun > 94 And kacgun <= 186 Then
                            bazfiyat = bazfiyatsinirkapi.altiay
                        End If
                        '12 AY
                        If kacgun > 186 Then
                            bazfiyat = bazfiyatsinirkapi.onikiay
                        End If

                        policefiyat = bazfiyat + eklenecektutar

                        Dim ustsinirbazfiyat As Decimal
                        Dim altsinirbazfiyat As Decimal
                        ustsinirbazfiyat = bazfiyat + 0.01
                        altsinirbazfiyat = bazfiyat - 0.01

                        If PolicyInfo.BasePriceValue > ustsinirbazfiyat Or PolicyInfo.BasePriceValue < altsinirbazfiyat Then
                            result.durum = "Hayır"
                            result.etkilenen = 854
                            result.hatastr = "Sınır kapısı için BasePriceValue " + Format(bazfiyat, "0.00") + " EURO olmalıdır veya " + _
                            Format(ustsinirbazfiyat, "0.00") + " ile " + Format(altsinirbazfiyat, "0.00") + " EURO arasında olmalıdır."
                            Return result
                        End If

                        Dim ustsinir As Decimal
                        Dim altsinir As Decimal
                        ustsinir = policefiyat + 0.1
                        altsinir = policefiyat - 0.1

                        If PolicyInfo.PolicyPremium > ustsinir Or PolicyInfo.PolicyPremium < altsinir Then
                            result.durum = "Hayır"
                            result.etkilenen = 855
                            result.hatastr = "Sınır kapısı için PolicyPremium " + Format(ustsinir, "0.00") + " EURO ile " + _
                            Format(altsinir, "0.00") + " EURO arasında olmalıdır." + _
                            " Ek Sürücüler İçin " + Format(eklenecektutar, "0.00") + " EURO eklendi."
                            Return result
                        End If
                        If PolicyInfo.InsurancePremium > ustsinir Or PolicyInfo.InsurancePremium < altsinir Then
                            result.durum = "Hayır"
                            result.etkilenen = 856
                            result.hatastr = "Sınır kapısı için InsurancePremium " + Format(ustsinir, "0.00") + " EURO ile " + _
                            Format(altsinir, "0.00") + " EURO arasında olmalıdır." + _
                            " Ek Sürücüler İçin " + Format(eklenecektutar, "0.00") + " EURO eklendi."
                            Return result
                        End If

                    End If
                End If '1 Ocak 2017 den sonrakiler için para kontrolü yapıyoruz.
            End If 'p ve t olanlara

        End If 'sonkayit>0


        Return result

    End Function


End Class
