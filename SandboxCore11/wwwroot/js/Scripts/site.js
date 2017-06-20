var SandboxCore11;
(function (SandboxCore11) {
    var Message = (function () {
        function Message() {
        }
        Message.prototype.display = function (message) {
            console.log('Message' + message);
        };
        return Message;
    }());
    SandboxCore11.Message = Message;
})(SandboxCore11 || (SandboxCore11 = {}));
//# sourceMappingURL=site.js.map