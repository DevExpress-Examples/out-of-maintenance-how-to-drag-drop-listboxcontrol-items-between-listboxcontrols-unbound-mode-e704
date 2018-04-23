Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports DevExpress.XtraEditors

Namespace WindowsApplication596
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private WithEvents listBoxControl1 As DevExpress.XtraEditors.ListBoxControl
		Private WithEvents listBoxControl2 As DevExpress.XtraEditors.ListBoxControl
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.listBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
			Me.listBoxControl2 = New DevExpress.XtraEditors.ListBoxControl()
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.listBoxControl2, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' listBoxControl1
			' 
			Me.listBoxControl1.ItemHeight = 15
			Me.listBoxControl1.Location = New System.Drawing.Point(32, 16)
			Me.listBoxControl1.Name = "listBoxControl1"
			Me.listBoxControl1.Size = New System.Drawing.Size(248, 288)
			Me.listBoxControl1.TabIndex = 0
'			Me.listBoxControl1.MouseMove += New System.Windows.Forms.MouseEventHandler(Me.listBoxControl1_MouseMove);
'			Me.listBoxControl1.MouseDown += New System.Windows.Forms.MouseEventHandler(Me.listBoxControl1_MouseDown);
			' 
			' listBoxControl2
			' 
			Me.listBoxControl2.AllowDrop = True
			Me.listBoxControl2.ItemHeight = 15
			Me.listBoxControl2.Location = New System.Drawing.Point(360, 16)
			Me.listBoxControl2.Name = "listBoxControl2"
			Me.listBoxControl2.Size = New System.Drawing.Size(248, 288)
			Me.listBoxControl2.TabIndex = 0
'			Me.listBoxControl2.DragOver += New System.Windows.Forms.DragEventHandler(Me.listBoxControl2_DragOver);
'			Me.listBoxControl2.DragDrop += New System.Windows.Forms.DragEventHandler(Me.listBoxControl2_DragDrop);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(768, 510)
			Me.Controls.Add(Me.listBoxControl1)
			Me.Controls.Add(Me.listBoxControl2)
			Me.Name = "Form1"
			Me.Text = "How to drag/drop ListBoxControl Items between ListBoxControls"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.listBoxControl2, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.Run(New Form1())
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			For i As Integer = 0 To 9
				If i Mod 2 = 0 Then
					listBoxControl1.Items.Add("Item " & i.ToString())
				Else
					listBoxControl2.Items.Add("Item " & i.ToString())
				End If
			Next i
		End Sub

		Private p As Point = Point.Empty

		Private Sub listBoxControl1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listBoxControl1.MouseDown
			Dim c As ListBoxControl = TryCast(sender, ListBoxControl)
			p = New Point(e.X, e.Y)
			Dim selectedIndex As Integer = c.IndexFromPoint(p)
			If selectedIndex = -1 Then
				p = Point.Empty
			End If
		End Sub

		Private Sub listBoxControl1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles listBoxControl1.MouseMove
			If e.Button = MouseButtons.Left Then
				If (p <> Point.Empty) AndAlso ((Math.Abs(e.X - p.X) > 5) OrElse (Math.Abs(e.Y - p.Y) > 5)) Then
					listBoxControl1.DoDragDrop(sender, DragDropEffects.Move)
				End If
			End If
		End Sub

		Private Sub listBoxControl2_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles listBoxControl2.DragOver
			e.Effect = DragDropEffects.Move
		End Sub

		Private Sub listBoxControl2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles listBoxControl2.DragDrop
			Dim listBox As ListBoxControl = TryCast(sender, ListBoxControl)
			Dim newPoint As New Point(e.X, e.Y)
			newPoint = listBox.PointToClient(newPoint)
			Dim selectedIndex As Integer = listBox.IndexFromPoint(newPoint)
			Dim item As Object = listBoxControl1.Items(listBoxControl1.IndexFromPoint(p))
			If selectedIndex = -1 Then
				listBox.Items.Add(item)
			Else
				listBox.Items.Insert(selectedIndex, item)
			End If
		End Sub
	End Class
End Namespace
