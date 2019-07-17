Namespace CustomizeDashboardItemCaption_Viewer_Example
	Partial Public Class ViewerForm1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.svgImageCollection1 = New DevExpress.Utils.SvgImageCollection(Me.components)
			Me.dashboardViewer = New DevExpress.DashboardWin.DashboardViewer(Me.components)
			DirectCast(Me.svgImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.dashboardViewer, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' svgImageCollection1
			' 
			Me.svgImageCollection1.Add("support", "image://svgimages/outlook inspired/support.svg")
			Me.svgImageCollection1.Add("title", "image://svgimages/dashboards/title.svg")
			' 
			' dashboardViewer
			' 
			Me.dashboardViewer.Appearance.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(242)))), (CInt((CByte(242)))), (CInt((CByte(242)))))
			Me.dashboardViewer.Appearance.Options.UseBackColor = True
			Me.dashboardViewer.DashboardSource = GetType(CustomizeDashboardItemCaption_Viewer_Example.SampleDashboard)
			Me.dashboardViewer.Dock = System.Windows.Forms.DockStyle.Fill
			Me.dashboardViewer.Location = New System.Drawing.Point(0, 0)
			Me.dashboardViewer.Name = "dashboardViewer"
			Me.dashboardViewer.Size = New System.Drawing.Size(800, 570)
			Me.dashboardViewer.TabIndex = 0
			' 
			' ViewerForm1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(800, 570)
			Me.Controls.Add(Me.dashboardViewer)
			Me.Name = "ViewerForm1"
			Me.Text = "Dashboard Viewer"
			DirectCast(Me.svgImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.dashboardViewer, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private dashboardViewer As DevExpress.DashboardWin.DashboardViewer
		Private svgImageCollection1 As DevExpress.Utils.SvgImageCollection
	End Class
End Namespace

