Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Web.Script.Serialization

Public Class CLASSARACKAYITDAIRE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim arackayitdaire As New CLASSARACKAYITDAIRE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal arackayitdaire As CLASSARACKAYITDAIRE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(arackayitdaire.PlakaNo)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
            Return resultset
        End If

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim komut As New SqlCommand
        komut.Connection = db_baglanti
        sqlstr = "insert into arackayitdaire values (@PlakaNo," + _
        "@KatKod,@Marka,@Tip,@Model," + _
        "@MotorGuc)"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlakaNo", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = arackayitdaire.PlakaNo
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@KatKod", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If arackayitdaire.KatKod = 0 Then
            param2.Value = 0
        Else
            param2.Value = arackayitdaire.KatKod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@Marka", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If arackayitdaire.Marka = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = arackayitdaire.Marka
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@Tip", SqlDbType.VarChar)
        param4.Direction = ParameterDirection.Input
        If arackayitdaire.Tip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = arackayitdaire.Tip
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@Model", SqlDbType.VarChar)
        param5.Direction = ParameterDirection.Input
        If arackayitdaire.Model = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = arackayitdaire.Model
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@MotorGuc", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If arackayitdaire.MotorGuc = 0 Then
            param6.Value = 0
        Else
            param6.Value = arackayitdaire.MotorGuc
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
    Function bultek(ByVal PlakaNo As String) As CLASSARACKAYITDAIRE

        Dim komut As New SqlCommand
        Dim donecekarackayitdaire As New CLASSARACKAYITDAIRE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from arackayitdaire where PlakaNo=@PlakaNo"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlakaNo", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = PlakaNo
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("PlakaNo") Is System.DBNull.Value Then
                    donecekarackayitdaire.PlakaNo = veri.Item("PlakaNo")
                End If

                If Not veri.Item("KatKod") Is System.DBNull.Value Then
                    donecekarackayitdaire.KatKod = veri.Item("KatKod")
                End If

                If Not veri.Item("Marka") Is System.DBNull.Value Then
                    donecekarackayitdaire.Marka = veri.Item("Marka")
                End If

                If Not veri.Item("Tip") Is System.DBNull.Value Then
                    donecekarackayitdaire.Tip = veri.Item("Tip")
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekarackayitdaire.Model = veri.Item("Model")
                End If

                If Not veri.Item("MotorGuc") Is System.DBNull.Value Then
                    donecekarackayitdaire.MotorGuc = veri.Item("MotorGuc")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekarackayitdaire

    End Function


    Function Duzenle(ByVal arackayitdaire As CLASSARACKAYITDAIRE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update arackayitdaire set " + _
        "KatKod=@KatKod," + _
        "Marka=@Marka," + _
        "Tip=@Tip," + _
        "Model=@Model," + _
        "MotorGuc=@MotorGuc" + _
        " where PlakaNo=@PlakaNo"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlakaNo", SqlDbType.VarChar, 100)
        param1.Direction = ParameterDirection.Input
        param1.Value = arackayitdaire.PlakaNo
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@KatKod", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If arackayitdaire.KatKod = 0 Then
            param2.Value = 0
        Else
            param2.Value = arackayitdaire.KatKod
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@Marka", SqlDbType.VarChar, 100)
        param3.Direction = ParameterDirection.Input
        If arackayitdaire.Marka = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = arackayitdaire.Marka
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@Tip", SqlDbType.VarChar, 100)
        param4.Direction = ParameterDirection.Input
        If arackayitdaire.Tip = "" Then
            param4.Value = System.DBNull.Value
        Else
            param4.Value = arackayitdaire.Tip
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@Model", SqlDbType.VarChar, 100)
        param5.Direction = ParameterDirection.Input
        If arackayitdaire.Model = "" Then
            param5.Value = System.DBNull.Value
        Else
            param5.Value = arackayitdaire.Model
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@MotorGuc", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If arackayitdaire.MotorGuc = 0 Then
            param6.Value = 0
        Else
            param6.Value = arackayitdaire.MotorGuc
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


    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSARACKAYITDAIRE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekarackayitdaire As New CLASSARACKAYITDAIRE
        Dim arackayitdaireler As New List(Of CLASSARACKAYITDAIRE)
        komut.Connection = db_baglanti
        sqlstr = "select * from arackayitdaire"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("PlakaNo") Is System.DBNull.Value Then
                    donecekarackayitdaire.PlakaNo = veri.Item("PlakaNo")
                End If

                If Not veri.Item("KatKod") Is System.DBNull.Value Then
                    donecekarackayitdaire.KatKod = veri.Item("KatKod")
                End If

                If Not veri.Item("Marka") Is System.DBNull.Value Then
                    donecekarackayitdaire.Marka = veri.Item("Marka")
                End If

                If Not veri.Item("Tip") Is System.DBNull.Value Then
                    donecekarackayitdaire.Tip = veri.Item("Tip")
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekarackayitdaire.Model = veri.Item("Model")
                End If

                If Not veri.Item("MotorGuc") Is System.DBNull.Value Then
                    donecekarackayitdaire.MotorGuc = veri.Item("MotorGuc")
                End If


                arackayitdaireler.Add(New CLASSARACKAYITDAIRE(donecekarackayitdaire.PlakaNo, _
                donecekarackayitdaire.KatKod, donecekarackayitdaire.Marka, donecekarackayitdaire.Tip, _
                donecekarackayitdaire.Model, donecekarackayitdaire.MotorGuc))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return arackayitdaireler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldur_plakayagore(ByVal PlakaNo As String) As List(Of CLASSARACKAYITDAIRE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekarackayitdaire As New CLASSARACKAYITDAIRE
        Dim arackayitdaireler As New List(Of CLASSARACKAYITDAIRE)
        komut.Connection = db_baglanti
        sqlstr = "select * from arackayitdaire where PlakaNo LIKE @PlakaNo+'%'"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlakaNo", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = PlakaNo
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("PlakaNo") Is System.DBNull.Value Then
                    donecekarackayitdaire.PlakaNo = veri.Item("PlakaNo")
                End If

                If Not veri.Item("KatKod") Is System.DBNull.Value Then
                    donecekarackayitdaire.KatKod = veri.Item("KatKod")
                End If

                If Not veri.Item("Marka") Is System.DBNull.Value Then
                    donecekarackayitdaire.Marka = veri.Item("Marka")
                End If

                If Not veri.Item("Tip") Is System.DBNull.Value Then
                    donecekarackayitdaire.Tip = veri.Item("Tip")
                End If

                If Not veri.Item("Model") Is System.DBNull.Value Then
                    donecekarackayitdaire.Model = veri.Item("Model")
                End If

                If Not veri.Item("MotorGuc") Is System.DBNull.Value Then
                    donecekarackayitdaire.MotorGuc = veri.Item("MotorGuc")
                End If


                arackayitdaireler.Add(New CLASSARACKAYITDAIRE(donecekarackayitdaire.PlakaNo, _
                donecekarackayitdaire.KatKod, donecekarackayitdaire.Marka, donecekarackayitdaire.Tip, _
                donecekarackayitdaire.Model, donecekarackayitdaire.MotorGuc))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return arackayitdaireler

    End Function


    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal PlakaNo As String) As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from arackayitdaire where PlakaNo=@PlakaNo"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlakaNo", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = PlakaNo
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


    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5, kol6, kol7 As String
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
        "<th>PlakaNo</th>" + _
        "<th>KatKod</th>" + _
        "<th>Marka</th>" + _
        "<th>Tip</th>" + _
        "<th>Model</th>" + _
        "<th>MotorGuc</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------

        If HttpContext.Current.Session("ltip") = "ARAMA" Then
            sqlstr = "select * from arackayitdaire where PlakaNo LIKE '%'+@PlakaNo+'%' order by PlakaNo"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@PlakaNo", SqlDbType.VarChar)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("PlakaNo")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim PlakaNo, KatKod, Marka, Tip, Model, MotorGuc As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"


                    If Not veri.Item("PlakaNo") Is System.DBNull.Value Then
                        PlakaNo = CStr(veri.Item("PlakaNo"))
                        link = "arackayitdaire.aspx?PlakaNo=" + CStr(PlakaNo) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("PlakaNo") Is System.DBNull.Value Then
                        PlakaNo = CStr(veri.Item("PlakaNo"))
                        kol2 = "<td>" + CStr(PlakaNo) + "</td>"
                    End If

                    If Not veri.Item("KatKod") Is System.DBNull.Value Then
                        KatKod = veri.Item("KatKod")
                        kol3 = "<td>" + KatKod + "</td>"
                    Else
                        kol3 = "<td>-</td>"
                    End If

                    If Not veri.Item("Marka") Is System.DBNull.Value Then
                        Marka = veri.Item("Marka")
                        kol4 = "<td>" + Marka + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    If Not veri.Item("Tip") Is System.DBNull.Value Then
                        Tip = veri.Item("Tip")
                        kol5 = "<td>" + Tip + "</td>"
                    Else
                        kol5 = "<td>-</td>"
                    End If

                    If Not veri.Item("Model") Is System.DBNull.Value Then
                        Model = veri.Item("Model")
                        kol6 = "<td>" + Model + "</td>"
                    Else
                        kol6 = "<td>-</td>"
                    End If

                    If Not veri.Item("MotorGuc") Is System.DBNull.Value Then
                        MotorGuc = veri.Item("MotorGuc")
                        kol7 = "<td>" + MotorGuc + "</td></tr>"
                    Else
                        kol7 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5 + kol6 + kol7
                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try

        db_baglanti.Close()
        db_baglanti.Dispose()

        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + pager + jvstring
        End If

        Return (donecek)

    End Function



    Public Function siltumu() As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from arackayitdaire"
        komut = New SqlCommand(sqlstr, db_baglanti)

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


    Public Function tirelileritemizle() As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from arackayitdaire where Marka=@Marka and Tip=@Tip and Model=@Model"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@Marka", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = "-"
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@Tip", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = "-"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@Model", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        param3.Value = "-"
        komut.Parameters.Add(param3)

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



    Public Function boslukluplakalaritemizle() As CLADBOPRESULT

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from arackayitdaire where PlakaNo LIKE '% %'"

        komut = New SqlCommand(sqlstr, db_baglanti)

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




    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal PlakaNo As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from arackayitdaire where PlakaNo=@PlakaNo"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@PlakaNo", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = PlakaNo
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


    Public Function tumdatayi_cek(ByVal baslangicplaka As String) As CLADBOPRESULT

        Dim plakakontrol_erisim As New CLASSPLAKAKONTROL_ERISIM
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim

        Dim a As Integer
        Dim kaydedilencnt As Integer = 0
        Dim yapilamayancnt As Integer = 0

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()


        sqlstr = "select distinct PlateNumber from PolicyInfo where (PlateCountryCode=@PlateCountryCode) and " + _
        "(PlateNumber like '" + baslangicplaka + "%')" + _
        " order by PlateNumber desc"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@PlateCountryCode", SqlDbType.VarChar)
        param1.Direction = ParameterDirection.Input
        param1.Value = 601
        komut.Parameters.Add(param1)

        Dim result As New CLADBOPRESULT
        Dim ekleresult As New CLADBOPRESULT

        Dim PlateNumber As String
        Dim PlateNumber_bosluklu As String

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("PlateNumber") Is System.DBNull.Value Then
                    PlateNumber = CStr(veri.Item("PlateNumber"))
                    PlateNumber_bosluklu = plakakontrol_erisim.plakayiboslukluyap(PlateNumber)

                    a = a + 1

                    Try
                        Dim arackayitdaire As New CLASSARACKAYITDAIRE
                        Dim js As New JavaScriptSerializer()
                        Dim arackayitcevap As String
                        Dim AracKayitServis As New AracKayitServis.AracBilgisiServiceClient
                        arackayitcevap = AracKayitServis.PlakayaGoreAracBilgisiGetir(PlateNumber_bosluklu)

                        If Len(arackayitcevap) > 0 Then
                            arackayitcevap = Replace(arackayitcevap, ".", "")
                        End If

                        arackayitdaire = js.Deserialize(Of CLASSARACKAYITDAIRE)(arackayitcevap)

                        arackayitdaire.Marka = Trim(arackayitdaire.Marka)
                        arackayitdaire.PlakaNo = PlateNumber
                        arackayitdaire.Tip = Trim(arackayitdaire.Tip)
                        arackayitdaire.Model = Trim(arackayitdaire.Model)
                        ekleresult = Ekle(arackayitdaire)
                        If ekleresult.durum = "Kaydedildi" Then
                            kaydedilencnt = kaydedilencnt + 1
                        End If
                    Catch ex As Exception
                        arackayitdaire.KatKod = 0
                        arackayitdaire.Marka = "-"
                        arackayitdaire.PlakaNo = PlateNumber
                        arackayitdaire.Tip = "-"
                        arackayitdaire.Model = "-"
                        arackayitdaire.MotorGuc = 0
                        ekleresult = Ekle(arackayitdaire)
                        result.durum = ex.Message
                        yapilamayancnt = yapilamayancnt + 1
                    End Try
                End If

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()


        result.etkilenen = kaydedilencnt
        result.hatastr = CStr(yapilamayancnt)

        Return result

    End Function

    Public Function sorgula_plakayagore_servisicin(ByVal PlateNumber As String) As CLASSARACKAYITDAIRE

        Dim plakakontrol_erisim As New CLASSPLAKAKONTROL_ERISIM
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim

        'EĞER PLAKANIN UZUNLUĞU 3 DEN BÜYÜK İSE VE İLK 3 KARAKTERİ HARF İSE BAŞINDA T YADA Z Yİ VEYA SONUNDA Z Yİ KALDIR.
        If Len(PlateNumber) > 3 Then
            If plakakontrol_erisim.harfmi(Mid(PlateNumber, 1, 1)) = "Evet" Then
                If plakakontrol_erisim.harfmi(Mid(PlateNumber, 2, 1)) = "Evet" Then
                    If plakakontrol_erisim.harfmi(Mid(PlateNumber, 3, 1)) = "Evet" Then

                        'ÖNCE BAŞINDA T yada Z VARSA TEMİZLE
                        If Mid(PlateNumber, 1, 1) = "T" Or Mid(PlateNumber, 1, 1) = "Z" Then
                            PlateNumber = Mid(PlateNumber, 2, Len(PlateNumber))
                        End If

                        'SONUNDA Z VARSA
                        If Mid(PlateNumber, Len(PlateNumber), 1) = "Z" Then
                            PlateNumber = Mid(PlateNumber, 1, Len(PlateNumber) - 1)
                        End If

                    End If
                End If
            End If
        End If


        'ÖNCE HATALI GİRİLMİŞ TABLOSUNA BAK VE DOĞRU CC Yİ GÖNDER
        Dim plakadis As New CLASSPLAKADIS
        Dim plakadis_erisim As New CLASSPLAKADIS_ERISIM
        Dim varmi As String
        varmi = plakadis_erisim.ciftkayitkontrol(PlateNumber)
        If varmi = "Evet" Then
            plakadis = plakadis_erisim.bultek_plakayagore(PlateNumber)
            arackayitdaire.KatKod = 1
            arackayitdaire.Marka = "-"
            arackayitdaire.PlakaNo = "Bu plaka araç kayıt dairesi kontrolü dışında tutuluyor. " + PlateNumber
            arackayitdaire.Tip = "Bu plaka araç kayıt dairesi kontrolü dışında tutuluyor"
            arackayitdaire.Model = ""
            arackayitdaire.MotorGuc = plakadis.dogrucc
            Return arackayitdaire
        End If


        'LOKAL VERİTABANINA BAK 
        Dim arackayitdaire_erisim As New CLASSARACKAYITDAIRE_ERISIM
        Dim lokalvarmi As String
        lokalvarmi = ciftkayitkontrol(PlateNumber)
        If lokalvarmi = "Evet" Then
            arackayitdaire = arackayitdaire_erisim.bultek(PlateNumber)
            arackayitdaire.PlakaNo = "CC bilgisi lokal veritabanından alındı. " + PlateNumber
            arackayitdaire.Tip = "CC bilgisi lokal veritabanından alındı"
            Return arackayitdaire
        End If


        Dim PlateNumber_bosluklu As String = plakakontrol_erisim.plakayiboslukluyap(PlateNumber)
        Dim donecekarackayitdaire As New CLASSARACKAYITDAIRE
        Dim js As New JavaScriptSerializer()
        Dim arackayitcevap As String
        Dim AracKayitServis As New AracKayitServis.AracBilgisiServiceClient
        AracKayitServis.InnerChannel.OperationTimeout = New TimeSpan(0, 0, 6)
        Try
            arackayitcevap = AracKayitServis.PlakayaGoreAracBilgisiGetir(PlateNumber_bosluklu)

            If Len(arackayitcevap) > 0 Then
                arackayitcevap = Replace(arackayitcevap, ".", "")
            End If

            arackayitdaire = js.Deserialize(Of CLASSARACKAYITDAIRE)(arackayitcevap)
            'LOKALE KAYDET------------------------------
            If arackayitdaire.KatKod <> 0 Then
                Try
                    arackayitdaire_erisim.Ekle(arackayitdaire)
                Catch ex As Exception
                End Try
            End If
            '-------------------------------------------
        Catch ex As Exception
            arackayitdaire.KatKod = 0
            arackayitdaire.Marka = "-"
            arackayitdaire.PlakaNo = arackayitcevap
            arackayitdaire.Tip = ex.Message
            arackayitdaire.Model = PlateNumber_bosluklu
            arackayitdaire.MotorGuc = 0
        End Try

        Return arackayitdaire

    End Function



    Public Function sorgula_plakayagore(ByVal PlateNumber As String) As CLASSARACKAYITDAIRE

        Dim policyinfo2_Erisim As New PolicyInfo2_Erisim
        Dim plakakontrol_erisim As New CLASSPLAKAKONTROL_ERISIM

        Dim PlateNumber_bosluklu As String = plakakontrol_erisim.plakayiboslukluyap(PlateNumber)
        Dim donecekarackayitdaire As New CLASSARACKAYITDAIRE
        Dim js As New JavaScriptSerializer()
        Dim arackayitcevap As String
        Dim AracKayitServis As New AracKayitServis.AracBilgisiServiceClient
        Try
            arackayitcevap = AracKayitServis.PlakayaGoreAracBilgisiGetir(PlateNumber_bosluklu)

            If Len(arackayitcevap) > 0 Then
                arackayitcevap = Replace(arackayitcevap, ".", "")
            End If

            arackayitdaire = js.Deserialize(Of CLASSARACKAYITDAIRE)(arackayitcevap)
        Catch ex As Exception
            arackayitdaire.KatKod = 0
            arackayitdaire.Marka = "-"
            arackayitdaire.PlakaNo = arackayitcevap
            arackayitdaire.Tip = ex.Message
            arackayitdaire.Model = PlateNumber_bosluklu
            arackayitdaire.MotorGuc = 0
        End Try

        Return arackayitdaire

    End Function


    Public Function istenileni_cek(ByVal baslangicplaka As String) As CLADBOPRESULT

        Dim plakakontrol_erisim As New CLASSPLAKAKONTROL_ERISIM
        Dim hatadetay As String = ""
        Dim PolicyInfo2_erisim As New PolicyInfo2_Erisim
        Dim plaka_tum As String
        Dim plakalar As New List(Of String)

        Dim plakaharfler As String
        plakaharfler = "ABCDEFGHIJKLMNOPQRSTUWXVYZ"

        Dim rr As String
        Dim a As Integer
        Dim kaydedilencnt As Integer = 0
        Dim yapilamayancnt As Integer = 0

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim result As New CLADBOPRESULT
        Dim ekleresult As New CLADBOPRESULT

        Dim PlateNumber As String
        Dim PlateNumber_bosluklu As String


        plakalar.Clear()

        For i = 0 To 999
            If i <= 9 Then
                rr = "00" + CStr(i)
            End If
            If i > 9 And i <= 99 Then
                rr = "0" + CStr(i)
            End If
            If i > 99 Then
                rr = CStr(i)
            End If
            plakalar.Add(baslangicplaka + rr)
        Next

        'PLAKALARI OLUŞTUR BAŞLANGIÇ TEK HARF-------
        If Len(baslangicplaka) = 1 Then
            For Each item As Char In plakaharfler
                For i = 0 To 999
                    If i <= 9 Then
                        rr = "00" + CStr(i)
                    End If
                    If i > 9 And i <= 99 Then
                        rr = "0" + CStr(i)
                    End If
                    If i > 99 Then
                        rr = CStr(i)
                    End If
                    plakalar.Add(baslangicplaka + item + rr)
                Next
            Next
        End If

        'oluşturulan plakaları göstermek için debug
        'For Each itemplaka In plakalar
        'result.hatastr = result.hatastr + itemplaka + "<br/>"
        'Next


        'OLUŞTURULAN PLAKALAR İÇİNDE GEZ VE ÇEKME İŞLEMİ YAP.
        For Each itemplaka In plakalar

            PlateNumber = itemplaka
            PlateNumber_bosluklu = plakakontrol_erisim.plakayiboslukluyap(itemplaka)

            Try
                Dim arackayitdaire As New CLASSARACKAYITDAIRE
                Dim js As New JavaScriptSerializer()
                Dim arackayitcevap As String

                Dim AracKayitServis As New AracKayitServis.AracBilgisiServiceClient
                AracKayitServis.InnerChannel.OperationTimeout = New TimeSpan(0, 0, 6)
                arackayitcevap = AracKayitServis.PlakayaGoreAracBilgisiGetir(PlateNumber_bosluklu)

                If Len(arackayitcevap) > 0 Then
                    arackayitcevap = Replace(arackayitcevap, ".", "")
                End If

                arackayitdaire = js.Deserialize(Of CLASSARACKAYITDAIRE)(arackayitcevap)
                arackayitdaire.Marka = Trim(arackayitdaire.Marka)
                arackayitdaire.PlakaNo = PlateNumber
                arackayitdaire.Tip = Trim(arackayitdaire.Tip)
                arackayitdaire.Model = Trim(arackayitdaire.Model)
                ekleresult = Ekle(arackayitdaire)
                If ekleresult.durum = "Kaydedildi" Then
                    kaydedilencnt = kaydedilencnt + 1
                End If
            Catch ex As Exception
                arackayitdaire.KatKod = 0
                arackayitdaire.Marka = "-"
                arackayitdaire.PlakaNo = PlateNumber
                arackayitdaire.Tip = "-"
                arackayitdaire.Model = "-"
                arackayitdaire.MotorGuc = 0
                ekleresult = Ekle(arackayitdaire)
                result.durum = ex.Message
                yapilamayancnt = yapilamayancnt + 1
                hatadetay = hatadetay + PlateNumber_bosluklu + ","
            End Try


        Next

        'boş olanları temizliyoruz.
        tirelileritemizle()
        boslukluplakalaritemizle()


        result.etkilenen = kaydedilencnt
        result.hatastr = CStr(yapilamayancnt) + "<br/>" + hatadetay

        Return result

    End Function



    Function topluguncelle() As CLADBOPRESULT

        topluguncelle_motor50()
        topluguncelle_motor97()
        topluguncelle_motor99()


    End Function


    Function topluguncelle_motor50() As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update arackayitdaire set " + _
        "MotorGuc=@GDegerMotorGuc " + _
        "where (Tip=@Tip1 or Tip=@Tip2) and " + _
        "(MotorGuc=@MotorGuc1 or MotorGuc=@MotorGuc2)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@GDegerMotorGuc", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = 50
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@Tip1", SqlDbType.VarChar, 100)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Motobisiklet"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@Tip2", SqlDbType.VarChar, 100)
        param3.Direction = ParameterDirection.Input
        param3.Value = "Motosiklet"
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@MotorGuc1", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = 499
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@MotorGuc2", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        param5.Value = 4999
        komut.Parameters.Add(param5)

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


    Function topluguncelle_motor97() As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update arackayitdaire set " + _
        "MotorGuc=@GDegerMotorGuc " + _
        "where (Tip=@Tip1 or Tip=@Tip2) and " + _
        "(MotorGuc=@MotorGuc)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@GDegerMotorGuc", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = 97
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@Tip1", SqlDbType.VarChar, 100)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Motobisiklet"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@Tip2", SqlDbType.VarChar, 100)
        param3.Direction = ParameterDirection.Input
        param3.Value = "Motosiklet"
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@MotorGuc", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = 973
        komut.Parameters.Add(param4)

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


    Function topluguncelle_motor99() As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update arackayitdaire set " + _
        "MotorGuc=@GDegerMotorGuc " + _
        "where (Tip=@Tip1 or Tip=@Tip2) and " + _
        "(MotorGuc=@MotorGuc)"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@GDegerMotorGuc", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = 99
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@Tip1", SqlDbType.VarChar, 100)
        param2.Direction = ParameterDirection.Input
        param2.Value = "Motobisiklet"
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@Tip2", SqlDbType.VarChar, 100)
        param3.Direction = ParameterDirection.Input
        param3.Value = "Motosiklet"
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@MotorGuc", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        param4.Value = 999
        komut.Parameters.Add(param4)

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

End Class

