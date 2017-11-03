module SandboxCore11 {

    $(function() {
        let view: PurchaseOrderView = {
            addButtonSelector: '#addButton',
            addPanelSelector: '#addPanel',
            addFormSelector: '#addForm',
            saveButtonSelector: '#saveButton',
            itemsTableBodySelector: '#itemsTableBody',
            itemTemplateSelector: '#itemTemplate',
            itemIdSelector: '.item-id',
            itemUnitPriceSelector: '.item-unit-price',
            itemQuantitySelector: '.item-quantity',
            itemTotalPriceSelector: '.item-total-price',
            productSearchButtonSelector: '#productSearchButton',
            productSearchPanelSelector: '#productSearchPanel',
            productSearchResultTemplate: '#searchResultTemplate',
            productSearchTableBody: '#productSearchTableBody'
        }

        new PurchaseOrderCreate(view);
    });

    interface PurchaseOrderView {
        addButtonSelector: string;
        addPanelSelector: string;
        addFormSelector: string;
        saveButtonSelector: string;
        itemsTableBodySelector: string;
        itemTemplateSelector: string;
        itemIdSelector: string;
        itemUnitPriceSelector: string,
        itemQuantitySelector: string,
        itemTotalPriceSelector: string,
        productSearchButtonSelector: string,
        productSearchPanelSelector: string,
        productSearchResultTemplate: string,
        productSearchTableBody: string
    }

    class PurchaseOrderCreate {
        constructor(private view: PurchaseOrderView) {
            this.initialize();
        }

        private addItem(): void {
            const $itemTemplate = $(this.view.itemTemplateSelector);
            const $itemTableBody = $(this.view.itemsTableBodySelector);

            const itemCount = $itemTableBody.data('item-count');

            const $clone = $itemTemplate.clone(true, true);

            const $appendedClone = $itemTableBody.append($clone.html());

            $appendedClone.find(this.view.itemIdSelector + ':last').attr('name', `purchaseOrderDetails[${itemCount}].inventoryItemId`);
            $appendedClone.find(this.view.itemUnitPriceSelector).last().attr('name', `purchaseOrderDetails[${itemCount}].unitPrice`);
            $appendedClone.find(this.view.itemQuantitySelector).last().attr('name', `purchaseOrderDetails[${itemCount}].quantity`);

            $itemTableBody.data('item-count', itemCount + 1);
        }

        private initialize(): void {
            $(this.view.addButtonSelector).on('click', () => this.addItem());
            $(this.view.saveButtonSelector).on('click', () => this.save());
            $(this.view.productSearchButtonSelector).on('click', () => this.search());
            $(this.view.itemsTableBodySelector).on('change', this.view.itemIdSelector, (event: Event) => this.populateItem(event));
            $(this.view.itemsTableBodySelector).on('keyup', this.view.itemQuantitySelector, (event: Event) => this.quantityChanged(event));

            this.addItem();
        }

        public populateItem(event: Event): void {
            const $item = $(event.target).closest('tr');
            const $unitPrice = $item.find(this.view.itemUnitPriceSelector);
            $unitPrice.val('14.99');

            this.updateTotal($item);
        }

        public save(): void {
            console.log('Save');
            this.toggleAddPanel(false);
        }

        private quantityChanged(event: Event): void {
            var $item = $(event.target).closest('tr');

            this.updateTotal($item);
        }

        private search(): void {
            const $productSearchResultTemplate = $(this.view.productSearchResultTemplate);
            const $itemTableBody = $(this.view.productSearchTableBody);

            const $clone = $productSearchResultTemplate.clone(true, true);

            const $appendedClone = $itemTableBody.append($clone.html());

        }

        private toggleAddPanel(show: boolean): void {
            $(this.view.addPanelSelector).toggle(show);
        }

        private updateTotal($item: JQuery): void {
            const $price = $item.find(this.view.itemUnitPriceSelector);
            const $quantity = $item.find(this.view.itemQuantitySelector);
            const $total = $item.find(this.view.itemTotalPriceSelector);

            $total.text(Number($price.val()) * Number($quantity.val()));
        }
    }
}
