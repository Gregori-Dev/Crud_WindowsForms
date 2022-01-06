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
			oRouter.getRoute("overview").attachPatternMatched(this.fetchTeste, this);
		},
		

		fetchTeste: async function () {
		
			const DadosUsuarios = await fetch(`/api/Cliente/Inicio`);
			const dadosUsuario = await DadosUsuarios.json()
			const jsonModel = new JSONModel({ DadosUsuarios: dadosUsuario })
			this.getView().setModel(jsonModel, "dadosUsuario")
			console.log(dadosUsuario);
		},
		onFilterInvoices: function (oEvent) {

			// build filter array
			var aFilter = [];
			var sQuery = oEvent.getParameter("query");
			if (sQuery) {
				aFilter.push(new Filter("nomeClientes", FilterOperator.Contains, sQuery));
			}

			// filter binding
			var oList = this.byId("clienteLista");
			var oBinding = oList.getBinding("items");
			oBinding.filter(aFilter);
		},
		onEdit: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("dadosUsuario");
			var selectedDados = bindingContext.getObject();
			var IdView = selectedDados.idClientes;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("edit", {
				data : IdView
			});
			//codigo: window.encodeURIComponent(oItem.getBindingContext("cliente").getProperty("codigo"))
		},

	});
});
