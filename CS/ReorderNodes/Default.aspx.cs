using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxTreeList;
using System.Collections.Generic;

namespace ReorderNodes {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            ASPxTreeList1.DataSource = Data;
            ASPxTreeList1.DataBind();
        }

        List<SampleDataItem> Data {
            get {
                const string key = "TreeListData";
                if(Session[key] == null)
                    Session[key] = CreateData();
                return (List<SampleDataItem>)Session[key];
            }
        }

        List<SampleDataItem> CreateData() {
            List<SampleDataItem> result = new List<SampleDataItem>();
            result.Add(new SampleDataItem(Guid.NewGuid(), Guid.Empty, "root", 0));
            result.Add(new SampleDataItem(result[0], "a", 1));
            result.Add(new SampleDataItem(result[0], "b", 2));
            result.Add(new SampleDataItem(result[1], "a1", 3));
            result.Add(new SampleDataItem(result[1], "a2", 4));
            result.Add(new SampleDataItem(result[1], "a3", 5));
            result.Add(new SampleDataItem(result[2], "b1", 6));
            result.Add(new SampleDataItem(result[2], "b2", 7));
            result.Add(new SampleDataItem(result[6], "b1a", 8));
            result.Add(new SampleDataItem(result[6], "b1b", 9));
            result.Add(new SampleDataItem(result[6], "b1c", 10));
            return result;
        }

        void SwapNodes(TreeListNode node1, TreeListNode node2) {
            if(node1 == null || node2 == null) return;
            SampleDataItem item1 = node1.DataItem as SampleDataItem;
            SampleDataItem item2 = node2.DataItem as SampleDataItem;
            int index1 = Data.IndexOf(item1);
            int index2 = Data.IndexOf(item2);
            Data[index1] = item2;
            Data[index2] = item1;
        }

        // drag-and-drop to reorder nodes
        protected void ASPxTreeList1_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e) {
            ASPxTreeList tl = (ASPxTreeList)sender;
            if(e.Argument.StartsWith("reorder:")) {
                string[] arg = e.Argument.Split(':');
                SwapNodes(tl.FindNodeByKeyValue(arg[1]), tl.FindNodeByKeyValue(arg[2]));
                tl.DataBind();
            }
        }

        // drag-and-drop to a new parent node
        protected void ASPxTreeList1_ProcessDragNode(object sender, TreeListNodeDragEventArgs e) {
            SampleDataItem child = e.Node.DataItem as SampleDataItem;
            SampleDataItem newParent = e.NewParentNode.DataItem as SampleDataItem;
            child.Parent = newParent.Pk;
            e.Handled = true;
        }

    }
}
