Public Class CLASSPLAKAKONTROL_ERISIM


    Public Function ilkkayitplakasimi(ByVal PlateNumber As String) As String

        Dim rakamkismi As String
        Dim ilkkayit_plakasimi = "Evet"

        If Len(PlateNumber) <> 5 Then
            ilkkayit_plakasimi = "Hayır"
        End If

        If Mid(PlateNumber, 1, 2) <> "TR" Then
            ilkkayit_plakasimi = "Hayır"
        End If

        If ilkkayit_plakasimi = "Evet" Then
            rakamkismi = Mid(PlateNumber, 3, 3)
            If rakamkismi = False Then
                ilkkayit_plakasimi = "Hayır"
            End If
        End If

        Return ilkkayit_plakasimi


    End Function


    Public Function plakakontrolbasit(ByVal TariffCode As String, ByVal kplaka As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        Dim r As Regex = New Regex("^[a-zA-Zİ0-9]*$")

        If kplaka = "" Then
            result.durum = "Hata Var"
            result.etkilenen = 0
            result.hatastr = "Plaka boş olmamalıdır."
            Return result
        End If

        If TariffCode = "CZ801" Then
            result.durum = "Hata Yok"
            result.etkilenen = 1
            result.hatastr = ""
            Return result
        End If

        If r.IsMatch(kplaka) = True Then
            result.durum = "Hata Yok"
            result.etkilenen = 1
            result.hatastr = ""
            Return result
        End If

        If r.IsMatch(kplaka) = False Then
            result.durum = "Hata Var"
            result.etkilenen = 0
            result.hatastr = "Plaka sadece harf ve rakamlardan oluşmalıdır."
            Return result
        End If

    End Function


    Public Function plakakontrolkktcplaka(ByVal kplaka As String, ByVal PolicyInfo As PolicyInfo) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        result.durum = "Hata Yok"
        result.etkilenen = 1
        result.hatastr = ""

        'BAZI PLAKALAR ŞASE NUMARASINA GÖRE KAYDEDİLİYOR BUNLARI KONTROLA SOKMA
        If Len(kplaka) > 8 Then
            result.durum = "Hata Yok"
            result.etkilenen = 1
            result.hatastr = ""
            Return result
        End If

        'CZ801 için kontrole sokma
        If PolicyInfo.TariffCode = "CZ801" Then
            result.durum = "Hata Yok"
            result.etkilenen = 1
            result.hatastr = ""
            Return result
        End If

        'kontrola sokma
        If PolicyInfo.PolicyType = 3 Then
            result.durum = "Hata Yok"
            result.etkilenen = 1
            result.hatastr = ""
            Return result
        End If

        'policytype 1 ve CZ9 ise kontrole sokma
        If PolicyInfo.PolicyType = 1 And PolicyInfo.TariffCode = "CZ9" Then
            result.durum = "Hata Yok"
            result.etkilenen = 1
            result.hatastr = ""
            Return result
        End If

        'TAKSİ, KİRALIK, DEVLET ARACI İSE KONTROL 
        If Mid(kplaka, 1, 1) = "T" Or Mid(kplaka, 1, 1) = "Z" Or Mid(kplaka, 1, 1) = "R" Or plakaninsonharfi(kplaka) = "Z" Then
            If harfsayisi(kplaka) > 3 Then
                result.durum = "Hata Var"
                result.etkilenen = 0
                result.hatastr = "Başında T veya Z veya R olan veya sonunda Z olan plakalarda en fazla 3 harf olmalıdır."
                Return result
            End If
        End If

        'NORMAL PLAKALAR EN FAZLA 2 HARF OLABİLİR
        If Mid(kplaka, 1, 1) <> "T" And Mid(kplaka, 1, 1) <> "Z" And Mid(kplaka, 1, 1) <> "R" And plakaninsonharfi(kplaka) <> "Z" Then
            If harfsayisi(kplaka) > 2 Then
                result.durum = "Hata Var"
                result.etkilenen = 0
                result.hatastr = "Normal plakalarda en fazla 2 harf olmalıdır."
                Return result
            End If
        End If

        Return result

    End Function


    Public Function plakakontrolrumplaka(ByVal kplaka As String, ByVal PolicyInfo As PolicyInfo) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        result.durum = "Hata Yok"
        result.etkilenen = 1
        result.hatastr = ""


        'BAŞINDA UN OLURSA KONTROLA SOKMA
        If Mid(kplaka, 1, 2) = "UN" Then
            Return result
        End If

        'BAŞINDA UNDP OLURSA KONTROLA SOKMA
        If Mid(kplaka, 1, 4) = "UNDP" Then
            Return result
        End If

        'BAŞINDA UNCMP OLURSA KONTROLA SOKMA
        If Mid(kplaka, 1, 5) = "UNCMP" Then
            Return result
        End If


        'TAKSİ, KİRALIK İSE KONTROL 
        If Mid(kplaka, 1, 1) = "T" Or Mid(kplaka, 1, 1) = "Z" Then
            If harfsayisi(kplaka) > 4 Then
                result.durum = "Hata Var"
                result.etkilenen = 0
                result.hatastr = "Başında T veya Z olan plakalarda en fazla 4 harf olmalıdır."
                Return result
            End If
        End If

        'NORMAL PLAKALAR EN FAZLA 3 HARF OLABİLİR
        If Mid(kplaka, 1, 1) <> "T" And Mid(kplaka, 1, 1) <> "Z" Then
            If harfsayisi(kplaka) > 3 Then
                result.durum = "Hata Var"
                result.etkilenen = 0
                result.hatastr = "Normal plakalarda en fazla 3 harf olmalıdır."
                Return result
            End If
        End If

        Return result

    End Function



    Public Function plakakontroldiger(ByVal kplaka As String, ByVal PolicyInfo As PolicyInfo) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        result.durum = "Hata Yok"
        result.etkilenen = 1
        result.hatastr = ""

        'TAKSİ, KİRALIK İSE KONTROL 
        If Mid(kplaka, 1, 1) = "T" Or Mid(kplaka, 1, 1) = "Z" Then
            If harfsayisi(kplaka) > 4 Then
                result.durum = "Hata Var"
                result.etkilenen = 0
                result.hatastr = "Başında T veya Z olan plakalarda en fazla 4 harf olmalıdır."
                Return result
            End If
        End If

        'NORMAL PLAKALAR EN FAZLA 3 HARF OLABİLİR
        If Mid(kplaka, 1, 1) <> "T" And Mid(kplaka, 1, 1) <> "Z" Then
            If harfsayisi(kplaka) > 3 Then
                result.durum = "Hata Var"
                result.etkilenen = 0
                result.hatastr = "Normal plakalarda en fazla 3 harf olmalıdır."
                Return result
            End If
        End If

        Return result

    End Function


    Public Function plakakontrol_servisayar(ByVal PolicyType As Integer, ByVal kplaka As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT
        result.durum = "Hata Yok"
        result.etkilenen = 1
        result.hatastr = ""

        'BAŞINDA UN OLURSA KONTROLA SOKMA
        If Mid(kplaka, 1, 2) = "UN" Then
            Return result
        End If

        'BAŞINDA UNDP OLURSA KONTROLA SOKMA
        If Mid(kplaka, 1, 4) = "UNDP" Then
            Return result
        End If


        'BAŞINDA UNCMP OLURSA KONTROLA SOKMA
        If Mid(kplaka, 1, 5) = "UNCMP" Then
            Return result
        End If


        If PolicyType <> 1 Then
            Return result
        End If

        If PolicyType = 1 Then

            If Len(kplaka) >= 3 Then
                If Mid(kplaka, 1, 1) <> "Z" And Mid(kplaka, 1, 1) <> "T" And plakaninsonharfi(kplaka) <> "Z" Then
                    'ilk 3 karakter harf ise
                    If harfmi(Mid(kplaka, 1, 1)) = "Evet" And harfmi(Mid(kplaka, 2, 1)) = "Evet" And harfmi(Mid(kplaka, 3, 1)) = "Evet" Then
                        If Len(kplaka) = 6 Then
                            result.durum = "Hata Var"
                            result.etkilenen = 0
                            result.hatastr = "Normal poliçelerde ilk 3 karakteri harf olan plakalar 6 karakter uzunluğunda olamaz."
                            Return result
                        End If
                    End If
                End If
            End If 'kplaka>=3


            If Len(kplaka) >= 4 Then
                If Mid(kplaka, 1, 1) = "Z" Or Mid(kplaka, 1, 1) = "T" Then
                    'ilk 4 karakter harf ise
                    If harfmi(Mid(kplaka, 1, 1)) = "Evet" And harfmi(Mid(kplaka, 2, 1)) = "Evet" And _
                    harfmi(Mid(kplaka, 3, 1)) = "Evet" And harfmi(Mid(kplaka, 4, 1)) = "Evet" Then
                        If Len(kplaka) = 7 Then
                            result.durum = "Hata Var"
                            result.etkilenen = 0
                            result.hatastr = "Normal poliçelerde başı Z veya T ile başlayıp ilk 4 karakteri harf olan" + _
                            " plakalar 7 karakter uzunluğunda olamaz."
                            Return result
                        End If
                    End If
                End If
            End If

        End If 'PolicyType=1

        Return result

    End Function



    Public Function plakakontrol(ByVal kplaka As String) As CLADBOPRESULT

        Dim result As New CLADBOPRESULT

        'ANYMOTOR İSE KONTROL YAPMA
        If kplaka = "ANYMOTOR" Then
            result.durum = "Hata Yok"
            result.etkilenen = 1
            result.hatastr = ""
            Return result
        End If

        'BÜYÜKLÜK KONTROL 
        If Len(kplaka) < 4 Then
            result.durum = "Hata"
            result.etkilenen = 0
            result.hatastr = "Hatalı Plaka. Plaka uzunluğu 4'den küçük olamaz"
            Return result
        End If
        If Len(kplaka) > 7 Then
            result.durum = "Hata"
            result.etkilenen = 0
            result.hatastr = "Hatalı Plaka. Plaka uzunluğu 7'den büyük olamaz"
            Return result
        End If


        'RHA İSE KONTROL
        If InStr(kplaka, "RHA", CompareMethod.Text) > 0 Then
            If Len(kplaka) <> 7 And Len(kplaka) <> 6 Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. RHA plaka uzunluğu 7 yada 6 karakter olmalıdır."
                Return result
            End If

            If Mid(kplaka, 1, 3) <> "RHA" Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. İlk 3 karakter RHA olmalıdır."
                Return result
            End If

            If rakammi(Mid(kplaka, 4, 1)) = "Hayır" Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. RHA plakalarda 4. karakter rakam olmalıdır."
                Return result
            End If
            If rakammi(Mid(kplaka, 5, 1)) = "Hayır" Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. RHA plakalarda 5. karakter rakam olmalıdır."
                Return result
            End If
            If rakammi(Mid(kplaka, 6, 1)) = "Hayır" Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. RHA plakalarda 6. karakter rakam olmalıdır."
                Return result
            End If

            If Len(kplaka) = 7 Then
                If rakammi(Mid(kplaka, 7, 1)) = "Hayır" Then
                    result.durum = "Hata"
                    result.etkilenen = 0
                    result.hatastr = "Hatalı Plaka. RHA plakalarda 7. karakter rakam olmalıdır."
                    Return result
                End If
            End If
        End If

        'TAKSİ YADA KİRALIK İSE KONTROL 
        If Mid(kplaka, 1, 1) = "T" Or Mid(kplaka, 1, 1) = "Z" Then

            If Len(kplaka) > 3 Then

                If harfmi(Mid(kplaka, 1, 1)) = "Evet" And harfmi(Mid(kplaka, 2, 1)) = "Evet" And harfmi(Mid(kplaka, 3, 1)) = "Evet" Then

                    If Len(kplaka) <> 7 And Len(kplaka) <> 6 Then
                        result.durum = "Hata"
                        result.etkilenen = 0
                        result.hatastr = "Hatalı Plaka. Taksi yada Kiralık plaka uzunluğu 7 yada 6 karakter olmalıdır."
                        Return result
                    End If

                    If harfmi(Mid(kplaka, 2, 1)) = "Hayır" Then
                        result.durum = "Hata"
                        result.etkilenen = 0
                        result.hatastr = "Hatalı Plaka. Taksi yada Kiralık plakalarda 2. karakter harf olmalıdır."
                        Return result
                    End If
                    If harfmi(Mid(kplaka, 3, 1)) = "Hayır" Then
                        result.durum = "Hata"
                        result.etkilenen = 0
                        result.hatastr = "Hatalı Plaka. Taksi yada Kiralık plakalarda 3. karakter harf olmalıdır."
                        Return result
                    End If

                    If rakammi(Mid(kplaka, 4, 1)) = "Hayır" Then
                        result.durum = "Hata"
                        result.etkilenen = 0
                        result.hatastr = "Hatalı Plaka. Taksi yada Kiralık plakalarda 4. karakter rakam olmalıdır."
                        Return result
                    End If

                    If rakammi(Mid(kplaka, 5, 1)) = "Hayır" Then
                        result.durum = "Hata"
                        result.etkilenen = 0
                        result.hatastr = "Hatalı Plaka. Taksi yada Kiralık plakalarda 5. karakter rakam olmalıdır."
                        Return result
                    End If

                    If rakammi(Mid(kplaka, 6, 1)) = "Hayır" Then
                        result.durum = "Hata"
                        result.etkilenen = 0
                        result.hatastr = "Hatalı Plaka. Taksi yada Kiralık plakalarda 6. karakter rakam olmalıdır."
                        Return result
                    End If

                    If Len(kplaka) = 7 Then
                        If rakammi(Mid(kplaka, 7, 1)) = "Hayır" Then
                            result.durum = "Hata"
                            result.etkilenen = 0
                            result.hatastr = "Hatalı Plaka. Taksi yada RHA plakalarda 7. karakter rakam olmalıdır."
                            Return result
                        End If
                    End If

                End If

            End If '3 den büyük
        End If 'taksi kiralık bitti 


        'NORMAL PLAKA İSE KONTROL 
        If Mid(kplaka, 1, 3) <> "RHA" Then

            If Len(kplaka) <> 5 And Len(kplaka) <> 4 Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. Normal plaka uzunluğu 5 yada 4 karakter olmalıdır."
                Return result
            End If

            If harfmi(Mid(kplaka, 1, 1)) = "Hayır" Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. Normal plakalarda 1. karakter harf olmalıdır."
                Return result
            End If

            If rakammi(Mid(kplaka, 3, 1)) = "Hayır" Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. Normal plakalarda 3. karakter rakam olmalıdır."
                Return result
            End If

            If rakammi(Mid(kplaka, 4, 1)) = "Hayır" Then
                result.durum = "Hata"
                result.etkilenen = 0
                result.hatastr = "Hatalı Plaka. Normal plakalarda 4. karakter rakam olmalıdır."
                Return result
            End If

            If Len(kplaka) = 5 Then
                If rakammi(Mid(kplaka, 5, 1)) = "Hayır" Then
                    result.durum = "Hata"
                    result.etkilenen = 0
                    result.hatastr = "Hatalı Plaka. Normal plakalarda 5. karakter rakam olmalıdır."
                    Return result
                End If
            End If

        End If

        Return result

    End Function

    Public Function harfmi(ByVal kharf As Char) As String

        Dim donecek As String
        donecek = "Hayır"
        Dim alfabe = "ABCDEFGHIİJKLMNOPQRSTUWXVYZ"

        If InStr(alfabe, kharf, CompareMethod.Text) > 0 Then
            donecek = "Evet"
        End If

        Return donecek

    End Function

    Public Function harfsayisi(ByVal kplaka As String) As Integer

        Dim kacadet As Integer = 0
        If Len(kplaka) > 0 Then
            Dim alfabe = "ABCDEFGHIİJKLMNOPQRSTUWXVYZ"
            For Each itemkplaka As Char In kplaka
                For Each itemalfabe As Char In alfabe
                    If itemkplaka = itemalfabe Then
                        kacadet = kacadet + 1
                    End If
                Next
            Next
        End If

        Return kacadet

    End Function


    Public Function plakaninsonharfi(ByVal kplaka As String) As String

        Dim donecek As String = ""

        If Len(kplaka) > 0 Then
            donecek = Mid(kplaka, Len(kplaka), 1)
        End If

        Return donecek

    End Function


    Public Function rakammi(ByVal kharf As Char) As String

        Dim donecek As String
        donecek = "Hayır"
        Dim alfabe = "0123456789"

        If InStr(alfabe, kharf, CompareMethod.Text) > 0 Then
            donecek = "Evet"
        End If

        Return donecek

    End Function

    Public Function plakayiboslukluyap(ByVal PlateNumber As String) As String

        Dim donecek As String = PlateNumber
        Dim uzunluk As Integer = Len(PlateNumber)

        If uzunluk > 3 Then

            If rakammi(Mid(PlateNumber, 2, 1)) = "Evet" Then
                donecek = Mid(PlateNumber, 1, 1) + " " + Mid(PlateNumber, 2, uzunluk)
                Return donecek
            End If

            If rakammi(Mid(PlateNumber, 3, 1)) = "Evet" Then
                donecek = Mid(PlateNumber, 1, 2) + " " + Mid(PlateNumber, 3, uzunluk)
                Return donecek
            End If

            If rakammi(Mid(PlateNumber, 4, 1)) = "Evet" Then
                donecek = Mid(PlateNumber, 1, 3) + " " + Mid(PlateNumber, 4, uzunluk)
            End If

        End If

        Return donecek

    End Function


End Class
