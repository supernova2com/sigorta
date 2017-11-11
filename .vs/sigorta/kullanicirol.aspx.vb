Partial Public Class kullanicirol
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
    Dim kullanicirol As New CLASSKULLANICIROL
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "kullanicirol"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("kullanicirol", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then


            'ANA MENULERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            Dim anamenu_erisim As New CLASSANAMENU_ERISIM
            Dim anamenuler As New List(Of CLASSANAMENU)
            anamenuler = anamenu_erisim.doldur()
            For Each item As CLASSANAMENU In anamenuler
                DropDownList1.Items.Add(New ListItem(item.ad, CStr(item.pkey)))
            Next

            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList2.Items.Add(New ListItem("KKSBM", "KKSBM"))
            DropDownList2.Items.Add(New ListItem("DİĞER", "DİĞER"))

            If Request.QueryString("op") = "yenikayit" Then

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False
                CheckBox4.Checked = False
                CheckBox5.Checked = False
                CheckBox6.Checked = False
                CheckBox7.Checked = False
                CheckBox8.Checked = False
                CheckBox9.Checked = False
                CheckBox10.Checked = False
                CheckBox11.Checked = False
                CheckBox12.Checked = False
                CheckBox13.Checked = False
                CheckBox14.Checked = False
                CheckBox15.Checked = False
                CheckBox16.Checked = False
                CheckBox17.Checked = False
                CheckBox18.Checked = False
                CheckBox19.Checked = False
                CheckBox20.Checked = False
                CheckBox21.Checked = False
                CheckBox22.Checked = False
                CheckBox23.Checked = False
                CheckBox24.Checked = False
                CheckBox25.Checked = False
                CheckBox26.Checked = False
                CheckBox27.Checked = False
                CheckBox28.Checked = False
                CheckBox29.Checked = False
                CheckBox30.Checked = False
                CheckBox31.Checked = False
                CheckBox32.Checked = False
                CheckBox33.Checked = False
                CheckBox34.Checked = False
                CheckBox35.Checked = False
                CheckBox36.Checked = False
                CheckBox37.Checked = False
                CheckBox38.Checked = False
                CheckBox39.Checked = False
                CheckBox40.Checked = False
                CheckBox41.Checked = False
                CheckBox42.Checked = False
                CheckBox43.Checked = False
                CheckBox44.Checked = False
                CheckBox45.Checked = False
                CheckBox46.Checked = False
                CheckBox47.Checked = False
                CheckBox48.Checked = False
                CheckBox49.Checked = False
                CheckBox50.Checked = False
                CheckBox51.Checked = False
                CheckBox52.Checked = False

            End If


            'TÜM GİRİLEN KULLANICI GRUPLARINI BUL 
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = kullanicirol_erisim.listele()

            If Request.QueryString("op") = "duzenle" Then

                Buttonsil.Visible = True

                Button1.Text = "Değişiklikleri Güncelle"
                kullanicirol = kullanicirol_erisim.bultek(Request.QueryString("pkey"))
                Textbox1.Text = kullanicirol.rolad
                Textbox2.Text = kullanicirol.yonsayfa

                If kullanicirol.tumsirketyetki = "Evet" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                If kullanicirol.panoyetki = "Evet" Then
                    CheckBox2.Checked = True
                Else
                    CheckBox2.Checked = False
                End If

                If kullanicirol.islemyetki = "Evet" Then
                    CheckBox3.Checked = True
                Else
                    CheckBox3.Checked = False
                End If

                If kullanicirol.aramayetki = "Evet" Then
                    CheckBox4.Checked = True
                Else
                    CheckBox4.Checked = False
                End If

                If kullanicirol.tanimyetki = "Evet" Then
                    CheckBox5.Checked = True
                Else
                    CheckBox5.Checked = False
                End If

                If kullanicirol.fiyatyetki = "Evet" Then
                    CheckBox6.Checked = True
                Else
                    CheckBox6.Checked = False
                End If

                If kullanicirol.belgeyonetimyetki = "Evet" Then
                    CheckBox7.Checked = True
                Else
                    CheckBox7.Checked = False
                End If

                If kullanicirol.resimyetki = "Evet" Then
                    CheckBox8.Checked = True
                Else
                    CheckBox8.Checked = False
                End If

                If kullanicirol.kullaniciyonetimyetki = "Evet" Then
                    CheckBox9.Checked = True
                Else
                    CheckBox9.Checked = False
                End If

                If kullanicirol.raporyetki = "Evet" Then
                    CheckBox10.Checked = True
                Else
                    CheckBox10.Checked = False
                End If

                If kullanicirol.logyetki = "Evet" Then
                    CheckBox11.Checked = True
                Else
                    CheckBox11.Checked = False
                End If

                If kullanicirol.mesajyetki = "Evet" Then
                    CheckBox12.Checked = True
                Else
                    CheckBox12.Checked = False
                End If

                If kullanicirol.ayaryetki = "Evet" Then
                    CheckBox13.Checked = True
                Else
                    CheckBox13.Checked = False
                End If

                If kullanicirol.sirkettarafaramayetki = "Evet" Then
                    CheckBox14.Checked = True
                Else
                    CheckBox14.Checked = False
                End If

                If kullanicirol.servisayaryetki = "Evet" Then
                    CheckBox15.Checked = True
                Else
                    CheckBox15.Checked = False
                End If

                If kullanicirol.profilyetki = "Evet" Then
                    CheckBox16.Checked = True
                Else
                    CheckBox16.Checked = False
                End If

                If kullanicirol.sirkettarafkullaniciyaratyetki = "Evet" Then
                    CheckBox17.Checked = True
                Else
                    CheckBox17.Checked = False
                End If

                If kullanicirol.toplumesajyetki = "Evet" Then
                    CheckBox18.Checked = True
                Else
                    CheckBox18.Checked = False
                End If

                If kullanicirol.dosyayetki = "Evet" Then
                    CheckBox19.Checked = True
                Else
                    CheckBox19.Checked = False
                End If

                If kullanicirol.sirkettarafraporerisim = "Evet" Then
                    CheckBox20.Checked = True
                Else
                    CheckBox20.Checked = False
                End If

                If kullanicirol.rolsirkettarafindasecilebilsinmi = "Evet" Then
                    CheckBox21.Checked = True
                Else
                    CheckBox21.Checked = False
                End If

                If kullanicirol.sirkettanimyetki = "Evet" Then
                    CheckBox22.Checked = True
                Else
                    CheckBox22.Checked = False
                End If

                If kullanicirol.acentetanimyetki = "Evet" Then
                    CheckBox23.Checked = True
                Else
                    CheckBox23.Checked = False
                End If

                If kullanicirol.personeltanimyetki = "Evet" Then
                    CheckBox24.Checked = True
                Else
                    CheckBox24.Checked = False
                End If

                If kullanicirol.aractarifetanimyetki = "Evet" Then
                    CheckBox25.Checked = True
                Else
                    CheckBox25.Checked = False
                End If

                If kullanicirol.ulketanimyetki = "Evet" Then
                    CheckBox26.Checked = True
                Else
                    CheckBox26.Checked = False
                End If

                DropDownList1.SelectedValue = kullanicirol.anamenupkey

                If kullanicirol.yardimyetki = "Evet" Then
                    CheckBox27.Checked = True
                Else
                    CheckBox27.Checked = False
                End If

                DropDownList2.SelectedValue = kullanicirol.mensup

                If kullanicirol.sirkettarafkullanicilisteyetki = "Evet" Then
                    CheckBox28.Checked = True
                Else
                    CheckBox28.Checked = False
                End If

                If kullanicirol.zeylcodetanimyetki = "Evet" Then
                    CheckBox29.Checked = True
                Else
                    CheckBox29.Checked = False
                End If

                If kullanicirol.urunkodtanimyetki = "Evet" Then
                    CheckBox30.Checked = True
                Else
                    CheckBox30.Checked = False
                End If

                If kullanicirol.currencycodetanimyetki = "Evet" Then
                    CheckBox31.Checked = True
                Else
                    CheckBox31.Checked = False
                End If

                If kullanicirol.sirkettarafacenteyaratyetki = "Evet" Then
                    CheckBox32.Checked = True
                Else
                    CheckBox32.Checked = False
                End If

                If kullanicirol.hasardurumkodtanimyetki = "Evet" Then
                    CheckBox33.Checked = True
                Else
                    CheckBox33.Checked = False
                End If

                If kullanicirol.sadecesirketicimesajlasma = "Evet" Then
                    CheckBox34.Checked = True
                Else
                    CheckBox34.Checked = False
                End If

                If kullanicirol.sadecesirketicidosyagonderimi = "Evet" Then
                    CheckBox35.Checked = True
                Else
                    CheckBox35.Checked = False
                End If

                If kullanicirol.policetiptanimyetki = "Evet" Then
                    CheckBox36.Checked = True
                Else
                    CheckBox36.Checked = False
                End If

                If kullanicirol.faturalandirmayetki = "Evet" Then
                    CheckBox37.Checked = True
                Else
                    CheckBox37.Checked = False
                End If

                If kullanicirol.acentetiptanimyetki = "Evet" Then
                    CheckBox38.Checked = True
                Else
                    CheckBox38.Checked = False
                End If

                If kullanicirol.bazfiyatgirissureyetki = "Evet" Then
                    CheckBox39.Checked = True
                Else
                    CheckBox39.Checked = False
                End If

                If kullanicirol.sirketbazfiyatgirisyetki = "Evet" Then
                    CheckBox40.Checked = True
                Else
                    CheckBox40.Checked = False
                End If

                If kullanicirol.sadecemerkezgozuk = "Evet" Then
                    CheckBox41.Checked = True
                Else
                    CheckBox41.Checked = False
                End If

                If kullanicirol.kimlikturtanimyetki = "Evet" Then
                    CheckBox42.Checked = True
                Else
                    CheckBox42.Checked = False
                End If

                If kullanicirol.adminpolicearayetki = "Evet" Then
                    CheckBox43.Checked = True
                Else
                    CheckBox43.Checked = False
                End If

                If kullanicirol.adminhasararayetki = "Evet" Then
                    CheckBox44.Checked = True
                Else
                    CheckBox44.Checked = False
                End If

                If kullanicirol.kuryetki = "Evet" Then
                    CheckBox45.Checked = True
                Else
                    CheckBox45.Checked = False
                End If

                If kullanicirol.tpbelgeyetki = "Evet" Then
                    CheckBox46.Checked = True
                Else
                    CheckBox46.Checked = False
                End If

                If kullanicirol.bekbelgeyetki = "Evet" Then
                    CheckBox47.Checked = True
                Else
                    CheckBox47.Checked = False
                End If

                If kullanicirol.dinamikraporyetki = "Evet" Then
                    CheckBox48.Checked = True
                Else
                    CheckBox48.Checked = False
                End If

                If kullanicirol.birlikpersoneltanimyetki = "Evet" Then
                    CheckBox49.Checked = True
                Else
                    CheckBox49.Checked = False
                End If

                If kullanicirol.tanimlanmisdinamikraporyetki = "Evet" Then
                    CheckBox50.Checked = True
                Else
                    CheckBox50.Checked = False
                End If

                If kullanicirol.iptallistesiyetki = "Evet" Then
                    CheckBox51.Checked = True
                Else
                    CheckBox51.Checked = False
                End If

                If kullanicirol.parakambiyoaramayetki = "Evet" Then
                    CheckBox52.Checked = True
                Else
                    CheckBox52.Checked = False
                End If


            End If

            If Request.QueryString("op") = "yenikayit" Then
                Buttonsil.Visible = False
                Textbox1.Focus()
            End If

            If Request.QueryString("op") = "" Then

                DropDownList1.Enabled = False
                DropDownList2.Enabled = False
                Textbox1.Enabled = False
                Textbox2.Enabled = False
                Button1.Enabled = False
                Buttonsil.Enabled = False
            End If

        End If


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.insertyetki = "Hayır" And opy = "yenikayit" Then
            Button1.Visible = False
            Buttonyenikayit.Visible = False
        End If
        If yetki.insertyetki = "Evet" And opy = "yenikayit" Then
            Button1.Visible = True
            Buttonyenikayit.Visible = True
        End If

        If yetki.updateyetki = "Hayır" And opy = "duzenle" Then
            Button1.Visible = False
        End If
        If yetki.updateyetki = "Evet" And opy = "duzenle" Then
            Button1.Visible = True
        End If

        If yetki.deleteyetki = "Hayır" Then
            Buttonsil.Visible = False
        End If
        If yetki.deleteyetki = "Evet" And opy = "duzenle" Then
            Buttonsil.Visible = True
        End If
        If yetki.readyetki = "Hayır" Then
            Label1.Visible = False
        Else
            Label1.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim hata, hatamesajlari As String


        durumlabel.Text = ""

        hata = "0"

        ' KONTROL ET ---------------------------

        'rol adını girmediniz
        If Textbox1.Text = "" Then
            Textbox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcı rol ismini girmediniz.<br/>"
        End If


        'yon sayfa girmediniz
        If Textbox2.Text = "" Then
            Textbox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının yönlendirileceği sayfayı girmediniz.<br/>"
        End If


        'hangi menuyu kullanacak seçilmiş mi
        If DropDownList1.SelectedValue = "0" Then
            DropDownList1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının hangi menuyu kullanacağını seçmediniz.<br/>"
        End If


        'mesup seçilmiş mi kontrol et
        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "Kullanıcının mensup olduğu grubu seçmediniz.<br/>"
        End If

        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
        Dim kullanicirol As New CLASSKULLANICIROL

        If hata = "0" Then

            If Request.QueryString("op") = "yenikayit" Then
                kullanicirol.rolad = Textbox1.Text
                kullanicirol.yonsayfa = Textbox2.Text

                If CheckBox1.Checked = True Then
                    kullanicirol.tumsirketyetki = "Evet"
                Else
                    kullanicirol.tumsirketyetki = "Hayır"
                End If

                If CheckBox2.Checked = True Then
                    kullanicirol.panoyetki = "Evet"
                Else
                    kullanicirol.panoyetki = "Hayır"
                End If

                If CheckBox3.Checked = True Then
                    kullanicirol.islemyetki = "Evet"
                Else
                    kullanicirol.islemyetki = "Hayır"
                End If

                If CheckBox4.Checked = True Then
                    kullanicirol.aramayetki = "Evet"
                Else
                    kullanicirol.aramayetki = "Hayır"
                End If

                If CheckBox5.Checked = True Then
                    kullanicirol.tanimyetki = "Evet"
                Else
                    kullanicirol.tanimyetki = "Hayır"
                End If

                If CheckBox6.Checked = True Then
                    kullanicirol.fiyatyetki = "Evet"
                Else
                    kullanicirol.fiyatyetki = "Hayır"
                End If

                If CheckBox7.Checked = True Then
                    kullanicirol.belgeyonetimyetki = "Evet"
                Else
                    kullanicirol.belgeyonetimyetki = "Hayır"
                End If

                If CheckBox8.Checked = True Then
                    kullanicirol.resimyetki = "Evet"
                Else
                    kullanicirol.resimyetki = "Hayır"
                End If

                If CheckBox9.Checked = True Then
                    kullanicirol.kullaniciyonetimyetki = "Evet"
                Else
                    kullanicirol.kullaniciyonetimyetki = "Hayır"
                End If

                If CheckBox10.Checked = True Then
                    kullanicirol.raporyetki = "Evet"
                Else
                    kullanicirol.raporyetki = "Hayır"
                End If

                If CheckBox11.Checked = True Then
                    kullanicirol.logyetki = "Evet"
                Else
                    kullanicirol.logyetki = "Hayır"
                End If

                If CheckBox12.Checked = True Then
                    kullanicirol.mesajyetki = "Evet"
                Else
                    kullanicirol.mesajyetki = "Hayır"
                End If

                If CheckBox13.Checked = True Then
                    kullanicirol.ayaryetki = "Evet"
                Else
                    kullanicirol.ayaryetki = "Hayır"
                End If

                If CheckBox14.Checked = True Then
                    kullanicirol.sirkettarafaramayetki = "Evet"
                Else
                    kullanicirol.sirkettarafaramayetki = "Hayır"
                End If

                If CheckBox15.Checked = True Then
                    kullanicirol.servisayaryetki = "Evet"
                Else
                    kullanicirol.servisayaryetki = "Hayır"
                End If

                If CheckBox16.Checked = True Then
                    kullanicirol.profilyetki = "Evet"
                Else
                    kullanicirol.profilyetki = "Hayır"
                End If

                If CheckBox17.Checked = True Then
                    kullanicirol.sirkettarafkullaniciyaratyetki = "Evet"
                Else
                    kullanicirol.sirkettarafkullaniciyaratyetki = "Hayır"
                End If

                If CheckBox18.Checked = True Then
                    kullanicirol.toplumesajyetki = "Evet"
                Else
                    kullanicirol.toplumesajyetki = "Hayır"
                End If

                If CheckBox19.Checked = True Then
                    kullanicirol.dosyayetki = "Evet"
                Else
                    kullanicirol.dosyayetki = "Hayır"
                End If

                If CheckBox20.Checked = True Then
                    kullanicirol.sirkettarafraporerisim = "Evet"
                Else
                    kullanicirol.sirkettarafraporerisim = "Hayır"
                End If

                If CheckBox21.Checked = True Then
                    kullanicirol.rolsirkettarafindasecilebilsinmi = "Evet"
                Else
                    kullanicirol.rolsirkettarafindasecilebilsinmi = "Hayır"
                End If

                If CheckBox22.Checked = True Then
                    kullanicirol.sirkettanimyetki = "Evet"
                Else
                    kullanicirol.sirkettanimyetki = "Hayır"
                End If

                If CheckBox23.Checked = True Then
                    kullanicirol.acentetanimyetki = "Evet"
                Else
                    kullanicirol.acentetanimyetki = "Hayır"
                End If

                If CheckBox24.Checked = True Then
                    kullanicirol.personeltanimyetki = "Evet"
                Else
                    kullanicirol.personeltanimyetki = "Hayır"
                End If

                If CheckBox25.Checked = True Then
                    kullanicirol.aractarifetanimyetki = "Evet"
                Else
                    kullanicirol.aractarifetanimyetki = "Hayır"
                End If

                If CheckBox26.Checked = True Then
                    kullanicirol.ulketanimyetki = "Evet"
                Else
                    kullanicirol.ulketanimyetki = "Hayır"
                End If

                kullanicirol.anamenupkey = DropDownList1.SelectedValue

                If CheckBox27.Checked = True Then
                    kullanicirol.yardimyetki = "Evet"
                Else
                    kullanicirol.yardimyetki = "Hayır"
                End If

                kullanicirol.mensup = DropDownList2.SelectedValue

                If CheckBox28.Checked = True Then
                    kullanicirol.sirkettarafkullanicilisteyetki = "Evet"
                Else
                    kullanicirol.sirkettarafkullanicilisteyetki = "Hayır"
                End If

                If CheckBox29.Checked = True Then
                    kullanicirol.zeylcodetanimyetki = "Evet"
                Else
                    kullanicirol.zeylcodetanimyetki = "Hayır"
                End If

                If CheckBox30.Checked = True Then
                    kullanicirol.urunkodtanimyetki = "Evet"
                Else
                    kullanicirol.urunkodtanimyetki = "Hayır"
                End If

                If CheckBox31.Checked = True Then
                    kullanicirol.currencycodetanimyetki = "Evet"
                Else
                    kullanicirol.currencycodetanimyetki = "Hayır"
                End If

                If CheckBox32.Checked = True Then
                    kullanicirol.sirkettarafacenteyaratyetki = "Evet"
                Else
                    kullanicirol.sirkettarafacenteyaratyetki = "Hayır"
                End If

                If CheckBox33.Checked = True Then
                    kullanicirol.hasardurumkodtanimyetki = "Evet"
                Else
                    kullanicirol.hasardurumkodtanimyetki = "Hayır"
                End If

                If CheckBox34.Checked = True Then
                    kullanicirol.sadecesirketicimesajlasma = "Evet"
                Else
                    kullanicirol.sadecesirketicimesajlasma = "Hayır"
                End If

                If CheckBox35.Checked = True Then
                    kullanicirol.sadecesirketicidosyagonderimi = "Evet"
                Else
                    kullanicirol.sadecesirketicidosyagonderimi = "Hayır"
                End If

                If CheckBox36.Checked = True Then
                    kullanicirol.policetiptanimyetki = "Evet"
                Else
                    kullanicirol.policetiptanimyetki = "Hayır"
                End If

                If CheckBox37.Checked = True Then
                    kullanicirol.faturalandirmayetki = "Evet"
                Else
                    kullanicirol.faturalandirmayetki = "Hayır"
                End If

                If CheckBox38.Checked = True Then
                    kullanicirol.acentetiptanimyetki = "Evet"
                Else
                    kullanicirol.acentetiptanimyetki = "Hayır"
                End If

                If CheckBox39.Checked = True Then
                    kullanicirol.bazfiyatgirissureyetki = "Evet"
                Else
                    kullanicirol.bazfiyatgirissureyetki = "Hayır"
                End If

                If CheckBox40.Checked = True Then
                    kullanicirol.sirketbazfiyatgirisyetki = "Evet"
                Else
                    kullanicirol.sirketbazfiyatgirisyetki = "Hayır"
                End If

                If CheckBox41.Checked = True Then
                    kullanicirol.sadecemerkezgozuk = "Evet"
                Else
                    kullanicirol.sadecemerkezgozuk = "Hayır"
                End If

                If CheckBox42.Checked = True Then
                    kullanicirol.kimlikturtanimyetki = "Evet"
                Else
                    kullanicirol.kimlikturtanimyetki = "Hayır"
                End If

                If CheckBox43.Checked = True Then
                    kullanicirol.adminpolicearayetki = "Evet"
                Else
                    kullanicirol.adminpolicearayetki = "Hayır"
                End If

                If CheckBox44.Checked = True Then
                    kullanicirol.adminhasararayetki = "Evet"
                Else
                    kullanicirol.adminhasararayetki = "Hayır"
                End If

                If CheckBox45.Checked = True Then
                    kullanicirol.kuryetki = "Evet"
                Else
                    kullanicirol.kuryetki = "Hayır"
                End If

                If CheckBox46.Checked = True Then
                    kullanicirol.tpbelgeyetki = "Evet"
                Else
                    kullanicirol.tpbelgeyetki = "Hayır"
                End If

                If CheckBox47.Checked = True Then
                    kullanicirol.bekbelgeyetki = "Evet"
                Else
                    kullanicirol.bekbelgeyetki = "Hayır"
                End If

                If CheckBox48.Checked = True Then
                    kullanicirol.dinamikraporyetki = "Evet"
                Else
                    kullanicirol.dinamikraporyetki = "Hayır"
                End If

                If CheckBox49.Checked = True Then
                    kullanicirol.birlikpersoneltanimyetki = "Evet"
                Else
                    kullanicirol.birlikpersoneltanimyetki = "Hayır"
                End If

                If CheckBox50.Checked = True Then
                    kullanicirol.tanimlanmisdinamikraporyetki = "Evet"
                Else
                    kullanicirol.tanimlanmisdinamikraporyetki = "Hayır"
                End If

                If CheckBox51.Checked = True Then
                    kullanicirol.iptallistesiyetki = "Evet"
                Else
                    kullanicirol.iptallistesiyetki = "Hayır"
                End If

                If CheckBox52.Checked = True Then
                    kullanicirol.parakambiyoaramayetki = "Evet"
                Else
                    kullanicirol.parakambiyoaramayetki = "Hayır"
                End If


                result = kullanicirol_erisim.Ekle(kullanicirol)
            End If

            If Request.QueryString("op") = "duzenle" Then
                kullanicirol = kullanicirol_erisim.bultek(Request.QueryString("pkey"))
                kullanicirol.rolad = Textbox1.Text
                kullanicirol.yonsayfa = Textbox2.Text

                If CheckBox1.Checked = True Then
                    kullanicirol.tumsirketyetki = "Evet"
                Else
                    kullanicirol.tumsirketyetki = "Hayır"
                End If

                If CheckBox2.Checked = True Then
                    kullanicirol.panoyetki = "Evet"
                Else
                    kullanicirol.panoyetki = "Hayır"
                End If

                If CheckBox3.Checked = True Then
                    kullanicirol.islemyetki = "Evet"
                Else
                    kullanicirol.islemyetki = "Hayır"
                End If

                If CheckBox4.Checked = True Then
                    kullanicirol.aramayetki = "Evet"
                Else
                    kullanicirol.aramayetki = "Hayır"
                End If

                If CheckBox5.Checked = True Then
                    kullanicirol.tanimyetki = "Evet"
                Else
                    kullanicirol.tanimyetki = "Hayır"
                End If

                If CheckBox6.Checked = True Then
                    kullanicirol.fiyatyetki = "Evet"
                Else
                    kullanicirol.fiyatyetki = "Hayır"
                End If

                If CheckBox7.Checked = True Then
                    kullanicirol.belgeyonetimyetki = "Evet"
                Else
                    kullanicirol.belgeyonetimyetki = "Hayır"
                End If

                If CheckBox8.Checked = True Then
                    kullanicirol.resimyetki = "Evet"
                Else
                    kullanicirol.resimyetki = "Hayır"
                End If

                If CheckBox9.Checked = True Then
                    kullanicirol.kullaniciyonetimyetki = "Evet"
                Else
                    kullanicirol.kullaniciyonetimyetki = "Hayır"
                End If

                If CheckBox10.Checked = True Then
                    kullanicirol.raporyetki = "Evet"
                Else
                    kullanicirol.raporyetki = "Hayır"
                End If

                If CheckBox11.Checked = True Then
                    kullanicirol.logyetki = "Evet"
                Else
                    kullanicirol.logyetki = "Hayır"
                End If

                If CheckBox12.Checked = True Then
                    kullanicirol.mesajyetki = "Evet"
                Else
                    kullanicirol.mesajyetki = "Hayır"
                End If

                If CheckBox13.Checked = True Then
                    kullanicirol.ayaryetki = "Evet"
                Else
                    kullanicirol.ayaryetki = "Hayır"
                End If

                If CheckBox14.Checked = True Then
                    kullanicirol.sirkettarafaramayetki = "Evet"
                Else
                    kullanicirol.sirkettarafaramayetki = "Hayır"
                End If

                If CheckBox15.Checked = True Then
                    kullanicirol.servisayaryetki = "Evet"
                Else
                    kullanicirol.servisayaryetki = "Hayır"
                End If

                If CheckBox16.Checked = True Then
                    kullanicirol.profilyetki = "Evet"
                Else
                    kullanicirol.profilyetki = "Hayır"
                End If

                If CheckBox17.Checked = True Then
                    kullanicirol.sirkettarafkullaniciyaratyetki = "Evet"
                Else
                    kullanicirol.sirkettarafkullaniciyaratyetki = "Hayır"
                End If

                If CheckBox18.Checked = True Then
                    kullanicirol.toplumesajyetki = "Evet"
                Else
                    kullanicirol.toplumesajyetki = "Hayır"
                End If

                If CheckBox19.Checked = True Then
                    kullanicirol.dosyayetki = "Evet"
                Else
                    kullanicirol.dosyayetki = "Hayır"
                End If

                If CheckBox20.Checked = True Then
                    kullanicirol.sirkettarafraporerisim = "Evet"
                Else
                    kullanicirol.sirkettarafraporerisim = "Hayır"
                End If

                If CheckBox21.Checked = True Then
                    kullanicirol.rolsirkettarafindasecilebilsinmi = "Evet"
                Else
                    kullanicirol.rolsirkettarafindasecilebilsinmi = "Hayır"
                End If

                If CheckBox22.Checked = True Then
                    kullanicirol.sirkettanimyetki = "Evet"
                Else
                    kullanicirol.sirkettanimyetki = "Hayır"
                End If

                If CheckBox23.Checked = True Then
                    kullanicirol.acentetanimyetki = "Evet"
                Else
                    kullanicirol.acentetanimyetki = "Hayır"
                End If

                If CheckBox24.Checked = True Then
                    kullanicirol.personeltanimyetki = "Evet"
                Else
                    kullanicirol.personeltanimyetki = "Hayır"
                End If

                If CheckBox25.Checked = True Then
                    kullanicirol.aractarifetanimyetki = "Evet"
                Else
                    kullanicirol.aractarifetanimyetki = "Hayır"
                End If

                If CheckBox26.Checked = True Then
                    kullanicirol.ulketanimyetki = "Evet"
                Else
                    kullanicirol.ulketanimyetki = "Hayır"
                End If

                kullanicirol.anamenupkey = DropDownList1.SelectedValue

                If CheckBox27.Checked = True Then
                    kullanicirol.yardimyetki = "Evet"
                Else
                    kullanicirol.yardimyetki = "Hayır"
                End If

                kullanicirol.mensup = DropDownList2.SelectedValue

                If CheckBox28.Checked = True Then
                    kullanicirol.sirkettarafkullanicilisteyetki = "Evet"
                Else
                    kullanicirol.sirkettarafkullanicilisteyetki = "Hayır"
                End If

                If CheckBox29.Checked = True Then
                    kullanicirol.zeylcodetanimyetki = "Evet"
                Else
                    kullanicirol.zeylcodetanimyetki = "Hayır"
                End If

                If CheckBox30.Checked = True Then
                    kullanicirol.urunkodtanimyetki = "Evet"
                Else
                    kullanicirol.urunkodtanimyetki = "Hayır"
                End If

                If CheckBox31.Checked = True Then
                    kullanicirol.currencycodetanimyetki = "Evet"
                Else
                    kullanicirol.currencycodetanimyetki = "Hayır"
                End If

                If CheckBox32.Checked = True Then
                    kullanicirol.sirkettarafacenteyaratyetki = "Evet"
                Else
                    kullanicirol.sirkettarafacenteyaratyetki = "Hayır"
                End If

                If CheckBox33.Checked = True Then
                    kullanicirol.hasardurumkodtanimyetki = "Evet"
                Else
                    kullanicirol.hasardurumkodtanimyetki = "Hayır"
                End If

                If CheckBox34.Checked = True Then
                    kullanicirol.sadecesirketicimesajlasma = "Evet"
                Else
                    kullanicirol.sadecesirketicimesajlasma = "Hayır"
                End If

                If CheckBox35.Checked = True Then
                    kullanicirol.sadecesirketicidosyagonderimi = "Evet"
                Else
                    kullanicirol.sadecesirketicidosyagonderimi = "Hayır"
                End If

                If CheckBox36.Checked = True Then
                    kullanicirol.policetiptanimyetki = "Evet"
                Else
                    kullanicirol.policetiptanimyetki = "Hayır"
                End If

                If CheckBox37.Checked = True Then
                    kullanicirol.faturalandirmayetki = "Evet"
                Else
                    kullanicirol.faturalandirmayetki = "Hayır"
                End If

                If CheckBox38.Checked = True Then
                    kullanicirol.acentetiptanimyetki = "Evet"
                Else
                    kullanicirol.acentetiptanimyetki = "Hayır"
                End If

                If CheckBox39.Checked = True Then
                    kullanicirol.bazfiyatgirissureyetki = "Evet"
                Else
                    kullanicirol.bazfiyatgirissureyetki = "Hayır"
                End If

                If CheckBox40.Checked = True Then
                    kullanicirol.sirketbazfiyatgirisyetki = "Evet"
                Else
                    kullanicirol.sirketbazfiyatgirisyetki = "Hayır"
                End If

                If CheckBox41.Checked = True Then
                    kullanicirol.sadecemerkezgozuk = "Evet"
                Else
                    kullanicirol.sadecemerkezgozuk = "Hayır"
                End If

                If CheckBox42.Checked = True Then
                    kullanicirol.kimlikturtanimyetki = "Evet"
                Else
                    kullanicirol.kimlikturtanimyetki = "Hayır"
                End If

                If CheckBox43.Checked = True Then
                    kullanicirol.adminpolicearayetki = "Evet"
                Else
                    kullanicirol.adminpolicearayetki = "Hayır"
                End If

                If CheckBox44.Checked = True Then
                    kullanicirol.adminhasararayetki = "Evet"
                Else
                    kullanicirol.adminhasararayetki = "Hayır"
                End If

                If CheckBox45.Checked = True Then
                    kullanicirol.kuryetki = "Evet"
                Else
                    kullanicirol.kuryetki = "Hayır"
                End If

                If CheckBox46.Checked = True Then
                    kullanicirol.tpbelgeyetki = "Evet"
                Else
                    kullanicirol.tpbelgeyetki = "Hayır"
                End If

                If CheckBox47.Checked = True Then
                    kullanicirol.bekbelgeyetki = "Evet"
                Else
                    kullanicirol.bekbelgeyetki = "Hayır"
                End If

                If CheckBox48.Checked = True Then
                    kullanicirol.dinamikraporyetki = "Evet"
                Else
                    kullanicirol.dinamikraporyetki = "Hayır"
                End If

                If CheckBox49.Checked = True Then
                    kullanicirol.birlikpersoneltanimyetki = "Evet"
                Else
                    kullanicirol.birlikpersoneltanimyetki = "Hayır"
                End If

                If CheckBox50.Checked = True Then
                    kullanicirol.tanimlanmisdinamikraporyetki = "Evet"
                Else
                    kullanicirol.tanimlanmisdinamikraporyetki = "Hayır"
                End If

                If CheckBox51.Checked = True Then
                    kullanicirol.iptallistesiyetki = "Evet"
                Else
                    kullanicirol.iptallistesiyetki = "Hayır"
                End If

                If CheckBox52.Checked = True Then
                    kullanicirol.parakambiyoaramayetki = "Evet"
                Else
                    kullanicirol.parakambiyoaramayetki = "Hayır"
                End If

            
                result = kullanicirol_erisim.Duzenle(kullanicirol)
            End If

            durumlabel.Text = javascript.alertresult(result)
            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = kullanicirol_erisim.listele()

        End If

    End Sub

    Protected Sub Buttonyenikayit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonyenikayit.Click

        Response.Redirect("kullanicirol.aspx?op=yenikayit")
        Button1.Text = "Kaydet"

    End Sub

    Private Sub Buttonsil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Buttonsil.Click

        result = KULLANICIROL_erisim.Sil(Request.QueryString("pkey"))
        durumlabel.Text = javascript.alertresult(result)
        HttpContext.Current.Session("ltip") = "TÜMÜ"
        Label1.Text = kullanicirol_erisim.listele()

    End Sub

End Class