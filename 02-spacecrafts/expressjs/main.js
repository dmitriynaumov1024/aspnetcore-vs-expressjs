console.log("Hello there, this script is useless, use npm run server\n")

import Spacecraft from "./src/models/Spacecraft.js"

var sa = Spacecraft.factory(4)
console.log(sa)
