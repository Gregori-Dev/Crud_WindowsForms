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
			const nomeDaPrimeiraRota = "edit";
			const nomeDaSegundaRota = "cadastrar";
			oRouter.getRoute(nomeDaPrimeiraRota).attachPatternMatched(this.aoCoincidirComARotaDeAtualizar, this);
			oRouter.getRoute(nomeDaSegundaRota).attachPatternMatched(this.aoCoincidirComARotaDeCadastrar, this);
		},

		receberDadosUsuarioDaModelo: function () {
			return this.getView().getModel("dadosUsuario").getData();
		},

		aoCoincidirComARotaDeAtualizar: async function (oEvent) {
			this.data = oEvent.getParameter("arguments").data;
			const DadosUsuarios = await fetch(`/api/Cliente/${this.data}`);
			const dadosUsuario = await DadosUsuarios.json();
			const oModel = new JSONModel(dadosUsuario);
			this.getView().setModel(oModel, "dadosUsuario");

			if (!cliente.nome) {
				var oRouter = this.getOwnerComponent().getRouter();
				const nomeDaRota = "listagemName";
				oRouter.navTo(nomeDaRota, {}, true);
			}
		},
		
		aoCoincidirComARotaDeCadastrar: async function (oEvent) {
			var oModel = new JSONModel()
			this.getView().setModel(oModel, "dadosUsuario");
		},

		emAlterarCliente: async function (ModelDados) {
			let dadosUsuario = this.verificaSeOsCamposEstaoVazios(this.receberDadosUsuarioDaModelo());
			if (dadosUsuario.idClientes == null) {

				const uri = await fetch('https://localhost:44364/api/Cliente/cadastrar', {
					method: 'POST',
					headers: {
						'Accept': 'application/json',
						'Content-Type': 'application/json'
					},
					body: JSON.stringify(dadosUsuario)
				});

				var oRouter = this.getOwnerComponent().getRouter();
				MessageBox.alert("Cliente cadastrado com sucesso!", {
					onClose: function () {
						const nomeDaRota = "overview";
						oRouter.navTo(nomeDaRota, {}, true);
					}
				});
			}
			else {
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
						const nomeDaRota = "overview";
						oRouter.navTo(nomeDaRota, {}, true);
					}
				});
			}
		},

		verificaSeOsCamposEstaoVazios: function (ModelDados) {
			let dadosUsuario = ModelDados;
			var validaNome = /[^a-zà-ú]/gi;

			if (dadosUsuario.nomeClientes == "" || validaNome.test(dadosUsuario.nomeClientes)) {
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

		emBarraDeRetorno: function () {
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();

			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				const nomeDaRota = "overview"
				oRouter.navTo(nomeDaRota, {}, true);
			}
		},
	})
});