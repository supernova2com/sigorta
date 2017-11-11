<%@ Page Language="vb" AutoEventWireup="false" enableEventValidation="false"  ValidateRequest="false"  CodeBehind="menu.aspx.vb" Inherits="sigorta.menu" %>


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
					Menu<small>Menu ayarlarını bu ekrandan yapabilirsiniz.</small>
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
							<a href="">
								Ayarlar
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="menu.aspx">
							    Menu
							</a>
						</li>
			
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			
			<div id="hatadialog">
                <asp:Label ID="Labelsiralamamenu" runat="server"></asp:Label> 
			</div>
			
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
                                <p>Kullanıcı menulerinin nasıl görüneceğini buradan düzenleyebilirisiniz.</p>
						</div>
					</div>
					<!-- YARDIM PORTLATE-->
					
					
					
				    <!-- ARAMA PORTLATE-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-search"></i>Arama
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
									
									<label class="col-md-3 control-label">Ana menu:</label> 
									
									<div class="col-md-3">   
									   <asp:DropDownList ID="DropDownList6"  class="form-control"  runat="server">
                                       </asp:DropDownList>  
                                    </div>
                                    
                                    <div class="col-md-3">   
                                    </div>
                                    
                                    <div class="col-md-3">    
                                      <asp:Button ID="Button2" runat="server" class="btn green" Text="Sadece Başlıkları Göster" /> 
							       </div>
                                    

                                </div>
                                
                                
                               <div class="form-group">						
									
								   <label class="col-md-3 control-label">Ana menu:</label> 
									
								   <div class="col-md-3">   
									   <asp:DropDownList ID="DropDownList7"  class="form-control"  runat="server">
                                       </asp:DropDownList>  
                                   </div>
                                    
                                   <div class="col-md-3">   
									   <asp:DropDownList ID="DropDownList8"  class="form-control"  runat="server">
                                       </asp:DropDownList>  
                                   </div>
                                    
                                   <div class="col-md-3">    
                                      <asp:Button ID="Button3" runat="server" class="btn green" Text="Alt Başlıkları Göster" /> 
							       </div>
							       
                                </div>
                                
                                
                                
                               <div class="form-group">						
									
									<label class="col-md-3 control-label">Ana menu:</label> 
									
									<div class="col-md-3">   
									   <asp:DropDownList ID="DropDownList9"  class="form-control"  runat="server">
                                       </asp:DropDownList>  
                                    </div>
                                    
                                    <div class="col-md-3">   
                                    </div>
                                    
                                    <div class="col-md-3">    
                                      <span id="siralamabutton" class="btn green">Sıralama Seçenekleri</span> 
							       </div>
                                    

                               </div>
                                
                                
                                <div id="validationresult2">
							            <asp:Label ID="durumlabelarama" runat="server"></asp:Label>  
					             </div>
						
						
						</div>	
	
							
						</div>
					<!-- ARAMA PORTLATE-->
							
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Menu Ekleme
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
                                <label class="col-md-3 control-label"> Hangi menu:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList1"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Başlık mı?</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList2"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div>   
                                   
		                    <div class="form-group">
                                <label class="col-md-3 control-label"> Başlık Değilse Hangi Başlık Altında?</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList3"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div>   
                                          
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Menu Yazısı (Başlık):</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox1" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div>         
 
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Sıra:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox2" autocomplete="off" AutoCompleteType="Disabled" runat="server"
                                      maxlength="2" class="form-control"/>    
                                </div>
                            </div>  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Tip:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox3" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> İkon CSS Sınıfı:</label>
                                <div class="col-md-4"> 
                                    <asp:textbox id="TextBox4" maxlength="50" autocomplete="off" AutoCompleteType="Disabled" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div>
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> CSS Sınıfı:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox5" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div>    
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> ID (Highlight İçin):</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox6" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="3" class="form-control"/>    
                                </div>
                            </div> 
                              
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Ek HTML:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox class="form-control" ID="TextBox7" runat="server" Height="150px" 
                                      TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Basıldığında Gideceği Sayfa Adresi:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="Textbox8" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div> 
                                
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Yetki Kolonu:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList4"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Bağlı Modülü:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList10"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                            
                           
                           <div class="form-group">
                                <label class="col-md-3 control-label"> Nerede Açılsın?</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList5"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                            
                            
                                <div class="form-group">
                                <label class="col-md-3 control-label"> Her zaman Gözüksün mü?</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList11"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div>   
                            
                            
                          	<div class="form-actions right">
                                <asp:Button ID="Button1" runat="server" class="btn green" Text="Kaydet" /> 
                                <asp:Button ID="Buttonsil" runat="server" class="btn green" Text="Sil" /> 
							</div>
								
						
						    <div id="validationresult">
							    <asp:Label ID="durumlabel" runat="server"></asp:Label>  
					        </div>  														
						 
					
						</div>
					</div>
					<!-- VERİ GİRİŞ PORTLATE-->
					
							
					<!-- DATATABLE PORTLATE-->
					<div class="portlet box grey">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-globe"></i>Menuler
							</div>
							
						    <div class="tools">
								<a href="javascript:;" class="collapse"></a>
					
								<a href="javascript:;" class="reload">
								</a>
								<a href="javascript:;" class="remove">
								</a>
							</div>
							
							<div class="actions">
									<asp:Button ID="Buttonyenikayit" runat="server" class="btn green" Text="Yeni Kayıt" /> 
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
<script type="text/javascript" src="js/menu.js"></script>

 
