﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Editor.ascx.cs" Inherits="lv_B2C.Web.Controls.Editor" %>

<script language="javascript" type="text/javascript" src='<%=ResolveUrl("~/Adminlvcn/1ref/controls/ckeditor/ckeditor.js")%>'></script>

<asp:TextBox ID="mckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>

<script type="text/javascript">
    //<![CDATA[
        CKEDITOR.replace('<%=mckeditor.ClientID %>',
        {
            skin: 'kama',
            enterMode: Number(3),
            shiftEnterMode: Number(3),

            filebrowserBrowseUrl: '<%=ResolveUrl("~/Adminlvcn/1ref/controls/ckfinder/ckfinder.html")%>',

            filebrowserImageBrowseUrl: '<%=ResolveUrl("~/Adminlvcn/1ref/controls/ckfinder/ckfinder.html?Type=Images")%>',

            filebrowserFlashBrowseUrl: '<%=ResolveUrl("~/Adminlvcn/1ref/controls/ckfinder/ckfinder.html?Type=Flash")%>',

            filebrowserUploadUrl: '<%=ResolveUrl("~/Adminlvcn/1ref/controls/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files")%>',

            filebrowserImageUploadUrl: '<%=ResolveUrl("~/Adminlvcn/1ref/controls/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images")%>',

            filebrowserFlashUploadUrl: '<%=ResolveUrl("~/Adminlvcn/1ref/controls/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash")%>'
        });
    //]]>
</script>

