module SandboxCore11 {

    $(function() {
        let view: PurchaseOrderView = {
            $addButton: $('#addButton'),
            $addPanel: $('#addPanel'),
            $addForm: $('#addForm'),
            $saveButton: $('#saveButton')
        }

        new PurchaseOrderCreate(view);
    });

    interface PurchaseOrderView {
        $addButton: JQuery,
        $addPanel: JQuery,
        $addForm: JQuery,
        $saveButton: JQuery
    }

    class PurchaseOrderCreate {
        constructor(private view: PurchaseOrderView) {
            this.initialize();
        }

        public add(): void {
            console.log("Add");
            this.toggleAddPanel(true);
        }

        private initialize(): void {
            this.view.$addButton.on("click", () => this.add());
            this.view.$saveButton.on("click", () => this.save());
        }

        public save(): void {
            console.log("Save");
            this.toggleAddPanel(false);
        }

        private toggleAddPanel(show: boolean): void {
            this.view.$addPanel.toggle(show);
        }
    }
}
