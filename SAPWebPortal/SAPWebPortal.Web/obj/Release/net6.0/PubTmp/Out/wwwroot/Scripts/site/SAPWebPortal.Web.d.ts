/// <reference path="../../../Modules/_Ext/_q/_q.d.ts" />
/// <reference path="../../../typings/jspdf/jspdf.autotable.d.ts" />
/// <reference types="serenity.corelib" />
/// <reference types="serenity.pro.ui" />
/// <reference types="jquery" />
/// <reference types="jqueryui" />
/// <reference types="jquery.validation" />
/// <reference types="serenity.pro.extensions" />
declare var isPageRefreshRequired: boolean;
declare namespace q {
    var queryString: {};
    var jsPDFHeaderImageData: string;
    var jsPDFHeaderTitle: string;
    var ListExcelServiceMethodName: string;
    var useSerenityInlineEditors: boolean;
    var DefaultMainGridOptions: ExtGridOptions;
    var DefaultEditorGridOptions: ExtGridOptions;
    var DefaultEntityDialogOptions: ExtDialogOptions;
    var DefaultEditorDialogOptions: ExtDialogOptions;
    var fiscalYearMonths: number[];
}
declare namespace _Ext {
    class GridBase<TItem, TOptions> extends Serenity.EntityGrid<TItem, TOptions> {
        protected getRowType(): {
            idProperty?: string;
            localTextPrefix?: string;
            nameProperty?: string;
            insertPermission?: string;
            updatePermission?: string;
            deletePermission?: string;
        };
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected getDeletePermission(): string;
        protected get_ExtGridOptions(): ExtGridOptions;
        protected isPickerMode(): boolean;
        protected getGrouping(): Slick.GroupInfo<TItem>[];
        isReadOnly: boolean;
        isRequired: boolean;
        isAutosized: boolean;
        isChildGrid: boolean;
        nextRowNumber: number;
        autoColumnSizePlugin: any;
        rowSelection: Serenity.GridRowSelectionMixin;
        pickerDialog: GridItemPickerDialog;
        constructor(container: JQuery, options?: TOptions);
        protected markupReady(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getReportRequest(): _Ext.ListReportRequest;
        protected getColumns(): Slick.Column[];
        protected createSlickGrid(): Slick.Grid;
        resetColumns(columns: Slick.Column[]): void;
        resizeAllCulumn(): void;
        protected getSlickOptions(): Slick.GridOptions;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPrintRowServiceMethod(): string;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected onInlineActionClick(target: JQuery, recordId: any, item: TItem): void;
        protected resetRowNumber(): void;
        setGrouping(groupInfo: Slick.GroupInfo<TItem>[]): void;
        protected getIncludeColumns(include: {
            [key: string]: boolean;
        }): void;
        protected getDefaultSortBy(): any[];
        protected onViewProcessData(response: Serenity.ListResponse<TItem>): Serenity.ListResponse<TItem>;
        initDialog(dialog: DialogBase<TItem, any>): void;
        get selectedItems(): TItem[];
        set selectedKeys(value: any[]);
        protected onViewSubmit(): boolean;
    }
    class GridBase1<TItem, TOptions> extends Serenity.EntityGrid<TItem, TOptions> {
        protected get_ExtGridOptions(): ExtGridOptions;
        protected isPickerMode(): boolean;
        isReadOnly: boolean;
        isRequired: boolean;
        isAutosized: boolean;
        isChildGrid: boolean;
        nextRowNumber: number;
        autoColumnSizePlugin: any;
        rowSelection: Serenity.GridRowSelectionMixin;
        pickerDialog: GridItemPickerDialog;
        constructor(container: JQuery, options?: TOptions);
        protected markupReady(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getReportRequest(): _Ext.ListReportRequest;
        protected getColumns(): Slick.Column[];
        protected createSlickGrid(): Slick.Grid;
        resetColumns(columns: Slick.Column[]): void;
        resizeAllCulumn(): void;
        protected getSlickOptions(): Slick.GridOptions;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPrintRowServiceMethod(): string;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected onInlineActionClick(target: JQuery, recordId: any, item: TItem): void;
        protected resetRowNumber(): void;
        protected setGrouping(groupInfo: Slick.GroupInfo<TItem>[]): void;
        protected onViewProcessData(response: Serenity.ListResponse<TItem>): Serenity.ListResponse<TItem>;
        initDialog(dialog: DialogBase<TItem, any>): void;
        get selectedItems(): TItem[];
        set selectedKeys(value: any[]);
        protected onViewSubmit(): boolean;
    }
}
declare namespace _Ext {
    class ReportGridBase<TItem, TOptions> extends _Ext.GridBase<TItem, TOptions> {
        protected getButtons(): Serenity.ToolButton[];
        protected getColumns(): Slick.Column[];
    }
}
declare namespace _Ext {
    class ReportPanelBase<TRequest> extends Serenity.PropertyPanel<TRequest, any> {
        protected getReportTitle(): string;
        protected getReportKey(): string;
        protected getReportRequest(): TRequest;
        constructor(container: JQuery, opt?: any);
        protected getTemplate(): string;
    }
}
declare namespace _Ext {
    class DialogBase<TEntity, TOptions> extends Serenity.EntityDialog<TEntity, TOptions> {
        protected getRowType(): {
            idProperty?: string;
            localTextPrefix?: string;
            nameProperty?: string;
            insertPermission?: string;
            updatePermission?: string;
            deletePermission?: string;
        };
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected getDeletePermission(): string;
        protected get_ExtDialogOptions(): ExtDialogOptions;
        protected loadedState: string;
        isReadOnly: boolean;
        protected form: any;
        constructor(opt?: any);
        protected updateInterface(): void;
        protected onDialogOpen(): void;
        protected onDialogClose(): void;
        protected setReadOnly(value: boolean): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected onRefreshClick(): void;
        protected onSaveAndNewButtonClick(): void;
        protected getSaveState(): string;
        protected onSaveSuccess(response: any): void;
        loadResponse(data: any): void;
        maximize(): void;
        fullContentArea(): void;
        setDialogSize(width?: any, height?: any, top?: any, left?: any, $content?: any): void;
        onAfterSetDialogSize(): void;
        onAfterDialogClose(entity: TEntity): void;
        parentGrid: GridBase<TEntity, any>;
    }
}
declare namespace _Ext {
    class GridItemPickerDialog extends Serenity.TemplatedDialog<GridItemPickerEditorOptions> {
        getTemplate(): string;
        checkGrid: GridBase<any, GridItemPickerEditorOptions>;
        get selectedItems(): any[];
        constructor(options: GridItemPickerEditorOptions);
        onSuccess: (selectedItems: any) => void;
        getDialogOptions(): JQueryUI.DialogOptions;
    }
}
declare namespace _Ext {
    class EditorDialogBase<TEntity> extends DialogBase<TEntity, any> {
        protected get_ExtDialogOptions(): ExtDialogOptions;
        protected getIdProperty(): string;
        onSave: (options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void) => void;
        onDelete: (options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void) => void;
        destroy(): void;
        protected updateInterface(): void;
        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void): void;
        protected deleteHandler(options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void): void;
        parentEditor: GridEditorBase<TEntity>;
    }
}
declare namespace _Ext {
    class GridEditorBaseWithOption<TEntity, TOptions> extends _Ext.GridBase<TEntity, TOptions> implements Serenity.IGetEditValue, Serenity.ISetEditValue, Serenity.IReadOnly {
        protected get_ExtGridOptions(): ExtGridOptions;
        protected getIdProperty(): string;
        isChildGrid: boolean;
        protected nextId: number;
        constructor(container: JQuery, options?: any);
        private sortGridFunction;
        protected getQuickFilters(): any[];
        protected id(entity: TEntity): any;
        protected save(opt: Serenity.ServiceOptions<any>, callback: (r: Serenity.ServiceResponse) => void): void;
        protected deleteEntity(id: number): boolean;
        protected validateEntity(row: TEntity, id: number): boolean;
        protected getNewEntity(): TEntity;
        protected getButtons(): Serenity.ToolButton[];
        protected addButtonClick(): void;
        protected editItem(entityOrId: any): void;
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        get value(): TEntity[];
        set value(value: TEntity[]);
        protected getGridCanLoad(): boolean;
        protected usePager(): boolean;
        protected getInitialTitle(): any;
        private searchText;
        protected createToolbarExtensions(): void;
        protected onViewFilter(row: any): boolean;
        private matchContains;
        getFilteredItems(): TEntity[];
        protected enableFiltering(): boolean;
        protected onViewSubmit(): boolean;
        get_readOnly(): boolean;
        set_readOnly(value: boolean): void;
        protected getSlickOptions(): Slick.GridOptions;
        parentDialog: DialogBase<any, any>;
        onItemsChanged(): void;
        onBeforeGetValue(items: TEntity[]): void;
    }
    class GridEditorBase<TEntity> extends GridEditorBaseWithOption<TEntity, any> {
    }
    class GridEditorBaseForJsonField<TEntity> extends GridEditorBaseWithOption<TEntity, any> {
        protected getRowIdField(): string;
        getEditValue(property: any, target: any): void;
    }
}
declare namespace _Ext {
    class JsonGridEditorBase<TEntity> extends _Ext.GridEditorBase<TEntity> {
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
    }
}
declare namespace SAPWebPortal.Administration {
    class ExceptionsColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface ExceptionsForm {
        Guid: Serenity.StringEditor;
        ApplicationName: Serenity.StringEditor;
        CreationDate: Serenity.DateEditor;
        Source: Serenity.StringEditor;
        DuplicateCount: Serenity.IntegerEditor;
        Message: Serenity.TextAreaEditor;
        Detail: Serenity.TextAreaEditor;
    }
    class ExceptionsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Administration {
    interface ExceptionsRow {
        Id?: number;
        Guid?: string;
        ApplicationName?: string;
        MachineName?: string;
        CreationDate?: string;
        Type?: string;
        IsProtected?: boolean;
        Host?: string;
        Url?: string;
        HttpMethod?: string;
        IpAddress?: string;
        Source?: string;
        Message?: string;
        Detail?: string;
        StatusCode?: number;
        Sql?: string;
        DeletionDate?: string;
        FullJson?: string;
        ErrorHash?: number;
        DuplicateCount?: number;
    }
    namespace ExceptionsRow {
        const idProperty = "Id";
        const nameProperty = "ApplicationName";
        const localTextPrefix = "Administration.Exceptions";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            Id = "Id",
            Guid = "Guid",
            ApplicationName = "ApplicationName",
            MachineName = "MachineName",
            CreationDate = "CreationDate",
            Type = "Type",
            IsProtected = "IsProtected",
            Host = "Host",
            Url = "Url",
            HttpMethod = "HttpMethod",
            IpAddress = "IpAddress",
            Source = "Source",
            Message = "Message",
            Detail = "Detail",
            StatusCode = "StatusCode",
            Sql = "Sql",
            DeletionDate = "DeletionDate",
            FullJson = "FullJson",
            ErrorHash = "ErrorHash",
            DuplicateCount = "DuplicateCount"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace ExceptionsService {
        const baseUrl = "Administration/Exceptions";
        function Create(request: Serenity.SaveRequest<ExceptionsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ExceptionsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ExceptionsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ExceptionsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Exceptions/Create",
            Update = "Administration/Exceptions/Update",
            Delete = "Administration/Exceptions/Delete",
            Retrieve = "Administration/Exceptions/Retrieve",
            List = "Administration/Exceptions/List"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    interface GETBoard_Response extends Serenity.ServiceResponse {
        CompanyDB?: string;
    }
}
declare namespace SAPWebPortal.Administration {
    class LanguageColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface LanguageForm {
        LanguageId: Serenity.StringEditor;
        LanguageName: Serenity.StringEditor;
    }
    class LanguageForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Administration {
    interface LanguageRow {
        Id?: number;
        LanguageId?: string;
        LanguageName?: string;
    }
    namespace LanguageRow {
        const idProperty = "Id";
        const nameProperty = "LanguageName";
        const localTextPrefix = "Administration.Language";
        const lookupKey = "Administration.Language";
        function getLookup(): Q.Lookup<LanguageRow>;
        const deletePermission = "Administration:Translation";
        const insertPermission = "Administration:Translation";
        const readPermission = "Administration:Translation";
        const updatePermission = "Administration:Translation";
        const enum Fields {
            Id = "Id",
            LanguageId = "LanguageId",
            LanguageName = "LanguageName"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace LanguageService {
        const baseUrl = "Administration/Language";
        function Create(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Language/Create",
            Update = "Administration/Language/Update",
            Delete = "Administration/Language/Delete",
            Retrieve = "Administration/Language/Retrieve",
            List = "Administration/Language/List"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    class LogColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface LogForm {
        UDateTime: Serenity.DateEditor;
        UDirection: Serenity.StringEditor;
        UError: Serenity.StringEditor;
        UXml: Serenity.TextAreaEditor;
        UResponse: Serenity.TextAreaEditor;
    }
    class LogForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Administration {
    interface LogRow {
        Id?: number;
        UDateTime?: string;
        UDirection?: string;
        UError?: string;
        UXml?: string;
        UResponse?: string;
        UObjType?: string;
        UVersion?: string;
        UKey?: string;
        UDocNum?: string;
        Updated?: number;
    }
    namespace LogRow {
        const idProperty = "Id";
        const nameProperty = "UDirection";
        const localTextPrefix = "Administration.Log";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            Id = "Id",
            UDateTime = "UDateTime",
            UDirection = "UDirection",
            UError = "UError",
            UXml = "UXml",
            UResponse = "UResponse",
            UObjType = "UObjType",
            UVersion = "UVersion",
            UKey = "UKey",
            UDocNum = "UDocNum",
            Updated = "Updated"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace LogService {
        const baseUrl = "Administration/Log";
        function Create(request: Serenity.SaveRequest<LogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function HeartBeat(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Log/Create",
            Update = "Administration/Log/Update",
            Delete = "Administration/Log/Delete",
            Retrieve = "Administration/Log/Retrieve",
            HeartBeat = "Administration/Log/HeartBeat",
            List = "Administration/Log/List"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace PermissionKeys {
        const Security = "Administration:Security";
        const Translation = "Administration:Translation";
    }
}
declare namespace SAPWebPortal.Administration {
    class RoleColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface RoleForm {
        RoleName: Serenity.StringEditor;
    }
    class RoleForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Administration {
    interface RolePermissionListRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface RolePermissionListResponse extends Serenity.ListResponse<string> {
    }
}
declare namespace SAPWebPortal.Administration {
    interface RolePermissionRow {
        RolePermissionId?: number;
        RoleId?: number;
        PermissionKey?: string;
        RoleRoleName?: string;
    }
    namespace RolePermissionRow {
        const idProperty = "RolePermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.RolePermission";
        const deletePermission = "Administration:Security";
        const insertPermission = "Administration:Security";
        const readPermission = "Administration:Security";
        const updatePermission = "Administration:Security";
        const enum Fields {
            RolePermissionId = "RolePermissionId",
            RoleId = "RoleId",
            PermissionKey = "PermissionKey",
            RoleRoleName = "RoleRoleName"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace RolePermissionService {
        const baseUrl = "Administration/RolePermission";
        function Update(request: RolePermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: RolePermissionListRequest, onSuccess?: (response: RolePermissionListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/RolePermission/Update",
            List = "Administration/RolePermission/List"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    interface RolePermissionUpdateRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: string[];
    }
}
declare namespace SAPWebPortal.Administration {
    interface RoleRow {
        RoleId?: number;
        RoleName?: string;
    }
    namespace RoleRow {
        const idProperty = "RoleId";
        const nameProperty = "RoleName";
        const localTextPrefix = "Administration.Role";
        const lookupKey = "Administration.Role";
        function getLookup(): Q.Lookup<RoleRow>;
        const deletePermission = "Administration:Security";
        const insertPermission = "Administration:Security";
        const readPermission = "Administration:Security";
        const updatePermission = "Administration:Security";
        const enum Fields {
            RoleId = "RoleId",
            RoleName = "RoleName"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace RoleService {
        const baseUrl = "Administration/Role";
        function Create(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Role/Create",
            Update = "Administration/Role/Update",
            Delete = "Administration/Role/Delete",
            Retrieve = "Administration/Role/Retrieve",
            List = "Administration/Role/List"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    class SessionsColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface SessionsForm {
        SessionId: Serenity.StringEditor;
        UserName: Serenity.StringEditor;
    }
    class SessionsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Administration {
    interface SessionsRow {
        Id?: number;
        SessionId?: string;
        UserName?: string;
        DateTimeStamp?: string;
    }
    namespace SessionsRow {
        const idProperty = "Id";
        const nameProperty = "SessionId";
        const localTextPrefix = "Administration.Sessions";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            Id = "Id",
            SessionId = "SessionId",
            UserName = "UserName",
            DateTimeStamp = "DateTimeStamp"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace SessionsService {
        const baseUrl = "Administration/Sessions";
        function Create(request: Serenity.SaveRequest<SessionsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<SessionsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SessionsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SessionsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/Sessions/Create",
            Update = "Administration/Sessions/Update",
            Delete = "Administration/Sessions/Delete",
            Retrieve = "Administration/Sessions/Retrieve",
            List = "Administration/Sessions/List"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    interface TranslationItem {
        Key?: string;
        SourceText?: string;
        TargetText?: string;
        CustomText?: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface TranslationListRequest extends Serenity.ListRequest {
        SourceLanguageID?: string;
        TargetLanguageID?: string;
    }
}
declare namespace SAPWebPortal.Administration {
    namespace TranslationService {
        const baseUrl = "Administration/Translation";
        function List(request: TranslationListRequest, onSuccess?: (response: Serenity.ListResponse<TranslationItem>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: TranslationUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "Administration/Translation/List",
            Update = "Administration/Translation/Update"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    interface TranslationUpdateRequest extends Serenity.ServiceRequest {
        TargetLanguageID?: string;
        Translations?: {
            [key: string]: string;
        };
    }
}
declare namespace SAPWebPortal.Administration {
    class UserColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserForm {
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        UserImage: Serenity.ImageUploadEditor;
        Password: Serenity.PasswordEditor;
        PasswordConfirm: Serenity.PasswordEditor;
        Source: Serenity.StringEditor;
        DetailList: Default.AutherizedCustomersEditor;
        CompanyDatabase: Serenity.StringEditor;
    }
    class UserForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserPermissionListRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserPermissionRow {
        UserPermissionId?: number;
        UserId?: number;
        PermissionKey?: string;
        Granted?: boolean;
        Username?: string;
        User?: string;
    }
    namespace UserPermissionRow {
        const idProperty = "UserPermissionId";
        const nameProperty = "PermissionKey";
        const localTextPrefix = "Administration.UserPermission";
        const deletePermission = "Administration:Security";
        const insertPermission = "Administration:Security";
        const readPermission = "Administration:Security";
        const updatePermission = "Administration:Security";
        const enum Fields {
            UserPermissionId = "UserPermissionId",
            UserId = "UserId",
            PermissionKey = "PermissionKey",
            Granted = "Granted",
            Username = "Username",
            User = "User"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace UserPermissionService {
        const baseUrl = "Administration/UserPermission";
        function Update(request: UserPermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<UserPermissionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListRolePermissions(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListPermissionKeys(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/UserPermission/Update",
            List = "Administration/UserPermission/List",
            ListRolePermissions = "Administration/UserPermission/ListRolePermissions",
            ListPermissionKeys = "Administration/UserPermission/ListPermissionKeys"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserPermissionUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: UserPermissionRow[];
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserRoleListRequest extends Serenity.ServiceRequest {
        UserID?: number;
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserRoleListResponse extends Serenity.ListResponse<number> {
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserRoleRow {
        UserRoleId?: number;
        UserId?: number;
        RoleId?: number;
        Username?: string;
        User?: string;
    }
    namespace UserRoleRow {
        const idProperty = "UserRoleId";
        const localTextPrefix = "Administration.UserRole";
        const deletePermission = "Administration:Security";
        const insertPermission = "Administration:Security";
        const readPermission = "Administration:Security";
        const updatePermission = "Administration:Security";
        const enum Fields {
            UserRoleId = "UserRoleId",
            UserId = "UserId",
            RoleId = "RoleId",
            Username = "Username",
            User = "User"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace UserRoleService {
        const baseUrl = "Administration/UserRole";
        function Update(request: UserRoleUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserRoleListRequest, onSuccess?: (response: UserRoleListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Update = "Administration/UserRole/Update",
            List = "Administration/UserRole/List"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserRoleUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Roles?: number[];
    }
}
declare namespace SAPWebPortal.Administration {
    interface UserRow {
        UserId?: number;
        Username?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        DisplayName?: string;
        Email?: string;
        UserImage?: string;
        LastDirectoryUpdate?: string;
        IsActive?: number;
        Password?: string;
        PasswordConfirm?: string;
        CompanyDatabase?: string;
        DetailList?: Default.UserDetail1Row[];
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }
    namespace UserRow {
        const idProperty = "UserId";
        const isActiveProperty = "IsActive";
        const nameProperty = "Username";
        const localTextPrefix = "Administration.User";
        const lookupKey = "Administration.User";
        function getLookup(): Q.Lookup<UserRow>;
        const deletePermission = "Administration:Security";
        const insertPermission = "Administration:Security";
        const readPermission = "Administration:Security";
        const updatePermission = "Administration:Security";
        const enum Fields {
            UserId = "UserId",
            Username = "Username",
            Source = "Source",
            PasswordHash = "PasswordHash",
            PasswordSalt = "PasswordSalt",
            DisplayName = "DisplayName",
            Email = "Email",
            UserImage = "UserImage",
            LastDirectoryUpdate = "LastDirectoryUpdate",
            IsActive = "IsActive",
            Password = "Password",
            PasswordConfirm = "PasswordConfirm",
            CompanyDatabase = "CompanyDatabase",
            DetailList = "DetailList",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
declare namespace SAPWebPortal.Administration {
    namespace UserService {
        const baseUrl = "Administration/User";
        function Create(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Undelete(request: Serenity.UndeleteRequest, onSuccess?: (response: Serenity.UndeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ActiveCompany(request: Serenity.ServiceRequest, onSuccess?: (response: GETBoard_Response) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Administration/User/Create",
            Update = "Administration/User/Update",
            Delete = "Administration/User/Delete",
            Undelete = "Administration/User/Undelete",
            Retrieve = "Administration/User/Retrieve",
            List = "Administration/User/List",
            ActiveCompany = "Administration/User/ActiveCompany"
        }
    }
}
declare namespace SAPWebPortal.Common.PermissionsKeys {
    namespace ApprovalProcessPermissionKeys {
        const General = "ApprovalProcess:General";
        const DefaultGeneral = "Administration:DefaultGeneral";
    }
}
declare namespace SAPWebPortal.Common.PermissionsKeys {
    namespace MarketingDocsPermissionKeys {
        const General = "MarketingDocs:General";
    }
}
declare namespace SAPWebPortal.Common.PermissionsKeys {
    namespace MasterDataPermissionKeys {
        const General = "MasterData:General";
    }
}
declare namespace SAPWebPortal.Common.PermissionsKeys {
    namespace ReportsPermissionKeys {
        const General = "Reports:General";
    }
}
declare namespace SAPWebPortal.Default {
    class AdditionalExpenseColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface AdditionalExpenseForm {
        ExpensCode: Serenity.IntegerEditor;
        Name: Serenity.StringEditor;
    }
    class AdditionalExpenseForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface AdditionalExpenseRow {
        ExpensCode?: number;
        Name?: string;
    }
    namespace AdditionalExpenseRow {
        const idProperty = "ExpensCode";
        const nameProperty = "Name";
        const localTextPrefix = "Default.AdditionalExpense";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            ExpensCode = "ExpensCode",
            Name = "Name"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace AdditionalExpenseService {
        const baseUrl = "Default/AdditionalExpense";
        function Create(request: Serenity.SaveRequest<AdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/AdditionalExpense/Create",
            Update = "Default/AdditionalExpense/Update",
            Delete = "Default/AdditionalExpense/Delete",
            Retrieve = "Default/AdditionalExpense/Retrieve",
            List = "Default/AdditionalExpense/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestDecisionColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface ApprovalRequestDecisionForm {
        Status: Serenity.EnumEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class ApprovalRequestDecisionForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface ApprovalRequestDecisionRow {
        ApproverUserName?: string;
        ApproverPassword?: string;
        Status?: string;
        Remarks?: string;
    }
    namespace ApprovalRequestDecisionRow {
        const idProperty = "ApproverUserName";
        const localTextPrefix = "Default.ApprovalRequestDecision";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            ApproverUserName = "ApproverUserName",
            ApproverPassword = "ApproverPassword",
            Status = "Status",
            Remarks = "Remarks"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ApprovalRequestDecisionService {
        const baseUrl = "Default/ApprovalRequestDecision";
        function Create(request: Serenity.SaveRequest<ApprovalRequestDecisionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ApprovalRequestDecisionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ApprovalRequestDecisionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ApprovalRequestDecisionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/ApprovalRequestDecision/Create",
            Update = "Default/ApprovalRequestDecision/Update",
            Delete = "Default/ApprovalRequestDecision/Delete",
            Retrieve = "Default/ApprovalRequestDecision/Retrieve",
            List = "Default/ApprovalRequestDecision/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    interface ApprovalRequestForm {
        ApprovalTemplatesID: SelectCodeNameValueEditor;
        ObjectType: Modules.DropDownEnums.ApprovalDocsEditor;
        IsDraft: Modules.DropDownEnums.IsYOrNEditor;
        ObjectEntry: Serenity.IntegerEditor;
        Status: Modules.DropDownEnums.ApprovalStatusEditor;
        CurrentStage: Serenity.IntegerEditor;
        OriginatorID: SelectCodeNameValueEditor;
        CreationDate: Serenity.DateEditor;
        DraftEntry: _Ext.GridItemPickerEditor;
        ApprovalRequestLines: ApprovalRequestLineEditor;
        ApprovalRequestDecisions: ApprovalRequestDecisionEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class ApprovalRequestForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestLineColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface ApprovalRequestLineForm {
        UserID: Serenity.IntegerEditor;
        StageCode: Serenity.IntegerEditor;
        Status: Modules.DropDownEnums.ApprovalLineStatusEditor;
        CreationDate: Serenity.DateTimeEditor;
        UpdateDate: Serenity.DateTimeEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class ApprovalRequestLineForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface ApprovalRequestLineRow {
        StageCode?: number;
        UserID?: number;
        Status?: string;
        Remarks?: string;
        CreationDate?: string;
        UpdateDate?: string;
    }
    namespace ApprovalRequestLineRow {
        const idProperty = "StageCode";
        const localTextPrefix = "Default.ApprovalRequestLine";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            StageCode = "StageCode",
            UserID = "UserID",
            Status = "Status",
            Remarks = "Remarks",
            CreationDate = "CreationDate",
            UpdateDate = "UpdateDate"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ApprovalRequestLineService {
        const baseUrl = "Default/ApprovalRequestLine";
        function Create(request: Serenity.SaveRequest<ApprovalRequestLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ApprovalRequestLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ApprovalRequestLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ApprovalRequestLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/ApprovalRequestLine/Create",
            Update = "Default/ApprovalRequestLine/Update",
            Delete = "Default/ApprovalRequestLine/Delete",
            Retrieve = "Default/ApprovalRequestLine/Retrieve",
            List = "Default/ApprovalRequestLine/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    interface ApprovalRequestRow {
        Code?: number;
        ApprovalTemplatesID?: number;
        ObjectType?: string;
        IsDraft?: string;
        ObjectEntry?: number;
        Status?: string;
        Remarks?: string;
        CurrentStage?: number;
        OriginatorID?: number;
        CreationDate?: string;
        CreationTime?: string;
        DraftEntry?: number;
        DraftType?: string;
        ApprovalRequestLines?: ApprovalRequestLineRow[];
        ApprovalRequestDecisions?: ApprovalRequestDecisionRow[];
    }
    namespace ApprovalRequestRow {
        const idProperty = "Code";
        const localTextPrefix = "Default.ApprovalRequest";
        const deletePermission = "ApprovalProcess:ApprovalRequests:Delete";
        const insertPermission = "ApprovalProcess:ApprovalRequests:Insert";
        const readPermission = "ApprovalProcess:ApprovalRequests:View";
        const updatePermission = "ApprovalProcess:ApprovalRequests:Modify";
        const enum Fields {
            Code = "Code",
            ApprovalTemplatesID = "ApprovalTemplatesID",
            ObjectType = "ObjectType",
            IsDraft = "IsDraft",
            ObjectEntry = "ObjectEntry",
            Status = "Status",
            Remarks = "Remarks",
            CurrentStage = "CurrentStage",
            OriginatorID = "OriginatorID",
            CreationDate = "CreationDate",
            CreationTime = "CreationTime",
            DraftEntry = "DraftEntry",
            DraftType = "DraftType",
            ApprovalRequestLines = "ApprovalRequestLines",
            ApprovalRequestDecisions = "ApprovalRequestDecisions"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ApprovalRequestService {
        const baseUrl = "Default/ApprovalRequest";
        function Create(request: Serenity.SaveRequest<ApprovalRequestRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ApprovalRequestRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ApprovalRequestRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ApprovalRequestRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/ApprovalRequest/Create",
            Update = "Default/ApprovalRequest/Update",
            Delete = "Default/ApprovalRequest/Delete",
            Retrieve = "Default/ApprovalRequest/Retrieve",
            List = "Default/ApprovalRequest/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class BPAddressesColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface BPAddressesForm {
        AddressType: BPAddressTypeEditor;
        AddressName: Serenity.StringEditor;
        Street: Serenity.StringEditor;
        Block: Serenity.StringEditor;
        ZipCode: Serenity.StringEditor;
        City: Serenity.StringEditor;
        County: Serenity.StringEditor;
        Country: SelectCodeNameValueEditor;
        State: SelectCodeNameValueEditor;
    }
    class BPAddressesForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface BPAddressesRow {
        AddressName?: string;
        Street?: string;
        Block?: string;
        ZipCode?: string;
        City?: string;
        County?: string;
        Country?: string;
        State?: string;
        BuildingFloorRoom?: string;
        AddressType?: string;
        AddressName2?: string;
        AddressName3?: string;
        TypeOfAddress?: string;
        StreetNo?: string;
        BPCode?: string;
        GlobalLocationNumber?: string;
        Nationality?: string;
        TaxOffice?: string;
        GSTIN?: string;
        GstType?: string;
    }
    namespace BPAddressesRow {
        const idProperty = "BPCode";
        const nameProperty = "BPCode";
        const localTextPrefix = "Default.BPAddresses";
        const deletePermission = "BPAddresses";
        const insertPermission = "BPAddresses";
        const readPermission = "BPAddresses";
        const updatePermission = "BPAddresses";
        const enum Fields {
            AddressName = "AddressName",
            Street = "Street",
            Block = "Block",
            ZipCode = "ZipCode",
            City = "City",
            County = "County",
            Country = "Country",
            State = "State",
            BuildingFloorRoom = "BuildingFloorRoom",
            AddressType = "AddressType",
            AddressName2 = "AddressName2",
            AddressName3 = "AddressName3",
            TypeOfAddress = "TypeOfAddress",
            StreetNo = "StreetNo",
            BPCode = "BPCode",
            GlobalLocationNumber = "GlobalLocationNumber",
            Nationality = "Nationality",
            TaxOffice = "TaxOffice",
            GSTIN = "GSTIN",
            GstType = "GstType"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace BPAddressesService {
        const baseUrl = "Default/BPAddresses";
        function Create(request: Serenity.SaveRequest<BPAddressesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<BPAddressesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BPAddressesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BPAddressesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/BPAddresses/Create",
            Update = "Default/BPAddresses/Update",
            Delete = "Default/BPAddresses/Delete",
            Retrieve = "Default/BPAddresses/Retrieve",
            List = "Default/BPAddresses/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class BPPaymentMethodsColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface BPPaymentMethodsForm {
        PaymentMethodCode: SelectCodeNameValueEditor;
    }
    class BPPaymentMethodsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface BPPaymentMethodsRow {
        BPCode?: string;
        PaymentMethodCode?: string;
    }
    namespace BPPaymentMethodsRow {
        const idProperty = "BPCode";
        const nameProperty = "BPCode";
        const localTextPrefix = "Default.BPPaymentMethods";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            BPCode = "BPCode",
            PaymentMethodCode = "PaymentMethodCode"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace BPPaymentMethodsService {
        const baseUrl = "Default/BPPaymentMethods";
        function Create(request: Serenity.SaveRequest<BPPaymentMethodsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<BPPaymentMethodsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BPPaymentMethodsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BPPaymentMethodsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/BPPaymentMethods/Create",
            Update = "Default/BPPaymentMethods/Update",
            Delete = "Default/BPPaymentMethods/Delete",
            Retrieve = "Default/BPPaymentMethods/Retrieve",
            List = "Default/BPPaymentMethods/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class BusinessPartnerColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface BusinessPartnerForm {
        Series: SelectCodeNameValueEditor;
        CardCode: Serenity.StringEditor;
        CardType: Modules.DropDownEnums.CardTypeEditor;
        CardName: Serenity.StringEditor;
        GroupCode: SelectCodeNameValueEditor;
        CardForeignName: Serenity.StringEditor;
        CurrentAccountBalance: Serenity.DecimalEditor;
        OpenDeliveryNotesBalance: Serenity.DecimalEditor;
        OpenOrdersBalance: Serenity.DecimalEditor;
        Currency: SelectCodeNameValueEditor;
        FederalTaxID: Serenity.StringEditor;
        Phone1: Serenity.StringEditor;
        Phone2: Serenity.StringEditor;
        MailAddress: Serenity.StringEditor;
        Website: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        Cellular: Serenity.StringEditor;
        SalesPersonCode: SelectCodeNameValueEditor;
        BPAddresses: BPAddressesEditor;
        BPPaymentMethods: BPPaymentMethodsEditor;
        PriceListNum: SelectCodeNameValueEditor;
    }
    class BusinessPartnerForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    class BusinessPartnerGroupColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface BusinessPartnerGroupForm {
        Name: Serenity.StringEditor;
        Type: Serenity.EnumEditor;
    }
    class BusinessPartnerGroupForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface BusinessPartnerGroupRow {
        Code?: number;
        Name?: string;
        Type?: string;
    }
    namespace BusinessPartnerGroupRow {
        const idProperty = "Code";
        const nameProperty = "Name";
        const localTextPrefix = "Default.BusinessPartnerGroup";
        const lookupKey = "Default.BusinessPartnerGroup";
        function getLookup(): Q.Lookup<BusinessPartnerGroupRow>;
        const deletePermission = "Administration:BusinessPartnerGroup";
        const insertPermission = "Administration:BusinessPartnerGroup";
        const readPermission = "Administration:BusinessPartnerGroup";
        const updatePermission = "Administration:BusinessPartnerGroup";
        const enum Fields {
            Code = "Code",
            Name = "Name",
            Type = "Type"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace BusinessPartnerGroupService {
        const baseUrl = "Default/BusinessPartnerGroup";
        function Create(request: Serenity.SaveRequest<BusinessPartnerGroupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<BusinessPartnerGroupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BusinessPartnerGroupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BusinessPartnerGroupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/BusinessPartnerGroup/Create",
            Update = "Default/BusinessPartnerGroup/Update",
            Delete = "Default/BusinessPartnerGroup/Delete",
            Retrieve = "Default/BusinessPartnerGroup/Retrieve",
            List = "Default/BusinessPartnerGroup/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    interface BusinessPartnerRow {
        Series?: number;
        CardCode?: string;
        CardName?: string;
        CardForeignName?: string;
        CardType?: string;
        CurrentAccountBalance?: number;
        OpenDeliveryNotesBalance?: number;
        OpenOrdersBalance?: number;
        GroupCode?: string;
        Currency?: string;
        BPAddresses?: BPAddressesRow[];
        BPPaymentMethods?: BPPaymentMethodsRow[];
        Phone1?: string;
        Phone2?: string;
        Cellular?: string;
        SalesPersonCode?: number;
        PriceListNum?: number;
        MailAddress?: string;
        Fax?: string;
        FederalTaxID?: string;
        Website?: string;
        FatherCard?: string;
    }
    namespace BusinessPartnerRow {
        const idProperty = "CardCode";
        const nameProperty = "CardCode";
        const localTextPrefix = "Default.BusinessPartner";
        const deletePermission = "MasterData:BusinessPartners:Delete";
        const insertPermission = "MasterData:BusinessPartners:Insert";
        const readPermission = "MasterData:BusinessPartners:View";
        const updatePermission = "MasterData:BusinessPartners:Modify";
        const enum Fields {
            Series = "Series",
            CardCode = "CardCode",
            CardName = "CardName",
            CardForeignName = "CardForeignName",
            CardType = "CardType",
            CurrentAccountBalance = "CurrentAccountBalance",
            OpenDeliveryNotesBalance = "OpenDeliveryNotesBalance",
            OpenOrdersBalance = "OpenOrdersBalance",
            GroupCode = "GroupCode",
            Currency = "Currency",
            BPAddresses = "BPAddresses",
            BPPaymentMethods = "BPPaymentMethods",
            Phone1 = "Phone1",
            Phone2 = "Phone2",
            Cellular = "Cellular",
            SalesPersonCode = "SalesPersonCode",
            PriceListNum = "PriceListNum",
            MailAddress = "MailAddress",
            Fax = "Fax",
            FederalTaxID = "FederalTaxID",
            Website = "Website",
            FatherCard = "FatherCard"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace BusinessPartnerService {
        const baseUrl = "Default/BusinessPartner";
        function Create(request: Serenity.SaveRequest<BusinessPartnerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<BusinessPartnerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BusinessPartnerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function RetrieveSeries(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BusinessPartnerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BusinessPartnerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/BusinessPartner/Create",
            Update = "Default/BusinessPartner/Update",
            Delete = "Default/BusinessPartner/Delete",
            Retrieve = "Default/BusinessPartner/Retrieve",
            RetrieveSeries = "Default/BusinessPartner/RetrieveSeries",
            List = "Default/BusinessPartner/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class ChartOfAccountColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface ChartOfAccountForm {
        Name: Serenity.StringEditor;
    }
    class ChartOfAccountForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface ChartOfAccountRow {
        Code?: string;
        Name?: string;
    }
    namespace ChartOfAccountRow {
        const idProperty = "Code";
        const nameProperty = "Code";
        const localTextPrefix = "Default.ChartOfAccount";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Code = "Code",
            Name = "Name"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ChartOfAccountService {
        const baseUrl = "Default/ChartOfAccount";
        function Create(request: Serenity.SaveRequest<ChartOfAccountRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ChartOfAccountRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ChartOfAccountRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ChartOfAccountRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/ChartOfAccount/Create",
            Update = "Default/ChartOfAccount/Update",
            Delete = "Default/ChartOfAccount/Delete",
            Retrieve = "Default/ChartOfAccount/Retrieve",
            List = "Default/ChartOfAccount/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class ContactEmployeesColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface ContactEmployeesForm {
        CardCode: Serenity.StringEditor;
        Name: Serenity.StringEditor;
        Position: Serenity.StringEditor;
        Address: Serenity.StringEditor;
        Phone1: Serenity.StringEditor;
        E_Mail: Serenity.StringEditor;
        FirstName: Serenity.StringEditor;
        MiddleName: Serenity.StringEditor;
        LastName: Serenity.StringEditor;
        EmailGroupCode: Serenity.StringEditor;
        Active: Serenity.StringEditor;
    }
    class ContactEmployeesForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface ContactEmployeesRow {
        CardCode?: string;
        Name?: string;
        Position?: string;
        Address?: string;
        Phone1?: string;
        E_Mail?: string;
        FirstName?: string;
        MiddleName?: string;
        EmailGroupCode?: string;
        LastName?: string;
        Active?: string;
    }
    namespace ContactEmployeesRow {
        const idProperty = "CardCode";
        const nameProperty = "CardCode";
        const localTextPrefix = "Default.ContactEmployees";
        const deletePermission = "ContactEmployees";
        const insertPermission = "ContactEmployees";
        const readPermission = "ContactEmployees";
        const updatePermission = "ContactEmployees";
        const enum Fields {
            CardCode = "CardCode",
            Name = "Name",
            Position = "Position",
            Address = "Address",
            Phone1 = "Phone1",
            E_Mail = "E_Mail",
            FirstName = "FirstName",
            MiddleName = "MiddleName",
            EmailGroupCode = "EmailGroupCode",
            LastName = "LastName",
            Active = "Active"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ContactEmployeesService {
        const baseUrl = "Default/ContactEmployees";
        function Create(request: Serenity.SaveRequest<ContactEmployeesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ContactEmployeesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ContactEmployeesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ContactEmployeesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/ContactEmployees/Create",
            Update = "Default/ContactEmployees/Update",
            Delete = "Default/ContactEmployees/Delete",
            Retrieve = "Default/ContactEmployees/Retrieve",
            List = "Default/ContactEmployees/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class FileRoutingColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface FileRoutingForm {
        Name: Serenity.StringEditor;
        CompanyDB: SAPCompanyEditor;
        SlObjectType: SAPObectsValuesEditor;
        ReportPath: Serenity.ImageUploadEditor;
        RdocCode: Serenity.StringEditor;
        ExportExtension: ExtensionsValuesEditor;
        FileNameTemplate: Serenity.StringEditor;
        ExportPath: Serenity.StringEditor;
    }
    class FileRoutingForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface FileRoutingRow {
        Id?: number;
        Name?: string;
        SlObjectType?: string;
        ReportPath?: string;
        RdocCode?: string;
        ExportExtension?: string;
        FileNameTemplate?: string;
        ExportPath?: string;
        CompanyDB?: string;
    }
    namespace FileRoutingRow {
        const idProperty = "Id";
        const nameProperty = "Name";
        const localTextPrefix = "Default.FileRouting";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Id = "Id",
            Name = "Name",
            SlObjectType = "SlObjectType",
            ReportPath = "ReportPath",
            RdocCode = "RdocCode",
            ExportExtension = "ExportExtension",
            FileNameTemplate = "FileNameTemplate",
            ExportPath = "ExportPath",
            CompanyDB = "CompanyDB"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace FileRoutingService {
        const baseUrl = "Default/FileRouting";
        function Create(request: Serenity.SaveRequest<FileRoutingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<FileRoutingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<FileRoutingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<FileRoutingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/FileRouting/Create",
            Update = "Default/FileRouting/Update",
            Delete = "Default/FileRouting/Delete",
            Retrieve = "Default/FileRouting/Retrieve",
            List = "Default/FileRouting/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    interface GETBoard_Response1 extends Serenity.ServiceResponse {
        CompanyDB?: string;
    }
}
declare namespace SAPWebPortal.Default {
    class ItemColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface ItemForm {
        ItemCode: Serenity.StringEditor;
        ItemName: Serenity.StringEditor;
        ForeignName: Serenity.StringEditor;
        BarCode: Serenity.StringEditor;
        PurchaseItem: Modules.DropDownEnums.YesOrNoEditor;
        SalesItem: Modules.DropDownEnums.YesOrNoEditor;
        InventoryItem: Modules.DropDownEnums.YesOrNoEditor;
        ItemWarehouseInfoCollection: ItemWarehouseInfoCollectionEditor;
    }
    class ItemForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface ItemRow {
        ItemCode?: string;
        ItemName?: string;
        ForeignName?: string;
        BarCode?: string;
        PurchaseItem?: string;
        SalesItem?: string;
        InventoryItem?: string;
        DefaultWarehouse?: string;
        ItemWarehouseInfoCollection?: ItemWarehouseInfoCollectionRow[];
    }
    namespace ItemRow {
        const idProperty = "ItemCode";
        const nameProperty = "ItemCode";
        const localTextPrefix = "Default.Item";
        const lookupKey = "Default.Item";
        function getLookup(): Q.Lookup<ItemRow>;
        const deletePermission = "MasterData:Items:Delete";
        const insertPermission = "MasterData:Items:Insert";
        const readPermission = "MasterData:Items:View";
        const updatePermission = "MasterData:Items:Modify";
        const enum Fields {
            ItemCode = "ItemCode",
            ItemName = "ItemName",
            ForeignName = "ForeignName",
            BarCode = "BarCode",
            PurchaseItem = "PurchaseItem",
            SalesItem = "SalesItem",
            InventoryItem = "InventoryItem",
            DefaultWarehouse = "DefaultWarehouse",
            ItemWarehouseInfoCollection = "ItemWarehouseInfoCollection"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ItemService {
        const baseUrl = "Default/Item";
        function Create(request: Serenity.SaveRequest<ItemRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ItemRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ItemRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ItemRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/Item/Create",
            Update = "Default/Item/Update",
            Delete = "Default/Item/Delete",
            Retrieve = "Default/Item/Retrieve",
            List = "Default/Item/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class ItemWarehouseInfoCollectionColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface ItemWarehouseInfoCollectionForm {
        ItemCode: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        InStock: Serenity.StringEditor;
        Committed: Serenity.StringEditor;
        Ordered: Serenity.StringEditor;
        CountedQuantity: Serenity.StringEditor;
    }
    class ItemWarehouseInfoCollectionForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface ItemWarehouseInfoCollectionRow {
        ItemCode?: string;
        WarehouseCode?: string;
        InStock?: number;
        Committed?: number;
        Ordered?: number;
        CountedQuantity?: number;
    }
    namespace ItemWarehouseInfoCollectionRow {
        const idProperty = "ItemCode";
        const nameProperty = "ItemCode";
        const localTextPrefix = "Default.ItemWarehouseInfoCollection";
        const deletePermission = "MasterData:General";
        const insertPermission = "MasterData:General";
        const readPermission = "MasterData:General";
        const updatePermission = "MasterData:General";
        const enum Fields {
            ItemCode = "ItemCode",
            WarehouseCode = "WarehouseCode",
            InStock = "InStock",
            Committed = "Committed",
            Ordered = "Ordered",
            CountedQuantity = "CountedQuantity"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ItemWarehouseInfoCollectionService {
        const baseUrl = "Default/ItemWarehouseInfoCollection";
        function Create(request: Serenity.SaveRequest<ItemWarehouseInfoCollectionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ItemWarehouseInfoCollectionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ItemWarehouseInfoCollectionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ItemWarehouseInfoCollectionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/ItemWarehouseInfoCollection/Create",
            Update = "Default/ItemWarehouseInfoCollection/Update",
            Delete = "Default/ItemWarehouseInfoCollection/Delete",
            Retrieve = "Default/ItemWarehouseInfoCollection/Retrieve",
            List = "Default/ItemWarehouseInfoCollection/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class RecordCountsColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface RecordCountsForm {
        ModuleName: Serenity.StringEditor;
        ObjectType: SAPObjectsValuesEditor;
        Company: Membership.CompanyDatabaseValuesEditor;
        Counts: Serenity.IntegerEditor;
        DateTimeStamp: Serenity.DateTimeEditor;
    }
    class RecordCountsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface RecordCountsRow {
        Id?: number;
        ModuleName?: string;
        ObjectType?: number;
        Company?: string;
        Counts?: number;
        DateTimeStamp?: string;
    }
    namespace RecordCountsRow {
        const idProperty = "Id";
        const nameProperty = "ModuleName";
        const localTextPrefix = "Default.RecordCounts";
        const deletePermission = "MasterData:RecordCounts:Delete";
        const insertPermission = "MasterData:RecordCounts:Insert";
        const readPermission = "MasterData:RecordCounts:View";
        const updatePermission = "MasterData:RecordCounts:Modify";
        const enum Fields {
            Id = "Id",
            ModuleName = "ModuleName",
            ObjectType = "ObjectType",
            Company = "Company",
            Counts = "Counts",
            DateTimeStamp = "DateTimeStamp"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace RecordCountsService {
        const baseUrl = "Default/RecordCounts";
        function Create(request: Serenity.SaveRequest<RecordCountsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RecordCountsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RecordCountsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RecordCountsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/RecordCounts/Create",
            Update = "Default/RecordCounts/Update",
            Delete = "Default/RecordCounts/Delete",
            Retrieve = "Default/RecordCounts/Retrieve",
            List = "Default/RecordCounts/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class Report_UsersColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface Report_UsersForm {
        UserId: Serenity.LookupEditor;
        RptName: Serenity.StringEditor;
        DB_Name: Membership.CompanyDatabaseValuesEditor;
        Rodcid: Serenity.LookupEditor;
    }
    class Report_UsersForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface Report_UsersRow {
        Id?: number;
        UserId?: number;
        Rodcid?: number;
        DB_Name?: string;
        RptName?: string;
    }
    namespace Report_UsersRow {
        const idProperty = "Id";
        const localTextPrefix = "Default.Report_Users";
        const lookupKey = "Default.Report_Users";
        function getLookup(): Q.Lookup<Report_UsersRow>;
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Id = "Id",
            UserId = "UserId",
            Rodcid = "Rodcid",
            DB_Name = "DB_Name",
            RptName = "RptName"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace Report_UsersService {
        const baseUrl = "Default/Report_Users";
        function Create(request: Serenity.SaveRequest<Report_UsersRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<Report_UsersRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<Report_UsersRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<Report_UsersRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/Report_Users/Create",
            Update = "Default/Report_Users/Update",
            Delete = "Default/Report_Users/Delete",
            Retrieve = "Default/Report_Users/Retrieve",
            List = "Default/Report_Users/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class ReportsColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface ReportsForm {
        RptName: Serenity.StringEditor;
        RptByteArray: Serenity.ImageUploadEditor;
        DB_Name: Membership.CompanyDatabaseValuesEditor;
        CreateDate: Serenity.DateEditor;
        UpdateDate: Serenity.DateEditor;
    }
    class ReportsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface ReportsRow {
        Rdocid?: number;
        RptName?: string;
        RptByteArray?: string;
        CreateDate?: string;
        UpdateDate?: string;
        DB_Name?: string;
    }
    namespace ReportsRow {
        const idProperty = "Rdocid";
        const nameProperty = "RptName";
        const localTextPrefix = "Default.Reports";
        const lookupKey = "Default.Reports";
        function getLookup(): Q.Lookup<ReportsRow>;
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Rdocid = "Rdocid",
            RptName = "RptName",
            RptByteArray = "RptByteArray",
            CreateDate = "CreateDate",
            UpdateDate = "UpdateDate",
            DB_Name = "DB_Name"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace ReportsService {
        const baseUrl = "Default/Reports";
        function Create(request: Serenity.SaveRequest<ReportsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ReportsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ReportsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ReportsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/Reports/Create",
            Update = "Default/Reports/Update",
            Delete = "Default/Reports/Delete",
            Retrieve = "Default/Reports/Retrieve",
            List = "Default/Reports/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class SapDatabasesColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface SapDatabasesForm {
        ServerName: Serenity.StringEditor;
        DbServerType: DbServerTypeValuesEditor;
        LicenseServer: Serenity.StringEditor;
        CompanyDb: Serenity.StringEditor;
        DbUserName: Serenity.StringEditor;
        DbPassword: Serenity.PasswordEditor;
        UserName: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
        ODBCServer: Serenity.StringEditor;
        Alias: Serenity.StringEditor;
        ServiceLayerUrl: Serenity.StringEditor;
        ServiceLayerVersion: Serenity.StringEditor;
        DBDriver: DBDriverEditor;
        IsDefault: Serenity.BooleanEditor;
    }
    class SapDatabasesForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface SapDatabasesRow {
        Id?: number;
        ServerName?: string;
        ODBCServer?: string;
        DbServerType?: string;
        LicenseServer?: string;
        CompanyDb?: string;
        DbUserName?: string;
        DbPassword?: string;
        UserName?: string;
        Password?: string;
        Alias?: string;
        ServiceLayerUrl?: string;
        ServiceLayerVersion?: string;
        DBDriver?: string;
        IsDefault?: boolean;
    }
    namespace SapDatabasesRow {
        const idProperty = "Id";
        const nameProperty = "CompanyDb";
        const localTextPrefix = "Default.SapDatabases";
        const lookupKey = "Default.SapDatabases";
        function getLookup(): Q.Lookup<SapDatabasesRow>;
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Id = "Id",
            ServerName = "ServerName",
            ODBCServer = "ODBCServer",
            DbServerType = "DbServerType",
            LicenseServer = "LicenseServer",
            CompanyDb = "CompanyDb",
            DbUserName = "DbUserName",
            DbPassword = "DbPassword",
            UserName = "UserName",
            Password = "Password",
            Alias = "Alias",
            ServiceLayerUrl = "ServiceLayerUrl",
            ServiceLayerVersion = "ServiceLayerVersion",
            DBDriver = "DBDriver",
            IsDefault = "IsDefault"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace SapDatabasesService {
        const baseUrl = "Default/SapDatabases";
        function Create(request: Serenity.SaveRequest<SapDatabasesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ConnecteionTest(request: SapDatabasesRow, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<SapDatabasesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SapDatabasesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SapDatabasesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/SapDatabases/Create",
            ConnecteionTest = "Default/SapDatabases/ConnecteionTest",
            Update = "Default/SapDatabases/Update",
            Delete = "Default/SapDatabases/Delete",
            Retrieve = "Default/SapDatabases/Retrieve",
            List = "Default/SapDatabases/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class UserDetail1Columns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface UserDetail1Form {
        UserDId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        UserCode: Serenity.StringEditor;
        UserName: Serenity.StringEditor;
        DbName: Serenity.StringEditor;
        CardCode: Serenity.StringEditor;
        CardName: Serenity.StringEditor;
        Active: Serenity.StringEditor;
    }
    class UserDetail1Form extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface UserDetail1Row {
        Id?: number;
        UserDId?: number;
        UserId?: number;
        UserCode?: string;
        UserName?: string;
        DbName?: string;
        CardCode?: string;
        CardName?: string;
        Active?: string;
    }
    namespace UserDetail1Row {
        const idProperty = "Id";
        const nameProperty = "UserCode";
        const localTextPrefix = "Default.UserDetail1";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Id = "Id",
            UserDId = "UserDId",
            UserId = "UserId",
            UserCode = "UserCode",
            UserName = "UserName",
            DbName = "DbName",
            CardCode = "CardCode",
            CardName = "CardName",
            Active = "Active"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace UserDetail1Service {
        const baseUrl = "Default/UserDetail1";
        function Create(request: Serenity.SaveRequest<UserDetail1Row>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserDetail1Row>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserDetail1Row>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserDetail1Row>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/UserDetail1/Create",
            Update = "Default/UserDetail1/Update",
            Delete = "Default/UserDetail1/Delete",
            Retrieve = "Default/UserDetail1/Retrieve",
            List = "Default/UserDetail1/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class UsersColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    class UsersDetailsColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface UsersDetailsForm {
        U1Id: Serenity.IntegerEditor;
        ParameterName: Serenity.StringEditor;
        ParameterQuery: Serenity.StringEditor;
        DbName: Serenity.StringEditor;
    }
    class UsersDetailsForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface UsersDetailsRow {
        Id?: number;
        U1Id?: number;
        UserId?: number;
        ParameterName?: string;
        ParameterQuery?: string;
        Rodcid?: number;
        DbName?: string;
    }
    namespace UsersDetailsRow {
        const idProperty = "Id";
        const nameProperty = "ParameterName";
        const localTextPrefix = "Default.UsersDetails";
        const lookupKey = "Default.UsersDetails";
        function getLookup(): Q.Lookup<UsersDetailsRow>;
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Id = "Id",
            U1Id = "U1Id",
            UserId = "UserId",
            ParameterName = "ParameterName",
            ParameterQuery = "ParameterQuery",
            Rodcid = "Rodcid",
            DbName = "DbName"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace UsersDetailsService {
        const baseUrl = "Default/UsersDetails";
        function Create(request: Serenity.SaveRequest<UsersDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UsersDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UsersDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UsersDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/UsersDetails/Create",
            Update = "Default/UsersDetails/Update",
            Delete = "Default/UsersDetails/Delete",
            Retrieve = "Default/UsersDetails/Retrieve",
            List = "Default/UsersDetails/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    interface UsersForm {
        UserId: Serenity.LookupEditor;
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        Source: Serenity.StringEditor;
        PasswordHash: Serenity.StringEditor;
        PasswordSalt: Serenity.StringEditor;
        LastDirectoryUpdate: Serenity.DateEditor;
        UserImage: Serenity.StringEditor;
        InsertDate: Serenity.DateEditor;
        InsertUserId: Serenity.IntegerEditor;
        UpdateDate: Serenity.DateEditor;
        UpdateUserId: Serenity.IntegerEditor;
        IsActive: Serenity.IntegerEditor;
        DetailList: Report_UsersEditor;
    }
    class UsersForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface UsersListRequest extends Serenity.ListRequest {
        Rodcid?: number;
    }
}
declare namespace SAPWebPortal.Default {
    interface UsersRow {
        UserId?: number;
        Username?: string;
        DisplayName?: string;
        Email?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        LastDirectoryUpdate?: string;
        UserImage?: string;
        InsertDate?: string;
        InsertUserId?: number;
        UpdateDate?: string;
        UpdateUserId?: number;
        CompanyDatabase?: string;
        IsActive?: number;
        DetailList?: Report_UsersRow[];
    }
    namespace UsersRow {
        const idProperty = "UserId";
        const nameProperty = "Username";
        const localTextPrefix = "Default.Users";
        const lookupKey = "Default.Users";
        function getLookup(): Q.Lookup<UsersRow>;
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            UserId = "UserId",
            Username = "Username",
            DisplayName = "DisplayName",
            Email = "Email",
            Source = "Source",
            PasswordHash = "PasswordHash",
            PasswordSalt = "PasswordSalt",
            LastDirectoryUpdate = "LastDirectoryUpdate",
            UserImage = "UserImage",
            InsertDate = "InsertDate",
            InsertUserId = "InsertUserId",
            UpdateDate = "UpdateDate",
            UpdateUserId = "UpdateUserId",
            CompanyDatabase = "CompanyDatabase",
            IsActive = "IsActive",
            DetailList = "DetailList"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace UsersService {
        const baseUrl = "Default/Users";
        function Create(request: Serenity.SaveRequest<UsersRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UsersRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UsersRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UsersRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/Users/Create",
            Update = "Default/Users/Update",
            Delete = "Default/Users/Delete",
            Retrieve = "Default/Users/Retrieve",
            List = "Default/Users/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class WarehouseColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface WarehouseForm {
        WarehouseCode: Serenity.StringEditor;
        WarehouseName: Serenity.StringEditor;
    }
    class WarehouseForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    interface WarehouseRow {
        WarehouseCode?: string;
        WarehouseName?: string;
    }
    namespace WarehouseRow {
        const idProperty = "WarehouseCode";
        const nameProperty = "WarehouseCode";
        const localTextPrefix = "Default.Warehouse";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            WarehouseCode = "WarehouseCode",
            WarehouseName = "WarehouseName"
        }
    }
}
declare namespace SAPWebPortal.Default {
    namespace WarehouseService {
        const baseUrl = "Default/Warehouse";
        function Create(request: Serenity.SaveRequest<WarehouseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<WarehouseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<WarehouseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<WarehouseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/Warehouse/Create",
            Update = "Default/Warehouse/Update",
            Delete = "Default/Warehouse/Delete",
            Retrieve = "Default/Warehouse/Retrieve",
            List = "Default/Warehouse/List"
        }
    }
}
declare namespace SAPWebPortal.Delivery {
    class DocumentColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Delivery {
    interface DocumentForm {
        DocObjectCode: Modules.DropDownEnums.DraftDocsEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: DeliveryLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.DecimalEditor;
        TotalDiscount: Serenity.DecimalEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        Comments: Serenity.TextAreaEditor;
        GroupNumber: Default.SelectCodeNameValueEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_Address: Serenity.TextAreaEditor;
        AttachmentEntry: Serenity.ImageUploadEditor;
    }
    class DocumentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Delivery {
    interface DocumentRow {
        DocEntry?: number;
        Series?: number;
        DocNum?: number;
        DocType?: string;
        DocDate?: string;
        DocDueDate?: string;
        CardCode?: string;
        CardName?: string;
        DocTotal?: number;
        VatSum?: number;
        SalesPersonCode?: number;
        AttachmentEntry?: string;
        DiscountPercent?: number;
        DocumentsOwner?: number;
        DocumentStatus?: string;
        DocCurrency?: string;
        TotalDiscount?: number;
        UserSign?: number;
        Comments?: string;
        Project?: string;
        GroupNumber?: number;
        PayToCode?: string;
        ShipToCode?: string;
        U_Address?: string;
        NumAtCard?: string;
        DocObjectCode?: string;
        DocumentLines?: DeliveryLine.DocumentLineRow[];
    }
    namespace DocumentRow {
        const idProperty = "DocEntry";
        const nameProperty = "DocEntry";
        const localTextPrefix = "Delivery.Document";
        const deletePermission = "MarketingDocs:Delivery:Delete";
        const insertPermission = "MarketingDocs:Delivery:Insert";
        const readPermission = "MarketingDocs:Delivery:View";
        const updatePermission = "MarketingDocs:Delivery:Modify";
        const enum Fields {
            DocEntry = "DocEntry",
            Series = "Series",
            DocNum = "DocNum",
            DocType = "DocType",
            DocDate = "DocDate",
            DocDueDate = "DocDueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            DocTotal = "DocTotal",
            VatSum = "VatSum",
            SalesPersonCode = "SalesPersonCode",
            AttachmentEntry = "AttachmentEntry",
            DiscountPercent = "DiscountPercent",
            DocumentsOwner = "DocumentsOwner",
            DocumentStatus = "DocumentStatus",
            DocCurrency = "DocCurrency",
            TotalDiscount = "TotalDiscount",
            UserSign = "UserSign",
            Comments = "Comments",
            Project = "Project",
            GroupNumber = "GroupNumber",
            PayToCode = "PayToCode",
            ShipToCode = "ShipToCode",
            U_Address = "U_Address",
            NumAtCard = "NumAtCard",
            DocObjectCode = "DocObjectCode",
            DocumentLines = "DocumentLines"
        }
    }
}
declare namespace SAPWebPortal.Delivery {
    namespace DocumentService {
        const baseUrl = "Delivery/Document";
        function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Delivery/Document/Create",
            Update = "Delivery/Document/Update",
            Delete = "Delivery/Document/Delete",
            Retrieve = "Delivery/Document/Retrieve",
            List = "Delivery/Document/List"
        }
    }
}
declare namespace SAPWebPortal.DeliveryLine {
    class DocumentLineColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.DeliveryLine {
    interface DocumentLineForm {
        LineNum: Serenity.IntegerEditor;
        ItemCode: _Ext.GridItemPickerEditor;
        ItemDescription: Serenity.StringEditor;
        AccountCode: _Ext.GridItemPickerEditor;
        Quantity: Serenity.DecimalEditor;
        UnitsOfMeasurment: Serenity.DecimalEditor;
        UnitPrice: Serenity.DecimalEditor;
        DiscountPercent: Serenity.DecimalEditor;
        VatGroup: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        UoMCode: Serenity.StringEditor;
        PriceAfterVat: Serenity.DecimalEditor;
        TaxTotal: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        GrossTotal: Serenity.DecimalEditor;
    }
    class DocumentLineForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.DeliveryLine {
    interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        ItemDescription?: string;
        Quantity?: number;
        UnitsOfMeasurment?: number;
        VatGroup?: string;
        UnitPrice?: number;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        AccountCode?: string;
        GrossTotal?: number;
        TaxTotal?: number;
    }
    namespace DocumentLineRow {
        const idProperty = "LineNum";
        const localTextPrefix = "DeliveryLine.DocumentLine";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            Quantity = "Quantity",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            AccountCode = "AccountCode",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal"
        }
    }
}
declare namespace SAPWebPortal.DeliveryLine {
    namespace DocumentLineService {
        const baseUrl = "DeliveryLine/DocumentLine";
        function Create(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "DeliveryLine/DocumentLine/Create",
            Update = "DeliveryLine/DocumentLine/Update",
            Delete = "DeliveryLine/DocumentLine/Delete",
            Retrieve = "DeliveryLine/DocumentLine/Retrieve",
            List = "DeliveryLine/DocumentLine/List"
        }
    }
}
declare namespace SAPWebPortal.Drafts {
    class DocumentColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Drafts {
    interface DocumentForm {
        DocObjectCode: Modules.DropDownEnums.DraftDocsEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: DraftsLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.DecimalEditor;
        TotalDiscount: Serenity.DecimalEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        Comments: Serenity.TextAreaEditor;
        GroupNumber: Default.SelectCodeNameValueEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_Address: Serenity.TextAreaEditor;
        AttachmentEntry: Serenity.ImageUploadEditor;
    }
    class DocumentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Drafts {
    interface DocumentRow {
        DocEntry?: number;
        Series?: number;
        DocNum?: number;
        DocType?: string;
        DocDate?: string;
        DocDueDate?: string;
        CardCode?: string;
        CardName?: string;
        DocTotal?: number;
        VatSum?: number;
        SalesPersonCode?: number;
        AttachmentEntry?: string;
        DiscountPercent?: number;
        DocumentsOwner?: number;
        DocumentStatus?: string;
        DocCurrency?: string;
        TotalDiscount?: number;
        UserSign?: number;
        Comments?: string;
        Project?: string;
        GroupNumber?: number;
        PayToCode?: string;
        ShipToCode?: string;
        U_Address?: string;
        NumAtCard?: string;
        DocObjectCode?: string;
        DocumentLines?: DraftsLine.DocumentLineRow[];
    }
    namespace DocumentRow {
        const idProperty = "DocEntry";
        const nameProperty = "DocEntry";
        const localTextPrefix = "Drafts.Document";
        const deletePermission = "ApprovalProcess:Drafts:Delete";
        const insertPermission = "ApprovalProcess:Drafts:Insert";
        const readPermission = "ApprovalProcess:Drafts:View";
        const updatePermission = "ApprovalProcess:Drafts:Modify";
        const enum Fields {
            DocEntry = "DocEntry",
            Series = "Series",
            DocNum = "DocNum",
            DocType = "DocType",
            DocDate = "DocDate",
            DocDueDate = "DocDueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            DocTotal = "DocTotal",
            VatSum = "VatSum",
            SalesPersonCode = "SalesPersonCode",
            AttachmentEntry = "AttachmentEntry",
            DiscountPercent = "DiscountPercent",
            DocumentsOwner = "DocumentsOwner",
            DocumentStatus = "DocumentStatus",
            DocCurrency = "DocCurrency",
            TotalDiscount = "TotalDiscount",
            UserSign = "UserSign",
            Comments = "Comments",
            Project = "Project",
            GroupNumber = "GroupNumber",
            PayToCode = "PayToCode",
            ShipToCode = "ShipToCode",
            U_Address = "U_Address",
            NumAtCard = "NumAtCard",
            DocObjectCode = "DocObjectCode",
            DocumentLines = "DocumentLines"
        }
    }
}
declare namespace SAPWebPortal.Drafts {
    namespace DocumentService {
        const baseUrl = "Drafts/Document";
        function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Drafts/Document/Create",
            Update = "Drafts/Document/Update",
            Delete = "Drafts/Document/Delete",
            Retrieve = "Drafts/Document/Retrieve",
            List = "Drafts/Document/List"
        }
    }
}
declare namespace SAPWebPortal.DraftsExpense {
    class DocumentAdditionalExpenseColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.DraftsExpense {
    interface DocumentAdditionalExpenseForm {
        LineNum: Serenity.IntegerEditor;
        ExpenseCode: _Ext.GridItemPickerEditor;
        U_Amount: Serenity.DecimalEditor;
        VatGroup: _Ext.GridItemPickerEditor;
        TaxPercent: Serenity.DecimalEditor;
        TaxSum: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class DocumentAdditionalExpenseForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.DraftsExpense {
    interface DocumentAdditionalExpenseRow {
        ExpenseCode?: number;
        LineNum?: number;
        LineTotal?: number;
        VatGroup?: string;
        TaxPercent?: number;
        TaxSum?: number;
        Remarks?: string;
        U_Amount?: number;
    }
    namespace DocumentAdditionalExpenseRow {
        const idProperty = "ExpenseCode";
        const localTextPrefix = "DraftsExpense.DocumentAdditionalExpense";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            ExpenseCode = "ExpenseCode",
            LineNum = "LineNum",
            LineTotal = "LineTotal",
            VatGroup = "VatGroup",
            TaxPercent = "TaxPercent",
            TaxSum = "TaxSum",
            Remarks = "Remarks",
            U_Amount = "U_Amount"
        }
    }
}
declare namespace SAPWebPortal.DraftsExpense {
    namespace DocumentAdditionalExpenseService {
        const baseUrl = "DraftsExpense/DocumentAdditionalExpense";
        function Create(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "DraftsExpense/DocumentAdditionalExpense/Create",
            Update = "DraftsExpense/DocumentAdditionalExpense/Update",
            Delete = "DraftsExpense/DocumentAdditionalExpense/Delete",
            Retrieve = "DraftsExpense/DocumentAdditionalExpense/Retrieve",
            List = "DraftsExpense/DocumentAdditionalExpense/List"
        }
    }
}
declare namespace SAPWebPortal.DraftsLine {
    class DocumentLineColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.DraftsLine {
    interface DocumentLineForm {
        LineNum: Serenity.IntegerEditor;
        ItemCode: _Ext.GridItemPickerEditor;
        ItemDescription: Serenity.StringEditor;
        AccountCode: _Ext.GridItemPickerEditor;
        Quantity: Serenity.DecimalEditor;
        UnitsOfMeasurment: Serenity.DecimalEditor;
        UnitPrice: Serenity.DecimalEditor;
        DiscountPercent: Serenity.DecimalEditor;
        VatGroup: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        UoMCode: Serenity.StringEditor;
        PriceAfterVat: Serenity.DecimalEditor;
        TaxTotal: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        GrossTotal: Serenity.DecimalEditor;
    }
    class DocumentLineForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.DraftsLine {
    interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        ItemDescription?: string;
        Quantity?: number;
        InventoryQuantity?: number;
        UnitsOfMeasurment?: number;
        VatGroup?: string;
        UnitPrice?: number;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        AccountCode?: string;
        GrossTotal?: number;
        TaxTotal?: number;
    }
    namespace DocumentLineRow {
        const idProperty = "LineNum";
        const localTextPrefix = "DraftsLine.DocumentLine";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            Quantity = "Quantity",
            InventoryQuantity = "InventoryQuantity",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            AccountCode = "AccountCode",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal"
        }
    }
}
declare namespace SAPWebPortal.DraftsLine {
    namespace DocumentLineService {
        const baseUrl = "DraftsLine/DocumentLine";
        function Create(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "DraftsLine/DocumentLine/Create",
            Update = "DraftsLine/DocumentLine/Update",
            Delete = "DraftsLine/DocumentLine/Delete",
            Retrieve = "DraftsLine/DocumentLine/Retrieve",
            List = "DraftsLine/DocumentLine/List"
        }
    }
}
declare namespace SAPWebPortal.Membership {
    interface ChangePasswordForm {
        OldPassword: Serenity.PasswordEditor;
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class ChangePasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Membership {
    interface ChangePasswordRequest extends Serenity.ServiceRequest {
        OldPassword?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace SAPWebPortal.Membership {
    interface ForgotPasswordForm {
        Email: Serenity.EmailAddressEditor;
    }
    class ForgotPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Membership {
    interface ForgotPasswordRequest extends Serenity.ServiceRequest {
        Email?: string;
    }
}
declare namespace SAPWebPortal.Membership {
    interface LoginForm {
        Username: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
        CompanyDatabase: Serenity.LookupEditor;
    }
    class LoginForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Membership {
    interface LoginRequest extends Serenity.ServiceRequest {
        Username?: string;
        Password?: string;
        CompanyDatabase?: string;
    }
}
declare namespace SAPWebPortal.Membership {
    interface ResetPasswordForm {
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class ResetPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Membership {
    interface ResetPasswordRequest extends Serenity.ServiceRequest {
        Token?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace SAPWebPortal.Membership {
    interface SignUpForm {
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailAddressEditor;
        ConfirmEmail: Serenity.EmailAddressEditor;
        Password: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
    class SignUpForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Membership {
    interface SignUpRequest extends Serenity.ServiceRequest {
        DisplayName?: string;
        Email?: string;
        Password?: string;
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    enum StatusEnum {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }
}
declare namespace SAPWebPortal.Orders {
    class DocumentColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Orders {
    interface DocumentForm {
        Series: Default.SelectCodeNameValueEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: OrdersLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.DecimalEditor;
        TotalDiscount: Serenity.DecimalEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        Comments: Serenity.TextAreaEditor;
        GroupNum: Serenity.IntegerEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_Address: Default.SelectCodeNameValueEditor;
        AttachmentEntry: Serenity.ImageUploadEditor;
    }
    class DocumentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Orders {
    interface DocumentRow {
        DocEntry?: number;
        Series?: number;
        DocNum?: number;
        DocType?: string;
        DocDate?: string;
        DocDueDate?: string;
        CardCode?: string;
        CardName?: string;
        DocTotal?: number;
        VatSum?: number;
        SalesPersonCode?: number;
        AttachmentEntry?: string;
        DiscountPercent?: number;
        DocumentsOwner?: number;
        DocumentStatus?: string;
        DocCurrency?: string;
        TotalDiscount?: number;
        UserSign?: number;
        Comments?: string;
        Project?: string;
        GroupNum?: number;
        PayToCode?: string;
        ShipToCode?: string;
        U_ApprovalGUID?: string;
        U_Address?: string;
        NumAtCard?: string;
        DocumentLines?: OrdersLine.DocumentLineRow[];
    }
    namespace DocumentRow {
        const idProperty = "DocEntry";
        const localTextPrefix = "Orders.Document";
        const deletePermission = "MarketingDocs:SalesOrder:Delete";
        const insertPermission = "MarketingDocs:SalesOrder:Insert";
        const readPermission = "MarketingDocs:SalesOrder:View";
        const updatePermission = "MarketingDocs:SalesOrder:Modify";
        const enum Fields {
            DocEntry = "DocEntry",
            Series = "Series",
            DocNum = "DocNum",
            DocType = "DocType",
            DocDate = "DocDate",
            DocDueDate = "DocDueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            DocTotal = "DocTotal",
            VatSum = "VatSum",
            SalesPersonCode = "SalesPersonCode",
            AttachmentEntry = "AttachmentEntry",
            DiscountPercent = "DiscountPercent",
            DocumentsOwner = "DocumentsOwner",
            DocumentStatus = "DocumentStatus",
            DocCurrency = "DocCurrency",
            TotalDiscount = "TotalDiscount",
            UserSign = "UserSign",
            Comments = "Comments",
            Project = "Project",
            GroupNum = "GroupNum",
            PayToCode = "PayToCode",
            ShipToCode = "ShipToCode",
            U_ApprovalGUID = "U_ApprovalGUID",
            U_Address = "U_Address",
            NumAtCard = "NumAtCard",
            DocumentLines = "DocumentLines"
        }
    }
}
declare namespace SAPWebPortal.Orders {
    namespace DocumentService {
        const baseUrl = "Orders/Document";
        function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function CheckStatus(request: DocumentRow, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetDownloadFile(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Orders/Document/Create",
            Update = "Orders/Document/Update",
            Delete = "Orders/Document/Delete",
            CheckStatus = "Orders/Document/CheckStatus",
            Retrieve = "Orders/Document/Retrieve",
            List = "Orders/Document/List",
            GetDownloadFile = "Orders/Document/GetDownloadFile"
        }
    }
}
declare namespace SAPWebPortal.OrdersExpense {
    class DocumentAdditionalExpenseColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.OrdersExpense {
    interface DocumentAdditionalExpenseForm {
        LineNum: Serenity.IntegerEditor;
        ExpenseCode: _Ext.GridItemPickerEditor;
        U_Amount: Serenity.DecimalEditor;
        VatGroup: _Ext.GridItemPickerEditor;
        TaxPercent: Serenity.DecimalEditor;
        TaxSum: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class DocumentAdditionalExpenseForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.OrdersExpense {
    interface DocumentAdditionalExpenseRow {
        ExpenseCode?: number;
        LineNum?: number;
        LineTotal?: number;
        VatGroup?: string;
        TaxPercent?: number;
        TaxSum?: number;
        Remarks?: string;
        U_Amount?: number;
    }
    namespace DocumentAdditionalExpenseRow {
        const idProperty = "ExpenseCode";
        const localTextPrefix = "OrdersExpense.DocumentAdditionalExpense";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            ExpenseCode = "ExpenseCode",
            LineNum = "LineNum",
            LineTotal = "LineTotal",
            VatGroup = "VatGroup",
            TaxPercent = "TaxPercent",
            TaxSum = "TaxSum",
            Remarks = "Remarks",
            U_Amount = "U_Amount"
        }
    }
}
declare namespace SAPWebPortal.OrdersExpense {
    namespace DocumentAdditionalExpenseService {
        const baseUrl = "OrdersExpense/DocumentAdditionalExpense";
        function Create(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "OrdersExpense/DocumentAdditionalExpense/Create",
            Update = "OrdersExpense/DocumentAdditionalExpense/Update",
            Delete = "OrdersExpense/DocumentAdditionalExpense/Delete",
            Retrieve = "OrdersExpense/DocumentAdditionalExpense/Retrieve",
            List = "OrdersExpense/DocumentAdditionalExpense/List"
        }
    }
}
declare namespace SAPWebPortal.OrdersLine {
    class DocumentLineColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.OrdersLine {
    interface DocumentLineForm {
        LineNum: Serenity.IntegerEditor;
        ItemCode: _Ext.GridItemPickerEditor;
        ItemDescription: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        UnitsOfMeasurment: Serenity.DecimalEditor;
        UnitPrice: Serenity.DecimalEditor;
        DiscountPercent: Serenity.DecimalEditor;
        VatGroup: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        UoMCode: Serenity.StringEditor;
        PriceAfterVat: Serenity.DecimalEditor;
        TaxTotal: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
    }
    class DocumentLineForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.OrdersLine {
    interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        ItemDescription?: string;
        Quantity?: number;
        InventoryQuantity?: number;
        UnitsOfMeasurment?: number;
        VatGroup?: string;
        UnitPrice?: number;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        AccountCode?: string;
        GrossTotal?: number;
        TaxTotal?: number;
    }
    namespace DocumentLineRow {
        const idProperty = "LineNum";
        const localTextPrefix = "OrdersLine.DocumentLine";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            Quantity = "Quantity",
            InventoryQuantity = "InventoryQuantity",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            AccountCode = "AccountCode",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal"
        }
    }
}
declare namespace SAPWebPortal.OrdersLine {
    namespace DocumentLineService {
        const baseUrl = "OrdersLine/DocumentLine";
        function Create(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "OrdersLine/DocumentLine/Create",
            Update = "OrdersLine/DocumentLine/Update",
            Delete = "OrdersLine/DocumentLine/Delete",
            Retrieve = "OrdersLine/DocumentLine/Retrieve",
            List = "OrdersLine/DocumentLine/List"
        }
    }
}
declare namespace SAPWebPortal.Quotations {
    class DocumentColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Quotations {
    interface DocumentForm {
        Series: Default.SelectCodeNameValueEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: QuotationsLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.DecimalEditor;
        TotalDiscount: Serenity.DecimalEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        Comments: Serenity.TextAreaEditor;
        GroupNumber: Default.SelectCodeNameValueEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_Address: Serenity.TextAreaEditor;
        AttachmentEntry: Serenity.ImageUploadEditor;
    }
    class DocumentForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Quotations {
    interface DocumentRow {
        DocEntry?: number;
        Series?: number;
        DocNum?: number;
        DocType?: string;
        DocDate?: string;
        DocDueDate?: string;
        CardCode?: string;
        CardName?: string;
        DocTotal?: number;
        VatSum?: number;
        SalesPersonCode?: number;
        AttachmentEntry?: string;
        DiscountPercent?: number;
        DocumentsOwner?: number;
        DocumentStatus?: string;
        DocCurrency?: string;
        TotalDiscount?: number;
        UserSign?: number;
        Comments?: string;
        Project?: string;
        GroupNumber?: number;
        PayToCode?: string;
        ShipToCode?: string;
        NumAtCard?: string;
        U_ApprovalGUID?: string;
        U_Address?: string;
        DocumentLines?: QuotationsLine.DocumentLineRow[];
    }
    namespace DocumentRow {
        const idProperty = "DocEntry";
        const localTextPrefix = "Quotations.Document";
        const deletePermission = "MarketingDocs:SalesQuotations:Delete";
        const insertPermission = "MarketingDocs:SalesQuotations:Insert";
        const readPermission = "MarketingDocs:SalesQuotations:View";
        const updatePermission = "MarketingDocs:SalesQuotations:Modify";
        const enum Fields {
            DocEntry = "DocEntry",
            Series = "Series",
            DocNum = "DocNum",
            DocType = "DocType",
            DocDate = "DocDate",
            DocDueDate = "DocDueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            DocTotal = "DocTotal",
            VatSum = "VatSum",
            SalesPersonCode = "SalesPersonCode",
            AttachmentEntry = "AttachmentEntry",
            DiscountPercent = "DiscountPercent",
            DocumentsOwner = "DocumentsOwner",
            DocumentStatus = "DocumentStatus",
            DocCurrency = "DocCurrency",
            TotalDiscount = "TotalDiscount",
            UserSign = "UserSign",
            Comments = "Comments",
            Project = "Project",
            GroupNumber = "GroupNumber",
            PayToCode = "PayToCode",
            ShipToCode = "ShipToCode",
            NumAtCard = "NumAtCard",
            U_ApprovalGUID = "U_ApprovalGUID",
            U_Address = "U_Address",
            DocumentLines = "DocumentLines"
        }
    }
}
declare namespace SAPWebPortal.Quotations {
    namespace DocumentService {
        const baseUrl = "Quotations/Document";
        function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function CheckStatus(request: DocumentRow, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function GetDownloadFile(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Quotations/Document/Create",
            Update = "Quotations/Document/Update",
            Delete = "Quotations/Document/Delete",
            Retrieve = "Quotations/Document/Retrieve",
            List = "Quotations/Document/List",
            CheckStatus = "Quotations/Document/CheckStatus",
            GetDownloadFile = "Quotations/Document/GetDownloadFile"
        }
    }
}
declare namespace SAPWebPortal.QuotationsExpense {
    class DocumentAdditionalExpenseColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.QuotationsExpense {
    interface DocumentAdditionalExpenseForm {
        LineNum: Serenity.IntegerEditor;
        ExpenseCode: _Ext.GridItemPickerEditor;
        U_Amount: Serenity.DecimalEditor;
        VatGroup: _Ext.GridItemPickerEditor;
        TaxPercent: Serenity.DecimalEditor;
        TaxSum: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
    }
    class DocumentAdditionalExpenseForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.QuotationsExpense {
    interface DocumentAdditionalExpenseRow {
        ExpenseCode?: number;
        LineNum?: number;
        LineTotal?: number;
        VatGroup?: string;
        TaxPercent?: number;
        TaxSum?: number;
        Remarks?: string;
        U_Amount?: number;
    }
    namespace DocumentAdditionalExpenseRow {
        const idProperty = "ExpenseCode";
        const localTextPrefix = "QuotationsExpense.DocumentAdditionalExpense";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            ExpenseCode = "ExpenseCode",
            LineNum = "LineNum",
            LineTotal = "LineTotal",
            VatGroup = "VatGroup",
            TaxPercent = "TaxPercent",
            TaxSum = "TaxSum",
            Remarks = "Remarks",
            U_Amount = "U_Amount"
        }
    }
}
declare namespace SAPWebPortal.QuotationsExpense {
    namespace DocumentAdditionalExpenseService {
        const baseUrl = "QuotationsExpense/DocumentAdditionalExpense";
        function Create(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "QuotationsExpense/DocumentAdditionalExpense/Create",
            Update = "QuotationsExpense/DocumentAdditionalExpense/Update",
            Delete = "QuotationsExpense/DocumentAdditionalExpense/Delete",
            Retrieve = "QuotationsExpense/DocumentAdditionalExpense/Retrieve",
            List = "QuotationsExpense/DocumentAdditionalExpense/List"
        }
    }
}
declare namespace SAPWebPortal.QuotationsLine {
    class DocumentLineColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.QuotationsLine {
    interface DocumentLineForm {
        LineNum: Serenity.IntegerEditor;
        ItemCode: _Ext.GridItemPickerEditor;
        ItemDescription: Serenity.StringEditor;
        AccountCode: _Ext.GridItemPickerEditor;
        Quantity: Serenity.DecimalEditor;
        UnitsOfMeasurment: Serenity.DecimalEditor;
        UnitPrice: Serenity.DecimalEditor;
        DiscountPercent: Serenity.DecimalEditor;
        VatGroup: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        UoMCode: Serenity.StringEditor;
        PriceAfterVat: Serenity.DecimalEditor;
        TaxTotal: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        GrossTotal: Serenity.DecimalEditor;
    }
    class DocumentLineForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.QuotationsLine {
    interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        ItemDescription?: string;
        AccountCode?: string;
        Quantity?: number;
        UnitsOfMeasurment?: number;
        VatGroup?: string;
        UnitPrice?: number;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        GrossTotal?: number;
        TaxTotal?: number;
    }
    namespace DocumentLineRow {
        const idProperty = "LineNum";
        const localTextPrefix = "QuotationsLine.DocumentLine";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            AccountCode = "AccountCode",
            Quantity = "Quantity",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal"
        }
    }
}
declare namespace SAPWebPortal.QuotationsLine {
    namespace DocumentLineService {
        const baseUrl = "QuotationsLine/DocumentLine";
        function Create(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "QuotationsLine/DocumentLine/Create",
            Update = "QuotationsLine/DocumentLine/Update",
            Delete = "QuotationsLine/DocumentLine/Delete",
            Retrieve = "QuotationsLine/DocumentLine/Retrieve",
            List = "QuotationsLine/DocumentLine/List"
        }
    }
}
declare namespace SAPB1 {
    enum BoBusinessPartnerGroupTypes {
        bbpgt_CustomerGroup = 0,
        bbpgt_VendorGroup = 1
    }
}
declare namespace SAPWebPortal {
    interface ScriptUserDefinition {
        Username?: string;
        DisplayName?: string;
        IsAdmin?: boolean;
        Permissions?: {
            [key: string]: boolean;
        };
    }
}
declare namespace SAPWebPortal.Texts {
}
declare namespace SAPWebPortal.VatGroups {
    class VatGroupColumns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.VatGroups {
    interface VatGroupForm {
        Name: Serenity.StringEditor;
        Inactive: Modules.DropDownEnums.YesOrNoEditor;
    }
    class VatGroupForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.VatGroups {
    interface VatGroupRow {
        Code?: string;
        Name?: string;
        Inactive?: string;
    }
    namespace VatGroupRow {
        const idProperty = "Code";
        const nameProperty = "Code";
        const localTextPrefix = "VatGroups.VatGroup";
        const deletePermission = "Administration:DefaultGeneral";
        const insertPermission = "Administration:DefaultGeneral";
        const readPermission = "Administration:DefaultGeneral";
        const updatePermission = "Administration:DefaultGeneral";
        const enum Fields {
            Code = "Code",
            Name = "Name",
            Inactive = "Inactive"
        }
    }
}
declare namespace SAPWebPortal.VatGroups {
    namespace VatGroupService {
        const baseUrl = "VatGroups/VatGroup";
        function Create(request: Serenity.SaveRequest<VatGroupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VatGroupRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VatGroupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VatGroupRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "VatGroups/VatGroup/Create",
            Update = "VatGroups/VatGroup/Update",
            Delete = "VatGroups/VatGroup/Delete",
            Retrieve = "VatGroups/VatGroup/Retrieve",
            List = "VatGroups/VatGroup/List"
        }
    }
}
declare namespace _Ext {
    enum AuditActionType {
        Insert = 1,
        Update = 2,
        Delete = 3
    }
}
declare namespace _Ext {
    class AuditLogColumns {
        static columnsKey: string;
    }
}
declare namespace _Ext {
    interface AuditLogForm {
        EntityTableName: Serenity.StringEditor;
        ActionType: Serenity.EnumEditor;
        ActionDate: Serenity.DateTimeEditor;
        EntityId: Serenity.IntegerEditor;
        Changes: StaticTextBlock;
        UserId: Serenity.LookupEditor;
        IpAddress: Serenity.StringEditor;
        SessionId: Serenity.StringEditor;
    }
    class AuditLogForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace _Ext {
    interface AuditLogRow {
        Id?: number;
        UserId?: number;
        ActionType?: AuditActionType;
        ActionDate?: string;
        EntityTableName?: string;
        EntityId?: number;
        Changes?: string;
        IpAddress?: string;
        SessionId?: string;
    }
    namespace AuditLogRow {
        const idProperty = "Id";
        const nameProperty = "EntityTableName";
        const localTextPrefix = "_Ext.AuditLog";
        const deletePermission = "Administration:AuditLog";
        const insertPermission = "Administration:AuditLog";
        const readPermission = "Administration:AuditLog";
        const updatePermission = "Administration:AuditLog";
        const enum Fields {
            Id = "Id",
            UserId = "UserId",
            ActionType = "ActionType",
            ActionDate = "ActionDate",
            EntityTableName = "EntityTableName",
            EntityId = "EntityId",
            Changes = "Changes",
            IpAddress = "IpAddress",
            SessionId = "SessionId"
        }
    }
}
declare namespace _Ext {
    namespace AuditLogService {
        const baseUrl = "_Ext/AuditLog";
        function Create(request: Serenity.SaveRequest<AuditLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<AuditLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<AuditLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<AuditLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "_Ext/AuditLog/Create",
            Update = "_Ext/AuditLog/Update",
            Delete = "_Ext/AuditLog/Delete",
            Retrieve = "_Ext/AuditLog/Retrieve",
            List = "_Ext/AuditLog/List"
        }
    }
}
declare namespace _Ext {
    interface AuditLogViewerRequest extends Serenity.ServiceRequest {
        FormKey?: string;
        EntityId?: number;
    }
}
declare namespace _Ext {
    interface AuditLogViewerResponse extends Serenity.ServiceResponse {
        EntityVersions?: AuditLogRow[];
    }
}
declare namespace _Ext {
    namespace AuditLogViewerService {
        const baseUrl = "AuditLogViewer";
        function List(request: AuditLogViewerRequest, onSuccess?: (response: AuditLogViewerResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            List = "AuditLogViewer/List"
        }
    }
}
declare namespace _Ext.DevTools {
    interface SergenConnection {
        Key?: string;
    }
}
declare namespace _Ext.DevTools {
    interface SergenGenerateOptions {
        Row?: boolean;
        Service?: boolean;
        UI?: boolean;
    }
}
declare namespace _Ext.DevTools {
    interface SergenGenerateRequest extends Serenity.ServiceRequest {
        ConnectionKey?: string;
        Table?: SergenTable;
        GenerateOptions?: SergenGenerateOptions;
    }
}
declare namespace _Ext.DevTools {
    interface SergenListTablesRequest extends Serenity.ServiceRequest {
        ConnectionKey?: string;
    }
}
declare namespace _Ext.DevTools {
    namespace SergenService {
        const baseUrl = "Administration/Sergen";
        function ListConnections(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<SergenConnection>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListTables(request: SergenListTablesRequest, onSuccess?: (response: Serenity.ListResponse<SergenTable>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Generate(request: SergenGenerateRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            ListConnections = "Administration/Sergen/ListConnections",
            ListTables = "Administration/Sergen/ListTables",
            Generate = "Administration/Sergen/Generate"
        }
    }
}
declare namespace _Ext.DevTools {
    interface SergenTable {
        Tablename?: string;
        Identifier?: string;
        Module?: string;
        PermissionKey?: string;
    }
}
declare namespace _Ext {
    interface EntityReportRequest extends Serenity.RetrieveRequest {
        ReportKey?: string;
        ReportServiceMethodName?: string;
        ReportDesignPath?: string;
    }
}
declare namespace _Ext {
    interface ListReportRequest extends Serenity.ListRequest {
        ReportKey?: string;
        ReportServiceMethodName?: string;
        ListExcelServiceMethodName?: string;
        ReportDesignPath?: string;
        EqualityFilterWithTextValue?: {
            [key: string]: string;
        };
        CustomParameters?: {
            [key: string]: any;
        };
    }
}
declare namespace _Ext {
    enum Months {
        January = 0,
        February = 1,
        March = 2,
        April = 3,
        May = 4,
        June = 5,
        July = 6,
        August = 7,
        September = 8,
        October = 9,
        November = 10,
        December = 11
    }
}
declare namespace _Ext {
    interface ReplaceRowForm {
        DeletedEntityName: Serenity.StringEditor;
        ReplaceWithEntityId: EmptyLookupEditor;
    }
    class ReplaceRowForm extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace _Ext {
    interface ReplaceRowRequest extends Serenity.ServiceRequest {
        FormKey?: string;
        IdProperty?: string;
        NameProperty?: string;
        EntityTypeTitle?: string;
        DeletedEntityId?: number;
        DeletedEntityName?: string;
        ReplaceWithEntityId?: number;
    }
}
declare namespace _Ext {
    interface ReplaceRowResponse extends Serenity.ServiceResponse {
    }
}
declare namespace _Ext {
    namespace ReplaceRowService {
        const baseUrl = "ReplaceRow";
        function Replace(request: ReplaceRowRequest, onSuccess?: (response: ReplaceRowResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Replace = "ReplaceRow/Replace"
        }
    }
}
declare namespace _Ext {
    enum TimeUoM {
        Hour = 1,
        Day = 2,
        Week = 3,
        Month = 4,
        CalenderMonth = 5,
        Year = 6
    }
}
declare namespace SAPWebPortal.Administration {
    class ExceptionsDialog extends Serenity.EntityDialog<ExceptionsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: ExceptionsForm;
    }
}
declare namespace SAPWebPortal.Administration {
    class ExceptionsGrid extends Serenity.EntityGrid<ExceptionsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ExceptionsDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Administration {
    class LanguageDialog extends Serenity.EntityDialog<LanguageRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: LanguageForm;
    }
}
declare namespace SAPWebPortal.Administration {
    class LanguageGrid extends Serenity.EntityGrid<LanguageRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LanguageDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): LanguageRow.Fields[];
    }
}
declare namespace SAPWebPortal.Administration {
    class LogDialog extends Serenity.EntityDialog<LogRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: LogForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Administration {
    class LogGrid extends Serenity.EntityGrid<LogRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LogDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Administration {
    class RoleDialog extends Serenity.EntityDialog<RoleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: RoleForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
    }
}
declare namespace SAPWebPortal.Administration {
    class RoleGrid extends Serenity.EntityGrid<RoleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof RoleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): RoleRow.Fields[];
    }
}
declare namespace SAPWebPortal.Administration {
    class RolePermissionDialog extends Serenity.TemplatedDialog<RolePermissionDialogOptions> {
        private permissions;
        constructor(opt: RolePermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface RolePermissionDialogOptions {
        roleID?: number;
        title?: string;
    }
}
declare namespace SAPWebPortal.Administration {
    class SessionsDialog extends Serenity.EntityDialog<SessionsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: SessionsForm;
    }
}
declare namespace SAPWebPortal.Administration {
    class SessionsGrid extends Serenity.EntityGrid<SessionsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof SessionsDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Administration {
    class TranslationGrid extends Serenity.EntityGrid<TranslationItem, any> {
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private hasChanges;
        private searchText;
        private sourceLanguage;
        private targetLanguage;
        private targetLanguageKey;
        constructor(container: JQuery);
        protected onClick(e: JQueryEventObject, row: number, cell: number): any;
        protected getColumns(): Slick.Column[];
        protected createToolbarExtensions(): void;
        protected saveChanges(language: string): PromiseLike<any>;
        protected onViewSubmit(): boolean;
        protected getButtons(): Serenity.ToolButton[];
        protected createQuickSearchInput(): void;
        protected onViewFilter(item: TranslationItem): boolean;
        protected usePager(): boolean;
    }
}
declare namespace SAPWebPortal.Administration {
    class UserDialog extends Serenity.EntityDialog<UserRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: UserForm;
        static Form: UserForm;
        constructor();
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
        protected afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Administration {
    class UserGrid extends Serenity.EntityGrid<UserRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDialog;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): UserRow.Fields[];
    }
}
declare namespace SAPWebPortal.Authorization {
    let userDefinition: ScriptUserDefinition;
    function hasPermission(permissionKey: string): boolean;
}
declare namespace SAPWebPortal.Administration {
    class PermissionCheckEditor extends Serenity.DataGrid<PermissionCheckItem, PermissionCheckEditorOptions> {
        protected getIdProperty(): string;
        private searchText;
        private byParentKey;
        constructor(container: JQuery, opt: PermissionCheckEditorOptions);
        private getItemGrantRevokeClass;
        private roleOrImplicit;
        private getItemEffectiveClass;
        protected getColumns(): Slick.Column[];
        setItems(items: PermissionCheckItem[]): void;
        protected onViewSubmit(): boolean;
        protected onViewFilter(item: PermissionCheckItem): boolean;
        private matchContains;
        private getDescendants;
        protected onClick(e: any, row: any, cell: any): void;
        private getParentKey;
        protected getButtons(): Serenity.ToolButton[];
        protected createToolbarExtensions(): void;
        private getSortedGroupAndPermissionKeys;
        get value(): UserPermissionRow[];
        set value(value: UserPermissionRow[]);
        private _rolePermissions;
        get rolePermissions(): string[];
        set rolePermissions(value: string[]);
        private _implicitPermissions;
        set implicitPermissions(value: Q.Dictionary<string[]>);
    }
    interface PermissionCheckEditorOptions {
        showRevoke?: boolean;
    }
    interface PermissionCheckItem {
        ParentKey?: string;
        Key?: string;
        Title?: string;
        IsGroup?: boolean;
        GrantRevoke?: boolean;
    }
}
declare namespace SAPWebPortal.Administration {
    class UserPermissionDialog extends Serenity.TemplatedDialog<UserPermissionDialogOptions> {
        private permissions;
        constructor(opt: UserPermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserPermissionDialogOptions {
        userID?: number;
        username?: string;
    }
}
declare namespace SAPWebPortal.Administration {
    class RoleCheckEditor extends Serenity.CheckTreeEditor<Serenity.CheckTreeItem<any>, any> {
        private searchText;
        constructor(div: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): any[];
        protected getTreeItems(): Serenity.CheckTreeItem<any>[];
        protected onViewFilter(item: any): boolean;
    }
}
declare namespace SAPWebPortal.Administration {
    class UserRoleDialog extends Serenity.TemplatedDialog<UserRoleDialogOptions> {
        private permissions;
        constructor(opt: UserRoleDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserRoleDialogOptions {
        userID: number;
        username: string;
    }
}
declare namespace SAPWebPortal.LanguageList {
    function getValue(): string[][];
}
declare namespace SAPWebPortal.ScriptInitialization {
}
declare namespace SAPWebPortal.Helpers {
    class BusinessFormHelper {
        constructor(form?: Serenity.PrefixedContext, dropdownfields?: string[], service?: string, dialog?: any);
        protected entity: any;
        protected service: string;
        protected dropdownfields: string[];
        protected form: Serenity.PrefixedContext;
        protected FillDropDown(propertyNameSAP: string): void;
    }
}
declare namespace SAPWebPortal.Helpers {
    class DocTotalHelper {
        constructor(form?: Serenity.PrefixedContext, service?: string);
        CalculateDocTotal(Form: any): void;
    }
}
declare namespace SAPWebPortal.Common {
    class SidebarSearch extends Serenity.Widget<any> {
        private menuUL;
        constructor(input: JQuery, menuUL: JQuery);
        protected updateMatchFlags(text: string): void;
    }
}
declare namespace SAPWebPortal.Default {
    class AdditionalExpenseDialog extends Serenity.EntityDialog<AdditionalExpenseRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: AdditionalExpenseForm;
    }
}
declare namespace SAPWebPortal.Default {
    class AdditionalExpenseGrid extends _Ext.GridBase1<AdditionalExpenseRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AdditionalExpenseDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getButtons(): Serenity.ToolButton[];
        constructor(container: JQuery, options?: any);
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestDialog extends Serenity.EntityDialog<ApprovalRequestRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: ApprovalRequestForm;
        static Form: ApprovalRequestForm;
        constructor(opt?: any);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestGrid extends Serenity.EntityGrid<ApprovalRequestRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ApprovalRequestDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery, options?: any);
        protected getButtons(): Serenity.ToolButton[];
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestDecisionDialog extends _Ext.EditorDialogBase<ApprovalRequestDecisionRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: ApprovalRequestDecisionForm;
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestDecisionEditor extends _Ext.GridEditorBase<ApprovalRequestDecisionRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ApprovalRequestDecisionDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestDecisionGrid extends Serenity.EntityGrid<ApprovalRequestDecisionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ApprovalRequestDecisionDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestLineDialog extends _Ext.EditorDialogBase<ApprovalRequestLineRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: ApprovalRequestLineForm;
        constructor(container: JQuery);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestLineEditor extends _Ext.GridEditorBase<ApprovalRequestLineRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ApprovalRequestLineDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
        protected getSlickOptions(): Slick.GridOptions;
        DisableModifyIcon(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class ApprovalRequestLineGrid extends Serenity.EntityGrid<ApprovalRequestLineRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ApprovalRequestLineDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BPAddressesDialog extends _Ext.EditorDialogBase<BPAddressesRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: BPAddressesForm;
        constructor(container: JQuery);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class BPAddressesEditor extends _Ext.GridEditorBase<BPAddressesRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BPAddressesDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BPAddressesGrid extends Serenity.EntityGrid<BPAddressesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BPAddressesDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BPAddressesTypeValueEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BPPaymentMethodsDialog extends _Ext.EditorDialogBase<BPPaymentMethodsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: BPPaymentMethodsForm;
        static Form: BPPaymentMethodsForm;
        constructor(opt?: any);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class BPPaymentMethodsEditor extends _Ext.GridEditorBase<BPPaymentMethodsRow> {
        protected getColumnsKey(): string;
        protected getIdProperty(): string;
        protected getDialogType(): typeof BPPaymentMethodsDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BPPaymentMethodsGrid extends Serenity.EntityGrid<BPPaymentMethodsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BPPaymentMethodsDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BusinessPartnerDialog extends Serenity.EntityDialog<BusinessPartnerRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: BusinessPartnerForm;
        static Form: BusinessPartnerForm;
        constructor(opt?: any);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class BusinessPartnerGrid extends _Ext.GridBase1<BusinessPartnerRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BusinessPartnerDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery, options?: any);
        protected getButtons(): Serenity.ToolButton[];
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace SAPWebPortal.Default {
    class CardTypeValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class SelectCodeNameValueEditor extends Serenity.Select2Editor<any, any> {
        static dropdownfields: Array<string>;
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery, opt?: any);
    }
}
declare namespace SAPWebPortal.Default {
    class SeriesValuesEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BusinessPartnerGroupDialog extends Serenity.EntityDialog<BusinessPartnerGroupRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: BusinessPartnerGroupForm;
    }
}
declare namespace SAPWebPortal.Default {
    class BusinessPartnerGroupEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BusinessPartnerGroupGrid extends Serenity.EntityGrid<BusinessPartnerGroupRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BusinessPartnerGroupDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class ChartOfAccountDialog extends Serenity.EntityDialog<ChartOfAccountRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: ChartOfAccountForm;
    }
}
declare namespace SAPWebPortal.Default {
    class ChartOfAccountGrid extends _Ext.GridBase1<ChartOfAccountRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ChartOfAccountDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getButtons(): Serenity.ToolButton[];
        constructor(container: JQuery, options?: any);
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace SAPWebPortal.Default {
    class ContactEmployeesDialog extends Serenity.EntityDialog<ContactEmployeesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: ContactEmployeesForm;
    }
}
declare namespace SAPWebPortal.Default {
    class ContactEmployeesEditor extends _Ext.GridEditorBase<ContactEmployeesRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ContactEmployeesDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class ContactEmployeesGrid extends Serenity.EntityGrid<ContactEmployeesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ContactEmployeesDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class ExtensionsValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class FileRoutingDialog extends Serenity.EntityDialog<FileRoutingRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: FileRoutingForm;
    }
}
declare namespace SAPWebPortal.Default {
    class FileRoutingGrid extends Serenity.EntityGrid<FileRoutingRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof FileRoutingDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class SAPCompaniesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class SAPObectsValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class ItemDialog extends _Ext.DialogBase<ItemRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: ItemForm;
        constructor(container: JQuery);
        protected afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class ItemGrid extends _Ext.GridBase1<ItemRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ItemDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery, options?: any);
        protected getButtons(): Serenity.ToolButton[];
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace SAPWebPortal.Default {
    class ItemWarehouseInfoCollectionDialog extends Serenity.EntityDialog<ItemWarehouseInfoCollectionRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: ItemWarehouseInfoCollectionForm;
    }
}
declare namespace SAPWebPortal.Default {
    class ItemWarehouseInfoCollectionEditor extends _Ext.GridEditorBase<ItemWarehouseInfoCollectionRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ItemWarehouseInfoCollectionDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class ItemWarehouseInfoCollectionGrid extends Serenity.EntityGrid<ItemWarehouseInfoCollectionRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ItemWarehouseInfoCollectionDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class RecordCountsDialog extends Serenity.EntityDialog<RecordCountsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: RecordCountsForm;
    }
}
declare namespace SAPWebPortal.Default {
    class RecordCountsGrid extends Serenity.EntityGrid<RecordCountsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof RecordCountsDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class SAPCompanyEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class SAPObjectsValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class Report_UsersDialog extends _Ext.EditorDialogBase<Report_UsersRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: Report_UsersForm;
        constructor();
    }
}
declare namespace SAPWebPortal.Default {
    class Report_UsersEditor extends _Ext.GridEditorBase<Report_UsersRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof Report_UsersDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        depID: number;
        validateEntity(row: Report_UsersRow, id: number): boolean;
        protected getSlickOptions(): Slick.GridOptions;
        protected ShowRowNumberColumn(): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Default {
    class Report_UsersGrid extends _Ext.GridBase<Report_UsersRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof Report_UsersDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class ReportsDialog extends _Ext.DialogBase<ReportsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: ReportsForm;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class ReportsEditor extends _Ext.GridEditorBase<ReportsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReportsDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        protected getAddButtonCaption(): string;
        validateEntity(row: ReportsRow, id: number): boolean;
    }
}
declare namespace SAPWebPortal.Default {
    class ReportsGrid extends _Ext.GridBase<ReportsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ReportsDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery, options?: any);
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        validateEntity(row: ReportsRow, id: number): boolean;
    }
}
declare namespace SAPWebPortal.Default {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class DBDriverEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class SapDatabasesDialog extends Serenity.EntityDialog<SapDatabasesRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: SapDatabasesForm;
    }
}
declare namespace SAPWebPortal.Default {
    class SapDatabasesGrid extends Serenity.EntityGrid<SapDatabasesRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof SapDatabasesDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class DbServerTypeValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class AutherizedCustomersEditor extends _Ext.GridEditorBase<UserDetail1Row> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDetail1Dialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class UserDetail1Dialog extends _Ext.EditorDialogBase<UserDetail1Row> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        static Form: UserDetail1Form;
        protected form: UserDetail1Form;
        constructor();
        protected afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class UserDetail1Grid extends Serenity.EntityGrid<UserDetail1Row, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDetail1Dialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    var ExUserID: any;
    class UsersDialog extends _Ext.DialogBase<UsersRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: UsersForm;
        protected onDialogOpen(): void;
        protected onDialogClose(): void;
        protected afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class UsersGrid extends _Ext.GridBase<UsersRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UsersDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Default {
    class UsersListFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace SAPWebPortal.Default {
    class UsersDetailsDialog extends Serenity.EntityDialog<UsersDetailsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: UsersDetailsForm;
        constructor();
        protected updateInterface(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class UsersDetails extends _Ext.GridEditorBase<UsersDetailsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UsersDetailsDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
        depID: number;
        protected getAddButtonCaption(): string;
    }
}
declare namespace SAPWebPortal.Default {
    class UsersDetailsGrid extends _Ext.GridBase<UsersDetailsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UsersDetailsDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected createSlickGrid(): Slick.Grid;
        protected getColumns(): Slick.Column[];
        protected getSlickOptions(): Slick.GridOptions;
        protected usePager(): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Default {
    class WarehouseDialog extends Serenity.EntityDialog<WarehouseRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: WarehouseForm;
    }
}
declare namespace SAPWebPortal.Default {
    class WarehouseGrid extends _Ext.GridBase1<WarehouseRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof WarehouseDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getButtons(): Serenity.ToolButton[];
        constructor(container: JQuery, options?: any);
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace SAPWebPortal.Delivery {
    class DocumentDialog extends Serenity.EntityDialog<DocumentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: DocumentForm;
        static Form: DocumentForm;
        static Flag: Boolean;
        static DocumentLineFlag: Boolean;
        static AdditionalExpenseFlag: Boolean;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Delivery {
    class DocumentGrid extends Serenity.EntityGrid<DocumentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery, options?: any);
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.DeliveryLine {
    class DocumentLineDialog extends _Ext.EditorDialogBase<DocumentLineRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: DocumentLineForm;
        static Form: DocumentLineForm;
        constructor(container: JQuery);
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.DeliveryLine {
    class DocumentLineEditor extends _Ext.GridEditorBase<SAPWebPortal.DeliveryLine.DocumentLineRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getLocalTextPrefix(): string;
        static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        deleteEntity(id: any): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.DeliveryLine {
    class DocumentLineGrid extends Serenity.EntityGrid<DocumentLineRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Drafts {
    class DocumentDialog extends Serenity.EntityDialog<DocumentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: DocumentForm;
        static Form: DocumentForm;
        static Flag: Boolean;
        static DocumentLineFlag: Boolean;
        static AdditionalExpenseFlag: Boolean;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Drafts {
    class DocumentGrid extends Serenity.EntityGrid<DocumentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery, options?: any);
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.DraftsExpense {
    class DocumentAdditionalExpenseDialog extends _Ext.EditorDialogBase<DocumentAdditionalExpenseRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: DocumentAdditionalExpenseForm;
        static Form: DocumentAdditionalExpenseForm;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.DraftsExpense {
    class DocumentAdditionalExpenseEditor extends _Ext.GridEditorBase<SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentAdditionalExpenseDialog;
        protected getLocalTextPrefix(): string;
        static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        deleteEntity(id: any): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.DraftsExpense {
    class DocumentAdditionalExpenseGrid extends Serenity.EntityGrid<DocumentAdditionalExpenseRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentAdditionalExpenseDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.DraftsLine {
    class DocumentLineDialog extends _Ext.EditorDialogBase<DocumentLineRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: DocumentLineForm;
        static Form: DocumentLineForm;
        constructor(container: JQuery);
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.DraftsLine {
    class DocumentLineEditor extends _Ext.GridEditorBase<SAPWebPortal.DraftsLine.DocumentLineRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getLocalTextPrefix(): string;
        static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        deleteEntity(id: any): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.DraftsLine {
    class DocumentLineGrid extends Serenity.EntityGrid<DocumentLineRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class ApprovalDocsEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class ApprovalLineStatusEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class ApprovalStatusEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class BPAddressTypeEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class CardTypeEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class DocStatusEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class DocTypeEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class DraftDocsEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class IsYOrNEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Modules.DropDownEnums {
    class YesOrNoEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Membership {
    /**
     * Our select editor with hardcoded values.
     *
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    class CompanyDatabaseValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Membership {
    class LoginPanel extends Serenity.PropertyPanel<LoginRequest, any> {
        protected getFormKey(): string;
        constructor(container: JQuery);
        protected redirectToReturnUrl(): void;
        protected getTemplate(): string;
    }
}
declare namespace SAPWebPortal.Membership {
    class ChangePasswordPanel extends Serenity.PropertyPanel<ChangePasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
        getTemplate(): string;
    }
}
declare namespace SAPWebPortal.Membership {
    class ForgotPasswordPanel extends Serenity.PropertyPanel<ForgotPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Membership {
    class ResetPasswordPanel extends Serenity.PropertyPanel<ResetPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Membership {
    class SignUpPanel extends Serenity.PropertyPanel<SignUpRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Orders {
    class DocumentDialog extends _Ext.DialogBase<DocumentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: DocumentForm;
        static Form: DocumentForm;
        static Flag: Boolean;
        static DocumentLineFlag: Boolean;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected updateInterface(): void;
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Orders {
    class DocumentGrid extends Serenity.EntityGrid<DocumentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery, options?: any);
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace SAPWebPortal.Orders.Document {
    class SelectCodeNameValueEditor extends Serenity.Select2Editor<any, any> {
        static dropdownfields: Array<string>;
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery, opt?: any);
    }
}
declare namespace SAPWebPortal.OrdersExpense {
    class DocumentAdditionalExpenseDialog extends _Ext.EditorDialogBase<DocumentAdditionalExpenseRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: DocumentAdditionalExpenseForm;
        static Form: DocumentAdditionalExpenseForm;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.OrdersExpense {
    class DocumentAdditionalExpenseEditor extends _Ext.GridEditorBase<SAPWebPortal.OrdersExpense.DocumentAdditionalExpenseRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentAdditionalExpenseDialog;
        protected getLocalTextPrefix(): string;
        static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        deleteEntity(id: any): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.OrdersExpense {
    class DocumentAdditionalExpenseGrid extends Serenity.EntityGrid<DocumentAdditionalExpenseRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentAdditionalExpenseDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.OrdersLine {
    class DocumentLineDialog extends _Ext.EditorDialogBase<DocumentLineRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: DocumentLineForm;
        static Form: DocumentLineForm;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.OrdersLine {
    class DocumentLineEditor extends _Ext.GridEditorBase<SAPWebPortal.OrdersLine.DocumentLineRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getLocalTextPrefix(): string;
        static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        deleteEntity(id: any): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.OrdersLine {
    class DocumentLineGrid extends Serenity.EntityGrid<DocumentLineRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        static Columns: any;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Quotations {
    class DocumentDialog extends Serenity.EntityDialog<DocumentRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: DocumentForm;
        static Form: DocumentForm;
        static Flag: Boolean;
        static DocumentLineFlag: Boolean;
        static AdditionalExpenseFlag: Boolean;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.Quotations {
    class DocumentGrid extends Serenity.EntityGrid<DocumentRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.QuotationsExpense {
    class DocumentAdditionalExpenseDialog extends _Ext.EditorDialogBase<DocumentAdditionalExpenseRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: DocumentAdditionalExpenseForm;
        static Form: DocumentAdditionalExpenseForm;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.QuotationsExpense {
    class DocumentAdditionalExpenseEditor extends _Ext.GridEditorBase<SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentAdditionalExpenseDialog;
        protected getLocalTextPrefix(): string;
        static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        deleteEntity(id: any): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.QuotationsExpense {
    class DocumentAdditionalExpenseGrid extends Serenity.EntityGrid<DocumentAdditionalExpenseRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentAdditionalExpenseDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.QuotationsLine {
    class DocumentLineDialog extends _Ext.EditorDialogBase<DocumentLineRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: DocumentLineForm;
        static Form: DocumentLineForm;
        constructor(container: JQuery);
        helper: SAPWebPortal.Helpers.BusinessFormHelper;
        afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.QuotationsLine {
    class DocumentLineEditor extends _Ext.GridEditorBase<SAPWebPortal.QuotationsLine.DocumentLineRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getLocalTextPrefix(): string;
        static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery);
        protected getSlickOptions(): Slick.GridOptions;
        deleteEntity(id: any): boolean;
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace SAPWebPortal.QuotationsLine {
    class DocumentLineGrid extends Serenity.EntityGrid<DocumentLineRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DocumentLineDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        static Columns: any;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.VatGroups {
    class VatGroupDialog extends Serenity.EntityDialog<VatGroupRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getDeletePermission(): string;
        protected getInsertPermission(): string;
        protected getUpdatePermission(): string;
        protected form: VatGroupForm;
    }
}
declare namespace SAPWebPortal.VatGroups {
    class VatGroupGrid extends _Ext.GridBase1<VatGroupRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VatGroupDialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected getButtons(): Serenity.ToolButton[];
        constructor(container: JQuery, options?: any);
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getPagerOptions(): Slick.PagerOptions;
    }
}
declare namespace _Ext {
    class AuditLogActionTypeFormatter implements Slick.Formatter {
        static format(ctx: Slick.FormatterContext): string;
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace _Ext {
    class AuditLogDialog extends DialogBase<AuditLogRow, any> {
        protected getFormKey(): string;
        protected getRowType(): typeof AuditLogRow;
        protected getService(): string;
        protected form: AuditLogForm;
        protected afterLoadEntity(): void;
        static getChangesInHtml(changesInJson: string): string;
    }
}
declare namespace _Ext {
    class AuditLogGrid extends GridBase<AuditLogRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof AuditLogDialog;
        protected getRowType(): typeof AuditLogRow;
        protected getService(): string;
        constructor(container: JQuery);
        protected getButtons(): Serenity.ToolButton[];
    }
}
declare namespace _Ext {
    class AuditLogViewer {
        el: string;
        data: {
            entityVersions: any[];
        };
        entity: any;
        entityId: any;
        constructor(el: string, entityVersions: AuditLogRow[]);
        mounted: () => void;
        computed: {
            test: () => string;
        };
        filters: {
            filterByYardId: () => any[];
        };
        methods: {
            getDiff: (versionInfo: AuditLogRow) => string;
        };
        destroyed(): void;
    }
}
declare namespace _Ext {
    class AuditLogViewerDialog extends Serenity.TemplatedDialog<any> {
        request: AuditLogViewerRequest;
        constructor(request: AuditLogViewerRequest);
        protected getTemplateName(): string;
    }
}
declare namespace _Ext {
    class DialogSnippets extends DialogBase<AuditLogRow, any> {
        protected getFormKey(): string;
        protected getRowType(): typeof AuditLogRow;
        protected getService(): string;
        protected form: AuditLogForm;
        protected addCssClass(): void;
        protected getTemplate(): string;
        protected getTemplateName(): string;
        protected getFallbackTemplate(): string;
        protected initValidator(): void;
        protected getValidatorOptions(): JQueryValidation.ValidationOptions;
        protected initTabs(): void;
        protected initToolbar(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected initPropertyGrid(): void;
        protected getPropertyGridOptions(): Serenity.PropertyGridOptions;
        protected initLocalizationGrid(): void;
        protected initLocalizationGridCommon(pgOptions: Serenity.PropertyGridOptions): void;
        load(entityOrId: any, done: () => void, fail: (ex: Q.Exception) => void): void;
        loadResponse(data: any): void;
        protected onLoadingData(data: Serenity.RetrieveResponse<AuditLogRow>): void;
        protected beforeLoadEntity(entity: AuditLogRow): void;
        protected loadEntity(entity: AuditLogRow): void;
        protected set_entityId(value: any): void;
        protected set_entity(entity: any): void;
        protected isEditMode(): boolean;
        protected get_entityId(): any;
        protected get_entity(): AuditLogRow;
        protected afterLoadEntity(): void;
        protected updateInterface(): void;
        protected isDeleted(): boolean;
        protected isLocalizationMode(): boolean;
        protected isNew(): boolean;
        protected updateTitle(): void;
        protected getEntityTitle(): string;
        protected getEntitySingular(): string;
        protected getSaveEntity(): AuditLogRow;
        protected initDialog(): void;
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getDialogTitle(): string;
        protected handleResponsive(): void;
        protected onDialogOpen(): void;
        protected arrange(): void;
        protected save(callback?: (response: Serenity.SaveResponse) => void): void | boolean;
        protected validateBeforeSave(): boolean;
        protected save_submitHandler(callback: (response: Serenity.SaveResponse) => void): void;
        protected getSaveOptions(callback: (response: Serenity.SaveResponse) => void): Serenity.ServiceOptions<Serenity.SaveResponse>;
        protected getSaveRequest(): Serenity.SaveRequest<AuditLogRow>;
        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void): void;
        protected onSaveSuccess(response: Serenity.SaveResponse): void;
        loadById(id: any, callback?: (response: Serenity.RetrieveResponse<AuditLogRow>) => void, fail?: () => void): void;
        protected getLoadByIdRequest(id: any): Serenity.RetrieveRequest;
        protected getLoadByIdOptions(id: any, callback: (response: Serenity.RetrieveResponse<AuditLogRow>) => void): Serenity.ServiceOptions<Serenity.RetrieveResponse<AuditLogRow>>;
        protected loadByIdHandler(options: Serenity.ServiceOptions<Serenity.RetrieveResponse<AuditLogRow>>, callback: (response: Serenity.RetrieveResponse<AuditLogRow>) => void, fail: () => void): void;
        protected showSaveSuccessMessage(response: Serenity.SaveResponse): void;
        protected getEntityNameFieldValue(): any;
        protected isCloneMode(): boolean;
        protected isNewOrDeleted(): boolean;
        protected getDeleteOptions(callback: (response: Serenity.DeleteResponse) => void): Serenity.ServiceOptions<Serenity.DeleteResponse>;
        protected deleteHandler(options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void): void;
        protected doDelete(callback: (response: Serenity.DeleteResponse) => void): void;
        protected onDeleteSuccess(response: Serenity.DeleteResponse): void;
        protected getEntityType(): string;
        protected getLocalTextDbPrefix(): string;
        protected getIsActiveProperty(): string;
        protected getIsDeletedProperty(): string;
        loadNewAndOpenDialog(asPanel?: boolean): void;
        loadEntityAndOpenDialog(entity: AuditLogRow, asPanel?: boolean): void;
        loadByIdAndOpenDialog(entityId: any, asPanel?: boolean): void;
        protected reloadById(): void;
        protected isLocalizationModeAndChanged(): boolean;
        protected localizationButtonClick(): void;
        protected getLanguages(): any[];
        protected loadLocalization(): void;
        protected setLocalizationGridCurrentValues(): void;
        protected getLocalizationGridValue(): any;
        protected getPendingLocalizations(): any;
        protected getPropertyItems(): Serenity.PropertyItem[];
        protected getCloningEntity(): AuditLogRow;
        protected getUndeleteOptions(callback?: (response: Serenity.UndeleteResponse) => void): Serenity.ServiceOptions<Serenity.UndeleteResponse>;
        protected undeleteHandler(options: Serenity.ServiceOptions<Serenity.UndeleteResponse>, callback: (response: Serenity.UndeleteResponse) => void): void;
        protected undelete(callback?: (response: Serenity.UndeleteResponse) => void): void;
        protected resetValidation(): void;
        protected validateForm(): boolean;
        protected onDialogClose(): void;
        destroy(): void;
    }
}
declare namespace _Ext {
    class DialogWithAllOverridableMethods extends DialogBase<AuditLogRow, any> {
        protected getFormKey(): string;
        protected getRowType(): typeof AuditLogRow;
        protected getService(): string;
        protected form: AuditLogForm;
        protected addCssClass(): void;
        protected getTemplate(): string;
        protected getTemplateName(): string;
        protected getFallbackTemplate(): string;
        protected initValidator(): void;
        protected getValidatorOptions(): JQueryValidation.ValidationOptions;
        protected initTabs(): void;
        protected initToolbar(): void;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected initPropertyGrid(): void;
        protected getPropertyGridOptions(): Serenity.PropertyGridOptions;
        protected initLocalizationGrid(): void;
        protected initLocalizationGridCommon(pgOptions: Serenity.PropertyGridOptions): void;
        load(entityOrId: any, done: () => void, fail: (ex: Q.Exception) => void): void;
        loadResponse(data: any): void;
        protected onLoadingData(data: Serenity.RetrieveResponse<AuditLogRow>): void;
        protected beforeLoadEntity(entity: AuditLogRow): void;
        protected loadEntity(entity: AuditLogRow): void;
        protected set_entityId(value: any): void;
        protected set_entity(entity: any): void;
        protected isEditMode(): boolean;
        protected get_entityId(): any;
        protected get_entity(): AuditLogRow;
        protected afterLoadEntity(): void;
        protected updateInterface(): void;
        protected isDeleted(): boolean;
        protected isLocalizationMode(): boolean;
        protected isNew(): boolean;
        protected updateTitle(): void;
        protected getEntityTitle(): string;
        protected getEntitySingular(): string;
        protected getSaveEntity(): AuditLogRow;
        protected initDialog(): void;
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getDialogTitle(): string;
        protected handleResponsive(): void;
        protected onDialogOpen(): void;
        protected arrange(): void;
        protected save(callback?: (response: Serenity.SaveResponse) => void): void | boolean;
        protected validateBeforeSave(): boolean;
        protected save_submitHandler(callback: (response: Serenity.SaveResponse) => void): void;
        protected getSaveOptions(callback: (response: Serenity.SaveResponse) => void): Serenity.ServiceOptions<Serenity.SaveResponse>;
        protected getSaveRequest(): Serenity.SaveRequest<AuditLogRow>;
        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void): void;
        protected onSaveSuccess(response: Serenity.SaveResponse): void;
        loadById(id: any, callback?: (response: Serenity.RetrieveResponse<AuditLogRow>) => void, fail?: () => void): void;
        protected getLoadByIdRequest(id: any): Serenity.RetrieveRequest;
        protected getLoadByIdOptions(id: any, callback: (response: Serenity.RetrieveResponse<AuditLogRow>) => void): Serenity.ServiceOptions<Serenity.RetrieveResponse<AuditLogRow>>;
        protected loadByIdHandler(options: Serenity.ServiceOptions<Serenity.RetrieveResponse<AuditLogRow>>, callback: (response: Serenity.RetrieveResponse<AuditLogRow>) => void, fail: () => void): void;
        protected showSaveSuccessMessage(response: Serenity.SaveResponse): void;
        protected getEntityNameFieldValue(): any;
        protected isCloneMode(): boolean;
        protected isNewOrDeleted(): boolean;
        protected getDeleteOptions(callback: (response: Serenity.DeleteResponse) => void): Serenity.ServiceOptions<Serenity.DeleteResponse>;
        protected deleteHandler(options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void): void;
        protected doDelete(callback: (response: Serenity.DeleteResponse) => void): void;
        protected onDeleteSuccess(response: Serenity.DeleteResponse): void;
        protected getEntityType(): string;
        protected getLocalTextDbPrefix(): string;
        protected getIsActiveProperty(): string;
        protected getIsDeletedProperty(): string;
        loadNewAndOpenDialog(asPanel?: boolean): void;
        loadEntityAndOpenDialog(entity: AuditLogRow, asPanel?: boolean): void;
        loadByIdAndOpenDialog(entityId: any, asPanel?: boolean): void;
        protected reloadById(): void;
        protected isLocalizationModeAndChanged(): boolean;
        protected localizationButtonClick(): void;
        protected getLanguages(): any[];
        protected loadLocalization(): void;
        protected setLocalizationGridCurrentValues(): void;
        protected getLocalizationGridValue(): any;
        protected getPendingLocalizations(): any;
        protected getPropertyItems(): Serenity.PropertyItem[];
        protected getCloningEntity(): AuditLogRow;
        protected getUndeleteOptions(callback?: (response: Serenity.UndeleteResponse) => void): Serenity.ServiceOptions<Serenity.UndeleteResponse>;
        protected undeleteHandler(options: Serenity.ServiceOptions<Serenity.UndeleteResponse>, callback: (response: Serenity.UndeleteResponse) => void): void;
        protected undelete(callback?: (response: Serenity.UndeleteResponse) => void): void;
        protected resetValidation(): void;
        protected validateForm(): boolean;
        protected onDialogClose(): void;
        destroy(): void;
    }
}
declare namespace _Ext {
    class GridSnippets extends _Ext.GridBase<AuditLogRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof DialogSnippets;
        protected getRowType(): typeof AuditLogRow;
        protected getService(): string;
        protected get_ExtGridOptions(): ExtGridOptions;
        constructor(container: JQuery, options?: any);
        protected getInitialTitle(): string;
        protected getDisplayName(): string;
        setTitle(value: string): void;
        getTitle(): string;
        protected layout(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getAddButtonCaption(): string;
        protected getItemName(): string;
        protected newRefreshButton(noText?: boolean): Serenity.ToolButton;
        getView(): Slick.RemoteView<AuditLogRow>;
        protected createToolbar(buttons: Serenity.ToolButton[]): void;
        protected createSlickContainer(): JQuery;
        protected createView(): Slick.RemoteView<AuditLogRow>;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getDefaultSortBy(): any[];
        protected usePager(): boolean;
        protected createSlickGrid(): Slick.Grid;
        protected getColumns(): Slick.Column[];
        protected getPropertyItems(): Serenity.PropertyItem[];
        protected propertyItemsToSlickColumns(propertyItems: Serenity.PropertyItem[]): Slick.Column[];
        protected itemLink(itemType?: string, idField?: string, text?: (ctx: Slick.FormatterContext) => string, cssClass?: (ctx: Slick.FormatterContext) => string, encode?: boolean): Slick.Format;
        protected getItemType(): string;
        protected getEntityType(): string;
        protected getSlickOptions(): Slick.GridOptions;
        protected postProcessColumns(columns: Slick.Column[]): Slick.Column[];
        protected setInitialSortOrder(): void;
        protected enableFiltering(): boolean;
        protected createFilterBar(): void;
        protected initializeFilterBar(): void;
        protected canFilterColumn(column: Slick.Column): boolean;
        protected createPager(): void;
        protected getPagerOptions(): Slick.PagerOptions;
        protected bindToSlickEvents(): void;
        protected bindToViewEvents(): void;
        protected createToolbarExtensions(): void;
        protected createIncludeDeletedButton(): void;
        protected createQuickSearchInput(): void;
        protected getQuickSearchFields(): Serenity.QuickSearchField[];
        protected createQuickFilters(): void;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected dateTimeRangeQuickFilter(field: string, title?: string): Serenity.QuickFilter<Serenity.DateTimeEditor, Serenity.DateTimeEditorOptions>;
        protected addQuickFilter<TWidget extends Serenity.Widget<any>, TOptions>(opt: Serenity.QuickFilter<TWidget, TOptions>): TWidget;
        protected updateDisabledState(): void;
        protected getCurrentSettings(flags?: Serenity.GridPersistanceFlags): Serenity.PersistedGridSettings;
        protected gridPersistanceFlags(): Serenity.GridPersistanceFlags;
        protected restoreSettings(settings?: Serenity.PersistedGridSettings, flags?: Serenity.GridPersistanceFlags): void;
        protected getPersistedSettings(): Serenity.PersistedGridSettings;
        protected getPersistanceStorage(): Serenity.SettingStorage;
        getGrid(): Slick.Grid;
        protected initialPopulate(): void;
        protected populateWhenVisible(): boolean;
        protected onViewSubmit(): boolean;
        protected getGridCanLoad(): boolean;
        protected setCriteriaParameter(): void;
        protected setIncludeColumnsParameter(): void;
        protected getIncludeColumns(include: {
            [key: string]: boolean;
        }): void;
        protected invokeSubmitHandlers(): void;
        protected onViewProcessData(response: Serenity.ListResponse<AuditLogRow>): Serenity.ListResponse<AuditLogRow>;
        protected getItemMetadata(item: AuditLogRow, index: number): any;
        protected getItemCssClass(item: AuditLogRow, index: number): string;
        protected getIsActiveProperty(): string;
        protected getIsDeletedProperty(): string;
        protected onViewFilter(item: AuditLogRow): boolean;
        getElement(): JQuery;
        protected viewDataChanged(e: any, rows: AuditLogRow[]): void;
        protected markupReady(): void;
        getItems(): AuditLogRow[];
        setItems(value: AuditLogRow[]): void;
        protected addButtonClick(): void;
        protected editItem(entityOrId: any): void;
        protected editItemOfType(itemType: string, entityOrId: any): void;
        protected routeDialog(itemType: string, dialog: Serenity.Widget<any>): void;
        protected initEntityDialog(itemType: string, dialog: Serenity.Widget<any>): void;
        protected createEntityDialog(itemType: string, callback?: (dlg: Serenity.Widget<any>) => void): Serenity.Widget<any>;
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getDialogOptionsFor(itemType: string): JQueryUI.DialogOptions;
        destroy(): void;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected setEquality(field: string, value: any): void;
        protected populateLock(): void;
        protected populateUnlock(): void;
        refresh(): void;
        protected refreshIfNeeded(): void;
        protected internalRefresh(): void;
        setIsDisabled(value: boolean): void;
        protected resizeCanvas(): void;
        protected subDialogDataChange(): void;
        protected addFilterSeparator(): void;
        protected determineText(getKey: (prefix: string) => string): string;
        protected addDateRangeFilter(field: string, title?: string): Serenity.DateEditor;
        protected dateRangeQuickFilter(field: string, title?: string): Serenity.QuickFilter<Serenity.DateEditor, Serenity.DateTimeEditorOptions>;
        protected addDateTimeRangeFilter(field: string, title?: string): Serenity.DateTimeEditor;
        protected addBooleanFilter(field: string, title?: string, yes?: string, no?: string): Serenity.SelectEditor;
        protected booleanQuickFilter(field: string, title?: string, yes?: string, no?: string): Serenity.QuickFilter<Serenity.SelectEditor, Serenity.SelectEditorOptions>;
        protected quickFilterChange(e: JQueryEventObject): void;
        protected getPersistanceKey(): string;
        protected canShowColumn(column: Slick.Column): boolean;
        protected persistSettings(flags?: Serenity.GridPersistanceFlags): void;
        getFilterStore(): Serenity.FilterStore;
    }
}
declare namespace _Ext {
    class GridWithAllOverridableMethods extends _Ext.GridBase<AuditLogRow, any> {
        protected getDialogType(): typeof DialogWithAllOverridableMethods;
        constructor(container: JQuery, options?: any);
        protected getInitialTitle(): string;
        protected getDisplayName(): string;
        protected getLocalTextPrefix(): string;
        setTitle(value: string): void;
        getTitle(): string;
        protected layout(): void;
        protected getButtons(): Serenity.ToolButton[];
        protected getAddButtonCaption(): string;
        protected getItemName(): string;
        protected newRefreshButton(noText?: boolean): Serenity.ToolButton;
        getView(): Slick.RemoteView<AuditLogRow>;
        protected createToolbar(buttons: Serenity.ToolButton[]): void;
        protected createSlickContainer(): JQuery;
        protected createView(): Slick.RemoteView<AuditLogRow>;
        protected getViewOptions(): Slick.RemoteViewOptions;
        protected getIdProperty(): string;
        protected getDefaultSortBy(): any[];
        protected usePager(): boolean;
        protected getService(): string;
        protected createSlickGrid(): Slick.Grid;
        protected getColumns(): Slick.Column[];
        protected getPropertyItems(): Serenity.PropertyItem[];
        protected getColumnsKey(): string;
        protected propertyItemsToSlickColumns(propertyItems: Serenity.PropertyItem[]): Slick.Column[];
        protected itemLink(itemType?: string, idField?: string, text?: (ctx: Slick.FormatterContext) => string, cssClass?: (ctx: Slick.FormatterContext) => string, encode?: boolean): Slick.Format;
        protected getItemType(): string;
        protected getEntityType(): string;
        protected getSlickOptions(): Slick.GridOptions;
        protected get_ExtGridOptions(): ExtGridOptions;
        protected postProcessColumns(columns: Slick.Column[]): Slick.Column[];
        protected setInitialSortOrder(): void;
        protected enableFiltering(): boolean;
        protected createFilterBar(): void;
        protected initializeFilterBar(): void;
        protected canFilterColumn(column: Slick.Column): boolean;
        protected createPager(): void;
        protected getPagerOptions(): Slick.PagerOptions;
        protected bindToSlickEvents(): void;
        protected bindToViewEvents(): void;
        protected createToolbarExtensions(): void;
        protected createIncludeDeletedButton(): void;
        protected createQuickSearchInput(): void;
        protected getQuickSearchFields(): Serenity.QuickSearchField[];
        protected createQuickFilters(): void;
        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[];
        protected dateTimeRangeQuickFilter(field: string, title?: string): Serenity.QuickFilter<Serenity.DateTimeEditor, Serenity.DateTimeEditorOptions>;
        protected addQuickFilter<TWidget extends Serenity.Widget<any>, TOptions>(opt: Serenity.QuickFilter<TWidget, TOptions>): TWidget;
        protected updateDisabledState(): void;
        protected getCurrentSettings(flags?: Serenity.GridPersistanceFlags): Serenity.PersistedGridSettings;
        protected gridPersistanceFlags(): Serenity.GridPersistanceFlags;
        protected restoreSettings(settings?: Serenity.PersistedGridSettings, flags?: Serenity.GridPersistanceFlags): void;
        protected getPersistedSettings(): Serenity.PersistedGridSettings;
        protected getPersistanceStorage(): Serenity.SettingStorage;
        getGrid(): Slick.Grid;
        protected initialPopulate(): void;
        protected populateWhenVisible(): boolean;
        protected onViewSubmit(): boolean;
        protected getGridCanLoad(): boolean;
        protected setCriteriaParameter(): void;
        protected setIncludeColumnsParameter(): void;
        protected getIncludeColumns(include: {
            [key: string]: boolean;
        }): void;
        protected invokeSubmitHandlers(): void;
        protected onViewProcessData(response: Serenity.ListResponse<AuditLogRow>): Serenity.ListResponse<AuditLogRow>;
        protected getItemMetadata(item: AuditLogRow, index: number): any;
        protected getItemCssClass(item: AuditLogRow, index: number): string;
        protected getIsActiveProperty(): string;
        protected getIsDeletedProperty(): string;
        protected onViewFilter(item: AuditLogRow): boolean;
        getElement(): JQuery;
        protected viewDataChanged(e: any, rows: AuditLogRow[]): void;
        protected markupReady(): void;
        getItems(): AuditLogRow[];
        setItems(value: AuditLogRow[]): void;
        protected addButtonClick(): void;
        protected editItem(entityOrId: any): void;
        protected editItemOfType(itemType: string, entityOrId: any): void;
        protected routeDialog(itemType: string, dialog: Serenity.Widget<any>): void;
        protected initEntityDialog(itemType: string, dialog: Serenity.Widget<any>): void;
        protected createEntityDialog(itemType: string, callback?: (dlg: Serenity.Widget<any>) => void): Serenity.Widget<any>;
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getDialogOptionsFor(itemType: string): JQueryUI.DialogOptions;
        destroy(): void;
        protected onClick(e: JQueryEventObject, row: number, cell: number): void;
        protected setEquality(field: string, value: any): void;
        protected populateLock(): void;
        protected populateUnlock(): void;
        refresh(): void;
        protected refreshIfNeeded(): void;
        protected internalRefresh(): void;
        setIsDisabled(value: boolean): void;
        protected resizeCanvas(): void;
        protected subDialogDataChange(): void;
        protected addFilterSeparator(): void;
        protected determineText(getKey: (prefix: string) => string): string;
        protected addDateRangeFilter(field: string, title?: string): Serenity.DateEditor;
        protected dateRangeQuickFilter(field: string, title?: string): Serenity.QuickFilter<Serenity.DateEditor, Serenity.DateTimeEditorOptions>;
        protected addDateTimeRangeFilter(field: string, title?: string): Serenity.DateTimeEditor;
        protected addBooleanFilter(field: string, title?: string, yes?: string, no?: string): Serenity.SelectEditor;
        protected booleanQuickFilter(field: string, title?: string, yes?: string, no?: string): Serenity.QuickFilter<Serenity.SelectEditor, Serenity.SelectEditorOptions>;
        protected quickFilterChange(e: JQueryEventObject): void;
        protected getPersistanceKey(): string;
        protected canShowColumn(column: Slick.Column): boolean;
        protected persistSettings(flags?: Serenity.GridPersistanceFlags): void;
        getFilterStore(): Serenity.FilterStore;
    }
}
declare namespace _Ext {
    class ReplaceRowDialog extends _Ext.DialogBase<any, any> {
        request: ReplaceRowRequest;
        entityList: Array<any>;
        protected getFormKey(): string;
        protected form: ReplaceRowForm;
        constructor(request: ReplaceRowRequest, entityList: Array<any>);
        protected getToolbarButtons(): Serenity.ToolButton[];
    }
}
declare var Vue: any;
declare namespace _Ext.DevTools {
    class SergenPanel extends Serenity.Widget<any> {
        constructor(container: JQuery);
    }
}
declare namespace _Ext {
    class AutoCompleteEditor extends Serenity.StringEditor {
        constructor(input: JQuery, options: AutoCompleteOptions);
        protected bindAutoComplete(input: any): void;
    }
    interface AutoCompleteOptions {
        lookupKey: string;
        sourceArray: string[];
        sourceCSV: string;
        minSearchLength: number;
    }
}
declare namespace _Ext {
    class ColorEditor extends Serenity.TemplatedWidget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        protected getTemplate(): string;
        constructor(container: JQuery);
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
    }
}
declare namespace _Ext {
    class DateTimePickerEditor extends Serenity.Widget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue, Serenity.IReadOnly {
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        constructor(container: JQuery);
        get value(): string;
        set value(val: string);
        get valueAsDate(): Date;
        set valueAsDate(val: Date);
        get_readOnly(): boolean;
        set_readOnly(value: boolean): void;
        set_minDate(date: Date): void;
        set_maxDate(date: Date): void;
        set_minDateTime(date: Date): void;
        set_maxDateTime(date: Date): void;
    }
}
declare namespace _Ext {
    class EmptyLookupEditor extends Serenity.LookupEditorBase<Serenity.LookupEditorOptions, any> {
        setSelect2Items(items: Select2Item[]): void;
        setLookupItems(lookup: Q.Lookup<any>): void;
    }
}
declare namespace _Ext {
    class HardCodedLookupEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery, options: HardCodedLookupEditorOptions);
        protected getSelect2Options(): Select2Options;
    }
    interface HardCodedLookupEditorOptions {
        sourceArray: string[];
        sourceCSV: string;
        allowOtherValue: boolean;
    }
}
declare namespace _Ext {
    class HtmlTemplateEditor extends Serenity.HtmlContentEditor {
        constructor(textArea: JQuery, opt?: HtmlTemplateEditorOptions);
        protected getConfig(): Serenity.CKEditorConfig;
    }
    interface HtmlTemplateEditorOptions extends Serenity.HtmlContentEditorOptions {
        cols?: any;
        rows?: any;
        placeholders?: any;
    }
}
declare namespace _Ext {
    class JsonViewer extends Serenity.TemplatedWidget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        protected getTemplate(): string;
        private _value;
        set value(val: string);
        get value(): string;
    }
}
declare namespace _Ext {
    class MonthYearEditor extends Serenity.Widget<any> implements Serenity.IGetEditValue, Serenity.ISetEditValue, Serenity.IReadOnly {
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        constructor(container: JQuery);
        get value(): string;
        set value(val: string);
        get_readOnly(): boolean;
        set_readOnly(value: boolean): void;
    }
}
declare namespace _Ext {
    class PrefixedStringEditor extends Serenity.Widget<PrefixedStringEditorOptions> implements Serenity.IGetEditValue, Serenity.ISetEditValue, Serenity.IReadOnly {
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        private prefixInput;
        constructor(container: JQuery, options: PrefixedStringEditorOptions);
        get value(): string;
        set value(val: string);
        private _prefix;
        get prefix(): string;
        set prefix(val: string);
        get_readOnly(): boolean;
        set_readOnly(value: boolean): void;
    }
    interface PrefixedStringEditorOptions {
        prefixLength: number;
        inputMaxLength: number;
        prefixFormatterType?: string;
    }
}
declare namespace _Ext {
    class StaticTextBlock extends Serenity.Widget<StaticTextBlockOptions> implements Serenity.ISetEditValue {
        private _value;
        constructor(container: JQuery, options: StaticTextBlockOptions);
        private updateElementContent;
        /**
         * By implementing ISetEditValue interface, we allow this editor to display its field value.
         * But only do this when our text content is not explicitly set in options
         */
        setEditValue(source: any, property: Serenity.PropertyItem): void;
        get value(): string;
        set value(value: string);
    }
    interface StaticTextBlockOptions {
        text: string;
        isHtml: boolean;
        isLocalText: boolean;
        hideLabel: boolean;
        isDate: boolean;
        isDateTime: boolean;
    }
}
declare namespace _Ext {
    class YesNoEditor extends Serenity.Select2Editor<any, any> {
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        constructor(container: JQuery);
        get valueAsBoolean(): boolean;
        set valueAsBoolean(val: boolean);
    }
}
declare namespace _Ext {
    class GridItemPickerEditor extends Serenity.Widget<GridItemPickerEditorOptions> implements Serenity.ISetEditValue, Serenity.IGetEditValue, Serenity.IStringValue, Serenity.IReadOnly, Serenity.IValidateRequired {
        options: GridItemPickerEditorOptions;
        containerDiv: JQuery;
        inplaceSearchButton: JQuery;
        inplaceViewButton: JQuery;
        clearSelectionButton: JQuery;
        constructor(container: JQuery, options: GridItemPickerEditorOptions);
        protected addInplaceButtons(): void;
        protected inplaceSearchClick(e: any): void;
        protected inplaceViewClick(e: any): void;
        private getDialogInstance;
        get value(): string;
        set value(val: string);
        get values(): string[];
        set values(val: string[]);
        get text(): string;
        set text(val: string);
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        get_value(): string;
        set_value(value: string): void;
        get_readOnly(): boolean;
        set_readOnly(value: boolean): void;
        get_required(): boolean;
        set_required(value: boolean): void;
        private _selectedItem;
        selectedItemIncludeColumns: string[];
        get selectedItem(): any;
        selectedItems: any[];
        private _serviceUrl;
        get serviceUrl(): string;
        setValueAndText(value: any, text: any): void;
        protected getCascadeFromValue(parent: Serenity.Widget<any>): any;
        protected cascadeLink: Serenity.CascadedWidgetLink<Serenity.Widget<any>>;
        protected setCascadeFrom(value: string): void;
        protected get_cascadeFrom(): string;
        get cascadeFrom(): string;
        protected set_cascadeFrom(value: string): void;
        set cascadeFrom(value: string);
        protected get_cascadeField(): any;
        get cascadeField(): string;
        protected set_cascadeField(value: string): void;
        set cascadeField(value: string);
        protected get_cascadeValue(): any;
        get cascadeValue(): any;
        protected set_cascadeValue(value: any): void;
        set cascadeValue(value: any);
        protected get_filterField(): string;
        get filterField(): string;
        protected set_filterField(value: string): void;
        set filterField(value: string);
        protected get_filterValue(): any;
        get filterValue(): any;
        protected set_filterValue(value: any): void;
        set filterValue(value: any);
        protected updateItems(): void;
    }
    interface GridItemPickerEditorOptions extends Serenity.Select2FilterOptions {
        gridType: any;
        nameFieldInThisRow?: string;
        serviceUrl?: string;
        rowType?: string;
        idFieldInGridRow?: string;
        nameFieldInGridRow?: string;
        inplaceView?: boolean;
        multiple?: boolean;
        preSelectedKeys?: any[];
        filteringCriteria?: any;
        customPrams?: any;
        dialogType?: any;
        cascadeFrom?: string;
        cascadeField?: string;
        cascadeValue?: any;
        filterField?: string;
        propertyName?: string;
        filterValue?: any;
    }
}
declare namespace _Ext {
    class InlineImageFormatter implements Slick.Formatter, Serenity.IInitializeColumn {
        format(ctx: Slick.FormatterContext): string;
        initializeColumn(column: Slick.Column): void;
        fileProperty: string;
        thumb: boolean;
        defaultImage: string;
        maxHeight: string;
        maxWidth: string;
    }
}
declare namespace _Ext {
    class InlineMultipleImageFormatter implements Slick.Formatter, Serenity.IInitializeColumn {
        format(ctx: Slick.FormatterContext): string;
        initializeColumn(column: Slick.Column): void;
        fileProperty: string;
        thumb: boolean;
        inlineUpload: boolean;
        defaultImage: string;
        maxHeight: string;
        maxWidth: string;
    }
}
declare namespace _Ext {
    class MonthYearFormatter implements Slick.Formatter {
        static format(val: string): string;
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace _Ext {
    class YesNoColoredFormatter implements Slick.Formatter {
        static format(val: any): string;
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace _Ext {
    class YesNoFormatter implements Slick.Formatter {
        static format(val: any): string;
        format(ctx: Slick.FormatterContext): string;
    }
}
declare namespace _Ext {
    class CardViewMixin<TItem> {
        private options;
        private dataGrid;
        private getId;
        private vm;
        private cardContainer;
        viewType: ('list' | 'card');
        constructor(options: CardViewMixinOptions<TItem>);
        switchView(viewType: ('grid' | 'card')): void;
        updateCardItems(): void;
        resizeCardView(): void;
    }
    interface CardViewMixinOptions<TItem> {
        grid: Serenity.DataGrid<TItem, any>;
        containerTemplate?: string;
        itemTemplate?: string;
        methods?: any;
        itemCssClass?: string;
        defaultViewType?: ('list' | 'card');
        itemsCssStyle?: string;
        itemCssStyle?: string;
    }
}
declare namespace _Ext {
    /**
     * A mixin that can be applied to a DataGrid for excel style filtering functionality
     */
    class HeaderFiltersMixin<TItem> {
        private options;
        private dataGrid;
        constructor(options: HeaderFiltersMixinOptions<TItem>);
    }
    interface HeaderFiltersMixinOptions<TItem> {
        grid: Serenity.DataGrid<TItem, any>;
    }
}
declare namespace _Ext {
    /**
     * A mixin that can be applied to a DataGrid for tree functionality
     */
    class TreeGridMixin<TItem> {
        private options;
        private dataGrid;
        private getId;
        constructor(options: TreeGridMixinOptions<TItem>);
        /**
         * Expands / collapses all rows in a grid automatically
         */
        toggleAll(): void;
        expandAll(): void;
        collapsedAll(): void;
        /**
         * Reorders a set of items so that parents comes before their children.
         * This method is required for proper tree ordering, as it is not so easy to perform with SQL.
         * @param items list of items to be ordered
         * @param getId a delegate to get ID of a record (must return same ID with grid identity field)
         * @param getParentId a delegate to get parent ID of a record
         */
        static applyTreeOrdering<TItem>(items: TItem[], getId: (item: TItem) => any, getParentId: (item: TItem) => any): TItem[];
        static filterById<TItem>(item: TItem, view: Slick.RemoteView<TItem>, idProperty: any, getParentId: (x: TItem) => any): boolean;
        static treeToggle<TItem>(getView: () => Slick.RemoteView<TItem>, getId: (x: TItem) => any, formatter: Slick.Format): Slick.Format;
        static toggleClick<TItem>(e: JQueryEventObject, row: number, cell: number, view: Slick.RemoteView<TItem>, getId: (x: TItem) => any): void;
    }
    interface TreeGridMixinOptions<TItem> {
        grid: Serenity.DataGrid<TItem, any>;
        idField?: string;
        getParentId: (item: TItem) => any;
        toggleField: string;
        initialCollapse?: () => boolean;
    }
}
declare namespace _Ext {
    interface ExcelExportOptions {
        grid: Serenity.DataGrid<any, any>;
        service: string;
        onViewSubmit: () => boolean;
        editRequest?: (request: Serenity.ListRequest) => Serenity.ListRequest;
        title?: string;
        hint?: string;
        separator?: boolean;
    }
    namespace ExcelExportHelper {
        function createToolButton(options: ExcelExportOptions): Serenity.ToolButton;
    }
}
declare var jsPDF: any;
declare namespace _Ext {
    interface PdfExportOptions {
        grid: Serenity.DataGrid<any, any>;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
        reportTitle?: string;
        titleTop?: number;
        titleFontSize?: number;
        fileName?: string;
        pageNumbers?: boolean;
        columnTitles?: {
            [key: string]: string;
        };
        tableOptions?: jsPDF.AutoTableOptions;
        output?: string;
        autoPrint?: boolean;
    }
    namespace PdfExportHelper {
        function exportToPdf(options: PdfExportOptions): void;
        function createToolButton(options: PdfExportOptions): Serenity.ToolButton;
    }
}
declare namespace Slick {
    interface RemoteView<TEntity> {
        getGroups(): Slick.Group<TEntity>[];
        getGrouping(): Slick.GroupInfo<TEntity>[];
    }
}
declare namespace _Ext {
    interface ReportExecuteOptions {
        reportKey: string;
        download?: boolean;
        extension?: 'pdf' | 'htm' | 'html' | 'xlsx' | 'docx';
        getParams?: () => any;
        params?: {
            [key: string]: any;
        };
        target?: string;
    }
    interface ReportButtonOptions extends ReportExecuteOptions {
        title?: string;
        cssClass?: string;
        icon?: string;
    }
    namespace ReportHelper {
        function createToolButton(options: ReportButtonOptions): Serenity.ToolButton;
        function execute(options: ReportExecuteOptions): void;
    }
}
declare namespace _Ext.DialogUtils {
    function pendingChangesConfirmation(element: JQuery, hasPendingChanges: () => boolean): void;
}
declare function loadScriptAsync(url: any, callback: any): void;
declare function loadScript(url: any): void;
declare function usingVuejs(): void;
declare function includeBootstrapColorPickerCss(): void;
declare function usingBootstrapColorPicker(): void;
declare function includeJqueryUITimepickerAddonCss(): void;
declare function usingJqueryUITimepickerAddon(): void;
declare function usingBabylonjs(): void;
declare function usingChartjs(): void;
declare function includeCustomMarkerCss(): void;
declare function usingCustomMarker(): void;
declare function includeGoogleMap(callback?: Function, callbackFullName?: string): void;
declare function includeMarkerWithLabel(): void;
declare function includeVisCss(): void;
declare function usingVisjs(): void;
declare function usingSlickGridEditors(): void;
declare function usingSlickAutoColumnSize(): void;
declare function usingSlickHeaderFilters(): void;
declare namespace q {
    function sum(xs: any[], key: any): any;
    function groupBy(xs: any[], key: any): any;
    function sortBy<T>(xs: T[], key: any): T[];
    function sortByDesc<T>(xs: T[], key: any): T[];
}
declare namespace q {
    function nextTick(date: any): Date;
    function addMinutes(date: Date, minutes: number): Date;
    function addHours(date: Date, hours: number): Date;
    function getHours(fromDate: Date, toDate: Date): number;
    function getDays24HourPulse(fromDate: Date, toDate: Date): number;
    function getDays(pFromDate: Date, pToDate: Date): number;
    function getMonths(fromDate: Date, toDate: Date): number;
    function getCalenderMonths(fromDate: Date, toDate: Date): number;
    function getCalenderMonthsCeil(fromDate: Date, toDate: Date): number;
    function addDays(date: Date, days: number): Date;
    function addMonths(date: Date, months: number): Date;
    function addYear(date: Date, years: number): Date;
    function getPeriods(fromDate: Date, toDate: Date, periodUnit: _Ext.TimeUoM): number;
    function addPeriod(date: Date, period: number, periodUnit: _Ext.TimeUoM): Date;
    function formatISODate(date: Date): string;
    function bindDateTimeEditorChange(editor: any, handler: any): void;
    function setMinDate(editor: Serenity.DateEditor, value: Date): void;
    function setMaxDate(editor: Serenity.DateEditor, value: Date): void;
    function initDateRangeEditor(fromDateEditor: Serenity.DateEditor, toDateEditor: Serenity.DateEditor, onChangeHandler?: (e: JQueryEventObject) => void): void;
    function initDateTimeRangeEditor(fromDateTimeEditor: _Ext.DateTimePickerEditor, toDateTimeEditor: _Ext.DateTimePickerEditor, onChangeHandler?: (e: JQueryEventObject) => void): void;
    function formatDate(d: Date | string, format?: string): string;
}
declare namespace q {
    function initDetailEditor(dialog: _Ext.DialogBase<any, any>, editor: _Ext.GridEditorBase<any>, options?: ExtGridEditorOptions): void;
    function setGridEditorHeight(editor: JQuery, heightInPx: number): void;
    function addNotificationIcon(editor: Serenity.Widget<any>, isSuccess: boolean): void;
    function addPopoverIcon(editor: Serenity.Widget<any>, isSuccess: boolean, popoverOptions: any): void;
    function setEditorLabel(editor: Serenity.Widget<any>, value: string): void;
    function hideEditorLabel(editor: Serenity.Widget<any>): void;
    function setEditorCategoryLabel(editor: Serenity.Widget<any>, value: string): void;
    function hideEditorCategory(editor: Serenity.Widget<any>, value?: boolean): void;
    function hideCategories(containerElement: JQuery, value?: boolean): void;
    function hideFields(containerElement: JQuery, value?: boolean): void;
    function hideFieldsAndCategories(containerElement: JQuery, value?: boolean): void;
    function hideField(editor: Serenity.Widget<any>, value?: boolean): void;
    function showField(editor: Serenity.Widget<any>, value?: boolean): void;
    function showAndEnableField(editor: Serenity.Widget<any>): void;
    function showFieldAndCategory(editor: Serenity.Widget<any>, value?: boolean): void;
    function hideEditorTab(editor: Serenity.Widget<any>, value?: boolean): void;
    function disableEditorTab(editor: Serenity.Widget<any>, value?: boolean): void;
    function readOnlyEditorTab(editor: Serenity.Widget<any>, value?: boolean): void;
    function readOnlyEditorCategory(editor: Serenity.Widget<any>, value?: boolean): void;
    function readonlyEditorCategory($editor: JQuery, value?: boolean): void;
    function readOnlyEditorPropertyGrid(editor: Serenity.Widget<any>, value?: boolean): void;
    function readonlyEditorPropertyGrid($editor: JQuery, value?: boolean): void;
    function readOnlyEditor(editor: Serenity.Widget<any>, value?: boolean): void;
    function readonlyEditor($editor: JQuery, value?: boolean): void;
    function moveEditorFromTab(editor: Serenity.Widget<any>, toElement: JQuery, isPrepend?: boolean): void;
    function moveEditorCategoryFromTab(editor: Serenity.Widget<any>, toElement: JQuery, isPrepend?: boolean): void;
    function selectEditorTab(editor: Serenity.Widget<any>): void;
}
declare namespace q {
    function getEnumText(enumTypeOrKey: any, value: any): string;
    function isNumber(value: any): boolean;
    function getEnumValues(enumType: any): number[];
    function getEnumKeys(enumType: any): string[];
}
declare namespace q {
    function switchKeybordLayout($container: any, layout: any): void;
}
declare namespace q {
    function text(key: string, fallback: string): string;
    function isCosmicThemeApplied(): boolean;
    function getSelectedLanguage(): string;
    function isBanglaMode(): boolean;
    function formatDecimal(value: any): string;
    function formatInt(value: any): string;
    function ToNumber(value: any): number;
    function ToFixed(value: any, fractionDigits?: number): string;
    function ToBool(value: any): boolean;
    function getRandomColor(hexLetters: any): string;
}
declare namespace SAPWebPortal.Default {
    class CardCodeValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class UserDetail2Columns {
        static columnsKey: string;
    }
}
declare namespace SAPWebPortal.Default {
    interface UserDetail2Form {
        UserDId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        UserCode: Serenity.StringEditor;
        UserName: Serenity.StringEditor;
        DbName: Serenity.StringEditor;
        SalesPersonCode: Serenity.StringEditor;
        SalesPersonName: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
    }
    class UserDetail2Form extends Serenity.PrefixedContext {
        static formKey: string;
        private static init;
        constructor(prefix: string);
    }
}
declare namespace SAPWebPortal.Default {
    namespace UserDetail2Service {
        const baseUrl = "Default/UserDetail2";
        function Create(request: Serenity.SaveRequest<UserDetail2Row>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserDetail2Row>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserDetail2Row>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserDetail2Row>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        const enum Methods {
            Create = "Default/UserDetail2/Create",
            Update = "Default/UserDetail2/Update",
            Delete = "Default/UserDetail2/Delete",
            Retrieve = "Default/UserDetail2/Retrieve",
            List = "Default/UserDetail2/List"
        }
    }
}
declare namespace SAPWebPortal.Default {
    class AutherizedSalesPersonEditor extends _Ext.GridEditorBase<UserDetail2Row> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDetail2Dialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class SalesPersonValuesEditor extends Serenity.Select2Editor<any, any> {
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    class UserDetail2Dialog extends _Ext.EditorDialogBase<UserDetail2Row> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: UserDetail2Form;
        static Form: UserDetail2Form;
        constructor();
        protected afterLoadEntity(): void;
    }
}
declare namespace SAPWebPortal.Default {
    class UserDetail2Grid extends Serenity.EntityGrid<UserDetail2Row, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDetail2Dialog;
        protected getIdProperty(): string;
        protected getInsertPermission(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace SAPWebPortal.Default {
    interface UserDetail2Row {
        Id?: number;
        UserDId?: number;
        UserId?: number;
        UserCode?: string;
        UserName?: string;
        DbName?: string;
        SalesPersonCode?: string;
        SalesPersonName?: string;
        Active?: string;
    }
    namespace UserDetail2Row {
        const idProperty = "Id";
        const nameProperty = "UserCode";
        const localTextPrefix = "Default.UserDetail2";
        const deletePermission = "Administration:General";
        const insertPermission = "Administration:General";
        const readPermission = "Administration:General";
        const updatePermission = "Administration:General";
        const enum Fields {
            Id = "Id",
            UserDId = "UserDId",
            UserId = "UserId",
            UserCode = "UserCode",
            UserName = "UserName",
            DbName = "DbName",
            SalesPersonCode = "SalesPersonCode",
            SalesPersonName = "SalesPersonName",
            Active = "Active"
        }
    }
}
declare namespace SAPWebPortal.Orders.Document {
    class AddressListEditor extends Serenity.Select2Editor<any, any> {
        static dropdownfields: Array<string>;
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery, opt?: any);
    }
}
