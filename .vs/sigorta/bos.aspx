<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="bos.aspx.vb" Inherits="sigorta.bos" %>
<%@ Register src="header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register src="headertemel.ascx" tagname="headertemel" tagprefix="uc3" %>
<uc1:header id="header1" runat="server" /> 

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
					Kullanıcı Rolleri<small>Bu sayfada kullanıcı rollerini tanımlayabilirsiniz.</small>
					</h3>
					<ul class="page-breadcrumb breadcrumb">
						<li class="btn-group">
							<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
							<span>
								İşlemler
							</span>
							<i class="fa fa-angle-down"></i>
							</button>
							<ul class="dropdown-menu pull-right" role="menu">
								<li>
									<a href="sabitrol.aspx?op=yenikayit">
										Yeni Kayıt
									</a>
								</li>
							</ul>
						</li>
						<li>
							<i class="fa fa-home"></i>
							<a href="default.aspx">
								Anasayfa
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Kullanıcı Rolleri
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
					
					
					    <!-- YARDIM ------------------------------- -->
    <div class="accordion">
    <h3><a href="">Yardım</a></h3>
    <div>
        <div class="help">
            <p class="helpinner">'Yeni Araç Tarife Kaydı' etiketli düğmeyi kullanarak yeni araç tarife kaydı yapabilirsiniz.
            Araç tarife kodu veya araç tarife adına göre kayıtlar içinde arama yapabilirsiniz. İlgili kaydı seçerek o kayıt 
            üzerinde değiştirme ve silme işlemleri gerçekleştirebilirsiniz.     
            </p>
        </div>
    </div>
    </div>
    <!-- YARDIM BİTTİ ---------------------- -->
    <BR/><BR/>  
    
			
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box purple">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Bilgiler
							</div>
						</div>
						<div class="portlet-body">
						
						
							<div class="table-toolbar">
							</div>
								
                           <asp:Label ID="Label1" runat="server"></asp:Label>		
							
						</div>
					</div>
					<!-- DATATABLE PORTLATE-->
							          
    
    
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	
	

</form>
<uc2:footer id="footer" runat="server" />

<uc3:headertemel id="headertemel" runat="server" /> 
<script type="text/javascript" src="js/aractarife.js"></script>
 




