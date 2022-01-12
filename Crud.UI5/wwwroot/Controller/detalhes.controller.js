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
			oRouter.getRoute("detalhes").attachPatternMatched(this.RotaDetalhes, this);
		},

		getDadosUsuarioModel: function () {
			return this.getView().getModel("dadosUsuario").getData();
		},

		RotaDetalhes: async function (oEvent) {
			this.Id = oEvent.getParameter("arguments").data
			data: { id: this.Id };

			const DadosUsuarios = await fetch(`/api/Cliente/${this.Id}`);
			const dadosUsuario = await DadosUsuarios.json()
			const jsonModel = new JSONModel(dadosUsuario)
			this.getView().setModel(jsonModel, "dadosUsuario")
		//	console.log(dadosUsuario);
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
				//console.log(dadosUsuario)
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
		onEdit: function (oEvent) {
			//var bindingContext = oEvent.getSource().getBindingContext("dadosUsuario");
			//var selectedDados = bindingContext.getObject();
			//var IdView = selectedDados.idClientes;
			//var oRouter = this.getOwnerComponent().getRouter();
			//oRouter.navTo("edit", {
			//	data: IdView
			//});
			//var oItem = oEvent.getSource();
			//var oRouter = this.getOwnerComponent().getRouter();
			//var dadosUsuario = this.getView().getModel("dadosUsuario").getData();
			//oRouter.navTo("edit", {
			//	data: window.encodeURIComponent(dadosUsuario.data)
			//});
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("edit", {
				data: this.Id
			});
		},
	})
});