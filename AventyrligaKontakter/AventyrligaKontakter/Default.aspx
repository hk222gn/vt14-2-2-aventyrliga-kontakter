<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AventyrligaKontakter.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <h1>Äventyrliga kontakter</h1>
        <div>
            <asp:ValidationSummary ID="ValidationSummary" HeaderText="Fel har inträffat, åtgärda dessa och försök igen!" DisplayMode="BulletList" runat="server" />
            <asp:ValidationSummary ID="EditValidationSummary" HeaderText="Fel har inträffat, åtgärda dessa och försök igen!" DisplayMode="BulletList" runat="server" ValidationGroup="Edit" />
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label>
                    <div>
                        <asp:ImageButton ID="ImageButton1" ImageUrl="Content/remove.png" runat="server" CausesValidation="false" />
                    </div>
            </asp:Panel>
        </div>
        <asp:ListView ID="ContactListView" runat="server" ItemType="AventyrligaKontakter.Model.Contact"
            SelectMethod="ContactListView_GetDataPageWise"
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
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
                <asp:DataPager ID="DataPager1" runat="server" PageSize="20">
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
                            <%#: Item.EmailAddress %>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />

                            <%-- Troligen fungerande ja/nej ruta. --%>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick='<%# String.Format("return confirm(\"Ta bort {0} {1} från databasen?\")", Item.FirstName, Item.LastName)%>' />
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
                            <asp:TextBox ID="FirstNameTextBox" MaxLength="50" runat="server" Text='<%# BindItem.FirstName %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet förnamn får ej vara tomt" ControlToValidate="FirstNameTextBox" Display="None"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="LastNameTextBox" MaxLength="50" runat="server" Text='<%# BindItem.LastName %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Fältet efternamn får ej vara tomt" ControlToValidate="LastNameTextBox" Display="None"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="EmailAddressTextBox" MaxLength="50" runat="server" Text='<%# BindItem.EmailAddress %>'/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Fältet E-Mail får ej vara tomt" ControlToValidate="EmailAddressTextBox" Display="None"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>  
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Mail adressen har ett eller flera otillåtna tecken eller är formaterad på ett felaktigt sätt." 
                    ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}" ControlToValidate="EmailAddressTextBox" Display="None"></asp:RegularExpressionValidator>
            </InsertItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" MaxLength="50" runat="server" ValidationGroup="Edit" Text='<%# BindItem.FirstName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" MaxLength="50" runat="server" ValidationGroup="Edit" Text='<%# BindItem.LastName %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddressTextBox" MaxLength="50" runat="server" ValidationGroup="Edit" Text='<%# BindItem.EmailAddress %>'/>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Update" ValidationGroup="Edit" Text="Spara" />
                        <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Edit" ErrorMessage="Fältet förnamn får ej vara tomt" ControlToValidate="FirstNameTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Edit" ErrorMessage="Fältet efternamn får ej vara tomt" ControlToValidate="LastNameTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Edit" ErrorMessage="Fältet E-Mail får ej vara tomt" ControlToValidate="EmailAddressTextBox" Display="None"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Edit" ErrorMessage="Mail adressen har ett eller flera otillåtna tecken eller är formaterad på ett felaktigt sätt." 
                    ValidationExpression="[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}" ControlToValidate="EmailAddressTextBox" Display="None"></asp:RegularExpressionValidator>
            </EditItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>