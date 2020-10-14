"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GuardaRotas = void 0;
var core_1 = require("@angular/core");
core_1.Injectable({
    providedIn: 'root'
});
var GuardaRotas = /** @class */ (function () {
    function GuardaRotas(router) {
        this.router = router;
    }
    GuardaRotas.prototype.canActivate = function (route, state) {
        //this.router.navigate(['/login']);
        return true;
    };
    return GuardaRotas;
}());
exports.GuardaRotas = GuardaRotas;
//# sourceMappingURL=guarda.rotas.js.map