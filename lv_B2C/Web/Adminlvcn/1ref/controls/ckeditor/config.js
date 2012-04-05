/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    config.width = 820;
    config.height = 200;
    config.resize_enabled = false;
    //工具栏（基础'Basic'、全能'Full'、自定义）
    config.toolbar = 'Full';
    config.toolbar_Full = [
       ['Undo', 'Redo'],
       ['Image', 'Flash', 'Table'],
       ['Font', 'FontSize', 'TextColor', 'BGColor'],
       ['Bold', 'Italic', 'Underline', 'Strike'],
       ['JustifyLeft', 'JustifyCenter', 'JustifyRight'],
       ['NumberedList', 'BulletedList'],
       ['Link', 'Unlink'],       
       ['RemoveFormat'], 
       ['Source']
    ];    
};
