Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSGRUPFIELD_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim grupfield As New CLASSGRUPFIELD
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal grupfield As CLASSGRUPFIELD) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(grupfield.raporpkey, grupfield.gosterilecekfieldpkeybag)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu alan için halihazırda grup tanımlanmış."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into grupfield values (@pkey," + _
            "@raporpkey,@gruptabload,@gruptablopkey,@gosterilecekfieldpkeybag," + _
            "@grupsira)"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If grupfield.raporpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = grupfield.raporpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@gruptabload", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If grupfield.gruptabload = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = grupfield.gruptabload
            End If
            komut.Parameters.Add(param3)

            Dim param4 As New SqlParameter("@gruptablopkey", SqlDbType.Int)
            param4.Direction = ParameterDirection.Input
            If grupfield.gruptablopkey = 0 Then
                param4.Value = 0
            Else
                param4.Value = grupfield.gruptablopkey
            End If
            komut.Parameters.Add(param4)

            Dim param5 As New SqlParameter("@gosterilecekfieldpkeybag", SqlDbType.Int)
            param5.Direction = ParameterDirection.Input
            If grupfield.gosterilecekfieldpkeybag = 0 Then
                param5.Value = 0
            Else
                param5.Value = grupfield.gosterilecekfieldpkeybag
            End If
            komut.Parameters.Add(param5)

            Dim param6 As New SqlParameter("@grupsira", SqlDbType.Int)
            param6.Direction = ParameterDirection.Input
            If grupfield.grupsira = 0 Then
                param6.Value = 0
            Else
                param6.Value = grupfield.grupsira
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
        sqlstr = "select max(pkey) from grupfield"
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
    Function Duzenle(ByVal grupfield As CLASSGRUPFIELD) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update grupfield set " + _
        "raporpkey=@raporpkey," + _
        "gruptabload=@gruptabload," + _
        "gruptablopkey=@gruptablopkey," + _
        "gosterilecekfieldpkeybag=@gosterilecekfieldpkeybag," + _
        "grupsira=@grupsira" + _
        " where pkey=@pkey"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = grupfield.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If grupfield.raporpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = grupfield.raporpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@gruptabload", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If grupfield.gruptabload = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = grupfield.gruptabload
        End If
        komut.Parameters.Add(param3)

        Dim param4 As New SqlParameter("@gruptablopkey", SqlDbType.Int)
        param4.Direction = ParameterDirection.Input
        If grupfield.gruptablopkey = 0 Then
            param4.Value = 0
        Else
            param4.Value = grupfield.gruptablopkey
        End If
        komut.Parameters.Add(param4)

        Dim param5 As New SqlParameter("@gosterilecekfieldpkeybag", SqlDbType.Int)
        param5.Direction = ParameterDirection.Input
        If grupfield.gosterilecekfieldpkeybag = 0 Then
            param5.Value = 0
        Else
            param5.Value = grupfield.gosterilecekfieldpkeybag
        End If
        komut.Parameters.Add(param5)

        Dim param6 As New SqlParameter("@grupsira", SqlDbType.Int)
        param6.Direction = ParameterDirection.Input
        If grupfield.grupsira = 0 Then
            param6.Value = 0
        Else
            param6.Value = grupfield.grupsira
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
    Function bultek(ByVal pkey As String) As CLASSGRUPFIELD

        Dim komut As New SqlCommand
        Dim donecekgrupfield As New CLASSGRUPFIELD()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from grupfield where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgrupfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekgrupfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("gruptabload") Is System.DBNull.Value Then
                    donecekgrupfield.gruptabload = veri.Item("gruptabload")
                End If

                If Not veri.Item("gruptablopkey") Is System.DBNull.Value Then
                    donecekgrupfield.gruptablopkey = veri.Item("gruptablopkey")
                End If

                If Not veri.Item("gosterilecekfieldpkeybag") Is System.DBNull.Value Then
                    donecekgrupfield.gosterilecekfieldpkeybag = veri.Item("gosterilecekfieldpkeybag")
                End If


                If Not veri.Item("grupsira") Is System.DBNull.Value Then
                    donecekgrupfield.grupsira = veri.Item("grupsira")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekgrupfield

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT

        Dim kacgrafikvar As Integer
        Dim grupfield As New CLASSGRUPFIELD
        grupfield = bultek(pkey)

        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM

        kacgrafikvar = dinamikraporgrafik_erisim.kacgrafikvar_ilgiliraporda(grupfield.raporpkey)
        If kacgrafikvar > 0 Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu raporda grafik tanımlandığından gruplama alanı silemezsiniz."
            resultset.etkilenen = 0
            Return resultset
        End If


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from grupfield where pkey=@pkey"
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
    Public Function sililgili(ByVal raporpkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from grupfield where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
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
    Public Function doldur() As List(Of CLASSGRUPFIELD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgrupfield As New CLASSGRUPFIELD
        Dim grupfieldler As New List(Of CLASSGRUPFIELD)
        komut.Connection = db_baglanti
        sqlstr = "select * from grupfield"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgrupfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekgrupfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("gruptabload") Is System.DBNull.Value Then
                    donecekgrupfield.gruptabload = veri.Item("gruptabload")
                End If

                If Not veri.Item("gruptablopkey") Is System.DBNull.Value Then
                    donecekgrupfield.gruptablopkey = veri.Item("gruptablopkey")
                End If

                If Not veri.Item("gosterilecekfieldpkeybag") Is System.DBNull.Value Then
                    donecekgrupfield.gosterilecekfieldpkeybag = veri.Item("gosterilecekfieldpkeybag")
                End If

                If Not veri.Item("grupsira") Is System.DBNull.Value Then
                    donecekgrupfield.grupsira = veri.Item("grupsira")
                End If

                grupfieldler.Add(New CLASSGRUPFIELD(donecekgrupfield.pkey, _
                donecekgrupfield.raporpkey, donecekgrupfield.gruptabload, _
                donecekgrupfield.gruptablopkey, donecekgrupfield.gosterilecekfieldpkeybag, _
                donecekgrupfield.grupsira))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return grupfieldler

    End Function


    '---------------------------------doldur-----------------------------------------
    Public Function doldurilgili(ByVal raporpkey As String) As List(Of CLASSGRUPFIELD)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekgrupfield As New CLASSGRUPFIELD
        Dim grupfieldler As New List(Of CLASSGRUPFIELD)
        komut.Connection = db_baglanti
        sqlstr = "select * from grupfield where raporpkey=@raporpkey order by grupsira"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekgrupfield.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                    donecekgrupfield.raporpkey = veri.Item("raporpkey")
                End If

                If Not veri.Item("gruptabload") Is System.DBNull.Value Then
                    donecekgrupfield.gruptabload = veri.Item("gruptabload")
                End If

                If Not veri.Item("gruptablopkey") Is System.DBNull.Value Then
                    donecekgrupfield.gruptablopkey = veri.Item("gruptablopkey")
                End If

                If Not veri.Item("gosterilecekfieldpkeybag") Is System.DBNull.Value Then
                    donecekgrupfield.gosterilecekfieldpkeybag = veri.Item("gosterilecekfieldpkeybag")
                End If

                If Not veri.Item("grupsira") Is System.DBNull.Value Then
                    donecekgrupfield.grupsira = veri.Item("grupsira")
                End If

                grupfieldler.Add(New CLASSGRUPFIELD(donecekgrupfield.pkey, _
                donecekgrupfield.raporpkey, donecekgrupfield.gruptabload, _
                donecekgrupfield.gruptablopkey, donecekgrupfield.gosterilecekfieldpkeybag, _
                donecekgrupfield.grupsira))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return grupfieldler

    End Function

  
    '---------------------------------listele--------------------------------------
    Public Function listele() As String
        Dim basliklar, satir As String
        Dim kol1, kol2, kol3, kol4, kol5 As String
        Dim tabloson As String
        Dim girdi As String
        Dim jvstring As String
        Dim donecek As String

        donecek = ""

        jvstring = "<script type='text/javascript'>" + _
             "$(document).ready(function() {" + _
                 "$('.button').button();" + _
             "});" + _
             "</script>"

        basliklar = "<table class='pure-table pure-table-bordered'>" + _
        "<thead>" + _
        "<tr>" + _
        "<th>Anahtar</th>" + _
        "<th>Rapor</th>" + _
        "<th>Gruplanacak Rapor Başlığı</th>" + _
        "<th>Sıra</th>" + _
        "<th>Sil</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "ilgili" Then
            sqlstr = "select * from grupfield where raporpkey=@raporpkey"

            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = HttpContext.Current.Session("raporpkey")
            komut.Parameters.Add(param1)

        End If

        girdi = "0"
        Dim link As String
        Dim pkey, raporpkey As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

        Dim gosterilecekfield As New CLASSGOSTERILECEKfield
        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        Dim gosterilecekfieldpkeybag As String

        Dim ajaxlinksil, dugmesil As String
        Dim grupsira As String

        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                    End If

                    If Not veri.Item("gosterilecekfieldpkeybag") Is System.DBNull.Value Then
                        gosterilecekfieldpkeybag = veri.Item("gosterilecekfieldpkeybag")
                    End If

                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "dinamikraporpopup.aspx?pkey=" + CStr(raporpkey) + _
                        "&op=duzenle" + _
                        "&grupfieldop=duzenle" + _
                        "&grupfieldpkey=" + CStr(pkey)
                        kol1 = "<tr><td><a href='" + link + "'>" + CStr(pkey) + "</a></td>"
                    End If

                    If Not veri.Item("raporpkey") Is System.DBNull.Value Then
                        raporpkey = veri.Item("raporpkey")
                        dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                        kol2 = "<td>" + dinamikrapor.raporad + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    gosterilecekfield = gosterilecekfield_erisim.bultek(gosterilecekfieldpkeybag)
                    kol3 = "<td>" + gosterilecekfield.raporalias + "</td>"

                    If Not veri.Item("grupsira") Is System.DBNull.Value Then
                        grupsira = veri.Item("grupsira")
                        kol4 = "<td>" + grupsira + "</td>"
                    Else
                        kol4 = "<td>-</td>"
                    End If

                    '--SİL DÜĞMESİ ------
                    ajaxlinksil = "grupfieldsil(" + CStr(pkey) + ")"
                    dugmesil = "<span id='grupfieldsilbutton' onclick='" + ajaxlinksil + _
                    "' class='button'>Sil</span>"
                    kol5 = "<td>" + dugmesil + "</td></tr>"

                    satir = satir + kol1 + kol2 + kol3 + kol4 + kol5

                End While
            End Using
        Catch ex As Exception
            'Response.Write(ex.ToString)
        End Try


        db_baglanti.Close()
        db_baglanti.Dispose()



        If girdi = "1" Then
            donecek = basliklar + satir + tabloson + jvstring
        End If

        Return (donecek)

    End Function

    '--- ÇİFT KAYIT KONTROL -------------------------------------------------------
    Function ciftkayitkontrol(ByVal raporpkey As Integer, ByVal gosterilecekfieldpkeybag As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from grupfield where raporpkey=@raporpkey and " + _
        "gosterilecekfieldpkeybag=@gosterilecekfieldpkeybag"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@gosterilecekfieldpkeybag", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        param2.Value = gosterilecekfieldpkeybag
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using
        db_baglanti.Close()
        Return varmi

    End Function


    Function gosterilecekalanlardavarmi(ByVal gosterilecekfieldpkeybag As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from grupfield where gosterilecekfieldpkeybag=@gosterilecekfieldpkeybag"

        komut = New SqlCommand(sqlstr, db_baglanti)
        Dim param1 As New SqlParameter("@gosterilecekfieldpkeybag", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = gosterilecekfieldpkeybag
        komut.Parameters.Add(param1)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
            End While
        End Using

        db_baglanti.Close()
        Return varmi

    End Function


    Public Function siralamagoster(ByVal raporpkey As String) As String

        Dim sqlstr As String
        Dim jvstring As String

        jvstring = "<script type='text/javascript'>" + _
                    "$(document).ready(function() {" + _
                        "$('#sortablegrup').sortable({" + _
                            "placeholder:  'ui-state-highlight'," + _
                            "axis:   'y'," + _
                        "});" + _
                    "});" + _
                    "</script>"

        Dim istring As String
        Dim db_baglanti As SqlConnection

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        Dim komut As SqlCommand
        Dim veri As SqlDataReader
        Dim pkey, anakat, sira As String
        Dim str As String
        Dim strhepsi, strbas, strorta, strson As String
        Dim anakatpkey, raporalias, gosterilecekfieldpkeybag As String

        Dim gosterilecekfield As New CLASSGOSTERILECEKfield
        Dim gosterilecekfield_Erisim As New CLASSGOSTERILECEKfield_ERISIM

        strbas = "<ul id=sortablegrup>"
        strson = "</ul>"
        strorta = ""


        sqlstr = "select * from grupfield where" + _
        " raporpkey=" + CStr(raporpkey) + " order by grupsira"
        komut = New SqlCommand(sqlstr, db_baglanti)
        veri = komut.ExecuteReader

        While veri.Read()

            If Not veri.Item("pkey") Is System.DBNull.Value Then
                pkey = CStr(veri.Item("pkey"))
            End If

            If Not veri.Item("gosterilecekfieldpkeybag") Is System.DBNull.Value Then
                gosterilecekfieldpkeybag = veri.Item("gosterilecekfieldpkeybag")
                gosterilecekfield = gosterilecekfield_Erisim.bultek(gosterilecekfieldpkeybag)
            End If

            If Not veri.Item("grupsira") Is System.DBNull.Value Then
                sira = CStr(veri.Item("grupsira"))
            End If

            strorta = strorta + "<li id=" + Chr(34) + CStr(pkey) + Chr(34) + _
            " class=" + Chr(34) + "ui-state-default" + Chr(34) + ">" + gosterilecekfield.raporalias + "</li>"

        End While

        db_baglanti.Close()

        strhepsi = strbas + strorta + strson + jvstring
        Return strhepsi


    End Function


    Public Function siralamayap(ByVal raporpkey As Integer, ByVal degerler As String) As String

        Dim sqlstr As String
        Dim i As String
        Dim x As Integer
        Dim varmi As Integer

        varmi = InStr(degerler, ",", CompareMethod.Text)
        Dim words As String() = degerler.Split(New Char() {","c})

        Dim kactane As String = kactanevar(raporpkey)

        Dim siralar(kactane) As String

        i = 0
        Dim word As String
        For Each word In words
            siralar(i) = word
            i = i + 1
        Next

        Dim istring As String
        Dim db_baglanti As SqlConnection
        Dim db_baglanti2 As SqlConnection

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        db_baglanti2 = New SqlConnection(istring)
        db_baglanti2.Open()

        Dim komut As SqlCommand
        Dim komut2 As SqlCommand
        Dim veri As SqlDataReader
        Dim pkey, baslik, sira As String
        Dim str As String

        sqlstr = "select * from grupfield where raporpkey=@raporpkey " + _
        " order by grupsira"

        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        veri = komut.ExecuteReader

        x = 0

        For Each word In words

            sqlstr = "update grupfield set " + _
            "grupsira=@grupsira" + _
            " where pkey=@pkey"

            komut2 = New SqlCommand(sqlstr, db_baglanti2)

            komut2.Parameters.Add("@grupsira", SqlDbType.Int)
            komut2.Parameters("@grupsira").Value = x

            komut2.Parameters.Add("@pkey", SqlDbType.Int)
            komut2.Parameters("@pkey").Value = word

            komut2.ExecuteNonQuery()
            x = x + 1

        Next

        db_baglanti.Close()
        db_baglanti2.Close()

    End Function



    Private Function kactanevar(ByVal raporpkey As Integer) As Integer

        Dim sqlstr As String
        Dim kactane As Integer
        Dim komut As SqlCommand

        Dim istring As String
        Dim db_baglanti As SqlConnection
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select count(*) from grupfield where raporpkey=@raporpkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@raporpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = raporpkey
        komut.Parameters.Add(param1)

        Dim maxkayit1 = komut.ExecuteScalar()
        If maxkayit1 Is System.DBNull.Value Then
            kactane = 0
        Else
            kactane = maxkayit1
        End If

        db_baglanti.Close()

        Return kactane

    End Function



End Class


