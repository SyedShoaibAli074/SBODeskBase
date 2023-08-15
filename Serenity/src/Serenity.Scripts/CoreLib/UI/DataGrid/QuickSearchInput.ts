﻿import { isValue } from "../../Q/System";
import { text } from "../../Q/LocalText";
import { isEmptyOrNull, trim } from "../../Q/Strings";
import { PopupMenuButton } from "../Widgets/Toolbar";
import { Widget } from "../Widgets/Widget";

export interface QuickSearchField {
    name: string;
    title: string;
}

export interface QuickSearchInputOptions {
    typeDelay?: number;
    loadingParentClass?: string;
    filteredParentClass?: string;
    onSearch?: (p1: string, p2: string, p3: (p1: boolean) => void) => void;
    fields?: QuickSearchField[];
}

export class QuickSearchInput extends Widget<QuickSearchInputOptions> {
    private lastValue: string;
    private field: QuickSearchField;
    private fieldChanged: boolean;
    private timer: number;

    constructor(input: JQuery, opt: QuickSearchInputOptions) {
        super(input, opt);

        input.attr('title', text('Controls.QuickSearch.Hint'))
            .attr('placeholder', text('Controls.QuickSearch.Placeholder'));
        this.lastValue = trim(input.val() ?? '');

        var self = this;
        this.element.bind('keyup.' + this.uniqueName, function () {
            self.checkIfValueChanged();
        });

        this.element.bind('change.' + this.uniqueName, function () {
            self.checkIfValueChanged();
        });

        $('<span><i></i></span>').addClass('quick-search-icon')
            .insertBefore(input);

        if (isValue(this.options.fields) && this.options.fields.length > 0) {
            var a = $('<a/>').addClass('quick-search-field').attr('title',
                text('Controls.QuickSearch.FieldSelection')).insertBefore(input);

            var menu = $('<ul></ul>').css('width', '120px');

            for (var item of this.options.fields) {
                var field = { $: item };
                $('<li><a/></li>').appendTo(menu).children().attr('href', '#')
                    .text(item.title ?? '').click(function (e: any) {
                        e.preventDefault();
                        this.$this.fieldChanged = self.field !== this.field.$;
                        self.field = this.field.$;
                        this.$this.updateInputPlaceHolder();
                        this.$this.checkIfValueChanged();
                    }.bind({
                        field: field,
                        $this: this
                    }));
            }

            new PopupMenuButton(a, {
                positionMy: 'right top',
                positionAt: 'right bottom',
                menu: menu
            });

            this.field = this.options.fields[0];
            this.updateInputPlaceHolder();
        }

        this.element.bind('execute-search.' + this.uniqueName, e1 => {
            if (!!this.timer) {
                window.clearTimeout(this.timer);
            }
            this.searchNow(trim(this.element.val() ?? ''));
        });
    }

    protected checkIfValueChanged(): void {
        if (this.element.hasClass('ignore-change')) {
            return;
        }

        var value = this.get_value();
        if (value == this.lastValue && (!this.fieldChanged || isEmptyOrNull(value))) {
            this.fieldChanged = false;
            return;
        }

        this.fieldChanged = false;

        if (!!this.timer) {
            window.clearTimeout(this.timer);
        }

        var self = this;
        this.timer = window.setTimeout(function () {
            self.searchNow(value);
        }, this.options.typeDelay ?? 500);

        this.lastValue = value;
    }

    get_value() {
        return trim(this.element.val() ?? '');
    }

    get_field(): QuickSearchField {
        return this.field;
    }

    set_field(value: QuickSearchField): void {
        if (this.field !== value) {
            this.fieldChanged = true;
            this.field = value;
            this.updateInputPlaceHolder();
            this.checkIfValueChanged();
        }
    }

    protected updateInputPlaceHolder() {
        var qsf = this.element.prevAll('.quick-search-field');
        if (this.field) {
            qsf.text(this.field.title);
        }
        else {
            qsf.text('');
        }
    }

    public restoreState(value: string, field: QuickSearchField) {
        this.fieldChanged = false;
        this.field = field;
        var value = trim(value ?? '');
        this.element.val(value);
        this.lastValue = value;
        if (!!this.timer) {
            window.clearTimeout(this.timer);
            this.timer = null;
        }
        this.updateInputPlaceHolder();
    }

    protected searchNow(value: string) {
        this.element.parent().toggleClass(
            (this.options.filteredParentClass ?? 's-QuickSearchFiltered'), !!(value.length > 0));

        this.element.parent().addClass(this.options.loadingParentClass ?? 's-QuickSearchLoading')
                .addClass(this.options.loadingParentClass ?? 's-QuickSearchLoading');

        var done = (results: any) => {
            this.element.removeClass(this.options.loadingParentClass ?? 's-QuickSearchLoading')
            .parent().removeClass(this.options.loadingParentClass ?? 's-QuickSearchLoading');

            if (!results) {
                this.element.closest('.s-QuickSearchBar')
                    .find('.quick-search-icon i')
                    .effect('shake', { distance: 2 });
            }
        };

        if (this.options.onSearch != null) {
            this.options.onSearch(((this.field != null &&
                !isEmptyOrNull(this.field.name)) ? this.field.name : null), value, done);
        }
        else {
            done(true);
        }
    }
}