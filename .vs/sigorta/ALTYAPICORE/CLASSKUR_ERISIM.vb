Imports System.Globalization.CultureInfo
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Xml

Public Class CLASSKUR_ERISIM
    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim kur As New CLASSkur
    Dim resultset As New CLADBOPRESULT

    Dim x As System.Dbnull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal kur As CLASSKUR) As CLADBOPRESULT

        etkilenen = 0
 
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into kur values (@pkey," + _
        "@pkod,@paciklama,@alis,@satis," + _
        "@kurtarih)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkeybul()
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pkod", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If kur.pkod = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = kur.pkod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@paciklama", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If kur.paciklama = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = kur.paciklama
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@alis", SqlDbType.Decimal)
        param4.Direction = ParameterDirection.Input
        If kur.alis = 0 Then
            param4.Value = 0
        Else
            param4.Value = kur.alis
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@satis", SqlDbType.Decimal)
        param5.Direction = ParameterDirection.Input
        If kur.satis = 0 Then
            param5.Value = 0
        Else
            param5.Value = kur.satis
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@kurtarih", SqlDbType.DateTime)
        param6.Direction = ParameterDirection.Input
        If kur.kurtarih Is Nothing Or kur.kurtarih = "00:00:00" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = kur.kurtarih
        End If
        komut.Parameters.Add(param6)

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


    '----------------------------------PKEY BUL---------------------------------------
    Public Function pkeybul() As Integer

        Dim sqlstr As String
        Dim pkey As Integer
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "select max(pkey) from kur"
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

    '-----------------------------------Düzenle------------------------------------
    Function Duzenle(ByVal kur As CLASSKUR) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update kur set " + _
        "pkod=@pkod," + _
        "paciklama=@paciklama," + _
        "alis=@alis," + _
        "satis=@satis," + _
        "kurtarih=@kurtarih" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = kur.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@pkod", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        If kur.pkod = "" Then
            param2.Value = System.DBNull.Value
        Else
            param2.Value = kur.pkod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@paciklama", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If kur.paciklama = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = kur.paciklama
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@alis", SqlDbType.Decimal)
        param4.Direction = ParameterDirection.Input
        If kur.alis = 0 Then
            param4.Value = 0
        Else
            param4.Value = kur.alis
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@satis", SqlDbType.Decimal)
        param5.Direction = ParameterDirection.Input
        If kur.satis = 0 Then
            param5.Value = 0
        Else
            param5.Value = kur.satis
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@kurtarih", SqlDbType.DateTime)
        param6.Direction = ParameterDirection.Input
        If kur.kurtarih Is Nothing Or kur.kurtarih = "00:00:00" Then
            param6.Value = System.DBNull.Value
        Else
            param6.Value = kur.kurtarih
        End If
        komut.Parameters.Add(param6)


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


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSkur

        Dim komut As New SqlCommand
        Dim donecekkur As New CLASSkur()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from kur where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkur.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("pkod") Is System.DBNull.Value Then
                    donecekkur.pkod = veri.Item("pkod")
                End If

                If Not veri.Item("paciklama") Is System.DBNull.Value Then
                    donecekkur.paciklama = veri.Item("paciklama")
                End If

                If Not veri.Item("alis") Is System.DBNull.Value Then
                    donecekkur.alis = veri.Item("alis")
                End If

                If Not veri.Item("satis") Is System.DBNull.Value Then
                    donecekkur.satis = veri.Item("satis")
                End If

                If Not veri.Item("kurtarih") Is System.DBNull.Value Then
                    donecekkur.kurtarih = veri.Item("kurtarih")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekkur

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kur where pkey=@pkey"
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


        Return resultset

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function sil_tarihegore(ByVal hangitarih As Date) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from kur where Convert(DATE,kurtarih)=@kurtarih"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@kurtarih", SqlDbType.Date)
        param1.Direction = ParameterDirection.Input
        param1.Value = hangitarih
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


        Return resultset

    End Function

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSkur)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekkur As New CLASSkur
        Dim kurler As New List(Of CLASSkur)
        komut.Connection = db_baglanti
        sqlstr = "select * from kur"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekkur.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("pkod") Is System.DBNull.Value Then
                    donecekkur.pkod = veri.Item("pkod")
                End If

                If Not veri.Item("paciklama") Is System.DBNull.Value Then
                    donecekkur.paciklama = veri.Item("paciklama")
                End If

                If Not veri.Item("alis") Is System.DBNull.Value Then
                    donecekkur.alis = veri.Item("alis")
                End If

                If Not veri.Item("satis") Is System.DBNull.Value Then
                    donecekkur.satis = veri.Item("satis")
                End If

                If Not veri.Item("kurtarih") Is System.DBNull.Value Then
                    donecekkur.kurtarih = veri.Item("kurtarih")
                End If


                kurler.Add(New CLASSkur(donecekkur.pkey, _
                donecekkur.pkod, donecekkur.paciklama, donecekkur.alis, donecekkur.satis, _
                donecekkur.kurtarih))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return kurler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6 As String
        Dim tabloson, pager As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""


        Dim javascript As New CLASSJAVASCRIPT
        jvstring = javascript.listele_datatable()

        basliklar = "<table class='table table-striped table-bordered table-hover' id='sample_1'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Kod</th>" + _
        "<th>Açıklama</th>" + _
        "<th>Alış</th>" + _
        "<th>Satış</th>" + _
        "<th>Tarih</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        sqlstr = "select * from kur where " + _
        "(Convert(DATE,kurtarih)>=@baslangic and Convert(DATE,kurtarih)<=@bitis)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        komut.Parameters.Add("@baslangic", SqlDbType.DateTime)
        komut.Parameters("@baslangic").Value = HttpContext.Current.Session("baslangic")

        komut.Parameters.Add("@bitis", SqlDbType.DateTime)
        komut.Parameters("@bitis").Value = Current.Session("bitis")

        girdi = "0"
        Dim link As String
        Dim pkey, pkod, paciklama, alis, satis, kurtarih As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        kol1 = "<tr><td>" + CStr(pkey) + "</td>"
                    End If

                    If Not veri.Item("pkod") Is System.DBNull.Value Then
                        pkod = veri.Item("pkod")
                        kol2 = "<td>" + pkod + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("paciklama") Is System.DBNull.Value Then
                        paciklama = veri.Item("paciklama")
                        kol3 = "<td>" + paciklama + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("alis") Is System.DBNull.Value Then
                        alis = veri.Item("alis")
                        kol4 = "<td>" + alis + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("satis") Is System.DBNull.Value Then
                        satis = veri.Item("satis")
                        kol5 = "<td>" + satis + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("kurtarih") Is System.DBNull.Value Then
                        kurtarih = veri.Item("kurtarih")
                        kol6 = "<td>" + kurtarih + "</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6
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


    Function kurcekmerkezbankasindan(ByVal baslangictarih As DateTime, ByVal bitistarih As DateTime) As String

        Dim kurdolar As New CLASSKUR
        Dim kureuro As New CLASSKUR
        Dim kursterlin As New CLASSKUR

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."

        Dim hata As String
        Dim hatatarih As Date
        Dim tempbaslangictarih As DateTime
        tempbaslangictarih = baslangictarih

        Dim debugy As String
        Dim i As Integer = 0
        Dim a As Integer = 0
        Dim g As Integer = 0

        Dim kacgun As Integer


        kacgun = bitistarih.Subtract(baslangictarih).Days

        '----tüm tarih aralaığındaki kurları temizle
        For g = 0 To kacgun
            sil_tarihegore(tempbaslangictarih)
            tempbaslangictarih = tempbaslangictarih.AddDays(1)
        Next

        For g = 0 To kacgun

            'kuru çekmek için linki oluştur -------------------------------
            Dim datestr As String
            datestr = baslangictarih.ToString("yyyyMMdd")

            Dim kurlink As String
            kurlink = ""
            kurlink = "http://www.mb.gov.ct.tr/kur/tarih/" + datestr


            Dim kur_erisim As New CLASSKUR_ERISIM
            Dim reader As XmlTextReader = New XmlTextReader(kurlink)

            Try

                Do While (reader.Read())

                    If reader.NodeType = XmlNodeType.Element Then
                        Dim name As String
                        Dim deger As String
                        deger = reader.Value
                        name = reader.Name
                    End If

                    'DOLAR ALIŞ
                    If i = 47 Then
                        kurdolar.pkod = "USD"
                        kurdolar.paciklama = "Dolar"
                        kurdolar.alis = reader.Value
                    End If
                    'DOLAR SATIŞ 
                    If i = 51 Then
                        kurdolar.satis = reader.Value
                        kurdolar.kurtarih = baslangictarih
                        kur_erisim.Ekle(kurdolar)
                    End If


                    'euro ALIŞ
                    If i = 143 Then
                        kureuro.pkod = "EUR"
                        kureuro.paciklama = "Euro"
                        kureuro.alis = reader.Value
                    End If
                    'euro SATIŞ 
                    If i = 147 Then
                        kureuro.satis = reader.Value
                        kureuro.kurtarih = baslangictarih
                        kur_erisim.Ekle(kureuro)
                    End If


                    'sterlin alış
                    If i = 175 Then
                        kursterlin.pkod = "STG"
                        kursterlin.paciklama = "Sterlin"
                        kursterlin.alis = reader.Value

                    End If
                    'sterlin SATIŞ
                    If i = 179 Then
                        kursterlin.satis = reader.Value
                        kursterlin.kurtarih = baslangictarih
                        kur_erisim.Ekle(kursterlin)
                    End If

                    If reader.NodeType = XmlNodeType.Text Then
                        debugy = debugy + reader.Value + "-" + CStr(i) + "-" + "<br/>"
                    End If

                    i = i + 1

                Loop
            Catch ex As Exception
                hatatarih = baslangictarih
                kurdolar.kurtarih = hatatarih
                kureuro.kurtarih = hatatarih
                kursterlin.kurtarih = hatatarih
                kur_erisim.Ekle(kurdolar)
                kur_erisim.Ekle(kureuro)
                kur_erisim.Ekle(kursterlin)
            Finally
                hata = "0"
                i = 0
                baslangictarih = baslangictarih.AddDays(1)

            End Try

        Next


        Return debugy

    End Function


  

End Class
