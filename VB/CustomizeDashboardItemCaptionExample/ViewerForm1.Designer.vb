Namespace CustomizeDashboardItemCaption_Viewer_Example

    Partial Class ViewerForm1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
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
            CType((Me.svgImageCollection1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.dashboardViewer), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' svgImageCollection1
            ' 
            Me.svgImageCollection1.Add("support", "image://svgimages/outlook inspired/support.svg")
            Me.svgImageCollection1.Add("title", "image://svgimages/dashboards/title.svg")
            ' 
            ' dashboardViewer
            ' 
            Me.dashboardViewer.Appearance.BackColor = System.Drawing.Color.FromArgb((CInt(((CByte((235)))))), (CInt(((CByte((236)))))), (CInt(((CByte((239)))))))
            Me.dashboardViewer.Appearance.Options.UseBackColor = True
            Me.dashboardViewer.DashboardSource = GetType(CustomizeDashboardItemCaption_Viewer_Example.SampleDashboard)
            Me.dashboardViewer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dashboardViewer.Location = New System.Drawing.Point(0, 0)
            Me.dashboardViewer.Name = "dashboardViewer"
            Me.dashboardViewer.Size = New System.Drawing.Size(986, 628)
            Me.dashboardViewer.TabIndex = 0
            ' 
            ' ViewerForm1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(986, 628)
            Me.Controls.Add(Me.dashboardViewer)
            Me.Name = "ViewerForm1"
            Me.Text = "Dashboard Viewer"
            CType((Me.svgImageCollection1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.dashboardViewer), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private dashboardViewer As DevExpress.DashboardWin.DashboardViewer

        Private svgImageCollection1 As DevExpress.Utils.SvgImageCollection
    End Class
End Namespace
