<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="card-wrapper">
            <h2>Card Sample</h2>
        </div>
            <asp:Label ID="paymentlabel" runat="server" Text=""></asp:Label>

            <div id="ccarea">

                <label>Card Number :</label>
                <asp:TextBox ID="cardnumber"  runat="server" placeholder="Card Number" required=""></asp:TextBox>
                <asp:TextBox ID="expirydate"  runat="server" placeholder="MM/YY" required=""></asp:TextBox>
                <asp:TextBox ID="cvcnumber"  runat="server" placeholder="CVC" required=""></asp:TextBox>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="Pay" runat="server" CssClass="button small" Text="Validate" OnClick="Pay_Click" />
    </div>

</asp:Content>
