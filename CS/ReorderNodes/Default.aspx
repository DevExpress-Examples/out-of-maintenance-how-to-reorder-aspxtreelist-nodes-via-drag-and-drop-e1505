<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReorderNodes._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to reorder ASPxTreeList nodes via drag-and-drop</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Keep the Shift key pressed to reorder nodes via drag-and-drop
        <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" AutoGenerateColumns="False"
            ClientInstanceName="treelist" KeyFieldName="Pk" OnCustomCallback="ASPxTreeList1_CustomCallback"
            ParentFieldName="Parent" OnProcessDragNode="ASPxTreeList1_ProcessDragNode" Width="227px">
            <ClientSideEvents EndDragNode="function(s, e) {
	if(e.htmlEvent.shiftKey){
		e.cancel = true;
		var key = s.GetNodeKeyByRow(e.targetElement);
		treelist.PerformCustomCallback('reorder'+':'+e.nodeKey+':'+key);
	}
}" />
            <SettingsEditing AllowNodeDragDrop="True" />
            <Columns>
                <dxwtl:TreeListTextColumn FieldName="Title" VisibleIndex="0">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn FieldName="Quantity" VisibleIndex="1">
                </dxwtl:TreeListTextColumn>
            </Columns>
        </dxwtl:ASPxTreeList>
    </div>
    </form>
</body>
</html>
