sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
], function (Controller, JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.CrudSap.Controller.ClienteLista", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("overview").attachPatternMatched(this.fetchTeste, this);
		},
		

		fetchTeste: async function () {
		
			const DadosUsuarios = await fetch(`/api/Cliente/Inicio`);
			const teste = await DadosUsuarios.json()
			const jsonModel = new JSONModel(teste)
			this.getView().setModel(jsonModel, "teste")

		},

	});
});
