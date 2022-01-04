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
			const dados = await DadosUsuarios.json()
			const jsonModel = new JSONModel({DadosUsuarios : dados })
			this.getView().setModel(jsonModel, "dados")
			console.log(dados);
		},
		onPress: function (oEvent) {
			var oItem = oEvent.getSource();
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("detail", {
				invoicePath: window.encodeURIComponent(oItem.getBindingContext("invoice").getPath().substr(1))
			});
		},

	});
});
