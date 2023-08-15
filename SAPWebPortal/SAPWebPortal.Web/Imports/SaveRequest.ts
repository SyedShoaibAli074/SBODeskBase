namespace SAPWebPortal.Default.SaveRequest {
    export interface SaveRequest<TEntity> extends Serenity.SaveRequest<TEntity> {
        EntityId?: any;
        Entity?: TEntity;
        Localizations?: any;
        DBName?: string;
    }

}
