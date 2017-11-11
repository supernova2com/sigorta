Partial Public Class dinamikraporpopup
    Inherits System.Web.UI.Page



    Dim dinamikrapor As New CLASSDINAMIKRAPOR
    Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
    Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
    Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
    Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
    Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
    Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
    Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM
    Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
    Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
    Dim dinamikraporjavascript_erisim As New CLASSDINAMIKRAPORJAVASCRIPT_ERISIM

    Dim dropdownlist_erisim As New CLASSDROPDOWNLIST_ERISIM

    Dim site As New CLASSSITE
    Dim site_erisim As New CLASSSITE_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String

        'Test Düğmesi Göster Yada Gösterme
        If op <> "duzenle" Then
            Button3.Visible = False
            Button4.Visible = False
            Button6.Visible = False

        Else
            Button3.Visible = True
            Button4.Visible = True
            Button6.Visible = True
        End If


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------

        site = site_erisim.bultek(1)

        If Not Page.IsPostBack Then

            'iptallere göre düğmeleri gizle---------------------------------
            If Request.QueryString("hangiiptal") = "2" Then
                Buttongosterilecealaniptal.Visible = False
                inn.Value = "2"
            End If
            If Request.QueryString("hangiiptal") = "3" Then
                Buttonkosulfieldiptal.Visible = False
                inn.Value = "3"
            End If
            If Request.QueryString("hangiiptal") = "4" Then
                Buttonsiralamafieldiptal.Visible = False
                inn.Value = "4"
            End If
            If Request.QueryString("hangiiptal") = "5" Then
                Buttongrupfieldiptal.Visible = False
                inn.Value = "5"
            End If
            If Request.QueryString("hangiiptal") = "6" Then
                Buttonaggfunciptal.Visible = False
                inn.Value = "6"
            End If
            If Request.QueryString("hangiiptal") = "7" Then
                Buttondinamikraporgrafikiptal.Visible = False
                inn.Value = "7"
            End If
            If Request.QueryString("hangiiptal") = "8" Then
                Buttondinamikraporzamanlamaiptal.Visible = False
                inn.Value = "8"
            End If
            If Request.QueryString("hangiiptal") = "9" Then
                Buttondinamikkullanicibagiptal.Visible = False
                inn.Value = "9"
            End If
            If Request.QueryString("hangiiptal") = "10" Then
                Buttondinamikraporjavascriptiptal.Visible = False
                inn.Value = "10"
            End If
            '---------------------------------------------------------------

            Dim innquery As String
            innquery = Request.QueryString("inn")
            If innquery <> "" Then
                inn.Value = innquery
            End If

            TextBox1.Focus()
            site = site_erisim.bultek(1)

            'KULLANICI ROLLERİNİ DOLDUR
            Dim kullanicirol_erisim As New CLASSKULLANICIROL_ERISIM
            Dim kullanicirollari As New List(Of CLASSKULLANICIROL)
            kullanicirollari = kullanicirol_erisim.doldur
            For Each item As CLASSKULLANICIROL In kullanicirollari
                DropDownList27.Items.Add(New ListItem(item.rolad, item.pkey))
            Next

            'RAPOR TİPLERİNİ DOLDUR 
            DropDownList1.Items.Add(New ListItem("Standart", "Standart"))
            DropDownList1.Items.Add(New ListItem("Manuel", "Manuel"))

            'VERİTABANI TABLOLARINI DOLDUR
            Dim sqlveritabani_erisim As New CLASSSQLVERITABANI_ERISIM
            Dim tablolar As New List(Of CLASSVERITABANI)
            tablolar = sqlveritabani_erisim.doldurtabloadlari(site.sistemveritabaniad)
            For Each item As CLASSVERITABANI In tablolar
                DropDownList9.Items.Add(New ListItem(item.ilgiliad, item.ilgiliad))
            Next

            'KULLANICILARI DOLDUR 
            Dim kullanicilar As New List(Of CLASSKULLANICI)
            kullanicilar = kullanici_erisim.doldur()
            For Each item As CLASSKULLANICI In kullanicilar
                DropDownList17.Items.Add(New ListItem(item.adsoyad, item.pkey))
            Next

            'REMINDER SETTING DOLDUR
            Dim remindersetting_erisim As New CLASSREMINDERSETTING_ERISIM
            Dim remindersettingler As New List(Of CLASSREMINDERSETTING)
            remindersettingler = remindersetting_erisim.doldur()
            For Each item As CLASSREMINDERSETTING In remindersettingler
                DropDownList31.Items.Add(New ListItem(item.reminder_name, item.pkey))
            Next

            'kosul operatörlerini doldur
            DropDownList4.Items.Add(New ListItem("=", "="))
            DropDownList4.Items.Add(New ListItem("!=", "!="))
            DropDownList4.Items.Add(New ListItem(">", ">"))
            DropDownList4.Items.Add(New ListItem("<", "<"))
            DropDownList4.Items.Add(New ListItem(">=", ">="))
            DropDownList4.Items.Add(New ListItem("<=", "<="))
            DropDownList4.Items.Add(New ListItem(" like ", " like "))

            'bağ mantık operatorlerin doldur 
            DropDownList6.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList6.Items.Add(New ListItem("ve", "and"))
            DropDownList6.Items.Add(New ListItem("veya", "or"))

            'runtime doldur
            DropDownList5.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList5.Items.Add(New ListItem("Hayır", "Hayır"))

            'siralama türlerini doldur
            DropDownList8.Items.Add(New ListItem("Artan", "1"))
            DropDownList8.Items.Add(New ListItem("Azalan", "2"))

            'aggregate fonkisyonlarini doldur 
            DropDownList16.Items.Add(New ListItem("min", "min"))
            DropDownList16.Items.Add(New ListItem("max", "max"))
            DropDownList16.Items.Add(New ListItem("count", "count"))
            DropDownList16.Items.Add(New ListItem("avg", "avg"))
            DropDownList16.Items.Add(New ListItem("count", "count"))
            DropDownList16.Items.Add(New ListItem("sum", "sum"))

            'otogonder
            DropDownList18.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList18.Items.Add(New ListItem("Hayır", "Hayır"))

            'eposta
            DropDownList20.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList20.Items.Add(New ListItem("Hayır", "Hayır"))

            'entegredosya
            DropDownList21.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList21.Items.Add(New ListItem("Hayır", "Hayır"))

            'ARABİRİM TİPLERİNİ DOLDUR 
            DropDownList22.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList22.Items.Add(New ListItem("TextBox", "TextBox"))
            DropDownList22.Items.Add(New ListItem("DropDownList", "DropDownList"))

            'AGG FUNC TİPLERİNİ DOLDUR 
            DropDownList24.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList24.Items.Add(New ListItem("Sistem", "Sistem"))
            DropDownList24.Items.Add(New ListItem("Manuel", "Manuel"))

            'ARABİRİM OLUŞTURULSUNMU 
            DropDownList25.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList25.Items.Add(New ListItem("Hayır", "Hayır"))

            'GRUP MANTIK OPERATÖRLERİNİ DOLDUR
            DropDownList26.Items.Add(New ListItem("Seçiniz", "0"))
            DropDownList26.Items.Add(New ListItem("ve", "and"))
            DropDownList26.Items.Add(New ListItem("veya", "or"))

            'TOPLAMLAR GÖZÜKSÜN MÜ
            DropDownList29.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList29.Items.Add(New ListItem("Hayır", "Hayır"))

            'EK KELİMELER
            DropDownList30.Items.Add(New ListItem("Seçiniz", ""))
            DropDownList30.Items.Add(New ListItem("distinct", "distinct"))

            'GRAFİK TİP
            DropDownList32.Items.Add(New ListItem("Pie", "pie"))
            DropDownList32.Items.Add(New ListItem("Line", "line"))



            If op = "duzenle" Then
                'GRAFİK İÇİN kolonseriad,kolonsayi
                raporpkey = Request.QueryString("pkey")
                DropDownList33.Items.Add(New ListItem("Seçiniz", "0"))
                Dim gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
                gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(raporpkey)
                For Each itemtablo As CLASSGOSTERILECEKfield In gosterilecekfieldler
                    DropDownList33.Items.Add(New ListItem(itemtablo.fieldad, itemtablo.fieldad))
                Next
                DropDownList34.Items.Add(New ListItem("Seçiniz", "0"))
                Dim aggfunclar As New List(Of CLASSAGGFUNC)
                aggfunclar = aggfunc_erisim.doldurilgili(raporpkey)
                For Each itemtablo As CLASSAGGFUNC In aggfunclar
                    DropDownList34.Items.Add(New ListItem(itemtablo.sayialias, itemtablo.sayialias))
                Next
            End If


            'GRAFİK LABEL GÖSTERİLSİN Mİ
            DropDownList35.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList35.Items.Add(New ListItem("Hayır", "Hayır"))

            'GRAFİK LEGEND GÖSTERİLSİN Mİ
            DropDownList37.Items.Add(New ListItem("Evet", "Evet"))
            DropDownList37.Items.Add(New ListItem("Hayır", "Hayır"))

            If op = "yenikayit" Then
                Button2.Visible = False
                TextBox1.Focus()
            End If


            If op = "duzenle" Then

                raporpkey = Request.QueryString("pkey")
                Button2.Visible = True

                HttpContext.Current.Session("ltip") = "ilgili"
                HttpContext.Current.Session("raporpkey") = raporpkey

                'kullanilacak tabloları göster
                Dim ilgili_kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelkullanilacaktablo.Text = kullanilacaktablo_erisim.listele()

                'gosterilecek field leri göster 
                Dim ilgili_gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelgosterilecekfield.Text = gosterilecekfield_erisim.listele()

                'kosulfield leri goster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelkosulfield.Text = kosulfield_erisim.listele()

                'siralamafield leri goster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelsiralamafield.Text = siralamafield_erisim.listele()
                ilgili_gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(raporpkey)

                'grupfield leri goster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelgrupfield.Text = grupfield_erisim.listele()

                'aggfunc leri goster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelaggfunc.Text = aggfunc_erisim.listele()

                'grafikleri goster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labelgrafik.Text = dinamikraporgrafik_erisim.listele()

                'rapora erişim yetkisi olan kullanicilari göster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labeldinamikkullanicibag.Text = dinamikkullanicibag_erisim.listele()

                'zamanlama ayarlarını göster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labeldinamikraporzamanlama.Text = dinamikraporzamanlama_erisim.listele()

                'javascript göster
                HttpContext.Current.Session("ltip") = "ilgili"
                Labeldinamikraporjavascript.Text = dinamikraporjavascript_erisim.listele()

                Dim ilgili_grupfieldler As New List(Of CLASSGRUPFIELD)
                ilgili_grupfieldler = grupfield_erisim.doldurilgili(raporpkey)

                'gösterilecek field ler için tabloları doldur.
                ilgili_kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(raporpkey)
                DropDownList10.Items.Add(New ListItem("Seçiniz", 0))
                For Each itemtablo As CLASSKULLANILACAKTABLO In ilgili_kullanilacaktablolar
                    DropDownList10.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
                Next

                'kosul field ler için tabloları doldur.
                ilgili_kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(raporpkey)
                DropDownList11.Items.Add(New ListItem("Seçiniz", 0))
                For Each itemtablo As CLASSKULLANILACAKTABLO In ilgili_kullanilacaktablolar
                    DropDownList11.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
                Next

                'siralama field leri için tabloları oluştur
                ilgili_kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(raporpkey)
                DropDownList12.Items.Add(New ListItem("Seçiniz", 0))
                For Each itemtablo As CLASSKULLANILACAKTABLO In ilgili_kullanilacaktablolar
                    DropDownList12.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
                Next

                'grupfieldleri için gösterilecek alanların sql alias larını doldur
                DropDownList13.Items.Add(New ListItem("Seçiniz", 0))
                For Each itemgosterilecekfield As CLASSGOSTERILECEKfield In ilgili_gosterilecekfieldler
                    DropDownList13.Items.Add(New ListItem(itemgosterilecekfield.raporalias, itemgosterilecekfield.pkey))
                Next

                'agggreagete icin seçme tablolarini doldur
                DropDownList14.Items.Add(New ListItem("Seçiniz", 0))
                For Each itemtablo As CLASSKULLANILACAKTABLO In ilgili_kullanilacaktablolar
                    DropDownList14.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
                Next

                'ZAMANLAMA SEÇENEKLERİNİ DOLDUR
                Dim zamanlamalar As New List(Of CLASSDINAMIKRAPORZAMANLAMA)
                zamanlamalar = dinamikraporzamanlama_erisim.dolduriligili(raporpkey)
                For Each item As CLASSDINAMIKRAPORZAMANLAMA In zamanlamalar
                    DropDownList19.Items.Add(New ListItem(item.zamanlamaad, item.pkey))
                    DropDownList28.Items.Add(New ListItem(item.zamanlamaad, item.pkey))
                Next


                'DROPDOWN LİSTELERİ DOLDUR 
                Dim dropdownlisteler As New List(Of CLASSDROPDOWNLIST)
                dropdownlisteler = dropdownlist_erisim.doldur()
                DropDownList23.Items.Add(New ListItem("Seçiniz", "0"))
                For Each item As CLASSDROPDOWNLIST In dropdownlisteler
                    DropDownList23.Items.Add(New ListItem(item.ad, item.pkey))
                Next

                TextBox1.Focus()
                Button1.Text = "Değişiklikleri Güncelle"
                dinamikrapor = dinamikrapor_erisim.bultek(Request.QueryString("pkey"))

                'dinamikrapor logosunu göster
                TextBox1.Text = dinamikrapor.raporad
                TextBox2.Text = dinamikrapor.aciklama
                DropDownList1.SelectedValue = dinamikrapor.raportip
                TextBox14.Text = dinamikrapor.sqlstr
                DropDownList25.SelectedValue = dinamikrapor.arabirimolsunmu
                DropDownList29.SelectedValue = dinamikrapor.toplamlargosterilsinmi

                'JAVASCRIPT YARDIMCI TABLOYU GÖSTER
                Labeldinamikraporjavascriptyardimci.Text = kosulfield_erisim.listele_javascriptyardimci()




                'GÖSTERİLECEKALAN DÜZENLE İÇİN ----------------------------------------------------
                Dim gosterilecekalanop As String
                gosterilecekalanop = Request.QueryString("gosterilecekalanop")
                If gosterilecekalanop = "duzenle" Then
                    Buttongosterilecealaniptal.Visible = True
                    inn.Value = "2"
                    Buttongosterilecealankaydet.Text = "Güncelle"
                    Dim gosterilecekfield As New CLASSGOSTERILECEKfield
                    Dim gosterilecekfieldpkey As String
                    gosterilecekfieldpkey = Request.QueryString("gosterilecekfieldpkey")
                    gosterilecekfield = gosterilecekfield_erisim.bultek(gosterilecekfieldpkey)

                    'gosterilecekfield dropunu doldur ve seçtir
                    Dim site As New CLASSSITE
                    Dim site_erisim As New CLASSSITE_ERISIM
                    site = site_erisim.bultek(1)
                    Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                    Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
                    kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, gosterilecekfield.gosterilecektabload)
                    For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                        DropDownList2.Items.Add(New ListItem(item.column_name, item.column_name))
                    Next
                    DropDownList2.SelectedValue = gosterilecekfield.fieldad
                    TextBox3.Text = gosterilecekfield.sqlalias
                    TextBox4.Text = gosterilecekfield.raporalias
                    TextBox5.Text = gosterilecekfield.raporsira
                    DropDownList10.SelectedValue = gosterilecekfield.kullanilacaktablopkey
                    DropDownList30.SelectedValue = gosterilecekfield.ekkelime
                Else
                    Buttongosterilecealankaydet.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------


                'KOSULFIELD DÜZENLE İÇİN ----------------------------------------------------
                Dim kosulfieldop As String
                kosulfieldop = Request.QueryString("kosulfieldop")
                If kosulfieldop = "duzenle" Then
                    inn.Value = "3"
                    Buttonkosulfieldiptal.Visible = True
                    Buttonkosulfieldekle.Text = "Güncelle"
                    Dim kosulfield As New CLASSKOSULFIELD
                    Dim kosulfieldpkey As String
                    kosulfieldpkey = Request.QueryString("kosulfieldpkey")
                    kosulfield = kosulfield_erisim.bultek(kosulfieldpkey)

                    'kosul field leri doldur
                    Dim site As New CLASSSITE
                    Dim site_erisim As New CLASSSITE_ERISIM
                    site = site_erisim.bultek(1)
                    Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                    Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
                    kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, kosulfield.kosultabload)
                    DropDownList3.Items.Clear()
                    For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                        DropDownList3.Items.Add(New ListItem(item.column_name, item.column_name))
                    Next

                    DropDownList3.SelectedValue = kosulfield.fieldad
                    TextBox6.Text = kosulfield.sira
                    DropDownList5.SelectedValue = kosulfield.runtime
                    DropDownList4.SelectedValue = kosulfield.kosulop
                    TextBox7.Text = kosulfield.deger
                    DropDownList6.SelectedValue = kosulfield.bagmantikop
                    DropDownList11.SelectedValue = kosulfield.kullanilacaktablopkey
                    TextBox12.Text = kosulfield.arabirimlabel
                    DropDownList22.SelectedValue = kosulfield.arabirimtip
                    DropDownList23.SelectedValue = kosulfield.dropdownlistpkey
                    TextBox17.Text = kosulfield.kosulgrupno
                    DropDownList26.SelectedValue = kosulfield.grupmantikop
                    TextBox18.Text = kosulfield.sezonad

                Else
                    Buttonkosulfieldekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

                'SIRALAMAFIELD DÜZENLE İÇİN ----------------------------------------------------
                Dim siralamafieldop As String
                siralamafieldop = Request.QueryString("siralamafieldop")
                If siralamafieldop = "duzenle" Then
                    inn.Value = "4"
                    Buttonsiralamafieldiptal.Visible = True
                    Buttonsiralamaekle.Text = "Güncelle"

                    Dim siralamafield As New CLASSSIRALAMAFIELD
                    Dim siralamafieldpkey As String
                    siralamafieldpkey = Request.QueryString("siralamafieldpkey")
                    siralamafield = siralamafield_erisim.bultek(siralamafieldpkey)

                    'siralama field leri doldur
                    Dim site As New CLASSSITE
                    Dim site_erisim As New CLASSSITE_ERISIM
                    site = site_erisim.bultek(1)

                    Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                    Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
                    kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, siralamafield.siralamatabload)
                    DropDownList7.Items.Clear()
                    For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                        DropDownList7.Items.Add(New ListItem(item.column_name, item.column_name))
                    Next

                    siralamafield.raporpkey = raporpkey
                    DropDownList7.SelectedValue = siralamafield.fieldad
                    TextBox8.Text = siralamafield.sirano
                    DropDownList8.SelectedValue = siralamafield.ordertype
                    DropDownList12.SelectedValue = siralamafield.kullanilacaktablopkey

                Else
                    Buttonsiralamaekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

                'GRUPFIELD DÜZENLE İÇİN ----------------------------------------------------
                Dim grupfieldop As String
                grupfieldop = Request.QueryString("grupfieldop")
                If grupfieldop = "duzenle" Then
                    inn.Value = "5"
                    Buttongrupfieldiptal.Visible = True
                    Buttongrupfieldekle.Text = "Güncelle"

                    Dim grupfield As New CLASSGRUPFIELD
                    Dim grupfieldpkey As String
                    grupfieldpkey = Request.QueryString("grupfieldpkey")
                    grupfield = grupfield_erisim.bultek(grupfieldpkey)
                    DropDownList13.SelectedValue = grupfield.gosterilecekfieldpkeybag
                    TextBox13.Text = grupfield.grupsira
                Else
                    Buttongrupfieldekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------


                'AGGREAGATE DÜZENLE İÇİN ----------------------------------------------------
                Dim aggfuncop As String
                aggfuncop = Request.QueryString("aggfuncop")
                If aggfuncop = "duzenle" Then
                    inn.Value = "6"
                    Buttonaggfunciptal.Visible = True
                    Buttonaggfuncekle.Text = "Güncelle"

                    Dim aggfunc As New CLASSAGGFUNC
                    Dim aggfuncpkey As String
                    aggfuncpkey = Request.QueryString("aggfuncpkey")
                    aggfunc = aggfunc_erisim.bultek(aggfuncpkey)
                    DropDownList16.SelectedValue = aggfunc.fonksiyonad
                    TextBox9.Text = aggfunc.sayialias
                    DropDownList14.SelectedValue = aggfunc.ktablopkey
                    Dim site As New CLASSSITE
                    Dim site_erisim As New CLASSSITE_ERISIM
                    site = site_erisim.bultek(1)
                    Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                    Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
                    kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList14.SelectedItem.Text)
                    For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                        DropDownList15.Items.Add(New ListItem(item.column_name, item.column_name))
                    Next
                    DropDownList15.SelectedValue = aggfunc.fieldad
                    DropDownList24.SelectedValue = aggfunc.fonksiyontip
                    TextBox15.Text = aggfunc.fonksiyonsql
                    TextBox16.Text = aggfunc.kolonbaslik
                Else
                    Buttonaggfuncekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

                'GRAFİK DÜZENLE İÇİN ----------------------------------------------------
                Dim dinamikraporgrafikop As String
                dinamikraporgrafikop = Request.QueryString("dinamikraporgrafikop")
                If dinamikraporgrafikop = "duzenle" Then
                    inn.Value = "7"
                    Buttondinamikraporgrafikiptal.Visible = True
                    Buttondinamikraporgrafikekle.Text = "Güncelle"
                    Dim dinamikraporgrafik As New CLASSDINAMIKRAPORGRAFIK
                    Dim dinamikraporgrafikpkey As String
                    dinamikraporgrafikpkey = Request.QueryString("dinamikraporgrafikpkey")
                    dinamikraporgrafik = dinamikraporgrafik_erisim.bultek(dinamikraporgrafikpkey)
                    TextBox11.Text = dinamikraporgrafik.grafikbaslik
                    DropDownList32.SelectedValue = dinamikraporgrafik.grafiktip
                    TextBox21.Text = dinamikraporgrafik.genislik
                    TextBox22.Text = dinamikraporgrafik.yukseklik
                    DropDownList33.SelectedValue = dinamikraporgrafik.kolonseriad
                    DropDownList34.SelectedValue = dinamikraporgrafik.kolonsayi
                    DropDownList35.SelectedValue = dinamikraporgrafik.labelgosterilsinmi
                    TextBox23.Text = dinamikraporgrafik.labelarkaplanrengi
                    TextBox19.Text = dinamikraporgrafik.labelseffaflik
                    DropDownList37.SelectedValue = dinamikraporgrafik.legendgosterilsinmi
                Else
                    Buttondinamikraporgrafikekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------

                'ZAMANLAMA DÜZENLE İÇİN ---------------------------------------------------------
                Dim dinamikraporzamanlamaop As String
                dinamikraporzamanlamaop = Request.QueryString("dinamikraporzamanlamaop")
                If dinamikraporzamanlamaop = "duzenle" Then
                    inn.Value = "8"
                    Buttondinamikraporzamanlamaiptal.Visible = True
                    Buttondinamikraporzamanlamaekle.Text = "Güncelle"
                    Dim dinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
                    Dim dinamikraporzamanlamapkey As String
                    dinamikraporzamanlamapkey = Request.QueryString("dinamikraporzamanlamapkey")
                    dinamikraporzamanlama = dinamikraporzamanlama_erisim.bultek(dinamikraporzamanlamapkey)
                    TextBox10.Text = dinamikraporzamanlama.zamanlamaad
                    DropDownList31.SelectedValue = dinamikraporzamanlama.remindersettingpkey
                Else
                    Buttondinamikraporzamanlamaekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------


                'KULLANICI RAPOR BAG ----------------------------------------------------
                Dim dinamikkullanicibagop As String
                dinamikkullanicibagop = Request.QueryString("dinamikraporkullanicibagop")
                If dinamikkullanicibagop = "duzenle" Then
                    inn.Value = "9"
                    Buttondinamikkullanicibagiptal.Visible = True
                    Buttondinamikkullanicibagekle.Text = "Güncelle"

                    Dim dinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
                    Dim dinamikkullanicibagpkey As String
                    dinamikkullanicibagpkey = Request.QueryString("dinamikraporkullanicibagpkey")
                    dinamikkullanicibag = dinamikkullanicibag_erisim.bultek(dinamikkullanicibagpkey)
                    DropDownList17.SelectedValue = dinamikkullanicibag.kullanicipkey
                    DropDownList18.SelectedValue = dinamikkullanicibag.otogonder
                    DropDownList19.SelectedValue = dinamikkullanicibag.zamanlamapkey
                    DropDownList20.SelectedValue = dinamikkullanicibag.epostagitsinmi
                    DropDownList21.SelectedValue = dinamikkullanicibag.entegredosyagitsinmi
                Else
                    Buttondinamikkullanicibagekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------



                'JAVASCRIPT DÜZENLE İÇİN ----------------------------------------------------
                Dim dinamikraporjavascriptop As String
                dinamikraporjavascriptop = Request.QueryString("dinamikraporjavascriptop")
                If dinamikraporjavascriptop = "duzenle" Then
                    inn.Value = "10"
                    Buttondinamikraporjavascriptiptal.Visible = True
                    Buttondinamikraporjavascriptekle.Text = "Güncelle"

                    Dim dinamikraporjavascript As New CLASSDINAMIKRAPORJAVASCRIPT
                    Dim dinamikraporjavascriptpkey As String
                    dinamikraporjavascriptpkey = Request.QueryString("dinamikraporjavascriptpkey")
                    dinamikraporjavascript = dinamikraporjavascript_erisim.bultek(dinamikraporjavascriptpkey)
                    TextBox20.Text = dinamikraporjavascript.jv
                Else
                    Buttondinamikraporjavascriptekle.Text = "Ekle"
                End If
                '--------------------------------------------------------------------------------


            End If

        End If 'postback

    End Sub


    'DİNAMİK RAPORU KAYDET
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim hata As String

        Dim dinamikrapor As New CLASSDINAMIKRAPOR
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'rapor adı
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Rapor adını girmediniz.</li>"
            inn.Value = "0"
        End If

        'rapor aciklama
        If TextBox2.Text = "" Then
            TextBox2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Rapor açıklamasını girmediniz.</li>"
            inn.Value = "0"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""

            dinamikrapor.raporad = TextBox1.Text
            dinamikrapor.aciklama = TextBox2.Text
            dinamikrapor.raportip = DropDownList1.SelectedValue
            dinamikrapor.sqlstr = TextBox14.Text
            dinamikrapor.arabirimolsunmu = DropDownList25.SelectedValue
            dinamikrapor.toplamlargosterilsinmi = DropDownList29.SelectedValue


            If Request.QueryString("op") = "yenikayit" Then
                result = dinamikrapor_erisim.Ekle(dinamikrapor)
                If result.durum = "Kaydedildi" Then
                    inn.Value = "1"

                    'BU RAPORU YARATAN KULLANACIYA BU RAPORA ERİŞİM YETKİSİ VER
                    Dim dinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
                    Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
                    dinamikkullanicibag.kullanicipkey = Session("kullanici_pkey")
                    dinamikkullanicibag.raporpkey = result.etkilenen
                    dinamikkullanicibag_erisim.Ekle(dinamikkullanicibag)
                    '---------------------------------------------------------------
                    Dim duzenlemelink As String
                    duzenlemelink = "dinamikraporpopup.aspx?pkey=" + CStr(result.etkilenen) + "&op=duzenle&inn=1"
                    Response.Redirect(duzenlemelink)
                End If
            End If

            If Request.QueryString("op") = "duzenle" Then
                dinamikrapor = dinamikrapor_erisim.bultek(Request.QueryString("pkey"))
                dinamikrapor.raporad = TextBox1.Text
                dinamikrapor.aciklama = TextBox2.Text
                dinamikrapor.raportip = DropDownList1.SelectedValue
                dinamikrapor.sqlstr = TextBox14.Text
                dinamikrapor.arabirimolsunmu = DropDownList25.SelectedValue
                dinamikrapor.toplamlargosterilsinmi = DropDownList29.SelectedValue
                result = dinamikrapor_erisim.Duzenle(dinamikrapor)
            End If

            If result.durum = "Kaydedildi" Then
                inn.Value = "1"
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

        End If 'hata=0

    End Sub


    ' RAPOR SİLME------------
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Dim result As New CLADBOPRESULT

        If Request.QueryString("pkey") <> "" Then

            Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
            result = dinamikrapor_erisim.Sil(Request.QueryString("pkey"))

            If result.etkilenen = 0 Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

        End If

        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3>" + _
            "<ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If


    End Sub


    'KULLANILACAK TABLOLAR EKLE
    Protected Sub Buttonkullanilacaktabloekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonkullanilacaktabloekle.Click

        Dim kullanilacaktablo As New CLASSKULLANILACAKTABLO
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")

        inn.Value = "1"
        Dim hatamesajlari As String
        Dim hata As String = "0"

        Dim ilisikliresult As New CLADBOPRESULT
        ilisikliresult = dinamikrapor_erisim.tabloilisiklimi(raporpkey, DropDownList9.SelectedValue)
        If ilisikliresult.durum = "Hayır" Then
            DropDownList9.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>" + ilisikliresult.hatastr + "</li>"
            inn.Value = "1"
        End If

        If hata = "1" Then
            Labeldurumkullanilacaktablo.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            kullanilacaktablo.tabload = DropDownList9.SelectedValue
            kullanilacaktablo.raporpkey = raporpkey

            result = kullanilacaktablo_erisim.Ekle(kullanilacaktablo)

            If result.etkilenen = 0 Then
                Labeldurumkullanilacaktablo.Text = "<div id=errorMsg>" + _
                "<h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                Labeldurumkullanilacaktablo.Text = "<div id=okMsg>" + _
                "<p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

            'kullanilacak tabloları göster
            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Dim ilgili_kullanilacaktablolar As New List(Of CLASSKULLANILACAKTABLO)
            Labelkullanilacaktablo.Text = kullanilacaktablo_erisim.listele()


            'kullanilacak tablolara göre tum tablo alanlarını doldur
            DropDownList2.Items.Clear()
            DropDownList3.Items.Clear()
            DropDownList7.Items.Clear()
            site = site_erisim.bultek(1)
            ilgili_kullanilacaktablolar = kullanilacaktablo_erisim.doldurilgili(raporpkey)
            For Each itemtablo As CLASSKULLANILACAKTABLO In ilgili_kullanilacaktablolar
                DropDownList10.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
                DropDownList11.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
                DropDownList12.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
                DropDownList14.Items.Add(New ListItem(itemtablo.tabload, itemtablo.pkey))
            Next

            'kullanilacak tablolara göre dropdownlistleri doldur 
            Dim dropdownlisteler As New List(Of CLASSDROPDOWNLIST)
            dropdownlisteler = dropdownlist_erisim.doldurilgili(raporpkey)
            DropDownList23.Items.Clear()
            For Each item As CLASSDROPDOWNLIST In dropdownlisteler
                DropDownList23.Items.Add(New ListItem(item.ad, item.pkey))
            Next

        End If


    End Sub


    'GÖSTERİLECEK FIELD LER EKLE
    Protected Sub Buttongosterilecealankaydet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongosterilecealankaydet.Click

        Dim hata As String

        Dim raporpkey As String
        Dim gosterilecekfield As New CLASSGOSTERILECEKfield
        Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
        raporpkey = Request.QueryString("pkey")

        inn.Value = "2"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        If DropDownList10.SelectedValue = "0" Then
            DropDownList10.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Tabloyu seçmediniz.</li>"
            inn.Value = "2"
        End If

        If DropDownList2.SelectedValue = "0" Then
            DropDownList2.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Alan adını seçmediniz.</li>"
            inn.Value = "2"
        End If


        'sql alias
        If TextBox3.Text = "" Then
            TextBox3.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Sql alias'ı girmediniz.</li>"
            inn.Value = "2"
        End If

        'rapor alias
        If TextBox4.Text = "" Then
            TextBox4.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Rapor başlığını girmediniz.</li>"
            inn.Value = "2"
        End If

        'rapor sira
        If IsNumeric(TextBox5.Text) = False Then
            TextBox5.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Sıra numarası rakamsal olmalıdır.</li>"
            inn.Value = "2"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then
            Dim gosterilecekalanop As String
            gosterilecekalanop = Request.QueryString("gosterilecekalanop")
            hatamesajlari = ""

            If gosterilecekalanop <> "duzenle" Then
                gosterilecekfield.raporpkey = raporpkey
                gosterilecekfield.fieldad = DropDownList2.SelectedValue
                gosterilecekfield.sqlalias = TextBox3.Text
                gosterilecekfield.raporalias = TextBox4.Text
                gosterilecekfield.raporsira = TextBox5.Text
                gosterilecekfield.gosterilecektabload = DropDownList10.SelectedItem.Text
                gosterilecekfield.kullanilacaktablopkey = DropDownList10.SelectedValue
                gosterilecekfield.ekkelime = DropDownList30.SelectedValue
                result = gosterilecekfield_erisim.Ekle(gosterilecekfield)

                'grupfield lere ekle bu alanı 
                Dim ilgili_gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
                ilgili_gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(raporpkey)

                DropDownList13.Items.Clear()
                For Each itemgosterilecekfield As CLASSGOSTERILECEKfield In ilgili_gosterilecekfieldler
                    DropDownList13.Items.Add(New ListItem(itemgosterilecekfield.raporalias, itemgosterilecekfield.pkey))
                Next

            End If

            If gosterilecekalanop = "duzenle" Then
                Dim gosterilecekfieldpkey As String
                gosterilecekfieldpkey = Request.QueryString("gosterilecekfieldpkey")
                gosterilecekfield = gosterilecekfield_erisim.bultek(gosterilecekfieldpkey)
                gosterilecekfield.raporpkey = raporpkey
                gosterilecekfield.fieldad = DropDownList2.SelectedValue
                gosterilecekfield.sqlalias = TextBox3.Text
                gosterilecekfield.raporalias = TextBox4.Text
                gosterilecekfield.raporsira = TextBox5.Text
                gosterilecekfield.gosterilecektabload = DropDownList10.SelectedItem.Text
                gosterilecekfield.kullanilacaktablopkey = DropDownList10.SelectedValue
                gosterilecekfield.ekkelime = DropDownList30.SelectedValue
                result = gosterilecekfield_erisim.Duzenle(gosterilecekfield)
            End If


            'GRAFİKTE KOLON SERİ ADI GÜNCELLE
            If result.durum = "Kaydedildi" Then
                DropDownList33.Items.Clear()
                DropDownList33.Items.Add(New ListItem("Seçiniz", "0"))
                Dim gosterilecekfieldler As New List(Of CLASSGOSTERILECEKfield)
                gosterilecekfieldler = gosterilecekfield_erisim.doldurilgili(raporpkey)
                For Each itemtablo As CLASSGOSTERILECEKfield In gosterilecekfieldler
                    DropDownList33.Items.Add(New ListItem(itemtablo.fieldad, itemtablo.fieldad))
                Next
            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labelgosterilecekfield.Text = gosterilecekfield_erisim.listele

        End If


    End Sub

    'KOSULFIELD EKLE
    Protected Sub Buttonkosulfieldekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonkosulfieldekle.Click

        Dim hata As String

        Dim op As String
        Dim raporpkey As String
        Dim kosulfield As New CLASSKOSULFIELD
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        raporpkey = Request.QueryString("pkey")
        op = Request.QueryString("op")


        inn.Value = "3"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'tablo adı
        If DropDownList11.SelectedValue = "0" Then
            DropDownList11.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Tabloyu seçmediniz.</li>"
            inn.Value = "3"
        End If

        'sira
        If IsNumeric(TextBox6.Text) = False Then
            TextBox6.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Sıra numarası rakamsal olmalıdır.</li>"
            inn.Value = "3"
        End If

        'deger
        If TextBox7.Text = "" Then
            TextBox7.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Runtime olmayan field ler için değeri girilmelidir." + _
            "Ayrıca koşul runtime olsa bile default değer girilmelidir.</li>"
            inn.Value = "3"
        End If

        If DropDownList5.SelectedValue = "Evet" And TextBox12.Text = "" Then
            TextBox12.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Arabirim form etiketi girilmelidir.</li>"
            inn.Value = "3"
        End If

        If DropDownList22.SelectedValue = "0" Then
            DropDownList22.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Arabirim tipini seçmediniz.</li>"
            inn.Value = "3"
        End If

        'kosul grup no
        If IsNumeric(TextBox17.Text) = False Then
            TextBox17.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Koşul grup numarası rakamsal olmalıdır.</li>"
            inn.Value = "3"
        End If


        If DropDownList22.SelectedValue = "DropDownList" Then
            If DropDownList23.SelectedValue = "0" Then
                DropDownList23.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Listeyi seçmediniz.</li>"
                inn.Value = "3"
            End If
        End If

        'mantıksal kontrol sezon
        If TextBox18.Text <> "" Then
            If DropDownList5.SelectedValue = "Evet" Then
                TextBox18.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Sezon değişkenleri run-time'da istenmez.</li>"
                inn.Value = "3"
            End If
        End If

        'mantıksal kontrol 
        Dim kosulfieldop As String
        kosulfieldop = Request.QueryString("kosulfieldop")

        If hata = "0" Then
            If kosulfieldop = "yenikayit" And kosulfield_erisim.siranumarasivarmi(raporpkey, TextBox6.Text) = "Evet" Then
                TextBox6.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Bu sıra numaralı koşul zaten halihazırda kayıtlıdır." + _
                "Koşulların sıra numaraları birbirinden farklı olmalıdır.</li>"
                inn.Value = "3"
            End If

            If kosulfieldop = "duzenle" Then
                Dim kosulfieldpkey As String
                kosulfieldpkey = Request.QueryString("kosulfieldpkey")
                kosulfield = kosulfield_erisim.bultek(kosulfieldpkey)
                If kosulfield.sira <> CInt(TextBox6.Text) Then
                    If kosulfield_erisim.siranumarasivarmi(raporpkey, TextBox6.Text) = "Evet" Then
                        TextBox6.Focus()
                        hata = "1"
                        hatamesajlari = hatamesajlari + "<li>Bu sıra numaralı koşul zaten halihazırda kayıtlıdır." + _
                        "Koşulların sıra numaraları birbirinden farklı olmalıdır.</li>"
                        inn.Value = "3"
                    End If
                End If
            End If
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then


            hatamesajlari = ""

            If kosulfieldop <> "duzenle" Then
                kosulfield.raporpkey = raporpkey
                kosulfield.fieldad = DropDownList3.SelectedValue
                kosulfield.sira = TextBox6.Text
                kosulfield.runtime = DropDownList5.SelectedValue
                kosulfield.kosulop = DropDownList4.SelectedValue
                kosulfield.deger = TextBox7.Text
                kosulfield.bagmantikop = DropDownList6.SelectedValue
                kosulfield.kosultabload = DropDownList11.SelectedItem.Text
                kosulfield.kullanilacaktablopkey = DropDownList11.SelectedValue
                'data tipini bulalım
                Dim veritabanikolondetay As New CLASSVERITABANIKOLONDETAY
                Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                veritabanikolondetay = sqlveritabanikolondetay_erisim.bulkolondetay(site.sistemveritabaniad, kosulfield.kosultabload, kosulfield.fieldad)
                kosulfield.fieldtype = veritabanikolondetay.data_type
                kosulfield.arabirimtip = DropDownList22.SelectedValue

                Try
                    kosulfield.dropdownlistpkey = DropDownList23.SelectedValue
                Catch
                    kosulfield.dropdownlistpkey = 0
                End Try

                kosulfield.kosulgrupno = TextBox17.Text
                kosulfield.grupmantikop = DropDownList26.SelectedValue
                kosulfield.sezonad = TextBox18.Text


                'girilen default değer ile veri tipi uyuşuyormu -----------------------------
                Dim degerdogrumu As New CLADBOPRESULT
                degerdogrumu = dinamikrapor_erisim.validateinput(kosulfield.fieldtype, kosulfield.deger)
                If degerdogrumu.durum = "Kaydedilmedi" Then
                    result = degerdogrumu
                End If
                If degerdogrumu.durum = "Kaydedildi" Then
                    kosulfield.arabirimlabel = TextBox12.Text
                    result = kosulfield_erisim.Ekle(kosulfield)
                End If
                '-----------------------------------------------------------------------------
            End If


            If kosulfieldop = "duzenle" Then

                Dim kosulfieldpkey As String
                kosulfieldpkey = Request.QueryString("kosulfieldpkey")
                kosulfield = kosulfield_erisim.bultek(kosulfieldpkey)

                kosulfield.fieldad = DropDownList3.SelectedValue
                kosulfield.sira = TextBox6.Text
                kosulfield.runtime = DropDownList5.SelectedValue
                kosulfield.kosulop = DropDownList4.SelectedValue
                kosulfield.deger = TextBox7.Text
                kosulfield.bagmantikop = DropDownList6.SelectedValue
                kosulfield.kosultabload = DropDownList11.SelectedItem.Text
                kosulfield.kullanilacaktablopkey = DropDownList11.SelectedValue
                kosulfield.arabirimlabel = TextBox12.Text
                kosulfield.arabirimtip = DropDownList22.SelectedValue
                kosulfield.dropdownlistpkey = DropDownList23.SelectedValue
                kosulfield.kosulgrupno = TextBox17.Text
                kosulfield.grupmantikop = DropDownList26.SelectedValue
                kosulfield.sezonad = TextBox18.Text

                Dim veritabanikolondetay As New CLASSVERITABANIKOLONDETAY
                Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
                veritabanikolondetay = sqlveritabanikolondetay_erisim.bulkolondetay(site.sistemveritabaniad, kosulfield.kosultabload, kosulfield.fieldad)
                kosulfield.fieldtype = veritabanikolondetay.data_type

                'girilen default değer ile veri tipi uyuşuyormu -----------------------------
                Dim degerdogrumu As New CLADBOPRESULT
                degerdogrumu = dinamikrapor_erisim.validateinput(kosulfield.fieldtype, kosulfield.deger)
                If degerdogrumu.durum = "Kaydedilmedi" Then
                    result = degerdogrumu
                End If
                If degerdogrumu.durum = "Kaydedildi" Then
                    kosulfield.arabirimlabel = TextBox12.Text
                    result = kosulfield_erisim.Duzenle(kosulfield)
                End If
                '-----------------------------------------------------------------------------

            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
                Labeldinamikraporjavascriptyardimci.Text = kosulfield_erisim.listele_javascriptyardimci()
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labelkosulfield.Text = kosulfield_erisim.listele

        End If


    End Sub

    'SIRALAMA EKLE
    Protected Sub Buttonsiralamaekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonsiralamaekle.Click

        Dim hata As String

        Dim raporpkey As String
        Dim siralamafield As New CLASSSIRALAMAFIELD
        Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
        raporpkey = Request.QueryString("pkey")

        inn.Value = "4"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"


        If DropDownList12.SelectedValue = "0" Then
            DropDownList12.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Tabloyu seçmediniz.</li>"
            inn.Value = "4"
        End If

        'sira
        If IsNumeric(TextBox8.Text) = False Then
            TextBox8.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Sıra numarası rakamsal olmalıdır.</li>"
            inn.Value = "4"
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""

            Dim siralamafieldop As String
            siralamafieldop = Request.QueryString("siralamafieldop")

            If siralamafieldop <> "duzenle" Then
                siralamafield.raporpkey = raporpkey
                siralamafield.fieldad = DropDownList7.SelectedValue
                siralamafield.sirano = TextBox8.Text
                siralamafield.ordertype = DropDownList8.SelectedValue
                siralamafield.siralamatabload = DropDownList12.SelectedItem.Text
                siralamafield.kullanilacaktablopkey = DropDownList12.SelectedValue
                result = siralamafield_erisim.Ekle(siralamafield)
            End If

            If siralamafieldop = "duzenle" Then

                Dim siralamafieldpkey As String
                siralamafieldpkey = Request.QueryString("siralamafieldpkey")
                siralamafield = siralamafield_erisim.bultek(siralamafieldpkey)

                siralamafield.fieldad = DropDownList7.SelectedValue
                siralamafield.sirano = TextBox8.Text
                siralamafield.ordertype = DropDownList8.SelectedValue
                siralamafield.siralamatabload = DropDownList12.SelectedItem.Text
                siralamafield.kullanilacaktablopkey = DropDownList12.SelectedValue
                result = siralamafield_erisim.Duzenle(siralamafield)
            End If


            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labelsiralamafield.Text = siralamafield_erisim.listele

        End If

    End Sub

    'GRUP FIELD EKLE -----------
    Protected Sub Buttongrupfieldekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongrupfieldekle.Click

        Dim hata As String
        Dim raporpkey As String
        Dim grupfield As New CLASSGRUPFIELD
        Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
        raporpkey = Request.QueryString("pkey")

        inn.Value = "5"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        If DropDownList13.SelectedValue = "0" Then
            DropDownList13.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Gruplanacak rapor başlığını seçmediniz.</li>"
            inn.Value = "5"
        End If

        If IsNumeric(TextBox13.Text) = False Then
            TextBox13.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Grup sıra numarası rakamsal olmalıdır.</li>"
            inn.Value = "5"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""
            Dim grupfieldop As String
            grupfieldop = Request.QueryString("grupfieldop")

            If grupfieldop <> "duzenle" Then
                grupfield.gosterilecekfieldpkeybag = DropDownList13.SelectedValue
                Dim gosterilecekfield As New CLASSGOSTERILECEKfield
                Dim gosterilecefield_erisim As New CLASSGOSTERILECEKfield_ERISIM
                gosterilecekfield = gosterilecekfield_erisim.bultek(grupfield.gosterilecekfieldpkeybag)
                grupfield.gruptabload = gosterilecekfield.gosterilecektabload
                grupfield.gruptablopkey = gosterilecekfield.kullanilacaktablopkey
                grupfield.raporpkey = raporpkey
                grupfield.grupsira = TextBox13.Text
                result = grupfield_erisim.Ekle(grupfield)
            End If

            If grupfieldop = "duzenle" Then
                Dim grupfieldpkey As String
                grupfieldpkey = Request.QueryString("grupfieldpkey")
                grupfield = grupfield_erisim.bultek(grupfieldpkey)
                grupfield.gosterilecekfieldpkeybag = DropDownList13.SelectedValue
                Dim gosterilecekfield As New CLASSGOSTERILECEKfield
                Dim gosterilecefield_erisim As New CLASSGOSTERILECEKfield_ERISIM
                gosterilecekfield = gosterilecekfield_erisim.bultek(grupfield.gosterilecekfieldpkeybag)
                grupfield.gruptabload = gosterilecekfield.gosterilecektabload
                grupfield.gruptablopkey = gosterilecekfield.kullanilacaktablopkey
                grupfield.raporpkey = raporpkey
                grupfield.grupsira = TextBox13.Text
                result = grupfield_erisim.Duzenle(grupfield)
            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labelgrupfield.Text = grupfield_erisim.listele

        End If

    End Sub

    'AGGREGATE FUNCTİON EKLE
    Protected Sub Buttonaggfuncekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonaggfuncekle.Click

        Dim hata As String
        Dim raporpkey As String
        Dim aggfunc As New CLASSAGGFUNC
        Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
        raporpkey = Request.QueryString("pkey")

        inn.Value = "6"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'sql alias
        If TextBox9.Text = "" Then
            TextBox9.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Sql alias'ı girmediniz.</li>"
            inn.Value = "6"
        End If

        'fonksiyon tip 
        If DropDownList24.SelectedValue = "0" Then
            DropDownList24.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Fonksiyon tipini seçmediniz.</li>"
            inn.Value = "6"
        End If

        'fonksiyon sql 
        If DropDownList24.SelectedValue = "Manuel" Then
            If TextBox15.Text = "" Then
                TextBox15.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Manuel sql'i yazmadınız.</li>"
                inn.Value = "6"
            End If
        End If

        'kolon başlığı
        If TextBox16.Text = "" Then
            TextBox16.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Kolon başlığını girmediniz.</li>"
            inn.Value = "6"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""
            Dim aggfuncop As String
            aggfuncop = Request.QueryString("aggfuncop")

            If aggfuncop <> "duzenle" Then
                aggfunc.raporpkey = raporpkey
                aggfunc.fonksiyonad = DropDownList16.SelectedValue
                aggfunc.sayialias = TextBox9.Text
                aggfunc.ktablopkey = DropDownList14.SelectedValue
                aggfunc.fieldad = DropDownList15.SelectedValue
                aggfunc.fonksiyontip = DropDownList24.SelectedValue
                aggfunc.fonksiyonsql = TextBox15.Text
                aggfunc.kolonbaslik = TextBox16.Text
                result = aggfunc_erisim.Ekle(aggfunc)
            End If

            If aggfuncop = "duzenle" Then
                Dim aggfuncpkey As String
                aggfuncpkey = Request.QueryString("aggfuncpkey")
                aggfunc = aggfunc_erisim.bultek(aggfuncpkey)
                aggfunc.fonksiyonad = DropDownList16.SelectedValue
                aggfunc.sayialias = TextBox9.Text
                aggfunc.ktablopkey = DropDownList14.SelectedValue
                aggfunc.fieldad = DropDownList15.SelectedValue
                aggfunc.fonksiyontip = DropDownList24.SelectedValue
                aggfunc.fonksiyonsql = TextBox15.Text
                aggfunc.kolonbaslik = TextBox16.Text
                result = aggfunc_erisim.Duzenle(aggfunc)
            End If

            'GRAFİKTE KOLON SAYI ADINI GÜNCELLE
            If result.durum = "Kaydedildi" Then
                DropDownList34.Items.Clear()
                DropDownList34.Items.Add(New ListItem("Seçiniz", "0"))
                Dim aggfunclar As New List(Of CLASSAGGFUNC)
                aggfunclar = aggfunc_erisim.doldurilgili(raporpkey)
                For Each itemtablo As CLASSAGGFUNC In aggfunclar
                    DropDownList34.Items.Add(New ListItem(itemtablo.sayialias, itemtablo.sayialias))
                Next
            End If


            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labelaggfunc.Text = aggfunc_erisim.listele

        End If

    End Sub


    'GRAFİK EKLE
    Protected Sub Buttondinamikraporgrafikekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttondinamikraporgrafikekle.Click

        Dim hata As String
        Dim raporpkey As String
        Dim dinamikraporgrafik As New CLASSDINAMIKRAPORGRAFIK

        Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM
        raporpkey = Request.QueryString("pkey")

        inn.Value = "7"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'grafik başlığı
        If TextBox11.Text = "" Then
            TextBox11.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Grafik başlığını girmediniz.</li>"
            inn.Value = "7"
        End If

        'grafik tipi
        If DropDownList32.SelectedValue = "0" Then
            DropDownList32.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Grafik tipini seçmediniz.</li>"
            inn.Value = "7"
        End If

        'genislik yukseklik kontrol
        If IsNumeric(TextBox21.Text) = False Then
            TextBox21.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Grafiğin genişliği rakamsal olmalıdır.</li>"
            inn.Value = "7"
        End If
        If IsNumeric(TextBox22.Text) = False Then
            TextBox22.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Grafiğin yüksekliği rakamsal olmalıdır.</li>"
            inn.Value = "7"
        End If


        'kolon seri ad
        If DropDownList33.SelectedValue = "0" Then
            DropDownList33.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Grafik kolon seri adını seçmediniz.</li>"
            inn.Value = "7"
        End If
        'kolon Sayı
        If DropDownList34.SelectedValue = "0" Then
            DropDownList34.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Grafik kolon seri sayısını seçmediniz.</li>"
            inn.Value = "7"
        End If




        'eğer label olacaksa
        If DropDownList35.SelectedValue = "Evet" Then
            If TextBox23.Text = "" Then
                TextBox23.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Grafik arka plan rengini seçmediniz.</li>"
                inn.Value = "7"
            End If

            If IsNumeric(TextBox19.Text) = False Then
                TextBox23.Focus()
                hata = "1"
                hatamesajlari = hatamesajlari + "<li>Şeffaflık ayarı rakamsal olmaldır.</li>"
                inn.Value = "7"
            End If
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""
            Dim dinamikraporgrafikop As String
            dinamikraporgrafikop = Request.QueryString("dinamikraporgrafikop")

            If dinamikraporgrafikop <> "duzenle" Then
                dinamikraporgrafik.raporpkey = raporpkey
                dinamikraporgrafik.grafikbaslik = TextBox11.Text
                dinamikraporgrafik.grafiktip = DropDownList32.SelectedValue
                dinamikraporgrafik.genislik = TextBox21.Text
                dinamikraporgrafik.yukseklik = TextBox22.Text
                dinamikraporgrafik.kolonseriad = DropDownList33.SelectedValue
                dinamikraporgrafik.kolonsayi = DropDownList34.SelectedValue
                dinamikraporgrafik.labelgosterilsinmi = DropDownList35.SelectedValue
                dinamikraporgrafik.labelarkaplanrengi = TextBox23.Text
                dinamikraporgrafik.labelseffaflik = TextBox19.Text
                dinamikraporgrafik.legendgosterilsinmi = DropDownList37.SelectedValue
                result = dinamikraporgrafik_erisim.Ekle(dinamikraporgrafik)
            End If

            If dinamikraporgrafikop = "duzenle" Then
                Dim dinamikraporgrafikpkey As String
                dinamikraporgrafikpkey = Request.QueryString("dinamikraporgrafikpkey")
                dinamikraporgrafik = dinamikraporgrafik_erisim.bultek(dinamikraporgrafikpkey)
                dinamikraporgrafik.grafikbaslik = TextBox11.Text
                dinamikraporgrafik.grafiktip = DropDownList32.SelectedValue
                dinamikraporgrafik.genislik = TextBox21.Text
                dinamikraporgrafik.yukseklik = TextBox22.Text
                dinamikraporgrafik.kolonseriad = DropDownList33.SelectedValue
                dinamikraporgrafik.kolonsayi = DropDownList34.SelectedValue
                dinamikraporgrafik.labelgosterilsinmi = DropDownList35.SelectedValue
                dinamikraporgrafik.labelarkaplanrengi = TextBox23.Text
                dinamikraporgrafik.labelseffaflik = TextBox19.Text
                dinamikraporgrafik.legendgosterilsinmi = DropDownList37.SelectedValue
                result = dinamikraporgrafik_erisim.Duzenle(dinamikraporgrafik)
            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labelgrafik.Text = dinamikraporgrafik_erisim.listele

        End If


    End Sub

    'ZAMANLAMA EKLE -------------------------
    Protected Sub Buttondinamikraporzamanlamaekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttondinamikraporzamanlamaekle.Click

        Dim hata As String
        Dim raporpkey As String
        Dim dinamikraporzamanlama As New CLASSDINAMIKRAPORZAMANLAMA
        Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
        raporpkey = Request.QueryString("pkey")

        inn.Value = "7"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'zamanlama adı
        If TextBox10.Text = "" Then
            TextBox10.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Zamanlama adını girmediniz.</li>"
            inn.Value = "8"
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""
            Dim dinamikraporzamanlamaop As String
            dinamikraporzamanlamaop = Request.QueryString("dinamikraporzamanlamaop")

            If dinamikraporzamanlamaop <> "duzenle" Then
                dinamikraporzamanlama.raporpkey = raporpkey
                dinamikraporzamanlama.zamanlamaad = TextBox10.Text
                dinamikraporzamanlama.remindersettingpkey = DropDownList31.SelectedValue
                result = dinamikraporzamanlama_erisim.Ekle(dinamikraporzamanlama)
            End If

            If dinamikraporzamanlamaop = "duzenle" Then
                Dim dinamikraporzamanlamapkey As String
                dinamikraporzamanlamapkey = Request.QueryString("dinamikraporzamanlamapkey")
                dinamikraporzamanlama = dinamikraporzamanlama_erisim.bultek(dinamikraporzamanlamapkey)
                dinamikraporzamanlama.zamanlamaad = TextBox10.Text
                dinamikraporzamanlama.remindersettingpkey = DropDownList31.SelectedValue
                result = dinamikraporzamanlama_erisim.Duzenle(dinamikraporzamanlama)
            End If

            If result.durum = "Kaydedildi" Then
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
                DropDownList19.Items.Clear()
                'ZAMANLAMA SEÇENEKLERİNİ DOLDUR
                Dim zamanlamalar As New List(Of CLASSDINAMIKRAPORZAMANLAMA)
                zamanlamalar = dinamikraporzamanlama_erisim.dolduriligili(raporpkey)
                For Each item As CLASSDINAMIKRAPORZAMANLAMA In zamanlamalar
                    DropDownList19.Items.Add(New ListItem(item.zamanlamaad, item.pkey))
                Next
                inn.Value = "8"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labeldinamikraporzamanlama.Text = dinamikraporzamanlama_erisim.listele

        End If
    End Sub


    'KULLANICI ERİŞİM EKLE
    Protected Sub Buttonkullaniciekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttondinamikkullanicibagekle.Click

        Dim result As New CLADBOPRESULT
        inn.Value = "8"

        Dim hata As String
        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'zamanlama 
        If DropDownList19.SelectedValue = "" Then
            DropDownList19.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Zamanlama adını seçmediniz.</li>"
            inn.Value = "9"
        End If

        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If


        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        Dim dinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
        Dim dinamikraporkullanicibagop As String
        dinamikraporkullanicibagop = Request.QueryString("dinamikraporkullanicibagop")

        If hata = "0" Then

            If dinamikraporkullanicibagop <> "duzenle" Then

                dinamikkullanicibag.raporpkey = raporpkey
                dinamikkullanicibag.kullanicipkey = DropDownList17.SelectedValue
                dinamikkullanicibag.otogonder = DropDownList18.SelectedValue
                dinamikkullanicibag.zamanlamapkey = DropDownList19.SelectedValue
                dinamikkullanicibag.epostagitsinmi = DropDownList20.SelectedValue
                dinamikkullanicibag.entegredosyagitsinmi = DropDownList21.SelectedValue
                result = dinamikkullanicibag_erisim.Ekle(dinamikkullanicibag)

            End If

            If dinamikraporkullanicibagop = "duzenle" Then

                Dim dinamikraporkullanicibagpkey As String
                dinamikraporkullanicibagpkey = Request.QueryString("dinamikraporkullanicibagpkey")
                dinamikkullanicibag = dinamikkullanicibag_erisim.bultek(dinamikraporkullanicibagpkey)
                dinamikkullanicibag.raporpkey = raporpkey
                dinamikkullanicibag.kullanicipkey = DropDownList17.SelectedValue
                dinamikkullanicibag.otogonder = DropDownList18.SelectedValue
                dinamikkullanicibag.zamanlamapkey = DropDownList19.SelectedValue
                dinamikkullanicibag.epostagitsinmi = DropDownList20.SelectedValue
                dinamikkullanicibag.entegredosyagitsinmi = DropDownList21.SelectedValue
                result = dinamikkullanicibag_erisim.Duzenle(dinamikkullanicibag)

            End If

            If result.durum = "Kaydedildi" Then
                Labeldinamikkullanicibag.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
                result.hatastr + "</ol></div>"
            End If

            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labeldinamikkullanicibag.Text = dinamikkullanicibag_erisim.listele

        End If



    End Sub

    Protected Sub DropDownList10_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList10.SelectedIndexChanged

        inn.Value = "2"

        If DropDownList10.SelectedValue <> "0" Then
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            DropDownList2.Items.Clear()
            DropDownList2.Items.Add(New ListItem("Seçiniz", "0"))
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList10.SelectedItem.Text)
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList2.Items.Add(New ListItem(item.column_name, item.column_name))
            Next
        End If


    End Sub



    Protected Sub DropDownList11_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList11.SelectedIndexChanged

        inn.Value = "3"

        If DropDownList11.SelectedValue <> "0" Then
            DropDownList3.Items.Clear()
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList11.SelectedItem.Text)
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList3.Items.Add(New ListItem(item.column_name, item.column_name))
            Next
        End If

    End Sub


    Protected Sub DropDownList12_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList12.SelectedIndexChanged

        inn.Value = "4"

        If DropDownList12.SelectedValue <> "0" Then
            DropDownList7.Items.Clear()
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList12.SelectedItem.Text)
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList7.Items.Add(New ListItem(item.column_name, item.column_name))
            Next
        End If

    End Sub

    Protected Sub DropDownList14_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList14.SelectedIndexChanged

        inn.Value = "6"

        If DropDownList14.SelectedValue <> "0" Then
            DropDownList15.Items.Clear()
            Dim site As New CLASSSITE
            Dim site_erisim As New CLASSSITE_ERISIM
            site = site_erisim.bultek(1)
            Dim sqlveritabanikolondetay_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
            Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)
            kolonlar = sqlveritabanikolondetay_erisim.bultumkolonlar(site.sistemveritabaniad, DropDownList14.SelectedItem.Text)
            For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
                DropDownList15.Items.Add(New ListItem(item.column_name, item.column_name))
            Next
        End If
    End Sub


    Protected Sub Buttongosterilecealaniptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongosterilecealaniptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=2"
        inn.Value = "2"
        Response.Redirect(link)
    End Sub

    Protected Sub Buttonkosulfieldiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonkosulfieldiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=3"
        inn.Value = "3"
        Response.Redirect(link)
    End Sub

    Protected Sub Buttonsiralamafieldiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonsiralamafieldiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=4"
        inn.Value = "4"
        Response.Redirect(link)
    End Sub

    Protected Sub Buttongrupfieldiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttongrupfieldiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=5"
        inn.Value = "5"
        Response.Redirect(link)
    End Sub


    Protected Sub Buttonaggfunciptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonaggfunciptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=6"
        inn.Value = "6"
        Response.Redirect(link)
    End Sub


    Protected Sub Buttondinamikraporzamanlamaiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttondinamikraporzamanlamaiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=7"
        inn.Value = "7"
        Response.Redirect(link)
    End Sub

    Protected Sub Buttondinamikkullanicibagiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttondinamikkullanicibagiptal.Click
        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=8"
        inn.Value = "8"
        Response.Redirect(link)
    End Sub


    Protected Sub Buttondinamikraporjavascriptiptal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttondinamikraporjavascriptiptal.Click

        Dim link As String
        Dim op As String
        op = Request.QueryString("op")
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        link = "dinamikraporpopup.aspx?op=" + op + "&pkey=" + raporpkey + "&hangiiptal=10"
        inn.Value = "10"
        Response.Redirect(link)

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click

        Dim result As New CLADBOPRESULT
        Dim rapor As New CLASSRAPOR
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

        result = dinamikrapor_erisim.mantiksaltest(raporpkey)
        If result.durum = "Kaydedilmedi" Then
            durumlabel.Text = "<div id=errorMsg><h3>Rapor Düzgün Çalışmıyor</h3><ol>" + _
            result.hatastr + "</ol></div>"
        End If

        'mantıksal kontrolü geçti ise çalıştır.
        If result.durum = "Kaydedildi" Then
            rapor = dinamikrapor_erisim.raporolustur(raporpkey)
            If rapor.calisiyormu = "Evet" Then
                durumlabel.Text = "<div id=okMsg><p><h3>Rapor düzgün bir şekilde çalışıyor.</h3><br/></p></div>"
            Else
                durumlabel.Text = "<div id=errorMsg><h3>Rapor Düzgün Çalışmıyor</h3><ol>" + _
                rapor.hatatxt + "</ol></div>"
            End If
        End If

        inn.Value = "0"

    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click

        Dim sqlstr As String
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM

        sqlstr = dinamikrapor_erisim.sqlolustur(raporpkey)

        durumlabel.Text = "<div id=okMsg><p><h3>" + sqlstr + "</h3><br/></p></div>"

    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click

        inn.Value = "9"
        Dim hata As String = "0"

        If DropDownList28.SelectedValue = "" Then
            hata = "1"
        End If


        If hata = "0" Then

            Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
            Dim kullanicilar As New List(Of CLASSKULLANICI)
            Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
            Dim result As New CLADBOPRESULT
            Dim raporpkey As String
            raporpkey = Request.QueryString("pkey")
            Dim eklenenstr As String = ""

            kullanicilar = kullanici_erisim.doldur_kullanicirolpkeyegore(DropDownList27.SelectedValue)

            For Each itemkullanici As CLASSKULLANICI In kullanicilar

                Dim dinamikkullanicibag As New CLASSDINAMIKKULLANICIBAG
                dinamikkullanicibag.raporpkey = raporpkey
                dinamikkullanicibag.kullanicipkey = itemkullanici.pkey
                dinamikkullanicibag.otogonder = "Evet"
                dinamikkullanicibag.zamanlamapkey = DropDownList28.SelectedValue
                dinamikkullanicibag.epostagitsinmi = "Evet"
                dinamikkullanicibag.entegredosyagitsinmi = "Evet"
                result = dinamikkullanicibag_erisim.Ekle(dinamikkullanicibag)

                If result.durum = "Kaydedildi" Then
                    eklenenstr = eklenenstr + itemkullanici.adsoyad + "<br/>"
                End If

            Next

            Labeleklenenler.Text = eklenenstr
            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labeldinamikkullanicibag.Text = dinamikkullanicibag_erisim.listele

        End If

    End Sub

    'OTOMATİK DÜZENLEME
    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click

        Dim donecek As String
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")
        donecek = dinamikrapor_erisim.otoduzelt(raporpkey)

        durumlabel.Text = "<div id=okMsg><p><h3>" + donecek + "</h3><br/></p></div>"

        inn.Value = "3"
        HttpContext.Current.Session("raporpkey") = raporpkey
        Labelkosulfield.Text = kosulfield_erisim.listele()


    End Sub

    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button7.Click

        Dim result As New CLADBOPRESULT
        Dim raporpkey As String
        raporpkey = Request.QueryString("pkey")

        If raporpkey <> "" Then

            Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM


            Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
            Dim dinamikraporzamanlama_erisim As New CLASSDINAMIKRAPORZAMANLAMA_ERISIM
            Dim aggfunc_erisim As New CLASSAGGFUNC_ERISIM
            Dim grupfield_erisim As New CLASSGRUPFIELD_ERISIM
            Dim siralamafield_erisim As New CLASSSIRALAMAFIELD_ERISIM
            Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
            Dim gosterilecekfield_erisim As New CLASSGOSTERILECEKfield_ERISIM
            Dim kullanilacaktablo_erisim As New CLASSKULLANILACAKTABLO_ERISIM
            Dim dinamikraporgrafik_erisim As New CLASSDINAMIKRAPORGRAFIK_ERISIM

            result = dinamikkullanicibag_erisim.sililgili(raporpkey)
            result = dinamikraporzamanlama_erisim.sililgili(raporpkey)
            result = aggfunc_erisim.sililgili(raporpkey)
            result = grupfield_erisim.sililgili(raporpkey)
            result = siralamafield_erisim.sililgili(raporpkey)
            result = kosulfield_erisim.sililgili(raporpkey)
            result = gosterilecekfield_erisim.sililgili(raporpkey)
            result = kullanilacaktablo_erisim.sililgili(raporpkey)
            result = dinamikraporgrafik_erisim.sililgili(raporpkey)
            result = dinamikrapor_erisim.Sil(raporpkey)


            If result.etkilenen = 0 Then
                durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol><li>" + _
                result.hatastr + "</li></ol></div>"
            Else
                durumlabel.Text = "<div id=okMsg><p>Değişiklikler kaydedildi. <br/></p></div>"
            End If

        End If

        If Request.QueryString("pkey") = "" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3>" + _
            "<ol><li>Lütfen silmek için aşağıdan herhangi bir kayıt seçiniz.</li></ol></div>"
        End If


    End Sub


    'DİNAMİK RAPOR JAVASCRIPT EKLE 
    Protected Sub Buttondinamikraporjavascriptekle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttondinamikraporjavascriptekle.Click

        Dim hata As String
        Dim raporpkey As String
        Dim dinamikraporjavascript As New CLASSDINAMIKRAPORJAVASCRIPT
        Dim dinamikraporjavascript_erisim As New CLASSDINAMIKRAPORJAVASCRIPT_ERISIM
        raporpkey = Request.QueryString("pkey")

        inn.Value = "10"

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"

        'javascript metni
        If TextBox20.Text = "" Then
            TextBox10.Focus()
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Javascript kodunu girmediniz.</li>"
            inn.Value = "10"
        End If


        If hata = "1" Then
            durumlabel.Text = "<div id=errorMsg><h3>Eksik yada Yanlış Bilgi Girdiniz</h3><ol>" + _
            hatamesajlari + "</ol></div>"
        End If

        If hata = "0" Then

            hatamesajlari = ""
            Dim dinamikraporjavascriptop As String
            dinamikraporjavascriptop = Request.QueryString("dinamikraporjavascriptop")

            If dinamikraporjavascriptop <> "duzenle" Then
                dinamikraporjavascript.raporpkey = raporpkey
                dinamikraporjavascript.jv = TextBox20.Text
                result = dinamikraporjavascript_erisim.Ekle(dinamikraporjavascript)
            End If

            If dinamikraporjavascriptop = "duzenle" Then
                Dim dinamikraporjavascriptpkey As String
                dinamikraporjavascriptpkey = Request.QueryString("dinamikraporjavascriptpkey")
                dinamikraporjavascript = dinamikraporjavascript_erisim.bultek(dinamikraporjavascriptpkey)
                dinamikraporjavascript.jv = TextBox20.Text
                result = dinamikraporjavascript_erisim.Duzenle(dinamikraporjavascript)
            End If


            HttpContext.Current.Session("ltip") = "ilgili"
            HttpContext.Current.Session("raporpkey") = raporpkey
            Labeldinamikraporjavascript.Text = dinamikraporjavascript_erisim.listele

        End If

    End Sub

   
End Class