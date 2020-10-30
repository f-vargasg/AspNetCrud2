<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AspNetCrud2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfProductID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Product" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProduct" Text="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Price" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPrice" Text="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Count" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCount" Text="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Description" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDescription" Text="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button Text="Save" ID="btnSave" runat="server" OnClick="BtnSave_Click" />
                        <asp:Button Text="Delete" ID="btnDelete" runat="server" OnClick="BtnDelete_Click" />
                        <asp:Button Text="Clear" ID="btnClear" runat="server" OnClick="BtnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSucessMessage" runat="server" ForeColor="Green" />

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" />

                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView  ID="gvProduct" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Product" HeaderText="Product" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Count" HeaderText="Count" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Select" ID="lnkSelect"  CommandArgument ='<%# Eval("productid")  %>' runat="server" OnClick="LnkSelect_OnClick" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
