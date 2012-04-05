var messageid;
function waitClick() {
    messageid = mini.loading("正在加载，请稍候...", "加载中");
}
function iframeLoad() {
    mini.hideMessageBox(messageid);
}
function onNodeSelect() {
    
}