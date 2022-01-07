sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",
	"sap/ui/core/routing/History",
], function (Controller, JSONModel, MessageBox, History) {
	"use strict";

	return Controller.extend("sap.ui.CrudSap.Controller.edit", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("edit").attachPatternMatched(this.RotaAtualizar, this);
			oRouter.getRoute("cadastrar").attachPatternMatched(this.RotaCadastrar, this);
		},
		getDadosUsuarioModel: function () {
			return this.getView().getModel("dadosUsuario").getData();

		},

		RotaAtualizar: async function (oEvent) {
			window.tela = this;
			this.Id = oEvent.getParameter("arguments").data
			data: { id: this.Id };

			const DadosUsuarios = await fetch(`/api/Cliente/${this.Id}`);
			const dadosUsuario = await DadosUsuarios.json()
			const jsonModel = new JSONModel(dadosUsuario)
			this.getView().setModel(jsonModel, "dadosUsuario")
			console.log(dadosUsuario);
		},
		RotaCadastrar: async function (oEvent) {
			var oModel = new JSONModel()
			this.getView().setModel(oModel, "dadosUsuario");

        },

		onAlterarClient: async function () {
			let dadosUsuario = this.verificaSeOsCamposEstaoVazios(this.getDadosUsuarioModel());
			if (dadosUsuario.idClientes == null) {

				const uri = await fetch('https://localhost:44364/api/Cliente/cadastrar', {
					method: 'POST',
					headers: {
						'Accept': 'application/json',
						'Content-Type': 'application/json'

					},

					body: JSON.stringify(dadosUsuario)

				});
				console.log(dadosUsuario)
				const content = await uri.json();
				var oRouter = this.getOwnerComponent().getRouter();
				MessageBox.alert("Cliente cadastrado com sucesso!", {
					onClose: function () {
						oRouter.navTo("overview", {}, true);
					}
				});
			}else {
				const uri = await fetch('/api/Cliente', {
					method: 'PUT',
					headers: {
						'Accept': 'application/json',
						'Content-Type': 'application/json'
					},
					body: JSON.stringify(dadosUsuario)
				});
				const content = await uri.json();
				var oRouter = this.getOwnerComponent().getRouter();
				MessageBox.alert("Cliente alterado com sucesso!", {
					onClose: function () {
						oRouter.navTo("overview", {}, true);
					}
				});

				}
		},
		verificaSeOsCamposEstaoVazios: function (ModelDados) {
			let dadosUsuario = ModelDados;
			var validaNome = /[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$/

			if (dadosUsuario.nomeClientes == "" || !validaNome.test(dadosUsuario.nomeClientes)) {
				MessageBox.show("O nome não pode ficar em branco e NÃO deve conter números", {
					icon: MessageBox.Icon.ERROR,
					title: "Erro"
				})
				this.getView().byId("dadosUsuario.nomeClientes").setValueState(sap.ui.core.ValueState.Error);
			}

			else if (dadosUsuario.idadeClientes == "" || dadosUsuario.idadeClientes <= 0 ||
				dadosUsuario.idadeClientes > 122) {
				MessageBox.show("Insira uma idade válida", {
					icon: MessageBox.Icon.ERROR,
					title: "Erro"
				})
				this.getView().byId("dadosUsuario.idadeClientes").setValueState(sap.ui.core.ValueState.Error);
			}
			else {

				return ModelDados;
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

    	//_onRouteMatched: function (oEvent) {
		//	var oArgs, sEmployeeID;
		//	oArgs = oEvent.getParameter("arguments");
		//	sEmployeeID = oArgs.EmployeeID;
		//	this.sPath = "/DadosUsuario('" + sEmployeeID + "')";
		//	this.oView.byId("IdPage").bindElement(this.sPath);
		//	 this._fetchJSONData(sProductPath);
		//},
			})
});