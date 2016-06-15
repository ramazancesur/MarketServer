<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test.SoapWs.MakroMarket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Web Servis Ürün Ekleme Sayfası

        <table>
            <tr>
                <td>
                    Marketler:  
                </td>
                <td>
                    <asp:DropDownList ID="drpMarketler" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Kategoriler
                </td>
                <td>
                    <asp:DropDownList ID="drpKategori" runat="server" ></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Makro Market
                </td>
                <td>
                    <asp:Button ID="btnMakro" runat="server" Text="Makro Market Urun Güncelle" OnClick="btnMakro_Click" />
                </td>
            </tr>

            <tr>
                <td>Courfursa
                </td>
                <td>
                    <asp:Button ID="btnCourfoursa" runat="server" Text="Courfursa Urun Güncelle" OnClick="btnCourfoursa_Click" />
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    MARKET EKLEME SERVİSİ
                </td>
            </tr>
            <tr>
                <td>
                    Market Adi:
                </td>
                <td>
                    <asp:TextBox ID="txtMarketAdi" runat="server"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>
                    Market Adresi:
                </td>
                <td>
                    <asp:TextBox ID="txtMarketAdres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnMarketEkle" runat="server" Text="Market Ekle..." OnClick="btnMarketEkle_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                 <a href="RestWs/WcfWs/Urun/UrunServices.svc">Urunler Rest Servisi</a>
                </td>
            </tr>
          
             <tr>
                <td colspan="2">
                 <a href="RestWs/WcfWs/Kategori/KategoriServices.svc">Kategori Rest Servisi</a>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                 <a href="RestWs/WcfWs/Market/MarketServisi.svc">Market Rest Servisi</a>
                </td>
            </tr>
        </table>
           
        </div>
    </form>
</body>
</html>
