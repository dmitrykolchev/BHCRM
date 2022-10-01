using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DykBits.Crm.Input
{
    public enum UICommandId
    {
        None,
        Create,
        CreateContact,
        Save,
        SaveAndClose,
        Open,
        Refresh,
        ShowProperties,
        Delete,
        CloseWindow,
        OK,
        Cancel,
        Default,
        ExportToExcel,
        ChangeDocumentState,
        ActivateView,
        SetTheme,
        AddRow,
        AddGroup,
        AddEmptyRow,
        EditRow,
        DeleteRow,
        ViewFilter,
        ExpandAllGroups,
        CollapseAllGroups,
        SortAscending,
        SortDescending,
        SortDialog,
        SaveLayout,
        RestoreLayout,
        ResetLayout,
        Print,
        PrintPreview,
        OpenAttachment,
        SaveAttachment,
        DeleteAttachment,
        Find,
        RecreatePresentation,
        Cut,
        Copy,
        Paste,
        MoveUp,
        MoveDown,
        OpenNotificationDocument,
        DeleteNotification,
        RefreshDetails,
        ApplyFilter,
        ClearAll
    }
    public static class CrmApplicationCommands
    {
        private static readonly UICommand CreateCommand = new UICommand(UICommandId.Create, typeof(CrmApplicationCommands));
        private static readonly UICommand CreateContactCommand = new UICommand(UICommandId.CreateContact, typeof(CrmApplicationCommands));
        private static readonly UICommand SaveCommand = new UICommand(UICommandId.Save, typeof(CrmApplicationCommands));
        private static readonly UICommand SaveAndCloseCommand = new UICommand(UICommandId.SaveAndClose, typeof(CrmApplicationCommands));
        private static readonly UICommand CloseWindowCommand = new UICommand(UICommandId.CloseWindow, typeof(CrmApplicationCommands));
        private static readonly UICommand OpenCommand = new UICommand(UICommandId.Open, typeof(CrmApplicationCommands));
        private static readonly UICommand RefreshCommand = new UICommand(UICommandId.Refresh, typeof(CrmApplicationCommands));
        private static readonly UICommand RefreshDetailsCommand = new UICommand(UICommandId.RefreshDetails, typeof(CrmApplicationCommands));
        private static readonly UICommand PropertiesCommand = new UICommand(UICommandId.ShowProperties, typeof(CrmApplicationCommands));
        private static readonly UICommand DeleteCommand = new UICommand(UICommandId.Delete, typeof(CrmApplicationCommands));
        private static readonly UICommand OKCommand = new UICommand(UICommandId.OK, typeof(CrmApplicationCommands));
        private static readonly UICommand CancelCommand = new UICommand(UICommandId.Cancel, typeof(CrmApplicationCommands));
        private static readonly UICommand DefaultCommand = new UICommand(UICommandId.Default, typeof(CrmApplicationCommands));
        private static readonly UICommand ExportToExcelCommand = new UICommand(UICommandId.ExportToExcel, typeof(CrmApplicationCommands));
        private static readonly UICommand ChangeDocumentStateCommand = new UICommand(UICommandId.ChangeDocumentState, typeof(CrmApplicationCommands));
        private static readonly UICommand ActivateViewCommand = new UICommand(UICommandId.ActivateView, typeof(CrmApplicationCommands));
        private static readonly UICommand SetThemeCommand = new UICommand(UICommandId.SetTheme, typeof(CrmApplicationCommands));
        private static readonly UICommand AddRowCommand = new UICommand(UICommandId.AddRow, typeof(CrmApplicationCommands));
        private static readonly UICommand AddEmptyRowCommand = new UICommand(UICommandId.AddEmptyRow, typeof(CrmApplicationCommands));
        private static readonly UICommand EditRowCommand = new UICommand(UICommandId.EditRow, typeof(CrmApplicationCommands));
        private static readonly UICommand DeleteRowCommand = new UICommand(UICommandId.DeleteRow, typeof(CrmApplicationCommands));
        private static readonly UICommand ViewFilterCommand = new UICommand(UICommandId.ViewFilter, typeof(CrmApplicationCommands));
        private static readonly UICommand ExpandAllGroupsCommand = new UICommand(UICommandId.ExpandAllGroups, typeof(CrmApplicationCommands));
        private static readonly UICommand CollapseAllGroupsCommand = new UICommand(UICommandId.CollapseAllGroups, typeof(CrmApplicationCommands));
        private static readonly UICommand SortAscendingCommand = new UICommand(UICommandId.SortAscending, typeof(CrmApplicationCommands));
        private static readonly UICommand SortDescendingCommand = new UICommand(UICommandId.SortDescending, typeof(CrmApplicationCommands));
        private static readonly UICommand SortDialogCommand = new UICommand(UICommandId.SortDialog, typeof(CrmApplicationCommands));
        private static readonly UICommand SaveLayoutCommand = new UICommand(UICommandId.SaveLayout, typeof(CrmApplicationCommands));
        private static readonly UICommand RestoreLayoutCommand = new UICommand(UICommandId.RestoreLayout, typeof(CrmApplicationCommands));
        private static readonly UICommand ResetLayoutCommand = new UICommand(UICommandId.ResetLayout, typeof(CrmApplicationCommands));
        private static readonly UICommand PrintCommand = new UICommand(UICommandId.Print, typeof(CrmApplicationCommands));
        private static readonly UICommand PrintPreviewCommand = new UICommand(UICommandId.PrintPreview, typeof(CrmApplicationCommands));
        private static readonly UICommand OpenAttachmentCommand = new UICommand(UICommandId.OpenAttachment, typeof(CrmApplicationCommands));
        private static readonly UICommand SaveAttachmentCommand = new UICommand(UICommandId.SaveAttachment, typeof(CrmApplicationCommands));
        private static readonly UICommand DeleteAttachmentCommand = new UICommand(UICommandId.DeleteAttachment, typeof(CrmApplicationCommands));
        private static readonly UICommand FindCommand = new UICommand(UICommandId.Find, typeof(CrmApplicationCommands));
        private static readonly UICommand RecreatePresentationCommand = new UICommand(UICommandId.RecreatePresentation, typeof(CrmApplicationCommands));
        private static readonly UICommand CutCommand = new UICommand(UICommandId.Cut, typeof(CrmApplicationCommands));
        private static readonly UICommand CopyCommand = new UICommand(UICommandId.Copy, typeof(CrmApplicationCommands));
        private static readonly UICommand PasteCommand = new UICommand(UICommandId.Paste, typeof(CrmApplicationCommands));
        private static readonly UICommand MoveUpCommand = new UICommand(UICommandId.MoveUp, typeof(CrmApplicationCommands));
        private static readonly UICommand MoveDownCommand = new UICommand(UICommandId.MoveDown, typeof(CrmApplicationCommands));
        private static readonly UICommand OpenNotificationDocumentCommand = new UICommand(UICommandId.OpenNotificationDocument, typeof(CrmApplicationCommands));
        private static readonly UICommand DeleteNotificationCommand = new UICommand(UICommandId.DeleteNotification, typeof(CrmApplicationCommands));
        private static readonly UICommand AddGroupCommand = new UICommand(UICommandId.AddGroup, typeof(CrmApplicationCommands));
        private static readonly UICommand ApplyFilterCommand = new UICommand(UICommandId.ApplyFilter, typeof(CrmApplicationCommands));
        private static readonly UICommand ClearAllCommand = new UICommand(UICommandId.ClearAll, typeof(CrmApplicationCommands));
        public static UICommand ClearAll
        {
            get { return ClearAllCommand; }
        }
        public static UICommand ApplyFilter
        {
            get { return ApplyFilterCommand; }
        }
        public static UICommand OpenNotificationDocument
        {
            get { return OpenNotificationDocumentCommand; }
        }
        public static UICommand DeleteNotification
        {
            get { return DeleteNotificationCommand; }
        }
        public static UICommand CreateContact
        {
            get { return CreateContactCommand; }
        }
        public static UICommand SaveLayout
        {
            get { return SaveLayoutCommand; }
        }
        public static UICommand RestoreLayout
        {
            get { return RestoreLayoutCommand; }
        }
        public static UICommand ResetLayout
        {
            get { return ResetLayoutCommand; }
        }
        public static UICommand SortDialog
        {
            get { return SortDialogCommand; }
        }
        public static UICommand SortAscending
        {
            get { return SortAscendingCommand; }
        }
        public static UICommand SortDescending
        {
            get { return SortDescendingCommand; }
        }
        public static UICommand ExpandAllGroups
        {
            get { return ExpandAllGroupsCommand; }
        }

        public static UICommand CollapseAllGroups
        {
            get { return CollapseAllGroupsCommand; }
        }

        public static UICommand ViewFilter
        {
            get { return ViewFilterCommand; }
        }

        public static UICommand SetTheme
        {
            get { return SetThemeCommand; }
        }

        public static UICommand ActivateView
        {
            get { return ActivateViewCommand; }
        }

        public static UICommand CloseWindow
        {
            get { return CloseWindowCommand; }
        }

        public static UICommand Save
        {
            get { return SaveCommand; }
        }
        public static UICommand SaveAndClose
        {
            get { return SaveAndCloseCommand; }
        }
        public static UICommand Create
        {
            get { return CreateCommand; }
        }

        public static UICommand Open
        {
            get { return OpenCommand; }
        }
        public static UICommand Refresh
        {
            get { return RefreshCommand; }
        }
        public static UICommand RefreshDetails
        {
            get { return RefreshDetailsCommand; }
        }
        public static UICommand Properties
        {
            get { return PropertiesCommand; }
        }
        public static UICommand Delete
        {
            get { return DeleteCommand; }
        }
        public static UICommand OK
        {
            get { return OKCommand; }
        }
        public static UICommand Cancel
        {
            get { return CancelCommand; }
        }
        public static UICommand Default
        {
            get { return DefaultCommand; }
        }
        public static UICommand ExportToExcel
        {
            get { return ExportToExcelCommand; }
        }
        public static UICommand ChangeDocumentState
        {
            get { return ChangeDocumentStateCommand; }
        }
        public static UICommand AddRow
        {
            get { return AddRowCommand; }
        }
        public static UICommand AddEmptyRow
        {
            get { return AddEmptyRowCommand; }
        }
        public static UICommand EditRow
        {
            get { return EditRowCommand; }
        }
        public static UICommand DeleteRow
        {
            get { return DeleteRowCommand; }
        }
        public static UICommand Print
        {
            get { return PrintCommand; }
        }
        public static UICommand PrintPreview
        {
            get { return PrintPreviewCommand; }
        }

        public static UICommand OpenAttachment
        {
            get { return OpenAttachmentCommand; }
        }
        public static UICommand SaveAttachment
        {
            get { return SaveAttachmentCommand; }
        }
        public static UICommand DeleteAttachment
        {
            get { return DeleteAttachmentCommand; }
        }
        public static UICommand Find
        {
            get { return FindCommand; }
        }
        public static UICommand Cut
        {
            get { return CutCommand; }
        }
        public static UICommand Copy
        {
            get { return CopyCommand; }
        }
        public static UICommand Paste
        {
            get { return PasteCommand; }
        }
        public static UICommand MoveUp
        {
            get { return MoveUpCommand; }
        }
        public static UICommand MoveDown
        {
            get { return MoveDownCommand; }
        }
        public static UICommand RecreatePresentation
        {
            get { return RecreatePresentationCommand; }
        }
        public static UICommand AddGroup
        {
            get { return AddGroupCommand; }
        }
    }
}
