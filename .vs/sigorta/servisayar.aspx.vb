Public Partial Class servisayar
    Inherits System.Web.UI.Page

    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("servisayar", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

            Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM
            Dim servisayar As New CLASSSERVISAYAR

            Dim kayitsayisi As Integer
            kayitsayisi = servisayar_erisim.kayitsayisibul

            If kayitsayisi = 0 Then

                Labeluyari.Text = "<div class='alert alert-danger'>" + _
                "WEB SERVİS AYARLARI YAPILMAMIŞ. LÜTFEN SUPERNOVA İLE TEMASA GEÇİNİZ." + _
                "</div>"

            End If

            If kayitsayisi > 0 Then
                servisayar = servisayar_erisim.bultek(1)

                If servisayar.bazfiyatdikkat = "Evet" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                If servisayar.ipdikkat = "Evet" Then
                    CheckBox2.Checked = True
                Else
                    CheckBox2.Checked = False
                End If

                If servisayar.tarifekodkontrol = "Evet" Then
                    CheckBox3.Checked = True
                Else
                    CheckBox3.Checked = False
                End If

                If servisayar.sinirkapitakvimkontrol = "Evet" Then
                    CheckBox4.Checked = True
                Else
                    CheckBox4.Checked = False
                End If

                If servisayar.sonzeyilbitistarihkontrol = "Evet" Then
                    CheckBox5.Checked = True
                Else
                    CheckBox5.Checked = False
                End If

                If servisayar.eksurucukontrol = "Evet" Then
                    CheckBox6.Checked = True
                Else
                    CheckBox6.Checked = False
                End If

                If servisayar.duzenlemebitiskontrol = "Evet" Then
                    CheckBox7.Checked = True
                Else
                    CheckBox7.Checked = False
                End If

                If servisayar.plakasinirkapikontrol = "Evet" Then
                    CheckBox8.Checked = True
                Else
                    CheckBox8.Checked = False
                End If

                If servisayar.plakakiralikarackontrol = "Evet" Then
                    CheckBox9.Checked = True
                Else
                    CheckBox9.Checked = False
                End If

                If servisayar.plakaticariarackontrol = "Evet" Then
                    CheckBox10.Checked = True
                Else
                    CheckBox10.Checked = False
                End If

                If servisayar.plakakktckontrol = "Evet" Then
                    CheckBox11.Checked = True
                Else
                    CheckBox11.Checked = False
                End If

                If servisayar.plakarumkontrol = "Evet" Then
                    CheckBox12.Checked = True
                Else
                    CheckBox12.Checked = False
                End If

                If servisayar.rzeyilkontrol = "Evet" Then
                    CheckBox13.Checked = True
                Else
                    CheckBox13.Checked = False
                End If

                If servisayar.damagekimlikkontrol = "Evet" Then
                    CheckBox14.Checked = True
                Else
                    CheckBox14.Checked = False
                End If




            End If

        End If 'postback


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim hata As String
        Dim hatamesajlari As String

        durumlabel.Text = ""
        hata = "0"

        Dim servisayar As New CLASSSERVISAYAR
        Dim servisayar_erisim As New CLASSSERVİSAYAR_ERISIM

        If hata = "0" Then

            If CheckBox1.Checked = True Then
                servisayar.bazfiyatdikkat = "Evet"
            Else
                servisayar.bazfiyatdikkat = "Hayır"
            End If
            If CheckBox2.Checked = True Then
                servisayar.ipdikkat = "Evet"
            Else
                servisayar.ipdikkat = "Hayır"
            End If
            If CheckBox3.Checked = True Then
                servisayar.tarifekodkontrol = "Evet"
            Else
                servisayar.tarifekodkontrol = "Hayır"
            End If
            If CheckBox4.Checked = True Then
                servisayar.sinirkapitakvimkontrol = "Evet"
            Else
                servisayar.sinirkapitakvimkontrol = "Hayır"
            End If
            If CheckBox5.Checked = True Then
                servisayar.sonzeyilbitistarihkontrol = "Evet"
            Else
                servisayar.sonzeyilbitistarihkontrol = "Hayır"
            End If
            If CheckBox6.Checked = True Then
                servisayar.eksurucukontrol = "Evet"
            Else
                servisayar.eksurucukontrol = "Hayır"
            End If
            If CheckBox7.Checked = True Then
                servisayar.duzenlemebitiskontrol = "Evet"
            Else
                servisayar.duzenlemebitiskontrol = "Hayır"
            End If
            If CheckBox8.Checked = True Then
                servisayar.plakasinirkapikontrol = "Evet"
            Else
                servisayar.plakasinirkapikontrol = "Hayır"
            End If
            If CheckBox9.Checked = True Then
                servisayar.plakakiralikarackontrol = "Evet"
            Else
                servisayar.plakakiralikarackontrol = "Hayır"
            End If
            If CheckBox10.Checked = True Then
                servisayar.plakaticariarackontrol = "Evet"
            Else
                servisayar.plakaticariarackontrol = "Hayır"
            End If
            If CheckBox11.Checked = True Then
                servisayar.plakakktckontrol = "Evet"
            Else
                servisayar.plakakktckontrol = "Hayır"
            End If
            If CheckBox12.Checked = True Then
                servisayar.plakarumkontrol = "Evet"
            Else
                servisayar.plakarumkontrol = "Hayır"
            End If

            If CheckBox13.Checked = True Then
                servisayar.rzeyilkontrol = "Evet"
            Else
                servisayar.rzeyilkontrol = "Hayır"
            End If

            If CheckBox14.Checked = True Then
                servisayar.damagekimlikkontrol = "Evet"
            Else
                servisayar.damagekimlikkontrol = "Hayır"
            End If

            Dim kayitsayisi As Integer
            kayitsayisi = servisayar_erisim.kayitsayisibul

            If kayitsayisi = 0 Then
                result = servisayar_erisim.Ekle(servisayar)
            End If

            If kayitsayisi > 0 Then
                servisayar.pkey = 1
                result = servisayar_erisim.Duzenle(servisayar)
            End If

            durumlabel.Text = javascript.alertresult(result)

        End If

    End Sub

End Class