using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.DashboardWin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace CustomizeDashboardItemCaption_Viewer_Example
{
    public partial class ViewerForm1 : DevExpress.XtraEditors.XtraForm
    {
        private static bool allowExport = false;

        public ViewerForm1()
        {
            InitializeComponent();
            dashboardViewer.AllowPrintDashboardItems = true;

            dashboardViewer.PopupMenuShowing += DashboardViewer_PopupMenuShowing;
            dashboardViewer.CustomizeDashboardTitle += DashboardViewer_CustomizeDashboardTitle;
            dashboardViewer.CustomizeDashboardItemCaption += DashboardViewer_CustomizeDashboardItemCaption;
            dashboardViewer.MasterFilterSet += DashboardViewer_MasterFilterSet;

            dashboardViewer.UpdateDashboardTitle();
            UpdateDashboardItemCaptions();
        }

        private void DashboardViewer_PopupMenuShowing(object sender, DashboardPopupMenuShowingEventArgs e)
        {
            // Hide popup menu everywhere except the dashboard title, to hide commands related to the export actions. 
            if (e.DashboardArea == DashboardArea.DashboardItem)
                e.Allow = false;
        }
        
        private void DashboardViewer_MasterFilterSet(object sender, MasterFilterSetEventArgs e)
        {
            if (e.DashboardItemName == "listBoxDashboardItem1")
                allowExport = e.SelectedValues.Select(value => value[0].ToString()).Contains("Bikes") ? false : true;
            UpdateDashboardItemCaptions();
            dashboardViewer.UpdateDashboardTitle();
        }

        private void DashboardViewer_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
        {
            DashboardViewer viewer = (DashboardViewer)sender;

            // Display filtered dimensions.
            List<string> filteredDimensions = new List<string>();
            foreach (var item in viewer.Dashboard.Items) {
                string dimensionName = String.Empty;
                var filterValues = viewer.GetCurrentFilterValues(item.ComponentName);
                if (filterValues != null)
                    if (filterValues.Count > 0)
                    {
                        dimensionName = String.Concat(filterValues.Select(
                            axp => String.Format("{0} ", axp.GetAxisPoint(axp.AvailableAxisNames[0]).Dimension.Name)).Distinct());
                        filteredDimensions.Add(dimensionName);
                    }
            }
            if (filteredDimensions.Count > 0)
                e.FilterText = String.Format(" ( Filtered by: {0})", String.Concat(filteredDimensions));

            // Remove the Export button depending on the static variable.
            if (!allowExport)
            {
                RemoveExportButton(e.Items);
            }

            // Add drop-down menu to show/hide dashboard item captions.
            DashboardToolbarItem toolbarItemRoot = new DashboardToolbarItem();
            toolbarItemRoot.Caption = "Show Dashboard Item Captions";
            //var itemNames = viewer.Dashboard.Items.Select(i => i.Name);
            foreach (var item in viewer.Dashboard.Items)
            {
                toolbarItemRoot.MenuItems.Add(new DashboardToolbarMenuItem(item.ShowCaption, item.Name,
                    new Action<DashboardToolbarItemClickEventArgs>((args) => {
                        item.ShowCaption = !item.ShowCaption;
                    })));
            }
            e.Items.Insert(0, toolbarItemRoot);


            // Add a button with an image to navigate to this example online.
            DashboardToolbarItem infoLinkItem = new DashboardToolbarItem("",
                new Action<DashboardToolbarItemClickEventArgs>((args) => {
                    System.Diagnostics.Process.Start("https://www.devexpress.com/Support/Center/Example/Details/T630210/");
                }));
            // Note that a raster image is proportionally resized to 24 px height when displayed in the Title area.
            //infoLinkItem.ButtonImage = Image.FromFile("KnowledgeBaseArticle_32x32.png");
            infoLinkItem.SvgImage = svgImageCollection1["support"];
            e.Items.Add(infoLinkItem);
        }

        private void DashboardViewer_CustomizeDashboardItemCaption(object sender, CustomizeDashboardItemCaptionEventArgs e)
        {
            // Remove the Export button depending on the static variable.
            if (!allowExport)
            {
                    if (!e.DashboardItemName.Contains("Map"))
                    {
                        RemoveExportButton(e.Items);
                    }
                }

            // Display filter values.
            DashboardViewer viewer = (DashboardViewer)sender;
            var filterValues = viewer.GetCurrentFilterValues(e.DashboardItemName);
            if (filterValues != null)
                if (filterValues.Count > 0)
            e.FilterText = String.Format(" ( Filter: {0})", string.Concat(filterValues.Select(
                axp => String.Format("{0} ", axp.GetAxisPoint(axp.AvailableAxisNames[0]).DisplayText)).ToArray()));

        }

        private void UpdateDashboardItemCaptions()
        {
            foreach (DashboardItem i in dashboardViewer.Dashboard.Items)
            {
                dashboardViewer.UpdateDashboardItemCaption(i.ComponentName);
            }
        }

        private void RemoveExportButton(IList<DashboardToolbarItem> items)
        {
            var exportItem = items.FirstOrDefault(i => i.ButtonType == DashboardButtonType.Export);
            if (exportItem != null)
            {
                items.Remove(exportItem);
            }
        }
    }
}
