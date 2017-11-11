Public Partial Class dinamikraporgoster
    Inherits System.Web.UI.Page

    Dim dinamikraporlog_erisim As New CLASSDINAMIKRAPORLOG_ERISIM
    Dim dinamikrapor As New CLASSDINAMIKRAPOR
    Dim dinamikrapor_erisim As New CLASSDINAMIKRAPOR_ERISIM
    Dim rapor_erisim As New CLASSRAPOR_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim rapor1 As New CLASSRAPOR


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'login kontrol
            If IsNumeric(Session("kullanici_pkey")) = False Then
                Response.Redirect("yonetimgiris.aspx")
            Else
                kullanici_erisim.busayfayigormeyeyetkilimi("dinamikraporgoster", Session("kullanici_rolpkey"))
            End If
            'login kontrol -------------------------------------------

            Dim raporpkey As String
            raporpkey = Request.QueryString("raporpkey")

            If IsNumeric(raporpkey) = True Then

                Dim dinamikkullanicibag_erisim As New CLASSDINAMIKKULLANICIBAG_ERISIM
                Dim yetkilimi As String
                yetkilimi = dinamikkullanicibag_erisim.yetkilimi(raporpkey, Session("kullanici_pkey"))

                'YETKİLİMİ---------------------------------------
                If yetkilimi = "Hayır" Then
                    Labelraporbaslik.Text = "Yetkisiz"
                    Labelraporaciklama.Text = "Yetkisiz"
                    Buttonpdfdinamik.Visible = False
                    Buttonexceldinamik.Visible = False
                    Buttonworddinamik.Visible = False
                End If

                'YETKİLİ İSE -----------------------------------
                If yetkilimi = "Evet" Then
                    dinamikrapor = dinamikrapor_erisim.bultek(raporpkey)
                    Labelraporbaslik.Text = dinamikrapor.raporad
                    Labelraporaciklama.Text = dinamikrapor.aciklama
                    rapor1 = dinamikrapor_erisim.raporolustur(raporpkey)
                    Label1.Text = rapor1.veri
                End If

                labellog.Text = dinamikraporlog_erisim.listele(raporpkey)

            End If 'raporpkey numeric tir

        End If 'postback

    End Sub

    Protected Sub Buttonpdfdinamik_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdfdinamik.Click
        Dim raporpkey As String
        raporpkey = Request.QueryString("raporpkey")
        rapor1 = dinamikrapor_erisim.raporolustur(raporpkey)
        rapor_erisim.yazdirpdf("ekran", rapor1)
    End Sub

    Protected Sub Buttonexceldinamik_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexceldinamik.Click
        Dim raporpkey As String
        raporpkey = Request.QueryString("raporpkey")
        rapor1 = dinamikrapor_erisim.raporolustur(raporpkey)
        rapor_erisim.yazdirexcel("ekran", rapor1)
    End Sub

    Protected Sub Buttonworddinamik_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonworddinamik.Click
        Dim raporpkey As String
        raporpkey = Request.QueryString("raporpkey")
        rapor1 = dinamikrapor_erisim.raporolustur(raporpkey)
        rapor_erisim.yazdirword("ekran", rapor1)
    End Sub
End Class