using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.DashboardWin;
using System;
using System.Collections.Generic;
using System.Data;
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

            dashboardViewer.CustomizeDashboardTitle += DashboardViewer_CustomizeDashboardTitle;
            dashboardViewer.CustomizeDashboardItemCaption += DashboardViewer_CustomizeDashboardItemCaption;

            dashboardViewer.PopupMenuShowing += DashboardViewer_PopupMenuShowing;
            dashboardViewer.MasterFilterSet += DashboardViewer_MasterFilterSet;

            dashboardViewer.UpdateDashboardTitle();
            UpdateDashboardItemCaptions();
        }

        private void DashboardViewer_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
        {
            DashboardViewer viewer = (DashboardViewer)sender;

            // Display a string of master filter values.
            string filterText = string.Empty;
            foreach (var item in viewer.Dashboard.Items)
            {
                if (viewer.CanSetMasterFilter(item.ComponentName))
                {
                    var filterValues = viewer.GetCurrentFilterValues(item.ComponentName);
                    filterText += GetFilterText(filterValues);
                }
            }
            DashboardToolbarItem toolbarItem = new DashboardToolbarItem();
            toolbarItem.Caption = "Filter: " + filterText;
            e.Items.Insert(0, toolbarItem);


            // Remove the Export button depending on the static variable.
            if (!allowExport)
            {
                RemoveExportButton(e.Items);
            }

            // Add drop-down menu to show/hide dashboard item captions.
            DashboardToolbarItem toolbarItemRoot = new DashboardToolbarItem();
            toolbarItemRoot.Caption = @"Show/Hide Dashboard Item Captions";
            toolbarItemRoot.SvgImage = svgImageCollection1["title"];
            foreach (var item in viewer.Dashboard.Items)
            {
                DashboardToolbarMenuItem menuItem = new DashboardToolbarMenuItem(item.ShowCaption, item.Name,
                    new Action<DashboardToolbarItemClickEventArgs>((args) =>
                    {
                        item.ShowCaption = !item.ShowCaption;
                    }));
                menuItem.ImageOptions.SvgImage = svgImageCollection1["title"];
                toolbarItemRoot.MenuItems.Add(menuItem);
            }
            e.Items.Insert(0, toolbarItemRoot);


            // Add a button with an image to navigate to this example online.
            DashboardToolbarItem infoLinkItem = new DashboardToolbarItem("",
                new Action<DashboardToolbarItemClickEventArgs>((args) => {
                    System.Diagnostics.Process.Start("https://www.devexpress.com/Support/Center/Example/Details/T630210/");
                }));
            // Note that a raster image is proportionally resized to 24 px height when displayed in the Title area.
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
                    e.FilterText = string.Format(" ( Filter: {0})", string.Concat(filterValues.Select(
                        axp => string.Format("{0} ", axp.GetAxisPoint(axp.AvailableAxisNames[0]).DisplayText)).ToArray()));

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
        private string GetFilterText(IList<AxisPointTuple> filterValues)
        {
            string filterText = string.Empty;
            if (filterValues.Count > 0)
            {
                string dimensionName = string.Concat(filterValues.Select(
                    axp => string.Format("{0} ", axp.GetAxisPoint(axp.AvailableAxisNames[0]).Dimension.Name)).Distinct());
                filterText = string.Format(" ({0}:{1})", dimensionName, string.Join(",", filterValues.Select(
                    axp => string.Format(" {0}", axp.GetAxisPoint(axp.AvailableAxisNames[0]).DisplayText)).ToArray()));
            }
            return filterText;
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
