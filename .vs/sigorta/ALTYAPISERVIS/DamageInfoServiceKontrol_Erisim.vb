Public Class DamageInfoServiceKontrol_Erisim


    Public Function kombinasyonkontrol(ByVal servisayar As CLASSSERVISAYAR, ByVal DamageInfo As DamageInfo) As root

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
        root.ResultCode = 1




        'DriverCountryCode
        If DamageInfo.DriverCountryCode <> "" Then
            If DamageInfo.DriverIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 504
                ErrorInfo.Message = "KOM. DriverIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.DriverIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 504
                    ErrorInfo.Message = "KOM. DriverIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.DriverName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 504
                ErrorInfo.Message = "KOM. DriverName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            'If DamageInfo.DriverIdentityCode = "KN" Or DamageInfo.DriverIdentityCode = "PN" Then
            If DamageInfo.DriverSurname = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 504
                ErrorInfo.Message = "KOM. DriverSurname boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
            'End If

        End If

        'DriverIdentityCode
        If DamageInfo.DriverIdentityCode <> "" Then
            If DamageInfo.DriverCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 505
                ErrorInfo.Message = "KOM. DriverCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.DriverIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 505
                    ErrorInfo.Message = "KOM. DriverIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.DriverName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 505
                ErrorInfo.Message = "KOM. DriverName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            'If DamageInfo.DriverIdentityCode = "KN" Or DamageInfo.DriverIdentityCode = "PN" Then
            If DamageInfo.DriverSurname = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 505
                ErrorInfo.Message = "KOM. DriverSurname boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
            'End If
        End If


        'DriverIdentityNo
        If DamageInfo.DriverIdentityNo <> "" Then
            If DamageInfo.DriverIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 506
                ErrorInfo.Message = "KOM. DriverIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.DriverCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 506
                ErrorInfo.Message = "KOM. DriverCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.DriverName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 506
                ErrorInfo.Message = "KOM. DriverName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            'If DamageInfo.DriverIdentityCode = "KN" Or DamageInfo.DriverIdentityCode = "PN" Then
            If DamageInfo.DriverSurname = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 506
                ErrorInfo.Message = "KOM. DriverSurname boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
            'End If
        End If


        'DriverName
        If DamageInfo.DriverName <> "" Then

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.DriverIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 507
                    ErrorInfo.Message = "KOM. DriverIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.DriverIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 507
                ErrorInfo.Message = "KOM. DriverIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.DriverCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 507
                ErrorInfo.Message = "KOM. DriverCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            'If DamageInfo.DriverIdentityCode = "KN" Or DamageInfo.DriverIdentityCode = "PN" Then
            If DamageInfo.DriverSurname = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 507
                ErrorInfo.Message = "KOM. DriverSurname boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
            'End if
        End If


        'DriverSurName
        If DamageInfo.DriverSurname <> "" Then

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.DriverIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 508
                    ErrorInfo.Message = "KOM. DriverIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.DriverIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 508
                ErrorInfo.Message = "KOM. DriverIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.DriverCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 508
                ErrorInfo.Message = "KOM. DriverCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.DriverName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 508
                ErrorInfo.Message = "KOM. DriverName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        'Driver kısmı bitti.
        'Claimant başladı



        'ClaimantCountryCode
        If DamageInfo.ClaimantCountryCode <> "" Then
            If DamageInfo.ClaimantIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 509
                ErrorInfo.Message = "KOM. ClaimantIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.ClaimantIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 509
                    ErrorInfo.Message = "KOM. ClaimantIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.ClaimantName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 509
                ErrorInfo.Message = "KOM. ClaimantName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantIdentityCode = "KN" Or DamageInfo.ClaimantIdentityCode = "PN" Then
                If DamageInfo.ClaimantSurname = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 509
                    ErrorInfo.Message = "KOM. ClaimantSurname boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If

        End If

        'ClaimantIdentityCode
        If DamageInfo.ClaimantIdentityCode <> "" Then
            If DamageInfo.ClaimantCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 510
                ErrorInfo.Message = "KOM. ClaimantCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.ClaimantIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 510
                    ErrorInfo.Message = "KOM. ClaimantIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.ClaimantName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 510
                ErrorInfo.Message = "KOM. ClaimantName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantIdentityCode = "KN" Or DamageInfo.ClaimantIdentityCode = "PN" Then
                If DamageInfo.ClaimantSurname = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 510
                    ErrorInfo.Message = "KOM. ClaimantSurname boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If

        End If

        'ClaimantIdentityNo
        If DamageInfo.ClaimantIdentityNo <> "" Then
            If DamageInfo.ClaimantIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 511
                ErrorInfo.Message = "KOM. ClaimantIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 511
                ErrorInfo.Message = "KOM. ClaimantCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 511
                ErrorInfo.Message = "KOM. ClaimantName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantIdentityCode = "KN" Or DamageInfo.ClaimantIdentityCode = "PN" Then
                If DamageInfo.ClaimantSurname = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 511
                    ErrorInfo.Message = "KOM. ClaimantSurname boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If

        End If



        'ClaimantName
        If DamageInfo.ClaimantName <> "" Then

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.ClaimantIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 512
                    ErrorInfo.Message = "KOM. ClaimantIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.ClaimantIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 512
                ErrorInfo.Message = "KOM. ClaimantIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 512
                ErrorInfo.Message = "KOM. ClaimantCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            'Claimantsurname sadece KN VE PN'de
            If DamageInfo.ClaimantIdentityCode = "KN" Or DamageInfo.ClaimantIdentityCode = "PN" Then
                If DamageInfo.ClaimantSurname = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 512
                    ErrorInfo.Message = "KOM. ClaimantSurname boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If

        End If


        'ClaimantSurName
        If DamageInfo.ClaimantSurname <> "" Then

            If servisayar.damagekimlikkontrol = "Evet" Then
                If DamageInfo.ClaimantIdentityNo = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 513
                    ErrorInfo.Message = "KOM. ClaimantIdentityNo boş olamaz"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            If DamageInfo.ClaimantIdentityCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 513
                ErrorInfo.Message = "KOM. ClaimantIdentityCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantCountryCode = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 513
                ErrorInfo.Message = "KOM. ClaimantCountryCode boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If

            If DamageInfo.ClaimantName = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 513
                ErrorInfo.Message = "KOM. ClaimantName boş olamaz"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If


        Return root

    End Function



    Public Function kombinasyonkontrol2(ByVal wskullaniciad As String, ByVal wssifre As String, ByVal sifresahibisirket As CLASSSIRKET, _
    ByVal Info As Info, ByVal InfoXML As String) As root

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM

        root.ResultCode = 1

        If Info.AuthorizedDrivers = "N" Then

            'kimlik numarası girildi fakat diğerleri eksik.
            If Info.IdentityNumber1 <> "" Then
                If Info.IdentityCountryCode1 = "" Or Info.IdentityCode1 = "" Or Info.IdentityBirthDate1 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNumber1 için tüm veriler tam gönderilmedi." + _
                    " IdentityCountryCode1,Info.IdentityCode1,IdentityBirthDate1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityNumber2 <> "" Then
                If Info.IdentityCountryCode2 = "" Or Info.IdentityCode2 = "" Or Info.IdentityBirthDate2 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNumber2 için tüm veriler tam gönderilmedi." + _
                    " IdentityCountryCode2,Info.IdentityCode2,IdentityBirthDate2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityNumber3 <> "" Then
                If Info.IdentityCountryCode3 = "" Or Info.IdentityCode3 = "" Or Info.IdentityBirthDate3 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNumber3 için tüm veriler tam gönderilmedi." + _
                    " IdentityCountryCode3,Info.IdentityCode3,IdentityBirthDate3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityNumber4 <> "" Then
                If Info.IdentityCountryCode4 = "" Or Info.IdentityCode4 = "" Or Info.IdentityBirthDate4 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNumber4 için tüm veriler tam gönderilmedi." + _
                    " IdentityCountryCode4,Info.IdentityCode4,IdentityBirthDate4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityNumber5 <> "" Then
                If Info.IdentityCountryCode5 = "" Or Info.IdentityCode5 = "" Or Info.IdentityBirthDate5 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNumber5 için tüm veriler tam gönderilmedi." + _
                    " IdentityCountryCode5,Info.IdentityCode5,IdentityBirthDate5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityNumber6 <> "" Then
                If Info.IdentityCountryCode6 = "" Or Info.IdentityCode6 = "" Or Info.IdentityBirthDate6 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNumber6 için tüm veriler tam gönderilmedi." + _
                    " IdentityCountryCode6,Info.IdentityCode6,IdentityBirthDate6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If


            'CountryCode girilmiş digerleri eksik
            If Info.IdentityCountryCode1 <> "" Then
                If Info.IdentityNumber1 = "" Or Info.IdentityCode1 = "" Or Info.IdentityBirthDate1 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNumber1 için tüm veriler tam gönderilmedi." + _
                    " IdentityNumber1,Info.IdentityCode1,IdentityBirthDate1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityCountryCode2 <> "" Then
                If Info.IdentityNumber2 = "" Or Info.IdentityCode2 = "" Or Info.IdentityBirthDate2 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNumber2 için tüm veriler tam gönderilmedi." + _
                    " IdentityNumber2,Info.IdentityCode2,IdentityBirthDate2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityCountryCode3 <> "" Then
                If Info.IdentityNumber3 = "" Or Info.IdentityCode3 = "" Or Info.IdentityBirthDate3 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNumber3 için tüm veriler tam gönderilmedi." + _
                    " IdentityNumber3,Info.IdentityCode3,IdentityBirthDate3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityCountryCode4 <> "" Then
                If Info.IdentityNumber4 = "" Or Info.IdentityCode4 = "" Or Info.IdentityBirthDate4 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNumber4 için tüm veriler tam gönderilmedi." + _
                    " IdentityNumber4,Info.IdentityCode4,IdentityBirthDate4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityCountryCode5 <> "" Then
                If Info.IdentityNumber5 = "" Or Info.IdentityCode5 = "" Or Info.IdentityBirthDate5 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNumber5 için tüm veriler tam gönderilmedi." + _
                    " IdentityNumber5,Info.IdentityCode5,IdentityBirthDate5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If Info.IdentityCountryCode6 <> "" Then
                If Info.IdentityNumber6 = "" Or Info.IdentityCode6 = "" Or Info.IdentityBirthDate6 Is Nothing Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNumber6 için tüm veriler tam gönderilmedi." + _
                    " IdentityNumber6,Info.IdentityCode6,IdentityBirthDate6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
        End If





        'IdentityCode girilmiş fakat diğerleri eksik
        If Info.IdentityCode1 <> "" Then
            If Info.IdentityNumber1 = "" Or Info.IdentityCountryCode1 = "" Or Info.IdentityBirthDate1 Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 453
                ErrorInfo.Message = "IdentityNumber1 için tüm veriler tam gönderilmedi." + _
                " Info.IdentityNumber1,IdentityCountryCode1,IdentityBirthDate1"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Info.IdentityCode2 <> "" Then
            If Info.IdentityNumber2 = "" Or Info.IdentityCountryCode2 = "" Or Info.IdentityBirthDate2 Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 453
                ErrorInfo.Message = "IdentityNumber2 için tüm veriler tam gönderilmedi." + _
                " Info.IdentityNumber2,IdentityCountryCode2,IdentityBirthDate2"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Info.IdentityCode3 <> "" Then
            If Info.IdentityNumber3 = "" Or Info.IdentityCountryCode3 = "" Or Info.IdentityBirthDate3 Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 453
                ErrorInfo.Message = "IdentityNumber3 için tüm veriler tam gönderilmedi." + _
                " Info.IdentityNumber3,IdentityCountryCode3,IdentityBirthDate3"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Info.IdentityCode4 <> "" Then
            If Info.IdentityNumber4 = "" Or Info.IdentityCountryCode4 = "" Or Info.IdentityBirthDate4 Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 453
                ErrorInfo.Message = "IdentityNumber4 için tüm veriler tam gönderilmedi." + _
                " Info.IdentityNumber4,IdentityCountryCode4,IdentityBirthDate4"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Info.IdentityCode5 <> "" Then
            If Info.IdentityNumber5 = "" Or Info.IdentityCountryCode5 = "" Or Info.IdentityBirthDate5 Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 453
                ErrorInfo.Message = "IdentityNumber5 için tüm veriler tam gönderilmedi." + _
                " Info.IdentityNumber5,IdentityCountryCode5,IdentityBirthDate5"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Info.IdentityCode6 <> "" Then
            If Info.IdentityNumber6 = "" Or Info.IdentityCountryCode6 = "" Or Info.IdentityBirthDate6 Is Nothing Then
                root.ResultCode = 0
                ErrorInfo.Code = 453
                ErrorInfo.Message = "IdentityNumber6 için tüm veriler tam gönderilmedi." + _
               " Info.IdentityNumber6,IdentityCountryCode6,IdentityBirthDate6"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If






        'BirthDate girilmiş fakat diğerleri girilmemiş
        If Not Info.IdentityBirthDate1 Is Nothing Then
            If Info.IdentityNumber1 = "" Or Info.IdentityCountryCode1 = "" Or Info.IdentityCode1 = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 454
                ErrorInfo.Message = "IdentityNumber1 için tüm veriler tam gönderilmedi." + _
                " IdentityCountryCode1,Info.IdentityNumber1,IdentityCode1"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Not Info.IdentityBirthDate2 Is Nothing Then
            If Info.IdentityNumber2 = "" Or Info.IdentityCountryCode2 = "" Or Info.IdentityCode2 = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 454
                ErrorInfo.Message = "IdentityNumber2 için tüm veriler tam gönderilmedi." + _
                " IdentityCountryCode2,Info.IdentityNumber2,IdentityCode2"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Not Info.IdentityBirthDate3 Is Nothing Then
            If Info.IdentityNumber3 = "" Or Info.IdentityCountryCode3 = "" Or Info.IdentityCode3 = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 454
                ErrorInfo.Message = "IdentityNumber3 için tüm veriler tam gönderilmedi." + _
                " IdentityCountryCode3,Info.IdentityNumber3,IdentityCode3"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Not Info.IdentityBirthDate4 Is Nothing Then
            If Info.IdentityNumber4 = "" Or Info.IdentityCountryCode4 = "" Or Info.IdentityCode4 = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 454
                ErrorInfo.Message = "IdentityNumber4 için tüm veriler tam gönderilmedi." + _
                " IdentityCountryCode4,IdentityNumber4,IdentityCode4"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Not Info.IdentityBirthDate5 Is Nothing Then
            If Info.IdentityNumber5 = "" Or Info.IdentityCountryCode5 = "" Or Info.IdentityCode5 = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 454
                ErrorInfo.Message = "IdentityNumber5 için tüm veriler tam gönderilmedi." + _
                " IdentityCountryCode5,IdentityNumber5,IdentityCode5"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If
        If Not Info.IdentityBirthDate6 Is Nothing Then
            If Info.IdentityNumber6 = "" Or Info.IdentityCountryCode6 = "" Or Info.IdentityCode6 = "" Then
                root.ResultCode = 0
                ErrorInfo.Code = 454
                ErrorInfo.Message = "IdentityNumber6 için tüm veriler tam gönderilmedi." + _
                " IdentityCountryCode6,IdentityNumber6,IdentityCode6"
                root.ErrorInfo = ErrorInfo
                Return root
            End If
        End If



        Dim kimliktur_erisim As New CLASSKIMLIKTUR_ERISIM
        Dim varmi As String = "Evet"
        If Info.IdentityCode1 <> "" Then
            Try
                varmi = kimliktur_erisim.kimlikturkodvarmi(Info.IdentityCode1)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityCode1 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 455
                ErrorInfo.Message = "IdentityCode1 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCode2 <> "" Then
            Try
                varmi = kimliktur_erisim.kimlikturkodvarmi(Info.IdentityCode2)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityCode2 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 455
                ErrorInfo.Message = "IdentityCode2 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCode3 <> "" Then
            Try
                varmi = kimliktur_erisim.kimlikturkodvarmi(Info.IdentityCode3)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityCode3 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 455
                ErrorInfo.Message = "IdentityCode3 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCode4 <> "" Then
            Try
                varmi = kimliktur_erisim.kimlikturkodvarmi(Info.IdentityCode4)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityCode4 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 455
                ErrorInfo.Message = "IdentityCode4 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCode5 <> "" Then
            Try
                varmi = kimliktur_erisim.kimlikturkodvarmi(Info.IdentityCode5)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityCode5 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 455
                ErrorInfo.Message = "IdentityCode5 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCode6 <> "" Then
            Try
                varmi = kimliktur_erisim.kimlikturkodvarmi(Info.IdentityCode6)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityCode6 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 455
                ErrorInfo.Message = "IdentityCode6 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If




        Dim ulke_erisim As New CLASSULKE_ERISIM
        If Info.IdentityCountryCode1 <> "" Then
            Try
                varmi = ulke_erisim.ulkekodvarmi(Info.IdentityCountryCode1)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityCountryCode1 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 456
                ErrorInfo.Message = "IdentityCountryCode1 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCountryCode2 <> "" Then
            Try
                varmi = ulke_erisim.ulkekodvarmi(Info.IdentityCountryCode2)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityCountryCode2 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 456
                ErrorInfo.Message = "IdentityCountryCode2 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCountryCode3 <> "" Then
            Try
                varmi = ulke_erisim.ulkekodvarmi(Info.IdentityCountryCode3)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityCountryCode3 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 456
                ErrorInfo.Message = "IdentityCountryCode3 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCountryCode4 <> "" Then
            Try
                varmi = ulke_erisim.ulkekodvarmi(Info.IdentityCountryCode4)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityCountryCode4 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 456
                ErrorInfo.Message = "IdentityCountryCode4 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCountryCode5 <> "" Then
            Try
                varmi = ulke_erisim.ulkekodvarmi(Info.IdentityCountryCode5)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityCountryCode5 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 456
                ErrorInfo.Message = "IdentityCountryCode5 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If
        If Info.IdentityCountryCode6 <> "" Then
            Try
                varmi = ulke_erisim.ulkekodvarmi(Info.IdentityCountryCode6)
                If varmi = "Hayır" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityCountryCode6 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            Catch ex As Exception
                root.ResultCode = 0
                ErrorInfo.Code = 456
                ErrorInfo.Message = "IdentityCountryCode6 KKSBM tarafından tanımlanmamış."
                root.ErrorInfo = ErrorInfo
                Return root
            End Try
        End If


        Return root

    End Function


   

End Class
