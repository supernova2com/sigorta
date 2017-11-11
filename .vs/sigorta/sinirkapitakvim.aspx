<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sinirkapitakvim.aspx.vb"
    Inherits="sigorta.sinirkapitakvim" %>

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
                    Sınır Kapıları İş Çizelgesi<small> Sınır Kapıları iş çizelgesini giriniz.</small>
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
                    <li><a href="#">Sınır Kapıları </a><i class="fa fa-angle-right"></i></li>
                    <li><a href="sinirkapitakvim.aspx">Sınır Kapıları Takvimi </a></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <div class="row">
            <div class="col-md-12">
                <!-- ARAMA PORTLATE-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-search"></i>Arama
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Tarih:</label>
                            <div class="col-md-4">
                                <asp:textbox id="TextBox3" class="form-control" autocomplete="off" runat="server"></asp:textbox>
                            </div>
                            <div class="col-md-4">
                                <asp:button id="Button3" runat="server" class="btn green" text="Ara" />
                                <asp:button id="Button4" runat="server" class="btn green" text="Tümünü Göster" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Gerçek Şirket:</label>
                            <div class="col-md-4">
                                <asp:dropdownlist id="DropDownList6" class="form-control" runat="server"></asp:dropdownlist>
                            </div>
                            <div class="col-md-4">
                                <asp:button id="Button5" runat="server" class="btn green" text="Ara" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Görevli Şirket:</label>
                            <div class="col-md-4">
                                <asp:dropdownlist id="DropDownList7" class="form-control" runat="server"></asp:dropdownlist>
                            </div>
                            <div class="col-md-4">
                                <asp:button id="Button6" runat="server" class="btn green" text="Ara" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- VERİ GİRİŞ PORTLATE-->
                <div class="portlet box green">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-plus"></i>Sınır Kapıları Takvimi
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-4">
                                <asp:literal id="Literalinput" runat="server"></asp:literal>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Gerçek Şirket 1:</label>
                                    <div class="col-md-4">
                                        <asp:dropdownlist id="DropDownList2" class="form-control" runat="server">
                                            </asp:dropdownlist>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Görevli Şirket 1:</label>
                                    <div class="col-md-4">
                                        <asp:dropdownlist id="DropDownList3" class="form-control" runat="server">
                                            </asp:dropdownlist>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:literal id="Literalinput2" runat="server"></asp:literal>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Gerçek Şirket 2:</label>
                                    <div class="col-md-4">
                                        <asp:dropdownlist id="DropDownList4" class="form-control" runat="server">
                                            </asp:dropdownlist>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Görevli Şirket 2:</label>
                                    <div class="col-md-4">
                                        <asp:dropdownlist id="DropDownList5" class="form-control" runat="server">
                                            </asp:dropdownlist>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:literal id="Literalinput3" runat="server"></asp:literal>
                                  <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Gerçek Şirket 3:</label>
                                    <div class="col-md-4">
                                        <asp:dropdownlist id="DropDownList8" class="form-control" runat="server">
                                            </asp:dropdownlist>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-3 control-label">
                                        Görevli Şirket 3:</label>
                                    <div class="col-md-4">
                                        <asp:dropdownlist id="DropDownList9" class="form-control" runat="server">
                                            </asp:dropdownlist>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label id="sinirkapilabel" runat="server" class="col-md-3 control-label">
                                Sınır Kapısı:</label>
                            <div class="col-md-4">
                                <asp:dropdownlist id="DropDownList1" class="form-control" runat="server">
                                            </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Başlangıç Tarihi:</label>
                            <div class="col-md-9">
                                <asp:textbox id="TextBox1" autocompletetype="Disabled" runat="server" maxlength="10"
                                    class="textboxorta" />
                                <asp:dropdownlist id="DropDownListbaslangicsaat" class="textboxkucuk" runat="server">
                                            </asp:dropdownlist>
                                <asp:dropdownlist id="DropDownListbaslangicdakika" class="textboxkucuk" runat="server">
                                            </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">
                                Bitiş Tarihi:</label>
                            <div class="col-md-9">
                                <asp:textbox id="TextBox2" autocompletetype="Disabled" runat="server" maxlength="10"
                                    class="textboxorta" />
                                <asp:dropdownlist id="DropDownListbitissaat" class="textboxkucuk" runat="server">
                                            </asp:dropdownlist>
                                <asp:dropdownlist id="DropDownListbitisdakika" class="textboxkucuk" runat="server">
                                            </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-actions right">
                            <asp:button id="Button1" runat="server" class="btn green" text="Kaydet" />
                            <asp:button id="Buttonsil" runat="server" class="btn green" text="Sil" />
                        </div>
                        <div id="validationresult">
                            <asp:label id="durumlabelkackayit" runat="server"></asp:label>
                            <asp:label id="durumlabel" runat="server"></asp:label>
                        </div>
                    </div>
                </div>
                <!-- VERİ GİRİŞ PORTLATE-->
                <!-- DATATABLE PORTLATE-->
                <div class="portlet box grey">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-globe"></i>Sınır Kapısı Takvimi
                        </div>
                        <div class="tools">
                            <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                            </a><a href="javascript:;" class="remove"></a>
                        </div>
                        <div class="actions">
                            <asp:button id="Buttonyenikayit" runat="server" class="btn green" text="Yeni Kayıt" />
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-toolbar">
                        </div>
                        <asp:label id="Label1" runat="server"></asp:label>
                    </div>
                </div>
                <!-- DATATABLE PORTLATE-->
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

<script type="text/javascript" src="js/sinirkapitakvim.js?rel=3s452346"></script>

