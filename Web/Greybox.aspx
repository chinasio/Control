<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Greybox.aspx.cs" Inherits="Maticsoft.Web.Greybox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无刷新弹窗示例-Maticsoft</title>
     <script type="text/javascript">
        var GB_ROOT_DIR = "./greybox/";
    </script>
    <script type="text/javascript" src="greybox/AJS.js"></script>
    <script type="text/javascript" src="greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="greybox/gb_scripts.js"></script>
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="static_files/help.js"></script>
    <link href="static_files/help.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div >
    
    
<h3>打开单个网站：</h3>
<ul>
    <li>
    <a href="http://www.baidu.com" title="百度" rel="gb_page_center[640, 480]">打开百度</a>
        
    </li>
    <li>
        <a href="http://www.maticsoft.com/" title="Maticsoft" rel="gb_page_fs[]">全屏方式打开动软</a>
    </li>
    <li>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="http://www.google.com" runat="server">CS代码中打开网站</asp:HyperLink>
    </li>
</ul>

<h3>多网站运行</h3>
<ul>
    <li>
        <a href="http://www.baidu.com/" title="百度" rel="gb_pageset[search_sites]">打开百度</a>
    </li>
    <li>
        <a href="http://www.google.com" rel="gb_pageset[search_sites]">打开Google</a>
    </li>
    <li>
        <a href="http://search.cn.yahoo.com/" rel="gb_pageset[search_sites]">雅虎搜索</a>
    </li>
</ul>

<h3>图片显示效果</h3>
<script type="text/javascript">
var image_set = [{'caption': 'Flower', 'url': 'http://www.maticsoft.com/images/2.0/0.jpg'},
                 {'caption': 'Nice waterfall', 'url': 'http://www.maticsoft.com/images/2.0/4.jpg'}];
</script>

<ul>
    <li>
        <a href="#" onclick="return GB_showImageSet(image_set, 1)">文字方式浏览图片</a>
    </li>

    <li>
        <a href="static_files/night_valley.jpg" rel="gb_imageset[nice_pics]" title="图片1">
            <img src="static_files/night_valley_thumb.jpg" />
        </a>
    </li>

    <li>
        <a href="static_files/salt.jpg" rel="gb_imageset[nice_pics]" title="图片2">
            <img src="static_files/salt_thumb.gif" />
        </a>
    </li>
    <li>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="http://www.maticsoft.com/images/2.0/4.jpg" runat="server">CS代码中打开图片</asp:HyperLink>
    </li>
</ul>


    </div>
    </form>
</body>
</html>
