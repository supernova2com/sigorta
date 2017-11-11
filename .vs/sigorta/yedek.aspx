<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="yedek.aspx.vb" Inherits="sigorta.yedek" %>

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
                    Yedek<small> Sistem Yedeği.</small>
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
                    <li><a href="#">Ayarlar </a><i class="fa fa-angle-right"></i></li>
                    <li><a href="#">Sistem Yedeği </a></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        
        
     
        <div class="row">
            <div class="col-md-12">
            
               <!-- DATATABLE PORTLATE AWS-->
                <div class="portlet box grey">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-globe"></i>AWS (54.93.223.145)
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-toolbar">
                        </div>
                        <asp:literal id="Label1" runat="server"></asp:literal><br/>
                        <asp:literal id="Label2" runat="server"></asp:literal>
                     
                    </div>
                </div>
                <!-- DATATABLE PORTLATE AWS-->
                
                
                
               <!-- DATATABLE PORTLATE YEDEK-->
                <div class="portlet box grey">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-globe"></i>Yedek (192.168.100.240)
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="table-toolbar">
                        </div>
                        <asp:literal id="Label3" runat="server"></asp:literal><br/>
                        <asp:literal id="Label4" runat="server"></asp:literal>
                     
                    </div>
                </div>
                <!-- DATATABLE PORTLATE YEDEK-->
                
     
                
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

<script type="text/javascript" src="js/yedek.js"></script>

<uc3:headertemel ID="headertemel" runat="server" />
