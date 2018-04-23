Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxTreeList
Imports System.Collections.Generic

Namespace ReorderNodes
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Overrides Sub OnInit(ByVal e As EventArgs)
			MyBase.OnInit(e)
			ASPxTreeList1.DataSource = Data
			ASPxTreeList1.DataBind()
		End Sub

		Private ReadOnly Property Data() As List(Of SampleDataItem)
			Get
				Const key As String = "TreeListData"
				If Session(key) Is Nothing Then
					Session(key) = CreateData()
				End If
				Return CType(Session(key), List(Of SampleDataItem))
			End Get
		End Property

		Private Function CreateData() As List(Of SampleDataItem)
			Dim result As New List(Of SampleDataItem)()
			result.Add(New SampleDataItem(Guid.NewGuid(), Guid.Empty, "root", 0))
			result.Add(New SampleDataItem(result(0), "a", 1))
			result.Add(New SampleDataItem(result(0), "b", 2))
			result.Add(New SampleDataItem(result(1), "a1", 3))
			result.Add(New SampleDataItem(result(1), "a2", 4))
			result.Add(New SampleDataItem(result(1), "a3", 5))
			result.Add(New SampleDataItem(result(2), "b1", 6))
			result.Add(New SampleDataItem(result(2), "b2", 7))
			result.Add(New SampleDataItem(result(6), "b1a", 8))
			result.Add(New SampleDataItem(result(6), "b1b", 9))
			result.Add(New SampleDataItem(result(6), "b1c", 10))
			Return result
		End Function

		Private Sub SwapNodes(ByVal node1 As TreeListNode, ByVal node2 As TreeListNode)
			If node1 Is Nothing OrElse node2 Is Nothing Then
				Return
			End If
			Dim item1 As SampleDataItem = TryCast(node1.DataItem, SampleDataItem)
			Dim item2 As SampleDataItem = TryCast(node2.DataItem, SampleDataItem)
			Dim index1 As Integer = Data.IndexOf(item1)
			Dim index2 As Integer = Data.IndexOf(item2)
			Data(index1) = item2
			Data(index2) = item1
		End Sub

		' drag-and-drop to reorder nodes
		Protected Sub ASPxTreeList1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs)
			Dim tl As ASPxTreeList = CType(sender, ASPxTreeList)
			If e.Argument.StartsWith("reorder:") Then
				Dim arg() As String = e.Argument.Split(":"c)
				SwapNodes(tl.FindNodeByKeyValue(arg(1)), tl.FindNodeByKeyValue(arg(2)))
				tl.DataBind()
			End If
		End Sub

		' drag-and-drop to a new parent node
		Protected Sub ASPxTreeList1_ProcessDragNode(ByVal sender As Object, ByVal e As TreeListNodeDragEventArgs)
			Dim child As SampleDataItem = TryCast(e.Node.DataItem, SampleDataItem)
			Dim newParent As SampleDataItem = TryCast(e.NewParentNode.DataItem, SampleDataItem)
			child.Parent = newParent.Pk
			e.Handled = True
		End Sub

	End Class
End Namespace
