Public Class DamageInfoServiceHelper_Erisim


    Dim fieldopvalue As New CLASSFIELDOPERATORVALUE
    Dim fieldopvalues As New List(Of CLASSFIELDOPERATORVALUE)
    Dim genericislem_erisim As New CLASSGENERICISLEM_ERISIM
    Dim DamageInfoService_erisim As New DamageInfoService_Erisim

    'kimlik ve plaka birlikte hasar zammına bakıyor.
    Public Function kimlikplakabirlikte(ByVal Info As Info, ByVal kimlikfieldad As String, _
    ByVal bakilacakkimlik As String, ByVal araliklar As List(Of CLASSARALIK)) As CLASSLOGVEDECIMAL

        Dim logx As String = ""

        Dim simdikiyilhasarivarmi As String = "Hayır"
        Dim bironcekiyilhasarivarmi As String = "Hayır"

        Dim doneceklogvedecimal As New CLASSLOGVEDECIMAL
        doneceklogvedecimal.logx = ""

        Dim toplamodenenhasar As Decimal = 0

        Dim veritabaniad As String = System.Configuration.ConfigurationManager.AppSettings("veritabaniad")
        Dim birinciyilplakakimlikaynimi As String = "Hayır"
        Dim ikinciyilplakakimlikaynimi As String = "Hayır"
        Dim aralik_simdikiyil As New CLASSARALIK
        Dim aralik_bironcekiyil As New CLASSARALIK
        aralik_simdikiyil = araliklar(0)
        aralik_bironcekiyil = araliklar(1)

        Dim simdikiyil_hasarzammituturi As Integer = 0
        Dim bironcekiyil_hasarzammituturi As Integer = 0

        Dim simdikiyil_hasarzammiorani As Integer = 0
        Dim bironcekiyil_hasarzammiorani As Integer = 0

        Dim simdikiyil_police_adet As Integer
        Dim bironcekiyil_police_adet As Integer

        Dim simdikiyil_damage As New List(Of tekdamage)
        Dim bironcekiyil_damage As New List(Of tekdamage)

        Dim tekdamage As New tekdamage
        Dim bak As String = "Hayır"


        'BAKILIP BAKILMAYACAĞINI KONTROL ET
        If kimlikfieldad = "PolicyOwnerIdentityNo" Then
            If Info.PlateNumber <> "" And bakilacakkimlik <> "" And _
            (Info.SIdentityCode = "KN" Or Info.SIdentityCode = "PN" Or Info.SIdentityCode = "GK") Then
                bak = "Evet"
                logx = logx + "Kimlik ve plakaya birlikte bakılıyor. " + kimlikfieldad + " için.--"
                doneceklogvedecimal.hasaroran = 0
                doneceklogvedecimal.hasarsizlikoran = 0
                doneceklogvedecimal.logx = logx
                doneceklogvedecimal.bakildimi = "Evet"
            End If
        End If
        If bak = "Hayır" Then
            logx = logx + "Kimlik ve plakaya birlikte bakılmıyor çünkü PlateNumber boş veya bakılacak kimlik boş veya " + _
            kimlikfieldad + " KN veya PN veya GK değil.--"
            doneceklogvedecimal.hasaroran = 0
            doneceklogvedecimal.hasarsizlikoran = 0
            doneceklogvedecimal.bakildimi = "Hayır"
            doneceklogvedecimal.logx = logx
            Return doneceklogvedecimal
        End If
        '----------------------------------------------------------------------------------------------------------------------




        'BAKILACAK KİMLİKLERİ AYARLA ------------------------------------------------------------------------------------------
        Dim kesilmisbakilacakmi As String = "0"
        Dim countryfieldad As String = ""
        Dim kesilmiskimlik As String = ""

        If kimlikfieldad = "PolicyOwnerIdentityNo" Then
            countryfieldad = "PolicyOwnerCountryCode"
            If Info.SIdentityCountryCode = "601" Then
                If Len(Info.SIdentityNumber) = 10 Then
                    kesilmisbakilacakmi = "1"
                    kesilmiskimlik = Mid(Info.SIdentityNumber, 5, 6)
                    logx = logx + " Ayrıca " + kesilmiskimlik + " e bakıyorum."
                End If
            End If
        End If


        'şimdiki yıl----------------------
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", CStr(Info.ProductCode), " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "StartDate", ">=", aralik_simdikiyil.bitis, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", kimlikfieldad, "=", bakilacakkimlik, " and "))
        If kesilmisbakilacakmi = "1" Then
            fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", kimlikfieldad, "=", kesilmiskimlik, " or "))
            fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", kimlikfieldad, "=", kesilmiskimlik, " ) and "))
        End If
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PlateNumber", "=", Info.PlateNumber, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "ZeylCode", "=", "P", " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ZeylCode", "=", "T", ")"))
        simdikiyil_police_adet = genericislem_erisim.countgeneric(veritabaniad, "PolicyInfo", "count(*)", fieldopvalues)

        If simdikiyil_police_adet > 0 Then
            logx = logx + bakilacakkimlik + " ve " + Info.PlateNumber + " " + _
            CStr(aralik_simdikiyil.bitis) + " tarihinden sonra poliçe bulundu. --"

            'önce plaka için hasar zammını bul
            simdikiyil_damage = DamageInfoService_erisim.damagebul_plakayagore(Info.PlateNumber, aralik_simdikiyil.baslangic, aralik_simdikiyil.bitis)
            If simdikiyil_damage.Count > 0 Then
                simdikiyilhasarivarmi = "Evet"
                For Each item As tekdamage In simdikiyil_damage
                    simdikiyil_hasarzammituturi = simdikiyil_hasarzammituturi + item.DamageCost
                Next
                simdikiyil_hasarzammiorani = DamageInfoService_erisim.tuzukhasargecirbul(simdikiyil_hasarzammituturi)
            End If
            logx = logx + "Şimdiki Yıl: Toplam Ödenen Hasar :" + Format(simdikiyil_hasarzammituturi, "0.00") + " TL ve tüzüğe göre %" + CStr(simdikiyil_hasarzammiorani) + " uygulanmalı.--"
        End If


        'bir önceki yıl ----------------------------------------------------
        fieldopvalues.Clear()
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ProductCode", "=", CStr(Info.ProductCode), " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "StartDate", ">=", aralik_bironcekiyil.bitis, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", kimlikfieldad, "=", bakilacakkimlik, " and "))
        If kesilmisbakilacakmi = "1" Then
            fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", kimlikfieldad, "=", kesilmiskimlik, " or "))
            fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", kimlikfieldad, "=", kesilmiskimlik, " ) and "))
        End If
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "PlateNumber", "=", Info.PlateNumber, " and "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("(", "ZeylCode", "=", "P", " or "))
        fieldopvalues.Add(New CLASSFIELDOPERATORVALUE("", "ZeylCode", "=", "T", ")"))
        bironcekiyil_police_adet = genericislem_erisim.countgeneric(veritabaniad, "PolicyInfo", "count(*)", fieldopvalues)

        If bironcekiyil_police_adet > 0 Then
            logx = logx + bakilacakkimlik + " ve " + Info.PlateNumber + " " + _
            CStr(aralik_bironcekiyil.bitis) + " tarihinden sonra poliçe bulundu ve plaka ve kimlik ayni. --"

            'önce plaka için hasar zammını bul
            bironcekiyil_damage = DamageInfoService_erisim.damagebul_plakayagore(Info.PlateNumber, _
            aralik_bironcekiyil.baslangic, aralik_bironcekiyil.bitis)
            If bironcekiyil_damage.Count > 0 Then
                bironcekiyilhasarivarmi = "Evet"
                For Each item As tekdamage In simdikiyil_damage
                    bironcekiyil_hasarzammituturi = bironcekiyil_hasarzammituturi + item.DamageCost
                Next
                bironcekiyil_hasarzammiorani = DamageInfoService_erisim.tuzukhasargecirbul(bironcekiyil_hasarzammituturi)
            End If
            logx = logx + "Bir önceki Yıl: Toplam Ödenen Hasar :" + Format(bironcekiyil_hasarzammituturi, "0.00") + " TL--"
        End If


        If simdikiyil_police_adet <= 0 Then
            logx = logx + "Birlikte baktığımda geriye dönük herhangi bir poliçe bulamadım--"
        End If


        'simdiki yil için hasarı var 
        If simdikiyilhasarivarmi = "Evet" Then
            doneceklogvedecimal.logx = logx
            doneceklogvedecimal.bakildimi = "Evet"
            doneceklogvedecimal.hasaroran = simdikiyil_hasarzammiorani
            doneceklogvedecimal.hasarsizlikoran = 0
            logx = logx + "Birlikte:  Şimdiki yıl için hasar buldum %" + CStr(simdikiyil_hasarzammiorani) + _
            " hasar zammı döneceğim, eğer bir önceki yılda hasar zammı var ise. "
        End If

        'simdiki yil için hasarı var bir onceki yil için yok
        If simdikiyilhasarivarmi = "Evet" And bironcekiyilhasarivarmi = "Hayır" Then
            doneceklogvedecimal.logx = logx
            doneceklogvedecimal.bakildimi = "Evet"
            doneceklogvedecimal.hasaroran = 0
            doneceklogvedecimal.hasarsizlikoran = 0
            logx = logx + "Birlikte: Fakat, Bir önceki yıl için toplam ödenen hasar tutarı 0 olduğundan" + _
            " herhangi bir hasar zammı veya hasarsızlık indirimi dönmüyorum. Hasar Zammı:%0 Hasarsızlık İndirimi:%0--"
        End If


        'simdiki yil için hasarı yok bir onceki yil için var senaryo 3
        If simdikiyilhasarivarmi = "Hayır" And bironcekiyilhasarivarmi = "Evet" Then
            doneceklogvedecimal.logx = logx
            doneceklogvedecimal.bakildimi = "Evet"
            doneceklogvedecimal.hasaroran = 0
            doneceklogvedecimal.hasarsizlikoran = 10
            logx = logx + "Birlikte: Fakat, şimdiki yıl için hasarı yok fakat bir önceki yıl hasarı olduğundan" + _
            " herhangi bir hasar zammı dönmüyor hasarsızlık indirimi %10 dönmüyorum. Hasar Zammı:%0 Hasarsızlık İndirimi:%0--"
            Return doneceklogvedecimal
        End If


        doneceklogvedecimal.simdikiyilhasarvarmi = simdikiyilhasarivarmi
        doneceklogvedecimal.oncekiyilhasarvarmi = bironcekiyilhasarivarmi
        Return doneceklogvedecimal


    End Function




End Class
