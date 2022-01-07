sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox"
], function (Controller, JSONModel, MessageBox) {
	"use strict";
	return Controller.extend("sap.ui.CrudSap.Controller.edit", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("cadastrar").attachPatternMatched(this.fetchTeste, this);
		},

		onAlterarClient: async function () {
			let dadosUsuario = this.verificaSeOsCamposEstaoVazios(this.getDadosUsuarioModel());
			if (dadosUsuario.idClientes == null) {

				const uri = await fetch('/api/Cliente', {
					method: 'POST',
					headers: {
						'Accept': 'application/json',
						'Content-Type': 'application/json'

					},

					body: JSON.stringify(dadosUsuario)

				});
				console.log(cliente)
				const content = await uri.json();
				var oRouter = this.getOwnerComponent().getRouter();
				MessageBox.alert("Cliente cadastrado com sucesso!", {
					onClose: function () {
						oRouter.navTo("overview", {}, true);
					}
				});
			} 
		},
		onNavBack: function () {
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("overview", {}, true);

			}


		},
	})
});