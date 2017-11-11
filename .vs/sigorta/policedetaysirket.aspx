<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="policedetaysirket.aspx.vb" Inherits="sigorta.policedetaysirket" %>

<%@ Register Src="headerfancy.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<head>
    <title>Poliçe Detayları</title>
</head>
<uc1:header ID="header1" runat="server" />

<script type="text/javascript" src="js/policedetaysirket.js?rel=6456456747"></script>

<body>


        <form id="form1" runat="server" class="uniForm">
        
        <!-- POLİÇE-->
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Poliçe
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                    </a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="Labeldigerkisiler" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <!-- POLİÇE-->
        
        
        <!-- ARAÇ-->
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Araç
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                    </a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <!-- Zeyil-->
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Zeyiller
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                    </a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        
        <!-- Hasar-->
        <div class="portlet box purple">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Hasar Dosyaları
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                    </a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        
         <!-- Talep-->
        <div class="portlet box purple">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-plus"></i>Talep
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse"></a><a href="javascript:;" class="reload">
                    </a><a href="javascript:;" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body">
                 <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <br/>
        
  
         <button type="button" id="kapatbutton" class="btn purple">Tamam</button>
         
        </form>
 

 
    <br />
    
    
</body>
