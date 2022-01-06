sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",

], function (Controller, JSONModel) {
	"use strict";

	return Controller.extend("sap.ui.CrudSap.Controller.edit", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("edit").attachPatternMatched(this.fetchTeste, this);
		},
		getDadosUsuarioModel: function () {
			return this.getView().getModel("dadosUsuario").getData();

		},

		fetchTeste: async function (oEvent) {
			window.tela = this;
			this.Id = oEvent.getParameter("arguments").data
			data: { id: this.Id };

			const DadosUsuarios = await fetch(`/api/Cliente/${this.Id}`);
			const dadosUsuario = await DadosUsuarios.json()
			const jsonModel = new JSONModel(dadosUsuario)
			this.getView().setModel(jsonModel, "dadosUsuario")
			console.log(dadosUsuario);

			//_onObjectMatched: async function (oEvent) {
			//	this.Codigo = oEvent.getParameter("arguments").id;

			//	const dados = await fetch(/api/Cliente / ${ this.Codigo });
			//	const cliente = await dados.json();
			//	const oModel = new JSONModel(cliente);
			//	this.getView().setModel(oModel, "cliente");

			//},
		},
		onAlterarClient: async function () {
			let dadosUsuario = this.verificaSeOsCamposEstaoVazios(this.getDadosUsuarioModel());
			const uri = await fetch('/api/Cliente', {
				method: 'PUT',
				headers: {
					'Accept': 'application/json',
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(dadosUsuario)
			});
			console.log(dadosUsuario);
			const content = await uri.json();
			var oRouter = this.getOwnerComponent().getRouter();
			MessageBox.alert("Cliente alterado com sucesso!", {
				onClose: function () {
					oRouter.navTo("clienteLista", {}, true);
				}
			});
		},
		verificaSeOsCamposEstaoVazios: function (ModelDados) {
			let dadosUsuario = ModelDados;
			if (dadosUsuario.nomeClientes == null
				|| dadosUsuario.idadeClientes == null
			) {
				
				return null;
			}
			else {

				return ModelDados;
			}

		},
		onAddClient: function (oEvent) {
			var id = this.getView().byId("inId").getValue();
			var nome = this.getView().byId("inNome").getValue();
			var idade = this.getView().byId("inIdade").getValue();

			var validaNome = /[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$/

			if (nome == "" || !validaNome.test(nome)) {
				MessageBox.show("O nome não pode ficar em branco e NÃO deve conter números", {
					icon: MessageBox.Icon.ERROR,
					title: "Erro"
				})
				this.getView().byId("inNome").setValueState(sap.ui.core.ValueState.Error);
			}

			else if (idade == "" || idade <= 0 || idade > 122) {
				MessageBox.show("Insira uma idade válida", {
					icon: MessageBox.Icon.ERROR,
					title: "Erro"
				})
				this.getView().byId("inIdade").setValueState(sap.ui.core.ValueState.Error);
			}
			else {
				var dados = {
					idClientes: id,
					nomeClientes: nome,
					idadeClientes: idade
				}
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