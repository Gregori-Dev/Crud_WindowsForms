sap.ui.define([
	"sap/ui/core/ComponentContainer"
], function (ComponentContainer) {
	"use strict";

	new ComponentContainer({
		name: "sap.ui.CrudSap",
		settings: {
			id: "CrudSap"
		},
		async: true
	}).placeAt("content");
});