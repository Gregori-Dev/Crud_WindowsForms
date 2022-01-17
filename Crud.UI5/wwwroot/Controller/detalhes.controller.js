sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",
	"sap/ui/core/routing/History",
], function (Controller, JSONModel, MessageBox, History) {
	"use strict";

	return Controller.extend("sap.ui.CrudSap.Controller.detalhes", {

		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			const nomeDaRota = "detalhes"
			oRouter.getRoute(nomeDaRota).attachPatternMatched(this.aoCoincidirComARotaDeDetalhes, this);
		},
		
		receberDadosUsuarioDaModelo: function () {
			return this.getView().getModel("dadosUsuario").getData();
		},

		aoCoincidirComARotaDeDetalhes: async function (oEvent) {
			this.Id = oEvent.getParameter("arguments").data
			data: { id: this.Id };

			const DadosUsuarios = await fetch(`/api/Cliente/${this.Id}`);
			const dadosUsuario = await DadosUsuarios.json()
			const jsonModel = new JSONModel(dadosUsuario)
			this.getView().setModel(jsonModel, "dadosUsuario")
		//	console.log(dadosUsuario);
		},
		
		emExcluirCliente: async function (oEvent) {
			const dadosUsuario = this.getView().getModel("dadosUsuario").getData();
			var oRouter = this.getOwnerComponent().getRouter();
			MessageBox.warning("Deseja realmente remover este cliente?.", {
				actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL],
				emphasizedAction: MessageBox.Action.OK,
				onClose: async function (sAction) {
					if (sAction === "OK") {
						
						const uri = await fetch(`/api/Cliente/${dadosUsuario}`, {
							method: 'DELETE',
							headers: {
								'Accept': 'application/json',
								'Content-Type': 'application/json'
							},
							body: JSON.stringify(dadosUsuario)
						});
						//console.log(dadosUsuario)
						MessageBox.alert("Dados Deletado com sucesso!", {
							onClose: function () {
								const nomeDaRota = "overview"
								oRouter.navTo(nomeDaRota, {}, true);

							}
						})
							} else {
								MessageToast.show("Operação cancelada");
					}
				}
			});
		},

		emBarraDeRetorno: function () {
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();
			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				const nomeDaRota = "overview";
				oRouter.navTo(nomeDaRota, {}, true);
			}
		},
		emEditar: function (oEvent) {
			var oRouter = this.getOwnerComponent().getRouter();
			const nomeDaRota = "edit";
			oRouter.navTo(nomeDaRota, {
				data: this.Id
			});
		},
	})
});