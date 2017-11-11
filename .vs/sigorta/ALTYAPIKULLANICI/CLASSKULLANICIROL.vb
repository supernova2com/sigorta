Public Class CLASSKULLANICIROL

    'raporyetki: özel rapor yetkidir.

    Private pkey_v As Integer
    Private rolad_v As String
    Private tumsirketyetki_v As String
    Private yonsayfa_v As String
    Private panoyetki_v As String
    Private islemyetki_v As String
    Private aramayetki_v As String
    Private tanimyetki_v As String
    Private fiyatyetki_v As String
    Private belgeyonetimyetki_v As String
    Private resimyetki_v As String
    Private kullaniciyonetimyetki_v As String
    Private raporyetki_v As String
    Private logyetki_v As String
    Private mesajyetki_v As String
    Private ayaryetki_v As String
    Private sirkettarafaramayetki_v As String
    Private servisayaryetki_v As String
    Private sirkettarafkullaniciyaratyetki_v As String
    Private profilyetki_v As String
    Private toplumesajyetki_v As String
    Private dosyayetki_v As String
    Private sirkettarafraporerisim_v As String
    Private rolsirkettarafindasecilebilsinmi_v As String
    Private sirkettanimyetki_v As String
    Private acentetanimyetki_v As String
    Private personeltanimyetki_v As String
    Private aractarifetanimyetki_v As String
    Private ulketanimyetki_v As String
    Private anamenupkey_v As Integer
    Private yardimyetki_v As String
    Private mensup_v As String
    Private sirkettarafkullanicilisteyetki_v As String
    Private zeylcodetanimyetki_v As String
    Private urunkodtanimyetki_v As String
    Private currencycodetanimyetki_v As String
    Private sirkettarafacenteyaratyetki_v As String
    Private hasardurumkodtanimyetki_v As String
    Private sadecesirketicimesajlasma_v As String
    Private sadecesirketicidosyagonderimi_v As String
    Private policetiptanimyetki_v As String
    Private faturalandirmayetki_v As String
    Private acentetiptanimyetki_v As String
    Private bazfiyatgirissureyetki_v As String
    Private sirketbazfiyatgirisyetki_v As String
    Private sadecemerkezgozuk_v As String
    Private kimlikturtanimyetki_v As String
    Private dinamikraporyetki_v As String
    Private adminpolicearayetki_v As String
    Private adminhasararayetki_v As String
    Private kuryetki_v As String
    Private tpbelgeyetki_v As String
    Private bekbelgeyetki_v As String
    Private birlikpersoneltanimyetki_v As String
    Private tanimlanmisdinamikraporyetki_v As String
    Private iptallistesiyetki_v As String
    Private parakambiyoaramayetki_v As String
  


    Public Sub New()
    End Sub

    Public Sub New(ByVal pkey As Integer, ByVal rolad As String, ByVal tumsirketyetki As String, _
    ByVal yonsayfa As String, ByVal panoyetki As String, ByVal islemyetki As String, _
    ByVal aramayetki As String, ByVal tanimyetki As String, ByVal fiyatyetki As String, _
    ByVal belgeyonetimyetki As String, ByVal resimyetki As String, ByVal kullaniciyonetimyetki As String, _
    ByVal raporyetki As String, ByVal logyetki As String, ByVal mesajyetki As String, _
    ByVal ayaryetki As String, ByVal sirkettarafaramayetki As String, ByVal servisayaryetki As String, _
    ByVal sirkettarafkullaniciyaratyetki As String, ByVal profilyetki As String, ByVal toplumesajyetki As String, _
    ByVal dosyayetki As String, ByVal sirkettarafraporerisim As String, ByVal rolsirkettarafindasecilebilsinmi As String, _
    ByVal sirkettanimyetki As String, ByVal acentetanimyetki As String, ByVal personeltanimyetki As String, _
    ByVal aractarifetanimyetki As String, ByVal ulketanimyetki As String, ByVal anamenupkey As Integer, _
    ByVal yardimyetki As String, ByVal mensup As String, ByVal sirkettarafkullanicilisteyetki As String, _
    ByVal zeylcodetanimyetki As String, ByVal urunkodtanimyetki As String, ByVal currencycodetanimyetki As String, _
    ByVal sirkettarafacenteyaratyetki As String, ByVal hasardurumkodtanimyetki As String, ByVal sadecesirketicimesajlasma As String, _
    ByVal sadecesirketicidosyagonderimi As String, ByVal policetiptanimyetki As String, ByVal faturalandirmayetki As String, _
    ByVal acentetiptanimyetki As String, ByVal bazfiyatgirissureyetki As String, ByVal sirketbazfiyatgirisyetki As String, _
    ByVal sadecemerkezgozuk As String, ByVal kimlikturtanimyetki As String, ByVal dinamikraporyetki As String, _
    ByVal adminpolicearayetki As String, ByVal adminhasararayetki As String, ByVal kuryetki As String, _
    ByVal tpbelgeyetki As String, ByVal bekbelgeyetki As String, ByVal birlikpersoneltanimyetki As String, _
    ByVal tanimlanmisdinamikraporyetki As String, ByVal iptallistesiyetki As String, _
    ByVal parakambiyoaramayetki As String)


        Me.pkey = pkey
        Me.rolad = rolad
        Me.tumsirketyetki = tumsirketyetki
        Me.yonsayfa = yonsayfa
        Me.panoyetki = panoyetki
        Me.islemyetki = islemyetki
        Me.aramayetki = aramayetki
        Me.tanimyetki = tanimyetki
        Me.fiyatyetki = fiyatyetki
        Me.belgeyonetimyetki = belgeyonetimyetki
        Me.resimyetki = resimyetki
        Me.kullaniciyonetimyetki = kullaniciyonetimyetki
        Me.raporyetki = raporyetki
        Me.logyetki = logyetki
        Me.mesajyetki = mesajyetki
        Me.ayaryetki = ayaryetki
        Me.sirkettarafaramayetki = sirkettarafaramayetki
        Me.servisayaryetki = servisayaryetki
        Me.sirkettarafkullaniciyaratyetki = sirkettarafkullaniciyaratyetki
        Me.profilyetki = profilyetki
        Me.toplumesajyetki = toplumesajyetki
        Me.dosyayetki = dosyayetki
        Me.sirkettarafraporerisim = sirkettarafraporerisim
        Me.rolsirkettarafindasecilebilsinmi = rolsirkettarafindasecilebilsinmi
        Me.sirkettanimyetki = sirkettanimyetki
        Me.acentetanimyetki = acentetanimyetki
        Me.personeltanimyetki = personeltanimyetki
        Me.aractarifetanimyetki = aractarifetanimyetki
        Me.ulketanimyetki = ulketanimyetki
        Me.anamenupkey = anamenupkey
        Me.yardimyetki = yardimyetki
        Me.mensup = mensup
        Me.sirkettarafkullanicilisteyetki = sirkettarafkullanicilisteyetki
        Me.zeylcodetanimyetki = zeylcodetanimyetki
        Me.urunkodtanimyetki = urunkodtanimyetki
        Me.currencycodetanimyetki = currencycodetanimyetki
        Me.sirkettarafacenteyaratyetki = sirkettarafacenteyaratyetki
        Me.hasardurumkodtanimyetki = hasardurumkodtanimyetki
        Me.sadecesirketicimesajlasma = sadecesirketicimesajlasma
        Me.sadecesirketicidosyagonderimi = sadecesirketicidosyagonderimi
        Me.policetiptanimyetki = policetiptanimyetki
        Me.faturalandirmayetki = faturalandirmayetki
        Me.acentetiptanimyetki = acentetiptanimyetki
        Me.bazfiyatgirissureyetki = bazfiyatgirissureyetki
        Me.sirketbazfiyatgirisyetki = sirketbazfiyatgirisyetki
        Me.sadecemerkezgozuk = sadecemerkezgozuk
        Me.kimlikturtanimyetki = kimlikturtanimyetki
        Me.dinamikraporyetki = dinamikraporyetki
        Me.adminpolicearayetki = adminpolicearayetki
        Me.adminhasararayetki = adminhasararayetki
        Me.kuryetki = kuryetki
        Me.tpbelgeyetki = tpbelgeyetki
        Me.bekbelgeyetki = bekbelgeyetki
        Me.birlikpersoneltanimyetki = birlikpersoneltanimyetki
        Me.tanimlanmisdinamikraporyetki = tanimlanmisdinamikraporyetki
        Me.iptallistesiyetki = iptallistesiyetki
        Me.parakambiyoaramayetki = parakambiyoaramayetki


    End Sub

    Public Property pkey() As Integer
        Get
            Return pkey_v
        End Get
        Set(ByVal value As Integer)
            pkey_v = value
        End Set
    End Property


    Public Property rolad() As String
        Get
            Return rolad_v
        End Get
        Set(ByVal value As String)
            rolad_v = value
        End Set
    End Property


    Public Property tumsirketyetki() As String
        Get
            Return tumsirketyetki_v
        End Get
        Set(ByVal value As String)
            tumsirketyetki_v = value
        End Set
    End Property


    Public Property yonsayfa() As String
        Get
            Return yonsayfa_v
        End Get
        Set(ByVal value As String)
            yonsayfa_v = value
        End Set
    End Property


    Public Property panoyetki() As String
        Get
            Return panoyetki_v
        End Get
        Set(ByVal value As String)
            panoyetki_v = value
        End Set
    End Property


    Public Property islemyetki() As String
        Get
            Return islemyetki_v
        End Get
        Set(ByVal value As String)
            islemyetki_v = value
        End Set
    End Property


    Public Property aramayetki() As String
        Get
            Return aramayetki_v
        End Get
        Set(ByVal value As String)
            aramayetki_v = value
        End Set
    End Property


    Public Property tanimyetki() As String
        Get
            Return tanimyetki_v
        End Get
        Set(ByVal value As String)
            tanimyetki_v = value
        End Set
    End Property


    Public Property fiyatyetki() As String
        Get
            Return fiyatyetki_v
        End Get
        Set(ByVal value As String)
            fiyatyetki_v = value
        End Set
    End Property


    Public Property belgeyonetimyetki() As String
        Get
            Return belgeyonetimyetki_v
        End Get
        Set(ByVal value As String)
            belgeyonetimyetki_v = value
        End Set
    End Property


    Public Property resimyetki() As String
        Get
            Return resimyetki_v
        End Get
        Set(ByVal value As String)
            resimyetki_v = value
        End Set
    End Property


    Public Property kullaniciyonetimyetki() As String
        Get
            Return kullaniciyonetimyetki_v
        End Get
        Set(ByVal value As String)
            kullaniciyonetimyetki_v = value
        End Set
    End Property


    Public Property raporyetki() As String
        Get
            Return raporyetki_v
        End Get
        Set(ByVal value As String)
            raporyetki_v = value
        End Set
    End Property


    Public Property logyetki() As String
        Get
            Return logyetki_v
        End Get
        Set(ByVal value As String)
            logyetki_v = value
        End Set
    End Property


    Public Property mesajyetki() As String
        Get
            Return mesajyetki_v
        End Get
        Set(ByVal value As String)
            mesajyetki_v = value
        End Set
    End Property


    Public Property ayaryetki() As String
        Get
            Return ayaryetki_v
        End Get
        Set(ByVal value As String)
            ayaryetki_v = value
        End Set
    End Property


    Public Property sirkettarafaramayetki() As String
        Get
            Return sirkettarafaramayetki_v
        End Get
        Set(ByVal value As String)
            sirkettarafaramayetki_v = value
        End Set
    End Property


    Public Property servisayaryetki() As String
        Get
            Return servisayaryetki_v
        End Get
        Set(ByVal value As String)
            servisayaryetki_v = value
        End Set
    End Property


    Public Property sirkettarafkullaniciyaratyetki() As String
        Get
            Return sirkettarafkullaniciyaratyetki_v
        End Get
        Set(ByVal value As String)
            sirkettarafkullaniciyaratyetki_v = value
        End Set
    End Property


    Public Property profilyetki() As String
        Get
            Return profilyetki_v
        End Get
        Set(ByVal value As String)
            profilyetki_v = value
        End Set
    End Property


    Public Property toplumesajyetki() As String
        Get
            Return toplumesajyetki_v
        End Get
        Set(ByVal value As String)
            toplumesajyetki_v = value
        End Set
    End Property


    Public Property dosyayetki() As String
        Get
            Return dosyayetki_v
        End Get
        Set(ByVal value As String)
            dosyayetki_v = value
        End Set
    End Property


    Public Property sirkettarafraporerisim() As String
        Get
            Return sirkettarafraporerisim_v
        End Get
        Set(ByVal value As String)
            sirkettarafraporerisim_v = value
        End Set
    End Property


    Public Property rolsirkettarafindasecilebilsinmi() As String
        Get
            Return rolsirkettarafindasecilebilsinmi_v
        End Get
        Set(ByVal value As String)
            rolsirkettarafindasecilebilsinmi_v = value
        End Set
    End Property


    Public Property sirkettanimyetki() As String
        Get
            Return sirkettanimyetki_v
        End Get
        Set(ByVal value As String)
            sirkettanimyetki_v = value
        End Set
    End Property


    Public Property acentetanimyetki() As String
        Get
            Return acentetanimyetki_v
        End Get
        Set(ByVal value As String)
            acentetanimyetki_v = value
        End Set
    End Property


    Public Property personeltanimyetki() As String
        Get
            Return personeltanimyetki_v
        End Get
        Set(ByVal value As String)
            personeltanimyetki_v = value
        End Set
    End Property


    Public Property aractarifetanimyetki() As String
        Get
            Return aractarifetanimyetki_v
        End Get
        Set(ByVal value As String)
            aractarifetanimyetki_v = value
        End Set
    End Property


    Public Property ulketanimyetki() As String
        Get
            Return ulketanimyetki_v
        End Get
        Set(ByVal value As String)
            ulketanimyetki_v = value
        End Set
    End Property


    Public Property anamenupkey() As Integer
        Get
            Return anamenupkey_v
        End Get
        Set(ByVal value As Integer)
            anamenupkey_v = value
        End Set
    End Property


    Public Property yardimyetki() As String
        Get
            Return yardimyetki_v
        End Get
        Set(ByVal value As String)
            yardimyetki_v = value
        End Set
    End Property


    Public Property mensup() As String
        Get
            Return mensup_v
        End Get
        Set(ByVal value As String)
            mensup_v = value
        End Set
    End Property


    Public Property sirkettarafkullanicilisteyetki() As String
        Get
            Return sirkettarafkullanicilisteyetki_v
        End Get
        Set(ByVal value As String)
            sirkettarafkullanicilisteyetki_v = value
        End Set
    End Property


    Public Property zeylcodetanimyetki() As String
        Get
            Return zeylcodetanimyetki_v
        End Get
        Set(ByVal value As String)
            zeylcodetanimyetki_v = value
        End Set
    End Property


    Public Property urunkodtanimyetki() As String
        Get
            Return urunkodtanimyetki_v
        End Get
        Set(ByVal value As String)
            urunkodtanimyetki_v = value
        End Set
    End Property


    Public Property currencycodetanimyetki() As String
        Get
            Return currencycodetanimyetki_v
        End Get
        Set(ByVal value As String)
            currencycodetanimyetki_v = value
        End Set
    End Property


    Public Property sirkettarafacenteyaratyetki() As String
        Get
            Return sirkettarafacenteyaratyetki_v
        End Get
        Set(ByVal value As String)
            sirkettarafacenteyaratyetki_v = value
        End Set
    End Property


    Public Property hasardurumkodtanimyetki() As String
        Get
            Return hasardurumkodtanimyetki_v
        End Get
        Set(ByVal value As String)
            hasardurumkodtanimyetki_v = value
        End Set
    End Property


    Public Property sadecesirketicimesajlasma() As String
        Get
            Return sadecesirketicimesajlasma_v
        End Get
        Set(ByVal value As String)
            sadecesirketicimesajlasma_v = value
        End Set
    End Property


    Public Property sadecesirketicidosyagonderimi() As String
        Get
            Return sadecesirketicidosyagonderimi_v
        End Get
        Set(ByVal value As String)
            sadecesirketicidosyagonderimi_v = value
        End Set
    End Property


    Public Property policetiptanimyetki() As String
        Get
            Return policetiptanimyetki_v
        End Get
        Set(ByVal value As String)
            policetiptanimyetki_v = value
        End Set
    End Property


    Public Property faturalandirmayetki() As String
        Get
            Return faturalandirmayetki_v
        End Get
        Set(ByVal value As String)
            faturalandirmayetki_v = value
        End Set
    End Property


    Public Property acentetiptanimyetki() As String
        Get
            Return acentetiptanimyetki_v
        End Get
        Set(ByVal value As String)
            acentetiptanimyetki_v = value
        End Set
    End Property


    Public Property bazfiyatgirissureyetki() As String
        Get
            Return bazfiyatgirissureyetki_v
        End Get
        Set(ByVal value As String)
            bazfiyatgirissureyetki_v = value
        End Set
    End Property


    Public Property sirketbazfiyatgirisyetki() As String
        Get
            Return sirketbazfiyatgirisyetki_v
        End Get
        Set(ByVal value As String)
            sirketbazfiyatgirisyetki_v = value
        End Set
    End Property


    Public Property sadecemerkezgozuk() As String
        Get
            Return sadecemerkezgozuk_v
        End Get
        Set(ByVal value As String)
            sadecemerkezgozuk_v = value
        End Set
    End Property


    Public Property kimlikturtanimyetki() As String
        Get
            Return kimlikturtanimyetki_v
        End Get
        Set(ByVal value As String)
            kimlikturtanimyetki_v = value
        End Set
    End Property


    Public Property dinamikraporyetki() As String
        Get
            Return dinamikraporyetki_v
        End Get
        Set(ByVal value As String)
            dinamikraporyetki_v = value
        End Set
    End Property


    Public Property adminpolicearayetki() As String
        Get
            Return adminpolicearayetki_v
        End Get
        Set(ByVal value As String)
            adminpolicearayetki_v = value
        End Set
    End Property


    Public Property adminhasararayetki() As String
        Get
            Return adminhasararayetki_v
        End Get
        Set(ByVal value As String)
            adminhasararayetki_v = value
        End Set
    End Property


    Public Property kuryetki() As String
        Get
            Return kuryetki_v
        End Get
        Set(ByVal value As String)
            kuryetki_v = value
        End Set
    End Property


    Public Property tpbelgeyetki() As String
        Get
            Return tpbelgeyetki_v
        End Get
        Set(ByVal value As String)
            tpbelgeyetki_v = value
        End Set
    End Property


    Public Property bekbelgeyetki() As String
        Get
            Return bekbelgeyetki_v
        End Get
        Set(ByVal value As String)
            bekbelgeyetki_v = value
        End Set
    End Property

    Public Property birlikpersoneltanimyetki() As String
        Get
            Return birlikpersoneltanimyetki_v
        End Get
        Set(ByVal value As String)
            birlikpersoneltanimyetki_v = value
        End Set
    End Property


    Public Property tanimlanmisdinamikraporyetki() As String
        Get
            Return tanimlanmisdinamikraporyetki_v
        End Get
        Set(ByVal value As String)
            tanimlanmisdinamikraporyetki_v = value
        End Set
    End Property


    Public Property iptallistesiyetki() As String
        Get
            Return iptallistesiyetki_v
        End Get
        Set(ByVal value As String)
            iptallistesiyetki_v = value
        End Set
    End Property


    Public Property parakambiyoaramayetki() As String
        Get
            Return parakambiyoaramayetki_v
        End Get
        Set(ByVal value As String)
            parakambiyoaramayetki_v = value
        End Set
    End Property



End Class
