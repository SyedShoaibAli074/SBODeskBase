namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerFormatter()
    export class UsersListFormatter implements Slick.Formatter {
        format(ctx: Slick.FormatterContext) {
            var idList = ctx.value as string[];
            if (!idList || !idList.length)
                return "";

			var byId = ReportsRow.getLookup().itemById;
            let z: ReportsRow;
            return idList.map(x => ((z = byId[x]) ? z.RptName : x )).join(", ");
        }
    }
}