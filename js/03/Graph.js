/*
 * Graph.js
 *
 * @author Ronald Rey Lovera
 * @contact reyronald@gmail.com
 * @date August 13, 2015
 */

var Graph = (function () {
  // Public functions
  Graph.prototype = {
    shortestPath: shortestPath,
    pathCost: pathCost,
    getOutput: getOutput,
  };

  // Public static functions
  Graph.getGraphDataFromInput = getGraphDataFromInput;

  // Private properties
  var start = end = null;
  var distances = [];
  var previous = [];

  return Graph;

  //////////////////////

	/*
	* Public static functions
	*/

  function getGraphDataFromInput(input) {
    var nodes = input[0].split(" ");
    var start = input[1][0];
    var end = input[1][2];

    var map = {};
    for (var i = 3; i < input.length; i++) {
      var fields = input[i].split(" ");
      if (typeof map[fields[0]] === 'undefined')
        map[fields[0]] = {};
      map[fields[0]][fields[1]] = Number(fields[2]);
    }
    return {
      nodes: nodes,
      start: start,
      end: end,
      map: map,
    }
  }

	/*
	* Public functions
	*/

  function Graph(nodes, map, _start, _end) {
    start = _start;
    end = _end;

    // Initialization
    for (var i in nodes) {
      distances[nodes[i]] = Infinity;
      previous[nodes[i]] = null;
    }
    distances[start] = 0;

    // Dijkstra Algorithm 
    var nodesQueue = nodes.slice(); // Array cloning. See http://jsperf.com/new-array-vs-splice-vs-slice/19
    while (nodesQueue) {
      var closestVertex = popClosestVertex(nodesQueue);

      // If there is no path to the current node, or the current node is the end
      if (closestVertex === null || closestVertex === end)
        break;

      for (var i in map[closestVertex]) {
        if (distances[i] > distances[closestVertex] + map[closestVertex][i]) {
          distances[i] = distances[closestVertex] + map[closestVertex][i];
          previous[i] = closestVertex;
        }
      }
    }
  }

  function shortestPath() {
    var next = end;
    var path = [next];

    if (!previous[next]) return [];

    while (next !== start) {
      next = previous[next];
      path.push(next)
    }
    return path.reverse();
  }

  function pathCost() {
    return distances[end];
  }

  function getOutput() {
    return this.shortestPath().length ?
      this.shortestPath().join(" ") + "\r\n\r\n" + this.pathCost() :
      "No path wass found from " + start + " to " + end + ".";
  }

	/*
	* Private functions
	*/

  function popClosestVertex(q) {
    var min = Infinity;
    var key = index = null;
    for (var i in q) {
      if (distances[q[i]] < min) {
        min = distances[q[i]];
        index = i;
        key = q[i];
      }
    }
    q.splice(index, 1);
    return key;
  }

})();

module.exports = Graph;
