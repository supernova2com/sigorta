Public Partial Class yedek
    Inherits System.Web.UI.Page


    Dim result As New CLADBOPRESULT
    Dim javascript As New CLASSJAVASCRIPT


    Dim kullanici_erisim As New CLASSKULLANICI_ERISIM
    Dim baglantikes_erisim As New CLASSBAGLANTIKES_ERISIM
    Dim sys_erisim As New CLASSSYS_ERISIM


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'login kontrol
        If IsNumeric(Session("kullanici_pkey")) = False Then
            Response.Redirect("yonetimgiris.aspx")
        Else
            kullanici_erisim.busayfayigormeyeyetkilimi("ayar", Session("kullanici_rolpkey"))
        End If
        'login kontrol -------------------------------------------


        If Not Page.IsPostBack Then

          
            Dim PolicyInfo_erisim As New PolicyInfo_Erisim
            Dim Damageinfo_erisim As New DamageInfo_Erisim
            Dim yedekrakam_erisim As New CLASSYEDEKRAKAM_ERISIM



            Label1.Text = "Toplam Poliçe: " + yedekrakam_erisim.toplampolicesayisi_aws().ToString("N0")
            Label2.Text = "Toplam Hasar: " + yedekrakam_erisim.toplamhasarsayisi_aws().ToString("N0")


            Label3.Text = "Toplam Poliçe: " + yedekrakam_erisim.toplampolicesayisi().ToString("N0")
            Label4.Text = "Toplam Hasar: " + yedekrakam_erisim.toplamhasarsayisi().ToString("N0")





        End If 'postback

    End Sub



End Class