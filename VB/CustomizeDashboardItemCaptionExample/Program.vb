Imports System
Imports System.Windows.Forms
Imports DevExpress.UserSkins
Imports DevExpress.Skins

Namespace CustomizeDashboardItemCaption_Viewer_Example

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call BonusSkins.Register()
            Call SkinManager.EnableFormSkins()
            Call Application.Run(New ViewerForm1())
        End Sub
    End Module
End Namespace
