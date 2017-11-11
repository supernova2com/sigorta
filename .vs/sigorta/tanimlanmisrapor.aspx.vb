Public Partial Class tanimlanmisrapor
    Inherits System.Web.UI.Page

    Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
    Dim rapor_erisim As New CLASSRAPOR_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim rapor1 As New CLASSRAPOR


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                'Session("kullanici_pkey") = "1"
                'Session("kullanici_rolpkey") = "2"
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("tanimlanmisrapor", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------


            Dim dinamikraporlar As New List(Of CLASSDINAMIKRAPOR)
            DropDownList1.Items.Add(New ListItem("Seçiniz", "0"))
            dinamikraporlar = dinamikrapor_erisim.dolduryetkili(Session("kullanici_pkey"))
            For Each item As CLASSDINAMIKRAPOR In dinamikraporlar
                DropDownList1.Items.Add(New ListItem(item.raporad, item.pkey))
            Next

        End If

    End Sub



    Protected Sub raporolusturbutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles raporolusturbutton.Click

        Dim javascript As New CLASSJAVASCRIPT
        Dim degerlerdogrumu As String = "Evet"

        Dim validateresult As New CLADBOPRESULT
        validateresult.durum = "Kaydedildi"
        validateresult.etkilenen = 1
        validateresult.hatastr = ""

        Dim raporpkey As String
        Dim kosulfield_erisim As New CLASSKOSULFIELD_ERISIM
        Dim kosullar As New List(Of CLASSKOSULFIELD)
        Dim deger As String
        raporpkey = HttpContext.Current.Session("raporpkey")
        kosullar = kosulfield_erisim.doldur_ilgili(raporpkey)
        Dim link As String
        'DİNAMİK ARABİRİME GİRİLEN VERİLERİ ÇEK
        If kosullar.Count > 0 Then
            For Each kosulitem As CLASSKOSULFIELD In kosullar
                If kosulitem.runtime = "Evet" Then
                    deger = Request.Form("ss" + CStr(kosulitem.pkey))
                    HttpContext.Current.Session("ss" + CStr(kosulitem.pkey)) = deger
                    validateresult = dinamikrapor_erisim.validateinput(kosulitem.fieldtype, deger)
                    If validateresult.durum = "Kaydedilmedi" Then
                        degerlerdogrumu = "Hayır"
                        durumvalidatelabel.Text = javascript.alertresult(validateresult)
                    End If
                End If
            Next
        End If 'kosullar.count>0

        'eğer para kambiyo poliçe raporu ise
        If raporpkey = 36 Then
            If degerlerdogrumu = "Evet" Then
                Dim baslangictarih, bitistarih As Date
                baslangictarih = Request.Form("ss35")
                bitistarih = Request.Form("ss36")
                If bitistarih.Subtract(baslangictarih).Days > 31 Then
                    degerlerdogrumu = "Hayır"
                End If
            End If
        End If
        If raporpkey = 37 Then
            If degerlerdogrumu = "Evet" Then
                Dim baslangictarih, bitistarih As Date
                baslangictarih = Request.Form("ss38")
                bitistarih = Request.Form("ss39")
                If bitistarih.Subtract(baslangictarih).Days > 31 Then
                    degerlerdogrumu = "Hayır"
                End If
            End If
        End If

        'eğer girilen değerler doğru ise
        If degerlerdogrumu = "Evet" Then
            durumvalidatelabel.Text = javascript.alertresult(validateresult)
            link = "dinamikraporgoster.aspx?raporpkey=" + raporpkey
            Response.Redirect(link)
        End If

    End Sub


End Class