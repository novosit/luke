/*
 * CodeGenerator.js
 *
 * @author Ronald Rey Lovera
 * @contact reyronald@gmail.com
 * @date August 13, 2015
 */

var changeCase = require('change-case');
var TEMPLATES = require('./TEMPLATES.js');

var CodeGenerator = (function () {
  // Public functions
  CodeGenerator.prototype = {
    getFile: getFile,
  };

  // Public static functions
  CodeGenerator.get = get;

  // Private properties
  var file = '';
  var ingredients = {};

  // Private constant properties
  const ALLOWED_TYPES = {
    'integer': 'Int32',
    'float': 'float',
    'double': 'Double',
    'string': 'String',
    'datetime': 'DateTime',
    'boolean': 'Boolean',
  };

  return CodeGenerator;

  //////////////////////

  // Public static functions
  function get(input) {
    return new CodeGenerator(input).getFile();
  }

  // Public functions
  function CodeGenerator(input) {
    var mutable = typeof input.mutable === 'undefined' ? false : input.mutable;
    for (var i in input.properties) {
      // Determining current property's mutability nature based on problem's specification.
      // We're doing this here in the constructor so we don't have to recalculate these 
      // values each time when we are dealing with building the actual 
      // fields, properties and parameters' strings for the code in the output result.
      // Also, setting the defaults if not specified in the input.
      var mutability = typeof input.properties[i].mutability === 'undefined' ? true : input.properties[i].mutability;
      input.properties[i].visible = !mutable || (mutable && !mutability) ? false : true;

      // Taking a further advantage of our loop to format the string 
      // of the type, taking into account its cardinality. 
      input.properties[i].finalType = ALLOWED_TYPES[input.properties[i].type.toLowerCase()];
      if (typeof input.properties[i].cardinality !== 'undefined' && input.properties[i].cardinality === 'many')
        input.properties[i].finalType = 'System.Collections.Generic.IList<' + input.properties[i].finalType + '>';
    }

    ingredients = {
      references: TEMPLATES.REFERENCE.replace(/%reference%/, 'System'),

      namespace: TEMPLATES.NAMESPACE.replace(/%namespace%/, input.namespace),

      className: TEMPLATES.CLASS_NAME
        .replace(/%visibility%/, typeof input.visibility === 'undefined' ? 'public' : input.visibility)
        .replace(/%name%/, changeCase.pascalCase(input.name)),

      classDescription: TEMPLATES.CLASS_DESCRIPTION.replace(/%description%/, input.description),

      fields: getFields(input),

      properties: getProperties(input),

      construct: getConstructor(input),
    };

    file = TEMPLATES.FILE
      .replace(/%references%/, ingredients.references)
      .replace(/%namespace%/, ingredients.namespace)
      .replace(/%classDescription%/, ingredients.classDescription)
      .replace(/%className%/, ingredients.className)
      .replace(/%fields%/, ingredients.fields.join("\r\n"))
      .replace(/%properties%/, ingredients.properties.join("\r\n"))
      .replace(/%construct%/, ingredients.construct);
  }

  function getFile() {
    return file;
  }

  // Private functions
  function getFields(input) {
    var fields = [];
    for (var i in input.properties) {
      // No need to declare a field if the property is mutable.
      if (!input.properties[i].visible)
        fields.push(TEMPLATES.FIELD
          .replace(/%visibility%/, 'private readonly')
          .replace(/%type%/, input.properties[i].finalType)
          .replace(/%name%/, input.properties[i].name)
        );
    }

    // For formatting purposes
    if (fields.length > 0)
      fields[fields.length - 1] += "\r\n\r\n";

    return fields;
  }

  function getProperties(input) {
    var props = [];
    for (var i in input.properties) {
      var template = !input.properties[i].visible ? TEMPLATES.PROPERTY : TEMPLATES.PROPERTY_MUTABLE;

      var prop =
        template
          .replace(/%visibility%/, typeof input.properties[i].visibility === 'undefined' ? 'public' : input.properties[i].visibility)
          .replace(/%type%/, input.properties[i].finalType)
          .replace(/%name%/, changeCase.pascalCase(input.properties[i].name))
          .replace(/%field%/, input.properties[i].name);

      // Does it have a description ?
      prop = typeof input.properties[i].description !== 'undefined' ?
        prop.replace(/%description%/, TEMPLATES.PROPERTY_DESCRIPTION.replace(/%description%/, input.properties[i].description) + "\r\n") :
        prop.replace(/%description%/, '');

      props.push(prop);
    }
    return props;
  }

  function getConstructor(input) {
    var parameters = [];
    var fields = [];
    for (var i in input.properties) {
      // Only the immutable properties are gonna be present in the constructor.
      if (!input.properties[i].visible) {
        parameters.push(
          TEMPLATES.PARAMETER
            .replace(/%type%/, input.properties[i].finalType)
            .replace(/%name%/, input.properties[i].name)
        );

        fields.push(
          "                        " + TEMPLATES.SETTER.replace(/%field%/g, input.properties[i].name)
        );
      }
    }

    // If all properties are mutable, 
    // then there is no need for a constructor.
    return fields.length > 0 ?
      "\r\n" + TEMPLATES.CONSTRUCT
        .replace(/%visibility%/, 'public')
        .replace(/%name%/, changeCase.pascalCase(input.name))
        .replace(/%arguments%/, parameters.join(", "))
        .replace(/%field_setters%/, fields.join("\r\n")) : '';
  }

})();

module.exports = CodeGenerator;
