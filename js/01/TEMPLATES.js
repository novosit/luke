module.exports = { 
		REFERENCE: "using %reference%;",

		NAMESPACE: "namespace %namespace%",

		CLASS_NAME: "%visibility% class %name%",
		CLASS_DESCRIPTION: "        \/\/\/ <summmary>\r\n        \/\/\/ %description%\r\n        \/\/\/ </summary>",

		FIELD: "                %visibility% %type% %name%;",

		PROPERTY_DESCRIPTION: "                \/\/\/ <summmary>\r\n                \/\/\/ %description%\r\n                \/\/\/ </summary>",
		PROPERTY:
		"%description%"+
		"                %visibility% %type% %name%\r\n"+
		"                {\r\n"+
		"                        get { return %field%; }\r\n"+
		"                }\r\n",	

		PROPERTY_MUTABLE:
		"%description%"+
		"                %visibility% %type% %name% { get; set; }\r\n",

		CONSTRUCT:
		"                %visibility% %name%(%arguments%)\r\n"+
		"                {\r\n"+
		"%field_setters%\r\n"+
		"                }\r\n",

		PARAMETER: "%type% %name%",

		SETTER: "this.%field% = %field%;",

		FILE:
		"%references%\r\n\r\n"+

		"%namespace%\r\n"+
		"{\r\n"+
		"%classDescription%\r\n"+
		"        %className%\r\n"+
		"        {\r\n"+
		"%fields%"+

		"%properties%"+

		"%construct%"+
		"        }\r\n"+
		"}",
};
