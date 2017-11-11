Imports System.Globalization.CultureInfo
Imports System.Globalization

Partial Public Class logservis
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT
    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim kullanici As New CLASSKULLANICI
    Dim rapor As New CLASSRAPOR
    Dim rapor_erisim As New CLASSRAPOR_ERISIM
    Dim logservis_erisim As New CLASSLOGSERVIS_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("logservis", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------

        If Not Page.IsPostBack Then

            'ŞİRKETLERİ DOLDUR---------------------------------------
            DropDownList1.Items.Add(New ListItem("Tümü", "0"))
            Dim sirket_erisim As New CLASSSIRKET_ERISIM
            Dim sirketler As New List(Of CLASSSIRKET)
            sirketler = sirket_erisim.doldur()
            For Each item As CLASSSIRKET In sirketler
                DropDownList1.Items.Add(New ListItem(item.sirketad, CStr(item.pkey)))
            Next


            'SERVİS İSİMLERİNİ DOLDUR-----------------------------------------
            DropDownList4.Items.Add(New ListItem("Tümü", "0"))
            DropDownList4.Items.Add(New ListItem("GetDamageInformation", "GetDamageInformation"))
            DropDownList4.Items.Add(New ListItem("IsAlive", "IsAlive"))
            DropDownList4.Items.Add(New ListItem("IsDBConnAlive", "IsDBConnAlive"))
            DropDownList4.Items.Add(New ListItem("LoadDamageInformation", "LoadDamageInformation"))
            DropDownList4.Items.Add(New ListItem("LoadPolicyInformation", "LoadPolicyInformation"))
            DropDownList4.Items.Add(New ListItem("getVersion", "getVersion"))
            DropDownList4.Items.Add(New ListItem("GetInfoInsuredPeople", "GetInfoInsuredPeople"))
            DropDownList4.Items.Add(New ListItem("GetCarAddressInfo", "GetCarAddressInfo"))
            DropDownList4.Items.Add(New ListItem("IsPolicySaved", "IsPolicySaved"))
            DropDownList4.Items.Add(New ListItem("IsDamageSaved", "IsDamageSaved"))
            DropDownList4.Items.Add(New ListItem("GetAttendantBorderFirms", "GetAttendantBorderFirms"))
            DropDownList4.Items.Add(New ListItem("TotalPolicyNumber", "TotalPolicyNumber"))
            DropDownList4.Items.Add(New ListItem("TotalPolicyNumberDate", "TotalPolicyNumberDate"))
            DropDownList4.Items.Add(New ListItem("TodayPolicyNumber", "TodayPolicyNumber"))
            DropDownList4.Items.Add(New ListItem("PolicySearch", "PolicySearch"))
            DropDownList4.Items.Add(New ListItem("CheckOnBorder", "CheckOnBorder"))
            DropDownList4.Items.Add(New ListItem("LoadFirePolicy", "LoadFirePolicy"))
            DropDownList4.Items.Add(New ListItem("LoadFireDamage", "LoadFireDamage"))


            'SONUÇLARI DOLDUR---------------------------------------
            DropDownList5.Items.Add(New ListItem("Tümü", "Tümü"))
            DropDownList5.Items.Add(New ListItem("Başarılı", "1"))
            DropDownList5.Items.Add(New ListItem("Başarısız", "0"))

            TextBox1.Text = DateTime.Now.ToShortDateString
            TextBox2.Text = DateTime.Now.ToShortDateString

            Dim eklenecek As String
            For i = 0 To 23
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownList10.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownList10.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next
            For i = 0 To 59
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownList11.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownList11.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next



            For i = 0 To 23
                If i < 10 Then
                    eklenecek = "0" + CStr(i)
                    DropDownList12.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownList12.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next
            For i = 0 To 60
                If i < 9 Then
                    eklenecek = "0" + CStr(i)
                    DropDownList13.Items.Add(New ListItem(eklenecek, eklenecek))
                Else
                    DropDownList13.Items.Add(New ListItem(CStr(i), CStr(i)))
                End If
            Next


            If Len(DateTime.Now.Hour.ToString) = 1 Then
                DropDownList10.SelectedValue = "0" + DateTime.Now.Hour.ToString
            Else
                DropDownList10.SelectedValue = DateTime.Now.Hour.ToString
            End If

            DropDownList11.SelectedItem.Text = "00"

            DropDownList12.SelectedValue = "23"
            DropDownList13.SelectedItem.Text = "59"

            If Len(DateTime.Now.Hour.ToString) = 1 Then
                'DropDownList10.SelectedValue = "0" + DateTime.Now.Hour.ToString
                'DropDownList10.SelectedItem.Text = "0" + DateTime.Now.Hour.ToString
            Else
                'DropDownList10.SelectedValue = DateTime.Now.Hour.ToString
                'DropDownList10.SelectedItem.Text = DateTime.Now.Hour.ToString
            End If

            If Len(DateTime.Now.Minute.ToString) = 1 Then
                'DropDownList11.SelectedValue = "0" + DateTime.Now.Minute.ToString
                'DropDownList11.SelectedItem.Text = "0" + DateTime.Now.Minute.ToString
            Else
                'DropDownList11.SelectedValue = DateTime.Now.Minute.ToString
                'DropDownList11.SelectedItem.Text = DateTime.Now.Minute.ToString
            End If

            If Label1.Text = "" Then
                Buttonexcel.Visible = False
                Buttonpdf.Visible = False
                Buttonword.Visible = False
            End If
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim dfi As DateTimeFormatInfo = New DateTimeFormatInfo()
        Dim ci As CultureInfo = New CultureInfo("de-DE")
        ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ci
        Dim baslangic, bitis As Date

        Dim hata As String

        durumlabel.Text = ""
        Dim hatamesajlari As String

        hata = "0"


        'baslangictarih---------------------------
        Try
            baslangic = TextBox1.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Başlangıç tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try

        'bitistarih---------------------------
        Try
            bitis = TextBox2.Text
        Catch
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Bitiş tarihini doğru girmediniz.</li>"
            TextBox1.Focus()
        End Try


        Dim tdbaslangicf As New DateTime(baslangic.Year, baslangic.Month, baslangic.Day, DropDownList10.SelectedValue, DropDownList11.SelectedValue, "01")
        Dim tdbitisf As New DateTime(bitis.Year, bitis.Month, bitis.Day, DropDownList12.SelectedValue, DropDownList13.SelectedValue, "59")

        If DateTime.Compare(tdbaslangicf, tdbitisf) <> -1 Then
            hata = "1"
            hatamesajlari = hatamesajlari + "<li>Araç Kiralama Başlangıç Tarihi bitiş tarihinden daha büyük olamaz. </li>"
            TextBox2.Focus()
        End If


        If hata = "1" Then
            durumlabel.Text = javascript.alert(hatamesajlari, "danger", 10, "warning")
        End If

        If hata = "0" Then

            HttpContext.Current.Session("baslangic") = tdbaslangicf
            HttpContext.Current.Session("bitis") = tdbitisf
            HttpContext.Current.Session("sirket") = DropDownList1.SelectedValue
            HttpContext.Current.Session("servisad") = DropDownList4.SelectedValue
            HttpContext.Current.Session("resultcode") = DropDownList5.SelectedValue
            HttpContext.Current.Session("gonderilenxml") = TextBox3.Text
            HttpContext.Current.Session("errorinfocode") = TextBox4.Text

            rapor = logservis_erisim.listele()
            Label1.Text = rapor.veri

            Buttonpdf.Visible = True
            Buttonexcel.Visible = True
            Buttonword.Visible = True

        End If

    End Sub

    Protected Sub Buttonexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonexcel.Click
        rapor = logservis_erisim.listele()
        rapor_erisim.yazdirexcel("ekran", rapor)
    End Sub

    Protected Sub Buttonword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonword.Click
        rapor = logservis_erisim.listele()
        rapor_erisim.yazdirword("ekran", rapor)
    End Sub

    Protected Sub Buttonpdf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Buttonpdf.Click
        rapor = logservis_erisim.listele()
        rapor_erisim.yazdirpdf("ekran", rapor)
    End Sub

End Class