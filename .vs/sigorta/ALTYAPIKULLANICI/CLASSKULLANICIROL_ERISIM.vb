Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO


Public Class CLASSKULLANICIROL_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim kullanicirol As New CLASSKULLANICIROL
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal kullanicirol As CLASSKULLANICIROL) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol("rolad", kullanicirol.rolad)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu rol isminde zaten halihazırda veritabanında kayıt vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand

            komut.Connection = db_baglanti

            sqlstr = "insert into kullanicirol values (@pkey," + _
            "@rolad,@tumsirketyetki,@yonsayfa,@panoyetki," + _
            "@islemyetki,@aramayetki,@tanimyetki,@fiyatyetki," + _
            "@belgeyonetimyetki,@resimyetki,@kullaniciyonetimyetki,@raporyetki," + _
            "@logyetki,@mesajyetki,@ayaryetki,@sirkettarafaramayetki," + _
            "@servisayaryetki,@sirkettarafkullaniciyaratyetki,@profilyetki,@toplumesajyetki," + _
            "@dosyayetki,@sirkettarafraporerisim,@rolsirkettarafindasecilebilsinmi,@sirkettanimyetki," + _
            "@acentetanimyetki,@personeltanimyetki,@aractarifetanimyetki,@ulketanimyetki," + _
            "@anamenupkey,@yardimyetki,@mensup,@sirkettarafkullanicilisteyetki," + _
            "@zeylcodetanimyetki,@urunkodtanimyetki,@currencycodetanimyetki,@sirkettarafacenteyaratyetki," + _
            "@hasardurumkodtanimyetki,@sadecesirketicimesajlasma,@sadecesirketicidosyagonderimi,@policetiptanimyetki," + _
            "@faturalandirmayetki,@acentetiptanimyetki,@bazfiyatgirissureyetki," + _
            "@sirketbazfiyatgirisyetki,@sadecemerkezgozuk,@kimlikturtanimyetki,@dinamikraporyetki," + _
            "@adminpolicearayetki,@adminhasararayetki,@kuryetki,@tpbelgeyetki,@bekbelgeyetki," + _
            "@birlikpersoneltanimyetki,@tanimlanmisdinamikraporyetki,@iptallistesiyetki,@parakambiyoaramayetki)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@rolad", SqlDbType.VarChar)
            param2.Direction = ParameterDirection.Input
            If kullanicirol.rolad = "" Then
                param2.Value = System.DBNull.Value
            Else
                param2.Value = kullanicirol.rolad
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@tumsirketyetki", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If kullanicirol.tumsirketyetki = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = kullanicirol.tumsirketyetki
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@yonsayfa", SqlDbType.VarChar)
            param4.Direction = ParameterDirection.Input
            If kullanicirol.yonsayfa = "" Then
                param4.Value = System.DBNull.Value
            Else
                param4.Value = kullanicirol.yonsayfa
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@panoyetki", SqlDbType.VarChar)
            param5.Direction = ParameterDirection.Input
            If kullanicirol.panoyetki = "" Then
                param5.Value = System.DBNull.Value
            Else
                param5.Value = kullanicirol.panoyetki
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@islemyetki", SqlDbType.VarChar)
            param6.Direction = ParameterDirection.Input
            If kullanicirol.islemyetki = "" Then
                param6.Value = System.DBNull.Value
            Else
                param6.Value = kullanicirol.islemyetki
            End If
            komut.Parameters.Add(param6)

            Dim param7 As New SqlParameter("@aramayetki", SqlDbType.VarChar)
            param7.Direction = ParameterDirection.Input
            If kullanicirol.aramayetki = "" Then
                param7.Value = System.DBNull.Value
            Else
                param7.Value = kullanicirol.aramayetki
            End If
            komut.Parameters.Add(param7)

            Dim param8 As New SqlParameter("@tanimyetki", SqlDbType.VarChar)
            param8.Direction = ParameterDirection.Input
            If kullanicirol.tanimyetki = "" Then
                param8.Value = System.DBNull.Value
            Else
                param8.Value = kullanicirol.tanimyetki
            End If
            komut.Parameters.Add(param8)

            Dim param9 As New SqlParameter("@fiyatyetki", SqlDbType.VarChar)
            param9.Direction = ParameterDirection.Input
            If kullanicirol.fiyatyetki = "" Then
                param9.Value = System.DBNull.Value
            Else
                param9.Value = kullanicirol.fiyatyetki
            End If
            komut.Parameters.Add(param9)

            Dim param10 As New SqlParameter("@belgeyonetimyetki", SqlDbType.VarChar)
            param10.Direction = ParameterDirection.Input
            If kullanicirol.belgeyonetimyetki = "" Then
                param10.Value = System.DBNull.Value
            Else
                param10.Value = kullanicirol.belgeyonetimyetki
            End If
            komut.Parameters.Add(param10)

            Dim param11 As New SqlParameter("@resimyetki", SqlDbType.VarChar)
            param11.Direction = ParameterDirection.Input
            If kullanicirol.resimyetki = "" Then
                param11.Value = System.DBNull.Value
            Else
                param11.Value = kullanicirol.resimyetki
            End If
            komut.Parameters.Add(param11)

            Dim param12 As New SqlParameter("@kullaniciyonetimyetki", SqlDbType.VarChar)
            param12.Direction = ParameterDirection.Input
            If kullanicirol.kullaniciyonetimyetki = "" Then
                param12.Value = System.DBNull.Value
            Else
                param12.Value = kullanicirol.kullaniciyonetimyetki
            End If
            komut.Parameters.Add(param12)

            Dim param13 As New SqlParameter("@raporyetki", SqlDbType.VarChar)
            param13.Direction = ParameterDirection.Input
            If kullanicirol.raporyetki = "" Then
                param13.Value = System.DBNull.Value
            Else
                param13.Value = kullanicirol.raporyetki
            End If
            komut.Parameters.Add(param13)

            Dim param14 As New SqlParameter("@logyetki", SqlDbType.VarChar)
            param14.Direction = ParameterDirection.Input
            If kullanicirol.logyetki = "" Then
                param14.Value = System.DBNull.Value
            Else
                param14.Value = kullanicirol.logyetki
            End If
            komut.Parameters.Add(param14)

            Dim param15 As New SqlParameter("@mesajyetki", SqlDbType.VarChar)
            param15.Direction = ParameterDirection.Input
            If kullanicirol.mesajyetki = "" Then
                param15.Value = System.DBNull.Value
            Else
                param15.Value = kullanicirol.mesajyetki
            End If
            komut.Parameters.Add(param15)

            Dim param16 As New SqlParameter("@ayaryetki", SqlDbType.VarChar)
            param16.Direction = ParameterDirection.Input
            If kullanicirol.ayaryetki = "" Then
                param16.Value = System.DBNull.Value
            Else
                param16.Value = kullanicirol.ayaryetki
            End If
            komut.Parameters.Add(param16)

            Dim param17 As New SqlParameter("@sirkettarafaramayetki", SqlDbType.VarChar)
            param17.Direction = ParameterDirection.Input
            If kullanicirol.sirkettarafaramayetki = "" Then
                param17.Value = System.DBNull.Value
            Else
                param17.Value = kullanicirol.sirkettarafaramayetki
            End If
            komut.Parameters.Add(param17)

            Dim param18 As New SqlParameter("@servisayaryetki", SqlDbType.VarChar)
            param18.Direction = ParameterDirection.Input
            If kullanicirol.servisayaryetki = "" Then
                param18.Value = System.DBNull.Value
            Else
                param18.Value = kullanicirol.servisayaryetki
            End If
            komut.Parameters.Add(param18)

            Dim param19 As New SqlParameter("@sirkettarafkullaniciyaratyetki", SqlDbType.VarChar)
            param19.Direction = ParameterDirection.Input
            If kullanicirol.sirkettarafkullaniciyaratyetki = "" Then
                param19.Value = System.DBNull.Value
            Else
                param19.Value = kullanicirol.sirkettarafkullaniciyaratyetki
            End If
            komut.Parameters.Add(param19)

            Dim param20 As New SqlParameter("@profilyetki", SqlDbType.VarChar)
            param20.Direction = ParameterDirection.Input
            If kullanicirol.profilyetki = "" Then
                param20.Value = System.DBNull.Value
            Else
                param20.Value = kullanicirol.profilyetki
            End If
            komut.Parameters.Add(param20)

            Dim param21 As New SqlParameter("@toplumesajyetki", SqlDbType.VarChar)
            param21.Direction = ParameterDirection.Input
            If kullanicirol.toplumesajyetki = "" Then
                param21.Value = System.DBNull.Value
            Else
                param21.Value = kullanicirol.toplumesajyetki
            End If
            komut.Parameters.Add(param21)

            Dim param22 As New SqlParameter("@dosyayetki", SqlDbType.VarChar)
            param22.Direction = ParameterDirection.Input
            If kullanicirol.dosyayetki = "" Then
                param22.Value = System.DBNull.Value
            Else
                param22.Value = kullanicirol.dosyayetki
            End If
            komut.Parameters.Add(param22)

            Dim param23 As New SqlParameter("@sirkettarafraporerisim", SqlDbType.VarChar)
            param23.Direction = ParameterDirection.Input
            If kullanicirol.sirkettarafraporerisim = "" Then
                param23.Value = System.DBNull.Value
            Else
                param23.Value = kullanicirol.sirkettarafraporerisim
            End If
            komut.Parameters.Add(param23)

            Dim param24 As New SqlParameter("@rolsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
            param24.Direction = ParameterDirection.Input
            If kullanicirol.rolsirkettarafindasecilebilsinmi = "" Then
                param24.Value = System.DBNull.Value
            Else
                param24.Value = kullanicirol.rolsirkettarafindasecilebilsinmi
            End If
            komut.Parameters.Add(param24)

            Dim param25 As New SqlParameter("@sirkettanimyetki", SqlDbType.VarChar)
            param25.Direction = ParameterDirection.Input
            If kullanicirol.sirkettanimyetki = "" Then
                param25.Value = System.DBNull.Value
            Else
                param25.Value = kullanicirol.sirkettanimyetki
            End If
            komut.Parameters.Add(param25)

            Dim param26 As New SqlParameter("@acentetanimyetki", SqlDbType.VarChar)
            param26.Direction = ParameterDirection.Input
            If kullanicirol.acentetanimyetki = "" Then
                param26.Value = System.DBNull.Value
            Else
                param26.Value = kullanicirol.acentetanimyetki
            End If
            komut.Parameters.Add(param26)

            Dim param27 As New SqlParameter("@personeltanimyetki", SqlDbType.VarChar)
            param27.Direction = ParameterDirection.Input
            If kullanicirol.personeltanimyetki = "" Then
                param27.Value = System.DBNull.Value
            Else
                param27.Value = kullanicirol.personeltanimyetki
            End If
            komut.Parameters.Add(param27)

            Dim param28 As New SqlParameter("@aractarifetanimyetki", SqlDbType.VarChar)
            param28.Direction = ParameterDirection.Input
            If kullanicirol.aractarifetanimyetki = "" Then
                param28.Value = System.DBNull.Value
            Else
                param28.Value = kullanicirol.aractarifetanimyetki
            End If
            komut.Parameters.Add(param28)

            Dim param29 As New SqlParameter("@ulketanimyetki", SqlDbType.VarChar)
            param29.Direction = ParameterDirection.Input
            If kullanicirol.ulketanimyetki = "" Then
                param29.Value = System.DBNull.Value
            Else
                param29.Value = kullanicirol.ulketanimyetki
            End If
            komut.Parameters.Add(param29)

            Dim param30 As New SqlParameter("@anamenupkey", SqlDbType.Int)
            param30.Direction = ParameterDirection.Input
            If kullanicirol.anamenupkey = 0 Then
                param30.Value = 0
            Else
                param30.Value = kullanicirol.anamenupkey
            End If
            komut.Parameters.Add(param30)

            Dim param31 As New SqlParameter("@yardimyetki", SqlDbType.VarChar)
            param31.Direction = ParameterDirection.Input
            If kullanicirol.yardimyetki = "" Then
                param31.Value = System.DBNull.Value
            Else
                param31.Value = kullanicirol.yardimyetki
            End If
            komut.Parameters.Add(param31)

            Dim param32 As New SqlParameter("@mensup", SqlDbType.VarChar)
            param32.Direction = ParameterDirection.Input
            If kullanicirol.mensup = "" Then
                param32.Value = System.DBNull.Value
            Else
                param32.Value = kullanicirol.mensup
            End If
            komut.Parameters.Add(param32)

            Dim param33 As New SqlParameter("@sirkettarafkullanicilisteyetki", SqlDbType.VarChar)
            param33.Direction = ParameterDirection.Input
            If kullanicirol.sirkettarafkullanicilisteyetki = "" Then
                param33.Value = System.DBNull.Value
            Else
                param33.Value = kullanicirol.sirkettarafkullanicilisteyetki
            End If
            komut.Parameters.Add(param33)

            Dim param34 As New SqlParameter("@zeylcodetanimyetki", SqlDbType.VarChar)
            param34.Direction = ParameterDirection.Input
            If kullanicirol.zeylcodetanimyetki = "" Then
                param34.Value = System.DBNull.Value
            Else
                param34.Value = kullanicirol.zeylcodetanimyetki
            End If
            komut.Parameters.Add(param34)

            Dim param35 As New SqlParameter("@urunkodtanimyetki", SqlDbType.VarChar)
            param35.Direction = ParameterDirection.Input
            If kullanicirol.urunkodtanimyetki = "" Then
                param35.Value = System.DBNull.Value
            Else
                param35.Value = kullanicirol.urunkodtanimyetki
            End If
            komut.Parameters.Add(param35)

            Dim param36 As New SqlParameter("@currencycodetanimyetki", SqlDbType.VarChar)
            param36.Direction = ParameterDirection.Input
            If kullanicirol.currencycodetanimyetki = "" Then
                param36.Value = System.DBNull.Value
            Else
                param36.Value = kullanicirol.currencycodetanimyetki
            End If
            komut.Parameters.Add(param36)

            Dim param37 As New SqlParameter("@sirkettarafacenteyaratyetki", SqlDbType.VarChar)
            param37.Direction = ParameterDirection.Input
            If kullanicirol.sirkettarafacenteyaratyetki = "" Then
                param37.Value = System.DBNull.Value
            Else
                param37.Value = kullanicirol.sirkettarafacenteyaratyetki
            End If
            komut.Parameters.Add(param37)

            Dim param38 As New SqlParameter("@hasardurumkodtanimyetki", SqlDbType.VarChar)
            param38.Direction = ParameterDirection.Input
            If kullanicirol.hasardurumkodtanimyetki = "" Then
                param38.Value = System.DBNull.Value
            Else
                param38.Value = kullanicirol.hasardurumkodtanimyetki
            End If
            komut.Parameters.Add(param38)

            Dim param39 As New SqlParameter("@sadecesirketicimesajlasma", SqlDbType.VarChar)
            param39.Direction = ParameterDirection.Input
            If kullanicirol.sadecesirketicimesajlasma = "" Then
                param39.Value = System.DBNull.Value
            Else
                param39.Value = kullanicirol.sadecesirketicimesajlasma
            End If
            komut.Parameters.Add(param39)

            Dim param40 As New SqlParameter("@sadecesirketicidosyagonderimi", SqlDbType.VarChar)
            param40.Direction = ParameterDirection.Input
            If kullanicirol.sadecesirketicidosyagonderimi = "" Then
                param40.Value = System.DBNull.Value
            Else
                param40.Value = kullanicirol.sadecesirketicidosyagonderimi
            End If
            komut.Parameters.Add(param40)

            Dim param41 As New SqlParameter("@policetiptanimyetki", SqlDbType.VarChar)
            param41.Direction = ParameterDirection.Input
            If kullanicirol.policetiptanimyetki = "" Then
                param41.Value = System.DBNull.Value
            Else
                param41.Value = kullanicirol.policetiptanimyetki
            End If
            komut.Parameters.Add(param41)

            Dim param42 As New SqlParameter("@faturalandirmayetki", SqlDbType.VarChar)
            param42.Direction = ParameterDirection.Input
            If kullanicirol.faturalandirmayetki = "" Then
                param42.Value = System.DBNull.Value
            Else
                param42.Value = kullanicirol.faturalandirmayetki
            End If
            komut.Parameters.Add(param42)

            Dim param43 As New SqlParameter("@acentetiptanimyetki", SqlDbType.VarChar)
            param43.Direction = ParameterDirection.Input
            If kullanicirol.acentetiptanimyetki = "" Then
                param43.Value = System.DBNull.Value
            Else
                param43.Value = kullanicirol.acentetiptanimyetki
            End If
            komut.Parameters.Add(param43)

            Dim param44 As New SqlParameter("@bazfiyatgirissureyetki", SqlDbType.VarChar)
            param44.Direction = ParameterDirection.Input
            If kullanicirol.bazfiyatgirissureyetki = "" Then
                param44.Value = System.DBNull.Value
            Else
                param44.Value = kullanicirol.bazfiyatgirissureyetki
            End If
            komut.Parameters.Add(param44)

            Dim param45 As New SqlParameter("@sirketbazfiyatgirisyetki", SqlDbType.VarChar)
            param45.Direction = ParameterDirection.Input
            If kullanicirol.sirketbazfiyatgirisyetki = "" Then
                param45.Value = System.DBNull.Value
            Else
                param45.Value = kullanicirol.sirketbazfiyatgirisyetki
            End If
            komut.Parameters.Add(param45)

            Dim param46 As New SqlParameter("@sadecemerkezgozuk", SqlDbType.VarChar)
            param46.Direction = ParameterDirection.Input
            If kullanicirol.sadecemerkezgozuk = "" Then
                param46.Value = System.DBNull.Value
            Else
                param46.Value = kullanicirol.sadecemerkezgozuk
            End If
            komut.Parameters.Add(param46)

            Dim param47 As New SqlParameter("@kimlikturtanimyetki", SqlDbType.VarChar)
            param47.Direction = ParameterDirection.Input
            If kullanicirol.kimlikturtanimyetki = "" Then
                param47.Value = System.DBNull.Value
            Else
                param47.Value = kullanicirol.kimlikturtanimyetki
            End If
            komut.Parameters.Add(param47)

            Dim param48 As New SqlParameter("@dinamikraporyetki", SqlDbType.VarChar)
            param48.Direction = ParameterDirection.Input
            If kullanicirol.dinamikraporyetki = "" Then
                param48.Value = System.DBNull.Value
            Else
                param48.Value = kullanicirol.dinamikraporyetki
            End If
            komut.Parameters.Add(param48)

            Dim param49 As New SqlParameter("@adminpolicearayetki", SqlDbType.VarChar)
            param49.Direction = ParameterDirection.Input
            If kullanicirol.adminpolicearayetki = "" Then
                param49.Value = System.DBNull.Value
            Else
                param49.Value = kullanicirol.adminpolicearayetki
            End If
            komut.Parameters.Add(param49)

            Dim param50 As New SqlParameter("@adminhasararayetki", SqlDbType.VarChar)
            param50.Direction = ParameterDirection.Input
            If kullanicirol.adminhasararayetki = "" Then
                param50.Value = System.DBNull.Value
            Else
                param50.Value = kullanicirol.adminhasararayetki
            End If
            komut.Parameters.Add(param50)

            Dim param51 As New SqlParameter("@kuryetki", SqlDbType.VarChar)
            param51.Direction = ParameterDirection.Input
            If kullanicirol.kuryetki = "" Then
                param51.Value = System.DBNull.Value
            Else
                param51.Value = kullanicirol.kuryetki
            End If
            komut.Parameters.Add(param51)

            Dim param52 As New SqlParameter("@tpbelgeyetki", SqlDbType.VarChar)
            param52.Direction = ParameterDirection.Input
            If kullanicirol.tpbelgeyetki = "" Then
                param52.Value = System.DBNull.Value
            Else
                param52.Value = kullanicirol.tpbelgeyetki
            End If
            komut.Parameters.Add(param52)

            Dim param53 As New SqlParameter("@bekbelgeyetki", SqlDbType.VarChar)
            param53.Direction = ParameterDirection.Input
            If kullanicirol.bekbelgeyetki = "" Then
                param53.Value = System.DBNull.Value
            Else
                param53.Value = kullanicirol.bekbelgeyetki
            End If
            komut.Parameters.Add(param53)

            Dim param54 As New SqlParameter("@birlikpersoneltanimyetki", SqlDbType.VarChar)
            param54.Direction = ParameterDirection.Input
            If kullanicirol.birlikpersoneltanimyetki = "" Then
                param54.Value = System.DBNull.Value
            Else
                param54.Value = kullanicirol.birlikpersoneltanimyetki
            End If
            komut.Parameters.Add(param54)

            Dim param55 As New SqlParameter("@tanimlanmisdinamikraporyetki", SqlDbType.VarChar)
            param55.Direction = ParameterDirection.Input
            If kullanicirol.tanimlanmisdinamikraporyetki = "" Then
                param55.Value = System.DBNull.Value
            Else
                param55.Value = kullanicirol.tanimlanmisdinamikraporyetki
            End If
            komut.Parameters.Add(param55)

            Dim param56 As New SqlParameter("@iptallistesiyetki", SqlDbType.VarChar)
            param56.Direction = ParameterDirection.Input
            If kullanicirol.iptallistesiyetki = "" Then
                param56.Value = System.DBNull.Value
            Else
                param56.Value = kullanicirol.iptallistesiyetki
            End If
            komut.Parameters.Add(param56)


            Dim param57 As New SqlParameter("@parakambiyoaramayetki", SqlDbType.VarChar)
            param57.Direction = ParameterDirection.Input
            If kullanicirol.parakambiyoaramayetki = "" Then
                param57.Value = System.DBNull.Value
            Else
                param57.Value = kullanicirol.parakambiyoaramayetki
            End If
            komut.Parameters.Add(param57)


            Try
                etkilenen = komut.ExecuteNonQuery()
            Catch ex As Exception
                resultset.durum = "Kayıt yapılamadı."
                resultset.hatastr = ex.Message
                resultset.etkilenen = 0
            Finally
                komut.Dispose()
            End Try
            If etkilenen > 0 Then
                resultset.durum = "Kaydedildi"
                resultset.hatastr = ""
                resultset.etkilenen = etkilenen
            End If
            db_baglanti.Close()
            db_baglanti.Dispose()

        End If

        Return resultset

    End Function


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from kullanicirol"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            pkey = 1
        Else
            pkey = maxkayit1 + 1
        End If
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return pkey

    End Function


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSKULLANICIROL

        Dim komut As New SqlCommand
        Dim donecekkullanicirol As New CLASSKULLANICIROL()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanicirol where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicirol.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("rolad") Is System.DBNull.Value Then
                    donecekkullanicirol.rolad = veri.Item("rolad")
                End If

                If Not veri.Item("tumsirketyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tumsirketyetki = veri.Item("tumsirketyetki")
                End If

                If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                    donecekkullanicirol.yonsayfa = veri.Item("yonsayfa")
                End If

                If Not veri.Item("panoyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.panoyetki = veri.Item("panoyetki")
                End If

                If Not veri.Item("islemyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.islemyetki = veri.Item("islemyetki")
                End If

                If Not veri.Item("aramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aramayetki = veri.Item("aramayetki")
                End If

                If Not veri.Item("tanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimyetki = veri.Item("tanimyetki")
                End If

                If Not veri.Item("fiyatyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.fiyatyetki = veri.Item("fiyatyetki")
                End If

                If Not veri.Item("belgeyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.belgeyonetimyetki = veri.Item("belgeyonetimyetki")
                End If

                If Not veri.Item("resimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.resimyetki = veri.Item("resimyetki")
                End If

                If Not veri.Item("kullaniciyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kullaniciyonetimyetki = veri.Item("kullaniciyonetimyetki")
                End If

                If Not veri.Item("raporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.raporyetki = veri.Item("raporyetki")
                End If

                If Not veri.Item("logyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.logyetki = veri.Item("logyetki")
                End If

                If Not veri.Item("mesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.mesajyetki = veri.Item("mesajyetki")
                End If

                If Not veri.Item("ayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ayaryetki = veri.Item("ayaryetki")
                End If

                If Not veri.Item("sirkettarafaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafaramayetki = veri.Item("sirkettarafaramayetki")
                End If

                If Not veri.Item("servisayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.servisayaryetki = veri.Item("servisayaryetki")
                End If

                If Not veri.Item("sirkettarafkullaniciyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullaniciyaratyetki = veri.Item("sirkettarafkullaniciyaratyetki")
                End If

                If Not veri.Item("profilyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.profilyetki = veri.Item("profilyetki")
                End If

                If Not veri.Item("toplumesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.toplumesajyetki = veri.Item("toplumesajyetki")
                End If

                If Not veri.Item("dosyayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dosyayetki = veri.Item("dosyayetki")
                End If

                If Not veri.Item("sirkettarafraporerisim") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafraporerisim = veri.Item("sirkettarafraporerisim")
                End If

                If Not veri.Item("rolsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicirol.rolsirkettarafindasecilebilsinmi = veri.Item("rolsirkettarafindasecilebilsinmi")
                End If

                If Not veri.Item("sirkettanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettanimyetki = veri.Item("sirkettanimyetki")
                End If

                If Not veri.Item("acentetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetanimyetki = veri.Item("acentetanimyetki")
                End If

                If Not veri.Item("personeltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.personeltanimyetki = veri.Item("personeltanimyetki")
                End If

                If Not veri.Item("aractarifetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aractarifetanimyetki = veri.Item("aractarifetanimyetki")
                End If

                If Not veri.Item("ulketanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ulketanimyetki = veri.Item("ulketanimyetki")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekkullanicirol.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("yardimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.yardimyetki = veri.Item("yardimyetki")
                End If

                If Not veri.Item("mensup") Is System.DBNull.Value Then
                    donecekkullanicirol.mensup = veri.Item("mensup")
                End If

                If Not veri.Item("sirkettarafkullanicilisteyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullanicilisteyetki = veri.Item("sirkettarafkullanicilisteyetki")
                End If

                If Not veri.Item("zeylcodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.zeylcodetanimyetki = veri.Item("zeylcodetanimyetki")
                End If

                If Not veri.Item("urunkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.urunkodtanimyetki = veri.Item("urunkodtanimyetki")
                End If

                If Not veri.Item("currencycodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.currencycodetanimyetki = veri.Item("currencycodetanimyetki")
                End If

                If Not veri.Item("sirkettarafacenteyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafacenteyaratyetki = veri.Item("sirkettarafacenteyaratyetki")
                End If

                If Not veri.Item("hasardurumkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.hasardurumkodtanimyetki = veri.Item("hasardurumkodtanimyetki")
                End If

                If Not veri.Item("sadecesirketicimesajlasma") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicimesajlasma = veri.Item("sadecesirketicimesajlasma")
                End If

                If Not veri.Item("sadecesirketicidosyagonderimi") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicidosyagonderimi = veri.Item("sadecesirketicidosyagonderimi")
                End If

                If Not veri.Item("policetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.policetiptanimyetki = veri.Item("policetiptanimyetki")
                End If

                If Not veri.Item("faturalandirmayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.faturalandirmayetki = veri.Item("faturalandirmayetki")
                End If

                If Not veri.Item("acentetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetiptanimyetki = veri.Item("acentetiptanimyetki")
                End If

                If Not veri.Item("bazfiyatgirissureyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bazfiyatgirissureyetki = veri.Item("bazfiyatgirissureyetki")
                End If

                If Not veri.Item("sirketbazfiyatgirisyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirketbazfiyatgirisyetki = veri.Item("sirketbazfiyatgirisyetki")
                End If

                If Not veri.Item("sadecemerkezgozuk") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecemerkezgozuk = veri.Item("sadecemerkezgozuk")
                End If

                If Not veri.Item("kimlikturtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kimlikturtanimyetki = veri.Item("kimlikturtanimyetki")
                End If

                If Not veri.Item("dinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dinamikraporyetki = veri.Item("dinamikraporyetki")
                End If

                If Not veri.Item("adminpolicearayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminpolicearayetki = veri.Item("adminpolicearayetki")
                End If

                If Not veri.Item("adminhasararayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminhasararayetki = veri.Item("adminhasararayetki")
                End If

                If Not veri.Item("kuryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kuryetki = veri.Item("kuryetki")
                End If

                If Not veri.Item("tpbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tpbelgeyetki = veri.Item("tpbelgeyetki")
                End If

                If Not veri.Item("bekbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bekbelgeyetki = veri.Item("bekbelgeyetki")
                End If

                If Not veri.Item("birlikpersoneltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.birlikpersoneltanimyetki = veri.Item("birlikpersoneltanimyetki")
                End If

                If Not veri.Item("tanimlanmisdinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimlanmisdinamikraporyetki = veri.Item("tanimlanmisdinamikraporyetki")
                End If

                If Not veri.Item("iptallistesiyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.iptallistesiyetki = veri.Item("iptallistesiyetki")
                End If

                If Not veri.Item("parakambiyoaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.parakambiyoaramayetki = veri.Item("parakambiyoaramayetki")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkullanicirol

    End Function



    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal kullanicirol As CLASSKULLANICIROL) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update kullanicirol set " + _
        "rolad=@rolad," + _
        "tumsirketyetki=@tumsirketyetki," + _
        "yonsayfa=@yonsayfa," + _
        "panoyetki=@panoyetki," + _
        "islemyetki=@islemyetki," + _
        "aramayetki=@aramayetki," + _
        "tanimyetki=@tanimyetki," + _
        "fiyatyetki=@fiyatyetki," + _
        "belgeyonetimyetki=@belgeyonetimyetki," + _
        "resimyetki=@resimyetki," + _
        "kullaniciyonetimyetki=@kullaniciyonetimyetki," + _
        "raporyetki=@raporyetki," + _
        "logyetki=@logyetki," + _
        "mesajyetki=@mesajyetki," + _
        "ayaryetki=@ayaryetki," + _
        "sirkettarafaramayetki=@sirkettarafaramayetki," + _
        "servisayaryetki=@servisayaryetki," + _
        "sirkettarafkullaniciyaratyetki=@sirkettarafkullaniciyaratyetki," + _
        "profilyetki=@profilyetki," + _
        "toplumesajyetki=@toplumesajyetki," + _
        "dosyayetki=@dosyayetki," + _
        "sirkettarafraporerisim=@sirkettarafraporerisim," + _
        "rolsirkettarafindasecilebilsinmi=@rolsirkettarafindasecilebilsinmi," + _
        "sirkettanimyetki=@sirkettanimyetki," + _
        "acentetanimyetki=@acentetanimyetki," + _
        "personeltanimyetki=@personeltanimyetki," + _
        "aractarifetanimyetki=@aractarifetanimyetki," + _
        "ulketanimyetki=@ulketanimyetki," + _
        "anamenupkey=@anamenupkey," + _
        "yardimyetki=@yardimyetki," + _
        "mensup=@mensup," + _
        "sirkettarafkullanicilisteyetki=@sirkettarafkullanicilisteyetki," + _
        "zeylcodetanimyetki=@zeylcodetanimyetki," + _
        "urunkodtanimyetki=@urunkodtanimyetki," + _
        "currencycodetanimyetki=@currencycodetanimyetki," + _
        "sirkettarafacenteyaratyetki=@sirkettarafacenteyaratyetki," + _
        "hasardurumkodtanimyetki=@hasardurumkodtanimyetki," + _
        "sadecesirketicimesajlasma=@sadecesirketicimesajlasma," + _
        "sadecesirketicidosyagonderimi=@sadecesirketicidosyagonderimi," + _
        "policetiptanimyetki=@policetiptanimyetki," + _
        "faturalandirmayetki=@faturalandirmayetki," + _
        "acentetiptanimyetki=@acentetiptanimyetki," + _
        "bazfiyatgirissureyetki=@bazfiyatgirissureyetki," + _
        "sirketbazfiyatgirisyetki=@sirketbazfiyatgirisyetki," + _
        "sadecemerkezgozuk=@sadecemerkezgozuk," + _
        "kimlikturtanimyetki=@kimlikturtanimyetki," + _
        "dinamikraporyetki=@dinamikraporyetki," + _
        "adminpolicearayetki=@adminpolicearayetki," + _
        "adminhasararayetki=@adminhasararayetki," + _
        "kuryetki=@kuryetki," + _
        "tpbelgeyetki=@tpbelgeyetki," + _
        "bekbelgeyetki=@bekbelgeyetki," + _
        "birlikpersoneltanimyetki=@birlikpersoneltanimyetki," + _
        "tanimlanmisdinamikraporyetki=@tanimlanmisdinamikraporyetki," + _
        "iptallistesiyetki=@iptallistesiyetki," + _
        "parakambiyoaramayetki=@parakambiyoaramayetki" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kullanicirol.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@rolad", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If kullanicirol.rolad = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = kullanicirol.rolad
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@tumsirketyetki", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If kullanicirol.tumsirketyetki = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = kullanicirol.tumsirketyetki
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@yonsayfa", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If kullanicirol.yonsayfa = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = kullanicirol.yonsayfa
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@panoyetki", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If kullanicirol.panoyetki = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = kullanicirol.panoyetki
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@islemyetki", SqlDbType.VarChar)
        param6.Direction = ParameterDirection.Input
        If kullanicirol.islemyetki = "" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = kullanicirol.islemyetki
        End If
        komut.Parameters.Add(param6)

        Dim param7 As New SqlParameter("@aramayetki", SqlDbType.VarChar)
        param7.Direction = ParameterDirection.Input
        If kullanicirol.aramayetki = "" Then
            param7.Value = System.DBNull.Value
        Else
            param7.Value = kullanicirol.aramayetki
        End If
        komut.Parameters.Add(param7)

        Dim param8 As New SqlParameter("@tanimyetki", SqlDbType.VarChar)
        param8.Direction = ParameterDirection.Input
        If kullanicirol.tanimyetki = "" Then
            param8.Value = System.DBNull.Value
        Else
            param8.Value = kullanicirol.tanimyetki
        End If
        komut.Parameters.Add(param8)

        Dim param9 As New SqlParameter("@fiyatyetki", SqlDbType.VarChar)
        param9.Direction = ParameterDirection.Input
        If kullanicirol.fiyatyetki = "" Then
            param9.Value = System.DBNull.Value
        Else
            param9.Value = kullanicirol.fiyatyetki
        End If
        komut.Parameters.Add(param9)

        Dim param10 As New SqlParameter("@belgeyonetimyetki", SqlDbType.VarChar)
        param10.Direction = ParameterDirection.Input
        If kullanicirol.belgeyonetimyetki = "" Then
            param10.Value = System.DBNull.Value
        Else
            param10.Value = kullanicirol.belgeyonetimyetki
        End If
        komut.Parameters.Add(param10)

        Dim param11 As New SqlParameter("@resimyetki", SqlDbType.VarChar)
        param11.Direction = ParameterDirection.Input
        If kullanicirol.resimyetki = "" Then
            param11.Value = System.DBNull.Value
        Else
            param11.Value = kullanicirol.resimyetki
        End If
        komut.Parameters.Add(param11)

        Dim param12 As New SqlParameter("@kullaniciyonetimyetki", SqlDbType.VarChar)
        param12.Direction = ParameterDirection.Input
        If kullanicirol.kullaniciyonetimyetki = "" Then
            param12.Value = System.DBNull.Value
        Else
            param12.Value = kullanicirol.kullaniciyonetimyetki
        End If
        komut.Parameters.Add(param12)

        Dim param13 As New SqlParameter("@raporyetki", SqlDbType.VarChar)
        param13.Direction = ParameterDirection.Input
        If kullanicirol.raporyetki = "" Then
            param13.Value = System.DBNull.Value
        Else
            param13.Value = kullanicirol.raporyetki
        End If
        komut.Parameters.Add(param13)

        Dim param14 As New SqlParameter("@logyetki", SqlDbType.VarChar)
        param14.Direction = ParameterDirection.Input
        If kullanicirol.logyetki = "" Then
            param14.Value = System.DBNull.Value
        Else
            param14.Value = kullanicirol.logyetki
        End If
        komut.Parameters.Add(param14)

        Dim param15 As New SqlParameter("@mesajyetki", SqlDbType.VarChar)
        param15.Direction = ParameterDirection.Input
        If kullanicirol.mesajyetki = "" Then
            param15.Value = System.DBNull.Value
        Else
            param15.Value = kullanicirol.mesajyetki
        End If
        komut.Parameters.Add(param15)

        Dim param16 As New SqlParameter("@ayaryetki", SqlDbType.VarChar)
        param16.Direction = ParameterDirection.Input
        If kullanicirol.ayaryetki = "" Then
            param16.Value = System.DBNull.Value
        Else
            param16.Value = kullanicirol.ayaryetki
        End If
        komut.Parameters.Add(param16)

        Dim param17 As New SqlParameter("@sirkettarafaramayetki", SqlDbType.VarChar)
        param17.Direction = ParameterDirection.Input
        If kullanicirol.sirkettarafaramayetki = "" Then
            param17.Value = System.DBNull.Value
        Else
            param17.Value = kullanicirol.sirkettarafaramayetki
        End If
        komut.Parameters.Add(param17)

        Dim param18 As New SqlParameter("@servisayaryetki", SqlDbType.VarChar)
        param18.Direction = ParameterDirection.Input
        If kullanicirol.servisayaryetki = "" Then
            param18.Value = System.DBNull.Value
        Else
            param18.Value = kullanicirol.servisayaryetki
        End If
        komut.Parameters.Add(param18)

        Dim param19 As New SqlParameter("@sirkettarafkullaniciyaratyetki", SqlDbType.VarChar)
        param19.Direction = ParameterDirection.Input
        If kullanicirol.sirkettarafkullaniciyaratyetki = "" Then
            param19.Value = System.DBNull.Value
        Else
            param19.Value = kullanicirol.sirkettarafkullaniciyaratyetki
        End If
        komut.Parameters.Add(param19)

        Dim param20 As New SqlParameter("@profilyetki", SqlDbType.VarChar)
        param20.Direction = ParameterDirection.Input
        If kullanicirol.profilyetki = "" Then
            param20.Value = System.DBNull.Value
        Else
            param20.Value = kullanicirol.profilyetki
        End If
        komut.Parameters.Add(param20)

        Dim param21 As New SqlParameter("@toplumesajyetki", SqlDbType.VarChar)
        param21.Direction = ParameterDirection.Input
        If kullanicirol.toplumesajyetki = "" Then
            param21.Value = System.DBNull.Value
        Else
            param21.Value = kullanicirol.toplumesajyetki
        End If
        komut.Parameters.Add(param21)

        Dim param22 As New SqlParameter("@dosyayetki", SqlDbType.VarChar)
        param22.Direction = ParameterDirection.Input
        If kullanicirol.dosyayetki = "" Then
            param22.Value = System.DBNull.Value
        Else
            param22.Value = kullanicirol.dosyayetki
        End If
        komut.Parameters.Add(param22)

        Dim param23 As New SqlParameter("@sirkettarafraporerisim", SqlDbType.VarChar)
        param23.Direction = ParameterDirection.Input
        If kullanicirol.sirkettarafraporerisim = "" Then
            param23.Value = System.DBNull.Value
        Else
            param23.Value = kullanicirol.sirkettarafraporerisim
        End If
        komut.Parameters.Add(param23)

        Dim param24 As New SqlParameter("@rolsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
        param24.Direction = ParameterDirection.Input
        If kullanicirol.rolsirkettarafindasecilebilsinmi = "" Then
            param24.Value = System.DBNull.Value
        Else
            param24.Value = kullanicirol.rolsirkettarafindasecilebilsinmi
        End If
        komut.Parameters.Add(param24)

        Dim param25 As New SqlParameter("@sirkettanimyetki", SqlDbType.VarChar)
        param25.Direction = ParameterDirection.Input
        If kullanicirol.sirkettanimyetki = "" Then
            param25.Value = System.DBNull.Value
        Else
            param25.Value = kullanicirol.sirkettanimyetki
        End If
        komut.Parameters.Add(param25)

        Dim param26 As New SqlParameter("@acentetanimyetki", SqlDbType.VarChar)
        param26.Direction = ParameterDirection.Input
        If kullanicirol.acentetanimyetki = "" Then
            param26.Value = System.DBNull.Value
        Else
            param26.Value = kullanicirol.acentetanimyetki
        End If
        komut.Parameters.Add(param26)

        Dim param27 As New SqlParameter("@personeltanimyetki", SqlDbType.VarChar)
        param27.Direction = ParameterDirection.Input
        If kullanicirol.personeltanimyetki = "" Then
            param27.Value = System.DBNull.Value
        Else
            param27.Value = kullanicirol.personeltanimyetki
        End If
        komut.Parameters.Add(param27)

        Dim param28 As New SqlParameter("@aractarifetanimyetki", SqlDbType.VarChar)
        param28.Direction = ParameterDirection.Input
        If kullanicirol.aractarifetanimyetki = "" Then
            param28.Value = System.DBNull.Value
        Else
            param28.Value = kullanicirol.aractarifetanimyetki
        End If
        komut.Parameters.Add(param28)

        Dim param29 As New SqlParameter("@ulketanimyetki", SqlDbType.VarChar)
        param29.Direction = ParameterDirection.Input
        If kullanicirol.ulketanimyetki = "" Then
            param29.Value = System.DBNull.Value
        Else
            param29.Value = kullanicirol.ulketanimyetki
        End If
        komut.Parameters.Add(param29)

        Dim param30 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param30.Direction = ParameterDirection.Input
        If kullanicirol.anamenupkey = 0 Then
            param30.Value = 0
        Else
            param30.Value = kullanicirol.anamenupkey
        End If
        komut.Parameters.Add(param30)

        Dim param31 As New SqlParameter("@yardimyetki", SqlDbType.VarChar)
        param31.Direction = ParameterDirection.Input
        If kullanicirol.yardimyetki = "" Then
            param31.Value = System.DBNull.Value
        Else
            param31.Value = kullanicirol.yardimyetki
        End If
        komut.Parameters.Add(param31)

        Dim param32 As New SqlParameter("@mensup", SqlDbType.VarChar)
        param32.Direction = ParameterDirection.Input
        If kullanicirol.mensup = "" Then
            param32.Value = System.DBNull.Value
        Else
            param32.Value = kullanicirol.mensup
        End If
        komut.Parameters.Add(param32)

        Dim param33 As New SqlParameter("@sirkettarafkullanicilisteyetki", SqlDbType.VarChar)
        param33.Direction = ParameterDirection.Input
        If kullanicirol.sirkettarafkullanicilisteyetki = "" Then
            param33.Value = System.DBNull.Value
        Else
            param33.Value = kullanicirol.sirkettarafkullanicilisteyetki
        End If
        komut.Parameters.Add(param33)

        Dim param34 As New SqlParameter("@zeylcodetanimyetki", SqlDbType.VarChar)
        param34.Direction = ParameterDirection.Input
        If kullanicirol.zeylcodetanimyetki = "" Then
            param34.Value = System.DBNull.Value
        Else
            param34.Value = kullanicirol.zeylcodetanimyetki
        End If
        komut.Parameters.Add(param34)

        Dim param35 As New SqlParameter("@urunkodtanimyetki", SqlDbType.VarChar)
        param35.Direction = ParameterDirection.Input
        If kullanicirol.urunkodtanimyetki = "" Then
            param35.Value = System.DBNull.Value
        Else
            param35.Value = kullanicirol.urunkodtanimyetki
        End If
        komut.Parameters.Add(param35)

        Dim param36 As New SqlParameter("@currencycodetanimyetki", SqlDbType.VarChar)
        param36.Direction = ParameterDirection.Input
        If kullanicirol.currencycodetanimyetki = "" Then
            param36.Value = System.DBNull.Value
        Else
            param36.Value = kullanicirol.currencycodetanimyetki
        End If
        komut.Parameters.Add(param36)

        Dim param37 As New SqlParameter("@sirkettarafacenteyaratyetki", SqlDbType.VarChar)
        param37.Direction = ParameterDirection.Input
        If kullanicirol.sirkettarafacenteyaratyetki = "" Then
            param37.Value = System.DBNull.Value
        Else
            param37.Value = kullanicirol.sirkettarafacenteyaratyetki
        End If
        komut.Parameters.Add(param37)


        Dim param38 As New SqlParameter("@hasardurumkodtanimyetki", SqlDbType.VarChar)
        param38.Direction = ParameterDirection.Input
        If kullanicirol.hasardurumkodtanimyetki = "" Then
            param38.Value = System.DBNull.Value
        Else
            param38.Value = kullanicirol.hasardurumkodtanimyetki
        End If
        komut.Parameters.Add(param38)

        Dim param39 As New SqlParameter("@sadecesirketicimesajlasma", SqlDbType.VarChar)
        param39.Direction = ParameterDirection.Input
        If kullanicirol.sadecesirketicimesajlasma = "" Then
            param39.Value = System.DBNull.Value
        Else
            param39.Value = kullanicirol.sadecesirketicimesajlasma
        End If
        komut.Parameters.Add(param39)

        Dim param40 As New SqlParameter("@sadecesirketicidosyagonderimi", SqlDbType.VarChar)
        param40.Direction = ParameterDirection.Input
        If kullanicirol.sadecesirketicidosyagonderimi = "" Then
            param40.Value = System.DBNull.Value
        Else
            param40.Value = kullanicirol.sadecesirketicidosyagonderimi
        End If
        komut.Parameters.Add(param40)

        Dim param41 As New SqlParameter("@policetiptanimyetki", SqlDbType.VarChar)
        param41.Direction = ParameterDirection.Input
        If kullanicirol.policetiptanimyetki = "" Then
            param41.Value = System.DBNull.Value
        Else
            param41.Value = kullanicirol.policetiptanimyetki
        End If
        komut.Parameters.Add(param41)

        Dim param42 As New SqlParameter("@faturalandirmayetki", SqlDbType.VarChar)
        param42.Direction = ParameterDirection.Input
        If kullanicirol.faturalandirmayetki = "" Then
            param42.Value = System.DBNull.Value
        Else
            param42.Value = kullanicirol.faturalandirmayetki
        End If
        komut.Parameters.Add(param42)

        Dim param43 As New SqlParameter("@acentetiptanimyetki", SqlDbType.VarChar)
        param43.Direction = ParameterDirection.Input
        If kullanicirol.acentetiptanimyetki = "" Then
            param43.Value = System.DBNull.Value
        Else
            param43.Value = kullanicirol.acentetiptanimyetki
        End If
        komut.Parameters.Add(param43)

        Dim param44 As New SqlParameter("@bazfiyatgirissureyetki", SqlDbType.VarChar)
        param44.Direction = ParameterDirection.Input
        If kullanicirol.bazfiyatgirissureyetki = "" Then
            param44.Value = System.DBNull.Value
        Else
            param44.Value = kullanicirol.bazfiyatgirissureyetki
        End If
        komut.Parameters.Add(param44)

        Dim param45 As New SqlParameter("@sirketbazfiyatgirisyetki", SqlDbType.VarChar)
        param45.Direction = ParameterDirection.Input
        If kullanicirol.sirketbazfiyatgirisyetki = "" Then
            param45.Value = System.DBNull.Value
        Else
            param45.Value = kullanicirol.sirketbazfiyatgirisyetki
        End If
        komut.Parameters.Add(param45)

        Dim param46 As New SqlParameter("@sadecemerkezgozuk", SqlDbType.VarChar)
        param46.Direction = ParameterDirection.Input
        If kullanicirol.sadecemerkezgozuk = "" Then
            param46.Value = System.DBNull.Value
        Else
            param46.Value = kullanicirol.sadecemerkezgozuk
        End If
        komut.Parameters.Add(param46)

        Dim param47 As New SqlParameter("@kimlikturtanimyetki", SqlDbType.VarChar)
        param47.Direction = ParameterDirection.Input
        If kullanicirol.kimlikturtanimyetki = "" Then
            param47.Value = System.DBNull.Value
        Else
            param47.Value = kullanicirol.kimlikturtanimyetki
        End If
        komut.Parameters.Add(param47)

        Dim param48 As New SqlParameter("@dinamikraporyetki", SqlDbType.VarChar)
        param48.Direction = ParameterDirection.Input
        If kullanicirol.dinamikraporyetki = "" Then
            param48.Value = System.DBNull.Value
        Else
            param48.Value = kullanicirol.dinamikraporyetki
        End If
        komut.Parameters.Add(param48)

        Dim param49 As New SqlParameter("@adminpolicearayetki", SqlDbType.VarChar)
        param49.Direction = ParameterDirection.Input
        If kullanicirol.adminpolicearayetki = "" Then
            param49.Value = System.DBNull.Value
        Else
            param49.Value = kullanicirol.adminpolicearayetki
        End If
        komut.Parameters.Add(param49)

        Dim param50 As New SqlParameter("@adminhasararayetki", SqlDbType.VarChar)
        param50.Direction = ParameterDirection.Input
        If kullanicirol.adminhasararayetki = "" Then
            param50.Value = System.DBNull.Value
        Else
            param50.Value = kullanicirol.adminhasararayetki
        End If
        komut.Parameters.Add(param50)

        Dim param51 As New SqlParameter("@kuryetki", SqlDbType.VarChar)
        param51.Direction = ParameterDirection.Input
        If kullanicirol.kuryetki = "" Then
            param51.Value = System.DBNull.Value
        Else
            param51.Value = kullanicirol.kuryetki
        End If
        komut.Parameters.Add(param51)

        Dim param52 As New SqlParameter("@tpbelgeyetki", SqlDbType.VarChar)
        param52.Direction = ParameterDirection.Input
        If kullanicirol.tpbelgeyetki = "" Then
            param52.Value = System.DBNull.Value
        Else
            param52.Value = kullanicirol.tpbelgeyetki
        End If
        komut.Parameters.Add(param52)

        Dim param53 As New SqlParameter("@bekbelgeyetki", SqlDbType.VarChar)
        param53.Direction = ParameterDirection.Input
        If kullanicirol.bekbelgeyetki = "" Then
            param53.Value = System.DBNull.Value
        Else
            param53.Value = kullanicirol.bekbelgeyetki
        End If
        komut.Parameters.Add(param53)

        Dim param54 As New SqlParameter("@birlikpersoneltanimyetki", SqlDbType.VarChar)
        param54.Direction = ParameterDirection.Input
        If kullanicirol.birlikpersoneltanimyetki = "" Then
            param54.Value = System.DBNull.Value
        Else
            param54.Value = kullanicirol.birlikpersoneltanimyetki
        End If
        komut.Parameters.Add(param54)

        Dim param55 As New SqlParameter("@tanimlanmisdinamikraporyetki", SqlDbType.VarChar)
        param55.Direction = ParameterDirection.Input
        If kullanicirol.tanimlanmisdinamikraporyetki = "" Then
            param55.Value = System.DBNull.Value
        Else
            param55.Value = kullanicirol.tanimlanmisdinamikraporyetki
        End If
        komut.Parameters.Add(param55)

        Dim param56 As New SqlParameter("@iptallistesiyetki", SqlDbType.VarChar)
        param56.Direction = ParameterDirection.Input
        If kullanicirol.iptallistesiyetki = "" Then
            param56.Value = System.DBNull.Value
        Else
            param56.Value = kullanicirol.iptallistesiyetki
        End If
        komut.Parameters.Add(param56)

        Dim param57 As New SqlParameter("@parakambiyoaramayetki", SqlDbType.VarChar)
        param57.Direction = ParameterDirection.Input
        If kullanicirol.parakambiyoaramayetki = "" Then
            param57.Value = System.DBNull.Value
        Else
            param57.Value = kullanicirol.parakambiyoaramayetki
        End If
        komut.Parameters.Add(param57)


        Try
            etkilenen = komut.ExecuteNonQuery()
        Catch ex As Exception
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = ex.Message
            resultset.etkilenen = 0
        Finally
            komut.Dispose()
        End Try
        If etkilenen > 0 Then
            resultset.durum = "Kaydedildi"
            resultset.hatastr = ""
            resultset.etkilenen = etkilenen
        End If
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return resultset

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim etkilenen As Integer
        Dim resultset As New CLADBOPRESULT
        Dim varmi As String
        Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
        varmi = kullanici_erisim.rolvarmi(pkey)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu rolde tanımlı " + _
            "kullanıcılar olduğundan bu kullanıcı rolünü silemezsiniz."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then

            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()

            sqlstr = "delete from kullanicirol where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkey
            komut.Parameters.Add(param1)

            Try
                etkilenen = komut.ExecuteNonQuery()
            Catch ex As Exception
                resultset.durum = "Kayıt yapılamadı."
                resultset.hatastr = ex.Message
                resultset.etkilenen = 0
            Finally
                komut.Dispose()
            End Try

            If etkilenen > 0 Then
                resultset.durum = "Kaydedildi"
                resultset.hatastr = ""
                resultset.etkilenen = etkilenen
            End If

            db_baglanti.Close()
            db_baglanti.Dispose()

        End If

        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSKULLANICIROL)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanicirol As New CLASSKULLANICIROL
        Dim kullaniciroller As New List(Of CLASSKULLANICIROL)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanicirol"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicirol.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("rolad") Is System.DBNull.Value Then
                    donecekkullanicirol.rolad = veri.Item("rolad")
                End If

                If Not veri.Item("tumsirketyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tumsirketyetki = veri.Item("tumsirketyetki")
                End If

                If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                    donecekkullanicirol.yonsayfa = veri.Item("yonsayfa")
                End If

                If Not veri.Item("panoyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.panoyetki = veri.Item("panoyetki")
                End If

                If Not veri.Item("islemyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.islemyetki = veri.Item("islemyetki")
                End If

                If Not veri.Item("aramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aramayetki = veri.Item("aramayetki")
                End If

                If Not veri.Item("tanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimyetki = veri.Item("tanimyetki")
                End If

                If Not veri.Item("fiyatyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.fiyatyetki = veri.Item("fiyatyetki")
                End If

                If Not veri.Item("belgeyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.belgeyonetimyetki = veri.Item("belgeyonetimyetki")
                End If

                If Not veri.Item("resimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.resimyetki = veri.Item("resimyetki")
                End If

                If Not veri.Item("kullaniciyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kullaniciyonetimyetki = veri.Item("kullaniciyonetimyetki")
                End If

                If Not veri.Item("raporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.raporyetki = veri.Item("raporyetki")
                End If

                If Not veri.Item("logyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.logyetki = veri.Item("logyetki")
                End If

                If Not veri.Item("mesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.mesajyetki = veri.Item("mesajyetki")
                End If

                If Not veri.Item("ayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ayaryetki = veri.Item("ayaryetki")
                End If

                If Not veri.Item("sirkettarafaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafaramayetki = veri.Item("sirkettarafaramayetki")
                End If

                If Not veri.Item("servisayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.servisayaryetki = veri.Item("servisayaryetki")
                End If

                If Not veri.Item("sirkettarafkullaniciyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullaniciyaratyetki = veri.Item("sirkettarafkullaniciyaratyetki")
                End If

                If Not veri.Item("profilyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.profilyetki = veri.Item("profilyetki")
                End If

                If Not veri.Item("toplumesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.toplumesajyetki = veri.Item("toplumesajyetki")
                End If

                If Not veri.Item("dosyayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dosyayetki = veri.Item("dosyayetki")
                End If

                If Not veri.Item("sirkettarafraporerisim") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafraporerisim = veri.Item("sirkettarafraporerisim")
                End If

                If Not veri.Item("rolsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicirol.rolsirkettarafindasecilebilsinmi = veri.Item("rolsirkettarafindasecilebilsinmi")
                End If

                If Not veri.Item("sirkettanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettanimyetki = veri.Item("sirkettanimyetki")
                End If

                If Not veri.Item("acentetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetanimyetki = veri.Item("acentetanimyetki")
                End If

                If Not veri.Item("personeltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.personeltanimyetki = veri.Item("personeltanimyetki")
                End If

                If Not veri.Item("aractarifetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aractarifetanimyetki = veri.Item("aractarifetanimyetki")
                End If

                If Not veri.Item("ulketanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ulketanimyetki = veri.Item("ulketanimyetki")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekkullanicirol.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("yardimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.yardimyetki = veri.Item("yardimyetki")
                End If

                If Not veri.Item("mensup") Is System.DBNull.Value Then
                    donecekkullanicirol.mensup = veri.Item("mensup")
                End If

                If Not veri.Item("sirkettarafkullanicilisteyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullanicilisteyetki = veri.Item("sirkettarafkullanicilisteyetki")
                End If

                If Not veri.Item("zeylcodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.zeylcodetanimyetki = veri.Item("zeylcodetanimyetki")
                End If

                If Not veri.Item("urunkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.urunkodtanimyetki = veri.Item("urunkodtanimyetki")
                End If

                If Not veri.Item("currencycodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.currencycodetanimyetki = veri.Item("currencycodetanimyetki")
                End If

                If Not veri.Item("sirkettarafacenteyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafacenteyaratyetki = veri.Item("sirkettarafacenteyaratyetki")
                End If

                If Not veri.Item("hasardurumkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.hasardurumkodtanimyetki = veri.Item("hasardurumkodtanimyetki")
                End If

                If Not veri.Item("sadecesirketicimesajlasma") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicimesajlasma = veri.Item("sadecesirketicimesajlasma")
                End If

                If Not veri.Item("sadecesirketicidosyagonderimi") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicidosyagonderimi = veri.Item("sadecesirketicidosyagonderimi")
                End If

                If Not veri.Item("policetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.policetiptanimyetki = veri.Item("policetiptanimyetki")
                End If

                If Not veri.Item("faturalandirmayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.faturalandirmayetki = veri.Item("faturalandirmayetki")
                End If

                If Not veri.Item("acentetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetiptanimyetki = veri.Item("acentetiptanimyetki")
                End If

                If Not veri.Item("bazfiyatgirissureyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bazfiyatgirissureyetki = veri.Item("bazfiyatgirissureyetki")
                End If

                If Not veri.Item("sirketbazfiyatgirisyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirketbazfiyatgirisyetki = veri.Item("sirketbazfiyatgirisyetki")
                End If

                If Not veri.Item("sadecemerkezgozuk") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecemerkezgozuk = veri.Item("sadecemerkezgozuk")
                End If

                If Not veri.Item("kimlikturtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kimlikturtanimyetki = veri.Item("kimlikturtanimyetki")
                End If

                If Not veri.Item("dinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dinamikraporyetki = veri.Item("dinamikraporyetki")
                End If

                If Not veri.Item("adminpolicearayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminpolicearayetki = veri.Item("adminpolicearayetki")
                End If

                If Not veri.Item("adminhasararayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminhasararayetki = veri.Item("adminhasararayetki")
                End If

                If Not veri.Item("kuryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kuryetki = veri.Item("kuryetki")
                End If

                If Not veri.Item("tpbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tpbelgeyetki = veri.Item("tpbelgeyetki")
                End If

                If Not veri.Item("bekbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bekbelgeyetki = veri.Item("bekbelgeyetki")
                End If

                If Not veri.Item("birlikpersoneltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.birlikpersoneltanimyetki = veri.Item("birlikpersoneltanimyetki")
                End If

                If Not veri.Item("tanimlanmisdinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimlanmisdinamikraporyetki = veri.Item("tanimlanmisdinamikraporyetki")
                End If

                If Not veri.Item("iptallistesiyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.iptallistesiyetki = veri.Item("iptallistesiyetki")
                End If

                If Not veri.Item("parakambiyoaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.parakambiyoaramayetki = veri.Item("parakambiyoaramayetki")
                End If



                kullaniciroller.Add(New CLASSKULLANICIROL(donecekkullanicirol.pkey, _
                donecekkullanicirol.rolad, donecekkullanicirol.tumsirketyetki, donecekkullanicirol.yonsayfa, donecekkullanicirol.panoyetki, _
                donecekkullanicirol.islemyetki, donecekkullanicirol.aramayetki, donecekkullanicirol.tanimyetki, donecekkullanicirol.fiyatyetki, _
                donecekkullanicirol.belgeyonetimyetki, donecekkullanicirol.resimyetki, donecekkullanicirol.kullaniciyonetimyetki, donecekkullanicirol.raporyetki, _
                donecekkullanicirol.logyetki, donecekkullanicirol.mesajyetki, donecekkullanicirol.ayaryetki, donecekkullanicirol.sirkettarafaramayetki, _
                donecekkullanicirol.servisayaryetki, donecekkullanicirol.sirkettarafkullaniciyaratyetki, donecekkullanicirol.profilyetki, donecekkullanicirol.toplumesajyetki, _
                donecekkullanicirol.dosyayetki, donecekkullanicirol.sirkettarafraporerisim, donecekkullanicirol.rolsirkettarafindasecilebilsinmi, donecekkullanicirol.sirkettanimyetki, _
                donecekkullanicirol.acentetanimyetki, donecekkullanicirol.personeltanimyetki, donecekkullanicirol.aractarifetanimyetki, donecekkullanicirol.ulketanimyetki, _
                donecekkullanicirol.anamenupkey, donecekkullanicirol.yardimyetki, donecekkullanicirol.mensup, _
                donecekkullanicirol.sirkettarafkullanicilisteyetki, donecekkullanicirol.zeylcodetanimyetki, _
                donecekkullanicirol.urunkodtanimyetki, donecekkullanicirol.currencycodetanimyetki, _
                donecekkullanicirol.sirkettarafacenteyaratyetki, donecekkullanicirol.hasardurumkodtanimyetki, _
                donecekkullanicirol.sadecesirketicimesajlasma, donecekkullanicirol.sadecesirketicidosyagonderimi, _
                donecekkullanicirol.policetiptanimyetki, donecekkullanicirol.faturalandirmayetki, _
                donecekkullanicirol.acentetiptanimyetki, donecekkullanicirol.bazfiyatgirissureyetki, _
                donecekkullanicirol.sirketbazfiyatgirisyetki, donecekkullanicirol.sadecemerkezgozuk, _
                donecekkullanicirol.kimlikturtanimyetki, donecekkullanicirol.dinamikraporyetki, _
                donecekkullanicirol.adminpolicearayetki, donecekkullanicirol.adminhasararayetki, _
                donecekkullanicirol.kuryetki, donecekkullanicirol.tpbelgeyetki, donecekkullanicirol.bekbelgeyetki, _
                donecekkullanicirol.birlikpersoneltanimyetki, donecekkullanicirol.tanimlanmisdinamikraporyetki, _
                donecekkullanicirol.iptallistesiyetki, donecekkullanicirol.parakambiyoaramayetki))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullaniciroller

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_sadecesirketinverebilecegi_rol(ByVal merkezhangisi As String) As List(Of CLASSKULLANICIROL)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanicirol As New CLASSKULLANICIROL
        Dim kullaniciroller As New List(Of CLASSKULLANICIROL)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanicirol where " + _
        "rolsirkettarafindasecilebilsinmi=@rolsirkettarafindasecilebilsinmi and " + _
        "sadecemerkezgozuk=@sadecemerkezgozuk"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@rolsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "Evet"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@sadecemerkezgozuk", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = merkezhangisi
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicirol.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("rolad") Is System.DBNull.Value Then
                    donecekkullanicirol.rolad = veri.Item("rolad")
                End If

                If Not veri.Item("tumsirketyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tumsirketyetki = veri.Item("tumsirketyetki")
                End If

                If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                    donecekkullanicirol.yonsayfa = veri.Item("yonsayfa")
                End If

                If Not veri.Item("panoyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.panoyetki = veri.Item("panoyetki")
                End If

                If Not veri.Item("islemyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.islemyetki = veri.Item("islemyetki")
                End If

                If Not veri.Item("aramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aramayetki = veri.Item("aramayetki")
                End If

                If Not veri.Item("tanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimyetki = veri.Item("tanimyetki")
                End If

                If Not veri.Item("fiyatyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.fiyatyetki = veri.Item("fiyatyetki")
                End If

                If Not veri.Item("belgeyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.belgeyonetimyetki = veri.Item("belgeyonetimyetki")
                End If

                If Not veri.Item("resimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.resimyetki = veri.Item("resimyetki")
                End If

                If Not veri.Item("kullaniciyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kullaniciyonetimyetki = veri.Item("kullaniciyonetimyetki")
                End If

                If Not veri.Item("raporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.raporyetki = veri.Item("raporyetki")
                End If

                If Not veri.Item("logyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.logyetki = veri.Item("logyetki")
                End If

                If Not veri.Item("mesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.mesajyetki = veri.Item("mesajyetki")
                End If

                If Not veri.Item("ayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ayaryetki = veri.Item("ayaryetki")
                End If

                If Not veri.Item("sirkettarafaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafaramayetki = veri.Item("sirkettarafaramayetki")
                End If

                If Not veri.Item("servisayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.servisayaryetki = veri.Item("servisayaryetki")
                End If

                If Not veri.Item("sirkettarafkullaniciyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullaniciyaratyetki = veri.Item("sirkettarafkullaniciyaratyetki")
                End If

                If Not veri.Item("profilyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.profilyetki = veri.Item("profilyetki")
                End If

                If Not veri.Item("toplumesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.toplumesajyetki = veri.Item("toplumesajyetki")
                End If

                If Not veri.Item("dosyayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dosyayetki = veri.Item("dosyayetki")
                End If

                If Not veri.Item("sirkettarafraporerisim") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafraporerisim = veri.Item("sirkettarafraporerisim")
                End If

                If Not veri.Item("rolsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicirol.rolsirkettarafindasecilebilsinmi = veri.Item("rolsirkettarafindasecilebilsinmi")
                End If

                If Not veri.Item("sirkettanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettanimyetki = veri.Item("sirkettanimyetki")
                End If

                If Not veri.Item("acentetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetanimyetki = veri.Item("acentetanimyetki")
                End If

                If Not veri.Item("personeltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.personeltanimyetki = veri.Item("personeltanimyetki")
                End If

                If Not veri.Item("aractarifetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aractarifetanimyetki = veri.Item("aractarifetanimyetki")
                End If

                If Not veri.Item("ulketanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ulketanimyetki = veri.Item("ulketanimyetki")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekkullanicirol.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("yardimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.yardimyetki = veri.Item("yardimyetki")
                End If

                If Not veri.Item("mensup") Is System.DBNull.Value Then
                    donecekkullanicirol.mensup = veri.Item("mensup")
                End If

                If Not veri.Item("sirkettarafkullanicilisteyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullanicilisteyetki = veri.Item("sirkettarafkullanicilisteyetki")
                End If

                If Not veri.Item("zeylcodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.zeylcodetanimyetki = veri.Item("zeylcodetanimyetki")
                End If

                If Not veri.Item("urunkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.urunkodtanimyetki = veri.Item("urunkodtanimyetki")
                End If

                If Not veri.Item("currencycodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.currencycodetanimyetki = veri.Item("currencycodetanimyetki")
                End If

                If Not veri.Item("sirkettarafacenteyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafacenteyaratyetki = veri.Item("sirkettarafacenteyaratyetki")
                End If

                If Not veri.Item("hasardurumkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.hasardurumkodtanimyetki = veri.Item("hasardurumkodtanimyetki")
                End If

                If Not veri.Item("sadecesirketicimesajlasma") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicimesajlasma = veri.Item("sadecesirketicimesajlasma")
                End If

                If Not veri.Item("sadecesirketicidosyagonderimi") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicidosyagonderimi = veri.Item("sadecesirketicidosyagonderimi")
                End If

                If Not veri.Item("policetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.policetiptanimyetki = veri.Item("policetiptanimyetki")
                End If

                If Not veri.Item("faturalandirmayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.faturalandirmayetki = veri.Item("faturalandirmayetki")
                End If

                If Not veri.Item("acentetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetiptanimyetki = veri.Item("acentetiptanimyetki")
                End If

                If Not veri.Item("bazfiyatgirissureyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bazfiyatgirissureyetki = veri.Item("bazfiyatgirissureyetki")
                End If

                If Not veri.Item("sirketbazfiyatgirisyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirketbazfiyatgirisyetki = veri.Item("sirketbazfiyatgirisyetki")
                End If

                If Not veri.Item("sadecemerkezgozuk") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecemerkezgozuk = veri.Item("sadecemerkezgozuk")
                End If

                If Not veri.Item("kimlikturtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kimlikturtanimyetki = veri.Item("kimlikturtanimyetki")
                End If

                If Not veri.Item("dinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dinamikraporyetki = veri.Item("dinamikraporyetki")
                End If

                If Not veri.Item("adminpolicearayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminpolicearayetki = veri.Item("adminpolicearayetki")
                End If

                If Not veri.Item("adminhasararayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminhasararayetki = veri.Item("adminhasararayetki")
                End If

                If Not veri.Item("kuryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kuryetki = veri.Item("kuryetki")
                End If

                If Not veri.Item("tpbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tpbelgeyetki = veri.Item("tpbelgeyetki")
                End If

                If Not veri.Item("bekbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bekbelgeyetki = veri.Item("bekbelgeyetki")
                End If

                If Not veri.Item("birlikpersoneltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.birlikpersoneltanimyetki = veri.Item("birlikpersoneltanimyetki")
                End If

                If Not veri.Item("tanimlanmisdinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimlanmisdinamikraporyetki = veri.Item("tanimlanmisdinamikraporyetki")
                End If

                If Not veri.Item("iptallistesiyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.iptallistesiyetki = veri.Item("iptallistesiyetki")
                End If

                If Not veri.Item("parakambiyoaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.parakambiyoaramayetki = veri.Item("parakambiyoaramayetki")
                End If

                kullaniciroller.Add(New CLASSKULLANICIROL(donecekkullanicirol.pkey, _
                donecekkullanicirol.rolad, donecekkullanicirol.tumsirketyetki, donecekkullanicirol.yonsayfa, donecekkullanicirol.panoyetki, _
                donecekkullanicirol.islemyetki, donecekkullanicirol.aramayetki, donecekkullanicirol.tanimyetki, donecekkullanicirol.fiyatyetki, _
                donecekkullanicirol.belgeyonetimyetki, donecekkullanicirol.resimyetki, donecekkullanicirol.kullaniciyonetimyetki, donecekkullanicirol.raporyetki, _
                donecekkullanicirol.logyetki, donecekkullanicirol.mesajyetki, donecekkullanicirol.ayaryetki, donecekkullanicirol.sirkettarafaramayetki, _
                donecekkullanicirol.servisayaryetki, donecekkullanicirol.sirkettarafkullaniciyaratyetki, donecekkullanicirol.profilyetki, donecekkullanicirol.toplumesajyetki, _
                donecekkullanicirol.dosyayetki, donecekkullanicirol.sirkettarafraporerisim, donecekkullanicirol.rolsirkettarafindasecilebilsinmi, donecekkullanicirol.sirkettanimyetki, _
                donecekkullanicirol.acentetanimyetki, donecekkullanicirol.personeltanimyetki, donecekkullanicirol.aractarifetanimyetki, donecekkullanicirol.ulketanimyetki, _
                donecekkullanicirol.anamenupkey, donecekkullanicirol.yardimyetki, donecekkullanicirol.mensup, _
                donecekkullanicirol.sirkettarafkullanicilisteyetki, donecekkullanicirol.zeylcodetanimyetki, _
                donecekkullanicirol.urunkodtanimyetki, donecekkullanicirol.currencycodetanimyetki, _
                donecekkullanicirol.sirkettarafacenteyaratyetki, donecekkullanicirol.hasardurumkodtanimyetki, _
                donecekkullanicirol.sadecesirketicimesajlasma, donecekkullanicirol.sadecesirketicidosyagonderimi, _
                donecekkullanicirol.policetiptanimyetki, donecekkullanicirol.faturalandirmayetki, _
                donecekkullanicirol.acentetiptanimyetki, donecekkullanicirol.bazfiyatgirissureyetki, _
                donecekkullanicirol.sirketbazfiyatgirisyetki, donecekkullanicirol.sadecemerkezgozuk, _
                donecekkullanicirol.kimlikturtanimyetki, donecekkullanicirol.dinamikraporyetki, _
                donecekkullanicirol.adminpolicearayetki, donecekkullanicirol.adminhasararayetki, _
                donecekkullanicirol.kuryetki, donecekkullanicirol.tpbelgeyetki, donecekkullanicirol.bekbelgeyetki, _
                donecekkullanicirol.birlikpersoneltanimyetki, donecekkullanicirol.tanimlanmisdinamikraporyetki, _
                donecekkullanicirol.iptallistesiyetki, donecekkullanicirol.parakambiyoaramayetki))


            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullaniciroller

    End Function

    '---------------------------------ara-----------------------------------------
    Function ara(ByVal tablecol As String, ByVal kriter As String) As List(Of CLASSKULLANICIROL)

        Dim istring As String
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkullanicirol As New CLASSKULLANICIROL
        Dim kullaniciroller As New List(Of CLASSKULLANICIROL)
        komut.Connection = db_baglanti
        sqlstr = "select * from kullanicirol where " + tablecol + " LIKE '%'+@kriter+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkullanicirol.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("rolad") Is System.DBNull.Value Then
                    donecekkullanicirol.rolad = veri.Item("rolad")
                End If

                If Not veri.Item("tumsirketyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tumsirketyetki = veri.Item("tumsirketyetki")
                End If

                If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                    donecekkullanicirol.yonsayfa = veri.Item("yonsayfa")
                End If

                If Not veri.Item("panoyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.panoyetki = veri.Item("panoyetki")
                End If

                If Not veri.Item("islemyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.islemyetki = veri.Item("islemyetki")
                End If

                If Not veri.Item("aramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aramayetki = veri.Item("aramayetki")
                End If

                If Not veri.Item("tanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimyetki = veri.Item("tanimyetki")
                End If

                If Not veri.Item("fiyatyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.fiyatyetki = veri.Item("fiyatyetki")
                End If

                If Not veri.Item("belgeyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.belgeyonetimyetki = veri.Item("belgeyonetimyetki")
                End If

                If Not veri.Item("resimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.resimyetki = veri.Item("resimyetki")
                End If

                If Not veri.Item("kullaniciyonetimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kullaniciyonetimyetki = veri.Item("kullaniciyonetimyetki")
                End If

                If Not veri.Item("raporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.raporyetki = veri.Item("raporyetki")
                End If

                If Not veri.Item("logyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.logyetki = veri.Item("logyetki")
                End If

                If Not veri.Item("mesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.mesajyetki = veri.Item("mesajyetki")
                End If

                If Not veri.Item("ayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ayaryetki = veri.Item("ayaryetki")
                End If

                If Not veri.Item("sirkettarafaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafaramayetki = veri.Item("sirkettarafaramayetki")
                End If

                If Not veri.Item("servisayaryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.servisayaryetki = veri.Item("servisayaryetki")
                End If

                If Not veri.Item("sirkettarafkullaniciyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullaniciyaratyetki = veri.Item("sirkettarafkullaniciyaratyetki")
                End If

                If Not veri.Item("profilyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.profilyetki = veri.Item("profilyetki")
                End If

                If Not veri.Item("toplumesajyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.toplumesajyetki = veri.Item("toplumesajyetki")
                End If

                If Not veri.Item("dosyayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dosyayetki = veri.Item("dosyayetki")
                End If

                If Not veri.Item("sirkettarafraporerisim") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafraporerisim = veri.Item("sirkettarafraporerisim")
                End If

                If Not veri.Item("rolsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                    donecekkullanicirol.rolsirkettarafindasecilebilsinmi = veri.Item("rolsirkettarafindasecilebilsinmi")
                End If

                If Not veri.Item("sirkettanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettanimyetki = veri.Item("sirkettanimyetki")
                End If

                If Not veri.Item("acentetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetanimyetki = veri.Item("acentetanimyetki")
                End If

                If Not veri.Item("personeltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.personeltanimyetki = veri.Item("personeltanimyetki")
                End If

                If Not veri.Item("aractarifetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.aractarifetanimyetki = veri.Item("aractarifetanimyetki")
                End If

                If Not veri.Item("ulketanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.ulketanimyetki = veri.Item("ulketanimyetki")
                End If

                If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                    donecekkullanicirol.anamenupkey = veri.Item("anamenupkey")
                End If

                If Not veri.Item("yardimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.yardimyetki = veri.Item("yardimyetki")
                End If

                If Not veri.Item("mensup") Is System.DBNull.Value Then
                    donecekkullanicirol.mensup = veri.Item("mensup")
                End If

                If Not veri.Item("sirkettarafkullanicilisteyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafkullanicilisteyetki = veri.Item("sirkettarafkullanicilisteyetki")
                End If

                If Not veri.Item("zeylcodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.zeylcodetanimyetki = veri.Item("zeylcodetanimyetki")
                End If

                If Not veri.Item("urunkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.urunkodtanimyetki = veri.Item("urunkodtanimyetki")
                End If

                If Not veri.Item("currencycodetanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.currencycodetanimyetki = veri.Item("currencycodetanimyetki")
                End If

                If Not veri.Item("sirkettarafacenteyaratyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirkettarafacenteyaratyetki = veri.Item("sirkettarafacenteyaratyetki")
                End If

                If Not veri.Item("hasardurumkodtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.hasardurumkodtanimyetki = veri.Item("hasardurumkodtanimyetki")
                End If

                If Not veri.Item("sadecesirketicimesajlasma") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicimesajlasma = veri.Item("sadecesirketicimesajlasma")
                End If

                If Not veri.Item("sadecesirketicidosyagonderimi") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecesirketicidosyagonderimi = veri.Item("sadecesirketicidosyagonderimi")
                End If

                If Not veri.Item("policetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.policetiptanimyetki = veri.Item("policetiptanimyetki")
                End If

                If Not veri.Item("faturalandirmayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.faturalandirmayetki = veri.Item("faturalandirmayetki")
                End If

                If Not veri.Item("acentetiptanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.acentetiptanimyetki = veri.Item("acentetiptanimyetki")
                End If

                If Not veri.Item("bazfiyatgirissureyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bazfiyatgirissureyetki = veri.Item("bazfiyatgirissureyetki")
                End If

                If Not veri.Item("sirketbazfiyatgirisyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.sirketbazfiyatgirisyetki = veri.Item("sirketbazfiyatgirisyetki")
                End If

                If Not veri.Item("sadecemerkezgozuk") Is System.DBNull.Value Then
                    donecekkullanicirol.sadecemerkezgozuk = veri.Item("sadecemerkezgozuk")
                End If

                If Not veri.Item("kimlikturtanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kimlikturtanimyetki = veri.Item("kimlikturtanimyetki")
                End If

                If Not veri.Item("dinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.dinamikraporyetki = veri.Item("dinamikraporyetki")
                End If

                If Not veri.Item("adminpolicearayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminpolicearayetki = veri.Item("adminpolicearayetki")
                End If

                If Not veri.Item("adminhasararayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.adminhasararayetki = veri.Item("adminhasararayetki")
                End If

                If Not veri.Item("kuryetki") Is System.DBNull.Value Then
                    donecekkullanicirol.kuryetki = veri.Item("kuryetki")
                End If

                If Not veri.Item("tpbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tpbelgeyetki = veri.Item("tpbelgeyetki")
                End If

                If Not veri.Item("bekbelgeyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.bekbelgeyetki = veri.Item("bekbelgeyetki")
                End If

                If Not veri.Item("birlikpersoneltanimyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.birlikpersoneltanimyetki = veri.Item("birlikpersoneltanimyetki")
                End If

                If Not veri.Item("tanimlanmisdinamikraporyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.tanimlanmisdinamikraporyetki = veri.Item("tanimlanmisdinamikraporyetki")
                End If

                If Not veri.Item("iptallistesiyetki") Is System.DBNull.Value Then
                    donecekkullanicirol.iptallistesiyetki = veri.Item("iptallistesiyetki")
                End If

                If Not veri.Item("parakambiyoaramayetki") Is System.DBNull.Value Then
                    donecekkullanicirol.parakambiyoaramayetki = veri.Item("parakambiyoaramayetki")
                End If


                kullaniciroller.Add(New CLASSKULLANICIROL(donecekkullanicirol.pkey, _
                donecekkullanicirol.rolad, donecekkullanicirol.tumsirketyetki, donecekkullanicirol.yonsayfa, donecekkullanicirol.panoyetki, _
                donecekkullanicirol.islemyetki, donecekkullanicirol.aramayetki, donecekkullanicirol.tanimyetki, donecekkullanicirol.fiyatyetki, _
                donecekkullanicirol.belgeyonetimyetki, donecekkullanicirol.resimyetki, donecekkullanicirol.kullaniciyonetimyetki, donecekkullanicirol.raporyetki, _
                donecekkullanicirol.logyetki, donecekkullanicirol.mesajyetki, donecekkullanicirol.ayaryetki, donecekkullanicirol.sirkettarafaramayetki, _
                donecekkullanicirol.servisayaryetki, donecekkullanicirol.sirkettarafkullaniciyaratyetki, donecekkullanicirol.profilyetki, donecekkullanicirol.toplumesajyetki, _
                donecekkullanicirol.dosyayetki, donecekkullanicirol.sirkettarafraporerisim, donecekkullanicirol.rolsirkettarafindasecilebilsinmi, donecekkullanicirol.sirkettanimyetki, _
                donecekkullanicirol.acentetanimyetki, donecekkullanicirol.personeltanimyetki, donecekkullanicirol.aractarifetanimyetki, donecekkullanicirol.ulketanimyetki, _
                donecekkullanicirol.anamenupkey, donecekkullanicirol.yardimyetki, donecekkullanicirol.mensup, _
                donecekkullanicirol.sirkettarafkullanicilisteyetki, donecekkullanicirol.zeylcodetanimyetki, _
                donecekkullanicirol.urunkodtanimyetki, donecekkullanicirol.currencycodetanimyetki, _
                donecekkullanicirol.sirkettarafacenteyaratyetki, donecekkullanicirol.hasardurumkodtanimyetki, _
                donecekkullanicirol.sadecesirketicimesajlasma, donecekkullanicirol.sadecesirketicidosyagonderimi, _
                donecekkullanicirol.policetiptanimyetki, donecekkullanicirol.faturalandirmayetki, _
                donecekkullanicirol.acentetiptanimyetki, donecekkullanicirol.bazfiyatgirissureyetki, _
                donecekkullanicirol.sirketbazfiyatgirisyetki, donecekkullanicirol.sadecemerkezgozuk, _
                donecekkullanicirol.kimlikturtanimyetki, donecekkullanicirol.dinamikraporyetki, _
                donecekkullanicirol.adminpolicearayetki, donecekkullanicirol.adminhasararayetki, _
                donecekkullanicirol.kuryetki, donecekkullanicirol.tpbelgeyetki, donecekkullanicirol.bekbelgeyetki, _
                donecekkullanicirol.birlikpersoneltanimyetki, donecekkullanicirol.tanimlanmisdinamikraporyetki, _
                donecekkullanicirol.iptallistesiyetki, donecekkullanicirol.parakambiyoaramayetki))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kullaniciroller

    End Function

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim kol9, kol10, kol11, kol12, kol13, kol14, kol15, kol16, kol17 As String
        Dim kol18, kol19, kol20, kol21, kol22, kol23, kol24 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Temel Ayarlar</th>" + _
        "<th>Arama Yetkileri</th>" + _
        "<th>Tanımlamalar Yetki</th>" + _
        "<th>Fiyatlar</th>" + _
        "<th>Belge Yönetimi</th>" + _
        "<th>Raporlar</th>" + _
        "<th>Diğer Yetkiler</th>" + _
        "<th>Şirket Tarafındaki Yetkiler</th>" + _
        "<th>İletişim Yetkileri</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then

            sqlstr = "select * from kullanicirol"
            komut = New SqlCommand(sqlstr, db_baglanti)

        End If

        If HttpContext.Current.Session("ltip") = "rolad" Then

            sqlstr = "select * from kullanicirol where rolad=@kriter"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@kriter", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kriter")
            komut.Parameters.Add(param1)

        End If

        If HttpContext.Current.Session("ltip") = "tekkisiyetki" Then

            sqlstr = "select * from kullanicirol where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kullanici_rolpkey")
            komut.Parameters.Add(param1)

        End If

        If HttpContext.Current.Session("ltip") = "sirketadminyardimci" Then

            sqlstr = "select * from kullanicirol where rolsirkettarafindasecilebilsinmi=@rolsirkettarafindasecilebilsinmi"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@rolsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Evet"
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim linkyetki As String
        Dim pkey, rolad, tumsirketyetki, yonsayfa, panoyetki As String
        Dim islemyetki, aramayetki, tanimyetki, fiyatyetki, belgeyonetimyetki As String
        Dim resimyetki, kullaniciyonetimyetki, raporyetki, logyetki As String
        Dim mesajyetki, ayaryetki, sirkettarafaramayetki As String
        Dim servisayaryetki, sirkettarafkullaniciyaratyetki As String
        Dim profilyetki, toplumesajyetki, dosyayetki As String
        Dim sirkettarafraporerisim As String
        Dim rolsirkettarafindasecilebilsinmi As String
        Dim sirkettanimyetki, acentetanimyetki, personeltanimyetki As String
        Dim aractarifetanimyetki, ulketanimyetki As String
        Dim yardimyetki, mensup As String
        Dim sirkettarafkullanicilisteyetki As String
        Dim zeylcodetanimyetki, urunkodtanimyetki As String
        Dim currencycodetanimyetki As String
        Dim sirkettarafacenteyaratyetki As String
        Dim hasardurumkodtanimyetki As String
        Dim sadecesirketicimesajlasma, sadecesirketicidosyagonderimi As String
        Dim policetiptanimyetki As String
        Dim faturalandirmayetki, acentetiptanimyetki As String
        Dim bazfiyatgirissureyetki, sirketbazfiyatgirisyetki As String
        Dim sadecemerkezgozuk, kimlikturtanimyetki As String
        Dim dinamikraporyetki, adminpolicearayetki, adminhasararayetki As String
        Dim kuryetki, tpbelgeyetki, bekbelgeyetki As String
        Dim birlikpersoneltanimyetki, tanimlanmisdinamikraporyetki, iptallistesiyetki As String
        Dim parakambiyoaramayetki As String


        Dim araccinstanimyetki As String
        Dim aracmarkatanimyetki As String
        Dim aracmodeltanimyetki As String
        Dim policeturtanimyetki As String
        Dim sigortalidurumtanimyetki As String
        Dim acentedurumtanimyetki As String
        Dim bilgigirisyetki As String
        Dim bilgipertarac As String
        Dim bilgiodemeyapmayansigortali As String
        Dim bilgiodemeyapmayanacente As String



        Dim anamenupkey As String
        Dim anamenuad As String
        Dim anamenu As New CLASSANAMENU
        Dim anamenu_Erisim As New CLASSANAMENU_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "kullanicirol.aspx?pkey=" + CStr(pkey) + "&op=duzenle"

                        If HttpContext.Current.Session("ltip") = "tekkisiyetki" Or _
                        HttpContext.Current.Session("ltip") = "sirketadminyardimci" Then
                            kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                        Else
                            linkyetki = "yetkigirispopup.aspx?kullanicirolpkey=" + CStr(pkey)
                            kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "<br/><br/>" + _
                            javascript.yetkibuttonyarat(linkyetki) + "</td>"
                        End If

                    End If

                    'temel bilgiler----------------------------------------------
                    If Not veri.Item("rolad") Is System.DBNull.Value Then
                        rolad = veri.Item("rolad")
                    Else
                        rolad = "-"
                    End If

                    If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                        yonsayfa = veri.Item("yonsayfa")
                    Else
                        yonsayfa = "-"
                    End If

                    If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                        anamenupkey = veri.Item("anamenupkey")
                        anamenu = anamenu_Erisim.bultek(anamenupkey)
                        anamenuad = anamenu.ad
                    Else
                        anamenuad = "-"
                    End If

                    If Not veri.Item("rolsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                        rolsirkettarafindasecilebilsinmi = veri.Item("rolsirkettarafindasecilebilsinmi")
                    Else
                        rolsirkettarafindasecilebilsinmi = "-"
                    End If


                    If Not veri.Item("sadecemerkezgozuk") Is System.DBNull.Value Then
                        sadecemerkezgozuk = veri.Item("sadecemerkezgozuk")
                    Else
                        sadecemerkezgozuk = "-"
                    End If

                    If Not veri.Item("tumsirketyetki") Is System.DBNull.Value Then
                        tumsirketyetki = veri.Item("tumsirketyetki")
                    Else
                        tumsirketyetki = "-"
                    End If

                    If Not veri.Item("mensup") Is System.DBNull.Value Then
                        mensup = veri.Item("mensup")
                    Else
                        mensup = "-"
                    End If

                    kol2 = "<td>" + _
                   "<strong>Rol Adı:</strong>" + rolad + "<br/>" + _
                   "<strong>Yönlendirileceği Sayfa:</strong>" + yonsayfa + "<br/>" + _
                   "<strong>Menusu:</strong>" + anamenuad + "<br/>" + _
                   "<strong>Rol Şirket Tarafında Eklenebilecek mi?</strong>" + rolsirkettarafindasecilebilsinmi + "<br/>" + _
                   "<strong>Rol Sadece Merkez Acente altında yaratılabilsin mi?</strong>" + sadecemerkezgozuk + "<br/>" + _
                   "<strong>Tüm Şirket Bilgilerine Erişim:</strong>" + tumsirketyetki + "<br/>" + _
                   "<strong>Mensup:</strong>" + mensup + _
                   "</td>"


                    'aramalar
                    If Not veri.Item("aramayetki") Is System.DBNull.Value Then
                        aramayetki = veri.Item("aramayetki")
                    Else
                        aramayetki = "-"
                    End If
                    If Not veri.Item("adminpolicearayetki") Is System.DBNull.Value Then
                        adminpolicearayetki = veri.Item("adminpolicearayetki")
                    Else
                        adminpolicearayetki = "-"
                    End If
                    If Not veri.Item("adminhasararayetki") Is System.DBNull.Value Then
                        adminhasararayetki = veri.Item("adminhasararayetki")
                    Else
                        adminhasararayetki = "-"
                    End If
                    If Not veri.Item("sirkettarafaramayetki") Is System.DBNull.Value Then
                        sirkettarafaramayetki = veri.Item("sirkettarafaramayetki")
                    Else
                        sirkettarafaramayetki = "-"
                    End If
                    If Not veri.Item("parakambiyoaramayetki") Is System.DBNull.Value Then
                        parakambiyoaramayetki = veri.Item("parakambiyoaramayetki")
                    Else
                        parakambiyoaramayetki = "-"
                    End If

                    kol3 = "<td>" + _
                    "<strong>Arama Yetki:</strong>" + aramayetki + "<br/>" + _
                    "<strong>Admin Poliçe Arama Yetki:</strong>" + adminpolicearayetki + "<br/>" + _
                    "<strong>Admin Hasar Arama Yetki:</strong>" + adminhasararayetki + "<br/>" + _
                    "<strong>Şirket Tarafında Arama Yetki:</strong>" + sirkettarafaramayetki + "<br/>" + _
                    "<strong>Para Kambiyo Arama Yetki:</strong>" + parakambiyoaramayetki + "<br/>" + _
                    "</td>"


                    'Tanımlamalar 
                    If Not veri.Item("tanimyetki") Is System.DBNull.Value Then
                        tanimyetki = veri.Item("tanimyetki")
                    Else
                        tanimyetki = "-"
                    End If

                    If Not veri.Item("sirkettanimyetki") Is System.DBNull.Value Then
                        sirkettanimyetki = veri.Item("sirkettanimyetki")
                    Else
                        sirkettanimyetki = "-"
                    End If

                    If Not veri.Item("acentetanimyetki") Is System.DBNull.Value Then
                        acentetanimyetki = veri.Item("acentetanimyetki")
                    Else
                        acentetanimyetki = "-"
                    End If

                    If Not veri.Item("personeltanimyetki") Is System.DBNull.Value Then
                        personeltanimyetki = veri.Item("personeltanimyetki")
                    Else
                        personeltanimyetki = "-"
                    End If

                    If Not veri.Item("aractarifetanimyetki") Is System.DBNull.Value Then
                        aractarifetanimyetki = veri.Item("aractarifetanimyetki")
                    Else
                        aractarifetanimyetki = "-"
                    End If

                    If Not veri.Item("ulketanimyetki") Is System.DBNull.Value Then
                        ulketanimyetki = veri.Item("ulketanimyetki")
                    Else
                        ulketanimyetki = "-"
                    End If

                    If Not veri.Item("zeylcodetanimyetki") Is System.DBNull.Value Then
                        zeylcodetanimyetki = veri.Item("zeylcodetanimyetki")
                    Else
                        zeylcodetanimyetki = "-"
                    End If

                    If Not veri.Item("urunkodtanimyetki") Is System.DBNull.Value Then
                        urunkodtanimyetki = veri.Item("urunkodtanimyetki")
                    Else
                        urunkodtanimyetki = "-"
                    End If

                    If Not veri.Item("urunkodtanimyetki") Is System.DBNull.Value Then
                        urunkodtanimyetki = veri.Item("urunkodtanimyetki")
                    Else
                        urunkodtanimyetki = "-"
                    End If

                    If Not veri.Item("currencycodetanimyetki") Is System.DBNull.Value Then
                        currencycodetanimyetki = veri.Item("currencycodetanimyetki")
                    Else
                        currencycodetanimyetki = "-"
                    End If

                    If Not veri.Item("hasardurumkodtanimyetki") Is System.DBNull.Value Then
                        hasardurumkodtanimyetki = veri.Item("hasardurumkodtanimyetki")
                    Else
                        hasardurumkodtanimyetki = "-"
                    End If

                    If Not veri.Item("policetiptanimyetki") Is System.DBNull.Value Then
                        policetiptanimyetki = veri.Item("policetiptanimyetki")
                    Else
                        policetiptanimyetki = "-"
                    End If

                    If Not veri.Item("acentetiptanimyetki") Is System.DBNull.Value Then
                        acentetiptanimyetki = veri.Item("acentetiptanimyetki")
                    Else
                        acentetiptanimyetki = "-"
                    End If

                    If Not veri.Item("kimlikturtanimyetki") Is System.DBNull.Value Then
                        kimlikturtanimyetki = veri.Item("kimlikturtanimyetki")
                    Else
                        kimlikturtanimyetki = "-"
                    End If

                    If Not veri.Item("birlikpersoneltanimyetki") Is System.DBNull.Value Then
                        birlikpersoneltanimyetki = veri.Item("birlikpersoneltanimyetki")
                    Else
                        birlikpersoneltanimyetki = "-"
                    End If


                    kol4 = "<td>" + _
                    "<strong>Tanım Erişim:</strong>" + tanimyetki + "<br/>" + _
                    "<strong>Şirket:</strong>" + sirkettanimyetki + "<br/>" + _
                    "<strong>Acente:</strong>" + acentetanimyetki + "<br/>" + _
                    "<strong>Acente Tipleri:</strong>" + acentetiptanimyetki + "<br/>" + _
                    "<strong>Personel:</strong>" + personeltanimyetki + "<br/>" + _
                    "<strong>Araç Tarife:</strong>" + aractarifetanimyetki + "<br/>" + _
                    "<strong>Zeyil Kod Tanımı:</strong>" + zeylcodetanimyetki + "<br/>" + _
                    "<strong>Ürün Kod Tanım Yetki</strong>" + urunkodtanimyetki + "<br/>" + _
                    "<strong>Para Birimleri Tanım Yetki</strong>" + currencycodetanimyetki + "<br/>" + _
                    "<strong>Hasar Durum Kod Tanım Yetki</strong>" + hasardurumkodtanimyetki + "<br/>" + _
                    "<strong>Poliçe Tip Tanım Yetki</strong>" + policetiptanimyetki + "<br/>" + _
                    "<strong>Kimlik Tür Tanım Yetki</strong>" + kimlikturtanimyetki + "<br/>" + _
                    "<strong>Birlik Personel Tanım Yetki</strong>" + birlikpersoneltanimyetki + "<br/>" + _
                    "</td>"


                    'fiyatlar 
                    If Not veri.Item("fiyatyetki") Is System.DBNull.Value Then
                        fiyatyetki = veri.Item("fiyatyetki")
                    Else
                        fiyatyetki = "-"
                    End If

                    If Not veri.Item("bazfiyatgirissureyetki") Is System.DBNull.Value Then
                        bazfiyatgirissureyetki = veri.Item("bazfiyatgirissureyetki")
                    Else
                        bazfiyatgirissureyetki = "-"
                    End If

                    If Not veri.Item("kuryetki") Is System.DBNull.Value Then
                        kuryetki = veri.Item("kuryetki")
                    Else
                        kuryetki = "-"
                    End If

                    kol5 = "<td>" + _
                    "<strong>Baz Fiyat Girişi:</strong>" + fiyatyetki + "<br/>" + _
                    "<strong>Baz Fiyat Süre Girişi:</strong>" + bazfiyatgirissureyetki + "<br/>" + _
                    "<strong>Kur Yetki:</strong>" + kuryetki + "<br/>" + _
                    "</td>"


                    'belge yönetimi
                    If Not veri.Item("belgeyonetimyetki") Is System.DBNull.Value Then
                        belgeyonetimyetki = veri.Item("belgeyonetimyetki")
                    Else
                        belgeyonetimyetki = "-"
                    End If
                    If Not veri.Item("tpbelgeyetki") Is System.DBNull.Value Then
                        tpbelgeyetki = veri.Item("tpbelgeyetki")
                    Else
                        tpbelgeyetki = "-"
                    End If
                    If Not veri.Item("bekbelgeyetki") Is System.DBNull.Value Then
                        bekbelgeyetki = veri.Item("bekbelgeyetki")
                    Else
                        bekbelgeyetki = "-"
                    End If

                    kol6 = "<td>" + _
                    "<strong>Acente Sicil Kayıt:</strong>" + belgeyonetimyetki + "<br/>" + _
                    "<strong>Teknik Personel:</strong>" + tpbelgeyetki + "<br/>" + _
                    "<strong>Bilgilendirme Eğitim:</strong>" + bekbelgeyetki + "<br/>" + _
                    "</td>"


                    'raporlar
                    If Not veri.Item("raporyetki") Is System.DBNull.Value Then
                        raporyetki = veri.Item("raporyetki")
                    Else
                        raporyetki = "-"
                    End If
                    If Not veri.Item("dinamikraporyetki") Is System.DBNull.Value Then
                        dinamikraporyetki = veri.Item("dinamikraporyetki")
                    Else
                        dinamikraporyetki = "-"
                    End If

                    If Not veri.Item("tanimlanmisdinamikraporyetki") Is System.DBNull.Value Then
                        tanimlanmisdinamikraporyetki = veri.Item("tanimlanmisdinamikraporyetki")
                    Else
                        tanimlanmisdinamikraporyetki = "-"
                    End If


                    kol7 = "<td>" + _
                    "<strong>Özel Rapor Yetki:</strong>" + raporyetki + "<br/>" + _
                    "<strong>Dinamik Rapor Yetki:</strong>" + dinamikraporyetki + "<br/>" + _
                    "<strong>Tanımlanmış Dinamik Rapor Yetki:</strong>" + tanimlanmisdinamikraporyetki + "<br/>" + _
                    "</td>"

                    'Diğer Yetkiler-----------------------------------------
                    If Not veri.Item("panoyetki") Is System.DBNull.Value Then
                        panoyetki = veri.Item("panoyetki")
                    Else
                        panoyetki = "-"
                    End If


                    If Not veri.Item("iptallistesiyetki") Is System.DBNull.Value Then
                        iptallistesiyetki = veri.Item("iptallistesiyetki")
                    Else
                        iptallistesiyetki = "-"
                    End If

                    If Not veri.Item("islemyetki") Is System.DBNull.Value Then
                        islemyetki = veri.Item("islemyetki")
                    Else
                        islemyetki = "-"
                    End If
                
                    If Not veri.Item("resimyetki") Is System.DBNull.Value Then
                        resimyetki = veri.Item("resimyetki")
                    Else
                        resimyetki = "-"
                    End If

                    If Not veri.Item("kullaniciyonetimyetki") Is System.DBNull.Value Then
                        kullaniciyonetimyetki = veri.Item("kullaniciyonetimyetki")
                    Else
                        kullaniciyonetimyetki = "-"
                    End If


                    If Not veri.Item("faturalandirmayetki") Is System.DBNull.Value Then
                        faturalandirmayetki = veri.Item("faturalandirmayetki")
                    Else
                        faturalandirmayetki = "-"
                    End If

                    If Not veri.Item("logyetki") Is System.DBNull.Value Then
                        logyetki = veri.Item("logyetki")
                    Else
                        logyetki = "-"
                    End If

                    If Not veri.Item("ayaryetki") Is System.DBNull.Value Then
                        ayaryetki = veri.Item("ayaryetki")
                    Else
                        ayaryetki = "-"
                    End If

                    If Not veri.Item("servisayaryetki") Is System.DBNull.Value Then
                        servisayaryetki = veri.Item("servisayaryetki")
                    Else
                        servisayaryetki = "-"
                    End If

                    If Not veri.Item("profilyetki") Is System.DBNull.Value Then
                        profilyetki = veri.Item("profilyetki")
                    Else
                        profilyetki = "-"
                    End If

                    If Not veri.Item("yardimyetki") Is System.DBNull.Value Then
                        yardimyetki = veri.Item("yardimyetki")
                    Else
                        yardimyetki = "-"
                    End If


                    kol8 = "<td>" + _
                    "<strong>Pano:</strong>" + panoyetki + "<br/>" + _
                    "<strong>Hasar İptali:</strong>" + islemyetki + "<br/>" + _
                    "<strong>İptal Listesi:</strong>" + iptallistesiyetki + "<br/>" + _
                    "<strong>Resim:</strong>" + resimyetki + "<br/>" + _
                    "<strong>Kullanıcı:</strong>" + kullaniciyonetimyetki + "<br/>" + _
                    "<strong>Faturalandırma:</strong>" + faturalandirmayetki + "<br/>" + _
                    "<strong>Log:</strong>" + logyetki + "<br/>" + _
                    "<strong>Ayar:</strong>" + ayaryetki + "<br/>" + _
                    "<strong>Web Servis Ayar:</strong>" + servisayaryetki + "<br/>" + _
                    "<strong>Profil:</strong>" + profilyetki + "<br/>" + _
                    "<strong>Yardım:</strong>" + yardimyetki + _
                    "</td>"


                    'Şirket Tarafındaki Yetkiler-------------------------------------------------
                    If Not veri.Item("sirkettarafaramayetki") Is System.DBNull.Value Then
                        sirkettarafaramayetki = veri.Item("sirkettarafaramayetki")
                    Else
                        sirkettarafaramayetki = "-"
                    End If

                    If Not veri.Item("sirkettarafraporerisim") Is System.DBNull.Value Then
                        sirkettarafraporerisim = veri.Item("sirkettarafraporerisim")
                    Else
                        sirkettarafraporerisim = "-"
                    End If

                    If Not veri.Item("sirkettarafkullaniciyaratyetki") Is System.DBNull.Value Then
                        sirkettarafkullaniciyaratyetki = veri.Item("sirkettarafkullaniciyaratyetki")
                    Else
                        sirkettarafkullaniciyaratyetki = "-"
                    End If

                    If Not veri.Item("sirkettarafkullanicilisteyetki") Is System.DBNull.Value Then
                        sirkettarafkullanicilisteyetki = veri.Item("sirkettarafkullanicilisteyetki")
                    Else
                        sirkettarafkullanicilisteyetki = "-"
                    End If

                    If Not veri.Item("sirkettarafacenteyaratyetki") Is System.DBNull.Value Then
                        sirkettarafacenteyaratyetki = veri.Item("sirkettarafacenteyaratyetki")
                    Else
                        sirkettarafacenteyaratyetki = "-"
                    End If

                    If Not veri.Item("sirketbazfiyatgirisyetki") Is System.DBNull.Value Then
                        sirketbazfiyatgirisyetki = veri.Item("sirketbazfiyatgirisyetki")
                    Else
                        sirketbazfiyatgirisyetki = "-"
                    End If



                    kol9 = "<td>" + _
                    "<strong>Arama:</strong>" + sirkettarafaramayetki + "<br/>" + _
                    "<strong>Raporlama:</strong>" + sirkettarafraporerisim + "<br/>" + _
                    "<strong>Kullanıcı Yaratma:</strong>" + sirkettarafkullaniciyaratyetki + "<br/>" + _
                    "<strong>Kullanıcı Listeleme:</strong>" + sirkettarafkullanicilisteyetki + "<br/>" + _
                    "<strong>Acente Yaratma:</strong>" + sirkettarafacenteyaratyetki + "<br/>" + _
                    "<strong>Baz Fiyat Girişi:</strong>" + sirketbazfiyatgirisyetki + "<br/>" + _
                    "</td>"


                    'İletişim Yetkileri -----------------------------------------------------------
                    If Not veri.Item("mesajyetki") Is System.DBNull.Value Then
                        mesajyetki = veri.Item("mesajyetki")
                    Else
                        mesajyetki = "-"
                    End If

                    If Not veri.Item("dosyayetki") Is System.DBNull.Value Then
                        dosyayetki = veri.Item("dosyayetki")
                    Else
                        dosyayetki = "-"
                    End If

                    If Not veri.Item("toplumesajyetki") Is System.DBNull.Value Then
                        toplumesajyetki = veri.Item("toplumesajyetki")
                    Else
                        toplumesajyetki = "-"
                    End If

                    If Not veri.Item("sadecesirketicimesajlasma") Is System.DBNull.Value Then
                        sadecesirketicimesajlasma = veri.Item("sadecesirketicimesajlasma")
                    Else
                        sadecesirketicimesajlasma = "-"
                    End If

                    If Not veri.Item("sadecesirketicidosyagonderimi") Is System.DBNull.Value Then
                        sadecesirketicidosyagonderimi = veri.Item("sadecesirketicidosyagonderimi")
                    Else
                        sadecesirketicidosyagonderimi = "-"
                    End If

                    kol10 = "<td>" + _
                    "<strong>Mesaj:</strong>" + mesajyetki + "<br/>" + _
                    "<strong>Dosya:</strong>" + dosyayetki + "<br/>" + _
                    "<strong>Toplu Mesaj:</strong>" + toplumesajyetki + "<br/>" + _
                    "<strong>Sadece Şirket İçi Mesajlaşma:</strong>" + sadecesirketicimesajlasma + "<br/>" + _
                    "<strong>Sadece Şirket İçi Dosya Gönderimi:</strong>" + sadecesirketicidosyagonderimi + "<br/>" + _
                    "</td>" + _
                    "</tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + _
                    kol7 + kol8 + kol9 + kol10

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal tablecol As String, ByVal kriter As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanicirol where " + tablecol + "=@kriter"
        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@kriter", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = kriter
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Function anamenuvarmi(ByVal anamenupkey As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kullanicirol where anamenupkey=@anamenupkey"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@anamenupkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = anamenupkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    '---------------------------------listele--------------------------------------
    Public Function listele_kullanicitarafiicin() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7, kol8 As String
        Dim kol9, kol10, kol11, kol12, kol13, kol14, kol15, kol16, kol17 As String
        Dim kol18, kol19, kol20, kol21, kol22, kol23, kol24 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_2'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Temel Ayarlar</th>" + _
        "<th>Şirket Tarafındaki Yetkiler</th>" + _
        "</tr>" + _
        "</thead>" + _
        "<tbody>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        If HttpContext.Current.Session("ltip") = "sirketadminyardimci" Then
            sqlstr = "select * from kullanicirol where rolsirkettarafindasecilebilsinmi=@rolsirkettarafindasecilebilsinmi"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@rolsirkettarafindasecilebilsinmi", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = "Evet"
            komut.Parameters.Add(param1)
        End If

        If HttpContext.Current.Session("ltip") = "sirketprofil" Then
            sqlstr = "select * from kullanicirol where pkey=@pkey"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlClient.SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("kullanici_rolpkey")
            komut.Parameters.Add(param1)
        End If

        girdi = "0"
        Dim link As String
        Dim rolad, tumsirketyetki, yonsayfa, panoyetki As String

        Dim sirkettarafraporerisim As String
        Dim rolsirkettarafindasecilebilsinmi As String
        Dim sirkettanimyetki, personeltanimyetki As String
        Dim mensup As String
        Dim sirkettarafkullanicilisteyetki As String
        Dim sirkettarafaramayetki As String
        Dim sirkettarafkullaniciyaratyetki As String
        Dim sirketbazfiyatgirisyetki As String
        Dim sirkettarafacenteyaratyetki As String
        Dim sadecemerkezgozuk As String


        Dim anamenupkey As String
        Dim anamenuad As String
        Dim anamenu As New CLASSANAMENU
        Dim anamenu_Erisim As New CLASSANAMENU_ERISIM

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()

                    girdi = "1"

                    'temel bilgiler----------------------------------------------
                    If Not veri.Item("rolad") Is System.DBNull.Value Then
                        rolad = veri.Item("rolad")
                    Else
                        rolad = "-"
                    End If

                    If Not veri.Item("yonsayfa") Is System.DBNull.Value Then
                        yonsayfa = veri.Item("yonsayfa")
                    Else
                        yonsayfa = "-"
                    End If

                    If Not veri.Item("anamenupkey") Is System.DBNull.Value Then
                        anamenupkey = veri.Item("anamenupkey")
                        anamenu = anamenu_Erisim.bultek(anamenupkey)
                        anamenuad = anamenu.ad
                    Else
                        anamenuad = "-"
                    End If

                    If Not veri.Item("rolsirkettarafindasecilebilsinmi") Is System.DBNull.Value Then
                        rolsirkettarafindasecilebilsinmi = veri.Item("rolsirkettarafindasecilebilsinmi")
                    Else
                        rolsirkettarafindasecilebilsinmi = "-"
                    End If

                    If Not veri.Item("sadecemerkezgozuk") Is System.DBNull.Value Then
                        sadecemerkezgozuk = veri.Item("sadecemerkezgozuk")
                    Else
                        sadecemerkezgozuk = "-"
                    End If

                    If Not veri.Item("tumsirketyetki") Is System.DBNull.Value Then
                        tumsirketyetki = veri.Item("tumsirketyetki")
                    Else
                        tumsirketyetki = "-"
                    End If

                    If Not veri.Item("mensup") Is System.DBNull.Value Then
                        mensup = veri.Item("mensup")
                    Else
                        mensup = "-"
                    End If

                    kol1 = "<tr><td>" + _
                    "<strong>Rol Adı:</strong>" + rolad + "<br/>" + _
                    "<strong>Yönlendirileceği Sayfa:</strong>" + yonsayfa + "<br/>" + _
                    "<strong>Menusu:</strong>" + anamenuad + "<br/>" + _
                    "<strong>Rol Şirket Tarafında Eklenebilecek mi?</strong>" + rolsirkettarafindasecilebilsinmi + "<br/>" + _
                    "<strong>Rol Sadece Merkez Acente altında yaratılabilsin mi?</strong>" + sadecemerkezgozuk + "<br/>" + _
                    "<strong>Tüm Şirket Bilgilerine Erişim:</strong>" + tumsirketyetki + "<br/>" + _
                    "<strong>Mensup:</strong>" + mensup + _
                    "</td>"


                    'Şirket Tarafındaki Yetkiler-------------------------------------------------
                    If Not veri.Item("sirkettarafaramayetki") Is System.DBNull.Value Then
                        sirkettarafaramayetki = veri.Item("sirkettarafaramayetki")
                    Else
                        sirkettarafaramayetki = "-"
                    End If

                    If Not veri.Item("sirkettarafraporerisim") Is System.DBNull.Value Then
                        sirkettarafraporerisim = veri.Item("sirkettarafraporerisim")
                    Else
                        sirkettarafraporerisim = "-"
                    End If

                    If Not veri.Item("sirkettarafkullaniciyaratyetki") Is System.DBNull.Value Then
                        sirkettarafkullaniciyaratyetki = veri.Item("sirkettarafkullaniciyaratyetki")
                    Else
                        sirkettarafkullaniciyaratyetki = "-"
                    End If

                    If Not veri.Item("sirkettarafkullanicilisteyetki") Is System.DBNull.Value Then
                        sirkettarafkullanicilisteyetki = veri.Item("sirkettarafkullanicilisteyetki")
                    Else
                        sirkettarafkullanicilisteyetki = "-"
                    End If

                    If Not veri.Item("sirkettarafacenteyaratyetki") Is System.DBNull.Value Then
                        sirkettarafacenteyaratyetki = veri.Item("sirkettarafacenteyaratyetki")
                    Else
                        sirkettarafacenteyaratyetki = "-"
                    End If

                    If Not veri.Item("sirketbazfiyatgirisyetki") Is System.DBNull.Value Then
                        sirketbazfiyatgirisyetki = veri.Item("sirketbazfiyatgirisyetki")
                    Else
                        sirketbazfiyatgirisyetki = "-"
                    End If

                    kol2 = "<td>" + _
                    "<strong>Arama:</strong>" + sirkettarafaramayetki + "<br/>" + _
                    "<strong>Raporlama:</strong>" + sirkettarafraporerisim + "<br/>" + _
                    "<strong>Acente Yaratma:</strong>" + sirkettarafacenteyaratyetki + "<br/>" + _
                    "<strong>Kullanıcı Yaratma:</strong>" + sirkettarafkullaniciyaratyetki + "<br/>" + _
                    "<strong>Kullanıcı Listeleme:</strong>" + sirkettarafkullanicilisteyetki + "<br/>" + _
                    "<strong>Baz Fiyat Girişi:</strong>" + sirketbazfiyatgirisyetki + "<br/>" + _
                    "</td></tr>"


                    satir = satir + kol1 + kol2

                End While
            End Using

        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function


End Class

