var SandboxCore11;
(function (SandboxCore11) {
    $(function () {
        var view = {
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
        };
        new PurchaseOrderCreate(view);
    });
    var PurchaseOrderCreate = (function () {
        function PurchaseOrderCreate(view) {
            this.view = view;
            this.initialize();
        }
        PurchaseOrderCreate.prototype.addItem = function () {
            var $itemTemplate = $(this.view.itemTemplateSelector);
            var $itemTableBody = $(this.view.itemsTableBodySelector);
            var itemCount = $itemTableBody.data('item-count');
            var $clone = $itemTemplate.clone(true, true);
            var $appendedClone = $itemTableBody.append($clone.html());
            $appendedClone.find(this.view.itemIdSelector + ':last').attr('name', "purchaseOrderDetails[" + itemCount + "].inventoryItemId");
            $appendedClone.find(this.view.itemUnitPriceSelector).last().attr('name', "purchaseOrderDetails[" + itemCount + "].unitPrice");
            $appendedClone.find(this.view.itemQuantitySelector).last().attr('name', "purchaseOrderDetails[" + itemCount + "].quantity");
            $itemTableBody.data('item-count', itemCount + 1);
        };
        PurchaseOrderCreate.prototype.initialize = function () {
            var _this = this;
            $(this.view.addButtonSelector).on('click', function () { return _this.addItem(); });
            $(this.view.saveButtonSelector).on('click', function () { return _this.save(); });
            $(this.view.productSearchButtonSelector).on('click', function () { return _this.search(); });
            $(this.view.itemsTableBodySelector).on('change', this.view.itemIdSelector, function (event) { return _this.populateItem(event); });
            $(this.view.itemsTableBodySelector).on('keyup', this.view.itemQuantitySelector, function (event) { return _this.quantityChanged(event); });
            this.addItem();
        };
        PurchaseOrderCreate.prototype.populateItem = function (event) {
            var $item = $(event.target).closest('tr');
            var $unitPrice = $item.find(this.view.itemUnitPriceSelector);
            $unitPrice.val('14.99');
            this.updateTotal($item);
        };
        PurchaseOrderCreate.prototype.save = function () {
            console.log('Save');
            this.toggleAddPanel(false);
        };
        PurchaseOrderCreate.prototype.quantityChanged = function (event) {
            var $item = $(event.target).closest('tr');
            this.updateTotal($item);
        };
        PurchaseOrderCreate.prototype.search = function () {
            var $productSearchResultTemplate = $(this.view.productSearchResultTemplate);
            var $itemTableBody = $(this.view.productSearchTableBody);
            var $clone = $productSearchResultTemplate.clone(true, true);
            var $appendedClone = $itemTableBody.append($clone.html());
        };
        PurchaseOrderCreate.prototype.toggleAddPanel = function (show) {
            $(this.view.addPanelSelector).toggle(show);
        };
        PurchaseOrderCreate.prototype.updateTotal = function ($item) {
            var $price = $item.find(this.view.itemUnitPriceSelector);
            var $quantity = $item.find(this.view.itemQuantitySelector);
            var $total = $item.find(this.view.itemTotalPriceSelector);
            $total.text(Number($price.val()) * Number($quantity.val()));
        };
        return PurchaseOrderCreate;
    }());
})(SandboxCore11 || (SandboxCore11 = {}));
//# sourceMappingURL=purchaseorder-create.js.map