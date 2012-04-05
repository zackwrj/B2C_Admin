<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Web.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        GetListByPage:<br />
        PageSize:<asp:TextBox ID="txt111" runat="server"></asp:TextBox><br />
        PageIndex:<asp:TextBox ID="txt" runat="server"></asp:TextBox><br />
        Where:<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox><br />
        <asp:Button ID="btn" runat="server" Text="提  交" onclick="btn_Click" />
        <br /><br />
        <asp:Repeater ID="rptTest" runat="server">
            <ItemTemplate>
                <%#Eval("ArticleID")%>----<%#Eval("Title") %><br />
            </ItemTemplate>
        </asp:Repeater>
        <hr />
       GetMaxID:<asp:Label ID="lblGetMaxID" runat="server" Text=""></asp:Label>
       <hr />
     
        Delete:<asp:TextBox ID="txtDelete" runat="server"></asp:TextBox>
         <asp:Button ID="btnDelete" runat="server" Text="删除" onclick="btnDelete_Click" />
          <asp:Label ID="lblDelete" runat="server" Text=""></asp:Label>
        <hr>
        DeleteIDList:
        <asp:TextBox ID="txtDelIDList" runat="server"></asp:TextBox>
         <asp:Button ID="btnDelIDList" runat="server" Text="删除List" onclick="btnDelIDList_Click" />
          <asp:Label ID="lblDelIDList" runat="server" Text=""></asp:Label>
        <hr />
          <asp:TextBox ID="txtGetCount" runat="server"></asp:TextBox>
          <asp:Button ID="btnGetCount" runat="server" Text="获取数量" onclick="btnGetCount_Click" />
           <asp:Label ID="lblGetCount" runat="server" Text=""></asp:Label>
        <hr />
        GetModel:
        <asp:TextBox ID="txtGetModel" runat="server"></asp:TextBox>
        <asp:Button ID="btnGetModel" runat="server" Text="获取Model" onclick="btnGetModel_Click" />
         <asp:Label ID="lblGetModel" runat="server" Text=""></asp:Label>
         <hr />
         GetList:<br />
           top:<asp:TextBox ID="txtGetListTop" runat="server"></asp:TextBox>
        strWhere:<asp:TextBox ID="txtGetListStrWhere" runat="server"></asp:TextBox>
        fieldOrder:<asp:TextBox ID="txtGetListFieldOrder" runat="server"></asp:TextBox>
        <asp:Button ID="btnGetList" runat="server" Text="提  交" onclick="btnGetList_Click" />
        <br /><br />
        <asp:Repeater ID="rptGetList" runat="server">
            <ItemTemplate>
                <%#Eval("ArticleID")%>----<%#Eval("Title") %><br />
            </ItemTemplate>
        </asp:Repeater>
        <hr />
        GetListLikeTitle
           top:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        Title:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        fieldOrder:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="提  交" onclick="Button1_Click" />
        <br /><br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <%#Eval("ArticleID")%>----<%#Eval("Title") %><br />
            </ItemTemplate>
        </asp:Repeater>
        <hr />
        GetListByIDList
           top:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        IDList:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        fieldOrder:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="提  交" onclick="Button2_Click" />
        <br /><br />
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <%#Eval("ArticleID")%>----<%#Eval("Title") %><br />
            </ItemTemplate>
        </asp:Repeater>
        <hr />


        添加：
        ID：<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
        Title：<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br />
         <asp:Button ID="Button3" runat="server" Text="新 增" onclick="Button3_Click" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <hr />

        更新：
        ID：<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox><br />
        Title：<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox><br />
         <asp:Button ID="Button4" runat="server" Text="更  新" onclick="Button4_Click" />
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <hr />

        更新单个字段的值
        ID：<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox><br />
        FieldName：<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox><br />
        FieldValue：<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button5" runat="server" Text="更  新" onclick="Button5_Click" />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
