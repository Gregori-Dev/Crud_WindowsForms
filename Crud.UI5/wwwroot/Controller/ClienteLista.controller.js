sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/FilterOperator",
	"sap/ui/model/Filter",
], function (Controller, JSONModel, FilterOperator, Filter) {
	"use strict";

	return Controller.extend("sap.ui.CrudSap.Controller.clienteLista", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			const nomeDaRota = "overview";
			oRouter.getRoute(nomeDaRota).attachPatternMatched(this.aoCoincidirComARotaDeListaDeUsuario, this);
		},
		
		receberDadosUsuarioDaModelo: function () {
			return this.getView().getModel("dadosUsuario").getData();
		},

		aoCoincidirComARotaDeListaDeUsuario: async function () {
			const DadosUsuarios = await fetch(`/api/Cliente/Inicio`);
			const dadosUsuario = await DadosUsuarios.json()
			const jsonModel = new JSONModel({ DadosUsuarios: dadosUsuario })
			this.getView().setModel(jsonModel, "dadosUsuario")
		},

		emFiltroDeUsuario: function (oEvent) {
			var aFilter = [];
			var sQuery = oEvent.getParameter("query");
			if (sQuery) {
				aFilter.push(new Filter("nomeClientes", FilterOperator.Contains, sQuery));
			}
			var oList = this.byId("clienteLista");
			var oBinding = oList.getBinding("items");
			oBinding.filter(aFilter);
		},

		emDetalhes: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("dadosUsuario");
			var selectedDados = bindingContext.getObject();
			var IdView = selectedDados.idClientes;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("detalhes", {
				data : IdView
			});
		},

		emCadastrar: function () {;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("cadastrar")
		},

		emExcluir: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("dadosUsuario");
			var selectedDados = bindingContext.getObject();
			var IdView = selectedDados.idClientes;
			var oRouter = this.getOwnerComponent().getRouter();
			const nomeDaRota = "excluir";
			oRouter.navTo(nomeDaRota, {
				data: IdView
			});
      },
	});
});
