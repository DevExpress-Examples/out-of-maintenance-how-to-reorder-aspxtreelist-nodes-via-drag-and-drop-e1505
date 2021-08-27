<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1505)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ReorderNodes/Default.aspx) (VB: [Default.aspx](./VB/ReorderNodes/Default.aspx))
* [Default.aspx.cs](./CS/ReorderNodes/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ReorderNodes/Default.aspx.vb))
* [SampleDataItem.cs](./CS/ReorderNodes/SampleDataItem.cs) (VB: [SampleDataItem.vb](./VB/ReorderNodes/SampleDataItem.vb))
<!-- default file list end -->
# How to reorder ASPxTreeList nodes via drag-and-drop


<p>The example demonstrates how to swap sibling nodes by dragging them within its parent node. To implement this functionality, handle the client <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxTreeListScriptsASPxClientTreeList_EndDragNodetopic"><u>EndDragNode</u></a> event, send a custom callback and process the callback on the server to reorder records in the data source.</p>

<br/>


