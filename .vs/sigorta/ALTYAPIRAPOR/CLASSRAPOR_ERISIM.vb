Imports System.Web.HttpContext
Imports System.Web.HttpApplicationState
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports HttpContext.Current
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports OfficeOpenXml
Imports OfficeOpenXml.Style



Public Class CLASSRAPOR_ERISIM

    Function rapordosyaadiolustur(ByVal tip As String) As String

        Dim datetimestr As String
        Dim donecek As String
        Dim datetime As DateTime
        datetime = Now.Date
        datetimestr = CStr(datetime)

        If tip = "Excel" Then
            donecek = "rapor" + tip + datetimestr + "-" + CStr(Now.Hour) + "-" + CStr(Now.Minute) + "-" + CStr(Now.Second) + ".xls"
        End If

        If tip = "Word" Then
            donecek = "rapor" + tip + datetimestr + "-" + CStr(Now.Hour) + "-" + CStr(Now.Minute) + "-" + CStr(Now.Second) + ".doc"
        End If

        If tip = "Pdf" Then
            donecek = "rapor" + tip + datetimestr + "-" + CStr(Now.Hour) + "-" + CStr(Now.Minute) + "-" + CStr(Now.Second) + ".pdf"
        End If

        Return donecek

    End Function


    Function rapordosyaadiolustur_randomlu(ByVal tip As String) As String

        Dim datetimestr As String
        Dim donecek As String
        Dim datetime As DateTime
        datetime = Now.Date
        datetimestr = CStr(datetime)

        If tip = "Excel" Then
            donecek = "rapor" + tip + datetimestr + "_" + GetRandomString(5) + ".xls"
        End If

        If tip = "Word" Then
            donecek = "rapor" + tip + datetimestr + "_" + GetRandomString(5) + ".doc"
        End If

        If tip = "Pdf" Then
            donecek = "rapor" + tip + datetimestr + "_" + GetRandomString(5) + ".pdf"
        End If

        Return donecek

    End Function


    Public Function GetRandomString(ByVal slen As Integer) As String

        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To slen
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next

        Return sb.ToString

    End Function

    Public Function yazdirpdf(ByVal yontem As String, ByVal rapor As CLASSRAPOR) As String

        If Not rapor.pdftablo Is Nothing Then

            Dim yaratilanfullpath As String
            Dim yaratilacak_pdfdosyaad As String
            yaratilacak_pdfdosyaad = rapordosyaadiolustur("Pdf")
            yaratilanfullpath = HttpContext.Current.Request.PhysicalApplicationPath + yaratilacak_pdfdosyaad

            Dim doc As Document = New Document
            PdfWriter.GetInstance(doc, New FileStream(yaratilanfullpath, FileMode.Create))
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
            doc.Open()

            'RAPORUN BAŞLIĞINI EKLE -------------
            Dim BF = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, "iso-8859-9", False)
            Dim fontsize As Single = 8.0
            Dim f = New iTextSharp.text.Font(BF, fontsize, iTextSharp.text.Font.NORMAL)
            Dim p1, p2 As New Paragraph
            p1.SpacingAfter = 14
            p1.Add(New Chunk(rapor.baslik, New iTextSharp.text.Font(BF, fontsize, iTextSharp.text.Font.BOLD)))
            doc.Add(p1)

            Dim pdftable As New PdfPTable(2)
            pdftable = rapor.pdftablo
            doc.Add(pdftable)

            If yontem = "ekran" Then
                doc.Close()
                doc.Dispose()
                HttpContext.Current.Response.Redirect("~/" + yaratilacak_pdfdosyaad)
            End If

            If yontem = "email" Then
                doc.Close()
                doc.Dispose()
                Return yaratilanfullpath
            End If

            If yontem = "servis" Then
                doc.Close()
                Return yaratilacak_pdfdosyaad
            End If

        End If

    End Function

    Public Function yazdirexcel(ByVal yontem As String, ByVal rapor As CLASSRAPOR) As String

        Dim yaratilanfullpath As String
        Dim yaratilacak_exceldosyaad As String

        yaratilacak_exceldosyaad = rapordosyaadiolustur("Excel")
        yaratilanfullpath = HttpContext.Current.Request.PhysicalApplicationPath + _
        yaratilacak_exceldosyaad

        'EXCEL İÇİN ------------------ 
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        Dim gridview1 As New WebControls.GridView
        gridview1.Visible = True
        gridview1.AutoGenerateColumns = True
        Dim table As System.Data.DataTable = rapor.tablo
        gridview1.DataSource = table
        gridview1.DataBind()
        hw.WriteLine(rapor.baslik)
        gridview1.RenderControl(hw)
        hw.Close()
        sw.Close()

        Dim kyer As String
        kyer = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + yaratilacak_exceldosyaad
        'File.WriteAllText(kyer, sw.ToString(), System.Text.Encoding.UTF8)
        'Return yaratilacak_exceldosyaad

        If yontem = "servis" Then
            Dim excel As New ExcelPackage
            Dim workSheet = excel.Workbook.Worksheets.Add("excelsheet")

            workSheet.Cells("A1:M1").Merge = True
            workSheet.Cells("A1:M1").Value = rapor.baslik

            workSheet.Cells("A2").LoadFromDataTable(table, True)
            Dim modelCells = workSheet.Cells("A2")
            Dim modelRows = table.Rows.Count() + 1
            Dim modelRange As String = "A2:AZ" + modelRows.ToString()
            Dim modelTable = workSheet.Cells(modelRange)
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin
            modelTable.AutoFitColumns()
            File.WriteAllBytes(kyer, excel.GetAsByteArray)
            Return yaratilacak_exceldosyaad
        End If

        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.Buffer = True
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + yaratilacak_exceldosyaad)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"

        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8
        HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble())

        HttpContext.Current.Response.Output.Write(sw.ToString())
        HttpContext.Current.Response.Flush()

        HttpContext.Current.ApplicationInstance.CompleteRequest()
        HttpContext.Current.Response.End()

        HttpContext.Current.Response.Redirect("~/" + yaratilacak_exceldosyaad)

    End Function

    Public Function yazdirword(ByVal yontem As String, ByVal rapor As CLASSRAPOR) As String

        Dim yaratilanfullpath As String
        Dim yaratilacak_worddosyaad As String
        yaratilacak_worddosyaad = rapordosyaadiolustur("Word")
        yaratilanfullpath = HttpContext.Current.Request.PhysicalApplicationPath + yaratilacak_worddosyaad

        'WORD İÇİN -------------------------------------------
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        Dim gridview1 As New GridView()
        Dim table As System.Data.DataTable = rapor.tablo
        gridview1.GridLines = GridLines.Both
        gridview1.Visible = True
        gridview1.AutoGenerateColumns = True
        gridview1.DataSource = table
        gridview1.DataBind()
        hw.WriteLine(rapor.baslik)
        gridview1.RenderControl(hw)
        hw.Close()
        sw.Close()

        If yontem = "servis" Then
            Dim kyer As String
            kyer = HttpContext.Current.Request.PhysicalApplicationPath + "otorapor" + "\" + yaratilacak_worddosyaad
            File.WriteAllText(kyer, sw.ToString(), System.Text.Encoding.UTF8)
            Return yaratilacak_worddosyaad
        End If

        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.Buffer = True
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + yaratilacak_worddosyaad)
        HttpContext.Current.Response.ContentType = "application/vnd.ms-word"
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8
        HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble())
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)

        HttpContext.Current.Response.Output.Write(sw.ToString())
        HttpContext.Current.Response.Flush()

        HttpContext.Current.ApplicationInstance.CompleteRequest()
        HttpContext.Current.Response.End()

        HttpContext.Current.Response.Redirect("~/" + yaratilacak_worddosyaad)

    End Function

End Class
