<%@ page language="vb" autoeventwireup="false" codebehind="sirkettarafozelrapor.aspx.vb" inherits="sigorta.sirketraporozelrapor" %>


<%@ register src="header.ascx" tagname="header" tagprefix="uc1" %>
<%@ register src="footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ register src="headertemel.ascx" tagname="headertemel" tagprefix="uc3" %>
<uc1:header ID="header1" runat="server" />


<!-- BEGIN FORM-->
<form id="form1" runat="server" class="form-horizontal">

    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                    <h3 class="page-title">Özel Raporları<small>Size özel hazırlanmış raporlar.</small>
                    </h3>
                    <ul class="page-breadcrumb breadcrumb">
                        <li class="btn-group">
                            <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                                <span>İşlemler
                                </span>
                                <i class="fa fa-angle-down"></i>
                            </button>
                            <ul class="dropdown-menu pull-right" role="menu">
                            </ul>
                        </li>
                        <li>
                            <i class="fa fa-home"></i>
                            <a href="default.aspx">Anasayfa
                            </a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <a href="#">Raporlar
                            </a>
                            <i class="fa fa-angle-right"></i>
                        </li>
                        <li>
                            <a href="ozelrapor.aspx">Özel Raporlar
                            </a>
                        </li>

                    </ul>
                    <!-- END PAGE TITLE & BREADCRUMB-->
                </div>
            </div>
            <!-- END PAGE HEADER-->


            <div class="row">
                <div class="col-md-12">


                    <!-- BİRİNCİ RAPOR PORTLATE-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-bullhorn"></i>Poliçelerin Zeyil Kodlarına Göre Dağılımı
                            </div>

                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>

                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>

                        </div>

                        <div class="portlet-body form">

                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Şirket:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList2" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Başlangıç Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox1" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Bitiş Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox2" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions right">
                                    <asp:button id="Button1" runat="server" class="btn green" text="Raporla" />
                                </div>


                                <div id="validationresult">
                                    <asp:label id="durumlabel" runat="server"></asp:label>
                                </div>


                            </div>
                            <!-- form body -->

                        </div>
                        <!-- portlet body -->
                    </div>
                    <!-- BİRİNCİ RAPOR PORTLATE-->




                    <!-- İKİNCİ RAPOR PORTLATE-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-bullhorn"></i>Şirket Genel Prim ve Hasar Raporu
                            </div>

                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>

                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>

                        </div>

                        <div class="portlet-body form">

                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Şirket:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Para Birimi:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList3" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Ürün Kodu:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList7" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Tarife Kodu:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList8" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Poliçe Tipi:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList13" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Başlangıç Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox3" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Bitiş Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox4" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions right">
                                    <asp:button id="Button2" runat="server" class="btn green" text="Raporla" />
                                </div>


                                <div id="validationresult2">
                                    <asp:label id="durumlabel2" runat="server"></asp:label>
                                </div>


                            </div>
                            <!-- form body -->

                        </div>
                        <!-- portlet body -->
                    </div>
                    <!-- İKİNCİ RAPOR PORTLATE-->




                    <!-- ÜÇÜNCÜ RAPOR PORTLATE-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-bullhorn"></i>Hasarların Durum Kodlarına Göre Dağılımı
                            </div>

                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>

                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>

                        </div>

                        <div class="portlet-body form">

                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Şirket:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList4" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Başlangıç Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox5" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Bitiş Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox6" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions right">
                                    <asp:button id="Button3" runat="server" class="btn green" text="Raporla" />
                                </div>


                                <div id="validationresult3">
                                    <asp:label id="durumlabel3" runat="server"></asp:label>
                                </div>


                            </div>
                            <!-- form body -->

                        </div>
                        <!-- portlet body -->
                    </div>
                    <!-- ÜÇÜNCÜ RAPOR PORTLATE-->


                    <!-- DÖRDÜNCÜ RAPOR PORTLATE-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-bullhorn"></i>Baz Fiyatlar
                            </div>

                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>

                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>

                        </div>

                        <div class="portlet-body form">

                            <div class="form-body">

                                <div class="form-actions right">
                                    <asp:button id="Button4" runat="server" class="btn green" text="Baz Fiyatlarım" />
                                </div>


                            </div>
                            <!-- form body -->

                        </div>
                        <!-- portlet body -->
                    </div>
                    <!-- DÖRDÜNCÜ RAPOR PORTLATE-->



                    <!-- BEŞİNCİ RAPOR PORTLATE-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-bullhorn"></i>Sektör Genel Prim ve Hasar Raporu
                            </div>

                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>

                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>

                        </div>

                        <div class="portlet-body form">

                            <div class="form-body">

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Para Birimi:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList5" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Poliçe Tipi:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList14" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Ürün Kodu:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList9" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Tarife Kodu:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList10" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Başlangıç Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox7" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">Bitiş Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox8" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-actions right">
                                    <asp:button id="Button5" runat="server" class="btn green" text="Raporla" />
                                </div>


                                <div id="validationresult5">
                                    <asp:label id="durumlabel5" runat="server"></asp:label>
                                </div>


                            </div>
                            <!-- form body -->

                        </div>
                        <!-- portlet body -->
                    </div>
                    <!-- BEŞİNCİ RAPOR PORTLATE-->








                    <!-- YEDİNCİ RAPOR PORTLATE-->

                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-bullhorn"></i>Baz Fiyat Analizi
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload"></a><a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div class="form-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Şirket:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList21" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Poliçe Tipi:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList22" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Ürün Kodu:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList23" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Tarife Kodu:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList24" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>

                                    </div>

                                </div>


                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Başlangıç Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox11" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Bitiş Tarihi:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox12" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <div class="row">
                                    <div class="col-md-6">

                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Para Birimi:</label>
                                            <div class="col-md-8">
                                                <asp:dropdownlist id="DropDownList40" class="form-control" runat="server"></asp:dropdownlist>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label col-md-4">
                                                Kontrol Baz Fiyat:</label>
                                            <div class="col-md-8">
                                                <asp:textbox id="TextBox9" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>



                                </div>



                                <div class="row">
                                    <div class="col-md-12">
                                        <table class="table">
                                            <thead>
                                                <td>Hİ 0
                                                </td>
                                                <td>Hİ 10
                                                </td>
                                                <td>Hİ 20
                                                </td>
                                                <td>Hİ 30
                                                </td>
                                                <td>Hİ 40
                                                </td>
                                                <td>HZ 0
                                                </td>
                                                <td>HZ 15
                                                </td>
                                                <td>HZ 20
                                                </td>
                                                <td>HZ 25
                                                </td>
                                                <td>HZ 30
                                                </td>
                                                <td>HZ 35
                                                </td>
                                                <td>HZ 40
                                                </td>
                                                <td>HZ 50
                                                </td>
                                                <td>YZ 0
                                                </td>
                                                <td>YZ 15
                                                </td>
                                                <td>YZ 30
                                                </td>
                                                <td>CC 0
                                                </td>
                                                <td>CC 5
                                                </td>
                                                <td>CC 15
                                                </td>
                                                <td>CC 20
                                                </td>
                                                <td>CC 25
                                                </td>
                                                <td>CC 30
                                                </td>
                                                <td>CC 35
                                                </td>
                                                <td>CC 45
                                                </td>
                                                <td>CC 50
                                                </td>
                                                <td>CC 75
                                                </td>
                                            </thead>
                                            <tbody>
                                                <td>
                                                    <asp:textbox id="hi0oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hi10oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hi20oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hi30oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hi40oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz0oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz15oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz20oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz25oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz30oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz35oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz40oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="hz50oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="yz0oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="yz15oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="yz30oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc0oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc5oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc15oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc20oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc25oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc30oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc35oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc45oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc50oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                                <td>
                                                    <asp:textbox id="cc75oran" autocomplete="off" class="textboxcokkucuk" runat="server"></asp:textbox>
                                                </td>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>



                                <div class="form-actions right">
                                    <asp:button id="Button8" runat="server" class="btn green" text="Raporla" />
                                </div>
                                <div id="validationresult8">
                                    <asp:label id="durumlabel8" runat="server"></asp:label>
                                </div>
                            </div>

                        </div>
                    </div>

                    <!-- YEDİNCİ RAPOR PORTLATE -->






                </div>
                <!-- col md12 -->
            </div>
            <!-- row -->

        </div>
        <!-- page-content-wrapper -->
    </div>
    <!-- page content -->




</form>
<uc2:footer ID="footer" runat="server" />

<uc3:headertemel ID="headertemel" runat="server" />
<script type="text/javascript" src="js/sirkettarafozelrapor.js?rnd=243432"></script>






