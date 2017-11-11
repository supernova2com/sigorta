Public Class PolicyInfoServiceKontrol_Erisim


    Public Function kombinasyonkontrol(ByVal PolicyInfo As PolicyInfo) As root

        Dim root As New root
        Dim ErrorInfo As New ErrorInfo
        Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM

        root.ResultCode = 1

        If PolicyInfo.AuthorizedDrivers = "N" Then

            'kimlik numarası girildi fakat diğerleri eksik.
            If PolicyInfo.IdentityNo1 <> "" Then

                If PolicyInfo.IdentityCode1 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode1 = "KN" Or PolicyInfo.IdentityCode1 = "PN" Then
                    If PolicyInfo.CountryCode1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.Name1 = "" Or PolicyInfo.Surname1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityCode1,BirthDate1,Name1,Surname1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode1 <> "KN" And PolicyInfo.IdentityCode1 <> "PN" Then
                    If PolicyInfo.CountryCode1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                   PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.Name1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityCode1,BirthDate1,Name1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.IdentityNo2 <> "" Then

                If PolicyInfo.IdentityCode2 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode2 = "KN" Or PolicyInfo.IdentityCode2 = "PN" Then
                    If PolicyInfo.CountryCode2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                      PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.Name2 = "" Or PolicyInfo.Surname2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityCode2,BirthDate2,Name2,Surname2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode2 <> "KN" And PolicyInfo.IdentityCode2 <> "PN" Then
                    If PolicyInfo.CountryCode2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                      PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.Name2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityCode2,BirthDate2,Name2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.IdentityNo3 <> "" Then

                If PolicyInfo.IdentityCode3 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode3 = "KN" Or PolicyInfo.IdentityCode3 = "PN" Then
                    If PolicyInfo.CountryCode3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.Name3 = "" Or PolicyInfo.Surname3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityCode3,BirthDate3,Name3,Surname3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode3 <> "KN" And PolicyInfo.IdentityCode3 <> "PN" Then
                    If PolicyInfo.CountryCode3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.Name3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityCode3,BirthDate3,Name3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.IdentityNo4 <> "" Then

                If PolicyInfo.IdentityCode4 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode4 = "KN" Or PolicyInfo.IdentityCode4 = "PN" Then
                    If PolicyInfo.CountryCode4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.Name4 = "" Or PolicyInfo.Surname4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityCode4,BirthDate4,Name4,Surname4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode4 <> "KN" And PolicyInfo.IdentityCode4 <> "PN" Then
                    If PolicyInfo.CountryCode4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.Name4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityCode4,BirthDate4,Name4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.IdentityNo5 <> "" Then

                If PolicyInfo.IdentityCode5 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode5 = "KN" Or PolicyInfo.IdentityCode5 = "PN" Then
                    If PolicyInfo.CountryCode5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                       PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.Name5 = "" Or PolicyInfo.Surname5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " CountryCode5,IdentityCode5,BirthDate5,Name5,Surname5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode5 <> "KN" And PolicyInfo.IdentityCode5 <> "PN" Then
                    If PolicyInfo.IdentityCode5 = "KN" Or PolicyInfo.IdentityCode5 = "PN" Then
                        If PolicyInfo.CountryCode5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                           PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.Name5 = "" Then
                            root.ResultCode = 0
                            ErrorInfo.Code = 451
                            ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                            " CountryCode5,IdentityCode5,BirthDate5,Name5"
                            root.ErrorInfo = ErrorInfo
                            Return root
                        End If
                    End If
                End If


            End If

            If PolicyInfo.IdentityNo6 <> "" Then

                If PolicyInfo.IdentityCode6 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 451
                    ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode6 = "KN" Or PolicyInfo.IdentityCode6 = "PN" Then
                    If PolicyInfo.CountryCode6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                       PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.Name6 = "" Or PolicyInfo.Surname6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityCode6,BirthDate6,Name6,Surname6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode6 <> "KN" And PolicyInfo.IdentityCode6 <> "PN" Then
                    If PolicyInfo.CountryCode6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                       PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.Name6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 451
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityCode6,BirthDate6,Name6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If



            'CountryCode girilmiş digerleri eksik
            If PolicyInfo.CountryCode1 <> "" Then

                If PolicyInfo.IdentityCode1 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode1 = "KN" Or PolicyInfo.IdentityCode1 = "PN" Then
                    If PolicyInfo.IdentityNo1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.Name1 = "" Or PolicyInfo.Surname1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo1,IdentityCode1,BirthDate1,Name1,Surname1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If


                If PolicyInfo.IdentityCode1 <> "KN" And PolicyInfo.IdentityCode1 <> "PN" Then
                    If PolicyInfo.IdentityNo1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.Name1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo1,IdentityCode1,BirthDate1,Name1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.CountryCode2 <> "" Then

                If PolicyInfo.IdentityCode2 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode2 = "KN" Or PolicyInfo.IdentityCode2 = "PN" Then
                    If PolicyInfo.IdentityNo2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                    PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.Name2 = "" Or PolicyInfo.Surname2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo2,IdentityCode2,BirthDate2,Name2,Surname2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode2 <> "KN" And PolicyInfo.IdentityCode2 <> "PN" Then
                    If PolicyInfo.IdentityNo2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                    PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.Name2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo2,IdentityCode2,BirthDate2,Name2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.CountryCode3 <> "" Then

                If PolicyInfo.IdentityCode3 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode3 = "KN" Or PolicyInfo.IdentityCode3 = "PN" Then
                    If PolicyInfo.IdentityNo3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.Name3 = "" Or PolicyInfo.Surname3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo3,IdentityCode3,BirthDate3,Name3,Surname3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode3 <> "KN" And PolicyInfo.IdentityCode3 <> "PN" Then
                    If PolicyInfo.IdentityNo3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.Name3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo3,IdentityCode3,BirthDate3,Name3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.CountryCode4 <> "" Then

                If PolicyInfo.IdentityCode4 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode4 = "KN" Or PolicyInfo.IdentityCode4 = "PN" Then
                    If PolicyInfo.IdentityNo4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.Name4 = "" Or PolicyInfo.Surname4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                      " IdentityNo4,IdentityCode4,BirthDate4,Name4,Surname4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode4 <> "KN" And PolicyInfo.IdentityCode4 <> "PN" Then
                    If PolicyInfo.IdentityNo4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.Name4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                      " IdentityNo4,IdentityCode4,BirthDate4,Name4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.CountryCode5 <> "" Then

                If PolicyInfo.IdentityCode5 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode5 = "KN" Or PolicyInfo.IdentityCode5 = "PN" Then
                    If PolicyInfo.IdentityNo5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                     PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.Name5 = "" Or PolicyInfo.Surname5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo5,IdentityCode5,BirthDate5,Name5,Surname5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode5 <> "KN" And PolicyInfo.IdentityCode5 <> "PN" Then
                    If PolicyInfo.IdentityNo5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                     PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.Name5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo5,IdentityCode5,BirthDate5,Name5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.CountryCode6 <> "" Then

                If PolicyInfo.IdentityCode6 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 452
                    ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode6 = "KN" Or PolicyInfo.IdentityCode6 = "PN" Then
                    If PolicyInfo.IdentityNo6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                     PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.Name6 = "" Or PolicyInfo.Surname6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo6,IdentityCode6,BirthDate6,Name6,Surname6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode6 <> "KN" And PolicyInfo.IdentityCode6 <> "PN" Then
                    If PolicyInfo.IdentityNo6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                     PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.Name6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 452
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo6,IdentityCode6,BirthDate6,Name6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If



            'IdentityCode girilmiş fakat diğerleri eksik
            If PolicyInfo.IdentityCode1 <> "" Then

                If PolicyInfo.IdentityCode1 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 453
                    ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode1 = "KN" Or PolicyInfo.IdentityCode1 = "PN" Then
                    If PolicyInfo.IdentityNo1 = "" Or PolicyInfo.CountryCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.Name1 = "" Or PolicyInfo.Surname1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo1,CountryCode1,IdentityBirthDate1,Name1,Surname1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode1 <> "KN" And PolicyInfo.IdentityCode1 <> "PN" Then
                    If PolicyInfo.IdentityNo1 = "" Or PolicyInfo.CountryCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.Name1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo1,CountryCode1,IdentityBirthDate1,Name1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.IdentityCode2 <> "" Then

                If PolicyInfo.IdentityCode2 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 453
                    ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode2 = "KN" Or PolicyInfo.IdentityCode2 = "PN" Then
                    If PolicyInfo.IdentityNo2 = "" Or PolicyInfo.CountryCode2 = "" Or _
                    PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.Name2 = "" Or PolicyInfo.Surname2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo2,CountryCode2,IdentityBirthDate2,Name2,Surname2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode2 <> "KN" And PolicyInfo.IdentityCode2 <> "PN" Then
                    If PolicyInfo.IdentityNo2 = "" Or PolicyInfo.CountryCode2 = "" Or _
                    PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.Name2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo2,CountryCode2,IdentityBirthDate2,Name2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.IdentityCode3 <> "" Then

                If PolicyInfo.IdentityCode3 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 453
                    ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode3 = "KN" Or PolicyInfo.IdentityCode3 = "PN" Then
                    If PolicyInfo.IdentityNo3 = "" Or PolicyInfo.CountryCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.Name3 = "" Or PolicyInfo.Surname3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo3,CountryCode3,IdentityBirthDate3,Name3,Surname3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode3 <> "KN" And PolicyInfo.IdentityCode3 <> "PN" Then
                    If PolicyInfo.IdentityNo3 = "" Or PolicyInfo.CountryCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.Name3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo3,CountryCode3,IdentityBirthDate3,Name3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.IdentityCode4 <> "" Then

                If PolicyInfo.IdentityCode4 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 453
                    ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode4 = "KN" Or PolicyInfo.IdentityCode4 = "PN" Then
                    If PolicyInfo.IdentityNo4 = "" Or PolicyInfo.CountryCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.Name4 = "" Or PolicyInfo.Surname4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo4,CountryCode4,IdentityBirthDate4,Name4,Surname4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode4 <> "KN" And PolicyInfo.IdentityCode4 <> "PN" Then
                    If PolicyInfo.IdentityNo4 = "" Or PolicyInfo.CountryCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.Name4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo4,CountryCode4,IdentityBirthDate4,Name4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.IdentityCode5 <> "" Then

                If PolicyInfo.IdentityCode5 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 453
                    ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode5 = "KN" Or PolicyInfo.IdentityCode5 = "PN" Then
                    If PolicyInfo.IdentityNo5 = "" Or PolicyInfo.CountryCode5 = "" Or _
                    PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.Name5 = "" Or PolicyInfo.Surname5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo5,CountryCode5,IdentityBirthDate5,Name5,Surname5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode5 <> "KN" And PolicyInfo.IdentityCode5 <> "PN" Then
                    If PolicyInfo.IdentityNo5 = "" Or PolicyInfo.CountryCode5 = "" Or _
                    PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.Name5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo5,CountryCode5,IdentityBirthDate5,Name5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.IdentityCode6 <> "" Then

                If PolicyInfo.IdentityCode6 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 453
                    ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode6 = "KN" Or PolicyInfo.IdentityCode6 = "PN" Then
                    If PolicyInfo.IdentityNo6 = "" Or PolicyInfo.CountryCode6 = "" Or _
                    PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.Name6 = "" Or PolicyInfo.Surname6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo6,CountryCode6,IdentityBirthDate6,Name6,Surname6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode6 <> "KN" And PolicyInfo.IdentityCode6 <> "PN" Then
                    If PolicyInfo.IdentityNo6 = "" Or PolicyInfo.CountryCode6 = "" Or _
                    PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.Name6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 453
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " IdentityNo6,CountryCode6,IdentityBirthDate6,Name6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If



            'BirthDate girilmiş fakat diğerleri girilmemiş
            If Not PolicyInfo.BirthDate1 Is Nothing Then

                If PolicyInfo.IdentityCode1 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 454
                    ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode1 = "KN" Or PolicyInfo.IdentityCode1 = "PN" Then
                    If PolicyInfo.IdentityNo1 = "" Or PolicyInfo.CountryCode1 = "" Or _
                    PolicyInfo.IdentityCode1 = "" Or PolicyInfo.Name1 = "" Or PolicyInfo.Surname1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityNo1,IdentityCode1,Name1,Surname1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode1 <> "KN" And PolicyInfo.IdentityCode1 <> "PN" Then
                    If PolicyInfo.IdentityNo1 = "" Or PolicyInfo.CountryCode1 = "" Or _
                    PolicyInfo.IdentityCode1 = "" Or PolicyInfo.Name1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityNo1,IdentityCode1,Name1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If Not PolicyInfo.BirthDate2 Is Nothing Then

                If PolicyInfo.IdentityCode2 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 454
                    ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode2 = "KN" Or PolicyInfo.IdentityCode2 = "PN" Then
                    If PolicyInfo.IdentityNo2 = "" Or PolicyInfo.CountryCode2 = "" Or _
                    PolicyInfo.IdentityCode2 = "" Or PolicyInfo.Name2 = "" Or PolicyInfo.Surname2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityNo2,IdentityCode2,Name2,Surname2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode2 <> "KN" And PolicyInfo.IdentityCode2 <> "PN" Then
                    If PolicyInfo.IdentityNo2 = "" Or PolicyInfo.CountryCode2 = "" Or _
                    PolicyInfo.IdentityCode2 = "" Or PolicyInfo.Name2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityNo2,IdentityCode2,Name2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If Not PolicyInfo.BirthDate3 Is Nothing Then

                If PolicyInfo.IdentityCode3 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 454
                    ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode3 = "KN" Or PolicyInfo.IdentityCode3 = "PN" Then
                    If PolicyInfo.IdentityNo3 = "" Or PolicyInfo.CountryCode3 = "" Or _
                    PolicyInfo.IdentityCode3 = "" Or PolicyInfo.Name3 = "" Or PolicyInfo.Surname3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityNo3,IdentityCode3,Name2,Surname2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode3 <> "KN" And PolicyInfo.IdentityCode3 <> "PN" Then
                    If PolicyInfo.IdentityNo3 = "" Or PolicyInfo.CountryCode3 = "" Or _
                    PolicyInfo.IdentityCode3 = "" Or PolicyInfo.Name3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityNo3,IdentityCode3,Name2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If Not PolicyInfo.BirthDate4 Is Nothing Then

                If PolicyInfo.IdentityCode4 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 454
                    ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode4 = "KN" Or PolicyInfo.IdentityCode4 = "PN" Then
                    If PolicyInfo.IdentityNo4 = "" Or PolicyInfo.CountryCode4 = "" Or _
                    PolicyInfo.IdentityCode4 = "" Or PolicyInfo.Name4 = "" Or PolicyInfo.Surname4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityNo4,IdentityCode4,Name4,Surname4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode4 <> "KN" And PolicyInfo.IdentityCode4 <> "PN" Then
                    If PolicyInfo.IdentityNo4 = "" Or PolicyInfo.CountryCode4 = "" Or _
                    PolicyInfo.IdentityCode4 = "" Or PolicyInfo.Name4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityNo4,IdentityCode4,Name4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If



            If Not PolicyInfo.BirthDate5 Is Nothing Then

                If PolicyInfo.IdentityCode5 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 454
                    ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode5 = "KN" Or PolicyInfo.IdentityCode5 = "PN" Then
                    If PolicyInfo.IdentityNo5 = "" Or PolicyInfo.CountryCode5 = "" Or _
                    PolicyInfo.IdentityCode5 = "" Or PolicyInfo.Name5 = "" Or PolicyInfo.Surname5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " CountryCode5,IdentityNo5,IdentityCode5,Name5,Surname5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode5 <> "KN" And PolicyInfo.IdentityCode5 <> "PN" Then
                    If PolicyInfo.IdentityNo5 = "" Or PolicyInfo.CountryCode5 = "" Or _
                    PolicyInfo.IdentityCode5 = "" Or PolicyInfo.Name5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " CountryCode5,IdentityNo5,IdentityCode5,Name5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If Not PolicyInfo.BirthDate6 Is Nothing Then

                If PolicyInfo.IdentityCode6 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 454
                    ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode6 = "KN" Or PolicyInfo.IdentityCode6 = "PN" Then
                    If PolicyInfo.IdentityNo6 = "" Or PolicyInfo.CountryCode6 = "" Or _
                    PolicyInfo.IdentityCode6 = "" Or PolicyInfo.Name6 = "" Or PolicyInfo.Surname6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityNo6,IdentityCode6,Name6,Surname6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode6 <> "KN" And PolicyInfo.IdentityCode6 <> "PN" Then
                    If PolicyInfo.IdentityNo6 = "" Or PolicyInfo.CountryCode6 = "" Or _
                    PolicyInfo.IdentityCode6 = "" Or PolicyInfo.Name6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 454
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityNo6,IdentityCode6,Name6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If




            'name1 girilmiş diğerleri eksik
            If PolicyInfo.Name1 <> "" Then

                If PolicyInfo.IdentityCode1 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode1 = "KN" Or PolicyInfo.IdentityCode1 = "PN" Then
                    If PolicyInfo.CountryCode1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.IdentityNo1 = "" Or PolicyInfo.Surname1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityCode1,BirthDate1,IdentityNo1,Surname1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode1 <> "KN" And PolicyInfo.IdentityCode1 <> "PN" Then
                    If PolicyInfo.CountryCode1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.IdentityNo1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityCode1,BirthDate1,IdentityNo1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.Name2 <> "" Then

                If PolicyInfo.IdentityCode2 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode2 = "KN" Or PolicyInfo.IdentityCode2 = "PN" Then
                    If PolicyInfo.CountryCode2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                      PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.IdentityNo2 = "" Or PolicyInfo.Surname2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityCode2,BirthDate2,IdentityNo2,Surname2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode2 <> "KN" And PolicyInfo.IdentityCode2 <> "PN" Then
                    If PolicyInfo.CountryCode2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                      PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.IdentityNo2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityCode2,BirthDate2,IdentityNo2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.Name3 <> "" Then

                If PolicyInfo.IdentityCode3 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode3 = "KN" Or PolicyInfo.IdentityCode3 = "PN" Then
                    If PolicyInfo.CountryCode3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.IdentityNo3 = "" Or PolicyInfo.Surname3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityCode3,BirthDate3,IdentityNo3,Surname3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode3 <> "KN" And PolicyInfo.IdentityCode3 <> "PN" Then
                    If PolicyInfo.CountryCode3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.IdentityNo3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityCode3,BirthDate3,IdentityNo3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.Name4 <> "" Then

                If PolicyInfo.IdentityCode4 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode4 = "KN" Or PolicyInfo.IdentityCode4 = "PN" Then
                    If PolicyInfo.CountryCode4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.IdentityNo4 = "" Or PolicyInfo.Surname4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityCode4,BirthDate4,IdentityNo4,Surname4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode4 <> "KN" And PolicyInfo.IdentityCode4 <> "PN" Then
                    If PolicyInfo.CountryCode4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.IdentityNo4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityCode4,BirthDate4,IdentityNo4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.Name5 <> "" Then

                If PolicyInfo.IdentityCode5 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode5 = "KN" Or PolicyInfo.IdentityCode5 = "PN" Then
                    If PolicyInfo.CountryCode5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                       PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.IdentityNo5 = "" Or PolicyInfo.Surname5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " CountryCode5,IdentityCode5,BirthDate5,IdentityNo5,Surname5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If


                If PolicyInfo.IdentityCode5 <> "KN" And PolicyInfo.IdentityCode5 <> "PN" Then
                    If PolicyInfo.CountryCode5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                       PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.IdentityNo5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " CountryCode5,IdentityCode5,BirthDate5,IdentityNo5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.Name6 <> "" Then

                If PolicyInfo.IdentityCode6 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 455
                    ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode6 = "KN" Or PolicyInfo.IdentityCode6 = "PN" Then
                    If PolicyInfo.CountryCode6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                       PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.IdentityNo6 = "" Or PolicyInfo.Surname6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityCode6,BirthDate6,IdentityNo6,Surname6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode6 <> "KN" And PolicyInfo.IdentityCode6 <> "PN" Then
                    If PolicyInfo.CountryCode6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                       PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.IdentityNo6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 455
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityCode6,BirthDate6,IdentityNo6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            'surname1 girilmiş diğerleri eksik
            If PolicyInfo.Surname1 <> "" Then

                If PolicyInfo.IdentityCode1 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode1"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode1 = "KN" Or PolicyInfo.IdentityCode1 = "PN" Then
                    If PolicyInfo.CountryCode1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.IdentityNo1 = "" Or PolicyInfo.Name1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityCode1,BirthDate1,IdentityNo1,Name1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode1 <> "KN" And PolicyInfo.IdentityCode1 <> "PN" Then
                    If PolicyInfo.CountryCode1 = "" Or PolicyInfo.IdentityCode1 = "" Or _
                    PolicyInfo.BirthDate1 Is Nothing Or PolicyInfo.IdentityNo1 = "" Or PolicyInfo.Name1 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo1 için tüm veriler tam gönderilmedi." + _
                        " CountryCode1,IdentityCode1,BirthDate1,IdentityNo1,Name1"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.Surname2 <> "" Then

                If PolicyInfo.IdentityCode2 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode2"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode2 = "KN" Or PolicyInfo.IdentityCode2 = "PN" Then
                    If PolicyInfo.CountryCode2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                      PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.IdentityNo2 = "" Or PolicyInfo.Name2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityCode2,BirthDate2,IdentityNo2,Name2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If


                If PolicyInfo.IdentityCode2 <> "KN" And PolicyInfo.IdentityCode2 <> "PN" Then
                    If PolicyInfo.CountryCode2 = "" Or PolicyInfo.IdentityCode2 = "" Or _
                      PolicyInfo.BirthDate2 Is Nothing Or PolicyInfo.IdentityNo2 = "" Or PolicyInfo.Name2 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo2 için tüm veriler tam gönderilmedi." + _
                        " CountryCode2,IdentityCode2,BirthDate2,IdentityNo2,Name2"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.Surname3 <> "" Then

                If PolicyInfo.IdentityCode3 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode3"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode3 = "KN" Or PolicyInfo.IdentityCode3 = "PN" Then
                    If PolicyInfo.CountryCode3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.IdentityNo3 = "" Or PolicyInfo.Name3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityCode3,BirthDate3,IdentityNo3,Name3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode3 <> "KN" And PolicyInfo.IdentityCode3 <> "PN" Then
                    If PolicyInfo.CountryCode3 = "" Or PolicyInfo.IdentityCode3 = "" Or _
                    PolicyInfo.BirthDate3 Is Nothing Or PolicyInfo.IdentityNo3 = "" Or PolicyInfo.Name3 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo3 için tüm veriler tam gönderilmedi." + _
                        " CountryCode3,IdentityCode3,BirthDate3,IdentityNo3,Name3"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.Surname4 <> "" Then

                If PolicyInfo.IdentityCode4 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode4"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode4 = "KN" Or PolicyInfo.IdentityCode4 = "PN" Then
                    If PolicyInfo.CountryCode4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.IdentityNo4 = "" Or PolicyInfo.Name4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityCode4,BirthDate4,IdentityNo4,Name4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode4 <> "KN" And PolicyInfo.IdentityCode4 <> "PN" Then
                    If PolicyInfo.CountryCode4 = "" Or PolicyInfo.IdentityCode4 = "" Or _
                    PolicyInfo.BirthDate4 Is Nothing Or PolicyInfo.IdentityNo4 = "" Or PolicyInfo.Name4 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo4 için tüm veriler tam gönderilmedi." + _
                        " CountryCode4,IdentityCode4,BirthDate4,IdentityNo4,Name4"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            If PolicyInfo.Surname5 <> "" Then

                If PolicyInfo.IdentityCode5 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode5"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode5 = "KN" Or PolicyInfo.IdentityCode5 = "PN" Then
                    If PolicyInfo.CountryCode5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                       PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.IdentityNo5 = "" Or PolicyInfo.Name5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " CountryCode5,IdentityCode5,BirthDate5,IdentityNo5,Name5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode5 <> "KN" And PolicyInfo.IdentityCode5 <> "PN" Then
                    If PolicyInfo.CountryCode5 = "" Or PolicyInfo.IdentityCode5 = "" Or _
                       PolicyInfo.BirthDate5 Is Nothing Or PolicyInfo.IdentityNo5 = "" Or PolicyInfo.Name5 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo5 için tüm veriler tam gönderilmedi." + _
                        " CountryCode5,IdentityCode5,BirthDate5,IdentityNo5,Name5"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If

            If PolicyInfo.Surname6 <> "" Then

                If PolicyInfo.IdentityCode6 = "" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 456
                    ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                    "IdentityCode6"
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

                If PolicyInfo.IdentityCode6 = "KN" Or PolicyInfo.IdentityCode6 = "PN" Then
                    If PolicyInfo.CountryCode6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                       PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.IdentityNo6 = "" Or PolicyInfo.Name6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityCode6,BirthDate6,IdentityNo6,Name6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

                If PolicyInfo.IdentityCode6 <> "KN" And PolicyInfo.IdentityCode6 <> "PN" Then
                    If PolicyInfo.CountryCode6 = "" Or PolicyInfo.IdentityCode6 = "" Or _
                       PolicyInfo.BirthDate6 Is Nothing Or PolicyInfo.IdentityNo6 = "" Or PolicyInfo.Name6 = "" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 456
                        ErrorInfo.Message = "IdentityNo6 için tüm veriler tam gönderilmedi." + _
                        " CountryCode6,IdentityCode6,BirthDate6,IdentityNo6,Name6"
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                End If

            End If


            Dim kimliktur_erisim As New CLASSKIMLIKTUR_ERISIM
            Dim varmi As String = "Evet"
            If PolicyInfo.IdentityCode1 <> "" Then
                Try
                    varmi = kimliktur_erisim.kimlikturkodvarmi(PolicyInfo.IdentityCode1)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 457
                        ErrorInfo.Message = "IdentityCode1 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 457
                    ErrorInfo.Message = "IdentityCode1 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.IdentityCode2 <> "" Then
                Try
                    varmi = kimliktur_erisim.kimlikturkodvarmi(PolicyInfo.IdentityCode2)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 457
                        ErrorInfo.Message = "IdentityCode2 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 457
                    ErrorInfo.Message = "IdentityCode2 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.IdentityCode3 <> "" Then
                Try
                    varmi = kimliktur_erisim.kimlikturkodvarmi(PolicyInfo.IdentityCode3)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 457
                        ErrorInfo.Message = "IdentityCode3 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 457
                    ErrorInfo.Message = "IdentityCode3 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.IdentityCode4 <> "" Then
                Try
                    varmi = kimliktur_erisim.kimlikturkodvarmi(PolicyInfo.IdentityCode4)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 457
                        ErrorInfo.Message = "IdentityCode4 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 457
                    ErrorInfo.Message = "IdentityCode4 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.IdentityCode5 <> "" Then
                Try
                    varmi = kimliktur_erisim.kimlikturkodvarmi(PolicyInfo.IdentityCode5)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 457
                        ErrorInfo.Message = "IdentityCode5 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 457
                    ErrorInfo.Message = "IdentityCode5 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.IdentityCode6 <> "" Then
                Try
                    varmi = kimliktur_erisim.kimlikturkodvarmi(PolicyInfo.IdentityCode6)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 457
                        ErrorInfo.Message = "IdentityCode6 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 457
                    ErrorInfo.Message = "IdentityCode6 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If



            Dim ulke_erisim As New CLASSULKE_ERISIM
            If PolicyInfo.CountryCode1 <> "" Then
                Try
                    varmi = ulke_erisim.ulkekodvarmi(PolicyInfo.CountryCode1)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 458
                        ErrorInfo.Message = "CountryCode1 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 458
                    ErrorInfo.Message = "CountryCode1 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.CountryCode2 <> "" Then
                Try
                    varmi = ulke_erisim.ulkekodvarmi(PolicyInfo.CountryCode2)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 458
                        ErrorInfo.Message = "CountryCode2 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 458
                    ErrorInfo.Message = "CountryCode2 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.CountryCode3 <> "" Then
                Try
                    varmi = ulke_erisim.ulkekodvarmi(PolicyInfo.CountryCode3)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 458
                        ErrorInfo.Message = "CountryCode3 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 458
                    ErrorInfo.Message = "CountryCode3 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.CountryCode4 <> "" Then
                Try
                    varmi = ulke_erisim.ulkekodvarmi(PolicyInfo.CountryCode4)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 458
                        ErrorInfo.Message = "CountryCode4 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 458
                    ErrorInfo.Message = "CountryCode4 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.CountryCode5 <> "" Then
                Try
                    varmi = ulke_erisim.ulkekodvarmi(PolicyInfo.CountryCode5)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 458
                        ErrorInfo.Message = "CountryCode5 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 458
                    ErrorInfo.Message = "CountryCode5 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If
            If PolicyInfo.CountryCode6 <> "" Then
                Try
                    varmi = ulke_erisim.ulkekodvarmi(PolicyInfo.CountryCode6)
                    If varmi = "Hayır" Then
                        root.ResultCode = 0
                        ErrorInfo.Code = 458
                        ErrorInfo.Message = "CountryCode6 KKSBM tarafından tanımlanmamış."
                        root.ErrorInfo = ErrorInfo
                        Return root
                    End If
                Catch ex As Exception
                    root.ResultCode = 0
                    ErrorInfo.Code = 458
                    ErrorInfo.Message = "CountryCode6 KKSBM tarafından tanımlanmamış."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End Try
            End If


            'NameDriver da IdentityCode sadece KN yada PN olabilir.
            If PolicyInfo.IdentityCode1 <> "" Then
                If PolicyInfo.IdentityCode1 <> "KN" And PolicyInfo.IdentityCode1 <> "PN" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 459
                    ErrorInfo.Message = "NameDriver olan poliçelerde IdentityCode1 KN yada PN olmalıdır."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.IdentityCode2 <> "" Then
                If PolicyInfo.IdentityCode2 <> "KN" And PolicyInfo.IdentityCode2 <> "PN" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 459
                    ErrorInfo.Message = "NameDriver olan poliçelerde IdentityCode2 KN yada PN olmalıdır."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.IdentityCode3 <> "" Then
                If PolicyInfo.IdentityCode3 <> "KN" And PolicyInfo.IdentityCode3 <> "PN" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 459
                    ErrorInfo.Message = "NameDriver olan poliçelerde IdentityCode3 KN yada PN olmalıdır."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.IdentityCode4 <> "" Then
                If PolicyInfo.IdentityCode4 <> "KN" And PolicyInfo.IdentityCode4 <> "PN" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 459
                    ErrorInfo.Message = "NameDriver olan poliçelerde IdentityCode4 KN yada PN olmalıdır."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.IdentityCode5 <> "" Then
                If PolicyInfo.IdentityCode5 <> "KN" And PolicyInfo.IdentityCode5 <> "PN" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 459
                    ErrorInfo.Message = "NameDriver olan poliçelerde IdentityCode5 KN yada PN olmalıdır."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If
            End If
            If PolicyInfo.IdentityCode6 <> "" Then
                If PolicyInfo.IdentityCode6 <> "KN" And PolicyInfo.IdentityCode6 <> "PN" Then
                    root.ResultCode = 0
                    ErrorInfo.Code = 459
                    ErrorInfo.Message = "NameDriver olan poliçelerde IdentityCode6 KN yada PN olmalıdır."
                    root.ErrorInfo = ErrorInfo
                    Return root
                End If

            End If

        End If 'NAME DRIVER OLANLAR


        Return root

    End Function

End Class
