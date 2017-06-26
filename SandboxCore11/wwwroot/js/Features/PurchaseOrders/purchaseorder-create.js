var SandboxCore11;
(function (SandboxCore11) {
    $(function () {
        var view = {
            $addButton: $('#addButton'),
            $addPanel: $('#addPanel'),
            $addForm: $('#addForm'),
            $saveButton: $('#saveButton')
        };
        new PurchaseOrderCreate(view);
    });
    var PurchaseOrderCreate = (function () {
        function PurchaseOrderCreate(view) {
            this.view = view;
            this.initialize();
        }
        PurchaseOrderCreate.prototype.add = function () {
            console.log("Add");
            this.toggleAddPanel(true);
        };
        PurchaseOrderCreate.prototype.initialize = function () {
            var _this = this;
            this.view.$addButton.on("click", function () { return _this.add(); });
            this.view.$saveButton.on("click", function () { return _this.save(); });
        };
        PurchaseOrderCreate.prototype.save = function () {
            console.log("Save");
            this.toggleAddPanel(false);
        };
        PurchaseOrderCreate.prototype.toggleAddPanel = function (show) {
            this.view.$addPanel.toggle(show);
        };
        return PurchaseOrderCreate;
    }());
})(SandboxCore11 || (SandboxCore11 = {}));
//# sourceMappingURL=purchaseorder-create.js.map