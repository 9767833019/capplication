<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="capplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label runat="server">Student Name</asp:Label>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <br />
            <br />
              <asp:Label runat="server">Student Address</asp:Label>
  <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
  <br />
  <br />
              <asp:Label runat="server">Student Mob</asp:Label>
  <asp:TextBox ID="txtmob" runat="server"></asp:TextBox>
  <br />
  <br />
              <asp:Label runat="server">Student Age</asp:Label>
  <asp:TextBox ID="txtage" runat="server"></asp:TextBox>
  <br />
  <br />
            <asp:Button runat="server" ID="btn" Text="Insert" OnClick="btn_Click"/>
            <br />

           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentID" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
    <Columns>
        <asp:BoundField DataField="StudentID" HeaderText="Student ID" ReadOnly="True" InsertVisible="False" />
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("StudentName") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("StudentName") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Address">
            <ItemTemplate>
                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("StudentAddress") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("StudentAddress") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Age">
            <ItemTemplate>
                <asp:Label ID="lblAge" runat="server" Text='<%# Eval("StudentAge") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAge" runat="server" Text='<%# Bind("StudentAge") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

        </div>
    </form>
</body>
</html>
