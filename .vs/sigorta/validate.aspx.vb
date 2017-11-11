Imports xzing
Imports ZXing
Imports System.IO
Imports System.Drawing


Partial Public Class validate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Label1.Text = ""
        Label2.Text = ""
        portlate.Visible = False

        Dim sbmcode As String
        sbmcode = Request.QueryString("SBMCode")
        If Len(sbmcode) < 5 Then
            Response.Redirect("default.aspx")
        End If

        Dim ne As String
        ne = Mid(sbmcode, 2, 1)

        If ne = "P" Then

            Dim renk As String
            Dim PolicyInfo_Erisim As New PolicyInfo_Erisim
            Dim PolicyInfo As New PolicyInfo
            PolicyInfo = PolicyInfo_Erisim.bultek_qrkodgore(sbmcode)

            If PolicyInfo.ProductCode = "" Then
                Label1.Text = "Bu poliçe SBM'de kayıtlı değildir!"
                Label2.Text = "Poliçe bilgilerinizi kontrol ediniz."
            End If

            If PolicyInfo.ProductCode <> "" Then

                If PolicyInfo.ProductCode = 15 Then
                    portlategenelsartlar.Visible = True
                Else
                    portlategenelsartlar.Visible = False
                End If


                Label1.Text = "Bu poliçe SBM'de kayıtlıdır."
                portlate.Visible = True
                Try

                    Dim site As New CLASSSITE
                    Dim site_erisim As New CLASSSITE_ERISIM
                    site = site_erisim.bultek(1)


                    Dim contentqrcode As String = site.path + "validate.aspx?" +
                    "sbmcode=" + CStr(PolicyInfo.SBMCode)

                    Dim writer As New BarcodeWriter
                    writer.Format = BarcodeFormat.QR_CODE
                    writer.Options.Height = 100
                    writer.Options.Width = 100

                    Dim br As New Bitmap(100, 100)

                    br = writer.Write(contentqrcode)

                    Dim ms As New MemoryStream()
                    br.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

                    Dim base64Data = Convert.ToBase64String(ms.ToArray())
                    barkodimg1.Width = 60
                    barkodimg1.Height = 60
                    barkodimg1.Src = "data:image/gif;base64," + base64Data

                    barkodimg2.Width = 80
                    barkodimg2.Height = 80
                    barkodimg2.Src = "data:image/gif;base64," + base64Data

                    barkodimg3.Width = 100
                    barkodimg3.Height = 100
                    barkodimg3.Src = "data:image/gif;base64," + base64Data

                    barkodimg4.Width = 120
                    barkodimg4.Height = 120
                    barkodimg4.Src = "data:image/gif;base64," + base64Data

                Catch EX As Exception
                End Try

                renk = PolicyInfo_Erisim.renkbul(PolicyInfo.FirmCode, PolicyInfo.ProductCode,
                PolicyInfo.AgencyCode, PolicyInfo.PolicyNumber, PolicyInfo.TecditNumber,
                PolicyInfo.ZeylCode, PolicyInfo.ZeylNo, PolicyInfo.ProductType)
                If renk = "green" Then
                    Label2.Text = "Bu poliçe geçerlidir."
                Else
                    Label2.Text = "Bu poliçe geçerli değildir."
                    portlategenelsartlar.Visible = False
                End If

                Label3.Text = "Araç Plakası: " + PolicyInfo.PlateNumber + "<br/>" +
                "Poliçe Sahibinin Adı Soyadı: " + PolicyInfo.PolicyOwnerName + " " +
                PolicyInfo.PolicyOwnerSurname



            End If
        End If 'Poliçe ise



        If ne = "H" Then
            Dim DamageInfo_Erisim As New DamageInfo_Erisim
            Dim DamageInfo As New DamageInfo
            DamageInfo = DamageInfo_Erisim.bultek_qrkodgore(sbmcode)

            If DamageInfo.ProductCode = "" Then
                Label1.Text = "Bu hasar SBM'de kayıtlı değildir!"
                Label2.Text = "Hasar bilgilerinizi kontrol ediniz."
            End If

            If DamageInfo.ProductCode <> "" Then
                Label1.Text = "Bu hasar SBM'de kayıtlıdır."
            End If
        End If 'Hasar ise




    End Sub

End Class