sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",
	"sap/ui/core/routing/History",
], function (Controller, JSONModel, MessageBox, History) {
	"use strict";

	return Controller.extend("sap.ui.CrudSap.Controller.delete", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("delete").attachPatternMatched(this.RotaDelete, this);
		},
		RotaDelete: async function (oEvent) {
			window.tela = this;
			this.Id = oEvent.getParameter("arguments").data
			data: { id: this.Id };

			const DadosUsuarios = await fetch(`/api/Cliente/${this.Id}`);
			const dadosUsuario = await DadosUsuarios.json()
			const jsonModel = new JSONModel(dadosUsuario)
			this.getView().setModel(jsonModel, "dadosUsuario")
			console.log(dadosUsuario);
		},
		onDeleteCliente: async function (oEvent) {
			const dadosUsuario = this.getView().getModel("dadosUsuario").getData();
			var oRouter = this.getOwnerComponent().getRouter();
			const uri = await fetch(`/api/Cliente/${dadosUsuario}`, {
				method: 'DELETE',
				headers: {
					'Accept': 'application/json',
					'Content-Type': 'application/json'
				},
			body: JSON.stringify(dadosUsuario)

		});
		console.log(dadosUsuario)
			const content = await uri.json();
		MessageBox.alert("Dados Deletado com sucesso!", {
			onClose: function () {
				oRouter.navTo("overview", {}, true);
			}
		});
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