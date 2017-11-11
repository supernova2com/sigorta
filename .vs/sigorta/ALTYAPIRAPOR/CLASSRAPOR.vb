Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CLASSRAPOR

    Private baslik_v As String
    Private veri_v As String
    Private kacadet_v As Integer
    Private tablo_v As DataTable
    Private pdftablo_v As PdfPTable
    Private kolsayi_v As Integer
    Private ds_v As DataSet
    Private calisiyormu_v As String
    Private hatatxt_v As String


    Public Sub New()

    End Sub

    Public Sub New(ByVal baslik As String, ByVal veri As String, _
    ByVal kacadet As Integer, ByVal tablo As DataTable, _
    ByVal pdftablo As PdfPTable, ByVal kolsayi As Integer, _
    ByVal ds As DataSet, ByVal calisiyormu As String, _
    ByVal hatatxt As String)

        Me.baslik = baslik
        Me.veri = veri
        Me.kacadet = kacadet
        Me.tablo = tablo
        Me.pdftablo = pdftablo
        Me.kolsayi = kolsayi
        Me.ds = ds
        Me.calisiyormu = calisiyormu
        Me.hatatxt = hatatxt

    End Sub


    Public Property baslik() As String
        Get
            Return baslik_v
        End Get
        Set(ByVal value As String)
            baslik_v = value
        End Set
    End Property

    Public Property veri() As String
        Get
            Return veri_v
        End Get
        Set(ByVal value As String)
            veri_v = value
        End Set
    End Property


    Public Property kacadet() As Integer
        Get
            Return kacadet_v
        End Get
        Set(ByVal value As Integer)
            kacadet_v = value
        End Set
    End Property

    Public Property tablo() As DataTable
        Get
            Return tablo_v
        End Get
        Set(ByVal value As DataTable)
            tablo_v = value
        End Set
    End Property

    Public Property pdftablo() As PdfPTable
        Get
            Return pdftablo_v
        End Get
        Set(ByVal value As PdfPTable)
            pdftablo_v = value
        End Set
    End Property

    Public Property kolsayi() As Integer
        Get
            Return kolsayi_v
        End Get
        Set(ByVal value As Integer)
            kolsayi_v = value
        End Set
    End Property


    Public Property ds() As DataSet
        Get
            Return ds_v
        End Get
        Set(ByVal value As DataSet)
            ds_v = value
        End Set
    End Property


    Public Property calisiyormu() As String
        Get
            Return calisiyormu_v
        End Get
        Set(ByVal value As String)
            calisiyormu_v = value
        End Set
    End Property


    Public Property hatatxt() As String
        Get
            Return hatatxt_v
        End Get
        Set(ByVal value As String)
            hatatxt_v = value
        End Set
    End Property


End Class
