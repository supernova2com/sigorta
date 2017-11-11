﻿Partial Public Class sinirkapibazfiyat
    Inherits System.Web.UI.Page


    Dim sinirkapibazfiyat_erisim As New CLASSSINIRKAPIBAZFIYAT_ERISIM
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM

    'yetkiler icin 
    Dim tabload As String = "sinirkapibazfiyat"
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

            HttpContext.Current.Session("ltip") = "TÜMÜ"
            Label1.Text = sinirkapibazfiyat_erisim.listele()

        End If


        'yetki kontrol ------------------------------
        Dim opy As String
        opy = Request.QueryString("op")
        tmodul = tmodul_erisim.bultabloadagore(tabload)
        yetki = yetki_erisim.bul_ilgili(Session("kullanici_rolpkey"), tmodul.pkey)

        If yetki.insertyetki = "Hayır" Then
            iframeyenikayit.Visible = False
        Else
            iframeyenikayit.Visible = True
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




End Class