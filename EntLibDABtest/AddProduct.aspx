<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="EntLibDABtest.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
     <table cellpadding="0" cellspacing="0">
         <tr>
             <td>Ad Soyad</td>
             <td>&nbsp;</td>
             <td>
                 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td>Adres</td>
             <td>&nbsp;</td>
             <td>
                 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td>Maaş</td>
             <td>&nbsp;</td>
             <td>
                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td>&nbsp;</td>
             <td>&nbsp;</td>
             <td>
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Kaydet" />
             </td>
         </tr>
     </table>


</asp:Content>
