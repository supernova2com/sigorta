Public Partial Class servislogdetay
    Inherits System.Web.UI.Page



    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            'Response.Redirect("yonetimgiris.aspx")
        Else
            'kullanici_erisim.busayfayigormeyeyetkilimi("servislogdetay", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            Dim pkey As String
            pkey = Request.QueryString("pkey")


            Dim resultcode_aciklama As String
            Dim sirket As New CLASSSIRKET
            Dim sirket_erisim As New CLASSSIRKET_ERISIM

            Dim logservis As New CLASSLOGSERVIS
            Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM
            logservis = logservis_erisim.bultek(pkey)


            'BİLGİLERİ GÖSTERMEYE BAŞLA
            Label1.Text = logservis.tarih
            Label2.Text = logservis.servisad
            sirket = sirket_erisim.bultek(logservis.sirketpkey)
            Label3.Text = sirket.sirketad

            If logservis.resultcode = 1 Then
                resultcode_aciklama = " (Başarılı) "
            Else
                resultcode_aciklama = " (Başarısız) "
            End If


            Label4.Text = CStr(logservis.resultcode) + resultcode_aciklama
            Label5.Text = CStr(logservis.errorinfocode)
            Label6.Text = logservis.errorinfomessage

            '--------------------------------------------------
            Label7.Text = CStr(logservis.insertedcnt)
            Label8.Text = CStr(logservis.updatedcnt)


            Literal1.Text = logservis.gonderilenxml
            TextBox1.Text = logservis.gonderilenxml


            If logservis.servisad = "GetDamageInformation" Then
                Label13.Text = Replace(logservis.getdamagelog, "--", "<br/>")
            End If

            If logservis.servisad = "LoadPolicyInformation" Then
                Label14.Text = Replace(logservis.hesaplog, "--", "<br/>")
            End If


            If logservis.errorinfocode = 998 And logservis.servisad = "LoadPolicyInformation" Then

                Dim hatadetay As String
                Dim hatakodu As String
                hatakodu = Mid(logservis.errorinfomessage, 73, 4)
                If IsNumeric(hatakodu) = True Then
                    hatadetay = Replace(Mid(logservis.gonderilenxml, hatakodu), "<", "")
                    Label12.Text = hatadetay
                End If

            End If '998 ise

        End If


    End Sub

End Class