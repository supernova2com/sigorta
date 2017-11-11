<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ozelrapor.aspx.vb" Inherits="sigorta.ozelrapor" %>

<%@ Register Src="header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="headertemel.ascx" TagName="headertemel" TagPrefix="uc3" %>
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
                <h3 class="page-title">
                    Özel Raporları<small>Size özel hazırlanmış raporlar.</small>
                </h3>
                <ul class="page-breadcrumb breadcrumb">
                    <li class="btn-group">
                        <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                            data-delay="1000" data-close-others="true">
                            <span>İşlemler </span><i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                        </ul>
                    </li>
                    <li><i class="fa fa-home"></i><a href="default.aspx">Anasayfa </a><i class="fa fa-angle-right">
                    </i></li>
                    <li><a href="#">Raporlar </a><i class="fa fa-angle-right"></i></li>
                    <li><a href="ozelrapor.aspx">Özel Raporlar </a></li>
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
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
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
                                            <asp:dropdownlist id="DropDownList2" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:textbox id="TextBox1" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Bitiş Tarihi:</label>
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
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
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
                                            <asp:dropdownlist id="DropDownList1" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Para Birimi:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList3" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:dropdownlist id="DropDownList5" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Tarife Kodu:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList6" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Poliçe Tipi:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList13" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Tarih Tipi:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList16" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:textbox id="TextBox3" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Bitiş Tarihi:</label>
                                        <div class="col-md-8">
                                            <asp:textbox id="TextBox4" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Hasar Türü:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList38" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions right">
                                <asp:button id="Button2" runat="server" class="btn green" text="Raporla" />
                                <asp:button id="Button9" runat="server" class="btn green" text="Motor Gücüne Göre Raporla" />
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
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
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
                                            <asp:dropdownlist id="DropDownList4" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:textbox id="TextBox5" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Bitiş Tarihi:</label>
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
                            <i class="fa fa-bullhorn"></i>Sektör Genel Prim ve Hasar Raporu
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Para Birimi:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList11" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Poliçe Tipi:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList14" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:dropdownlist id="DropDownList9" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Tarife Kodu:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList10" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Hangi Poliçeler:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList15" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Tarih Tipi:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList17" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:textbox id="TextBox7" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Bitiş Tarihi:</label>
                                        <div class="col-md-8">
                                            <asp:textbox id="TextBox8" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                                <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Hasar Türü:</label>
                                        <div class="col-md-8">
                                           <asp:dropdownlist id="DropDownList39" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                </div>
                                
                            <div class="form-actions right">
                                <asp:button id="Button5" runat="server" class="btn green" text="Raporla" />
                                  <asp:button id="Button11" runat="server" class="btn yellow" text="Raporla TL" />
                            </div>
                            <div id="validationresult5">
                                <asp:label id="durumlabel5" runat="server"></asp:label>
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
                            <i class="fa fa-bullhorn"></i>Mükerrer Poliçe Raporu
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
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
                                            <asp:dropdownlist id="DropDownList12" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions right">
                                <asp:button id="Button6" runat="server" class="btn green" text="Raporla" />
                            </div>
                            <div id="validationresult6">
                                <asp:label id="durumlabel6" runat="server"></asp:label>
                            </div>
                        </div>
                        <!-- form body -->
                    </div>
                    <!-- portlet body -->
                </div>
                <!-- BEŞİNCİ RAPOR PORTLATE-->
                <!-- ALTINCI RAPOR PORTLATE-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-bullhorn"></i>Tarife Koduna Göre Zam Oranları
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
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
                                            <asp:dropdownlist id="DropDownList18" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Poliçe Tipi:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList19" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:dropdownlist id="DropDownList20" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Başlangıç Tarihi:</label>
                                        <div class="col-md-8">
                                            <asp:textbox id="TextBox9" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Bitiş Tarihi:</label>
                                        <div class="col-md-8">
                                            <asp:textbox id="TextBox10" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions right">
                                <asp:button id="Button7" runat="server" class="btn green" text="Raporla" />
                            </div>
                            <div id="validationresult7">
                                <asp:label id="durumlabel7" runat="server"></asp:label>
                            </div>
                        </div>
                        <!-- form body -->
                    </div>
                    <!-- portlet body -->
                </div>
                <!-- ALTINCI RAPOR PORTLATE-->
                
                
                <!-- YEDİNCİ RAPOR PORTLATE-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-bullhorn"></i>Baz Fiyat Analizi
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
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
                                            <asp:textbox id="TextBox13" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <table class="table">
                                        <thead>
                                            <td>
                                                Hİ 0
                                            </td>
                                            <td>
                                                Hİ 10
                                            </td>
                                            <td>
                                                Hİ 20
                                            </td>
                                            <td>
                                                Hİ 30
                                            </td>
                                            <td>
                                                Hİ 40
                                            </td>
                                            <td>
                                                HZ 0
                                            </td>
                                            <td>
                                                HZ 15
                                            </td>
                                            <td>
                                                HZ 20
                                            </td>
                                            <td>
                                                HZ 25
                                            </td>
                                            <td>
                                                HZ 30
                                            </td>
                                            <td>
                                                HZ 35
                                            </td>
                                            <td>
                                                HZ 40
                                            </td>
                                            <td>
                                                HZ 50
                                            </td>
                                            <td>
                                                YZ 0
                                            </td>
                                            <td>
                                                YZ 15
                                            </td>
                                            <td>
                                                YZ 30
                                            </td>
                                            <td>
                                                CC 0
                                            </td>
                                            <td>
                                                CC 5
                                            </td>
                                            <td>
                                                CC 15
                                            </td>
                                            <td>
                                                CC 20
                                            </td>
                                            <td>
                                                CC 25
                                            </td>
                                            <td>
                                                CC 30
                                            </td>
                                            <td>
                                                CC 35
                                            </td>
                                            <td>
                                                CC 45
                                            </td>
                                            <td>
                                                CC 50
                                            </td>
                                            <td>
                                                CC 75
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
                        <!-- form body -->
                    </div>
                    <!-- portlet body -->
                </div>
                <!-- YEDİNCİ RAPOR PORTLATE-->
                <!-- SEKİZİNCİ RAPOR PORTLATE-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-bullhorn"></i>Sınır Kapısına Göre Poliçe Sayısı Raporu
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
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
                                            <asp:dropdownlist id="DropDownList25" class="form-control" runat="server"></asp:dropdownlist>
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
                                            <asp:textbox id="TextBox14" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            Bitiş Tarihi:</label>
                                        <div class="col-md-8">
                                            <asp:textbox id="TextBox15" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            1. Başlangıç Saati</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList26" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            1. Başlangıç Dakikası:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList27" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            1. Bitiş Saati:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList28" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            1. Bitiş Dakikası:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList29" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            2. Başlangıç Saati</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList30" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            2. Başlangıç Dakikası:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList31" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            2. Bitiş Saati:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList32" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            2. Bitiş Dakikası:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList33" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            3. Başlangıç Saati</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList34" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            3. Başlangıç Dakikası:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList35" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            3. Bitiş Saati:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList36" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label col-md-4">
                                            3. Bitiş Dakikası:</label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="DropDownList37" class="form-control" runat="server"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions right">
                                <asp:button id="Button10" runat="server" class="btn green" text="Raporla" />
                            </div>
                            <div id="validationresult9">
                                <asp:label id="durumlabel9" runat="server"></asp:label>
                            </div>
                        </div>
                        <!-- form body -->
                    </div>
                    <!-- portlet body -->
                </div>
                <!-- SEKİZİNCİ RAPOR PORTLATE-->
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

<script type="text/javascript" src="js/ozelrapor.js?rel=3fghfgh346"></script>

