Public Class CLASSCOREXML_ERISIM


    Public Function UnescapeXMLValue(ByVal xmlString As String) As String
        Return xmlString.Replace("&apos;", "'").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&")

    End Function

    Public Function EscapeXMLValue(ByVal xmlString As String) As String
        Return xmlString.Replace("'", "&apos;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("&", "&amp;")
    End Function

End Class
