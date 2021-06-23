# Dashboard for WinForms - How to Customize the Dashboard Title and Dashboard Item Captions

This example demonstrates how to handle the [DashboardViewer](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer) events to modify dashboard title and dashboard item captions. You can add or remove command buttons and display a text.

| Event | Dashboard Element |
| --- | --- |
| [CustomizeDashboardTitle](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.CustomizeDashboardTitle) | [Dashboard Title](https://docs.devexpress.com/Dashboard/15618) |
| [CustomizeDashboardItemCaption](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardViewer.CustomizeDashboardItemCaption) | [Dashboard Item Caption](https://docs.devexpress.com/Dashboard/15620)

The **dashboard title** displays the dimensions and values by which the dashboard data is filtered. You can use a drop-down menu to selectively hide dashboard item captions. Clicking a custom Support button navigates to this example online.

A **dashboard item caption** displays the item's master filter values.

Export buttons are hidden for all dashboard items except the map, and for the entire dashboard, if the displayed data's Category field contains "Bikes".

![screenshot](/images/screenshot.png)

## Documentation

- [Title and Item Captions](https://docs.devexpress.com/Dashboard/401132/winforms-dashboard/winforms-viewer/title-and-item-captions)

## More Examples

- [WinForms Dashboard Viewer - How to Add a Command Button to the Dashboard Title and Item Caption](https://github.com/DevExpress-Examples/winforms-dashboard-custom-command-buttons)
- [WinForms Dashboard Designer - How to delay data load until all filters are set](https://github.com/DevExpress-Examples/winforms-dashboard-how-to-delay-data-load-until-all-filters-are-set-t629796)
