<%@ page language="vb" autoeventwireup="false" codebehind="servislogdetay.aspx.vb" inherits="sigorta.servislogdetay" %>

<%@ register src="headerfancy.ascx" tagname="header" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
    <title>Servis Logu Detayları</title>


    <!-- syntax highlighter -->
    <script type="text/javascript" src="syntaxhighlighter/scripts/shCore.js"></script>
    <script type="text/javascript" src="syntaxhighlighter/scripts/shBrushJScript.js"></script>
    <script type="text/javascript" src="syntaxhighlighter/scripts/shBrushXml.js"></script>
    <link type="text/css" rel="stylesheet" href="syntaxhighlighter/styles/shCoreDefault.css" />
    <script type="text/javascript">SyntaxHighlighter.all();</script>
    <script type="text/javascript">
        function lineWrap() {
            var wrap = function () {
                var elems = document.getElementsByClassName('syntaxhighlighter');
                for (var j = 0; j < elems.length; ++j) {
                    var sh = elems[j];
                    var gLines = sh.getElementsByClassName('gutter')[0].getElementsByClassName('line');
                    var cLines = sh.getElementsByClassName('code')[0].getElementsByClassName('line');
                    var stand = 15;
                    for (var i = 0; i < gLines.length; ++i) {
                        var h = $(cLines[i]).height();
                        if (h != stand) {
                            console.log(i);
                            gLines[i].setAttribute('style', 'height: ' + h + 'px !important;');
                        }
                    }
                }
            };
            var whenReady = function () {
                if ($('.syntaxhighlighter').length === 0) {
                    setTimeout(whenReady, 800);
                } else {
                    wrap();
                }
            };
            whenReady();
        };
        lineWrap();
        $(window).resize(function () { lineWrap() });
    </script>

    <!-- bu stil kodu bölmek içindir -->
    <style type="text/css">
        body .syntaxhighlighter .line {
            white-space: pre-wrap !important; /* make code wrap */
        }
    </style>


</head>
<uc1:header ID="header2" runat="server" />

<script type="text/javascript" src="js/policedetaysirket.js?rel=6456456747"></script>

<body>



    <form id="form1" runat="server">





        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Detaylı Servis Logu İncelemesi
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">


                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Temel Bilgiler</th>
                            <th>Veri</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td>Servisin Çağrılma Tarihi ve Saati:</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">Çağrılan Servisin Adı:</td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">Çağıran Şirket:</td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>
        </div>




        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Servis Sonucu
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">


                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Servis Sonucu</th>
                            <th>Veri</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td>Sonuç Kodu:</td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">Hata Kodu:</td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">Hata Mesajı:</td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>

                    </tbody>
                </table>


                <table class="table table-striped table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Kayıt Sayıları</th>
                            <th>Veri</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Kaydedilen Kayıt Sayısı:</td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">Güncellenen Kayıt Sayısı:</td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>

            </div>
        </div>






        <div class="portlet box purple">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Tramer Sorgu Logu (GetDamageInformation)
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:Label ID="Label13" runat="server"></asp:Label>
            </div>
        </div>


        <div class="portlet box purple">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Poliçe Hesaplama Logu (LoadPolicyInformation)
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">

                <table class="pure-table pure-table-bordered">
                    <thead>
                        <tr>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Style="font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>


            </div>
        </div>







        <div class="portlet box yellow">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Gönderilen Veriler
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">

                <table class="pure-table">
                    <thead>
                        <tr>
                            <th>Gönderilen XML Bilgileri</th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr>
                            <td>
                                <pre class="brush: xml;"> <asp:Literal ID="Literal1" runat="server"></asp:Literal> </pre>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" Style="width: 100%; height: 450px;" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <!--
                        <tr>
                          
                            <td>
                                <pre><code>
                                    <asp:Label ID="Label12" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>   
                                </code></pre>
                            </td>
                        </tr>
                            -->

                    </tbody>
                </table>



            </div>
        </div>




    </form>



</body>

</html>




