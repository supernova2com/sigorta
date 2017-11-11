Public Partial Class faturayazdir
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            Dim faturano As String
            faturano = Request.QueryString("faturano")

            Dim hesap As New CLASSHESAP
            Dim hesap_erisim As New CLASSHESAP_ERISIM
            Dim hesaplar As New List(Of CLASSHESAP)
            hesap = hesap_erisim.bulfaturanovetipegore(faturano, "Gelir")
            hesaplar.Add(New CLASSHESAP(hesap.pkey, hesap.firmcode, hesap.faturano, hesap.tip, hesap.tarih, _
            hesap.tutar, hesap.aciklama, hesap.ay, hesap.yil, hesap.eder, hesap.tur, hesap.oran))

            Dim result As New CLADBOPRESULT
            hesap_erisim.pdfolustur(hesaplar, "ekran")

        End If
    End Sub

End Class