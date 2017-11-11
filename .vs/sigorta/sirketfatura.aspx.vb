Partial Public Class sirketfatura
    Inherits System.Web.UI.Page

    Dim javascript As New CLASSJAVASCRIPT
    Dim result As New CLADBOPRESULT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim sinirkapitakvim As New CLASSSINIRKAPITAKVIM
    Dim sinirkapitakvim_erisim As New CLASSSINIRKAPITAKVIM_ERISIM

    Dim sinirkapi As New CLASSSINIRKAPI
    Dim sinirkapi_erisim As New CLASSSINIRKAPI_ERISIM


    'yetkiler icin 
    Dim tabload As String = "hesap"
    Dim yetki_erisim As New CLASSYETKI_ERISIM
    Dim yetki As New CLASSYETKI
    Dim tmodul As New CLASSTMODUL
    Dim tmodul_erisim As New CLASSTMODUL_ERISIM

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            Dim hesap_erisim As New CLASSHESAP_ERISIM
            Dim sirket As New CLASSSIRKET
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            sirket = sirket_erisim.bultek(Session("kullanici_sirketpkey"))
            HttpContext.Current.Session("firmcode") = sirket.sirketkod
            Labelfatura.Text = hesap_erisim.listelesirketicinfatura
            Labelodeme.Text = hesap_erisim.listelesirketicinodeme

        End If

        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)
        If yetki.readyetki = "Hayır" Then
            Labelfatura.Visible = False
        Else
            Labelfatura.Visible = True
        End If
        If yetki.insertyetki = "Hayır" And yetki.updateyetki = "Hayır" And _
        yetki.deleteyetki = "Hayır" And yetki.readyetki = "Hayır" Then
            Response.Redirect("yetkisiz.aspx")
        End If
        'yetki kontrol----------------------------------

    End Sub

End Class