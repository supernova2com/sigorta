Imports System.Data.SqlClient
Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class CLASSPRODUCTTYPE_ERISIM

    Dim istring As String
    Dim sqlstr As String
    Dim etkilenen As Integer
    Dim db_baglanti As SqlConnection
    Dim komut As New SqlCommand
    Dim ProductType As New CLASSPRODUCTTYPE
    Dim resultset As New CLADBOPRESULT

    Dim x As System.DBNull

    '------------------------------EKLE-------------------------------------------
    Public Function Ekle(ByVal ProductType As CLASSPRODUCTTYPE) As CLADBOPRESULT

        etkilenen = 0
        Dim varmi As String
        varmi = ciftkayitkontrol(ProductType.urunkodpkey, ProductType.ProductTypeCode)

        If varmi = "Evet" Then
            resultset.durum = "Kayıt yapılamadı."
            resultset.hatastr = "Bu kaydın aynisi halihazırda veritabanında vardır."
            resultset.etkilenen = 0
        End If

        If varmi = "Hayır" Then
            istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
            db_baglanti = New SqlConnection(istring)
            db_baglanti.Open()
            Dim komut As New SqlCommand
            komut.Connection = db_baglanti
            sqlstr = "insert into ProductType values (@pkey," + _
            "@urunkodpkey,@ProductTypeCode)"
            komut = New SqlCommand(sqlstr, db_baglanti)

            Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
            param1.Direction = ParameterDirection.Input
            param1.Value = pkeybul()
            komut.Parameters.Add(param1)

            Dim param2 As New SqlParameter("@urunkodpkey", SqlDbType.Int)
            param2.Direction = ParameterDirection.Input
            If ProductType.urunkodpkey = 0 Then
                param2.Value = 0
            Else
                param2.Value = ProductType.urunkodpkey
            End If
            komut.Parameters.Add(param2)

            Dim param3 As New SqlParameter("@ProductTypeCode", SqlDbType.VarChar)
            param3.Direction = ParameterDirection.Input
            If ProductType.ProductTypeCode = "" Then
                param3.Value = System.DBNull.Value
            Else
                param3.Value = ProductType.ProductTypeCode
            End If
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
        sqlstr = "select max(pkey) from ProductType"
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
    Function Duzenle(ByVal ProductType As CLASSPRODUCTTYPE) As CLADBOPRESULT

        etkilenen = 0
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        komut.Connection = db_baglanti
        sqlstr = "update ProductType set " + _
        "urunkodpkey=@urunkodpkey," + _
        "ProductTypeCode=@ProductTypeCode" + _
        " where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = ProductType.pkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@urunkodpkey", SqlDbType.Int)
        param2.Direction = ParameterDirection.Input
        If ProductType.urunkodpkey = 0 Then
            param2.Value = 0
        Else
            param2.Value = ProductType.urunkodpkey
        End If
        komut.Parameters.Add(param2)

        Dim param3 As New SqlParameter("@ProductTypeCode", SqlDbType.VarChar)
        param3.Direction = ParameterDirection.Input
        If ProductType.ProductTypeCode = "" Then
            param3.Value = System.DBNull.Value
        Else
            param3.Value = ProductType.ProductTypeCode
        End If
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


    '---------------------------------bultek-----------------------------------------
    Function bultek(ByVal pkey As String) As CLASSPRODUCTTYPE

        Dim komut As New SqlCommand
        Dim donecekProductType As New CLASSPRODUCTTYPE()
        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ProductType where pkey=@pkey"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@pkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = pkey
        komut.Parameters.Add(param1)


        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekProductType.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("urunkodpkey") Is System.DBNull.Value Then
                    donecekProductType.urunkodpkey = veri.Item("urunkodpkey")
                End If

                If Not veri.Item("ProductTypeCode") Is System.DBNull.Value Then
                    donecekProductType.ProductTypeCode = veri.Item("ProductTypeCode")
                End If


            End While
        End Using
        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return donecekProductType

    End Function

    '---------------------------------sil-----------------------------------------
    Public Function Sil(ByVal pkey As String) As CLADBOPRESULT


        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        sqlstr = "delete from ProductType where pkey=@pkey"
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

    '---------------------------------doldur-----------------------------------------
    Public Function doldur() As List(Of CLASSPRODUCTTYPE)

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()
        Dim donecekProductType As New CLASSPRODUCTTYPE
        Dim ProductTypeler As New List(Of CLASSPRODUCTTYPE)
        komut.Connection = db_baglanti
        sqlstr = "select * from ProductType"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()

                If Not veri.Item("pkey") Is System.DBNull.Value Then
                    donecekProductType.pkey = veri.Item("pkey")
                End If

                If Not veri.Item("urunkodpkey") Is System.DBNull.Value Then
                    donecekProductType.urunkodpkey = veri.Item("urunkodpkey")
                End If

                If Not veri.Item("ProductTypeCode") Is System.DBNull.Value Then
                    donecekProductType.ProductTypeCode = veri.Item("ProductTypeCode")
                End If


                ProductTypeler.Add(New CLASSPRODUCTTYPE(donecekProductType.pkey, _
                donecekProductType.urunkodpkey, donecekProductType.ProductTypeCode))

            End While
        End Using

        komut.Dispose()
        db_baglanti.Close()
        db_baglanti.Dispose()
        Return ProductTypeler

    End Function

   

    '---------------------------------listele--------------------------------------
    Public Function listele() As String

        Dim basliklar, satir As String
        Dim kol1, kol2, kol3 As String
        Dim tabloson As String
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
        "<th>Ürün Kodu</th>" + _
        "<th>Ürün Çeşidi Kodu</th>" + _
        "</tr>" + _
        "</thead>"

        tabloson = "</tbody></table>"

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        '--- LİSTELEME İŞLEMİ İÇİN PARAMETRELERİ AYARLIYORUZ---------------------------
        If HttpContext.Current.Session("ltip") = "TÜMÜ" Then
            sqlstr = "select * from ProductType"
            komut = New SqlCommand(sqlstr, db_baglanti)
        End If


        girdi = "0"
        Dim link As String
        Dim pkey, urunkodpkey, ProductTypeCode As String

        Dim urunkod As New CLASSURUNKOD
        Dim urunkod_erisim As New CLASSURUNKOD_ERISIM


        Try
            Using veri As SqlDataReader = komut.ExecuteReader()
                While veri.Read()
                    girdi = "1"
                    If Not veri.Item("pkey") Is System.DBNull.Value Then
                        pkey = CStr(veri.Item("pkey"))
                        link = "producttype.aspx?pkey=" + CStr(pkey) + "&op=duzenle"
                        kol1 = "<tr><td>" + javascript.editbuttonyarat(link) + "</td>"
                    End If

                    If Not veri.Item("urunkodpkey") Is System.DBNull.Value Then
                        urunkodpkey = veri.Item("urunkodpkey")
                        urunkod = urunkod_erisim.bultek(urunkodpkey)
                        kol2 = "<td>" + urunkod.kod + ":" + urunkod.aciklama + "</td>"
                    Else
                        kol2 = "<td>-</td>"
                    End If

                    If Not veri.Item("ProductTypeCode") Is System.DBNull.Value Then
                        ProductTypeCode = veri.Item("ProductTypeCode")
                        kol3 = "<td>" + ProductTypeCode + "</td></tr>"
                    Else
                        kol3 = "<td>-</td></tr>"
                    End If

                    satir = satir + kol1 + kol2 + kol3
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
    Function ciftkayitkontrol(ByVal urunkodpkey As String, ByVal ProductTypeCode As String) As String

        istring = System.Configuration.ConfigurationManager.AppSettings("sigorta")
        Dim varmi As String = "Hayır"
        db_baglanti = New SqlConnection(istring)
        db_baglanti.Open()

        sqlstr = "select * from ProductType where urunkodpkey=@urunkodpkey and ProductTypeCode=@ProductTypeCode"
        komut = New SqlCommand(sqlstr, db_baglanti)

        Dim param1 As New SqlParameter("@urunkodpkey", SqlDbType.Int)
        param1.Direction = ParameterDirection.Input
        param1.Value = urunkodpkey
        komut.Parameters.Add(param1)

        Dim param2 As New SqlParameter("@ProductTypeCode", SqlDbType.VarChar)
        param2.Direction = ParameterDirection.Input
        param2.Value = ProductTypeCode
        komut.Parameters.Add(param2)

        Using veri As SqlDataReader = komut.ExecuteReader()
            While veri.Read()
                varmi = "Evet"
                Exit While
            End While
        End Using

        db_baglanti.Close()
        db_baglanti.Dispose()

        Return varmi

    End Function


 

End Class
