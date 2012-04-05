<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Photh_Manage.ascx.cs" Inherits="lv_B2C.Web.Photh_Manage" %>
<link href="/Adminlvcn/1ref/controls/ImageManage/CSS/WebAlbum.css" rel="stylesheet" type="text/css" />
<link href="/Adminlvcn/1ref/controls/ImageManage/CSS/ContextMenu.css" rel="stylesheet" type="text/css" />
<script src="/base_js/jquery-1.5.2.js" type="text/javascript"></script>
<script src="/Adminlvcn/1ref/controls/ImageManage/JS/WebAlbumManage.js" type="text/javascript"></script>

<div id="WebAlbumManage" oncontextmenu = showMenu('')>
  <div>
     <input type="checkbox" value="" />
  </div>
  <div class="webAlbum">
  <!--目录-->
  <div class="webAlbumLeft">
     <div id="ImageDir"><h2>文件夹</h2></div>
     <div>
         <ul id="webImageDir">
         </ul>
      </div>
  </div>
  <!--图片-->
  <div class="webAlbumRight" >
      <div>
        <input type="checkbox" id="checkAll" />
        <label for="checkAll">全选/反选</label>
        <span></span>
        <input type="button"  id="moveView" value="显示文件夹"/>
        <ul id="moveSelect" ablum="0" style=" visibility:hidden">

        </ul>
        <input type="button"  id="moveAll" value="移至文件夹"/>
        
        <input type="button"  id="deleteAll" value="批量删除"/>
        <input type="button"  id="editAll" value="批量编辑"/>
        <input type="text" id="editAllTitle"  style=" visibility:hidden"/>
      </div>
      <div id="viewImage">
         
      </div>
  </div>
</div>
</div>

<ul id="MenuRoot" class="contextMenu">
  <li id="addRoot" class="paste">
      <a>添加根文件夹</a>
  </li>
</ul>

<ul id="ManageDir" class="contextMenu">
    <li id="addDir" class="paste">
		<a>添加目录</a>
	</li>
    <li id="editDir" class="edit">
		<a>修改目录</a>
	</li>
	<li id="deleteDir" class="delete">
		<a>删除目录</a>
	</li>
</ul>

<div id="editManage">
    <div class="top_btn_bg ">
         <h5>
         <span>
         修改类别
         </span>
         <span><img src="/Adminlvcn/1ref/controls/ImageManage/Images/close.png" alt="关闭" onclick="Manage_hide();" />
         </span>
         </h5>
    </div>
    <ul>
      <li>目录名称：</li>
      <li>
          <input id="editManageText" type="text" />
      </li>
    </ul>
    <ul>
      <li>
          <input id="editManageBut" type="button" value="确定" />
      </li>
      <li>
         <input id="editManageRes" type="button" value="重置" />
      </li>
    </ul>
</div>

<ul id="imageManage" class="contextMenu" image="0">
    <li id="imageManage_Select" class="paste">
		<a>选中</a>
	</li>
    <li id="imageManage_Delete" class="delete">
		<a>删除</a>
	</li>
	<li id="imageManage_Edit" class="edit">
		<a>修改名称</a>
	</li>
</ul>