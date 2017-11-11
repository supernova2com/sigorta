<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="arackayittest.aspx.vb" Inherits="sigorta.arackayittest" %>

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
					Araç Kayıt Servis Testi<small></small>
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
								XML Web Servisleri
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="#">
								Araç Kayıt Servis Testi
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			
			<div class="row">
				<div class="col-md-12">
				
                    <!-- YARDIM PORTLATE-->
					<div class="portlet box red">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-bell-o"></i>Yardım
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
				
								<a href="javascript:;" class="remove"></a>
							</div>
							
				
						</div>
						<div class="portlet-body">	
						
							<div class="table-toolbar">
							</div>
								
                           <p>Araç Kayıt Dairesinin KKSBM'ye vermiş olduğu servisin düzgün çalışıp çalışmadığını bu ekrandan test edebilirsiniz.</p>
								
						    <asp:Label ID="Labeluyari" runat="server" style="color: #FF0000"></asp:Label>	
						    
						</div>
					
					</div>
					<!-- YARDIM PORTLATE-->
					
								
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Araç Kayıt Dairesi Test 
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
					        </div>
					     
						</div>
						
							
						<div class="portlet-body">
					
						   
		                    <div class="form-group">
                                <label class="col-md-3 control-label"> Plaka:</label>
                                <div class="col-md-4"> 
                                    <asp:TextBox id="Textbox1" autocomplete="off" AutoCompleteType="Disabled" runat="server" size="254" 
                                    maxlength="254" type="text" class="form-control"/>
                                </div>
                            </div>   
                            
                            <div class="form-actions right">
                                <asp:Button ID="Button2" runat="server" class="btn green" Text="Test Et" /> 
							</div>
                               		
	                        <asp:Label ID="Labelserviscevap" runat="server"></asp:Label>  
	 
	 
						    <div id="validationresult">
							    <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					        </div>  														
						 
						 
						 
					
						</div>
					</div>
					<!-- VERİ GİRİŞ PORTLATE-->
							         
			
					
				</div> <!-- col md12 -->
			</div> <!-- row -->
	
		</div> <!-- page-content-wrapper -->
	</div> <!-- page content -->

	

</form>
<uc2:footer id="footer" runat="server" />
<script type="text/javascript" src="js/arackayittest.js"></script>
<uc3:headertemel id="headertemel" runat="server" /> 

 




