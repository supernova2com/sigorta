<%@ Page Language="vb" AutoEventWireup="false" enableEventValidation="false" CodeBehind="pertarac.aspx.vb" Inherits="sigorta.pertarac" %>


<%@ Register src="headerbilgi.ascx" tagname="header" tagprefix="uc1" %>
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
					Pert Araçlar <small>Pert Araçlar İle İlgili İşlemler</small>
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
								Bilgi Girişi
							</a>
							<i class="fa fa-angle-right"></i>
						</li>
						<li>
							<a href="pertarac.aspx">
							    Pert Araçlar
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
								
                           <p>Pert araçlar ile ilgili işlemleri bu ekrandan yapabilirsiniz. </p>
							
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
																						
							
								          <div class="row">
							            <div class="col-md-6">
									       <div class="form-group">
										        <label class="control-label col-md-4">Şirket:</label>
										        <div class="col-md-8">
											         <asp:DropDownList ID="DropDownList8"  class="form-control"  runat="server">
                                                     </asp:DropDownList>  
										        </div>
									         </div>
								         </div>
							         </div>
							             

							         <div class="form-actions right">
                                        <asp:Button ID="Button2" runat="server" class="btn green" Text="Sorgula" /> 
							         </div>
	
							
						</div>
					</div>
					<!-- ARAMA PORTLATE-->
					
					
				
					<!-- VERİ GİRİŞ PORTLATE-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-plus"></i>Pert Araç Girişi
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
                                <label class="col-md-3 control-label"> Şirket:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList1"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Araç Cinsi:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList2"  class="form-control"  runat="server">
                                    </asp:DropDownList>    
                                </div>
                            </div>
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Araç Markası:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList3"  class="form-control"  runat="server">
                                    </asp:DropDownList>     
                                </div>
                            </div>  
                            
                           
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Araç Modeli:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList4"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div>   
                                   
  
                                          
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Plaka:</label>
                                <div class="col-md-4"> 
                                      <asp:TextBox id="TextBox3" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Şasi No:</label>
                                <div class="col-md-4"> 
                                    <asp:textbox id="TextBox4" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div>  
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Motor No:</label>
                                <div class="col-md-4"> 
                                     <asp:textbox id="TextBox5" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Kapı Sayısı:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList5"  class="form-control"  runat="server">
                                    </asp:DropDownList> 
                                </div>
                            </div>  
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Motor Gücü (cc):</label>
                                <div class="col-md-4"> 
                                     <asp:textbox id="TextBox7" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div> 
                            
                            
                           <div class="form-group">
                                <label class="col-md-3 control-label"> İmal Yılı:</label>
                                <div class="col-md-4"> 
                                    <asp:DropDownList ID="DropDownList6"  class="form-control"  runat="server">
                                    </asp:DropDownList> 
                                </div>
                            </div>  
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Kaza Tarihi:</label>
                                <div class="col-md-4"> 
                                     <asp:textbox id="TextBox8" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div>  
                            
                            
       
                              <div class="form-group">
                                <label class="col-md-3 control-label"> Ödenen Hasar:</label>
                                <div class="col-md-3"> 
                                      <asp:TextBox id="TextBox9" autocomplete="off" AutoCompleteType="Disabled" runat="server" 
                                      maxlength="254" class="form-control"/>    
                                </div>
                                  <div class="col-md-3"> 
                                    <asp:DropDownList ID="DropDownList7"  class="form-control"  runat="server">
                                    </asp:DropDownList>  
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> Piyasa Değeri:</label>
                                <div class="col-md-4"> 
                                     <asp:textbox id="TextBox11" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div> 
                            
                            
                                 <div class="form-group">
                                <label class="col-md-3 control-label"> Hemen Satış Fiyatı:</label>
                                <div class="col-md-4"> 
                                     <asp:textbox id="TextBox14" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> İlan Başlangıç Tarihi:</label>
                                <div class="col-md-4"> 
                                     <asp:textbox id="TextBox12" autocomplete="off" class="form-control" runat="server"></asp:textbox>
                                </div>
                            </div> 
                            
                            
                            <div class="form-group">
                                <label class="col-md-3 control-label"> İlan Bitiş Tarihi:</label>
                                <div class="col-md-4"> 
                                     <asp:textbox id="TextBox13" autocomplete="off" class="form-control" runat="server"></asp:textbox>
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
								<i class="fa fa-globe"></i>Pert Araçlar
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
								
								<div class="btn-group pull-right">	
								    <asp:Button ID="Buttonpdf" class="btn red" runat="server" Text="PDF" />
									<asp:Button ID="Buttonexcel" class="btn blue" runat="server" Text="EXCEL" />
									<asp:Button ID="Buttonword" class="btn white" runat="server" Text="WORD" />	
								</div>	
								
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
<script type="text/javascript" src="js/pertarac.js"></script>
