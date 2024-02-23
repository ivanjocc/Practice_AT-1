<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webPizza.aspx.cs" Inherits="prjWebCsControlleASP.webPizza" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        body {
            background-color: bisque;
            color: brown;
            font-weight: bold;
        }

        h1 {
            text-align: center;
        }

        marquee {
            background-color: red;
            color: white;
            font-weight: bold;
        }

        .boite {
            font-weight: bold;
            width: 200px;
            border-radius: 5px;
            color: navy;
        }

        #grandTableau {
            display: flex;
            justify-content: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>TECCART - PIZZA - HURTS</h1>
            <hr />
            <marquee>La mejor pizza hecha por el tigro</marquee>
            <hr />
            <table id="grandTableau">
                <tr>
                    <td>
                        <asp:Panel ID="panPizza" runat="server" BackColor="#ffc981" ForeColor="Red" Font-Bold="True" Width="450px" GroupingText="Information Client et Pizza">
                <table>
                    <tr>
                        <td>Nom de client : </td>
                        <td>
                            <asp:TextBox ID="txtNom" runat="server" CssClass="boite"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>Telephone du client : </td>
                        <td>
                            <asp:TextBox ID="txtTelephone" runat="server" CssClass="boite"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Pour livraison ? : </td>
                        <td>
                            <asp:CheckBox ID="chkLivraison" runat="server" Font-Bold="True" Text="Oui" AutoPostBack="True" OnCheckedChanged="chkLivraison_CheckedChanged" />
                        </td>
                    </tr>

                    <tr>
                        <td style="vertical-align: top;">
                            <asp:Label ID="lblAdresse" runat="server" Text="Adress Livraison"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAdresse" runat="server" CssClass="boite" Height="50px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Choisir votre pizza : </td>
                        <td>
                            <asp:DropDownList ID="cboPizzas" runat="server" CssClass="boite" OnSelectedIndexChanged="cboPizzas_SelectedIndexChanged" AutoPostBack="true">
                                <%--<asp:ListItem>Faites votre choix</asp:ListItem>
                                <asp:ListItem>L&#39;italienne</asp:ListItem>
                                <asp:ListItem>La vegetarienne</asp:ListItem>
                                <asp:ListItem>La halal</asp:ListItem>
                                <asp:ListItem>La mexicanaine</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td style="vertical-align: top;">Choisir la taille : </td>
                        <td>
                            <asp:ListBox ID="lstTailles" runat="server" CssClass="boite" Height="100%" Rows="3" AutoPostBack="True" OnSelectedIndexChanged="lstTailles_SelectedIndexChanged">

                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Choisir garnitures : </td>
                        <td>
                            <asp:CheckBoxList ID="lstChkGarnitures" runat="server" CssClass="boite" OnSelectedIndexChanged="lstChkGarnitures_SelectedIndexChanged" AutoPostBack="true">

                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">Choisir Croute : </td>
                        <td>
                            <asp:RadioButtonList ID="lstRbtnCrust" runat="server" OnSelectedIndexChanged="lstRbtnCrust_SelectedIndexChanged" AutoPostBack="true">


                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
                    </td>
                    <td style="vertical-align: top">
                        <asp:Panel ID="PanPrix" runat="server" BackColor="#ffc981" ForeColor="Red" Font-Bold="True" Width="450px" GroupingText="Information Client et Pizza">
                            <asp:Label ID="lblPrix" runat="server" Text="" ForeColor="Brown" Font-Bold="true"></asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
