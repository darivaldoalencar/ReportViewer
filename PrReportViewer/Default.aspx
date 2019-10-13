<%@ Page Title="Menu Inicial" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrReportViewer._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="phCorpo" runat="server">
    <div class="container">
        <div class="box">
            <h2>Menu do sistema</h2>
            <ul>
                <li>
                    <a href="Relatorio/Relatorio.aspx">Relatório WebForms / DataTable</a>
                </li>
            </ul>            
            <div class="msg"><b>OBS:</b> Não foi criado para testar Front End, caso tenha chegado aqui por acaso, aprecie apenas o objetivo do sistema</div>
        </div>
    </div>
</asp:Content>
