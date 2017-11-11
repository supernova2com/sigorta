Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports OfficeOpenXml
Imports OfficeOpenXml.Table
Imports System.Net


Partial Public Class test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Button6.Enabled = False

    End Sub

   

    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click

        If (FileUpload1.HasFile AndAlso IO.Path.GetExtension(FileUpload1.FileName) = ".xlsx") Then
            Using excel = New ExcelPackage(FileUpload1.PostedFile.InputStream)

                Dim data_table As New DataTable

                Dim ws = excel.Workbook.Worksheets.First()
                Dim hasHeader = True ' change it if required '
                ' create DataColumns '

                data_table = WorksheetToDataTable(ws, False)

            End Using
        Else

        End If

    End Sub


    Private Function WorksheetToDataTable(ByVal ws As ExcelWorksheet, ByVal hasHeader As Boolean) As DataTable

        Dim dt As DataTable = New DataTable(ws.Name)
        Dim totalCols As Integer = ws.Dimension.[End].Column
        Dim totalRows As Integer = ws.Dimension.[End].Row
        Dim startRow As Integer = If(hasHeader, 2, 1)
        Dim wsRow As ExcelRange
        Dim dr As DataRow

        For Each firstRowCell In ws.Cells(1, 1, 1, totalCols)
            dt.Columns.Add(If(hasHeader, firstRowCell.Text, String.Format("Column {0}", firstRowCell.Start.Column)))
        Next
        For rowNum As Integer = startRow To totalRows
            wsRow = ws.Cells(rowNum, 1, rowNum, totalCols)
            dr = dt.NewRow()
            For Each cell In wsRow
                dr(cell.Start.Column - 1) = cell.Text
            Next
            dt.Rows.Add(dr)
        Next

        Return dt

    End Function

    Protected Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click


        Dim donecek, enbas, enson, ic As String
        donecek = ""
        enbas = "<root><Info "
        enson = " /></root>"
        ic = ""

        Dim sqlserver_erisim As New CLASSSQLVERITABANIKOLONDETAY_ERISIM
        Dim kolonlar As New List(Of CLASSVERITABANIKOLONDETAY)

        kolonlar = sqlserver_erisim.bultumkolonlar("sigortay", "FirePolicyInfo")
        For Each item As CLASSVERITABANIKOLONDETAY In kolonlar
            ic = ic + item.column_name + "=" + Chr(34) + "t1" + Chr(34) + " "
        Next

        donecek = enbas + ic + enson
        TextBox1.Text = "<code><pre>" + donecek + "</pre></code>"

    End Sub




End Class