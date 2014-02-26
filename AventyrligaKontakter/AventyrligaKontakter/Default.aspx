<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AventyrligaKontakter.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary" HeaderText="Fel har inträffat, åtgärda dessa och försök igen!" DisplayMode="BulletList" runat="server" />
            <asp:ValidationSummary ID="EditValidationSummary" HeaderText="Fel har inträffat, åtgärda dessa och försök igen!" DisplayMode="BulletList" runat="server" ValidationGroup="Edit" />
        </div>
        <asp:ListView ID="ContactListView" runat="server" ItemType="AventyrligaKontakter.Model.Contact"
            SelectMethod="ContactListView_GetData"
            InsertMethod="ContactListView_InsertItem"
            UpdateMethod="ContactListView_UpdateItem"
            DeleteMethod="ContactListView_DeleteItem"
            DataKeyNames="ContactID"
            InsertItemPosition="FirstItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>
                            Förnamn
                        </th>
                        <th>
                            Efternamn
                        </th>
                        <th>
                            E-Mail
                        </th>
                    </tr>
                </table>
                <%-- Implementera DataPager --%>
                <asp:DataPager ID="DataPager1" runat="server">
                    <fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true"  
                            FirstPageText="<<" 
                            ShowNextPageButton="false" 
                            ShowPreviousPageButton="false"/>
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField 
                            ShowLastPageButton="true" 
                            LastPageText=">>"
                            ShowFirstPageButton="false" 
                            ShowPreviousPageButton="false" />
                    </fields>

                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                        <td>
                            <%#: Item.FirstName %>
                        </td>
                        <td>
                            <%#: Item.LastName %>
                        </td>
                        <td>
                            <%#: Item.EmailAdress %>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />

                            <%-- Troligen fungerande ja/nej ruta. --%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick='<%# "return confirm(\"Ta bort namnet {0}?\")" %>' />
                        </td>
                    </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <p>
                    Det finns inga kontaktuppgifter.
                </p>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr>
                        <td>
                            <asp:TextBox ID="FirstName" MaxLength="50" runat="server" Text='<%# BindItem.FirstName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="LastName" MaxLength="50" runat="server" Text='<%# BindItem.LastName %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAdress" MaxLength="50" runat="server" Text='<%# BindItem.EmailAdress %>'/>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet får ej vara tomt" ControlToValidate="FirstNameTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fältet får ej vara tomt" ControlToValidate="LastNameTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fältet får ej vara tomt" ControlToValidate="MailTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Mail adressen har ett eller flera otillåtna tecken eller är formaterad på ett felaktigt sätt." 
                    ValidationExpression="[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}" ControlToValidate="MailTextBox" Display="None"></asp:RegularExpressionValidator>
            </InsertItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" MaxLength="50" runat="server" ValidationGroup="Edit" Text='<%# BindItem.FirstName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" MaxLength="50" runat="server" ValidationGroup="Edit" Text='<%# BindItem.LastName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAdress" MaxLength="50" runat="server" ValidationGroup="Edit" Text='<%# BindItem.EmailAdress %>'/>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Update" ValidationGroup="Edit" Text="Spara" />
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Edit" ErrorMessage="Fältet får ej vara tomt" ControlToValidate="FirstNameTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Edit" ErrorMessage="Fältet får ej vara tomt" ControlToValidate="LastNameTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Edit" ErrorMessage="Fältet får ej vara tomt" ControlToValidate="MailTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Edit" ErrorMessage="Mail adressen har ett eller flera otillåtna tecken eller är formaterad på ett felaktigt sätt." 
                    ValidationExpression="[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}" ControlToValidate="MailTextBox" Display="None"></asp:RegularExpressionValidator>
            </EditItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>